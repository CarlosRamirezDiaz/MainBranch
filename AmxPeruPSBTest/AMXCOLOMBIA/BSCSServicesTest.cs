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
    public class BSCSServicesTest
    {
        [TestMethod]
        public void GenericDirectoryNumberSearch()
        {
            
            var input = new Dictionary<string, object>()
            {
                { "directoryNumberRequest",
                    new AmxSoapServicesActivities.Model.GenericDirectoryNumberServiceRequest
                    {
                       npcode = "1",
                       plcode = "1001",
                       submId="1",
                       hlcode="1",
                       //hmcode="1",
                       dnCode = "3",
                       dnStatus="r",
                       searchCount="1",
                       reservation=true
                    }
                },
                
            };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                
                var result = WorkflowHelper.PrepareFor<AmxSoapServicesWorkflows.RetrieveGenericDirectoryNumber>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.CRMDEVURL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            
        }

        [TestMethod]
        public void StorageMediumSearch()
        {
            try
            {
                var input = new Dictionary<string, object>(){ };
                var result = WorkflowHelper.PrepareFor<AmxSoapServicesWorkflows.StorageMediumSearch>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.CRMDEVURL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        [TestMethod]
        public void ContractSearchByDirnum()
        {
            var input = new Dictionary<string, object>()
            {

                {"dirNum", "51800000048" }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxSoapServicesWorkflows.ContractsSearchByDirnum>(input)
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
