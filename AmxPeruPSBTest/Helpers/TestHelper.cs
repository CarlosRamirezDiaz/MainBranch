using Ericsson.ETELCRM.CrmCachingLibrary.Caching;
using Ericsson.PSB.Workflow.Client.Core;
using ExternalApiActivities.Activities.Customer.CustomerValidation;
using ExternalApiActivities.Helpers;
using System;
using System.Activities;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Client;
using System.ServiceModel.Description;

namespace AmxPeruTest.Helpers
{
    class TestHelper
    {
        public struct ConfigurationHelper
        {
            public const string URL = "http://100.126.0.19/TCRMDEV/XRMServices/2011/Organization.svc;COMCEL;vsunittest;Ericsson2017";//100.126.0.19

            public const string CRMDEVURL = "http://100.126.0.19/TCRMDEV/XRMServices/2011/Organization.svc;COMCEL;srikanth;Wipro2018*";//100.126.0.19

            public const string TCRMCATALOGURL = "http://100.126.0.19/TCRMDEVCATALOG/XRMServices/2011/Organization.svc;COMCEL;eemrsek;Ericsson2017";

            public const string BIL_Webservice_URL = "https://136.225.7.31:8843/BILWebServices/CustomerServices?wsdl";

            public const string BIL_FinancialTransaction_URL = "https://136.225.7.31:8843/BILWebServices/FinancialTransactionSearchService?wsdl";

            public const string BIL_BusinessInteractionSearch_URL = "https://136.225.7.31:8843/BILWebServices/BusinessInteractionSearchService?wsdl";

            public const string BIL_Contract_Search_Url = "https://136.225.7.31:8843/BILWebServices/ContractSearchService?wsdl";

            public const string BIL_Rest_BaseUrl = "http://136.225.7.31:8480/BILWebServices/rs/";

            public const string BIL_Contract_Url = "https://136.225.7.31:8843/BILWebServices/ContractServices?wsdl";

            public const string BIL_BusinessInteraction_URL = "https://136.225.7.31:8843/BILWebServices/BusinessInteractionServices?wsdl";

            public const string CERTIFICATECNVALUE = "CN=Ericsson Telco CRM BIL, OU=Ericsson, O=Ericsson, L=Istanbul, S=Istanbul, C=TR";
        }

        internal static class OrganizationProxy
        {
            public static OrganizationServiceProxy GetOrganizationProxy()
            {
                var parameters = ConfigurationHelper.URL.Split(';');

                Uri oUri = new Uri(parameters[0]);
                //** Your client credentials 
                ClientCredentials clientCredentials = new ClientCredentials();
                clientCredentials.UserName.UserName = parameters[1] + @"\" + parameters[2];
                clientCredentials.UserName.Password = parameters[3];

                //Create your Organization Service Proxy
                OrganizationServiceProxy _serviceProxy = new OrganizationServiceProxy(oUri, null, clientCredentials, null);

                return _serviceProxy;
            }
        }

        internal static class WorkflowHelper
        {
            public static WorkflowHelper<TWorkflowType> PrepareFor<TWorkflowType>(Dictionary<string, object> input = null)
                where TWorkflowType : Activity, new()
            {
                return new WorkflowHelper<TWorkflowType>(new TWorkflowType(), input);
            }
        }

        internal sealed class CacheSettings : IDistributedCacheSettings
        {
            public string OrganizationName { get; private set; } = "TCRMDEV";
            public int RedisDatabaseId { get; private set; }
            public int RedisMaxRetries { get; private set; }
            public string RedisPassword { get; private set; }
            public int RedisPort { get; private set; }
            public int RedisRetryTimeout { get; private set; }
            public string RedisUrl { get; private set; }
        }

        internal class PersonalContext : IIdentity
        {
            public string AuthenticationType
            {
                get
                {
                    return "";
                }
            }

            public bool IsAuthenticated
            {
                get
                {
                    return true;
                }
            }

            public string Name
            {
                get
                {
                    return "COMCEL\\eheldma";
                }
            }
        }

        internal class WorkflowHelper<TWorkflowType>
                where TWorkflowType : Activity, new()
        {
            private readonly WorkflowInvoker _invoker;
            private readonly Dictionary<string, object> _input;
            private readonly ConcurrentDictionary<string, string> _configuration;

            public WorkflowHelper(Activity workflow, Dictionary<string, object> input = null)
            {
                _invoker = new WorkflowInvoker(workflow);
                _input = input ?? new Dictionary<string, object>();
                _configuration = new ConcurrentDictionary<string, string>();
                _invoker.Extensions.Add(new ConfigurationExtension(_configuration));
                _invoker.Extensions.Add(new UserIdentityExtension(new PersonalContext()));
                var distributedCache = CacheManagerCreatorFactory.Default.Create(CacheManagerCreatorFactory.CacheManagerType.InMemoryCacheManager, new CacheSettings());
                _invoker.Extensions.Add(new CachingExtension(distributedCache));
                var customerValidationAnswerExtension = new CustomerValidationAnswerExtension(
                    new List<ICustomerValidationAnswerEngine>()
                    {
                    new ValidationAnswererTaxNumber(),
                    new ValidationAnswererContactPrimaryAddressCity()
                    });
                _invoker.Extensions.Add(customerValidationAnswerExtension);
                ConfigureFor("USECONTEXT", "1");
            }

            public WorkflowHelper<TWorkflowType> ConfigureXrmDataContext(string connectionParameter = "connectionString")
            {
                string configValue = null;
                if (_configuration.TryGetValue(connectionParameter, out configValue))
                {
                    _invoker.Extensions.Add(OrganizationServiceHelper.CreateContextProvider(configValue));
                }
                else
                {
                    throw new ArgumentException();
                }
                return this;
            }

            public WorkflowHelper<TWorkflowType> AddExtension(object extension)
            {
                _invoker.Extensions.Add(extension);
                return this;
            }

            public WorkflowHelper<TWorkflowType> ConfigureFor(string key, string value)
            {
                _configuration.TryAdd(key, value);
                return this;
            }

            public WorkflowHelper<TWorkflowType> InputFor(string key, string value)
            {
                _input.Add(key, value);
                return this;
            }

            public IDictionary<string, object> Invoke()
            {
                return _invoker.Invoke(_input);
            }
        }
    }
}
