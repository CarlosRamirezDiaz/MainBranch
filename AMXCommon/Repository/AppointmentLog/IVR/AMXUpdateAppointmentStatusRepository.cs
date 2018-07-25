using AMXCommon.Model.AppointmentLog;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMXCommon.Repository.AppointmentLog
{
    public class AMXUpdateAppointmentStatusRepository
    {
        public ResponseStatus UpdateAppointmentStatus(IOrganizationService service, string appNo, string appConfirmationStatus, string appLogstatus, string appTechnicianId, string appStatusReason)
        {
            var response = new ResponseStatus();
            try
            {
                Entity appointmentLog = new Entity("etel_appointmentlog", "amx_appointmentnumber", appNo); 
                if(appConfirmationStatus != null && appConfirmationStatus.Trim() != "")
                    appointmentLog["amx_confirmationstatus"] = appConfirmationStatus.ToLower() == "confirmed" ? new OptionSetValue(173800000) : appConfirmationStatus.ToLower() == "pending" ? new OptionSetValue(173800001) : appConfirmationStatus.ToLower() == "cancelled" ? new OptionSetValue(100000000) : null;

                if(appTechnicianId != null && appTechnicianId.Trim() != "")
                    appointmentLog["amx_technicianid"] = appTechnicianId == null || appTechnicianId == "" ? "" : appTechnicianId;
                if (appLogstatus != null && appLogstatus.Trim() != "")
                    appointmentLog["etel_appointmentstatus"] = SetAppointmentStatus(appLogstatus);
                if (appLogstatus != null && appLogstatus != "" && appLogstatus != "-")
                    appointmentLog["statuscode"] = SetStatusReason(appStatusReason);
                service.Update(appointmentLog);
                response = new ResponseStatus { code = 1, description = "Success" };
            }
            catch (Exception ex) {
                response = new ResponseStatus { code= 0, description= "Failed.Error while updating Appointment log for the customer" };
            }

            return response;
        }

        private object SetStatusReason(string appStatusReason)
        {
            object reason = null;
            switch (appStatusReason)
            {
                case "C02-Subscriber's request":
                    reason = 100000000;
                    break;
                case "C03-Technical breach":
                    reason = 100000001;
                    break;
                case "C04-Lack of Management Permits":
                    reason = 100000002;
                    break;
                case "C05-Massive Incident Still Open":
                    reason = 100000003;
                    break;
                case "C06-Lack of Materials / Equipment":
                    reason = 100000004;
                    break;
                default:
                    reason = 1;
                    break;
            }
            return reason == null ? null : new OptionSetValue(Convert.ToInt32(reason));

        }

        private object SetAppointmentStatus(string milestoneType) {
            object reason = null;
            switch (milestoneType.ToLower()) {
                case "initiate_visit":
                    reason = 831260000;
                        break;
                case "hard_close":
                    reason = 831260001;
                    break;
                case "notifycancellation":
                    reason = 831260002;
                    break;
                case "tech_routing":
                    reason = 831260003;
                    break;
                case "assign_equip":
                    reason = 831260004;
                    break;
                case "soft_close":
                    reason = 831260005;
                    break;
                case "not_done":
                    reason = 831260006;
                    break;
                case "notifysuspendworkorder":
                    reason = 831260007;
                    break;                    
            }
            return reason == null ? null : new OptionSetValue(Convert.ToInt32(reason));
        }

    }
}
