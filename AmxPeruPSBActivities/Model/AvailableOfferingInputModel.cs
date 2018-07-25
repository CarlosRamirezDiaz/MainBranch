using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AvailableOfferingInputModel
    {
        public List<CharValue> CharList { get; set; }

        public string ParentOfferinId { get; set; }

        public string OfferTypeCode { get; set; }
    }

    public class CharValue
    {
        public string Id { get; set; }

        public string Value { get; set; }
    }
}
