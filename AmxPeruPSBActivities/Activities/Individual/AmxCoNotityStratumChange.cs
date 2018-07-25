using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.Individual;
using AmxPeruPSBActivities.Model.StratumChange;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.Individual
{
    public class AmxCoNotityStratumChange : XrmAwareCodeActivity
    {
        public InArgument<AmxCoNotityStratumChangeRequest> objAmxCoNotityStratumChangeRequest { get; set; }

        public OutArgument<AmxCoNotityStratumChangeResponse> objAmxCoNotityStratumChangeResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                AmxCoNotityStratumChangeBusiness business = new AmxCoNotityStratumChangeBusiness();
                AmxCoNotityStratumChangeResponse objResponse = business.AmxCoNotityStratumChange(ContextProvider.OrganizationService, objAmxCoNotityStratumChangeRequest.Get(context));
                objAmxCoNotityStratumChangeResponse.Set(context, objResponse);
            }
            catch (Exception)
            {

            }
        }
    }
}
