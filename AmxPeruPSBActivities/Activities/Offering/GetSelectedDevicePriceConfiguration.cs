using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Ericsson.PSB.Workflow.Client.Core;
using Ericsson.ETELCRM.Entities.Crm.CustomEntities;

namespace AmxPeruPSBActivities.Activities.Offering
{

    public class DeviceConfigurationPriceMode
    {
        public Guid Id { get; set; }

        public Guid OfferingId { get; set; }

        public string OfferingName { get; set; }

        public string Storage { get; set; }

        public string Color { get; set; }

        public int Installment { get; set; }

        public string RCAmount { get; set; }

        public string OTCAmount { get; set; }

        public string DeviceName { get; set; }
    }    

    public class CharValueModel
    {
        public Guid Id { get; set; }

        public string Value { get; set; }
    }

    public class CharValueCollectionModel
    {
        public List<CharValueModel> StorageValues { get; set; }
        public List<CharValueModel> ColorValues { get; set; }
        public List<CharValueModel> DeviceNameValues { get; set; }
    }


    public class GetSelectedDevicePriceConfiguration : XrmAwareCodeActivity
    {
        public InArgument<Guid> DeviceId { get; set; }

        public InArgument<EntityCollection> PriceConfigurations { get; set; }

        public InArgument<List<OptionSet>> PriceTypeCodeList { get; set; }

        public OutArgument<List<DeviceConfigurationPriceMode>> ResponseModel  { get; set; }

        public OutArgument<CharValueCollectionModel> CharValueCollection { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var deviceId = DeviceId.Get(context);

            var priceConfigurations = PriceConfigurations.Get(context);
            //device price cong.
            var devicePriceConfigurations = priceConfigurations.Entities.Where(price => ((EntityReference)price.Attributes["amxperu_productoffering"]).Id == deviceId);

            //all char values
            string EntityProductcharacteristicvalue = "etel_productcharacteristicvalue";
            var productcharacteristicvalues = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = EntityProductcharacteristicvalue,
                ColumnSet = new ColumnSet(true),
            });

            //all price configuration - char relations
            string EntityPriceConfigurationCharValue = "amxperu_priceconfiguration_charvalue";
            var priceConfigurationCharValues = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = EntityPriceConfigurationCharValue,
                ColumnSet = new ColumnSet(true),
            });

            //all char Id
            string EntityProductcharacteristic = "etel_productcharacteristic";
            var Productcharacteristics = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = EntityProductcharacteristic,
                ColumnSet = new ColumnSet(true),
            });

            var charNames = new List<string>();
            charNames.Add("storage");
            charNames.Add("color");

            var storageCharId = Productcharacteristics.Entities.Where(a => Convert.ToString(a.Attributes["etel_externalid"]).Equals("storage")).FirstOrDefault();
            var colorCharId = Productcharacteristics.Entities.Where(a => Convert.ToString(a.Attributes["etel_externalid"]).Equals("color")).FirstOrDefault();
            var deviceNameCharId = Productcharacteristics.Entities.Where(a => Convert.ToString(a.Attributes["etel_externalid"]).Equals("devicename")).FirstOrDefault();
            
            // all configuration prices 
            string EntityPOP = "amxperu_productofferingprice";
            var configurationPrices = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = EntityPOP,
                ColumnSet = new ColumnSet(true),
            });


            var storageCharValueList = new List<CharValueModel>();
            var colorCharValueList = new List<CharValueModel>();
            var deviceNameCharValueList = new List<CharValueModel>();                      


            var priceConfigurationList = new List<DeviceConfigurationPriceMode>();
            var priceTypeCodeList = PriceTypeCodeList.Get(context);

            foreach (var item in devicePriceConfigurations)
            {
                var priceConfiguration = new DeviceConfigurationPriceMode();

                priceConfiguration.Id = item.Id;
                priceConfiguration.OfferingName = ((EntityReference)item.Attributes["amxperu_productoffering"]).Name;
                priceConfiguration.OfferingId = ((EntityReference)item.Attributes["amxperu_productoffering"]).Id;

                var confChars = priceConfigurationCharValues.Entities
                    .Where(a => ((Guid)a.Attributes["amxperu_productofferingpriceconfigurationid"]) == item.Id);

                //var confPriceCharges = devicePriceChars.Where
                foreach (var charValue in confChars)
                {
                    Guid charvalueId = ((Guid)charValue.Attributes["etel_productcharacteristicvalueid"]);
                    var charValueEntity = productcharacteristicvalues.Entities.Where(a => a.Id == charvalueId).FirstOrDefault();

                    if ((((EntityReference)(charValueEntity.Attributes["etel_productcharacteristicid"])).Id == storageCharId.Id)){
                        priceConfiguration.Storage = Convert.ToString(charValueEntity.Attributes["etel_name"]);
                        storageCharValueList.Add(new CharValueModel()
                        {
                            Id = charValueEntity.Id,
                            Value = Convert.ToString(charValueEntity.Attributes["etel_name"])
                        });
                    }
                    else if((((EntityReference)(charValueEntity.Attributes["etel_productcharacteristicid"]))).Id == colorCharId.Id)
                    {
                        priceConfiguration.Color = Convert.ToString(charValueEntity.Attributes["etel_name"]);
                        colorCharValueList.Add(new CharValueModel()
                        {
                            Id = charValueEntity.Id,
                            Value = Convert.ToString(charValueEntity.Attributes["etel_name"])
                        });
                    }
                    else if ((((EntityReference)(charValueEntity.Attributes["etel_productcharacteristicid"]))).Id == deviceNameCharId.Id)
                    {
                        priceConfiguration.DeviceName = Convert.ToString(charValueEntity.Attributes["etel_name"]);
                        deviceNameCharValueList.Add(new CharValueModel()
                        {
                            Id = charValueEntity.Id,
                            Value = Convert.ToString(charValueEntity.Attributes["etel_name"])
                        });
                    }
                }

                var charValueCollection = new CharValueCollectionModel();
                charValueCollection.ColorValues = colorCharValueList;
                charValueCollection.StorageValues = storageCharValueList;
                charValueCollection.DeviceNameValues = deviceNameCharValueList;

                CharValueCollection.Set(context, charValueCollection);

                var itemPrices = configurationPrices.Entities
                    .Where(a => ((EntityReference)a.Attributes["amxperu_popconfiguration"]).Id == item.Id);

                foreach (var price in itemPrices)
                {
                    var priceTypeCode = priceTypeCodeList.Find(p => p.Value == ((OptionSetValue)price.Attributes["amxperu_pricetypecode"]).Value);
                    switch (priceTypeCode.Value)
                    {
                        //case (int)etel_pricetypecode.Deposit:
                        //    model.Deposit = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
                        //    break;
                        case (int)etel_pricetypecode.OneTime:
                            priceConfiguration.OTCAmount = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
                            break;
                        case (int)etel_pricetypecode.Recurring:
                            priceConfiguration.RCAmount = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
                            break;
                        //case checkOutPriceCode:
                        //    model.CheckOutPrice = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
                        //    break;
                        default:
                            break;
                    }
                }

                priceConfigurationList.Add(priceConfiguration);
            }

            ResponseModel.Set(context, priceConfigurationList);
        }
    }
}
