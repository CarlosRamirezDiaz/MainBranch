using AmxPeruPSBActivities.Model;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class GetProductCharacteristics : XrmAwareCodeActivity
    {
        //In Argument for the workflow : Guid of the Order record
        public InArgument<string> OrderItemGuid { get; set; }

        //Out Argument for the workflow : this is a custom Model for output/result : Model is custom one
        public OutArgument<ProductCharacteristicsModel> prodCharModel { get; set; }

        //Implementation of the Execute abstract method
        //protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        //{
        //    //Method Variables
        //    ProductCharacteristicsModel _ProductCharacteristicsModel = null;
        //    Guid OrderItemGuid = Guid.Empty;

        //    try
        //    {
        //        //Instances of the Model/Model support classed to hold the result after CRM db query
        //        _ProductCharacteristicsModel = new ProductCharacteristicsModel();
        //        List<etel_orderitem> orderItemList = new List<etel_orderitem>();
        //        orderItem _orderItem = null;
        //        List<orderItem> listOfOrderitems = new List<orderItem>();
        //        List<Characteristics> listOfCharacteristics = null;
        //        List<CharacteristicsValue> listOfCharacteristicsValue = null;

        //        //Entity Names : newsly created entity records for Product Catalogue
        //        string prodCharUseEntityName = "amxperu_productofferingcharuse";
        //        string prodCharValueEntityName = "amxperu_productofferingcharvalueuse";

        //        //Get the Input Order Capture Guid
        //        OrderItemGuid = new Guid(context.GetValue(this.OrderItemGuid));

        //        //Get the List of Order Items from the OrderItem entity via the Supplied OrderCaptureGuid -- (No of Service Call X 1)
        //        //var queryOrderItems = from OrderItem in dataContext.etel_orderitemSet
        //        //                      where OrderItem.etel_orderid.Id == OrderItemGuid
        //        //                      select OrderItem;
        //        //orderItemList = queryOrderItems.ToList();

        //        QueryExpression _query = new QueryExpression("etel_orderitem");
        //        _query.ColumnSet = new ColumnSet(true);
        //        _query.Criteria = new FilterExpression();
        //        _query.Criteria.AddCondition("etel_orderid", ConditionOperator.Equal, OrderItemGuid.ToString());
        //        EntityCollection listOfOrderItems = ContextProvider.OrganizationService.RetrieveMultiple(_query);

        //        if (listOfOrderItems != null)
        //        {
        //            if (listOfOrderItems.Entities.Count > 0)
        //            {
        //                //Find the List of Characteristics for each of the Order Items
        //                foreach (etel_orderitem typeOrderItem in listOfOrderItems.Entities)
        //                {
        //                    //Fetch OfferingType
        //                    bool IsOfferingTypeDevice = false;
        //                    string fetchOfferingTypeCode = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>
        //                                                      <entity name='product'>
        //                                                        <attribute name='name' />
        //                                                        <attribute name='productid' />
        //                                                        <attribute name='etel_offertypecode' />
        //                                                        <order attribute='name' descending='false' />
        //                                                        <link-entity name='etel_orderitem' from='etel_offeringid' to='productid' alias='aa'>
        //                                                          <filter type='and'>
        //                                                            <condition attribute='etel_orderitemid' operator='eq' uiname='' uitype='etel_orderitem' value='{0}' />
        //                                                          </filter>
        //                                                        </link-entity>
        //                                                      </entity>
        //                                                    </fetch>";
        //                    fetchOfferingTypeCode = string.Format(fetchOfferingTypeCode, typeOrderItem.Id.ToString());
        //                    EntityCollection listOfOffering = ContextProvider.OrganizationService.RetrieveMultiple(new FetchExpression(fetchOfferingTypeCode));
        //                    if (listOfOffering != null)
        //                    {
        //                        if (listOfOffering.Entities.Count > 0)
        //                        {
        //                            IsOfferingTypeDevice = (listOfOffering.Entities[0].Attributes.Contains("etel_offertypecode")) ? 
        //                                                    ((listOfOffering.Entities[0].Attributes["etel_offertypecode"] as OptionSetValue).Value == 831260007) 
        //                                                    ? true : false : false;
        //                        }
        //                    }
        //                    //Fetch OfferingType

        //                    //Offer Code Type : Device : OptionSetValue : 831260007
        //                    if (!IsOfferingTypeDevice)
        //                    {
        //                        _orderItem = new orderItem();

        //                        //Set the Order Item Guid
        //                        _orderItem.guid = (Guid)typeOrderItem.etel_orderitemId;
        //                        _orderItem.OfferingGuid = typeOrderItem.etel_offeringid.Id;
        //                        _orderItem.name = (typeOrderItem.Attributes.Contains("etel_offeringid")) ? (typeOrderItem.Attributes["etel_offeringid"] as EntityReference).Name : string.Empty;

        //                        //Generate the Query to fetch the Product Char
        //                        QueryExpression queryProdChar = new QueryExpression(prodCharUseEntityName);
        //                        queryProdChar.ColumnSet = new ColumnSet(true);
        //                        queryProdChar.Criteria = new FilterExpression();
        //                        queryProdChar.Criteria.AddCondition("amxperu_productoffering", ConditionOperator.Equal, typeOrderItem.etel_offeringid.Id);
        //                        //Generate the Query to fetch the Product Char


        //                        string fetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
        //                                  <entity name='amxperu_productofferingcharuse'>
        //                                    <attribute name='amxperu_productofferingcharuseid' />
        //                                    <attribute name='amxperu_name' />
        //                                    <attribute name='amxperu_characteristic' />
        //                                    <attribute name='amxperu_editable' />
        //                                    <order attribute='amxperu_name' descending='false' />
        //                                    <filter type='and'>
        //                                      <condition attribute='amxperu_productoffering' operator='eq' uitype='product' value='{0}' />
        //                                    </filter>
        //                                    <link-entity name='etel_productcharacteristic' from='etel_productcharacteristicid' to='amxperu_characteristic' visible='false' link-type='outer' alias='a_join'>
        //                                      <attribute name='etel_datatype' />
        //                                    </link-entity>
        //                                  </entity>
        //                                </fetch>";
        //                        fetchXml = string.Format(fetchXml, typeOrderItem.etel_offeringid.Id.ToString());

        //                        //Get the List of Prod Characteristics for the Specific Product Offering via the Query
        //                        EntityCollection lisOfProdChar = ContextProvider.OrganizationService.RetrieveMultiple(new FetchExpression(fetchXml));
        //                        if (lisOfProdChar != null)
        //                        {
        //                            if (lisOfProdChar.Entities.Count > 0)
        //                            {
        //                                listOfCharacteristics = new List<Characteristics>();

        //                                //For Each product Characteristic available for that Offering -- (No of Service Call X No of Prod Chars)
        //                                foreach (Entity typeProdChar in lisOfProdChar.Entities)
        //                                {
        //                                    int characterDataType = (((AliasedValue)typeProdChar.Attributes["a_join.etel_datatype"]).Value as OptionSetValue).Value;

        //                                    switch (characterDataType)
        //                                    {
        //                                        case 831260003:
        //                                            //New Prod Catlog Structure

        //                                            var resultPriceConfigurations = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
        //                                            {
        //                                                EntityName = "amxperu_productofferingpriceconfiguration",
        //                                                ColumnSet = new ColumnSet(true),
        //                                                Criteria =
        //                                                       new FilterExpression
        //                                                       {
        //                                                           Conditions =
        //                                                               {
        //                                                            new ConditionExpression("amxperu_productoffering", ConditionOperator.Equal, _orderItem.OfferingGuid)
        //                                                               }
        //                                                       }
        //                                            });

        //                                            List<Guid> priceConfigList = new List<Guid>();

        //                                            foreach (var item in resultPriceConfigurations.Entities)
        //                                            {
        //                                                priceConfigList.Add(item.Id);
        //                                            }
        //                                            var resultRelationTable = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
        //                                            {
        //                                                EntityName = "amxperu_priceconfiguration_charvalue",
        //                                                ColumnSet = new ColumnSet(true),
        //                                                Criteria =
        //                                                       new FilterExpression
        //                                                       {
        //                                                           Conditions =
        //                                                               {
        //                                                            new ConditionExpression("amxperu_productofferingpriceconfigurationid",ConditionOperator.In, priceConfigList)
        //                                                               }
        //                                                       },
        //                                                LinkEntities =
        //                                        {
        //                                            new LinkEntity("amxperu_priceconfiguration_charvalue", "etel_productcharacteristicvalue", "etel_productcharacteristicvalueid", "etel_productcharacteristicvalueid", JoinOperator.Inner)
        //                                            {
        //                                                    Columns = new ColumnSet(true),
        //                                                    LinkCriteria = new FilterExpression()
        //                                                    {
        //                                                        Conditions =
        //                                                        {
        //                                                             new ConditionExpression("etel_productcharacteristicid",ConditionOperator.Equal, ((EntityReference) typeProdChar.Attributes["amxperu_characteristic"]).Id)
        //                                                        }
        //                                                    },
        //                                                    EntityAlias = "CharValue"
        //                                            }
        //                                        }
        //                                            }


        //                                            );

        //                                            string valuelist = string.Empty;

        //                                            List<Guid> valueList = new List<Guid>();

        //                                            foreach (var value in resultRelationTable.Entities)
        //                                            {
        //                                                valueList.Add(new Guid(value.Attributes["etel_productcharacteristicvalueid"].ToString()));
        //                                            }

        //                                            if (resultRelationTable.Entities.Count > 0)
        //                                            {
        //                                                var resultCharacteristicValueList = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
        //                                                {
        //                                                    EntityName = "etel_productcharacteristicvalue",
        //                                                    ColumnSet = new ColumnSet(true),
        //                                                    Criteria =
        //                                                       new FilterExpression
        //                                                       {
        //                                                           Conditions =
        //                                                               {
        //                                                            new ConditionExpression("etel_productcharacteristicvalueid",ConditionOperator.In,valueList),
        //                                                            new ConditionExpression("etel_productcharacteristicid",ConditionOperator.Equal, ((EntityReference) typeProdChar.Attributes["amxperu_characteristic"]).Id)
        //                                                               }
        //                                                       }
        //                                                });



        //                                                listOfCharacteristicsValue = new List<CharacteristicsValue>();
        //                                                foreach (Entity typeProdCharValue in resultCharacteristicValueList.Entities)
        //                                                {
        //                                                    listOfCharacteristicsValue.Add(new CharacteristicsValue() { guid = typeProdCharValue.Id, value = typeProdCharValue.Attributes["etel_name"].ToString() });
        //                                                }
        //                                                listOfCharacteristics.Add(new Characteristics()
        //                                                {
        //                                                    guid = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Id,
        //                                                    name = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Name,
        //                                                    dataType = characterDataType,
        //                                                    ProdCharValues = listOfCharacteristicsValue
        //                                                });
        //                                            }

        //                                            break;
        //                                        case 831260000:
        //                                            if (true)
        //                                            {
        //                                                listOfCharacteristics.Add(new Characteristics()
        //                                                {
        //                                                    guid = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Id,
        //                                                    name = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Name,
        //                                                    dataType = characterDataType,
        //                                                    editable = (bool)typeProdChar.Attributes["amxperu_editable"],
        //                                                    ProdCharValues = null
        //                                                });
        //                                            }
        //                                            break;

        //                                        //patch code
        //                                        //send data type of Text for Numbers and Decimal
        //                                        case 831260001:
        //                                            listOfCharacteristics.Add(new Characteristics()
        //                                            {
        //                                                guid = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Id,
        //                                                name = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Name,
        //                                                dataType = 831260000,
        //                                                editable = (bool)typeProdChar.Attributes["amxperu_editable"],
        //                                                ProdCharValues = null
        //                                            });
        //                                            break;

        //                                        case 831260005:
        //                                            listOfCharacteristics.Add(new Characteristics()
        //                                            {
        //                                                guid = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Id,
        //                                                name = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Name,
        //                                                dataType = 831260000,
        //                                                editable = (bool)typeProdChar.Attributes["amxperu_editable"],
        //                                                ProdCharValues = null
        //                                            });
        //                                            break;
        //                                    }
        //                                }

        //                                //Set the ListOfCharacters for Each OrderItems
        //                                _orderItem.listProdChar = listOfCharacteristics;
        //                            }
        //                        }


        //                        listOfOrderitems.Add(_orderItem);
        //                    }

        //                }
        //            }
        //        }

        //        //Set the List of Guid Item to Prod Characteristics Model to Return
        //        _ProductCharacteristicsModel.listOrderItems = listOfOrderitems;

        //        context.SetValue(prodCharModel, _ProductCharacteristicsModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //New Code
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            //Method Variables
            ProductCharacteristicsModel _ProductCharacteristicsModel = null;
            Guid OrderItemGuid = Guid.Empty;

            try
            {
                //Instances of the Model/Model support classed to hold the result after CRM db query
                _ProductCharacteristicsModel = new ProductCharacteristicsModel();
                List<etel_orderitem> orderItemList = new List<etel_orderitem>();
                orderItem _orderItem = null;
                List<orderItem> listOfOrderitems = new List<orderItem>();
                List<Characteristics> listOfCharacteristics = null;

                //Get the Input Order Capture Guid
                OrderItemGuid = new Guid(context.GetValue(this.OrderItemGuid));

                //Get the List of Order Items from the OrderItem entity via the Supplied OrderCaptureGuid -- (No of Service Call X 1)
                //var queryOrderItems = from OrderItem in dataContext.etel_orderitemSet
                //                      where OrderItem.etel_orderid.Id == OrderItemGuid
                //                      select OrderItem;
                //orderItemList = queryOrderItems.ToList();

                QueryExpression _query = new QueryExpression("etel_orderitem");
                _query.ColumnSet = new ColumnSet(true);
                _query.Criteria = new FilterExpression();
                _query.Criteria.AddCondition("etel_orderid", ConditionOperator.Equal, OrderItemGuid.ToString());
                EntityCollection listOfOrderItems = ContextProvider.OrganizationService.RetrieveMultiple(_query);

                if (listOfOrderItems != null)
                {
                    if (listOfOrderItems.Entities.Count > 0)
                    {
                        //Find the List of Characteristics for each of the Order Items
                        foreach (etel_orderitem typeOrderItem in listOfOrderItems.Entities)
                        {
                            //Fetch OfferingType
                            bool IsOfferingTypeDevice = false;
                            string fetchOfferingTypeCode = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>
                                                              <entity name='product'>
                                                                <attribute name='name' />
                                                                <attribute name='productid' />
                                                                <attribute name='etel_offertypecode' />
                                                                <order attribute='name' descending='false' />
                                                                <link-entity name='etel_orderitem' from='etel_offeringid' to='productid' alias='aa'>
                                                                  <filter type='and'>
                                                                    <condition attribute='etel_orderitemid' operator='eq' uiname='' uitype='etel_orderitem' value='{0}' />
                                                                  </filter>
                                                                </link-entity>
                                                              </entity>
                                                            </fetch>";
                            fetchOfferingTypeCode = string.Format(fetchOfferingTypeCode, typeOrderItem.Id.ToString());
                            EntityCollection listOfOffering = ContextProvider.OrganizationService.RetrieveMultiple(new FetchExpression(fetchOfferingTypeCode));
                            if (listOfOffering != null)
                            {
                                if (listOfOffering.Entities.Count > 0)
                                {
                                    IsOfferingTypeDevice = (listOfOffering.Entities[0].Attributes.Contains("etel_offertypecode")) ?
                                                            ((listOfOffering.Entities[0].Attributes["etel_offertypecode"] as OptionSetValue).Value == 831260007)
                                                            ? true : false : false;
                                }
                            }
                            //Fetch OfferingType

                            //Offer Code Type : Device : OptionSetValue : 831260007
                            //if (!IsOfferingTypeDevice)
                            //{
                            _orderItem = new orderItem();

                            //Set the Order Item Guid
                            _orderItem.guid = (Guid)typeOrderItem.etel_orderitemId;
                            _orderItem.OfferingGuid = typeOrderItem.etel_offeringid.Id;
                            _orderItem.name = (typeOrderItem.Attributes.Contains("etel_offeringid")) ? (typeOrderItem.Attributes["etel_offeringid"] as EntityReference).Name : string.Empty;

                            //Generate the Query to fetch the Product Char
                            QueryExpression queryProdChar = new QueryExpression("amxperu_productofferingcharuse");
                            queryProdChar.ColumnSet = new ColumnSet(true);
                            queryProdChar.Criteria = new FilterExpression();
                            queryProdChar.Criteria.AddCondition("amxperu_productoffering", ConditionOperator.Equal, typeOrderItem.etel_offeringid.Id);
                            //Generate the Query to fetch the Product Char

                            string fetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                          <entity name='amxperu_productofferingcharuse'>
                                            <attribute name='amxperu_productofferingcharuseid' />
                                            <attribute name='amxperu_name' />
                                            <attribute name='amxperu_characteristic' />
                                            <attribute name='amxperu_editable' />
                                            <attribute name='amxperu_defaultvalue' />
                                            <order attribute='amxperu_name' descending='false' />
                                            <filter type='and'>
                                              <condition attribute='amxperu_productoffering' operator='eq' uitype='product' value='{0}' />
                                            </filter>
                                            <link-entity name='etel_productcharacteristic' from='etel_productcharacteristicid' to='amxperu_characteristic' visible='false' link-type='outer' alias='a_join'>
                                              <attribute name='etel_datatype' />
                                            </link-entity>
                                          </entity>
                                        </fetch>";
                            fetchXml = string.Format(fetchXml, typeOrderItem.etel_offeringid.Id.ToString());

                            listOfCharacteristics = new List<Characteristics>();

                            //Get the List of Prod Characteristics for the Specific Product Offering
                            EntityCollection lisOfProdChar = ContextProvider.OrganizationService.RetrieveMultiple(new FetchExpression(fetchXml));
                            //Get the Characteristics of the Offering
                            SetCharacteristicsValue(ref listOfCharacteristics, lisOfProdChar, _orderItem);

                            //Get CFSS Characteristics
                            SetCharacteristicsValueForCFSS(ref listOfCharacteristics, _orderItem.OfferingGuid);

                            //Get CFSS Characteristics

                            //Set the ListOfCharacters for Each OrderItems
                            _orderItem.listProdChar = listOfCharacteristics;

                            listOfOrderitems.Add(_orderItem);
                            //}
                        }
                    }
                }

                //Set the List of Guid Item to Prod Characteristics Model to Return
                _ProductCharacteristicsModel.listOrderItems = listOfOrderitems;

                //Testcode to Generate Payload for UpdateShoppingCart activity
                string productCharResponseModelJson = Newtonsoft.Json.JsonConvert.SerializeObject(_ProductCharacteristicsModel);
                //Testcode to Generate Payload for UpdateShoppingCart activity

                context.SetValue(prodCharModel, _ProductCharacteristicsModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetCharacteristicsValueForCFSS(ref List<Characteristics> listOfCharacteristics, Guid OfferingGuid)
        {
            try
            {
                //Get OfferingSpecGuid
                Guid productSpecGuid = Guid.Empty;
                string fetchXmlProductSpec = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                  <entity name='product'>
                                                    <attribute name='name' />
                                                    <attribute name='productid' />
                                                    <attribute name='etel_productspecificationid' />
                                                    <order attribute='name' descending='false' />
                                                    <filter type='and'>
                                                      <condition attribute='productid' operator='eq' value='{0}' />
                                                    </filter>
                                                  </entity>
                                                </fetch>";
                fetchXmlProductSpec = string.Format(fetchXmlProductSpec, OfferingGuid);
                EntityCollection OfferingCollection = ContextProvider.OrganizationService.RetrieveMultiple(new FetchExpression(fetchXmlProductSpec));
                if (OfferingCollection != null)
                {
                    if (OfferingCollection.Entities.Count > 0)
                    {
                        productSpecGuid = (OfferingCollection.Entities[0].Attributes.Contains("etel_productspecificationid")) ? ((EntityReference)OfferingCollection.Entities[0].Attributes["etel_productspecificationid"]).Id : Guid.Empty;
                    }
                }

                if (productSpecGuid != Guid.Empty)
                {
                    List<Guid> listOgCFSSGuids = new List<Guid>();

                    QueryExpression queryIntersect = new QueryExpression("amxperu_cfss_etel_productspecification");
                    queryIntersect.ColumnSet = new ColumnSet(true);
                    queryIntersect.Criteria.AddCondition("etel_productspecificationid", ConditionOperator.Equal, productSpecGuid);
                    EntityCollection cfssListForProdSpec = ContextProvider.OrganizationService.RetrieveMultiple(queryIntersect);
                    if (cfssListForProdSpec != null)
                    {
                        if (cfssListForProdSpec.Entities.Count > 0)
                        {
                            foreach (Entity item in cfssListForProdSpec.Entities)
                            {
                                listOgCFSSGuids.Add((Guid)item.Attributes["amxperu_cfssid"]);
                            }
                        }
                    }

                    foreach (Guid item in listOgCFSSGuids)
                    {
                        string fetchXmlCFSSCharacteristics = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                                              <entity name='amxperu_cfsscharuse'>
                                                                                <attribute name='amxperu_cfsscharuseid' />
                                                                                <attribute name='amxperu_name' />
                                                                                <attribute name='amxperu_editable' />
                                                                                <attribute name='amxperu_characteristicid' />
                                                                                <attribute name='amxperu_defaultvalue' />
                                                                                <order attribute='amxperu_name' descending='false' />
                                                                                <filter type='and'>
                                                                                  <condition attribute='amxperu_cfssid' operator='eq' value='{0}' />
                                                                                </filter>
                                                                                <link-entity name='etel_productcharacteristic' from='etel_productcharacteristicid' to='amxperu_characteristicid' visible='false' link-type='outer' alias='a_join'>
                                                                                  <attribute name='etel_datatype' />
                                                                                </link-entity>
                                                                              </entity>
                                                                            </fetch>";
                        fetchXmlCFSSCharacteristics = string.Format(fetchXmlCFSSCharacteristics, item.ToString());
                        EntityCollection cfssCharacteristicCollection = ContextProvider.OrganizationService.RetrieveMultiple(new FetchExpression(fetchXmlCFSSCharacteristics));
                        if (cfssCharacteristicCollection != null)
                        {
                            if (cfssCharacteristicCollection.Entities.Count > 0)
                            {

                                foreach (Entity cfssProdChar in cfssCharacteristicCollection.Entities)
                                {
                                    //TODO:Coding for ComboBox type Characteristics for CFSS

                                    int cfssDataType = (((AliasedValue)cfssProdChar.Attributes["a_join.etel_datatype"]).Value as OptionSetValue).Value;
                                    switch (cfssDataType)
                                    {
                                        case 831260003:
                                            listOfCharacteristics.Add(new Characteristics()
                                            {
                                                dataType = cfssDataType,
                                                editable = (bool)cfssProdChar.Attributes["amxperu_editable"],
                                                guid = cfssProdChar.Id,
                                                guidOfProdChar = ((EntityReference)cfssProdChar.Attributes["amxperu_characteristicid"]).Id,
                                                //inputValue = (cfssProdChar.Attributes.Contains("amxperu_defaultvalue")) ? cfssProdChar.Attributes["amxperu_defaultvalue"].ToString() : string.Empty,
                                                name = (cfssProdChar.Attributes.Contains("amxperu_name")) ? cfssProdChar.Attributes["amxperu_name"].ToString() : string.Empty,
                                                ProdCharValues = null,
                                                type = "cfss"
                                            });
                                            break;
                                        case 831260000:
                                        case 831260001:
                                        case 831260005:
                                            listOfCharacteristics.Add(new Characteristics()
                                            {
                                                dataType = 831260000,
                                                editable = (bool)cfssProdChar.Attributes["amxperu_editable"],
                                                guid = cfssProdChar.Id,
                                                guidOfProdChar = ((EntityReference)cfssProdChar.Attributes["amxperu_characteristicid"]).Id,
                                                //inputValue = (cfssProdChar.Attributes.Contains("amxperu_defaultvalue")) ? cfssProdChar.Attributes["amxperu_defaultvalue"].ToString() : string.Empty,
                                                name = (cfssProdChar.Attributes.Contains("amxperu_name")) ? cfssProdChar.Attributes["amxperu_name"].ToString() : string.Empty,
                                                ProdCharValues = null,
                                                type = "cfss"
                                            });
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetCharacteristicsValue(ref List<Characteristics> listOfCharacteristics, EntityCollection lisOfProdChar, orderItem _orderItem)
        {
            List<CharacteristicsValue> listOfCharacteristicsValue = null;

            try
            {
                if (lisOfProdChar != null)
                {
                    if (lisOfProdChar.Entities.Count > 0)
                    {
                        //For Each product Characteristic available for that Offering -- (No of Service Call X No of Prod Chars)
                        foreach (Entity typeProdChar in lisOfProdChar.Entities)
                        {
                            var resultPriceConfigurations = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                            {
                                EntityName = "amxperu_productofferingpriceconfiguration",
                                ColumnSet = new ColumnSet(true),
                                Criteria =
                                               new FilterExpression
                                               {
                                                   Conditions = { new ConditionExpression("amxperu_productoffering", ConditionOperator.Equal, _orderItem.OfferingGuid) }
                                               }
                            });

                            List<Guid> priceConfigList = new List<Guid>();

                            foreach (var item in resultPriceConfigurations.Entities)
                            {
                                priceConfigList.Add(item.Id);
                            }
                            var resultRelationTable = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                            {
                                EntityName = "amxperu_priceconfiguration_charvalue",
                                ColumnSet = new ColumnSet(true),
                                Criteria =
                                       new FilterExpression
                                       {
                                           Conditions =
                                               {
                                                    new ConditionExpression("amxperu_productofferingpriceconfigurationid",ConditionOperator.In, priceConfigList)
                                               }
                                       },
                                LinkEntities =
                                                {
                                                    new LinkEntity("amxperu_priceconfiguration_charvalue", "etel_productcharacteristicvalue", "etel_productcharacteristicvalueid", "etel_productcharacteristicvalueid", JoinOperator.Inner)
                                                    {
                                                            Columns = new ColumnSet(true),
                                                            LinkCriteria = new FilterExpression()
                                                            {
                                                                Conditions =
                                                                {
                                                                     new ConditionExpression("etel_productcharacteristicid",ConditionOperator.Equal, ((EntityReference) typeProdChar.Attributes["amxperu_characteristic"]).Id)
                                                                }
                                                            },
                                                            EntityAlias = "CharValue"
                                                    }
                                                }
                            }
                            );

                            string valuelist = string.Empty;
                            List<Guid> valueList = new List<Guid>();
                            foreach (var value in resultRelationTable.Entities)
                            {
                                valueList.Add(new Guid(value.Attributes["etel_productcharacteristicvalueid"].ToString()));
                            }

                            if (resultRelationTable.Entities.Count > 0)
                            {
                                var resultCharacteristicValueList = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                                {
                                    EntityName = "etel_productcharacteristicvalue",
                                    ColumnSet = new ColumnSet(true),
                                    Criteria =
                                       new FilterExpression
                                       {
                                           Conditions =
                                               {
                                                    new ConditionExpression("etel_productcharacteristicvalueid",ConditionOperator.In,valueList),
                                                    new ConditionExpression("etel_productcharacteristicid",ConditionOperator.Equal, ((EntityReference) typeProdChar.Attributes["amxperu_characteristic"]).Id)
                                               }
                                       }
                                });

                                listOfCharacteristicsValue = new List<CharacteristicsValue>();
                                foreach (Entity typeProdCharValue in resultCharacteristicValueList.Entities)
                                {
                                    listOfCharacteristicsValue.Add(new CharacteristicsValue() { guid = typeProdCharValue.Id, value = typeProdCharValue.Attributes["etel_name"].ToString() });
                                }
                            }

                            int characterDataType = (((AliasedValue)typeProdChar.Attributes["a_join.etel_datatype"]).Value as OptionSetValue).Value;

                            switch (characterDataType)
                            {
                                //TODO: PatchCode -- needs to be updated - Work In Progress
                                case 831260003:
                                    listOfCharacteristics.Add(new Characteristics()
                                    {
                                        guid = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Id,
                                        guidOfProdChar = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Id,
                                        name = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Name,
                                        dataType = characterDataType,
                                        //editable = (bool)typeProdChar.Attributes["amxperu_editable"],
                                        ProdCharValues = listOfCharacteristicsValue,
                                        type = "notcfss"
                                    });
                                    break;
                                case 831260000:
                                case 831260001:
                                case 831260005:
                                    listOfCharacteristics.Add(new Characteristics()
                                    {
                                        guid = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Id,
                                        guidOfProdChar = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Id,
                                        name = ((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Name,
                                        dataType = 831260000,
                                        editable = (bool)typeProdChar.Attributes["amxperu_editable"],
                                        ProdCharValues = listOfCharacteristicsValue,
                                        inputValue = (typeProdChar.Attributes.Contains("amxperu_defaultvalue")) ? typeProdChar.Attributes["amxperu_defaultvalue"].ToString() : string.Empty,
                                        type = "notcfss"
                                    });
                                    break;
                                    //TODO: PatchCode -- needs to be updated - Work In Progress
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}