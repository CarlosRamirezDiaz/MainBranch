using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model
{
    public class AmxCoAppointmentLogModel
    {
        public Guid etel_appointmentlogid { get; set; }
        public String amx_workorderid { get; set; }
        public String amx_timeslot { get; set; }
        public String amx_duration { get; set; }
        public String etel_externalid { get; set; }
        public String etel_name { get; set; }
        public OptionSetValue etel_appointmentstatus { get; set; }
    }
}
