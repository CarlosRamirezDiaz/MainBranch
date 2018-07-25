using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.Offering
{
    public class RetrievePopConfigIdsByEstrato : XrmAwareCodeActivity
    {
        public InArgument<string> Estrato { get; set; }
        public InArgument<List<Guid>> OfferingIds { get; set; }
        public OutArgument<List<Guid>> CharValues { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var estrato = Estrato.Get(context);
            var offeringIds = OfferingIds.Get(context);

            if (!string.IsNullOrWhiteSpace(estrato) && offeringIds?.Count > 0)
            {
                /*
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

                var charValues = ContextProvider.OrganizationService
                                                .RetrieveMultiple(prodCharValueEntity)?
                                                .Entities?
                                                .Select(p => (Guid)p.GetAttributeValue<AliasedValue>("popconfig_charvalue.amxperu_productofferingpriceconfigurationid")?.Value)
                                                .ToList();
                */
                var pricingBusiness = new PricingBusiness(ContextProvider);
                var charValues = pricingBusiness.RetrievePopConfigIdsByEstrato(estrato, offeringIds);
                CharValues.Set(context, charValues);
            }
        }
    }
}
