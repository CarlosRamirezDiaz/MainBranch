using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AmxPeruTest.Helpers.TestHelper;
using AmxPeruPSBActivities.BSS_CUSTOMER_CREDIT_SCORE_MGMT_LG_V1;
using AmxPeruPSBActivities.Model.BSSCustomerCreditScoreMgmtLG;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.CustomerAccountStatement;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class BSSCustomerCreditScoreTest
    {
        [TestMethod]
        public void BSSCustomerCreditTest()
        {
            try
            {
                var input = new Dictionary<string, object>()
                {
                   { "creditScorerequest",
                        new AMXPeruBSSCustomerCreditScoreMgmtLGRequest
                        {
                            Requestburorequesttype = new AMXPeruRequestBuroRequestType()
                            {
                                Documentnumber = "16",
                                Documenttype = "doctype",
                                Lastname = "lname",
                                Motherlastname = "mlname",
                                Names = "Robin",
                                Tableconfiguration = new AMXPeruTableconfigtype()
                                {
                                    Code = 789,
                                    Firstname = "Robin",
                                    Share = 878,
                                    Typedocument = "67",
                                    Url = "dummy Url"
                                }
                            },

                            Optionalrequestlist = new AMXPeruOptionalrequestlisttype()
                            {
                                Name = "dew",
                                Value = "dd"
                            }
                        }

                   }
                };

             var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.BSSCustomerCreditScoreMgmtLG>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }

            
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void GetConsultationAccountStatusTest()
        {
            try
            {
                var input = new Dictionary<string, object>()
                {
                   { "request",
                        new AMXPeruAccountConsultationRequest
                        {
                            ApplicationCode="1",
                            BalanceEnquryFlag= "true" ,
                            Channel="test" ,
                            CLIAccountNo="1000" ,
                            CustomerExternalId="1",
                            CustomerType=1,
                            EndDate=DateTime.Now.Date,
                            PageNo="1",
                            PageSize=10,
                            PaymentDisputeFlag="false",
                            QueryType="1" ,
                            ServiceType="1" ,
                            StartDate=DateTime.Now.AddMonths(-1),
                            TelephoneNo="90999",
                            TransactionId="1"    ,
                            UserApplication="owner"


                        }

                   }
                };

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.GetConsultationAccountStatus>(input)
                               .ConfigureFor("connectionString", ConfigurationHelper.URL)
                               .Invoke();
            }


            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }





        [TestMethod]
        public void AddressValidateTest()
        {
            try
            {
                var input = new Dictionary<string, object>()
                {
                   { "input",
                        new AMxperuValidaCoberturaRequest
                        {
                            latitude = 22.34F,
                            longitude = 65.78F
                        }
                   }
                };

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMxperuValidaCobertura>(input)
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
