using AmxSoapServicesActivities.Activities;
using AmxSoapServicesWorkflows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class BalanceHistoryReadActivityTest
    {
        [TestMethod]
        public void GetBalanceHistoryReadTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "BalanceHistoryReadRequest",
                    new AmxSoapServicesActivities.Model.BalanceHistoryReadRequest
                    {
                       csIdPub = null,
                       snapFromDate = null,
                       snapEndDate = null,
                       coId = null,
                       coIdPub = null,
                       profileId = null,
                       sncode = null,
                       sncodePub = null,
                       seqNo = null,
                       searchLimit = null,
                       csId = 1065,
                       bpId = null,
                       memberCoId = null,
                       memberCoIdPub=null,
                       consumerCoId = null,
                       consumerCoIdPub = null,
                       cfssId = null,
                       spcode = null,
                       productofferingId = null,
                       productId = null,
                       suppressReratedBirs = null,
                       accountId = null,
                       accountTypeId = null,
                       accountTypeIdPub = null,
                       excludeIndividualUc = null,
                       balanceSpecificationId = null,
                       excludeTechnicalBalances = null
                    }
                },
                {"HostUrl","http://localhost:9090/wsi/services/ws_CIL_7_BalanceHistoryReadService.wsdl" }
            };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxSoapServicesActivities.Activities.BalanceHistoryRead>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.CRMDEVURL)
                            .ConfigureXrmDataContext()
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void GetBalanceHistoryReadFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "BalanceHistoryReadRequest",
                    new AmxSoapServicesActivities.Model.BalanceHistoryReadRequest
                    {
                       csIdPub = null,
                       snapFromDate = null,
                       snapEndDate = null,
                       coId = null,
                       coIdPub = null,
                       profileId = null,
                       sncode = null,
                       sncodePub = null,
                       seqNo = null,
                       searchLimit = null,
                       csId = 1065,
                       bpId = null,
                       memberCoId = null,
                       memberCoIdPub=null,
                       consumerCoId = null,
                       consumerCoIdPub = null,
                       cfssId = null,
                       spcode = null,
                       productofferingId = null,
                       productId = null,
                       suppressReratedBirs = null,
                       accountId = null,
                       accountTypeId = null,
                       accountTypeIdPub = null,
                       excludeIndividualUc = null,
                       balanceSpecificationId = null,
                       excludeTechnicalBalances = null
                    }
                },
                {"HostUrl","http://localhost:9090/wsi/services/ws_CIL_7_BalanceHistoryReadService.wsdl" }
            };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxSoapServicesWorkflows.BalanceHistoryRead>(input)
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
