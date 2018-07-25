using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model;

namespace AmxCoPSBActivities.Model.TorreDeControl
{
    public class AmxCoTorreDeControlRequest
    {
        public string pushType { get; set; }
        public string typeCostumer { get; set; }
        public List<AmxCoMessageBoxExt> messageBox { get; set; }
        public List<string> profileId { get; set; }
        public List<string> communicationType { get; set; }
        public string communicationOrigin { get; set; }
        public string deliveryReceipts { get; set; }
        public string contentType { get; set; }
        public string messageContent { get; set; }

        public class AmxCoMessageBoxInt
        {
            public string customerId { get; set; }
            public string customerBox { get; set; }
        }

        public class AmxCoMessageBoxExt
        {
            public string messageChannel { get; set; }
            public List<AmxCoMessageBoxInt> messageBox { get; set; }
        }
    }
}
