using AmxCoPSBActivities.Repository;
using AmxPeruPSBActivities.Model.EOC;
using Microsoft.Xrm.Sdk.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Common
{
    public class AmxHTTPCallEOC
    {
        private OrganizationServiceProxy organizationService;

        public AmxHTTPCallEOC(OrganizationServiceProxy service)
        {
            this.organizationService = service;
        }

        public bool RestCall<tRequest>(string url, tRequest requestObject, out string jsonResponse, out string error, string webrequestMethod = "PUT")
        {
            error = string.Empty;
            jsonResponse = string.Empty;

            var jsonRequest = JsonConvert.SerializeObject(requestObject, Formatting.Indented);

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                webrequest.Method = webrequestMethod;
                webrequest.Timeout = 60000;
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
                        if (jsonResponse.Contains("<type>com.conceptwave.system.CwfException</type>"))
                        {
                            var exceptionMessage = JsonConvert.DeserializeObject<EocCwfException>(jsonResponse);

                            if (exceptionMessage != null && exceptionMessage.fault != null && exceptionMessage.fault.cwApiError != null)
                            {
                                if (!string.IsNullOrEmpty(exceptionMessage.fault.cwApiError.Message))
                                    error = exceptionMessage.fault.cwApiError.Message;
                                else if (!string.IsNullOrEmpty(exceptionMessage.fault.cwApiError.cwCode))
                                    error = exceptionMessage.fault.cwApiError.cwCode;
                            }
                        }
                        else if (typeof(tRequest).Name == "AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest")
                        {
                            // Handle failure
                            var deserializedErrorResponse = JsonConvert.DeserializeObject<Model.OrderCaptureSubmit.SubmitOrderErrorResponse>(jsonResponse);
                            error = deserializedErrorResponse.fault.reason;
                        }
                        else if (!string.IsNullOrEmpty(jsonResponse))
                        {
                            error = jsonResponse;
                        }
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
            var logRepository = new EOCRequestLogRepository(this.organizationService);
            logRepository.Create(url, success, elapsedMs, jsonRequest, jsonResponse, error);
        }
    }
}
