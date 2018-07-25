using AmxPeruPSBActivities.Model.CustomerCampaign;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Service.CustomerCampaign
{
    public class CustomerCampaignService
    {
        public CustomerCampaignResponse GetCustomerCampaignList(CustomerCampaignRequest custCampaignRequest, OrganizationServiceProxy organizationService)
        {
            CustomerCampaignResponse custCampaignResponse = new CustomerCampaignResponse();
            try
            {


                ///Todo: there is error in the: ListaCampaniaCliente_V1.WSDL.  proxy creation not possible.
                ///creation of mock data in following section.  for test purpose following code wirtten 
                ///there no relation with  tcrm request to claro request object and claro  response to  tcrm response


                List<CampanaType> objListCampanaType = new List<CampanaType>();


                Random random = new Random();
                var ctr = random.Next(2, 5);
                for (int i = 0; i < ctr; i++)
                {
                    CampanaType campanaType = new CampanaType()
                    {
                        Canal_Aplicable = "test" + i.ToString(),
                        Codigo_Campana = "test data" + i.ToString(),
                        Descripcion_Campana = "desc" + i.ToString(),
                        Estado_Campana = "estado" + i.ToString(),
                        Fecha_Campana_Fin = DateTime.Now.AddMonths(i),
                        Fecha_Campana_Inicio = DateTime.Now.AddMonths((-1) * i),
                        Nombre_Campana = i.ToString(),
                        Numero_Telefono = random.Next(100000, 3000300).ToString(),
                        Num_Document = random.Next(2000, 3000).ToString()

                    };
                    objListCampanaType.Add(campanaType);
                }

               
                custCampaignResponse.ListaCampana.AddRange( objListCampanaType);
                custCampaignResponse.CodigoRespuesta = "OK";
                custCampaignResponse.DescripcionRespuesta = "Service running fine ";


                return custCampaignResponse;


            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
