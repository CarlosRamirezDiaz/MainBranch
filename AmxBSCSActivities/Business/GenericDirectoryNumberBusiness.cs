using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.Xrm.Sdk.Client;
using AmxSoapServicesActivities.Model;
using AmxSoapServicesActivities.XmlStrings;
using AmxSoapServicesActivities.Activities;
using System.Xml.Linq;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace AmxSoapServicesActivities.Business
{
    public class GenericDirectoryNumberBusiness
    {
        public string GetDirectoryNumbers(GenericDirectoryNumberServiceRequest directoryNumberRequest, string hostUrl, OrganizationServiceProxy service)
        {
            var jsonResponse = "";
            if (directoryNumberRequest.npcode != null && directoryNumberRequest.plcode != null && directoryNumberRequest.submId != null && directoryNumberRequest.hlcode != null && directoryNumberRequest.dnCode != null && directoryNumberRequest.dnStatus != null && directoryNumberRequest.searchCount != null && directoryNumberRequest.reservation == true)
            {
                string directoryNumberRequestXml = new GenericDirectoryNumberRequestXml().GetXmlrequest(directoryNumberRequest.npcode, directoryNumberRequest.plcode, directoryNumberRequest.submId, directoryNumberRequest.hlcode, directoryNumberRequest.dnCode, directoryNumberRequest.dnStatus, directoryNumberRequest.searchCount, directoryNumberRequest.reservation);
                jsonResponse = GetGenericDirectoryNumberDetails(directoryNumberRequestXml, hostUrl, service);
                
            }
            return jsonResponse;
        }
        public string GetGenericDirectoryNumberDetails(string xml, string url, OrganizationServiceProxy service)
        {
            string soapResult = string.Empty;
            // AMXCommon.Common common = new AMXCommon.Common();
            // HttpWebRequest webRequest = common.CreateWebRequest(url);
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
        
    }
}
