using AmxPeruPSBActivities.Model.OrderItem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class GetOrderBasketItem
    {
        [TestMethod]
        public void GetGetOrderBasketItem()
        {
            var input = new Dictionary<string, object>()
            {
                {"orderGuid","8904A9F9-B5E6-E711-80E9-FA163E10DFBE" }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.GetOrderBasket>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void AmxPeruLineCompatibilityItem()
        {
            var input = new Dictionary<string, object>()
            {
                //{ "orderGuid", "4DCF57BA-8582-E711-8126-00505601173A"}
                //{ "orderGuid", "5959CCE9-3D87-E711-8126-00505601173A"}
            };

            try
            {
                //var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruLinePortabilityQuery>(input)
                //            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                //            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void FindingRelevantPOOfferings()
        {
            var input = new Dictionary<string, object>()
            {
                
                { "orderItemShoppingCartModel",
                    new OrderItemAddShoppingCartModel() {
                        OrderCaptureId = "6B5F53E8-240C-E811-80ED-FA163E10DFBE",
                        OfferingId = "16a9a229-d30c-e811-80ed-fa163e10dfbe",
                        ParentOrderItemId = "c0876955-c511-e811-80ed-fa163e10dfbe",
                        SrProductId ="",
                        SrParentPoId = "",
                        OrderItemAction = "1",
                        RecurringPrice ="0",
                        OneTimePrice ="",
                        PopExternalId = "POP_TelPosPlanSegLineaREC",
                        AddressId ="16086108-3910-e811-80ed-fa163e10dfbe",
                        SelectedAddressStratum = "3",
                        BasicOffering = "Telephony2"
                    }
                }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AddShoppingCart>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void UpdateOrderItemAction()
        {
            var input = new Dictionary<string, object>()
            {

                { "orderItemId", "aa75ded2-2ed9-e711-80e6-fa163e10dfbe" },
                { "orderItemAction", "4" }
    };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxCoUpdateOrderItemAction>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void UpdateOrderItemsForMultiPlay()
        {
            var input = new Dictionary<string, object>()
            {
                { "estrato", "3"},
                { "orderCaptureId", "4CF687E1-3933-E811-80F0-FA163E10DFBE"}
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.UpdateOrderItemsForMultiPlay>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.TCRMCATALOGURL)
                            //.ConfigureXrmDataContext()
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void RetrieveProductsByBasicOffer()
        {
            var input = new Dictionary<string, object>()
            {   
                { "parentOfferingId","222ea950-d5a9-e711-80e2-fa163e106136" },
                { "estrato","3"}
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
        public void RevertCartPrices()
        {
            var input = new Dictionary<string, object>()
            {
                { "orderCaptureId", "8904A9F9-B5E6-E711-80E9-FA163E10DFBE"},
                { "isRemovedItemPermanencia", true }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxCoRevertCartPrices>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void TestAddressFunctionInShoppingCartStep()
        {
            var input = new Dictionary<string, object>()
            {
                { "orderItemShoppingCartModel",
                    new OrderItemAddShoppingCartModel() {
                        AddressId = "dba747dd-1ae5-e711-80e9-fa163e10dfbe",
                        OrderCaptureId = "BDC3DBF0-11F6-E711-80E9-FA163E10DFBE" }
                }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AddShoppingCart>(input)
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