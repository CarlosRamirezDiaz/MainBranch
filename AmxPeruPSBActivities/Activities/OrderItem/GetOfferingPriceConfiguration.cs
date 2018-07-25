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
    public class GetOfferingPriceConfiguration : XrmAwareCodeActivity
    {
        public OutArgument<EntityCollection> OfferingPriceConfigurationList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            string EntityProductOfferingPriceConfiguration = "amxperu_productofferingpriceconfiguration";

            var resultOfferings = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = EntityProductOfferingPriceConfiguration,
                ColumnSet = new ColumnSet(true),
            });

            OfferingPriceConfigurationList.Set(context, resultOfferings);
        }
    }
}
