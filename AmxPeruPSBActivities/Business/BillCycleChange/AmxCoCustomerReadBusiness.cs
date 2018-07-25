using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle;
using Microsoft.Xrm.Sdk.Client;
using Newtonsoft.Json;
using RestSharp;
using AMXCommon;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Business.BillCycleChange
{
    public class AmxCoCustomerReadBusiness
    {
        /// <summary>
        /// This method is used to build the customer soap xml and to fetch the customer data from bscs system
        /// </summary>
        /// <param name="customerRequest"></param>
        /// <param name="hostUrl"></param>
        /// <param name="service"></param>
        /// <returns>customer data from bscs</returns>
        public string GetCustomerBillDetails(AmxCoCustomerReadServiceRequest customerRequest, string hostUrl, OrganizationServiceProxy service)
        {
            var jsonResponse = "";
            if (customerRequest.csIdPub != null)
            {
                string customerXml = GetCustomerReadXml(customerRequest.csIdPub, customerRequest.csId);
                jsonResponse = GetCustomerBillingAccounts(customerXml, hostUrl, service);
            }
            return jsonResponse;
        }

      

        /// <summary>
        /// This method is to fetch the customer data from bscs using soap request
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="url"></param>
        /// <returns>customerDetails from bscs</returns>
        public string GetCustomerBillingAccounts(string xml, string url, OrganizationServiceProxy service)
        {
            string soapResult = string.Empty;
            AMXCommon.Common common = new AMXCommon.Common();
            HttpWebRequest webRequest = common.CreateWebRequest(url);
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

        /// <summary>
        /// This method is to return the customer read xml document
        /// </summary>
        /// <param name="customerPub"></param>
        /// <param name="customerId"></param>
        /// <returns>customer xml document</returns>
        public string GetCustomerReadXml(string customerPub, int? customerId)
        {
            string buId = "BU_ID";
            string syncDB = "";
            string custXml = "<soapenv:Envelope xmlns:soapenv = 'http://schemas.xmlsoap.org/soap/envelope/' xmlns:cus = 'http://ericsson.com/services/ws_CIL_7/customerread' xmlns:ses = 'http://ericsson.com/services/ws_CIL_7/sessionchange'>" +
      "<soapenv:Header>" +
      "<Security xmlns='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>" +
         "<UsernameToken>" +
            "<Username>ADMX</Username>" +
             "<Password>ADMX</Password>" +
           "</UsernameToken>" +
        "</Security>" +
     "</soapenv:Header>" +
     "<soapenv:Body>" +
        "<cus:customerReadRequest>" +
           "<cus:inputAttributes>" +
              "<cus:csId>" + customerId + "</cus:csId>" +
              "<cus:csIdPub>" + customerPub + "</cus:csIdPub>" +
               "<cus:syncWithDb>" + syncDB + "</cus:syncWithDb>" +
            "</cus:inputAttributes>" +
            "<cus:sessionChangeRequest>" +
               "<ses:values>" +
                  "<ses:item>" +
                     "<ses:key>" + buId + "</ses:key>" +
                      "<ses:value>2</ses:value>" +
                    "</ses:item>" +
                 "</ses:values>" +
              "</cus:sessionChangeRequest>" +
           "</cus:customerReadRequest>" +
        "</soapenv:Body>" +
     "</soapenv:Envelope>";

            return custXml;
        }
    }
}
