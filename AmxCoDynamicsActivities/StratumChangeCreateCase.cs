using Microsoft.Xrm.Sdk;
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

namespace AmxDynamicsActivities
{
    public class StratumChangeCreateCase : CodeActivity
    {
        [Input("Item cambio de estrato")]
        [ReferenceTarget("amx_stratumchangeitem")]
        [RequiredArgument]
        public InArgument<EntityReference> InItemStratumChange { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InItemStratumChange.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erItemStratumChange)
        {
            string result = string.Empty;

            QueryExpression queryItem = new QueryExpression(erItemStratumChange.LogicalName);
            queryItem.ColumnSet = new ColumnSet("amx_stratumchange", "amx_customeraddress", "amx_billingstratum", "amx_mglcrmstratum",
                "amx_newstratum", "amx_orderitem");
            queryItem.Criteria.AddCondition("amx_stratumchangeitemid", ConditionOperator.Equal, erItemStratumChange.Id);

            LinkEntity leStratumChange = new LinkEntity(erItemStratumChange.LogicalName, "amx_stratumchange", "amx_stratumchange", "amx_stratumchangeid", JoinOperator.Inner);
            leStratumChange.Columns = new ColumnSet("amx_individualcustomer", "ownerid", "amx_supportfilename", "amx_othersupportfilename");
            leStratumChange.EntityAlias = "sc";

            LinkEntity leSystemUser = new LinkEntity("amx_stratumchange", "systemuser", "ownerid", "systemuserid", JoinOperator.Inner);
            leSystemUser.Columns = new ColumnSet("domainname");
            leSystemUser.EntityAlias = "us";

            queryItem.LinkEntities.Add(leStratumChange);
            queryItem.LinkEntities.Add(leSystemUser);

            EntityCollection ecItems = service.RetrieveMultiple(queryItem);

            if (ecItems.Entities.Count > 0)
            {
                Entity eItemStratumChange = ecItems.Entities[0];
                string caseType = string.Empty;
                string actionRequest = string.Empty;
                string urlRequest = string.Empty;
                string xmlRequest = string.Empty;
                string userRequest = string.Empty;
                string passwordRequest = string.Empty;
                string systemRequest = string.Empty;
                string appRequest = string.Empty;

                QueryExpression queryParameters = new QueryExpression("amxperu_amxconfigurations");
                queryParameters.ColumnSet = new ColumnSet("amxperu_value", "amxperu_name");
                queryParameters.Criteria.FilterOperator = LogicalOperator.Or;
                queryParameters.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "UrlCreateRequestStratumChange");
                queryParameters.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "ActionCreateRequestStratumChange");
                queryParameters.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "CaseTypeStratumChange");
                queryParameters.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "UserCreateRequestStratumChange");
                queryParameters.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "PasswordCreateRequestStratumChange");
                queryParameters.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "SystemCreateRequestStratumChange");
                queryParameters.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "AppCreateRequestStratumChange");

                EntityCollection ecParameters = service.RetrieveMultiple(queryParameters);

                foreach (Entity eParam in ecParameters.Entities)
                {
                    string nameParam = string.Empty;
                    if (eParam.Contains("amxperu_name"))
                        nameParam = eParam["amxperu_name"].ToString();

                    if (nameParam.Equals("UrlCreateRequestStratumChange")) { urlRequest = eParam["amxperu_value"].ToString(); }
                    else if (nameParam.Equals("ActionCreateRequestStratumChange")) { actionRequest = eParam["amxperu_value"].ToString(); }
                    else if (nameParam.Equals("CaseTypeStratumChange")) { caseType = eParam["amxperu_value"].ToString(); }
                    else if (nameParam.Equals("UserCreateRequestStratumChange")) { userRequest = eParam["amxperu_value"].ToString(); }
                    else if (nameParam.Equals("PasswordCreateRequestStratumChange")) { passwordRequest = eParam["amxperu_value"].ToString(); }
                    else if (nameParam.Equals("SystemCreateRequestStratumChange")) { systemRequest = eParam["amxperu_value"].ToString(); }
                    else if (nameParam.Equals("AppCreateRequestStratumChange")) { appRequest = eParam["amxperu_value"].ToString(); }
                }

                if (eItemStratumChange.Contains("amx_stratumchange"))
                {
                    var newstratum = ((OptionSetValue)eItemStratumChange["amx_newstratum"]).Value.ToString();
                    var mglcrmstratum = eItemStratumChange["amx_mglcrmstratum"].ToString();
                    if (Int32.Parse(newstratum) != Int32.Parse(mglcrmstratum))
                    {
                        Guid idIndividualCustomer = ((EntityReference)((AliasedValue)eItemStratumChange["sc.amx_individualcustomer"]).Value).Id;
                        EntityReference erStratumChange = (EntityReference)eItemStratumChange["amx_stratumchange"];

                        EntityReference erCaseType = null;
                        QueryExpression queryCaseType = new QueryExpression("amxperu_casetype");
                        queryCaseType.ColumnSet = new ColumnSet(false);
                        queryCaseType.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, caseType);

                        EntityCollection ecCaseType = service.RetrieveMultiple(queryCaseType);

                        if (ecCaseType.Entities.Count > 0)
                        {
                            erCaseType = ecCaseType.Entities[0].ToEntityReference();
                        }

                        Entity eIncidentCreate = new Entity("incident");
                        eIncidentCreate["amxperu_casetype"] = erCaseType;
                        eIncidentCreate["customerid"] = (EntityReference)((AliasedValue)eItemStratumChange["sc.amx_individualcustomer"]).Value;
                        eIncidentCreate["description"] = "Solicitud de cambio de estrato: " + ((OptionSetValue)eItemStratumChange["amx_newstratum"]).Value.ToString();
                        eIncidentCreate["amx_stratumchange"] = erStratumChange;

                        Guid idIncident = service.Create(eIncidentCreate);

                        string[] idUser = ((AliasedValue)eItemStratumChange["us.domainname"]).Value.ToString().Split('\\');

                        QueryExpression queryIndividual = new QueryExpression("contact");
                        queryIndividual.ColumnSet = new ColumnSet("etel_externalid");
                        queryIndividual.Criteria.AddCondition("contactid", ConditionOperator.Equal, ((EntityReference)((AliasedValue)eItemStratumChange["sc.amx_individualcustomer"]).Value).Id);

                        LinkEntity leCustomerAddress = new LinkEntity("contact", "etel_customeraddress", "contactid", "etel_individualcustomerid", JoinOperator.LeftOuter);
                        leCustomerAddress.EntityAlias = "ca";
                        leCustomerAddress.Columns = new ColumnSet("amx_addressid");

                        LinkEntity leContactInformation = new LinkEntity("contact", "amx_customercontactinformation", "contactid", "amx_individualcustomerid", JoinOperator.LeftOuter);
                        leContactInformation.EntityAlias = "ci";
                        leContactInformation.Columns = new ColumnSet("amx_phoneno", "amx_primarycontacttype");
                        leContactInformation.LinkCriteria.AddCondition("amx_phoneno", ConditionOperator.NotNull);

                        queryIndividual.LinkEntities.Add(leCustomerAddress);
                        queryIndividual.LinkEntities.Add(leContactInformation);

                        EntityCollection ecIndividual = service.RetrieveMultiple(queryIndividual);

                        string detailedAddress = string.Empty;
                        string contactPhone = string.Empty;
                        string suscriberAccount = string.Empty;

                        foreach (Entity eIndividual in ecIndividual.Entities)
                        {
                            if (eIndividual.Contains("etel_externalid") && string.IsNullOrEmpty(suscriberAccount))
                                suscriberAccount = eIndividual["etel_externalid"].ToString();

                            if (eIndividual.Contains("ca.amx_addressid") && string.IsNullOrEmpty(detailedAddress))
                                detailedAddress = ((AliasedValue)eIndividual["ca.amx_addressid"]).Value.ToString();

                            if (eIndividual.Contains("ci.amx_phoneno"))
                            {
                                if (eIndividual.Contains("ci.amx_primarycontacttype"))
                                {
                                    if ((bool)((AliasedValue)eIndividual["ci.amx_primarycontacttype"]).Value)
                                        contactPhone = ((AliasedValue)eIndividual["ci.amx_phoneno"]).Value.ToString();
                                    else if (string.IsNullOrEmpty(contactPhone))
                                        contactPhone = ((AliasedValue)eIndividual["ci.amx_phoneno"]).Value.ToString();
                                }
                                else if (string.IsNullOrEmpty(contactPhone))
                                    contactPhone = ((AliasedValue)eIndividual["ci.amx_phoneno"]).Value.ToString();

                            }
                        }

                        xmlRequest = getHeaderXML(userRequest, passwordRequest, systemRequest, appRequest);
                        xmlRequest = xmlRequest + getTagXML("v1:idUsuario", (idUser.Length > 1) ? idUser[1] : idUser[0]);
                        xmlRequest = xmlRequest + getTagXML("v1:estratoNuevo", ((OptionSetValue)eItemStratumChange["amx_newstratum"]).Value.ToString());
                        xmlRequest = xmlRequest + getTagXML("v1:observaciones", "Solicitud de cambio de estrato.");
                        xmlRequest = xmlRequest + getTagXML("v1:cuentaSuscriptor", suscriberAccount);
                        xmlRequest = xmlRequest + getTagXML("v1:contacto", ((EntityReference)((AliasedValue)eItemStratumChange["sc.amx_individualcustomer"]).Value).Id.ToString());
                        xmlRequest = xmlRequest + getTagXML("v1:telefonoContacto", contactPhone);
                        xmlRequest = xmlRequest + getTagXML("v1:canalVentas", "CANAL DUMMY");

                        if (eItemStratumChange.Contains("sc.amx_supportfilename"))
                        {
                            Entity eStratumChange = service.Retrieve(erStratumChange.LogicalName, erStratumChange.Id, new ColumnSet("amx_supportfilename"));
                            xmlRequest = xmlRequest + getTagXML("v1:fileName", eStratumChange.FormattedValues["amx_supportfilename"].ToString());
                        }
                        else if (eItemStratumChange.Contains("sc.amx_othersupportfilename"))
                            xmlRequest = xmlRequest + getTagXML("v1:fileName", ((AliasedValue)eItemStratumChange["sc.amx_othersupportfilename"]).Value.ToString());
                        else
                            xmlRequest = xmlRequest + getTagXML("v1:fileName", "");

                        xmlRequest = xmlRequest + getTagXML("v1:fileBytes", "YWRmYWdkc2Znc2RmZ3NkZmdzZGY=");
                        xmlRequest = xmlRequest + getTagXML("v1:direccionDetalladaId", (string.IsNullOrEmpty(detailedAddress)) ? "1130386" : detailedAddress);
                        xmlRequest = xmlRequest + getTagXML("v1:casoTcrmId", idIncident.ToString());
                        xmlRequest = xmlRequest + getFooterXML();

                        Entity eIncident = service.Retrieve("incident", idIncident, new ColumnSet("ticketnumber"));

                        try
                        {
                            string response = callWebService(xmlRequest, urlRequest, actionRequest);
                            string messageResponse = getInfoBetweenTags(response, "<tns:mensaje>", "</tns:mensaje>");

                            result = "Se ha generado un caso con numero: " + eIncident["ticketnumber"].ToString();
                            result = result + " | " + messageResponse;

                        }
                        catch (Exception ex)
                        {
                            result = "Se ha generado un caso con numero: " + eIncident["ticketnumber"].ToString();
                            result = result + " | " + ex.Message;
                        }

                        Entity eStratumChangeUpd = new Entity(erStratumChange.LogicalName);
                        eStratumChangeUpd.Id = erStratumChange.Id;
                        eStratumChangeUpd["amx_responserequest"] = result;

                        service.Update(eStratumChangeUpd);

                        Entity individualCust = new Entity("contact");
                        individualCust.Id = idIndividualCustomer;
                        individualCust["amx_isforchangestratum"] = true;

                        service.Update(individualCust);
                    }
                    else
                    {
                        result = "El nuevo estrato seleccionado es igual al estrato actual. Por favor verifique";
                    }
                }
            }
        }

        private string getHeaderXML(string user, string password, string systemReq, string app)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:v1='http://www.amx.com/Schema/Operation/SolicitudCambioEstrato/V1.0' xmlns:v11='http://www.amx.com/CO/Schema/ClaroHeaders/v1'>";
            header = header + "<soapenv:Header/><soapenv:Body><v1:SolicitudCambioEstratoRequest>";
            header = header + "<v1:headerRequest><v11:transactionId>" + Guid.NewGuid() + "</v11:transactionId><v11:system>" + systemReq + "</v11:system><v11:user>" + user + "</v11:user>";
            header = header + "<v11:password>" + password + "</v11:password><v11:requestDate>" + DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss") + "</v11:requestDate><v11:ipApplication>" + app + "</v11:ipApplication>";
            header = header + "<v11:traceabilityId>?</v11:traceabilityId></v1:headerRequest>";

            return header;
        }

        private string getFooterXML()
        {
            return "</v1:SolicitudCambioEstratoRequest></soapenv:Body></soapenv:Envelope >";
        }

        private string getTagXML(string tagname, string value)
        {
            return "<" + tagname + ">" + value + "</" + tagname + ">";
        }

        private string callWebService(string xml, string url, string action)
        {
            string soapResult = string.Empty;
            string _action = url + "?op=" + action;

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(xml);
            HttpWebRequest webRequest = CreateWebRequest(url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

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

        private HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
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
