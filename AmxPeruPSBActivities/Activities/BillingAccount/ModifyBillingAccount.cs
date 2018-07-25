using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.BillingAccount
{
    public sealed class ModifyBillingAccount : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruModifyBillingAccountRequest> inputObject { get; set; }
        public OutArgument<AmxPeruModifyBillingAccountResponse> outputObject { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AmxPeruModifyBillingAccountRequest _request = new AmxPeruModifyBillingAccountRequest();
            AmxPeruModifyBillingAccountResponse _response = new AmxPeruModifyBillingAccountResponse();
            _request = inputObject.Get(context);
            BillingAccountBusiness billingAccountBusiness = new BillingAccountBusiness();
            _response = billingAccountBusiness.UpdateBA(_request, ContextProvider.OrganizationService);
        }
    }
}
