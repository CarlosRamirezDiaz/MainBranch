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
    public class AmxCoGetContractsByCustomerBusiness
    {
        List<string> _results;

        public AmxCoGetContractsByCustomerResponse AmxCoGetContractsByCustomer(OrganizationServiceProxy service, AmxCoGetContractsByCustomerRequest request)
        {
            _results = new List<string>();
            AmxCoGetContractsByCustomerResponse objresponse = new AmxCoGetContractsByCustomerResponse();

            string xmlRequest = string.Empty;

            CrmConfigurationContract configCrm = getConfig(service);

            if (configCrm != null)
            {
                if (!string.IsNullOrEmpty(configCrm.UrlContracts) && !string.IsNullOrEmpty(configCrm.UrlContractName))
                {
                    Entity contactEnt = service.Retrieve("contact", Guid.Parse(request.customerid), new ColumnSet("etel_externalid"));

                    if (contactEnt != null)
                    {
                        if (contactEnt.Contains("etel_externalid"))
                        {
                            xmlRequest = createXmlRequestContracts(configCrm, contactEnt.GetAttributeValue<string>("etel_externalid"));
                            string strResponse = callSoapWebService(xmlRequest, configCrm.UrlContracts);

                            if (strResponse != null)
                            {
                                objresponse = getContracts(strResponse, configCrm);
                                objresponse.Cyclies = getCycles(configCrm);
                            }
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

            string xmlRequestBSCS = string.Empty;

            return objresponse;
        }

        private AmxCoGetContractsByCustomerResponse getContracts(string xmlRequest, CrmConfigurationContract configcrm)
        {
            AmxCoGetContractsByCustomerResponse response = new AmxCoGetContractsByCustomerResponse();
            response.Contracts = new List<Contract>();

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlRequest);

            var nameRequest = new XmlNamespaceManager(xml.NameTable);
            nameRequest.AddNamespace("SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
            nameRequest.AddNamespace("msbld", "http://ericsson.com/services/ws_CIL_7/contractssearch");

            XmlNodeList result = xml.SelectNodes("//SOAP-ENV:Envelope/SOAP-ENV:Body/msbld:contractsSearchResponse/msbld:contracts/msbld:item/msbld:coIdPub", nameRequest);

            foreach (XmlNode contractcode in result)
            {
                Contract contrac = new Contract();

                string xmlrequestcontractname = createXmlRequestForRatePlansRead(contractcode.InnerText);
                string xmlresponse = callSoapWebService(xmlrequestcontractname, configcrm.UrlContractName);

                XmlDocument xmlDocResponse = new XmlDocument();
                xmlDocResponse.LoadXml(xmlresponse);

                var nameResponse = new XmlNamespaceManager(xmlDocResponse.NameTable);
                nameResponse.AddNamespace("SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
                nameResponse.AddNamespace("msbld", "http://ericsson.com/services/ws_CMI_7/rateplansread");

                XmlNode nodeContactName = xmlDocResponse.SelectSingleNode("/SOAP-ENV:Envelope/SOAP-ENV:Body/msbld:rateplansReadResponse/msbld:numRp/msbld:item[1]/msbld:rpDes", nameResponse);

                contrac.ContractCoId = contractcode.InnerText;
                contrac.ContractName = nodeContactName.InnerText;

                response.Contracts.Add(contrac);
            }

            return response;
        }

        private string createXmlRequestForRatePlansRead(string coIdPub)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml("<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:rat='http://ericsson.com/services/ws_CMI_7/rateplansread' xmlns:ses='http://ericsson.com/services/ws_CMI_7/sessionchange'>   <soapenv:Header>      <cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>         <cwl_fullStack.bscsSecurity:UsernameToken>            <cwl_fullStack.bscsSecurity:Username>ADMX</cwl_fullStack.bscsSecurity:Username>            <cwl_fullStack.bscsSecurity:Password>ADMX</cwl_fullStack.bscsSecurity:Password>         </cwl_fullStack.bscsSecurity:UsernameToken>      </cwl_fullStack.bscsSecurity:Security>   </soapenv:Header>   <soapenv:Body>      <rat:rateplansReadRequest>         <rat:inputAttributes>            <rat:rpcode>32</rat:rpcode>            <rat:rpcodePub></rat:rpcodePub>         </rat:inputAttributes>         <rat:sessionChangeRequest>            <ses:values>               <ses:item>                  <ses:key>BU_ID</ses:key>                  <ses:value>2</ses:value>               </ses:item>            </ses:values>         </rat:sessionChangeRequest>      </rat:rateplansReadRequest>   </soapenv:Body></soapenv:Envelope>");

            var name = new XmlNamespaceManager(xml.NameTable);
            name.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            name.AddNamespace("rat", "http://ericsson.com/services/ws_CMI_7/rateplansread");
            name.AddNamespace("ses", "http://ericsson.com/services/ws_CMI_7/sessionchange");
            name.AddNamespace("cwl_fullStack.bscsSecurity", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            name.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            var node = xml.DocumentElement.SelectSingleNode("/soapenv:Envelope/soapenv:Body/rat:rateplansReadRequest/rat:inputAttributes/rat:rpcodePub", name);

            if (node != null)
            {
                node.InnerText = coIdPub;
                return xml.InnerXml;
            }

            return null;
        }

        private List<Cycle> getCycles(CrmConfigurationContract configcrm)
        {
            List<Cycle> cycles = new List<Cycle>();

            XmlDocument xmlRequest = new XmlDocument();
            xmlRequest.LoadXml("<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:bil='http://ericsson.com/services/ws_CMI_7/billcyclesread' xmlns:ses='http://ericsson.com/services/ws_CMI_7/sessionchange'>   <soapenv:Header>      <cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>         <cwl_fullStack.bscsSecurity:UsernameToken>            <cwl_fullStack.bscsSecurity:Username>ADMX</cwl_fullStack.bscsSecurity:Username>            <cwl_fullStack.bscsSecurity:Password>ADMX</cwl_fullStack.bscsSecurity:Password>         </cwl_fullStack.bscsSecurity:UsernameToken>      </cwl_fullStack.bscsSecurity:Security>   </soapenv:Header>   <soapenv:Body>      <bil:billCyclesReadRequest>         <bil:inputAttributes>            <bil:partyType>C</bil:partyType>            <bil:readAll>false</bil:readAll>         </bil:inputAttributes>         <bil:sessionChangeRequest>            <ses:values>               <ses:item>                  <!--You may enter the following 2 items in any order-->                  <ses:key>BU_ID</ses:key>                  <ses:value>2</ses:value>               </ses:item>            </ses:values>         </bil:sessionChangeRequest>      </bil:billCyclesReadRequest>   </soapenv:Body></soapenv:Envelope>");

            var nameRequest = new XmlNamespaceManager(xmlRequest.NameTable);
            nameRequest.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            nameRequest.AddNamespace("bil", "http://ericsson.com/services/ws_CMI_7/billcyclesread");
            nameRequest.AddNamespace("ses", "http://ericsson.com/services/ws_CMI_7/sessionchange");
            nameRequest.AddNamespace("cwl_fullStack.bscsSecurity", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            nameRequest.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");


            var userNode = xmlRequest.DocumentElement.SelectSingleNode("/soapenv:Envelope/soapenv:Header/cwl_fullStack.bscsSecurity:Security/cwl_fullStack.bscsSecurity:UsernameToken/cwl_fullStack.bscsSecurity:Username", nameRequest);
            userNode.InnerText = configcrm.UrlCycleUser;

            var passwordNode = xmlRequest.DocumentElement.SelectSingleNode("/soapenv:Envelope/soapenv:Header/cwl_fullStack.bscsSecurity:Security/cwl_fullStack.bscsSecurity:UsernameToken/cwl_fullStack.bscsSecurity:Password", nameRequest);
            passwordNode.InnerText = configcrm.UrlCyclePassword;

            string response = callSoapWebService(xmlRequest.InnerXml, configcrm.UrlCycle);

            XmlDocument xmlReponse = new XmlDocument();
            xmlReponse.LoadXml("<SOAP-ENV:Envelope xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/'>   <SOAP-ENV:Header/>   <SOAP-ENV:Body>      <billCyclesReadResponse xmlns='http://ericsson.com/services/ws_CMI_7/billcyclesread'>         <billCycles>            <item>               <billcycle>01</billcycle>               <description>Billcycle #1</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2018-02-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2018-03-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>20</billcycle>               <description>Billcycle #20</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-16T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-02-20T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>28</billcycle>               <description>Billcycle #28</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>98</billcycle>               <description>BC</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>97</billcycle>               <description>BM</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>99</billcycle>               <description>Billcycle #99</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>12</billcycle>               <description>Billcycle #12</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>96</billcycle>               <description>TB</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>16</billcycle>               <description>Billcycle #16</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-05-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-06-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>06</billcycle>               <description>Billcycle #06</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>24</billcycle>               <description>Billcycle #24</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>09</billcycle>               <description>Billcycle #09</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>10</billcycle>               <description>Billcycle #10</description>               <intervalType>M</intervalType>               <length>1</length>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>03</billcycle>               <description>Billcycle #03</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>14</billcycle>               <description>Billcycle #14</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>26</billcycle>               <description>Billcycle #26</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>05</billcycle>               <description>Billcycle #05</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-02-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>08</billcycle>               <description>Billcycle #08</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>11</billcycle>               <description>Billcycle #11</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>18</billcycle>               <description>Billcycle #18</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>22</billcycle>               <description>Billcycle #22</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>93</billcycle>               <description>Billcycle #93</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>            <item>               <billcycle>95</billcycle>               <description>Billcycle #95</description>               <intervalType>M</intervalType>               <length>1</length>               <lastRunDate>2016-01-01T00:00:00-05:00</lastRunDate>               <bchRunDate>2016-01-01T00:00:00-05:00</bchRunDate>               <businessUnitId>1</businessUnitId>               <approvedInd>true</approvedInd>               <validDate>2016-01-01</validDate>            </item>         </billCycles>      </billCyclesReadResponse>   </SOAP-ENV:Body></SOAP-ENV:Envelope>");

            var nameResponse = new XmlNamespaceManager(xmlRequest.NameTable);
            nameResponse.AddNamespace("SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
            nameResponse.AddNamespace("msbld", "http://ericsson.com/services/ws_CMI_7/billcyclesread");

            XmlNodeList result = xmlReponse.SelectNodes("/SOAP-ENV:Envelope/SOAP-ENV:Body/msbld:billCyclesReadResponse/msbld:billCycles/msbld:item", nameResponse);

            foreach (XmlNode node in result)
            {
                Cycle cycle = new Cycle();
                cycle.Billcycle = node.SelectSingleNode("msbld:billcycle", nameResponse) != null ? node.SelectSingleNode("msbld:billcycle", nameResponse).InnerText : string.Empty;
                cycle.Description = node.SelectSingleNode("msbld:description", nameResponse) != null ? node.SelectSingleNode("msbld:description", nameResponse).InnerText : string.Empty;
                cycle.LastRunDate = node.SelectSingleNode("msbld:lastRunDate", nameResponse) != null ? node.SelectSingleNode("msbld:lastRunDate", nameResponse).InnerText : string.Empty;
                cycle.BchRunDate = node.SelectSingleNode("msbld:bchRunDate", nameResponse) != null ? node.SelectSingleNode("msbld:bchRunDate", nameResponse).InnerText : string.Empty;

                cycles.Add(cycle);
            }

            return cycles;
        }

        private CrmConfigurationContract getConfig(OrganizationServiceProxy service)
        {
            Entity config = getParam(service, "ConfigContractsByCustomerBusiness");

            if (config != null)
            {
                if (config.Contains("etel_value"))
                {
                    CrmConfigurationContract configurationCrm = (CrmConfigurationContract)convertJsonToObjeto(typeof(CrmConfigurationContract), config.GetAttributeValue<string>("etel_value"));
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

        private void addResultToList(string detail)
        {
            _results.Add(detail);
        }

        private string createXmlRequestContracts(CrmConfigurationContract configcrm, string externalid)
        {
            string xmlrequest = string.Empty;

            xmlrequest = getHeaderXML(configcrm);

            string searcher = getTagXML("con:searcher", "SimpleContractSearch");
            string csIdPub = getTagXML("con:csIdPub", externalid);
            //string csIdPub = getTagXML("con:csIdPub", "CUST0000000038");

            string inputAttributes = getTagXML("con:inputAttributes", searcher + csIdPub);

            xmlrequest = xmlrequest + inputAttributes;

            xmlrequest = xmlrequest + getFooterXML();

            return xmlrequest;
        }

        private string getHeaderXML(CrmConfigurationContract config)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:con='http://ericsson.com/services/ws_CIL_7/contractssearch' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>";
            header = header + "<soapenv:Header>";
            header = header + "<cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>";
            header = header + "<cwl_fullStack.bscsSecurity:UsernameToken>";
            header = header + "<cwl_fullStack.bscsSecurity:Username>" + config.UrlContractsUser + "</cwl_fullStack.bscsSecurity:Username>";
            header = header + "<cwl_fullStack.bscsSecurity:Password>" + config.UrlContractsPassword + "</cwl_fullStack.bscsSecurity:Password>";
            header = header + "</cwl_fullStack.bscsSecurity:UsernameToken>";
            header = header + "</cwl_fullStack.bscsSecurity:Security>";
            header = header + "</soapenv:Header>";
            header = header + "<soapenv:Body>";
            header = header + "<con:contractsSearchRequest>";

            return header;
        }

        private string getFooterXML()
        {
            string footer = string.Empty;

            footer = footer + "<con:sessionChangeRequest>";
            footer = footer + "<ses:values>";
            footer = footer + "<ses:item>";
            footer = footer + "<ses:key>BU_ID</ses:key>";
            footer = footer + "<ses:value>2</ses:value>";
            footer = footer + "</ses:item>";
            footer = footer + "</ses:values>";
            footer = footer + "</con:sessionChangeRequest>";
            footer = footer + "</con:contractsSearchRequest>";
            footer = footer + "</soapenv:Body>";
            footer = footer + "</soapenv:Envelope>";

            return footer;
        }
        private string getTagXML(string tagname, string value)
        {
            return "<" + tagname + ">" + value + "</" + tagname + ">";
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

    [DataContract]
    class CrmConfigurationContract
    {
        [DataMember]
        public string UrlContracts { get; set; }
        [DataMember]
        public string UrlContractsUser { get; set; }
        [DataMember]
        public string UrlContractsPassword { get; set; }
        [DataMember]
        public string UrlContractName { get; set; }
        [DataMember]
        public string UrlContractNameUser { get; set; }
        [DataMember]
        public string UrlContractNamePassword { get; set; }
        [DataMember]
        public string UrlCycle { get; set; }
        [DataMember]
        public string UrlCycleUser { get; set; }
        [DataMember]
        public string UrlCyclePassword { get; set; }
    }
}
