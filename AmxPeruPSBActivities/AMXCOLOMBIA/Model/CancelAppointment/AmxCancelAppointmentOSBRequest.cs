using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model.CancelAppointment
{
    public class AmxCancelAppointmentOSBRequest
    {
        public HeaderRequest headerRequest { get; set; }
        public string dateOrder { get; set; }
        public List<Commands> commands { get; set; }
    }
    public class Commands
    {
        public string externalId { get; set; }
        public Appointments appointment { get; set; }
        

    }
    public class Appointments
    {
       
        public string apptNumber { get; set; }
        public string workTypeLabel { get; set; }
        public string timeSlot { get; set; }
        public string name { get; set; }
        public List<Properties> properties { get; set; }
    }
    public class Properties
    {
        public string attributeName { get; set; }
        public string attributeValue { get; set; }
    }
    public class HeaderRequest
    {
        public string transactionId { get; set; }
        public string system { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string requestDate { get; set; }
        public string ipApplication { get; set; }
        public string traceabilityId { get; set; }
    }
}
