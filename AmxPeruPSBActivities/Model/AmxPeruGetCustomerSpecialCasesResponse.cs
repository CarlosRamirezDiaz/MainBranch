using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruGetCustomerSpecialCasesResponse : BaseResponse
    {
        public List<MarketingList> specialCases { get; set; }
    }
    public class MarketingList
    {
        public string name { get; set; }
    }
}
