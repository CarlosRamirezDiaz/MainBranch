using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruPlugins.Model.ProductOfferingSync;

namespace AmxPeruPlugins.Workflow.ProductOfferingOperations
{
    public class ProductOfferingImport
    {
        public IActionContext actionContext = null;

        public ProductOfferingImport(IActionContext context)
        {
            actionContext = context;
        }

        private Guid ProductSpec(ProductSpecification productSpecification)
        {
            var resultPS = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = etel_productspecification.EntityLogicalName,
                ColumnSet = new ColumnSet("etel_productspecificationid"),
                Criteria = new FilterExpression() { Conditions = { new ConditionExpression("etel_externalid", ConditionOperator.Equal, productSpecification.ExternalId) } }
            });

            Guid psId = Guid.Empty;
            if (resultPS.Entities.Count > 0)
            {
                psId = resultPS.Entities[0].Id;
            }
            else
            {
                var ps = new etel_productspecification();
                ps.etel_externalid = productSpecification.ExternalId;
                ps.etel_name = productSpecification.Name;
                ps.statuscode = new OptionSetValue(1);

                psId = actionContext.OrganizationService.Create(ps);
            }

            //Product Resource Specification
            if (productSpecification.ResourceSpecificationList != null)
            {
                ProductResourceSpec(psId, productSpecification.ResourceSpecificationList);
            }

            //CFSS
            if (productSpecification.CFSSList != null)
            {
                CFSSSync(psId, productSpecification.CFSSList);
            }

