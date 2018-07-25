using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities;
using static AmxPeruTest.Helpers.TestHelper;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using System.Web.Script.Serialization;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class AmxGetCustomerAddressTests
    {
        [TestMethod]
        public void GetCustomerAddressMGL() {
            var input = new Dictionary<string, object>()
            {
                //{ "headerRequest",
                //    new AmxPeruPSBActivities.AMXCOLOMBIA.Model.MGLHeaderRequest
                //    {
                //        transactionId = "12345",
                //        system = "Prueba",
                //        user = "Prueba",
                //        password = "Prueba",
                //        requestDate = "2008-09-28T20:49:45",
                //        ipApplication = "Prueba",
                //    }
                //},
                { "addressMGLRequest",
                    new AmxPeruPSBActivities.AMXCOLOMBIA.Model.cmtDireccionRequestDto
                    {
                       codigoDane = "11001000", direccion = null, segmento = "",
                       proyecto = "", isDth = true, nodoGestion ="", user ="user258", estrato = "",
                       cmtDireccionTabuladaDto = new AmxPeruPSBActivities.AMXCOLOMBIA.Model.cmtDireccionTabuladaDto {
                           idTipoDireccion = "BM",
                        dirPrincAlt = "",
                        barrio = "CORTIJO",
                        tipoViaPrincipal = "",
                        numViaPrincipal = "",
                        ltViaPrincipal = "",
                        nlPostViaP = "",
                        bisViaPrincipal = "",
                        cuadViaPrincipal = "",
                        tipoViaGeneradora = "",
                        numViaGeneradora = "",
                        ltViaGeneradora = "",
                        nlPostViaG = "",
                        bisViaGeneradora = "",
                        cuadViaGeneradora = "",
                        placaDireccion = "",
                        cpTipoNivel1 = "",
                        cpTipoNivel2 = "",
                        cpTipoNivel3 = "",
                        cpTipoNivel4 = "",
                        cpTipoNivel5 = "CASA",
                        cpTipoNivel6 = "",
                        cpValorNivel1 = "",
                        cpValorNivel2 = "",
                        cpValorNivel3 = "",
                        cpValorNivel4 = "",
                        cpValorNivel5 = "7",
                        cpValorNivel6 = "",
                        mzTipoNivel1 = "",
                        mzTipoNivel2 = "",
                        mzTipoNivel3 = "",
                        mzTipoNivel4 = "MANZANA",
                        mzTipoNivel5 = "",
                        mzValorNivel1 = "",
                        mzValorNivel2 = "",
                        mzValorNivel3 = "",
                        mzValorNivel4 = "",
                        mzValorNivel5 = "7",
                        idDirCatastro = "",
                        mzTipoNivel6 = "",
                        mzValorNivel6 = "",
                        itTipoPlaca = null,
                        itValorPlaca = null,
                        estadoDirGeo = null,
                        letra3G = null,
                        idDireccionDetallada = null
                       }
                    }
                }
            };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.AMXRetrieveCustomerAddress>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
