using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.OrderCapture
{
    public class OrderCaptureModel
    {
        public Guid OrderCaptureId { get; set; }
        public Guid amxperu_installationaddressid { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
