using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Ericsson.PSB.Workflow.Client.Core;
using Ericsson.PSB.Workflow.Client.Core.Serializer;
using System.IO;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model.OrderCaptureSubmit;

namespace Ericsson.PSB.Workflow.Activities
{
    public sealed class AmxHttpCall<TInArgument, TResult> : CodeActivity<TResult>
    {
        [RequiredArgument]
        public InArgument<string> Uri { get; set; }
        [RequiredArgument]
        public InArgument<string> Method { get; set; }
        public InArgument<string> TimeoutTicks { get; set; }
        public InArgument<TInArgument> RequestParameter { get; set; }
        public InArgument<Dictionary<string, string>> Headers { get; set; }
        public InArgument<JsonSettings> JsonSerializerSetting { get; set; }

        protected override TResult Execute(CodeActivityContext context)
        {
            string uri = context.GetValue(Uri);
            var useridentityExtension = context.GetExtension<UserIdentityExtension>();
            string method = context.GetValue(Method);
            TInArgument requestParameter = context.GetValue(RequestParameter);
            JsonSettings setting = context.GetValue(JsonSerializerSetting);
            var timeoutTicks = Convert.ToInt64(TimeoutTicks.Get(context));
            var jsonSerializer = new NewtonsoftJsonSerializer();

            Dictionary<string, string> headers = context.GetValue(Headers);

            using (var client = new HttpClient())
            {
                //setting headers
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                //setting user header
                var identity = useridentityExtension?.GetIdentity();

                if (!string.IsNullOrWhiteSpace(identity?.Name))
                {
                    client.DefaultRequestHeaders.Add("tcrm-username", identity.Name);
                }

                client.Timeout = new TimeSpan(timeoutTicks);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                IRestClientStrategy<TInArgument, TResult> strategy = GetCallingStrategy(method);
                var response = strategy.Call(uri, requestParameter, client, setting);

                return response;
            }
        }

        private IRestClientStrategy<TInArgument, TResult> GetCallingStrategy(string method)
        {
            IRestClientStrategy<TInArgument, TResult> restStrategy = null;
            if (string.IsNullOrWhiteSpace(method))
            {
                throw new ArgumentNullException(nameof(method));
            }
            switch (method.ToUpperInvariant())
            {
                case "POST":
                    restStrategy = new RestPost<TInArgument, TResult>();
                    break;
                case "PUT":
                    restStrategy = new RestPut<TInArgument, TResult>();
                    break;
                case "GET":
                    restStrategy = new RestGet<TInArgument, TResult>();
                    break;
                case "DELETE":
                    restStrategy = new RestDelete<TInArgument, TResult>();
                    break;
                default:
                    throw new NotSupportedException("Method name is wrong or not supported");
            }
            return restStrategy;
        }
    }

    class RestPost<TInArgument, TResult> : IRestClientStrategy<TInArgument, TResult>
    {
        public object HttpClientExtensions { get; private set; }

        public TResult Call(string uri, TInArgument inArgument, HttpClient client, JsonSettings jsonSetting)
        {
            /*earande debug*/
            string path = @"c:\tcrm\logs\earande.txt";
            FileStream fs = null;
            if (File.Exists(path))
            { fs = File.Open(path, FileMode.Append); }
            else { fs = File.Create(path); }

            string inArgumentAsJson = null;
            var jsonSerializer = new NewtonsoftJsonSerializer();
            if (inArgument != null)
            {
                inArgumentAsJson = jsonSerializer.Serialize(inArgument, jsonSetting);
            }
            else
            {
                inArgumentAsJson = string.Empty;
            }

            fs.Write(Encoding.ASCII.GetBytes("\r\nJSON REQUEST: \r\n"), 0, "\r\nJSON REQUEST: \r\n".Length);
            fs.Write(Encoding.ASCII.GetBytes(inArgumentAsJson), 0, inArgumentAsJson.Length);

            var response = default(HttpResponseMessage);
            var request = new StringContent(inArgumentAsJson, Encoding.UTF8, "application/json");
            String responseResult = null;

            try {
                client.Timeout = TimeSpan.FromMinutes(30);
                response = client.PostAsync(uri, request).Result;
                responseResult = response.Content.ReadAsStringAsync().Result;

                // Printing result from JSON REQUEST
                fs.Write(Encoding.ASCII.GetBytes("\r\nJSON RESPONSE \r\n"), 0, "\r\nJSON RESPONSE \r\n".Length);
                fs.Write(Encoding.ASCII.GetBytes(responseResult), 0, responseResult.Length);
                fs.Write(Encoding.ASCII.GetBytes("\r\n"), 0, "\r\n".Length);
                fs.Close();

                Debug.WriteLine($"POST response from Service \r\n {responseResult}");
                
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return jsonSerializer.Deserialize<TResult>(responseResult, jsonSetting);
                }
                else
                {
                    // Handle failure
                    var deserializedErrorResponse = jsonSerializer.Deserialize<SubmitOrderErrorResponse>(responseResult, jsonSetting);
                    var reason = deserializedErrorResponse.fault.reason;
                    throw new HttpRequestException(reason);
                }                         
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }

    class RestPut<TInArgument, TResult> : IRestClientStrategy<TInArgument, TResult>
    {
        public TResult Call(string uri, TInArgument inArgument, HttpClient client, JsonSettings jsonSetting)
        {
            string inArgumentAsJson = null;
            var jsonSerializer = new NewtonsoftJsonSerializer();
            if (inArgument != null)
            {
                inArgumentAsJson = jsonSerializer.Serialize(inArgument, jsonSetting);
            }
            else
            {
                inArgumentAsJson = string.Empty;
            }

            var response = client.PutAsync(uri, new StringContent(inArgumentAsJson, Encoding.Default, "application/json")).Result;            

            var responseResult = response.Content.ReadAsStringAsync().Result;

            response.EnsureSuccessStatusCode();

            return jsonSerializer.Deserialize<TResult>(responseResult, jsonSetting);
        }
    }

    class RestGet<TInArgument, TResult> : IRestClientStrategy<TInArgument, TResult>
    {
        public TResult Call(string uri, TInArgument inArgument, HttpClient client, JsonSettings jsonSetting)
        {
            var jsonSerializer = new NewtonsoftJsonSerializer();
            var response = client.GetAsync(uri).Result;
            var responseResult = response.Content.ReadAsStringAsync().Result;
            response.EnsureSuccessStatusCode();
            Debug.WriteLine(string.Format("GET response from Service \r\n {0}", responseResult));
            return jsonSerializer.Deserialize<TResult>(responseResult, jsonSetting);
        }
    }

    class RestDelete<TInArgument, TResult> : IRestClientStrategy<TInArgument, TResult>
    {
        public TResult Call(string uri, TInArgument inArgument, HttpClient client, JsonSettings jsonSetting)
        {
            var jsonSerializer = new NewtonsoftJsonSerializer();
            var response = client.DeleteAsync(uri).Result;
            var responseResult = response.Content.ReadAsStringAsync().Result;
            response.EnsureSuccessStatusCode();
            Debug.WriteLine(string.Format("DELETE response from Service \r\n {0}", responseResult));
            return jsonSerializer.Deserialize<TResult>(responseResult, jsonSetting);
        }
    }

    class LogHelper {

        public void CreateLog(string t)
        {
            StreamWriter writer = new StreamWriter("C:\\tcrm\\logs\\HttpCall.txt");
            writer.WriteLine(t);
            writer.Close();
        }
    }

}
