using AmxPeruPSBActivities.SendNotification;
using AmxPeruPSBActivities.Model.SendNotification;
using Microsoft.Xrm.Sdk.Client;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using ExternalApiActivities.Common;
using AmxPeruPSBActivities.Service.SendNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.SendNotification
{
    public class AmxperuSendNotification : XrmAwareCodeActivity
    {
        public InArgument<AmxperuSendNotificationRequest> request { get; set; }

        public OutArgument<AmxperuSendNotificationResponse> response { get; set; }
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                SendNotificationServiceStatus objService = new SendNotificationServiceStatus();
                Microsoft.Xrm.Sdk.Entity entity = new Microsoft.Xrm.Sdk.Entity();
                AmxperuSendNotificationResponse objResponse = objService.SendnotificationStatus(request.Get(context), ContextProvider.OrganizationService, entity);
                response.Set(context, objResponse);
            }
            catch (System.Exception ex)
            {

            }
        }

    }
}
