using AmxPeruPSBActivities.Common;
using AmxPeruPSBActivities.Model.StratumChange;
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
    public class AmxCoStratumChangeCreateItemBusiness
    {
        public StratumChangeCreateItemResponse CreateItemsItemAddress(StratumChangeCreateItemRequest objRequest, OrganizationServiceProxy service)
        {
            StratumChangeCreateItemResponse objResponse = new StratumChangeCreateItemResponse();
            string messageErrorSubscription = string.Empty;
            string messageErrorIntegration = string.Empty;

            try
            {
                Entity eStratumChange = service.Retrieve("amx_stratumchange", Guid.Parse(objRequest.idStratum), new ColumnSet("amx_individualcustomer"));

                TranslationManage traslate = new TranslationManage();
                EntityCollection ecTraslate = traslate.getTraslateFormMessage("StratumChange", Guid.Parse(objRequest.idUser), service);

                foreach (Entity eTraslate in ecTraslate.Entities)
                {
                    if (eTraslate["etel_code"].ToString().Equals("MessageErrorSubscription")) { messageErrorSubscription = eTraslate["etel_message"].ToString(); }
                    if (eTraslate["etel_code"].ToString().Equals("MessageErrorIntegration")) { messageErrorIntegration = eTraslate["etel_message"].ToString(); }
                }

                if (eStratumChange != null)
                {
                    if (eStratumChange.Contains("amx_individualcustomer"))
                    {
                        Entity eIndividual = service.Retrieve("contact", ((EntityReference)eStratumChange["amx_individualcustomer"]).Id, new ColumnSet("etel_externalid"));

                        if (eIndividual.Contains("etel_externalid"))
                        {
                            string externalId = eIndividual["etel_externalid"].ToString();

                            string[] arrSeparator = { "</item>" };
                            string urlContractSearchRequest = string.Empty;
                            string urlInstallationAddressReadRequest = string.Empty;
                            string urlRatePlanRequest = string.Empty;
                            string userRequest = string.Empty;
                            string passwordRequest = string.Empty;

                            QueryExpression queryParameters = new QueryExpression("etel_crmconfiguration");
                            queryParameters.ColumnSet = new ColumnSet("etel_value", "etel_name");
                            queryParameters.Criteria.FilterOperator = LogicalOperator.Or;
                            queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "BIL_IntegrationsBSCS_UsrPsw");
                            queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bil_ContractSearch_Url");
                            queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bil_InstallationAddressRead_Url");
                            queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bil_RatePlanRead_Url");

                            EntityCollection ecParameters = service.RetrieveMultiple(queryParameters);

                            foreach (Entity eParam in ecParameters.Entities)
                            {
                                string nameParam = string.Empty;
                                if (eParam.Contains("etel_name"))
                                    nameParam = eParam["etel_name"].ToString();

                                if (nameParam.Equals("BIL_IntegrationsBSCS_UsrPsw")) { userRequest = eParam["etel_value"].ToString(); passwordRequest = eParam["etel_value"].ToString(); }
                                else if (nameParam.Equals("Bil_ContractSearch_Url")) { urlContractSearchRequest = eParam["etel_value"].ToString(); }
                                else if (nameParam.Equals("Bil_InstallationAddressRead_Url")) { urlInstallationAddressReadRequest = eParam["etel_value"].ToString(); }
                                else if (nameParam.Equals("Bil_RatePlanRead_Url")) { urlRatePlanRequest = eParam["etel_value"].ToString(); }
                            }

                            string xmlContractSearch = getSearchContractXML(userRequest, passwordRequest, externalId);
                            string contractSearch = callWebService(xmlContractSearch, urlContractSearchRequest);
                            string[] arrContracts;
                            int countContracts = 0;

                            if (!string.IsNullOrEmpty(contractSearch))
                            {
                                arrContracts = contractSearch.Split(arrSeparator, StringSplitOptions.None);

                                QueryExpression query = new QueryExpression("etel_customeraddress");
                                query.ColumnSet = new ColumnSet("etel_customeraddressid", "etel_postalcode");
                                query.Criteria.AddCondition("etel_individualcustomerid", ConditionOperator.Equal, ((EntityReference)eStratumChange["amx_individualcustomer"]).Id);

                                LinkEntity leDetailsTechnicals = new LinkEntity("etel_customeraddress", "amx_bimgltechnicaldetails", "etel_customeraddressid", "amx_customeraddressid", JoinOperator.Inner);
                                leDetailsTechnicals.Columns = new ColumnSet("amx_stratum");
                                leDetailsTechnicals.EntityAlias = "mgltd";

                                query.LinkEntities.Add(leDetailsTechnicals);

                                EntityCollection ecAddress = service.RetrieveMultiple(query);

                                if (arrContracts.Length > 0)
                                {
                                    foreach (string contract in arrContracts)
                                    {
                                        if (contract.Contains("coIdPub"))
                                        {
                                            string rpCode = getInfoBetweenTags(contract, "<rpcode xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</rpcode>");
                                            string contractId = getInfoBetweenTags(contract, "<coIdPub xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</coIdPub>");

                                            string xmlInstallationAddress = getReadInstallationAddressXML(userRequest, passwordRequest, contractId);
                                            string installationAddress = string.Empty;

                                            try
                                            {
                                                installationAddress = callWebService(xmlInstallationAddress, urlInstallationAddressReadRequest);
                                            }
                                            catch (Exception ex)
                                            {
                                                objResponse.IsError = true;
                                                objResponse.MsgError = string.Format(messageErrorIntegration, ex.Message, "Contract Search");
                                                return objResponse;
                                            }

                                            if (!string.IsNullOrEmpty(installationAddress))
                                            {
                                                string[] arrInstallationAddress = installationAddress.Split(arrSeparator, StringSplitOptions.None);

                                                foreach (string item in arrInstallationAddress)
                                                {
                                                    if (item.Contains("adrZip"))
                                                    {
                                                        string addressZip = getInfoBetweenTags(installationAddress, "<adrZip xmlns=\"http://ericsson.com/services/ws_CMI_7/installationaddressread\">", "</adrZip>");

                                                        foreach (Entity eAddress in ecAddress.Entities)
                                                        {
                                                            if (eAddress.Contains("etel_postalcode"))
                                                            {
                                                                if (eAddress["etel_postalcode"].ToString().Equals(addressZip))
                                                                {
                                                                    Entity createItemSC = new Entity("amx_stratumchangeitem");
                                                                    createItemSC["amx_stratumchange"] = eStratumChange.ToEntityReference();
                                                                    createItemSC["amx_customeraddress"] = new EntityReference("etel_customeraddress", (Guid)eAddress["etel_customeraddressid"]);
                                                                    if (eAddress.Contains("mgltd.amx_stratum")) createItemSC["amx_mglcrmstratum"] = ((AliasedValue)eAddress["mgltd.amx_stratum"]).Value.ToString();
                                                                    createItemSC["amx_billingstratum"] = "";
                                                                    createItemSC["amx_contractid"] = contractId;

                                                                    string xmlRatePlan = getReadRatePlanXML(userRequest, passwordRequest, rpCode);
                                                                    string ratePlan = string.Empty;

                                                                    try
                                                                    {
                                                                        ratePlan = callWebService(xmlRatePlan, urlRatePlanRequest);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        objResponse.IsError = true;
                                                                        objResponse.MsgError = string.Format(messageErrorIntegration, ex.Message, "Rate plan read");
                                                                        return objResponse;
                                                                    }

                                                                    if (!string.IsNullOrEmpty(ratePlan))
                                                                    {
                                                                        string rpCodeRate = getInfoBetweenTags(ratePlan, "<rpcode xmlns=\"http://ericsson.com/services/ws_CMI_7/rateplansread\">", "</rpcode>");

                                                                        if (rpCodeRate.Equals(rpCode))
                                                                        {
                                                                            createItemSC["amx_contractname"] = getInfoBetweenTags(ratePlan, "<rpDes xmlns=\"http://ericsson.com/services/ws_CMI_7/rateplansread\">", "</rpDes>");
                                                                        }
                                                                    }

                                                                    service.Create(createItemSC);

                                                                    countContracts++;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    if (countContracts == 0)
                                    {
                                        objResponse.IsError = true;
                                        objResponse.MsgError = messageErrorSubscription;
                                    }
                                }
                                else
                                {
                                    objResponse.IsError = true;
                                    objResponse.MsgError = messageErrorSubscription;
                                }
                            }
                            else
                            {
                                objResponse.IsError = true;
                                objResponse.MsgError = messageErrorSubscription;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objResponse.IsError = true;
                objResponse.MsgError = ex.Message;
                return objResponse;
            }

            objResponse.IsError = false;
            objResponse.MsgError = "Success";

            return objResponse;
        }

        private string getSearchContractXML(string user, string password, string customerId)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:con='http://ericsson.com/services/ws_CIL_7/contractssearch' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>";
            header = header + "<soapenv:Header><cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'> <cwl_fullStack.bscsSecurity:UsernameToken>";
            header = header + "<cwl_fullStack.bscsSecurity:Username>" + user + "</cwl_fullStack.bscsSecurity:Username><cwl_fullStack.bscsSecurity:Password>" + password + "</cwl_fullStack.bscsSecurity:Password></cwl_fullStack.bscsSecurity:UsernameToken></cwl_fullStack.bscsSecurity:Security></soapenv:Header><soapenv:Body><con:contractsSearchRequest>";
            header = header + "<con:inputAttributes><con:searcher>SimpleContractSearch</con:searcher><con:csIdPub>" + customerId + "</con:csIdPub> </con:inputAttributes> <con:sessionChangeRequest><ses:values><ses:item><ses:key>BU_ID</ses:key><ses:value>2</ses:value></ses:item></ses:values> </con:sessionChangeRequest></con:contractsSearchRequest></soapenv:Body></soapenv:Envelope>";

            return header;
        }

        private string getReadInstallationAddressXML(string user, string password, string contractId)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ins='http://ericsson.com/services/ws_CMI_7/installationaddressread' xmlns:ses='http://ericsson.com/services/ws_CMI_7/sessionchange'><soapenv:Header><Security xmlns='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>";
            header = header + "<UsernameToken><Username>" + user + "</Username><Password>" + password + "</Password></UsernameToken></Security></soapenv:Header><soapenv:Body><ins:installationAddressReadRequest><ins:inputAttributes><ins:coId></ins:coId>";
            header = header + "<ins:coIdPub>" + contractId + "</ins:coIdPub></ins:inputAttributes><ins:sessionChangeRequest><ses:values><ses:item><ses:key>BU_ID</ses:key><ses:value>2</ses:value>   </ses:item></ses:values></ins:sessionChangeRequest></ins:installationAddressReadRequest></soapenv:Body></soapenv:Envelope>";

            return header;
        }

        private string getReadRatePlanXML(string user, string password, string rpcode)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:rat='http://ericsson.com/services/ws_CMI_7/rateplansread' xmlns:ses='http://ericsson.com/services/ws_CMI_7/sessionchange'>";
            header = header + "<soapenv:Header><cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'><cwl_fullStack.bscsSecurity:UsernameToken>";
            header = header + "<cwl_fullStack.bscsSecurity:Username>" + user + "</cwl_fullStack.bscsSecurity:Username><cwl_fullStack.bscsSecurity:Password>" + password + "</cwl_fullStack.bscsSecurity:Password></cwl_fullStack.bscsSecurity:UsernameToken></cwl_fullStack.bscsSecurity:Security>";
            header = header + "</soapenv:Header><soapenv:Body><rat:rateplansReadRequest><rat:inputAttributes><rat:rpcode>" + rpcode + "</rat:rpcode><rat:rpcodePub></rat:rpcodePub><rat:extProductId></rat:extProductId><rat:extProductIdPub>";
            header = header + "</rat:extProductIdPub></rat:inputAttributes>      <rat:sessionChangeRequest><ses:values><ses:item><ses:key>BU_ID</ses:key><ses:value>2</ses:value></ses:item></ses:values></rat:sessionChangeRequest></rat:rateplansReadRequest></soapenv:Body></soapenv:Envelope>";

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

        private Guid getIdInternalExternal(Guid idIndividual, OrganizationServiceProxy service)
        {
            Guid idInternal = Guid.Empty;

            QueryExpression query = new QueryExpression("amx_biincludeandexcludeaccount");
            query.ColumnSet = new ColumnSet(false);
            query.Criteria.AddCondition("amx_individualcustomer", ConditionOperator.Equal, idIndividual);
            query.Orders.Add(new OrderExpression("createdon", OrderType.Descending));

            EntityCollection ecbis = service.RetrieveMultiple(query);
            foreach (Entity eBi in ecbis.Entities)
            {
                idInternal = eBi.Id;
                break;
            }

            return idInternal;
        }
    }
}
