using AmxPeruPSBActivities.AMXCOLOMBIA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class AMXRetrieveCustomerAddressTest
    {
        [TestMethod]
        public void GetCustomerAddressTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();

            var request =
                    new AmxPeruPSBActivities.AMXCOLOMBIA.Model.cmtDireccionRequestDto
                    {            
                        codigoDane = "11001000",  // Bogotá
                        direccion = "CL 101",
                        isDth = false,
                        nodoGestion = "",
                        user = "",
                        estrato = ""
                    };


            var mgl_user = "user258";
            var mgl_url = "http://localhost:8002";
            var mgl_Header = "{ 'transactionId' : 'transactionId1', 'system' : 'system2', 'user' : 'user3', 'password' : 'password4', 'requestDate' : '2018-01-05T15:22:40.408', 'ipApplication' : 'ipApplication5', 'traceabilityId' : 'traceabilityId6' }";
            try
            {
                var jsonResponseStr = new AmxGetCustomerAddressBusiness()
                    .GetCustomerAddress(request, mgl_user, mgl_url, mgl_Header, _org);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
