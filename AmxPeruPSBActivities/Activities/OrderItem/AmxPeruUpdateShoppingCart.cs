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
using AmxPeruPSBActivities.Activities.Common;
using AmxPeruPSBActivities.Activities.Appointment;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class AmxPeruUpdateShoppingCart : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruOfferingPriceModel> InputModel { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AmxPeruOfferingPriceModel inputArray = context.GetValue(InputModel);

            if (inputArray != null)
            {
                foreach (var item in inputArray.OrderItemList)
                {
                    if (item.PriceConfigurationId != null)
                    {
                        Entity orderitem = new Entity();
                        orderitem.LogicalName = "etel_orderitem";
                        orderitem.Id = new Guid(item.OrderItemId);
                        orderitem.Attributes["amxperu_offeringpriceconfigurationid"] = new EntityReference("amxperu_productofferingpriceconfiguration", new Guid(item.PriceConfigurationId));
                        ContextProvider.OrganizationService.Update(orderitem);
                    }

                    foreach (var charac in item.CharacteristicList)
                    {
                        var resultproductcharacteristic = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                        {
                            EntityName = "etel_orderproductcharacteristic",
                            ColumnSet = new ColumnSet(true),
                            Criteria =
                            new FilterExpression()
                            {
                                Conditions =
                                    {
                                        new ConditionExpression("etel_orderitemid", ConditionOperator.Equal,item.OrderItemId),
                                        new ConditionExpression("etel_characteristicid", ConditionOperator.Equal,charac.CharacteristicId)
                                    }
                            }
                        });

                        if (resultproductcharacteristic.Entities.Count > 0)
                        {
                            Entity productcharacteristic = new Entity();
                            productcharacteristic.LogicalName = "etel_orderproductcharacteristic";
                            productcharacteristic.Id = resultproductcharacteristic.Entities[0].Id;

                            if (charac.ValueList.Count == 1)
                            {
                                //TODO: Use Data Type
                                if (string.IsNullOrEmpty(charac.ValueList[0].ValueId))
                                {
                                    productcharacteristic.Attributes["etel_value"] = charac.ValueList[0].ValueText;
                                }
                                else
                                {
                                    productcharacteristic.Attributes["etel_value"] = charac.ValueList[0].ValueText;
                                    productcharacteristic.Attributes["etel_characteristicvalueid"] = new EntityReference("etel_productcharacteristicvalue", new Guid(charac.ValueList[0].ValueId));
                                }

                            }
                            else if (charac.ValueList.Count > 1)
                            {
                                //TODO
                            }

                            ContextProvider.OrganizationService.Update(productcharacteristic);
                        }
                    }
                }
            }
        }
    }
}