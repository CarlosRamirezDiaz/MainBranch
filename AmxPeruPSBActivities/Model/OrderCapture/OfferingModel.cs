using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.OrderCapture
{
    public class OfferingRequestModel
    {
        public string OfferingTypeCode { get; set; }
        public string OfferName { get; set; }
        public string OfferId { get; set; }
        public string Family { get; set; }
        public string SpecialCase { get; set; }
        public string Campaign { get; set; }
        public string Location { get; set; }
    }

    public class OfferingModel
    {
        public List<ProductOfferingItem> ListOfOfferings { get; set; }
        public string Status { get; set; }
        public string Count { get; set; }
    }

    public class ProductOfferingItem
    {
        public string OfferingName { get; set; }
        public string OfferingTypeCode { get; set; }
        public string OfferingTypeText { get; set; }
        public string SubOfferingTypeCode { get; set; }
        public string SubOfferingTypeText { get; set; }
        public string OfferingId { get; set; }
        public string ParentOfferingGuid { get; set; }
        public string ExternalId { get; set; }
        public string Family { get; set; }
        public string Technology { get; set; }
        public bool IsSelleable { get; set; }
        public bool IsBasicPO { get; set; }
        public List<OneTime> OneTime{ get; set; }
        public List<Recurring> Recurring{ get; set; }
        public List<Deposit> Deposit{ get; set; }
        public List<Checkout> Checkout{ get; set; }
        public string Currency { get; set; }
    }

    public class OneTime
    {
        public decimal? Amount { get; set; }
        public string Period { get; set; }
        public string PopExternalId { get; set; }
    }

    public class Recurring
    {
        public decimal? Amount { get; set; }
        public string Period { get; set; }
        public string PopExternalId { get; set; }
    }

    public class Deposit
    {
        public decimal? Amount { get; set; }
        public string Period { get; set; }
        public string PopExternalId { get; set; }
    }

    public class Checkout
    {
        public decimal? Amount { get; set; }
        public string Period { get; set; }
        public string PopExternalId { get; set; }
    }

    public class ProductCharacteristicModel // etel_productcharacteristic
    {
        public Guid etel_productcharacteristicid { get; set; }
        public string etel_externalid { get; set; }
    }

    public class ProductCharacteristicUseModel // etel_productcharacteristicuse
    {
        public Guid etel_productcharacteristicuseid { get; set; }
        public string etel_name { get; set; }
        public EntityReference etel_productcharacteristicid { get; set; }
    }

    public class ProductCharacteristicValueModel // etel_productcharacteristicvalue
    {
        public Guid etel_productcharacteristicvalueid { get; set; }
        public string etel_name { get; set; }
        public EntityReference etel_productcharacteristicid { get; set; }
    }

    public class ProductCharacteristicValueUseModel // etel_productcharacteristicvalueuse
    {
        public Guid etel_productcharacteristicvalueuseid { get; set; }
        public string etel_name { get; set; }
        public EntityReference etel_productcharacteristicuseid { get; set; }
    }

    public class ProductOfferingCharUseModel // amxperu_productofferingcharuse
    {
        public Guid amxperu_productofferingcharuseid { get; set; }
        public string amxperu_name { get; set; }
        public EntityReference amxperu_productoffering { get; set; }
    }

    public class ProductOfferingCharValueUseModel // amxperu_productofferingcharvalueuse
    {
        public Guid amxperu_productofferingcharvalueuseid { get; set; }
        public string amxperu_name { get; set; }
        public EntityReference amxperu_productofferingcharuse { get; set; }
        public EntityReference amxperu_value { get; set; }
    }
}