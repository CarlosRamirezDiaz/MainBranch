using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using System;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;

namespace AmxPeruPlugins.Workflow.ProductOfferingOperations
{
    public class ProductVersionHandler
    {
        public IActionContext actionContext = null;

        public ProductVersionHandler(IActionContext context)
        {
            actionContext = context;
        }

        private void SetStatus(string entityName, Guid entityId, int stateCode, int statusCode)
        {
            SetStateRequest req = new SetStateRequest();
            req.EntityMoniker = new EntityReference(entityName, entityId);

            req.State = new OptionSetValue(stateCode);
            req.Status = new OptionSetValue(statusCode);
            actionContext.OrganizationService.Execute(req);
        }

        //IMPORTANT: Async Workflow
        public void Execute(Guid productVersionId)
        {
            var dataContext = actionContext.XrmDataContext;
            var resultVersionHandler = actionContext.OrganizationService.Retrieve("amxperu_productversionhandler", productVersionId, new ColumnSet(true));
            var status = ((OptionSetValue)resultVersionHandler.Attributes["statuscode"]).Value;

            Guid productId = Guid.Empty;
            Guid infoTableId = Guid.Empty;
            Guid infoTableRecordId = Guid.Empty;
            Guid availabilityRecordId = Guid.Empty;
            Guid popConfigurationRecordId = Guid.Empty;

            Product product = new Product();

            if ((resultVersionHandler.Contains("amxperu_productofferingid")) && (resultVersionHandler.Attributes["amxperu_productofferingid"] != null))
            {
                productId = ((EntityReference)resultVersionHandler.Attributes["amxperu_productofferingid"]).Id;
                product = (Product)actionContext.OrganizationService.Retrieve(Product.EntityLogicalName, productId, new ColumnSet(true));
            }

            if ((resultVersionHandler.Contains("amxperu_infotableid")) && (resultVersionHandler.Attributes["amxperu_infotableid"] != null))
            {
                infoTableId = ((EntityReference)resultVersionHandler.Attributes["amxperu_infotableid"]).Id;
            }

            if ((resultVersionHandler.Contains("amxperu_infotablerecordid")) && (resultVersionHandler.Attributes["amxperu_infotablerecordid"] != null))
            {
                infoTableRecordId = ((EntityReference)resultVersionHandler.Attributes["amxperu_infotablerecordid"]).Id;
            }

            if ((resultVersionHandler.Contains("amxperu_availabilityconfigurationid")) && (resultVersionHandler.Attributes["amxperu_availabilityconfigurationid"] != null))
            {
                availabilityRecordId = ((EntityReference)resultVersionHandler.Attributes["amxperu_availabilityconfigurationid"]).Id;
            }

            if ((resultVersionHandler.Contains("amxperu_productofferingpriceconfigurationid")) && (resultVersionHandler.Attributes["amxperu_productofferingpriceconfigurationid"] != null))
            {
                popConfigurationRecordId = ((EntityReference)resultVersionHandler.Attributes["amxperu_productofferingpriceconfigurationid"]).Id;
            }

            if (productId != Guid.Empty)
            {
                if (status == 100000000) //Completed status version handler record
                {
                    //set status of previous PO as Expired
                    var resultPOVersions = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = "etel_offeringversion",
                        ColumnSet = new ColumnSet(true),
                        Criteria = new FilterExpression() { Conditions = { new ConditionExpression("etel_currentversionid", ConditionOperator.Equal, productId) } }
                    });

                    if (resultPOVersions.Entities.Count > 0)
                    {
                        foreach (var item in resultPOVersions.Entities)
                        {
                            SetStatus(Product.EntityLogicalName, ((EntityReference)item.Attributes["etel_previousversionid"]).Id, 1, 2);

                            var resultPOPConfigVersions = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                            {
                                EntityName = "amxperu_productofferingpriceconfiguration",
                                ColumnSet = new ColumnSet(true),
                                Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_productoffering", ConditionOperator.Equal, ((EntityReference)item.Attributes["etel_previousversionid"]).Id) } }
                            });

                            if (resultPOPConfigVersions.Entities.Count > 0)
                            {
                                foreach (var config in resultPOPConfigVersions.Entities)
                                {
                                    SetStatus("amxperu_productofferingpriceconfiguration", config.Id, 1, 2);
                                }
                            }

                            UpdateAssociations(productId, ((EntityReference)item.Attributes["etel_previousversionid"]).Id, product.etel_externalid);
                            UpdateGroupSubOffers(productId, ((EntityReference)item.Attributes["etel_previousversionid"]).Id);

                            UpdateAvailabilityConfiguration(productId, ((EntityReference)item.Attributes["etel_previousversionid"]).Id);

                            UpdatePOPConfiguration(productId, ((EntityReference)item.Attributes["etel_previousversionid"]).Id);
                            UpdatePOP(productId, ((EntityReference)item.Attributes["etel_previousversionid"]).Id);
                        }
                    }
                    else
                    {
                        UpdateAssociations(productId, Guid.Empty, product.etel_externalid);
                    }

