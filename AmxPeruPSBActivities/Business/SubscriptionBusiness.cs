using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    class SubscriptionBusiness
    {
        XrmDataContextProvider _xrmDataContextProvider;

        /// <summary>
        /// Get contract's External Id
        /// </summary>
        /// <param name="id">Contract Id</param>
        /// <returns>External Id of a contract</returns>
        public string GetContractExternalIdById(Guid id)
        {
            var dataContext = _xrmDataContextProvider.DataContext;
            return dataContext.etel_subscriptionSet.Where(t => t.Id == id).Select(c => c.etel_externalid).FirstOrDefault();
        }
    }
}
