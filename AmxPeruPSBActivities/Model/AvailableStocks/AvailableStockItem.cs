using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.AvailableStocks
{
    class AvailableStockItem
    {
        public string Description { get; set; }
        public string ProductSpecificationId { get; set; }
        public string CharacteristicDescription { get; set; }
        public string CharacteristicHashCode { get; set; }
        public int Status { get; set; }
        public int Quantity { get; set; }
        public string SalesOrganizationRoleName { get; set; }
        public string SalesOrganizationRoleId { get; set; }
        public string PlaceName { get; set; }
        public string PlaceId { get; set; }
        public int PlaceType { get; set; }
        public int LockingBIType { get; set; }
        public string LockingBIId { get; set; }
        public string LockingBICode { get; set; }
        public int TotalRecords { get; set; }
        public string Article { get; set; }
        public string StartSerialNumber { get; set; }
        public string EndSerialNumber { get; set; }
    }
}
