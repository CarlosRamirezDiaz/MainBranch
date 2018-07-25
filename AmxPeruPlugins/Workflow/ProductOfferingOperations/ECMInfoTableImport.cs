using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using System;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Messages;
using System.Net;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using AmxPeruPlugins.Model;
using System.Collections.Generic;

namespace AmxPeruPlugins.Workflow.ProductOfferingOperations
{
    public class ECMInfoTableImport
    {
        public IActionContext actionContext = null;

        public ECMInfoTableImport(IActionContext context)
        {
            actionContext = context;
        }

        private static T DeserializeInnerSoapObject<T>(string soapResponse)
        {
            XmlDocument x = new XmlDocument();
            x.LoadXml(soapResponse);
            var soapBody = x.GetElementsByTagName("soapenv:Body")[0];
            string innerObject = soapBody.InnerXml;
            XmlSerializer deserializer = new XmlSerializer(typeof(T));

            using (StringReader reader = new StringReader(innerObject))
            {
                return (T)deserializer.Deserialize(reader);
            }
        }

        public void InitiateImport(Guid ecmRequestId)
        {
            Entity ecmRequestLog = new Entity("amxperu_ecmrequestlog");

            try
            {
                var dataContext = actionContext.XrmDataContext;

                var ecmRequest = actionContext.OrganizationService.Retrieve("amxperu_ecmrequest", ecmRequestId, new ColumnSet(true));

                if (((OptionSetValue)ecmRequest.Attributes["statuscode"]).Value == 1)
                {
                    string infoModelRequest = ecmRequest.Attributes["amxperu_request"].ToString();
                    var infoModelUrl = ecmRequest.Attributes["amxperu_url"].ToString();

                    var ruleType = ((OptionSetValue)ecmRequest.Attributes["amxperu_ruletype"]).Value;

                    var modelType = Convert.ToBoolean(ecmRequest.Attributes["amxperu_modeltype"]);

                    string infoTableRequest = ecmRequest.Attributes["amxperu_infotablerequest"].ToString();
                    var infoTableUrl = ecmRequest.Attributes["amxperu_infotableurl"].ToString();

                    string username = ecmRequest.Contains("amxperu_username") ? ecmRequest.Attributes["amxperu_username"].ToString() : string.Empty;
                    string password = ecmRequest.Contains("amxperu_password") ? ecmRequest.Attributes["amxperu_password"].ToString() : string.Empty;


                    Guid resultInfoModelId = ecmRequest.Contains("amxperu_infomodelid") ? ((EntityReference)ecmRequest.Attributes["amxperu_infomodelid"]).Id : Guid.Empty;

                    //Info Model Sync
                    if (resultInfoModelId == Guid.Empty)
                    {
                        resultInfoModelId = InfoModelSync(username, password, infoModelUrl, infoModelRequest);
                    }

                    ecmRequestLog.Attributes["amxperu_name"] = ecmRequest.Attributes["amxperu_name"].ToString() + " - " + DateTime.Now.ToString();
                    ecmRequestLog.Attributes["amxperu_ecmrequestid"] = new EntityReference("amxperu_ecmrequest", ecmRequest.Id);

                    var resultPriceConfiguration = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = "amxperu_infomodelpriceconfiguration",
                        ColumnSet = new ColumnSet(true),
                        Criteria = new FilterExpression()
                        {
                            Conditions = { new ConditionExpression("amxperu_ecmrequestid", ConditionOperator.Equal, ecmRequest.Id) }
                        }
                    });

                    if ((modelType == false) && (ruleType == 1)) //price for Data version
                    {
                        PriceInfoTableSyncDataModel(username, password, resultInfoModelId, infoTableUrl, infoTableRequest, ((EntityReference)ecmRequest.Attributes["amxperu_productofferingid"]).Id, resultPriceConfiguration);
                    }
                    else if ((modelType == false) && (ruleType == 2)) //availability for Data version
                    {
                        AvailabilityInfoTableSyncDataModel(username, password, resultInfoModelId, infoTableUrl, infoTableRequest);
                    }
                    else if ((modelType == false) && (ruleType == 3)) //other for Data version
                    {
                        OtherInfoTableSyncDataModel(username, password, resultInfoModelId, infoTableUrl, infoTableRequest, resultPriceConfiguration);
                    }
                    else if ((modelType == true) && (ruleType == 3)) //other for Row version // generic field
                    {
                        OtherInfoTableSyncRowModel(username, password, resultInfoModelId, infoTableUrl, infoTableRequest, resultPriceConfiguration);
                    }
                    else if ((modelType == true) && (ruleType == 2)) //availability for Row version
                    {
                        AvailabilityInfoTableSyncRowModel(username, password, resultInfoModelId, infoTableUrl, infoTableRequest);
                    }
                    else if ((modelType == true) && (ruleType == 1)) //price for Row version
                    {
                        PriceInfoTableSyncRowModel(username, password, resultInfoModelId, infoTableUrl, infoTableRequest, ((EntityReference)ecmRequest.Attributes["amxperu_productofferingid"]).Id, resultPriceConfiguration);
                    }
                    else if ((modelType == true) && (ruleType == 4)) //row model generic
                    {
                        OtherInfoTableSyncRowModelGenericField(username, password, resultInfoModelId, infoTableUrl, infoTableRequest);
                    }
                    else if ((modelType == false) && (ruleType == 4)) //data model generic
                    {
                        OtherInfoTableSyncDataModelGenericField(username, password, resultInfoModelId, infoTableUrl, infoTableRequest);
                    }


                    ecmRequestLog.Attributes["statuscode"] = new OptionSetValue(1);
                    actionContext.OrganizationService.Create(ecmRequestLog);

                    Entity ecm = new Entity("amxperu_ecmrequest");
                    ecm.Id = ecmRequest.Id;

                    var date = ecmRequest.Contains("amxperu_nextexecutedate") ? Convert.ToDateTime(ecmRequest.Attributes["amxperu_nextexecutedate"].ToString()) : DateTime.Now;

                    ecm.Attributes["amxperu_nextexecutedate"] = date.AddDays(1);
                    ecm.Attributes["amxperu_lastexecutedate"] = DateTime.Now;
                    ecm.Attributes["amxperu_infomodelid"] = new EntityReference("amxperu_infomodel", resultInfoModelId);
                    actionContext.OrganizationService.Update(ecm);
                }
            }
            catch (Exception ex)
            {
                ecmRequestLog.Attributes["statuscode"] = new OptionSetValue(250000000);
                actionContext.OrganizationService.Create(ecmRequestLog);
                throw ex;
            }
        }

        private Guid InfoModelSync(string username, string password, string serviceUrl, string SoapXmlText)
        {
            string soapResult = ExecuteECMService(username, password, serviceUrl, SoapXmlText, "", "ReadInfoModel");

            Guid infoModelId = Guid.Empty;

            InfoModel deserializedObject = DeserializeInnerSoapObject<InfoModel>(soapResult);

            //create info model
            Entity infoModel = new Entity("amxperu_infomodel");
            infoModel.Attributes["amxperu_infomodelcode"] = deserializedObject.InfoModelCode;
            infoModel.Attributes["amxperu_label"] = deserializedObject.Label;
            infoModel.Attributes["amxperu_name"] = deserializedObject.Name;
            infoModel.Attributes["amxperu_startdate"] = Convert.ToDateTime(deserializedObject.StartDate);
            infoModel.Attributes["amxperu_updatedate"] = Convert.ToDateTime(deserializedObject.UpdateDate);
            infoModel.Attributes["amxperu_createdate"] = Convert.ToDateTime(deserializedObject.CreateDate);
            infoModel.Attributes["amxperu_status"] = deserializedObject.Status;
            infoModel.Attributes["amxperu_createdby"] = deserializedObject.CreatedBy;
            infoModel.Attributes["amxperu_description"] = deserializedObject.Description;
            infoModel.Attributes["amxperu_updatedby"] = deserializedObject.UpdatedBy;

            infoModelId = actionContext.OrganizationService.Create(infoModel);

            foreach (var attribute in deserializedObject.InfoModelAttributes)
            {
                //create info model attribute
                Entity infoModelAttribute = new Entity("amxperu_infomodelattribute");
                infoModelAttribute.Attributes["amxperu_attributecode"] = attribute.AttributeCode;
                infoModelAttribute.Attributes["amxperu_createdate"] = Convert.ToDateTime(attribute.CreateDate);
                infoModelAttribute.Attributes["amxperu_createdby"] = attribute.CreatedBy;
                infoModelAttribute.Attributes["amxperu_issearch"] = attribute.IsSearch == "1" ? true : false;
                infoModelAttribute.Attributes["amxperu_label"] = attribute.Label;
                infoModelAttribute.Attributes["amxperu_modelattrname"] = attribute.ModelAttrName;
                infoModelAttribute.Attributes["amxperu_name"] = attribute.Name;
                infoModelAttribute.Attributes["amxperu_projectcode"] = attribute.ProjectCode;
                infoModelAttribute.Attributes["amxperu_sequence"] = Convert.ToInt32(attribute.Sequence);
                infoModelAttribute.Attributes["amxperu_updatedate"] = Convert.ToDateTime(attribute.UpdateDate);
                infoModelAttribute.Attributes["amxperu_updatedby"] = attribute.UpdatedBy;
                infoModelAttribute.Attributes["amxperu_infomodelid"] = new EntityReference("amxperu_infomodel", infoModelId);
                actionContext.OrganizationService.Create(infoModelAttribute);

            }

            return infoModelId;
        }

        private void PriceInfoTableSyncRowModel(string username, string password, Guid infoModelId, string serviceUrl, string SoapXmlText, Guid productId, EntityCollection priceConfigurations)
        {
            string res = ExecuteECMService(username, password, serviceUrl, SoapXmlText, "", "SearchInfoTable");

            InfoTableList4 deserializedObject = DeserializeInnerSoapObject<InfoTableList4>(res);

            foreach (var item in deserializedObject.InfoTables)
            {
                //check infotable
                var infoTable = RetriveInfoTable(item.InfoModelCode, item.InfoTableCode);

                if (infoTable.Entities.Count > 0)
                {
                    //if startdate>tablestartdate readinfo
                    DateTime d1 = Convert.ToDateTime(item.StartDate);
                    DateTime d2 = Convert.ToDateTime(infoTable.Entities[0].Attributes["amxperu_startdate"].ToString());

                    if (d1 > d2)
                    {
                        //readinfotable
                        string ress = ExecuteECMService(username, password, serviceUrl, SoapXmlText, item.StartDate, "ReadInfoTable");

                        InfoTable2 deserializedObject2 = DeserializeInnerSoapObject<InfoTable2>(ress);
                        CreatePriceInfoTableRecordsRowModel(deserializedObject2, infoModelId, infoTable.Entities[0].Id, productId, priceConfigurations);

                        Entity e = new Entity("amxperu_infotable");
                        e.Id = infoTable.Entities[0].Id;
                        e.Attributes["amxperu_startdate"] = d1;
                        actionContext.OrganizationService.Update(e);
                    }
                }
                else
                {
                    //create table
                    var infoTableId = CreateInfoTableRowModel(item, infoModelId);

                    //readinfotable
                    string ress = ExecuteECMService(username, password, serviceUrl, SoapXmlText, item.StartDate, "ReadInfoTable");

                    InfoTable2 deserializedObject2 = DeserializeInnerSoapObject<InfoTable2>(ress);
                    CreatePriceInfoTableRecordsRowModel(deserializedObject2, infoModelId, infoTableId, productId, priceConfigurations);
                }
            }
        }

        private void CreatePriceInfoTableRecordsRowModel(InfoTable2 deserializedObject, Guid infoModelId, Guid infoTableId, Guid productId, EntityCollection priceConfigurations)
        {
            Dictionary<string, int> priceList = new Dictionary<string, int>();

            foreach (var item in priceConfigurations.Entities)
            {
                priceList.Add(item.Attributes["amxperu_attributename"].ToString(), ((OptionSetValue)item.Attributes["amxperu_pricetypecode"]).Value);
            }

            var infoTableRecord = deserializedObject.InfoTableRows;

            //For performance, create all record without any condition check in pending status. Version handler will execute async and commit

            foreach (var record in infoTableRecord)
            {
                Entity POPConfig = new Entity("amxperu_productofferingpriceconfiguration");
                POPConfig.Attributes["amxperu_name"] = record.InfoTableCode;
                POPConfig.Attributes["amxperu_productoffering"] = new EntityReference(Product.EntityLogicalName, productId);
                POPConfig.Attributes["amxperu_infotableid"] = new EntityReference("amxperu_infotable", infoTableId);
                POPConfig.Attributes["amxperu_infomodelid"] = new EntityReference("amxperu_infomodel", infoModelId);

                //TODO: below lines
                POPConfig.Attributes["amxperu_version"] = "1";
                POPConfig.Attributes["amxperu_startdate"] = Convert.ToDateTime(deserializedObject.StartDate);
                POPConfig.Attributes["amxperu_code"] = record.Code;
                POPConfig.Attributes["amxperu_cancel"] = record.Cancel;
                POPConfig.Attributes["statuscode"] = new OptionSetValue(1);

                var popConfigId = actionContext.OrganizationService.Create(POPConfig);

                //retrieve info table record with code,info model and şnfo table
                //if startdate>now , create a version handler, else change status

                CreateProductVersionHandler(Guid.Empty, Guid.Empty, Guid.Empty, popConfigId, deserializedObject.StartDate);

                foreach (var item in record.Data)
                {
                    //create info table value
                    if ((priceList.Count > 0) && (!priceList.Keys.Contains(item.ColumnName))
                        || (priceList.Count <= 0))
                    {
                        var resultCharacteristic = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                        {
                            EntityName = etel_productcharacteristic.EntityLogicalName,
                            ColumnSet = new ColumnSet("etel_name"),
                            Criteria = new FilterExpression()
                            {
                                Conditions = { new ConditionExpression("etel_externalid", ConditionOperator.Equal, item.ColumnName) }
                            }
                        });

                        if (resultCharacteristic.Entities.Count > 0)
                        {
                            var resultCharacteristicUse = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                            {
                                EntityName = "amxperu_productofferingcharuse",
                                ColumnSet = new ColumnSet("amxperu_productofferingcharuseid"),
                                Criteria = new FilterExpression()
                                {
                                    Conditions = { new ConditionExpression("amxperu_characteristic", ConditionOperator.Equal, resultCharacteristic.Entities[0].Id)
                                            , new ConditionExpression("amxperu_productoffering", ConditionOperator.Equal, productId)}
                                }
                            });

                            if (resultCharacteristicUse.Entities.Count > 0)
                            {
                                var resultCharacteristicValue = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                                {
                                    EntityName = etel_productcharacteristicvalue.EntityLogicalName,
                                    ColumnSet = new ColumnSet("etel_productcharacteristicvalueid"),
                                    Criteria = new FilterExpression()
                                    {
                                        Conditions =
                                    { new ConditionExpression("etel_name", ConditionOperator.Equal, item),
                                      new ConditionExpression("etel_productcharacteristicid", ConditionOperator.Equal, resultCharacteristic.Entities[0].Id) }
                                    }
                                });

                                Guid valueId = Guid.Empty;

                                if (resultCharacteristicValue.Entities.Count > 0)
                                {
                                    valueId = resultCharacteristicValue.Entities[0].Id;
                                }
                                else
                                {
                                    Entity newValue = new Entity("etel_productcharacteristicvalue");
                                    newValue.Attributes["etel_name"] = item;
                                    newValue.Attributes["etel_externalid"] = item;
                                    newValue.Attributes["etel_productcharacteristicid"] = new EntityReference(etel_productcharacteristic.EntityLogicalName, resultCharacteristic.Entities[0].Id);

                                    valueId = actionContext.OrganizationService.Create(newValue);

                                    Entity newCharacteristicValueUse = new Entity("amxperu_productofferingcharvalueuse");
                                    newCharacteristicValueUse.Attributes["amxperu_name"] = resultCharacteristic.Entities[0].Attributes["etel_name"];
                                    newCharacteristicValueUse.Attributes["amxperu_productofferingcharuse"] = new EntityReference("amxperu_productofferingcharuse", resultCharacteristicUse.Entities[0].Id);
                                    newCharacteristicValueUse.Attributes["amxperu_value"] = new EntityReference(etel_productcharacteristicvalue.EntityLogicalName, valueId);

                                    var charValueUseId = actionContext.OrganizationService.Create(newCharacteristicValueUse);

                                }

                                var relation = new AssociateRequest
                                {
                                    Target = new EntityReference("etel_productcharacteristicvalue", valueId),
                                    RelatedEntities = new EntityReferenceCollection { new EntityReference("amxperu_productofferingpriceconfiguration", popConfigId) },
                                    Relationship = new Relationship("amxperu_priceconfiguration_charvalue")
                                };

                                actionContext.OrganizationService.Execute(relation);
                            }

                        }

                        //create info table price

                        if (priceList.Count > 0)
                        {
                            if (priceList.Keys.Contains(item.ColumnName))
                            {
                                Entity newPOP = new Entity("amxperu_productofferingprice");
                                newPOP.Attributes["amxperu_externalid"] = item.ColumnName;
                                newPOP.Attributes["amxperu_name"] = item.ColumnName;
                                newPOP.Attributes["amxperu_pricetypecode"] = new OptionSetValue(priceList[item.ColumnName]);
                                newPOP.Attributes["amxperu_price"] = new Money(Convert.ToDecimal(item.ColumnValue));
                                newPOP.Attributes["amxperu_productofferingid"] = new EntityReference(Product.EntityLogicalName, productId);
                                newPOP.Attributes["amxperu_popconfiguration"] = new EntityReference("amxperu_productofferingpriceconfiguration", popConfigId);

                                var popId = actionContext.OrganizationService.Create(newPOP);
                            }
                        }
                    }

                }
            }

        }

        private void PriceInfoTableSyncDataModel(string username, string password, Guid infoModelId, string serviceUrl, string SoapXmlText, Guid productId, EntityCollection priceConfigurations)
        {
            string soapResult = ExecuteECMService(username, password, serviceUrl, SoapXmlText, "", "SearchInfoTable");

            InfoTableList5 deserializedObject = DeserializeInnerSoapObject<InfoTableList5>(soapResult);

            Dictionary<int, int> priceList = new Dictionary<int, int>();

            foreach (var item in priceConfigurations.Entities)
            {
                priceList.Add(Convert.ToInt32(item.Attributes["amxperu_sequence"].ToString()), ((OptionSetValue)item.Attributes["amxperu_pricetypecode"]).Value);
            }

            //retrive infomodelattiributes

            var queryInfoModelAtt = new QueryExpression
            {
                EntityName = "amxperu_infomodelattribute",
                ColumnSet = new ColumnSet("amxperu_sequence", "amxperu_modelattrname", "amxperu_name"),
                Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_infomodelid", ConditionOperator.Equal, infoModelId) } }
            };
            queryInfoModelAtt.AddOrder("amxperu_sequence", OrderType.Ascending);

            var resultInfoModelAttribute = actionContext.OrganizationService.RetrieveMultiple(queryInfoModelAtt);

            foreach (var item in deserializedObject.InfoTables)
            {
                Guid infoTableId = Guid.Empty;

                //check existing info table
                var queryExp = new QueryExpression
                {
                    EntityName = "amxperu_infotable",
                    ColumnSet = new ColumnSet("amxperu_startdate", "amxperu_version"),
                    Criteria = new FilterExpression()
                    {
                        Conditions = { new ConditionExpression("amxperu_infomodelcode", ConditionOperator.Equal, item.InfoModelCode),
                    new ConditionExpression("amxperu_infotablecode", ConditionOperator.Equal, item.InfoTableCode)}
                    }
                };
                queryExp.AddOrder("createdon", OrderType.Descending);

                var resultInfoTable = actionContext.OrganizationService.RetrieveMultiple(queryExp);

                string version = string.Empty;
                Guid previousInfoTableId = Guid.Empty;

                if ((resultInfoTable.Entities.Count > 0)
                    && (Convert.ToDateTime(resultInfoTable.Entities[0].Attributes["amxperu_startdate"].ToString()) < Convert.ToDateTime(item.StartDate)))
                {
                    previousInfoTableId = resultInfoTable.Entities[0].Id;
                    version = resultInfoTable.Entities[0].Attributes["amxperu_version"].ToString();
                    int versionNumber = Convert.ToInt32(version);
                    int newVersionNumber = versionNumber + 1;

                    version = newVersionNumber.ToString();
                }
                else if (resultInfoTable.Entities.Count <= 0)
                {
                    version = "1";
                }

                if (!string.IsNullOrEmpty(version))
                {
                    bool isAvailable = false;

                    if (Convert.ToDateTime(item.StartDate) <= DateTime.Now)
                    {
                        isAvailable = true;
                    }

                    infoTableId = CreateInfoTableDataModel(item, version, infoModelId, isAvailable, previousInfoTableId);

                    CreatePriceInfoTableRecordsDataModel(item, version, infoModelId, infoTableId, productId, priceConfigurations, isAvailable, priceList, resultInfoModelAttribute);

                    if (!isAvailable)
                    {
                        CreateProductVersionHandler(infoTableId, Guid.Empty, Guid.Empty, Guid.Empty, item.StartDate);
                    }
                }
            }
        }

        private void AvailabilityInfoTableSyncDataModel(string username, string password, Guid infoModelId, string serviceUrl, string SoapXmlText)
        {
            string soapResult = ExecuteECMService(username, password, serviceUrl, SoapXmlText, "", "SearchInfoTable");

            InfoTableList5 deserializedObject = DeserializeInnerSoapObject<InfoTableList5>(soapResult);

            //retrive infomodelattiributes

            var queryInfoModelAtt = new QueryExpression
            {
                EntityName = "amxperu_infomodelattribute",
                ColumnSet = new ColumnSet("amxperu_sequence", "amxperu_modelattrname", "amxperu_name"),
                Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_infomodelid", ConditionOperator.Equal, infoModelId) } }
            };
            queryInfoModelAtt.AddOrder("amxperu_sequence", OrderType.Ascending);

            var resultInfoModelAttribute = actionContext.OrganizationService.RetrieveMultiple(queryInfoModelAtt);

            foreach (var item in deserializedObject.InfoTables)
            {
                Guid infoTableId = Guid.Empty;

                //check existing info table
                var queryExp = new QueryExpression
                {
                    EntityName = "amxperu_infotable",
                    ColumnSet = new ColumnSet("amxperu_startdate", "amxperu_version"),
                    Criteria = new FilterExpression()
                    {
                        Conditions = { new ConditionExpression("amxperu_infomodelcode", ConditionOperator.Equal, item.InfoModelCode),
                    new ConditionExpression("amxperu_infotablecode", ConditionOperator.Equal, item.InfoTableCode)}
                    }
                };
                queryExp.AddOrder("createdon", OrderType.Descending);

                var resultInfoTable = actionContext.OrganizationService.RetrieveMultiple(queryExp);

                string version = string.Empty;
                Guid previousInfoTableId = Guid.Empty;

                if ((resultInfoTable.Entities.Count > 0)
                    && (Convert.ToDateTime(resultInfoTable.Entities[0].Attributes["amxperu_startdate"].ToString()) < Convert.ToDateTime(item.StartDate)))
                {
                    previousInfoTableId = resultInfoTable.Entities[0].Id;
                    version = resultInfoTable.Entities[0].Attributes["amxperu_version"].ToString();
                    int versionNumber = Convert.ToInt32(version);
                    int newVersionNumber = versionNumber + 1;

                    version = newVersionNumber.ToString();
                }
                else if (resultInfoTable.Entities.Count <= 0)
                {
                    version = "1";
                }

                if (!string.IsNullOrEmpty(version))
                {
                    bool isAvailable = false;

                    if (Convert.ToDateTime(item.StartDate) <= DateTime.Now)
                    {
                        isAvailable = true;
                    }

                    infoTableId = CreateInfoTableDataModel(item, version, infoModelId, isAvailable, previousInfoTableId);

                    CreateAvailabilityInfoTableRecordsDataModel(item, version, infoModelId, infoTableId, isAvailable, resultInfoModelAttribute);

                    if (!isAvailable)
                    {
                        CreateProductVersionHandler(infoTableId, Guid.Empty, Guid.Empty, Guid.Empty, item.StartDate);
                    }
                }
            }
        }

        private void AvailabilityInfoTableSyncRowModel(string username, string password, Guid infoModelId, string serviceUrl, string SoapXmlText)
        {
            string res = ExecuteECMService(username, password, serviceUrl, SoapXmlText, "", "SearchInfoTable");

            InfoTableList4 deserializedObject = DeserializeInnerSoapObject<InfoTableList4>(res);

            foreach (var item in deserializedObject.InfoTables)
            {
                //check infotable
                var infoTable = RetriveInfoTable(item.InfoModelCode, item.InfoTableCode);

                if (infoTable.Entities.Count > 0)
                {
                    //if startdate>tablestartdate readinfo
                    DateTime d1 = Convert.ToDateTime(item.StartDate);
                    DateTime d2 = Convert.ToDateTime(infoTable.Entities[0].Attributes["amxperu_startdate"].ToString());

                    if (d1 > d2)
                    {
                        //readinfotable
                        string ress = ExecuteECMService(username, password, serviceUrl, SoapXmlText, item.StartDate, "ReadInfoTable");

                        InfoTable2 deserializedObject2 = DeserializeInnerSoapObject<InfoTable2>(ress);
                        CreateAvailabilityInfoTableRecordsRowModel(deserializedObject2, infoModelId, infoTable.Entities[0].Id);

                        Entity e = new Entity("amxperu_infotable");
                        e.Id = infoTable.Entities[0].Id;
                        e.Attributes["amxperu_startdate"] = d1;
                        actionContext.OrganizationService.Update(e);
                    }
                }
                else
                {
                    //create table
                    var infoTableId = CreateInfoTableRowModel(item, infoModelId);

                    //readinfotable
                    string ress = ExecuteECMService(username, password, serviceUrl, SoapXmlText, item.StartDate, "ReadInfoTable");

                    InfoTable2 deserializedObject2 = DeserializeInnerSoapObject<InfoTable2>(ress);
                    CreateAvailabilityInfoTableRecordsRowModel(deserializedObject2, infoModelId, infoTableId);
                }
            }
        }

        private void OtherInfoTableSyncDataModel(string username, string password, Guid infoModelId, string serviceUrl, string SoapXmlText, EntityCollection priceConfigurations)
        {
            //Returns all info tables and info tables content
            string soapResult = ExecuteECMService(username, password, serviceUrl, SoapXmlText, "", "SearchInfoTable");

            InfoTableList5 deserializedObject = DeserializeInnerSoapObject<InfoTableList5>(soapResult);

            Dictionary<int, int> priceList = new Dictionary<int, int>();

            foreach (var item in priceConfigurations.Entities)
            {
                priceList.Add(Convert.ToInt32(item.Attributes["amxperu_sequence"].ToString()), ((OptionSetValue)item.Attributes["amxperu_pricetypecode"]).Value);
            }

            //retrive infomodelattiributes

            var queryInfoModelAtt = new QueryExpression
            {
                EntityName = "amxperu_infomodelattribute",
                ColumnSet = new ColumnSet("amxperu_sequence", "amxperu_modelattrname", "amxperu_name"),
                Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_infomodelid", ConditionOperator.Equal, infoModelId) } }
            };
            queryInfoModelAtt.AddOrder("amxperu_sequence", OrderType.Ascending);

            var resultInfoModelAttribute = actionContext.OrganizationService.RetrieveMultiple(queryInfoModelAtt);

            foreach (var item in deserializedObject.InfoTables)
            {
                Guid infoTableId = Guid.Empty;

                //check existing info table
                var queryExp = new QueryExpression
                {
                    EntityName = "amxperu_infotable",
                    ColumnSet = new ColumnSet("amxperu_startdate", "amxperu_version"),
                    Criteria = new FilterExpression()
                    {
                        Conditions = { new ConditionExpression("amxperu_infomodelcode", ConditionOperator.Equal, item.InfoModelCode),
                        new ConditionExpression("amxperu_infotablecode", ConditionOperator.Equal, item.InfoTableCode)}
                    }
                };
                queryExp.AddOrder("createdon", OrderType.Descending);

                var resultInfoTable = actionContext.OrganizationService.RetrieveMultiple(queryExp);

                string version = string.Empty;
                Guid previousInfoTableId = Guid.Empty;

                if ((resultInfoTable.Entities.Count > 0)
                    && (Convert.ToDateTime(resultInfoTable.Entities[0].Attributes["amxperu_startdate"].ToString()) < Convert.ToDateTime(item.StartDate)))
                {
                    previousInfoTableId = resultInfoTable.Entities[0].Id;
                    version = resultInfoTable.Entities[0].Attributes["amxperu_version"].ToString();
                    int versionNumber = Convert.ToInt32(version);
                    int newVersionNumber = versionNumber + 1;

                    version = newVersionNumber.ToString();
                }
                else if (resultInfoTable.Entities.Count <= 0)
                {
                    version = "1";
                }

                if (!string.IsNullOrEmpty(version))
                {
                    bool isAvailable = false;

                    if (Convert.ToDateTime(item.StartDate) <= DateTime.Now)
                    {
                        isAvailable = true;
                    }

                    infoTableId = CreateInfoTableDataModel(item, version, infoModelId, isAvailable, previousInfoTableId);

                    CreateOtherInfoTableRecordsDataModel(item, version, infoModelId, infoTableId, priceConfigurations, isAvailable, priceList, resultInfoModelAttribute);

                    if (!isAvailable)
                    {
                        CreateProductVersionHandler(infoTableId, Guid.Empty, Guid.Empty, Guid.Empty, item.StartDate);
                    }
                }
            }
        }

        private void OtherInfoTableSyncDataModelGenericField(string username, string password, Guid infoModelId, string serviceUrl, string SoapXmlText)
        {
            //Returns all info tables and info tables content
            string soapResult = ExecuteECMService(username, password, serviceUrl, SoapXmlText, "", "SearchInfoTable");

            InfoTableList5 deserializedObject = DeserializeInnerSoapObject<InfoTableList5>(soapResult);

            Dictionary<int, int> priceList = new Dictionary<int, int>();

            //retrive infomodelattiributes

            var queryInfoModelAtt = new QueryExpression
            {
                EntityName = "amxperu_infomodelattribute",
                ColumnSet = new ColumnSet("amxperu_sequence", "amxperu_modelattrname", "amxperu_name"),
                Criteria = new FilterExpression() { Conditions = { new ConditionExpression("amxperu_infomodelid", ConditionOperator.Equal, infoModelId) } }
            };
            queryInfoModelAtt.AddOrder("amxperu_sequence", OrderType.Ascending);

            var resultInfoModelAttribute = actionContext.OrganizationService.RetrieveMultiple(queryInfoModelAtt);

            foreach (var item in deserializedObject.InfoTables)
            {
                Guid infoTableId = Guid.Empty;

                //check existing info table
                var queryExp = new QueryExpression
                {
                    EntityName = "amxperu_infotable",
                    ColumnSet = new ColumnSet("amxperu_startdate", "amxperu_version"),
                    Criteria = new FilterExpression()
                    {
                        Conditions = { new ConditionExpression("amxperu_infomodelcode", ConditionOperator.Equal, item.InfoModelCode),
                        new ConditionExpression("amxperu_infotablecode", ConditionOperator.Equal, item.InfoTableCode)}
                    }
                };
                queryExp.AddOrder("createdon", OrderType.Descending);

                var resultInfoTable = actionContext.OrganizationService.RetrieveMultiple(queryExp);

                string version = string.Empty;
                Guid previousInfoTableId = Guid.Empty;

                if ((resultInfoTable.Entities.Count > 0)
                    && (Convert.ToDateTime(resultInfoTable.Entities[0].Attributes["amxperu_startdate"].ToString()) < Convert.ToDateTime(item.StartDate)))
                {
                    previousInfoTableId = resultInfoTable.Entities[0].Id;
                    version = resultInfoTable.Entities[0].Attributes["amxperu_version"].ToString();
                    int versionNumber = Convert.ToInt32(version);
                    int newVersionNumber = versionNumber + 1;

                    version = newVersionNumber.ToString();
                }
                else if (resultInfoTable.Entities.Count <= 0)
                {
                    version = "1";
                }

                if (!string.IsNullOrEmpty(version))
                {
                    bool isAvailable = false;

                    if (Convert.ToDateTime(item.StartDate) <= DateTime.Now)
                    {
                        isAvailable = true;
                    }

                    infoTableId = CreateInfoTableDataModel(item, version, infoModelId, isAvailable, previousInfoTableId);

                    CreateOtherInfoTableRecordsDataModelGenericField(item, version, infoModelId, infoTableId, isAvailable, resultInfoModelAttribute);

                    if (!isAvailable)
                    {
                        CreateProductVersionHandler(infoTableId, Guid.Empty, Guid.Empty, Guid.Empty, item.StartDate);
                    }
                }
            }
        }

        private void OtherInfoTableSyncRowModel(string username, string password, Guid infoModelId, string serviceUrl, string SoapXmlText, EntityCollection priceConfigurations)
        {
            //SearchInfoTable
            //returns all infotables regarding infomodel with all versions without data
            //for each infotable execute readinfotable
            //returns only delta rows
            //check startdate and if it is necessary create version or new infotable
            //info table Code is used for checking existing info table

            string res = ExecuteECMService(username, password, serviceUrl, SoapXmlText, "", "SearchInfoTable");

            InfoTableList4 deserializedObject = DeserializeInnerSoapObject<InfoTableList4>(res);

            foreach (var item in deserializedObject.InfoTables)
            {
                //check infotable
                var infoTable = RetriveInfoTable(item.InfoModelCode, item.InfoTableCode);

                if (infoTable.Entities.Count > 0)
                {
                    //if startdate>tablestartdate readinfo
                    DateTime d1 = Convert.ToDateTime(item.StartDate);
                    DateTime d2 = Convert.ToDateTime(infoTable.Entities[0].Attributes["amxperu_startdate"].ToString());

                    if (d1 > d2)
                    {
                        //readinfotable
                        string ress = ExecuteECMService(username, password, serviceUrl, SoapXmlText, item.StartDate, "ReadInfoTable");

                        InfoTable2 deserializedObject2 = DeserializeInnerSoapObject<InfoTable2>(ress);
                        CreateOtherInfoTableRecordsRowModel(deserializedObject2, infoModelId, infoTable.Entities[0].Id, priceConfigurations);

                        Entity e = new Entity("amxperu_infotable");
                        e.Id = infoTable.Entities[0].Id;
                        e.Attributes["amxperu_startdate"] = d1;
                        actionContext.OrganizationService.Update(e);

                    }
                }
                else
                {
                    //create table
                    var infoTableId = CreateInfoTableRowModel(item, infoModelId);

                    //readinfotable
                    string ress = ExecuteECMService(username, password, serviceUrl, SoapXmlText, item.StartDate, "ReadInfoTable");

                    InfoTable2 deserializedObject2 = DeserializeInnerSoapObject<InfoTable2>(ress);
                    CreateOtherInfoTableRecordsRowModel(deserializedObject2, infoModelId, infoTableId, priceConfigurations);
                }
            }
        }

        private void OtherInfoTableSyncRowModelGenericField(string username, string password, Guid infoModelId, string serviceUrl, string SoapXmlText)
        {
            //SearchInfoTable
            //returns all infotables regarding infomodel with all versions without data
            //for each infotable execute readinfotable
            //returns only delta rows
            //check startdate and if it is necessary create version or new infotable
            //info table Code is used for checking existing info table

            string res = ExecuteECMService(username, password, serviceUrl, SoapXmlText, "", "SearchInfoTable");

            InfoTableList4 deserializedObject = DeserializeInnerSoapObject<InfoTableList4>(res);

            foreach (var item in deserializedObject.InfoTables)
            {
                //check infotable
                var infoTable = RetriveInfoTable(item.InfoModelCode, item.InfoTableCode);

                if (infoTable.Entities.Count > 0)
                {
                    //if startdate>tablestartdate readinfo
                    DateTime d1 = Convert.ToDateTime(item.StartDate);
                    DateTime d2 = Convert.ToDateTime(infoTable.Entities[0].Attributes["amxperu_startdate"].ToString());

                    if (d1 > d2)
                    {
                        //readinfotable
                        string ress = ExecuteECMService(username, password, serviceUrl, SoapXmlText, item.StartDate, "ReadInfoTable");

                        InfoTable2 deserializedObject2 = DeserializeInnerSoapObject<InfoTable2>(ress);
                        CreateOtherInfoTableRecordsRowModelGenericField(deserializedObject2, infoModelId, infoTable.Entities[0].Id);

                        Entity e = new Entity("amxperu_infotable");
                        e.Id = infoTable.Entities[0].Id;
                        e.Attributes["amxperu_startdate"] = d1;
                        actionContext.OrganizationService.Update(e);

                    }
                }
                else
                {
                    //create table
                    var infoTableId = CreateInfoTableRowModel(item, infoModelId);

                    //readinfotable
                    string ress = ExecuteECMService(username, password, serviceUrl, SoapXmlText, item.StartDate, "ReadInfoTable");

                    InfoTable2 deserializedObject2 = DeserializeInnerSoapObject<InfoTable2>(ress);
                    CreateOtherInfoTableRecordsRowModelGenericField(deserializedObject2, infoModelId, infoTableId);
                }
            }
        }

        private EntityCollection RetriveInfoTable(string infoModelCode, string infoTableCode)
        {
            var queryExp = new QueryExpression
            {
                EntityName = "amxperu_infotable",
                ColumnSet = new ColumnSet("amxperu_startdate", "amxperu_version"),
                Criteria = new FilterExpression()
                {
                    Conditions = { new ConditionExpression("amxperu_infomodelcode", ConditionOperator.Equal, infoModelCode),
                    new ConditionExpression("amxperu_infotablecode", ConditionOperator.Equal, infoTableCode)}
                }
            };

            var result = actionContext.OrganizationService.RetrieveMultiple(queryExp);
            return result;
        }

        private void CreateProductVersionHandler(Guid infoTableId, Guid infoTableRecordId, Guid availabilityConfigId, Guid popConfigId, string startDate)
        {
            Entity handler = new Entity("amxperu_productversionhandler");

            if (infoTableId != Guid.Empty)
            {
                handler.Attributes["amxperu_infotableid"] = new EntityReference("amxperu_infotable", infoTableId);
            }

            if (infoTableRecordId != Guid.Empty)
            {
                handler.Attributes["amxperu_infotablerecordid"] = new EntityReference("amxperu_infotablerecord", infoTableRecordId);
            }

            if (availabilityConfigId != Guid.Empty)
            {
                handler.Attributes["amxperu_availabilityconfigurationid"] = new EntityReference("amxperu_productofferingavailabilityconfiguratio", availabilityConfigId);
            }

            if (popConfigId != Guid.Empty)
            {
                handler.Attributes["amxperu_productofferingpriceconfigurationid"] = new EntityReference("amxperu_productofferingpriceconfiguration", popConfigId);
            }

            handler.Attributes["statuscode"] = new OptionSetValue(1); //Pending
            handler.Attributes["amxperu_startdate"] = Convert.ToDateTime(startDate);
            actionContext.OrganizationService.Create(handler);
        }

        private void CreatePriceInfoTableRecordsDataModel(InfoTables5 deserializedObject, string version, Guid infoModelId, Guid infoTableId, Guid productId, EntityCollection priceConfigurations, bool isAvailable, Dictionary<int, int> priceList, EntityCollection resultInfoModelAttribute)
        {
            var infoTableRecord = (InfoTableRecords)Newtonsoft.Json.JsonConvert.DeserializeObject(deserializedObject.Data, typeof(InfoTableRecords));

            var resultCharacteristics = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = etel_productcharacteristic.EntityLogicalName,
                ColumnSet = new ColumnSet("etel_externalid")
            });

            var resultCharacteristicUses = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = "amxperu_productofferingcharuse",
                ColumnSet = new ColumnSet("amxperu_characteristic", "amxperu_name"),
                Criteria = new FilterExpression()
                {
                    Conditions = { new ConditionExpression("amxperu_productoffering", ConditionOperator.Equal, productId) }
                }
            });

            OrganizationRequestCollection associateRequest = new OrganizationRequestCollection();

            foreach (var record in infoTableRecord.infoTableRecords.data)
            {
                var splittedRecord = record.Split(',');

                //Create POP Config
                Entity POPConfig = new Entity("amxperu_productofferingpriceconfiguration");
                POPConfig.Attributes["amxperu_name"] = record;
                POPConfig.Attributes["amxperu_productoffering"] = new EntityReference(Product.EntityLogicalName, productId);
                POPConfig.Attributes["amxperu_infotableid"] = new EntityReference("amxperu_infotable", infoTableId);
                POPConfig.Attributes["amxperu_infomodelid"] = new EntityReference("amxperu_infomodel", infoModelId);
                POPConfig.Attributes["amxperu_version"] = version;

                if (!isAvailable)
                {
                    POPConfig.Attributes["statuscode"] = new OptionSetValue(250000000);
                }
                else
                {
                    POPConfig.Attributes["statuscode"] = new OptionSetValue(1);
                }

                var popConfigId = actionContext.OrganizationService.Create(POPConfig);

                int sequence = 1;

                foreach (var item in splittedRecord)
                {
                    Entity infoModelAttribute =
                        resultInfoModelAttribute.Entities.Where(e => e.Attributes["amxperu_sequence"].ToString() == sequence.ToString()).FirstOrDefault();

                    //check if info table value exists
                    if ((priceList.Count > 0) && (!priceList.Keys.Contains(sequence))
                        || (priceList.Count <= 0))
                    {
                        Entity resultCharacteristic =
                       resultCharacteristics.Entities.Where(e => e.Attributes["etel_externalid"].ToString() == infoModelAttribute.Attributes["amxperu_modelattrname"].ToString()).FirstOrDefault();

                        if (resultCharacteristic != null)
                        {
                            Entity resultCharacteristicUse =
                      resultCharacteristicUses.Entities.Where(e => ((EntityReference)e.Attributes["amxperu_characteristic"]).Id == resultCharacteristic.Id).FirstOrDefault();

                            if (resultCharacteristicUse != null)
                            {
                                var resultCharacteristicValue = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                                {
                                    EntityName = etel_productcharacteristicvalue.EntityLogicalName,
                                    ColumnSet = new ColumnSet("etel_productcharacteristicvalueid"),
                                    Criteria = new FilterExpression()
                                    {
                                        Conditions =
                                    { new ConditionExpression("etel_name", ConditionOperator.Equal, item),
                                      new ConditionExpression("etel_productcharacteristicid", ConditionOperator.Equal,  ((EntityReference)resultCharacteristicUse.Attributes["amxperu_characteristic"]).Id) }
                                    }
                                });

                                Guid valueId = Guid.Empty;

                                if (resultCharacteristicValue.Entities.Count > 0)
                                {
                                    valueId = resultCharacteristicValue.Entities[0].Id;
                                }
                                else
                                {
                                    Entity newValue = new Entity("etel_productcharacteristicvalue");
                                    newValue.Attributes["etel_name"] = item;
                                    newValue.Attributes["etel_externalid"] = item;
                                    newValue.Attributes["etel_productcharacteristicid"] = new EntityReference(etel_productcharacteristic.EntityLogicalName, ((EntityReference)resultCharacteristicUse.Attributes["amxperu_characteristic"]).Id);

                                    valueId = actionContext.OrganizationService.Create(newValue);

                                    Entity newCharacteristicValueUse = new Entity("amxperu_productofferingcharvalueuse");
                                    newCharacteristicValueUse.Attributes["amxperu_name"] = resultCharacteristicUse.Attributes["amxperu_name"];
                                    newCharacteristicValueUse.Attributes["amxperu_productofferingcharuse"] = new EntityReference("amxperu_productofferingcharuse", resultCharacteristicUse.Id);
                                    newCharacteristicValueUse.Attributes["amxperu_value"] = new EntityReference(etel_productcharacteristicvalue.EntityLogicalName, valueId);

                                    var charValueUseId = actionContext.OrganizationService.Create(newCharacteristicValueUse);

                                }

                                var relation = new AssociateRequest
                                {
                                    Target = new EntityReference("etel_productcharacteristicvalue", valueId),
                                    RelatedEntities = new EntityReferenceCollection { new EntityReference("amxperu_productofferingpriceconfiguration", popConfigId) },
                                    Relationship = new Relationship("amxperu_priceconfiguration_charvalue")
                                };



                                associateRequest.Add(relation);
                                //actionContext.OrganizationService.Execute(relation);
                            }
                        }
                    }

                    //create info table price

                    if (priceList.Count > 0)
                    {
                        if (priceList.Keys.Contains(sequence))
                        {
                            Entity newPOP = new Entity("amxperu_productofferingprice");
                            newPOP.Attributes["amxperu_externalid"] = infoModelAttribute.Attributes["amxperu_modelattrname"];
                            newPOP.Attributes["amxperu_name"] = infoModelAttribute.Attributes["amxperu_name"];
                            newPOP.Attributes["amxperu_pricetypecode"] = new OptionSetValue(priceList[sequence]);
                            newPOP.Attributes["amxperu_price"] = new Money(Convert.ToDecimal(item));
                            newPOP.Attributes["amxperu_productofferingid"] = new EntityReference(Product.EntityLogicalName, productId);
                            newPOP.Attributes["amxperu_popconfiguration"] = new EntityReference("amxperu_productofferingpriceconfiguration", popConfigId);

                            var popId = actionContext.OrganizationService.Create(newPOP);

                        }
                    }

                    sequence++;
                }
            }

            if (associateRequest.Count > 0)
            {
                ExecuteMultipleRequest executeMultipleRequest = new ExecuteMultipleRequest();

                int countRest = associateRequest.Count % 1000;
                int count1000 = associateRequest.Count / 1000;

                for (int i = 0; i < count1000; i++)
                {

                    executeMultipleRequest.Requests = new OrganizationRequestCollection();
                    for (int y = i * 1000; y < i * 1000 + 1000; y++)
                    {
                        executeMultipleRequest.Requests.Add(associateRequest[y]);
                    }

                    executeMultipleRequest.Settings = new ExecuteMultipleSettings()
                    {
                        ContinueOnError = true,
                        ReturnResponses = true
                    };
                    ExecuteMultipleResponse responses = (ExecuteMultipleResponse)actionContext.OrganizationService.Execute(executeMultipleRequest);
                }

                for (int y = 1; y <= countRest; y++)
                {
                    executeMultipleRequest.Requests = new OrganizationRequestCollection();

                    executeMultipleRequest.Requests.Add(associateRequest[count1000 * 1000 + y]);

                    executeMultipleRequest.Settings = new ExecuteMultipleSettings()
                    {
                        ContinueOnError = true,
                        ReturnResponses = true
                    };
                    actionContext.OrganizationService.Execute(executeMultipleRequest);
                }
            }
        }

        private void CreateOtherInfoTableRecordsDataModel(InfoTables5 deserializedObject, string version, Guid infoModelId, Guid infoTableId, EntityCollection priceConfigurations, bool isAvailable, Dictionary<int, int> priceList, EntityCollection resultInfoModelAttribute)
        {
            var infoTableRecord = (InfoTableRecords)Newtonsoft.Json.JsonConvert.DeserializeObject(deserializedObject.Data, typeof(InfoTableRecords));

            OrganizationRequestCollection associateRequest = new OrganizationRequestCollection();

            foreach (var record in infoTableRecord.infoTableRecords.data)
            {
                var splittedRecord = record.Split(',');

                Entity infoTableRecordEntity = new Entity("amxperu_infotablerecord");
                infoTableRecordEntity.Attributes["amxperu_infotableid"] = new EntityReference("amxperu_infotable", infoTableId);
                infoTableRecordEntity.Attributes["amxperu_infomodelid"] = new EntityReference("amxperu_infomodel", infoModelId);
                infoTableRecordEntity.Attributes["amxperu_name"] = record;
                var infoTableRecordEntityId = actionContext.OrganizationService.Create(infoTableRecordEntity);

                int sequence = 1;

                foreach (var item in splittedRecord)
                {
                    Entity infoModelAttribute =
                        resultInfoModelAttribute.Entities.Where(e => e.Attributes["amxperu_sequence"].ToString() == sequence.ToString()).FirstOrDefault();

                    //check if info table value exists
                    if ((priceList.Count > 0) && (!priceList.Keys.Contains(sequence))
                        || (priceList.Count <= 0))
                    {
                        var query = new QueryExpression
                        {
                            EntityName = "amxperu_infotablevalue",
                            ColumnSet = new ColumnSet(true)
                        };
                        query.Criteria = new FilterExpression();
                        query.Criteria.AddCondition("amxperu_infomodelattribute", ConditionOperator.Equal, infoModelAttribute.Id);
                        query.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, item);

                        var resultInfoTableValue = actionContext.OrganizationService.RetrieveMultiple(query);
                        Guid infoTableValueId = Guid.Empty;

                        if (resultInfoTableValue.Entities.Count > 0)
                        {
                            infoTableValueId = resultInfoTableValue.Entities[0].Id;
                        }
                        else
                        {
                            //create info table value and associate with info table record
                            Entity infoTableValue = new Entity("amxperu_infotablevalue");
                            infoTableValue.Attributes["amxperu_name"] = item;
                            infoTableValue.Attributes["amxperu_infomodelattribute"] = new EntityReference("amxperu_infomodelattribute", infoModelAttribute.Id);
                            infoTableValueId = actionContext.OrganizationService.Create(infoTableValue);
                        }

                        AssociateRequest relation = new AssociateRequest
                        {
                            Target = new EntityReference("amxperu_infotablevalue", infoTableValueId),
                            RelatedEntities = new EntityReferenceCollection { new EntityReference("amxperu_infotablerecord", infoTableRecordEntityId) },
                            Relationship = new Relationship("amxperu_infotablevalue_infotablerecord")
                        };

                        //actionContext.OrganizationService.Execute(relation);
                        associateRequest.Add(relation);

                    }

                    //create info table price

                    if (priceList.Count > 0)
                    {
                        if (priceList.Keys.Contains(sequence))
                        {
                            //amxperu_infotableprice will be removed
                            Entity infoTablePrice = new Entity("amxperu_infotableprice");
                            infoTablePrice.Attributes["amxperu_amount"] = Convert.ToDecimal(item);
                            infoTablePrice.Attributes["amxperu_infomodelattribute"] = new EntityReference("amxperu_infomodelattribute", infoModelAttribute.Id);
                            infoTablePrice.Attributes["amxperu_infotablerecord"] = new EntityReference("amxperu_infotablerecord", infoTableRecordEntityId);
                            var infoTablePriceId = actionContext.OrganizationService.Create(infoTablePrice);
                        }
                    }

                    sequence++;
                }
            }

            if (associateRequest.Count > 0)
            {
                ExecuteMultipleRequest executeMultipleRequest = new ExecuteMultipleRequest();

                int countRest = associateRequest.Count % 1000;
                int count1000 = associateRequest.Count / 1000;

                for (int i = 0; i < count1000; i++)
                {

                    executeMultipleRequest.Requests = new OrganizationRequestCollection();
                    for (int y = i * 1000; y < i * 1000 + 1000; y++)
                    {
                        executeMultipleRequest.Requests.Add(associateRequest[y]);
                    }

                    executeMultipleRequest.Settings = new ExecuteMultipleSettings()
                    {
                        ContinueOnError = true,
                        ReturnResponses = true
                    };
                    ExecuteMultipleResponse responses = (ExecuteMultipleResponse)actionContext.OrganizationService.Execute(executeMultipleRequest);
                }

                for (int y = 1; y <= countRest; y++)
                {
                    executeMultipleRequest.Requests = new OrganizationRequestCollection();

                    executeMultipleRequest.Requests.Add(associateRequest[count1000 * 1000 + y]);

                    executeMultipleRequest.Settings = new ExecuteMultipleSettings()
                    {
                        ContinueOnError = true,
                        ReturnResponses = true
                    };
                    actionContext.OrganizationService.Execute(executeMultipleRequest);
                }
            }
        }

        private void CreateOtherInfoTableRecordsDataModelGenericField(InfoTables5 deserializedObject, string version, Guid infoModelId, Guid infoTableId, bool isAvailable, EntityCollection resultInfoModelAttribute)
        {
            var infoTableRecord = (InfoTableRecords)Newtonsoft.Json.JsonConvert.DeserializeObject(deserializedObject.Data, typeof(InfoTableRecords));

            foreach (var record in infoTableRecord.infoTableRecords.data)
            {
                var splittedRecord = record.Split(',');

                Entity infoTableRecordEntity = new Entity("amxperu_infotablerecord");
                infoTableRecordEntity.Attributes["amxperu_infotableid"] = new EntityReference("amxperu_infotable", infoTableId);
                infoTableRecordEntity.Attributes["amxperu_infomodelid"] = new EntityReference("amxperu_infomodel", infoModelId);
                infoTableRecordEntity.Attributes["amxperu_name"] = record;

                int sequence = 0;
                string columns = string.Empty;

                foreach (var item in splittedRecord)
                {
                    sequence++;
                    Entity infoModelAttribute =
                        resultInfoModelAttribute.Entities.Where(e => e.Attributes["amxperu_sequence"].ToString() == sequence.ToString()).FirstOrDefault();

                    columns += infoModelAttribute.Attributes["amxperu_name"].ToString() + ",";
                    infoTableRecordEntity.Attributes["amxperu_field" + sequence.ToString()] = item;
                }

                columns = columns.TrimEnd(',');
                infoTableRecordEntity.Attributes["amxperu_columns"] = columns;

                actionContext.OrganizationService.Create(infoTableRecordEntity);
            }
        }

        private void CreateOtherInfoTableRecordsRowModel(InfoTable2 deserializedObject, Guid infoModelId, Guid infoTableId, EntityCollection priceConfigurations)
        {
            Dictionary<string, int> priceList = new Dictionary<string, int>();

            foreach (var item in priceConfigurations.Entities)
            {
                priceList.Add(item.Attributes["amxperu_attributename"].ToString(), ((OptionSetValue)item.Attributes["amxperu_pricetypecode"]).Value);
            }

            var infoTableRecord = deserializedObject.InfoTableRows;

            //For performance, create all record without any condition check in pending status. Version handler will execute async and commit

            foreach (var record in infoTableRecord)
            {
                //retrieve info table record with code,info model and şnfo table
                //if startdate>now , create a version handler, else change status

                Entity infoTableRecordEntity = new Entity("amxperu_infotablerecord");
                infoTableRecordEntity.Attributes["amxperu_infotableid"] = new EntityReference("amxperu_infotable", infoTableId);
                infoTableRecordEntity.Attributes["amxperu_infomodelid"] = new EntityReference("amxperu_infomodel", infoModelId);
                infoTableRecordEntity.Attributes["amxperu_name"] = record.InfoTableCode;
                infoTableRecordEntity.Attributes["amxperu_code"] = record.Code;
                infoTableRecordEntity.Attributes["amxperu_cancel"] = record.Cancel;
                infoTableRecordEntity.Attributes["statuscode"] = new OptionSetValue(250000000);
                infoTableRecordEntity.Attributes["amxperu_startdate"] = Convert.ToDateTime(deserializedObject.StartDate);
                var infoTableRecordEntityId = actionContext.OrganizationService.Create(infoTableRecordEntity);

                CreateProductVersionHandler(Guid.Empty, infoTableRecordEntityId, Guid.Empty, Guid.Empty, deserializedObject.StartDate);

                foreach (var item in record.Data)
                {
                    //create info table value
                    if ((priceList.Count > 0) && (!priceList.Keys.Contains(item.ColumnName))
                        || (priceList.Count <= 0))
                    {
                        var query = new QueryExpression
                        {
                            EntityName = "amxperu_infotablevalue",
                            ColumnSet = new ColumnSet(true)
                        };
                        query.Criteria = new FilterExpression();
                        query.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, item.ColumnName);

                        if (!string.IsNullOrEmpty(item.ColumnValue))
                        {
                            query.Criteria.AddCondition("amxperu_value", ConditionOperator.Equal, item.ColumnValue);
                        }


                        var resultInfoTableValue = actionContext.OrganizationService.RetrieveMultiple(query);
                        Guid infoTableValueId = Guid.Empty;

                        if (resultInfoTableValue.Entities.Count > 0)
                        {
                            infoTableValueId = resultInfoTableValue.Entities[0].Id;
                        }
                        else
                        {
                            //create info table value and associate with info table record
                            Entity infoTableValue = new Entity("amxperu_infotablevalue");
                            infoTableValue.Attributes["amxperu_name"] = item.ColumnName;
                            infoTableValue.Attributes["amxperu_value"] = item.ColumnValue;

                            infoTableValueId = actionContext.OrganizationService.Create(infoTableValue);
                        }

                        AssociateRequest relation = new AssociateRequest
                        {
                            Target = new EntityReference("amxperu_infotablevalue", infoTableValueId),
                            RelatedEntities = new EntityReferenceCollection { new EntityReference("amxperu_infotablerecord", infoTableRecordEntityId) },
                            Relationship = new Relationship("amxperu_infotablevalue_infotablerecord")
                        };

                        actionContext.OrganizationService.Execute(relation);
                    }

                    //create info table price

                    if (priceList.Count > 0)
                    {
                        if (priceList.Keys.Contains(item.ColumnName))
                        {
                            Entity infoTablePrice = new Entity("amxperu_infotableprice");
                            infoTablePrice.Attributes["amxperu_amount"] = Convert.ToDecimal(item.ColumnValue);
                            infoTablePrice.Attributes["amxperu_name"] = item.ColumnName;
                            infoTablePrice.Attributes["amxperu_infotablerecord"] = new EntityReference("amxperu_infotablerecord", infoTableRecordEntityId);
                            var infoTablePriceId = actionContext.OrganizationService.Create(infoTablePrice);
                        }
                    }

                }
            }

        }

        private void CreateOtherInfoTableRecordsRowModelGenericField(InfoTable2 deserializedObject, Guid infoModelId, Guid infoTableId)
        {
            var infoTableRecord = deserializedObject.InfoTableRows;

            //For performance, create all record without any condition check in pending status. Version handler will execute async and commit

            foreach (var record in infoTableRecord)
            {
                //retrieve info table record with code,info model and info table
                //if startdate>now , create a version handler, else change status

                Entity infoTableRecordEntity = new Entity("amxperu_infotablerecord");
                infoTableRecordEntity.Attributes["amxperu_infotableid"] = new EntityReference("amxperu_infotable", infoTableId);
                infoTableRecordEntity.Attributes["amxperu_infomodelid"] = new EntityReference("amxperu_infomodel", infoModelId);
                infoTableRecordEntity.Attributes["amxperu_code"] = record.Code;
                infoTableRecordEntity.Attributes["amxperu_cancel"] = record.Cancel;
                infoTableRecordEntity.Attributes["statuscode"] = new OptionSetValue(250000000);
                infoTableRecordEntity.Attributes["amxperu_startdate"] = Convert.ToDateTime(deserializedObject.StartDate);

                string columns = string.Empty;
                string data = string.Empty;

                int fieldOrder = 0;
                foreach (var item in record.Data)
                {
                    fieldOrder++;
                    columns += item.ColumnName + ",";
                    data += item.ColumnValue + ",";
                    infoTableRecordEntity.Attributes["amxperu_field" + fieldOrder.ToString()] = item.ColumnValue;
                }

                columns = columns.TrimEnd(',');
                data = data.TrimEnd(',');

                infoTableRecordEntity.Attributes["amxperu_columns"] = columns;
                infoTableRecordEntity.Attributes["amxperu_name"] = data;

                var infoTableRecordEntityId = actionContext.OrganizationService.Create(infoTableRecordEntity);
                CreateProductVersionHandler(Guid.Empty, infoTableRecordEntityId, Guid.Empty, Guid.Empty, deserializedObject.StartDate);
            }

        }

        private void CreateAvailabilityInfoTableRecordsDataModel(InfoTables5 deserializedObject, string version, Guid infoModelId, Guid infoTableId, bool isAvailable, EntityCollection resultInfoModelAttribute)
        {
            var infoTableRecord = (InfoTableRecords)Newtonsoft.Json.JsonConvert.DeserializeObject(deserializedObject.Data, typeof(InfoTableRecords));

            foreach (var record in infoTableRecord.infoTableRecords.data)
            {
                var splittedRecord = record.Split(',');

                //Create Availability Config
                Entity AvailabilityConfig = new Entity("amxperu_productofferingavailabilityconfiguratio");
                AvailabilityConfig.Attributes["amxperu_name"] = record;
                AvailabilityConfig.Attributes["amxperu_infotableid"] = new EntityReference("amxperu_infotable", infoTableId);
                AvailabilityConfig.Attributes["amxperu_infomodelid"] = new EntityReference("amxperu_infomodel", infoModelId);
                AvailabilityConfig.Attributes["amxperu_version"] = version;

                if (!isAvailable)
                {
                    AvailabilityConfig.Attributes["statuscode"] = new OptionSetValue(250000000);
                }
                else
                {
                    AvailabilityConfig.Attributes["statuscode"] = new OptionSetValue(1);
                }

                int sequence = 1;

                QueryExpression queryExp = new QueryExpression();

                foreach (var item in splittedRecord)
                {
                    Entity infoModelAttribute =
                        resultInfoModelAttribute.Entities.Where(e => e.Attributes["amxperu_sequence"].ToString() == sequence.ToString()).FirstOrDefault();

                    AvailabilityConfig.Attributes["amxperu_" + infoModelAttribute.Attributes["amxperu_modelattrname"].ToString().ToLower()] = item;

                    if (infoModelAttribute.Attributes["amxperu_modelattrname"].ToString() == "BasicPO")
                    {
                        queryExp = new QueryExpression
                        {
                            EntityName = Product.EntityLogicalName,
                            ColumnSet = new ColumnSet(true),
                            Criteria = new FilterExpression() { Conditions = { new ConditionExpression("etel_externalid", ConditionOperator.Equal, item) } }
                        };

                        var resultPO = actionContext.OrganizationService.RetrieveMultiple(queryExp);

                        if (resultPO.Entities.Count > 0)
                        {
                            AvailabilityConfig.Attributes["amxperu_productofferingid"] = new EntityReference(Product.EntityLogicalName, resultPO.Entities[0].Id);
                        }
                    }

                    sequence++;
                }

                var availabilityConfigId = actionContext.OrganizationService.Create(AvailabilityConfig);
            }
        }

        private void CreateAvailabilityInfoTableRecordsRowModel(InfoTable2 deserializedObject, Guid infoModelId, Guid infoTableId)
        {
            Guid availabilityConfigId = Guid.Empty;
            var infoTableRecord = deserializedObject.InfoTableRows;

            foreach (var record in infoTableRecord)
            {
                Entity AvailabilityConfig = new Entity("amxperu_productofferingavailabilityconfiguratio");
                AvailabilityConfig.Attributes["amxperu_name"] = record.InfoTableCode;
                AvailabilityConfig.Attributes["amxperu_infotableid"] = new EntityReference("amxperu_infotable", infoTableId);
                AvailabilityConfig.Attributes["amxperu_infomodelid"] = new EntityReference("amxperu_infomodel", infoModelId);
                AvailabilityConfig.Attributes["amxperu_code"] = record.Code;
                AvailabilityConfig.Attributes["amxperu_cancel"] = record.Cancel;
                AvailabilityConfig.Attributes["amxperu_startdate"] = Convert.ToDateTime(deserializedObject.StartDate);

                AvailabilityConfig.Attributes["statuscode"] = new OptionSetValue(250000000); //Draft //TODO version handler...

                foreach (var item in record.Data)
                {
                    AvailabilityConfig.Attributes["amxperu_" + item.ColumnName.ToString().ToLower()] = item.ColumnValue;

                    if (item.ColumnName == "BasicPO")
                    {
                        var queryExp = new QueryExpression
                        {
                            EntityName = Product.EntityLogicalName,
                            ColumnSet = new ColumnSet(true),
                            Criteria = new FilterExpression() { Conditions = { new ConditionExpression("etel_externalid", ConditionOperator.Equal, item.ColumnValue) } }
                        };

                        var resultPO = actionContext.OrganizationService.RetrieveMultiple(queryExp);

                        if (resultPO.Entities.Count > 0)
                        {
                            AvailabilityConfig.Attributes["amxperu_productofferingid"] = new EntityReference(Product.EntityLogicalName, resultPO.Entities[0].Id);
                        }
                    }
                }

                availabilityConfigId = actionContext.OrganizationService.Create(AvailabilityConfig);

                CreateProductVersionHandler(Guid.Empty, Guid.Empty, availabilityConfigId, Guid.Empty, deserializedObject.StartDate);
            }
        }

        private Guid CreateInfoTableRowModel(InfoTables4 deserializedObject, Guid infoModelId)
        {
            Guid infoTableId = Guid.Empty;

            Entity infoTable = new Entity("amxperu_infotable");
            infoTable.Attributes["amxperu_infomodelcode"] = deserializedObject.InfoModelCode;
            infoTable.Attributes["amxperu_infotablecode"] = deserializedObject.InfoTableCode;
            infoTable.Attributes["amxperu_label"] = deserializedObject.Label;
            infoTable.Attributes["amxperu_name"] = deserializedObject.Label;
            infoTable.Attributes["amxperu_startdate"] = Convert.ToDateTime(deserializedObject.StartDate);
            infoTable.Attributes["amxperu_updatedate"] = Convert.ToDateTime(deserializedObject.UpdateDate);
            infoTable.Attributes["amxperu_createdate"] = Convert.ToDateTime(deserializedObject.CreateDate);
            infoTable.Attributes["amxperu_versioncommitdate"] = Convert.ToDateTime(deserializedObject.VersionCommitDate);
            infoTable.Attributes["amxperu_status"] = deserializedObject.Status;
            infoTable.Attributes["amxperu_createdby"] = deserializedObject.CreatedBy;
            infoTable.Attributes["amxperu_description"] = deserializedObject.Description;
            infoTable.Attributes["amxperu_updatedby"] = deserializedObject.UpdatedBy;
            infoTable.Attributes["amxperu_versionid"] = deserializedObject.VersionId;
            infoTable.Attributes["amxperu_versionid"] = deserializedObject.VersionId;
            infoTable.Attributes["amxperu_infomodelid"] = new EntityReference("amxperu_infomodel", infoModelId);

            infoTableId = actionContext.OrganizationService.Create(infoTable);

            return infoTableId;
        }

        private Guid CreateInfoTableDataModel(InfoTables5 deserializedObject, string version, Guid infoModelId, bool isAvailable, Guid previousInfoTableId)
        {
            Entity infoTable = new Entity("amxperu_infotable");
            infoTable.Attributes["amxperu_infomodelcode"] = deserializedObject.InfoModelCode;
            infoTable.Attributes["amxperu_infotablecode"] = deserializedObject.InfoTableCode;
            infoTable.Attributes["amxperu_label"] = deserializedObject.Label;
            infoTable.Attributes["amxperu_name"] = deserializedObject.Label;
            infoTable.Attributes["amxperu_startdate"] = Convert.ToDateTime(deserializedObject.StartDate);
            infoTable.Attributes["amxperu_updatedate"] = Convert.ToDateTime(deserializedObject.UpdateDate);
            infoTable.Attributes["amxperu_createdate"] = Convert.ToDateTime(deserializedObject.CreateDate);
            infoTable.Attributes["amxperu_versioncommitdate"] = Convert.ToDateTime(deserializedObject.VersionCommitDate);
            infoTable.Attributes["amxperu_status"] = deserializedObject.Status;
            infoTable.Attributes["amxperu_createdby"] = deserializedObject.CreatedBy;
            infoTable.Attributes["amxperu_updatedby"] = deserializedObject.UpdatedBy;
            infoTable.Attributes["amxperu_versionid"] = deserializedObject.VersionId;
            infoTable.Attributes["amxperu_versionid"] = deserializedObject.VersionId;
            infoTable.Attributes["amxperu_version"] = version;
            infoTable.Attributes["amxperu_infomodelid"] = new EntityReference("amxperu_infomodel", infoModelId);

            if (previousInfoTableId != Guid.Empty)
            {
                infoTable.Attributes["amxperu_previousinfotableid"] = new EntityReference("amxperu_infotable", previousInfoTableId);
            }

            if (!isAvailable)
            {
                infoTable.Attributes["statuscode"] = new OptionSetValue(250000000);
            }
            else
            {
                infoTable.Attributes["statuscode"] = new OptionSetValue(1);
            }

            var infoTableId = actionContext.OrganizationService.Create(infoTable);

            return infoTableId;
        }

        private string ExecuteECMService(string username, string password, string serviceUrl, string soapXmlText, string startDate, string soapAction)
        {
            string soapResult = string.Empty;

            HttpWebRequest request = CreateWebRequest(username, password, serviceUrl, soapAction);
            XmlDocument soapEnvelopeXml = new XmlDocument();

            string xmlText = string.Empty;

            if (!string.IsNullOrEmpty(startDate))
            {
                xmlText = soapXmlText.Replace("@startdate", "<startDate>" + startDate + "</startDate>");
            }
            else
            {
                xmlText = soapXmlText.Replace("@startdate", "");
            }

            soapEnvelopeXml.LoadXml(xmlText);

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
            }

            return soapResult;
        }

        public HttpWebRequest CreateWebRequest(string username, string password, string EcmApiUri, string header)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(EcmApiUri);
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            webRequest.Headers.Add("SOAPAction:" + header);
            webRequest.Credentials = new NetworkCredential(username, password);

            //if ((!string.IsNullOrEmpty(username)) && (!string.IsNullOrEmpty(password)))
            //{
            //    string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));
            //    webRequest.Headers.Add("Authorization", "Basic " + svcCredentials);
            //}

            return webRequest;
        }

    }
}