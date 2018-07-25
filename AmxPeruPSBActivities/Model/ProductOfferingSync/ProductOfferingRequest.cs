using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.ProductOfferingSync
{
    public class ProductOfferingRequest
    {
        public List<ProductOffering> ProductOfferingList { get; set; }
    }

    public class ProductOffering
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public ProductSpecification ProductSpecification { get; set; }
        public List<Characteristic> CharacteristicList { get; set; }
    }

    public class ProductSpecification
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public List<CFSS> CFSSList { get; set; }
    }

    public class CFSS
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public List<Characteristic> CharacteristicList { get; set; }
    }

    public class Characteristic
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public bool Editable { get; set; }
        public string DataType { get; set; }
        public string DefaultValue { get; set; }

        public List<CharacteristicValue> CharacteristicValueList { get; set; }
    }


    public class CharacteristicValue
    {
        public string ExternalId { get; set; }
        public string Value { get; set; }
        public bool IsDefaultValue { get; set; }
    }

}
