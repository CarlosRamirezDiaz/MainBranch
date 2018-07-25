using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruChangeSimCardGeneralResponse
    {
        public string CurrentSimCard { get; set; }
        public List<ChangeReason> ReasonList;
    }

    public class ChangeReason
    {
        string Text { get; set; }
        string Value { get; set; }
    }
}
