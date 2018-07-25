using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.Certicamara;
using AmxPeruPSBActivities.AMXCOLOMBIA.Business.Certicamara;
using static AmxPeruTest.Helpers.TestHelper;
using System.Threading.Tasks;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class AmxCerticamaraTest
    {
        [TestMethod]
        public void CerticamaraPayloadTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();
            var certicamaraBusiness = new CerticamaraBusiness(_org);
            var token = certicamaraBusiness.GetJsonWebToken("1234678", "Paulo Silva");

            certicamaraBusiness.ValidateResponse(token);
        }

        [TestMethod]
        public void CerticamaraResponseTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();
            var certicamaraBusiness = new CerticamaraBusiness(_org);

            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE1MTkwNTI3NzIsImV4cCI6MTUxOTA1MzA3MiwianNvbiI6IntcIkNvZGlnb1wiOjIwMDAyMDAsXCJSZXN1bHRhZG9cIjpcIkF1dG9yaXphZG9cIixcIk51dFwiOlwicTBvN2NhYmFzcDg3XCIsXCJDZWR1bGFcIjpcIjAwMTgwNDU1NTRcIn0ifQ.q6QyZ71Zh3MsVRGMCAgg8YqwrRLnpXqqkPEbHw2Asww";

            //error token
            //var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE1MTg3MjI5NzIsImV4cCI6MTUxODcyMzI3MiwianNvbiI6Ik5vIGV4aXN0ZSByZXNwdWVzdGEsIG5pbmd1biBwcm9jZXNvIGluaWNpYWRvIn0.WIqcz2FhMcU3dqIrad6H_xitWgKidamQP2wWmUS3n-o";

            var resultado = certicamaraBusiness.ValidateResponse(token);

            // wait for recording logs
            var waittask = Task.Delay(30 * 1000);
            Task.WaitAll(new Task[] { waittask });

        }
    }
}
