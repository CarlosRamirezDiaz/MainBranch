using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.OrderItem;

namespace AmxPeruPSBActivities.Activities.Order
{
    public class RetrieveOrderCapture : XrmAwareCodeActivity
    {
        public InArgument<OrderItemAddShoppingCartModel> OrderItemShoppingCartModel { get; set; }

        public OutArgument<etel_ordercapture> OrderCapture { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var orderItemShoppingCartModel = OrderItemShoppingCartModel.Get(context);

            var orderCaptureId = new Guid(orderItemShoppingCartModel.OrderCaptureId);         
            var query = from orderCapture in dataContext.etel_ordercaptureSet
                        where orderCapture.Id == orderCaptureId
                        select orderCapture;            

            OrderCapture.Set(context, query.FirstOrDefault());
            
        }
    }
}
