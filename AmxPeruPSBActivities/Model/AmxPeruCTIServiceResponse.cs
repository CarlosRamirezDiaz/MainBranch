using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruCTIServiceResponse: BaseResponse
    {
        public string CustomerUri { get; set; }
        public int successFlag { get; set; }
    }
}
