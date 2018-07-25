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
    public class GetProdCharacteristicsTest
    {
        //[TestMethod]
        //public void GetProdCharacteristicsMethod()
        //{
        //    var input = new Dictionary<string, object>()
        //    {
        //        { "orderGuid", "D72D76C2-D187-E711-8126-00505601173A"}
                
        //    };

        //    try
        //    {
        //        var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.GetProductCharacteristics>(input)
        //                    .ConfigureFor("connectionString", ConfigurationHelper.URL)
        //                    .Invoke();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}

        //[TestMethod]
        //public void SubmitOrderCapture()
        //{
        //    try
        //    {
        //        var input = new Dictionary<string, object>()
        //        {

        //            { "orderCaptureId", "D72D76C2-D187-E711-8126-00505601173A"},
        //            { "individualCustomerId", "B43FDF45-1D79-E711-8126-00505601173A" },
        //            { "corporateCustomerId",""}
        //        };

        //        var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.SubmitOrderCapture>(input)
        //                    .ConfigureFor("connectionString", ConfigurationHelper.URL)
        //                    .Invoke();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}
    }
}