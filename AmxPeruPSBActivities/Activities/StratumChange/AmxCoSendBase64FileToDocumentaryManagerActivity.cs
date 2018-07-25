using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.StratumChange;
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
    public class AmxCoSendBase64FileToDocumentaryManagerActivity : XrmAwareCodeActivity
    {
        public InArgument<AmxCoSendBase64FileToDocumentaryManagerRequest> objSendBase64FileToDocumentaryManagerRequest { get; set; }

        public OutArgument<AmxCoSendBase64FileToDocumentaryManagerResponse> objSendBase64FileToDocumentaryManagerResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                AmxCoSendBase64FileToDocumentaryManagerBusiness objSendBase64FileToDocumentaryManagerBusiness = new AmxCoSendBase64FileToDocumentaryManagerBusiness();
                AmxCoSendBase64FileToDocumentaryManagerResponse objResponse = objSendBase64FileToDocumentaryManagerBusiness.SendBase64FileToDocumentaryManagerBusiness(ContextProvider.OrganizationService, objSendBase64FileToDocumentaryManagerRequest.Get(context));
                objSendBase64FileToDocumentaryManagerResponse.Set(context, objResponse);
            }
            catch (Exception)
            {

            }
        }
    }
}
