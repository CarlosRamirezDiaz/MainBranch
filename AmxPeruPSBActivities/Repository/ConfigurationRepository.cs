using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;

namespace AmxPeruPSBActivities.Repository
{
    public class ConfigurationRepository
    {
        OrganizationServiceProxy _organizationService;

        public ConfigurationRepository(OrganizationServiceProxy org)
        {
            if (org == null)
                throw new System.Exception("ConfigurationRepository: OrganizationServiceProxy is null");

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
                EntityName = "etel_crmconfiguration",
                ColumnSet = new ColumnSet(new string[] { "etel_name", "etel_value" })
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_name", Microsoft.Xrm.Sdk.Query.ConditionOperator.Equal, configurationName);


            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return string.Empty;

            return collection.Entities[0].GetAttributeValue<string>("etel_value");
        }
    }

    public static class CRMConfiguration
    {
        private static Dictionary<string, object> configurationValues = new Dictionary<string, object>();

        private static ConfigurationRepository _repository = null;

        private static ConfigurationRepository configRepository(OrganizationServiceProxy org)
        {
            if (_repository == null)
                _repository = new ConfigurationRepository(org);

            return _repository;
        }

        public static string GetStringValue(string configurationName, OrganizationServiceProxy org)
        {
            configurationName = configurationName.ToLower();

            if (configurationValues.ContainsKey(configurationName))
                return configurationValues[configurationName].ToString();

            var value = configRepository(org).GetString(configurationName);

            configurationValues.Add(configurationName, value);

            return value;
        }

        public static int GetIntValue(string configurationName, OrganizationServiceProxy org)
        {
            configurationName = configurationName.ToLower();

            if (configurationValues.ContainsKey(configurationName))
                return (int)configurationValues[configurationName];

            var value = configRepository(org).GetInt(configurationName);

            configurationValues.Add(configurationName, value);

            return value;
        }
    }
}