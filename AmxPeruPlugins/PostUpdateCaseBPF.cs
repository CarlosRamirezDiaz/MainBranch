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
    public class PostUpdateCaseBPF : IPlugin
    {
        #region [Execute Method]
        public void Execute(IServiceProvider serviceProvider)
        {
            try
            {
                ITracingService _ITracingService = null;
                IPluginExecutionContext _IPluginExecutionContext = null;
                IOrganizationServiceFactory _factory = null;
                IOrganizationService _service = null;

                _ITracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
                _IPluginExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                _factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                _service = (IOrganizationService)_factory.CreateOrganizationService(_IPluginExecutionContext.UserId);

                if (_IPluginExecutionContext.Depth < 4 && _IPluginExecutionContext.InputParameters.Contains("Target") && _IPluginExecutionContext.InputParameters["Target"] is Entity)
                {
                    Entity _entity = (Entity)_IPluginExecutionContext.InputParameters["Target"];
                    if (_entity.Contains("stageid"))
                    {
                        Entity caseEntity = _service.Retrieve(_entity.LogicalName, _entity.Id, new ColumnSet("amxperu_associatedopentask"));
                        if (caseEntity.Contains("amxperu_associatedopentask") && (bool)caseEntity.Attributes["amxperu_associatedopentask"] == true)
                        {
                            Entity stage = _service.Retrieve("processstage", (Guid)_entity.Attributes["stageid"], new ColumnSet("stagename"));
                            if (stage.Attributes["stagename"].ToString() == "Resolve")
                            {
                                int languageId = GetContextUserLanguageId(_IPluginExecutionContext.UserId, _service);
                                string tOpenTaskError = GetTranslatedMessage(languageId, "PLUGIN_CaseStageChange", "tOpenTaskError", _service);

                                throw new Exception(tOpenTaskError);
                            }
                        }
                    }
                }


            }
            catch (InvalidPluginExecutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

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
            string message = "Case Record can't be resolve until all related tasks are completed.";
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
