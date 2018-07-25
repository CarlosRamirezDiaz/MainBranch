using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using ExternalApiActivities.Common;
using AmxSoapServicesActivities.ContractsSearchService;
using System.Activities;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruCommonLibrary;
using System.Web.Services;
using System.Web.Services.Protocols;
using AmxSoapServicesActivities.Model;
using System.ServiceModel;
using Ericsson.PSB.Workflow.Client.Core;
using AmxPeruPSBActivities.Repository;
using System.Net;
using System.IO;

namespace AmxSoapServicesActivities.Business
{
    public class ContractsSearchBusiness
    {
        public List<AmxSoapServicesActivities.Model.ContractsSearchResponse> contractsSearchById(string bscsURL, Guid individualCustomerId, UserIdentityExtension identityExtension, OrganizationServiceProxy _org)
        {
            var individualRepository = new IndividualCustomerRepository(_org);
            var individual = individualRepository.GetById(individualCustomerId);
            if (individual.IndividualCustomerId == Guid.Empty)
                throw new Exception("Individual Customer not found for Id: " + individualCustomerId);
            string customerExternalId = individual.CustomerId;

            var _inputAttr = new ContractsSearchService.inputAttributes()
            {
                searcher = "SimpleContractSearch",
                csIdPub = customerExternalId
            };

            var request = new contractsSearchRequest();
            request.inputAttributes = _inputAttr;

            var response = ContractsSearch(bscsURL, request, identityExtension);

            return response;
        }
        public List<AmxSoapServicesActivities.Model.ContractsSearchResponse> contractsSearchByDirnum(string bscsURL, string Dirnum, UserIdentityExtension identityExtension, OrganizationServiceProxy _org)
        {

            var _inputAttr = new ContractsSearchService.inputAttributes()
            {
                dirnum = Dirnum
            };

            var request = new contractsSearchRequest();
            request.inputAttributes = _inputAttr;

            var response= ContractsSearch(bscsURL, request, identityExtension);

            return response;
        }

        

