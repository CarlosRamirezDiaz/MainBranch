using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class OrderItemDataModel
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid ParentOrderItemId { get; set; }

        public string OfferingName { get; set; }

        public Guid OfferingId { get; set; }

        public ProductOfferingConfigurationPriceModel PriceConfiguration { get; set; }

    }

    public class OrderDataModel
    {
        public Guid Id { get; set; }
        public List<OrderItemDataModel> orderItems { get; set; }
    }

    public class OrderItemModel
    {
        public Guid Id { get; set; }
        public OptionSetValue amx_action { get; set; }
        public String amx_billingaccountexternalid { get; set; }
        public String amx_productsrid { get; set; }
        public String amx_popexternalid { get; set; }
        public Money etel_recurringcharge { get; set; }
        public Money etel_recurringcharge_base { get; set; }
        public Money etel_onetimecharge { get; set; }
        public Money etel_onetimecharge_base { get; set; }
        public EntityReference amx_appointmentlogid { get; set; }
        public EntityReference etel_offeringid { get; set; }
        public EntityReference etel_parentorderitemid { get; set; }
    }

    public class Internet
    {
        public Guid? OrderItemId { get; set; }
        public string ExternalId { get; set; }
        public decimal? RecurringAmount { get; set; }
    }

    public class Tv
    {
        public Guid? OrderItemId { get; set; }
        public string ExternalId { get; set; }
        public decimal? RecurringAmount { get; set; }
    }

    public class Telephony
    {
        public Guid? OrderItemId { get; set; }
        public string ExternalId { get; set; }
        public decimal? RecurringAmount { get; set; }
    }
}