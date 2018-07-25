using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AmxPeruTest.Helpers.TestHelper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class AmxGetRequiredAppointmentsTest
    {
        [TestMethod]
        public void AmxGetRequiredAppointmentsFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                {
                    //"orderCaptureId", "{10F31D5F-6B13-E811-80ED-FA163E10DFBE}"
                    //"orderCaptureId", "{36D3651B-1614-E811-80ED-FA163E10DFBE}"   // ORDMD0002655
                    "orderCaptureId", "{23D0AB02-DE2D-E811-80EF-FA163E10DFBE}" // ORDMD0003879
                }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor <AmxPeruPSBWorkflows.AMX_COLOMBIA.AmxGetRequiredAppointments> (input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
                result.ToString();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            // wait for recording logs
            var waittask = Task.Delay(10 * 1000);
            Task.WaitAll(new Task[] { waittask });

        }
    }
}

