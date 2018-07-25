using Ericsson.ETELCRM.Entities.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.OrderItem
{
    public class OrderItemAddShoppingCartModel
    {
        public string OrderCaptureId { get; set; }

        public string OfferingId { get; set; }

        public string ParentOrderItemId { get; set; }

        public string SrProductId { get; set; }

        public string SrParentPoId { get; set; }

        public string OrderItemAction { get; set; }

        public string RecurringPrice { get; set; }

        public string OneTimePrice { get; set; }

        public string PopExternalId { get; set; }

        public string AddressId { get; set; }

        public string SelectedAddressStratum { get; set; }

        public string BasicOffering { get; set; }

        public string PoExternalId { get; set; }

        public bool FromServiceRegistry { get; set; }
    }
}
