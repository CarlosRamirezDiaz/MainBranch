using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web.Script.Serialization;

namespace AMXCommon
{
    public class Common
    {
        public void CreateExceptionLog(IOrganizationService service, object request, string sourceName, string exceptionMessage)
        {
            var jsonSerializeReq = new JavaScriptSerializer().Serialize(request);
            Entity logEntity = new Entity("etel_exceptionlog");
            logEntity.Attributes.Add("etel_name", "Create_App_Test_" + DateTime.Now);
            logEntity.Attributes.Add("etel_stacktrace", jsonSerializeReq);
            logEntity.Attributes.Add("etel_sourcesystem", sourceName);
            logEntity.Attributes.Add("etel_server", "psb_hostServer");
            logEntity.Attributes.Add("etel_innerexceptionmessage", exceptionMessage);
            logEntity.Id = service.Create(logEntity);
        }

        public string RetrieveCrmConfiguration(string keyName, IOrganizationService service)
        {
            if (string.IsNullOrEmpty(keyName))
                return string.Empty;

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_crmconfiguration",
                ColumnSet = new ColumnSet(new string[] { "etel_name", "etel_value" }),
                Criteria = {
                     Conditions = {
                         new ConditionExpression("etel_name", ConditionOperator.Equal, keyName)
                    }
                }
            };
            EntityCollection collection = service.RetrieveMultiple(query);
            if (collection == null || collection.Entities.Count == 0)
                return string.Empty;

            return collection.Entities[0].GetAttributeValue<string>("etel_value");
        }

        public BasicHttpBinding GetSoapServiceBasicHttpBinding() {
            BasicHttpBinding binding = new BasicHttpBinding {
                Name = "vpPOMAgentAPIServiceBinding",
                OpenTimeout = new TimeSpan(0, 15, 0),
                CloseTimeout = new TimeSpan(0, 15, 0),
                ReceiveTimeout = new TimeSpan(0, 15, 0),
                SendTimeout = new TimeSpan(0, 15, 0)
            };
            return binding;
        }

        /// <summary>
        /// This method formats the response as per the incoming Request Type
        /// If the incoming request is of type XML, the output will be formatted to XML
        /// If the incoming request is of type JSON, the output will be formatted to JSON
        /// </summary>
        public static void FormatResponse()
        {
            try
            {
                if (WebOperationContext.Current.IncomingRequest.ContentType.Contains("xml"))
                {
                    WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
                }
                else if (WebOperationContext.Current.IncomingRequest.ContentType.Contains("json"))
                {
                    WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Custom Response Format Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Get the date string with Format YYYY-MM-DD
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string GetDateStringYYYYMMDD(DateTime date)
        {
            var dateStr = string.Empty;
            dateStr = date.Year.ToString() + "-" +
                (date.Month.ToString().Length > 1 ? date.Month.ToString() : "0" + date.Month.ToString()) + "-" +
                (date.Day.ToString().Length > 1 ? date.Day.ToString() : "0" + date.Day.ToString());
            return dateStr;
        }

        #region Wipro Methods
        /// <summary>
        /// This method is to generate the http web request with wsdl url
        /// </summary>
        /// <param name="url">API Url</param>
        /// <returns>http webrequest object</returns>
        public HttpWebRequest CreateWebRequest(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        /// <summary>
        /// This method used to to get the amx configuration record value by passing the key name
        /// </summary>
        /// <param name="keyName">name of the record</param>
        /// <param name="service">CRM Service</param>
        /// <returns></returns>
        public string RetrieveAmxCrmConfiguration(string keyName, IOrganizationService service)
        {
            if (string.IsNullOrEmpty(keyName))
                return string.Empty;

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "amxperu_amxconfigurations",
                ColumnSet = new ColumnSet(new string[] { "amxperu_name", "amxperu_value" }),
                Criteria = {
                     Conditions = {
                         new ConditionExpression("amxperu_name", ConditionOperator.Equal, keyName)
                    }
                }
            };
            EntityCollection collection = service.RetrieveMultiple(query);
            if (collection == null || collection.Entities.Count == 0)
                return string.Empty;

            return collection.Entities[0].GetAttributeValue<string>("amxperu_value") != string.Empty ? collection.Entities[0].GetAttributeValue<string>("amxperu_value") : string.Empty;
        }
       
        #endregion
    }
}
