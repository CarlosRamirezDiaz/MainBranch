using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.BSSCustomerCreditScoreMgmtLG
{
    public class AMXPeruInquiryburoresponsetype
    {
        public string Numberoperation { get; set; }
        public int Burocode { get; set; }
        public AMXPeruMassivetype Massiveresponse { get; set; }
        public AMXPeruCorporatetype Corporateresponse { get; set; }

    }
}
