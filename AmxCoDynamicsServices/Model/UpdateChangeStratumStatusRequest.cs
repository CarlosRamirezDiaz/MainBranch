using System.Runtime.Serialization;

namespace AmxDynamicsServices
{
    [DataContract]
    public class UpdateChangeStratumStatusRequest
    {
        [DataMember]
        public string caseId { get; set; }
        [DataMember]
        public string caseReason { get; set; }
        [DataMember]
        public string caseIdMGL { get; set; }
        [DataMember]
        public string caseStatus { get; set; }
    }
}
