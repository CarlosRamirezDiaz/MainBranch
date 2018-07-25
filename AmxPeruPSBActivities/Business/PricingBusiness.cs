using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruPSBActivities.Model.OrderCapture;
using AmxPeruCommonLibrary.OptionSets;

namespace AmxPeruPSBActivities.Business
{
    public class PricingBusiness
    {
        XrmDataContextProvider ContextProvider;

        public List<Entity> RetrievePopListByOfferingId(List<Guid> offeringIds)
        {
            QueryExpression popConfigEntity = new QueryExpression();
            popConfigEntity.EntityName = "amxperu_productofferingpriceconfiguration";
            popConfigEntity.ColumnSet = new ColumnSet("amxperu_productoffering");
            popConfigEntity.Criteria = new FilterExpression
            {
                Conditions = { new ConditionExpression("amxperu_productoffering", ConditionOperator.In, offeringIds) }
            };

            LinkEntity popEntity = new LinkEntity("amxperu_productofferingpriceconfiguration", "amxperu_productofferingprice", "amxperu_productofferingpriceconfigurationid", "amxperu_popconfiguration", JoinOperator.Inner);
            popEntity.Columns = new ColumnSet("amxperu_price", "amxperu_pricetypecode", "amxperu_periodcode", "amxperu_externalid");
            popEntity.EntityAlias = "pop";
            popConfigEntity.LinkEntities.Add(popEntity);

            return ContextProvider.OrganizationService.RetrieveMultiple(popConfigEntity)?.Entities?.ToList();
        }


        public List<Guid> RetrievePopConfigIdsByEstrato(string estrato, List<Guid> offeringIds)
        {
            if (string.IsNullOrEmpty(estrato))
            {
                estrato = "3";
            }

            QueryExpression prodCharValueEntity = new QueryExpression();
            prodCharValueEntity.EntityName = etel_productcharacteristicvalue.EntityLogicalName;
            prodCharValueEntity.ColumnSet = new ColumnSet("etel_name");

            prodCharValueEntity.Criteria = new FilterExpression
            {
                FilterOperator = LogicalOperator.Or,
                Conditions = {
                                new ConditionExpression("etel_name", ConditionOperator.Equal, "All"),
                                new ConditionExpression("etel_name", ConditionOperator.Equal, estrato)
                             }
            };

            LinkEntity prodCharEntity = new LinkEntity(etel_productcharacteristicvalue.EntityLogicalName, etel_productcharacteristic.EntityLogicalName, "etel_productcharacteristicid", "etel_productcharacteristicid", JoinOperator.Inner);
            prodCharEntity.EntityAlias = etel_productcharacteristic.EntityLogicalName;
            prodCharEntity.LinkCriteria.AddCondition("etel_name", ConditionOperator.Equal, "Estrato");
            prodCharValueEntity.LinkEntities.Add(prodCharEntity);

            LinkEntity priceConfigCharValue = new LinkEntity(etel_productcharacteristicvalue.EntityLogicalName, "amxperu_priceconfiguration_charvalue", "etel_productcharacteristicvalueid", "etel_productcharacteristicvalueid", JoinOperator.Inner);
            priceConfigCharValue.EntityAlias = "popconfig_charvalue";
            priceConfigCharValue.Columns = new ColumnSet("amxperu_productofferingpriceconfigurationid");
            prodCharValueEntity.LinkEntities.Add(priceConfigCharValue);

            return ContextProvider.OrganizationService
                                            .RetrieveMultiple(prodCharValueEntity)?
                                            .Entities?
                                            .Select(p => (Guid)p.GetAttributeValue<AliasedValue>("popconfig_charvalue.amxperu_productofferingpriceconfigurationid")?.Value)
                                            .ToList();
        }


