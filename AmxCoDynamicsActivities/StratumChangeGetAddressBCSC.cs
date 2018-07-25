using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.IO;
using System.Net;
using System.Xml;

namespace AmxDynamicsActivities
{
    public class StratumChangeGetAddressBCSC : CodeActivity
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
                queryParameters.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "UrlGetAddressBSCS");                
                queryParameters.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "UserGetAddressBSCS");
                queryParameters.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "PasswordGetAddressBSCS");

                EntityCollection ecParameters = service.RetrieveMultiple(queryParameters);

                foreach (Entity eParam in ecParameters.Entities)
                {
                    string nameParam = string.Empty;
                    if (eParam.Contains("amxperu_name"))
                        nameParam = eParam["amxperu_name"].ToString();

                    if (nameParam.Equals("UrlGetAddressBSCS")) { urlRequest = eParam["amxperu_value"].ToString(); }                    
                    else if (nameParam.Equals("UserGetAddressBSCS")) { userRequest = eParam["amxperu_value"].ToString(); }
                    else if (nameParam.Equals("PasswordGetAddressBSCS")) { passwordRequest = eParam["amxperu_value"].ToString(); }
                }

                if (eIndividual.Contains("etel_externalid"))
                {
                    xmlRequest = getHeaderXML(userRequest, passwordRequest) + eIndividual["etel_externalid"].ToString() + getFooterXML();

                    try
                    {
                        string response = callWebService(xmlRequest, urlRequest);
                        string messageResponse = getInfoBetweenTags(response, "<listOfAllAddresses xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</listOfAllAddresses>");

                        string[] arrSeparator = { "</item>" };
                        string[] arrItems = messageResponse.Split(arrSeparator, StringSplitOptions.None);

                        foreach (string item in arrItems)
                        {
                            if (item.Contains("<adrRoles xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">"))
                            {
                                bool isUpdate = false;

                                string nameCity = string.Empty;
                                string adrSeq = getInfoBetweenTags(item, "<adrSeq xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrSeq>");
                                string adrRoles = getInfoBetweenTags(item, "<adrRoles xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrRoles>");
                                string adrTempbillOverridden = getInfoBetweenTags(item, "<adrTempbillOverridden xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrTempbillOverridden>");
                                string ttlId = getInfoBetweenTags(item, "<ttlId xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</ttlId>");
                                string ttlIdPub = getInfoBetweenTags(item, "<ttlIdPub xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</ttlIdPub>");
                                string adrLname = getInfoBetweenTags(item, "<adrLname xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrLname>");
                                string adrStreet = getInfoBetweenTags(item, "<adrStreet xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrStreet>");
                                string adrStreetno = getInfoBetweenTags(item, "<adrStreetno xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrStreetno>");
                                string adrZip = getInfoBetweenTags(item, "<adrZip xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrZip>");
                                string adrCity = getInfoBetweenTags(item, "<adrCity xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrCity>");
                                string countryId = getInfoBetweenTags(item, "<countryId xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</countryId>");
                                string countryIdPub = getInfoBetweenTags(item, "<countryIdPub xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</countryIdPub>");
                                string lngCode = getInfoBetweenTags(item, "<lngCode xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</lngCode>");
                                string lngCodePub = getInfoBetweenTags(item, "<lngCodePub xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</lngCodePub>");
                                string adrUrgent = getInfoBetweenTags(item, "<adrUrgent xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrUrgent>");
                                string adrForward = getInfoBetweenTags(item, "<adrForward xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrForward>");
                                string idtypeCode = getInfoBetweenTags(item, "<idtypeCode xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</idtypeCode>");
                                string adrCusttype = getInfoBetweenTags(item, "<adrCusttype xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrCusttype>");
                                string masCode = getInfoBetweenTags(item, "<masCode xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</masCode>");
                                string masCodePub = getInfoBetweenTags(item, "<masCodePub xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</masCodePub>");
                                string adrNationality = getInfoBetweenTags(item, "<adrNationality xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrNationality>");
                                string adrNationalityPub = getInfoBetweenTags(item, "<adrNationalityPub xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrNationalityPub>");
                                string adrEmployee = getInfoBetweenTags(item, "<adrEmployee xmlns=\"http://ericsson.com/services/ws_CIL_7/addressesread\">", "</adrEmployee>");

                                Entity eAddress = new Entity("etel_customeraddress");
                                eAddress["etel_individualcustomerid"] = erIndividual;
                                eAddress["amx_addressrole"] = adrRoles;
                                eAddress["etel_postalcode"] = adrZip;
                                eAddress["amx_ttl"] = ttlId + " " + ttlIdPub;
                                eAddress["amx_searchaddress"] = adrStreet + " " + adrStreetno;
                                eAddress["etel_isprimaryaddress"] = false; 

                                if (!string.IsNullOrEmpty(adrCity))
                                {
                                    Entity erCity = getLookup(service, "etel_city", "etel_name", adrCity);

                                    if (erCity != null)
                                    {
                                        eAddress["etel_cityidname"] = erCity.ToEntityReference();
                                        nameCity = erCity["etel_name"].ToString();

                                    }
                                }

                                if (!string.IsNullOrEmpty(countryIdPub))
                                {
                                    Entity erContry = getLookup(service, "etel_country", "etel_name", countryIdPub);

                                    if (erContry != null)
                                    {
                                        eAddress["etel_countryidname"] = erContry.ToEntityReference();
                                    }
                                }

                                QueryExpression queryAddress = new QueryExpression("etel_customeraddress");
                                queryAddress.ColumnSet = new ColumnSet(false);
                                queryAddress.Criteria.AddCondition("etel_name", ConditionOperator.Like, adrStreet);
                                queryAddress.Criteria.AddCondition("etel_individualcustomerid", ConditionOperator.Like, erIndividual.Id);

                                EntityCollection ecAddresses = service.RetrieveMultiple(queryAddress);

                                if (ecAddresses.Entities.Count > 0)
                                {
                                    eAddress.Id = ecAddresses.Entities[0].Id;
                                    isUpdate = true;
                                }

                                if (isUpdate)
                                {
                                    service.Update(eAddress);
                                }
                                else
                                {
                                    eAddress["etel_name"] = nameCity + "-" + adrStreet + " " + adrStreetno;
                                    service.Create(eAddress);
                                }
                            }
                        }
                    }
                    catch (Exception ex) { string message = ex.Message; }
                }
            }
        }

        private string getHeaderXML(string user, string password)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:add='http://ericsson.com/services/ws_CIL_7/addressesread' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>";
            header = header + "<soapenv:Header><cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>";
            header = header + "<cwl_fullStack.bscsSecurity:UsernameToken><cwl_fullStack.bscsSecurity:Username>" + user + "</cwl_fullStack.bscsSecurity:Username><cwl_fullStack.bscsSecurity:Password>" + password + "</cwl_fullStack.bscsSecurity:Password>";
            header = header + "</cwl_fullStack.bscsSecurity:UsernameToken></cwl_fullStack.bscsSecurity:Security></soapenv:Header><soapenv:Body><add:addressesReadRequest><add:inputAttributes><add:csId></add:csId><add:csIdPub>";

            return header;
        }

        private string getFooterXML()
        {
            return "</add:csIdPub></add:inputAttributes><add:sessionChangeRequest><ses:values><ses:item><ses:key>BU_ID</ses:key><ses:value>2</ses:value></ses:item></ses:values></add:sessionChangeRequest></add:addressesReadRequest></soapenv:Body></soapenv:Envelope>";
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

        private Entity getLookup(IOrganizationService service, string entity, string field, string value)
        {
            Entity erLookup = null;

            QueryExpression query = new QueryExpression(entity);
            query.ColumnSet = new ColumnSet(field);
            query.Criteria.AddCondition(field, ConditionOperator.Like, "%" + value + "%");

            EntityCollection ecRecords = service.RetrieveMultiple(query);

            if (ecRecords.Entities.Count > 0)
            {
                erLookup = ecRecords.Entities[0];
            }

            return erLookup;
        }
    }
}
