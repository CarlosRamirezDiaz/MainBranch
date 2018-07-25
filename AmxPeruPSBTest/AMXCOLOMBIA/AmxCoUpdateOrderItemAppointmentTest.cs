using AmxPeruPSBActivities.AMXCOLOMBIA.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    class AmxCoUpdateOrderItemAppointmentTest
    {
        [TestClass]
        public class AmxCoAddUpdateResourceCharTest
        {
            [TestMethod]
            public void AddUpdateResourceCharTest()
            {
                String orderId = "0F2BC75D-02E7-E711-80E9-FA163E10DFBE";
                String appointmentId = "DC90BDA8-BBE6-E711-80E9-FA163E10DFBE";

                var input = new Dictionary<string, object>() {
                    {"orderId", orderId},
                    { "appointmentId", appointmentId }
                };


                try
                {
                    // Business
                    /*var _org = OrganizationProxy.GetOrganizationProxy();
                    AmxCoUpdateOrderItemAppointmentBusiness business = new AmxCoUpdateOrderItemAppointmentBusiness();
                    business.AmxCoUpdateOrderItemAppointment(_org, new Guid(orderId), new Guid(appointmentId));
                    business.ToString();*/

                    // WF
                    var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.AmxCoUpdateOrderItemAppointment>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
                            
                }
                catch (Exception ex)
                { ex.Message.ToString(); }
            }
        }
    }
}
