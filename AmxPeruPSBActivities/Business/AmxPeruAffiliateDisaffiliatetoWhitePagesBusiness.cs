using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model.AffiliateDisaffiliate;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace AmxPeruPSBActivities.Business
{
    public class AmxPeruAffiliateDisaffiliatetoWhitePagesBusiness
    {
        public AmxPeruAffiliateDisaffiliatetoWhitePagesResponse UpdateSubscriptionWhitePage(AmxPeruAffiliateDisaffiliatetoWhitePagesRequest _request, OrganizationServiceProxy _org)
        {
            AmxPeruAffiliateDisaffiliatetoWhitePagesResponse _response = null;
            if (_request != null)
            {
                _response = new AmxPeruAffiliateDisaffiliatetoWhitePagesResponse();
                Entity Subscription = new Entity("etel_subscription");
                if (!string.IsNullOrEmpty(_request.SubscriptionID))
                {
                    Guid SubscriptionGuid = new Guid(_request.SubscriptionID);
                    Subscription.Id = SubscriptionGuid;

                    if (_request.CurrentWhitePageValue !=250000000)
                    {
                        Subscription.Attributes["amxperu_whitepages"] = new OptionSetValue(_request.CurrentWhitePageValue);
                    }
                    _org.Update(Subscription);
                    _response.Status = "OK";
                    _response.successFlag = 1;
                }
            }
            return _response;
        }
    }
}
