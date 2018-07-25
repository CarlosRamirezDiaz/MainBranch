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


namespace AmxPeruPSBActivities.AMXCOLOMBIA.Business.BillCycleChange
{
    public class AmxCoBillCycleReadBusiness
    {
        /// <summary>
        /// This method is to fetch the bill cycles from BSCS System
        /// </summary>
        /// <param name="billCycleRequest">Input params need to send for bscs system</param>
        /// <param name="hostUrl">BSCS Request Url</param>
        /// <param name="service">CRM Service</param>
        /// <returns></returns>
        public string GetBillCycleChangeDetails(AmxCoBillCycleReadServiceRequest billCycleRequest, string hostUrl, OrganizationServiceProxy service)
        {
            var jsonResponse = "";
            if (billCycleRequest.partyType != null)
            {
                string billCycleXml = GetBillCycleReadXML(billCycleRequest.partyType, billCycleRequest.readAll);
                jsonResponse = GetBillCycleChangeDetails(billCycleXml, hostUrl, service);
            }
            return jsonResponse;
        }

        /// <summary>
        /// This method is to retrieve the all Bill Cycles from BSCS System.
        /// </summary>
        /// <param name="xml">Bill cycle request xml</param>
        /// <param name="url">BSCS Request Url</param>
        /// <param name="service">CRM Service</param>
        /// <returns></returns>
        public string GetBillCycleChangeDetails(string xml, string url, OrganizationServiceProxy service)
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
            //JavaScriptSerializer javascriptSerializer = new JavaScriptSerializer();
            //string responseString = javascriptSerializer.Serialize(soapResult);
            return soapResult;
        }

       

        public string GetBillCycleReadXML(string partyType, bool readAll)
        {
            string soapEnvelope = string.Empty;

            string buId = "BU_ID";
            int sesValue = 2;

            soapEnvelope = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:bil='http://ericsson.com/services/ws_CMI_7/billcyclesread' xmlns:ses='http://ericsson.com/services/ws_CMI_7/sessionchange'>" +
            "<soapenv:Header>" +
              "<cwl_fullStack.bscsSecurity:Security xmlns:cwl_fullStack.bscsSecurity='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:xsi = 'http://www.w3.org/2001/XMLSchema-instance'>" +
                   "<cwl_fullStack.bscsSecurity:UsernameToken>" +
                        "<cwl_fullStack.bscsSecurity:Username>ADMX</cwl_fullStack.bscsSecurity:Username>" +
                              "<cwl_fullStack.bscsSecurity:Password> ADMX</cwl_fullStack.bscsSecurity:Password>" +
                                "</cwl_fullStack.bscsSecurity:UsernameToken>" +
                              "</cwl_fullStack.bscsSecurity:Security>" +
                            "</soapenv:Header>" +
                             "<soapenv:Body>" +
                                 "<bil:billCyclesReadRequest>" +
                                     "<bil:inputAttributes>" +
                                        "<bil:partyType>" + partyType + "</bil:partyType>" +
                                             "<bil:readAll>" + readAll + "</bil:readAll>" +
                                                "</bil:inputAttributes>" +
                                                 "<bil:sessionChangeRequest>" +
                                                     "<ses:values>" +
                                                         "<ses:item>" +
                                                             "<ses:key>" + buId + "</ses:key>" +
                                                                  "<ses:value>" + sesValue + "</ses:value>" +
                                                                    "</ses:item>" +
                                                                  "</ses:values>" +
                                                                "</bil:sessionChangeRequest>" +
                                                              "</bil:billCyclesReadRequest>" +
                                                            "</soapenv:Body>" +
                                                          "</soapenv:Envelope>";
            return soapEnvelope;
        }
    }
}
