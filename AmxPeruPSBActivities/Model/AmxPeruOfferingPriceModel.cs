using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruOfferingPriceModel
    {
        public string OrderId { get; set; }
        public List<Offering> OrderItemList { get; set; }              
    }

    public class Offering
    {
        public string OfferingId { get; set; }
        public string OfferingName { get; set; }
        public string OrderItemId { get; set; }
        
        public string PriceConfigurationId { get; set; }
        public string OneTimeCharge { get; set; }
        public string RecurringCharge { get; set; }
        public string Deposit { get; set; }
        public string CheckOutPrice { get; set; }  
        
        public string ResourceSIM { get; set; }
        public string ResourceMSISDN { get; set; }

        public List<Characteristic> CharacteristicList { get; set; }        
    }

    public class Characteristic
    {
        public string CharacteristicName { get; set; }
        public string CharacteristicId { get; set; }
        public List<Value> ValueList { get; set; }
    }

    public class Value
    {
        public string ValueId { get; set; }
        public string ValueText { get; set; }
    }
}
