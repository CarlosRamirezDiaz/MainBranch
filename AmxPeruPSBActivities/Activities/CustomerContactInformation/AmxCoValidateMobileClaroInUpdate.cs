using AmxPeruPSBActivities.Model.CustomerContactInformation;
using AmxPeruPSBActivities.Service.CustomerContactInformation;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.CustomerContactInformation
{
    public class AmxCoValidateMobileClaroInUpdate : XrmAwareCodeActivity
    {
        public InArgument<AmxCoValidateMobileClaroInUpdateRequest> custContactValRequest { get; set; }

        public OutArgument<AmxCoValidateMobileClaroInUpdateResponse> custContactValResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                AmxCoValidateMobileClaroInUpdateService objCustomerCampaignService = new AmxCoValidateMobileClaroInUpdateService();
                AmxCoValidateMobileClaroInUpdateResponse objResponse = objCustomerCampaignService.validateMobileClaro(custContactValRequest.Get(context), ContextProvider.OrganizationService);
                custContactValResponse.Set(context, objResponse);
            }
            catch (Exception)
            {

            }
        }
    }
}
