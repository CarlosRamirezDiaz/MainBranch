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
    public class AmxOrderUpdateAddressTest
    {
        [TestMethod]
        public void UpdateAddressFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                {"addressId", "CC325FFE-4416-E811-80ED-FA163E10DFBE" },
                {"orderCaptureId",  "E4B8103D-B413-E811-80ED-FA163E10DFBE" } //ORDMD0002672
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.UpdateOrderAddress>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();
            }
            catch (Exception ex)
            { }

        }
    }
}

