using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Crm.Sdk.Messages;

namespace AmxPeruPlugins
{
    /// <summary>
    /// Plugin purpose - Associate/Dissociate records between new_bispecrole and new_biconnectionmapping.
    /// Triggering Point - When In HTML selection is changed for specific role record.
    /// Exception - NA
    /// </summary>
   public class AssociateSubRoleBI : IPlugin
    {
        Entity _entity = null;
        ITracingService _ITracingService = null;
        IPluginExecutionContext _IPluginExecutionContext = null;
        IOrganizationServiceFactory _factory = null;
        IOrganizationService _service = null;
        Entity eachSubscriptionEntity = null;
        EntityReference subscriptionLookup = null;
        Guid subID = Guid.Empty;
        string subEntityType = null;

        string connectionfetch = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
                                                " <entity name='connection'>" +
                                                  "  <attribute name='record2id' />" +
                                                   " <attribute name='record2roleid' />" +
                                                   " <attribute name='connectionid' />" +
                                                    "<order attribute='record2id' descending='false' />" +
                                                    "<filter type='and'>" +
                                                     " <condition attribute='connectionid' operator='eq' value='{0}' />" +
                                                    "</filter>" +
                                                  "</entity>" +
                                                "</fetch>";
        public void Execute(IServiceProvider _provider)
        {
            try
            {
                _ITracingService = (ITracingService)_provider.GetService(typeof(ITracingService));
                _IPluginExecutionContext = (IPluginExecutionContext)_provider.GetService(typeof(IPluginExecutionContext));
                _factory = (IOrganizationServiceFactory)_provider.GetService(typeof(IOrganizationServiceFactory));
                _service = (IOrganizationService)_factory.CreateOrganizationService(_IPluginExecutionContext.UserId);

                if (_IPluginExecutionContext.InputParameters.Contains("Target") && _IPluginExecutionContext.InputParameters["Target"] is Entity)
                {
                    //  if (_IPluginExecutionContext.MessageName.ToUpper() == "CREATE") 
                    //  {
                    // _entity = (Entity)_IPluginExecutionContext.InputParameters["Target"];
                    _entity = (Entity)_IPluginExecutionContext.PostEntityImages["PostImage"];

                    string rolehiddenguid = _entity.Attributes["amxperu_rolehiddensubscriptionguid"].ToString();
                    //  string rolehiddenguid1 = _entity.Attributes["amxperu_rolehiddensubscriptionguid123"].ToString();
                    if (_entity.Attributes["amxperu_subscription1"] != null)
                    {
                        subscriptionLookup = (EntityReference)_entity.Attributes["amxperu_subscription1"];
                        subID = subscriptionLookup.Id;
                        subEntityType = subscriptionLookup.LogicalName;
                    }
                    string connectionID = _entity.Attributes["amxperu_selectedconnectionvalue"].ToString();
                    var connectedtoidrecord = _service.RetrieveMultiple(new FetchExpression(string.Format(connectionfetch, connectionID)));
                    if (connectedtoidrecord.Entities.Count > 0)
                    {
                        foreach (var con in connectedtoidrecord.Entities)
                        {
                            var rec2IdRef = con.Contains("record2id") ? con.GetAttributeValue<EntityReference>("record2id") : null;
                            ColumnSet subscriptionCols = new ColumnSet(new string[] { "etel_corporateuserid", "etel_individualuserid", "etel_name" });
                            eachSubscriptionEntity = _service.Retrieve("etel_subscription", subID, subscriptionCols);
                            if (rec2IdRef.LogicalName == "contact")
                            {
                                eachSubscriptionEntity["etel_corporateuserid"] = null;
                                eachSubscriptionEntity["etel_individualuserid"] = new EntityReference("contact", rec2IdRef.Id);
                            }
                            else if (rec2IdRef.LogicalName == "account")
                            {
                                eachSubscriptionEntity["etel_corporateuserid"] = new EntityReference("account", rec2IdRef.Id);
                                eachSubscriptionEntity["etel_individualuserid"] = null;
                            }
                            _service.Update(eachSubscriptionEntity);
                        }

                    }
                    //  string rolehiddenguid1 = _entity.Attributes["amxperu_rolehiddensubscriptionguid123"].ToString();
                    Guid SubscriptionGuid = CreateConnectionMapping(_entity, _service, eachSubscriptionEntity);
                    // string test = "test";
                    // _entity.Attributes.Add("amxperu_name", test);

                    //var connectionvalue = (_entity.Attributes["amxperu_selectedconnectionvalue"]).ToString();
                    //ColumnSet connectionColumns = new ColumnSet(new string[] { "name" });
                    //Entity connectionEntity = _service.Retrieve("connection", new Guid(connectionvalue), connectionColumns);
                    //_entity.Attributes.Add("amxperu_name", eachSubscriptionEntity["etel_name"] + "-" + connectionEntity["name"]);
                    //_service.Update(_entity);
                    //  }
                }

            }

            catch (Exception ex)
            {
                _ITracingService.Trace("Check Point Error.");

                throw new InvalidPluginExecutionException(ex.Message + "error from bisubrole");
            }
        }
        private Guid CreateConnectionMapping(Entity postImage, IOrganizationService _service, Entity subscription)
        {
            //Create A Record
            EntityReference customerLookup = null;
            string customerName = null;
            Guid customerGUID = Guid.Empty;
            Entity connectionmapping = new Entity("amxperu_biconnectionmapping");
            string rolehidden = postImage.Attributes["amxperu_rolehiddensubscriptionguid"].ToString();
            connectionmapping.Attributes.Add("amxperu_rolehiddenguids", rolehidden);
            EntityReference subscriptionLookup = (EntityReference)postImage.Attributes["amxperu_subscription1"];
            string subscriptionName = subscriptionLookup.Name;
            Guid subID = subscriptionLookup.Id;
            connectionmapping.Attributes.Add("amxperu_subscription12", new EntityReference("etel_subscription", subID));
            connectionmapping.Attributes.Add("amxperu_connectionguid", postImage.Attributes["amxperu_selectedconnectionvalue"]);
            var conn = (postImage.Attributes["amxperu_selectedconnectionvalue"]).ToString();
            ColumnSet connectionCols = new ColumnSet(new string[] { "name" });
            Entity connectionEntity = _service.Retrieve("connection", new Guid(conn), connectionCols);
            ColumnSet subCols = new ColumnSet(new string[] { "etel_name" });
            Entity subcolsEntity = _service.Retrieve("etel_subscription", subID, subCols);
            connectionmapping.Attributes.Add("amxperu_entitycheck1", postImage.Attributes["amxperu_entitycheck"]);

            if (_entity.Attributes["amxperu_individualcustomer"] != null)
            {
                customerLookup = (EntityReference)postImage.Attributes["amxperu_individualcustomer"];
                customerName = customerLookup.Name;
                customerGUID = customerLookup.Id;
                connectionmapping.Attributes.Add("amxperu_individualcustomer", new EntityReference("contact", customerGUID));
            }
            else if (_entity.Attributes["amxperu_corporatecustomer"] != null)
            {
                customerLookup = (EntityReference)postImage.Attributes["amxperu_corporatecustomer"];
                customerName = customerLookup.Name;
                customerGUID = customerLookup.Id;
                connectionmapping.Attributes.Add("amxperu_corporatecustomer", new EntityReference("account", customerGUID));
            }

            connectionmapping.Attributes.Add("amxperu_name", subcolsEntity["etel_name"] + "-" + connectionEntity["name"]);

            Guid createdSubscription = _service.Create(connectionmapping);

            if (connectionmapping.Contains("amxperu_rolehiddenguids"))
            {
                string passedGuid = connectionmapping.Attributes["amxperu_rolehiddenguids"].ToString();
                List<Guid> bISpecIDs = (new List<String>(passedGuid.Split(','))).Select(Guid.Parse).ToList();
                QueryExpression oldRelatedRecordQuery = new QueryExpression
                {
                    EntityName = "amxperu_bispecrole",
                    ColumnSet = new ColumnSet("etel_businessinteractionspecificationid"),
                    Criteria = new FilterExpression
                    {
                        FilterOperator = LogicalOperator.And,
                        Conditions =
                        {
                            new ConditionExpression("amxperu_biconnectionmappingid",ConditionOperator.Equal, createdSubscription)
                        }
                    }

                };
                EntityCollection oldRelatedRecordCollection = _service.RetrieveMultiple(oldRelatedRecordQuery);
                List<EntityReference> listOfRecordsForAssociation = new List<EntityReference>();
                List<EntityReference> listOfRecordsForDissociation = new List<EntityReference>();
                foreach (Entity biSpecificationEntity in oldRelatedRecordCollection.Entities)
                {
                    Guid relatedBISpecficationID = (Guid)(biSpecificationEntity.Attributes["etel_businessinteractionspecificationid"]);
                    if (bISpecIDs.Contains(relatedBISpecficationID))
                    {
                        bISpecIDs.Remove(relatedBISpecficationID);
                    }
                    else
                    {
                        listOfRecordsForDissociation.Add(new EntityReference("etel_businessinteractionspecification", relatedBISpecficationID));
                    }
                }

                foreach (Guid eachbISpecID in bISpecIDs)
                {
                    EntityReference linkedEntity = new EntityReference("etel_businessinteractionspecification", eachbISpecID);
                    listOfRecordsForAssociation.Add(linkedEntity);
                }
                if (listOfRecordsForAssociation.Count > 0)
                {
                    AssociateRequest AssociateRequest = new AssociateRequest();
                    AssociateRequest.Target = new EntityReference("amxperu_biconnectionmapping", createdSubscription);
                    AssociateRequest.RelatedEntities = new EntityReferenceCollection(listOfRecordsForAssociation);
                    AssociateRequest.Relationship = new Relationship("amxperu_bispecrole");
                    _service.Execute(AssociateRequest);
                }
                if (listOfRecordsForDissociation.Count > 0)
                {
                    DisassociateRequest DisassociateRequest = new DisassociateRequest();
                    DisassociateRequest.Target = new EntityReference("amxperu_biconnectionmapping", createdSubscription);
                    DisassociateRequest.RelatedEntities = new EntityReferenceCollection(listOfRecordsForDissociation);
                    DisassociateRequest.Relationship = new Relationship("amxperu_bispecrole");
                    _service.Execute(DisassociateRequest);
                }
            }
            //Check if it is Active or not
            var connectionMappingCols = new ColumnSet(new[] { "statecode", "statuscode" });
            var entity = _service.Retrieve("amxperu_biconnectionmapping", createdSubscription, connectionMappingCols);

            if (entity != null && entity.GetAttributeValue<OptionSetValue>("statecode").Value == 0)
            {
                //StateCode = 1 and StatusCode = 2 for deactivating Account or Contact
                SetStateRequest setStateRequest = new SetStateRequest()
                {
                    EntityMoniker = new EntityReference
                    {
                        Id = createdSubscription,
                        LogicalName = "amxperu_biconnectionmapping",
                    },
                    State = new OptionSetValue(1),
                    Status = new OptionSetValue(2)
                };
                _service.Execute(setStateRequest);
            }

            return createdSubscription;
        }
        private bool Associate(Entity associateentity, IOrganizationService _service)
        {
            if (_IPluginExecutionContext.Depth == 1)
            {

                if (associateentity.Attributes.Contains("amxperu_rolehiddensubscriptionguid"))
                {

                    //Get String of IDs and make list.
                    string passedGuid = associateentity.Attributes["amxperu_rolehiddensubscriptionguid"].ToString();
                    List<Guid> bISpecIDs = (new List<String>(passedGuid.Split(','))).Select(Guid.Parse).ToList();

                    QueryExpression oldRelatedRecordQuery = new QueryExpression()
                    {
                        EntityName = "amxperu_bispecrole",
                        ColumnSet = new ColumnSet("etel_businessinteractionspecificationid"),
                        Criteria = new FilterExpression
                        {
                            FilterOperator = LogicalOperator.And,
                            Conditions =
                                    {
                                        new ConditionExpression("amxperu_biconnectionmappingid",ConditionOperator.Equal, associateentity.Id)
                                    }
                        }

                    };
                    EntityCollection oldRelatedRecordCollection = _service.RetrieveMultiple(oldRelatedRecordQuery);

                    List<EntityReference> listOfRecordsForAssociation = new List<EntityReference>();

                    List<EntityReference> listOfRecordsForDissociation = new List<EntityReference>();

                    foreach (Entity biSpecificationEntity in oldRelatedRecordCollection.Entities)
                    {
                        Guid relatedBISpecficationID = (Guid)(biSpecificationEntity.Attributes["etel_businessinteractionspecificationid"]);
                        if (bISpecIDs.Contains(relatedBISpecficationID))
                        {
                            bISpecIDs.Remove(relatedBISpecficationID);

                        }
                        else
                        {

                            listOfRecordsForDissociation.Add(new EntityReference("etel_businessinteractionspecification", relatedBISpecficationID));
                        }
                    }

                    foreach (Guid eachbISpecID in bISpecIDs)
                    {
                        EntityReference linkedEntity = new EntityReference("etel_businessinteractionspecification", eachbISpecID);
                        listOfRecordsForAssociation.Add(linkedEntity);
                    }
                    if (listOfRecordsForAssociation.Count > 0)
                    {
                        AssociateRequest AssociateRequest = new AssociateRequest();

                        AssociateRequest.Target = new EntityReference("amxperu_bisubscriptionmapping", associateentity.Id);
                        AssociateRequest.RelatedEntities = new EntityReferenceCollection(listOfRecordsForAssociation);
                        AssociateRequest.Relationship = new Relationship("amxperu_bisubspecrole");
                        _service.Execute(AssociateRequest);
                    }
                    if (listOfRecordsForDissociation.Count > 0)
                    {
                        DisassociateRequest DisassociateRequest = new DisassociateRequest();

                        DisassociateRequest.Target = new EntityReference("amxperu_bisubscriptionmapping", associateentity.Id);
                        DisassociateRequest.RelatedEntities = new EntityReferenceCollection(listOfRecordsForDissociation);
                        DisassociateRequest.Relationship = new Relationship("amxperu_bisubspecrole");
                        _service.Execute(DisassociateRequest);
                    }
                }
            }
            return true;
        }
    }
}
