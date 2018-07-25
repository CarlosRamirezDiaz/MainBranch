using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruPSBActivities.Model.Appointment;
using System.Web.Script.Serialization;

namespace AmxPeruPSBActivities.Activities.Appointment
{

    public sealed class CreateAppointmentRequestActivity : XrmAwareCodeActivity
    {
        public InOutArgument<CreateAppointmentRequestModel> CreateAppointmentRequest { get; set; }
        public InArgument<CreateAppointmentRequestModel> CreateAppRequest { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            //var dateOrder = DateOrder.Get(context);
            var createAppRequest = CreateAppRequest.Get(context);
            var crearOrdenRequest = new CreateAppointmentRequestModel
            {
                headerRequest = createAppRequest.headerRequest,
                dateOrder = createAppRequest.dateOrder, // dateRequest.ToString("yyyy-MM-dd"), // "2017-12-11";
                commands = createAppRequest.commands
            };

            #region Commented Hardcoded values
            //Header HeaderReq = new Header()
            //{
            //    transactionId = "12345679",
            //    system = "PRUEBA",
            //    user = "YFONSECA",
            //    password = "PRUEBA",
            //    requestDate = "2017-12-04T14:20:45",
            //    ipApplication = "PRUEBA",
            //    traceabilityId = "PRUEBA"
            //};

            //AppointmentModel Appointment = new AppointmentModel()
            //{
            //    apptNumber = "_L_CO_13",
            //    workTypeLabel = "AR",
            //    timeSlot = "14-17",
            //    name = "YGZ PLA",
            //    duration = "45",
            //    cell = "96786768",
            //    phone = "855765767",
            //    address = "Calle: CL 3 Placa: 5-31 Apto: CASA Com: BOG Div: TVC",
            //    city = "BOGOTA",
            //    state = "BOGOTA DC",
            //    zip = "001",
            //    points = "1602",
            //    coordx = "-74.07778841",
            //    coordy = "4.58979588"
            //};

            //Random rnd = new Random();
            //Appointment.apptNumber = rnd.Next(2383972, 9999999)+Appointment.apptNumber;
            //Appointment.customerNumber = rnd.Next(2383972, 9999999).ToString();

            //Commands Commands = new Commands()
            //{
            //    externalId = "DCE021",
            //    appointment = Appointment
            //};

            #endregion


            //////////////// Create App. Request Log ypala ///////////
            var jsonPayLoadPostedToClaro = new JavaScriptSerializer().Serialize(crearOrdenRequest);
            Microsoft.Xrm.Sdk.Entity _logRequest = new Microsoft.Xrm.Sdk.Entity("etel_exceptionlog");
            _logRequest.Attributes.Add("etel_name", "Create_App_Test_" + DateTime.Now);
            _logRequest.Attributes.Add("etel_stacktrace", jsonPayLoadPostedToClaro);
            _logRequest.Attributes.Add("etel_sourcesystem", "PSB_AmxCoCreateAppointment_Request");
            _logRequest.Attributes.Add("etel_server", "psb_hostServer");
            _logRequest.Id = ContextProvider.OrganizationService.Create(_logRequest);
            //Logging the Payload to ExceptionLog Entity for Easy Debugging : Pre Post to EOC 
            ////////////////////

            //CreateAppointmentRequest.Set(context, crearOrdenRequest);
        }
    }
}
