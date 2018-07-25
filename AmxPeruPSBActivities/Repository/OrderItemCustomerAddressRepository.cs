using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model.OrderItem;
using AmxPeruPSBActivities.Repository.Factory;

namespace AmxPeruPSBActivities.Repository
{
    public class OrderItemCustomerAddressRepository
    {
        OrganizationServiceProxy _organizationService;

        public OrderItemCustomerAddressRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieve the Order Item Customer Address
        /// </summary>
        /// <param name="orderItemCustomerAddressId"></param>
        /// <returns></returns>
        public OrderItemCustomerAddressModel GetOrderItemCustomerAddress(System.Guid orderItemCustomerAddressId)
        {
            if (orderItemCustomerAddressId == Guid.Empty)
                return new OrderItemCustomerAddressModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "amx_orderitemcustomeraddress",
                ColumnSet = AmxPeruPSBActivities.Repository.Factory.OrderItemCustomerAddressFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("amx_orderitemcustomeraddressid", ConditionOperator.Equal, orderItemCustomerAddressId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new OrderItemCustomerAddressModel();

            return AmxPeruPSBActivities.Repository.Factory.OrderItemCustomerAddressFactory.CreateOrderItemCustomerAddressFrom(collection.Entities[0]);
        }

        public Guid Create(OrderItemCustomerAddressModel orderItemCustomerAddress)
        {
            Entity entity = AmxPeruPSBActivities.Repository.Factory.OrderItemCustomerAddressFactory.CreateEntityFrom(this._organizationService, orderItemCustomerAddress);

            return this._organizationService.Create(entity);
        }

        public void Update(OrderItemCustomerAddressModel orderItemCustomerAddress)
        {
            Entity entity = AmxPeruPSBActivities.Repository.Factory.OrderItemCustomerAddressFactory.CreateEntityFrom(this._organizationService, orderItemCustomerAddress);
             
            this._organizationService.Update(entity);
        }

        /// <summary>
        /// Retrieve the Order Item Customer Address from Order Item
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <returns></returns>
        public List<OrderItemCustomerAddressModel> GetOrderItemCustomerAddressFromOrderItem(System.Guid orderItemId)
        {
            if (orderItemId == Guid.Empty)
                return new List<OrderItemCustomerAddressModel>();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "amx_orderitemcustomeraddress",
                ColumnSet = AmxPeruPSBActivities.Repository.Factory.OrderItemCustomerAddressFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("amx_orderitemid", ConditionOperator.Equal, orderItemId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new List<OrderItemCustomerAddressModel>();

            List<OrderItemCustomerAddressModel> orderItemCustomerAddressList  = new List<OrderItemCustomerAddressModel>();

            foreach (Entity entity in collection.Entities)
                orderItemCustomerAddressList.Add(AmxPeruPSBActivities.Repository.Factory.OrderItemCustomerAddressFactory.CreateOrderItemCustomerAddressFrom(entity));

            return orderItemCustomerAddressList;
        }

        /// <summary>
        /// Retrieve the Order Item Customer Address from OrderCaptureId
        /// </summary>
        /// <param name="orderCaptureId"></param>
        /// <returns></returns>
        public List<OrderItemCustomerAddressModel> ListOrderItemCustomerAddressByOrderCaptureId(System.Guid orderCaptureId)
        {
            if (orderCaptureId == Guid.Empty)
                return new List<OrderItemCustomerAddressModel>();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "amx_orderitemcustomeraddress",
                ColumnSet = AmxPeruPSBActivities.Repository.Factory.OrderItemCustomerAddressFactory.Fields
            };

            query.AddLink("etel_orderitem", "amx_orderitemid", "etel_orderitemid");
            query.LinkEntities[0].AddLink("etel_ordercapture", "etel_orderid", "etel_ordercaptureid");
            query.LinkEntities[0].LinkEntities[0].LinkCriteria.AddCondition("etel_ordercaptureid", ConditionOperator.Equal, orderCaptureId);

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new List<OrderItemCustomerAddressModel>();

            List<OrderItemCustomerAddressModel> orderItemCustomerAddressList = new List<OrderItemCustomerAddressModel>();

            foreach (Entity entity in collection.Entities)
                orderItemCustomerAddressList.Add(AmxPeruPSBActivities.Repository.Factory.OrderItemCustomerAddressFactory.CreateOrderItemCustomerAddressFrom(entity));

            return orderItemCustomerAddressList;
        }

        /// <summary>
        /// Create or update address association for order item
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public void CreateUpdateAddressForOrderItem(System.Guid orderItemId, System.Guid addressId)
        {
            // Find all order item customer address for order item
            List<OrderItemCustomerAddressModel> orderItemCustomerAddressList = GetOrderItemCustomerAddressFromOrderItem(orderItemId);

            // If there is no record create, else update
            if(orderItemCustomerAddressList.Count == 0)
            {
                OrderItemCustomerAddressModel orderItemCustomerAddress = new OrderItemCustomerAddressModel();
                orderItemCustomerAddress.amx_customeraddressid = addressId;
                orderItemCustomerAddress.amx_orderitemid = orderItemId;
                orderItemCustomerAddress.amx_name = "";
                Create(orderItemCustomerAddress);
            }
            else {
                foreach (OrderItemCustomerAddressModel orderItemCustomerAddress in orderItemCustomerAddressList)
                {
                    orderItemCustomerAddress.amx_customeraddressid = addressId;
                    Update(orderItemCustomerAddress);
                }
                    
            }
        }
    }
}
