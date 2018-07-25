using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.AffiliateDisaffiliate;
using AmxPeruPSBActivities.Model.Case;
using AmxPeruPSBActivities.Model.Task;
using AmxPSBActivities.Model;
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
    public class AmxCOCTITest
    {
        [TestMethod]
        public void AmxGetCustomerInfo()
        {
            var input = new Dictionary<string, object>()
            {
                { "request",
                    new AmxGetCustomerInfoRequest
                    {
                        CustomerExternalId= "CUST0000000096",
                        CustomerType=1,
                        documentType=1,
                        documentNumber="J990012782",
                        msisdn="99880011"
                    }
                }

            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.AmxGetCustomerInfo>(input)
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
