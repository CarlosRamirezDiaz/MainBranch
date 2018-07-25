using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using AmxPeruPSBActivities.Model.CreditScore;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.CreditScore
{

    public sealed class AmxPeruGetCreditScore : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruGetCreditScoreRequest> inputObject { get; set; }
        public OutArgument<AmxPeruGetCreditScoreResponse> outputObject { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {

            AmxPeruGetCreditScoreResponse _AmxPeruGetCreditScoreResponse = null;
            try
            {
                AmxPeruGetCreditScoreBusiness _AmxPeruGetCreditScoreBusiness = new AmxPeruGetCreditScoreBusiness();

                _AmxPeruGetCreditScoreResponse = _AmxPeruGetCreditScoreBusiness.GetCreditScore(inputObject.Get(context), ContextProvider.OrganizationService);

                //call business layer method for processing

                _AmxPeruGetCreditScoreResponse.Status = "SUCCESS";
                //_AmxPeruGetCreditScoreResponse.SucessFlag = 1;
                //Set Values for the Out Parameter/Argument
                context.SetValue(outputObject, _AmxPeruGetCreditScoreResponse);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
