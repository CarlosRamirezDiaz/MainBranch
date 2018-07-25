using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.AMXCOLOMBIA.Model.OrderCapture
{
    public class ListOrderCapture
    {
        public Guid OrderCaptureId { get; internal set; }
        public string Name { get; internal set; }
        public string OrderType { get; internal set; }
        public string StatusReason { get; internal set; }
        public string CancelOrPostponeReason { get; internal set; }
        public string CreatedOn { get; internal set; }
        public string ExternalOrderId { get; internal set; }
        public string ShoppingCardId { get; internal set; }
        public string SourceSystem { get; internal set; }
        public string SubscriptionName { get; internal set; }
        public string CancelReasonName { get; internal set; }
        public string PostponeReasonName { get; internal set; }
    }
}
