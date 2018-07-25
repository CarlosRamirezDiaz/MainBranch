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

namespace AmxPeruPSBActivities.Activities.Individual
{

    public sealed class AmxPeruCTIService : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruCTIServiceRequest> CTIRequest { get; set; }
        public InArgument<string> CTIUrl { get; set; }
        public InArgument<string> CustomerSearchUrl { get; set; }
        public OutArgument<AmxPeruCTIServiceResponse> CTIResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AmxPeruCTIServiceResponse _response = null;
            var request = CTIRequest.Get(context);
            var ctiUrl = CTIUrl.Get(context);
            var customerSearchUrl = CustomerSearchUrl.Get(context);
            try
            {
                _response = new AmxPeruCTIServiceResponse();
                AmxPeruCTIServiceBusiness _business = new AmxPeruCTIServiceBusiness();
                _response = _business.SearchCustomerUri(request,ctiUrl,customerSearchUrl, ContextProvider.OrganizationService);
                CTIResponse.Set(context, _response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
