using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.DirectoryNumberRead
{
    public class GenericDirectoryNumberReadResponseModel
    {
        public string dirnum { get; set; }
        public string dnStatus { get; set; }
    }

    public class ClaroDirectoryNumberConfigResponseModel
    {
        public string PhoneNumber { get; set; }
        public string Status { set; get; }
        public string Provider { set; get; }
    }

}
