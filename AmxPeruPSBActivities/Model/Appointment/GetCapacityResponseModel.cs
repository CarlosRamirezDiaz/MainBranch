using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Appointment
{
    public class GetCapacityResponseModel
    {
        public ResponseHeader headerResponse { get; set; }
        public List<CapacityModel> capacities { get; set; }

    }

    public class ResponseHeader
    {
        public string responseDate { get; set; }
        public string traceabilityId { get; set; }
    }
}
