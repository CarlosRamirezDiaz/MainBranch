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

namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxCOProspectTest
    {
        [TestMethod]
        public void CreateProspectTest()
        {
            var createProspectBusiness = new AmxPeruPSBActivities.Business.AmxCoCreateProspectBusiness();

            var prospectRequest = new AxmPeruCreateProspectRequest()
            {
                documentType = (int)AmxCoDocumentTypeEnum.CEDULA_DE_CIUDADANIA,
                documentNumber = "18045554",
                phone = "5411985251421",
                firstName = string.Empty,
                lastName = string.Empty
            };

            var _org = OrganizationProxy.GetOrganizationProxy();

            var prospectResponse = createProspectBusiness.CreateProspectCustomer(prospectRequest, _org);

            Guid prospectId = Guid.Empty;
            Guid.TryParse(prospectResponse.prospectId, out prospectId);

            var prospectUrl = string.Format("http://172.18.88.70/TCRMDEV/main.aspx?etc=2&extraqs=formid%3d3a7ba5d1-84e6-4659-a654-9a4911a6a2f7&id=%7b{0}%7d&pagetype=entityrecord", prospectId);

            Assert.AreNotEqual(prospectId, Guid.Empty);
        }
    }
}
