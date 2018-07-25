using AmxPeruPSBActivities.Model.Case;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Service.Case
{
    public class AmxCoUpdateCaseStatusService
    {
        public AmxCoUpdateCaseStatusResponse UpdateCaseStatus(AmxCoUpdateCaseStatusRequest request, OrganizationServiceProxy service)
        {
            AmxCoUpdateCaseStatusResponse objResponse = new AmxCoUpdateCaseStatusResponse();

            try
            {
                Entity eIncident = service.Retrieve("incident", Guid.Parse(request.caseId), new ColumnSet("description","statecode"));

                if (eIncident != null)
                {
                    //description, sqdm_caseidmgl
                    Entity incident = new Entity(eIncident.LogicalName, eIncident.Id);
                    if (eIncident.Contains("description"))
                        incident["description"] = eIncident["description"].ToString() + ". " + request.caseReason;
                    else
                        incident["description"] = request.caseReason;

                    if (!string.IsNullOrEmpty(request.caseCompleted))  
                        incident["amx_caseidmgl"] = request.caseCompleted;                    

                    incident["amx_caseidmgl"] = request.caseIdMGL;

                    service.Update(incident);

                    if (request.caseStatus.ToUpper().Contains("FINALIZADO"))
                    {   
                        closeIncident(service, request.caseReason, eIncident.ToEntityReference());
                    }
                    else if (request.caseStatus.ToUpper().Contains("PENDIENTE"))
                    {
                        if (((OptionSetValue)eIncident["statecode"]).Value == 0)
                            changeState(service, eIncident.ToEntityReference());
                    }
                    
                }

                objResponse.Error = string.Empty;
                objResponse.Status = "Success";
            }
            catch (Exception ex)
            {
                objResponse.Error = ex.Message;
                objResponse.Status = "Error";
            }

            return objResponse;
        }


        private void closeIncident(OrganizationServiceProxy service, string subject, EntityReference incident)
        {
            Entity incidentesolution = new Entity("incidentresolution");
            incidentesolution["subject"] = subject;
            incidentesolution["incidentid"] = incident;

            // Close the incident with the resolution.
            CloseIncidentRequest closeIncidentRequest = new CloseIncidentRequest
            {
                IncidentResolution = incidentesolution,
                Status = new OptionSetValue(1000)
            };

            service.Execute(closeIncidentRequest);
        }

        private void changeState(OrganizationServiceProxy service, EntityReference incident)
        {
            SetStateRequest state = new SetStateRequest();
            state.State = new OptionSetValue(0);
            state.Status = new OptionSetValue(1);
            state.EntityMoniker = incident;

            service.Execute(state);
        }
    }
}
