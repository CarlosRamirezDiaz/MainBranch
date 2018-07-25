using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static AmxPeruTest.Helpers.TestHelper;
using Newtonsoft.Json;
using AmxPeruPSBWorkflows.AMX_COLOMBIA;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BICreditProfile;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class BICreditProfileTest
    {
        [TestMethod]
        public void GetBICreditProfileInfoTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "BICreditProfileRequest",
                    new AmxPeruPSBActivities.AMXCOLOMBIA.Model.BICreditProfile.BICreditProfileRequest
                    {
                       getOperation = "cun",
                       message = "{\"documentType\":\"CC\",\"documentId\":\"80057683\", \"business\":\"FIJA\"}"
                    }
                }
            };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                var result = WorkflowHelper.PrepareFor<BICreditProfile>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
