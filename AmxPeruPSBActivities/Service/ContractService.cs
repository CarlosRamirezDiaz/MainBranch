using Ericsson.ETELCRM.Business;
using Ericsson.ETELCRM.Business.WCF;
using Ericsson.ETELCRM.CrmFoundationLibrary.ServiceClient.Entities;
using Ericsson.ETELCRM.CrmFoundationLibrary.ServiceClient.ServiceContracts;
using Ericsson.ETELCRM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Service
{
    class ContractService
    {
        /// <summary>
        /// Retrieves products from BSCS by the provided external Id
        /// </summary>
        /// <param name="contractExternalId"></param>
        /// <returns></returns>
        public SearchProductResponse GetProductResponse(PsbConfigurationBusiness psbConfigurationBusiness, IIdentity identity, string contractExternalId)
        {
            using (var searchProxy = new GenericWCFProxyFactory().CreateProxy<ContractSearchPortType>(psbConfigurationBusiness,
                CRMConfigurationEntry.BIL_Contract_Search_Url, identity?.Name))
            {
                var request = new SearchProductRequest
                {
                    contract = new Contract { externalId = contractExternalId }
                };
                var response = searchProxy.Channel.searchContract(new searchContract1()
                {
                    searchContractRequest = request
                });
                return response.@return;
            }
        }
    }
}
