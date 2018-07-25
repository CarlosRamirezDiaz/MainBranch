using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
//using Ericsson.ETELCRM.Entities.Crm;
//using Microsoft.Xrm.Sdk;
//using AmxPeruPSBActivities.Model;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Business;
using AmxPSBActivities.Model;
using AmxPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.Individual
{

    public sealed class AmxCoCTIExistsCustomerByANI : XrmAwareCodeActivity
    {
        public InArgument<AmxGetCustomerInfoRequest> CTIRequest { get; set; }
        public OutArgument<AmxGetCustomerInfoResponse> CTIResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AmxGetCustomerInfoResponse _response = null;
            var request = CTIRequest.Get(context);
            try
            {
                _response = new AmxGetCustomerInfoResponse();
                AmxGetCustomerInfoBusiness _business = new AmxGetCustomerInfoBusiness(ContextProvider.OrganizationService);
                _response = _business.GetCustomerInfo(request);
                CTIResponse.Set(context, _response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
