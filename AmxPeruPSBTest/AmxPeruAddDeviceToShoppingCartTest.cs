using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static AmxPeruTest.Helpers.TestHelper;
using AmxPeruPSBActivities.Activities.OrderItem;
using AmxPeruPSBActivities.Model;
using System.Collections.Generic;
using AmxPeruPSBWorkflows;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxPeruAddDeviceToShoppingCartTest
    {
        [TestMethod]
        public void AmxPeruAddDeviceToShoppingCartSuccess()
        {
          

            var x = "{\"$type\":\"AmxPeruPSBActivities.Model.AmxPeruOfferingPriceModel, AmxPeruPSBActivities\",\"OrderId\":\"AAF018D0-548D-E711-812A-00505601173A\",\"OrderItemList\":{\"$type\":\"System.Collections.Generic.List`1[[AmxPeruPSBActivities.Model.Offering, AmxPeruPSBActivities]], mscorlib\",\"$values\":[{\"OfferingId\":\"4fb98aa3-3083-e711-8126-00505601173a\",\"PriceConfigurationId\":\"9aa4761e-3283-e711-8126-00505601173a\",\"OfferingName\":\"todo\",\"OrderItemId\":null}]}}";
            var j = Newtonsoft.Json.JsonConvert.DeserializeObject(x, typeof(AmxPeruOfferingPriceModel));
            var input = new Dictionary<string, object>()
            {
                { "InputModel",j }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruAddDeviceToShoppingCart>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        [TestMethod]
        public void AddShoppingCart()
        {


            var x = "{\"$type\":\"AmxPeruPSBActivities.Model.AmxPeruOfferingPriceModel, AmxPeruPSBActivities\",\"OrderId\":\"AAF018D0-548D-E711-812A-00505601173A\",\"OrderItemList\":{\"$type\":\"System.Collections.Generic.List`1[[AmxPeruPSBActivities.Model.Offering, AmxPeruPSBActivities]], mscorlib\",\"$values\":[{\"OfferingId\":\"4fb98aa3-3083-e711-8126-00505601173a\",\"PriceConfigurationId\":\"9aa4761e-3283-e711-8126-00505601173a\",\"OfferingName\":\"todo\",\"OrderItemId\":null}]}}";
            var j = Newtonsoft.Json.JsonConvert.DeserializeObject(x, typeof(AmxPeruOfferingPriceModel));
            var input = new Dictionary<string, object>()
            {
                { "InputModel",j }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruAddDeviceToShoppingCart>(input)
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
