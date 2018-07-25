using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.InvoiceClarification
{
    class AmxCoGetFileDocumentaryManagerResponse
    {
        public List<string> ErrorDetail { get; set; }
        public bool error { get; set; }
        public string fileName { get; set; }
        public string base64file { get; set; }
        public string numContract { get; set; }
    }
}
