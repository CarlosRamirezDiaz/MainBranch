using AmxPeruPSBActivities.Activities.Individual;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.CreditScore;
using AmxPeruPSBWorkflows;
using ExternalApiWorkflows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class DontInsistTest
    {
     
        [TestMethod]
        public void CreateBulkIndividual()
        {
            string samplefile = File.ReadAllText("C:\\Users\\exybbdi\\Desktop\\finalsamplefilCopy1.csv");
            var input = new Dictionary<string, object>()
            {
                { "inputObject",
                    new AmxPeruBulkIndividualCreationRequest
                    {
                       OrderCaptureID = new Guid("8D450750-B39B-E711-812B-00505601173A"),
                       FileName = "finalsamplefilCopy1",
                       MimeType = "application/csv",
                       EncodedFile = Convert.ToBase64String(Encoding.UTF8.GetBytes(samplefile))
        }

                }

            };
            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruBulkIndividualCreation>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }


        [TestMethod]
        public void DontInsist()
        {
            var input = new Dictionary<string, object>()
            {

                { "AmxPeruDontInsistRequest",
                    new AmxPeruDontInsistRequest
                    {
                        CustomerExternalId="sfsgsggg"
                    }
                }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruDontInsist>(input)
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
    public class GetCreditScore
    {
        [TestMethod]
        public void GetCreditScoreTest()
        {

            var input = new Dictionary<string, object>()
            {

                { "AmxPeruGetCreditScoreRequest",
                    new AmxPeruGetCreditScoreRequest
                    {
                        CustomerExternalId="",
                        CustomerType=1,
                        DocumentType=250000003,
                        DocumentID="987654321"
                    }
                }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruGetCreditScore>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();

                dynamic obj = new { request = result };
                obj = result;
                var data = new JavaScriptSerializer().Serialize(result);




            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


        }
    }
}
