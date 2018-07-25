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
    public class ContactInformationValidatePrimary : CodeActivity
    {
        [Input("Contact information")]
        [ReferenceTarget("amx_customercontactinformation")]
        [RequiredArgument]
        public InArgument<EntityReference> InContactInformation { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InContactInformation.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erContactInformation)
        {
            Entity eContactInformation = service.Retrieve(erContactInformation.LogicalName, erContactInformation.Id,
                new ColumnSet("amx_individualcustomerid", "amx_contacttype"));

            if (eContactInformation != null)
            {
                if (eContactInformation.Contains("amx_individualcustomerid") && eContactInformation.Contains("amx_contacttype"))
                {
                    QueryExpression query = new QueryExpression("amx_customercontactinformation");
                    query.ColumnSet = new ColumnSet(false);
                    query.Criteria.AddCondition("amx_primarycontacttype", ConditionOperator.Equal, true);
                    query.Criteria.AddCondition("amx_individualcustomerid", ConditionOperator.Equal, ((EntityReference)eContactInformation["amx_individualcustomerid"]).Id);
                    query.Criteria.AddCondition("amx_contacttype", ConditionOperator.Equal, ((OptionSetValue)eContactInformation["amx_contacttype"]).Value);
                    
                    EntityCollection ecConInfos = service.RetrieveMultiple(query);

                    if (ecConInfos.Entities.Count > 1)
                    {
                        throw new InvalidPluginExecutionException("El usuario no debe tener mas de una información de contacto primaria.");
                    }
                }
            }
        }
    }
}
