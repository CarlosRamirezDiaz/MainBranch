using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    //This Model is used for
    //fetch product characteristics
    //updating order basket
    public class ProductCharacteristicsModel
    {
        public string message { get; set; }
        public List<orderItem> listOrderItems { get; set; }
    }

    public class orderItem
    {
        public Guid guid { get; set; }
        public Guid OfferingGuid { get; set; }
        public Guid OfferingType { get; set; }
        public string name { get; set; }
        public List<Characteristics> listProdChar { get; set; }

        public Guid PriceConfigurationGuid { get; set; }
        public string DepositPrice { get; set; }
        public string RecurringPrice { get; set; }
        public string OneTimePrice { get; set; }
        public string CheckOutPrice { get; set; }
    }

    public class Characteristics
    {
        public Characteristics()
        {
            inputValue = "";
        }

        public Guid guid { get; set; }
        public Guid guidOfProdChar { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public int dataType { get; set; }
        public bool editable { get; set; }
        public string inputValue { get; set; }
        public List<CharacteristicsValue> ProdCharValues { get; set; }
        public CharacteristicsValue selectedProdCharValues { get; set; }
        public string etel_externalid { get; set; }
    }

    public class CharacteristicsValue
    {
        public Guid guid { get; set; }
        public string value { get; set; }
    }
}