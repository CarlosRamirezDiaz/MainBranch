using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using Microsoft.Xrm.Sdk.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Business.CancelAppointment
{
    public class AmxCancelAppointmentOSBBusiness
    {
        public static string GetOSBResponce()
        {
            string resultJson = string.Empty;
            // Initiate Rest Client
            var client = new RestClient("http://localhost:50123"); //"hosturl"
            var request = new RestRequest("/WorkOrder/V1.0/Rest/CancelAppointment");
            // Set headers, method and cookies
            request.Method = Method.PUT;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "*/*");
            // Set Data format
            request.RequestFormat = DataFormat.Json;
            // Set Data

            request.AddBody(new
            {
                AmxCancelAppointmentOSBRequest = new
                {
                    HeaderRequest = new
                    {
                        transactionId = "123456789",
                        system = "PRUEBA",
                        user = "YFONSECA",
                        password = "PRUEBA",
                        requestDate = "2017-09-20T09:50:38.129",
                        ipApplication = "PRUEBA",
                        traceabilityId = "PRUEBA"
                    },
                    dateOrder = "2017-11-15",
                    Commands = new {
                        externalId = "DNA90",
                        Appointments = new
                        {
                            apptNumber = "18173",
                            workTypeLabel = "IN23",
                            timeSlot = "14-17",
                            name = "prueba",
                            Properties = new{
                                attributeName = "XA_RazonDeCancelacion",
                                attributeValue = "C02 -  Solicitud del Suscriptor"

                            }
                        }
                     }


                },
            });
            
            try
            {
                var executeRestSharp = client.Execute(request);
                resultJson = executeRestSharp.Content;
            }
            catch (Exception ex)
            {
                throw;
            }
            return resultJson;

        }



    }
}
