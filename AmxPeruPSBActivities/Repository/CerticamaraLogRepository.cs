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
    public class CerticamaraLogRepository
    {
        OrganizationServiceProxy _organizationService;

        public CerticamaraLogRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Save the EOC Log
        /// </summary>
        /// <param name="url"></param>
        /// <param name="success"></param>
        /// <param name="elapsedTime"></param>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public Guid Create(bool authorized, string fullname, string documentId, string code, string message, string minucia)
        {
            try
            {
                Entity entity = new Entity("amx_certicamaralog");

                if (!string.IsNullOrEmpty(code) && code.Length > 3999)
                    code = code.Substring(0, 3999);

                if (!string.IsNullOrEmpty(message) && message.Length > 3999)
                    message = message.Substring(0, 3999);

                if (!string.IsNullOrEmpty(minucia) && minucia.Length > 3999)
                    minucia = minucia.Substring(0, 3999);

                entity.Attributes.Add("amx_name", fullname);
                entity.Attributes.Add("amx_authorized", authorized);
                entity.Attributes.Add("amx_documentid", documentId);
                entity.Attributes.Add("amx_code", code);
                entity.Attributes.Add("amx_message", message);
                entity.Attributes.Add("amx_minucia", minucia);

                return this._organizationService.Create(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("CerticamaraLogRepository Create: " + ex.Message);
            }
        }
    }
}