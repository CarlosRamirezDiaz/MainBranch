using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System.Activities;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities.AddressMGL
{
    public class AmxGetCustomerAddressHhpp : XrmAwareCodeActivity
    {
        #region Input/Output Arguments
        public InArgument<Model.AmxAddressMGLHhppRequest> CustomerAddressRequest { get; set; }
        public InArgument<string> MGLUser { get; set; }
        public InArgument<string> HostUrl { get; set; }
        public InArgument<string> HeaderRequestStr { get; set; }
        public OutArgument<string> CustomerAddressResponse { get; set; }

        #endregion

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var request = CustomerAddressRequest.Get(context);
            string jsonResponseStr = null;
            if (request != null)
            {
                jsonResponseStr = new AmxGetCustomerAddressBusiness()
                    .GetCustomerAddressHhpp(request, MGLUser.Get(context), HostUrl.Get(context), HeaderRequestStr.Get(context), ContextProvider.OrganizationService);
            }
            CustomerAddressResponse.Set(context, jsonResponseStr);
        }
    }
}
