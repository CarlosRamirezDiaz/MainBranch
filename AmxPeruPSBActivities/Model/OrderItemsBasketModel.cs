using Ericsson.ETELCRM.Entities.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class OrderItemsBasketModel
    {
        public string message { get; set; }
        public List<OrderBasketOrderItem> listOfOrderBasketOrderItems { get; set; }
    }

    public class OrderBasketOrderItem
    {
        public Guid guid { get; set; }

        public string offeringGuid { get; set; }
        public string name { get; set; }

        public string BillingAccountId { get; set; }
        public string Currency { get; set; }
        public string DepositCharge { get; set; }
        public string CheckOutCharge { get; set; }
        public string Family { get; set; }
        public string OTSinglePlanCharge { get; internal set; }
        public string OfferTypeCode { get; set; }
        public string OfferTypeCodeValue { get; set; }
        public string OrderItemAction { get; set; }
        public string SRProductId { get; set; }
        public string ServiceId { get; set; }
        public string ActivationStartDate { get; set; }
        public string ActivationEndDate { get; set; }
        public string OneTimeCharge { get; set; }
        public string PriceType { get; set; }
        public string Period { get; set; }
        public string RecurringCharge { get; set; }
        public string SinglePlanCharge { get; set; }
        public string Taxes { get; set; }
        public bool ParentOrder { get; set; }
        public Guid ParentOrderItemId { get; set; }
        public Boolean Configurable { get; set; }
        public Boolean Configured { get; set; }



        public string ResourceMSISDN { get; set; }

        public string ResourceSIM { get; set; }
        public string ResourceId { get; set; }
        public string ResourceValue { get; set; }
        //public string ReservationId { get; set; }

        public List<OrderBasketItemProdCharacteristic> listOfOrderBasketOrderItemProdCharacteristics { get; set; }
        //public List<OrderItemPrice> listOfPrices { get; set; }
    }

    public class OrderBasketItemProdCharacteristic
    {
        public Guid guid { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }

    //public class OrderItemPrice
    //{
    //    public int PriceType { get; set; }
    //    public string Period { get; set; }
    //    public string RecurringCharge { get; set; }
    //    public string OneTimeCharge { get; set; }
    //    public string DepositCharge { get; set; }
    //    public string CheckOutCharge { get; set; }
    //}
}