                    //set status of PO as Available 
                    SetStatus(Product.EntityLogicalName, productId, 0, 1);
                }
                else
                {
                    //set status of PO as Available 
                    SetStatus(Product.EntityLogicalName, productId, 0, 1);

                    //set status of POP Cofigs as Available 
                    var resultPOPConfig = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = "amxperu_productofferingpriceconfiguration",
                        ColumnSet = new ColumnSet(true),
                        Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_productoffering", ConditionOperator.Equal, productId) } }
                    });

                    if (resultPOPConfig.Entities.Count > 0)
                    {
                        foreach (var item in resultPOPConfig.Entities)
                        {
                            SetStatus("amxperu_productofferingpriceconfiguration", item.Id, 0, 1);
                        }
                    }

                    //set status of previous PO as Expired
                    var resultPOVersions = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = "etel_offeringversion",
                        ColumnSet = new ColumnSet(true),
                        Criteria = new FilterExpression() { Conditions = { new ConditionExpression("etel_currentversionid", ConditionOperator.Equal, productId) } }
                    });

                    if (resultPOVersions.Entities.Count > 0)
                    {
                        foreach (var item in resultPOVersions.Entities)
                        {
                            SetStatus(Product.EntityLogicalName, ((EntityReference)item.Attributes["etel_previousversionid"]).Id, 1, 2);

                            var resultPOPConfigVersions = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                            {
                                EntityName = "amxperu_productofferingpriceconfiguration",
                                ColumnSet = new ColumnSet(true),
                                Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_productoffering", ConditionOperator.Equal, ((EntityReference)item.Attributes["etel_previousversionid"]).Id) } }
                            });

                            if (resultPOPConfigVersions.Entities.Count > 0)
                            {
                                foreach (var config in resultPOPConfigVersions.Entities)
                                {
                                    SetStatus("amxperu_productofferingpriceconfiguration", config.Id, 1, 2);
                                }
                            }

                            UpdateAssociations(productId, ((EntityReference)item.Attributes["etel_previousversionid"]).Id, product.etel_externalid);
                            UpdateGroupSubOffers(productId, ((EntityReference)item.Attributes["etel_previousversionid"]).Id);

                            UpdateAvailabilityConfiguration(productId, ((EntityReference)item.Attributes["etel_previousversionid"]).Id);

                            UpdatePOPConfiguration(productId, ((EntityReference)item.Attributes["etel_previousversionid"]).Id);
                            UpdatePOP(productId, ((EntityReference)item.Attributes["etel_previousversionid"]).Id);
                        }
                    }
                    else
                    {
                        UpdateAssociations(productId, Guid.Empty, product.etel_externalid);
                    }

                }

                //version handler will be completed
                SetStatus("amxperu_productversionhandler", productVersionId, 1, 2);
            }
            else if (infoTableId != Guid.Empty)
            {
                //Data Model
                var resultInfoTable = actionContext.OrganizationService.Retrieve("amxperu_infotable", infoTableId, new ColumnSet("amxperu_previousinfotableid"));

                var resultPOPConfiguration = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "amxperu_productofferingpriceconfiguration",
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_infotableid", ConditionOperator.Equal, infoTableId) } }
                });

                var resultPOAvailability = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "amxperu_productofferingavailabilityconfiguratio",
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_infotableid", ConditionOperator.Equal, infoTableId) } }
                });

                var resultInfoTableRecord = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "amxperu_infotablerecord",
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_infotableid", ConditionOperator.Equal, infoTableId) } }
                });

                if (resultPOPConfiguration.Entities.Count > 0)
                {
                    foreach (var config in resultPOPConfiguration.Entities)
                    {
                        SetStatus("amxperu_productofferingpriceconfiguration", config.Id, 0, 1);
                    }

                    var resultPreviousPOPConfiguration = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = "amxperu_productofferingpriceconfiguration",
                        ColumnSet = new ColumnSet("amxperu_productofferingpriceconfigurationid"),
                        Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_infotableid", ConditionOperator.Equal, resultInfoTable.Attributes["amxperu_previousinfotableid"]) } }
                    });

                    foreach (var config in resultPreviousPOPConfiguration.Entities)
                    {
                        SetStatus("amxperu_productofferingpriceconfiguration", config.Id, 1, 2);
                    }
                }

                if (resultPOAvailability.Entities.Count > 0)
                {
                    foreach (var config in resultPOAvailability.Entities)
                    {
                        SetStatus("amxperu_productofferingavailabilityconfiguratio", config.Id, 0, 1);
                    }

                    var resultPreviousPOAvailability = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = "amxperu_productofferingavailabilityconfiguratio",
                        ColumnSet = new ColumnSet("amxperu_productofferingavailabilityconfiguratioid"),
                        Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_infotableid", ConditionOperator.Equal, resultInfoTable.Attributes["amxperu_previousinfotableid"]) } }
                    });

                    foreach (var config in resultPreviousPOAvailability.Entities)
                    {
                        SetStatus("amxperu_productofferingavailabilityconfiguratio", config.Id, 1, 2);
                    }
                }

                if (resultInfoTableRecord.Entities.Count > 0)
                {
                    foreach (var config in resultPOAvailability.Entities)
                    {
                        SetStatus("amxperu_infotablerecord", config.Id, 0, 1);
                    }

                    var resultPreviousInfoTableRecord = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = "amxperu_infotablerecord",
                        ColumnSet = new ColumnSet("amxperu_infotablerecordid"),
                        Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_infotableid", ConditionOperator.Equal, resultInfoTable.Attributes["amxperu_previousinfotableid"]) } }
                    });

                    foreach (var config in resultPreviousInfoTableRecord.Entities)
                    {
                        SetStatus("amxperu_infotablerecord", config.Id, 1, 2);
                    }
                }

                //version handler will be completed
                SetStatus("amxperu_productversionhandler", productVersionId, 1, 2);
            }
            else if (infoTableRecordId != Guid.Empty)
            {
                var infoTableRecord = actionContext.OrganizationService.Retrieve("amxperu_infotablerecord", infoTableRecordId, new ColumnSet(true));

                if (Convert.ToDateTime(infoTableRecord.Attributes["amxperu_startdate"]) < DateTime.Now)
                {
                    if (infoTableRecord.Attributes["amxperu_cancel"].ToString() == "1") //Disable
                    {
                        SetStatus("amxperu_infotablerecord", infoTableRecordId, 1, 2);

                    }
                    if (infoTableRecord.Attributes["amxperu_cancel"].ToString() != "1") //Modify or New
                    {
                        //Previous records will be Expire, new record will be Active

                        var result = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                        {
                            EntityName = "amxperu_infotablerecord",
                            ColumnSet = new ColumnSet(true),
                            Criteria = new FilterExpression()
                            {
                                Conditions = {  new ConditionExpression("amxperu_infotableid", ConditionOperator.Equal, ((EntityReference)infoTableRecord.Attributes["amxperu_infotableid"]).Id),
                                                new ConditionExpression("amxperu_code", ConditionOperator.Equal, infoTableRecord.Attributes["amxperu_code"].ToString()) ,
                                                new ConditionExpression("statecode", ConditionOperator.Equal, 0)}
                            }
                        });

                        if (result.Entities.Count > 0)
                        {
                            foreach (var item in result.Entities)
                            {
                                if ((item.Id == infoTableRecordId) && (((OptionSetValue)item.Attributes["statuscode"]).Value.ToString() == "250000000"))
                                {
                                    Entity rec = new Entity("amxperu_infotablerecord");
                                    rec.Id = item.Id;
                                    rec.Attributes["statuscode"] = new OptionSetValue(1);
                                    actionContext.OrganizationService.Update(rec);
                                }
                                else
                                {
                                    SetStatus("amxperu_infotablerecord", item.Id, 1, 2);
                                }
                            }
                        }
                    }

                    //version handler will be completed
                    SetStatus("amxperu_productversionhandler", productVersionId, 1, 2);
                }
            }
            else if (availabilityRecordId != Guid.Empty)
            {
                var availabilityRecord = actionContext.OrganizationService.Retrieve("amxperu_productofferingavailabilityconfiguratio", availabilityRecordId, new ColumnSet(true));

                if (Convert.ToDateTime(availabilityRecord.Attributes["amxperu_startdate"]) < DateTime.Now)
                {
                    if (availabilityRecord.Attributes["amxperu_cancel"].ToString() == "1") //Disable
                    {
                        SetStatus("amxperu_productofferingavailabilityconfiguratio", availabilityRecordId, 1, 2);

                    }
                    if (availabilityRecord.Attributes["amxperu_cancel"].ToString() != "1") //Modify or New
                    {
                        //Previous records will be Expire, new record will be Active

                        var result = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                        {
                            EntityName = "amxperu_productofferingavailabilityconfiguratio",
                            ColumnSet = new ColumnSet(true),
                            Criteria = new FilterExpression()
                            {
                                Conditions = {  new ConditionExpression("amxperu_infotableid", ConditionOperator.Equal, ((EntityReference)availabilityRecord.Attributes["amxperu_infotableid"]).Id),
                                                new ConditionExpression("amxperu_code", ConditionOperator.Equal, availabilityRecord.Attributes["amxperu_code"].ToString()) ,
                                                new ConditionExpression("statecode", ConditionOperator.Equal, 0)}
                            }
                        });

                        if (result.Entities.Count > 0)
                        {
                            foreach (var item in result.Entities)
                            {
                                if (((OptionSetValue)item.Attributes["statuscode"]).Value.ToString() == "250000000")
                                {
                                    Entity rec = new Entity("amxperu_productofferingavailabilityconfiguratio");
                                    rec.Id = item.Id;
                                    rec.Attributes["statuscode"] = new OptionSetValue(1);
                                    actionContext.OrganizationService.Update(rec);
                                }
                                else
                                {
                                    SetStatus("amxperu_productofferingavailabilityconfiguratio", item.Id, 1, 2);
                                }
                            }
                        }
                    }

                    //version handler will be completed
                    SetStatus("amxperu_productversionhandler", productVersionId, 1, 2);
                }
            }
            else if (popConfigurationRecordId != Guid.Empty)
            {
                var popConfigurationRecord = actionContext.OrganizationService.Retrieve("amxperu_productofferingpriceconfiguration", popConfigurationRecordId, new ColumnSet(true));

                if (Convert.ToDateTime(popConfigurationRecord.Attributes["amxperu_startdate"]) < DateTime.Now)
                {
                    if (popConfigurationRecord.Attributes["amxperu_cancel"].ToString() == "1") //Disable
                    {
                        SetStatus("amxperu_productofferingpriceconfiguration", popConfigurationRecordId, 1, 2);

                    }
                    if (popConfigurationRecord.Attributes["amxperu_cancel"].ToString() != "1") //Modify or New
                    {
                        //Previous records will be Expire, new record will be Active

                        var result = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                        {
                            EntityName = "amxperu_productofferingpriceconfiguration",
                            ColumnSet = new ColumnSet(true),
                            Criteria = new FilterExpression()
                            {
                                Conditions = {  new ConditionExpression("amxperu_infotableid", ConditionOperator.Equal, ((EntityReference)popConfigurationRecord.Attributes["amxperu_infotableid"]).Id),
                                                new ConditionExpression("amxperu_code", ConditionOperator.Equal, popConfigurationRecord.Attributes["amxperu_code"].ToString()) ,
                                                new ConditionExpression("statecode", ConditionOperator.Equal, 0)}
                            }
                        });

                        if (result.Entities.Count > 0)
                        {
                            foreach (var item in result.Entities)
                            {
                                if (((OptionSetValue)item.Attributes["statuscode"]).Value.ToString() == "250000000")
                                {
                                    Entity rec = new Entity("amxperu_productofferingpriceconfiguration");
                                    rec.Id = item.Id;
                                    rec.Attributes["statuscode"] = new OptionSetValue(1);
                                    actionContext.OrganizationService.Update(rec);
                                }
                                else
                                {
                                    SetStatus("amxperu_productofferingpriceconfiguration", item.Id, 1, 2);
                                }
                            }
                        }
                    }

                    //version handler will be completed
                    SetStatus("amxperu_productversionhandler", productVersionId, 1, 2);
                }
            }
        }

        private void UpdateAvailabilityConfiguration(Guid productId, Guid previousProductId)
        {
            if (previousProductId != Guid.Empty)
            {
                var resultAvailabilies = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "amxperu_productofferingavailabilityconfiguratio",
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_productofferingid", ConditionOperator.Equal, previousProductId) } }
                });

                if (resultAvailabilies.Entities.Count > 0)
                {
                    foreach (var availability in resultAvailabilies.Entities)
                    {
                        Entity availabilityEntity = new Entity("amxperu_productofferingavailabilityconfiguratio");
                        availabilityEntity.Id = availability.Id;
                        availabilityEntity.Attributes["amxperu_productofferingid"] = new EntityReference(Product.EntityLogicalName, productId);
                        actionContext.OrganizationService.Update(availabilityEntity);
                    }
                }
            }
        }

        private void UpdatePOPConfiguration(Guid productId, Guid previousProductId)
        {
            if (previousProductId != Guid.Empty)
            {
                var resultPOPConfigurations = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "amxperu_productofferingpriceconfiguration",
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_productoffering", ConditionOperator.Equal, previousProductId) } }
                });

                if (resultPOPConfigurations.Entities.Count > 0)
                {
                    foreach (var popCofiguration in resultPOPConfigurations.Entities)
                    {
                        Entity popConfigEntity = new Entity("amxperu_productofferingpriceconfiguration");
                        popConfigEntity.Id = popCofiguration.Id;
                        popConfigEntity.Attributes["amxperu_productoffering"] = new EntityReference(Product.EntityLogicalName, productId);
                        actionContext.OrganizationService.Update(popConfigEntity);
                    }
                }
            }
        }

        private void UpdatePOP(Guid productId, Guid previousProductId)
        {
            if (previousProductId != Guid.Empty)
            {
                var resultPOPs = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "amxperu_productofferingprice",
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_productofferingid", ConditionOperator.Equal, previousProductId) } }
                });

                if (resultPOPs.Entities.Count > 0)
                {
                    foreach (var pop in resultPOPs.Entities)
                    {
                        Entity popEntity = new Entity("amxperu_productofferingprice");
                        popEntity.Id = pop.Id;
                        popEntity.Attributes["amxperu_productofferingid"] = new EntityReference(Product.EntityLogicalName, productId);
                        actionContext.OrganizationService.Update(popEntity);
                    }
                }
            }
        }

        private void UpdateGroupSubOffers(Guid productId, Guid previousProductId)
        {
            if (previousProductId != Guid.Empty)
            {
                var resultAssociations = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "amxperu_productofferinggroupsuboffer",
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_productofferingid", ConditionOperator.Equal, previousProductId) } }
                });

                if (resultAssociations.Entities.Count > 0)
                {
                    foreach (var suboffer in resultAssociations.Entities)
                    {
                        Entity updateSubOffer = new Entity("amxperu_productofferinggroupsuboffer");
                        updateSubOffer.Id = suboffer.Id;
                        updateSubOffer.Attributes["amxperu_productofferingid"] = new EntityReference(Product.EntityLogicalName, productId);
                        actionContext.OrganizationService.Update(updateSubOffer);
                    }
                }
            }
        }

        private void UpdateECMRequest(Guid productId, Guid previousProductId)
        {
            if (previousProductId != Guid.Empty)
            {
                var resultEcmRequest = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "amxperu_ecmrequest",
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_productofferingid", ConditionOperator.Equal, previousProductId) } }
                });

                if (resultEcmRequest.Entities.Count > 0)
                {
                    foreach (var ecm in resultEcmRequest.Entities)
                    {
                        Entity ecmEntity = new Entity("amxperu_ecmrequest");
                        ecmEntity.Id = ecm.Id;
                        ecmEntity.Attributes["amxperu_productofferingid"] = new EntityReference(Product.EntityLogicalName, productId);
                        actionContext.OrganizationService.Update(ecmEntity);
                    }
                }
            }
        }

        private void UpdateAssociations(Guid productId, Guid previousProductId, string externalId)
        {
            if (previousProductId != Guid.Empty)
            {
                var resultAssociations = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "etel_offeringassociation",
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression() { Conditions = { new ConditionExpression("etel_secondaryofferingid", ConditionOperator.Equal, previousProductId) } }
                });

                if (resultAssociations.Entities.Count > 0)
                {
                    foreach (var association in resultAssociations.Entities)
                    {
                        Entity updateAssociation = new Entity("etel_offeringassociation");
                        updateAssociation.Id = association.Id;
                        updateAssociation.Attributes["etel_secondaryofferingid"] = new EntityReference(Product.EntityLogicalName, productId);
                        actionContext.OrganizationService.Update(updateAssociation);
                    }
                }
            }

            var resultAssociations2 = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = "etel_offeringassociation",
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression()
                {
                    Conditions = { new ConditionExpression("amxperu_associatedofferingtext", ConditionOperator.Equal, externalId),
                        new ConditionExpression("etel_secondaryofferingid", ConditionOperator.Null)}
                }
            });

            if (resultAssociations2.Entities.Count > 0)
            {
                foreach (var association in resultAssociations2.Entities)
                {
                    Entity updateAssociation = new Entity("etel_offeringassociation");
                    updateAssociation.Id = association.Id;
                    updateAssociation.Attributes["etel_secondaryofferingid"] = new EntityReference(Product.EntityLogicalName, productId);
                    actionContext.OrganizationService.Update(updateAssociation);
                }
            }
        }
    }
}