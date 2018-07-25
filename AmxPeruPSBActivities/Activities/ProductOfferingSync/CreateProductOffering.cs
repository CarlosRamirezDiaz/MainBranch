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
using AmxPeruPSBActivities.Model.ProductOfferingSync;

namespace AmxPeruPSBActivities.Activities.ProductOfferingSync
{
    public class CreateProductOffering : XrmAwareCodeActivity
    {

        public InArgument<ProductOfferingRequest> ProductOfferingRequest { get; set; }


        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var productOfferingRequest = ProductOfferingRequest.Get(context);

            foreach (var item in productOfferingRequest.ProductOfferingList)
            {
                var ps = new etel_productspecification();
                ps.etel_externalid = item.ProductSpecification.ExternalId;
                ps.etel_name = item.ProductSpecification.Name;
                var psId = ContextProvider.OrganizationService.Create(ps);

                var product = new Product();
                product.etel_externalid = item.ExternalId;
                product.Name = item.Name;
                product.ProductNumber = item.ExternalId;
                product.DefaultUoMId = new EntityReference(UoM.EntityLogicalName, new Guid("FB6BF811-51EF-488B-8571-0541E4D75DEC"));
                product.DefaultUoMScheduleId = new EntityReference(UoMSchedule.EntityLogicalName, new Guid("1C59A261-40D0-4213-835E-75C2BB257A44"));
                product.TransactionCurrencyId = new EntityReference(TransactionCurrency.EntityLogicalName, new Guid("39D506B7-5578-E711-8123-00505601173A"));

                product.etel_productspecificationId = new EntityReference(etel_productspecification.EntityLogicalName, psId);

                var productId = ContextProvider.OrganizationService.Create(product);

                foreach (var cfss in item.ProductSpecification.CFSSList)
                {
                    Entity newCfss = new Entity("amxperu_cfss");
                    newCfss.Attributes["amxperu_externalid"] = cfss.ExternalId;
                    newCfss.Attributes["amxperu_name"] = cfss.Name;
                    newCfss.Attributes["amxperu_productspecificationid"] = new EntityReference(etel_productspecification.EntityLogicalName, psId);
                    ContextProvider.OrganizationService.Create(newCfss);
                }

                foreach (var characteristic in item.CharacteristicList)
                {
                    Entity newCharacteristic = new Entity("etel_productcharacteristic");
                    newCharacteristic.Attributes["etel_name"] = characteristic.Name;
                    newCharacteristic.Attributes["etel_externalid"] = characteristic.ExternalId;
                    var charId = ContextProvider.OrganizationService.Create(newCharacteristic);

                    Entity newCharacteristicUse = new Entity("amxperu_productofferingcharuse");
                    newCharacteristicUse.Attributes["amxperu_name"] = characteristic.Name;
                    newCharacteristicUse.Attributes["amxperu_productoffering"] = new EntityReference( Product.EntityLogicalName, productId);
                    newCharacteristicUse.Attributes["amxperu_characteristic"] = new EntityReference(etel_productcharacteristic.EntityLogicalName, charId);
                    var charUseId = ContextProvider.OrganizationService.Create(newCharacteristicUse);

                    foreach (var value in characteristic.CharacteristicValueList)
                    {
                        Entity newValue = new Entity("etel_productcharacteristicvalue");
                        newValue.Attributes["etel_name"] = value.Value;
                        newValue.Attributes["etel_externalid"] = value.ExternalId;
                        var valueId = ContextProvider.OrganizationService.Create(newValue);

                        Entity newCharacteristicValueUse = new Entity("amxperu_productofferingcharvalueuse");
                        newCharacteristicValueUse.Attributes["amxperu_name"] = characteristic.Name;
                        newCharacteristicValueUse.Attributes["amxperu_productofferingcharuse"] = new EntityReference("amxperu_productofferingcharuse", charUseId);
                        newCharacteristicValueUse.Attributes["amxperu_value"] = new EntityReference(etel_productcharacteristicvalue.EntityLogicalName, valueId);
                        var charValueUseId = ContextProvider.OrganizationService.Create(newCharacteristicUse);
                    }

                }
            }
        }
    }
}

