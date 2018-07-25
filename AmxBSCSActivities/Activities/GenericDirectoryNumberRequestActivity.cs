using AmxPeruCommonLibrary;
using AmxSoapServicesActivities.Business;
using AmxSoapServicesActivities.Model;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using Microsoft.Xrm.Sdk;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace AmxSoapServicesActivities.Activities
{

    public class GenericDirectoryNumberRequestActivity : XrmAwareCodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<GenericDirectoryNumberServiceRequest> DirectoryNumberServiceRequest { get; set; }
        public InArgument<string> HostUrl { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        public OutArgument<string> DirectoryNumberServiceResponse { get; set; }
        public OutArgument<string> SdpIdResponse { get; set; }
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var jsonResponseStr = "";
           
            if (DirectoryNumberServiceRequest.Get(context) != null)
            {
                string endPoint = HostUrl.Get(context);
                string userName = "ADMX";

                #region
                //using (var proxy = new AmxPeruGenericProxy<global::GenericDirectoryNumberSearchService>(endPoint, userName))
                //{
                //    //var genericDirectoryNumberSearchRequest = new genericDirectoryNumberSearchRequest
                //    //{
                //    //    inputAttributes = new inputAttributes
                //    //    {
                //    //        npcode = Convert.ToInt64(DirectoryNumberServiceRequest.Get(context).npcode),
                //    //        plcode = Convert.ToInt64(DirectoryNumberServiceRequest.Get(context).plcode),
                //    //        submId = Convert.ToInt64(DirectoryNumberServiceRequest.Get(context).submId),
                //    //        hlcode = Convert.ToInt64(DirectoryNumberServiceRequest.Get(context).hlcode),
                //    //        dntypes = new long[] { Convert.ToInt64(DirectoryNumberServiceRequest.Get(context).dnCode) },
                //    //        statuses = new string[] { DirectoryNumberServiceRequest.Get(context).dnStatus },
                //    //        searchCount = DirectoryNumberServiceRequest.Get(context).searchCount,
                //    //        reservation = DirectoryNumberServiceRequest.Get(context).reservation
                //    //    }
                //    //};
                //    var genericDirectoryNumberSearchRequest = new genericDirectoryNumberSearchRequest1(new genericDirectoryNumberSearchRequest
                //    {
                //        inputAttributes = new inputAttributes
                //        {
                //            plcode = Convert.ToInt64(DirectoryNumberServiceRequest.Get(context).plcode),
                //            npcode = Convert.ToInt64(DirectoryNumberServiceRequest.Get(context).npcode),
                //            submId = Convert.ToInt64(DirectoryNumberServiceRequest.Get(context).submId),
                //            hlcode = Convert.ToInt64(DirectoryNumberServiceRequest.Get(context).hlcode),
                //            dntypes = new long[] { Convert.ToInt64(DirectoryNumberServiceRequest.Get(context).dnCode) },
                //            statuses = new string[] { DirectoryNumberServiceRequest.Get(context).dnStatus },
                //            searchCount = DirectoryNumberServiceRequest.Get(context).searchCount,
                //            reservation = DirectoryNumberServiceRequest.Get(context).reservation
                //        }
                //    });
                //    var genericDirectoryNumberSearchResponse = proxy.Channel.genericDirectoryNumberSearch(genericDirectoryNumberSearchRequest);

                //    // var response = genericDirectoryNumberSearchResponse.directorynumbers;
                //    //DirectoryNumberServiceResponse.Set(context, response);

                //}
                #endregion
                jsonResponseStr = new GenericDirectoryNumberBusiness().GetDirectoryNumbers(DirectoryNumberServiceRequest.Get(context), HostUrl.Get(context), ContextProvider.OrganizationService);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(jsonResponseStr);
               
                ////XmlElement root = xmlDoc.DocumentElement;
                //XmlNode root = xmlDoc.DocumentElement;
                //XmlNodeList nodes = xmlDoc.SelectNodes("/item/item");
                //string mobileNumber = string.Empty;
                //foreach(XmlNode node in nodes)
                //{
                //    mobileNumber = node.InnerXml;
                //}

                string str = "<?xml version=\"1.0\"?>";
                jsonResponseStr = str + jsonResponseStr;
                var value = XDocument.Parse(jsonResponseStr);
                SOAPEnvelope deserializedObject;
                using (var reader = value.CreateReader(System.Xml.Linq.ReaderOptions.None))
                {
                    var ser = new XmlSerializer(typeof(SOAPEnvelope));
                    deserializedObject = (SOAPEnvelope)ser.Deserialize(reader);
                    string directorynumbers = deserializedObject.body.genericDirectoryNumberSearchResponse.directorynumbers[0].dirnum;
                    long sdp_id = deserializedObject.body.genericDirectoryNumberSearchResponse.directorynumbers[0].sdpId;
                    DirectoryNumberServiceResponse.Set(context, directorynumbers);
                    SdpIdResponse.Set(context, sdp_id.ToString());

                }

               

            }
           
        }

    }



}
