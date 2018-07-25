using Ericsson.ETELCRM.CrmFoundationLibrary.ExternalService;
using Ericsson.ETELCRM.Entities.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    class ContractBusiness
    {
        /// <summary>
        /// Get External Id
        /// </summary>
        /// <param name="id">
        /// Contract Id
        /// </param>
        /// <returns>
        /// external Id
        /// </returns>
        public string GetExternalId(Guid id)
        {
            var subscriptionBusiness = new SubscriptionBusiness();
            return subscriptionBusiness.GetContractExternalIdById(id);
        }
        
    }
}
