using AmxPeruPSBActivities.AMXCOLOMBIA.Model.CancelAppointment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;
using AmxPeruPSBActivities.TechnicianAppGetResource;
using System.ServiceModel;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using AmxPeruPSBActivities.Business;
using System.Net;
using System.Xml;
using System.IO;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]

    public class AmxCreateAppointmentLogTest
    {
        private Newtonsoft.Json.Formatting jsonSerializerSettings;

        [TestMethod]
        public void CancelAppointmentLog()
        {

            var header = new AmxPeruPSBActivities.AMXCOLOMBIA.Model.CancelAppointment.HeaderRequest
            {
                transactionId = "123456789",
                system = "PRUEBA",
                user = "YFONSECA",
                password = "PRUEBA",
                requestDate = "2018-01-03T14:20:45",
                ipApplication = "PRUEBA",
                traceabilityId = "PRUEBA"
            };

            var propertyList = new List<Properties>();
            propertyList.Add(new Properties
            {
                attributeName = "XA_RazonDeCancelacion",
                attributeValue = "C02 -  Solicitud del Suscriptor"
            });
            propertyList.Add(new Properties
            {
                attributeName = "XA_order_comments",
                attributeValue = "dummy xpto"
            });


            var commandList = new List<Commands>();
            commandList.Add(new Commands
            {
                externalId = "11DNA123",
                appointment = new Appointments
                {
                    apptNumber = "cancelRequestFirstTry",
                    workTypeLabel = "IN23",
                    timeSlot = "14 - 15",
                    name = "John Doe",
                    properties = propertyList
                }
            });




            var input = new Dictionary<string, object>()
            {
                {
                   
                    "cancelAppntRequest", new AmxCancelAppointmentOSBRequest
                    {
                        headerRequest =header,
                        dateOrder = "2018-01-03",
                        commands = commandList
                 }
             }
    };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxCoAppointmentCancel>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void CreateAppointmentLog()
        {
            var propertyList = new List<AmxPeruPSBActivities.Model.Appointment.Fog>();

            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "activity_notes",
                attributeValue = "PRUEBAS DE NUEVA VERSION OFSC"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Idcity",
                attributeValue = "BOG"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_FechaCreacion",
                attributeValue = "2018-03-14" // CHANGE
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Regional",
                attributeValue = "TVC"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_TipoOrdenSupervision",
                attributeValue = "TC"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "Node",
                attributeValue = "LHS"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_WorkOrderSubtype",
                attributeValue = "IN23"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Bucket",
                attributeValue = "DNA102"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Red",
                attributeValue = "Bidireccional"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_NombreNodo",
                attributeValue = "LACHES SANTA BARBARA BIDACTCS"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_NombreCompleto",
                attributeValue = "NOME COMPLETO TESTE" // CHANGE
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_DireccionActual",
                attributeValue = "Calle: CL 3 Placa: 5-31"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_SLASuscriptor",
                attributeValue = "36"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_EstadoSLA",
                attributeValue = "EN CUMPLIMIENTO"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_IndicadorEstadoSLA",
                attributeValue = "C"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_SLACumplimiento",
                attributeValue = "2"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_IndicadorReincidencias",
                attributeValue = "N"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_TipoOrdenMGW",
                attributeValue = "W"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_HogaresActivos",
                attributeValue = "0"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_EspecialistaComercial",
                attributeValue = "CRM User"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_CodigoEspecialistaComercial",
                attributeValue = "007"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Prioridad",
                attributeValue = "2"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Contacto",
                attributeValue = "prueba"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Telefonouno",
                attributeValue = "3214318140"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_NumeroMarker",
                attributeValue = "A09271640"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Marker",
                attributeValue = "1"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Confirmation_Mail",
                attributeValue = "0"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Telefonodos_Contacto",
                attributeValue = "0"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Celular",
                attributeValue = "0"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Celular2",
                attributeValue = "VALOR"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_NombreCorrespondencia",
                attributeValue = "prueba"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_OrigenOrden",
                attributeValue = "7"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Telefonodos",
                attributeValue = "3110987890" //Change
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_NumeroReincidenciasOT",
                attributeValue = "1"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_NumeroCancelaciones",
                attributeValue = "0"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_NumeroReincidenciasServicios",
                attributeValue = "0"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_NumeroReincidenciasCalidad",
                attributeValue = "0"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_TipoCliente",
                attributeValue = "31"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Estrato",
                attributeValue = "2"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_NotasUnidad",
                attributeValue = "Notas de MGL"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_EstructuraComercial",
                attributeValue = "\n<estructuraComercial><estructura><row>1</row><nivel>4</nivel><codigo>LHS</codigo><descripcion>LACHES SANTA BARBARA BIDACTCS</descripcion></estructura></estructuraComercial>\n"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_RentaCliente",
                attributeValue = "38585.00"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Saldo",
                attributeValue = "38585.00"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_UltimoPago",
                attributeValue = "38585.00"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_FechaUltimoPago",
                attributeValue = "20170515"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_InformacionCatastral",
                attributeValue = "<InfoCatastral><item1>...................................</item1><item2>SANTAFE</item2><item3>NG - NG - CBU104</item3><item4>...................................</item4></InfoCatastral>"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_Generico",
                attributeValue = "<condicionesEsoeciales ><ítem>CERTA – Certificado Alturas</ítem><ítem>TRAEX– Trabalho Especial</ítem><condicionesEsoeciales >"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_TipoConstruccion",
                attributeValue = "Apartamento"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_DireccionCorrespondencia",
                attributeValue = "CL 1 D SUR 77 05"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_CantidadServicios",
                attributeValue = "2"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_ServiciosOT",
                attributeValue = "<serviciosOt><servicio><row>1</row><codServ>U50</codServ><descripcion>Plan Internet 50 Megas</descripcion><actuales>0</actuales><cambios>1</cambios><rentaMensual>0</rentaMensual><CodActivacion>0</CodActivacion><CobroInstal>1</CobroInstal><TomasTelef>0</TomasTelef><CobroTT>0</CobroTT><TomasTV_Reinst>0</TomasTV_Reinst><CobroTTV_Reinst>0</CobroTTV_Reinst></servicio><servicio><row>2</row><codServ>LTE</codServ><descripcion>Plan Ilimitado Telefonia Fija</descripcion><actuales>0</actuales><cambios>1</cambios><rentaMensual>0</rentaMensual><CodActivacion>0</CodActivacion><CobroInstal>0</CobroInstal><TomasTelef>1</TomasTelef><CobroTT>0</CobroTT><TomasTV_Reinst>0</TomasTV_Reinst><CobroTTV_Reinst>0</CobroTTV_Reinst></servicio><servicio><row>3</row><codServ>PACK_COL_AVANZHD</codServ><descripcion>Plan Avanzada TV</descripcion><actuales>0</actuales><cambios>1</cambios><rentaMensual>0</rentaMensual><CodActivacion>0</CodActivacion><CobroInstal>0</CobroInstal><TomasTelef>0</TomasTelef><CobroTT>0</CobroTT><TomasTV_Reinst>0</TomasTV_Reinst><CobroTTV_Reinst>0</CobroTTV_Reinst></servicio><cobro><TotalRentaMens>0</TotalRentaMens><TotalInstal>3</TotalInstal><TotalTT>1</TotalTT><TotalTTV>1</TotalTTV></cobro></serviciosOt>"
            });
            propertyList.Add(new AmxPeruPSBActivities.Model.Appointment.Fog
            {
                attributeName = "XA_ServiciosAfectados",
                attributeValue = "<ServiciosAfectados><Servicio><IdCorto>1</IdCorto><IdProductoEnIntraway>4345345</IdProductoEnIntraway><NombreDelServicio>PACK_COL_AVANZHD</NombreDelServicio><DescripcionDelServicio>Plan Avanzado TV</DescripcionDelServicio><AccionARealizar>Nuevo</AccionARealizar><NumeroDeTomas>1</NumeroDeTomas><CodigoDeActivacion>00000</CodigoDeActivacion></Servicio><Servicio><IdCorto>2</IdCorto><IdProductoEnIntraway>09832j</IdProductoEnIntraway><NombreDelServicio>U50</NombreDelServicio><DescripcionDelServicio>Plan Internet 50 Megas</DescripcionDelServicio><AccionARealizar>Nuevo</AccionARealizar><NumeroDeTomas>1</NumeroDeTomas><CodigoDeActivacion>111111</CodigoDeActivacion></Servicio><Servicio><IdCorto>3</IdCorto><IdProductoEnIntraway>09832j</IdProductoEnIntraway><NombreDelServicio>LTE</NombreDelServicio><DescripcionDelServicio>Oferta Plan Ilimitado Telefonia Fija</DescripcionDelServicio><AccionARealizar>Nuevo</AccionARealizar><NumeroDeTomas>1</NumeroDeTomas><CodigoDeActivacion>22222</CodigoDeActivacion></Servicio>    </ServiciosAfectados>"
            });

            var commands = new List<AmxPeruPSBActivities.Model.Appointment.Commands>();
            commands.Add(new AmxPeruPSBActivities.Model.Appointment.Commands
            {
                externalId = "DCE021",
                appointment = new AmxPeruPSBActivities.Model.Appointment.AppointmentModel
                {
                    apptNumber = "Everis9Rest100002",
                    customerNumber = "89973879",
                    workTypeLabel = "AR",
                    timeSlot = "14-17",
                    name = "MODESTA PERNETT",
                    duration = "45",
                    cell = "3143256656",
                    phone = "3214318140",
                    address = "Calle: CL 3 Placa: 5-31 Apto: CASA Com: BOG Div: TVC",
                    city = "BOGOTA",
                    state = "BOGOTA D C",
                    zip = "001",
                    points = "1602",
                    coordX = "-74.07778841",
                    coordY = "4.58979588",
                    properties = propertyList
                }
            });

            var input = new Dictionary<string, object>()
            {
                {
                    "createAppRequest", new AmxPeruPSBActivities.Model.Appointment.CreateAppointmentRequestModel{
                        headerRequest = new AmxPeruPSBActivities.Model.Appointment.Header {
                        transactionId = "12345679", system = "PRUEBA", user = "YFONSECA",
                        password = "PRUEBA", requestDate = "2018-03-13T14:20:45",
                        ipApplication = "PRUEBA", traceabilityId = "PRUEBA"
                        },
                        dateOrder = "2018-01-15",
                        commands = commands

                    }
                }
            };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxCoCreateAppointment>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            
        }

        [TestMethod]
        public void NotifycancelAppointment()
        {
            var input = new Dictionary<string, object>()
            {
                {"workOrderId","1727272" },
                { "appointmentNumber", "0061190" },
                {"cancelDescription", "Solicitud del Suscriptor" },
                {"cancelValue", "C02" }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor < AmxPeruPSBWorkflows.AmxCoNotifyCancelAppointment> (input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void GetResource()
        {
            //XML Request

            var passwordDate = DateTime.Now.ToString("o").Remove(19, 8);

            var md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(passwordDate + "b85ed53b1b6b5c6ddf71afd69a47293e");

            byte[] hash = md5.ComputeHash(inputBytes);
            var password = ToHex(hash, false);

            AmxPeruPSBActivities.AMXCOLOMBIA.Model.GetResourceRequest Oreourcereq = new AmxPeruPSBActivities.AMXCOLOMBIA.Model.GetResourceRequest
            {

                headerRequest = new AmxPeruPSBActivities.AMXCOLOMBIA.Model.HeaderRequest
                {
                    ipApplication = "PRUEBA",
                    traceabilityId = "",
                    transactionId = "PRUEBA",
                    system = "PRUEBA",
                    password = "",
                    user = "soap",
                    requestDate = ""
                },

                company = "amx-co.test",
                id = "71188180",
                date = "2017-08-12"


            };


            var input = new Dictionary<string, object>()
            {
                {

                    "TechnicianAppGetResourceRequest", new AmxPeruPSBActivities.AMXCOLOMBIA.Model.AmxCoTechnicianAppGetResourceRequest {
                         getResourceRequest = Oreourcereq
                    }
                }
            };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);
            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxCoTechnicianAppGetResource>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public string ToHex(byte[] bytes, bool upperCase)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

            return result.ToString();
        }

        [TestMethod]
        public void GetResource1()
        {
            HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"
               <?xml version=""1.0"" encoding=""utf-8""?>

                <soap:Envelope xmlns:soap=""http:=""//schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                <soapenv:Body>
                  <v1:getResourceRequest>
                    <v1:headerRequest>
                      <v11:transactionId>PRUEBA</v11:transactionId>
                      <!--Optional:-->
                      <v11:system>PRUEBA</v11:system>
                      <!--Optional:-->
                      <v11:user>soap</v11:user>
                      <!--Optional:-->
                      <v11:password>a28734d853ebaf93a44f3049a7c957b2</v11:password>
                      <v11:requestDate>2018-02-12T16:43:50+05:00</v11:requestDate>
                      <!--Optional:-->
                      <v11:ipApplication>PRUEBA</v11:ipApplication>
                      <!--Optional:-->
                    </v1:headerRequest>
                    <!--Optional:-->
                    <v1:company>amx-co.test</v1:company>
                    <!--Optional:-->
                    <v1:id>71188180</v1:id>
                    <!--Optional:-->
                    <v1:date>2017-08-12</v1:date>
                  </v1:getResourceRequest>
                </soapenv:Body>
                </soap:Envelope>
               ");
            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    Console.WriteLine(soapResult);
                }
            }
           
            

        }
        public HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://dev.nl/Rvl.Demo.TestWcfServiceApplication/SoapWebService.asmx");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
    }
}
