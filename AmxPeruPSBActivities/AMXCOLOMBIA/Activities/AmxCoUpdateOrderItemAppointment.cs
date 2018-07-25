using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities
{
    public class AmxCoUpdateOrderItemAppointment : XrmAwareCodeActivity
    {
        public InArgument<Guid> orderId { get; set; }
        public InArgument<Guid> appointmentId { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var business = new AmxPeruPSBActivities.AMXCOLOMBIA.Business.AmxCoUpdateOrderItemAppointmentBusiness();
            business.AmxCoUpdateOrderItemAppointment(ContextProvider.OrganizationService, orderId.Get(context), appointmentId.Get(context));
        }
    }
}
