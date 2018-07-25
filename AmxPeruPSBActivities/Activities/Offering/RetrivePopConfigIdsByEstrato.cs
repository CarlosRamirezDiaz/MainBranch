using ExternalApiActivities.Common;
using System;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;
using Microsoft.Xrm.Sdk;

namespace AmxPeruPSBActivities.Activities.Offering
{
    public class RetrivePopConfigIdsByEstrato : XrmAwareCodeActivity
    {
        public InArgument<string> Estrato { get; set; }
        public OutArgument<List<Guid>> EstratoPopConfigIds { get; set; }
        public OutArgument<List<Guid>> AllEstratoPopConfigIds { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var estrato = Estrato.Get(context);

            QueryExpression prodCharValueEntity = new QueryExpression();
            prodCharValueEntity.EntityName = etel_productcharacteristicvalue.EntityLogicalName;
            prodCharValueEntity.ColumnSet = new ColumnSet("etel_name");

            LinkEntity prodCharEntity = new LinkEntity(etel_productcharacteristicvalue.EntityLogicalName, etel_productcharacteristic.EntityLogicalName, "etel_productcharacteristicid", "etel_productcharacteristicid", JoinOperator.Inner);
            prodCharEntity.Columns = new ColumnSet("etel_name");
            prodCharEntity.EntityAlias = etel_productcharacteristic.EntityLogicalName;
            prodCharValueEntity.LinkEntities.Add(prodCharEntity);

            LinkEntity priceConfigCharValue = new LinkEntity(etel_productcharacteristicvalue.EntityLogicalName, "amxperu_priceconfiguration_charvalue", "etel_productcharacteristicvalueid", "etel_productcharacteristicvalueid", JoinOperator.Inner);
            priceConfigCharValue.Columns = new ColumnSet("amxperu_productofferingpriceconfigurationid");
            priceConfigCharValue.EntityAlias = "amxperu_priceconfiguration_charvalue";
            prodCharValueEntity.LinkEntities.Add(priceConfigCharValue);

            var popConfigEntities = ContextProvider.OrganizationService.RetrieveMultiple(prodCharValueEntity)
                                               .Entities
                                               .ToList();

            var estratoPopConfigIds = popConfigEntities.Where(p => p.Attributes["etel_name"].ToString() == estrato &&
                                                                           p.GetAttributeValue<AliasedValue>("etel_productcharacteristic.etel_name").Value.ToString() == "Estrato")
                                                               .Select(p => (Guid)p.GetAttributeValue<AliasedValue>("amxperu_priceconfiguration_charvalue.amxperu_productofferingpriceconfigurationid").Value)
                                                               .Distinct()
                                                               .ToList();

            var allEstratoPopConfigIds = popConfigEntities.Where(p => p.Attributes["etel_name"].ToString() == "All" &&
                                                                      p.GetAttributeValue<AliasedValue>("etel_productcharacteristic.etel_name").Value.ToString() == "Estrato")
                                                          .Select(p => (Guid)p.GetAttributeValue<AliasedValue>("amxperu_priceconfiguration_charvalue.amxperu_productofferingpriceconfigurationid").Value)
                                                          .Distinct()
                                                          .ToList();

            allEstratoPopConfigIds = allEstratoPopConfigIds.Except(estratoPopConfigIds)
                                                             .ToList();

            EstratoPopConfigIds.Set(context, estratoPopConfigIds);
            AllEstratoPopConfigIds.Set(context, allEstratoPopConfigIds);
        }
    }
}
