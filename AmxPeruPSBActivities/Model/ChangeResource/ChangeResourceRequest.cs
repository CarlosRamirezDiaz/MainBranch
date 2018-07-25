using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.ChangeResource
{
    public class ChangeResourceRequest: BaseRequest
    {
        public string CustomerId { get; set; }
        public string SubscriptionId { get; set; }
    }
}
