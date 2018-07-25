using AmxPeruPSBActivities.Model.StratumChange;
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
    public class AmxCoSendBase64FileToDocumentaryManagerBusiness
    {
        List<string> _results;

        public AmxCoSendBase64FileToDocumentaryManagerResponse SendBase64FileToDocumentaryManagerBusiness(OrganizationServiceProxy service, AmxCoSendBase64FileToDocumentaryManagerRequest request)
        {
            //string objetJson = convertObjetoToJson(request);

            _results = new List<string>();

            AmxCoSendBase64FileToDocumentaryManagerResponse SendBase64FileToDocumentaryManagerResponse = new AmxCoSendBase64FileToDocumentaryManagerResponse();

            CrmConfiguration configCrm = getConfig(service);
            string xmlRequest = string.Empty;

            if (configCrm != null)
            {
                Entity individual = service.Retrieve("contact", Guid.Parse(request.individualid), new ColumnSet("amxperu_documenttype", "etel_iddocumentnumber", "etel_externalid"));

                if (individual != null)
                {
                    xmlRequest = getHeaderXML(configCrm);

                    if (individual.Contains("amxperu_documenttype"))
                    {
                        string document = string.Empty;

                        string documentType = string.Empty;

                        if (individual.Contains("amxperu_documenttype"))
                        {
                            documentType = validateDocumentType(individual.GetAttributeValue<OptionSetValue>("amxperu_documenttype").Value);

                            if (!string.IsNullOrEmpty(documentType))
                            {
                                if (individual.Contains("etel_externalid"))
                                {
                                    string attributeName = (getTagXML("attributeName", "xdTipoIdentificacion") + getTagXML("attributeValue", documentType));
                                    document = document + getTagXML("v1:field", attributeName);

                                    attributeName = getTagXML("attributeName", "xdNumeroIdentificacion") + getTagXML("attributeValue", individual.Contains("etel_iddocumentnumber") ? individual.GetAttributeValue<string>("etel_iddocumentnumber") : string.Empty);
                                    document = document + getTagXML("v1:field", attributeName);

                                    attributeName = getTagXML("attributeName", "xdTipoDocumental") + getTagXML("attributeValue", "PRUEBA_ENTREGA");
                                    document = document + getTagXML("v1:field", attributeName);

                                    attributeName = getTagXML("attributeName", "xdEmpresa") + getTagXML("attributeValue", "COMCEL");
                                    document = document + getTagXML("v1:field", attributeName);

                                    attributeName = getTagXML("attributeName", "xdCustomerCode") + getTagXML("attributeValue", individual.GetAttributeValue<string>("etel_externalid"));
                                    document = document + getTagXML("v1:field", attributeName);

                                    attributeName = getTagXML("attributeName", "xdMIN") + getTagXML("attributeValue", "3131001000");
                                    document = document + getTagXML("v1:field", attributeName);

                                    xmlRequest = xmlRequest + getTagXML("v1:document", document);

                                    string file = getTagXML("v1:name", request.filename) + getTagXML("v1:content", request.base64file);
                                    xmlRequest = xmlRequest + getTagXML("v1:file", file);
                                }
                                else
                                {
                                    addResultToList("El documento externo del cliente individual es requerido.");
                                }
                            }
                            else
                            {
                                addResultToList("El tipo de documento del cliente individual no es valido.");
                            }
                        }
                        else
                        {
                            addResultToList("El tipo de documento del cliente individual es requerido.");
                        }

                        xmlRequest = xmlRequest + getFooterXML();


                        if (!string.IsNullOrEmpty(configCrm.url))
                        {
                            string ulr = configCrm.url;
                            string response = callWebService(xmlRequest, ulr);
                        }
                        else
                        {
                            addResultToList("No se encontró la URL en el parametro: ConfigSendBase64FileToDocumentaryManagerBusiness.");
                        }
                    }
                    else
                    {
                        addResultToList("El tipo de identificación del contacto es requerido.");
                    }
                }
                else
                {
                    addResultToList("No se pudo encontrar el contacto relacionado.");
                }
            }

            if (_results.Count > 0)
            {
                SendBase64FileToDocumentaryManagerResponse.ErrorDetail = _results;
                SendBase64FileToDocumentaryManagerResponse.error = true;
            }
            else
            {
                SendBase64FileToDocumentaryManagerResponse.ErrorDetail = null;
                SendBase64FileToDocumentaryManagerResponse.error = false;
            }

            return SendBase64FileToDocumentaryManagerResponse;
        }

        private CrmConfiguration getConfig(OrganizationServiceProxy service)
        {
            Entity config = getParam(service, "ConfigSendBase64FileToDocumentaryManagerBusiness");

            if (config != null)
            {
                if (config.Contains("etel_value"))
                {
                    CrmConfiguration configurationCrm = (CrmConfiguration)convertJsonToObjeto(typeof(CrmConfiguration), config.GetAttributeValue<string>("etel_value"));
                    return configurationCrm;
                }
                else
                {
                    addResultToList("Error: El JSON almacenado en el parametro: Address_MGL_HeaderRequest, esta vacío.");
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
                addResultToList(string.Format("Error: No se encontró el parámetro: {0}.", paramname));
            }
            return null;
        }

        private string validateDocumentType(int valueDocType)
        {
            string documentType = null;

            switch (valueDocType)
            {
                case 1:
                    documentType = "CC";
                    break;

                case 2:
                    documentType = "NIT";
                    break;

                case 3:
                    documentType = "CE";
                    break;

                case 5:
                    documentType = "PP";
                    break;

                case 7:
                    documentType = "TI";
                    break;

                default:
                    documentType = null;
                    break;
            }

            return documentType;
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

        private string getHeaderXML(CrmConfiguration config)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:v1='http://www.amx.com/Schema/Operation/UploadAgreementDocument/V1.0' xmlns:v11='http://www.amx.com/CO/Schema/ClaroHeaders/v1'>";
            header = header + "<soapenv:Header/>";
            header = header + "<soapenv:Body>";
            header = header + "<v1:uploadAgreementDocumentRequest>";
            header = header + "<v1:headerRequest>";
            header = header + "<v11:transactionId>?</v11:transactionId>";
            header = header + "<v11:system>" + config.system + "</v11:system>";
            header = header + "<v11:user>" + config.user + "</v11:user>";
            header = header + "<v11:password>" + config.password + "</v11:password>";
            header = header + "<v11:requestDate>" + config.requestDate + "</v11:requestDate>";
            header = header + "<v11:ipApplication>" + config.ipApplication + "</v11:ipApplication>";
            header = header + "<v11:traceabilityId>" + config.traceabilityId + "</v11:traceabilityId>";
            header = header + "</v1:headerRequest>";

            return header;
        }

        private string getFooterXML()
        {
            return "</v1:uploadAgreementDocumentRequest></soapenv:Body></soapenv:Envelope>";
        }

        private string getTagXML(string tagname, string value)
        {
            return "<" + tagname + ">" + value + "</" + tagname + ">";
        }

        private string callWebService(string xml, string url)
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

        private string getInfoBetweenTags(string response, string tag1, string tag2)
        {
            string info = string.Empty;
            string[] arrSeparator = { tag1, tag2 };
            string[] arrResponse = response.Split(arrSeparator, StringSplitOptions.None);

            if (arrResponse.Length > 1)
                info = arrResponse[1];

            return info;
        }

        private void addResultToList(string detail)
        {
            _results.Add(detail);
        }
    }

    [DataContract]
    public class CrmConfiguration
    {
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string system { get; set; }
        [DataMember]
        public string user { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string requestDate { get; set; }
        [DataMember]
        public string ipApplication { get; set; }
        [DataMember]
        public string traceabilityId { get; set; }
    }


}
