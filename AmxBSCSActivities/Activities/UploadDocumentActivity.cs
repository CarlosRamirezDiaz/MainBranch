using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using System;
using System.ServiceModel;
using System.Linq;

namespace AmxSoapServicesActivities.Activities
{
    public class UploadDocumentActivity : XrmAwareCodeActivity
    {
        public InArgument<DocumentManagerService.UploadDocumentRequest> uploadDocumentRequest { get; set; }
        public OutArgument<DocumentManagerService.UploadDocumentResponse> uploadDocumentResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            DocumentManagerService.UploadDocumentRequest request = uploadDocumentRequest.Get(context);

            string configurationName = "ClaroESB_DocumentManager";

            IQueryable<etel_crmconfiguration> query = from configuration in dataContext.etel_crmconfigurationSet
                                                      where configuration.etel_name == configurationName
                                                      select configuration;

            string url = query.FirstOrDefault().etel_value;

            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress(url);

            DocumentManagerService.DocumentCMSInterfaceClient client =
                new DocumentManagerService.DocumentCMSInterfaceClient(binding, address);
            DocumentManagerService.UploadDocumentResponse response = client.UploadDocument(request);

            uploadDocumentResponse.Set(context, response);
        }
    }
}
