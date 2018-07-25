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
    public class AddressCustomerCheckAddressUsage : CodeActivity
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
            QueryExpression query = new QueryExpression("etel_customeraddress");
            query.ColumnSet = new ColumnSet("amx_addressusagecode");
            query.Criteria.AddCondition("etel_individualcustomerid", ConditionOperator.Equal, erIndividual.Id);

            EntityCollection ecAddresses = service.RetrieveMultiple(query);

            foreach (Entity eAddress in ecAddresses.Entities)
            {
                if (eAddress.Contains("amx_addressusagecode"))
                {
                    char[] crSeparator = { ',' };
                    string[] codesAddressUsage = eAddress["amx_addressusagecode"].ToString().Split(crSeparator);

                    Entity eAddressUpdate = new Entity(eAddress.LogicalName, eAddress
                        .Id);
                    eAddressUpdate["amx_delivery"] = false;
                    eAddressUpdate["amx_installation"] = false;
                    eAddressUpdate["amx_invoicecontract"] = false;
                    eAddressUpdate["amx_mobileservice"] = false;

                    foreach (string addressusage in codesAddressUsage)
                    {
                        switch (addressusage)
                        {
                            case "173800000":
                                eAddressUpdate["amx_invoicecontract"] = true;
                                break;
                            case "173800001":
                                eAddressUpdate["amx_delivery"] = true;
                                break;
                            case "173800002":
                                eAddressUpdate["amx_installation"] = true;
                                break;
                            case "173800003":
                                eAddressUpdate["amx_mobileservice"] = true;
                                break;
                        }
                    }

                    service.Update(eAddressUpdate);
                }
            }
        }
    }
}
