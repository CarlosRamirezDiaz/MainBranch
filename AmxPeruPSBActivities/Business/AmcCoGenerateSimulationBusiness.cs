using AmxPeruPSBActivities.Model.InternalExternalAccount;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AmxPeruPSBActivities.Business
{
    public class AmcCoGenerateSimulationBusiness
    {
        public AmcCoGenerateSimulationResponse SimularionBilling(AmcCoGenerateSimulationRequest objRequest, OrganizationServiceProxy service)
        {
            AmcCoGenerateSimulationResponse objResponse = new AmcCoGenerateSimulationResponse();
            string infoSimulation = string.Empty;

            try
            {
                string urlProcessCreateRequest = string.Empty;
                string urlProcessReadRequest = string.Empty;
                string xmlRequest = string.Empty;
                string userRequest = string.Empty;
                string passwordRequest = string.Empty;
                
                QueryExpression queryParameters = new QueryExpression("etel_crmconfiguration");
                queryParameters.ColumnSet = new ColumnSet("etel_value", "etel_name");
                queryParameters.Criteria.FilterOperator = LogicalOperator.Or;
                queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bil_ProcessCreate_Url");
                queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bil_ProcessRead_Url");
                queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "BIL_IntegrationsBSCS_UsrPsw");

                EntityCollection ecParameters = service.RetrieveMultiple(queryParameters);

                foreach (Entity eParam in ecParameters.Entities)
                {
                    string nameParam = string.Empty;
                    if (eParam.Contains("etel_name"))
                        nameParam = eParam["etel_name"].ToString();

                    if (nameParam.Equals("Bil_ProcessCreate_Url")) { urlProcessCreateRequest = eParam["etel_value"].ToString(); }
                    else if(nameParam.Equals("Bil_ProcessRead_Url")) { urlProcessReadRequest = eParam["etel_value"].ToString(); }
                    else if (nameParam.Equals("BIL_IntegrationsBSCS_UsrPsw")) { userRequest = eParam["etel_value"].ToString(); passwordRequest = eParam["etel_value"].ToString(); }
                }

                Entity eCustomer = service.Retrieve("contact", Guid.Parse(objRequest.CustomerId), new ColumnSet("etel_externalid"));
                Entity eItemCT = service.Retrieve("amx_itemcontract", Guid.Parse(objRequest.ContractId), new ColumnSet("amx_code"));

                if (eCustomer.Contains("etel_externalid") && eItemCT.Contains("amx_code"))
                {
                    string customerCus = eCustomer["etel_externalid"].ToString();
                    string xmlAssigmentWrite = getCreateProcessXML(userRequest, passwordRequest, customerCus, eItemCT["amx_code"].ToString());
                    try
                    {
                        string processCreate = callWebService(xmlAssigmentWrite, urlProcessCreateRequest);

                        string idProcess = getInfoBetweenTags(processCreate, "<billingRequestNumber xmlns=\"http://ericsson.com/services/ws_CIL_7/billprocesscreate\">", "</billingRequestNumber>");

                        string xmlProcessSearch = getSearchProcessXML(userRequest, passwordRequest, customerCus, idProcess);

                        string processSearch = callWebService(xmlProcessSearch, urlProcessReadRequest);

                        if (!string.IsNullOrEmpty(processSearch))
                        {
                            infoSimulation = getInfoBetweenTags(processSearch, "<statusShortDescr xmlns=\"http://ericsson.com/services/ws_CIL_7/billprocesssearch\">", "</statusShortDescr>");
                        }
                    }
                    catch (Exception execp)
                    {
                        objResponse.IsError = true;
                        objResponse.MsgError = execp.Message;
                    }
                }

            }
            catch (Exception ex)
            {
                objResponse.IsError = true;
                objResponse.MsgError = ex.Message;
            }

            objResponse.IsError = false;
            objResponse.MsgError = "success";
            objResponse.infoSimulation = infoSimulation;

            return objResponse;
        }

        private string getCreateProcessXML(string user, string password, string customerId, string ContractId)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:bil='http://ericsson.com/services/ws_CIL_7/billprocesscreate' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'><soapenv:Header><Security xmlns='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>";
            header = header + "<UsernameToken><Username>" + user + "</Username><Password>" + password + "</Password> </UsernameToken></Security></soapenv:Header><soapenv:Body><bil:billprocessCreateRequest><bil:inputAttributes><bil:requestType>B</bil:requestType><bil:requestSubType>I</bil:requestSubType><bil:customerKeyCollection><bil:item><bil:csId></bil:csId>";
            header = header + "<bil:csIdPub>" + customerId + "</bil:csIdPub></bil:item></bil:customerKeyCollection><bil:contractKeyCollection><bil:item><bil:coId></bil:coId><bil:coIdPub>" + ContractId + "</bil:coIdPub>   </bil:item></bil:contractKeyCollection><bil:contractTypeId></bil:contractTypeId><bil:billCycle></bil:billCycle>";
            header = header + "<bil:periodStartDate></bil:periodStartDate><bil:periodEndDate></bil:periodEndDate><bil:information>False</bil:information><bil:simulation>True</bil:simulation><bil:referenceDate></bil:referenceDate><bil:postingPeriod></bil:postingPeriod><bil:acknowledgement>False</bil:acknowledgement><bil:collectInd></bil:collectInd><bil:ignoreBuInd>";
            header = header + "</bil:ignoreBuInd><bil:allBusinessUnits></bil:allBusinessUnits><bil:disableInvoiceForwarding></bil:disableInvoiceForwarding><bil:billcycleRestrictionInd></bil:billcycleRestrictionInd><bil:twoPhaseBilling></bil:twoPhaseBilling></bil:inputAttributes><bil:sessionChangeRequest><ses:values><ses:item><ses:key>BU_ID</ses:key>";
            header = header + "<ses:value>2</ses:value></ses:item></ses:values></bil:sessionChangeRequest></bil:billprocessCreateRequest></soapenv:Body></soapenv:Envelope>";


            return header;
        }

        private string getSearchProcessXML(string user, string password, string customerId, string processNumber)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:bil='http://ericsson.com/services/ws_CIL_7/billprocesssearch' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>";
            header = header + "<soapenv:Header><Security xmlns='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'><UsernameToken><Username>"+ user + "</Username><Password>"+ password + "</Password> </UsernameToken></Security></soapenv:Header>";
            header = header + "<soapenv:Body><bil:billprocessSearchRequest><bil:inputAttributes><bil:billingRequestNumber>"+ processNumber + "</bil:billingRequestNumber><bil:requestType>B</bil:requestType><bil:requestSubType></bil:requestSubType><bil:csCode></bil:csCode><bil:csId></bil:csId>";
            header = header + "<bil:csIdPub>"+ customerId + "</bil:csIdPub><bil:coId></bil:coId><bil:coIdPub></bil:coIdPub><bil:contractTypeId></bil:contractTypeId><bil:billCycle></bil:billCycle><bil:size></bil:size><bil:fromDate></bil:fromDate><bil:toDate></bil:toDate><bil:partyType></bil:partyType>";
            header = header + "</bil:inputAttributes><bil:sessionChangeRequest><ses:values><ses:item><ses:key>BU_ID</ses:key><ses:value>2</ses:value></ses:item></ses:values></bil:sessionChangeRequest></bil:billprocessSearchRequest></soapenv:Body></soapenv:Envelope>";
            
            return header;
        }

        private string getTagXML(string tagname, string value)
        {
            return "<" + tagname + ">" + value + "</" + tagname + ">";
        }

        private string callWebService(string xml, string url)
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

        private void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
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
    }
}
