using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Appointment
{
    public class CreateAppointmentResponseModel
    {
        public ResponseHeader headerResponse { get; set; }
        public List<CommandsResponse> commandsResponse { get; set; }
    }

    public class CommandsResponse
    {
        public string externalId { get; set; }
        public string date { get; set; }
        public string type { get; set; }
        public AppointmentResponse appointmentResponse { get; set; }
    }

    public class AppointmentResponse
    {
        public string apptNumber { get; set; }
        public string customerNumber { get; set; }
        public string name { get; set; }
        public string aid { get; set; }
        public List<Report> report { get; set; }
    }

    public class Report
    {
        public string result { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string type { get; set; }
    }
}
