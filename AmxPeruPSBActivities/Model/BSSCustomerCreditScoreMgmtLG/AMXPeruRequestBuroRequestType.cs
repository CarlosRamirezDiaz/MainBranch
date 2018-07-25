using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AmxPeruPSBActivities.BSS_CUSTOMER_CREDIT_SCORE_MGMT_LG_V1;

namespace AmxPeruPSBActivities.Model.BSSCustomerCreditScoreMgmtLG
{
    public class AMXPeruRequestBuroRequestType:BaseRequest
    {
        //public HeaderRequestType HeaderRequest { get; set; }
        public string Documenttype { get; set; }
        public string Documentnumber { get; set; }
        public string Lastname { get; set; }
        public string Motherlastname { get; set; }
        public string Names { get; set; }
        public AMXPeruTableconfigtype Tableconfiguration { get; set; }

    }
}
