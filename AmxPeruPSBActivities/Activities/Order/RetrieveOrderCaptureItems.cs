using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model;

namespace AmxPeruPSBActivities.Activities.Order
{
    public class RetrieveOrderCaptureItems : XrmAwareCodeActivity
    {
        public InArgument<Guid> OrderCaptureId { get; set; }

        public OutArgument<List<etel_orderitem>> OrderItems { get; set; }        

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var orderCaptureId = OrderCaptureId.Get(context);

            var itemQuery = from OrderItem in dataContext.etel_orderitemSet
                            where OrderItem.etel_orderid.Id == orderCaptureId
                            select OrderItem;
            OrderItems.Set(context, itemQuery.ToList());            

            /*
            var orderItemDataModelList = new List<OrderItemDataModel>();
            foreach (var item in orderItems)
            {
                var orderItemModel = new OrderItemDataModel();
                orderItemModel.Id = item.Id;
                orderItemModel.OfferingName = item.etel_offeringid.Name;
                orderItemModel.ParentOrderItemId = item.etel_parentorderitemid.Id;
                orderItemModel.OrderId = orderCaptureId;
                orderItemModel.OfferingId = item.etel_offeringid.Id;
                orderItemDataModelList.Add(orderItemModel);
            }
            OrderItemModel.Set(context, orderItemDataModelList);
            */
        }
    }
}
