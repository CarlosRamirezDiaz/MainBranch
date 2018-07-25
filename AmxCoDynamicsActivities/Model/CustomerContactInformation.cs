using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AmxDynamicsActivities.Model
{
    [DataContract]
    public class CustomerContactInformation
    {
        [DataMember]
        public string guid { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string contacttype { get; set; }
        [DataMember]
        public string contactinfo { get; set; }
        [DataMember]
        public string mobileInfo { get; set; }
        [DataMember]
        public string fixedlineInfo { get; set; }
        [DataMember]
        public string fixedOrMobile { get; set; }
        [DataMember]
        public string isprimary { get; set; }
    }
}
