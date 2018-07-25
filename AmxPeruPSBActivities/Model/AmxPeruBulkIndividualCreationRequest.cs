using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
   public class AmxPeruBulkIndividualCreationRequest : BaseRequest
    {
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public Guid OrderCaptureID { get; set; }
        public string EncodedFile { get; set; }
    }
}
