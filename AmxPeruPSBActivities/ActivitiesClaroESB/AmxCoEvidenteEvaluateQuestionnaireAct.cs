using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using AmxCoPSBActivities.ModelClaroESB.Evidente;
using AmxCoPSBActivities.Model.Evidente;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;

namespace AmxPeruPSBActivities.ActivitiesClaroESB
{

    public sealed class AmxCoEvidenteEvaluateQuestionnaireAct : XrmAwareCodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<AmxCoEvaluateQuestionnaireRequest> EvaluateQuestionnaireRequest { get; set; }
        public InArgument<string> evidenteURL { get; set; }
        
        public OutArgument<AmxCoEvaluateQuestionnaireResponse> EvaluateQuestionnaireResponse { get; set; }


        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            var evidenteBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoEvidenteBusiness(ContextProvider.OrganizationService);

            AmxCoEvaluateQuestionnaireRequest request = context.GetValue(this.EvaluateQuestionnaireRequest);
            string evidenteURL = context.GetValue(this.evidenteURL);

            var resp = evidenteBusiness.EvaluateQuestionnaire(request, evidenteURL, Guid.Empty, Guid.Empty);

            context.SetValue(EvaluateQuestionnaireResponse, resp);
        }
    }
}