        public List<AmxSoapServicesActivities.Model.ContractsSearchResponse> ContractsSearch(string bscsURL, contractsSearchRequest contractRequest, UserIdentityExtension identityExtension)
        {
            var endPoint = bscsURL;
            var contractSearchBusiness = new AmxSoapServicesActivities.Business.ContractsSearchBusiness();
            const string _sessionBU_ID_Key = "BU_ID";
            const string _sessionBU_ID_Value = "2";

            using (var factory = new AmxPeruGenericProxy<AmxSoapServicesActivities.ContractsSearchService.ContractsSearchService>(endPoint, identityExtension.GetIdentity().Name))
            {

                //start to create session change Req
                var _sessionChangeReq = new ContractsSearchService.sessionChangeRequest();
                var _sessionChangeValues = new List<ContractsSearchService.valuesListpartRequest>();
                _sessionChangeValues.Add(new ContractsSearchService.valuesListpartRequest()
                {
                    key = _sessionBU_ID_Key,
                    value = _sessionBU_ID_Value
                });
                _sessionChangeReq.values = _sessionChangeValues.ToArray();

                contractRequest.sessionChangeRequest = _sessionChangeReq;

                contractsSearchResponse1 response = new contractsSearchResponse1();

                try
                {
                    response = factory.Channel.contractsSearch(new contractsSearchRequest1()
                    {
                        contractsSearchRequest = contractRequest
                    });

                    int x = response.contractsSearchResponse.contracts.Count();

                    List<AmxSoapServicesActivities.Model.ContractsSearchResponse> resp = new List<AmxSoapServicesActivities.Model.ContractsSearchResponse>();
                    for (int i = 0; i < x; i++)
                    {
                        AmxSoapServicesActivities.Model.ContractsSearchResponse respmsg = new AmxSoapServicesActivities.Model.ContractsSearchResponse();
                        respmsg.contractTypeId = response.contractsSearchResponse.contracts[i].contractTypeId.ToString();
                        respmsg.buId = response.contractsSearchResponse.contracts[i].buId.ToString();
                        respmsg.coStatus = response.contractsSearchResponse.contracts[i].coStatus.ToString();
                        respmsg.dirnum = response.contractsSearchResponse.contracts[i].dirnum.ToString();
                        respmsg.plcode = response.contractsSearchResponse.contracts[i].plcode.ToString();
                        respmsg.rpcode = response.contractsSearchResponse.contracts[i].rpcode.ToString();
                        respmsg.coActivated = response.contractsSearchResponse.contracts[i].coStatus;
                        respmsg.coId = response.contractsSearchResponse.contracts[i].coId.ToString();
                        respmsg.coIdPub = response.contractsSearchResponse.contracts[i].coIdPub.ToString();
                        respmsg.currentDn = response.contractsSearchResponse.contracts[i].currentDn;
                        respmsg.dnPending = response.contractsSearchResponse.contracts[i].dnPending;
                        respmsg.paymentMethodInd = response.contractsSearchResponse.contracts[i].paymentMethodInd;
                        respmsg.csCode = response.contractsSearchResponse.contracts[i].csCode;
                        respmsg.submId = response.contractsSearchResponse.contracts[i].submId.ToString();
                        respmsg.externalind = response.contractsSearchResponse.contracts[i].externalind;
                        respmsg.hlcode = response.contractsSearchResponse.contracts[i].hlcode.ToString();
                        respmsg.csId = response.contractsSearchResponse.contracts[i].csId.ToString();
                        respmsg.csIdPub = response.contractsSearchResponse.contracts[i].csIdPub;
                        respmsg.paymentResp = response.contractsSearchResponse.contracts[i].paymentResp;
                        respmsg.csContrResp = response.contractsSearchResponse.contracts[i].csContrResp;

                        resp.Add(respmsg);
                    }

                    /*var resposta = new AmxSoapServicesActivities.Model.ContractsSearchResponse();
                    List<AmxSoapServicesActivities.Model.Contract> resp = new List<AmxSoapServicesActivities.Model.Contract>();
                    Model.Contract respmsg = new Model.Contract();

                    resposta.contracts.Add(new Model.Contract
                    {
                        buId = "",
                        coActivated = ""
                    });

                    if (x != 0)
                    {

                        for (int i = 0; i < x; i++)
                        {
                            respmsg.contractTypeId = response.contractsSearchResponse.contracts[i].contractTypeId.ToString();
                            respmsg.buId = response.contractsSearchResponse.contracts[i].buId.ToString();
                            respmsg.coStatus = response.contractsSearchResponse.contracts[i].coStatus.ToString();
                            respmsg.dirnum = response.contractsSearchResponse.contracts[i].dirnum.ToString();
                            respmsg.plcode = response.contractsSearchResponse.contracts[i].plcode.ToString();
                            respmsg.rpcode = response.contractsSearchResponse.contracts[i].rpcode.ToString();
                            respmsg.coActivated = response.contractsSearchResponse.contracts[i].coStatus;
                            respmsg.coId = response.contractsSearchResponse.contracts[i].coId.ToString();
                            respmsg.coIdPub = response.contractsSearchResponse.contracts[i].coIdPub.ToString();
                            respmsg.currentDn = response.contractsSearchResponse.contracts[i].currentDn;
                            respmsg.dnPending = response.contractsSearchResponse.contracts[i].dnPending;
                            respmsg.paymentMethodInd = response.contractsSearchResponse.contracts[i].paymentMethodInd;
                            //respmsg(new AmxSoapServicesActivities.Model.Contract
                            //resposta.contracts.Add(new AmxSoapServicesActivities.Model.Contract
                            /*{ 
                                contractTypeId = response.contractsSearchResponse.contracts[i].contractTypeId.ToString(),
                                buId = response.contractsSearchResponse.contracts[i].buId.ToString(),
                                coStatus = response.contractsSearchResponse.contracts[i].coStatus.ToString(),
                                dirnum = response.contractsSearchResponse.contracts[i].dirnum.ToString(),
                                plcode = response.contractsSearchResponse.contracts[i].plcode.ToString(),
                                rpcode = response.contractsSearchResponse.contracts[i].rpcode.ToString(),
                                coActivated = response.contractsSearchResponse.contracts[i].coStatus,
                                coId = response.contractsSearchResponse.contracts[i].coId.ToString(),
                                coIdPub = response.contractsSearchResponse.contracts[i].coIdPub.ToString(),
                                currentDn = response.contractsSearchResponse.contracts[i].currentDn,
                                dnPending = response.contractsSearchResponse.contracts[i].dnPending,
                                paymentMethodInd = response.contractsSearchResponse.contracts[i].paymentMethodInd
                            });
                            //resposta.contracts.Add(respmsg);
                            resp.Add(respmsg);
                        }*/



                    //resposta.contracts.Add(new Model.Contract { contractTypeId = "xxxx" });
                    //resposta.contracts.Add(new Model.Contract { contractTypeId = "yyyy" });
                    //resposta.contracts.Add(respmsg);
                    //string json = JsonConvert.SerializeObject(resp, Formatting.Indented);

                    return resp;
                }
                catch (Exception ex)
                {
                    //var resposta = new AmxSoapServicesActivities.Model.ContractsSearchResponse();
                    //return resposta;
                    List<AmxSoapServicesActivities.Model.ContractsSearchResponse> resp = new List<AmxSoapServicesActivities.Model.ContractsSearchResponse>();
                    return resp;

                }
            }
        }

