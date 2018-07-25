using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxDynamicsActivities
{
    public class ConfigurationGetCaseState : CodeActivity
    {
        [Input("Parameter")]
        [RequiredArgument]
        public InArgument<string> InParameter { get; set; }

        [Output("State")]        
        [ReferenceTarget("amx_statecase")]
        [RequiredArgument]
        public OutArgument<EntityReference> OutState { get; set; }
        
        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            EntityReference outState = this.Run(service, InParameter.Get(executionContext));
            OutState.Set(executionContext, outState);
        }

        public EntityReference Run(IOrganizationService service, string parameter)
        {
            EntityReference erState = null;

            QueryExpression queryParameters = new QueryExpression("etel_crmconfiguration");
            queryParameters.ColumnSet = new ColumnSet("etel_value");
            queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, parameter);

            EntityCollection ecParam = service.RetrieveMultiple(queryParameters);

            if (ecParam.Entities.Count > 0)
            {
                QueryExpression query = new QueryExpression("amx_statecase");
                query.ColumnSet = new ColumnSet(false);
                query.Criteria.AddCondition("amx_name", ConditionOperator.Equal, ecParam.Entities[0]["etel_value"].ToString());

                EntityCollection ecStateCase = service.RetrieveMultiple(query);

                if (ecStateCase.Entities.Count > 0)
                {
                    erState = ecStateCase.Entities[0].ToEntityReference();
                }
            }

            return erState;
        }
    }
}
