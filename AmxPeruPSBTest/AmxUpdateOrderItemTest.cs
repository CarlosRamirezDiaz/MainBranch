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
    public class AmxUpdateOrderItemTest
    {
        [TestMethod]
        public void AmxUpdateOrderItemFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                {"billingAccountId", "Billing aCCOUNT TEST 123" },
                {"orderItemId",  "7FB7A955-D9CE-E711-80E6-FA163E10DFBE" } //ORDMD0001387
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.UpdateOrderItemBillingAccount>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();
            }
            catch (Exception ex)
            { }

        }
    }
}

