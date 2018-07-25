
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace AmxDynamicsActivities
{
    public class CaseGenerateResource : CodeActivity
    {
        [Input("Incident")]
        [ReferenceTarget("incident")]
        [RequiredArgument]
        public InArgument<EntityReference> InIncident { get; set; }

        [Output("Id Resources")]
        [RequiredArgument]
        public OutArgument<string> OutResource { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            string idResource = this.Run(service, InIncident.Get(executionContext));
            OutResource.Set(executionContext, idResource);
        }

        public string Run(IOrganizationService service, EntityReference erIncident)
        {
            Guid idResource = Guid.Empty;
            Entity eIncidentParent = service.Retrieve(erIncident.LogicalName, erIncident.Id, new Microsoft.Xrm.Sdk.Query.ColumnSet(true));
            Entity eIncidentResource = new Entity(eIncidentParent.LogicalName);
            eIncidentResource["amx_resource"] = eIncidentParent.ToEntityReference();

            foreach (var key in eIncidentParent.Attributes)
            {
                if (!key.Key.Equals("parentcaseid") && !key.Key.Equals("incidentid")
                    && !key.Key.Equals("createdon") && !key.Key.Equals("ownerid")
                    && !key.Key.Equals("amx_state"))
                {
                    eIncidentResource.Attributes.Add(key.Key, key.Value);
                }
            }

            idResource = service.Create(eIncidentResource);

            Entity eIncidentUpdate = new Entity(eIncidentParent.LogicalName, eIncidentParent.Id);
            eIncidentUpdate["amx_haveresourse"] = true;

            service.Update(eIncidentUpdate);

            return idResource.ToString();
        }
    }
}
