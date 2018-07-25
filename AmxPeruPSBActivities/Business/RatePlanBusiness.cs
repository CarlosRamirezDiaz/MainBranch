using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    class RatePlanBusiness
    {

        XrmDataContext _xrmDataContext { set; get; }

        public etel_rateplan GetRatePlanByOfferingId(Guid offeringId)
        {
            var temp = from rateplan in _xrmDataContext.etel_rateplanSet
                       join offering in _xrmDataContext.ProductSet
                       on rateplan.etel_rateplanId equals offering.etel_rateplanid.Id
                       where offering.ProductId == offeringId
                       select rateplan;

            etel_rateplan retVal = temp.FirstOrDefault();

            return retVal;
        }

        /// <summary>
        /// Gets the associated rate plan record from CRM for the specified contract Id
        /// </summary>
        /// <param name="contractid">Unique identifier for the contract</param>
        /// <returns>Returns a list of rate plans</returns>
        public List<etel_rateplan> GetRatePlanByContractId(Guid contractid)
        {
            var tempList = from subscription in _xrmDataContext.etel_subscriptionSet
                           join rateplan in _xrmDataContext.etel_rateplanSet
                           on subscription.etel_rateplanid.Id equals rateplan.etel_rateplanId.Value
                           where subscription.etel_subscriptionId == contractid
                           select rateplan;

            List<etel_rateplan> retVal = tempList.ToList();

            return retVal;
        }



    }
}
