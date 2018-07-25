using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Business;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.Eligibility;



namespace AmxPeruPSBActivities.Activities.Task
{
   public class CreateTAskUpdated : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruCreateTaskUpdatedRequest> createTaskUpdatedRequest { get; set; }
        public OutArgument<AmxPeruCreateTaskUpdatedResponse> createTaskUpdatedResponse { get; set; }
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AmxPeruPSBActivities.Model.AmxPeruConstants Constants = new AmxPeruPSBActivities.Model.AmxPeruConstants();

            var request = createTaskUpdatedRequest.Get(context);
            try
            {
           
                 AmxPeruCreateTaskUpdatedResponse _CreateTaskUpdatedResponse = null;
                    _CreateTaskUpdatedResponse = new AmxPeruCreateTaskUpdatedResponse();
                    AmxPeruCreateTaskUpdatedRequest _CreateTaskUpdatedRequest = new AmxPeruCreateTaskUpdatedRequest();
                    if (request != null)
                    {
                       Entity  taskEntity = new Entity("task");
                        if (!string.IsNullOrEmpty(request.Description))
                        {
                            taskEntity["description"] = request.Description;
                        }
                        if (!string.IsNullOrEmpty(request.Subject))
                        {
                            taskEntity["subject"] = request.Subject;
                        }

                        if (!string.IsNullOrEmpty(request.ServiceId))
                        {
                            taskEntity["tclab_serviceid"] = request.ServiceId;
                        }

                        if (request.Duration != 0)
                        {
                            taskEntity["actualdurationminutes"] = request.Duration;
                        }

                        if (request.TaskType != 0)
                        {
                            taskEntity["amxbase_tasktype"] = new OptionSetValue(request.TaskType);
                        }

                        if (request.BIRequired != false)
                        {
                            taskEntity["amxbase_birequired"] = request.BIRequired;
                        }

                        if (request.ScheduledEnd != null && request.ScheduledEnd > DateTime.MinValue)
                        {
                            taskEntity["scheduledend"] = request.ScheduledEnd;
                        }

                        if (request.OwnerName != null && request.OwnerType != null)
                        {
                            taskEntity["ownerid"] = GetLookupValueFromField(request.OwnerType, "fullname", request.OwnerName);
                        }

                        if (request.RegardingType != null && request.RegardingColumnName != null && request.RegardingColumnValue != null)
                        {
                            taskEntity["regardingobjectid"] = GetLookupValueFromField(request.RegardingType, request.RegardingColumnName, request.RegardingColumnValue);
                        }
                        Guid createdTask = ContextProvider.OrganizationService.Create(taskEntity);
                        _CreateTaskUpdatedResponse.CreatedTaskID = createdTask.ToString();
                        if (request.CustomerExternalId != null)
                        {
                            _CreateTaskUpdatedResponse.CreatedTaskID = createdTask.ToString();
                        _CreateTaskUpdatedResponse.regardingRecordEntityName = taskEntity.LogicalName;
                        AmxPeruCreateBILOGRequest BIRequest = new AmxPeruCreateBILOGRequest();
                            // BIRequest = new CreateBILogRequest();
                            request.Channel = BIRequest.Channel;
                            BIRequest.CustomerExternalId = request.CustomerExternalId;
                            BIRequest.CustomerType = request.CustomerType;

                          BIRequest.subject = "Task Record Created.";
                          BIRequest.description = "New task record is Created in CRM. ";
                       // BIRequest.RegardingRecordEntityName = 
                           // BIRequest.RegardingRecordID = createdTask;

                            AmxPeruCreateBILOG BIBusiness = new AmxPeruCreateBILOG();
                       
                           // BIBusiness.Execute(BIRequest);
                        }
                    }
                createTaskUpdatedResponse.Set(context, _CreateTaskUpdatedResponse);
            }
            
               //
               
             catch (Exception ex)
            {
                throw ex;
            }
        }
        private Guid GetLookupValueFromField(string entityName, string columnName, string columnValue)
        {
            QueryExpression retrieveQuery = new QueryExpression(entityName);
            retrieveQuery.Criteria.AddCondition(columnName, ConditionOperator.Equal, columnValue);
            EntityCollection retrievedCollection = ContextProvider.OrganizationService.RetrieveMultiple(retrieveQuery);

            if (retrievedCollection.Entities.Count == 1)
            {
                return retrievedCollection[0].Id;
            }
            return Guid.Empty;
        }
        }
 
}
