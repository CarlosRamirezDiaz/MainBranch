using AMXCommon.Model.AppointmentLog;
using AMXCommon.Repository.AppointmentLog;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMXCommon.Business.AppointmentLog
{
    public class AMXUpdateAppointmentStatusBusiness
    {
        public ResponseStatus UpdateAppointmentStatus(IOrganizationService service, string appNo, string appConfirmationStatus, string appLogstatus, string appTechnicianId, string appStatusReason)
        {
            var response = new ResponseStatus();
            try
            {
                response = new AMXUpdateAppointmentStatusRepository().UpdateAppointmentStatus(service, appNo, appConfirmationStatus, appLogstatus, appTechnicianId, appStatusReason);
                response = new ResponseStatus { code = 1, description = "Success" };
            }
            catch (Exception ex)
            {
                response = new ResponseStatus { code = 0, description = "Failed.Error while updating Appointment log for the customer" };
            }

            return response;
        }
    }
}
