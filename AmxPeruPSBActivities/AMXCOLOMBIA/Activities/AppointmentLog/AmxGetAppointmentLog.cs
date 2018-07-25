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
    public class AmxGetAppointmentLog : XrmAwareCodeActivity
    {
        public InArgument<string> ClientIdentificationNo { get; set; }
        public OutArgument<AMXGetAppointmentDetailsResponseModel> AppGetResponse { get; set; }
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var documentId = ClientIdentificationNo.Get(context);
            if (documentId != null) {
                var response = new AMXCommon.Business.AppointmentLog.AMXGetAppointmentDetailsBusiness()
                    .GetAppointmentLogDetails(ContextProvider.OrganizationService, documentId);
                AppGetResponse.Set(context, response);
            }           

        }

    }
}
