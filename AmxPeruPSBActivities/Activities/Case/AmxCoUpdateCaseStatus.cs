using AmxPeruPSBActivities.Model.Case;
using AmxPeruPSBActivities.Service.Case;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.Case
{
    public class AmxCoUpdateCaseStatus : XrmAwareCodeActivity
    {
        public InArgument<AmxCoUpdateCaseStatusRequest> objUpdateCaseStatusRequest { get; set; }

        public OutArgument<AmxCoUpdateCaseStatusResponse> objUpdateCaseStatusResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                AmxCoUpdateCaseStatusService objUpdateCaseStatus = new AmxCoUpdateCaseStatusService();
                AmxCoUpdateCaseStatusResponse objResponse = objUpdateCaseStatus.UpdateCaseStatus(objUpdateCaseStatusRequest.Get(context), ContextProvider.OrganizationService);
                objUpdateCaseStatusResponse.Set(context, objResponse);
            }
            catch (Exception)
            {

            }
        }
    }
}
