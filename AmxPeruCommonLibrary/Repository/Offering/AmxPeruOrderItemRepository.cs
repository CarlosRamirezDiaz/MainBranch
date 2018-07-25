using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruCommonLibrary.Repository.Offering
{
    public class AmxPeruOrderItemRepository : AmxPeruRepositoryBase
    {
        public static readonly string OrderItemEntityName = "etel_orderitem";
        public static readonly string OrderProductCharacteristicEntityName = "etel_orderproductcharacteristic";


        public EntityCollection RetrieveOrderItemCharacteristics(IOrganizationService organizationService, Guid orderItemId)
        {
            var resultproductcharacteristic = organizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = OrderProductCharacteristicEntityName,
                ColumnSet = new ColumnSet(true),
                Criteria =
                new FilterExpression()
                {
                    Conditions =
                        {
                                    new ConditionExpression("etel_orderitemid", ConditionOperator.Equal,orderItemId),
                        }
                }
            });
            return resultproductcharacteristic;
        }


        public EntityCollection RetrieveOrderCharacteristics(IOrganizationService organizationService, Guid orderCaptureId)
        {
            const string OrderItemIdColumn = "etel_orderitemid";
            const string OrderIdColumn = "etel_orderid";

            //Add Product Offering Entity to Query
            QueryExpression query = new QueryExpression();
            query.EntityName = OrderProductCharacteristicEntityName;
            query.ColumnSet = new ColumnSet(true);
            query.LinkEntities.Add(new LinkEntity(OrderProductCharacteristicEntityName, etel_orderitem.EntityLogicalName,
                OrderItemIdColumn, OrderItemIdColumn, JoinOperator.Inner));
            query.LinkEntities[0].EntityAlias = etel_orderitem.EntityLogicalName;
            query.LinkEntities[0].LinkCriteria.Conditions.Add(
                new ConditionExpression(OrderIdColumn, ConditionOperator.Equal, orderCaptureId));
            var result = organizationService.RetrieveMultiple(query);
            return result;

        }
    }
}
