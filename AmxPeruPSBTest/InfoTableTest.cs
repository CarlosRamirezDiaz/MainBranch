using AmxPeruPSBActivities.Activities.Offering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AmxPeruPSBWorkflows;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class InfoTableTest
    {
        [TestMethod]
        public void RetrieveOptionalOfferingsFromInfoTableActivity()
        {
            var input = new Dictionary<string, object>()
            {
                { "infoModelName", "PrecioBaseInternet"},
                { "estrato", "3"}
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<RetrieveOptionalOfferingsFromInfoTable>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.TCRMCATALOGURL)
                            .ConfigureXrmDataContext()
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void RetrieveOptionalOfferingsFromInfoTableWorkflow()
        {
            var input = new Dictionary<string, object>()
            {
                { "estrato", "3"},
                { "parentOfferingId", "902E32C2-9426-E811-80ED-FA163E10DFBE"}
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<TestActivities>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.TCRMCATALOGURL)
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