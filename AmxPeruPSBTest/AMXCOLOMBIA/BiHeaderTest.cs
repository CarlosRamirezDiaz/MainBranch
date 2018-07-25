using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class BiHeaderTest
    {
        [TestMethod]
        public void GetActiveBiHeaderTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();

            var repository = new AMXCommon.Repository.BiHeader.BiHeaderRepository();

            var userId = new Guid("30163661-05A3-E711-80DD-FA163E106136");

            var activeBiHeader = repository.GetActiveBiHeader(userId, _org);
        }

        [TestMethod]
        public void CloseActiveBiHeaderTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();

            var repository = new AMXCommon.Repository.BiHeader.BiHeaderRepository();

            var userId = new Guid("30163661-05A3-E711-80DD-FA163E106136");

            var activeBiHeader = repository.GetActiveBiHeader(userId, _org);

            repository.CloseBiHeader(activeBiHeader.Id, _org);
        }

        [TestMethod]
        public void CreateBiHeaderTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();

            var repository = new AMXCommon.Repository.BiHeader.BiHeaderRepository();

            var biHeader = new AMXCommon.Model.BiHeader.BiHeaderModel();

            biHeader.ChannelInteractionId = "00001";
            biHeader.CsrId = new Guid("30163661-05A3-E711-80DD-FA163E106136");
            biHeader.IndividualCustomerId = new Guid("204333DC-6C1E-E811-80ED-FA163E10DFBE");
            biHeader.Subject = string.Format("Digiturno: {0}", biHeader.ChannelInteractionId);

            repository.Create(biHeader, _org);
        }
    }
}
