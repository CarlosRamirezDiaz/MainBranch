using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxCoPSBActivities.ModelClaroESB.Digiturno;
using Microsoft.Xrm.Sdk.Client;
using Newtonsoft.Json;
using AmxCoPSBActivities.Model.Digiturno;
using AmxPeruPSBActivities.Repository;

namespace AmxCoPSBActivities.BusinessClaroESB
{
    public class AmxCoDigiturnoBusiness
    {
        public string GetDigiturnoCodeFromBiSpecification(string biSpecificationName, OrganizationServiceProxy org)
        {
            var biSpecificationRepository = new BISpecificationRepository(org);

            var biSpecification = biSpecificationRepository.GetByName(biSpecificationName);

            if (biSpecification.SendNotificationToDigiturno)
                return biSpecification.DigiturnoCode.ToString();

            return string.Empty;
        }

        public DigiturnoNotifyEventTurnResponse SendStartNotificationToDigiturno(string biSpecificationName, Guid userId, string digiturnoUrl, OrganizationServiceProxy org)
        {
            try
            {
                // Check digiturno id in Bi Header
                var repository = new AMXCommon.Repository.BiHeader.BiHeaderRepository();

                var activeBiHeader = repository.GetActiveBiHeader(userId, org);

                if (activeBiHeader == null)
                {
                    throw new Exception("No BI Header open for user: " + userId.ToString());
                }

                if (!activeBiHeader.Contains("etel_channelinteractionid"))
                {
                    var response = new DigiturnoNotifyEventTurnResponse();
                    response.description = "No digiturno Id in Bi Header";
                    response.Success = true;
                    return response;
                }

                var digiturnoId = activeBiHeader.GetAttributeValue<string>("etel_channelinteractionid");
                if (string.IsNullOrEmpty(digiturnoId))
                {
                    var response = new DigiturnoNotifyEventTurnResponse();
                    response.description = "No digiturno Id in Bi Header";
                    response.Success = true;
                    return response;
                }

                var digiturnoCode = this.GetDigiturnoCodeFromBiSpecification(biSpecificationName, org);
                if (string.IsNullOrEmpty(digiturnoCode))
                {
                    var response = new DigiturnoNotifyEventTurnResponse();
                    response.description = "No digiturno definition in BiSpecification";
                    response.Success = true;
                    return response;
                }

                var request = new DigiturnoNotifyEventTurnRequest();
                request.IdEvent = (int)AmxCoPSBActivities.Model.Digiturno.EventEnum.StartAttention;
                request.IdBusinessInteraction = int.Parse(digiturnoCode);
                request.IdTurn = int.Parse(digiturnoId);

                return this.NotifyEventTurn(request, digiturnoUrl, org);
            }
            catch (Exception ex)
            {
                throw new Exception("SendNotificationToDigiturno error: " + ex.Message);
            }
        }

        public DigiturnoNotifyEventTurnResponse NotifyEventTurn(DigiturnoNotifyEventTurnRequest request, string digiturnoURL, OrganizationServiceProxy _org)
        {
            var response = new DigiturnoNotifyEventTurnResponse();

            try
            {
                var common = new AmxCoPSBActivities.BusinessClaroESB.AmxCoClaroESBCommon(_org);

                var esbRequest = new AmxCoPSBActivities.ModelClaroESB.Digiturno.NotifyEventTurnRequest();
                esbRequest.idBusinessIteration = request.IdBusinessInteraction;
                esbRequest.idEvent = request.IdEvent;
                esbRequest.idTurn = request.IdTurn;

                string jsonRequest;
                string jsonResponse;
                string error;

                if (!common.RestCall<ModelClaroESB.Digiturno.NotifyEventTurnRequest>(digiturnoURL, esbRequest, out jsonRequest, out jsonResponse, out error, "POST"))
                {
                    response.Success = false;
                    response.Error = error;
                    return response;
                }

                var responseObject = JsonConvert.DeserializeObject<ModelClaroESB.Digiturno.NotifyEventTurnResponse>(jsonResponse);

                response.code = responseObject.code;
                response.description = responseObject.description;

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error += ex.Message;
            }

            return response;
        }

        public DigiturnoUpdateUserTurnResponse UpdateUserTurn(DigiturnoUpdateUserTurnRequest request, string digiturnoURL, OrganizationServiceProxy _org)
        {
            var response = new DigiturnoUpdateUserTurnResponse();

            try
            {
                var common = new AmxCoPSBActivities.BusinessClaroESB.AmxCoClaroESBCommon(_org);

                var esbRequest = new AmxCoPSBActivities.ModelClaroESB.Digiturno.UpdateUserTurnRequest();

                //esbRequest.idTurn = request.idTurn;

                string jsonRequest;
                string jsonResponse;
                string error;

                if (!common.RestCall<ModelClaroESB.Digiturno.UpdateUserTurnRequest>(digiturnoURL, esbRequest, out jsonRequest, out jsonResponse, out error, "POST"))
                {
                    response.Success = false;
                    response.Error = error;
                    return response;
                }

                var responseObject = JsonConvert.DeserializeObject<ModelClaroESB.Digiturno.NotifyEventTurnResponse>(jsonResponse);

                //response.code = responseObject.code;
                //response.description = responseObject.description;

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error += ex.Message;
            }

            return response;
        }
    }
}
