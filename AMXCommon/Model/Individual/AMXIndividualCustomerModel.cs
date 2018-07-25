using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMXCommon
{
    public class CustomerContactInformations
    {
        public List<CustomerContactInfo> customerContactInfo { get; set; }
    }
    public class CustomerContactInfo
    {
        public int contacttype { get; set; }
        public string contactinfo { get; set; }
        public string mobileInfo { get; set; }
        public string fixedlineInfo { get; set; }
        public int isprimary { get; set; }
    }
}
