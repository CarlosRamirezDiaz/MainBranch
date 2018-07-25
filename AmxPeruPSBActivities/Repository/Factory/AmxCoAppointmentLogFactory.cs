using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace AmxPeruPSBActivities.Repository.Factory
{
    class AmxCoAppointmentLogFactory
    {
        internal static Entity CreateEntityFrom(OrganizationServiceProxy org, AmxCoAppointmentLogModel appointmentLog)
        {
            Entity entity = new Entity("etel_appointmentlog");

            entity.Id = appointmentLog.etel_appointmentlogid;
            entity.Attributes.Add("amx_workorderid", appointmentLog.amx_workorderid);
            entity.Attributes.Add("amx_timeslot", appointmentLog.amx_timeslot);
            entity.Attributes.Add("amx_duration", appointmentLog.amx_duration);
            entity.Attributes.Add("etel_externalid", appointmentLog.etel_externalid);
            entity.Attributes.Add("etel_name", appointmentLog.etel_name);
            entity.Attributes.Add("etel_appointmentstatus", appointmentLog.etel_appointmentstatus);

            return entity;
        }

        internal static AmxCoAppointmentLogModel CreateAppointmentLogFrom(Entity entity)
        {
            var appointmentLog = new AmxCoAppointmentLogModel();

            appointmentLog.etel_appointmentlogid = entity.Id;

            if (entity.Contains("amx_workorderid"))
                appointmentLog.amx_workorderid = entity.Attributes["amx_workorderid"].ToString();
            if (entity.Contains("amx_timeslot"))
                appointmentLog.amx_timeslot = entity.Attributes["amx_timeslot"].ToString();
            if (entity.Contains("amx_duration"))
                appointmentLog.amx_duration = entity.Attributes["amx_duration"].ToString();
            if (entity.Contains("etel_externalid"))
                appointmentLog.etel_externalid = entity.Attributes["etel_externalid"].ToString();
            if (entity.Contains("etel_name"))
                appointmentLog.etel_name = entity.Attributes["etel_name"].ToString();
            if (entity.Contains("etel_appointmentstatus"))
                appointmentLog.etel_appointmentstatus = (OptionSetValue)entity.Attributes["etel_appointmentstatus"];

            return appointmentLog;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "etel_appointmentlogid"
                                                    ,"amx_workorderid"
                                                    ,"amx_timeslot"
                                                    ,"amx_duration"
                                                    ,"etel_externalid"
                                                    ,"etel_name"
                                                    ,"etel_appointmentstatus"});
            }
        }
    }
}
