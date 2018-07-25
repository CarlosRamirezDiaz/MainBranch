using AmxPeruPSBActivities.Model;
using ExternalApiWorkflows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class GetAvgBilling
    {
        [TestMethod]
        public void GetAvgBillingTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "input",
                    new AmxPeruGetAvgBillDebtLimitRequest
                    {
                        CustomerType =1,
                        CustomerExternalId = "CUST0000000034"

                    }
                }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruGetAverageBilling>(input)
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