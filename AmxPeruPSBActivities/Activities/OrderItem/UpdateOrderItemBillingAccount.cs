using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Repository;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class UpdateOrderItemBillingAccount : XrmAwareCodeActivity
    {
        public InArgument<Guid> OrderItemId { get; set; }
        public InArgument<String> BillingAccountId { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var orderItemRepository = new OrderItemRepository(ContextProvider.OrganizationService);
            var orderItem = orderItemRepository.RetrieveCustomizedOrderItemByOrder(OrderItemId.Get(context));

            orderItem.amx_billingaccountexternalid = BillingAccountId.Get(context);

            orderItemRepository.Update(orderItem);
        }
    }
}
