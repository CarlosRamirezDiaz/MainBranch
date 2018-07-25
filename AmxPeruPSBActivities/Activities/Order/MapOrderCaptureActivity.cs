using AmxPeruPSBActivities.Model;
using Ericsson.ETELCRM.Entities.Crm;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.Order
{
    public class MapOrderCaptureActivity : CodeActivity
    {
        public InArgument<etel_ordercapture> OrderCapture { get; set; }

        public InArgument<List<etel_orderitem>> OrderItems { get; set; }

        public OutArgument<OrderDataModel> OrderModel { get; set; }

        protected override void Execute(CodeActivityContext context)
        {

            var orderItems = OrderItems.Get(context);
            var orderCapture = OrderCapture.Get(context);

            var orderItemDataModelList = new List<OrderItemDataModel>();
            foreach (var item in orderItems)
            {
                var orderItemModel = new OrderItemDataModel();
                orderItemModel.Id = item.Id;
                orderItemModel.OfferingName = item.etel_offeringid.Name;
                orderItemModel.ParentOrderItemId = item.etel_parentorderitemid != null ? item.etel_parentorderitemid.Id : Guid.Empty;
                orderItemModel.OrderId = orderCapture.Id;
                orderItemModel.OfferingId = item.etel_offeringid.Id;
                orderItemDataModelList.Add(orderItemModel);
            }

            var orderModel = new OrderDataModel();
            orderModel.Id = orderCapture.Id;
            orderModel.orderItems = orderItemDataModelList;
            OrderModel.Set(context, orderModel);
        }
    }
}
