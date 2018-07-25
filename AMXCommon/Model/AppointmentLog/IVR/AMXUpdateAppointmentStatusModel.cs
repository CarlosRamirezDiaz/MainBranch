using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMXCommon.Model.AppointmentLog
{
   public class AMXUpdateAppointmentStatusModel
    {
        public string workOrderId { get; set; } 
        public string confirmationStatus { get; set; } 
    }
}
