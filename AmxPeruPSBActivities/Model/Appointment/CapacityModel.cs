using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Appointment
{
    public class CapacityModel
    {
        public string Date { get; set; }
        public string TimeSlot { get; set; }
        public string WorkSkill { get; set; }
        public int Available { get; set; }
        public int Quota { get; set; }
        public Restriction Restriction { get; set; }
    }

    public class Restriction
    {
        public string Code { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
