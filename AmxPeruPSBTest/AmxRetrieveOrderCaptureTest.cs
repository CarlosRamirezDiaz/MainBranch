using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AmxPeruPSBActivities.Activities.Order;
using System.Activities;
using static AmxPeruTest.Helpers.TestHelper;
using AmxPeruPSBActivities.Model;

namespace AmxCoPSBTest
{
    [TestClass]
    public class AmxRetrieveOrderCaptureTest
    {
        [TestMethod]
        public void OrderCaptureRepositoryTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();
            var repository = new AmxPeruPSBActivities.Repository.OrderCaptureRepository(_org);

            var individualId = new Guid("D0271757-D4A7-E711-80E1-FA163E106136");
            var dateStart = DateTime.Now.Date.AddDays(-90);
            var dateEnd = DateTime.Now.Date;
            var stateCode = -1;
            var statusCode = -1;

            var orders = repository.ListOrderCaptureByIndividualAndDate(individualId, dateStart, dateEnd, statusCode, stateCode);
        }

        [TestMethod]
        public void AmxRetrieveOrderCaptureFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "request",
                    new ExternalApiActivities.Models.OrderCaptureRequestModel
                    {
                        customerId = "IND04772",  // "Anderson Isamu"
                        startDate = DateTime.Now.Date.AddDays(-90),
                        endDate = DateTime.Now.Date,
                        orgTimezoneOffset = -300,
                        languagecode = "1033",
                        viewtype = 1
                    }
                }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.AmxRetrieveOrderCapture>(input)
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






