using AmxPeruPSBActivities.Model.Case;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace AmxPeruPSBActivities.Business
{
    public class CaseGetCunBusiness
    {
        public CaseGetCunResponse GetCun(CaseGetCunRequest objRequest, OrganizationServiceProxy service)
        {
            CaseGetCunResponse response = new CaseGetCunResponse();

            try
            {
                string urlGetCun = string.Empty;
                string jsonRequest = string.Empty;

                QueryExpression queryParameters = new QueryExpression("etel_crmconfiguration");
                queryParameters.ColumnSet = new ColumnSet("etel_value", "etel_name");
                queryParameters.Criteria.FilterOperator = LogicalOperator.Or;
                queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Case_GenerateCun_Request");
                queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Case_GenerateCun_Url");

                EntityCollection ecParameters = service.RetrieveMultiple(queryParameters);

                foreach (Entity eParam in ecParameters.Entities)
                {
                    string nameParam = string.Empty;
                    if (eParam.Contains("etel_name"))
                        nameParam = eParam["etel_name"].ToString();

                    if (nameParam.Equals("Case_GenerateCun_Request")) { jsonRequest = eParam["etel_value"].ToString(); }
                    else if (nameParam.Equals("Case_GenerateCun_Url")) { urlGetCun = eParam["etel_value"].ToString(); }
                }

                jsonRequest = jsonRequest.Replace("{0}", DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss"));
                jsonRequest = jsonRequest.Replace("{1}", objRequest.documentType);
                jsonRequest = jsonRequest.Replace("{2}", objRequest.documentId);
                jsonRequest = jsonRequest.Replace("{3}", objRequest.business);

                string responseJson = callWebService(urlGetCun, jsonRequest);
                ResponseGetProblem objResponseGetProblem = (ResponseGetProblem)convertJsonToObjeto(typeof(ResponseGetProblem), responseJson);
                
                response.success = true;
                response.message = string.Empty;
                response.cun = objResponseGetProblem.message.Replace("{cunId:", "").Replace("}", "").Trim();

                Entity eCunLog = new Entity("amx_cunlog");
                eCunLog["amx_case"] = new EntityReference("incident", Guid.Parse(objRequest.incidentId));
                eCunLog["amx_request"] = jsonRequest;
                eCunLog["amx_response"] = responseJson;
                eCunLog["amx_success"] = true;
                eCunLog["amx_name"] = objRequest.documentType + " - " + objRequest.documentId + " - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                Guid created = service.Create(eCunLog);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
                response.cun = string.Empty;

                Entity eCunLog = new Entity("amx_cunlog");
                eCunLog["amx_case"] = new EntityReference("incident", Guid.Parse(objRequest.incidentId));
                eCunLog["amx_request"] = "DocumentType: " + objRequest.documentType + " - DocumentId: " + objRequest.documentId + " - Business: " + objRequest.business;
                eCunLog["amx_response"] = ex.Message;
                eCunLog["amx_success"] = false;
                eCunLog["amx_name"] = objRequest.documentType + " - " + objRequest.documentId + " - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                Guid created = service.Create(eCunLog);
            }

            return response;
        }

        private Object convertJsonToObjeto(Type tipo, String json)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(tipo);
            Object objeto = dataContractJsonSerializer.ReadObject(new MemoryStream(Encoding.Default.GetBytes(json)));
            return objeto;
        }

        private string convertObjetoToJson(object objJson)
        {
            MemoryStream memoryStream = new MemoryStream();

            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(objJson.GetType());
            dataContractJsonSerializer.WriteObject(memoryStream, objJson);

            String json = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());

            return json;
        }

        private string callWebService(string urlrequest, string objectJson)
        {
            string responseRequest = null;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlrequest);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(objectJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseRequest = streamReader.ReadToEnd();
            }


            return responseRequest;
        }
    }

    [DataContract]
    public class ResponseGetProblem
    {
        [DataMember]
        public HeaderResponseGetProblem headerResponse { get; set; }
        [DataMember]
        public string isValid { get; set; }
        [DataMember]
        public string message { get; set; }
    }

    [DataContract]
    public class HeaderResponseGetProblem
    {
        [DataMember]
        public string responseDate { get; set; }
        [DataMember]
        public string traceabilityId { get; set; }
    }


}
