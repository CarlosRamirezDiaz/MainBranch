using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AmxPeruPSBActivities.Business
{
    public class AmxPeruBillCycleChangefromOMBusiness
    {
        public AmxPeruBillCycleChangefromOMResponse AmxPeruBillCycleChangefromOMValues(AmxPeruBillCycleChangefromOMRequest request, OrganizationServiceProxy OrgService)
        {
            AmxPeruBillCycleChangefromOMResponse _AmxPeruBillCycleChangefromOMResponse = null;

            try
            {
                _AmxPeruBillCycleChangefromOMResponse = new AmxPeruBillCycleChangefromOMResponse();
                if (request != null)
                {

                    //Entity contactEntity=  OrgService.Retrieve("contact", new Guid(request.relatedParties[0].reference), new ColumnSet("etel_externalid"));
                    //  if (contactEntity.Contains("etel_externalid"))
                    //  {
                    //      request.relatedParties[0].reference=  contactEntity.Attributes["etel_externalid"].ToString();
                    //  }

                    dynamic obj = new { request = request };
                    obj = request;
                    var data = new JavaScriptSerializer().Serialize(request);
                    string url = string.Empty;
                    url = GetEocURl("EOC Bill Cycle Change Url", OrgService);
                    using (var client = new WebClient { UseDefaultCredentials = true })
                    {
                        client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                        //   byte[] responseObj = client.UploadData("http://10.103.27.172:8080/eoc/om/v1/order", "POST", Encoding.UTF8.GetBytes(data));
                        byte[] responseObj = client.UploadData(url, "POST", Encoding.UTF8.GetBytes(data));
                        string responseString = System.Text.Encoding.UTF8.GetString(responseObj);
                        var res = new JavaScriptSerializer().Deserialize<AmxPeruBillCycleChangefromOMResponse>(responseString);
                        _AmxPeruBillCycleChangefromOMResponse = (AmxPeruBillCycleChangefromOMResponse)res;
                    }


                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return _AmxPeruBillCycleChangefromOMResponse;
        }

        public Guid GetLookupGuidFromField(string entityName, string columnName, string columnValue, OrganizationServiceProxy OrgService)
        {
            QueryExpression retrieveQuery = new QueryExpression(entityName);
            retrieveQuery.Criteria.AddCondition(columnName, ConditionOperator.Equal, columnValue);
            EntityCollection retrievedCollection = OrgService.RetrieveMultiple(retrieveQuery);

            if (retrievedCollection.Entities.Count >= 1)
            {
                return retrievedCollection.Entities.First().Id;
            }

            return Guid.Empty;
        }
        public string GetEocURl(string name, OrganizationServiceProxy OrgService)
        {
        string Url = string.Empty;
            QueryExpression retrieveUrl = new QueryExpression("amxperu_amxconfigurations");
            retrieveUrl.ColumnSet = new ColumnSet("amxperu_value");
            retrieveUrl.Criteria = new FilterExpression();
            //EOC Bill Cycle Change Url
            retrieveUrl.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, name);
            EntityCollection retrieveCollection = OrgService.RetrieveMultiple(retrieveUrl);
            if(retrieveCollection.Entities.Count >= 1)
            {
               // Url = retrieveCollection.Entities;
                Url= retrieveCollection[0].GetAttributeValue<string>("amxperu_value");
            }
        return Url;
        }


    }
}
