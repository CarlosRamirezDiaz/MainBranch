using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using System.IO;
using Microsoft.Xrm.Sdk;
using AmxPeruCommonLibrary.OptionSets;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Activities.Appointment;
using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.OrderItem;

namespace AmxPeruPSBActivities.Activities.OrderItem
{

    public sealed class AddRelevantPOToCart : XrmAwareCodeActivity
    {
        public InArgument<OrderItemAddShoppingCartModel> OrderItemShoppingCartModel { get; set; }

        public InOutArgument<Guid> OrderItemId { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var orderItemShoppingCartModel = OrderItemShoppingCartModel.Get(context);

            Guid offeringId = new Guid(orderItemShoppingCartModel.OfferingId);
            Guid parentOrderItemId = context.GetValue(OrderItemId);
            Guid orderCaptureId = new Guid(orderItemShoppingCartModel.OrderCaptureId);
            string srProductId = orderItemShoppingCartModel.SrProductId;

            if (!orderItemShoppingCartModel.FromServiceRegistry)
            {
                var associatedOfferings = (from association in dataContext.etel_offeringassociationSet
                                           join pProduct in dataContext.ProductSet on association.etel_primaryofferingid.Id equals pProduct.Id
                                           join sProduct in dataContext.ProductSet on association.etel_secondaryofferingid.Id equals sProduct.Id
                                           where association.etel_primaryofferingid.Id == offeringId
                                           select new { association, pProduct, sProduct }).ToList();

                var filteredAssociatedOfferings = associatedOfferings.Where(p =>
                                ((OptionSetValue)p.association.Attributes["amxperu_associationtypecode"]).Value.Equals(3) ||
                                ((OptionSetValue)p.association.Attributes["amxperu_associationtypecode"]).Value.Equals(12))
                                //                                ((OptionSetValue)p.association.Attributes["amxperu_associationtypecode"]).Value.Equals(4))
                                .Select(p => new
                                {
                                    p.association.etel_name,
                                    p.association.etel_primaryofferingid,
                                    p.association.etel_secondaryofferingid,
                                    ((OptionSetValue)p.sProduct.Attributes["amxperu_offertypecode"]).Value,
                                    p.sProduct.etel_productspecificationId,
                                    p.pProduct.etel_externalid,
                                    p.sProduct
                                });

                foreach (var item in filteredAssociatedOfferings)
                {
                    var t = (from cart in dataContext.etel_orderitemSet
                             where cart.etel_orderid.Id == orderCaptureId && cart.etel_offeringid == item.etel_secondaryofferingid
                             select cart).ToList();

                    // if PO is not in basket
                    if (t.Count == 0 || item.Value != 1 || orderItemShoppingCartModel.BasicOffering == "Mobile")
                    {
                        bool replaceEquipment = false;
                        bool addEquipment = true;
                        var willBeRemovedOrderItemId = new Guid();

                        if (item.Value == 1 && orderItemShoppingCartModel.BasicOffering != "Mobile") // if PO is an equipment 
                        {
                            // query basket to find an item with same PS of that item
                            var q = (from cart in dataContext.etel_orderitemSet
                                     join product in dataContext.ProductSet on cart.etel_offeringid.Id equals product.Id
                                     where cart.etel_orderid.Id == orderCaptureId &&
                                           product.etel_productspecificationId == item.etel_productspecificationId
                                     select new { product.ProductId, cart.Id }).FirstOrDefault();

                            // if there is same PS item in basket
                            if (q != null)
                            {
                                addEquipment = false;
                                // retrieving PO char use value of product in basket
                                QueryExpression charInUseQueryExpression = new QueryExpression("amxperu_productofferingcharuse");
                                charInUseQueryExpression.ColumnSet = new ColumnSet("amxperu_defaultvalue");
                                charInUseQueryExpression.Criteria.AddCondition("amxperu_name", ConditionOperator.BeginsWith, "Norma");
                                charInUseQueryExpression.Criteria.AddCondition("amxperu_productoffering", ConditionOperator.Equal, q.ProductId);
                                var POCharUseInBasket = ContextProvider.OrganizationService.RetrieveMultiple(charInUseQueryExpression).Entities.FirstOrDefault();

                                // retrieving PO char use value of product might need to be added to basket
                                charInUseQueryExpression = new QueryExpression("amxperu_productofferingcharuse");
                                charInUseQueryExpression.ColumnSet = new ColumnSet("amxperu_defaultvalue");
                                charInUseQueryExpression.Criteria.AddCondition("amxperu_name", ConditionOperator.BeginsWith, "Norma");
                                charInUseQueryExpression.Criteria.AddCondition("amxperu_productoffering", ConditionOperator.Equal, item.etel_secondaryofferingid.Id);
                                var POCharUseBeAddedToBasket = ContextProvider.OrganizationService.RetrieveMultiple(charInUseQueryExpression).Entities.FirstOrDefault();

                                if (POCharUseBeAddedToBasket != null && POCharUseInBasket != null &&
                                    int.Parse(POCharUseBeAddedToBasket.Attributes["amxperu_defaultvalue"].ToString()) > int.Parse(POCharUseInBasket.Attributes["amxperu_defaultvalue"].ToString()))
                                {
                                    replaceEquipment = true;
                                    willBeRemovedOrderItemId = q.Id;
                                }
                            }
                        }
                        if (item.Value != 1 || addEquipment || replaceEquipment)
                        {
                            var orderItem = new etel_orderitem()
                            {
                                etel_offeringid = item.etel_secondaryofferingid,
                                etel_orderid = new EntityReference("etel_ordercapture", orderCaptureId),
                                etel_parentorderitemid = new EntityReference("etel_orderitem", parentOrderItemId),
                            };
                            orderItem.Attributes["amx_action"] = new OptionSetValue((int)amx_orderitemaction.Add);
                            orderItem.Attributes["amx_offertypecode"] = new OptionSetValue(item.Value);
                            orderItem.Attributes["amx_family"] = orderItemShoppingCartModel.BasicOffering;

                            /////////////////////////////////////////////////////////////////////////////////////////////
                            //////////// PRICING ////////////////////////////////////////////////////////////////////////
                            var offeringList = new List<Entity>();
                            offeringList.Add(item.sProduct);
                            var offeringIds = new List<Guid>();
                            offeringIds.Add(item.etel_secondaryofferingid.Id);
                            var pricingBusiness = new PricingBusiness(ContextProvider);
                            var popList = pricingBusiness.RetrievePopListByOfferingId(offeringIds);
                            var charValues = pricingBusiness.RetrievePopConfigIdsByEstrato("3", offeringIds);
                            var offeringWithPrices = pricingBusiness.RetrieveOfferingsWithPrices(offeringList, popList, charValues, "");

                            if (offeringWithPrices.Count > 0)
                            {
                                if (offeringWithPrices[0].Recurring != null && offeringWithPrices[0].Recurring[0].Amount != null)
                                {
                                    orderItem.etel_recurringcharge = new Money(Convert.ToDecimal(offeringWithPrices[0].Recurring[0].Amount));
                                    orderItem.Attributes["amx_popexternalid"] = offeringWithPrices[0].Recurring[0].PopExternalId;
                                }

                                if (offeringWithPrices[0].OneTime != null && offeringWithPrices[0].OneTime[0].Amount != null)
                                {
                                    orderItem.etel_onetimecharge = new Money(Convert.ToDecimal(offeringWithPrices[0].OneTime[0].Amount));
                                    orderItem.Attributes["amx_popexternalid"] = offeringWithPrices[0].OneTime[0].PopExternalId;
                                }

                                var taxBusiness = new TaxBusiness(ContextProvider);
                                orderItem.Attributes["amx_taxes"] = taxBusiness.CalculateTax(orderItemShoppingCartModel);
                            }
                            /////////////////////////////////////////////////////////////////////////////////////////////

                            var createdOrderItemId = ContextProvider.OrganizationService.Create(orderItem);

                            CreateOrderResourceAndCharacteristics(item.sProduct.etel_productspecificationId.Id, createdOrderItemId);

                            if (replaceEquipment)
                            {
                                ContextProvider.OrganizationService.Delete(etel_orderitem.EntityLogicalName, willBeRemovedOrderItemId);
                            }
                        }
                    }
                }
            }

        }


