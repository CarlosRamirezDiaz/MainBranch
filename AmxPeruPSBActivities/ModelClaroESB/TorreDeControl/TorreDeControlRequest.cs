using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxCoPSBActivities.Model.TorreDeControl;
using Newtonsoft.Json;

namespace AmxCoPSBActivities.ModelClaroESB.TorreDeControl
{
    public class TorreDeControlRequest
    {
        public string pushType { get; set; }
        public string typeCostumer { get; set; }
        public List<MessageBoxExt> messageBox { get; set; }
        public List<string> profileId { get; set; }
        public List<string> communicationType { get; set; }
        public string communicationOrigin { get; set; }
        public string deliveryReceipts { get; set; }
        public string contentType { get; set; }
        public string messageContent { get; set; }

        public class MessageBoxInt
        {
            public string customerId { get; set; }
            public string customerBox { get; set; }
        }

        public class MessageBoxExt
        {
            public string messageChannel { get; set; }
            public List<MessageBoxInt> messageBox { get; set; }
        }

        public static TorreDeControlRequest TorreDeControlRequestFactory(AmxCoTorreDeControlRequest request)
        {
            var returnValue = new TorreDeControlRequest();
            return returnValue;
        }

    }
}
