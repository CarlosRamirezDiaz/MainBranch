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
    public class CaseValidateGenerateCUN : CodeActivity
    {
        [Input("Case")]
        [ReferenceTarget("incident")]
        [RequiredArgument]
        public InArgument<EntityReference> InIncident { get; set; }

        [Output("Validate")]
        [RequiredArgument]
        public OutArgument<bool> OutIncident { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            bool booValidate = this.Run(service, InIncident.Get(executionContext));

            OutIncident.Set(executionContext, booValidate);
        }

        public bool Run(IOrganizationService service, EntityReference erIncident)
        {
            bool booValidate = true;

            Entity eIncident = service.Retrieve(erIncident.LogicalName, erIncident.Id, new ColumnSet("amx_casetype"));

            if (eIncident != null)
            {
                string familyTV = string.Empty;

                QueryExpression queryParameters = new QueryExpression("etel_crmconfiguration");
                queryParameters.ColumnSet = new ColumnSet("etel_value", "etel_name");
                queryParameters.Criteria.FilterOperator = LogicalOperator.Or;
                queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Family_Product_TV");

                EntityCollection ecParameters = service.RetrieveMultiple(queryParameters);

                foreach (Entity eParam in ecParameters.Entities)
                {
                    string nameParam = string.Empty;
                    if (eParam.Contains("etel_name"))
                        nameParam = eParam["etel_name"].ToString();

                    if (nameParam.Equals("Family_Product_TV")) { familyTV = eParam["etel_value"].ToString(); }                    
                }

                QueryExpression query = new QueryExpression("amx_productsincase");
                query.ColumnSet = new ColumnSet("amx_productfamily");
                query.Criteria.AddCondition("amx_case", ConditionOperator.Equal, erIncident.Id);
                query.Criteria.AddCondition("amx_selected", ConditionOperator.Equal, true);

                FilterExpression feFamily = new FilterExpression(LogicalOperator.Or);
                feFamily.AddCondition("amx_productfamily", ConditionOperator.Equal, familyTV);
                feFamily.AddCondition("amx_productfamily", ConditionOperator.Null);

                query.Criteria.AddFilter(feFamily);

                EntityCollection ecIncident = service.RetrieveMultiple(query);

                if (ecIncident.Entities.Count > 0)
                {
                    booValidate = false;
                }
            }

            return booValidate;
        }
    }
}
