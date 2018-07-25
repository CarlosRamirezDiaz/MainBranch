using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxDigiturnoTest
    {
        [TestMethod]
        public void NotifyEventTurnBusinessTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();
            //var digiturnoURL = @"http://172.24.42.211:8002/Turn/V1.0/Rest/NotifyEventTurn";
            var digiturnoURL = @"http://localhost:58002/Turn/V1.0/Rest/NotifyEventTurn";

            var digiturnoBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoDigiturnoBusiness();

            var request = new AmxCoPSBActivities.Model.Digiturno.DigiturnoNotifyEventTurnRequest
            {
                IdBusinessInteraction = 3,
                IdEvent = 3,
                IdTurn = 90191022
            };

            try
            {
                var response = digiturnoBusiness.NotifyEventTurn(request, digiturnoURL, _org);
            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void NotifyEventTurnFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "request",
                    new AmxCoPSBActivities.Model.Digiturno.DigiturnoNotifyEventTurnRequest
                    {
                        IdBusinessInteraction = 3,
                        IdEvent = 3,
                        IdTurn = 3
                    }
                }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ClaroESB.AmxCoDigiturnoNotifyEventTurn>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void NotifyEventTurnQctivityTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "request",
                    new AmxCoPSBActivities.Model.Digiturno.DigiturnoNotifyEventTurnRequest
                    {
                        IdBusinessInteraction = 3,
                        IdEvent = 3,
                        IdTurn = 3
                    }
                }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBActivities.ActivitiesClaroESB.AmxCoDigiturnoNotifyEventTurn>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .ConfigureXrmDataContext()
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void UpdateUserTurnBusinessTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();
            //var digiturnoURL = @"http://172.24.42.211:8002/Turn/V1.0/Rest/UpdateUserTurn";
            var digiturnoURL = @"http://localhost:58002/Turn/V1.0/Rest/UpdateUserTurn";

            var digiturnoBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoDigiturnoBusiness();

            var request = new AmxCoPSBActivities.Model.Digiturno.DigiturnoUpdateUserTurnRequest
            {
            };

            try
            {
                var response = digiturnoBusiness.UpdateUserTurn(request, digiturnoURL, _org);
            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void UpdateUserTurnFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "request",
                    new AmxCoPSBActivities.Model.Digiturno.DigiturnoUpdateUserTurnRequest
                    {
                    }
                }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ClaroESB.AmxCoDigiturnoUpdateUserTurn>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void SendToPSBAmxCoDigiturnoNotifyEventTurnTest()
        {
            var interactionId = "0020";
            var eventId = "2";
            var digiturnoId = "90901";

            var request = "{\"request\":" +
                "{ \"$type\":\"AmxCoPSBActivities.Model.Digiturno.DigiturnoNotifyEventTurnRequest, AmxPeruPSBActivities\"," +
                " \"IdBusinessInteraction\" : {{IdBusinessInteraction}}," +
                "\"IdEvent\" : {{IdEvent}}," +
                "\"IdTurn\" : \"{{IdTurn}}\"" +
                 "}" +
            "}";

            request = request.Replace("{{IdBusinessInteraction}}", interactionId);
            request = request.Replace("{{IdEvent}}", eventId);
            request = request.Replace("{{IdTurn}}", digiturnoId);

            var url = @"http://localhost:56006" + @"/api/v1/workflow/AmxCoDigiturnoNotifyEventTurn";
            var user = "epcosva";
            var password = "Ericsson2017";
            var domain = "COMCEL";

            try
            {
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);

                NetworkCredential credential = new NetworkCredential(user, password, domain);
                CredentialCache credentialCache = new CredentialCache();
                credentialCache.Add(new Uri(url), "NTLM", credential);

                webrequest.Credentials = credentialCache;

                webrequest.Method = "POST";
                webrequest.Timeout = 30000;
                webrequest.ContentType = "application/json";
                byte[] sentData = Encoding.UTF8.GetBytes(request);
                webrequest.ContentLength = sentData.Length;

                using (System.IO.Stream sendStream = webrequest.GetRequestStream())
                {
                    sendStream.Write(sentData, 0, sentData.Length);
                    sendStream.Close();
                }

                string jsonResponse = string.Empty;
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
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void SendStartInteractionNotificationToDigiturnoActivityTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "biSpecificationName", "Bill Cycle Change" }, 
                { "userId", "30163661-05A3-E711-80DD-FA163E106136" },
                { "digiturnoUrl", @"http://localhost:8002/Turn/V1.0/Rest/NotifyEventTurn" }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBActivities.AMXCOLOMBIA.Activities.Digiturno.SendStartInteractionNotificationToDigiturno>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .ConfigureXrmDataContext()
                        .Invoke();
            }
            catch (Exception ex)
            { }
        }

        [TestMethod]
        public void SendStartInteractionNotificationToDigiturnoFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "biSpecificationName", "Bill Cycle Change" },
                { "userId", "30163661-05A3-E711-80DD-FA163E106136" }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.SendStartInteractionNotificationToDigiturno>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();
            }
            catch (Exception ex)
            { }
        }
    }
}

