using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Model;
using AmxPeruCommonLibrary.Repository.Offering; 

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class AmxPeruGetOfferingPrices : XrmAwareCodeActivity
    {
        public InOutArgument<AmxPeruOfferingPriceModel> testtest { get; set; }

        //protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        //{
        //    string EntityProductOfferingPrice = "amxperu_productofferingprice";

        //    var inputArray = testtest.Get(context);

        //    var result = new AmxPeruOfferingPriceModel();

        //    result.OrderId = inputArray.OrderId;
        //    result.OrderItemList = new List<Model.Offering>();


        //    foreach (var item in inputArray.OrderItemList)
        //    {
        //        //Retrieve one PriceConfig record using VelueList and Offering
        //        //then retrieve priceconfig's prices

        //        var resultPriceConfigurations = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
        //        {
        //            EntityName = "amxperu_productofferingpriceconfiguration",
        //            ColumnSet = new ColumnSet(true),
        //            Criteria =
        //                new FilterExpression
        //                {
        //                    Conditions =
        //                        {
        //                                new ConditionExpression(
        //                                    "amxperu_productoffering",
        //                                    ConditionOperator.Equal,
        //                                    new Guid(item.OfferingId))
        //                        }
        //                }
        //        });


        //        List<Guid> configList = new List<Guid>();

        //        foreach (var config in resultPriceConfigurations.Entities)
        //        {
        //            configList.Add(config.Id);
        //        }

        //        string valuelist = string.Empty;

        //        List<Guid> valueList = new List<Guid>();

        //        foreach (var characteristic in item.CharacteristicList)
        //        {
        //            foreach (var value in characteristic.ValueList)
        //            {
        //                if (!string.IsNullOrEmpty(value.ValueId))
        //                {
        //                    valueList.Add(new Guid(value.ValueId));
        //                }
        //            }
        //        }


        //        var filter = new FilterExpression();

        //        if (!string.IsNullOrEmpty(valuelist))
        //        {
        //            filter = new FilterExpression()
        //            {
        //                Conditions =
        //                    {
        //                                new ConditionExpression("etel_productcharacteristicvalueid", ConditionOperator.In,valueList),
        //                                new ConditionExpression("amxperu_productofferingpriceconfigurationid", ConditionOperator.In,configList)
        //                    }
        //            };
        //        }
        //        else
        //        {
        //            filter = new FilterExpression()
        //            {
        //                Conditions =
        //                    {
        //                                new ConditionExpression("amxperu_productofferingpriceconfigurationid", ConditionOperator.In,configList)
        //                    }
        //            };
        //        }

        //        var resultrelations = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
        //        {
        //            EntityName = "amxperu_priceconfiguration_charvalue",
        //            ColumnSet = new ColumnSet(true),
        //            Criteria = filter

        //        });

        //        if (resultrelations.Entities.Count > 0)
        //        {
        //            var resultOfferings = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
        //            {
        //                EntityName = EntityProductOfferingPrice,
        //                ColumnSet = new ColumnSet(true),
        //                Criteria =
        //                    new FilterExpression
        //                    {
        //                        Conditions =
        //                            {
        //                                new ConditionExpression(
        //                                    "amxperu_popconfiguration",
        //                                    ConditionOperator.Equal,
        //                                    new Guid(resultrelations.Entities[0].Attributes["amxperu_productofferingpriceconfigurationid"].ToString()))
        //                            }
        //                    }
        //            });

        //            item.PriceConfigurationId = resultrelations.Entities[0].Attributes["amxperu_productofferingpriceconfigurationid"].ToString();

        //            foreach (var price in resultOfferings.Entities)
        //            {
        //                var priceType = (OptionSetValue)price.Attributes["amxperu_pricetypecode"];
        //                switch (priceType.Value)
        //                {
        //                    case (int)etel_pricetypecode.Deposit:
        //                        item.Deposit = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
        //                        break;
        //                    case (int)etel_pricetypecode.OneTime:
        //                        item.OneTimeCharge = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
        //                        break;
        //                    case (int)etel_pricetypecode.Recurring:
        //                        item.RecurringCharge = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            var defaultPriceConfigurationGuid = resultPriceConfigurations.Entities[0].Id;

        //            var resultOfferings = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
        //            {
        //                EntityName = EntityProductOfferingPrice,
        //                ColumnSet = new ColumnSet(true),
        //                Criteria =
        //                    new FilterExpression
        //                    {
        //                        Conditions =
        //                            {
        //                                new ConditionExpression("amxperu_popconfiguration", ConditionOperator.Equal, defaultPriceConfigurationGuid)
        //                            }
        //                    }
        //            });

        //            item.PriceConfigurationId = defaultPriceConfigurationGuid.ToString();

        //            foreach (var price in resultOfferings.Entities)
        //            {
        //                var priceType = (OptionSetValue)price.Attributes["amxperu_pricetypecode"];
        //                switch (priceType.Value)
        //                {
        //                    case (int)etel_pricetypecode.Deposit:
        //                        item.Deposit = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
        //                        break;
        //                    case (int)etel_pricetypecode.OneTime:
        //                        item.OneTimeCharge = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
        //                        break;
        //                    case (int)etel_pricetypecode.Recurring:
        //                        item.RecurringCharge = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //        }


        //        //Get Resources for this Order Item
        //        //Temp : Fetch Based Fix
        //        string FetchXmlOrderResources = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
        //                                              <entity name='etel_orderresource'>
        //                                                <attribute name='etel_orderresourceid' />
        //                                                <attribute name='etel_name' />
        //                                                <attribute name='etel_value' />
        //                                                <order attribute='etel_name' descending='false' />
        //                                                <link-entity name='etel_orderitem' from='etel_orderitemid' to='etel_orderitemid' alias='ah'>
        //                                                  <filter type='and'>
        //                                                    <condition attribute='etel_orderitemid' operator='eq' uitype='etel_orderitem' value='{0}' />
        //                                                  </filter>
        //                                                </link-entity>
        //                                                <link-entity name='etel_productresourcespecification' from='etel_productresourcespecificationid' to='etel_productresourcespecification' visible='false' link-type='outer' alias='a_join'>
        //                                                  <attribute name='etel_resourcetypecode' />
        //                                                </link-entity>
        //                                              </entity>
        //                                            </fetch>";
        //        FetchXmlOrderResources = string.Format(FetchXmlOrderResources, item.OrderItemId);
        //        EntityCollection _listOfResourcesOrderItem = ContextProvider.OrganizationService.RetrieveMultiple(new FetchExpression(FetchXmlOrderResources));
        //        if (_listOfResourcesOrderItem != null)
        //        {
        //            if (_listOfResourcesOrderItem.Entities.Count > 0)
        //            {
        //                foreach (Entity orderResource in _listOfResourcesOrderItem.Entities)
        //                {
        //                    int ResourceTypeCode = (orderResource.Attributes.Contains("a_join.etel_resourcetypecode")) ? (((AliasedValue)orderResource.Attributes["a_join.etel_resourcetypecode"]).Value as OptionSetValue).Value : -1;
        //                    if (ResourceTypeCode == 1)
        //                    {
        //                        item.ResourceMSISDN = (orderResource.Attributes.Contains("etel_value")) ? orderResource.Attributes["etel_value"].ToString() : string.Empty;
        //                    }
        //                    else if (ResourceTypeCode == 0)
        //                    {
        //                        item.ResourceSIM = (orderResource.Attributes.Contains("etel_value")) ? orderResource.Attributes["etel_value"].ToString() : string.Empty;
        //                    }
        //                }
        //            }
        //        }
        //        //Get Resources for this Order Item

        //        result.OrderItemList.Add(item);
        //    }

        //    testtest.Set(context, result);
        //}

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var inputArray = testtest.Get(context);
            var result = new AmxPeruOfferingPriceModel();
            result.OrderId = inputArray.OrderId;
            result.OrderItemList = new List<Model.Offering>();


            foreach (var item in inputArray.OrderItemList)
            {
                //Retrieve one PriceConfig record using VelueList and Offering
                //then retrieve priceconfig's prices
                List<Guid> valueList = new List<Guid>();
                EntityCollection charValueCollection = new EntityCollection();

                foreach (var characteristic in item.CharacteristicList)
                {
                    foreach (var value in characteristic.ValueList)
                    {
                        if (!string.IsNullOrEmpty(value.ValueId))
                        {
                            //TODO: emuusah : list typed chars
                            charValueCollection.Entities.Add(
                            new Entity("etel_productcharacteristicvalue")
                            {
                                Id = Guid.Parse(characteristic.CharacteristicId),
                                Attributes = new AttributeCollection()
                                {
                                    new KeyValuePair<string, object>("etel_name", value.ValueText)
                                }
                            });
                            valueList.Add(new Guid(value.ValueId));
                        }
                    }
                }
                var offeringRepository = new AmxPeruOfferingRepository();
                var POPs = offeringRepository.RetrievePOPsByCharValueList(ContextProvider.OrganizationService,
                    Guid.Parse(item.OfferingId),
                    charValueCollection);


                item.PriceConfigurationId = ((EntityReference)POPs.Entities[0].Attributes["amxperu_popconfiguration"]).Id.ToString();


                int Deposit = 0, OneTimeCharge = 0, RecurringCharge = 0;

                foreach (var price in POPs.Entities)
                {
                    var priceType = (OptionSetValue)price.Attributes["amxperu_pricetypecode"];
                    int priceValue = Convert.ToInt32(((Money)price.Attributes["amxperu_price"]).Value);

                    switch (priceType.Value)
                    {
                        case (int)etel_pricetypecode.Deposit:
                            Deposit = Deposit + priceValue;
                            item.Deposit = Deposit.ToString();
                            break;
                        case (int)etel_pricetypecode.OneTime:
                            OneTimeCharge = OneTimeCharge + priceValue;
                            item.OneTimeCharge = OneTimeCharge.ToString();
                            break;
                        case (int)etel_pricetypecode.Recurring:
                            RecurringCharge = RecurringCharge + priceValue;
                            item.RecurringCharge = RecurringCharge.ToString();
                            break;
                        default:
                            break;
                    }
                }

                //Get Resources for this Order Item
                //Temp : Fetch Based Fix
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
                FetchXmlOrderResources = string.Format(FetchXmlOrderResources, item.OrderItemId);
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
                                item.ResourceMSISDN = (orderResource.Attributes.Contains("etel_value")) ? orderResource.Attributes["etel_value"].ToString() : string.Empty;
                            }
                            else if (ResourceTypeCode == 0)
                            {
                                item.ResourceSIM = (orderResource.Attributes.Contains("etel_value")) ? orderResource.Attributes["etel_value"].ToString() : string.Empty;
                            }
                        }
                    }
                }
                //Get Resources for this Order Item
                result.OrderItemList.Add(item);
            }

            testtest.Set(context, result);
        }
    }
}
