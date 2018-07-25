using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.ChangeResource
{
    public class AmxPeruValidatioIsOpenShoppingCartActivity : XrmAwareCodeActivity
    {
        public InArgument<string> subscriptionId { get; set; }

        public OutArgument<bool> hasOpenShoppingCart { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                var _subscriptionId = subscriptionId.Get(context);

                QueryExpression ordersForSubscription = new QueryExpression { EntityName = "etel_ordercapture", ColumnSet = new ColumnSet(true) };
                ordersForSubscription.Criteria = new FilterExpression();
                ordersForSubscription.Criteria.AddCondition("etel_subscriptionid", ConditionOperator.Equal, new Guid(_subscriptionId));
                EntityCollection ResourceCollectionList = ContextProvider.OrganizationService.RetrieveMultiple(ordersForSubscription);
                //statecode == "Inactive" and statuscode not starts with "Completed" 
                if (ResourceCollectionList != null)
                {
                    if (ResourceCollectionList.Entities.Count > 0)
                    {
                        var hasActiveOrder = ResourceCollectionList.Entities.Any(a => a.FormattedValues["statecode"] == "Active");

                        hasOpenShoppingCart.Set(context, hasActiveOrder);
                    }
                    else
                        hasOpenShoppingCart.Set(context, false);
                }
                else
                    hasOpenShoppingCart.Set(context, false);
            }
            catch (System.Exception ex)
            {
            }
        }
    }
}