        public void CreateOrderResourceAndCharacteristics(Guid productSpecificationId, Guid orderItemId)
        {
            var t = new QueryExpression("amxperu_productresourcecardinality");
            t.ColumnSet = new ColumnSet(true);
            t.Criteria.AddCondition("amxperu_productspecificationid", ConditionOperator.Equal, productSpecificationId);
            var cardinalities = ContextProvider.OrganizationService.RetrieveMultiple(t).Entities;
            Guid productResourceSpecId;
            if (cardinalities.Count > 0)
            {

                foreach (var cardinality in cardinalities)
                {
                    productResourceSpecId = new Guid(((EntityReference)cardinality.Attributes["amxperu_productresourcespecificationid"]).Id.ToString());
                    var orderResource = new etel_orderresource()
                    {
                        etel_name = cardinality.Attributes["amxperu_name"].ToString(),
                        etel_productresourcespecification = new EntityReference("etel_ordercapture", productResourceSpecId),
                        etel_orderitemid = new EntityReference("etel_orderitem", orderItemId),
                    };
                    var orderResourceId = ContextProvider.OrganizationService.Create(orderResource);

                    var query = new QueryExpression("amxperu_productresourcespec_resourcecharvalue")
                    {
                        NoLock = true,
                        ColumnSet = new ColumnSet(true),
                        Criteria = { Filters = { new FilterExpression { Conditions = {
                            new ConditionExpression("etel_productresourcespecificationid", ConditionOperator.Equal, productResourceSpecId) }
                    } } }
                    };

                    var resourceCharLink = new LinkEntity("amxperu_productresourcespec_resourcecharvalue", "amxperu_resourcecharacteristicvalue", "amxperu_resourcecharacteristicvalueid", "amxperu_resourcecharacteristicvalueid", JoinOperator.Inner);
                    resourceCharLink.EntityAlias = "ResourceCharVal";
                    resourceCharLink.Columns = new ColumnSet(true);
                    query.LinkEntities.Add(resourceCharLink);

                    var resourceCharValues = ContextProvider.OrganizationService.RetrieveMultiple(query).Entities;

                    if (resourceCharValues.Count > 0)
                    {
                        foreach (var resourceCharValue in resourceCharValues)
                        {
                            var id = new Guid(resourceCharValue.Attributes["amxperu_resourcecharacteristicvalueid"].ToString());
                            var resourceCharId = ((EntityReference)resourceCharValue.GetAttributeValue<AliasedValue>("ResourceCharVal.amxperu_resourcecharacteristicid").Value).Id;
                            var name = ((EntityReference)resourceCharValue.GetAttributeValue<AliasedValue>("ResourceCharVal.amxperu_resourcecharacteristicid").Value).Name.ToString();
                            var orderResourceCharacteristic = new etel_orderresourcecharacteric() {
                                etel_name = name,
                                etel_orderresourceid = new EntityReference("etel_orderresource", orderResourceId)
                            };
                            orderResourceCharacteristic.Attributes["amx_resource_characteristic"] = new EntityReference("amxperu_resourcecharacteristic", resourceCharId);
                            orderResourceCharacteristic.Attributes["amx_resource_characteristicvalue"] = new EntityReference("amxperu_resourcecharacteristicvalue", id);
                            ContextProvider.OrganizationService.Create(orderResourceCharacteristic);
                        }
                    }
                }

            }
        }
    }
}
