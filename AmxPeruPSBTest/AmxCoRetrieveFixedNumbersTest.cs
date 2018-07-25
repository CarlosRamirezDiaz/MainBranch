using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxCoRetrieveFixedNumbersTest
{
    [TestClass]
    public class RetrieveFixedNumbersTest
    {
        [TestMethod]
        public void RetrieveFixedNumbers()
        {
            var input = new Dictionary<string, object>()
                {
                    { "addressId", "995F6042-F610-E811-80ED-FA163E10DFBE"},
                    { "customerId", "EF7B50FB-D3CE-E711-80E6-FA163E10DFBE" }
                };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.RetrieveFixedLineNumbers>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .ConfigureXrmDataContext()
                            .Invoke();
                result.GetType();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
