using AmxSoapServicesActivities.Business;
using AmxSoapServicesActivities.Model;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System.Activities;

namespace AmxSoapServicesActivities.Activities
{
    public class ContractsSearch : XrmAwareCodeActivity
    {
        #region Input/Output Arguments
        public InArgument<ContractsSearchRequest> ContractsSearchRequest { get; set; }
        public InArgument<string> HostUrl { get; set; }
        public OutArgument<string> ContractsSearchResponse { get; set; }
        #endregion

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var jsonResponseStr = "";
            if (ContractsSearchRequest.Get(context) != null)
            {
                jsonResponseStr = new ContractsSearchBusiness().GetContractsSearchDetails(ContractsSearchRequest.Get(context), HostUrl.Get(context), ContextProvider.OrganizationService);
            }
            ContractsSearchResponse.Set(context, jsonResponseStr);
        }
    }
}
