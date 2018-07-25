using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System.Web.Script.Serialization;
using AmxPeruPSBActivities.AMXCOLOMBIA.Business.CancelAppointment;

namespace AmxPeruPSBActivities.Activities.Appointment
{

    public sealed class NotifyCancelAppointmentESB : XrmAwareCodeActivity
    {
        // Define an activity input argument of type string
        //public InArgument<string> Text { get; set; }
        public InArgument<string> workOrderId { get; set; }
        public InArgument<string> appointmentNumber { get; set; }
        public InArgument<string> cancelDescription { get; set; }
        public InArgument<string> cancelValue { get; set; }
        public InArgument<string> Uri { get; set; }
        public OutArgument<string> Message { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                var WorkOrderId = workOrderId.Get(context);
                var AppointmentNumber = appointmentNumber.Get(context);
                var CancelDescription = cancelDescription.Get(context);
                var CancelValue = cancelValue.Get(context);
                var uri = Uri.Get(context);

                // Obtain the runtime value of the Text input argument
                var responcemsg = AmxNotifyCancelAppointmentESBBusiness.notifyCancelAppESB(WorkOrderId, AppointmentNumber, CancelDescription, CancelValue, uri);
                Message.Set(context, responcemsg);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
