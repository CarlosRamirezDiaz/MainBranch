using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;

namespace AmxPeruPSBActivities.Repository
{
    class AmxCoRiskConfigurationRepository
    {
        OrganizationServiceProxy _organizationService;

        public AmxCoRiskConfigurationRepository(OrganizationServiceProxy org)
        {
            if (org == null)
                throw new System.Exception("AmxCoRiskConfigurationRepository: OrganizationServiceProxy is null");

            this._organizationService = org;
        }

        public string GetString(string configurationName)
        {
            var stringValue = this.Get(configurationName);
            return stringValue;
        }

        public int GetInt(string configurationName)
        {
            var stringValue = this.Get(configurationName);
            var intValue = 0;

            int.TryParse(stringValue, out intValue);

            return intValue;
        }

        private string Get(string configurationName)
        {
            if (string.IsNullOrEmpty(configurationName))
                return string.Empty;

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "amx_riskconfiguration",
                ColumnSet = new ColumnSet(new string[] { "amx_name" })
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("amx_name", Microsoft.Xrm.Sdk.Query.ConditionOperator.Equal, configurationName);


            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return string.Empty;

            return collection.Entities[0].GetAttributeValue<string>("etel_value");
        }
    }

}
