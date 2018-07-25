using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.AffiliateDisaffiliate
{
    public class AffiliateDisaffilateBlacklistRequest : BaseRequest
    {
        public string ContractID { get; set; }
        public string PromotionsBlackList { get; set; }
        public string SurveysBlackList { get; set; }
        public string ClaroVASBlackList { get; set; }
        public string ExternalVASBlackList { get; set; }
    }
}
