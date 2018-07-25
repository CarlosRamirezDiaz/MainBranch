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

    public sealed class AmxPeruCreateProspect : XrmAwareCodeActivity
    {
        public InArgument<AxmPeruCreateProspectRequest> ProspectRequest { get; set; }
        public OutArgument<AxmPeruCreateProspectResponse> ProspectResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AxmPeruCreateProspectResponse _response = null;
            var _request = ProspectRequest.Get(context);
            try
            {
                _response = new AxmPeruCreateProspectResponse();
                AmxPeruCreateProspectBusiness _business = new AmxPeruCreateProspectBusiness();
                _response = _business.CreateProspectCustomer(_request, ContextProvider.OrganizationService);
                ProspectResponse.Set(context, _response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
