using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxCoCTIGetCustomerResponse : BaseResponse
    {
        public string CustomerUri { get; set; }
        public int successFlag { get; set; }
    }

    public class AmxCoCTIExistsCustomerByANIResponse : BaseResponse
    {
        public bool Exists { get; set; }
        public int successFlag { get; set; }
    }

    public class AmxCoCTIExistsCustomerByDocumentIdResponse : BaseResponse
    {
        public bool Exists { get; set; }
        public int successFlag { get; set; }
    }
}
