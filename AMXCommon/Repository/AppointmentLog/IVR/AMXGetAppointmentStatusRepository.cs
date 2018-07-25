using AMXCommon.Model.AppointmentLog;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMXCommon.Repository.AppointmentLog
{
    public class AMXGetAppointmentStatusRepository
    {
        public AMXGetAppointmentDetailsResponseModel GetAppointmentStatus(IOrganizationService service, string appNo)
        {
            var response = new AMXGetAppointmentDetailsResponseModel(); 
            response.appointmentList = new List<AMXCommon.Model.AppointmentLog.AppointmentLog>();

            QueryExpression query = new QueryExpression
            {
                EntityName = "etel_appointmentlog", 
                ColumnSet = new ColumnSet(new string[] { "etel_appointmentlogid", "amx_appointmentnumber", "amx_confirmationstatus", "etel_appointmentstatus" }),
                Criteria = { Conditions = { new ConditionExpression("amx_appointmentnumber", ConditionOperator.Equal, appNo) } }
            };
            try
            {
                var entityCollection = service.RetrieveMultiple(query);
                foreach (var en in entityCollection.Entities)
                {
                    response.appointmentList.Add(new Model.AppointmentLog.AppointmentLog
                    {
                        appointmentNumber = en.Contains("amx_appointmentnumber") ? en["amx_appointmentnumber"].ToString() : "",
                        appointmentStatus = en.Contains("etel_appointmentstatus") ? en.FormattedValues["etel_appointmentstatus"] : ""
                    });
                }
                response.responseStatus = new ResponseStatus { code = 1, description = "Success" };
            }
            catch (Exception ex)
            {
                response.responseStatus = new ResponseStatus { code = 0, description = "Failed. Error while retrieving Appointment log for the customer" };
            }

            return response;
        }
    }
}
