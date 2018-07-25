using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.SeeCreditAssessment
{
    public class AMXPeruOfferType
    {
        public AMXPeruBellType Bell { get; set; }
        public int Quantityofdecos { get; set; }
        public int Quantitylinesec { get; set; }
        public string Specialcase { get; set; }
        public string Combo { get; set; }
        public string Consumercontrol { get; set; }
        public string Installationkit { get; set; }
        public int Monthassignor { get; set; }
        public string Transferringmode { get; set; }
        public double Amountcfsec { get; set; }
        public string Assignoroperator { get; set; }
        public AMXPeruCurrentPlanType Currentplan { get; set; }
        public AMXPeruRequestedPlan Requestedplan { get; set; }
        public string Agreementterm { get; set; }
        public string Commercialproduct { get; set; }
        public string Mobileprotection { get; set; }
        public string Risk { get; set; }
        public string Offersegment { get; set; }
        public string Typeofoperationcompany { get; set; }
        public string Kindofproduct { get; set; }
    }
}
