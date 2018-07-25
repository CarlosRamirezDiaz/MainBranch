using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.InternalExternalAccount;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.InternalExternalAccount
{
    public class AmcCoGenerateSimulation : XrmAwareCodeActivity
    {
        public InArgument<AmcCoGenerateSimulationRequest> objRequest { get; set; }

        public OutArgument<AmcCoGenerateSimulationResponse> objResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                var objSimulation = new AmcCoGenerateSimulationBusiness();
                AmcCoGenerateSimulationResponse objResponse = objSimulation.SimularionBilling(objRequest.Get(context), ContextProvider.OrganizationService);
                this.objResponse.Set(context, objResponse);
            }
            catch (Exception)
            {

            }
        }
    }
}
