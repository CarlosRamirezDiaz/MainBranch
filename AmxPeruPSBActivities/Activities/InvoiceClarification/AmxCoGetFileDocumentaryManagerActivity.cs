using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Business.InvoiceClarification;
using AmxPeruPSBActivities.Model.InvoiceClarification;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.InvoiceClarification
{
    class AmxCoGetFileDocumentaryManagerActivity : XrmAwareCodeActivity
    {

        public InArgument<AmxCoGetFileDocumentaryManagerRequest> objGetFileDocumentaryManagerRequest { get; set; }
        public OutArgument<AmxCoGetFileDocumentaryManagerResponse> objGetFileDocumentaryManagerResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                AmxCoGetFileDocumentaryManagerBusiness objGetFileDocumentaryManagerBusiness = new AmxCoGetFileDocumentaryManagerBusiness();
                AmxCoGetFileDocumentaryManagerResponse objResponse = objGetFileDocumentaryManagerBusiness.GetFileDocumentaryManagerBusiness(ContextProvider.OrganizationService, objGetFileDocumentaryManagerRequest.Get(context));
                objGetFileDocumentaryManagerResponse.Set(context, objResponse);
            }
            catch (Exception)
            {

            }
        }
    }
}
