using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruCustomerAddressRequest : BaseRequest
    {
        public int AddressType { get; set; }
        public int ZoneType { get; set; }
        public string Department { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string ZIPPostalCode { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int BlockEdifice { get; set; }
        public int ApartmentTypeInterior { get; set; }
        public int UrbanizationType { get; set; }
        public int PopulationZone { get; set; }
        public string ReferenceDescription { get; set; }
        public string CustomerAddressID { get; set; }
        public string Square { get; set; }
        public string Allotment { get; set; }
        public string Number { get; set; }
        public string Grouping { get; set; }
        //public string BillingEmail { get; set; }
        public int Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        //public int Building { get; set; }
        public int BuildType { get; set; }
        public bool Normalized { get; set; }
    }

    public class AmxPeruCustomerAddressUpdateRequest
    {
        public string CustomerAddressId { get; set; }
        public string CustomerType { get; set; }
        public int AddressType { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string AddressName { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string IndividualCustomerId { get; set; }
        public string CorporateCustomerId { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string MainPhone { get; set; }
        public string Phone2 { get; set; }
        public bool IsPrimaryAddress { get; set; }
        public string Department { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public int BuildType { get; set; }
        public string Building { get; set; }
        public string PopulationZone { get; set; }
        public string Blockediffice { get; set; }
        public string ApartmentTypeInterior { get; set; }
        public string ZoneType { get; set; }
        public string UrbanizationType { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Number { get; set; }
        public string Ubigeo { get; set; }
        public string ReferenceDescription { get; set; }
        public string Square { get; set; }
        public string Allotment { get; set; }
        public string Grouping { get; set; }
        public string Normalized { get; set; }
        public string BillingEmail { get; set; }
    }
}
