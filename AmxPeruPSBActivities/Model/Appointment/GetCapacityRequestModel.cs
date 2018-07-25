using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Appointment
{
    public class GetCapacityRequestModel    
    {
        public Header headerRequest { get; set; }
        public string idOrder { get; set; }
        public string addressId { get; set; }
        public string documentId { get; set; }
        public string appt_number { get; set; }
        public List<string> date { get; set; }
        public List<string> location { get; set; }
        public string calculateDuration { get; set; }
        public string calculateTravelTime { get; set; }
        public string calculateWorkSkill { get; set; }
        public string returnTimeSlotInfo { get; set; }
        public string determineLocationByWorkZone { get; set; }
        public List<Fog> activityField { get; set; }
        public List<Fog> infoOrderAct { get; set; }
        public Inventory inventory { get; set; }
    }

    public class Header
    {
        public string transactionId { get; set; }
        public string system { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string requestDate { get; set; }
        public string ipApplication { get; set; }
        public string traceabilityId { get; set; }
    }

    public class Fog
    {
        public string attributeName { get; set; }
        public string attributeValue { get; set; }
    }

    public class Inventory
    {
        public string type { get; set; }
        public string manufacture { get; set; }
        public string family { get; set; }
    }
}
