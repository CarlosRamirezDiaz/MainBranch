using AmxPeruPSBActivities.Business;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.StratumChange
{
    public class AmxCoStratumChangeCreateCase : XrmAwareCodeActivity
    {
        public InArgument<string> objIdStratumChange { get; set; }

        public OutArgument<bool> objError { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                AmxCoStratumChangeCreateCaseBusiness objtratumChangeCreateCaseBusiness = new AmxCoStratumChangeCreateCaseBusiness();
                bool objResponse = objtratumChangeCreateCaseBusiness.StratumChangeCreateCase(objIdStratumChange.Get(context), ContextProvider.OrganizationService);
                objError.Set(context, objResponse);
            }
            catch (Exception)
            {

            }
        }
    }
}
