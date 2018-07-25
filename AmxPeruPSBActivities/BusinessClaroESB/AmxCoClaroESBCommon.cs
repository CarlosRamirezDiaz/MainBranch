﻿using AmxCoPSBActivities.Repository;
using AmxPeruPSBActivities.ModelClaroESB;
using Microsoft.Xrm.Sdk.Client;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.BusinessClaroESB
{
    public class AmxCoClaroESBCommon
    {
        private OrganizationServiceProxy organizationService;

        public AmxCoClaroESBCommon(OrganizationServiceProxy service)
        {
            this.organizationService = service;
        }
        
        public bool RestCall<t>(string url, t requestObject, out string jsonRequest, out string jsonResponse, out string error, string webrequestMethod = "PUT", string headerParameter = "ClaroESB_Header")
        {
            jsonRequest = string.Empty;
            jsonResponse = string.Empty;
            error = string.Empty;
            var jsonHeaderString = string.Empty;

            if (headerParameter == "ClaroESB_Header")
                jsonHeaderString = JsonConvert.SerializeObject(new AmxCoClaroESBHeader(this.organizationService), Formatting.Indented);
            else
                jsonHeaderString = JsonConvert.SerializeObject(new ClaroESBInterfaceHeaderRequest(this.organizationService, headerParameter), Formatting.Indented);

            var jsonString = JsonConvert.SerializeObject(requestObject, Formatting.Indented);

            jsonRequest = string.Format("{{\"headerRequest\":{0},{1}", jsonHeaderString, jsonString.Substring(1));

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                webrequest.Method = webrequestMethod;
                webrequest.Timeout = 120000;
                webrequest.ContentType = "application/json";
                byte[] sentData = Encoding.UTF8.GetBytes(jsonRequest);
                webrequest.ContentLength = sentData.Length;

                using (System.IO.Stream sendStream = webrequest.GetRequestStream())
                {
                    sendStream.Write(sentData, 0, sentData.Length);
                    sendStream.Close();
                }

                System.Net.WebResponse res = webrequest.GetResponse();
                System.IO.Stream ReceiveStream = res.GetResponseStream();
                using (System.IO.StreamReader sr = new
                System.IO.StreamReader(ReceiveStream, Encoding.UTF8))
                {
                    Char[] read = new Char[256];
                    int count = sr.Read(read, 0, 256);

                    while (count > 0)
                    {
                        String str = new String(read, 0, count);
                        jsonResponse += str;
                        count = sr.Read(read, 0, 256);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                error = string.Format("HTTP_ERROR :: The second HttpWebRequest object has raised an Argument Exception as 'Connection' Property is set to 'Close' :: {0}", ex.Message);
            }
            catch (WebException ex)
            {
                error = string.Format("HTTP_ERROR :: WebException raised![{0}] - {1}", url, ex.Message);

                if (ex.Response != null)
                {
                    System.IO.Stream ReceiveStream = ex.Response.GetResponseStream();
                    using (System.IO.StreamReader sr = new
                    System.IO.StreamReader(ReceiveStream, Encoding.UTF8))
                    {

                        Char[] read = new Char[256];
                        int count = sr.Read(read, 0, 256);

                        while (count > 0)
                        {
                            String str = new String(read, 0, count);
                            jsonResponse += str;
                            count = sr.Read(read, 0, 256);
                        }
                    }

                    try
                    {
                        var exceptionMessage = JsonConvert.DeserializeObject<AmxCoClaroESBExceptionResponse>(jsonResponse);

                        if (!string.IsNullOrEmpty(exceptionMessage.technicalDescription.description))
                            error = exceptionMessage.technicalDescription.description;
                        else if (!string.IsNullOrEmpty(exceptionMessage.categoryDescription))
                            error = exceptionMessage.categoryDescription;
                    }
                    catch { error = jsonResponse; }
                }
            }
            catch (Exception ex)
            {
                error = string.Format("Exception raised![{0}] - {1}", url, ex.Message);
            }

            var success = string.IsNullOrEmpty(error);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            if (this.organizationService != null)
            {
                try
                {
                    var jsonRequestLog = jsonRequest;
                    var jsonResponseLog = jsonResponse;
                    var errorLog = error;

                    Task.Run(() => this.logRestCall(this.organizationService, url, success, elapsedMs, jsonRequestLog, jsonResponseLog, errorLog));
                }
                catch
                {

                }
            }

            return success;
        }

        private void logRestCall(OrganizationServiceProxy organizationService, string url, bool success, long elapsedMs, string jsonRequest, string jsonResponse, string error)
        {
            var logRepository = new ClaroESBLogRepository(this.organizationService);
            logRepository.Create(url, success, elapsedMs, jsonRequest, jsonResponse, error);
        }
    }
}