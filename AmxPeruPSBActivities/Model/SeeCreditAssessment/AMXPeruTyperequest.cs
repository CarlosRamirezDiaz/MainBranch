using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.SeeCreditAssessment
{
    public class AMXPeruTyperequest
    {
        public string BuroConsulted { get; set; }
        public string Fixedcharge { get; set; }
        public AMXPeruCustomerType Client { get; set; }
        public double Totalcostofequipment { get; set; }
        public AMXPeruTypeEquipment Equipment { get; set; }
        public DateTime Dateofexecution { get; set; }
        public string Flagofbid { get; set; }
        public int Hourrun { get; set; }
        public AMXPeruOfferType Offer { get; set; }
        public double Pricetotalequipmentsale { get; set; }
        public AMXPeruPointofSaleType Pointofsale { get; set; }
        public int Risktotalequipment { get; set; }
        public string Bagtype { get; set; }
        public string Dispatchtype { get; set; }
        public string Typeofoperation { get; set; }
        public string Transaction { get; set; }
    }
}
