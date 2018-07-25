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
    public class AmxCoBAAssignmentBusiness
    {
        public AmxCoBillingAccountAssignmentResponse AssignmentContractInBA(AmxCoBillingAccountAssignmentRequest objRequest, OrganizationServiceProxy service)
        {
            AmxCoBillingAccountAssignmentResponse objResponse = new AmxCoBillingAccountAssignmentResponse();

            try
            {
                string urlAssignmentWriteRequest = string.Empty;
                string xmlRequest = string.Empty;
                string userRequest = string.Empty;
                string passwordRequest = string.Empty;

                QueryExpression queryParameters = new QueryExpression("etel_crmconfiguration");
                queryParameters.ColumnSet = new ColumnSet("etel_value", "etel_name");
                queryParameters.Criteria.FilterOperator = LogicalOperator.Or;
                queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bill_AssigmentWriteBA_URL");
                queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "BIL_IntegrationsBSCS_UsrPsw");

                EntityCollection ecParameters = service.RetrieveMultiple(queryParameters);

                foreach (Entity eParam in ecParameters.Entities)
                {
                    string nameParam = string.Empty;
                    if (eParam.Contains("etel_name"))
                        nameParam = eParam["etel_name"].ToString();

                    if (nameParam.Equals("Bill_AssigmentWriteBA_URL")) { urlAssignmentWriteRequest = eParam["etel_value"].ToString(); }
                    else if (nameParam.Equals("BIL_IntegrationsBSCS_UsrPsw")) { userRequest = eParam["etel_value"].ToString(); passwordRequest = eParam["etel_value"].ToString(); }
                }

                Entity eItemBA = service.Retrieve("amx_itembillingaccount", Guid.Parse(objRequest.BillingAccountId), new ColumnSet("amx_billingaccountcode"));
                Entity eItemCT = service.Retrieve("amx_itemcontract", Guid.Parse(objRequest.ContractId), new ColumnSet("amx_code"));

                if (eItemBA.Contains("amx_billingaccountcode") && eItemCT.Contains("amx_code"))
                {
                    string xmlAssigmentWrite = getAssigmentWriteXML(userRequest, passwordRequest, eItemBA["amx_billingaccountcode"].ToString(), eItemCT["amx_code"].ToString());
                    try
                    {
                        string assigmentWrite = callWebService(xmlAssigmentWrite, urlAssignmentWriteRequest);

                        objResponse.IsError = false;
                        objResponse.MsgError = "success";
                    }
                    catch (Exception execp)
                    {
                        if (execp.Message.Contains("already"))
                        {
                            objResponse.IsError = false;
                            objResponse.MsgError = "success";
                        }
                        else
                        {
                            objResponse.IsError = true;
                            objResponse.MsgError = execp.Message;
                        }
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

            return objResponse;
        }

        private string getAssigmentWriteXML(string user, string password, string baCode, string ctCode)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:bil='http://ericsson.com/services/ws_CIL_7/billingaccountassignmentwrite' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>";
            header = header + "<soapenv:Header><cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'> <cwl_fullStack.bscsSecurity:UsernameToken>";
            header = header + "<cwl_fullStack.bscsSecurity:Username>" + user + "</cwl_fullStack.bscsSecurity:Username><cwl_fullStack.bscsSecurity:Password>" + password + "</cwl_fullStack.bscsSecurity:Password></cwl_fullStack.bscsSecurity:UsernameToken></cwl_fullStack.bscsSecurity:Security></soapenv:Header>";
            header = header + "<soapenv:Body>  <bil:billingAccountAssignmentWriteRequest> <bil:inputAttributes><bil:billingAccountAssignmentWriteInputDTO><bil:billingAccountId></bil:billingAccountId><bil:billingAccountIdPub>" + baCode + "</bil:billingAccountIdPub><bil:validToDate>";
            header = header + "</bil:validToDate><bil:contractId></bil:contractId><bil:contractIdPub>" + ctCode + "</bil:contractIdPub><bil:delete></bil:delete><bil:seqNo></bil:seqNo><bil:priority></bil:priority><bil:billingAccountAssignmentTemplateId>1</bil:billingAccountAssignmentTemplateId>";
            header = header + "</bil:billingAccountAssignmentWriteInputDTO></bil:inputAttributes><bil:sessionChangeRequest><ses:values><ses:item>  <ses:key>BU_ID</ses:key><ses:value>2</ses:value></ses:item></ses:values> </bil:sessionChangeRequest>  </bil:billingAccountAssignmentWriteRequest></soapenv:Body></soapenv:Envelope>";

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
