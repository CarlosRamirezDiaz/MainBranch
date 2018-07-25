using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model.CancelAppointment
{
    public class AmxNotifyCancelAppointmentESBRequest
    {
        public string Description { get; set; }
        public string Id { get; set; }
        public string interactionStatus { get; set; }
    }
    public class workOrderItem
    {
        public string id { get; set; }
    }
    public class workOrder
    {
        public string Description { get; set; }
        public string id { get; set; }
    }
}
