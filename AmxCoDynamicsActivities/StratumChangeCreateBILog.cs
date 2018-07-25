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
    public class StratumChangeCreateBILog : CodeActivity
    {
        [Input("Cambio de estrato")]
        [ReferenceTarget("amx_stratumchange")]
        [RequiredArgument]
        public InArgument<EntityReference> InStratumChange { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InStratumChange.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erStratumChange)
        {
            Entity eStratumChange = service.Retrieve(erStratumChange.LogicalName, erStratumChange.Id, new ColumnSet("amx_individualcustomer", "ownerid"));

            if (eStratumChange != null)
            {
                QueryExpression queryHeader = new QueryExpression("etel_bi_header");
                queryHeader.ColumnSet = new ColumnSet("activityid", "createdon");
                queryHeader.Criteria.AddCondition("createdby", ConditionOperator.Equal, ((EntityReference)eStratumChange["ownerid"]).Id);
                queryHeader.Criteria.AddCondition("etel_headerstatus", ConditionOperator.Equal, true);

                EntityCollection ecHeader = service.RetrieveMultiple(queryHeader);

                Entity eBillingLogCreate = new Entity("etel_bi_log");
                if (ecHeader.Entities.Count > 0)
                {
                    eBillingLogCreate["etel_bi_headerid"] = ecHeader.Entities[0].ToEntityReference();
                    eBillingLogCreate["actualstart"] = (DateTime)ecHeader.Entities[0]["createdon"];
                }

                eBillingLogCreate["subject"] = "Stratum Change - In Review";
                eBillingLogCreate["etel_description"] = "Request Stratum Change Send";
                eBillingLogCreate["etel_customerchannel"] = "External channel";
                eBillingLogCreate["actualend"] = DateTime.Now;

                EntityReference erContact = (EntityReference)eStratumChange["amx_individualcustomer"];
                Entity party1 = new Entity("activityparty");
                party1["partyid"] = new EntityReference(erContact.LogicalName, erContact.Id);
                EntityCollection entCollection = new EntityCollection();
                entCollection.Entities.Add(party1);

                eBillingLogCreate["customers"] = entCollection;
                eBillingLogCreate["etel_individualcustomerid"] = erContact;
                eBillingLogCreate["regardingobjectid"] = erStratumChange;
                eBillingLogCreate["ownerid"] = (EntityReference)eStratumChange["ownerid"];

                service.Create(eBillingLogCreate);
            }
        }
    }
}
