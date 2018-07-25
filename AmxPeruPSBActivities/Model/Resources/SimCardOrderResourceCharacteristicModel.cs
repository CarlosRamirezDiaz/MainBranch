using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Resources
{
    public class SIMCardOrderResourceCharacteristicModel
    {
        public string SIM { get; set; }
        public string ICCID { get; set; }
        public string IMSI { get; set; }
        public string PUK { get; set; }
        public string KI { get; set; }
        public string IMEI { get; set; }
        public string SerialNumber { get; set; }
        public string Technology { get; set; }
    }
}
