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
    public class AmxCoSendSurvey : XrmAwareCodeActivity
    {
        public InArgument<AmxCoSendSurveyRequest> objAmxCoSendSurveyRequest { get; set; }

        public OutArgument<AmxCoSendSurveyResponse> objAmxCoSendSurveyResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                AmxCoSendSurveyBusiness business = new AmxCoSendSurveyBusiness();
                AmxCoSendSurveyResponse objResponse = business.AmxCoSendSurvey(ContextProvider.OrganizationService, objAmxCoSendSurveyRequest.Get(context));
                objAmxCoSendSurveyResponse.Set(context, objResponse);
            }
            catch (Exception)
            {

            }
        }
    }
}
