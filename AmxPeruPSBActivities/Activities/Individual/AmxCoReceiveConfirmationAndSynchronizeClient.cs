using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.Individual;
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
    public class AmxCoReceiveConfirmationAndSynchronizeClient : XrmAwareCodeActivity
    {
        public InArgument<AmxCoReceiveConfirmationAndSynchronizeClientRequest> objAmxCoSynchronizeClientRequest { get; set; }

        public OutArgument<AmxCoReceiveConfirmationAndSynchronizeClientResponse> objAmxCoSynchronizeClientResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                AmxCoReceiveConfirmationAndSynchronizeClientBusiness business = new AmxCoReceiveConfirmationAndSynchronizeClientBusiness();
                AmxCoReceiveConfirmationAndSynchronizeClientResponse objResponse = business.AmxCoSynchronizeClient(ContextProvider.OrganizationService, objAmxCoSynchronizeClientRequest.Get(context));
                objAmxCoSynchronizeClientResponse.Set(context, objResponse);
            }
            catch (Exception)
            {

            }
        }
    }
}
