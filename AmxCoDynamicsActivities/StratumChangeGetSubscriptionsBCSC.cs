﻿using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Net.WebRequestMethods;

namespace AmxDynamicsActivities
{
    public class StratumChangeGetSubscriptionsBCSC : CodeActivity
    {
        [Input("Individual customer")]
        [ReferenceTarget("contact")]
        [RequiredArgument]
        public InArgument<EntityReference> InIndividual { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InIndividual.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erIndividual)
        {
            Entity eIndividual = service.Retrieve(erIndividual.LogicalName, erIndividual.Id, new ColumnSet("etel_externalid"));

            if (eIndividual != null)
            {                
                string urlRequest = string.Empty;
                string xmlRequest = string.Empty;
                string userRequest = string.Empty;
                string passwordRequest = string.Empty;

                QueryExpression queryParameters = new QueryExpression("amxperu_amxconfigurations");
                queryParameters.ColumnSet = new ColumnSet("amxperu_value", "amxperu_name");
                queryParameters.Criteria.FilterOperator = LogicalOperator.Or;
                queryParameters.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "UrlGetSubscriptionsBCSC");                
                queryParameters.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "UserGetSubscriptionsBCSC");
                queryParameters.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "PasswordGetSubscriptionsBCSC");

                EntityCollection ecParameters = service.RetrieveMultiple(queryParameters);

                foreach (Entity eParam in ecParameters.Entities)
                {
                    string nameParam = string.Empty;
                    if (eParam.Contains("amxperu_name"))
                        nameParam = eParam["amxperu_name"].ToString();

                    if (nameParam.Equals("UrlGetSubscriptionsBCSC")) { urlRequest = eParam["amxperu_value"].ToString(); }                    
                    else if (nameParam.Equals("UserGetSubscriptionsBCSC")) { userRequest = eParam["amxperu_value"].ToString(); }
                    else if (nameParam.Equals("PasswordGetSubscriptionsBCSC")) { passwordRequest = eParam["amxperu_value"].ToString(); }
                }

                if (eIndividual.Contains("etel_externalid"))
                {
                    xmlRequest = getHeaderXML(userRequest, passwordRequest) + eIndividual["etel_externalid"].ToString() + getFooterXML();

                    try
                    {
                        string response = callWebService(xmlRequest, urlRequest);
                        string messageResponse = getInfoBetweenTags(response, "<contracts xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</contracts>");

                        string[] arrSeparator = { "</item>" };
                        string[] arrItems = messageResponse.Split(arrSeparator, StringSplitOptions.None);

                        foreach (string item in arrItems)
                        {
                            if (item.Contains("<dirnum xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">"))
                            {
                                bool isUpdate = false;

                                string contractTypeId = getInfoBetweenTags(item, "<contractTypeId xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</contractTypeId>");
                                string buId = getInfoBetweenTags(item, "<buId xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</buId>");
                                string coStatus = getInfoBetweenTags(item, "<coStatus xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</coStatus>");
                                string dirnum = getInfoBetweenTags(item, "<dirnum xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</dirnum>");
                                string plcode = getInfoBetweenTags(item, "<plcode xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</plcode>");
                                string rpcode = getInfoBetweenTags(item, "<rpcode xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</rpcode>");
                                string coActivated = getInfoBetweenTags(item, "<coActivated xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</coActivated>");
                                string coId = getInfoBetweenTags(item, "<coId xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</coId>");
                                string coIdPub = getInfoBetweenTags(item, "<coIdPub xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</coIdPub>");
                                string currentDn = getInfoBetweenTags(item, "<currentDn xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</currentDn>");
                                string dnPending = getInfoBetweenTags(item, "<dnPending xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</dnPending>");
                                string paymentMethodInd = getInfoBetweenTags(item, "<paymentMethodInd xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</paymentMethodInd>");

                            }
                        }
                    }
                    catch (Exception ex) { string message = ex.Message; }
                }

            }
        }

        private string getHeaderXML(string user, string password)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:con='http://ericsson.com/services/ws_CIL_7/contractssearch' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'><soapenv:Header><cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>";
            header = header + "<cwl_fullStack.bscsSecurity:UsernameToken><cwl_fullStack.bscsSecurity:Username>" + user + "</cwl_fullStack.bscsSecurity:Username><cwl_fullStack.bscsSecurity:Password>" + password + "</cwl_fullStack.bscsSecurity:Password></cwl_fullStack.bscsSecurity:UsernameToken></cwl_fullStack.bscsSecurity:Security></soapenv:Header><soapenv:Body><con:contractsSearchRequest><con:inputAttributes><con:searcher>SimpleContractSearch</con:searcher><con:csIdPub>";

            return header;
        }

        private string getFooterXML()
        {
            return "</con:csIdPub></con:inputAttributes><con:sessionChangeRequest><ses:values><ses:item><ses:key>BU_ID</ses:key><ses:value>2</ses:value></ses:item></ses:values></con:sessionChangeRequest></con:contractsSearchRequest></soapenv:Body></soapenv:Envelope>";
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
