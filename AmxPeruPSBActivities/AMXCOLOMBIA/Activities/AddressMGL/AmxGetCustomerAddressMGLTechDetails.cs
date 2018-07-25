using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using Ericsson.PSB.Workflow.Activities;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA
{
    public class AmxGetCustomerAddressMGLTechDetails : XrmAwareCodeActivity
    {
        #region Input/Output Arguments
        public InArgument<Model.AddressMGLtechDetails> CustomerAddressRequest { get; set; }
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
                    .GetCustomerAddressMGLTechDetails(request, MGLUser.Get(context), HostUrl.Get(context), HeaderRequestStr.Get(context), ContextProvider.OrganizationService);
            }
            CustomerAddressResponse.Set(context, jsonResponseStr);
        }
    }
}
