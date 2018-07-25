using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class ConfigurableItemsModel
    {
        public List<ProductOfferingFull> productOfferingFullList { get; set; }
        public OrderItemsBasketModel orderItemsBasket { get; set; }
        public bool hasConfigurableItems { get; set; }
    }
}
