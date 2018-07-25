using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.Case;
using AmxPeruPSBActivities.Model.ChangeResource;
using AmxPeruPSBActivities.Model.CustomerCampaign;
using AmxPeruPSBActivities.Model.DocumentUpload;
using AmxPeruPSBActivities.Model.SeeCreditAssessment;
using AmxPeruPSBActivities.Model.AffiliateDisaffiliate;
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
    public class ExternalServiceTest
    {
        [TestMethod]
        public void ConsultaEvaluacionCrediticiaTest()
        {
            var input = new Dictionary<string, object>()
            {
              { "_requestModel",
                    new AMXPeruSeeCreditAssessmentRequest
                    {CustomerType=1,
                    DecisionID="test",
                    Channel="Test",
                    CustomerExternalId="Test1",
                    Request=new AMXPeruTyperequest()
                    {
                        Bagtype="",
                        BuroConsulted="",
                        Dateofexecution=DateTime.Now,
                        Dispatchtype="Test1",
                        Equipment=new AMXPeruTypeEquipment() {
                            Cost=1000,
                            Decotype="Test",
                            Dues=1,
                            Feeamount=100,
                            Group="test",
                            Initialpaymentfactor=1000,
                            Initialrate=1000,
                            Model="test",
                            Risk=1,
                            Saleprice=10000,
                            Spectrum="test1",
                            Subsidyfactor=1000,
                            Typeoperationkit="1000",
                            Waytopay="test2"
                        },
                        Client=new AMXPeruCustomerType()
                        {
                            Age=10,
                            Address=new AMXPeruAddressType()
                            {
                                Department="test",
                                District="asansol",
                                Planecode="123asdn",
                                Province="test",
                                Region="test"
                            }
                        }
                    }

                    }

                    }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ConsultaEvaluacionCrediticia>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void AffiliateDisaffiliatewhitepageTest()
        {
            var input = new Dictionary<string, object>()
            {
              { "Input",
                    new AmxPeruAffiliateDisaffiliatetoWhitePagesRequest
                    {
                        CurrentWhitePageValue=250000001,
                        SubscriptionID="E1CB98D9-3192-E711-812A-00505601173A"
                    }
               }
            };
            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruAffiliateDisaffiliatetoWhitePages>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }


    [TestClass]
    public class ExternalService
    {
        [TestMethod]
        public void ConsultaDocumentoOnBaseTest()
        {
            var input = new Dictionary<string, object>()
            {
                {
                    "documentId", "d1"
                }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ConsultaDocumentoOnBase>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void ValidateChangeResourceTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "requestModel",
                    new ChangeResourceRequest
                    {
                            SubscriptionId = "F1152D44-6D7B-E711-8126-00505601173A",
                            CustomerId = "c1"
                    }
                }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruValidationBeforeChangeResource>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }

    [TestClass]
    public class RetrieveResourcesTest
    {

        [TestMethod]
        public void ReserveResourceInERMS()
        {
            //var input = new Dictionary<string, object>()
            //{

            //    {
            //        "orderId", "06A8E130-FC83-E711-8126-00505601173A"
            //    }
            //};

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ReserveReourceInERMS>()
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }


        [TestMethod]
        public void RetrieveResources()
        {
            var input = new Dictionary<string, object>()
            {

                { "orderId", "06A8E130-FC83-E711-8126-00505601173A"
                }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.RetriveResources>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void RemoveShop()
        {
            var input = new Dictionary<string, object>()
            {
                { "orderCaptureId","57BC1115-22E5-E711-80E9-FA163E10DFBE" },
                { "orderItemId","b554d839-bee5-e711-80e9-fa163e10dfbe"}
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
    }


    [TestClass]
    public class NewSubscriptionTest
    {
        [TestMethod]
        public void NewSubscriptionSuccess()
        {
            var input = new Dictionary<string, object>()
            {
                {"orderCaptureId", "37F19690-2686-E711-8126-00505601173A" },
                { "individualCustomerId", "B43FDF45-1D79-E711-8126-00505601173A" },
                { "corporateCustomerId",""},
                {"languageId","1033"}
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



        [TestClass]
        public class CreateCaseTest
        {
            [TestMethod]
            public void CreateCase()
            {
                var input = new Dictionary<string, object>()
            {

                { "request",
                    new CaseRequest
                    {CustomerType=1,
                        CaseTitle = "Tast Case"+ DateTime.Now,

                        CaseType = "Informatives",
                        caseTypeCategory1="Balance and Consumption",
                        caseTypeCategory2="Balance Clarification/Consultation",

                        CustomerId ="E14F376B-D280-E711-8114-00505601173A",
                        CaseParentId="1",
                        Documents =   new List<Documents>()
                        {new Documents(){DocumentId="1",DocumentName="First Document",DocumentIdOnbase="HFDMIDF"},
                        new Documents(){DocumentId="2", DocumentName="Second Document",DocumentIdOnbase="KKVGIOH"}
                        },
                        Description ="Sample Description"
                    }

                    }

            };

                try
                {

                    var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.CraeteCase>(input)
                                .ConfigureFor("connectionString", ConfigurationHelper.URL)
                                .Invoke();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }


            [TestMethod]
            public void GetCustomerCampaignList()
            {
                var input = new Dictionary<string, object>()
            {

                { "custCampaignRequest",
                    new CustomerCampaignRequest
                    {CustomerType=1,
                        NumDocumento="test" ,
                        NumeroTelefono=998998,
                        TipoDocumento="Billing",


                    }

                    }

            };

                try
                {

                    var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.GetCustomerCampaignList>(input)
                                .ConfigureFor("connectionString", ConfigurationHelper.URL)
                                .Invoke();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }




            [TestMethod]
            public void UploadDocument()
            {
                var input = new Dictionary<string, object>()
            {

                { "docuploadrequest",
                    new DocumentUploadRequest
                    {
                      CustomerType=(int) CustomerType.Individual,
                      Users="owner",

                    }

                    }

            };

                try
                {

                    var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.DocumentUploadOnBaseActivity>(input)
                                .ConfigureFor("connectionString", ConfigurationHelper.URL)
                                .Invoke();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
        }


        [TestMethod]
        public void GetAvailableStocksTest()
        {
            var input = new Dictionary<string, object>()
            {

                {
                    "partNumber", "ClaroSimNano"
                }

                ,{
                    "userId", "39339"

                }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruGetAvailableStocks>(input)
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
