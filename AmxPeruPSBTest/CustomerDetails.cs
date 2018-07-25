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
    public class CustomerDetails
    {

        [TestMethod]
        public void RemoveShop2()
        {
            
                         var input = new Dictionary<string, object>()
            {
                { "orderCaptureId","9F27C624-CB88-E711-8126-00505601173A" },
                { "orderItemId","1644c5d3-cb88-e711-8126-00505601173a"}
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.RemoveOrderItemFromBasket>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }


        [TestMethod]
        public void SubmitOrderCapture()
        {            
            try
            {
                var input = new Dictionary<string, object>()
                {

                    { "orderCaptureId", "4DCF57BA-8582-E711-8126-00505601173A"},
                    { "individualCustomerId", "B43FDF45-1D79-E711-8126-00505601173A" },
                    { "corporateCustomerId",""}
                };

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.SubmitOrderCapture>(input)
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
