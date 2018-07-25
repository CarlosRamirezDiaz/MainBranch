using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.AffiliateDisaffiliate;
using AmxPeruPSBActivities.Model.Case;
using AmxPeruPSBActivities.Model.Individual;
using AmxPeruPSBActivities.Model.Task;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;
using System.Web.Script;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using AmxCoPSBActivities.Model.Evidente;
using AmxCoPSBActivities.ModelClaroESB.Bureau;
using System.Activities;
using AmxCoPSBActivities.ModelClaroESB.Evidente;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxUpdateAppointmentStatusTest
    {
        [TestMethod]
        public void AmxUpdateAppointmentStatusFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                {"workOrderId", "ORDMD0002113_29"},
                {"confirmationStatus", ""},
                {"status", "notifystartworkorder"},
                {"technicianId", ""},
                {"statusReason", ""}
            };

            try
            {
                 var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.IVR.AmxUpdateAppointmentStatus>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();
            }
            catch (Exception ex)
            { }
        }
    }
}
