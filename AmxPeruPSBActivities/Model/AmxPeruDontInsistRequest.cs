using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruDontInsistRequest : BaseRequest
    {
        public bool DontInsistFlag { get; set; }
        public DateTime DontInsistDate { get; set; }
        public string Application { get; set; }
    }
}
