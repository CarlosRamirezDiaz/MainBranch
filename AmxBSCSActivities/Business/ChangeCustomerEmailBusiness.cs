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
using System.Xml.Serialization;

namespace AmxSoapServicesActivities.Business
{
    public class ChangeCustomerEmailBusiness
    {
        //public string PutCustomerChangeEmail(AmxCoCustomerChangeEmailRequest customerChangeEmailRequest, string hostUrl, OrganizationServiceProxy service,string str_LName,string str_FName,string str_Scode)
        public string PutCustomerChangeEmail(CustomerChangeEmailRequest customerChangeEmailRequest, string hostUrl, OrganizationServiceProxy service)
        {
            var xmlResponse = "";
            

            //string CustomerChangeEmailXml = new AmxCoChangeCustomerEmailRequestXml().GetXmlrequest(customerChangeEmailRequest.inputAttributes.customersNew.paymentResp,
            //        customerChangeEmailRequest.inputAttributes.customersNew.prgCode, customerChangeEmailRequest.inputAttributes.customersNew.rpcode,
            //        customerChangeEmailRequest.inputAttributes.customersNew.csBillcycle, customerChangeEmailRequest.inputAttributes.paymentArrangementWrite.cspPmntId,
            //        customerChangeEmailRequest.inputAttributes.addresses.Item.AddressWrite.adrSeq, customerChangeEmailRequest.inputAttributes.addresses.Item.AddressWrite.adrLname,
            //        customerChangeEmailRequest.inputAttributes.addresses.Item.AddressWrite.adrFname, customerChangeEmailRequest.inputAttributes.addresses.Item.AddressWrite.adrStreet,
            //        customerChangeEmailRequest.inputAttributes.addresses.Item.AddressWrite.adrStreetno, customerChangeEmailRequest.inputAttributes.addresses.Item.AddressWrite.adrZip,
            //        customerChangeEmailRequest.inputAttributes.addresses.Item.AddressWrite.adrCity,customerChangeEmailRequest.inputAttributes.customerWrite.paymentResp,
            //        customerChangeEmailRequest.inputAttributes.customerWrite.csStatus, customerChangeEmailRequest.inputAttributes.customerWrite.rsCode,
            //        customerChangeEmailRequest.inputAttributes.customersNew.externalCustomerId);

            string CustomerChangeEmailXml = new ChangeCustomerEmailRequestXml().GetXmlrequest(customerChangeEmailRequest.customerId,customerChangeEmailRequest.email);
            xmlResponse = PutCustomerChangeEmailDetails(CustomerChangeEmailXml, hostUrl, service);

            
            return xmlResponse;
        }
        public string PutCustomerChangeEmailDetails(string xml, string url, OrganizationServiceProxy service)
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

    }
}
