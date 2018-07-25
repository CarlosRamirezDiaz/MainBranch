using ExternalApiActivities.Common;
using System.Collections.Generic;
using System.Linq;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.Offering
{
    public class RetrievePopListByOfferingIdList : XrmAwareCodeActivity
    {
        public InArgument<List<Guid>> OfferingIds { get; set; }
        public OutArgument<List<Entity>> PopList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var offeringIds = OfferingIds.Get(context);

            if (offeringIds?.Count > 0)
            {
                /*
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

                var popList = ContextProvider.OrganizationService.RetrieveMultiple(popConfigEntity)?.Entities?.ToList();
                */

                var pricingBusiness = new PricingBusiness(ContextProvider);

                var popList = pricingBusiness.RetrievePopListByOfferingId(offeringIds);
                PopList.Set(context, popList);
            }
        }
    }
}
