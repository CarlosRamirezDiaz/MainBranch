using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.BSSCustomerCreditScoreMgmtLG
{
    public class AMXPeruCorporatetype
    {
        public int Score { get; set; }
        public decimal Creditlimit { get; set; }
        public decimal Creditcardentry { get; set; }
        public decimal Mortgagedebtincome { get; set; }
        public decimal NonMortgagedebtincome { get; set; }
        public List<AMXPeruIntegraltype> Listmembers { get; set; }
        public List<AMXPeruTyperepresentative> Listrepresentatives { get; set; }
    }
}
