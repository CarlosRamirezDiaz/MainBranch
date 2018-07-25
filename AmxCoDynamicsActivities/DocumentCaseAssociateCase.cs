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
    public class DocumentCaseAssociateCase : CodeActivity
    {
        [Input("Document")]
        [ReferenceTarget("amx_documentspercase")]
        [RequiredArgument]
        public InArgument<EntityReference> InDocument { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InDocument.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erDocument)
        {
            Entity eDocument = service.Retrieve(erDocument.LogicalName, erDocument.Id, new ColumnSet("amx_caseid", "amx_documentid"));

            if (eDocument.Contains("amx_caseid") && eDocument.Contains("amx_documentid"))
            {
                QueryExpression query = new QueryExpression("incident");
                query.ColumnSet = new ColumnSet("amx_documents", "ticketnumber");
                query.Criteria.AddCondition("incidentid", ConditionOperator.Equal, Guid.Parse(eDocument["amx_caseid"].ToString()));

                EntityCollection ecIncidents = service.RetrieveMultiple(query);

                if (ecIncidents.Entities.Count > 0)
                {
                    Entity eIncident = ecIncidents.Entities[0];

                    Entity eIncidentUpdate = new Entity("incident");
                    eIncidentUpdate.Id = eIncident.Id;

                    if (ecIncidents.Entities[0].Contains("amx_documents"))
                    {
                        eIncidentUpdate["amx_documents"] = eIncident["amx_documents"].ToString() + "," + eDocument["amx_documentid"].ToString();
                    }
                    else
                    {
                        eIncidentUpdate["amx_documents"] = eDocument["amx_documentid"].ToString();
                    }

                    service.Update(eIncidentUpdate);

                    Entity eDocumentUpdate = new Entity(eDocument.LogicalName);
                    eDocumentUpdate.Id = eDocument.Id;
                    eDocumentUpdate["amx_name"] = eIncident["ticketnumber"].ToString() + " - " + eDocument["amx_documentid"].ToString();
                    eDocumentUpdate["amx_case"] = eIncident.ToEntityReference();

                    service.Update(eDocumentUpdate);
                }
            }            
        }
    }
}
