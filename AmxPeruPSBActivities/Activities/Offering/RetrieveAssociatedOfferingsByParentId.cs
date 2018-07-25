using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System.Linq;
using System.Collections.Generic;
using System;

namespace AmxPeruPSBActivities.Activities.Offering
{
    public class RetrieveAssociatedOfferingsByParentId : XrmAwareCodeActivity
    {
        public InArgument<string> ParentOfferindId { get; set; }
        public OutArgument<List<Guid>> OfferingIds { get; set; }
        public OutArgument<List<Entity>> OfferingList { get; set; }
        public OutArgument<Entity> ParentOffering { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var parentOfferindId = ParentOfferindId.Get(context);

            if (!string.IsNullOrWhiteSpace(parentOfferindId))
            {
                var parentOffering = ContextProvider.OrganizationService.Retrieve(Product.EntityLogicalName, new Guid(parentOfferindId), new ColumnSet("productid", "name", "etel_offertypecode", "amxperu_offertypecode", "etel_externalid"));
                ParentOffering.Set(context, parentOffering);

                QueryExpression offerAssociation = new QueryExpression();
                offerAssociation.EntityName = etel_offeringassociation.EntityLogicalName;
                offerAssociation.Criteria.AddCondition("etel_primaryofferingid", ConditionOperator.Equal, parentOfferindId);

                LinkEntity productEntity = new LinkEntity(etel_offeringassociation.EntityLogicalName, Product.EntityLogicalName, "etel_secondaryofferingid", "productid", JoinOperator.Inner);
                productEntity.EntityAlias = Product.EntityLogicalName;
                productEntity.Columns = new ColumnSet("productid", "name", "etel_offertypecode", "amxperu_offertypecode", "etel_parentofferingid", "etel_externalid");
                productEntity.LinkCriteria.AddCondition(new ConditionExpression("etel_offertypecode", ConditionOperator.NotEqual, (int)AmxPeruCommonLibrary.OptionSets.etel_offertypecode.Basic));
                productEntity.LinkCriteria.AddCondition(new ConditionExpression("etel_issellable", ConditionOperator.Equal, true));
                offerAssociation.LinkEntities.Add(productEntity);

                var offeringList = ContextProvider.OrganizationService.RetrieveMultiple(offerAssociation)?.Entities?.ToList();
                OfferingIds.Set(context, offeringList?.Select(p => (Guid)p.GetAttributeValue<AliasedValue>("product.productid")?.Value)?.ToList());
                OfferingList.Set(context, offeringList);
            }
        }
    }
}
