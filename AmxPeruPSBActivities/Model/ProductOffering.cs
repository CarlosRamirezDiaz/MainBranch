using AmxCoPSBActivities.Model;
using Ericsson.ETELCRM.Entities.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class ProductOffering
    {
        public string ProductOfferingId { get; set; }
        public string ParentOfferingId { get; set; }
        public string OfferingName { get; set; }
        public int OfferTypeCode { get; set; }
        public Guid ProductSpecification { get; set; }
        public string ParentProductId { get; set; }
    }

    public class ProductOfferingFull
    {
        public string ProductOfferingId { get; set; }
        public string ParentOfferingId { get; set; }
        public string OfferingName { get; set; }
        public int OfferTypeCode { get; set; }
        public string ParentProductId { get; set; }
        public Guid ProductSpecificationId { get; set; }
        public AmxCoProductSpecificationModelFull ProductSpecification { get; set; }

    }
}
