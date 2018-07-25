using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxCoPSBActivities.BusinessClaroESB;
using AmxCoPSBActivities.Model.TorreDeControl;
using AmxCoPSBActivities.Repository;
using AmxCoPSBActivities.ModelClaroESB.TorreDeControl;
using Newtonsoft.Json;
using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.CreditProfile;
using AmxPeruPSBActivities.Service.SendNotification;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Common;
using System.Web;
using System.Diagnostics;
using AmxPeruPSBActivities.Business;
namespace AmxCoPSBActivities.BusinessClaroESB
{
    public class AmxCoTorreDeControlBusiness
    {
        private OrganizationServiceProxy organizationService;
       //public AmxCoTorreDeControlBusiness(OrganizationServiceProxy serviceProxy)
       // {
       //     this.organizationService = serviceProxy;
       // }
        public AmxCoTorreDeControlResponse SendNotification(string torreURL, AmxCoTorreDeControlRequest request, OrganizationServiceProxy _org)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();

            string uri = torreURL;

            // Put a slash in the end of the URL

            string lastCharacter = uri.Substring(uri.Length - 1, 1);
            if (lastCharacter != "/")
            {
                uri = uri + "/";
            }

            // Convert JSON to String and append to URI

            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            string endpoint = System.Net.WebUtility.UrlEncode(jsonString).Replace("+", "%20");
            uri = uri + endpoint;

            var response = new AmxCoTorreDeControlResponse();
            var common = new AmxCoPSBActivities.BusinessClaroESB.AmxCoClaroESBCommon(_org);
            var req = TorreDeControlRequest.TorreDeControlRequestFactory(request);

            string jsonRequest;
            string jsonResponse;
            string error = null;


            try
            {
                if (!common.RestCall<TorreDeControlRequest>(uri, req, out jsonRequest, out jsonResponse, out error))
                {
                    response.Success = false;
                    response.Error = "Torre de Control no funciona!";
                    return response;
                }

                var torreDeControlResponse = JsonConvert.DeserializeObject<ModelClaroESB.TorreDeControl.TorreDeControlRespose>(jsonResponse);
                                
                response.isValid = torreDeControlResponse.isValid;
                response.message = torreDeControlResponse.message;
                
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                var success = string.IsNullOrEmpty(error);
                //Storing ESB Logs
                if (_org != null)
                {
                    try
                    {

                        string jsonRequestLog = jsonString;
                        string jsonResponseLog = jsonResponse;
                        string errorLog = error;
                        Task.Run(() => this.logRestCall(_org, torreURL, success, elapsedMs, jsonRequestLog, jsonResponseLog.ToString(), errorLog));
                    }
                    catch
                    {

                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //This method is created to save the log
        private void logRestCall(OrganizationServiceProxy _org, string url, bool success, long elapsedMs, string jsonRequest, string jsonResponse, string error)
        {
            var logRepository = new ClaroESBLogRepository(_org);
            logRepository.Create(url, success, elapsedMs, jsonRequest, jsonResponse, error);
        }
    }
}
