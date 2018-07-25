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
    public class EvidenteLogRepository
    {
        OrganizationServiceProxy _organizationService;

        public EvidenteLogRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        public Guid Create(bool success, string codeQuestionnaire, string questionnaireSequence, Guid individualId, Guid orderCaptionId, string name, string error)
        {
            try
            {
                Entity entity = new Entity("amx_evidentelog");


                if (codeQuestionnaire.Length > 100)
                    codeQuestionnaire = codeQuestionnaire.Substring(0, 100);

                if (questionnaireSequence.Length > 100)
                    questionnaireSequence = questionnaireSequence.Substring(0, 100);

                if (name.Length > 100)
                    name = questionnaireSequence.Substring(0, 100);

                entity.Attributes.Add("amx_codequestionnaire", codeQuestionnaire);
                entity.Attributes.Add("amx_questionnairesequence", questionnaireSequence);

                if (!string.IsNullOrEmpty(error))
                {
                    if (error.Length > 100)
                        error = error.Substring(0, 100);

                    entity.Attributes.Add("amx_error", error);
                }

                entity.Attributes.Add("amx_name", name);
                entity.Attributes.Add("amx_rechazada", success);

                if (individualId != Guid.Empty)
                    entity.Attributes.Add("amx_individualid", new EntityReference("contact", individualId));

                if (orderCaptionId != Guid.Empty)
                    entity.Attributes.Add("amx_ordercaptionid", new EntityReference("etel_ordercaption", orderCaptionId));

                return this._organizationService.Create(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("EvidenteLogRepository Create: " + ex.Message);
            }
        }
    }
}