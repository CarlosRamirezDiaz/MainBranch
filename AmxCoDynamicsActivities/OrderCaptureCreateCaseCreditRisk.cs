using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxDynamicsActivities
{
    public class OrderCaptureCreateCaseCreditRisk : CodeActivity
    {
        [Input("Order capture")]
        [ReferenceTarget("etel_ordercapture")]
        [RequiredArgument]
        public InArgument<EntityReference> InOrderCapture { get; set; }

        [Output("Id incident")]
        [RequiredArgument]
        public OutArgument<string> OutIncident { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            string guidIncident = this.Run(service, InOrderCapture.Get(executionContext));
            OutIncident.Set(executionContext, guidIncident);
        }

        public string Run(IOrganizationService service, EntityReference erOrderCapture)
        {
            string guidIncidentId = string.Empty;
            Entity eOrderCapture = service.Retrieve(erOrderCapture.LogicalName, erOrderCapture.Id, new ColumnSet("etel_individualcustomerid"));

            if (eOrderCapture != null)
            {
                if (eOrderCapture.Contains("etel_individualcustomerid"))
                {
                    EntityReference erCaseType = null;

                    QueryExpression queryParameters = new QueryExpression("etel_crmconfiguration");
                    queryParameters.ColumnSet = new ColumnSet("etel_value", "etel_name");
                    queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Case_Type_Credit_Risk");

                    EntityCollection ecParameters = service.RetrieveMultiple(queryParameters);

                    if (ecParameters.Entities.Count > 0)
                    {
                        if (ecParameters.Entities[0].Contains("etel_value"))
                        {
                            QueryExpression queryCaseType = new QueryExpression("amxperu_casetype");
                            queryCaseType.ColumnSet = new ColumnSet(false);
                            queryCaseType.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, ecParameters.Entities[0]["etel_value"].ToString());

                            EntityCollection ecCaseType = service.RetrieveMultiple(queryCaseType);

                            if (ecCaseType.Entities.Count > 0)
                            {
                                erCaseType = ecCaseType.Entities[0].ToEntityReference();
                            }
                        }
                    }

                    Entity eIncidentCreate = new Entity("incident");
                    if (erCaseType != null) eIncidentCreate["amxperu_casetype"] = erCaseType;
                    eIncidentCreate["customerid"] = (EntityReference)eOrderCapture["etel_individualcustomerid"];
                    eIncidentCreate["amx_ordercapture"] = erOrderCapture;

                    Guid guidIdIncident = service.Create(eIncidentCreate);

                    guidIncidentId = guidIdIncident.ToString();
                }
            }

            return guidIncidentId;
        }
    }

}

