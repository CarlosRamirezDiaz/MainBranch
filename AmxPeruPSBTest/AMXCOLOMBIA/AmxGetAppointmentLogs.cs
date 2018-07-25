using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;
using AMXCommon.Model.AppointmentLog;
using Microsoft.Xrm.Sdk;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class AmxGetAppointmentLogs
    {
        [TestMethod]
        public void GetAppointmentLog()
        {
            var input = new Dictionary<string, object>()
            {
                {
                    "clientIdentifiationNo", "P6753864"
                }
            };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.AmxGetAppoinments>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void GetAppointmentStatus()
        {
            var input = new Dictionary<string, object>()
            {
                {
                    "workorderId", "38576"
                }
            };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.IVR.AmxGetAppointmentStatus>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void UpdateAppointmentStatus()
        {
            var input = new Dictionary<string, object>()
            {
                {
                    "appUpdateRequest" , new AMXUpdateAppointmentStatusModel{
                     workOrderId = "38576", confirmationStatus = "Pending"
                    }

                }
            };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.IVR.AmxUpdateAppointmentStatus>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void SaveContactToList()
        {
            //IOrganizationService service = OrganizationProxy.GetOrganizationProxy();
            //var res = new AMXCommon.Business.AppointmentLog.AMXSaveContactToListBusiness().GetAppointmentLogDetails(
            //    service, new Guid("F4B6D229-B3E1-E711-80E7-FA163E10DFBE"), "SaveContactList");

            //var input = new Dictionary<string, object>()
            //{
               
            //};

            //var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            //var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            //try
            //{
            //    var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.AMXSaveContactToList>(input)
            //                .ConfigureFor("connectionString", ConfigurationHelper.URL)
            //                .Invoke();
            //}
            //catch (Exception ex)
            //{
            //    ex.Message.ToString();
            //}
        }

    }
}
