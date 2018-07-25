using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System.Activities;
using System.Collections.Generic;
using System.Linq;

namespace AmxPeruPSBActivities.Activities.Common
{
    public class AmxCoGetEntities : XrmAwareCodeActivity
    {
        [RequiredArgument]
        public InArgument<string> EntityLogicalName { get; set; }

        [RequiredArgument]
        public InArgument<ColumnSet> ColumnSet { get; set; }

        public InArgument<List<ConditionExpression>> Conditions { get; set; }

        public OutArgument<List<Entity>> ResultEntities { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var entityName = EntityLogicalName.Get(context);

            var filter = new FilterExpression();
            filter.Conditions.AddRange(Conditions.Get(context));

            var result = ContextProvider.OrganizationService.RetrieveMultiple(
                new QueryExpression()
                {
                    ColumnSet = ColumnSet.Get(context),
                    EntityName = EntityLogicalName.Get(context),
                    Criteria = filter
                }
            );
            ResultEntities.Set(context, result.Entities.ToList());
        }
    }
}
