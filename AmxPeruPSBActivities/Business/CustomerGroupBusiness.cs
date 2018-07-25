using Ericsson.ETELCRM.Entities.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    class CustomerGroupBusiness
    {
        /// <summary>
        /// Gets all customer groups in CRM
        /// </summary>
        /// <returns>List of customer groups</returns>
        public List<etel_customergroup> GetCustomerGroups()
        {
            //return ActionContext.Resolve<ICustomerGroupRepository>().GetCustomerGroups();
            //todo: implement with xrmdatacontext;
            return null;
        }

        /// <summary>
        /// Gets customer groups by customer id and type
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <param name="customerType">Customer Type</param>
        /// <returns>Customer Group List</returns>
        public List<etel_customergroup> GetCustomerGroups(Guid customerId, int customerType)
        {
            //ToDO: @tahir this thing must converted to ICustomer architecture
            // return ActionContext.Resolve<ICustomerGroupRepository>().GetCustomerGroups(customerId, customerType);
            //todo: implement with xrmdatacontext;
            return null;
        }
    }
}
