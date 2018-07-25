using AMXCommon.Model.AppointmentLog;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMXCommon.Business.AppointmentLog
{
    public class AMXGetAppointmentDetailsBusiness
    {
        /// <summary>
        /// Get All Appointment logs based on Document Id
        /// </summary>
        /// <param name="service"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public AMXGetAppointmentDetailsResponseModel GetAppointmentLogDetails(IOrganizationService service, string documentId)
        {
            var response = new AMXGetAppointmentDetailsResponseModel();
            try
            {
                response = new Repository.AppointmentLog.AMXGetAppointmentDetailsRepository().GetAppointmentDetails(service, documentId);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving Appoinment details", ex);
            }
            return response;
        }
    }
}
