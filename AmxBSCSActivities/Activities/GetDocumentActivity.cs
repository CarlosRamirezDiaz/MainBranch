using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using System;
using System.ServiceModel;
using System.Linq;


namespace AmxSoapServicesActivities.Activities
{
    public class GetDocumentActivity : XrmAwareCodeActivity
    {
        public InArgument<DocumentManagerService.GetDocumentRequest> getDocumentRequest { get; set; }
        public OutArgument<DocumentManagerService.GetDocumentResponse> getDocumentResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            DocumentManagerService.GetDocumentRequest data = getDocumentRequest.Get(context);

            DocumentManagerService.GetDocumentRequest request = new DocumentManagerService.GetDocumentRequest();
            DocumentManagerService.HeaderRequest headerRequest = new DocumentManagerService.HeaderRequest();

            headerRequest.requestDate = DateTime.Now;

            DocumentManagerService.AttributeValuePair[] document = new DocumentManagerService.AttributeValuePair[]
            {
                    new DocumentManagerService.AttributeValuePair{
                        attributeName = "xdTipoIdentificacion",
                        attributeValue = "CC"
                    },
                    new DocumentManagerService.AttributeValuePair{
                        attributeName = "xdNumeroIdentificacion",
                        attributeValue = "928899e99"
                    },
                    new DocumentManagerService.AttributeValuePair
                    {
                        attributeName = "dID",
                        attributeValue = "26456"
                    }
            };

            request.headerRequest = headerRequest;
            request.document = document;

            string configurationName = "ClaroESB_DocumentManager";

            IQueryable<etel_crmconfiguration> query = from configuration in dataContext.etel_crmconfigurationSet
                                                      where configuration.etel_name == configurationName
                                                      select configuration;

            string url = query.FirstOrDefault().etel_value;

            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress(url);

            DocumentManagerService.DocumentCMSInterfaceClient client =
                new DocumentManagerService.DocumentCMSInterfaceClient(binding, address);
            DocumentManagerService.GetDocumentResponse response = client.GetDocument(request);

            getDocumentResponse.Set(context, response);
        }
    }

}
