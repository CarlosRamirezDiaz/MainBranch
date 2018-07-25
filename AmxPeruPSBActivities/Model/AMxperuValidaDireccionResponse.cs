using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AMxperuValidaDireccionResponse : BaseResponse
    {
        public string addressCode { get; set; }
        public string subAddressCode { get; set; }
        public string standardAddress { get; set; }
        public string departmentCode { get; set; }
        public string provinceCode { get; set; }
        public string districtCode { get; set; }
        public string street1Code { get; set; }
        public string street2 { get; set; }
        public string street3 { get; set; }
        public string street4 { get; set; }
        public string squareCode { get; set; }
        public string allotmentCode { get; set; }
        public string subAllotmentCode { get; set; }
        public string buildTypeCode { get; set; }
        public string buildType { get; set; }
        public string apartmentCode { get; set; }
        public string apartmentNumber { get; set; }
        public string urbanizationCode { get; set; }
        public string Urbanization { get; set; }
        public string zoneCode { get; set; }
        public string zone { get; set; }
        public string sectorType { get; set; }
        public string sectorDescription { get; set; }
        public string stageType { get; set; }
        public string stageDescription { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string blacklist { get; set; }
        public string dangerZone { get; set; }
        public string ruralZone { get; set; }
        public AddressExceptionType addressException { get; set; }
        public string ubigeoPopulatedcenter { get; set; }
       

    }
    public class AddressExceptionType
    {
        public string codigoRespuesta { get; set; }

        public string fechaRespuesta { get; set; }

        public string codigoError { get; set; }

        public string descripcionError { get; set; }
        public string mapaGeoManual { get; set; }
    }
}
