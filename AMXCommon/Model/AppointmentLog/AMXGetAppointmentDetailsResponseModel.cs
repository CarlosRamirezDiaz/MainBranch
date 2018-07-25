using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMXCommon.Model.AppointmentLog
{
    public class AMXGetAppointmentDetailsResponseModel
    {        
        public List<AppointmentLog> appointmentList { get; set; }
        public ResponseStatus responseStatus { get; set; }
    }
     
    public class AppointmentLog
    {
        public string id { get; set; }
        public string appointmentNumber { get; set; }
        public string workTypeLabel { get; set; }
        public string customerName { get; set; }
        public string timeSlot { get; set; }
        public string primaryPhone { get; set; }
        public string secondaryPhone { get; set; }
        public DateTime appointmentDate { get; set; }
        public string address { get; set; }        
        public int cancelado { get; set; }
        public string appointmentStatus { get; set; }
    }

    public class ResponseStatus
    {
        public int code { get; set; }
        public string description { get; set; }
    }
}
