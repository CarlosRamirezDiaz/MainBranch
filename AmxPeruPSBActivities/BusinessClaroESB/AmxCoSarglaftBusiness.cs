using AmxCoPSBActivities.ModelClaroESB.Sarglaft;
using Microsoft.Xrm.Sdk.Client;
using Newtonsoft.Json;
using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace AmxCoPSBActivities.BusinessClaroESB
{
    public class AmxCoSarglaftBusiness
    {
        public string ConsultLists(string sarglaftURL, string fullName, string customerId, int punctuation, OrganizationServiceProxy _org)
        {
            var common = new AmxCoPSBActivities.BusinessClaroESB.AmxCoClaroESBCommon(_org);

            var request = ConsultListsRequest.ConsultListsRequestFactory(fullName, customerId, punctuation, _org);

            string jsonRequest = null;
            string jsonResponse = null;
            string error = null;
            string response = string.Empty;

            ConsultListsResponse sarglaftResponse = null;
            if (common.RestCall<ConsultListsRequest>(sarglaftURL, request, out jsonRequest, out jsonResponse, out error, "PUT", "ConsultLists"))
            {
                try
                {
                    sarglaftResponse = JsonConvert.DeserializeObject<ConsultListsResponse>(jsonResponse);
                    foreach(SarglatList list in sarglaftResponse.lists)
                    {
                        if (list.coincidence) {
                            response += list.list;
                            if (!string.IsNullOrEmpty(list.observations))
                                response += " (" + list.observations + ")";
                        }
                    }
                }
                catch (Exception ex) { response = jsonResponse; }
            }

            this.CreateSarglaftLog(fullName, string.IsNullOrEmpty(error), punctuation, jsonRequest, jsonResponse, error, sarglaftResponse, _org);

            if (string.IsNullOrEmpty(error))
                return response;
            else
                return error;
        }

        public Guid CreateSarglaftLog(string fullName, bool success, int punctuation, string request, string response, string error, ConsultListsResponse sarglaftResponse, OrganizationServiceProxy _org)
        {
            Entity sarglaftLog = new Entity("amx_sarglaftlog");
            sarglaftLog.Attributes["amx_success"] = success;
            sarglaftLog.Attributes["amx_name"] = fullName;
            sarglaftLog.Attributes["amx_punctuation"] = punctuation;
            sarglaftLog.Attributes["amx_request"] = request;
            sarglaftLog.Attributes["amx_response"] = response;
            sarglaftLog.Attributes["amx_error"] = error;

            if (sarglaftResponse != null)
            {
                foreach (SarglatList list in sarglaftResponse.lists)
                {
                    if (list.coincidence)
                    {
                        if (list.list.ToLower().Equals("fbi"))
                        {
                            sarglaftLog.Attributes["amx_fbi"] = true;
                            if (!string.IsNullOrEmpty(list.observations))
                                sarglaftLog.Attributes["amx_fbi_observation"] = list.observations;
                        }
                        if (list.list.ToLower().Equals("ofac"))
                        {
                            sarglaftLog.Attributes["amx_ofac"] = true;
                            if (!string.IsNullOrEmpty(list.observations))
                                sarglaftLog.Attributes["amx_ofac_observation"] = list.observations;
                        }
                        if (list.list.ToLower().Equals("onu"))
                        {
                            sarglaftLog.Attributes["amx_onu"] = true;
                            if (!string.IsNullOrEmpty(list.observations))
                                sarglaftLog.Attributes["amx_onu_observation"] = list.observations;
                        }
                    }
                }
            }

            Guid sarglaftLogId = _org.Create(sarglaftLog);

            return sarglaftLogId;
        }
    }
}
