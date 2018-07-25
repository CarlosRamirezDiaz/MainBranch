using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.Case;
using ExternalApiActivities.Common;
using System;

namespace AmxPeruPSBActivities.Activities.Case
{
    public class CreateCase : XrmAwareCodeActivity
    {

        public InArgument<AmxPeruPSBActivities.Model.Case.CaseRequest> request { get; set; }

        public OutArgument<CaseResponse> response { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                AmxPeruCreateCaseBusiness objCreateCaseBusiness = new AmxPeruCreateCaseBusiness();
                CaseResponse objResponse = objCreateCaseBusiness.CreateCaseOnCRM(request.Get(context), ContextProvider.OrganizationService);
                //CreateCaseBusiness objCreateBusiness = new CreateCaseBusiness();
                //CaseRequest caseRequest = request.Get(context);
                //CaseResponse objResponse = objCreateBusiness.CreateCaseOnCRM(caseRequest, ContextProvider.OrganizationService);


                response.Set(context, objResponse);
            }
            catch (Exception ex)
            {

            }
        }
    }
}