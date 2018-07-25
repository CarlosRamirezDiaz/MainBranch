using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public class PostCompleteTask : IPlugin
    {
        IPluginExecutionContext _context = null;
        IOrganizationService _orgService = null;
        IOrganizationServiceFactory _orgServiceFactory = null;

        int ManualCreditCheckRequried = 2;
        int Accepted = 250000000;
        int Rejected = 250000001;

        public void Execute(IServiceProvider serviceProvider)
        {
            _context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            _orgServiceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            _orgService = _orgServiceFactory.CreateOrganizationService(_context.UserId);

            if (_context.InputParameters.Contains("EntityMoniker") && _context.InputParameters["EntityMoniker"] is EntityReference)
            {
                EntityReference _entity = (EntityReference)_context.InputParameters["EntityMoniker"];
                Entity postImage = (Entity)_context.PostEntityImages["TaskPostImage"];

                if (_context.Depth == 1 && postImage.LogicalName == "task")
                {
                    int taskType = -1;

                    if (postImage.Attributes.Contains("amxperu_birequired"))
                    {
                        bool BiRequiredFlag = (bool)postImage.Attributes["amxperu_birequired"];
                        if (BiRequiredFlag)
                        {
                            if (!(postImage.Contains("amxperu_relatedbilogactivity") && ((EntityReference)postImage.Attributes["amxperu_relatedbilogactivity"]).Id != null))
                            {
                                int languageId = GetContextUserLanguageId(_context.UserId, _orgService);
                                string tRemedyRelatedTask = GetTranslatedMessage(languageId, "PLUGIN_TaskCompletion", "tRemedyRelatedTask", _orgService);
                                throw new InvalidPluginExecutionException(tRemedyRelatedTask);
                            }
                        }
                    }

                    if (postImage.Attributes.Contains("amxperu_tasktype"))
                    {
                        taskType = (postImage.Attributes["amxperu_tasktype"] as OptionSetValue).Value;

                        if (taskType == ManualCreditCheckRequried)
                        {
                            throw new InvalidPluginExecutionException("IWS Service Call to Push : Manual Credit Check Task Completion Status");
                        }
                    }

                    if (postImage.Contains("regardingobjectid") && ((EntityReference)postImage.Attributes["regardingobjectid"]).LogicalName == "incident")
                    {
                        QueryExpression caseTask = new QueryExpression("task");
                        caseTask.ColumnSet = new ColumnSet(false);
                        caseTask.Criteria.AddCondition("regardingobjectid", ConditionOperator.Equal, ((EntityReference)postImage.Attributes["regardingobjectid"]).Id);
                        caseTask.Criteria.AddCondition("statecode", ConditionOperator.NotEqual, 1);
                        caseTask.Criteria.AddCondition("activityid", ConditionOperator.NotEqual, _entity.Id);
                        EntityCollection retrievedCase = _orgService.RetrieveMultiple(caseTask);

                        if (retrievedCase.Entities.Count == 0)
                        {
                            Entity caseEntity = new Entity(((EntityReference)postImage.Attributes["regardingobjectid"]).LogicalName, ((EntityReference)postImage.Attributes["regardingobjectid"]).Id);
                            caseEntity["amxperu_associatedopentask"] = false;
                            _orgService.Update(caseEntity);
                        }
                    }

                    if (postImage.Contains("regardingobjectid") && ((EntityReference)postImage.Attributes["regardingobjectid"]).LogicalName == "account")
                    {
                        if ((postImage.Contains("amxperu_confirmation")) && (postImage.Attributes["amxperu_confirmation"]) != null)
                        {
                            Guid accountid = ((EntityReference)postImage.Attributes["regardingobjectid"]).Id;
                            Entity _corpEntity = new Entity(((EntityReference)postImage.Attributes["regardingobjectid"]).LogicalName, ((EntityReference)postImage.Attributes["regardingobjectid"]).Id);
                            string ConsultantDueDate;
                            DateTime DueDate;
                            int Confirmation = (postImage.Attributes["amxperu_confirmation"] as OptionSetValue).Value;
                            int additionalDays = 0;
                            if (Confirmation == Accepted)
                            {
                                if ((postImage.Contains("amxperu_additionaldays")) && (postImage.Attributes["amxperu_additionaldays"] != null))
                                {
                                    additionalDays = int.Parse(postImage.Attributes["amxperu_additionaldays"].ToString());
                                    ConsultantDueDate = GetDueDate(accountid);
                                    DueDate = DateTime.Parse(ConsultantDueDate).AddDays(additionalDays);
                                    ConsultantDueDate = DueDate.ToString();
                                    _corpEntity.Attributes.Add("amxperu_consultantduedate", ConsultantDueDate);
                                }
                            }
                            _corpEntity.Attributes.Add("amxperu_additionaldays", "");
                            _corpEntity.Attributes.Add("amxperu_istaskcreated", false);
                            _orgService.Update(_corpEntity);
                        }
                    }
                }
            }
        }

        private string GetDueDate(Guid Accountid)
        {
            string DueDate = "";
            string fetchDueDate = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0' > "
                               + "<entity name='account'>"
                               + "<attribute name='name'/>"
                               + "<attribute name='amxperu_consultantduedate'/>"
                               + "<attribute name='accountid'/>"
                               + "<order descending='false' attribute='name'/>"
                               + "<filter type='and'>"
                               + "<condition attribute='accountid' value='" + Accountid + "' operator='eq'/>"
                               + "</filter>"
                               + "</entity>"
                               + "</fetch>";
            EntityCollection resultset = new EntityCollection();
            resultset = _orgService.RetrieveMultiple(new FetchExpression(fetchDueDate));
            if (resultset != null && resultset.Entities.Count > 0)
            {
                foreach (Entity _result in resultset.Entities)
                {
                    if (_result.Contains("amxperu_consultantduedate"))
                    {
                        DueDate = _result.Attributes["amxperu_consultantduedate"].ToString();
                    }
                }
            }
            return DueDate;
        }

        private int GetContextUserLanguageId(Guid userId, IOrganizationService orgService)
        {
            int langid = 1033;
            RetrieveUserSettingsSystemUserRequest request = new RetrieveUserSettingsSystemUserRequest();
            request.EntityId = userId;
            request.ColumnSet = new ColumnSet("uilanguageid");
            RetrieveUserSettingsSystemUserResponse response = (RetrieveUserSettingsSystemUserResponse)orgService.Execute(request);
            langid = int.Parse(response.Entity.Attributes["uilanguageid"].ToString());
            return langid;
        }

        private string GetTranslatedMessage(int languageId, string formId, string codeId, IOrganizationService orgService)
        {
            string message = "Task can't be close. BI Log is mandatory if Task Type is Remedy.";
            QueryExpression translationQuery = new QueryExpression("etel_translation");
            translationQuery.Criteria.AddCondition("etel_formid", ConditionOperator.Equal, formId);
            translationQuery.Criteria.AddCondition("etel_code", ConditionOperator.Equal, codeId);
            translationQuery.Criteria.AddCondition("etel_lcid", ConditionOperator.Equal, languageId);
            translationQuery.ColumnSet = new ColumnSet("etel_message");
            EntityCollection translationRecords = orgService.RetrieveMultiple(translationQuery);
            if (translationRecords.Entities.Count >= 1)
            {
                Entity firstRecord = translationRecords.Entities.First();
                if (firstRecord.Contains("etel_message"))
                {
                    return firstRecord.Attributes["etel_message"].ToString();
                }
            }

            return message;
        }

    }
}
