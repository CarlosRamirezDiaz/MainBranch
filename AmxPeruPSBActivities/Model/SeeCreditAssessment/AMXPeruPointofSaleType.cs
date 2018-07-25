using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.SeeCreditAssessment
{
    public class AMXPeruPointofSaleType
    {
        public string Qualityofsalesman { get; set; }
        public string Channel { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public AMXPeruAddressType Address { get; set; }
        public string Group { get; set; }
        public bool Risky { get; set; }
    }
}
