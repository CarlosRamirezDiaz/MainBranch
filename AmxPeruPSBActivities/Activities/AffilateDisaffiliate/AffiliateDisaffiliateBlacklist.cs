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
using AmxPeruPSBActivities.Model.OrderCaptureSubmit;

namespace AmxPeruPSBActivities.Activities.AffilateDisaffiliate
{
   public class AffiliateDisaffiliateBlacklist : XrmAwareCodeActivity
    {
        public InArgument<AffiliateDisaffilateBlacklistRequest> BlacklistRequest { get; set; }

        public OutArgument<SubmitOrderRequest> BlacklistResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var request = BlacklistRequest.Get(context);
            SubmitOrderRequest response = null;
            if (request != null)
            {
                response = new SubmitOrderRequest();
                AmxPeruAffiliateDisaffilateBlacklistBusiness _business = new AmxPeruAffiliateDisaffilateBlacklistBusiness();
                response = _business.getOrderCaptureRequest(request, ContextProvider.OrganizationService);
            }
            BlacklistResponse.Set(context, response);
        }
    }
}
