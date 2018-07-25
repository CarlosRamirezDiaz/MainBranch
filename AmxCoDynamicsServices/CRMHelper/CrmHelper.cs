using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ServiceModel.Description;
using AmxPeruPSBActivities.Model;

namespace AmxDynamicsServices
{
    public class CrmHelper
    {
        IOrganizationService OrgService = null;

        public CrmHelper()
        {
            //Get the CRM Org Service instance from the CRM Connetion Class
            //Caching is implemented
            //OrgService = CRMConnection.GetConnection();

            string userName = ConfigurationManager.AppSettings["OrgServiceInstanceUserId"].ToString();
            string Password = ConfigurationManager.AppSettings["OrgServiceInstancePassword"].ToString();
            string CrmConnectionString = ConfigurationManager.AppSettings["OrgServiceInstanceUri"].ToString();
            ClientCredentials _ClientCredentials = new ClientCredentials();
            _ClientCredentials.UserName.UserName = userName;
            _ClientCredentials.UserName.Password = Password;
            OrganizationServiceProxy _OrganizationServiceProxy = new OrganizationServiceProxy(new Uri(CrmConnectionString), null, _ClientCredentials, null);
            _OrganizationServiceProxy.EnableProxyTypes();
            OrgService = (IOrganizationService)_OrganizationServiceProxy;
        }

