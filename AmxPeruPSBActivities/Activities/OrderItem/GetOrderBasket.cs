using AmxPeruCommonLibrary.OptionSets;
using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class GetOrderBasket : XrmAwareCodeActivity
    {
        public InArgument<string> OrderItemGuid { get; set; }
        public OutArgument<OrderItemsBasketModel> orderBasket { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            OrderItemsBasketModel _OrderItemsBasketModel = null;
            List<OrderBasketItemProdCharacteristic> _listOfOrderBasketItemProdCharacteristic = null;
            Guid OrderGuid = Guid.Empty;

            try
            {
                _OrderItemsBasketModel = new OrderItemsBasketModel();
                OrderBasketOrderItem _OrderBasketOrderItem = null;
                List<OrderBasketOrderItem> listOfOrderBasketItems = new List<OrderBasketOrderItem>();
                OrderGuid = new Guid(context.GetValue(this.OrderItemGuid));

                //Get the List of Order Items from the OrderItem entity via the Supplied OrderCaptureGuid
                QueryExpression etelOrderItems = new QueryExpression("etel_orderitem");
                etelOrderItems.ColumnSet = new ColumnSet(new string[] {"etel_offeringid"
                    , "etel_parentorderitemid"
                    , "amx_billingaccountexternalid"
                    , "amx_offertypecode"
                    , "amx_action"
                    , "amx_productsrid"
                    , "amx_taxes"
                    , "amx_family"
                    , "etel_recurringcharge"
                    , "etel_onetimecharge"
                    , "amx_activationstartdate"
                    , "amx_activationenddate"
                    , "amx_billingaccountexternalid"
                    , "etel_depositamount"
                    , "etel_extendedrecurringcharge"
                    , "etel_extendedonetimecharge"});
                
                etelOrderItems.Criteria = new FilterExpression();
                etelOrderItems.Criteria.AddCondition("etel_orderid", ConditionOperator.Equal, OrderGuid);
                EntityCollection orderItemList = ContextProvider.OrganizationService.RetrieveMultiple(etelOrderItems);

                foreach (Entity typeOrderItem in orderItemList.Entities)
                {
                    _OrderBasketOrderItem = new OrderBasketOrderItem();
                    _OrderBasketOrderItem.guid = typeOrderItem.Id;
                    _OrderBasketOrderItem.name = (typeOrderItem.Attributes.Contains("etel_offeringid")) ? (typeOrderItem.Attributes["etel_offeringid"] as EntityReference).Name : string.Empty;
                    _OrderBasketOrderItem.offeringGuid = (typeOrderItem.Attributes.Contains("etel_offeringid")) ? (typeOrderItem.Attributes["etel_offeringid"] as EntityReference).Id.ToString() : string.Empty;
                    _OrderBasketOrderItem.OfferTypeCode = (typeOrderItem.Attributes.Contains("amx_offertypecode")) ? (((OptionSetValue)typeOrderItem.Attributes["amx_offertypecode"]).Value).ToString() : string.Empty;
                    _OrderBasketOrderItem.OfferTypeCodeValue = !string.IsNullOrEmpty(_OrderBasketOrderItem.OfferTypeCode) ? ((amx_offertypecode)((OptionSetValue)typeOrderItem.Attributes["amx_offertypecode"]).Value).ToString(): "Basic Offer";
                    _OrderBasketOrderItem.OrderItemAction = (typeOrderItem.Attributes.Contains("amx_action")) ? ((amx_orderitemaction)((OptionSetValue)typeOrderItem.Attributes["amx_action"]).Value).ToString() : string.Empty;
                    _OrderBasketOrderItem.SRProductId = typeOrderItem.Attributes.Contains("amx_productsrid") ? typeOrderItem.Attributes["amx_productsrid"].ToString() : string.Empty;
                    _OrderBasketOrderItem.RecurringCharge = typeOrderItem.Attributes.Contains("etel_recurringcharge") ? ((Money)typeOrderItem.Attributes["etel_recurringcharge"]).Value.ToString() : string.Empty;
                    _OrderBasketOrderItem.OneTimeCharge = typeOrderItem.Attributes.Contains("etel_onetimecharge") ? ((Money)typeOrderItem.Attributes["etel_onetimecharge"]).Value.ToString() : string.Empty;
                    _OrderBasketOrderItem.SinglePlanCharge = typeOrderItem.Attributes.Contains("etel_extendedrecurringcharge") ? ((Money)typeOrderItem.Attributes["etel_extendedrecurringcharge"]).Value.ToString() : string.Empty;
                    _OrderBasketOrderItem.OTSinglePlanCharge = typeOrderItem.Attributes.Contains("etel_extendedonetimecharge") ? ((Money)typeOrderItem.Attributes["etel_extendedonetimecharge"]).Value.ToString() : string.Empty;
                    _OrderBasketOrderItem.Currency = "$ ";
                    _OrderBasketOrderItem.ActivationStartDate = typeOrderItem.Attributes.Contains("amx_activationstartdate") ? ((DateTime)typeOrderItem.Attributes["amx_activationstartdate"]).ToShortDateString() : string.Empty;
                    _OrderBasketOrderItem.ActivationEndDate = typeOrderItem.Attributes.Contains("amx_activationenddate") ? ((DateTime)typeOrderItem.Attributes["amx_activationenddate"]).ToShortDateString() : string.Empty;
                    _OrderBasketOrderItem.Taxes = typeOrderItem.Attributes.Contains("amx_taxes") ? typeOrderItem.Attributes["amx_taxes"].ToString() : string.Empty;
                    _OrderBasketOrderItem.Family = typeOrderItem.Attributes.Contains("amx_family") ? typeOrderItem.Attributes["amx_family"].ToString() : string.Empty;
                    _OrderBasketOrderItem.BillingAccountId = typeOrderItem.Attributes.Contains("amx_billingaccountexternalid") ? ((String)typeOrderItem.Attributes["amx_billingaccountexternalid"]) : string.Empty;
                    _OrderBasketOrderItem.ParentOrder = false;
                    if (!typeOrderItem.Attributes.Contains("etel_parentorderitemid"))
                    {
                        _OrderBasketOrderItem.ParentOrder = true;
                    }
                    else { _OrderBasketOrderItem.ParentOrderItemId = (typeOrderItem.Attributes["etel_parentorderitemid"] as EntityReference).Id ; }

                    if (!string.IsNullOrEmpty(_OrderBasketOrderItem.OfferTypeCode) && int.Parse(_OrderBasketOrderItem.OfferTypeCode) == 10)
                    {
                        var offeringBusiness = new OfferingsBusiness(ContextProvider);
                        _OrderBasketOrderItem.ServiceId = offeringBusiness.FindServiceIdOfProduct(_OrderBasketOrderItem.offeringGuid);
                    }

                    // get resource value
                    var resourceQueryExprression = new QueryExpression(etel_orderresource.EntityLogicalName);
                    resourceQueryExprression.ColumnSet = new ColumnSet("etel_value");
                    resourceQueryExprression.Criteria.AddCondition("etel_orderitemid",ConditionOperator.Equal,_OrderBasketOrderItem.guid);
                    var resources = ContextProvider.OrganizationService.RetrieveMultiple(resourceQueryExprression)?.Entities?.FirstOrDefault();
                    if (resources != null && resources.Contains("etel_value"))
                    {
                        _OrderBasketOrderItem.ResourceValue = resources.Attributes["etel_value"].ToString();
                    }

                    //for each order Item, there should be a list of Order Product Characteristics
                    /*
                     * ypala 22/02 closed
                    _listOfOrderBasketItemProdCharacteristic = new List<OrderBasketItemProdCharacteristic>();
                    QueryExpression queryOrderProdChar = new QueryExpression("etel_orderproductcharacteristic");
                    queryOrderProdChar.ColumnSet = new ColumnSet(true);
                    queryOrderProdChar.Criteria.AddCondition("etel_orderitemid", ConditionOperator.Equal, typeOrderItem.Id);
                    EntityCollection _EntityCollection = ContextProvider.OrganizationService.RetrieveMultiple(queryOrderProdChar);
                    if (_EntityCollection != null)
                    {
                        if (_EntityCollection.Entities.Count > 0)
                        {
                            foreach (Entity orderproductcharacteristic in _EntityCollection.Entities)
                            {
                                _listOfOrderBasketItemProdCharacteristic.Add(new OrderBasketItemProdCharacteristic()
                                {
                                    guid = orderproductcharacteristic.Id,
                                    name = (orderproductcharacteristic.Attributes.Contains("etel_characteristicid")) ? (orderproductcharacteristic.Attributes["etel_characteristicid"] as EntityReference).Name : string.Empty,
                                    value = GetValueOfCharacteristic(orderproductcharacteristic)
                                });
                            }
                        }
                    }
                    */

                    /*
                     * ypala 23.02 closed
                    //Get Resources for this Order Item
                    string FetchXmlOrderResources = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                      <entity name='etel_orderresource'>
                                                        <attribute name='etel_orderresourceid' />
                                                        <attribute name='etel_name' />
                                                        <attribute name='etel_value' />
                                                        <order attribute='etel_name' descending='false' />
                                                        <link-entity name='etel_orderitem' from='etel_orderitemid' to='etel_orderitemid' alias='ah'>
                                                          <filter type='and'>
                                                            <condition attribute='etel_orderitemid' operator='eq' uitype='etel_orderitem' value='{0}' />
                                                          </filter>
                                                        </link-entity>
                                                        <link-entity name='etel_productresourcespecification' from='etel_productresourcespecificationid' to='etel_productresourcespecification' visible='false' link-type='outer' alias='a_join'>
                                                          <attribute name='etel_resourcetypecode' />
                                                        </link-entity>
                                                      </entity>
                                                    </fetch>";
                    FetchXmlOrderResources = string.Format(FetchXmlOrderResources, typeOrderItem.Id.ToString());
                    EntityCollection _listOfResourcesOrderItem = ContextProvider.OrganizationService.RetrieveMultiple(new FetchExpression(FetchXmlOrderResources));
                    if (_listOfResourcesOrderItem != null)
                    {
                        if (_listOfResourcesOrderItem.Entities.Count > 0)
                        {
                            foreach (Entity orderResource in _listOfResourcesOrderItem.Entities)
                            {
                                int ResourceTypeCode = (orderResource.Attributes.Contains("a_join.etel_resourcetypecode")) ? (((AliasedValue)orderResource.Attributes["a_join.etel_resourcetypecode"]).Value as OptionSetValue).Value : -1;
                                if (ResourceTypeCode == 1)
                                {
                                    _OrderBasketOrderItem.ResourceMSISDN = (orderResource.Attributes.Contains("etel_value")) ? orderResource.Attributes["etel_value"].ToString() : string.Empty;
                                }
                                else if (ResourceTypeCode == 0)
                                {
                                    _OrderBasketOrderItem.ResourceSIM = (orderResource.Attributes.Contains("etel_value")) ? orderResource.Attributes["etel_value"].ToString() : string.Empty;
                                }
                            }
                        }
                    }
                    */
                    //Get Resources for this Order Item

                    //_OrderBasketOrderItem.listOfPrices = _listOfPrices;
                    _OrderBasketOrderItem.listOfOrderBasketOrderItemProdCharacteristics = _listOfOrderBasketItemProdCharacteristic;

                    //GetPrices from etel_orderitem fields
                    _OrderBasketOrderItem.OneTimeCharge = (typeOrderItem.Attributes.Contains("etel_onetimecharge")) ? (((Money)typeOrderItem.Attributes["etel_onetimecharge"]).Value).ToString() : string.Empty;
                    _OrderBasketOrderItem.DepositCharge = (typeOrderItem.Attributes.Contains("etel_depositamount")) ? (((Money)typeOrderItem.Attributes["etel_depositamount"]).Value).ToString() : string.Empty; ;
                    _OrderBasketOrderItem.RecurringCharge = (typeOrderItem.Attributes.Contains("etel_recurringcharge")) ? (((Money)typeOrderItem.Attributes["etel_recurringcharge"]).Value).ToString() : string.Empty;
                    _OrderBasketOrderItem.CheckOutCharge = (typeOrderItem.Attributes.Contains("amxperu_checkoutprice")) ? (((Money)typeOrderItem.Attributes["amxperu_checkoutprice"]).Value).ToString() : string.Empty;
                    //GetPrices from etel_orderitem fields

                    listOfOrderBasketItems.Add(_OrderBasketOrderItem);
                }

                _OrderItemsBasketModel.message = "SUCCESS";
                _OrderItemsBasketModel.listOfOrderBasketOrderItems = listOfOrderBasketItems;

                //TestCode for Checking JSON Data
                JavaScriptSerializer javascriptSerializer = new JavaScriptSerializer();
                string responseString = javascriptSerializer.Serialize(_OrderItemsBasketModel);
                //TestCode for Checking JSON Data

                context.SetValue(orderBasket, _OrderItemsBasketModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetValueOfCharacteristic(Entity orderproductcharacteristic)
        {
            string value = string.Empty;
            int orderProdCharDataType = (orderproductcharacteristic.Attributes.Contains("etel_datatypecode")) ? ((orderproductcharacteristic.Attributes["etel_datatypecode"]) as OptionSetValue).Value : -1;

            switch (orderProdCharDataType)
            {
                case 831260000:
                case 831260001:
                case 831260005:
                    value = (orderproductcharacteristic.Attributes.Contains("etel_value")) ? orderproductcharacteristic.Attributes["etel_value"].ToString() : string.Empty;
                    break;
                case 831260003:
                    value = (orderproductcharacteristic.Attributes.Contains("etel_characteristicvalueid")) ? (orderproductcharacteristic.Attributes["etel_characteristicvalueid"] as EntityReference).Name : string.Empty;
                    break;
            }

            return value;
        }
    }
}