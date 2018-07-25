using AmxPeruPSBWorkflows.AMX_COLOMBIA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class AmxGetCustomerBillingAccountsTest
    {
        [TestMethod]
        public void GetCustomerBillingAccountsTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "CustomerReadRequest",
                    new AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle.AmxCoCustomerReadServiceRequest
                    {
                      // csId = 220,
                      // csIdPub = "CUST00000006",
                       csIdPub= "CUST0000000202",
                       syncWithDb = ""
                    }
                },
                {"HostUrl","http://localhost:9090/wsi/services" }
                //{"HostUrl","http://localhost:9090/wsi/services/ws_CIL_7_CustomerReadService.wsdl" },
            };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxCoGetCustomerBillAccounts>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.CRMDEVURL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
