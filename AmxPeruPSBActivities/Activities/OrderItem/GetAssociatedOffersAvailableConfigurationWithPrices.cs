using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk;
using Ericsson.ETELCRM.Entities.Crm.CustomEntities;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class GetAssociatedOffersAvailableConfigurationWithPrices : XrmAwareCodeActivity
    {

        public InArgument<EntityCollection> OfferingPriceList { get; set; }

        public InArgument<EntityCollection> OfferingPriceConfigurationList { get; set; }

        public InArgument<EntityCollection> OfferingAvailabilityConfigurationList { get; set; }

        public InArgument<List<OptionSet>> PriceTypeCodeList { get; set; }

        public InArgument<List<OptionSet>> PricePeriodCodeList { get; set; }

        public OutArgument<List<ProductOfferingConfigurationPriceModel>> ProductOfferingPriceList { get; set; }

        public InArgument<AvailableOfferingInputModel> FilterAvailableOfferingInputModel { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            const int checkOutPriceCode = 831260003;
            var offeringPriceList = OfferingPriceList.Get(context);
            var offeringPriceConfigurationList = OfferingPriceConfigurationList.Get(context);
            var offeringAvailabilityConfigurationList = OfferingAvailabilityConfigurationList.Get(context);
            var priceTypeCodeList = PriceTypeCodeList.Get(context);
            var pricePeriodCodeList = PricePeriodCodeList.Get(context);
            
            var availableOfferingInputModel = FilterAvailableOfferingInputModel.Get(context);
            var modelList = new List<ProductOfferingConfigurationPriceModel>();



            #region associated
            string Entityofferingassociation = "etel_offeringassociation";
            var resultofferingassociation = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = Entityofferingassociation,
                ColumnSet = new ColumnSet(true),
            });

            var associatedproductOfferingIds = resultofferingassociation.Entities.Select(a => ((EntityReference)(a.Attributes["etel_secondaryofferingid"])).Id).Distinct();
            #endregion


            #region Availability


            string EntityAvailabilityCharValueUse = "amxperu_productofferingavailabilityconfig";
            var resultproductofferingavailabilityconfig = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = EntityAvailabilityCharValueUse,
                ColumnSet = new ColumnSet(true),
            });            
            
            string productcharacteristicvalue = "etel_productcharacteristicvalue";
            var resultproductcharacteristicvalue = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = productcharacteristicvalue,
                ColumnSet = new ColumnSet(true),
            });
            
            var CharValueList = new List<Guid>();
            foreach (var item in availableOfferingInputModel.CharList)
            {
                //modelList.Add(new ProductOfferingConfigurationPriceModel
                //{
                //    OfferingName = item.Id,
                //    Deposit = item.Value
                //});

                //ProductOfferingPriceList.Set(context, modelList);
                //return;
                var filteredCharValue = resultproductcharacteristicvalue.Entities
                .Where(cv => ((EntityReference)cv.Attributes["etel_productcharacteristicid"]).Id == Guid.Parse(item.Id)
                    && Convert.ToString(cv.Attributes["etel_name"]) == item.Value);
                CharValueList.Add(filteredCharValue.First().Id);
            }
            
            var filteredproductofferingavailabilityconfig = resultproductofferingavailabilityconfig.Entities
                .Where(avconfig => CharValueList.Contains((Guid)(avconfig.Attributes["etel_productcharacteristicvalueid"])))
                .Select(avconfig => ((Guid)(avconfig.Attributes["amxperu_productofferingavailabilityconfiguratioid"])))
                .Distinct()
                .ToList();

            var filteredConfigurationList = offeringAvailabilityConfigurationList.Entities.Where(av => filteredproductofferingavailabilityconfig.Contains(av.Id));

            var productOfferingIds = filteredConfigurationList.Select(a => ((EntityReference)(a.Attributes["amxperu_productofferingid"])).Id).Distinct();

            #endregion


            var configurations = offeringPriceConfigurationList.Entities.Where(a => associatedproductOfferingIds.Contains(((EntityReference)(a.Attributes["amxperu_productoffering"])).Id));
            
            var prices = offeringPriceList.Entities.Where(a => configurations.Select(configuration => configuration.Id).Contains(((EntityReference)(a.Attributes["amxperu_popconfiguration"])).Id));

            

            foreach (var item in configurations)
            {                
                var model = new ProductOfferingConfigurationPriceModel();
                model.PriceConfigurationId = item.Id.ToString();
                model.OfferingName = ((EntityReference)(item.Attributes["amxperu_productoffering"])).Name;
                model.PriceConfigurationName = item.Attributes["amxperu_name"].ToString();
                var itemPrices = prices.Where(a => ((EntityReference)(a.Attributes["amxperu_popconfiguration"])).Id.Equals(item.Id));

                foreach (var price in itemPrices)
                {
                    var priceTypeCode = priceTypeCodeList.Find(p => p.Value == ((OptionSetValue)price.Attributes["amxperu_pricetypecode"]).Value);
                    switch (priceTypeCode.Value)
                    {
                        case (int)etel_pricetypecode.Deposit:
                            model.Deposit = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
                            break;
                        case (int)etel_pricetypecode.OneTime:
                            model.OneTimeCharge = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
                            break;
                        case (int)etel_pricetypecode.Recurring:
                            model.RecurringCharge = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
                            break;
                        case checkOutPriceCode:
                            model.CheckOutPrice = Convert.ToString(((Money)price.Attributes["amxperu_price"]).Value);
                            break;
                        default:
                            break;
                    }                    
                }
                modelList.Add(model);
            }

            ProductOfferingPriceList.Set(context, modelList);

        }
    }
}
