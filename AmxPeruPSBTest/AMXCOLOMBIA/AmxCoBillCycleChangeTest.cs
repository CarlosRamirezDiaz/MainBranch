using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities;
using static AmxPeruTest.Helpers.TestHelper;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using System.Web.Script.Serialization;
using AmxPeruPSBWorkflows.AMX_COLOMBIA;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class AmxCoBillCycleChangeTest
    {
        [TestMethod]
        public void GetBillCycleChangeTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "BillCycleReadRequest",
                    new AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle.AmxCoBillCycleReadServiceRequest
                    {
                       partyType = "C",
                       readAll = false
                    }
                },
                {"HostUrl","http://localhost:9090/wsi/services/ws_CIL_7_BillCyclesReadService.wsdl" }
            };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxCoBillCycleChange>(input)
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