            return psId;
        }

        private void ProductResourceSpec(Guid psId, List<ResourceSpecification> resourceSpecificationList)
        {
            foreach (var resource in resourceSpecificationList)
            {
                var resultPRS = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = etel_productresourcespecification.EntityLogicalName,
                    ColumnSet = new ColumnSet("etel_productresourcespecificationid"),
                    Criteria = new FilterExpression() { Conditions = { new ConditionExpression("etel_externalid", ConditionOperator.Equal, resource.ExternalId) } }
                });

                Guid prsId = Guid.Empty;

                if (resultPRS.Entities.Count > 0)
                {
                    prsId = resultPRS.Entities[0].Id;

                    QueryExpression query1 = new QueryExpression("amxperu_ps_prs")
                    {
                        NoLock = true,
                        ColumnSet = new ColumnSet(true),
                        Criteria = { Filters = { new FilterExpression { Conditions = { new ConditionExpression("etel_productspecificationid", ConditionOperator.Equal, psId), new ConditionExpression("etel_productresourcespecificationid", ConditionOperator.Equal, prsId) } } } }
                    };

                    EntityCollection retrievedRelations = actionContext.OrganizationService.RetrieveMultiple(query1);

                    if (retrievedRelations.Entities.Count <= 0)
                    {
                        AssociateRequest relation = new AssociateRequest
                        {
                            Target = new EntityReference(etel_productspecification.EntityLogicalName, psId),
                            RelatedEntities = new EntityReferenceCollection { new EntityReference(etel_productresourcespecification.EntityLogicalName, prsId) },
                            Relationship = new Relationship("amxperu_ps_prs")
                        };

                        actionContext.OrganizationService.Execute(relation);

                        /////////Resource Cardinality

                        Entity prc = new Entity("amxperu_productresourcecardinality");
                        prc.Attributes["amxperu_productspecificationid"] = new EntityReference(etel_productspecification.EntityLogicalName, psId);
                        prc.Attributes["amxperu_productresourcespecificationid"] = new EntityReference(etel_productresourcespecification.EntityLogicalName, prsId);
                        prc.Attributes["amxperu_name"] = resource.Name;

                        if (!string.IsNullOrEmpty(resource.DefaultCardinality))
                        {
                            prc.Attributes["amxperu_defaultcardinality"] = Convert.ToInt32(resource.DefaultCardinality);
                        }

                        if (!string.IsNullOrEmpty(resource.TargetCardinalityMin))
                        {
                            prc.Attributes["amxperu_targetcardinalitymin"] = Convert.ToInt32(resource.TargetCardinalityMin);
                        }

                        if (!string.IsNullOrEmpty(resource.TargetCardinalityMax))
                        {
                            prc.Attributes["amxperu_targetcardinalitymax"] = Convert.ToInt32(resource.TargetCardinalityMax);
                        }

                        actionContext.OrganizationService.Create(prc);

                        //////
                    }

                    if (resource.ResourceCharacteristicList != null)
                    {
                        ResourceCharacteristicSync(resource.ResourceCharacteristicList, prsId);
                    }

                }
                else
                {

                    Entity prs = new Entity("etel_productresourcespecification");
                    prs.Attributes["etel_externalid"] = resource.ExternalId;
                    prs.Attributes["etel_name"] = resource.Name;

                    if (resource.SpecificationSubType != null)
                    {
                        var result = SearchEntityOptionset("etel_productresourcespecification", "amxperu_specificationsubtypecode", resource.SpecificationSubType);

                        if (result > 0)
                        {
                            prs.Attributes["amxperu_specificationsubtypecode"] = new OptionSetValue(result);
                        }
                    }

                    if (resource.ResourceType != null)
                    {
                        var result = SearchEntityOptionset("etel_productresourcespecification", "amxperu_resourcetypecode", resource.ResourceType);

                        if (result > 0)
                        {
                            prs.Attributes["amxperu_resourcetypecode"] = new OptionSetValue(result);
                        }
                    }

                    prsId = actionContext.OrganizationService.Create(prs);

                    //Create N:N relation with PS

                    AssociateRequest relation = new AssociateRequest
                    {
                        Target = new EntityReference(etel_productspecification.EntityLogicalName, psId),
                        RelatedEntities = new EntityReferenceCollection { new EntityReference(etel_productresourcespecification.EntityLogicalName, prsId) },
                        Relationship = new Relationship("amxperu_ps_prs")
                    };

                    actionContext.OrganizationService.Execute(relation);

                    /////////Resource Cardinality

                    Entity prc = new Entity("amxperu_productresourcecardinality");
                    prc.Attributes["amxperu_productspecificationid"] = new EntityReference(etel_productspecification.EntityLogicalName, psId);
                    prc.Attributes["amxperu_productresourcespecificationid"] = new EntityReference(etel_productresourcespecification.EntityLogicalName, prsId);
                    prc.Attributes["amxperu_name"] = resource.Name;

                    if (!string.IsNullOrEmpty(resource.DefaultCardinality))
                    {
                        prc.Attributes["amxperu_defaultcardinality"] = Convert.ToInt32(resource.DefaultCardinality);
                    }

                    if (!string.IsNullOrEmpty(resource.TargetCardinalityMin))
                    {
                        prc.Attributes["amxperu_targetcardinalitymin"] = Convert.ToInt32(resource.TargetCardinalityMin);
                    }

                    if (!string.IsNullOrEmpty(resource.TargetCardinalityMax))
                    {
                        prc.Attributes["amxperu_targetcardinalitymax"] = Convert.ToInt32(resource.TargetCardinalityMax);
                    }

                    actionContext.OrganizationService.Create(prc);

                    //////

                    if (resource.ResourceCharacteristicList != null)
                    {
                        ResourceCharacteristicSync(resource.ResourceCharacteristicList, prsId);
                    }
                }
            }

        }

        private Guid CreateCharacteristic(Model.ProductOfferingSync.Characteristic characteristic)
        {
            var resultCharacteristic = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = etel_productcharacteristic.EntityLogicalName,
                ColumnSet = new ColumnSet("etel_productcharacteristicid"),
                Criteria = new FilterExpression() { Conditions = { new ConditionExpression("etel_externalid", ConditionOperator.Equal, characteristic.ExternalId) } }
            });

            Guid charId = Guid.Empty;

            if (resultCharacteristic.Entities.Count > 0)
            {
                charId = resultCharacteristic.Entities[0].Id;
            }
            else
            {
                Entity newCharacteristic = new Entity("etel_productcharacteristic");
                newCharacteristic.Attributes["etel_name"] = characteristic.Name;
                newCharacteristic.Attributes["etel_externalid"] = characteristic.ExternalId;

                int datatypeValue = SearchGlobalOptionset("etel_datatypecode", characteristic.DataType);

                if (datatypeValue > -1)
                {
                    newCharacteristic.Attributes["etel_datatype"] = new OptionSetValue(datatypeValue);
                }

                charId = actionContext.OrganizationService.Create(newCharacteristic);
            }

            return charId;
        }

        private DataCollection<Entity> RetrieveCharacteristicValue(Guid charId)
        {
            var resultCharacteristicValue = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = etel_productcharacteristicvalue.EntityLogicalName,
                ColumnSet = new ColumnSet("etel_productcharacteristicvalueid", "etel_name"),
                Criteria = new FilterExpression()
                {
                    Conditions = { new ConditionExpression("etel_productcharacteristicid", ConditionOperator.Equal, charId) }
                }
            });

            return resultCharacteristicValue.Entities;
        }

        private Guid CreateCharacteristicValue(string value, Guid charId, string charName)
        {
            EntityCollection resultCharacteristicValue = new EntityCollection();
            Guid valueId = Guid.Empty;

            if (!string.IsNullOrEmpty(value))
            {
                resultCharacteristicValue = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = etel_productcharacteristicvalue.EntityLogicalName,
                    ColumnSet = new ColumnSet("etel_productcharacteristicvalueid"),
                    Criteria = new FilterExpression()
                    {
                        Conditions =
                                    { new ConditionExpression("etel_name", ConditionOperator.Equal, value)
                                    , new ConditionExpression("etel_productcharacteristicid", ConditionOperator.Equal, charId) }
                    }
                });


                if (resultCharacteristicValue.Entities.Count > 0)
                {
                    valueId = resultCharacteristicValue.Entities[0].Id;

                    foreach (var item in resultCharacteristicValue.Entities)
                    {
                        Entity updateValue = new Entity("etel_productcharacteristicvalue");
                        updateValue.Id = item.Id;
                        updateValue.Attributes["etel_name"] = value;
                        actionContext.OrganizationService.Update(updateValue);
                    }
                }
                else
                {
                    Entity newValue = new Entity("etel_productcharacteristicvalue");
                    newValue.Attributes["etel_name"] = value;
                    newValue.Attributes["etel_externalid"] = charName;
                    newValue.Attributes["etel_productcharacteristicid"] = new EntityReference(etel_productcharacteristic.EntityLogicalName, charId);

                    valueId = actionContext.OrganizationService.Create(newValue);
                }
            }

            return valueId;
        }

        private void CreateCFSSCharacteristic(List<Model.ProductOfferingSync.Characteristic> characteristicList, Guid cfssId)
        {
            if (characteristicList != null)
            {
                foreach (var characteristic in characteristicList)
                {
                    var charId = CreateCharacteristic(characteristic);

                    var resultCharacteristicUse = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = "amxperu_cfsscharuse",
                        ColumnSet = new ColumnSet("amxperu_cfsscharuseid"),
                        Criteria = new FilterExpression()
                        {
                            Conditions = { new ConditionExpression("amxperu_cfssid", ConditionOperator.Equal, cfssId)
                        , new ConditionExpression("amxperu_characteristicid", ConditionOperator.Equal, charId) }
                        }
                    });

                    if (resultCharacteristicUse.Entities.Count <= 0)
                    {
                        Entity newCharacteristicUse = new Entity("amxperu_cfsscharuse");
                        newCharacteristicUse.Attributes["amxperu_name"] = characteristic.Name;
                        newCharacteristicUse.Attributes["amxperu_cfssid"] = new EntityReference("amxperu_cfss", cfssId);
                        newCharacteristicUse.Attributes["amxperu_characteristicid"] = new EntityReference(etel_productcharacteristic.EntityLogicalName, charId);

                        int datatypeValue = SearchGlobalOptionset("etel_datatypecode", characteristic.DataType);

                        if (datatypeValue > -1)
                        {
                            newCharacteristicUse.Attributes["amxperu_datatype"] = new OptionSetValue(datatypeValue);
                        }

                        newCharacteristicUse.Attributes["amxperu_editable"] = characteristic.Editable;

                        if ((characteristic.DataType != "Combobox") && (characteristic.DataType != "List"))
                        {
                            if (!string.IsNullOrEmpty(characteristic.DefaultValue))
                            {
                                newCharacteristicUse.Attributes["amxperu_defaultvalue"] = characteristic.DefaultValue;
                                /////CreateCharacteristicValue(characteristic.DefaultValue, charId, characteristic.Name);
                            }

                            var charUseId = actionContext.OrganizationService.Create(newCharacteristicUse);
                        }
                        else if (characteristic.DataType == "Combobox")
                        {
                            var charUseId = actionContext.OrganizationService.Create(newCharacteristicUse);

                            var characteristicPossibleValues = RetrieveCharacteristicValue(charId);

                            if (characteristicPossibleValues.Count > 0)
                            {
                                foreach (var item in characteristicPossibleValues)
                                {
                                    Entity newCharacteristicValueUse = new Entity("amxperu_cfsscharvalueuse");
                                    newCharacteristicValueUse.Attributes["amxperu_name"] = characteristic.Name;
                                    newCharacteristicValueUse.Attributes["amxperu_cfssscaruseid"] = new EntityReference("amxperu_cfsscharuse", charUseId);
                                    newCharacteristicValueUse.Attributes["amxperu_valueid"] = new EntityReference("etel_productcharacteristicvalue", item.Id);

                                    if ((item.Attributes.Contains("etel_name") && (characteristic.DefaultValue == item.Attributes["etel_name"].ToString())))
                                    {
                                        newCharacteristicValueUse.Attributes["amxperu_isdefaultvalue"] = true;
                                    }

                                    var charValueUseId = actionContext.OrganizationService.Create(newCharacteristicValueUse);
                                }
                            }
                        }
                        else if (characteristic.DataType == "List")
                        {

                            var charUseId = actionContext.OrganizationService.Create(newCharacteristicUse);

                            var characteristicPossibleValues = RetrieveCharacteristicValue(charId);

                            if (characteristicPossibleValues.Count > 0)
                            {
                                foreach (var item in characteristicPossibleValues)
                                {
                                    Entity newCharacteristicValueUse = new Entity("amxperu_cfsscharvalueuse");
                                    newCharacteristicValueUse.Attributes["amxperu_name"] = characteristic.Name;
                                    newCharacteristicValueUse.Attributes["amxperu_cfssscaruseid"] = new EntityReference("amxperu_cfsscharuse", charUseId);
                                    newCharacteristicValueUse.Attributes["amxperu_valueid"] = new EntityReference("etel_productcharacteristicvalue", item.Id);


                                    //if (characteristic.DefaultValue == item.Attributes["etel_name"].ToString())
                                    //{
                                    //    newCharacteristicValueUse.Attributes["amxperu_isdefaultvalue"] = true;
                                    //}

                                    var charValueUseId = actionContext.OrganizationService.Create(newCharacteristicValueUse);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CreateResourceCharacteristic(List<Model.ProductOfferingSync.Characteristic> characteristicList, Guid prsId)
        {
            if (characteristicList != null)
            {
                foreach (var characteristic in characteristicList)
                {
                    var resultCharacteristic = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = "amxperu_resourcecharacteristic",
                        ColumnSet = new ColumnSet("amxperu_resourcecharacteristicid"),
                        Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_externalid", ConditionOperator.Equal, characteristic.ExternalId) } }
                    });

                    Guid charId = Guid.Empty;

                    if (resultCharacteristic.Entities.Count > 0)
                    {
                        charId = resultCharacteristic.Entities[0].Id;
                    }
                    else
                    {
                        Entity newCharacteristic = new Entity("amxperu_resourcecharacteristic");
                        newCharacteristic.Attributes["amxperu_name"] = characteristic.Name;
                        newCharacteristic.Attributes["amxperu_externalid"] = characteristic.ExternalId;

                        charId = actionContext.OrganizationService.Create(newCharacteristic);
                    }


                    if (characteristic.CharacteristicValueList != null)
                    {
                        foreach (var value in characteristic.CharacteristicValueList)
                        {
                            var resultCharacteristicValue = new EntityCollection();

                            if (!string.IsNullOrEmpty(value.Value))
                            {
                                resultCharacteristicValue = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                                {
                                    EntityName = "amxperu_resourcecharacteristicvalue",
                                    ColumnSet = new ColumnSet("amxperu_resourcecharacteristicvalueid"),
                                    Criteria = new FilterExpression()
                                    {
                                        Conditions = { new ConditionExpression("amxperu_name", ConditionOperator.Equal, value.Value),
                                     new ConditionExpression("amxperu_resourcecharacteristicid", ConditionOperator.Equal, charId) }
                                    }
                                });

                            }
                            else
                            {
                                resultCharacteristicValue = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                                {
                                    EntityName = "amxperu_resourcecharacteristicvalue",
                                    ColumnSet = new ColumnSet("amxperu_resourcecharacteristicvalueid"),
                                    Criteria = new FilterExpression()
                                    {
                                        Conditions = { new ConditionExpression("amxperu_name", ConditionOperator.Null),
                                     new ConditionExpression("amxperu_resourcecharacteristicid", ConditionOperator.Equal, charId) }
                                    }
                                });
                            }

                            Guid valueId = Guid.Empty;

                            if (resultCharacteristicValue.Entities.Count > 0)
                            {
                                valueId = resultCharacteristicValue.Entities[0].Id;
                            }
                            else
                            {
                                Entity newResourceCharacteristicValue = new Entity("amxperu_resourcecharacteristicvalue");
                                newResourceCharacteristicValue.Attributes["amxperu_name"] = value.Value;
                                newResourceCharacteristicValue.Attributes["amxperu_resourcecharacteristicid"] = new EntityReference("amxperu_resourcecharacteristic", charId);

                                valueId = actionContext.OrganizationService.Create(newResourceCharacteristicValue);
                            }

                            QueryExpression query1 = new QueryExpression("amxperu_productresourcespec_resourcecharvalue")
                            {
                                NoLock = true,
                                ColumnSet = new ColumnSet(true),
                                Criteria = { Filters = { new FilterExpression { Conditions = { new ConditionExpression("amxperu_resourcecharacteristicvalueid", ConditionOperator.Equal, valueId), new ConditionExpression("etel_productresourcespecificationid", ConditionOperator.Equal, prsId) } } } }
                            };

                            EntityCollection retrievedRelations = actionContext.OrganizationService.RetrieveMultiple(query1);

                            if (retrievedRelations.Entities.Count <= 0)
                            {
                                AssociateRequest relation = new AssociateRequest
                                {
                                    Target = new EntityReference(etel_productresourcespecification.EntityLogicalName, prsId),
                                    RelatedEntities = new EntityReferenceCollection { new EntityReference("amxperu_resourcecharacteristicvalue", valueId) },
                                    Relationship = new Relationship("amxperu_productresourcespec_resourcecharvalue")
                                };

                                actionContext.OrganizationService.Execute(relation);
                            }

                        }
                    }
                }
            }
        }

        private void CreatePOPCharacteristic(List<Model.ProductOfferingSync.Characteristic> characteristicList, Guid popId, Guid productId)
        {
            if (characteristicList != null)
            {
                string configName = string.Empty;
                List<Guid> valueList = new List<Guid>();

                foreach (var characteristic in characteristicList)
                {
                    configName += characteristic.Name + " : ";

                    var charId = CreateCharacteristic(characteristic);

                    if (characteristic.CharacteristicValueList != null)
                    {
                        foreach (var value in characteristic.CharacteristicValueList)
                        {
                            var valueId = CreateCharacteristicValue(value.Value, charId, characteristic.Name);

                            valueList.Add(valueId);

                            configName += value.Value + " - ";

                            AssociateRequest relation = new AssociateRequest
                            {
                                Target = new EntityReference("etel_productcharacteristicvalue", valueId),
                                RelatedEntities = new EntityReferenceCollection { new EntityReference("amxperu_productofferingprice", popId) },
                                Relationship = new Relationship("amxperu_productofferingprice_charvalue")
                            };

                            actionContext.OrganizationService.Execute(relation);
                        }
                    }
                }

                var popConfigId = CreatePOPConfig(productId, configName, valueList);

                Entity updatePOP = new Entity("amxperu_productofferingprice");
                updatePOP.Id = popId;
                updatePOP.Attributes["amxperu_popconfiguration"] = new EntityReference("amxperu_productofferingpriceconfiguration", popConfigId);
                actionContext.OrganizationService.Update(updatePOP);
            }
        }

        private void CreateProductAttachment(List<Model.ProductOfferingSync.Attachment> attachmentList, Guid productId)
        {
            if (attachmentList != null)
            {
                var resultAttachmentURL = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "etel_crmconfiguration",
                    ColumnSet = new ColumnSet("etel_value"),
                    Criteria = new FilterExpression() { Conditions = { new ConditionExpression("etel_name", ConditionOperator.Equal, "AttachmentUrl") } }
                });

                if (resultAttachmentURL.Entities.Count > 0)
                {
                    foreach (var attachment in attachmentList)
                    {
                        var resultAttachment = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                        {
                            EntityName = "amxperu_productofferingattachment",
                            ColumnSet = new ColumnSet("amxperu_productofferingattachmentid"),
                            Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_externalid", ConditionOperator.Equal, attachment.ExternalId) } }
                        });

                        if (resultAttachment.Entities.Count <= 0)
                        {
                            Entity newAttachment = new Entity("amxperu_productofferingattachment");

                            newAttachment.Attributes["amxperu_name"] = attachment.Name;
                            newAttachment.Attributes["amxperu_externalid"] = attachment.ExternalId;
                            newAttachment.Attributes["amxperu_attachmentcode"] = attachment.AttachmentCode;
                            newAttachment.Attributes["amxperu_attachmentname"] = attachment.AttachmentName;
                            newAttachment.Attributes["amxperu_mimetype"] = attachment.MimeType;
                            newAttachment.Attributes["amxperu_type"] = attachment.Type;
                            newAttachment.Attributes["amxperu_url"] = resultAttachmentURL.Entities[0].Attributes["etel_value"].ToString() + attachment.URL;
                            newAttachment.Attributes["amxperu_productofferingid"] = new EntityReference(Product.EntityLogicalName, productId);

                            actionContext.OrganizationService.Create(newAttachment);
                        }

                    }
                }
            }
        }

        private void CreateProductCharacteristic(List<Model.ProductOfferingSync.Characteristic> characteristicList, Guid productId, List<Guid> valueList)
        {
            if (characteristicList != null)
            {
                foreach (var characteristic in characteristicList)
                {
                    var charId = CreateCharacteristic(characteristic);

                    var resultCharacteristicUse = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = "amxperu_productofferingcharuse",
                        ColumnSet = new ColumnSet("amxperu_productofferingcharuseid"),
                        Criteria = new FilterExpression()
                        {
                            Conditions = { new ConditionExpression("amxperu_productoffering", ConditionOperator.Equal, productId)
                            , new ConditionExpression("amxperu_characteristic", ConditionOperator.Equal, charId) }
                        }
                    });

                    if (resultCharacteristicUse.Entities.Count <= 0)
                    {
                        Entity newCharacteristicUse = new Entity("amxperu_productofferingcharuse");
                        newCharacteristicUse.Attributes["amxperu_name"] = characteristic.Name;
                        newCharacteristicUse.Attributes["amxperu_productoffering"] = new EntityReference(Product.EntityLogicalName, productId);
                        newCharacteristicUse.Attributes["amxperu_characteristic"] = new EntityReference(etel_productcharacteristic.EntityLogicalName, charId);

                        int datatypeValue = SearchGlobalOptionset("etel_datatypecode", characteristic.DataType);

                        if (datatypeValue > -1)
                        {
                            newCharacteristicUse.Attributes["amxperu_datatypecode"] = new OptionSetValue(datatypeValue);
                        }

                        newCharacteristicUse.Attributes["amxperu_editable"] = characteristic.Editable;

                        if ((characteristic.DataType != "Combobox") && (characteristic.DataType != "List"))
                        {
                            if (!string.IsNullOrEmpty(characteristic.DefaultValue))
                            {
                                newCharacteristicUse.Attributes["amxperu_defaultvalue"] = characteristic.DefaultValue;

                                ///////CreateCharacteristicValue(characteristic.DefaultValue, charId, characteristic.Name);
                            }

                            var charUseId = actionContext.OrganizationService.Create(newCharacteristicUse);
                        }
                        else if (characteristic.DataType == "Combobox")
                        {
                            var charUseId = actionContext.OrganizationService.Create(newCharacteristicUse);

                            var characteristicPossibleValues = RetrieveCharacteristicValue(charId);

                            if (characteristicPossibleValues.Count > 0)
                            {
                                foreach (var item in characteristicPossibleValues)
                                {
                                    Entity newCharacteristicValueUse = new Entity("amxperu_productofferingcharvalueuse");
                                    newCharacteristicValueUse.Attributes["amxperu_name"] = characteristic.Name;
                                    newCharacteristicValueUse.Attributes["amxperu_productofferingcharuse"] = new EntityReference("amxperu_productofferingcharuse", charUseId);
                                    newCharacteristicValueUse.Attributes["amxperu_value"] = new EntityReference(etel_productcharacteristicvalue.EntityLogicalName, item.Id);

                                    if (!string.IsNullOrEmpty(characteristic.DefaultValue))
                                    {
                                        if ((item.Attributes.Contains("etel_name") && (characteristic.DefaultValue == item.Attributes["etel_name"].ToString())))
                                        {
                                            newCharacteristicValueUse.Attributes["amxperu_isdefaultvalue"] = true;
                                        }
                                    }

                                    actionContext.OrganizationService.Create(newCharacteristicValueUse);
                                }
                            }

                        }
                        else if (characteristic.DataType == "List")
                        {
                            var charUseId = actionContext.OrganizationService.Create(newCharacteristicUse);

                            var characteristicPossibleValues = RetrieveCharacteristicValue(charId);

                            if (characteristicPossibleValues.Count > 0)
                            {
                                foreach (var item in characteristicPossibleValues)
                                {
                                    Entity newCharacteristicValueUse = new Entity("amxperu_productofferingcharvalueuse");
                                    newCharacteristicValueUse.Attributes["amxperu_name"] = characteristic.Name;
                                    newCharacteristicValueUse.Attributes["amxperu_productofferingcharuse"] = new EntityReference("amxperu_productofferingcharuse", charUseId);
                                    newCharacteristicValueUse.Attributes["amxperu_value"] = new EntityReference(etel_productcharacteristicvalue.EntityLogicalName, item.Id);
                                    actionContext.OrganizationService.Create(newCharacteristicValueUse);
                                }
                            }

                        }
                    }
                }
            }
        }

        private Tuple<bool, string> POSyncValidation(ProductOfferingRequest offeringRequest)
        {
            bool result = true;
            string message = string.Empty;
            if (offeringRequest.ProductOfferingList != null)
            {
                foreach (var offering in offeringRequest.ProductOfferingList)
                {
                    if (offering.ProductTechnicalType == null)
                    {
                        message = "ProductTechnicalType is missing";
                    }

                    if (offering.StartDate == null)
                    {
                        message = "StartDate is missing";
                    }

                    if (offering.ExternalId == null)
                    {
                        message = "Product Offering external id is missing";
                    }

                    if (offering.ProductSpecification == null)
                    {

                    }
                    else if (offering.ProductSpecification.ExternalId == null)
                    {

                    }
                }
            }
            var tuple = new Tuple<bool, string>(result, message);

            return tuple;
        }

        private Tuple<string, Product, List<Guid>, bool> POSyncRule(ProductOffering offering)
        {
            string result = string.Empty;
            bool status = true;

            var resultPO = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = Product.EntityLogicalName,
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression() { Conditions = { new ConditionExpression("etel_externalid", ConditionOperator.Equal, offering.ExternalId) } }
            });

            Product product = new Product();
            Guid productId = Guid.Empty;
            List<Guid> popConfigList = new List<Guid>();
            bool isNewVersion = false;
            bool isRollback = false;

            if (resultPO.Entities.Count > 0)
            {
                //Commit
                //Create Version with rollback
                //Create Version with commit

                //Check Draft PO exist
                product = (Product)resultPO.Entities.Where(i => ((OptionSetValue)i.Attributes["statuscode"]).Value == (int)product_statuscode.Draft).FirstOrDefault();

                if (product != null)
                {
                    var resultPOPConfig = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = "amxperu_productofferingpriceconfiguration",
                        ColumnSet = new ColumnSet("amxperu_productofferingpriceconfigurationid"),
                        Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_productoffering", ConditionOperator.Equal, product.Id) } }
                    });

                    if (resultPOPConfig.Entities.Count > 0)
                    {
                        foreach (var item in resultPOPConfig.Entities)
                        {
                            popConfigList.Add(item.Id);
                        }
                    }

                    if ((product.StatusCode.Value == (int)product_statuscode.Draft) && (!offering.IsRollback))
                    {
                        isNewVersion = false;
                        isRollback = false;

                        result = "Draft To Available";
                    }
                    else if ((product.StatusCode.Value == (int)product_statuscode.Draft) && (offering.IsRollback))
                    {
                        result = "Remove Existing Draft PO";
                    }

                    productId = product.Id;
                }
                else
                {
                    //Check Available PO exist
                    product = (Product)resultPO.Entities.Where(i => ((OptionSetValue)i.Attributes["statuscode"]).Value == (int)product_statuscode.Available).FirstOrDefault();
                    if (product != null)
                    {
                        if (offering.IsRollback)
                        {
                            //Create new version with Draft status
                            isNewVersion = true;
                            isRollback = true;

                            result = "Create Draft PO Version";
                        }
                        else if (!offering.IsRollback)
                        {
                            //Commit new version from Draft to Available.
                            isNewVersion = false;
                            isRollback = false;

                            result = "Draft To Available";
                        }
                    }
                    else
                    {
                        //Check Plan PO exist
                        product = (Product)resultPO.Entities.Where(i => ((OptionSetValue)i.Attributes["statuscode"]).Value == (int)product_statuscode.Plan).FirstOrDefault();
                        if (product != null)
                        {
                            if (offering.IsRollback)
                            {
                                //Create new version with Draft status
                                isNewVersion = true;
                                isRollback = true;

                                result = "Create Draft PO Version";
                            }
                            else if (!offering.IsRollback)
                            {
                                //Commit new version from Draft to Available.
                                isNewVersion = false;
                                isRollback = false;

                                result = "Draft To Available";
                            }
                        }
                    }

                    productId = product.Id;
                }
            }
            else
            {
                if (offering.IsRollback)
                {
                    result = "Create Draft PO";
                }
                else
                {
                    result = "Wrong Request: Draft PO does not exist";
                    status = false;
                }
            }

            var tuple = new Tuple<string, Product, List<Guid>, bool>(result, product, popConfigList, status);

            return tuple;
        }

        private Guid CreateProductOffering(ProductOffering offering, Guid psId, string defaultUnit, string unitGroup, string currency, string version)
        {
            Guid productId = Guid.Empty;

            var product = new Product();
            product.etel_externalid = offering.ExternalId;
            product.Name = offering.Name;
            product.ProductNumber = offering.ExternalId;
            product.etel_productspecificationId = new EntityReference(etel_productspecification.EntityLogicalName, psId);
            product.etel_version = version;

            if (offering.StartDate != null)
            {
                product.etel_startdate = Convert.ToDateTime(offering.StartDate);
            }

            product.Description = offering.Description;

            product.etel_issellable = offering.IsSellable;
            product.etel_bundle = offering.IsBundle;

            int technicalType = SearchEntityOptionset(Product.EntityLogicalName, "etel_offertypecode", offering.ProductTechnicalType);

            if (technicalType > 0)
            {
                product.etel_offertypecode = new OptionSetValue(technicalType);
            }

            if (offering.OfferType != null)
            {
                int offerType = SearchEntityOptionset("product", "amxperu_offertypecode", offering.OfferType);

                if (offerType > 0)
                {
                    product.Attributes["amxperu_offertypecode"] = new OptionSetValue(offerType);
                }
            }

            if (offering.OfferSubType != null)
            {
                int offerSubType = SearchEntityOptionset("product", "amxperu_offersubtypecode", offering.OfferSubType);

                if (offerSubType > 0)
                {
                    product.Attributes["amxperu_offersubtypecode"] = new OptionSetValue(offerSubType);
                }
            }

            product.QuantityDecimal = 2;

            product.DefaultUoMId = new EntityReference(UoM.EntityLogicalName, new Guid(defaultUnit));
            product.DefaultUoMScheduleId = new EntityReference(UoMSchedule.EntityLogicalName, new Guid(unitGroup));
            product.TransactionCurrencyId = new EntityReference(TransactionCurrency.EntityLogicalName, new Guid(currency));

            productId = actionContext.OrganizationService.Create(product);

            return productId;
        }

        private void SetStatus(bool isRollback, string startDate, Guid productId, List<Guid> popConfigList, string offeringName)
        {
            //Set Product status // Rollback or Commit
            SetStateRequest req = new SetStateRequest();

            if (isRollback)
            {
                //DRAFT
                req.EntityMoniker = new EntityReference(Product.EntityLogicalName, productId);
                req.State = new OptionSetValue(2);
                req.Status = new OptionSetValue(0);
                actionContext.OrganizationService.Execute(req);
            }
            else if ((!isRollback) && (Convert.ToDateTime(startDate) <= DateTime.Now))
            {
                //AVAILABLE
                req.EntityMoniker = new EntityReference(Product.EntityLogicalName, productId);
                req.State = new OptionSetValue(0);
                req.Status = new OptionSetValue(1);
                actionContext.OrganizationService.Execute(req);

                foreach (var popConfigId in popConfigList)
                {
                    if (popConfigId != Guid.Empty)
                    {
                        req = new SetStateRequest();
                        req.EntityMoniker = new EntityReference("amxperu_productofferingpriceconfiguration", popConfigId);
                        req.State = new OptionSetValue(0);
                        req.Status = new OptionSetValue(1);
                        actionContext.OrganizationService.Execute(req);
                    }
                }

                CreateProductVersionHandler(productId, startDate, offeringName, 100000000); //completed
            }
            else if ((!isRollback) && (Convert.ToDateTime(startDate) > DateTime.Now))
            {
                //PLAN
                req.EntityMoniker = new EntityReference(Product.EntityLogicalName, productId);
                req.State = new OptionSetValue(0);
                req.Status = new OptionSetValue(831260000);
                actionContext.OrganizationService.Execute(req);

                foreach (var popConfigId in popConfigList)
                {
                    if (popConfigId != Guid.Empty)
                    {
                        req = new SetStateRequest();
                        req.EntityMoniker = new EntityReference("amxperu_productofferingpriceconfiguration", popConfigId);
                        req.State = new OptionSetValue(0);
                        req.Status = new OptionSetValue(250000001);
                        actionContext.OrganizationService.Execute(req);
                    }
                }

                CreateProductVersionHandler(productId, startDate, offeringName, 1); //pending
            }
        }

        private Guid ProductOfferingSync(ProductOffering offering, Guid psId, string defaultUnit, string unitGroup, string currency, string result, Product existingProduct, List<Guid> existingPOPConfigList, List<Guid> valueList)
        {

            Guid productId = existingProduct.Id;

            if (result == "Remove Existing Draft PO")
            {
                var versionNumber = Convert.ToInt32(existingProduct.etel_version);
                int newVersionNumber = versionNumber + 1;

                actionContext.OrganizationService.Delete(Product.EntityLogicalName, existingProduct.Id);

                productId = CreateProductOffering(offering, psId, defaultUnit, unitGroup, currency, newVersionNumber.ToString());

                SetStatus(offering.IsRollback, offering.StartDate, productId, existingPOPConfigList, offering.Name);

                CreateProductCharacteristic(offering.CharacteristicList, productId, valueList);

                CreateProductOfferingGroup(offering, productId);
                CreateProductAttachment(offering.AttachmentList, productId);

                CreatePOP(productId, offering.POPList, existingProduct, valueList);

                CreateRelation(productId, offering.RelationList);
            }
            else if (result == "Create Draft PO")
            {
                //try
                //{
                productId = CreateProductOffering(offering, psId, defaultUnit, unitGroup, currency, "1");
                SetStatus(offering.IsRollback, offering.StartDate, productId, existingPOPConfigList, offering.Name);

                CreateProductCharacteristic(offering.CharacteristicList, productId, valueList);

                CreateProductOfferingGroup(offering, productId);
                CreateProductAttachment(offering.AttachmentList, productId);

                CreatePOP(productId, offering.POPList, existingProduct, valueList);

                CreateRelation(productId, offering.RelationList);
                //}
                //catch (Exception ex)
                //{
                //    throw new Exception(ex.Message);
                //}
            }
            else if (result == "Create Draft PO Version")
            {
                Product oldVersion = new Product();
                oldVersion.Id = productId;
                oldVersion.etel_enddate = Convert.ToDateTime(offering.StartDate);
                actionContext.OrganizationService.Update(oldVersion);

                var versionNumber = Convert.ToInt32(existingProduct.etel_version);
                int newVersionNumber = versionNumber + 1;

                productId = CreateProductOffering(offering, psId, defaultUnit, unitGroup, currency, newVersionNumber.ToString());
                CreateVersion(existingProduct.Id, productId);

                SetStatus(offering.IsRollback, offering.StartDate, productId, existingPOPConfigList, offering.Name);

                CreateProductCharacteristic(offering.CharacteristicList, productId, valueList);

                CreateProductOfferingGroup(offering, productId);
                CreateProductAttachment(offering.AttachmentList, productId);

                CreatePOP(productId, offering.POPList, existingProduct, valueList);

                CreateRelation(productId, offering.RelationList);
            }
            else if (result == "Draft To Available")
            {
                SetStatus(offering.IsRollback, offering.StartDate, productId, existingPOPConfigList, offering.Name); //TODO
            }

            return productId;
        }

        private void CreateProductOfferingGroup(ProductOffering offering, Guid productId)
        {
            if (offering.GroupList != null)
            {
                foreach (var item in offering.GroupList)
                {
                    Guid groupId = new Guid();

                    //Check existing group
                    var resultGroup = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = "amxperu_productofferinggroup",
                        ColumnSet = new ColumnSet("amxperu_productofferinggroupid"),
                        Criteria = new FilterExpression()
                        {
                            Conditions = { new ConditionExpression("amxperu_code", ConditionOperator.Equal, item.Code)
                            , new ConditionExpression("amxperu_productofferingid", ConditionOperator.Equal, productId) }
                        }
                    });

                    if (resultGroup.Entities.Count > 0)
                    {
                        groupId = resultGroup.Entities[0].Id;
                    }
                    else
                    {
                        Entity group = new Entity("amxperu_productofferinggroup");
                        group.Attributes["amxperu_name"] = item.Name;
                        group.Attributes["amxperu_code"] = item.Code;
                        group.Attributes["amxperu_type"] = item.Type;
                        group.Attributes["amxperu_min"] = Convert.ToInt32(item.MinCardinality);
                        group.Attributes["amxperu_max"] = Convert.ToInt32(item.MaxCardinality);
                        group.Attributes["amxperu_productofferingid"] = new EntityReference(Product.EntityLogicalName, productId);

                        groupId = actionContext.OrganizationService.Create(group);

                        //GroupSuboffers

                        foreach (var subitem in item.GroupSubOffers)
                        {
                            Entity groupSubOffer = new Entity("amxperu_productofferinggroupsuboffer");
                            groupSubOffer.Attributes["amxperu_groupid"] = new EntityReference("amxperu_productofferinggroup", groupId);
                            groupSubOffer.Attributes["amxperu_poexternalid"] = subitem.POExternalId;
                            groupSubOffer.Attributes["amxperu_type"] = subitem.Type;

                            var resultPO = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                            {
                                EntityName = Product.EntityLogicalName,
                                ColumnSet = new ColumnSet("productid"),
                                Criteria = new FilterExpression()
                                {
                                    Conditions = { new ConditionExpression("etel_externalid", ConditionOperator.Equal, subitem.POExternalId),
                                    new ConditionExpression("statuscode", ConditionOperator.Equal, product_statuscode.Available) }
                                }
                            });

                            if (resultPO.Entities.Count > 0)
                            {
                                groupSubOffer.Attributes["amxperu_productofferingid"] = new EntityReference(Product.EntityLogicalName, resultPO.Entities[0].Id);
                            }

                            //var resultPOP = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                            //{
                            //    EntityName = "amxperu_productofferingprice",
                            //    ColumnSet = new ColumnSet(true),
                            //    Criteria = new FilterExpression() { Conditions = {
                            //            new ConditionExpression("amxperu_externalid", ConditionOperator.Equal, subitem.POPExternalId),
                            //            new ConditionExpression("amxperu_productofferingid", ConditionOperator.Equal, productId)
                            //        } }
                            //});

                            //if (resultPOP.Entities.Count > 0)
                            //{
                            //    group.Attributes["amxperu_popid"] = new EntityReference("amxperu_productofferingprice", resultPOP.Entities[0].Id);
                            //}

                            actionContext.OrganizationService.Create(groupSubOffer);
                        }
                    }



                }
            }
        }

        private void CreateProductVersionHandler(Guid productId, string startDate, string name, int statuscode)
        {
            Entity handler = new Entity("amxperu_productversionhandler");
            handler.Attributes["amxperu_productofferingid"] = new EntityReference(Product.EntityLogicalName, productId);
            handler.Attributes["amxperu_name"] = name;
            handler.Attributes["statuscode"] = statuscode;
            handler.Attributes["amxperu_startdate"] = Convert.ToDateTime(startDate);
            actionContext.OrganizationService.Create(handler);
        }

        private void CreateVersion(Guid existingProductId, Guid newProductId)
        {
            Entity version = new Entity("etel_offeringversion");
            version.Attributes["etel_previousversionid"] = new EntityReference(Product.EntityLogicalName, existingProductId);
            version.Attributes["amxperu_nextversionid"] = new EntityReference(Product.EntityLogicalName, newProductId);
            version.Attributes["etel_currentversionid"] = new EntityReference(Product.EntityLogicalName, newProductId);
            actionContext.OrganizationService.Create(version);

            var resultVersion = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = "etel_offeringversion",
                ColumnSet = new ColumnSet("etel_offeringversionid"),
                Criteria = new FilterExpression() { Conditions = { new ConditionExpression("etel_currentversionid", ConditionOperator.Equal, existingProductId) } }
            });

            if (resultVersion.Entities.Count > 0)
            {
                foreach (var item in resultVersion.Entities)
                {
                    var updateVersion = new etel_offeringversion();
                    updateVersion.Id = item.Id;
                    updateVersion.etel_currentversionid = new EntityReference(Product.EntityLogicalName, newProductId);
                    actionContext.OrganizationService.Update(updateVersion);
                }
            }
        }

        private Guid CreatePOPConfig(Guid productId, string configName, List<Guid> valueList)
        {
            Guid popConfigId = Guid.Empty;
            if (valueList != null)
            {
                Entity newPOPConfig = new Entity("amxperu_productofferingpriceconfiguration");
                newPOPConfig.Attributes["amxperu_name"] = string.IsNullOrEmpty(configName) ? "Default Price Configuration" : configName;
                newPOPConfig.Attributes["amxperu_productoffering"] = new EntityReference(Product.EntityLogicalName, productId);

                //active 1, draft 250000000
                newPOPConfig.Attributes["statuscode"] = new OptionSetValue(250000000);

                popConfigId = actionContext.OrganizationService.Create(newPOPConfig);

                foreach (var item in valueList)
                {
                    var relation = new AssociateRequest
                    {
                        Target = new EntityReference("etel_productcharacteristicvalue", item),
                        RelatedEntities = new EntityReferenceCollection { new EntityReference("amxperu_productofferingpriceconfiguration", popConfigId) },
                        Relationship = new Relationship("amxperu_priceconfiguration_charvalue")
                    };

                    actionContext.OrganizationService.Execute(relation);
                }
            }

            return popConfigId;
        }

        private void CreatePOP(Guid productId, List<POP> POPList, Product existingProduct, List<Guid> valueList)
        {
            //try
            //{
            Guid popConfigId = CreatePOPConfig(productId, string.Empty, valueList);

            if ((POPList != null) && (popConfigId != Guid.Empty))
            {
                foreach (var pop in POPList)
                {
                    Entity newPOP = new Entity("amxperu_productofferingprice");
                    newPOP.Attributes["amxperu_externalid"] = pop.ExternalId;
                    newPOP.Attributes["amxperu_name"] = pop.ExternalId;

                    var result = SearchGlobalOptionset("etel_pricetypecode", pop.PriceType);
                    if (result > 0)
                    {
                        newPOP.Attributes["amxperu_pricetypecode"] = new OptionSetValue(result);
                    }

                    newPOP.Attributes["amxperu_price"] = new Money(Convert.ToDecimal(pop.Value));
                    newPOP.Attributes["amxperu_productofferingid"] = new EntityReference(Product.EntityLogicalName, productId);
                    newPOP.Attributes["amxperu_popconfiguration"] = new EntityReference("amxperu_productofferingpriceconfiguration", popConfigId);

                    var popId = actionContext.OrganizationService.Create(newPOP);

                    CreatePOPCharacteristic(pop.CharacteristicList, popId, productId);
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("POP Error : " + ex.Message);
            //}
        }

        private void CFSSCharacteristicSync(List<Model.ProductOfferingSync.Characteristic> characteristicList, Guid cfssId)
        {
            CreateCFSSCharacteristic(characteristicList, cfssId);
        }

        private void ResourceCharacteristicSync(List<Model.ProductOfferingSync.Characteristic> characteristicList, Guid prsId)
        {
            CreateResourceCharacteristic(characteristicList, prsId);
        }

        private void CFSSSync(Guid psId, List<CFSS> CFSSList)
        {
            foreach (var cfss in CFSSList)
            {
                var resultCFSS = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "amxperu_cfss",
                    ColumnSet = new ColumnSet("amxperu_cfssid"),
                    Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_externalid", ConditionOperator.Equal, cfss.ExternalId) } }
                });

                Guid cfssId = Guid.Empty;

                if (resultCFSS.Entities.Count > 0)
                {
                    cfssId = resultCFSS.Entities[0].Id;
                }
                else
                {
                    Entity newCfss = new Entity("amxperu_cfss");
                    newCfss.Attributes["amxperu_externalid"] = cfss.ExternalId;
                    newCfss.Attributes["amxperu_name"] = cfss.Name;

                    if (cfss.ServiceTechnicalType != null)
                    {
                        int result = SearchEntityOptionset("amxperu_cfss", "amxperu_servicetechnicaltypecode", cfss.ServiceTechnicalType);

                        if (result > 0)
                        {
                            newCfss.Attributes["amxperu_servicetechnicaltypecode"] = new OptionSetValue(result);
                        }
                    }

                    cfssId = actionContext.OrganizationService.Create(newCfss);
                }

                QueryExpression query1 = new QueryExpression("amxperu_cfss_etel_productspecification")
                {
                    NoLock = true,
                    ColumnSet = new ColumnSet(true),
                    Criteria = { Filters = { new FilterExpression { Conditions = { new ConditionExpression("amxperu_cfssid", ConditionOperator.Equal, cfssId), new ConditionExpression("etel_productspecificationid", ConditionOperator.Equal, psId) } } } }
                };

                EntityCollection retrievedRelations = actionContext.OrganizationService.RetrieveMultiple(query1);

                if (retrievedRelations.Entities.Count <= 0)
                {
                    AssociateRequest relation = new AssociateRequest
                    {
                        Target = new EntityReference("amxperu_cfss", cfssId),
                        RelatedEntities = new EntityReferenceCollection { new EntityReference(etel_productspecification.EntityLogicalName, psId) },
                        Relationship = new Relationship("amxperu_cfss_etel_productspecification")
                    };

                    actionContext.OrganizationService.Execute(relation);
                }

                if (cfss.CharacteristicList != null)
                {
                    CFSSCharacteristicSync(cfss.CharacteristicList, cfssId);
                }

            }
        }

        private void CreateRelation(Guid productId, List<Relation> OptionalList)
        {
            if (OptionalList != null)
            {
                foreach (var optional in OptionalList)
                {
                    //Retrieve Optional
                    var resultOfferingCollection = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = Product.EntityLogicalName,
                        ColumnSet = new ColumnSet("productid"),
                        Criteria = new FilterExpression()
                        {
                            Conditions = { new ConditionExpression("etel_externalid", ConditionOperator.Equal, optional.RelationExternalId),
                             new ConditionExpression("statuscode", ConditionOperator.Equal, product_statuscode.Available) }
                        }
                    });

                    Entity newPOAssociation = new Entity("etel_offeringassociation");

                    int relationType = SearchGlobalOptionset("amxperu_offeringassociationyype", optional.RelationType);

                    if (relationType > -1)
                    {
                        newPOAssociation.Attributes["amxperu_associationtypecode"] = new OptionSetValue(relationType);
                    }

                    newPOAssociation.Attributes["etel_primaryofferingid"] = new EntityReference(Product.EntityLogicalName, productId);
                    newPOAssociation.Attributes["etel_name"] = optional.RelationExternalId;

                    if (resultOfferingCollection.Entities.Count > 0)
                    {
                        var PO = (Product)resultOfferingCollection.Entities[0];
                        newPOAssociation.Attributes["etel_secondaryofferingid"] = new EntityReference(Product.EntityLogicalName, PO.Id);
                        newPOAssociation.Attributes["etel_name"] = PO.Name;
                    }

                    if (!string.IsNullOrEmpty(optional.Sequence))
                    {
                        newPOAssociation.Attributes["amxperu_sequence"] = Convert.ToInt32(optional.Sequence);
                    }

                    if (!string.IsNullOrEmpty(optional.MaxQuantity))
                    {
                        newPOAssociation.Attributes["amxperu_maxquantity"] = Convert.ToInt32(optional.MaxQuantity);
                    }

                    if (!string.IsNullOrEmpty(optional.MinQuantity))
                    {
                        newPOAssociation.Attributes["amxperu_minquantity"] = Convert.ToInt32(optional.MinQuantity);
                    }
                    newPOAssociation.Attributes["amxperu_associatedofferingtext"] = optional.RelationExternalId;
                    newPOAssociation.Attributes["amxperu_suppressbscsonetimecharges"] = optional.SuppressBSCSOneTimeCharges;

                    if (optional.ChangeType != null)
                    {
                        int changeType = SearchEntityOptionset("etel_offeringassociation", "amxperu_changetypecode", optional.ChangeType);

                        if (changeType > 0)
                        {
                            newPOAssociation.Attributes["amxperu_changetypecode"] = new OptionSetValue(changeType);
                        }
                    }

                    actionContext.OrganizationService.Create(newPOAssociation);
                }
            }
        }

        public int SearchEntityOptionset(string entityName, string attributeName, string searchText)
        {
            try
            {
                var attributeRequest = new RetrieveAttributeRequest
                {
                    EntityLogicalName = entityName,
                    LogicalName = attributeName,
                    RetrieveAsIfPublished = true
                };

                var attributeResponse = (RetrieveAttributeResponse)actionContext.OrganizationService.Execute(attributeRequest);
                var attributeMetadata = (EnumAttributeMetadata)attributeResponse.AttributeMetadata;

                var optionList = (from o in attributeMetadata.OptionSet.Options
                                  select new { Value = o.Value, Text = o.Label.UserLocalizedLabel.Label }).ToList();

                if (optionList.Count > 0)
                {
                    foreach (var item in optionList)
                    {
                        if (item.Text.ToLower() == searchText.ToLower())
                        {
                            return item.Value.Value;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(entityName + " - " + attributeName + " - " + searchText);
            }

            return -1;
        }

        public int SearchGlobalOptionset(string globalOptionSetName, string searchText)
        {
            try
            {
                RetrieveOptionSetRequest retrieveOptionSetRequest = new RetrieveOptionSetRequest { Name = globalOptionSetName };
                RetrieveOptionSetResponse retrieveOptionSetResponse = (RetrieveOptionSetResponse)actionContext.OrganizationService.Execute(retrieveOptionSetRequest);
                OptionSetMetadata retrievedOptionSetMetadata = (OptionSetMetadata)retrieveOptionSetResponse.OptionSetMetadata;
                OptionMetadata[] optionList = retrievedOptionSetMetadata.Options.ToArray();

                if (optionList.Length > 0)
                {
                    foreach (var item in optionList)
                    {
                        if (item.Label.LocalizedLabels[0].Label.ToLower() == searchText.ToLower())
                        {
                            return item.Value.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(globalOptionSetName + " - " + searchText);
            }

            return -1;
        }

        //public void InitiateImport(Guid productOfferingSyncId)
        public void InitiateImport(Annotation annotation)
        {
            try
            {
                var fileDataByte = Convert.FromBase64String(annotation.DocumentBody);

                if (fileDataByte.Length > 0)
                {
                    var fileDataString = Encoding.UTF8.GetString(fileDataByte);

                    var productOfferingRequest = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductOfferingRequest>(fileDataString);

                    //Validation

                    var resultValidation = POSyncValidation(productOfferingRequest);

                    if (!resultValidation.Item1)
                    {
                        throw new Exception(resultValidation.Item2);
                    }

                    var crmConfigurationList = RetrieveCRMConfiguration();

                    if (crmConfigurationList.Count > 0)
                    {

                        foreach (var offering in productOfferingRequest.ProductOfferingList)
                        {

                            //Commit - Rollback - New Version decision

                            var result = POSyncRule(offering);
                            if ((result.Item4) && (!string.IsNullOrEmpty(result.Item1)))
                            {
                                //PS
                                var psId = ProductSpec(offering.ProductSpecification);
                                //PO
                                List<Guid> valueList = new List<Guid>();
                                Guid productId = ProductOfferingSync(offering, psId, crmConfigurationList[0].etel_value, crmConfigurationList[1].etel_value, crmConfigurationList[2].etel_value, result.Item1, result.Item2, result.Item3, valueList);
                            }
                            else
                            {
                                throw new InvalidPluginExecutionException(result.Item1);
                            }


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<etel_crmconfiguration> RetrieveCRMConfiguration()
        {
            string[] crmConfigValues = new string[] { "Default_Unit", "Unit_Group", "Currency" };
            List<etel_crmconfiguration> crmConfigurationList = new List<etel_crmconfiguration>();

            var resultCrmConfig = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = etel_crmconfiguration.EntityLogicalName,
                ColumnSet = new ColumnSet("etel_name", "etel_value"),
                Criteria = new FilterExpression() { Conditions = { new ConditionExpression("etel_name", ConditionOperator.In, crmConfigValues) } }
            });

            var defaultUnit = (etel_crmconfiguration)resultCrmConfig.Entities.Where(e => e.Attributes["etel_name"].ToString() == "Default_Unit").FirstOrDefault();
            crmConfigurationList.Add(defaultUnit);

            var unitGroup = (etel_crmconfiguration)resultCrmConfig.Entities.Where(e => e.Attributes["etel_name"].ToString() == "Unit_Group").FirstOrDefault();
            crmConfigurationList.Add(unitGroup);

            var currency = (etel_crmconfiguration)resultCrmConfig.Entities.Where(e => e.Attributes["etel_name"].ToString() == "Currency").FirstOrDefault();
            crmConfigurationList.Add(currency);

            return crmConfigurationList;

        }
    }
}


