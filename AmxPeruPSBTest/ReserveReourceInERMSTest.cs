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
    public class ReserveReourceInERMSTest
    {
        [TestMethod]
        public void ReserveResourceInERMSTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "OrderResourceId", new Guid("062B6CAE-CD84-E711-8126-00505601173A") },
                { "PartNumber", "ClaroSimNano" },
                { "ResourceId", "8951100000000070925" }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ReserveReourceInERMS>(input)
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
