using AmxCoPSBActivities.AMXCOLOMBIA.Activities.Configuration;
using AmxPeruPSBActivities.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxCoGetConfigurableItemsTest
    {
        [TestMethod]
        public void GetConfigurableItemsTest()
        {
            OrderItemsBasketModel orderItemsBasket = new OrderItemsBasketModel();
            OrderItemsBasketModel configurableOrderItemsBasket = new OrderItemsBasketModel();

            // Build request
            var input = new Dictionary<string, object>()
            {
                {"orderGuid","8416CB16-09E6-E711-80E9-FA163E10DFBE" }
            };

            try
            {
                /*var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.GetOrderBasket>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();

                orderItemsBasket = (OrderItemsBasketModel)result["orderBasket"];*/
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            // Get Configurable Items
            try
            {
                var bureauBusiness = new AmxCoPSBActivities.Business.AmxCoGetConfigurableItemsBusiness();

                var _org = OrganizationProxy.GetOrganizationProxy();

                try
                {
                    var response = bureauBusiness.GetConfigurableItems(_org, orderItemsBasket);
                    orderItemsBasket.listOfOrderBasketOrderItems.Count();
                }
                catch (Exception ex)
                { ex.Message.ToString(); }
            }
            catch (Exception ex)
            { ex.Message.ToString(); }

        }
    }
}
