using AmxPeruPSBActivities.Model;
using System.Runtime.Serialization;

namespace AmxDynamicsServices
{
    [DataContract]
    public class BaseRequest
    {
        [DataMember]
        public string Channel { get; set; }

        [DataMember]
        public CustomerType? CustomerType { get; set; }

        [DataMember]
        public string CustomerExternalID { get; set; }
    }    
}