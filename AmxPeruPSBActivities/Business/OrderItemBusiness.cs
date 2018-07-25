using AmxPeruPSBActivities.Repository;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    public class OrderItemBusiness
    {
        /// <summary>
        /// Retrieves the order item list by order id
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <returns>Order Item List</returns>
        public List<etel_orderitem> RetrieveOrderItems(Guid orderId)
        {
            var orderItemRepository = new OrderItemRepository();
            return orderItemRepository.RetrieveOrderItemByOrder(orderId);
        }

        
    }
}
