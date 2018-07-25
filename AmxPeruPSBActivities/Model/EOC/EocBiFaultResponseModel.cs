using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.EOC
{
    public class EocCwfException
    {
        public Fault fault { get; set; }
    }

    public class Fault
    {
        public CwApiError cwApiError { get; set; }
    }

    public class CwApiError
    {
        public string cwCode { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Type { get; set; }
    }
}



