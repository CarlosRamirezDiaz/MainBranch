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
using AmxPeruPSBActivities.Model.InternalExternalAccount;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AmxCoCreateItemsAccountTest()
        {
            var input = new Dictionary<string, object>();
            input.Add("Individuald", "EC17E8C1-9418-E811-80ED-FA163E10DFBE");
            //Guid guidIndividual = Guid.Parse("B48ED77E-9227-E811-80ED-FA163E10DFBE");

            //var workflowStartInput = {
            //  Individuald = "{EC17E8C1-9418-E811-80ED-FA163E10DFBE}"
            //};

            
            //var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            //var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);
            

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxCoCreateItemsAccountWithDataBSCS>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.CRMDEVURLt)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
