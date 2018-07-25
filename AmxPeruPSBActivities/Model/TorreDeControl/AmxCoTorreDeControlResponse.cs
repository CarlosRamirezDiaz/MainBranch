using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model;

namespace AmxCoPSBActivities.Model.TorreDeControl
{
    public class AmxCoTorreDeControlResponse : BaseResponse
    {
        public Boolean isValid { get; set; }
        public string message { get; set; }
    }
}