        /// <summary>
        /// This method is to fetch the ContractsSearch from BSCS System
        /// </summary>
        /// <param name="contractsSearchRequest">Input params need to send for bscs system</param>
        /// <param name="hostUrl">BSCS Request Url</param>
        /// <param name="service">CRM Service</param>
        /// <returns></returns>
        public string GetContractsSearchDetails(ContractsSearchRequest contractsSearchRequest, string hostUrl, OrganizationServiceProxy service)
        {
            var jsonResponse = "";
            if (contractsSearchRequest.csIdPub != null)
            {
                string contractsSearchXml = GetContractsSearchXML(contractsSearchRequest.csIdPub, contractsSearchRequest.searcher);
                jsonResponse = GetJsonResponse(contractsSearchXml, hostUrl, service);
            }
            return jsonResponse;
        }

        /// <summary>
        /// This method is to retrieve the all ContractsSearch from BSCS System.
        /// </summary>
        /// <param name="xml">Request xml</param>
        /// <param name="url">BSCS Request Url</param>
        /// <param name="service">CRM Service</param>
        /// <returns></returns>
        public string GetJsonResponse(string xml, string url, OrganizationServiceProxy service)
        {
            string soapResult = string.Empty;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";

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

        public string GetContractsSearchXML(string csIdPub, string searcher)
        {
            string buId = "BU_ID";
            int sesValue = 2;
            string soapEnvelope = string.Empty;

            soapEnvelope = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:con='http://ericsson.com/services/ws_CIL_7/contractssearch' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>" +
    "<soapenv:Header>" +
      "<cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>" +
         "<cwl_fullStack.bscsSecurity:UsernameToken>" +
            "<cwl_fullStack.bscsSecurity:Username>ADMX</cwl_fullStack.bscsSecurity:Username>" +
            "<cwl_fullStack.bscsSecurity:Password>ADMX</cwl_fullStack.bscsSecurity:Password>" +
         "</cwl_fullStack.bscsSecurity:UsernameToken>" +
      "</cwl_fullStack.bscsSecurity:Security>" +
    "</soapenv:Header>" +
    "<soapenv:Body>" +
      "<con:contractsSearchRequest>" +
         "<!--You may enter the following 2 items in any order-->" +
         "<!--Optional:-->" +
         "<con:inputAttributes>" +
            "<!--You may enter the following 91 items in any order-->a" +
            "<!--Optional:-->" +
             "<con:searcher>" + searcher + "</con:searcher>" +
            "<con:csIdPub>" + csIdPub + "</con:csIdPub> " +
             "<!--Optional:-->" +
         "</con:inputAttributes>" +
         "<!--Optional:-->" +
         "<con:sessionChangeRequest>" +
            "<!--Optional:-->" +
            "<ses:values>" +
               "<!--1 or more repetitions:-->" +
               "<ses:item>" +
                  "<!--You may enter the following 2 items in any order-->" +
                  "<ses:key>" + buId + "</ses:key>" +
                  "<ses:value>" + sesValue + "</ses:value>" +
               "</ses:item>" +
            "</ses:values>" +
         "</con:sessionChangeRequest>" +
      "</con:contractsSearchRequest>" +
    "</soapenv:Body>" +
    "</soapenv:Envelope>";
            return soapEnvelope;
        }
    }
}