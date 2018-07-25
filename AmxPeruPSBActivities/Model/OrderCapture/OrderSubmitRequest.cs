using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.OrderCaptureSubmit
{
    public class SubmitOrderRequest
    {
        public string createdDate { get; set; }
        public int version { get; set; }
        public string requestedCompletionDate { get; set; }
        public string description { get; set; }
        public List<RelatedParty> relatedParties { get; set; }
        public List<RelatedEntity> relatedEntities { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public bool run { get; set; }
    }

    public class RelatedParty
    {
        public string role { get; set; }
        public string reference { get; set; }
        public Party party { get; set; }
    }

    public class Party
    {
        public CustomerInformation CustomerInformation { get; set; }
    }

    public class CustomerInformation
    {
        public List<Attribute> attributes { get; set; }
    }

    public class Attr
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Attribute
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class ContractCreationInformation
    {
        public List<Attribute> attributes { get; set; }
    }

    public class LocationInformation
    {
        public List<Attribute> attributes { get; set; }
    }

    public class AppointmentInformation
    {
        public List<Attribute> attributes { get; set; }
    }

    public class DirectoryNumberInformation
    {
        public List<Attribute> attributes { get; set; }
    }

    public class Entity
    {
        public ContractCreationInformation contractCreationInformation { get; set; }
        public LocationInformation locationInformation { get; set; }
        public AppointmentInformation appointmentInformation { get; set; }
        public DirectoryNumberInformation directoryNumberInformation { get; set; }
    }

    public class RelatedEntity
    {
        public string type { get; set; }
        public string name { get; set; }
        public string reference { get; set; }
        public string dependentEntityName { get; set; }
        public Entity entity { get; set; }
    }

    public class ProductOffering
    {
        public string id { get; set; }
    }

    public class ProductCharacteristic
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class ProductPrice
    {
        public string amount { get; set; }
        public string taxCode { get; set; }
        public string frequency { get; set; }
        public string currency { get; set; }
        public string chargeTypeCode { get; set; }
        public string popId { get; set; }
        public string priceType { get; set; }
        public List<ProductCharacteristic> characteristics { get; set; }
        public string name { get; set; }
        public string externalIds { get; set; }
        public string unitOfMeasure { get; set; }
        public string description { get; set; }
    }

    public class Product
    {
        public String productId { get; set; }
        public List<ProductCharacteristic> productCharacteristics { get; set; }
        public List<ProductPrice> productPrices { get; set; }
    }

    public class ResourceCharacteristic
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Resource
    {
        public List<ResourceCharacteristic> resourceCharacteristics { get; set; }
        public string resourceSpecification { get; set; }
        public bool isLogical { get; set; }
        public bool isCompound { get; set; }
    }

    public class Item
    {
        public string orderType { get; set; }
        public string action { get; set; }
        public string id { get; set; }


        public List<Attr> attrs { get; set; }
        public List<RelatedEntity> relatedEntities { get; set; }
        public ProductOffering productOffering { get; set; }
        public Product product { get; set; }
        public List<Resource> resources { get; set; }
        public List<RelatedOrderItem> relatedOrderItems { get; set; }
    }

    public class RelatedOrderItem
    {
        public string role { get; set; }
        public string relatedBasicPoCode { get; set; }
        public string reference { get; set; }
    }


    public class OrderItem
    {
        public Item item { get; set; }
    }

    public class SubmitOrderErrorResponse
    {
        public Fault fault { get; set; }
    }

    public class Fault
    {
        public string status { get; set; }
        public string errorCode { get; set; }
        public string reason { get; set; }
        public string details { get; set; }
    }

    public class SubmitResponseRelatedEntity
    {
        public string type { get; set; }
        public string name { get; set; }
        public string reference { get; set; }
        public string entitySpecification { get; set; }
        public string dependentEntityName { get; set; }
        public ContractCreationInformation contractCreationInformation { get; set; }
        public LocationInformation locationInformation { get; set; }
    }

    public class SubmitOrderResponse
    {
        public string id { get; set; }
        public string createdBy { get; set; }
        public string createdDate { get; set; }
        public string modifiedBy { get; set; }
        public string lastModifiedDate { get; set; }
        public string version { get; set; }
        public string description { get; set; }
        public string orderType { get; set; }
        public string requestedCompletionDate { get; set; }
        public string state { get; set; }
        public string requestedStartDate { get; set; }
        public List<RelatedParties> relatedParties { get; set; }
        public string notes { get; set; }
        public string externalID { get; set; }
        public string origOrderId { get; set; }
        public string isBundled { get; set; }
        public string orderItems { get; set; }
        public string attrs { get; set; }
        public List<SubmitResponseRelatedEntity> relatedEntities { get; set; }
        public string completionDate { get; set; }
        public string isLocked { get; set; }
        public string orderSpecification { get; set; }
        public string requester { get; set; }
        public string requestID { get; set; }
        public string mode { get; set; }
        public string relatedOrders { get; set; }
        public string interactionDate { get; set; }
    }
}
