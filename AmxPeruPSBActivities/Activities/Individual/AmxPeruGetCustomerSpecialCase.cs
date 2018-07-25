using System;
using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.Individual
{

    public sealed class AmxPeruGetCustomerSpecialCase : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruGetCustomerSpecialCasesRequest> Request { get; set; }
        public OutArgument<AmxPeruGetCustomerSpecialCasesResponse> Response { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AmxPeruGetCustomerSpecialCasesResponse _response = null;
            var _request = Request.Get(context);
            try
            {
                _response = new AmxPeruGetCustomerSpecialCasesResponse();
                AmxPeruGetCustomerSpecialCasesBusiness _business = new AmxPeruGetCustomerSpecialCasesBusiness();
                _response = _business.GetSpecialCases(_request, ContextProvider.OrganizationService);
                Response.Set(context, _response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }       
    }
}
