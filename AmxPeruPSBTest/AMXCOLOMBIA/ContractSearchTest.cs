using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class ContractSearchTest
    {
        [TestMethod]
        public void GetContractsSearchTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "ContractsSearchRequest",
                    new AmxSoapServicesActivities.Model.ContractsSearchRequest
                    {
                       csIdPub = "CUST0000000319",
                       searcher = "SimpleContractSearch"
                    }
                },
                {"HostUrl","http://localhost:9090/wsi/services/ws_CIL_6_ContractsSearchService.wsdl" }
            };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                //var result = WorkflowHelper.PrepareFor<AmxSoapServicesWorkflows.ContractsSearch>(input)
                //            .ConfigureFor("connectionString", ConfigurationHelper.CRMDEVURL)
                //            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
