using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace AmxDynamicsActivities
{

    public class UpdateCustomerCreateBILog : CodeActivity
    {
        [Input("BI Update Customer")]
        [ReferenceTarget("amx_updatecustomer")]
        [RequiredArgument]
        public InArgument<EntityReference> InUpdateCustomer { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InUpdateCustomer.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erUpdateCustomer)
        {
            Entity eUpdateCustomer = service.Retrieve(erUpdateCustomer.LogicalName, erUpdateCustomer.Id, new ColumnSet("amx_individual", "ownerid"));

            if (eUpdateCustomer != null)
            {
                QueryExpression queryHeader = new QueryExpression("etel_bi_header");
                queryHeader.ColumnSet = new ColumnSet("activityid", "createdon");
                queryHeader.Criteria.AddCondition("createdby", ConditionOperator.Equal, ((EntityReference)eUpdateCustomer["ownerid"]).Id);
                queryHeader.Criteria.AddCondition("etel_headerstatus", ConditionOperator.Equal, true);

                EntityCollection ecHeader = service.RetrieveMultiple(queryHeader);

                Entity eBillingLogCreate = new Entity("etel_bi_log");
                if (ecHeader.Entities.Count > 0)
                {
                    eBillingLogCreate["etel_bi_headerid"] = ecHeader.Entities[0].ToEntityReference();
                    eBillingLogCreate["actualstart"] = (DateTime)ecHeader.Entities[0]["createdon"];
                }

                eBillingLogCreate["subject"] = "Update Customer - In Review";
                eBillingLogCreate["etel_description"] = "Request Update Customer Send";
                eBillingLogCreate["etel_customerchannel"] = "External channel";
                eBillingLogCreate["actualend"] = DateTime.Now;

                EntityReference erContact = (EntityReference)eUpdateCustomer["amx_individual"];
                Entity party1 = new Entity("activityparty");
                party1["partyid"] = new EntityReference(erContact.LogicalName, erContact.Id);
                EntityCollection entCollection = new EntityCollection();
                entCollection.Entities.Add(party1);

                eBillingLogCreate["customers"] = entCollection;
                eBillingLogCreate["etel_individualcustomerid"] = erContact;
                eBillingLogCreate["regardingobjectid"] = erUpdateCustomer;
                eBillingLogCreate["ownerid"] = (EntityReference)eUpdateCustomer["ownerid"];

                service.Create(eBillingLogCreate);
            }
        }
    }
}