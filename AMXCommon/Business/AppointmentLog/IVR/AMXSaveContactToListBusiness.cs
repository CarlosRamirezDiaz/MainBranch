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
    public class AMXSaveContactToListBusiness
    {
        public AMXResponseModel GetAppointmentLogDetails(IOrganizationService service, Guid primaryId, string conListName, bool isOneDay)
        {
            var response = new AMXResponseModel();
            try
            {
                response = new AMXSaveContactToListRepository().GetAppointmentLogDetails(service, primaryId, conListName, isOneDay);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving Appoinment details", ex);
            }
            return response;
        }
    }
}


