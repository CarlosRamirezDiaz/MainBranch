using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model.AffiliateDisaffiliate;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.AffilateDisaffiliate
{
    public class AffiliateDisaffiliateDataProtection : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruDataProtectionRequest> DataProtectionRequest { get; set; }
        public OutArgument<AmxPeruDataProtectionResponse> DataProtectionResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var request = DataProtectionRequest.Get(context);
            AmxPeruDataProtectionResponse response = null;
            if (request != null)
            {
                response = new AmxPeruDataProtectionResponse();
                AmxPeruAffiliateDisaffiliateDataProtectionBusiness _business = new AmxPeruAffiliateDisaffiliateDataProtectionBusiness();
                response = _business.UpdateCustomerDataProtection(request, ContextProvider.OrganizationService);
            }
            DataProtectionResponse.Set(context, response);
        }
    }
}
