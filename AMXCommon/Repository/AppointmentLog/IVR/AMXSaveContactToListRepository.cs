using AMXCommon.Model.AppointmentLog;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMXCommon.Repository.AppointmentLog
{
    public class AMXSaveContactToListRepository
    {

        #region Variables
        private string fetchAppointmentLog = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                  <entity name='etel_appointmentlog'>
	                                                <attribute name='etel_appointmentlogid' />                                                
	                                                <attribute name='etel_name' />
	                                                <attribute name='etel_individualcustomerid' />
	                                                <attribute name='etel_externalid' />
	                                                <attribute name='etel_appointmentdate' />
	                                                <attribute name='amx_workorderid' />
	                                                <attribute name='amx_workflowordersubtype' />
	                                                <attribute name='amx_timeslot' />
	                                                <attribute name='amx_duration' />
	                                                <attribute name='amx_confirmationstatus' />
	                                                <attribute name='amx_appointmentnumber' />
	                                                <attribute name='amx_addressid' />
	                                                <attribute name='amx_address' />
                                                    <order attribute='etel_name' descending='false' />
                                                    <filter type='and'>
                                                      <condition attribute='amx_confirmationstatus' operator='eq' value='173800001' />
                                                      <condition attribute='statecode' operator='eq' value='0' />
                                                      <condition attribute='etel_appointmentlogid' operator='eq' value='{0}' />
                                                    </filter>
	                                                <link-entity name='contact' from='contactid' to='etel_individualcustomerid' alias='ae'>
	                                                  <attribute name='etel_accountnumber' />
	                                                  <attribute name='fullname' />
	                                                  <attribute name='amx_ccinfojsontext' />
	                                                  <attribute name='amxperu_documenttype' />
	                                                  <attribute name='etel_iddocumentnumber' />
	                                                </link-entity>
                                                  </entity>
                                                </fetch>";

        #endregion

        /// <summary>
        /// Get All Appointment logs based on Document Id
        /// </summary>
        /// <param name="service"></param>
        /// <param name="documentId"></param>  
        /// <returns></returns>
        public AMXResponseModel GetAppointmentLogDetails(IOrganizationService service, Guid primaryId, string conListName, bool isOneDay)
        {
            string primaryPhone = string.Empty;
            string secondaryPhone = string.Empty;
            string contactId = string.Empty;
            var request = new AMXSaveContactToListRequestModel();
            var response = new AMXResponseModel();
            var contactToJobReq = new Model.AppointmentLog.IVR.AMXAddContactFromListToJobModel();
            try
            {
                var entityCollection = service.RetrieveMultiple(new FetchExpression(string.Format(fetchAppointmentLog, primaryId.ToString())));
                if (entityCollection.Entities.Count > 0)
                {
                    var entity = entityCollection.Entities[0];
                    //request.userContactID = entity.Contains("amx_workorderid") ? entity["amx_workorderid"].ToString() : "";
                    //contactId = entity.Contains("amx_workorderid") ? entity["amx_workorderid"].ToString() : "";
                    request.userContactID = entity.Contains("amx_appointmentnumber") ? entity["amx_appointmentnumber"].ToString() : "";
                    contactId = entity.Contains("amx_appointmentnumber") ? entity["amx_appointmentnumber"].ToString() : "";
                    request.contactListName = conListName;
                    if (entity.Contains("ae.amx_ccinfojsontext"))
                    {
                        var resPhoneInfo = new AMXGetAppointmentDetailsRepository().GetCustomerContactInfo(((AliasedValue)entity["ae.amx_ccinfojsontext"]).Value.ToString());
                        var phoneinfo = resPhoneInfo.Split(';');
                        primaryPhone = phoneinfo.Length > 0 ? phoneinfo[0] : string.Empty;
                        secondaryPhone = phoneinfo.Length > 1 ? phoneinfo[1] : string.Empty;
                    }
                }
                foreach (var entity in entityCollection.Entities)
                {
                    var dateSchedule = entity.Contains("etel_appointmentdate") ? 
                        new AMXCommon.Common().GetDateStringYYYYMMDD(Convert.ToDateTime(entity["etel_appointmentdate"])) : DateTime.MinValue.ToString();
                    request.attributeObj = new AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType[]
                    {
                            new AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType { Name = "address", Value = entity.Contains("amx_address") ? entity["amx_address"].ToString() : "" },
                            new AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType { Name = "customerName", Value = entity.Contains("ae.fullname") ? ((AliasedValue)entity["ae.fullname"]).Value.ToString() : "" },
                            new AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType { Name = "phone1", Value = primaryPhone },
                            new AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType { Name = "phone2", Value = secondaryPhone},
                            new AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType { Name = "dateSchedule", Value =  dateSchedule },
                            new AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType { Name = "timeSlot", Value = entity.Contains("amx_timeslot") ? entity["amx_timeslot"].ToString() : "" },
                            new AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType { Name = "workOrderId", Value = entity.Contains("amx_workorderid") ? entity["amx_workorderid"].ToString() : "" },
                            //new AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType { Name = "id", Value = entity.Contains("amx_workorderid") ? entity["amx_workorderid"].ToString() : "" },
                            new AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType { Name = "workOrderType", Value = entity.Contains("amx_workflowordersubtype") ? entity["amx_workflowordersubtype"].ToString() : "" },
                            new AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType { Name = "documentId", Value = entity.Contains("ae.etel_iddocumentnumber") ? ((AliasedValue)entity["ae.etel_iddocumentnumber"]).Value.ToString() : "" },
                            new AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType { Name = "documentType", Value = entity.Contains("ae.amxperu_documenttype") ? ((OptionSetValue)((AliasedValue)entity["ae.amxperu_documenttype"]).Value).Value.ToString() : "" },
                            //new AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType { Name = "amx_confirmationstatus", Value = entity.Contains("amx_confirmationstatus") ? ((OptionSetValue)entity["amx_confirmationstatus"]).Value == 173800000 ? "Confirmed" : "Pending" : "Pending" },
                    };
                    break;
                }
                
                var ivrSaveToContactListRes = IVRSaveContactToList(request, service);
                if (ivrSaveToContactListRes.responseStatus.code == 0) { return ivrSaveToContactListRes; }

                if (!isOneDay)
                {
                    var ivrAddContactListToJobRes = IVRAddContactListToJob(contactId, service);
                    if (ivrAddContactListToJobRes.responseStatus.code == 0) { return ivrAddContactListToJobRes; }
                    response.responseStatus = new ResponseStatus { code = 1, description = "Success" };
                }
            }
            catch (Exception ex)
            {
                response.responseStatus = new ResponseStatus { code = 0, description = "Failed. Error while retrieving Appointment log for the customer" };
            }
            return response;
        }
        /// <summary>
        /// Push data to IVR service SaveContactToList
        /// </summary>
        /// <param name="request"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        private AMXResponseModel IVRSaveContactToList(AMXSaveContactToListRequestModel request, IOrganizationService service) {
            var response = new AMXResponseModel();
            var exceptionMesssage = string.Empty;
            AmxWorkflowPlugin.VP_POMAgentAPIService.SaveContactToListRequest saveContactToListRequest = new AmxWorkflowPlugin.VP_POMAgentAPIService.SaveContactToListRequest
            {
                ContactToBeSaved = new AmxWorkflowPlugin.VP_POMAgentAPIService.ContactDataType {
                    UserContactId = request.userContactID,
                    ContactListName = request.contactListName,
                    AttributeObj = request.attributeObj
                }
            };
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding { Name = "vpPOMAgentAPIServiceBinding", OpenTimeout = new TimeSpan(0, 15, 0), CloseTimeout = new TimeSpan(0, 15, 0), ReceiveTimeout = new TimeSpan(0, 15, 0), SendTimeout = new TimeSpan(0, 15, 0) };
                var configValue = new AMXCommon.Common().RetrieveCrmConfiguration("IVR_SaveContactToList_URL", service);
                if (configValue != string.Empty)
                {
                    EndpointAddress endpointAddress = new EndpointAddress(configValue);
                    AmxWorkflowPlugin.VP_POMAgentAPIService.VP_POMAgentAPIServiceClient client = new AmxWorkflowPlugin.VP_POMAgentAPIService.VP_POMAgentAPIServiceClient(binding, endpointAddress);
                    var ivrResponse = client.SaveContactToList(saveContactToListRequest.ContactToBeSaved, false, false, false, false, false);
                    if (ivrResponse == 0)
                    {
                        response.responseStatus = new ResponseStatus { code = 1, description = "Success" };
                    }
                }
            }
            catch(Exception ex)
            {
                exceptionMesssage = ((System.ServiceModel.FaultException<AmxWorkflowPlugin.VP_POMAgentAPIService.SaveContactToListFaultInfo>)ex).Detail.FaultMsg;
                response.responseStatus = new ResponseStatus { code = 0, description = exceptionMesssage };
            }
            new AMXCommon.Common().CreateExceptionLog(service, request, "SaveContactToList", exceptionMesssage);
            return response;
        }
        /// <summary>
        /// Push data to IVR service AddContactListToJob
        /// </summary>
        /// <param name="request"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        private AMXResponseModel IVRAddContactListToJob(string contactId, IOrganizationService service)
        {
            var response = new AMXResponseModel();
            var contactToJobReq = new Model.AppointmentLog.IVR.AMXAddContactFromListToJobModel();
            var exceptionMesssage = string.Empty;            
            try
            {
                contactToJobReq = new Model.AppointmentLog.IVR.AMXAddContactFromListToJobModel
                {
                    CampaignName = "CONFIRMACION_VISITAS_INSPIRA",
                    ContactListName = "CONFIRMACION_VISITAS_INSPIRA", 
                    ContactID = contactId
                };                
                BasicHttpBinding binding = new AMXCommon.Common().GetSoapServiceBasicHttpBinding();
                var configValue = new AMXCommon.Common().RetrieveCrmConfiguration("IVR_AddContactListToJob_URL", service);
                if (configValue != string.Empty)
                {
                    EndpointAddress endpointAddress = new EndpointAddress(configValue);
                    AmxWorkflowPlugin.VP_POMAgentAPIService.VP_POMAgentAPIServiceClient client = new AmxWorkflowPlugin.VP_POMAgentAPIService.VP_POMAgentAPIServiceClient(binding, endpointAddress);
                    var ivrResponse = client.AddContactFromListToJob(contactToJobReq.CampaignName, contactToJobReq.ContactID, contactToJobReq.ContactListName, new AmxWorkflowPlugin.VP_POMAgentAPIService.Priority());
                    if (ivrResponse == 0)
                    {
                        response.responseStatus = new ResponseStatus { code = 1, description = "Success" };
                    }
                }
            }
            catch(Exception ex)
            {
                exceptionMesssage = ((System.ServiceModel.FaultException<AmxWorkflowPlugin.VP_POMAgentAPIService.AddContactFromListToJobFaultInfo>)ex).Detail.FaultMsg;
                response.responseStatus = new ResponseStatus { code = 0, description = exceptionMesssage };
            }
            new AMXCommon.Common().CreateExceptionLog(service, contactToJobReq, "AddContactFromListToJob", exceptionMesssage);
            return response; 
        }
    }
}
