using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;

namespace AmxPeruPSBActivities.Activities.OrderItem
{

    public sealed class UpdateOrderItemAction : XrmAwareCodeActivity
    {
        public InArgument<Guid> OrderItemId { get; set; }

        public InArgument<string> OrderItemAction { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            Guid orderItemId = OrderItemId.Get(context);

            string orderItemAction = OrderItemAction.Get(context);

            Entity orderitem = new Entity();
            orderitem.LogicalName = "etel_orderitem";
            orderitem.Id = orderItemId;

            orderitem.Attributes["amx_action"] = new OptionSetValue(int.Parse(orderItemAction));
            ContextProvider.OrganizationService.Update(orderitem);
        }
    }
}
