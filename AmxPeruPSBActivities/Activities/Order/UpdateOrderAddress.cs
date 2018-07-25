using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.OrderCapture;
using System.IO;
using AmxPeruPSBActivities.Repository;

namespace AmxPeruPSBActivities.Activities.Order
{
    public class UpdateOrderAddress : XrmAwareCodeActivity
    {
        public InArgument<Guid> OrderCaptureId { get; set; }
        public InArgument<Guid> AddressId { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var orderCaptureRepository = new OrderCaptureRepository(ContextProvider.OrganizationService);
            var orderCapture = new OrderCaptureModel();

            orderCapture.OrderCaptureId = OrderCaptureId.Get(context);
            orderCapture.amxperu_installationaddressid = AddressId.Get(context);
            orderCaptureRepository.Update(orderCapture);

            // Update all address in order items
            var orderItemRepository = new OrderItemRepository(ContextProvider.OrganizationService);
            List<OrderItemModel> orderItemList = orderItemRepository.RetrieveOrderItemModelByOrder(orderCapture.OrderCaptureId);
            foreach (OrderItemModel orderItem in orderItemList)
            {
                // Create or update order item customer adderss 
                var orderItemCustomerAddressRepository = new AmxPeruPSBActivities.Repository.OrderItemCustomerAddressRepository(ContextProvider.OrganizationService);
                orderItemCustomerAddressRepository.CreateUpdateAddressForOrderItem(orderItem.Id, orderCapture.amxperu_installationaddressid);
            }

        }
    }
}
