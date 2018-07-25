using AmxPeruCommonLibrary.Caching;
using Ericsson.ETELCRM.CrmCachingLibrary.Caching;
using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruCommonLibrary.Repository
{
    public class AmxPeruRepositoryBase
    {
        public AmxPeruRepositoryBase()
        {

        }

        public virtual Entity RetrieveById(IOrganizationService organizationSevice, Guid id, string EntityLogicalName)
        {
            Entity entity = organizationSevice.Retrieve(EntityLogicalName, id, new ColumnSet(true));
            return entity;
        }

        public virtual Entity RetrieveById(IOrganizationService organizationSevice, Guid id, string EntityLogicalName, ColumnSet columnSet)
        {
            Entity entity = organizationSevice.Retrieve(EntityLogicalName, id, columnSet);
            return entity;
        }

        public virtual EntityCollection RetrieveMultiple(IOrganizationService organizationSevice, string entityLogicalName, ConditionExpression condition = null, params string[] columns)
        {
            if (organizationSevice == null)
            {
                throw new Exception("Organization service not initialized");
            }

            QueryExpression orderItemsExpression = new QueryExpression(entityLogicalName);
            orderItemsExpression.ColumnSet = columns.Length == 0 ? new ColumnSet(true) : new ColumnSet(columns);
            orderItemsExpression.Criteria = new FilterExpression();
            orderItemsExpression.Criteria.AddCondition(condition);
            EntityCollection orderItemList = organizationSevice.RetrieveMultiple(orderItemsExpression);
            return orderItemList;
        }
    }
}
