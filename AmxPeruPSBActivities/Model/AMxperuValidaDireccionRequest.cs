using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
   public class AMxperuValidaDireccionRequest : BaseRequest
    {
        public string departmentCode { get; set; }
        public string provinceCode { get; set; }
        public string districtCode { get; set; }
        public string codePopulatedcenter { get; set; }
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
        public string urbanization { get; set; }
        public string zoneCode { get; set; }
        public string zone { get; set; }
        public string sectorType { get; set; }
        public string sectorDescription { get; set; }
        public string stageType { get; set; }
        public string stageDescription { get; set; }

    }
}


