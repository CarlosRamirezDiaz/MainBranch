using AmxCoPSBActivities.AMXCOLOMBIA.Business.OrderCapture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class AmxDigiturnoTest
    {
        [TestMethod]
        public void AmxListOrderCaptureTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();

            var business = new RetrieveOrderCaptureBusiness(_org);

            var result = business.RetrieveOrderCaptureByIndividualAndDate("IND04772", DateTime.Now.Date.AddDays(-90), DateTime.Now.Date, 1);
        }

        [TestMethod]
        public void AmxListOrderCaptureFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "request",
                    new ExternalApiActivities.Models.OrderCaptureRequestModel
                    {
                        customerId = "IND04772",
                        startDate = DateTime.Now.Date.AddDays(-90),
                        endDate = DateTime.Now.Date,
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

