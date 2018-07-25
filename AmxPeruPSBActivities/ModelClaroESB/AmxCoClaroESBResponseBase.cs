using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.ModelClaroESB
{
    public class AmxCoClaroESBResponseBase
    {
        public HeaderResponse headerResponse { get; set; }
    }

    public class HeaderResponse
    {
        public string traceabilityId { get; set; }
        public DateTime responseDate { get; set; }
    }

}
