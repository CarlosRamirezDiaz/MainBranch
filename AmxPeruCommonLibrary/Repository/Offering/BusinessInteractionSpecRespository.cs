using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Ericsson.ETELCRM.CrmCachingLibrary.Caching;

namespace AmxPeruCommonLibrary.Repository.Offering
{
    public class BusinessInteractionSpecRespository : AmxPeruRepositoryBase
    {
        public const string EntityLogicalName = "etel_businessinteractionspecification";

        public EntityCollection RetrieveMultipleFromCache(
            IOrganizationService organizationSevice,
            ConditionExpression condition = null, params string[] columns)
        {
            //var businessInteractionSpecificationSet =
            //cacheManager.GetOrAdd(CacheKeyHelper.Keys.BusinessInteractionSpecificationSet, () =>
            //{
            return organizationSevice.RetrieveMultiple(new QueryExpression
            {
                EntityName = "etel_businessinteractionspecification",
                ColumnSet = new ColumnSet(true)
            });
            //});

            //return businessInteractionSpecificationSet;
        }


        public Entity RetrieveBusinessInteractionSpecWithOrderType(
            IOrganizationService organizationSevice,
            int orderTypeCode)
        {
            var businessInteractionSpecificationSet = RetrieveMultipleFromCache(organizationSevice);
            var queryResult = from spec in businessInteractionSpecificationSet.Entities
                              where spec.Attributes.ContainsKey("amxperu_ordertypecode")
                              && spec.Attributes["amxperu_ordertypecode"] != null
                              && (spec.Attributes["amxperu_ordertypecode"] as OptionSetValue).Value.Equals(orderTypeCode)
                              select spec;

            return queryResult.FirstOrDefault();
        }
    }
}
