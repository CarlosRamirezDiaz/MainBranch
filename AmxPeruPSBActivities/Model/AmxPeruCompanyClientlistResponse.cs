using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruCompanyClientlistResponse : BaseResponse
    {
        public string codeResponse { get; set; }

        public string descriptionResponse { get; set; }

        public List<CompanyType> interests { get; set; }
    }

    public class CompanyType
    {
        public string phoneNumber1 { get; set; }

        public string documentNumber { get; set; }

        public DateTime startDateTime { get; set; }

        public DateTime endDateTime { get; set; }

        public string MarketsegmentName { get; set; }

        public string status { get; set; }

        public string ID { get; set; }

        public string MarketcampaignName { get; set; }

        public string description { get; set; }
    }
}