        #region [CRM Custom Helper Methods - Wrap Around Original ]
        /// <summary>
        /// Wrap Method for associating records in CRM
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="entityId"></param>
        /// <param name="relationship"></param>
        /// <param name="relatedEntities"></param>
        public void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            try
            {
                if (OrgService != null)
                {
                    OrgService.Associate(entityName, entityId, relationship, relatedEntities);
                }
                else
                {
                    throw new Exception(AmxPeruConstants.tInvalidOrgService);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Guid Create(Entity entity)
        {
            Guid CreatedRecordId = Guid.Empty;

            try
            {
                if (OrgService != null)
                {
                    CreatedRecordId = OrgService.Create(entity);
                    return CreatedRecordId;
                }
                else
                {
                    throw new Exception(AmxPeruConstants.tInvalidOrgService);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(string entityName, Guid id)
        {
            try
            {
                if (OrgService != null)
                {
                    OrgService.Delete(entityName, id);
                }
                else
                {
                    throw new Exception(AmxPeruConstants.tInvalidOrgService);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            try
            {
                if (OrgService != null)
                {
                    OrgService.Disassociate(entityName, entityId, relationship, relatedEntities);
                }
                else
                {
                    throw new Exception(AmxPeruConstants.tInvalidOrgService);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public OrganizationResponse Execute(OrganizationRequest request)
        {
            OrganizationResponse _OrganizationResponse = new OrganizationResponse();

            try
            {
                if (true)
                {
                    _OrganizationResponse = OrgService.Execute(request);
                    return _OrganizationResponse;
                }
                else
                {
                    throw new Exception(AmxPeruConstants.tInvalidOrgService);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet)
        {
            Entity _Entity = new Entity();

            try
            {
                if (OrgService != null)
                {
                    _Entity = OrgService.Retrieve(entityName, id, columnSet);
                    return _Entity;
                }
                else
                {
                    throw new Exception(AmxPeruConstants.tInvalidOrgService);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EntityCollection RetrieveMultiple(string fetchXml)
        {
            EntityCollection _EntityCollection = null;

            try
            {
                if (OrgService != null)
                {
                    _EntityCollection = OrgService.RetrieveMultiple(new FetchExpression(fetchXml));
                    return _EntityCollection;
                }
                else
                {
                    throw new Exception(AmxPeruConstants.tInvalidOrgService);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Entity entity)
        {
            try
            {
                if (OrgService != null)
                {
                    OrgService.Update(entity);
                }
                else
                {
                    throw new Exception(AmxPeruConstants.tInvalidOrgService);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetOptionSetText(string entityName, string attributeName, int optionsetValue)
        {
            string optionSetText = string.Empty;

            try
            {
                if (!String.IsNullOrEmpty(entityName) && !String.IsNullOrEmpty(attributeName) && optionsetValue > 0)
                {
                    if (OrgService != null)
                    {
                        RetrieveAttributeRequest retrieveAttributeRequest = new RetrieveAttributeRequest();
                        retrieveAttributeRequest.EntityLogicalName = entityName;
                        retrieveAttributeRequest.LogicalName = attributeName;
                        retrieveAttributeRequest.RetrieveAsIfPublished = true;

                        RetrieveAttributeResponse retrieveAttributeResponse = (RetrieveAttributeResponse)OrgService.Execute(retrieveAttributeRequest);
                        PicklistAttributeMetadata picklistAttributeMetadata = (PicklistAttributeMetadata)retrieveAttributeResponse.AttributeMetadata;

                        OptionSetMetadata optionsetMetadata = picklistAttributeMetadata.OptionSet;

                        foreach (OptionMetadata optionMetadata in optionsetMetadata.Options)
                        {
                            if (optionMetadata.Value == optionsetValue)
                            {
                                optionSetText = optionMetadata.Label.UserLocalizedLabel.Label;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception(AmxPeruConstants.tInvalidOrgService);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return optionSetText;
        }

        public int GetOptionSetValue(string entityName, string attributeName, string optionsetText)
        {
            int optionSetValue = 0;

            try
            {
                if (!String.IsNullOrEmpty(entityName) && !String.IsNullOrEmpty(attributeName) && !String.IsNullOrEmpty(optionsetText))
                {
                    if (OrgService != null)
                    {

                        RetrieveAttributeRequest retrieveAttributeRequest = new RetrieveAttributeRequest();
                        retrieveAttributeRequest.EntityLogicalName = entityName;
                        retrieveAttributeRequest.LogicalName = attributeName;
                        retrieveAttributeRequest.RetrieveAsIfPublished = true;

                        RetrieveAttributeResponse retrieveAttributeResponse = (RetrieveAttributeResponse)OrgService.Execute(retrieveAttributeRequest);
                        PicklistAttributeMetadata picklistAttributeMetadata = (PicklistAttributeMetadata)retrieveAttributeResponse.AttributeMetadata;

                        OptionSetMetadata optionsetMetadata = picklistAttributeMetadata.OptionSet;

                        foreach (OptionMetadata optionMetadata in optionsetMetadata.Options)
                        {
                            if (optionMetadata.Label.UserLocalizedLabel.Label.ToLower() == optionsetText.ToLower())
                            {
                                optionSetValue = optionMetadata.Value.Value;
                            }
                        }

                    }
                    else
                    {
                        throw new Exception(AmxPeruConstants.tInvalidOrgService); //No translation Required : Programming Purpose Only
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return optionSetValue;
        }

        /*
        public string RetireveAttributeValue(string entityLogicalName, Guid guid, string colName)
        {
            string retrievedColumnValue = string.Empty;

            try
            {
                if (OrgService != null)
                {
                    ColumnSet _ColumnSet = new ColumnSet(new String[] { colName });
                    Entity _tempEntity = OrgService.Retrieve(entityLogicalName, guid, _ColumnSet);
                    retrievedColumnValue = CrmCastAttributeDatatype.CastAttributeValue(_tempEntity.Attributes, colName);
                }
                else
                {
                    throw new Exception(AmxPeruConstants.tInvalidOrgService);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retrievedColumnValue;
        }
        */
        public string GetConfigurationByKey(string keyItem)
        {

            string FetchAmxConfigValues = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                              <entity name='amxbase_configuration'>
                                                <attribute name='amxbase_name' />
                                                <attribute name='amxbase_value' />
                                                <attribute name='amxbase_configurationid' />
                                                <filter type='and'>
                                                  <condition attribute='amxbase_name' operator='eq' value='{0}' />
                                                </filter>
                                              </entity>
                                            </fetch>";

            string fetchXmlResult = string.Empty;
            EntityCollection ConfigEntityCollection = null;
            string _configurationByVal = string.Empty;

            try
            {
                if (OrgService != null)
                {
                    string fetchXml = string.Format(FetchAmxConfigValues, keyItem);
                    ConfigEntityCollection = OrgService.RetrieveMultiple(new FetchExpression(fetchXml));
                    if (ConfigEntityCollection.Entities != null && ConfigEntityCollection.Entities[0].Attributes.Contains("amxbase_value"))
                    {
                        Entity configItem = ConfigEntityCollection.Entities[0];
                        _configurationByVal = configItem["amxbase_value"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _configurationByVal;
        }

        public Dictionary<string, string> GetConfigurationByListOfKeys(List<string> listOfKeys)
        {
            string fetchXmlResult = string.Empty;
            EntityCollection ConfigEntityCollection = null;

            string fetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                  <entity name='tclab_crmconfiguration'>
                                    <attribute name='tclab_stringvalue' />
                                    <attribute name='tclab_crmconfigurationid' />
                                    <filter type='and'>
                                      <condition attribute='tclab_name' operator='eq' value='{0}' />
                                    </filter>
                                  </entity>
                                </fetch>";
            Dictionary<string, string> _configurationByVal = new Dictionary<string, string>();

            try
            {
                if (OrgService != null)
                {
                    foreach (string key in listOfKeys)
                    {
                        fetchXml = string.Format(fetchXml, key);
                        ConfigEntityCollection = OrgService.RetrieveMultiple(new FetchExpression(fetchXml));
                        if (ConfigEntityCollection.Entities != null && ConfigEntityCollection.Entities[0].Attributes.Contains("tclab_stringvalue"))
                        {
                            Entity configItem = ConfigEntityCollection.Entities[0];
                            _configurationByVal.Add(key, configItem["tclab_stringvalue"].ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return _configurationByVal;
        }

        /*
        public Guid GetIndividualCustomerGuid(string CustomerExternalId)
        {
            string fetchXml = string.Empty;
            Guid CustomerGuid = Guid.Empty;
            try
            {
                if (!string.IsNullOrEmpty(CustomerExternalId))
                {
                    fetchXml = string.Format(FetchXMLs.FetchContactFields, CustomerExternalId);
                    EntityCollection _EntityCollection = OrgService.RetrieveMultiple(new FetchExpression(fetchXml));
                    if (_EntityCollection != null && _EntityCollection.Entities.Count > 0)
                    {
                        if (_EntityCollection.Entities[0].Attributes.Contains("contactid"))
                        {
                            CustomerGuid = new Guid(_EntityCollection.Entities[0].Attributes["contactid"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CustomerGuid;
        }
        */

            /*
        public Guid GetCorporateCustomerGuid(string CustomerExternalId)
        {
            string fetchXml = string.Empty;
            Guid CustomerGuid = Guid.Empty;
            try
            {
                if (!string.IsNullOrEmpty(CustomerExternalId))
                {
                    fetchXml = string.Format(FetchXMLs.FetchContactFields, CustomerExternalId);
                    EntityCollection _EntityCollection = OrgService.RetrieveMultiple(new FetchExpression(fetchXml));
                    if (_EntityCollection != null && _EntityCollection.Entities.Count > 0)
                    {
                        if (_EntityCollection.Entities[0].Attributes.Contains("contactid"))
                        {
                            CustomerGuid = new Guid(_EntityCollection.Entities[0].Attributes["contactid"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CustomerGuid;
        }
        */
        public Guid GetLookupGuidFromField(string entityName, string columnName, string columnValue)
        {
            QueryExpression retrieveQuery = new QueryExpression(entityName);
            retrieveQuery.Criteria.AddCondition(columnName, ConditionOperator.Equal, columnValue);
            EntityCollection retrievedCollection = OrgService.RetrieveMultiple(retrieveQuery);

            if (retrievedCollection.Entities.Count == 1)
            {
                return retrievedCollection[0].Id;
            }
            return Guid.Empty;
        }
        #endregion
    }
}