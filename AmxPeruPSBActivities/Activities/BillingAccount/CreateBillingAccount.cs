using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.BillingAccount
{
    public sealed class CreateBillingAccount : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruCreateBillingAccountRequest> inputObject { get; set; }
        public OutArgument<AmxPeruCreateBillingAccountResponse> outputObject { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AmxPeruCreateBillingAccountRequest _request = new AmxPeruCreateBillingAccountRequest();
            AmxPeruCreateBillingAccountResponse _response = new AmxPeruCreateBillingAccountResponse();
            _request = inputObject.Get(context);
            BillingAccountBusiness billingAccountBusiness = new BillingAccountBusiness();
            _response = billingAccountBusiness.CreateBillingAccount(_request, ContextProvider.OrganizationService);
        }
    }
}
