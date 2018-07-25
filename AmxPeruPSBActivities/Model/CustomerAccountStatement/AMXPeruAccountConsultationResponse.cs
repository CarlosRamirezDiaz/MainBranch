using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.CustomerAccountStatement
{
    public class AMXPeruAccountConsultationResponse : BaseResponse
    {
        public List<AMXPruStateCountType> XtAccountStatus { get; set; }
        public string ReplyCode { get; set; }
        public string ResponseDescription { get; set; }

    }
}
