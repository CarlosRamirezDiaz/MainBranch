using AmxSoapServicesActivities.DocumentManagerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class GetDocumentTest
    {
        [TestMethod]
        public void GetDocument()
        {
            GetDocumentRequest request = new GetDocumentRequest();
            AttributeValuePair[] document = new AttributeValuePair[]
                {
                    new AttributeValuePair{
                        attributeName = "xdTipoIdentificacion",
                        attributeValue = "CC"
                    },
                    new AttributeValuePair{
                        attributeName = "xdNumeroIdentificacion",
                        attributeValue = "928899e99"
                    }
                };

            request.document = document;

            var input = new Dictionary<string, object>()
            {
                { "GetDocumentRequest",
                    request
                }
            };

            var result = WorkflowHelper.PrepareFor<AmxSoapServicesWorkflows.GetDocument>(input) //AMXSOAPSERcv
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();
        }
    }
}
