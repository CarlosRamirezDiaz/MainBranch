using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AmxPeruTest.Helpers.TestHelper;
using System.Collections.Generic;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class ParadigmaTest
    {
        [TestMethod]
        public void GetIFrameUrlTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();

            var paradigmaBusiness = new AmxPeruPSBActivities.AMXCOLOMBIA.Business.ParadigmaBusiness(_org);

            var customerId = new Guid("1CD7DC0F-B9B5-E711-80E4-FA163E106136");
            var csrUserId = new Guid("30163661-05A3-E711-80DD-FA163E106136");

            var iFrameBaseUrl = @"http://baseUrl/token=";

            try
            {
                var url = paradigmaBusiness.GetIFrameUrl(customerId, csrUserId, iFrameBaseUrl);
            }
            catch (Exception ex)
            {
            }
        }

        [TestMethod]
        public void GetIFrameUrlActivityTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "individualId", "099B11B1-A5C0-E711-80E5-FA163E10DFBE" },  //Hector Antonio Gutierrez
                { "userId", "30163661-05A3-E711-80DD-FA163E106136" },
                { "iFrameBaseUrl", "http://baseurl/token=" }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBActivities.AMXCOLOMBIA.Activities.Paradigma.ParadigmaGetIFrameUrl>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .ConfigureXrmDataContext()
                        .Invoke();
            }
            catch (Exception ex)
            { }
        }

        [TestMethod]
        public void GetIFrameUrlFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "individualId", "099B11B1-A5C0-E711-80E5-FA163E10DFBE" },  //Hector Antonio Gutierrez
                { "userId", "30163661-05A3-E711-80DD-FA163E106136" }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.ParadigmaGetIFrameUrl>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();
            }
            catch (Exception ex)
            { }
        }
    }
}