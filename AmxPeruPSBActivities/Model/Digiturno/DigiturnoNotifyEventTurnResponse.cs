using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Model.Digiturno
{
    public class DigiturnoNotifyEventTurnResponse : AmxPeruPSBActivities.Model.BaseResponse
    {
        public int code { get; set; }
        public string description { get; set; }
    }
}
