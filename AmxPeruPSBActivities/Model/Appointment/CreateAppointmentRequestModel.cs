using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Appointment
{
    public class CreateAppointmentRequestModel
    {
        public Header headerRequest { get; set; }
        public string dateOrder { get; set; }
        public List<Commands> commands { get; set; }
    }

    public class Commands
    {
        public string externalId { get; set; }
        public AppointmentModel appointment { get; set; }
    }

    public class AppointmentModel
    {
        public string apptNumber { get; set; }
        public string customerNumber { get; set; }
        public string workTypeLabel { get; set; }
        public string slaWindowStart { get; set; }
        public string slaWindowEnd { get; set; }
        public string timeSlot { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string duration { get; set; }
        public string cell { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string points { get; set; }
        public string coordX { get; set; }
        public string coordY { get; set; }
        public List<Fog> properties { get; set; }
    }
}
