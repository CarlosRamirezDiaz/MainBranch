using AmxPeruPSBActivities.Model.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Client;

namespace AmxPeruPSBActivities.Business
{
    public class AmxPeruCreateTaskBusiness
    {
        string CustomerTypeField = null;
        private EntityReference GetLookupValueFromField(string entityName, string columnName, string columnValue, OrganizationServiceProxy _org)
        {
            QueryExpression retrieveQuery = new QueryExpression(entityName);
            retrieveQuery.Criteria.AddCondition(columnName, ConditionOperator.Equal, columnValue);
            EntityCollection retrievedCollection = _org.RetrieveMultiple(retrieveQuery);

            if (retrievedCollection.Entities.Count == 1)
            {
                return new EntityReference(retrievedCollection[0].LogicalName, retrievedCollection[0].Id);
            }
            return null;
        }
        public AmxPeruCreateTaskResponse CreateTask(AmxPeruCreateTaskRequest request, OrganizationServiceProxy _org)
        {
            AmxPeruCreateTaskResponse _CreateTaskResponse = null;
            try
            {
                if (request != null)
                {
                    _CreateTaskResponse = new AmxPeruCreateTaskResponse();
                    Entity taskEntity = new Entity("task");
                    if (!string.IsNullOrEmpty(request.Description))
                    {
                        taskEntity["description"] = request.Description;
                    }
                    if (!string.IsNullOrEmpty(request.Subject))
                    {
                        taskEntity["subject"] = request.Subject;
                    }
                    if (request.Duration != 0)
                    {
                        taskEntity["actualdurationminutes"] = request.Duration;
                    }
                    if (request.TaskType != 0)
                    {
                        taskEntity["amxperu_tasktype"] = new OptionSetValue(request.TaskType);
                    }
                    if (request.BIRequired)
                    {
                        taskEntity["amxperu_birequired"] = true;
                    }
                    else
                    {
                        taskEntity["amxperu_birequired"] = false;
                    }

                    if (request.ScheduledEnd != null && request.ScheduledEnd > DateTime.MinValue)
                    {
                        taskEntity["scheduledend"] = request.ScheduledEnd;
                    }
                    if (request.OwnerName != null && request.OwnerType != null)
                    {
                        EntityReference Owner = GetLookupValueFromField(request.OwnerType, "fullname", request.OwnerName, _org);
                        taskEntity["ownerid"] = new EntityReference(Owner.LogicalName, Owner.Id);
                    }
                    if (request.RegardingType != null && request.RegardingColumnName != null && request.RegardingColumnValue != null)
                    {
                        taskEntity["regardingobjectid"] = GetLookupValueFromField(request.RegardingType, request.RegardingColumnName, request.RegardingColumnValue, _org);
                    }
                    Guid createdTask = _org.Create(taskEntity);
                    if (!string.IsNullOrEmpty(createdTask.ToString()))
                    {
                        _CreateTaskResponse.CreatedTaskID = createdTask.ToString();
                        _CreateTaskResponse.Status = "OK";
                    }
                    else
                    {
                        _CreateTaskResponse.Status = "NOK";
                    }
                }
            }
            catch (Exception)
            {
                _CreateTaskResponse.Error = "An Error occur during request processing, please check the data for task creation";
                _CreateTaskResponse.Status = "NOK";
            }
            return _CreateTaskResponse;
        }
    }
}
