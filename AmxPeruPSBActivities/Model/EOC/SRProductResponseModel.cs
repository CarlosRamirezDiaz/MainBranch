using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.EOC
{
    public class SRProductResponseModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string productSerialNumber { get; set; }
        public SRProductOffering productOffering { get; set; }
        public List<ProductRelationships> productRelationships { get; set; }
        public ValidDates validFor { get; set; }
    }

    public class ProductRelationships
    {
        public string type { get; set; }
        public SRProductOffering product { get; set; }
    }

    public class SRProductOffering
    {
        public string id { get; set; }
    }

    public class ValidDates
    {
        public string start { get; set; }
        public string end { get; set; }
    }
}
