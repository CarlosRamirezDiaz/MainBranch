using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    class CustomerBusiness
    {
        /// <summary>
        /// Retrieves the entity from CRM for the specified entity Id
        /// </summary>
        /// <param name="entityName">Logical name of the entity</param>
        /// <param name="entityId">Unique identifier for the entity</param>
        /// <param name="columnSet">columns of the entity</param>
        /// <returns>Returns entity record</returns>
        public virtual Entity RetrieveById(string entityName, Guid entityId, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            //return ActionContext.Resolve<IGenericRepository>().RetrieveById(entityName, entityId, columnSet);
            //todo: use xrm datacontext here;
            return null;
        }

        /// <summary>
        /// Gets the market segments identifier.
        /// </summary>
        /// <param name="customerType">Type of the customer.</param>
        /// <param name="entityId">The customer identifier.</param>
        /// <returns>A customer</returns>
        public EntityReference GetMarketSegmentsId(int customerType, Guid entityId)
        {
            string entityName = customerType == 1 ? Account.EntityLogicalName : Ericsson.ETELCRM.Entities.Crm.Contact.EntityLogicalName;
            return ((ICustomer)this.RetrieveById(entityName, entityId, new ColumnSet("etel_marketsegmentid"))).etel_marketsegmentid;
        }
    }
}
