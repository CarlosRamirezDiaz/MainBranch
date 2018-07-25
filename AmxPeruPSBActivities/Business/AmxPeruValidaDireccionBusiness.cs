using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AmxPeruPSBActivities.Business
{
   public class AmxPeruValidaDireccionBusiness
    {
        public AMxperuValidaDireccionResponse AmxperuValidaDireccion(AMxperuValidaDireccionRequest _AMxperuValidaDireccionRequest, OrganizationServiceProxy orgservice)
        {
            AMxperuValidaDireccionResponse _AmxperuValidaDireccionResponse = null;
            try
            {
                if (_AMxperuValidaDireccionRequest != null)
                {

                    AMxperuValidaDireccionResponse validateresponse = new AMxperuValidaDireccionResponse()
                    {
                        addressCode= "addressCode",
                        subAllotmentCode= "subAllotmentCode",
                        standardAddress= "standardAddress",
                        departmentCode = "departmentCode",
                        provinceCode = "provinceCode",
                        districtCode = "districtCode",
                        street1Code = "street1Code",
                        street2 = "street2",
                        street3 = "street3",
                        street4 = "street4",
                        squareCode = "squareCode",
                        allotmentCode = "allotmentCode",
                        buildTypeCode = "buildTypeCode",
                        buildType = "buildType",
                        apartmentCode = "apartmentCode",
                        apartmentNumber = "apartmentNumber",
                        urbanizationCode = "urbanizationCode",
                        Urbanization = "Urbanization",
                        zoneCode = "zoneCode",
                        zone = "zone",
                        sectorType = "sectorType",
                        sectorDescription = "sectorDescription",
                        stageType = "stageType",
                        stageDescription = "stageDescription",
                        latitude = "latitude",
                        longitude = "longitude",
                        blacklist = "blacklist",
                        dangerZone = "dangerZone",
                        ruralZone = "ruralZone",
                        subAddressCode= "subAddressCode",
                        Error= "No Error Found",
                        Status="OK",
                        ubigeoPopulatedcenter= "ubigeoPopulatedcenter",
                        
                        addressException = new AddressExceptionType()
                       {
                            codigoError= "codigoError",
                            codigoRespuesta= "codigoRespuesta",
                            descripcionError= "descripcionError",
                            fechaRespuesta= "fechaRespuesta",
                            mapaGeoManual= "mapaGeoManual"
                       }
                    };
                    _AmxperuValidaDireccionResponse= validateresponse;
                }
                return _AmxperuValidaDireccionResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
