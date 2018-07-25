using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model;
using AmxPSBActivities.Business;
using AmxPSBActivities.Model;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPSBActivities.Activities.Individual
{
    public class AmxGetCustomerInfo : XrmAwareCodeActivity
    {

        public InArgument<AmxGetCustomerInfoRequest> customerRequest { get; set; }

        public OutArgument<AmxGetCustomerInfoResponse> customerResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var request = customerRequest.Get(context);
            AmxGetCustomerInfoResponse _response = null;
            try
            {
                _response = new AmxGetCustomerInfoResponse();
                AmxGetCustomerInfoBusiness _business = new AmxGetCustomerInfoBusiness(ContextProvider.OrganizationService);
                _response = _business.GetCustomerInfo(request);
                customerResponse.Set(context, _response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
