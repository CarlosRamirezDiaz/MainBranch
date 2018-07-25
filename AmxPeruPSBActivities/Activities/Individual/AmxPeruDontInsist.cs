using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.Individual
{
    public class AmxPeruDontInsist : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruDontInsistRequest> inputObject { get; set; }
        public OutArgument<AmxPeruDontInsistResponse> outputObject { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {

            AmxPeruDontInsistResponse _AmxPeruDontInsistResponse = null;
            try
            {
                AmxPeruDontInsistBusiness _AmxPeruDontInsistBusiness = new AmxPeruDontInsistBusiness();

                _AmxPeruDontInsistResponse = _AmxPeruDontInsistBusiness.SetDontInsist(inputObject.Get(context),ContextProvider.OrganizationService);

                //call business layer method for processing

                _AmxPeruDontInsistResponse.Status = "SUCCESS";

                //Set Values for the Out Parameter/Argument
                context.SetValue(outputObject, _AmxPeruDontInsistResponse);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}