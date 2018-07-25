using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class RetrieveProductOfferingsTest
    {
        [TestMethod]
        public void RetrieveOptionalPOs()
        {
            var input = new Dictionary<string, object>()
            {
                { "estrato", "3"},
                { "parentOfferingId", "134b7311-6326-e811-80ed-fa163e10dfbe"}
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.RetrieveOptionalOfferings>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void RetrieveBasicProductsOffering()
        {
            try
            {

            //    var input = new Dictionary<string, object>()
            //{
            //    { "EntityLogicalName", "etel_offeringassociation"},
            //    { "ColumnSet", new ColumnSet(true) }
            //};
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.RetrieveBasicOfferings>()
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
        public void RetrieveBasicOfferings()
        {
            try
            {

                //    var input = new Dictionary<string, object>()
                //{
                //    { "EntityLogicalName", "etel_offeringassociation"},
                //    { "ColumnSet", new ColumnSet(true) }
                //};
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.RetrieveBasicOfferings>()
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
