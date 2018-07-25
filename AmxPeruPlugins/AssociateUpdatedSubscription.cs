using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Crm.Sdk.Messages;

namespace AmxPeruPlugins
{
   public class AssociateUpdatedSubscription : IPlugin
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
        Entity connectionmappingEntity = null;

        Entity connectionEntityForName = null;
        Entity connectionEntityForName1 = null;


        // Take out Connection Record as per passing newly selected Connection Value
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
        // fetch c.m record ID passing subscription ID as I/P
        string connectionmappingfetch = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
  "   <entity name='amxperu_biconnectionmapping'>" +
   "      <attribute name='amxperu_biconnectionmappingid' />" +
    "     <attribute name='amxperu_name' />" +
     "    <attribute name='createdon' />" +
      "   <order attribute='amxperu_name' descending='false' />" +
       "  <filter type='and'>" +
        "     <condition attribute='amxperu_subscription12' operator='eq'  value='{0}' />" +
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
                //   Entity postEntityImage = (Entity)_IPluginExecutionContext.PostEntityImages["PostImage"];
                if (_IPluginExecutionContext.InputParameters.Contains("Target") && _IPluginExecutionContext.InputParameters["Target"] is Entity)
                {
                    //throw new InvalidPluginExecutionException("error from my code");
                    //  _entity = (Entity)_IPluginExecutionContext.InputParameters["Target"];
                    _entity = (Entity)_IPluginExecutionContext.PostEntityImages["PostImage"];
                    //subscription field name

                    if (_entity.Attributes["amxperu_subscriptionupdate"] != null)
                    {
                        subscriptionLookup = (EntityReference)_entity.Attributes["amxperu_subscriptionupdate"];
                        subID = subscriptionLookup.Id;
                        subEntityType = subscriptionLookup.LogicalName;
                    }
                    var connectionmppingidrecord = _service.RetrieveMultiple(new FetchExpression(string.Format(connectionmappingfetch, subID)));

                    string newconnectionID = _entity.Attributes["amxperu_newselectedconnection"].ToString();
                    if (newconnectionID != null)
                    {
                        var connectedtoidrecord = _service.RetrieveMultiple(new FetchExpression(string.Format(connectionfetch, newconnectionID)));
                        if (connectedtoidrecord.Entities.Count > 0)
                        {
                            var rec2IdRef = connectedtoidrecord.Entities[0].Contains("record2id") ? connectedtoidrecord.Entities[0].GetAttributeValue<EntityReference>("record2id") : null;
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
                            // Updating Conection Value in c.m Record
                            // connectionmppingidrecord.Entities[0].GetAttributeValue("etel_corporateuserid") =    _entity.Attributes.Contains("amxperu_newlyselectedconnectionvalue");

                            ColumnSet connectionCols = new ColumnSet(new string[] { "amxperu_name", "amxperu_connectionguid" });
                            connectionmappingEntity = _service.Retrieve("amxperu_biconnectionmapping", connectionmppingidrecord.Entities[0].Id, connectionCols);
                            //Update Newly selected Connection Value Field
                            connectionmappingEntity["amxperu_connectionguid"] = _entity["amxperu_newselectedconnection"];
                            ColumnSet connectionColsName = new ColumnSet(new string[] { "name" });
                            connectionEntityForName = _service.Retrieve("connection", new Guid(connectionmappingEntity.GetAttributeValue<string>("amxperu_connectionguid").ToString()), connectionColsName);
                            connectionmappingEntity["amxperu_name"] = eachSubscriptionEntity["etel_name"] + "-" + connectionEntityForName["name"];
                            _service.Update(connectionmappingEntity);
                        }
                    }

                    // field name of adding guids on click of checkbox
                    if (_entity.Attributes.Contains("amxperu_rolehiddenguidsupdate"))
                    {
                        // associate the old connection mapping record with Associated Records
                        string passedGuid = _entity.Attributes["amxperu_rolehiddenguidsupdate"].ToString();
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
                                        new ConditionExpression("amxperu_biconnectionmappingid",ConditionOperator.Equal,connectionmppingidrecord.Entities[0].Id)
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

                            AssociateRequest.Target = new EntityReference("amxperu_biconnectionmapping", connectionmppingidrecord.Entities[0].Id);
                            AssociateRequest.RelatedEntities = new EntityReferenceCollection(listOfRecordsForAssociation);
                            AssociateRequest.Relationship = new Relationship("amxperu_bispecrole");
                            _service.Execute(AssociateRequest);
                        }
                        if (listOfRecordsForDissociation.Count > 0)
                        {
                            DisassociateRequest DisassociateRequest = new DisassociateRequest();

                            DisassociateRequest.Target = new EntityReference("amxperu_biconnectionmapping", connectionmppingidrecord.Entities[0].Id);
                            DisassociateRequest.RelatedEntities = new EntityReferenceCollection(listOfRecordsForDissociation);
                            DisassociateRequest.Relationship = new Relationship("amxperu_bispecrole");
                            _service.Execute(DisassociateRequest);
                        }
                        var subscriptionMappingUpdateCols = new ColumnSet(new[] { "statecode", "statuscode" });
                        var entity = _service.Retrieve("amxperu_bisubscriptionmappingupdate", _IPluginExecutionContext.PrimaryEntityId, subscriptionMappingUpdateCols);

                        if (entity != null && entity.GetAttributeValue<OptionSetValue>("statecode").Value == 0)
                        {
                            //StateCode = 1 and StatusCode = 2 for deactivating Account or Contact
                            SetStateRequest setStateRequest = new SetStateRequest()
                            {
                                EntityMoniker = new EntityReference
                                {
                                    Id = _IPluginExecutionContext.PrimaryEntityId,
                                    LogicalName = "amxperu_bisubscriptionmappingupdate",
                                },
                                State = new OptionSetValue(1),
                                Status = new OptionSetValue(2)
                            };
                            _service.Execute(setStateRequest);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                _ITracingService.Trace("Check Point Error.");


            }
        }

    }
}
