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

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class AmxPeruAddDeviceToShoppingCart : XrmAwareCodeActivity
    {
        public InOutArgument<AmxPeruOfferingPriceModel> InputModel { get; set; }

        

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var inputArray = InputModel.Get(context);

            var result = new AmxPeruOfferingPriceModel();

            result.OrderId = inputArray.OrderId;
            result.OrderItemList = new List<Model.Offering>();

            foreach (var item in inputArray.OrderItemList)
            {

                if (item.OrderItemId == null)
                {
                    Entity orderitem = new Entity();
                    orderitem.LogicalName = "etel_orderitem";
                    orderitem.Attributes["amxperu_offeringpriceconfigurationid"] = new EntityReference("amxperu_productofferingpriceconfiguration", new Guid(item.PriceConfigurationId));
                    orderitem.Attributes["etel_offeringid"] = new EntityReference("product", new Guid(item.OfferingId));
                    var orderItemId = ContextProvider.OrganizationService.Create(orderitem);

                    var filter = new FilterExpression()
                        {
                            Conditions =
                            {
                                        new ConditionExpression("amxperu_productofferingpriceconfigurationid", ConditionOperator.Equal,item.PriceConfigurationId)
                            }
                        };

                    var resultrelations = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = "amxperu_priceconfiguration_charvalue",
                        ColumnSet = new ColumnSet(true),
                        Criteria = filter

                    });

                    item.CharacteristicList = new List<Model.Characteristic>();

                    foreach (var charValue in resultrelations.Entities)
                    {
                        var resultCharacteristicValue = 
                            (etel_productcharacteristicvalue)
                            ContextProvider.OrganizationService.Retrieve(etel_productcharacteristicvalue.EntityLogicalName, 
                            new Guid(charValue.Attributes["etel_productcharacteristicvalueid"].ToString()), new ColumnSet(true));

                        var resultCharacteristic = (etel_productcharacteristic)ContextProvider.OrganizationService.Retrieve
                            (etel_productcharacteristic.EntityLogicalName, resultCharacteristicValue.etel_productcharacteristicid.Id, new ColumnSet(true));

                        var orderitemchar = new etel_orderproductcharacteristic();
                        orderitemchar.etel_datatypecode = new OptionSetValue(resultCharacteristic.etel_datatype.Value);
                        orderitemchar.etel_orderitemid = new EntityReference(etel_orderitem.EntityLogicalName, orderItemId);
                        orderitemchar.etel_characteristicid = new EntityReference("etel_productcharacteristic", resultCharacteristic.Id);
                        orderitemchar.etel_characteristicvalueid = new EntityReference("etel_productcharacteristicvalue", resultCharacteristicValue.Id);
                        ContextProvider.OrganizationService.Create(orderitemchar);

                        var characteristic = new Model.Characteristic();
                        characteristic.CharacteristicId = resultCharacteristic.Id.ToString();
                        characteristic.CharacteristicName = resultCharacteristic.etel_name;

                        characteristic.ValueList = new List<Value>();

                        var value = new Model.Value();
                        value.ValueId = resultCharacteristicValue.Id.ToString();
                        value.ValueText = resultCharacteristicValue.etel_name;

                        characteristic.ValueList.Add(value);

                        item.CharacteristicList.Add(characteristic);
                    }
                }

                result.OrderItemList.Add(item);
            }

            InputModel.Set(context, result);
        }
    }
}