        public List<ProductOfferingItem> RetrieveOfferingsWithPrices(List<Entity> offeringList,List<Entity> popConfigList, List<Guid> charValues, string parentOfferingId)
        {
            ProductOfferingItem offeringModel;
            var offeringBusiness = new OfferingsBusiness(ContextProvider);
            var optionalOfferingList = new List<ProductOfferingItem>();

            var popList = popConfigList.Where(p => charValues.Contains((Guid)p.Attributes["amxperu_productofferingpriceconfigurationid"])).ToList();

            foreach (var offering in offeringList)
            {
                var t = new Guid(offering.Attributes.Contains("productid") ? offering.Attributes["productid"].ToString() : offering.GetAttributeValue<AliasedValue>("product.productid").Value.ToString());
                var offeringId = t;
                var existingOffering = optionalOfferingList.Where(p => p.OfferingId == offeringId.ToString()).FirstOrDefault();
                var pop = popList.Where(p=>((EntityReference)p.Attributes["amxperu_productoffering"])?.Id == offeringId).FirstOrDefault();

                var offeringType = ((OptionSetValue)offering.GetAttributeValue<AliasedValue>("product.etel_offertypecode")?.Value)?.Value;
                var subOfferingType = ((OptionSetValue)offering.GetAttributeValue<AliasedValue>("product.amxperu_offertypecode")?.Value)?.Value;
                var priceType = pop != null ? ((OptionSetValue)pop.GetAttributeValue<AliasedValue>("pop.amxperu_pricetypecode")?.Value)?.Value : 0;
                var periodType = pop != null ? ((OptionSetValue)pop.GetAttributeValue<AliasedValue>("pop.amxperu_periodcode")?.Value)?.Value : 0;
                var price = pop != null ? ((Money)pop.GetAttributeValue<AliasedValue>("pop.amxperu_price")?.Value)?.Value : 0;
                var popExternalId = pop != null ? (pop.GetAttributeValue<AliasedValue>("pop.amxperu_externalid")?.Value)?.ToString() : string.Empty;

                offeringModel = new ProductOfferingItem();
                existingOffering = optionalOfferingList.Where(p => p.OfferingId == offeringId.ToString()).FirstOrDefault();

                if (existingOffering == null)
                {
                    offeringModel.OfferingId = offeringId.ToString();
                    offeringModel.OfferingName = offering.GetAttributeValue<AliasedValue>("product.name")?.Value?.ToString();
                    offeringModel.ParentOfferingGuid = offering.GetAttributeValue<AliasedValue>("product.etel_parentofferingid")?.Value?.ToString();
                    offeringModel.ExternalId = offering.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString();
                    offeringModel.Currency = pop != null ? ((EntityReference)pop.GetAttributeValue<AliasedValue>("pop.transactioncurrencyid")?.Value)?.Name : "";
                    offeringModel.OfferingTypeCode = offeringType?.ToString();
                    offeringModel.OfferingTypeText = offeringType != null ? ((AmxPeruCommonLibrary.OptionSets.etel_offertypecode)offeringType).ToString(): "";
                    offeringModel.SubOfferingTypeCode = subOfferingType?.ToString();
                    offeringModel.SubOfferingTypeText = subOfferingType != null ? ((amxperu_offertypecode)subOfferingType).ToString() : "";
                    offeringModel.IsBasicPO = false;
                    offeringModel.Technology = offeringBusiness.FindProductTechnologyExternalId(offeringModel.OfferingId);
                    offeringModel.ParentOfferingGuid = parentOfferingId;

                    optionalOfferingList.Add(offeringModel);
                }

                if (pop != null)
                {
                    SetPrices(price, priceType, periodType, popExternalId, existingOffering ?? offeringModel);
                }

            }
            return optionalOfferingList;
        }


        private void SetPrices(decimal? price, int? priceType, int? periodType, string popExternalId, ProductOfferingItem offering)
        {
            switch (priceType)
            {
                case (int)amxperu_pricetypecode.Deposit:
                    var deposit = new Deposit();
                    deposit.Amount = price;
                    deposit.Period = (periodType != null) ? ((amxperu_periodcode)periodType).ToString() : "";
                    deposit.PopExternalId = popExternalId;
                    if (offering.Deposit == null)
                        offering.Deposit = new List<Deposit>();
                    offering.Deposit.Add(deposit);
                    break;

                case (int)amxperu_pricetypecode.OneTime:
                    var oneTime = new OneTime();
                    oneTime.Amount = price;
                    oneTime.Period = (periodType != null) ? ((amxperu_periodcode)periodType).ToString() : "";
                    oneTime.PopExternalId = popExternalId;
                    if (offering.OneTime == null)
                        offering.OneTime = new List<OneTime>();
                    offering.OneTime.Add(oneTime);
                    break;

                case (int)amxperu_pricetypecode.Recurring:
                    var recurring = new Recurring();
                    recurring.Amount = price;
                    recurring.Period = (periodType != null) ? ((amxperu_periodcode)periodType).ToString() : "";
                    recurring.PopExternalId = popExternalId;
                    if (offering.Recurring == null)
                        offering.Recurring = new List<Recurring>();
                    offering.Recurring.Add(recurring);
                    break;
                default:
                    break;
            }
        }


        public PricingBusiness()
        {

        }

        public PricingBusiness(XrmDataContextProvider contextProvider)
        {
            ContextProvider = contextProvider;
        }


    }
}
