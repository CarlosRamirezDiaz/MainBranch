using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AmxPeruPSBActivities.Activities.Order;
using System.Activities;
using static AmxPeruTest.Helpers.TestHelper;
using AmxPeruPSBActivities.Model;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class AmxOrderSubmitTests
    {
        [TestMethod]
        public void SubmitOrderActivityTest()
        {
            //List<OptionSet> resourceTypeCodes = new List<OptionSet>();

            var input = new Dictionary<string, object>()
            {
                {"orderCaptureId", "BF33F073-532D-E811-80EF-FA163E10DFBE" } //ORDMD0003475
                //{"orderCaptureId", "ECAF7FE6-ACD3-E711-80E6-FA163E10DFBE"} //ORDMD0001438
            };
            
            try
            {
              var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.SubmitOrderCaptureTest>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();

                result.ToString();
            }
            catch (Exception ex)
            { }            

        }
    }
}
