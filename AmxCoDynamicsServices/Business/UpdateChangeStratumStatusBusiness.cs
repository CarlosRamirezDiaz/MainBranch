using AmxDynamicsServices;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace AmxDynamicsServices
{
    public class UpdateChangeStratumStatusBusiness
    {
        IOrganizationService OrgService = null;
        CrmHelper helperObj = null;

        /// <summary>
        /// This is the default constructor
        /// </summary>
        public UpdateChangeStratumStatusBusiness()
        {
            //Get the CRM Org Service instance from the CRM Connetion Class
            //Caching is implemented
            OrgService = CRMConnection.GetConnection();
        }

        public UpdateChangeStratumStatusResponse UpdateChangeStratumStatusInCRM(UpdateChangeStratumStatusRequest request)
        {
            UpdateChangeStratumStatusResponse _UpdateChangeStratumStatusResponse = null;

            try
            {
                _UpdateChangeStratumStatusResponse = new UpdateChangeStratumStatusResponse();

                helperObj = new CrmHelper();

                Entity eIncident = OrgService.Retrieve("incident", Guid.Parse(request.caseId), new ColumnSet("description,statecode"));

                if (eIncident != null)
                {
                    //description, sqdm_caseidmgl
                    Entity incident = new Entity(eIncident.LogicalName, eIncident.Id);
                    if (eIncident.Contains("description"))
                        incident["description"] = eIncident["description"].ToString() + ". " + request.caseReason;
                    else
                        incident["description"] = request.caseReason;

                    incident["sqdm_caseidmgl"] = request.caseIdMGL;

                    OrgService.Update(incident);

                    if (request.caseStatus.ToUpper().Contains("FINALIZADO"))
                    {
                        closeIncident(request.caseReason, eIncident.ToEntityReference());
                    }
                    else if (request.caseStatus.ToUpper().Contains("PENDIENTE"))
                    {
                        if(((OptionSetValue)eIncident["statecode"]).Value == 0)
                            changeState(eIncident.ToEntityReference());
                    }

                    /* /Create BI Log
                    CreateBILogRequest BIRequest = new CreateBILogRequest();
                    BIRequest.subject = Constants.BILogBlacklistStatusSubject;
                    BIRequest.description = Constants.BILogBlacklistStatusDescription;
                    BIRequest.RegardingRecordEntityName = incident.LogicalName;
                    BIRequest.RegardingRecordID = incident.Id;
                    CreateBILogBusiness BIBusiness = new CreateBILogBusiness();
                    BIBusiness.CreateBILogValues(BIRequest);
                    //Create BI Log */

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _UpdateChangeStratumStatusResponse;
        }

        private void closeIncident(string subject, EntityReference incident)
        {
            Entity incidentesolution = new Entity("incidentresolution");
            incidentesolution["subject"] = subject;
            incidentesolution["incidentid"] = incident;

            // Close the incident with the resolution.
            CloseIncidentRequest closeIncidentRequest = new CloseIncidentRequest
            {
                IncidentResolution = incidentesolution,
                Status = new OptionSetValue((int)1000)
            };

            OrgService.Execute(closeIncidentRequest);
        }

        private void changeState(EntityReference incident) {
            
            SetStateRequest state = new SetStateRequest();
            state.State = new OptionSetValue(0);
            state.Status = new OptionSetValue(1);
            state.EntityMoniker = incident;

            OrgService.Execute(state);
        }
    }
}
