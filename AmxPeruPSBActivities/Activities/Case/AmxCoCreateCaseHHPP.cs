using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.Case;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.Case
{
    public class AmxCoCreateCaseHHPP : XrmAwareCodeActivity
    {
        public InArgument<AmxCoCreateCaseHHPPRequest> objCreateCaseHHPPRequest { get; set; }

        public OutArgument<AmxCoCreateCaseHHPPResponse> objCreateCaseHHPPResponse { get; set; }
                
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                AmxCoCreateCaseHHPPBusiness objOpenNewCaseMLG = new AmxCoCreateCaseHHPPBusiness();
                AmxCoCreateCaseHHPPResponse objResponse = objOpenNewCaseMLG.CreateCaseHHPP(objCreateCaseHHPPRequest.Get(context), ContextProvider.OrganizationService);
                objCreateCaseHHPPResponse.Set(context, objResponse);
            }
            catch (Exception)
            {

            }
        }
    }
}
