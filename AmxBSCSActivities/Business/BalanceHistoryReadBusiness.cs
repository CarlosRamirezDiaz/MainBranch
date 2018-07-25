using AmxSoapServicesActivities.Model;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.IO;
using System.Net;

namespace AmxSoapServicesActivities.Business.BalanceEnquiry
{
    public class BalanceHistoryReadBusiness
    {
        /// <summary>
        /// This method is to fetch the BalanceHistoryRead from BSCS System
        /// </summary>
        /// <param name="balanceHistoryReadRequest">Input params need to send for bscs system</param>
        /// <param name="hostUrl">BSCS Request Url</param>
        /// <param name="service">CRM Service</param>
        /// <returns></returns>
        public string GetBalanceHistoryReadDetails(BalanceHistoryReadRequest balanceHistoryReadRequest, string hostUrl, OrganizationServiceProxy service)
        {
            var jsonResponse = "";
            if (balanceHistoryReadRequest != null)
            {
                string balanceHistoryReadXml = GetBalanceHistoryReadXML(balanceHistoryReadRequest);
                jsonResponse = GetJsonResponse(balanceHistoryReadXml, hostUrl, service);
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

        public string GetBalanceHistoryReadXML(BalanceHistoryReadRequest balanceHistoryReadRequest)
        {
            string soapEnvelope = string.Empty;
            string buId = "BU_ID";
            int sesValue = 2;

            soapEnvelope = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:bal='http://ericsson.com/services/ws_CIL_7/balancehistoryread' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>" +
            "<soapenv:Header>" +
                   "<Security xmlns='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>" +
            "<UsernameToken>" +
               "<Username>ADMX</Username>" +
               "<Password>ADMX</Password>" +
            "</UsernameToken>" +
         "</Security>" +
  "</soapenv:Header>" +
  "<soapenv:Body>" +
     "<bal:balanceHistoryReadRequest>" +
        "<bal:inputAttributes>" +
           "<bal:coId>" + balanceHistoryReadRequest.coId + "</bal:coId>" +
           "<bal:coIdPub>" + balanceHistoryReadRequest.coIdPub + "</bal:coIdPub>" +
           "<bal:profileId>" + balanceHistoryReadRequest.profileId + "</bal:profileId>" +
           "<bal:sncode>" + balanceHistoryReadRequest.sncode + "</bal:sncode>" +
           "<bal:sncodePub>" + balanceHistoryReadRequest.sncodePub + "</bal:sncodePub>" +
           "<bal:seqNo>" + balanceHistoryReadRequest.seqNo + "</bal:seqNo>" +
           "<bal:snapFromDate>" + balanceHistoryReadRequest.snapFromDate + "</bal:snapFromDate>" +
           "<bal:snapEndDate>" + balanceHistoryReadRequest.snapEndDate + "</bal:snapEndDate>" +
           "<bal:searchLimit>" + balanceHistoryReadRequest.searchLimit + "</bal:searchLimit>" +
           "<bal:csId>" + balanceHistoryReadRequest.csId + "</bal:csId>" +
           "<bal:csIdPub>" + balanceHistoryReadRequest.csIdPub + "</bal:csIdPub>" +
           "<bal:bpId>" + balanceHistoryReadRequest.bpId + "</bal:bpId>" +
           "<bal:memberCoId>" + balanceHistoryReadRequest.memberCoId + "</bal:memberCoId>" +
           "<bal:memberCoIdPub>" + balanceHistoryReadRequest.memberCoIdPub + "</bal:memberCoIdPub>" +
           "<bal:cfssId>" + balanceHistoryReadRequest.cfssId + "</bal:cfssId>" +
           "<bal:spcode>" + balanceHistoryReadRequest.spcode + "</bal:spcode>" +
           "<bal:productofferingId>" + balanceHistoryReadRequest.productofferingId + "</bal:productofferingId>" +
           "<bal:productId>" + balanceHistoryReadRequest.productId + "</bal:productId>" +
           "<bal:suppressReratedBirs>" + balanceHistoryReadRequest.suppressReratedBirs + "</bal:suppressReratedBirs>" +
           "<bal:accountId>" + balanceHistoryReadRequest.accountId + "</bal:accountId>" +
           "<bal:accountTypeId>" + balanceHistoryReadRequest.accountTypeId + "</bal:accountTypeId>" +
           "<bal:accountTypeIdPub>" + balanceHistoryReadRequest.accountTypeIdPub + "</bal:accountTypeIdPub>" +
           "<bal:excludeIndividualUc>" + balanceHistoryReadRequest.excludeIndividualUc + "</bal:excludeIndividualUc>" +
           "<bal:balanceSpecificationId>" + balanceHistoryReadRequest.balanceSpecificationId + "</bal:balanceSpecificationId>" +
           "<bal:excludeTechnicalBalances>" + balanceHistoryReadRequest.excludeTechnicalBalances + "</bal:excludeTechnicalBalances>" +
        "</bal:inputAttributes>" +
        "<!--Optional:-->" +
        "<bal:sessionChangeRequest>" +
           "<!--Optional:-->" +
           "<ses:values>" +
              "<!--1 or more repetitions:-->" +
              "<ses:item>" +
                 "<!--You may enter the following 2 items in any order-->" +
                 "<ses:key>" + buId + "</ses:key>" +
                 "<ses:value>" + sesValue + "</ses:value>" +
              "</ses:item>" +
           "</ses:values>" +
        "</bal:sessionChangeRequest>" +
     "</bal:balanceHistoryReadRequest>" +
  "</soapenv:Body>" +
"</soapenv:Envelope>";
            return soapEnvelope;
        }
    }
}
