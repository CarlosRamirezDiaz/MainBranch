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
    public class ContactInformationLoadSubgrid : CodeActivity
    {
        [Input("Individual customer")]
        [ReferenceTarget("contact")]
        [RequiredArgument]
        public InArgument<EntityReference> InIndividual { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InIndividual.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erIndividual)
        {
            QueryExpression query = new QueryExpression("amx_customercontactinformation");
            query.ColumnSet = new ColumnSet("amx_contacttype", "amx_email", "amx_phoneno");
            query.Criteria.AddCondition("amx_contactinformation", ConditionOperator.Null);
            query.Criteria.AddCondition("amx_individualcustomerid", ConditionOperator.Equal, erIndividual.Id);

            EntityCollection ecAddress = service.RetrieveMultiple(query);

            foreach (Entity eContactInf in ecAddress.Entities)
            {
                if (eContactInf.Contains("amx_contacttype"))
                {
                    if (((OptionSetValue)eContactInf["amx_contacttype"]).Value == 173800000)
                    {
                        if (eContactInf.Contains("amx_email"))
                        {
                            Entity eContactUpdate = new Entity(eContactInf.LogicalName, eContactInf.Id);
                            eContactUpdate["amx_contactinformation"] = eContactInf["amx_email"].ToString();
                            service.Update(eContactUpdate);
                        }
                    }
                    else
                    {
                        if (eContactInf.Contains("amx_phoneno"))
                        {
                            Entity eContactUpdate = new Entity(eContactInf.LogicalName, eContactInf.Id);
                            eContactUpdate["amx_contactinformation"] = eContactInf["amx_phoneno"].ToString();
                            service.Update(eContactUpdate);
                        }
                    }
                }
            }
        }
    }
}
