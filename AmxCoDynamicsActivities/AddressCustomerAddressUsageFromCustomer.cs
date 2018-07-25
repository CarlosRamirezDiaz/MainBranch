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
    public class AddressCustomerAddressUsageFromCustomer : CodeActivity
    {
        [Input("Customer address")]
        [ReferenceTarget("etel_customeraddress")]
        [RequiredArgument]
        public InArgument<EntityReference> InAddress { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InAddress.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erAddress)
        {
            Entity eAddress = service.Retrieve(erAddress.LogicalName, erAddress.Id, new ColumnSet("amx_delivery", "amx_installation", "amx_invoicecontract", "amx_mobileservice"));

            if (eAddress != null)
            {
                string codesAddressUsage = "";
                string labelsAddressUsage = "";

                Entity eAddressUpdate = new Entity(erAddress.LogicalName, erAddress.Id);

                if ((bool)eAddress["amx_invoicecontract"])
                {
                    codesAddressUsage = fillCodesAndLabels("173800000", codesAddressUsage);
                    labelsAddressUsage = fillCodesAndLabels("Invoice/Contract", labelsAddressUsage);                    
                }

                if ((bool)eAddress["amx_delivery"])
                {
                    codesAddressUsage = fillCodesAndLabels("173800001", codesAddressUsage);
                    labelsAddressUsage = fillCodesAndLabels("Delivery", labelsAddressUsage);
                }

                if ((bool)eAddress["amx_installation"])
                {
                    codesAddressUsage = fillCodesAndLabels("173800002", codesAddressUsage);
                    labelsAddressUsage = fillCodesAndLabels("Installation", labelsAddressUsage);
                }

                if ((bool)eAddress["amx_mobileservice"])
                {
                    codesAddressUsage = fillCodesAndLabels("173800003", codesAddressUsage);
                    labelsAddressUsage = fillCodesAndLabels("Mobile services", labelsAddressUsage);
                }

                eAddressUpdate["amx_addressusagecode"] = codesAddressUsage;
                eAddressUpdate["amx_addressusagelabel"] = labelsAddressUsage;

                service.Update(eAddressUpdate);
            }
        }

        private string fillCodesAndLabels(string value, string addressUsage)
        {
            if (string.IsNullOrEmpty(addressUsage))
            {
                addressUsage = value;
            }
            else
            {
                addressUsage = addressUsage + "," + value;
            }

            return addressUsage;
        }
        
    }
}
