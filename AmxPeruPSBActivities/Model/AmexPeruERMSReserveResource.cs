using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.ERMSReserveResource
{
    public class Actions
    {
        public bool CanSubmit { get; set; }
        public bool CanCancel { get; set; }
    }

    public class Product
    {
        public string Id { get; set; }
        public string ProductSpecificationId { get; set; }
        public string ProductSpecificationName { get; set; }
        public int ProductTrackingType { get; set; }
        public CustomFields CustomFields { get; set; }
    }

    public class CustomFields
    {
        public string PartNumber { get; set; }
        public string DateOfPurchase { get; set; }
        public string SerialStatusId { get; set; }
        public string DeliveryDate { get; set; }
    }

    public class SaveAsDraftResponse
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public List<object> Items { get; set; }
        public Actions Actions { get; set; }
    }

    public class SaveItemResponse
    {
        public string BusinessInteractionItemId { get; set; }
        public object ResponseMessage { get; set; }
    }

    public class GetProductsBySerialNumberWithSpecsResponse
    {
        public List<Product> Products { get; set; }
    }
}



