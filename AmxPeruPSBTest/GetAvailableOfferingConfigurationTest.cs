using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.OrderItem;
using AmxPeruPSBWorkflows;
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
    public class GetAvailableOfferingConfigurationTest
    {
        

        [TestMethod]
        public void GetAssociatedOffersAvailableConfigurationWithPrices()
        {
            var input = new Dictionary<string, object>()
            {

                { "availableOfferingInputModel",
                    new AvailableOfferingInputModel
                    {
                        OfferTypeCode = "Associated",
                        ParentOfferinId = "481E958E-867E-E711-8126-00505601173A",

                        CharList = new List<CharValue>()
                        {
                            new CharValue{Id = "A480B2EC-087D-E711-8126-00505601173A", Value = "LIMA"}
                        }
                    }
                }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<GetAvailableOfferingConfiguration>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }


        [TestMethod]
        public void RetrieveDeivceInfo()
        {
            var input = new Dictionary<string, object>()
            {

                { "deviceId","4FB98AA3-3083-E711-8126-00505601173A"}
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<RetrieveDeviceInfoModel>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void GetAssociatedProductOfferings()
        {
            var input = new Dictionary<string, object>()
            {

                { "parentOfferingId",
                   "481e958e-867e-e711-8126-00505601173a"
                }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<GetAssociatedProductOfferings>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void AddParentOfferingToShoppingCart()
        {
            var input = new Dictionary<string, object>()
            {
                { "orderItemShoppingCartModel",
                    new OrderItemAddShoppingCartModel() {
                        OrderCaptureId = "6B5F53E8-240C-E811-80ED-FA163E10DFBE",
                        OfferingId = "222ea950-d5a9-e711-80e2-fa163e106136",
                        ParentOrderItemId = "00000000-0000-0000-0000-000000000000",
                        SrProductId ="",
                        SrParentPoId = "",
                        OrderItemAction = "1",
                        RecurringPrice ="",
                        OneTimePrice ="",
                        PopExternalId = "",
                        AddressId ="16086108-3910-e811-80ed-fa163e10dfbe",
                        SelectedAddressStratum = "3",
                        BasicOffering = "Internet"
                    }
                }
             };

            try
            {

                var result = WorkflowHelper.PrepareFor<AddShoppingCart>(input)
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
