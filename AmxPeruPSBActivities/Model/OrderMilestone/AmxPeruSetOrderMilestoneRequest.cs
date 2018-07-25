using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.OrderMilestone
{
    public class AmxPeruSetOrderMilestoneRequest : BaseRequest
    {
        public string CRMOrderId { get; set; }

        public string EOCOrderId { get; set; }

        public string EOCQuoteId { get; set; }

        public string ErrorCode { get; set; }

        public string Description { get; set; }

        public string MileStone { get; set; }

        public bool PointOfNoReturn { get; set; }

        public OrderFulFillmentStatusCode OrderFulFillmentStatusCode { get; set; }

    }
    public enum OrderFulFillmentStatusCode
    {
        New = 1,
        InProgress = 2,
        Error = 3,
        Completed = 4,
        Cancelled = 5,
        Amended = 6
    }
}
