using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;
using System.Net;
using System.Xml;
using System.IO;
using AmxSoapServicesActivities.Model;
using AmxSoapServicesActivities.Business;
using AmxSoapServicesActivities.Activities;
using AmxSoapServicesActivities.XmlStrings;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class ChangeCustomerEmailTest1
    {
        private object customerIdTest;

        [TestMethod]
        public void ChangeCustomerEmail()
        {
            var input = new Dictionary<string, object>()
            {
                { "CustomerChangeEmailRequest",
                    new AmxSoapServicesActivities.Model.CustomerChangeEmailRequest
                    {
                        customerId = "CUST0000000089",
                        email = "wilmaralfaro@sqdm.com"
                    }
                },

            };

            

        var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ChangeCustomerEmail>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.CRMDEVURL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }




        }
    }
}
