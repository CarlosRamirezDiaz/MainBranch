using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model.AffiliateDisaffiliate;
using AmxPeruPSBActivities.Business;
using ExternalApiActivities.Common;

namespace AmxPeruPSBActivities.Activities.AffilateDisaffiliate
{
    public class AmxPeruAffiliateDisaffiliatetoWhitePagesActivity : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruAffiliateDisaffiliatetoWhitePagesRequest> WhitePageRequest { get; set; }
        public OutArgument<AmxPeruAffiliateDisaffiliatetoWhitePagesResponse> WhitePageResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                var request = WhitePageRequest.Get(context);
                AmxPeruAffiliateDisaffiliatetoWhitePagesResponse response = null;
                if (request != null)
                {
                    response = new AmxPeruAffiliateDisaffiliatetoWhitePagesResponse();
                    AmxPeruAffiliateDisaffiliatetoWhitePagesBusiness _business = new AmxPeruAffiliateDisaffiliatetoWhitePagesBusiness();
                    response = _business.UpdateSubscriptionWhitePage(request, ContextProvider.OrganizationService);
                }
                WhitePageResponse.Set(context, response);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
