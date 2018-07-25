using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.GeneralEnquiry
{
    public class ProductCatalogSearchRequest :BaseRequest
    {
        public string LookForInputText { get; set; }
        public string OfferName { get; set; }
        public string ProductCategory { get; set; }
        public string MarketType { get; set; }
        public string PaymemtType { get; set; }
        public string EquimentName { get; set; }

    }
}
