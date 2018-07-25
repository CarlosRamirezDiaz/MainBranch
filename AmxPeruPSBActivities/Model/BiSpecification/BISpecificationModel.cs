using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.BiSpecification
{
    public class BISpecificationModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool RequiresBiHeader { get; set; }
        public bool SendNotificationToDigiturno { get; set; }
        public int DigiturnoCode { get; set; }
    }
}
