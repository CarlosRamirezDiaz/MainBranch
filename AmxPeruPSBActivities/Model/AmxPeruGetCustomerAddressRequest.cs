using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruGetCustomerAddressRequest : BaseRequest
    {
        public int documentType { get; set; }
        public string documentNumber { get; set; }
    }
}
