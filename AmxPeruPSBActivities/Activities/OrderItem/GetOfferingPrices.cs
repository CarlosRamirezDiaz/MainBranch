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
    public class GetOfferingPrices : XrmAwareCodeActivity
    {

        public OutArgument<EntityCollection> OfferingPriceList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            string EntityProductOfferingPrice = "amxperu_productofferingprice";

            var resultOfferings = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = EntityProductOfferingPrice,
                ColumnSet = new ColumnSet(true),
            });

            OfferingPriceList.Set(context, resultOfferings);
        }
    }
}
