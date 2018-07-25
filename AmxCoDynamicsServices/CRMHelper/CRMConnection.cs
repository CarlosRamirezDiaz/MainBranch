using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Configuration;
using System.ServiceModel.Description;

namespace AmxDynamicsServices
{
    public static class CRMConnection
    {
        public static IOrganizationService GetConnection()
        {
            IOrganizationService OrgService = null;

            if (!CacheUtility.IsAvailableInCache("OrganizationService"))
            {
                string userName = ConfigurationManager.AppSettings["OrgServiceInstanceUserId"].ToString();
                string Password = ConfigurationManager.AppSettings["OrgServiceInstancePassword"].ToString();
                string CrmConnectionString = ConfigurationManager.AppSettings["OrgServiceInstanceUri"].ToString();

                if (CrmConnectionString != null)
                {
                    ClientCredentials _ClientCredentials = new ClientCredentials();
                    _ClientCredentials.UserName.UserName = userName;
                    _ClientCredentials.UserName.Password = Password;
                    OrganizationServiceProxy _OrganizationServiceProxy = new OrganizationServiceProxy(new Uri(CrmConnectionString), null, _ClientCredentials, null);
                    _OrganizationServiceProxy.EnableProxyTypes();
                    OrgService = (IOrganizationService)_OrganizationServiceProxy;

                    if (OrgService != null)
                    {
                        string cacheTimeSpan = ConfigurationManager.AppSettings["CacheTimeSpan"].ToString();
                        string[] timeSeperation = cacheTimeSpan.Split(':');
                        TimeSpan _timeSpan = new TimeSpan(int.Parse(timeSeperation[0]), int.Parse(timeSeperation[1]), int.Parse(timeSeperation[2]));
                        CacheUtility.SetValueToCache("OrganizationService", (object)OrgService, _timeSpan);
                    }
                }
            }
            else
            {
                object obj = CacheUtility.GetValueFromCache<object>("OrganizationService");
                OrgService = (IOrganizationService)(obj);
            }

            return OrgService;
        }
    }
}