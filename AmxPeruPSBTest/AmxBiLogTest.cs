using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BI_Log;
using AmxPeruPSBActivities.AMXCOLOMBIA.Business.BI_Log;
using static AmxPeruTest.Helpers.TestHelper;
using System.Collections.Generic;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxBiLogTest
    {
        [TestMethod]
        public void biLogAddBusinessTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();

            var request = new AmxBiLogAddRequest();
            var business = new AmxBiLogBusiness(_org);

            var response = business.AddBiLog(request);

        }

        [TestMethod]
        public void biLogAddFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "request", new AmxBiLogAddRequest()  }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.AmxAddBiLog>(input)
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
