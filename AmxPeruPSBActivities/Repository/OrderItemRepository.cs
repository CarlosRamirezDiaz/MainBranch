using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model;

namespace AmxPeruPSBActivities.Repository
{
    public class OrderItemRepository
    {
        XrmDataContext _xrmDataContext;
        XrmDataContextProvider _xrmDataContextProvider;

        OrganizationServiceProxy _organizationService;

        public OrderItemRepository()
        {
        }


        public OrderItemRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieves the customized order item list by order id
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <returns>Order Item List</returns>
        public OrderItemModel RetrieveCustomizedOrderItemByOrder(System.Guid orderId)
        {
            if (orderId == Guid.Empty)
                return new OrderItemModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_orderitem",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.OrderItemFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_orderitemid", ConditionOperator.Equal, orderId);

            query.TopCount = 1;

            var collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new OrderItemModel();

            return AmxCoPSBActivities.Repository.Factory.OrderItemFactory.CreateOrderItemFrom(collection.Entities[0]);
        }

        /// <summary>
        /// Retrieves the order item list by order id
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <returns>Order Item List</returns>
        public List<etel_orderitem> RetrieveOrderItemByOrder(System.Guid orderId)
        {
            return _xrmDataContext.etel_orderitemSet
                .Where(i => i.etel_orderid.Id == orderId)
                    .OrderBy(i => i.CreatedOn).ToList();
        }

        /// <summary>
        /// Retrieves the order item list by order id
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <returns>Order Item List</returns>
        public List<etel_orderitem> RetrieveOrderItemByOrderViaOrganizationService(System.Guid orderId)
        {
            var result = _xrmDataContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                ColumnSet = new ColumnSet(true),
                Criteria =
                    new FilterExpression
                    {
                        Conditions
                                =
                                {
                                    new ConditionExpression(
                                        "etel_orderid",
                                        ConditionOperator.Equal,
                                        orderId),
                                }
                    }
            });

            return result.Entities.Select(e=> e.ToEntity<etel_orderitem>()).OrderBy(i => i.CreatedOn).ToList();
        }

        /// <summary>
        /// Update order item with customized fields order item list by order id
        /// </summary>
        /// <param name="this._organizationService">this._organizationService</param>
        /// <param name="orderItem">orderItem</param>
        /// <returns>Order Item List</returns>
        public void Update(OrderItemModel orderItem)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.OrderItemFactory.CreateEntityFrom(this._organizationService, orderItem);

            this._organizationService.Update(entity);
        }

        /// <summary>
        /// Retrieves the order item list by order id
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <returns>Order Item List</returns>
        public List<OrderItemModel> RetrieveOrderItemModelByOrder(System.Guid orderId)
        {
            if (orderId == Guid.Empty)
                return new List<OrderItemModel>();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_orderitem",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.OrderItemFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_orderid", ConditionOperator.Equal, orderId);

            var collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new List<OrderItemModel>();

            List<OrderItemModel> orderItemList = new List<OrderItemModel>();

            if (collection.Entities.Count() > 0)
                foreach(Entity entity in collection.Entities)
                    orderItemList.Add(AmxCoPSBActivities.Repository.Factory.OrderItemFactory.CreateOrderItemFrom(entity));
            
            return orderItemList;
        }
    }
}
