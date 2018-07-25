using AmxPeruPSBActivities.AMXCOLOMBIA.Business.BillCycleChange;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System.Activities;

namespace AmxPeruPSBActivities.AMXCOLOMBIA
{
    public class AmxGetCustomerBillingAccounts : XrmAwareCodeActivity
    {
        #region Input/Output Arguments
        public InArgument<AmxCoCustomerReadServiceRequest> CustomerReadRequest { get; set; }
        public InArgument<string> HostUrl { get; set; }
        public OutArgument<string> CustomerReadResponse { get; set; }
        #endregion

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            System.Diagnostics.Debugger.Launch();
            var jsonResponseStr = "";
            if (CustomerReadRequest.Get(context) != null)
            {
                jsonResponseStr = new AmxCoCustomerReadBusiness().GetCustomerBillDetails(CustomerReadRequest.Get(context), HostUrl.Get(context), ContextProvider.OrganizationService);
            }
            CustomerReadResponse.Set(context, jsonResponseStr);
        }
    }
}
