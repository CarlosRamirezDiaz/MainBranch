using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model.CancelAppointment
{
    public class AmxCancelAppointmentOSBResponce
    {
       public HeaderResponse headerResponse { get; set; }
        public List<CommandsResponse> commandsResponse { get; set; }
    }
    public class AppointmentResponse
    {
        public List<Report> report { get; set; }
    }
    public class Report
    {
        public string result { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }
    public class CommandsResponse
    {
        public AppointmentResponse appointmentResponse { get; set; }
    }
    public class HeaderResponse
    {
        public string responseDate { get; set; }
        public string traceabilityId { get; set; }
    }
    //public class Head
    //{
    //    public string idTransaccion { get; set; }
    //}

    //public class Message
    //{
    //    public string result { get; set; }
    //    public string code { get; set; }
    //    public string description { get; set; }
    //}

    //public class Report
    //{
    //    public Message message { get; set; }
    //}

    //public class Appointment
    //{
    //    public Report report { get; set; }
    //}

    //public class Command
    //{
    //    public Appointment appointment { get; set; }
    //}

    //public class CommandsResponce
    //{
    //    public Command command { get; set; }
    //}

    //public class Data
    //{
    //    public CommandsResponce commands { get; set; }
    //}

    //public class AmxCancelAppointmentOSBResponce
    //{
    //    public Head head { get; set; }
    //    public Data data { get; set; }
    //}

    //public class RootObject
    //{
    //    public AmxCancelAppointmentOSBResponce reagendarOrdenResponse { get; set; }
    //}
}
