using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.CustomerEmailBilling;
using AmxCoPSBActivities.Repository;
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
using AmxPeruPSBActivities.Model;


namespace AmxPeruPSBActivities.Business
{
    public class AmxCoCustomerEmailBillingBusiness
    {
        private OrganizationServiceProxy organizationService;
        //public AmxCoTorreDeControlBusiness(OrganizationServiceProxy serviceProxy)
        // {
        //     this.organizationService = serviceProxy;
        // }
        public AmxCoCustomerEmailBillingRespose SendNotification(string ParadigmaUpdateMailURL, AmxCoCustomerEmailBillingRequest request, OrganizationServiceProxy _org)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();

            string uri = ParadigmaUpdateMailURL;

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

            var response = new AmxCoCustomerEmailBillingRespose();
            var common = new AmxCoPSBActivities.BusinessClaroESB.AmxCoClaroESBCommon(_org);
            var req = AmxCoCustomerEmailBillingRequest.CustomerEmailBillingRequestFactory();

            string jsonRequest;
            string jsonResponse;
            string error = null;


            try
            {
                if (!common.RestCall<AmxCoCustomerEmailBillingRequest>(uri, req, out jsonRequest, out jsonResponse, out error))
                {
                    response.Success = false;
                    response.Error = "Actualiza Paradigma Email no funciona!";
                    return response;
                }

                var customerEmailBilling = JsonConvert.DeserializeObject<AmxCoCustomerEmailBillingRespose>(jsonResponse);

                response.Error = customerEmailBilling.Error;
                response.registrado = customerEmailBilling.registrado;

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
                        Task.Run(() => this.logRestCall(_org, ParadigmaUpdateMailURL, success, elapsedMs, jsonRequestLog, jsonResponseLog.ToString(), errorLog));
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