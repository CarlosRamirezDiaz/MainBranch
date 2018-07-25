using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AmxPeruTest.Helpers.TestHelper;
using System.Collections.Generic;
using AmxPeruPSBActivities.Model.Appointment;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class GetCapacityTest
    {
        [TestMethod]
        public void GetCapacityFlowTest()
        {
            GetCapacityRequestModel getCapacityRequest = new GetCapacityRequestModel();

            getCapacityRequest.addressId = "866dd922-1614-e811-80ed-fa163e10dfbe";
            getCapacityRequest.documentId = "353534";
            /*getCapacityRequest.date = new List<String> {
                { "2018-01-28" },
                { "2018-01-29" },
                { "2018-01-30" },
            { "2018-01-31" },
                { "2018-02-01"},
            { "2018-02-02"},
            { "2018-02-03"} };*/


            getCapacityRequest.date = new List<String> {
                { "2018-02-20" }};

            var input = new Dictionary<string, object>()
            {
                {"orderCaptureId", "ORDMD0002655"},
                { "dates", getCapacityRequest.date },
                {"documentId", "353534" },
                {"sequenceNumber", "2" },
                {"addressId", "866dd922-1614-e811-80ed-fa163e10dfbe" }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxCoGetCapacity>(input)
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

