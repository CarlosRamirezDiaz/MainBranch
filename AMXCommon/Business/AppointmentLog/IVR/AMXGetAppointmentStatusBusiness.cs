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
    public class AMXGetAppointmentStatusBusiness
    {
        public AMXGetAppointmentDetailsResponseModel GetAppointmentStatus(IOrganizationService service, string appNo)
        {
            var response = new AMXGetAppointmentDetailsResponseModel();
            try
            {
                response = new AMXGetAppointmentStatusRepository().GetAppointmentStatus(service, appNo);
            }
            catch (Exception ex)
            {
                response.responseStatus = new ResponseStatus { code = 0, description = "Failed.Error while updating Appointment log for the customer" };
            }

            return response;
        }
    }
}
