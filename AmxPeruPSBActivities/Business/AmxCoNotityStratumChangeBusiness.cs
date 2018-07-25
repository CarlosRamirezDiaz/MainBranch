using AmxCoPSBActivities.Repository;
using AmxPeruPSBActivities.Model.Individual;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AmxPeruPSBActivities.Business
{
    public class AmxCoNotityStratumChangeBusiness
    {
        List<string> _results;
        public AmxCoNotityStratumChangeResponse AmxCoNotityStratumChange(OrganizationServiceProxy service, AmxCoNotityStratumChangeRequest request)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            AmxCoNotityStratumChangeResponse objresponse = new AmxCoNotityStratumChangeResponse();

            _results = new List<string>();

            CrmConfiguration configCrm = getConfig(service);

            if (configCrm != null)
            {
                if (!string.IsNullOrEmpty(configCrm.url))
                {
                    QueryExpression query = new QueryExpression("amx_customercontactinformation");
                    query.Criteria.AddCondition("amx_individualcustomerid", ConditionOperator.Equal, Guid.Parse(request.contactid));
                    query.Criteria.AddCondition("amx_contacttype", ConditionOperator.Equal, 173800000);
                    query.ColumnSet.AddColumns("amx_email", "amx_primarycontacttype");

                    EntityCollection result = service.RetrieveMultiple(query);

                    if (result.Entities.Count > 0)
                    {
                        Entity individual = service.Retrieve("contact", Guid.Parse(request.contactid), new ColumnSet("etel_externalid"));

                        string email = getCustomerEmail(result);
                        string externalid = string.Empty;

                        if (!string.IsNullOrEmpty(email))
                        {
                            if (individual.Contains("etel_externalid"))
                            {
                                externalid = individual.GetAttributeValue<string>("etel_externalid");
                            }

                            string jsonrequest = createJson(email, externalid);

                            string ulr = configCrm.url;
                            string response = callWebService(ulr, jsonrequest);

                            ResponseNotification objResponseControlTower = (ResponseNotification)convertJsonToObjeto(typeof(ResponseNotification), response);
                            RegisterLog(service, stopWatch, configCrm, jsonrequest, response, objResponseControlTower);
                        }
                        else
                        {
                            addResultToList("No se pudo enviar la notificación: La dirección de correo electrónico es requerida para enviar la notificación.");
                        }
                    }
                    else
                    {
                        addResultToList("No se pudo enviar la notificación: No se encontro un correo asociado al cliente individual.");
                    }
                }
                else
                {
                    addResultToList("No se pudo enviar la notificación: No se encontró la URL en el parametro: ConfigSendBase64FileToDocumentaryManagerBusiness.");
                }
            }

            if (_results.Count > 0)
            {
                objresponse.ErrorDetail = _results;
                objresponse.Error = true;
            }
            else
            {
                objresponse.ErrorDetail = null;
                objresponse.Error = false;
            }

            return objresponse;
        }

        //This method is created to save the log
        private void RegisterLog(OrganizationServiceProxy service, Stopwatch stopWatch, CrmConfiguration configCrm, string jsonrequest, string response, ResponseNotification objResponseControlTower)
        {
            if (!bool.TryParse(objResponseControlTower.isValid, out bool isvalid))
            {
                isvalid = false;
            }

            string errorMessage = string.Empty;

            if (!isvalid)
            {
                errorMessage = objResponseControlTower.message;
            }

            stopWatch.Stop();
            var elapsed = stopWatch.ElapsedMilliseconds;

            ClaroESBLogRepository claroesb = new ClaroESBLogRepository(service);
            claroesb.Create(configCrm.url, isvalid, elapsed, jsonrequest, response, errorMessage);
        }

        private string getCustomerEmail(EntityCollection customerContactInformations)
        {
            string email = null;

            foreach (Entity info in customerContactInformations.Entities)
            {
                if (info.Contains("amx_email"))
                {
                    email = info.GetAttributeValue<string>("amx_email");

                    if (info.Contains("amx_primarycontacttype"))
                    {
                        if (info.GetAttributeValue<bool>("amx_primarycontacttype") == true)
                        {
                            break;
                        }
                    }
                }
            }

            return email;
        }

        private string createJson(string email, string externalid)
        {
            JsonNotify json = new JsonNotify();

            json.pushType = "SINGLE";
            json.typeCostumer = "costumerId";
            json.messageBox = new List<MessageBox>();

            MessageBox messageBox = new MessageBox();
            messageBox.messageChannel = "MAIL";

            messageBox.messageBox = new List<MessageBoxSon>();

            MessageBoxSon mesSon = new MessageBoxSon();
            mesSon.costumerId = externalid;
            mesSon.costumerBox = email;

            json.profileId = new List<string>();
            json.profileId.Add("profile1");

            json.communicationType = new List<string>();
            json.communicationType.Add("communicationType");

            json.communicationOrigin = "TCRM|PLM|CLM|EOC|XCOLLECTIONS|BCSC|NMS";
            json.deliveryReceipts = "N";
            json.contentType = "message";
            json.messageContent = "Se le informa que se inició el proceso de cambio de estado satisfactoriamente.";

            messageBox.messageBox.Add(mesSon);
            json.messageBox.Add(messageBox);

            string jsonrequest = convertObjetoToJson(json);

            return jsonrequest;
        }

        private CrmConfiguration getConfig(OrganizationServiceProxy service)
        {
            Entity config = getParam(service, "ConfigNotityStratumChange");

            if (config != null)
            {
                if (config.Contains("etel_value"))
                {
                    CrmConfiguration configurationCrm = (CrmConfiguration)convertJsonToObjeto(typeof(CrmConfiguration), config.GetAttributeValue<string>("etel_value"));
                    return configurationCrm;
                }
                else
                {
                    addResultToList("No se pudo enviar la notificación: El JSON almacenado en el parametro: Address_MGL_HeaderRequest, esta vacío.");
                }
            }

            return null;
        }

        private Entity getParam(OrganizationServiceProxy service, string paramname)
        {
            QueryExpression query = new QueryExpression("etel_crmconfiguration");
            query.Criteria.AddCondition("etel_name", ConditionOperator.Equal, paramname);
            query.ColumnSet.AddColumns("etel_value");

            EntityCollection configResult = service.RetrieveMultiple(query);

            if (configResult.Entities.Count > 0)
            {
                return configResult.Entities.FirstOrDefault();
            }
            else
            {
                addResultToList(string.Format("No se pudo enviar la notificación: No se encontró el parámetro: {0}.", paramname));
            }
            return null;
        }

        private void addResultToList(string detail)
        {
            _results.Add(detail);
        }

        private Object convertJsonToObjeto(Type tipo, String json)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(tipo);
            Object objeto = dataContractJsonSerializer.ReadObject(new MemoryStream(Encoding.Default.GetBytes(json)));
            return objeto;
        }

        private string convertObjetoToJson(object objeto)
        {
            MemoryStream memoryStream = new MemoryStream();

            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(objeto.GetType());
            dataContractJsonSerializer.WriteObject(memoryStream, objeto);

            String json = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());

            return json;
        }

        private string callWebService(string urlrequest, string objectJson)
        {
            string responseRequest = null;

            try
            {
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
            }
            catch (Exception e)
            {
                addResultToList("No se pudo enviar la notificación: Se presentó un error al ejecutar el servicio. Detalles: " + e.Message);
            }

            return responseRequest;
        }        
    }

    [DataContract]
    public class JsonNotify
    {
        [DataMember]
        public string pushType { get; set; }
        [DataMember]
        public string typeCostumer { get; set; }
        [DataMember]
        public List<MessageBox> messageBox { get; set; }
        [DataMember]
        public List<string> profileId { get; set; }
        [DataMember]
        public List<string> communicationType { get; set; }
        [DataMember]
        public string communicationOrigin { get; set; }
        [DataMember]
        public string deliveryReceipts { get; set; }
        [DataMember]
        public string contentType { get; set; }
        [DataMember]
        public string messageContent { get; set; }
    }

    [DataContract]
    public class MessageBox
    {
        [DataMember]
        public string messageChannel { get; set; }
        [DataMember]
        public List<MessageBoxSon> messageBox { get; set; }
    }

    [DataContract]
    public class MessageBoxSon
    {
        [DataMember]
        public string costumerId { get; set; }
        [DataMember]
        public string costumerBox { get; set; }
    }

    [DataContract]
    class ResponseNotification
    {
        [DataMember]
        public string isValid { get; set; }
        [DataMember]
        public string message { get; set; }
    }
}
