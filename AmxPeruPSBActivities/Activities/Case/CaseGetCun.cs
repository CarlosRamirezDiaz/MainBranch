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
    public class CaseGetCun : XrmAwareCodeActivity
    {

        public InArgument<CaseGetCunRequest> request { get; set; }

        public OutArgument<CaseGetCunResponse> response { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                CaseGetCunBusiness objCaseGetCunBusiness = new CaseGetCunBusiness();
                CaseGetCunResponse objResponse = objCaseGetCunBusiness.GetCun(request.Get(context), ContextProvider.OrganizationService);
                
                response.Set(context, objResponse);
            }
            catch (Exception)
            {
            }
        }
    }
}
