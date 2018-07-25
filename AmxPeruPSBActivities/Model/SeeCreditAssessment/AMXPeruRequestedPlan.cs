using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.SeeCreditAssessment
{
    public class AMXPeruRequestedPlan
    {
        public double Fixedcharge { get; set; }
        public string Description { get; set; }
        public string Groups { get; set; }
        public string Package { get; set; }
        public AMXPeruTypeService Service { get; set; }
    }
}
