using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruBlacklistRequest :BaseRequest
    {
        public int BlacklistStatus { get; set; }
        
        public string BlacklistStatusReason { get; set; }
    }
}
