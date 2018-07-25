using AmxCoPSBActivities.AMXCOLOMBIA.Activities.Configuration;
using AmxPeruPSBActivities.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class UpdateOrderItemBillingAccountBusinessTest
    {
        [TestMethod]
        public void UpdateOrderItemBillingAccount()
        {

            var input = new Dictionary<string, object>()
            {
                {"orderItemId", "C06CA068-09E6-E711-80E9-FA163E10DFBE" },
                {"billingAccountId",  "BA - 255317 - Anderson NIT Tes" }
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
