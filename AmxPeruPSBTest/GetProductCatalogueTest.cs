using AmxPeruPSBActivities.Model;
using ExternalApiWorkflows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class GetProductCatalogueTest
    {
    //    [TestMethod]
    //    public void CreateCase()
    //    {
    //        var input = new Dictionary<string, object>()
    //        {

    //            { "request", new Guid("4DCF57BA-8582-E711-8126-00505601173A")}
    //        };

    //        try
    //        {

    //            var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.GetProductCharacteristics>(input)
    //                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
    //                        .Invoke();
    //        }
    //        catch (Exception ex)
    //        {
    //            ex.Message.ToString();
    //        }
    //    }
        [TestMethod]
        public void NewSubscription()
        {
            var input = new Dictionary<string, object>()
            {

                { "customerId" , "IND00001" },
                { "languageId" , "1033" },
                {"customerType" , 2 }

    };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruNewSubscription>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void GetAssociatedProductOfferingListTest()
        {
            var input = new Dictionary<string, object>()
            {

                { "parentOfferingId", "497AF985-087D-E711-8126-00505601173A"},
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.GetAssociatedProductOfferings> (input)
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
