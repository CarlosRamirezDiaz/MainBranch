using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model.BICreditProfile
{
    public class BICreditProfileResponse : BaseResponse
    {
        public HeaderResponse headerResponse { get; set; }
        public string isValid { get; set; }
        public string message { get; set; }
    }
    public class HeaderResponse
    {
        public DateTime responseDate { get; set; }
        public string traceabilityId { get; set; }
    }
}
