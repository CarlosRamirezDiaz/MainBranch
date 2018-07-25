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
    public class GetSelectedDeviceAvailableResourcesTests
    {
        [TestMethod]
        public void GetSelectedDeviceAvailableResourcesTestsMethod()
        {
            var input = new Dictionary<string, object>()
            {
                { "orderId", "D72D76C2-D187-E711-8126-00505601173A" }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.RetriveResources>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .ConfigureXrmDataContext()
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
