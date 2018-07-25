using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.CreditProfile
{
    public class CreditProfileModel
    {
        public Guid Id { get; set; }
        public Guid IndividualCustomerId { get; set; }
        public string BureauClassification { get; set; }
        public string BureauCreditScore { get; set; }
        public DateTime BureauDate { get; set; }
        public string BureauFamilyNames { get; set; }
        public string BureauGivenNames { get; set; }
        public string BureauScore { get; set; }
        public string BureauType { get; set; }
        public int BuroInternoScoreCustomerAge { get; set; }
        public int BuroInternoScoreCustomerSince { get; set; }
        public int BuroInternoScoreActiveLines { get; set; }
        public int BuroInternoScore { get; set; }
        public string BureauSource { get; set; }


    }
}
