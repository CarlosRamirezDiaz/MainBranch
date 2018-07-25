using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AmxPeruPSBActivities.AMXCOLOMBIA

{
    public class AmxGetCustomerAddressBusiness
    {
        #region Public Methods
        /// <summary>
        /// Retrieve the Customer Address from MGL system
        /// </summary>
        /// <param name="mglRequest"></param>
        /// <param name="hostUrl"></param>
        /// <param name="headerRequest"></param>
        /// <returns></returns>
        public string GetCustomerAddress(cmtDireccionRequestDto mglRequest, string mglUser, string hostUrl, string headerRequest, OrganizationServiceProxy service)
        {
            //var serRequest = SetCMTDireccionRequest(mglRequest);
            var mglHeaderRequest = GetMGLHeaderRequest(headerRequest);
            var jsonResponse = SetCMTDireccionResponse(mglRequest, mglUser, hostUrl, mglHeaderRequest, service);
            return jsonResponse;
        }

        public string GetCustomerAddressHhpp(AmxAddressMGLHhppRequest mglRequest, string mglUser, string hostUrl, string headerRequest, OrganizationServiceProxy service)
        {
            //var serRequest = SetCMTDireccionRequest(mglRequest);
            var mglHeaderRequest = GetMGLHeaderRequest(headerRequest);
            var jsonResponse = GetHhppDireccionResponse(mglRequest, mglUser, hostUrl, mglHeaderRequest, service);
            return jsonResponse;
        }

        /// <summary>
        /// Retrieve the Customer Address from MGL system
        /// </summary>
        /// <param name="tipoRed"></param>
        /// <param name="hostUrl"></param>
        /// <param name="headerRequest"></param>
        /// <returns></returns>
        public string GetMGLTabularConfiguration(string tipoRed, string mglUser, string hostUrl, string headerRequest, OrganizationServiceProxy service)
        {
            //var serRequest = SetCMTDireccionRequest(mglRequest);
            var mglHeaderRequest = GetMGLHeaderRequest(headerRequest);
            var jsonResponse = SetMGLTabularConfigurationResponse(tipoRed, mglUser, hostUrl, mglHeaderRequest, service);
            return jsonResponse;
        }

        /// <summary>
        /// Retrieve the Customer Address from MGL system
        /// </summary>
        /// <param name="mglRequest"></param>
        /// <param name="hostUrl"></param>
        /// <param name="headerRequest"></param>
        /// <returns></returns>
        public string GetCustomerAddressMGLTechDetails(AddressMGLtechDetails mglRequest, string mglUser, string hostUrl, string headerRequest, OrganizationServiceProxy service)
        {
            //var serRequest = SetCMTDireccionRequest(mglRequest);
            var mglHeaderRequest = GetMGLHeaderRequest(headerRequest);
            var jsonResponse = SetCMTDireccionResponseMGLTechDetails(mglRequest, mglUser, hostUrl, mglHeaderRequest, service);
            return jsonResponse;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Set the MGL Header request from the CRM Configuration value 
        /// </summary>
        /// <param name="headerRequest"></param>
        /// <returns></returns>
        private MGLHeaderRequest GetMGLHeaderRequest(string headerRequest)
        {
            var jsSerializer = new JavaScriptSerializer();
            var resultRequest = jsSerializer.Deserialize(headerRequest, typeof(MGLHeaderRequest));
            return (MGLHeaderRequest)resultRequest;
        }

        /// <summary>
        /// Map the input request from UI
        /// </summary>
        /// <param name="mglRequest"></param>
        /// <returns></returns>
        private cmtDireccionRequestDto SetCMTDireccionRequest(cmtDireccionRequestDto mglRequest)
        {
            var serRequest = new cmtDireccionRequestDto
            {
                codigoDane = mglRequest.codigoDane,
                direccion = mglRequest.direccion               
            };
            return serRequest;
        }


        /// <summary>
        /// Execute the Restsharp to get the JSON reponse from MGL system with required input
        /// </summary>
        /// <param name="mglRequest"></param>
        /// <param name="hostUrl"></param>
        /// <param name="mglHeaderRequest"></param>
        /// <returns></returns>
        private string SetMGLTabularConfigurationResponse(string tipoRed, string mglUser, string hostUrl, MGLHeaderRequest mglHeaderRequest, OrganizationServiceProxy service)
        {
            string resultJson = string.Empty; string errorStr = string.Empty; string jsonRequestString = string.Empty; string jsonResponseString = string.Empty;
            // Initiate Rest Client
            var client = new RestClient(hostUrl);//"http://localhost:50002"
            var restRequestUrl = "/Address/V2.0/Rest/obtenerConfiguracionComponenteDireccion";
            var request = new RestRequest(restRequestUrl);
            // Set headers, method and cookies
            request.Method = Method.PUT;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "*/*");
            // Set Data format
            request.RequestFormat = DataFormat.Json;
            // Set Data
            request.AddBody(new
            {
                headerRequest = new
                {
                    transactionId = mglHeaderRequest.transactionId,
                    system = mglHeaderRequest.system,
                    user = mglHeaderRequest.user,
                    password = mglHeaderRequest.password,
                    requestDate = mglHeaderRequest.requestDate,
                    ipApplication = mglHeaderRequest.ipApplication
                },
                tipoRed = tipoRed
            });
            // Execute
            var watch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                jsonRequestString = request.Parameters[2].Value.ToString();
                var executeRestSharp = client.Execute(request);
                resultJson = executeRestSharp.Content;
                jsonResponseString = resultJson; //JsonConvert.SerializeObject(resultJson, Formatting.Indented);
            }
            catch (Exception ex)
            {
                errorStr = string.Format("Error while retrieving MGL Config data :: {0}", ex.Message);
            }
            var configValue = new AMXCommon.Common().RetrieveCrmConfiguration("MGL_ErrorLog", service);
            if (configValue == "yes")
            {
                var success = string.IsNullOrEmpty(errorStr);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                var logRepository = new AmxCoPSBActivities.Repository.ClaroESBLogRepository(service);
                logRepository.Create(hostUrl + restRequestUrl, success, elapsedMs, jsonRequestString, jsonResponseString, errorStr);
            }
            return resultJson;
        }

        /// <summary>
        /// Execute the Restsharp to get the JSON reponse from MGL system with required input
        /// </summary>
        /// <param name="mglRequest"></param>
        /// <param name="hostUrl"></param>
        /// <param name="mglHeaderRequest"></param>
        /// <returns></returns>
        private string SetCMTDireccionResponse(cmtDireccionRequestDto mglRequest, string mglUser, string hostUrl, MGLHeaderRequest mglHeaderRequest, OrganizationServiceProxy service)
        {
            string resultJson = string.Empty; string errorStr = string.Empty; string jsonRequestString = string.Empty; string jsonResponseString = string.Empty;
            // Initiate Rest Client
            var client = new RestClient(hostUrl);//"http://localhost:50002"
            var restRequestUrl = "/Address/V2.0/Rest/consultaDireccionGeneral";
            var request = new RestRequest(restRequestUrl);
            // Set headers, method and cookies
            request.Method = Method.PUT;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "*/*");
            // Set Data format
            request.RequestFormat = DataFormat.Json;
            // Set Data
            if (mglRequest.cmtDireccionTabuladaDto == null)
            {
                request.AddBody(new
                {
                    headerRequest = new
                    {
                        transactionId = mglHeaderRequest.transactionId,
                        system = mglHeaderRequest.system,
                        user = mglHeaderRequest.user,
                        password = mglHeaderRequest.password,
                        requestDate = mglHeaderRequest.requestDate,
                        ipApplication = mglHeaderRequest.ipApplication
                    },
                    codigoDane = mglRequest.codigoDane,
                    direccion = mglRequest.direccion,
                    segmento = mglRequest.segmento,
                    proyecto = mglRequest.proyecto,
                    isDth = mglRequest.isDth,
                    nodoGestion = mglRequest.nodoGestion,
                    user = mglUser,
                    estrato = mglRequest.estrato,
                });
            }
            else
            {

                request.AddBody(new
                {
                    headerRequest = new
                    {
                        transactionId = mglHeaderRequest.transactionId,
                        system = mglHeaderRequest.system,
                        user = mglHeaderRequest.user,
                        password = mglHeaderRequest.password,
                        requestDate = mglHeaderRequest.requestDate,
                        ipApplication = mglHeaderRequest.ipApplication
                    },
                    codigoDane = mglRequest.codigoDane,
                    direccion = mglRequest.direccion,
                    segmento = mglRequest.segmento,
                    proyecto = mglRequest.proyecto,
                    isDth = mglRequest.isDth,
                    nodoGestion = mglRequest.nodoGestion,
                    user = mglUser,
                    estrato = mglRequest.estrato,
                    direccionTabulada = new
                    {
                        idTipoDireccion = mglRequest.cmtDireccionTabuladaDto.idTipoDireccion,
                        dirPrincAlt = mglRequest.cmtDireccionTabuladaDto.dirPrincAlt,
                        barrio = mglRequest.cmtDireccionTabuladaDto.barrio,
                        tipoViaPrincipal = mglRequest.cmtDireccionTabuladaDto.tipoViaPrincipal,
                        numViaPrincipal = mglRequest.cmtDireccionTabuladaDto.numViaPrincipal,
                        ltViaPrincipal = mglRequest.cmtDireccionTabuladaDto.ltViaPrincipal,
                        nlPostViaP = mglRequest.cmtDireccionTabuladaDto.nlPostViaP,
                        bisViaPrincipal = mglRequest.cmtDireccionTabuladaDto.bisViaPrincipal,
                        cuadViaPrincipal = mglRequest.cmtDireccionTabuladaDto.cuadViaPrincipal,
                        tipoViaGeneradora = mglRequest.cmtDireccionTabuladaDto.tipoViaGeneradora,
                        numViaGeneradora = mglRequest.cmtDireccionTabuladaDto.numViaGeneradora,
                        ltViaGeneradora = mglRequest.cmtDireccionTabuladaDto.ltViaGeneradora,
                        nlPostViaG = mglRequest.cmtDireccionTabuladaDto.nlPostViaG,
                        bisViaGeneradora = mglRequest.cmtDireccionTabuladaDto.bisViaGeneradora,
                        cuadViaGeneradora = mglRequest.cmtDireccionTabuladaDto.cuadViaGeneradora,
                        placaDireccion = mglRequest.cmtDireccionTabuladaDto.placaDireccion,
                        cpTipoNivel1 = mglRequest.cmtDireccionTabuladaDto.cpTipoNivel1,
                        cpTipoNivel2 = mglRequest.cmtDireccionTabuladaDto.cpTipoNivel2,
                        cpTipoNivel3 = mglRequest.cmtDireccionTabuladaDto.cpTipoNivel3,
                        cpTipoNivel4 = mglRequest.cmtDireccionTabuladaDto.cpTipoNivel4,
                        cpTipoNivel5 = mglRequest.cmtDireccionTabuladaDto.cpTipoNivel5,
                        cpTipoNivel6 = mglRequest.cmtDireccionTabuladaDto.cpTipoNivel6,
                        cpValorNivel1 = mglRequest.cmtDireccionTabuladaDto.cpValorNivel1,
                        cpValorNivel2 = mglRequest.cmtDireccionTabuladaDto.cpValorNivel2,
                        cpValorNivel3 = mglRequest.cmtDireccionTabuladaDto.cpValorNivel3,
                        cpValorNivel4 = mglRequest.cmtDireccionTabuladaDto.cpValorNivel4,
                        cpValorNivel5 = mglRequest.cmtDireccionTabuladaDto.cpValorNivel5,
                        cpValorNivel6 = mglRequest.cmtDireccionTabuladaDto.cpValorNivel6,
                        mzTipoNivel1 = mglRequest.cmtDireccionTabuladaDto.mzTipoNivel1,
                        mzTipoNivel2 = mglRequest.cmtDireccionTabuladaDto.mzTipoNivel2,
                        mzTipoNivel3 = mglRequest.cmtDireccionTabuladaDto.mzTipoNivel3,
                        mzTipoNivel4 = mglRequest.cmtDireccionTabuladaDto.mzTipoNivel4,
                        mzTipoNivel5 = mglRequest.cmtDireccionTabuladaDto.mzTipoNivel5,
                        mzValorNivel1 = mglRequest.cmtDireccionTabuladaDto.mzValorNivel1,
                        mzValorNivel2 = mglRequest.cmtDireccionTabuladaDto.mzValorNivel2,
                        mzValorNivel3 = mglRequest.cmtDireccionTabuladaDto.mzValorNivel3,
                        mzValorNivel4 = mglRequest.cmtDireccionTabuladaDto.mzValorNivel4,
                        mzValorNivel5 = mglRequest.cmtDireccionTabuladaDto.mzValorNivel5,
                        idDirCatastro = mglRequest.cmtDireccionTabuladaDto.idDirCatastro,
                        mzTipoNivel6 = mglRequest.cmtDireccionTabuladaDto.mzTipoNivel6,
                        mzValorNivel6 = mglRequest.cmtDireccionTabuladaDto.mzValorNivel6,
                        itTipoPlaca = mglRequest.cmtDireccionTabuladaDto.itTipoPlaca,
                        itValorPlaca = mglRequest.cmtDireccionTabuladaDto.itValorPlaca,
                        estadoDirGeo = mglRequest.cmtDireccionTabuladaDto.estadoDirGeo,
                        letra3G = mglRequest.cmtDireccionTabuladaDto.letra3G,
                        idDireccionDetallada = mglRequest.cmtDireccionTabuladaDto.idDireccionDetallada
                    }
                });
            }

            // Execute
            var watch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                jsonRequestString = request.Parameters[2].Value.ToString(); 
                var executeRestSharp = client.Execute(request);
                resultJson = executeRestSharp.Content;
                jsonResponseString = resultJson; //JsonConvert.SerializeObject(resultJson, Formatting.Indented);
            }
            catch (Exception ex)
            {
                errorStr = string.Format("Error while retrieving MGL data :: {0}", ex.Message);
            }
            var configValue = new AMXCommon.Common().RetrieveCrmConfiguration("MGL_ErrorLog", service);
            if (configValue == "yes")
            {
                var success = string.IsNullOrEmpty(errorStr);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                var logRepository = new AmxCoPSBActivities.Repository.ClaroESBLogRepository(service);
                logRepository.Create(hostUrl + restRequestUrl, success, elapsedMs, jsonRequestString, jsonResponseString, errorStr);
            }
            return resultJson;
        }


        private string GetHhppDireccionResponse(AmxAddressMGLHhppRequest mglRequest, string mglUser, string hostUrl, MGLHeaderRequest mglHeaderRequest, OrganizationServiceProxy service)
        {
            string resultJson = string.Empty; string errorStr = string.Empty; string jsonRequestString = string.Empty; string jsonResponseString = string.Empty;
            // Initiate Rest Client
            var client = new RestClient(hostUrl);//"http://localhost:50002"
            var restRequestUrl = "/Address/V2.0/Rest/construirDireccionHhpp";
            var request = new RestRequest(restRequestUrl);
            // Set headers, method and cookies
            request.Method = Method.PUT;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "*/*");
            // Set Data format
            request.RequestFormat = DataFormat.Json;
            // Set Data
            request.AddBody(new
            {
                headerRequest = new
                {
                    transactionId = mglHeaderRequest.transactionId,
                    system = mglHeaderRequest.system,
                    user = mglHeaderRequest.user,
                    password = mglHeaderRequest.password,
                    requestDate = mglHeaderRequest.requestDate,
                    ipApplication = mglHeaderRequest.ipApplication
                },
                drDireccion = new
                {
                    id = mglRequest.drDireccion.id,
                    estrato = mglRequest.drDireccion.estrato,
                    barrio = mglRequest.drDireccion.barrio,
                    idSolicitud = mglRequest.drDireccion.idSolicitud,
                    idDirCatastro = mglRequest.drDireccion.idDirCatastro,
                    itTipoPlaca = mglRequest.drDireccion.itTipoPlaca,
                    itValorPlaca = mglRequest.drDireccion.itValorPlaca,
                    idTipoDireccion = mglRequest.drDireccion.idTipoDireccion,
                    dirPrincAlt = mglRequest.drDireccion.dirPrincAlt,
                    tipoViaPrincipal = mglRequest.drDireccion.tipoViaPrincipal,
                    numViaPrincipal = mglRequest.drDireccion.numViaPrincipal,
                    ltViaPrincipal = mglRequest.drDireccion.ltViaPrincipal,
                    nlPostViaP = mglRequest.drDireccion.nlPostViaP,
                    bisViaPrincipal = mglRequest.drDireccion.bisViaPrincipal,
                    cuadViaPrincipal = mglRequest.drDireccion.cuadViaPrincipal,
                    tipoViaGeneradora = mglRequest.drDireccion.tipoViaGeneradora,
                    numViaGeneradora = mglRequest.drDireccion.numViaGeneradora,
                    ltViaGeneradora = mglRequest.drDireccion.ltViaGeneradora,
                    nlPostViaG = mglRequest.drDireccion.nlPostViaG,
                    bisViaGeneradora = mglRequest.drDireccion.bisViaGeneradora,
                    cuadViaGeneradora = mglRequest.drDireccion.cuadViaGeneradora,
                    placaDireccion = mglRequest.drDireccion.placaDireccion,
                    cpTipoNivel1 = mglRequest.drDireccion.cpTipoNivel1,
                    cpTipoNivel2 = mglRequest.drDireccion.cpTipoNivel2,
                    cpTipoNivel3 = mglRequest.drDireccion.cpTipoNivel3,
                    cpTipoNivel4 = mglRequest.drDireccion.cpTipoNivel4,
                    cpTipoNivel5 = mglRequest.drDireccion.cpTipoNivel5,
                    cpTipoNivel6 = mglRequest.drDireccion.cpTipoNivel6,
                    cpValorNivel1 = mglRequest.drDireccion.cpValorNivel1,
                    cpValorNivel2 = mglRequest.drDireccion.cpValorNivel2,
                    cpValorNivel3 = mglRequest.drDireccion.cpValorNivel3,
                    cpValorNivel4 = mglRequest.drDireccion.cpValorNivel4,
                    cpValorNivel5 = mglRequest.drDireccion.cpValorNivel5,
                    cpValorNivel6 = mglRequest.drDireccion.cpValorNivel6,
                    mzTipoNivel1 = mglRequest.drDireccion.mzTipoNivel1,
                    mzTipoNivel2 = mglRequest.drDireccion.mzTipoNivel2,
                    mzTipoNivel3 = mglRequest.drDireccion.mzTipoNivel3,
                    mzTipoNivel4 = mglRequest.drDireccion.mzTipoNivel4,
                    mzTipoNivel5 = mglRequest.drDireccion.mzTipoNivel5,
                    mzValorNivel1 = mglRequest.drDireccion.mzValorNivel1,
                    mzValorNivel2 = mglRequest.drDireccion.mzValorNivel2,
                    mzValorNivel3 = mglRequest.drDireccion.mzValorNivel3,
                    mzValorNivel4 = mglRequest.drDireccion.mzValorNivel4,
                    mzValorNivel5 = mglRequest.drDireccion.mzValorNivel5,
                    mzTipoNivel6 = mglRequest.drDireccion.mzTipoNivel6,
                    mzValorNivel6 = mglRequest.drDireccion.mzValorNivel6,
                    estadoDirGeo = mglRequest.drDireccion.estadoDirGeo,
                    letra3G = mglRequest.drDireccion.letra3G,
                    dirEstado = mglRequest.drDireccion.dirEstado,
                    barrioTxtBM = mglRequest.drDireccion.barrioTxtBM
                },
                comunidad = mglRequest.comunidad,
                tipoAdicion = mglRequest.tipoAdicion,
                tipoNivel = mglRequest.tipoNivel,
                valorNivel = mglRequest.valorNivel,
                idUsuario = mglRequest.idUsuario
            });
            // Execute
            var watch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                jsonRequestString = request.Parameters[2].Value.ToString();
                var executeRestSharp = client.Execute(request);
                resultJson = executeRestSharp.Content;
                jsonResponseString = resultJson; //JsonConvert.SerializeObject(resultJson, Formatting.Indented);
            }
            catch (Exception ex)
            {
                errorStr = string.Format("Error while retrieving MGL HHpp data :: {0}", ex.Message);
            }
            var configValue = new AMXCommon.Common().RetrieveCrmConfiguration("MGL_ErrorLog", service);
            if (configValue == "yes")
            {
                var success = string.IsNullOrEmpty(errorStr);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                var logRepository = new AmxCoPSBActivities.Repository.ClaroESBLogRepository(service);
                logRepository.Create(hostUrl + restRequestUrl, success, elapsedMs, jsonRequestString, jsonResponseString, errorStr);
            }
            return resultJson;
        }



        /// <summary>
        /// Execute the Restsharp to get the JSON reponse from MGL system with required input
        /// </summary>
        /// <param name="mglRequest"></param>
        /// <param name="hostUrl"></param>
        /// <param name="mglHeaderRequest"></param>
        /// <returns></returns>
        private string SetCMTDireccionResponseMGLTechDetails(AddressMGLtechDetails mglRequest, string mglUser, string hostUrl, MGLHeaderRequest mglHeaderRequest, OrganizationServiceProxy service)
        {
            string resultJson = string.Empty; string errorStr = string.Empty; string jsonRequestString = string.Empty; string jsonResponseString = string.Empty;
            // Initiate Rest Client
            var client = new RestClient(hostUrl);//"http://localhost:50002"
            var restRequestUrl = "/Address/V2.0/Rest/consultaDireccion";
            var request = new RestRequest(restRequestUrl);
            // Set headers, method and cookies
            request.Method = Method.PUT;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "*/*");
            // Set Data format
            request.RequestFormat = DataFormat.Json;
            // Set Data
            request.AddBody(new
            {
                headerRequest = new
                {
                    transactionId = mglHeaderRequest.transactionId,
                    system = mglHeaderRequest.system,
                    user = mglHeaderRequest.user,
                    password = mglHeaderRequest.password,
                    requestDate = mglHeaderRequest.requestDate,
                    ipApplication = mglHeaderRequest.ipApplication
                },
                idDireccion = mglRequest.idDireccion,
                segmento = mglRequest.segmento,
                residencial = mglRequest.residencial,
                proyecto = mglRequest.proyecto
            });
            // Execute
            var watch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                jsonRequestString = request.Parameters[2].Value.ToString();
                var executeRestSharp = client.Execute(request);
                resultJson = executeRestSharp.Content;
                jsonResponseString = resultJson;//JsonConvert.SerializeObject(resultJson, Formatting.Indented);
            }
            catch (Exception ex)
            {
                errorStr = string.Format("Error while retrieving MGL data :: {0}", ex.Message);
            }
            var configValue = new AMXCommon.Common().RetrieveCrmConfiguration("MGL_ErrorLog", service);
            if (configValue == "yes")
            {
                var success = string.IsNullOrEmpty(errorStr);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                var logRepository = new AmxCoPSBActivities.Repository.ClaroESBLogRepository(service);
                logRepository.Create(hostUrl + restRequestUrl, success, elapsedMs, jsonRequestString, jsonResponseString, errorStr);
            }
            return resultJson;
        }


        #endregion
    }
}
