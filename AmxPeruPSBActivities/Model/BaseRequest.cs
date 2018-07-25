using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class BaseRequest
    {
        public string Channel { get; set; }
        public string CustomerExternalId { get; set; }

        public int CustomerType { get; set; }
    }
}