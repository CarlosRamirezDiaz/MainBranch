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
    public class AMXGetAppointmentStatus : XrmAwareCodeActivity
    {
        public InArgument<string> AppointmentNumber { get; set; }
        public OutArgument<AMXGetAppointmentDetailsResponseModel> AppResponse { get; set; }
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var appNo = AppointmentNumber.Get(context);
            if (appNo != null)
            {
                var response = new AMXCommon.Business.AppointmentLog.AMXGetAppointmentStatusBusiness()
                    .GetAppointmentStatus(ContextProvider.OrganizationService, appNo);
                AppResponse.Set(context, response);
            }

        }
    }
}
