using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class ProductOfferingConfigurationPriceModel
    {
        public ProductOfferingConfigurationPriceModel()
        {
            Deposit = string.Empty;
            OneTimeCharge = string.Empty;
            CheckOutPrice = string.Empty;
            RecurringCharge = string.Empty;
        }     

        public string PriceConfigurationId { get; set; }
        public string OfferingName { get; set; }
        public string PriceConfigurationName { get; set; }
        public string OneTimeCharge { get; set; }
        public string RecurringCharge { get; set; }
        public string Deposit { get; set; }
        public string CheckOutPrice { get; set; }
        public string OfferingId { get; set; }
        public string OrderItemId { get; set; }        
    }
}
