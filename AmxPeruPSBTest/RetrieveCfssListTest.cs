using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class RetrieveCfssListTest
    {
        [TestMethod]
        public void RetrieveCfssListByProductExternalId()
        {
            var input = new Dictionary<string, object>()
            {
                { "ProductExternalId", "PO_TelPosBloqueos"}
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBActivities.Activities.Cfss.RetrieveCfssListByProductExternalId>(input)
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
