using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AmxPeruTest.Helpers.TestHelper;
using AmxPeruPSBActivities.Model.Resources;

namespace AmxPeruPSBTest
{
    /// <summary>
    /// Summary description for OrderCaptureUnitTests
    /// </summary>
    [TestClass]
    public class OrderCaptureUnitTests
    {
        public OrderCaptureUnitTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        [TestMethod]
        public void SimCardOrderItemOperationsTest()
        {
            var input = new Dictionary<string, object>()
            {
                {"orderItemId", "c9491b00-862b-e811-80ef-fa163e10dfbe" },
                { "simCardResourceCharModel",
                    new SIMCardOrderResourceCharacteristicModel() {
                        ICCID = "8951171000024",
                        IMSI = "716170000000024",
                        PUK = "90100025",
                        KI = "CF7B6C0AF8F1C2D2CBF2A413C64C1752"
                    }
                }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.SIMCardOrderItemOperations>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void RetrieveOrderCaptureAddressTest()
        {
            var input = new Dictionary<string, object>()
            {
                {"orderCaptureId", "7AE19068-E631-E811-80F0-FA163E10DFBE" }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.GetOrderCaptureAddress>(input)
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
