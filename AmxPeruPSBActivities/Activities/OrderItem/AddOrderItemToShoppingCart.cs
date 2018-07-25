using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.OrderItem;
using AmxPeruCommonLibrary.OptionSets;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class AddOrderItemToShoppingCart : XrmAwareCodeActivity
    {

        public InArgument<etel_ordercapture> OrderCapture { get; set; }

        public InArgument<OrderItemAddShoppingCartModel> OrderItemShoppingCartModel { get; set; }

        public InArgument<Nullable<DateTime>> ActivationStartDate { get; set; }

        public InArgument<Nullable<DateTime>> ActivationEndDate { get; set; }

        public InOutArgument<Guid> OrderItemId { get; set; }
        

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var orderCaptureEntity = OrderCapture.Get(context);
            var orderItemShoppingCartModel = OrderItemShoppingCartModel.Get(context);
            var offeringId = new Guid(orderItemShoppingCartModel.OfferingId);
            var parentOrderItemId = new Guid(orderItemShoppingCartModel.ParentOrderItemId);
            var addressId = new Guid(orderItemShoppingCartModel.AddressId);
            var activationStartDate = ActivationStartDate.Get(context);
            var activationEndDate = ActivationEndDate.Get(context);

            if (orderCaptureEntity.statuscode.Value == (int)etel_ordercapture_statuscode.Draft || orderCaptureEntity.statuscode.Value == (int)etel_ordercapture_statuscode.SubmittedwithErrors)
            {
                Guid parentOfferingId = Guid.Empty;
                var prod = (Product)ContextProvider.OrganizationService.Retrieve(Product.EntityLogicalName, offeringId, new ColumnSet(true));
                EntityReference prodReference = prod.ToEntityReference();
                prodReference.Name = prod.Name;

                var result = new etel_orderitem();
                result.etel_offeringid = prodReference;

                result.etel_orderid = new EntityReference(etel_ordercapture.EntityLogicalName, orderCaptureEntity.etel_ordercaptureId.Value);
                result.Attributes["amx_action"] = new OptionSetValue(int.Parse(orderItemShoppingCartModel.OrderItemAction));
                result.Attributes["amx_family"] = !orderItemShoppingCartModel.FromServiceRegistry ? orderItemShoppingCartModel.BasicOffering : "";

                if (parentOrderItemId != Guid.Empty)
                {
                    result.etel_parentorderitemid = new EntityReference(etel_orderitem.EntityLogicalName, parentOrderItemId);
                }
                else if (!string.IsNullOrEmpty(orderItemShoppingCartModel.SrParentPoId))
                {
                    parentOrderItemId = FindParentOrderItemId(dataContext, orderItemShoppingCartModel.SrParentPoId, orderCaptureEntity);

                    if (parentOrderItemId != Guid.Empty)
                        result.etel_parentorderitemid = new EntityReference(etel_orderitem.EntityLogicalName, parentOrderItemId);
                }

                if (prod.Attributes.Contains("amxperu_offertypecode"))
                {
                    result.Attributes["amx_offertypecode"] = prod.Attributes["amxperu_offertypecode"];
                }

                if (!string.IsNullOrEmpty(orderItemShoppingCartModel.SrProductId))
                {
                    result.Attributes["amx_productsrid"] = orderItemShoppingCartModel.SrProductId;
                }
                if (!string.IsNullOrEmpty(orderItemShoppingCartModel.RecurringPrice))
                {
                    result.etel_recurringcharge = new Money(Convert.ToDecimal(orderItemShoppingCartModel.RecurringPrice));
                }
                if (!string.IsNullOrEmpty(orderItemShoppingCartModel.OneTimePrice))
                {
                    result.etel_onetimecharge = new Money(Convert.ToDecimal(orderItemShoppingCartModel.OneTimePrice));
                }
                if (!string.IsNullOrEmpty(orderItemShoppingCartModel.PopExternalId))
                {
                    result.Attributes["amx_popexternalid"] = orderItemShoppingCartModel.PopExternalId; 
                }
                if (activationStartDate != null)
                {
                    result.Attributes["amx_activationstartdate"] = activationStartDate.Value;
                }
                if (activationEndDate != null)
                {
                    result.Attributes["amx_activationenddate"] = activationEndDate.Value;
                }

                if (parentOrderItemId != Guid.Empty && !orderItemShoppingCartModel.FromServiceRegistry)
                {
                    var taxBusiness = new TaxBusiness(ContextProvider);
                    result.Attributes["amx_taxes"] = taxBusiness.CalculateTax(orderItemShoppingCartModel);
                }

                result.Id = ContextProvider.OrganizationService.Create(result);

                //retrieve Charuse table for the offering, you will get the characteriscs of that offering
                //foreach charuse, create orderproductcharacterisctic entity
                var resultOfferingCharUse = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "amxperu_productofferingcharuse",
                    ColumnSet = new ColumnSet(true),
                    Criteria =
                        new FilterExpression
                        {
                            Conditions =
                                {
                                    new ConditionExpression(
                                        "amxperu_productoffering",
                                        ConditionOperator.Equal,
                                        offeringId)
                                }
                        }
                });

                foreach (var item in resultOfferingCharUse.Entities)
                {
                    var resultCharacteristic = (etel_productcharacteristic)ContextProvider.OrganizationService.Retrieve(etel_productcharacteristic.EntityLogicalName, ((EntityReference)item.Attributes["amxperu_characteristic"]).Id, new ColumnSet(true));
                    var orderitemchar = new etel_orderproductcharacteristic();
                    orderitemchar.etel_datatypecode = new OptionSetValue(resultCharacteristic.etel_datatype.Value);
                    orderitemchar.etel_orderitemid = new EntityReference(etel_orderitem.EntityLogicalName, result.Id);
                    orderitemchar.etel_characteristicid = new EntityReference("etel_productcharacteristic", resultCharacteristic.Id);
                    ContextProvider.OrganizationService.Create(orderitemchar);
                }

                GetProductSpeficiationResourceCardinality(prod.etel_productspecificationId.Id);

                OrderItemId.Set(context,result.Id);
            }
        }


        public Guid FindParentOrderItemId(XrmDataContext dataContext, string srParentPoId, etel_ordercapture orderCaptureEntity)
        {
            var itemList = (from cart in dataContext.etel_orderitemSet where cart.etel_orderid.Id == orderCaptureEntity.Id select cart).ToList();

            var parentOrderItemId = itemList.Where(t => (string)t.Attributes["amx_productsrid"] == srParentPoId)
                                        .Select(p => p.Id).FirstOrDefault();

            if (parentOrderItemId == Guid.Empty)
            {
                return FindParentOrderItemId(dataContext, srParentPoId, orderCaptureEntity);
            }

            return parentOrderItemId;
        }
        
        
        public void GetProductSpeficiationResourceCardinality(Guid productSpecificationId)
        {
            var t = new QueryExpression("amxperu_productresourcecardinality");
            t.Criteria.AddCondition("amxperu_productspecificationid", ConditionOperator.Equal, productSpecificationId);
            var cardinalities = ContextProvider.OrganizationService.RetrieveMultiple(t).Entities;
        }
    }

}