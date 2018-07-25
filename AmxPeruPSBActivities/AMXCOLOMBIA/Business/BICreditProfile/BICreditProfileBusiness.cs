using AmxCoPSBActivities.BusinessClaroESB;
using AmxCoPSBActivities.Repository;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BICreditProfile;
using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk.Client;
using Newtonsoft.Json;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Business.BICreditProfile
{
    public class BICreditProfileBusiness
    {
        #region Declaration
        private OrganizationServiceProxy service = null;

        string jsonResponse = string.Empty;

        string error = string.Empty;
       
        #endregion


        /// <summary>
        /// This method is to get customer Credit profile information
        /// </summary>
        /// <param name="bICreditProfileRequest">BI Credit Profile Request input parameters</param>
        /// <param name="service">CRM Service</param>
        /// <returns></returns>
        public BICreditProfileResponse GetBICreditProfileInfo(BICreditProfileRequest bICreditProfileRequest, OrganizationServiceProxy service)
        {
            AMXCommon.Common com = new AMXCommon.Common();
            var common = new AmxCoPSBActivities.BusinessClaroESB.AmxCoClaroESBCommon(service);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var response = new BICreditProfileResponse();
            if (bICreditProfileRequest == null)
                return null;

            var creditProfileBiURL = CRMConfiguration.GetStringValue("BI_CreditProfile", service);
            //var creditProfileBiURL = @"http://localhost:8002/Customer/V1.0/Rest/getRisk"; // only for unit test

            string jsonResponse = string.Empty;
            string jsonRequest = string.Empty;
            string error = string.Empty;

            var successCall = common.RestCall<BICreditProfileRequest>(creditProfileBiURL, bICreditProfileRequest, out jsonRequest, out jsonResponse,out error,"PUT", "BICreditProfile");

            if (!successCall)
            {
                response.Success = false;
                response.Error = error;
                return response;
            }
            response = JsonConvert.DeserializeObject<BICreditProfileResponse>(jsonResponse);
            response.Success = successCall;
            response.Status = "SUCCESS";

            return response;
        }

    }
}
