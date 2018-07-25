using Ericsson.ETELCRM.Entities.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Mapping
{

    public class Mapping
    {
        public Order Map(XrmDataContext context, 
            etel_ordercapture CrmOrderCapture)
        {
            var omOrder = new Order();
            //TODO:Format this value
            omOrder.createdDate = CrmOrderCapture.CreatedOn.ToString();
            omOrder.version = 1;
            //TODO:What is actual completion date
            omOrder.requestedCompletionDate = DateTime.Now.AddDays(5).ToString();
            omOrder.description = string.Format(CrmOrderCapture.etel_name);

            //Load Order Items
            var orderItems = context.etel_orderitemSet
                .Where(i => i.etel_orderid.Id == CrmOrderCapture.Id)
                    .OrderBy(i => i.CreatedOn).ToList();

            return omOrder;
        }
    }
    


    public class Order
    {
        //format : "2017-08-19T19:34:07.072Z"
        public string createdDate { get; set; }
        // always = 1
        public int version { get; set; }
        public string requestedCompletionDate { get; set; }
        public string description { get; set; }
        public List<RelatedParty> relatedParties { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public bool run { get; set; }
    }

    public class RelatedParty
    {
        public string role { get; set; }
        public string reference { get; set; }
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

    public class Entity
    {
        public ContractCreationInformation contractCreationInformation { get; set; }
    }

    public class RelatedEntity
    {
        public string type { get; set; }
        public string name { get; set; }
        public string reference { get; set; }
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

    public class Product
    {
        public List<ProductCharacteristic> productCharacteristics { get; set; }
    }

    public class ResourceCharacteristic
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Resource
    {
        public List<ResourceCharacteristic> resourceCharacteristics { get; set; }
        public string resourceType { get; set; }
        public string serialNumber { get; set; }
        public string resourceSpecification { get; set; }
    }

    public class Item
    {
        public string orderType { get; set; }
        public string action { get; set; }
        public List<Attr> attrs { get; set; }
        public List<RelatedEntity> relatedEntities { get; set; }
        public ProductOffering productOffering { get; set; }
        public Product product { get; set; }
        public List<Resource> resources { get; set; }
    }

    public class OrderItem
    {
        public Item item { get; set; }
    }

    
}
