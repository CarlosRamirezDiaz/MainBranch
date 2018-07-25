using AmxCoPSBActivities.Repository;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.Certicamara;
using Microsoft.Xrm.Sdk.Client;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Business.Certicamara
{
    public class CerticamaraBusiness
    {
        private OrganizationServiceProxy organizationService;
        private CerticamaraLogRepository _certicamaraLogRepository = null;
        private CerticamaraLogRepository certicamaraLogRepository
        {
            get
            {
                if (this._certicamaraLogRepository == null)
                    this._certicamaraLogRepository = new CerticamaraLogRepository(this.organizationService);
                return this._certicamaraLogRepository;
            }
        }

        public CerticamaraBusiness(OrganizationServiceProxy org)
        {
            this.organizationService = org;
        }

        public string GetJsonWebToken(string documentId, string fullName)
        {
            var certicamaraPayload = new CerticamaraHClientPayload();
            certicamaraPayload.DataRequestFingerPrint.cedula = documentId;
            certicamaraPayload.DataRequestFingerPrint.usuario = fullName;

            // Define const Key this should be private secret key  stored in some safe place
            string key = "CerticamaraCLARO";
            //key =  "Q2VydGljYW1hcmFDTEFSTw==";
            key = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(key));

            // Create Security key  using private key above:
            // not that latest version of JWT using Microsoft namespace instead of System
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            // Also note that securityKey length should be >256b
            // so you have to make sure that your private key has a proper length
            //
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                              (securityKey, "HS256");

            //  Finally create a Token
            var header = new JwtHeader(credentials);

            //Some PayLoad that contain information about the  customer

            
            var payload = new JwtPayload()
            {
                { "iat", certicamaraPayload.iat },
                { "exp", certicamaraPayload.exp },
                { "DataRequestFingerPrint", certicamaraPayload.DataRequestFingerPrint }
            };

            //
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            // Token to String so you can use it in your client
            var tokenString = handler.WriteToken(secToken);

            return tokenString;
        }

        public string ValidateResponse(string tokenString)
        {
            var handler = new JwtSecurityTokenHandler();

            var token = handler.ReadJwtToken(tokenString);

            var payload = token.EncodedPayload;
            if (token.EncodedPayload.Length % 4 > 0)
                payload = token.EncodedPayload.PadRight(token.EncodedPayload.Length + 4 - token.EncodedPayload.Length % 4, '=');

            var payloadJson = Encoding.UTF8.GetString(System.Convert.FromBase64String(payload));

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateFormatString = "dd/MM/yyyy HH:mm:ss"
            };
            var payloadObject = JsonConvert.DeserializeObject<HClientPayloadResponse>(payloadJson, settings);

            if (payloadObject.json.StartsWith("{"))
            {
                var responseObject = new HClientException();
                try
                {
                    responseObject = JsonConvert.DeserializeObject<HClientException>(payloadObject.json, settings);
                }
                catch (Exception ex)
                {
                    responseObject.Resultado = string.Format("Unable to parse {0}. ErrorMessage: {1}", payloadObject.json, ex.Message);
                }

                if (this.organizationService != null)
                {
                    try
                    {
                        Task.Run(() => this.certicamaraLogRepository.Create(responseObject.Codigo == "2000200", responseObject.Cedula, responseObject.Cedula, responseObject.Codigo, responseObject.Resultado, (responseObject.minuciaHuella == null ? responseObject.Nut : responseObject.minuciaHuella)));

                    }
                    catch
                    {

                    }
                }

                return responseObject.Resultado;
            }

            return payloadObject.json;
        }
    }
}
