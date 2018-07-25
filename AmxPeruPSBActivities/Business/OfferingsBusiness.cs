using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Repository;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    public class OfferingsBusiness
    {
        XrmDataContextProvider ContextProvider;

        public OfferingsBusiness()
        {

        }

        public OfferingsBusiness(XrmDataContextProvider contextProvider)
        {
            ContextProvider = contextProvider;
        }

        public string FindProductTechnologyExternalId(Guid poCharUseId)
        {
            var poCharValuesQueryExp = new QueryExpression("amxperu_productofferingcharvalueuse");
            poCharValuesQueryExp.ColumnSet = new ColumnSet("amxperu_value");
            poCharValuesQueryExp.Criteria.AddCondition("amxperu_productofferingcharuse", ConditionOperator.Equal, poCharUseId);

            var poCharsInUseList = ContextProvider.OrganizationService.RetrieveMultiple(poCharValuesQueryExp).Entities;

            if (poCharsInUseList != null && poCharsInUseList.Count > 0)
            {
                var techValue = poCharsInUseList[0].Contains("amxperu_value") ? (poCharsInUseList[0].FormattedValues["amxperu_value"]).ToString() : "";
                var prCharValuesQueryExp = new QueryExpression(etel_productcharacteristicvalue.EntityLogicalName);
                prCharValuesQueryExp.ColumnSet = new ColumnSet("etel_externalid");
                prCharValuesQueryExp.Criteria.AddCondition("etel_name", ConditionOperator.Equal, techValue);
                var prCharsInUseList = ContextProvider.OrganizationService.RetrieveMultiple(prCharValuesQueryExp).Entities;
                return prCharsInUseList[0].Attributes["etel_externalid"].ToString() + ";";
            }

            return String.Empty;
        }

        public string FindProductTechnologyExternalId(string offeringId)
        {
            var poCharUseId = FindProductCharacteristicUseId(offeringId, "Technology");

            if (!string.IsNullOrEmpty(poCharUseId))
            {
                return FindProductTechnologyExternalId(new Guid(poCharUseId));
            }

            return string.Empty;
        }

        public string FindProductCharacteristicUseId(string offeringId, string productCharacteristic)
        {
            var poCharUseQueryExpression = new QueryExpression("amxperu_productofferingcharuse");
            poCharUseQueryExpression.ColumnSet = new ColumnSet("amxperu_productofferingcharuseid");
            poCharUseQueryExpression.Criteria.AddCondition("amxperu_productoffering", ConditionOperator.Equal, new Guid(offeringId));

            var productCharacteristicLink = new LinkEntity("amxperu_productofferingcharuse", etel_productcharacteristic.EntityLogicalName, "amxperu_characteristic", "etel_productcharacteristicid", JoinOperator.Inner);
            productCharacteristicLink.LinkCriteria.AddCondition("etel_externalid", ConditionOperator.Equal, productCharacteristic);
            poCharUseQueryExpression.LinkEntities.Add(productCharacteristicLink);

            var poChars = ContextProvider.OrganizationService.RetrieveMultiple(poCharUseQueryExpression)?.Entities?.FirstOrDefault();

            if (poChars != null && poChars.Contains("amxperu_productofferingcharuseid"))
            {
                var poCharUseId = poChars.Attributes["amxperu_productofferingcharuseid"].ToString();
                return poCharUseId;
            }

            return string.Empty;
        }

        public string FindServiceIdOfProduct(string offeringId)
        {
            var poCharUseQueryExpression = new QueryExpression("amxperu_productofferingcharuse");
            poCharUseQueryExpression.ColumnSet = new ColumnSet("amxperu_defaultvalue");
            poCharUseQueryExpression.Criteria.AddCondition("amxperu_productoffering", ConditionOperator.Equal, new Guid(offeringId));
            poCharUseQueryExpression.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, "Service Id");

            var poChars = ContextProvider.OrganizationService.RetrieveMultiple(poCharUseQueryExpression)?.Entities?.FirstOrDefault();

            if (poChars != null && poChars.Contains("amxperu_defaultvalue"))
            {
                var serviceId = poChars.Attributes["amxperu_defaultvalue"].ToString();
                return serviceId;
            }

            return string.Empty;
        }

        public List<Entity> RetrieveInfoTableRecordsByInfoTableName(string infoTableName)
        {
            QueryExpression infoTable = new QueryExpression();
            infoTable.EntityName = "amxperu_infotable";
            infoTable.Criteria.Conditions.Add(new ConditionExpression("amxperu_infotablecode", ConditionOperator.Equal, infoTableName));

            LinkEntity infoTableAttribute = new LinkEntity("amxperu_infotable", "amxperu_infotablerecord", "amxperu_infotableid", "amxperu_infotableid", JoinOperator.Inner);
            infoTableAttribute.EntityAlias = "amxperu_infotablerecord";
            infoTableAttribute.Columns = new ColumnSet("amxperu_columns", "amxperu_name");
            infoTable.LinkEntities.Add(infoTableAttribute);
            var infoTableResult = ContextProvider.OrganizationService.RetrieveMultiple(infoTable)?.Entities?.ToList();

            return infoTableResult;
        }

        public List<Characteristics> GetProductCharacteristics(Guid offeringGuid)
        {
            var listChar = new List<Characteristics>();

            //Method Variables
            ProductCharacteristicsModel _ProductCharacteristicsModel = null;

            //Instances of the Model/Model support classed to hold the result after CRM db query
            _ProductCharacteristicsModel = new ProductCharacteristicsModel();
            List<etel_orderitem> orderItemList = new List<etel_orderitem>();
            orderItem _orderItem = null;
            List<orderItem> listOfOrderitems = new List<orderItem>();
            List<Characteristics> listOfCharacteristics = null;




            //Generate the Query to fetch the Product Char
            QueryExpression queryProdChar = new QueryExpression("amxperu_productofferingcharuse");
            queryProdChar.ColumnSet = new ColumnSet(true);
            queryProdChar.Criteria = new FilterExpression();
            queryProdChar.Criteria.AddCondition("amxperu_productoffering", ConditionOperator.Equal, offeringGuid);
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
            fetchXml = string.Format(fetchXml, offeringGuid.ToString());

            listOfCharacteristics = new List<Characteristics>();

            //Get the List of Prod Characteristics for the Specific Product Offering
            EntityCollection lisOfProdChar = ContextProvider.OrganizationService.RetrieveMultiple(new FetchExpression(fetchXml));
            //Get the Characteristics of the Offering
            SetCharacteristicsValue(ref listOfCharacteristics, lisOfProdChar, offeringGuid);

            //Get CFSS Characteristics
            SetCharacteristicsValueForCFSS(ref listOfCharacteristics, offeringGuid);

            return listOfCharacteristics;
        }

        private void SetCharacteristicsValue(ref List<Characteristics> listOfCharacteristics, EntityCollection lisOfProdChar, Guid offeringGuid)
        {
            try
            {
                if (lisOfProdChar != null)
                {
                    if (lisOfProdChar.Entities.Count > 0)
                    {
                        //For Each product Characteristic available for that Offering -- (No of Service Call X No of Prod Chars)
                        foreach (Entity typeProdChar in lisOfProdChar.Entities)
                        {
                            List<CharacteristicsValue> listOfCharacteristicsValue = new List<CharacteristicsValue>();

                            var charValueList = (new OfferingRepository(ContextProvider.OrganizationService)).GetProductOfferCharValueUsesFromOfferCharUse(typeProdChar.Id);

                            listOfCharacteristicsValue.AddRange(charValueList);

                            // Getting the charcteristic values and adding to list
                            int characterDataType = (((AliasedValue)typeProdChar.Attributes["a_join.etel_datatype"]).Value as OptionSetValue).Value;

                            // Get characteristic external id
                            var characterExternalId = (new AmxPeruPSBActivities.Repository.OfferingRepository(ContextProvider.OrganizationService)).GetProductCharacteristic(((EntityReference)typeProdChar.Attributes["amxperu_characteristic"]).Id).etel_externalid;

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
                                        type = "notcfss",
                                        etel_externalid = characterExternalId
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
                                        type = "notcfss",
                                        etel_externalid = characterExternalId
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
    }
}