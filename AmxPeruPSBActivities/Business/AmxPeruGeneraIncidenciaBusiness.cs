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
using AmxPeruPSBActivities.GeneraIncidencia_V1;

namespace AmxPeruPSBActivities.Business
{
    public class AmxPeruGeneraIncidenciaBusiness
    {
        public AMxperuGeneralIncidenciaResponse AMxperuGeneralIncidencia(AMxperuGeneralIncidenciaRequest generalIncidenciaRequest, OrganizationServiceProxy orgService)
        {
            AMxperuGeneralIncidenciaResponse GeneralIncidenciaResponse = new AMxperuGeneralIncidenciaResponse();

            try
            {
                if (generalIncidenciaRequest != null)
                {                    
                    GeneraIncidencia_V1.GeneraIncidencia _client = new GeneraIncidencia_V1.GeneraIncidencia
                    {
                        HeaderRequest = new HeaderRequestType
                        {
                            Actor = "",
                            consumer = "",
                            country = "",
                            DidUnderstand = true,
                            dispositivo = "",
                            EncodedMustUnderstand = "0",
                            userId = "",
                             
                        }
                    };
                    GeneraIncidencia_V1.generarIncidenciaResponseType res = _client.generarIncidencia(
                        new GeneraIncidencia_V1.generarIncidenciaRequestType()
                    {
                       
                        
                        // businessInteractionItem = new GeneraIncidencia_V1.BusinessInteractionItem { id =  }
                        businessInteractionItem = new GeneraIncidencia_V1.BusinessInteractionItem
                        {
                            id = generalIncidenciaRequest.BusinessInteractionItem.id
                        },
                        customerProblem = new GeneraIncidencia_V1.CustomerProblem
                        {
                            severity = generalIncidenciaRequest.CustomerProblem.severity
                        },
                        customerProblemExtension = new GeneraIncidencia_V1.CustomerProblemExtension
                        {
                            _typification = generalIncidenciaRequest.CustomerProblemExtension._typification,
                            _affectedServices = generalIncidenciaRequest.CustomerProblemExtension._affectedServices,
                            _affectedZone = generalIncidenciaRequest.CustomerProblemExtension._affectedZone
                        },
                         customerSpec = new  GeneraIncidencia_V1.CustomerSpec
                         {
                             name = generalIncidenciaRequest.customerSpec.name,
                              lastName = generalIncidenciaRequest.customerSpec.lastName
                         },
                          knownProblemDescription = new GeneraIncidencia_V1.KnownProblemDescription
                          {
                               description = generalIncidenciaRequest.KnownProblemDescription.Description,
                                 name =  generalIncidenciaRequest.KnownProblemDescription.name
                          }
                          

                    });
                 //   GeneraIncidencia_V1.GeneraIncidencia generalIncidencia = new GeneraIncidencia_V1.GeneraIncidencia();
                    //  generalIncidencia.generarIncidencia();

                }
            }
            catch (Exception ex)
            {
                GeneralIncidenciaResponse._ticketRemedy= "test response";
                GeneralIncidenciaResponse.code = "001";
                GeneralIncidenciaResponse.message="success";
                //throw;

            }
            return GeneralIncidenciaResponse;
        }
    }
}
