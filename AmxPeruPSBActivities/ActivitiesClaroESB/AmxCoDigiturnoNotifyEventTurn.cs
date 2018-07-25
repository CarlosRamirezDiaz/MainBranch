using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using AmxCoPSBActivities.ModelClaroESB.Digiturno;
using AmxCoPSBActivities.Model.Digiturno;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;

namespace AmxPeruPSBActivities.ActivitiesClaroESB
{

    public sealed class AmxCoDigiturnoNotifyEventTurn : XrmAwareCodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<DigiturnoNotifyEventTurnRequest> request { get; set; }
        public InArgument<string> digiturnoUrl { get; set; }        
        public OutArgument<DigiturnoNotifyEventTurnResponse> response { get; set; }


        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            var digiturnoBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoDigiturnoBusiness();

            var request = context.GetValue(this.request);
            string digiturnoUrl = context.GetValue(this.digiturnoUrl);

            var resp = digiturnoBusiness.NotifyEventTurn(request, digiturnoUrl, ContextProvider.OrganizationService);

            context.SetValue(response, resp);
        }
    }
}
