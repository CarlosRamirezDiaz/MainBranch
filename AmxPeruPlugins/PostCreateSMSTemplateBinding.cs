using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public class PostCreateSMSTemplateBinding : IPlugin
    {
        //  Entity _entity = null;
        IPluginExecutionContext _IPluginExecutionContext = null;
        IOrganizationServiceFactory _factory = null;
        IOrganizationService _service = null;
        Guid CustomerGuid = Guid.Empty;
        string CustomerName = string.Empty;
        string TemplateName = string.Empty;
        string SmsContent = string.Empty;
        bool isCorporate = false;

        public void Execute(IServiceProvider _provider)
        {
            try
            {
                _IPluginExecutionContext = (IPluginExecutionContext)_provider.GetService(typeof(IPluginExecutionContext));
                _factory = (IOrganizationServiceFactory)_provider.GetService(typeof(IOrganizationServiceFactory));
                _service = (IOrganizationService)_factory.CreateOrganizationService(_IPluginExecutionContext.UserId);

                if (_IPluginExecutionContext.InputParameters.Contains("Target") && _IPluginExecutionContext.InputParameters["Target"] is Entity)
                {
                    //  _entity = (Entity)_IPluginExecutionContext.InputParameters["Target"];
                    Entity _entity = (Entity)_IPluginExecutionContext.PostEntityImages["SMSImage"];

                    if (_entity.Contains("amxperu_smstemplate"))
                    {

                        Entity tempSMSEntity = new Entity("etel_sms");
                        tempSMSEntity.Id = _entity.Id;
                        tempSMSEntity.Attributes.Add("description", ResolveSmsContent(_entity));
                        _service.Update(tempSMSEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ResolveSmsContent(Entity _entity)
        {
            string SmsContent = string.Empty;
            List<string> listOfPlaceHolders = new List<string>();
            string placeHolder = string.Empty;

            try
            {
                SmsContent = FetchSMSDescriptionFromTemplate(_entity);
                var regex = new Regex("{{.*?}}");
                var matches = regex.Matches(SmsContent);
                foreach (var match in matches)
                {
                    string valueWithBraces = match.ToString();
                    string value = RemoveSpecialCharacters(valueWithBraces);
                    string[] tokens = value.Split(':');
                    if (tokens.Length == 2)
                    {
                        SmsContent = SmsContent.Replace(valueWithBraces, GetPlaceHolderValue(tokens, _entity));
                    }
                    else if (tokens.Length == 3)
                    {
                        SmsContent = SmsContent.Replace(valueWithBraces, GetRelatedEntityValue(tokens, _entity));

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
          

            return SmsContent;
        }

        private string FetchSMSDescriptionFromTemplate(Entity _entity)
        {
            string desc = string.Empty;
            string fetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                  <entity name='amxperu_smstemplate'>
                                    <attribute name='amxperu_smstemplateid' />
                                    <attribute name='amxperu_templatetext' />
                                    <filter type='and'>
                                      <condition attribute='amxperu_smstemplateid' operator='eq' value='{0}' />
                                    </filter>
                                  </entity>
                                </fetch>";

            try
            {
                fetchXml = string.Format(fetchXml, (_entity.Attributes["amxperu_smstemplate"] as EntityReference).Id.ToString());
                EntityCollection _EntityCollection = _service.RetrieveMultiple(new FetchExpression(fetchXml));
                if (_EntityCollection != null)
                {
                    if (_EntityCollection.Entities.Count > 0)
                    {
                        desc = _EntityCollection.Entities
                                           .Where(row => _EntityCollection.Entities.Count > 0)
                                           .Where(row => row.Attributes.ContainsKey("amxperu_templatetext"))
                                           .Select(row => row.GetAttributeValue<string>("amxperu_templatetext"))
                                           .FirstOrDefault<string>();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return desc;
        }

        private string GetPlaceHolderValue(string[] tokens, Entity _entity)
        {
            string placeHOlderValue = "";
            string fetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                              <entity name='{0}'>
                                                <attribute name='{1}' />
                                                <filter type='and'>
                                                  <condition attribute='{2}' operator='eq' value='{3}' />
                                                </filter>
                                              </entity>
                                            </fetch>";

            try
            {
                RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest();
                retrieveEntityRequest.EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Entity;
                retrieveEntityRequest.LogicalName = RemoveSpecialCharacters(tokens[0]);
                RetrieveEntityResponse retrieveEntityResponse = (RetrieveEntityResponse)_service.Execute(retrieveEntityRequest);
                string primaryKeyAttribute = retrieveEntityResponse.EntityMetadata.PrimaryIdAttribute;

                fetchXml = string.Format(fetchXml, tokens[0], tokens[1], primaryKeyAttribute, (_entity.Attributes["regardingobjectid"] as EntityReference).Id.ToString());
                EntityCollection _EntityCollection = _service.RetrieveMultiple(new FetchExpression(fetchXml));
                if (_EntityCollection != null)
                {
                    if (_EntityCollection.Entities.Count > 0)
                    {
                        if (_EntityCollection[0].Contains(tokens[1]))
                        {
                            object attValue = _EntityCollection[0].Attributes[tokens[1]];
                            switch (attValue.GetType().Name)
                            {
                                case "EntityReference":
                                    placeHOlderValue = ((EntityReference)attValue).Name;
                                    break;
                                case "String":
                                    placeHOlderValue = attValue.ToString();
                                    break;
                                default:
                                    placeHOlderValue = _EntityCollection[0].FormattedValues[tokens[1]].ToString();
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return placeHOlderValue;
        }

        private string GetRelatedEntityValue(string[] tokens, Entity _entity)
        {
            string relatedEntityValue = "";
            Entity regardingEntity = _service.Retrieve((_entity.Attributes["regardingobjectid"] as EntityReference).LogicalName, (_entity.Attributes["regardingobjectid"] as EntityReference).Id, new ColumnSet(tokens[1]));
            if (regardingEntity != null && regardingEntity.Contains(tokens[1]))
            {
                Entity regardingEntityValue = _service.Retrieve((regardingEntity.Attributes[tokens[1]] as EntityReference).LogicalName, (regardingEntity.Attributes[tokens[1]] as EntityReference).Id, new ColumnSet(tokens[2]));

                if (regardingEntityValue != null && regardingEntityValue.Contains(tokens[2]))
                {
                    object attValue = regardingEntityValue.Attributes[tokens[2]];
                    switch (attValue.GetType().Name)
                    {
                        case "EntityReference":
                            relatedEntityValue = ((EntityReference)attValue).Name;
                            break;

                        case "String":
                            relatedEntityValue = attValue.ToString();

                            break;
                        default:
                            relatedEntityValue = regardingEntityValue.FormattedValues[tokens[2]].ToString();
                            break;
                    }

                }
            }
            return relatedEntityValue;
        }

        public string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.:]+", "", RegexOptions.Compiled);
        }

    }
}
