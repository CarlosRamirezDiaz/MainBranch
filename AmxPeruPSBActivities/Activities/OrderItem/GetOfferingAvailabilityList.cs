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

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class GetOfferingAvailabilityList : XrmAwareCodeActivity
    {
        public OutArgument<EntityCollection> OfferingAvailabilityConfigurationList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {

            string EntityProductOfferingAvailabilityConfiguration = "amxperu_productofferingavailabilityconfiguratio";
            
            //string EntityProductOfferingPriceConfiguration = "amxperu_productofferingpriceconfiguration";
            //string EntityProductOfferingPrice = "amxperu_productofferingprice";

            //string FieldProductOfferingId = "amxperu_productofferingid";
            //string FieldProductOfferingPriceConfigurationId = "amxperu_productofferingpriceconfigurationid";
            //string FieldPopConfiguration = "amxperu_popconfiguration";
            //string FieldPrice = "amxperu_price";
            //string FieldPriceType = "amxperu_pricetype";
            //string FieldPeriod = "amxperu_period";
            //string FieldCurrency = "transactioncurrencyid";

            //string[] columnsForOfferings = { FieldProductOfferingId };
            //string[] columnsForPriceConfigurations = { FieldProductOfferingId, FieldProductOfferingPriceConfigurationId };
            //string[] columnsForOfferingPrice = { FieldProductOfferingId, FieldPopConfiguration, FieldPrice, FieldPriceType, FieldPeriod, FieldCurrency };


            var resultOfferings = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = EntityProductOfferingAvailabilityConfiguration,
                ColumnSet = new ColumnSet(true),                
            });

            OfferingAvailabilityConfigurationList.Set(context, resultOfferings);

        }
    }
}
