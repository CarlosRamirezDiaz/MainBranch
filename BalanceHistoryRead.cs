using AmxSoapServicesActivities.Business.BalanceEnquiry;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System.Activities;

namespace AmxSoapServicesActivities.Activities
{
    public class BalanceHistoryRead : XrmAwareCodeActivity
    {
        #region Input/Output Arguments
        public InArgument<Model.BalanceHistoryReadRequest> BalanceHistoryReadRequest { get; set; }
        public InArgument<string> HostUrl { get; set; }
        public OutArgument<string> BalanceHistoryReadResponse { get; set; }
        #endregion.
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var jsonResponseStr = "";
            if (BalanceHistoryReadRequest.Get(context) != null)
            {
                jsonResponseStr = new BalanceHistoryReadBusiness().GetBalanceHistoryReadDetails(BalanceHistoryReadRequest.Get(context), HostUrl.Get(context), ContextProvider.OrganizationService);
            }
            BalanceHistoryReadResponse.Set(context, jsonResponseStr);
        }
    }
}
