using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using AmxPeruPSBActivities.NotifyCancelAppointment;
namespace AmxPeruPSBActivities.AMXCOLOMBIA.Business.CancelAppointment
{
    public class AmxNotifyCancelAppointmentESBBusiness
    {
        public static string notifyCancelAppESB(string workOrderId, string appointmentNumber, string cancelDescription, string cancelValue,string uri)
        {
            try
            {
                notifyCancellationAppointmentRequest oRequest = new notifyCancellationAppointmentRequest
            {
                headerRequest = new HeaderRequestType
                {
                    channel = null,
                    idApplication = null,
                    userApplication = null,
                    userSession = null,
                    idESBTransaction = null,
                    idBusinessTransaction = null,
                    startDate = DateTime.MinValue,
                    additionalNode = null
                },
                notifyCancellationAppointmentRequest1 = new notifyCancellationAppointmentRequestType
                {
                    _workOrder = new WorkOrder
                    {
                        description = "Cancelation",
                        id = workOrderId,//"1727272",
                        interactionstatus = "CANCEL_APPT",
                        _workOrderItem = new WorkOrderItem[] { new WorkOrderItem { id = appointmentNumber } }//"0061190"
                    },
                    _workOrderItem = new WorkOrderItem { _workOrder = new WorkOrder { description = cancelDescription, id = cancelValue } },
                }
            };

            
                var binding = new BasicHttpBinding { Name = "notifycancelAppAPIServiceBindingo", OpenTimeout = new TimeSpan(0, 15, 0), CloseTimeout = new TimeSpan(0, 15, 0), ReceiveTimeout = new TimeSpan(0, 15, 0), SendTimeout = new TimeSpan(0, 15, 0), };
                binding.MaxReceivedMessageSize = Int32.MaxValue;
                binding.MaxBufferSize = Int32.MaxValue;
                //var configValue = new AmxPeruPSBActivities.Repository.ConfigurationRepository().GetString(("");
                EndpointAddress endpointAddress = new EndpointAddress(uri);


                var client = new serviceOrderPortTypeClient(binding, endpointAddress);
                var oResponse = new NotifyCancellationAppointmentResponse_TYPE { };
                client.notifyCancellationAppointment(oRequest.headerRequest, oRequest.notifyCancellationAppointmentRequest1, out oResponse);
                var Message = oResponse._responseStatus.message;
                var Code = oResponse._responseStatus.code;
                return Message;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
