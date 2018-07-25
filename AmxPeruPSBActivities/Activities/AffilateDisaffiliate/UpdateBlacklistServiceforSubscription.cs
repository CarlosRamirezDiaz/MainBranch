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
    public class UpdateBlacklistServiceforSubscription : XrmAwareCodeActivity
    {
        public InArgument<AffiliateDisaffilateBlacklistRequest> SubscriptionRequest { get; set; }

        public OutArgument<SubscriptionBlacklistResponse> SubscriptionResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var request = SubscriptionRequest.Get(context);
            SubscriptionBlacklistResponse response = null;
            if (request != null)
            {
                response = new SubscriptionBlacklistResponse();
                AmxPeruAffiliateDisaffilateBlacklistBusiness _business = new AmxPeruAffiliateDisaffilateBlacklistBusiness();
                response = _business.UpdateSubscriptionBlacklistFields(request, ContextProvider.OrganizationService);
            }
            SubscriptionResponse.Set(context, response);
        }
    }
}
