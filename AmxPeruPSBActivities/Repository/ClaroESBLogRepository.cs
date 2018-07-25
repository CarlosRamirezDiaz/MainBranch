using AmxPeruPSBActivities.Model.CreditProfile;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Repository
{
    public class ClaroESBLogRepository
    {
        OrganizationServiceProxy _organizationService;

        public ClaroESBLogRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Save the Claro ESB Log
        /// </summary>
        /// <param name="url"></param>
        /// <param name="success"></param>
        /// <param name="elapsedTime"></param>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public Guid Create(string url, bool success, long elapsedTime, string request, string response, string error)
        {
            try
            {
                Entity entity = new Entity("amx_claroesblog");

                if (elapsedTime > Int32.MaxValue)
                    elapsedTime = Int32.MaxValue;

                if (url.Length > 450)
                    url = url.Substring(0, 450);

                if (request.Length > 1048576)
                    request = request.Substring(0, 1048576);

                if (response.Length > 1048576)
                    response = response.Substring(0, 1048576);

                if (error.Length > 1048576)
                    error = error.Substring(0, 1048576);

                entity.Attributes.Add("amx_name", url);
                entity.Attributes.Add("amx_success", success);
                entity.Attributes.Add("amx_elapsedtime", Convert.ToInt32(elapsedTime));
                entity.Attributes.Add("amx_request", request);
                entity.Attributes.Add("amx_response", response);
                entity.Attributes.Add("amx_error", error);
                entity.Attributes.Add("amx_requestlength", string.IsNullOrEmpty(request) ? 0 : request.Length);
                entity.Attributes.Add("amx_responselength", string.IsNullOrEmpty(response)? 0: response.Length);

                return this._organizationService.Create(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("ClaroESBLogRepository Create: " + ex.Message);
            }
        }
    }
}