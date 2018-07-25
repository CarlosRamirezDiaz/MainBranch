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
    public class DataModificationValidateRegarding : CodeActivity
    {
        [Input("BI Log")]
        [ReferenceTarget("etel_bi_log")]
        [RequiredArgument]
        public InArgument<EntityReference> InBILog { get; set; }

        [Output("Validate")]
        [RequiredArgument]
        public OutArgument<bool> InValidate { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            bool booValidate = this.Run(service, InBILog.Get(executionContext));
            InValidate.Set(executionContext, booValidate);
        }

        public bool Run(IOrganizationService service, EntityReference erBiLog)
        {
            bool booValidate = false;
            Entity eBiLog = service.Retrieve(erBiLog.LogicalName, erBiLog.Id, new ColumnSet("regardingobjectid"));

            if (eBiLog.Contains("regardingobjectid"))
            {
                QueryExpression query = new QueryExpression("etel_crmconfiguration");
                query.ColumnSet = new ColumnSet("etel_value");
                query.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "DataUpdateRegardingObject");

                EntityCollection ecAddresses = service.RetrieveMultiple(query);

                if (ecAddresses.Entities.Count > 0)
                {
                    if (ecAddresses.Entities[0].Contains("etel_value"))
                    {
                        string entityNameParam = ecAddresses.Entities[0]["etel_value"].ToString();
                        string entityName = ((EntityReference)eBiLog["regardingobjectid"]).LogicalName.ToUpper();

                        if (entityNameParam.ToUpper().Equals(entityName))
                        {
                            booValidate = true;
                        }
                    }
                }
            }

            return booValidate;
        }
    }
}
