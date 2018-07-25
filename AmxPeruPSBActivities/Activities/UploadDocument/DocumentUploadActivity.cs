using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model.DocumentUpload;
using AmxPeruPSBActivities.Service.DocumentUpload;

namespace AmxPeruPSBActivities.Activities.UploadDocument
{
    public class DocumentUploadActivity : XrmAwareCodeActivity
    {
        public InArgument<DocumentUploadRequest> docuploadrequest { get; set; }

        public OutArgument<DocumentUploadResponse> docUploadresponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {


                DocumentUploadService objService = new DocumentUploadService();
                DocumentUploadResponse objResponse = objService.UploadDocument(docuploadrequest.Get(context), ContextProvider.OrganizationService);
                docUploadresponse.Set(context, objResponse);
            }
            catch (System.Exception ex)
            {

            }


        }
    }
}
