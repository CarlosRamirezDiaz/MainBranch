using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using ExternalApiActivities.Helpers;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Rules.Eligibility
{
    public class EligibilityHandler
    {
        XrmDataContextProvider _xrmDataContextProvider;

        public EligibilityHandler(XrmDataContextProvider xrmDataContextProvider)
        {
            _xrmDataContextProvider = xrmDataContextProvider;
        }

        /// <summary>
        /// Apply rules and execute query
        /// </summary>
        /// <param name="dataContext">The action context instance.</param>
        /// <param name="queryContext">The offerin query context instance.</param>
        public List<Product> HandleEligibilityRules(XrmDataContextProvider dataContext, OfferingQueryContext queryContext)
        {
            foreach (var rule in queryContext.Rules)
            {
                rule.BuildContext(queryContext);
            }

            if (queryContext.PageSize > 0)
            {
                queryContext.Query.PageInfo = new PagingInfo
                {
                    ReturnTotalRecordCount = true,
                    Count = queryContext.PageSize,
                    PageNumber = queryContext.PageNumber
                };
            }

            
            var result = dataContext.OrganizationService.RetrieveMultiple(queryContext.Query);

            if (queryContext.PageSize > 0)
            {
                queryContext.TotalRowsCount = result.TotalRecordCount;
            }
            return result.Entities.Select(item => item.ToEntity<Product>()).ToList();
        }
    }
}
