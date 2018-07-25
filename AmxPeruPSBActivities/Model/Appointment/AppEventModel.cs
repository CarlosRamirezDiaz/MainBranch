using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Appointment
{
    public class AppEventModel
    {
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Url { get; set; }
        public int AvailableTechnician { get; set; }
        public Restriction Restriction { get; set; }
    }
}
