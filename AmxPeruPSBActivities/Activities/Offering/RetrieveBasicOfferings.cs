using System.Activities;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.OrderCapture;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk;
using System;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.Offering
{
    public class RetrieveBasicOfferings : XrmAwareCodeActivity
    {
        public OutArgument<List<ProductOfferingItem>> BasicOfferingList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var offeringBusiness = new OfferingsBusiness(ContextProvider);

            var productEntity = new QueryExpression(Product.EntityLogicalName);
            productEntity.ColumnSet = new ColumnSet("productid", "name", "etel_offertypecode", "etel_externalid");
            productEntity.Criteria.AddCondition("etel_issellable", ConditionOperator.Equal, true);
            productEntity.Criteria.AddCondition("statecode", ConditionOperator.Equal, (int)(ProductState.Active));
            productEntity.Criteria.AddCondition("etel_offertypecode", ConditionOperator.Equal, (int)AmxPeruCommonLibrary.OptionSets.etel_offertypecode.Basic);
            productEntity.AddOrder("name", OrderType.Ascending);

            var poCharUseLink = new LinkEntity(Product.EntityLogicalName, "amxperu_productofferingcharuse", "productid", "amxperu_productoffering", JoinOperator.Inner);
            poCharUseLink.EntityAlias = "poCharUse";
            poCharUseLink.Columns = new ColumnSet("amxperu_productofferingcharuseid");
            //poCharUseLink.LinkCriteria.AddCondition("amxperu_characteristic", ConditionOperator.Equal, "");
            productEntity.LinkEntities.Add(poCharUseLink);

            var productCharacteristicLink = new LinkEntity("amxperu_productofferingcharuse", etel_productcharacteristic.EntityLogicalName, "amxperu_characteristic", "etel_productcharacteristicid", JoinOperator.Inner);
            //productCharacteristicLink.EntityAlias = "pCharacteristic";
            //productCharacteristicLink.Columns = new ColumnSet(true);
            productCharacteristicLink.LinkCriteria.AddCondition("etel_externalid", ConditionOperator.Equal, "Technology");
            poCharUseLink.LinkEntities.Add(productCharacteristicLink);

            var products = ContextProvider.OrganizationService.RetrieveMultiple(productEntity).Entities;

            var offeringList = new List<ProductOfferingItem>();
            ProductOfferingItem offering = null;

            Guid poCharUseId;
            foreach (var product in products)
            {
                poCharUseId = new Guid((product.GetAttributeValue<AliasedValue>("poCharUse.amxperu_productofferingcharuseid")?.Value)?.ToString());

                if (offeringList.Count > 0 && offeringList[offeringList.Count - 1].ExternalId == product.Attributes["etel_externalid"].ToString())
                {
                    offeringList[offeringList.Count - 1].Technology += offeringBusiness.FindProductTechnologyExternalId(poCharUseId);
                    // break;
                }
                else
                {
                    offering = new ProductOfferingItem();
                    offering.OfferingId = (product.Contains("productid")) ? product.Attributes["productid"].ToString() : string.Empty;
                    offering.OfferingName = (product.Contains("name")) ? product.Attributes["name"].ToString() : string.Empty;
                    offering.ExternalId = (product.Contains("etel_externalid")) ? product.Attributes["etel_externalid"].ToString() : string.Empty;
                    offering.OfferingTypeText = (product.Contains("etel_offertypecode")) ? product.FormattedValues["etel_offertypecode"].ToString() : string.Empty;
                    offering.OfferingTypeCode = (product.Contains("etel_offertypecode")) ? ((OptionSetValue)product.Attributes["etel_offertypecode"]).Value.ToString() : string.Empty;
                    offering.IsBasicPO = true;
                    offering.IsSelleable = true;
                    offering.Technology = offeringBusiness.FindProductTechnologyExternalId(poCharUseId);

                    if (offering.ExternalId.Contains("Int"))
                    {
                        offering.Family = "INT";
                    }
                    else if (offering.ExternalId.Contains("Tv"))
                    {
                        offering.Family = "TV";
                    }
                    else if (offering.ExternalId.Contains("Tel") && offering.ExternalId.Contains("Basic"))
                    {
                        offering.Family = "TEL";
                    }
                    else if (offering.ExternalId.Contains("Tel"))
                    {
                        offering.Family = "TEL2";
                    }
                    else if (offering.ExternalId.Contains("Mov"))
                    {
                        offering.Family = "MOV";
                    }

                    offeringList.Add(offering);
                }
            }
            BasicOfferingList.Set(context, offeringList);
        }        
    }
}
