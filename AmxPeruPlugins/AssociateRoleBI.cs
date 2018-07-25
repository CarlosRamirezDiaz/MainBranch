using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmxPeruPlugins
{
    /// <summary>
    /// Plugin purpose - Associate/Dissociate records between new_bispecrole and new_biconnectionmapping.
    /// Triggering Point - When In HTML selection is changed for specific role record.
    /// Exception - NA
    /// </summary>
    public class AssociateRoleBI : IPlugin
    {
        Entity _entity = null;
        ITracingService _ITracingService = null;
        IPluginExecutionContext _IPluginExecutionContext = null;
        IOrganizationServiceFactory _factory = null;
        IOrganizationService _service = null;

        //  List<string> Guids = null;
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
                    //   _entity = (Entity)_IPluginExecutionContext.InputParameters["Target"];
                    _entity = (Entity)_IPluginExecutionContext.PostEntityImages["POSTIMG"];

                    if (_IPluginExecutionContext.Depth == 1)
                    {

                        if (_entity.Attributes.Contains("amxperu_rolehiddensubscriptionguid"))
                        {

                            //Get String of IDs and make list.
                            string passedGuid = _entity.Attributes["amxperu_rolehiddensubscriptionguid"].ToString();
                            List<Guid> bISpecIDs = (new List<String>(passedGuid.Split(','))).Select(Guid.Parse).ToList();
                            //Entity ss = _service.Retrieve("amxperu_bisubscriptionmapping", new Guid("a7ae1fca-a086-e711-8116-00505601173a"), new ColumnSet(true));

                            QueryExpression oldRelatedRecordQuery = new QueryExpression()
                            {
                                EntityName = "amxperu_bisubspecrole",
                                ColumnSet = new ColumnSet("etel_businessinteractionspecificationid"),
                                Criteria = new FilterExpression
                                {
                                    FilterOperator = LogicalOperator.And,
                                    Conditions =
                                    {
                                        new ConditionExpression("amxperu_bisubscriptionmappingid",ConditionOperator.Equal, _entity.Id)
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
                                if (eachbISpecID != Guid.Empty)
                                {
                                    EntityReference linkedEntity = new EntityReference("etel_businessinteractionspecification", eachbISpecID);
                                    listOfRecordsForAssociation.Add(linkedEntity);
                                }
                            }

                            if (listOfRecordsForAssociation.Count > 0)
                            {
                                AssociateRequest _AssociateRequest = null;
                                _AssociateRequest = new AssociateRequest();

                                _AssociateRequest.Target = new EntityReference("amxperu_bisubscriptionmapping", _entity.Id);
                                _AssociateRequest.RelatedEntities = new EntityReferenceCollection(listOfRecordsForAssociation);
                                _AssociateRequest.Relationship = new Relationship("amxperu_bisubspecrole");
                                _service.Execute(_AssociateRequest);
                            }
                            if (listOfRecordsForDissociation.Count > 0)
                            {
                                DisassociateRequest DisassociateRequest = new DisassociateRequest();

                                DisassociateRequest.Target = new EntityReference("amxperu_bisubscriptionmapping", _entity.Id);
                                DisassociateRequest.RelatedEntities = new EntityReferenceCollection(listOfRecordsForDissociation);
                                DisassociateRequest.Relationship = new Relationship("amxperu_bisubspecrole");
                                _service.Execute(DisassociateRequest);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _ITracingService.Trace("Check Point Error.");
                throw new InvalidPluginExecutionException(ex.Message + "error from rolebi");
            }
        }
    }
}
