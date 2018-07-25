using AMXCommon.Model.AppointmentLog;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities.AppointmentLog
{
    public class AMXUpdateAppointmentStatus : XrmAwareCodeActivity
    {
        public InArgument<string> AppointmentNumber { get; set; }
        public InArgument<string> confirmationStatus { get; set; }
        public InArgument<string> status { get; set; }
        public InArgument<string> technicianId { get; set; }
        public InArgument<string> statusReason { get; set; }
        public OutArgument<ResponseStatus> UpdateResponse { get; set; }
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var response = new ResponseStatus();
            var appNo = AppointmentNumber.Get(context);
            var apStatus = confirmationStatus.Get(context);
            var appLogstatus = status.Get(context);
            var appTechnicianId = technicianId.Get(context);
            var appStatusReason = statusReason.Get(context);
            try
            {
                response = new AMXCommon.Business.AppointmentLog.AMXUpdateAppointmentStatusBusiness()
                    .UpdateAppointmentStatus(ContextProvider.OrganizationService, appNo, apStatus, appLogstatus, appTechnicianId, appStatusReason);
                UpdateResponse.Set(context, response);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving Appoinment details", ex);
            }
        }
    }
}
