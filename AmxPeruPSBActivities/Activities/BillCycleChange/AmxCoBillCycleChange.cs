using AmxPeruPSBActivities.AMXCOLOMBIA.Business.BillCycleChange;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System.Activities;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities.BillCycleChange
{
    public class AmxCoBillCycleChange : XrmAwareCodeActivity
    {
        #region Input/Output Arguments
        public InArgument<AmxCoBillCycleReadServiceRequest> BillCycleReadRequest { get; set; }
        public InArgument<string> HostUrl { get; set; }
        public OutArgument<string> BillCycleReadResponse { get; set; }
        #endregion

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            System.Diagnostics.Debugger.Launch();
            var jsonResponseStr = "";
            if (BillCycleReadRequest.Get(context) != null)
            {
                jsonResponseStr = new AmxCoBillCycleReadBusiness().GetBillCycleChangeDetails(BillCycleReadRequest.Get(context), HostUrl.Get(context), ContextProvider.OrganizationService);
            }
            BillCycleReadResponse.Set(context, jsonResponseStr);
        }
    }
}
