using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Business
{
    public class AmxCoUpdateOrderItemAppointmentBusiness
    {
        public void AmxCoUpdateOrderItemAppointment(OrganizationServiceProxy _org, Guid orderId, Guid appointmentId)
        {
            OrderItemRepository orderItemRepository = new OrderItemRepository(_org);

            var orderItemList = orderItemRepository.RetrieveOrderItemModelByOrder(orderId);

            foreach (OrderItemModel orderItem in orderItemList) {
                orderItem.amx_appointmentlogid = new EntityReference("etel_appointmentlog", appointmentId);
                orderItemRepository.Update(orderItem);
            }   
        }
    }
}