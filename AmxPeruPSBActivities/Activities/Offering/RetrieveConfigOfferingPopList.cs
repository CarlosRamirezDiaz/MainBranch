using ExternalApiActivities.Common;
using System;
using Microsoft.Xrm.Sdk;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;

namespace AmxPeruPSBActivities.Activities.Offering
{
    public class RetrieveConfigOfferingPopList : XrmAwareCodeActivity
    {
        public InArgument<string> ParentOfferingId { get; set; }
        public InArgument<List<Entity>> AssociatedOfferings { get; set; }
        public OutArgument<List<Entity>> ConfigOfferingPopList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var parentOfferingId = ParentOfferingId.Get(context);
            var associatedOfferings = AssociatedOfferings.Get(context);

            QueryExpression popConfigEntity = new QueryExpression();
            popConfigEntity.EntityName = "amxperu_productofferingpriceconfiguration";
            popConfigEntity.ColumnSet = new ColumnSet("amxperu_productofferingpriceconfigurationid");

            LinkEntity productEntity = new LinkEntity("amxperu_productofferingpriceconfiguration", Product.EntityLogicalName, "amxperu_productoffering", "productid", JoinOperator.Inner);
            productEntity.Columns = new ColumnSet("productid", "name", "etel_offertypecode", "amxperu_offertypecode", "etel_parentofferingid");
            productEntity.LinkCriteria.AddCondition(new ConditionExpression("etel_offertypecode", ConditionOperator.NotEqual, (int)AmxPeruCommonLibrary.OptionSets.etel_offertypecode.Basic));
            productEntity.LinkCriteria.AddCondition(new ConditionExpression("etel_issellable", ConditionOperator.Equal, true));
            productEntity.EntityAlias = Product.EntityLogicalName;
            popConfigEntity.LinkEntities.Add(productEntity);

            LinkEntity popEntity = new LinkEntity(Product.EntityLogicalName, "amxperu_productofferingprice", "productid", "amxperu_productofferingid", JoinOperator.Inner);
            popEntity.Columns = new ColumnSet("amxperu_price", "amxperu_pricetypecode", "amxperu_periodcode", "amxperu_popconfiguration");
            popEntity.EntityAlias = "amxperu_productofferingprice";
            productEntity.LinkEntities.Add(popEntity);

            var offeringList = ContextProvider.OrganizationService.RetrieveMultiple(popConfigEntity)?.Entities?.ToList();

            var associatedOfferingIds = associatedOfferings?.Where(a => ((EntityReference)(a.Attributes["etel_primaryofferingid"])).Id == Guid.Parse(parentOfferingId) &&
                                                                                           a.Contains("etel_secondaryofferingid"))
                                                            .Select(a => ((EntityReference)(a.Attributes["etel_secondaryofferingid"])).Id).Distinct();

            var configOfferingPopList = offeringList?.Where(p => associatedOfferingIds.Contains((Guid)p.GetAttributeValue<AliasedValue>("product.productid")?.Value)).ToList();

            ConfigOfferingPopList.Set(context, configOfferingPopList);
        }
    }
}
