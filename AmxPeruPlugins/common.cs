using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace AmxPeruPlugins
{
    public static class common
    {
        public static void CreateBILogValues(Entity postImage, IOrganizationService OrgService, BILogSchema biLogSchema)
        {
            string customerTypeName = string.Empty;
            string CustomerTypeField = string.Empty;
            string customerFilterField = string.Empty;
            Guid customerGuid = Guid.Empty;
            string fetchXmlBiHeader = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                      <entity name='etel_bi_header'>
                                        <attribute name='activityid' />
                                        <attribute name='createdon' />
                                        <order attribute='subject' descending='false' />
                                        <filter type='and'>
                                          <condition attribute='createdby' operator='eq' value='{0}' />
                                          <condition attribute='etel_headerstatus' operator='eq' value='1' />
                                        </filter>
                                      </entity>
                                    </fetch>";
            Guid loggedinUserId = Guid.Empty;
            Guid BIHeaderRecordGuid = Guid.Empty;

            try
            {
                if (biLogSchema != null)
                {
                    if (biLogSchema.LoggedInUserId != Guid.Empty)
                    {
                        loggedinUserId = biLogSchema.LoggedInUserId;
                    }
                }

                Entity biLogActivityEnt = new Entity("etel_bi_log");
                if (postImage.Attributes.Contains("amxbase_isexternal"))
                {
                    if (!(bool)postImage.Attributes["amxbase_isexternal"])
                    {
                        fetchXmlBiHeader = string.Format(fetchXmlBiHeader, loggedinUserId);
                        EntityCollection _EntityCollection = OrgService.RetrieveMultiple(new FetchExpression(fetchXmlBiHeader));

                        if (_EntityCollection != null)
                        {
                            if (_EntityCollection.Entities.Count > 0)
                            {
                                //Get the BI Header for this BI Activity
                                BIHeaderRecordGuid = new Guid(_EntityCollection.Entities[0].Attributes["activityid"].ToString());
                            }
                        }

                        if (BIHeaderRecordGuid != Guid.Empty)
                        {
                            //Update the Subject of the Bi Header with the BI Activity
                            Entity tempEnt = new Entity("etel_bi_header");
                            ColumnSet columnSet = new ColumnSet(new string[] { "activityid", "createdon" });
                            tempEnt = OrgService.Retrieve(tempEnt.LogicalName, BIHeaderRecordGuid, columnSet);
                            tempEnt.Attributes.Add("subject", "Customer Address Update");
                            OrgService.Update(tempEnt);
                            biLogActivityEnt.Attributes.Add("etel_bi_headerid", new EntityReference("etel_bi_header", BIHeaderRecordGuid));
                        }
                    }
                }

                biLogActivityEnt.Attributes.Add("scheduledend", DateTime.Now);
                biLogActivityEnt.Attributes.Add("subject", biLogSchema.Subject);
                biLogActivityEnt.Attributes.Add("etel_description", biLogSchema.Description);
                biLogActivityEnt.Attributes.Add("etel_customerchannel", biLogSchema.Channel);
                if (postImage.Attributes.Contains("etel_individualcustomer"))
                {
                    customerTypeName = "contact";
                    customerFilterField = "contactid";
                    CustomerTypeField = "etel_individualcustomerid";
                    customerGuid = (postImage.Attributes["etel_individualcustomer"] as EntityReference).Id;
                }
                else if (postImage.Attributes.Contains("etel_corporatecustomer"))
                {
                    customerTypeName = "account";
                    customerFilterField = "accountid";
                    CustomerTypeField = "etel_corporatecustomerid";
                    customerGuid = (postImage.Attributes["etel_corporatecustomer"] as EntityReference).Id;
                }
                QueryExpression searchQuery = new QueryExpression(customerTypeName);
                searchQuery.Criteria.AddCondition(customerFilterField, ConditionOperator.Equal, customerGuid);
                EntityCollection contactRecords = OrgService.RetrieveMultiple(searchQuery);
                if (contactRecords.Entities.Count > 0)
                {
                    biLogActivityEnt[CustomerTypeField] = new EntityReference(contactRecords[0].LogicalName, contactRecords[0].Id);
                    Entity party1 = new Entity("activityparty");
                    party1["partyid"] = new EntityReference(contactRecords[0].LogicalName, contactRecords[0].Id);
                    EntityCollection entCollection = new EntityCollection();
                    entCollection.Entities.Add(party1);
                    biLogActivityEnt["customers"] = entCollection;
                }
                biLogActivityEnt.Attributes.Add("regardingobjectid", new EntityReference(postImage.LogicalName, postImage.Id));
                Guid CreatedBiLogGuid = OrgService.Create(biLogActivityEnt);
                if (postImage.LogicalName == "etel_ordercapture")
                {
                    if (CreatedBiLogGuid != null)
                    {
                        EntityReference moniker = new EntityReference();
                        moniker.LogicalName = "etel_bi_log";
                        moniker.Id = CreatedBiLogGuid;
                        OrganizationRequest orgrequest = new OrganizationRequest() { RequestName = "SetState" };
                        orgrequest["EntityMoniker"] = moniker;
                        OptionSetValue state = new OptionSetValue(1);
                        OptionSetValue status = new OptionSetValue(2);
                        orgrequest["State"] = state;
                        orgrequest["Status"] = status;
                        OrgService.Execute(orgrequest);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string RetrieveAmxConfigValue(IOrganizationService OrgService, string keyName)
        {
            string configValue = string.Empty;
            string fetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                  <entity name='amxperu_amxconfigurations'>
                                    <attribute name='amxperu_amxconfigurationsid' />
                                    <attribute name='amxperu_value' />
                                    <filter type='and'>
                                      <condition attribute='amxperu_name' operator='eq' value='{0}' />
                                    </filter>
                                  </entity>
                                </fetch>";

            try
            {
                fetchXml = string.Format(fetchXml, keyName);
                EntityCollection _EntityCollection = OrgService.RetrieveMultiple(new FetchExpression(fetchXml));
                if (_EntityCollection != null && _EntityCollection.Entities.Count > 0)
                {
                    if (_EntityCollection.Entities.Count == 1)
                    {
                         configValue = _EntityCollection[0].GetAttributeValue<string>("amxperu_value");
                    }
                    else
                    {
                        //throw new InvalidPluginExecutionException(Constants.MultipleValuesFound + keyName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return configValue;
        }

        public static string FetchCustomerExternalIdViaGuid(IOrganizationService OrgService, string customerGuid)
        {
            string csIdPub = string.Empty;

            try
            {
                csIdPub = (OrgService.Retrieve("contact", new Guid(customerGuid), new ColumnSet("etel_externalid"))).Attributes["etel_externalid"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return csIdPub;
        }

        public static void SetRecordStatus(IOrganizationService OrgService, string EntityName, Guid recordId, int StateCode, int StatusCode)
        {
            var entEntityName = OrgService.Retrieve(EntityName, recordId, new ColumnSet(new[] { "statecode", "statuscode" }));
            try
            {
                if (entEntityName != null)
                {
                    SetStateRequest objSetStateRequest = new SetStateRequest()
                    {
                        EntityMoniker = new EntityReference(EntityName, recordId),
                        State = new OptionSetValue(StateCode),
                        Status = new OptionSetValue(StatusCode),
                    };
                    OrgService.Execute(objSetStateRequest);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Dictionary<string, string> GetTranslatedMessagesForPluginClass(IOrganizationService OrgService, int languageId, string formId)
        {
            Dictionary<string, string> translatedMessages = new Dictionary<string, string>();

            try
            {
                QueryExpression translationQuery = new QueryExpression("etel_translation");
                translationQuery.Criteria.AddCondition("etel_formid", ConditionOperator.Equal, formId);
                translationQuery.Criteria.AddCondition("etel_lcid", ConditionOperator.Equal, languageId);
                translationQuery.ColumnSet = new ColumnSet("etel_message", "etel_code");
                EntityCollection translationRecords = OrgService.RetrieveMultiple(translationQuery);
                if (translationRecords != null && translationRecords.Entities.Count > 0)
                {
                    foreach (Entity translationItem in translationRecords.Entities)
                    {
                        if (translationItem.Contains("etel_code") && translationItem.Contains("etel_message"))
                        {
                            translatedMessages.Add(translationItem.Attributes["etel_code"].ToString(), translationItem.Attributes["etel_message"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return translatedMessages;
        }

        public static Guid CreateBILogValues(IOrganizationService OrgService, BILogRequest biLogRequest)
        {
            Guid createdBiLogEntryGuid = Guid.Empty;
            Guid loggedinUserId = Guid.Empty;

            try
            {
                if (biLogRequest != null)
                {
                    Entity biLogEntity = new Entity("etel_bi_log");

                    if (biLogRequest.LoggedInUserId != Guid.Empty)
                    {
                        loggedinUserId = biLogRequest.LoggedInUserId;
                    }

                    createdBiLogEntryGuid = OrgService.Create(biLogEntity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return createdBiLogEntryGuid;
        }

        public static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        public static XmlDocument CreateSoapEnvelope(string SOAPXML)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(SOAPXML);
            return soapEnvelop;
        }

        public static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }       
    }

    public static class Constants
    {
        #region [Programming Purpose]
        public static string IndividualCreationEntityName = "amxperu_createindividual";
        public static string CorporateCreationEntityName = "amxperu_corporatecreate";
        public static string EntityLogicalNameFinancialAgreement = "amxbase_financialagreement";
        #endregion

        #region [Translation Required]
        public static string MultipleValuesFound = "Multiple Configuration Values Found With Same Key : ";
        #endregion
    }
}