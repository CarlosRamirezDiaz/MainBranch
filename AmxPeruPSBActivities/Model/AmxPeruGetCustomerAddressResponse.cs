using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruGetCustomerAddressResponse : BaseResponse
    {
        public List<Address> listOfAddresses { get; set; }
        public int successFlag { get; set; }
    }
    public class Address
    {
        public string CustomerAddressID { get; set; }
        public int AddressType { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Ubigeo { get; set; } 
        public string AddressName { get; set; }
    }
}
