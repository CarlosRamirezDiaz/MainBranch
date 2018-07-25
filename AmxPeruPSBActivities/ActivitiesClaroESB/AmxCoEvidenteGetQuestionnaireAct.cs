using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using AmxCoPSBActivities.BusinessClaroESB;
using AmxPeruPSBActivities.Model;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;

namespace AmxPeruPSBActivities.ActivitiesClaroESB
{

    public sealed class AmxCoEvidenteGetQuestionnaireAct : XrmAwareCodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<AmxCoPSBActivities.Model.Evidente.AmxCoGetQuestionnaireRequest> request { get; set; }
        public OutArgument<AmxCoPSBActivities.Model.Evidente.AmxCoGetQuestionnaireResponse> response { get; set; }
        public InArgument<string> evidenteURL { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            var evidenteBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoEvidenteBusiness(ContextProvider.OrganizationService);

            string evidenteURL = context.GetValue(this.evidenteURL);

            var request = context.GetValue(this.request);

            try
            {
                var questionnaire = evidenteBusiness.GetQuestionnaire(request, evidenteURL);

                context.SetValue(response, questionnaire);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
