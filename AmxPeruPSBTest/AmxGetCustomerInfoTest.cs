using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;
using System.Web.Script;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using System.Activities;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxGetCustomerInfoTest
    {
        [TestMethod]
        public void GetCustomerInfoTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();

            var getCustomerInfoBusiness = new AmxPSBActivities.Business.AmxGetCustomerInfoBusiness(_org);

            var request = new AmxPSBActivities.Model.AmxGetCustomerInfoRequest()
            {
                documentType = 1, //(int)AmxPeruPSBActivities.Model.Individual.AmxCoDocumentTypeEnum.CEDULA_DE_CIUDADANIA,
                documentNumber = "1051830366",
                msisdn = "5411985251421",
                customerName = "",
                accountNumber = "",
                invoiceNumber = ""
            };

            try
            {
                var response = getCustomerInfoBusiness.GetCustomerInfo(request);
            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void GetCustomerInfoFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "request",
                    new AmxPSBActivities.Model.AmxGetCustomerInfoRequest
                    {
                        documentType = (int)AmxPeruPSBActivities.Model.Individual.AmxCoDocumentTypeEnum.CEDULA_DE_CIUDADANIA,
                        documentNumber = "18045554",
                        msisdn = "0123456789",
                        customerName = "",
                        accountNumber = "",
                        invoiceNumber = ""
                    }
                }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.AmxGetCustomerInfo>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }
    }
}

