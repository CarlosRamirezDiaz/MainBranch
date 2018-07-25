using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.CompanyClientList
{
    public class AmxPeruGetCompanyClientInfo : XrmAwareCodeActivity
    {

        public InArgument<AmxPeruCompanyClientlistRequest> inputObject { get; set; }
        public OutArgument<AmxPeruCompanyClientlistResponse> outputObject { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AmxPeruCompanyClientlistResponse _AmxPeruCompanyClientlistResponse = null;
            try
            {
                AmxPeruGetCompanyClientInfoBusiness _AmxPeruGetCompanyClientBusiness = new AmxPeruGetCompanyClientInfoBusiness();
                _AmxPeruCompanyClientlistResponse = _AmxPeruGetCompanyClientBusiness.AmxperuGetcompanyList(inputObject.Get(context), ContextProvider.OrganizationService);
                context.SetValue(outputObject, _AmxPeruCompanyClientlistResponse);

            }
            catch (Exception ex)
            {
                throw;

            }
        }

    }
}
