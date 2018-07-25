using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
//using Ericsson.ETELCRM.Entities.Crm;
//using Microsoft.Xrm.Sdk;
//using AmxPeruPSBActivities.Model;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruPSBActivities.Model;

namespace AmxPeruPSBActivities.Activities.Individual
{

    public sealed class AmxPeruBlacklist : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruBlacklistRequest> inputObject { get; set; }
        public OutArgument<AmxPeruBlacklistResponse> outputObject { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AmxPeruBlacklistResponse _AmxPeruBlacklistResponse = null;

            try
            {
                _AmxPeruBlacklistResponse = new AmxPeruBlacklistResponse();

                //call business layer method for processing

                _AmxPeruBlacklistResponse.Status = "SUCCESS";

                //Set Values for the Out Parameter/Argument
                context.SetValue(outputObject, _AmxPeruBlacklistResponse);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
