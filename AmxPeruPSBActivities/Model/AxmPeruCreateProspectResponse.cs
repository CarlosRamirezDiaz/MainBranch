using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AxmPeruCreateProspectResponse : BaseResponse
    {
        public int successFlag { get; set; }
        public string prospectId { get; set; }
    }
}
