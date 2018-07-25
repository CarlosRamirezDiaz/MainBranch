using AmxCoPSBActivities.Business;
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

namespace AmxCoPSBActivities.AMXCOLOMBIA.Activities.Configuration
{
    public class GetConfigurableItems : XrmAwareCodeActivity
    {
        public InArgument<OrderItemsBasketModel> orderItemsBasket { get; set; }
        public OutArgument<ConfigurableItemsModel> configurableItemsBasket { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            OrderItemsBasketModel _orderItemsBasket = context.GetValue(this.orderItemsBasket);
            OrderItemsBasketModel _configurableItemsBasket = new OrderItemsBasketModel();
            _configurableItemsBasket.listOfOrderBasketOrderItems = new List<OrderBasketOrderItem>();

            AmxCoGetConfigurableItemsBusiness getConfigurableItemsBusiness = new AmxCoGetConfigurableItemsBusiness();
            
            configurableItemsBasket.Set(context, getConfigurableItemsBusiness.GetConfigurableItems(ContextProvider.OrganizationService, _orderItemsBasket));
        }
    }
}
