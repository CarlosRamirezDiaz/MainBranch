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
    public class UpdateDigitalDateCreateBILog : CodeActivity
    {
        [Input("Individual")]
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
            Entity eIndividual = service.Retrieve(erIndividual.LogicalName, erIndividual.Id, new ColumnSet("ownerid", "modifiedby"));

            if (eIndividual != null)
            {
                QueryExpression queryHeader = new QueryExpression("etel_bi_header");
                queryHeader.ColumnSet = new ColumnSet("activityid", "createdon");
                queryHeader.Criteria.AddCondition("createdby", ConditionOperator.Equal, ((EntityReference)eIndividual["ownerid"]).Id);
                queryHeader.Criteria.AddCondition("etel_headerstatus", ConditionOperator.Equal, true);

                EntityCollection ecHeader = service.RetrieveMultiple(queryHeader);

                Entity eBillingLogCreate = new Entity("etel_bi_log");
                if (ecHeader.Entities.Count > 0)
                {
                    eBillingLogCreate["etel_bi_headerid"] = ecHeader.Entities[0].ToEntityReference();
                    eBillingLogCreate["actualstart"] = (DateTime)ecHeader.Entities[0]["createdon"];
                }
                eBillingLogCreate["scheduledend"] = DateTime.Now;
                eBillingLogCreate["subject"] = "Update Digital Date";
                eBillingLogCreate["etel_description"] = "Request Update Digital Date Sended";
                eBillingLogCreate["scheduledend"] = "External channel";
                eBillingLogCreate["actualend"] = DateTime.Now;

                Entity party1 = new Entity("activityparty");
                party1["partyid"] = new EntityReference(erIndividual.LogicalName, erIndividual.Id);
                EntityCollection entCollection = new EntityCollection();
                entCollection.Entities.Add(party1);

                eBillingLogCreate["customers"] = entCollection;
                eBillingLogCreate["etel_individualcustomerid"] = erIndividual;
                eBillingLogCreate["scheduledend"] = DateTime.Now;
                eBillingLogCreate["ownerid"] = (EntityReference)eIndividual["modifiedby"];

                service.Create(eBillingLogCreate);
            }
        }
    }
}
