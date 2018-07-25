using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.SendNotification
{
    public class AmxperuSendNotificationResponse :BaseResponse
    {
        public List<KeyValuePairResponse> AttributeValuePairResponse { get; set; }

    }
    public class KeyValuePairResponse
    {
        public string ResponsenameField { get; set; }
        public string ResponsevalueField { get; set; }

    }
}
