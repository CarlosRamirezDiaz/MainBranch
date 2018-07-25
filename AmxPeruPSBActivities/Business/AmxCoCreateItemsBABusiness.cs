using AmxPeruPSBActivities.Model.InternalExternalAccount;
using Microsoft.Xrm.Sdk.Client;
using System;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System.IO;
using System.Xml;
using System.Net;
using System.Reflection;
using System.Net.Configuration;
using AmxPeruPSBActivities.Common;

namespace AmxPeruPSBActivities.Business
{
    public class AmxCoCreateItemsBABusiness
    {
        public AmxCoCreateItemsAccountWithDataBSCSResponse CreateItemsAccountWithDataBSCS(string idIndividual, OrganizationServiceProxy service, Guid idUser)
        {
            AmxCoCreateItemsAccountWithDataBSCSResponse objResponse = new AmxCoCreateItemsAccountWithDataBSCSResponse();
            string messageErrorIntegration = string.Empty;

            try
            {                
                TranslationManage traslate = new TranslationManage();
                EntityCollection ecTraslate = traslate.getTraslateFormMessage("IncludeAndExcludeAccount", idUser, service);

                foreach (Entity eTraslate in ecTraslate.Entities)
                {                    
                    if (eTraslate["etel_code"].ToString().Equals("MessageErrorIntegration")) { messageErrorIntegration = eTraslate["etel_message"].ToString(); }
                }

                Guid guidIndividual = Guid.Parse(idIndividual);
                Entity eIndividual = service.Retrieve("contact", guidIndividual, new ColumnSet("etel_externalid"));
                Entity eAccountChange = new Entity("amx_biincludeandexcludeaccount");
                eAccountChange.Id = getIdInternalExternal(guidIndividual, service);

                if (eIndividual != null)
                {
                    if (eIndividual.Contains("etel_externalid"))
                    {
                        string[] arrSeparator = { "</item>" };
                        string urlCustomerReadRequest = string.Empty;
                        string urlCyclesReadRequest = string.Empty;
                        string urlPamentArragementReadRequest = string.Empty;
                        string urlPamentMethodRequest = string.Empty;
                        string urlbillingAccountSearchRequest = string.Empty;
                        string urlbillingAccountReadRequest = string.Empty;
                        string urlBillMediumReadRequest = string.Empty;
                        string urlContractSearchRequest = string.Empty;
                        string urlContractReadRequest = string.Empty;
                        string urlRatePlanRequest = string.Empty;
                        string xmlRequest = string.Empty;
                        string userRequest = string.Empty;
                        string passwordRequest = string.Empty;

                        QueryExpression queryParameters = new QueryExpression("etel_crmconfiguration");
                        queryParameters.ColumnSet = new ColumnSet("etel_value", "etel_name");
                        queryParameters.Criteria.FilterOperator = LogicalOperator.Or;
                        queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bill_CustomerReadBscs_URL");
                        queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "BIL_IntegrationsBSCS_UsrPsw");
                        queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "BIL_CyclesRead_URL");
                        queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bil_PaymentArragement_Url");
                        queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bil_PaymentMethod_Url");
                        queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bil_BillingAccountSearch_Url");
                        queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bil_BillingAccountRead_Url");
                        queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bil_BillMediumRead_Url");
                        queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bil_ContractSearch_Url");
                        queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bil_ContractRead_Url");
                        queryParameters.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "Bil_RatePlanRead_Url");

                        EntityCollection ecParameters = service.RetrieveMultiple(queryParameters);

                        foreach (Entity eParam in ecParameters.Entities)
                        {
                            string nameParam = string.Empty;
                            if (eParam.Contains("etel_name"))
                                nameParam = eParam["etel_name"].ToString();

                            if (nameParam.Equals("Bill_CustomerReadBscs_URL")) { urlCustomerReadRequest = eParam["etel_value"].ToString(); }
                            else if (nameParam.Equals("BIL_IntegrationsBSCS_UsrPsw")) { userRequest = eParam["etel_value"].ToString(); passwordRequest = eParam["etel_value"].ToString(); }
                            else if (nameParam.Equals("BIL_CyclesRead_URL")) { urlCyclesReadRequest = eParam["etel_value"].ToString(); }
                            else if (nameParam.Equals("Bil_PaymentArragement_Url")) { urlPamentArragementReadRequest = eParam["etel_value"].ToString(); }
                            else if (nameParam.Equals("Bil_PaymentMethod_Url")) { urlPamentMethodRequest = eParam["etel_value"].ToString(); }
                            else if (nameParam.Equals("Bil_BillingAccountSearch_Url")) { urlbillingAccountSearchRequest = eParam["etel_value"].ToString(); }
                            else if (nameParam.Equals("Bil_BillingAccountRead_Url")) { urlbillingAccountReadRequest = eParam["etel_value"].ToString(); }
                            else if (nameParam.Equals("Bil_BillMediumRead_Url")) { urlBillMediumReadRequest = eParam["etel_value"].ToString(); }
                            else if (nameParam.Equals("Bil_ContractSearch_Url")) { urlContractSearchRequest = eParam["etel_value"].ToString(); }
                            else if (nameParam.Equals("Bil_ContractRead_Url")) { urlContractReadRequest = eParam["etel_value"].ToString(); }
                            else if (nameParam.Equals("Bil_RatePlanRead_Url")) { urlRatePlanRequest = eParam["etel_value"].ToString(); }
                        }

                        string externalId = eIndividual["etel_externalid"].ToString();
                        string xmlCustomerRead = getReadCustomerXML(userRequest, passwordRequest, externalId);
                        string customerRead = string.Empty;

                        try
                        {
                            customerRead = callWebService(xmlCustomerRead, urlCustomerReadRequest);
                        }
                        catch (Exception ex)
                        {
                            objResponse.error = true;
                            objResponse.message = string.Format(messageErrorIntegration, "Customer Read", ex.Message);
                            return objResponse;
                        }

                        if (!string.IsNullOrEmpty(customerRead))
                        {
                            string cycle = getInfoBetweenTags(customerRead, "<csBillcycle xmlns=\"http://ericsson.com/services/ws_CIL_7/customerread\">", "</csBillcycle>");
                            eAccountChange["amx_cycle"] = getInfoBetweenTags(customerRead, "<csBillcycleDesc xmlns=\"http://ericsson.com/services/ws_CIL_7/customerread\">", "</csBillcycleDesc>");
                            string responsible = getInfoBetweenTags(customerRead, "<paymentResp xmlns=\"http://ericsson.com/services/ws_CIL_7/customerread\">", "</paymentResp>");
                            if (!string.IsNullOrEmpty(responsible))
                            {
                                bool booResponsible = false;
                                bool.TryParse(responsible, out booResponsible);
                                eAccountChange["amx_responsible"] = booResponsible;
                            }

                            string xmlCycleRead = getReadCyclesXML(userRequest, passwordRequest);
                            string cycleRead = callWebService(xmlCycleRead, urlCyclesReadRequest);

                            try
                            {
                                cycleRead = callWebService(xmlCycleRead, urlCyclesReadRequest);
                            }
                            catch (Exception ex)
                            {
                                objResponse.error = true;
                                objResponse.message = string.Format(messageErrorIntegration, "Cycle Read", ex.Message);
                                return objResponse;
                            }

                            if (!string.IsNullOrEmpty(cycleRead))
                            {
                                string[] arrItems = cycleRead.Split(arrSeparator, StringSplitOptions.None);

                                foreach (string item in arrItems)
                                {
                                    if (item.Contains("<item xmlns=\"http://ericsson.com/services/ws_CMI_7/billcyclesread\">"))
                                    {
                                        string billCycle = getInfoBetweenTags(item, "<billcycle xmlns=\"http://ericsson.com/services/ws_CMI_7/billcyclesread\">", "</billcycle>");

                                        if (!string.IsNullOrEmpty(billCycle))
                                        {
                                            if (billCycle.Equals(cycle))
                                            {
                                                string dateBch = getInfoBetweenTags(item, "<bchRunDate xmlns=\"http://ericsson.com/services/ws_CMI_7/billcyclesread\">", "</bchRunDate>");
                                                if (!string.IsNullOrEmpty(dateBch)) eAccountChange["amx_bchrundate"] = DateTime.Parse(dateBch);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        string xmlPaymentArrangements = getReadPayentArragementXML(userRequest, passwordRequest, externalId);
                        string paymentArragementRead = string.Empty;

                        try
                        {
                            paymentArragementRead = callWebService(xmlPaymentArrangements, urlPamentArragementReadRequest);
                        }
                        catch (Exception ex)
                        {
                            objResponse.error = true;
                            objResponse.message = string.Format(messageErrorIntegration, "Payment arragement", ex.Message);
                            return objResponse;
                        }

                        if (!string.IsNullOrEmpty(paymentArragementRead))
                        {
                            string csPmnId = getInfoBetweenTags(paymentArragementRead, "<cspPmntIdPub xmlns=\"http://ericsson.com/services/ws_CIL_7/paymentarrangementsread\">", "</cspPmntIdPub>");
                            string xmlPaymentMethod = getReadPayentMethodstXML(userRequest, passwordRequest);
                            string paymentMethods = string.Empty;

                            try
                            {
                                paymentMethods = callWebService(xmlPaymentMethod, urlPamentMethodRequest);
                            }
                            catch (Exception ex)
                            {
                                objResponse.error = true;
                                objResponse.message = string.Format(messageErrorIntegration, "Payment methods", ex.Message);
                                return objResponse;
                            }

                            if (!string.IsNullOrEmpty(paymentMethods))
                            {
                                string[] arrItems = paymentMethods.Split(arrSeparator, StringSplitOptions.None);

                                foreach (string item in arrItems)
                                {
                                    if (item.Contains("<item xmlns=\"http://ericsson.com/services/ws_CIL_7/paymentmethodsread\">"))
                                    {
                                        string payMet = getInfoBetweenTags(item, "<paymethIdPub xmlns=\"http://ericsson.com/services/ws_CIL_7/paymentmethodsread\">", "</paymethIdPub>");

                                        if (!string.IsNullOrEmpty(payMet))
                                        {
                                            if (payMet.Equals(csPmnId))
                                            {
                                                string paymentMet = getInfoBetweenTags(item, "<paymethDesc xmlns=\"http://ericsson.com/services/ws_CIL_7/paymentmethodsread\">", "</paymethDesc>");
                                                if (!string.IsNullOrEmpty(paymentMet)) eAccountChange["amx_paymentmethod"] = paymentMet;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        service.Update(eAccountChange);

                        string xmlBillingAccountSearch = getSearchBillingAccountXML(userRequest, passwordRequest, externalId);
                        string billingAccountsSearch = string.Empty;
                        string[][] arrBilAccounts;

                        try
                        {
                            billingAccountsSearch = callWebService(xmlBillingAccountSearch, urlbillingAccountSearchRequest);
                        }
                        catch (Exception ex)
                        {
                            objResponse.error = true;
                            objResponse.message = string.Format(messageErrorIntegration, "Billing Account Search", ex.Message);
                            return objResponse;
                        }

                        if (!string.IsNullOrEmpty(billingAccountsSearch))
                        {
                            string[] arrItems = billingAccountsSearch.Split(arrSeparator, StringSplitOptions.None);
                            arrBilAccounts = new string[arrItems.Length - 1][];

                            string xmlBillMediusRead = getReadBillMediumXML(userRequest, passwordRequest);
                            string billMediumsRead = string.Empty;

                            try
                            {
                                billMediumsRead = callWebService(xmlBillMediusRead, urlBillMediumReadRequest);
                            }
                            catch (Exception ex)
                            {
                                objResponse.error = true;
                                objResponse.message = string.Format(messageErrorIntegration, "Billing Medium Read", ex.Message);
                                return objResponse;
                            }

                            if (!string.IsNullOrEmpty(billMediumsRead))
                            {
                                string[] billMediuns = billMediumsRead.Split(arrSeparator, StringSplitOptions.None);

                                for (int i = 0; i < arrItems.Length; i++)
                                {
                                    string item = arrItems[i];
                                    if (item.Contains("<item xmlns=\"http://ericsson.com/services/ws_CIL_7/billingaccountsearch\">"))
                                    {
                                        string billAccountCode = getInfoBetweenTags(item, "<billingAccountCode xmlns=\"http://ericsson.com/services/ws_CIL_7/billingaccountsearch\">", "</billingAccountCode>");

                                        Entity eBillAccount = new Entity("amx_itembillingaccount");
                                        eBillAccount["amx_biinternalandexternal"] = new EntityReference("amx_biincludeandexcludeaccount", eAccountChange.Id);
                                        eBillAccount["amx_billingaccountcode"] = billAccountCode;
                                        eBillAccount["amx_description"] = getInfoBetweenTags(item, "<billingAccountName xmlns=\"http://ericsson.com/services/ws_CIL_7/billingaccountsearch\">", "</billingAccountName>");
                                        string csId = getInfoBetweenTags(item, "<csId xmlns=\"http://ericsson.com/services/ws_CIL_7/billingaccountsearch\">", "</csId>");
                                        eBillAccount["amx_csid"] = csId;
                                        arrBilAccounts[i] = new string[2];
                                        arrBilAccounts[i][0] = csId;

                                        string xmlBillingAccountRead = getReadBillingAccountXML(userRequest, passwordRequest, billAccountCode);
                                        string bilAccountRead = callWebService(xmlBillingAccountRead, urlbillingAccountSearchRequest);

                                        if (!string.IsNullOrEmpty(bilAccountRead))
                                        {
                                            string bmId = getInfoBetweenTags(bilAccountRead, "<bmId xmlns=\"http://ericsson.com/services/ws_CMI_6/billingaccountread\">", "</bmId>");

                                            foreach (string itemBmId in billMediuns)
                                            {
                                                if (itemBmId.Contains("<bmDes xmlns=\"http://ericsson.com/services/ws_CMI_7/billmediumread\">"))
                                                {
                                                    string bmIdInItem = getInfoBetweenTags(itemBmId, "<bmId xmlns=\"http://ericsson.com/services/ws_CMI_7/billmediumread\">", "</bmId>");

                                                    if (bmIdInItem.Equals(bmId))
                                                    {
                                                        eBillAccount["amx_billmedium"] = getInfoBetweenTags(itemBmId, "<bmDes xmlns=\"http://ericsson.com/services/ws_CMI_7/billmediumread\">", "</bmDes>");
                                                        break;
                                                    }
                                                }
                                            }
                                        }

                                        Guid idBillingAccount = service.Create(eBillAccount);
                                        arrBilAccounts[i][1] = idBillingAccount.ToString();
                                    }
                                }
                            }
                        }
                        else { arrBilAccounts = null; }

                        string xmlContractSearch = getSearchContractXML(userRequest, passwordRequest, externalId);
                        string contractsSearch = string.Empty;

                        try
                        {
                            contractsSearch = callWebService(xmlContractSearch, urlContractSearchRequest);
                        }
                        catch (Exception ex)
                        {
                            objResponse.error = true;
                            objResponse.message = string.Format(messageErrorIntegration, "Request Cotract Search", ex.Message);
                            return objResponse;
                        }

                        if (!string.IsNullOrEmpty(contractsSearch))
                        {
                            string[] arrItemsContract = contractsSearch.Split(arrSeparator, StringSplitOptions.None);

                            foreach (string item in arrItemsContract)
                            {
                                Entity eContract = new Entity("amx_itemcontract");

                                if (item.Contains("<item xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">"))
                                {
                                    string rpCode = getInfoBetweenTags(item, "<rpcode xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</rpcode>");
                                    string contractId = getInfoBetweenTags(item, "<coIdPub xmlns=\"http://ericsson.com/services/ws_CIL_7/contractssearch\">", "</coIdPub>");
                                    eContract["amx_code"] = contractId;

                                    try
                                    {
                                        string xmlContractRead = getReadContractXML(userRequest, passwordRequest, contractId);
                                        string contractRead = callWebService(xmlContractRead, urlContractReadRequest);

                                        if (!string.IsNullOrEmpty(contractRead))
                                        {
                                            string csIdContract = getInfoBetweenTags(contractRead, "<csId xmlns=\"http://ericsson.com/services/ws_CIL_7/contractread\">", "</csId>");

                                            foreach (string[] arrItem in arrBilAccounts)
                                            {
                                                if (arrItem[0].Equals(csIdContract))
                                                {
                                                    eContract["amx_itembillingaccount"] = new EntityReference("amx_itembillingaccount", Guid.Parse(arrItem[1]));
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        objResponse.error = true;
                                        objResponse.message = string.Format(messageErrorIntegration, "Cotract Read", ex.Message);
                                        return objResponse;
                                    }

                                    string xmlRatePlan = getReadRatePlanXML(userRequest, passwordRequest, rpCode);
                                    string ratePlan = string.Empty;

                                    try
                                    {
                                        ratePlan = callWebService(xmlRatePlan, urlRatePlanRequest);
                                    }
                                    catch (Exception ex)
                                    {
                                        objResponse.error = true;
                                        objResponse.message = string.Format(messageErrorIntegration, "Rate Plan Read", ex.Message);
                                        return objResponse;
                                    }

                                    if (!string.IsNullOrEmpty(ratePlan))
                                    {
                                        string rpCodeRate = getInfoBetweenTags(ratePlan, "<rpcode xmlns=\"http://ericsson.com/services/ws_CMI_7/rateplansread\">", "</rpcode>");

                                        if (rpCodeRate.Equals(rpCode))
                                        {
                                            eContract["amx_name"] = getInfoBetweenTags(ratePlan, "<rpDes xmlns=\"http://ericsson.com/services/ws_CMI_7/rateplansread\">", "</rpDes>");
                                        }
                                    }

                                    service.Create(eContract);
                                }
                            }
                        }

                        //amx_itemcontract

                        objResponse.error = false;
                        objResponse.message = "Success";
                    }
                    else
                    {
                        objResponse.error = false;
                        objResponse.message = "Error";
                    }
                    
                }
                else
                {
                    objResponse.error = false;
                    objResponse.message = "Error";
                }
                
            }
            catch (Exception ex)
            {
                objResponse.error = true;
                objResponse.message = ex.Message;
            }

            

            return objResponse;
        }

        private string getReadCustomerXML(string user, string password, string customerId)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:cus='http://ericsson.com/services/ws_CIL_7/customerread' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>";
            header = header + "<soapenv:Header><Security xmlns='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'><UsernameToken>";
            header = header + "<Username>" + user + "</Username><Password>" + password + "</Password></UsernameToken></Security></soapenv:Header><soapenv:Body><cus:customerReadRequest><cus:inputAttributes><cus:csId></cus:csId>";
            header = header + "<cus:csIdPub>" + customerId + "</cus:csIdPub><cus:syncWithDb></cus:syncWithDb></cus:inputAttributes><cus:sessionChangeRequest><ses:values><ses:item><ses:key>BU_ID</ses:key>";
            header = header + "<ses:value>2</ses:value></ses:item></ses:values></cus:sessionChangeRequest></cus:customerReadRequest></soapenv:Body></soapenv:Envelope>";

            return header;
        }

        private string getReadCyclesXML(string user, string password)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:bil='http://ericsson.com/services/ws_CMI_7/billcyclesread' xmlns:ses='http://ericsson.com/services/ws_CMI_7/sessionchange'>";
            header = header + "<soapenv:Header><cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>";
            header = header + "<cwl_fullStack.bscsSecurity:UsernameToken><cwl_fullStack.bscsSecurity:Username>" + user + "</cwl_fullStack.bscsSecurity:Username><cwl_fullStack.bscsSecurity:Password>" + password + "</cwl_fullStack.bscsSecurity:Password>";
            header = header + "</cwl_fullStack.bscsSecurity:UsernameToken></cwl_fullStack.bscsSecurity:Security></soapenv:Header><soapenv:Body><bil:billCyclesReadRequest><bil:inputAttributes><bil:partyType>C</bil:partyType><bil:readAll>false</bil:readAll></bil:inputAttributes>";
            header = header + "<bil:sessionChangeRequest><ses:values><ses:item><ses:key>BU_ID</ses:key><ses:value>2</ses:value></ses:item></ses:values></bil:sessionChangeRequest></bil:billCyclesReadRequest></soapenv:Body></soapenv:Envelope>";

            return header;
        }

        private string getReadPayentArragementXML(string user, string password, string customerId)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:pay='http://ericsson.com/services/ws_CIL_7/paymentarrangementsread' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>";
            header = header + "<soapenv:Header><cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>";
            header = header + "<cwl_fullStack.bscsSecurity:UsernameToken><cwl_fullStack.bscsSecurity:Username>" + user + "</cwl_fullStack.bscsSecurity:Username><cwl_fullStack.bscsSecurity:Password>" + password + "</cwl_fullStack.bscsSecurity:Password></cwl_fullStack.bscsSecurity:UsernameToken>";
            header = header + "</cwl_fullStack.bscsSecurity:Security></soapenv:Header><soapenv:Body>   <pay:paymentArrangementsReadRequest><pay:inputAttributes><pay:flagCurrent></pay:flagCurrent><pay:csId></pay:csId><pay:csIdPub>" + customerId + "</pay:csIdPub>";
            header = header + "</pay:inputAttributes><pay:sessionChangeRequest><ses:values><ses:item><ses:key>BU_ID</ses:key><ses:value>2</ses:value>   </ses:item></ses:values></pay:sessionChangeRequest></pay:paymentArrangementsReadRequest></soapenv:Body></soapenv:Envelope>";

            return header;
        }

        private string getReadPayentMethodstXML(string user, string password)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:pay='http://ericsson.com/services/ws_CIL_7/paymentmethodsread' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>";
            header = header + "<soapenv:Header><cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'><cwl_fullStack.bscsSecurity:UsernameToken>";
            header = header + "<cwl_fullStack.bscsSecurity:Username>" + user + "</cwl_fullStack.bscsSecurity:Username><cwl_fullStack.bscsSecurity:Password>" + password + "</cwl_fullStack.bscsSecurity:Password></cwl_fullStack.bscsSecurity:UsernameToken>";
            header = header + "</cwl_fullStack.bscsSecurity:Security></soapenv:Header><soapenv:Body><pay:paymentMethodsReadRequest><pay:inputAttributes><pay:paymethStandardOnly></pay:paymethStandardOnly></pay:inputAttributes><pay:sessionChangeRequest><ses:values><ses:item>";
            header = header + "<ses:key>BU_ID</ses:key><ses:value>2</ses:value></ses:item></ses:values></pay:sessionChangeRequest></pay:paymentMethodsReadRequest></soapenv:Body></soapenv:Envelope>";

            return header;
        }

        private string getSearchBillingAccountXML(string user, string password, string customerId)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:bil='http://ericsson.com/services/ws_CIL_7/billingaccountsearch' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>    ";
            header = header + "<soapenv:Header><Security xmlns='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'><UsernameToken><Username>" + user + "</Username><Password>" + password + "</Password>";
            header = header + "</UsernameToken></Security></soapenv:Header><soapenv:Body><bil:billingAccountSearchRequest><bil:inputAttributes><bil:csId></bil:csId><bil:csIdPub>" + customerId + "</bil:csIdPub><bil:mode>O</bil:mode><bil:invoicingInd></bil:invoicingInd>";
            header = header + "<bil:srchCount></bil:srchCount> </bil:inputAttributes> <bil:sessionChangeRequest><ses:values><ses:item><ses:key>BU_ID</ses:key><ses:value>2</ses:value></ses:item></ses:values> </bil:sessionChangeRequest></bil:billingAccountSearchRequest></soapenv:Body></soapenv:Envelope>";

            return header;
        }

        private string getReadBillingAccountXML(string user, string password, string bilAccId)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:bil='http://ericsson.com/services/ws_CMI_6/billingaccountread' xmlns:ses='http://ericsson.com/services/ws_CMI_6/sessionchange'>";
            header = header + "<soapenv:Header><Security><UsernameToken><Username>" + user + "</Username><Password>" + password + "</Password></UsernameToken></Security></soapenv:Header><soapenv:Body><bil:billingAccountReadRequest><bil:inputAttributes><bil:billingAccountId>";
            header = header + "</bil:billingAccountId><bil:billingAccountCode>" + bilAccId + "</bil:billingAccountCode><bil:mode>L</bil:mode> </bil:inputAttributes><bil:sessionChangeRequest><ses:values>";
            header = header + "<ses:item><ses:key>BU_ID</ses:key>  <ses:value>2</ses:value></ses:item></ses:values> </bil:sessionChangeRequest></bil:billingAccountReadRequest></soapenv:Body></soapenv:Envelope>";

            return header;
        }

        private string getReadBillMediumXML(string user, string password)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:bil='http://ericsson.com/services/ws_CMI_7/billmediumread' xmlns:ses='http://ericsson.com/services/ws_CMI_7/sessionchange'>";
            header = header + "<soapenv:Header><Security><UsernameToken><Username>ADMX</Username><Password>ADMX</Password>  </UsernameToken></Security></soapenv:Header><soapenv:Body><bil:billMediumReadRequest>";
            header = header + "<bil:inputAttributes><bil:purpose></bil:purpose><bil:ignoreBuInd></bil:ignoreBuInd> </bil:inputAttributes> <bil:sessionChangeRequest><ses:values><ses:item>  <ses:key>BU_ID</ses:key><ses:value>2</ses:value></ses:item>";
            header = header + "</ses:values></bil:sessionChangeRequest></bil:billMediumReadRequest></soapenv:Body></soapenv:Envelope>";

            return header;
        }

        private string getSearchContractXML(string user, string password, string customerId)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:con='http://ericsson.com/services/ws_CIL_7/contractssearch' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>";
            header = header + "<soapenv:Header><cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'> <cwl_fullStack.bscsSecurity:UsernameToken>";
            header = header + "<cwl_fullStack.bscsSecurity:Username>" + user + "</cwl_fullStack.bscsSecurity:Username><cwl_fullStack.bscsSecurity:Password>" + password + "</cwl_fullStack.bscsSecurity:Password></cwl_fullStack.bscsSecurity:UsernameToken></cwl_fullStack.bscsSecurity:Security></soapenv:Header><soapenv:Body><con:contractsSearchRequest>";
            header = header + "<con:inputAttributes><con:searcher>SimpleContractSearch</con:searcher><con:csIdPub>" + customerId + "</con:csIdPub> </con:inputAttributes> <con:sessionChangeRequest><ses:values><ses:item><ses:key>BU_ID</ses:key><ses:value>2</ses:value></ses:item></ses:values> </con:sessionChangeRequest></con:contractsSearchRequest></soapenv:Body></soapenv:Envelope>";

            return header;
        }

        private string getReadContractXML(string user, string password, string contractId)
        {
            string header = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:con='http://ericsson.com/services/ws_CIL_7/contractread' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>";
            header = header + "<soapenv:Header><cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'> <cwl_fullStack.bscsSecurity:UsernameToken>";
            header = header + "<cwl_fullStack.bscsSecurity:Username>" + user + "</cwl_fullStack.bscsSecurity:Username><cwl_fullStack.bscsSecurity:Password>" + password + "</cwl_fullStack.bscsSecurity:Password></cwl_fullStack.bscsSecurity:UsernameToken></cwl_fullStack.bscsSecurity:Security></soapenv:Header><soapenv:Body>";
            header = header + "<con:contractReadRequest><con:inputAttributes><con:coId></con:coId><con:coIdPub>" + contractId + "</con:coIdPub><con:syncWithDb></con:syncWithDb> </con:inputAttributes><con:sessionChangeRequest><ses:values><ses:item><ses:key>BU_ID</ses:key><ses:value>2</ses:value></ses:item>";
            header = header + "</ses:values></con:sessionChangeRequest></con:contractReadRequest></soapenv:Body></soapenv:Envelope>";

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
