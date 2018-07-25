using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.SeeCreditAssessment
{
    public class AMXPeruTypeEquipment
    {
        public double Cost { get; set; }
        public int Dues { get; set; }
        public double Initialpaymentfactor { get; set; }
        public double Subsidyfactor { get; set; }
        public string Waytopay { get; set; }
        public string Spectrum { get; set; }
        public string Group { get; set; }
        public string Model { get; set; }
        public double Feeamount { get; set; }
        public double Initialrate { get; set; }
        public double Saleprice { get; set; }
        public int Risk { get; set; }
        public string Decotype { get; set; }
        public string Typeoperationkit { get; set; }
    }
}
