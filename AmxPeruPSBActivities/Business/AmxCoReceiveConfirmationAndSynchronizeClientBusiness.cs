using AmxPeruPSBActivities.Model.Individual;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
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
    public class AmxCoReceiveConfirmationAndSynchronizeClientBusiness
    {
        List<string> _results;
        public AmxCoReceiveConfirmationAndSynchronizeClientResponse AmxCoSynchronizeClient(OrganizationServiceProxy service, AmxCoReceiveConfirmationAndSynchronizeClientRequest request)
        {
            _results = new List<string>();
            AmxCoReceiveConfirmationAndSynchronizeClientResponse response = new AmxCoReceiveConfirmationAndSynchronizeClientResponse();

            CrmConfiguration configCrm = getConfig(service);
            string xmlRequestBSCS = string.Empty;

            if (configCrm != null)
            {
                if (!string.IsNullOrEmpty(configCrm.url))
                {
                    QueryExpression query = new QueryExpression("etel_bi_log");
                    query.Criteria.AddCondition("activityid", ConditionOperator.Equal, Guid.Parse(request.BiLogId));
                    query.ColumnSet.AddColumns("customers", "subject");

                    EntityCollection result = service.RetrieveMultiple(query);

                    if (result.Entities.Count > 0)
                    {
                        Entity biEnt = result.Entities.FirstOrDefault();

                        if (request.Confirmation == true)
                        {
                            if (biEnt.Contains("customers"))
                            {
                                string contactId = getCustomerField(biEnt);

                                if (contactId != null)
                                {
                                    Entity contactEnt = service.Retrieve("contact", Guid.Parse(contactId), new ColumnSet("etel_externalid"));

                                    if (contactEnt != null)
                                    {
                                        if (contactEnt.Contains("etel_externalid"))
                                        {
                                            updateIndividualCustomer(service, request, contactEnt.Id);

                                            xmlRequestBSCS = createXmlRequest(configCrm, request.email, biEnt.GetAttributeValue<string>("etel_externalid"));
                                            string strResponse = callSoapWebService(xmlRequestBSCS, configCrm.url);

                                            changeStateBi(service, biEnt.Id, "Confirmado");
                                        }
                                        else
                                        {
                                            addResultToList("El campo: etel_externalid es requerido en cliente individual.");
                                        }
                                    }
                                    else
                                    {
                                        addResultToList("No se encontró un cliente individual asociado a la BILog.");
                                    }
                                }

                            }
                            else
                            {
                                addResultToList("El cliente individual es requerido para la actualización de datos.");
                            }
                        }
                        else
                        {
                            changeStateBi(service, biEnt.Id, "Caduco");
                        }
                    }
                }
            }

            if (_results.Count > 0)
            {
                response.ErrorDetail = _results;
                response.Error = true;
            }
            else
            {
                response.ErrorDetail = null;
                response.Error = false;
            }

            return response;
        }

        private string getCustomerField(Entity biEnt)
        {
            bool error = false;
            EntityCollection results = (EntityCollection)biEnt["customers"];

            if (results.Entities.Count > 0)
            {
                Entity party = results.Entities.FirstOrDefault();

                if (party.Contains("partyid"))
                {
                    return party.GetAttributeValue<EntityReference>("partyid").Id.ToString();
                }
                else
                {
                    error = true;
                }
            }
            else
            {
                error = true;
            }

            if (error)
            {
                addResultToList("No se encontró un cliente individual asociado a la BILog.");
            }

            return null;
        }

        private string createXmlRequest(CrmConfiguration configCrm, string email, string externalid)
        {
            string xmlrequest = string.Empty;

            string body = string.Empty;
            string customerCreate = string.Empty;
            string inputAttributes = string.Empty;
            string sessionChangeRequest = string.Empty;

            xmlrequest = getHeaderXML(configCrm);

            string cspPmntId = getTagXML("pay:cspPmntId", "-1");
            string paymentArrangementWrite = getTagXML("cus:paymentArrangementWrite", cspPmntId);

            string adrSeq = getTagXML("add:adrSeq", "0");
            string adrEmail = getTagXML("add:adrEmail", email);

            string addressWrite = adrSeq;
            addressWrite = addressWrite + adrEmail;
            addressWrite = getTagXML("cus:addressWrite", addressWrite);

            string item = getTagXML("cus:item", addressWrite);
            string addresses = getTagXML("cus:addresses", item);

            string csIdPub = getTagXML("cus3:csIdPub", externalid);
            string customerWrite = getTagXML("cus:customerWrite", csIdPub);

            inputAttributes = "<cus:customerNew/>" + paymentArrangementWrite + addresses + customerWrite;

            string item2 = getTagXML("ses:key", "BU_ID") + getTagXML("ses:value", "2");
            string values = getTagXML("ses:item", item2);

            sessionChangeRequest = getTagXML("ses:values", values);

            customerCreate = getTagXML("cus:inputAttributes", inputAttributes);
            customerCreate = customerCreate + getTagXML("cus:sessionChangeRequest", sessionChangeRequest);

            xmlrequest = xmlrequest + getTagXML("cus:customerCreateRequest", customerCreate);

            xmlrequest = xmlrequest + getFooterXML();

            return xmlrequest;
        }

        private string getHeaderXML(CrmConfiguration config)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:cus='http://ericsson.com/services/ws_CIL_7/customercreate' xmlns:cus1='http://ericsson.com/services/ws_CIL_7/customernew' xmlns:mon='http://lhsgroup.com/lhsws/money' xmlns:pay='http://ericsson.com/services/ws_CIL_7/paymentarrangementwrite' xmlns:add='http://ericsson.com/services/ws_CIL_7/addresswrite' xmlns:cus2='http://ericsson.com/services/ws_CIL_7/customerinfowrite' xmlns:cus3='http://ericsson.com/services/ws_CIL_7/customerwrite' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>";
            header = header + "<soapenv:Header>";
            header = header + "<Security xmlns='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>";
            header = header + "<UsernameToken>";
            header = header + "<Username>" + config.user + "</Username>";
            header = header + "<Password>" + config.password + "</Password>";
            header = header + "</UsernameToken>";
            header = header + "</Security>";
            header = header + "</soapenv:Header>";
            header = header + "<soapenv:Body>";

            return header;
        }

        private string getFooterXML()
        {
            return "</soapenv:Body></soapenv:Envelope>";
        }

        private string getTagXML(string tagname, string value)
        {
            return "<" + tagname + ">" + value + "</" + tagname + ">";
        }

        private void updateIndividualCustomer(OrganizationServiceProxy service, AmxCoReceiveConfirmationAndSynchronizeClientRequest request, Guid individualcustomerid)
        {
            Entity indCustoEnt = new Entity("contact");

            if (!string.IsNullOrEmpty(request.anniversary))
            {
                indCustoEnt["birthdate"] = DateTime.ParseExact(request.anniversary, "yyyy-MM-dd", null);
            }

            if (request.gendercode == 1 || request.gendercode == 2)
            {
                indCustoEnt["gendercode"] = new OptionSetValue(request.gendercode);
            }

            if (!string.IsNullOrEmpty(request.nickname))
            {
                indCustoEnt["nickname"] = request.nickname;
            }

            indCustoEnt.Id = individualcustomerid;
            service.Update(indCustoEnt);

            if (!string.IsNullOrEmpty(request.email))
            {
                upsertCustomerContactInformation(service, individualcustomerid, request.email, 173800000);
            }
            if (!string.IsNullOrEmpty(request.cellphoneno))
            {
                upsertCustomerContactInformation(service, individualcustomerid, request.cellphoneno, 173800001);
            }
            if (!string.IsNullOrEmpty(request.phoneno))
            {
                upsertCustomerContactInformation(service, individualcustomerid, request.phoneno, 173800002);
            }
            if (!string.IsNullOrEmpty(request.address))
            {
                upsertAddress(service, individualcustomerid, request.address);
            }
        }

        private void upsertCustomerContactInformation(OrganizationServiceProxy service, Guid individualcustomerid, string value, int type)
        {
            try
            {
                QueryExpression query = new QueryExpression("amx_customercontactinformation");
                query.Criteria.AddCondition("amx_individualcustomerid", ConditionOperator.Equal, individualcustomerid);
                query.Criteria.AddCondition("amx_contacttype", ConditionOperator.Equal, type);
                query.Criteria.AddCondition("amx_primarycontacttype", ConditionOperator.Equal, true);

                EntityCollection result = service.RetrieveMultiple(query);

                Entity customerContactInf = new Entity("amx_customercontactinformation");

                if (type != 173800000)
                {
                    customerContactInf["amx_phoneno"] = value;
                }
                else
                {
                    customerContactInf["amx_email"] = value;
                }

                if (result.Entities.Count > 0)
                {
                    customerContactInf.Id = result.Entities.FirstOrDefault().Id;
                    service.Update(customerContactInf);
                }
                else
                {
                    customerContactInf["amx_individualcustomerid"] = new EntityReference("contact", individualcustomerid);
                    customerContactInf["amx_contacttype"] = new OptionSetValue(type);
                    customerContactInf["amx_primarycontacttype"] = true;
                    service.Create(customerContactInf);
                }
            }
            catch (Exception e)
            {
                addResultToList(string.Format("Se prensentó un error al modificar el medio de contacto. Valor enviado: {0}. Excepción: {1}", value, e.Message));
            }
        }

        private void upsertAddress(OrganizationServiceProxy service, Guid individualcustomerid, string value)
        {
            try
            {
                QueryExpression query = new QueryExpression("etel_customeraddress");
                query.Criteria.AddCondition("etel_individualcustomerid", ConditionOperator.Equal, individualcustomerid);
                query.Criteria.AddCondition("etel_isprimaryaddress", ConditionOperator.Equal, true);

                EntityCollection result = service.RetrieveMultiple(query);

                Entity customeraddressEnt = new Entity("etel_customeraddress");
                customeraddressEnt["etel_addressline1"] = value;

                if (result.Entities.Count > 0)
                {
                    customeraddressEnt.Id = result.Entities.FirstOrDefault().Id;
                    service.Update(customeraddressEnt);
                }
                //else
                //{
                //    customeraddressEnt["etel_individualcustomerid"] = new EntityReference("contact", individualcustomerid);
                //    customeraddressEnt["etel_isprimaryaddress"] = true;
                //    service.Create(customeraddressEnt);
                //}
            }
            catch (Exception e)
            {
                addResultToList(string.Format("Se prensentó un error al modificar la dirección primaria. Valor enviado: {0}. Excepción: {1}", value, e.Message));
            }
        }

        private void changeStateBi(OrganizationServiceProxy service, Guid BiLogId, string state)
        {
            try
            {
                Entity BilogEnt = service.Retrieve("etel_bi_log", BiLogId, new ColumnSet("subject"));

                if (BilogEnt != null)
                {
                    string subject;

                    if (BilogEnt.Contains("subject"))
                    {
                        subject = BilogEnt.GetAttributeValue<string>("subject");

                        if (subject.Contains("-"))
                        {
                            subject = subject.Split('-')[0];
                            subject = string.Concat(subject, "- ", state);
                        }
                        else
                        {
                            subject = string.Concat(subject, " - ", state);
                        }
                    }
                    else
                    {
                        subject = state;
                    }

                    Entity BilogUpd = new Entity(BilogEnt.LogicalName);
                    BilogUpd.Id = BilogEnt.Id;
                    BilogUpd["subject"] = subject;

                    service.Update(BilogUpd);
                }
                else
                {
                    addResultToList("No se encontró la BI por el ID: " + BiLogId);
                }

            }
            catch (Exception e)
            {
                addResultToList(string.Format("Se prensentó un error al actualizar el estado de la BI con ID: {0}. Excepción: {1}", BiLogId, e.Message));
            }
        }

        private CrmConfiguration getConfig(OrganizationServiceProxy service)
        {
            Entity config = getParam(service, "ConfigReceiveConfirmationAndSynchronizeClient");

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

        private string callRestWebService(string urlrequest, string objectJson)
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

        private string callSoapWebService(string xml, string url)
        {
            try
            {
                string soapResult = string.Empty;

                XmlDocument soapEnvelopeXml = CreateSoapEnvelope(xml);
                HttpWebRequest webRequest = CreateWebRequest(url);
                byte[] bytes;
                bytes = System.Text.Encoding.ASCII.GetBytes(xml);

                webRequest.ContentLength = bytes.Length;

                Stream requestStream = webRequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();

                IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
                asyncResult.AsyncWaitHandle.WaitOne();

                using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                    }
                }
                return soapResult;
            }
            catch (Exception e)
            {
                addResultToList(string.Format("Error: Se presentó un error al consumir el servicio: {0}.", e.Message));
                return null;
            }
        }

        private HttpWebRequest CreateWebRequest(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private XmlDocument CreateSoapEnvelope(string xml)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(xml);
            return soapEnvelopeDocument;
        }
    }
}
