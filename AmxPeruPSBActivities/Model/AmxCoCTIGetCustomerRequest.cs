using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxCoCTIGetCustomerRequest : BaseRequest
    {
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string ANI { get; set; }
        public int SelectOption { get; set; }
    }

    public class AmxCoCTIExistsCustomerByANIRequest : BaseRequest
    {
        public string ANI { get; set; }
    }

    public class AmxCoCTIExistsCustomerByDocumentIdRequest : BaseRequest
    {
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; }
    }
}
