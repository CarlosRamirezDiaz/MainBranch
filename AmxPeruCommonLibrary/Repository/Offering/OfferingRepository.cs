using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruCommonLibrary.Repository.Offering
{
    public class AmxPeruOfferingRepository : AmxPeruRepositoryBase
    {
        private const string PriceconfigurationCharvalueRelationEntityName = "amxperu_priceconfiguration_charvalue";
        private const string ProductOfferingPriceConfigurationEntityName = "amxperu_productofferingpriceconfiguration";
        private const string ProductOfferingPriceEntityName = "amxperu_productofferingprice";
        private const string ProductCharacteristicValueEntity = "etel_productcharacteristicvalue";
        private const string eventCodeExternalValue = "eventcode";

        public AmxPeruOfferingRepository() : base()
        {

        }

        public List<Entity> GetOfferingCharUses(IOrganizationService organizationService, Guid offeringId)
        {
            var resultOfferingCharUse = organizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = "amxperu_productofferingcharuse",
                ColumnSet = new ColumnSet(true),
                Criteria =
                            new FilterExpression
                            {
                                Conditions =
                                    {
                                    new ConditionExpression(
                                        "amxperu_productoffering",
                                        ConditionOperator.Equal,
                                        offeringId)
                                    }
                            }
            });

            return resultOfferingCharUse.Entities.ToList();
        }

        public EntityCollection RetrieveAdminChargeOfEventCode(IOrganizationService organizationService, string eventCode)
        {


            var OfferingEntity = "product";
            var POPEntity = "amxperu_productofferingprice";
            var POPCharValEntity = "amxperu_productofferingprice_charvalue";
            var ProdCharValEntity = "etel_productcharacteristicvalue";
            var ProdCharEntity = "etel_productcharacteristic";

            var Offering_IdColumn = "productid";
            var Offering_OfferTypeColumn = "etel_offertypecode";
            var Offering_NameColumn = "name";
            var OfferingTypeAdminCharge = 831260010;

            var POP_OfferingIdColumn = "amxperu_productofferingid";
            var POP_NameColumn = "amxperu_name";
            var POP_POPIdColumn = "amxperu_productofferingpriceid";

            var POPCharVal_POPIDColumn = "amxperu_productofferingpriceid";
            var POPCharVal_ProdCharValIdColumn = "etel_productcharacteristicvalueid";

            var ProdCharVal_ProdCharValIdColumn = "etel_productcharacteristicvalueid";
            var ProdCharVal_ProdCharIdColumn = "etel_productcharacteristicid";
            var ProdCharVal_NameColumn = "etel_name";

            var ProdChar_ProdCharIdColumn = "etel_productcharacteristicid";
            var ProdChar_ExternalIdColumn = "etel_externalid";


            //Add Product Offering Entity to Query
            QueryExpression query = new QueryExpression();
            query.EntityName = OfferingEntity;
            query.ColumnSet.Columns.Add(Offering_IdColumn);
            query.ColumnSet.Columns.Add(Offering_NameColumn);
            query.Criteria.Conditions.Add
            (
                new ConditionExpression(Offering_OfferTypeColumn, ConditionOperator.Equal, OfferingTypeAdminCharge)
            );
            //Join Product Offering Price with Offering on Offering Id                 
            query.LinkEntities.Add(new LinkEntity(OfferingEntity, POPEntity, Offering_IdColumn, POP_OfferingIdColumn,
                 JoinOperator.Inner));
            query.LinkEntities[0].Columns.AddColumn(POP_NameColumn);
            query.LinkEntities[0].Columns.AddColumn(POP_POPIdColumn);
            query.LinkEntities[0].EntityAlias = POPEntity;
            //Join Product Offering Price Char Val with Product Offering Price on Productr Offering Price Id
            query.LinkEntities[0].AddLink(POPCharValEntity,
                POP_POPIdColumn, POPCharVal_POPIDColumn, JoinOperator.Inner);
            //Join Product Char Val with Product Offering Price Char Val on Product Char Val Id
            query.LinkEntities[0].LinkEntities[0].AddLink(ProdCharValEntity,
                POPCharVal_ProdCharValIdColumn, ProdCharVal_ProdCharValIdColumn, JoinOperator.Inner);
            //Filter with external Id value of order capture.
            query.LinkEntities[0].LinkEntities[0].LinkEntities[0].LinkCriteria.Conditions.Add(
                new ConditionExpression(ProdCharVal_NameColumn, ConditionOperator.Equal, eventCode));
            //Join Prod Char with Prod Char VAl on prod char Id
            query.LinkEntities[0].LinkEntities[0].LinkEntities[0].AddLink(ProdCharEntity,
                ProdCharVal_ProdCharIdColumn, ProdChar_ProdCharIdColumn, JoinOperator.Inner);
            //Filter with prod char external Id get only the characteristics that its name is "eventcode"
            query.LinkEntities[0].LinkEntities[0].LinkEntities[0].LinkEntities[0].LinkCriteria.Conditions.Add(
                new ConditionExpression(ProdChar_ExternalIdColumn, ConditionOperator.Equal, eventCodeExternalValue));

            return organizationService.RetrieveMultiple(query);
        }

        /// <summary>
        /// returns all price configurations of an offering
        /// </summary>
        /// <param name="organizationService"></param>
        /// <param name="offeringId"></param>
        /// <returns></returns>
        public EntityCollection RetrieveAllPOPConfigurations(IOrganizationService organizationService, Guid offeringId)
        {
            var resultPriceConfigurations = organizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = ProductOfferingPriceConfigurationEntityName,
                ColumnSet = new ColumnSet(true),
                Criteria =
                        new FilterExpression
                        {
                            Conditions =
                                {
                                        new ConditionExpression(
                                            "amxperu_productoffering",
                                            ConditionOperator.Equal,
                                            offeringId)
                                }
                        }
            });

            return resultPriceConfigurations;
        }

        public EntityCollection RetrievePOPByPOPConfigurationId(IOrganizationService organizationService, List<Guid> POPConfigurationIdList)
        {
            var conditionExpression = POPConfigurationIdList.Count == 1 ?
                new ConditionExpression("amxperu_popconfiguration", ConditionOperator.Equal, POPConfigurationIdList.First()) :
                new ConditionExpression("amxperu_popconfiguration", ConditionOperator.In, POPConfigurationIdList);

            return organizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = ProductOfferingPriceEntityName,
                ColumnSet = new ColumnSet(true),
                Criteria =
                        new FilterExpression
                        {
                            Conditions = { conditionExpression }
                        }
            });

        }

        public EntityCollection RetrievePOPsByCharValueList(IOrganizationService organizationService, Guid offeringId, EntityCollection CharValueList)
        {

            var ConfigCharVal_PriceConfigurationdId = "amxperu_productofferingpriceconfigurationid";
            var Config_PriceConfigurationdId = "amxperu_productofferingpriceconfigurationid";
            var ConfigCharVal_ProdCharValIdColumn = "etel_productcharacteristicvalueid";
            var COnfig_OfferingId = "amxperu_productoffering";
            var ProdCharVal_ProdCharValIdColumn = "etel_productcharacteristicvalueid";
            var ProdCharVal_NameColumn = "etel_name";
            var ProdCharVal_ProductCharIdColumn = "etel_productcharacteristicid";


            //Add Product Offering Entity to Query
            QueryExpression query = new QueryExpression();
            query.EntityName = ProductOfferingPriceConfigurationEntityName;
            query.ColumnSet.Columns.Add(Config_PriceConfigurationdId);
            query.Criteria.Conditions.Add(new ConditionExpression(COnfig_OfferingId, ConditionOperator.Equal, offeringId));

            //Join POPConfig with Price Offering Prod Char VAl
            query.LinkEntities.Add(new LinkEntity(ProductOfferingPriceConfigurationEntityName, PriceconfigurationCharvalueRelationEntityName,
                Config_PriceConfigurationdId, ConfigCharVal_PriceConfigurationdId,
                 JoinOperator.LeftOuter));
            //Join Price Offering Prod Char VAl with Prod Char Val
            query.LinkEntities[0].AddLink(ProductCharacteristicValueEntity,
                ConfigCharVal_ProdCharValIdColumn, ProdCharVal_ProdCharValIdColumn, JoinOperator.LeftOuter);
            query.LinkEntities[0].LinkEntities[0].EntityAlias = ProductCharacteristicValueEntity;
            query.LinkEntities[0].LinkEntities[0].Columns.AddColumn(ProdCharVal_ProductCharIdColumn);
            query.LinkEntities[0].LinkEntities[0].Columns.AddColumn(ProdCharVal_NameColumn);

            var results = organizationService.RetrieveMultiple(query);

            var groupedResults = results.Entities.GroupBy(a => a.Attributes[ConfigCharVal_PriceConfigurationdId],
                (key, g) => new { PriceConfigurationdId = key, Entities = g.ToList() });

            var POPConfigurationIdList = new List<Guid>();
            foreach (var config in groupedResults)
            {
                //check all char config is available in list
                if (IsMatchingWithConfgiurationCharValues(config.Entities, CharValueList))
                {
                    POPConfigurationIdList.Add((Guid)config.PriceConfigurationdId);
                }
            }

            if (POPConfigurationIdList.Count == 0)
            {
                var offering = RetrieveById(organizationService, offeringId, Product.EntityLogicalName);
                throw new Exception(string.Format("Offering is not configured properly - Offering Name {0} External Id {1} ", offering.Attributes["name"].ToString(), offering.Attributes["etel_externalid"]));
            }

            var offeringPOPs = RetrievePOPByPOPConfigurationId(organizationService, POPConfigurationIdList);

            return offeringPOPs;
        }

        private bool IsMatchingWithConfgiurationCharValues(List<Entity> configCharValues, EntityCollection OrderItemCharValList)
        {
            //All Item should be in orderItemCharValList
            foreach (var item in configCharValues)
            {
                if (item.Attributes.Contains("etel_productcharacteristicvalue.etel_productcharacteristicid"))
                {
                    if (OrderItemCharValList.Entities != null)
                    {
                        var orderItemCharVal = OrderItemCharValList.Entities.Where(a => ((EntityReference) a.Attributes["etel_characteristicid"]).Id == ((EntityReference)(((AliasedValue)item.Attributes["etel_productcharacteristicvalue.etel_productcharacteristicid"]).Value)).Id).FirstOrDefault();
                        if (orderItemCharVal != null)
                        {
                            //check the values
                            var CharValueString = ((AliasedValue)item.Attributes["etel_productcharacteristicvalue.etel_name"]).Value.ToString();
                            //TODO : do type of list later
                            if (orderItemCharVal.Attributes.Contains("etel_value") &&
                                orderItemCharVal.Attributes["etel_value"].ToString() == CharValueString)
                            {
                                continue;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }

            }
            return true;
        }


        public EntityCollection RetrieveAdminChargePOPByEventCode(IOrganizationService organizationService, Guid AdminPOId, string eventCode)
        {
            var resultPriceConfigurations = RetrieveAllPOPConfigurations(organizationService, AdminPOId);
            List<Guid> configList = resultPriceConfigurations.Entities.Select(e => e.Id).ToList();

            var filter = new FilterExpression();
            filter.AddCondition(new ConditionExpression("amxperu_productofferingpriceconfigurationid", ConditionOperator.In, configList));
            var productCharacteristicRepository = new AmxPeruProductCharacteristicRepository();
            var charValueId = productCharacteristicRepository.RetrieveCharValueEntity(organizationService, eventCodeExternalValue, eventCode);
            List<Guid> CharValueIdList = new List<Guid>() { charValueId.Id };
            if (CharValueIdList.Count > 0)
            {
                filter.AddCondition(new ConditionExpression("etel_productcharacteristicvalueid", ConditionOperator.In, CharValueIdList));
            }
            var resultrelations = organizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = PriceconfigurationCharvalueRelationEntityName,
                ColumnSet = new ColumnSet(true),
                Criteria = filter
            });
            var foundPriceConfigId = resultrelations.Entities.Count > 0
            ? (Guid)(resultrelations.Entities[0].Attributes["amxperu_productofferingpriceconfigurationid"])
            : resultPriceConfigurations.Entities[0].Id;

            var offeringPOPs = RetrievePOPByPOPConfigurationId(organizationService, new List<Guid>() { foundPriceConfigId });

            return offeringPOPs;
        }

        public EntityCollection RetrieveAdminChargePOPByEventCode(IOrganizationService organizationService, string eventCode)
        {
            var adminCharges = RetrieveAdminChargeOfEventCode(organizationService, eventCode);
            if (adminCharges != null && adminCharges.Entities != null && adminCharges.Entities.Count > 0)
            {
                var offeringId = (Guid)adminCharges.Entities.First().Attributes["productid"];
                return RetrieveAdminChargePOPByEventCode(organizationService, offeringId, eventCode);
            }
            else
            {
                throw new Exception("Couldn't find any admin charge with given event code : " + eventCode);
            }
        }
    }
}
