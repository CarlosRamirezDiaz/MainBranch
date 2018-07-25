using System.Runtime.Serialization;

namespace AmxDynamicsServices
{
    [DataContract]
    public class BaseResponse
    {
        [DataMember]
        public string Error { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
