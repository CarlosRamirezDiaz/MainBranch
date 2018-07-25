using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxCoPSBActivities.ModelClaroESB.Evidente;
using Newtonsoft.Json;
using AmxCoPSBActivities.Model.Evidente;
using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk.Client;
using AmxCoPSBActivities.Repository;

namespace AmxCoPSBActivities.BusinessClaroESB
{
    public class AmxCoEvidenteBusiness
    {
        private OrganizationServiceProxy _org;
        private ConfigurationRepository _configurationRepository;
        private ConfigurationRepository configurationRepository
        {
            get
            {
                if (this._configurationRepository == null)
                    this._configurationRepository = new ConfigurationRepository(this._org);
                return this._configurationRepository;
            }
        }

        public AmxCoEvidenteBusiness(OrganizationServiceProxy _org)
        {
            this._org = _org;
        }

        public AmxCoGetQuestionnaireResponse GetQuestionnaire(AmxCoGetQuestionnaireRequest request, string evidenteURL)
        {
            var response = new AmxCoGetQuestionnaireResponse();

            try
            {
                var common = new AmxCoPSBActivities.BusinessClaroESB.AmxCoClaroESBCommon(_org);
                var individualRepository = new IndividualCustomerRepository(_org);
                var individual = individualRepository.GetById(request.ContactId);

                if (individual.IndividualCustomerId == Guid.Empty)
                    throw new Exception("Individual Customer not found for Id: " + request.ContactId.ToString());

                if (string.IsNullOrEmpty(individual.LastName))
                    throw new Exception("Individual Customer lastname empty for Id: " + request.ContactId.ToString());

                var lastNames = individual.LastName.Trim().Split(' ');
                var lastName = lastNames[0];

                var keyCIFIN = CRMConfiguration.GetStringValue("ClaroESB_Evidente_keyCIFIN", _org);
                var password = CRMConfiguration.GetStringValue("ClaroESB_Evidente_Password", _org);

                var esbRequest = ModelClaroESB.Evidente.GetQuestionnaireRequest.GetQuestionnaireRequestFactory(request.codeQuestionnaire, individual.DocumentType, individual.DocumentNumber, individual.DocumentIssueDate, lastName, keyCIFIN, password);

                string jsonRequest;
                string jsonResponse;
                string error;

                if (!common.RestCall<ModelClaroESB.Evidente.GetQuestionnaireRequest>(evidenteURL, esbRequest, out jsonRequest, out jsonResponse, out error))
                {
                    response.Success = false;
                    response.Error = error;
                    return response;
                }

                // Response sample for testing
                //jsonResponse = System.IO.File.ReadAllText(@"ResponseSampleFiles\EvidenteGetQuestionnaireResponseWithErrorSample.txt");
                //jsonResponse = System.IO.File.ReadAllText(@"ResponseSampleFiles\EvidenteGetQuestionnaireResponseSample.txt");
                //if (individual.DocumentNumber == "1083916584")
                //    jsonResponse = this.sampleResponse;

                var responseObject = JsonConvert.DeserializeObject<ModelClaroESB.Evidente.GetQuestionnaireResponse>(jsonResponse);

                if (responseObject.dataThird == null)
                {
                    response.Success = false;
                    response.Error = responseObject.responseProcess.descriptionCode;
                    return response;
                }

                response.codeIdentificationType = responseObject.dataThird.codeIdentificationType;
                response.identificationNumber = responseObject.dataThird.identificationNumber;
                response.fullName = responseObject.dataThird.fullName;
                response.codeQuestionnaire = responseObject.codeQuestionnaire;
                response.questionnaireSequence = responseObject.questionnaireSequence;

                response.Questions = new List<Question>();
                if (responseObject.listQuestions == null)
                {
                    response.Success = false;
                    response.Error = responseObject.responseProcess.descriptionCode;
                    return response;
                }
                foreach (ListQuestion q in responseObject.listQuestions)
                {
                    var question = new Question();
                    question.sequenceQuestion = q.sequenceQuestion;
                    question.text = q.textQuestion;
                    question.answers = new List<answer>();

                    foreach (AnswerList a in q.answerList)
                    {
                        question.answers.Add(new answer() { text = a.textResponse, sequenceAnswer = a.sequenceAnswer, sequenceQuestion = a.sequenceQuestion });
                    }
                    response.Questions.Add(question);
                }
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error += ex.Message;
            }

            return response;
        }

        public AmxCoEvaluateQuestionnaireResponse EvaluateQuestionnaire(AmxCoEvaluateQuestionnaireRequest request, string evidenteURL, Guid individualId, Guid orderCaptureId)
        {
            var response = new AmxCoEvaluateQuestionnaireResponse();

            try
            {
                var common = new AmxCoPSBActivities.BusinessClaroESB.AmxCoClaroESBCommon(_org);

                var keyCIFIN = this.configurationRepository.GetString("ClaroESB_Evidente_keyCIFIN");
                var password = this.configurationRepository.GetString("ClaroESB_Evidente_Password");

                var esbRequest = EvaluateQuestionnaireRequest.EvaluateQuestionnaireFactory(request, keyCIFIN, password);

                string jsonRequest;
                string jsonResponse;
                string error;

                if (!common.RestCall<ModelClaroESB.Evidente.EvaluateQuestionnaireRequest>(evidenteURL, esbRequest, out jsonRequest, out jsonResponse, out error))
                {
                    response.Success = false;
                    response.Error = error;
                }
                else
                {
                    response.Success = true;

                    var responseObject = JsonConvert.DeserializeObject<ModelClaroESB.Evidente.EvaluateQuestionnaireResponse>(jsonResponse);

                    response.resultConfrontation = responseObject.resultConfrontation;
                    response.responseCode = responseObject.responseProcess.responseCode;
                    response.descriptionCode = responseObject.responseProcess.descriptionCode;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error += ex.Message;
            }

            if (_org != null)
            {
                try
                {
                    var rechazada = response.resultConfrontation.Equals("3");
                    var error = string.Empty;
                    if (response.Success)
                        error = response.descriptionCode;
                    else
                        error = response.Error;

                    Task.Run(() => this.logEvidente(_org, rechazada, request.codeQuestionnaire, request.questionnaireSequence, individualId, orderCaptureId, string.Empty, request.Error));
                }
                catch
                {

                }
            }
            return response;
        }

        private void logEvidente(OrganizationServiceProxy organizationService, bool success, string codeQuestionnaire, string questionnaireSequence, Guid individualId, Guid orderCaptionId, string name, string error)
        {
            var logRepository = new EvidenteLogRepository(organizationService);
            logRepository.Create(success, codeQuestionnaire, questionnaireSequence, individualId, orderCaptionId, name, error);
        }


        string sampleResponse = @"
        {
'headerResponse' : {
'responseDate' : '2018-02-21T09:58:28.123-05:00',
'traceabilityId' : '243b9da6-0c0b-462d-ba0b-6f463a84e39c'
},
'listQuestions' : [ {
'sequenceQuestion' : '74',
'answerList' : [ {
'textResponse' : 'CITIBANK',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '74',
'sequenceAnswer' : '4365498'
}, {
'textResponse' : 'Ninguna de las anteriores',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '74',
'sequenceAnswer' : '4365497'
}, {
'textResponse' : 'BANCO CORPBANCA',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '74',
'sequenceAnswer' : '4365499'
}, {
'textResponse' : 'HSBC COLOMBIA S.A.',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '74',
'sequenceAnswer' : '4365500'
} ],
'questionPosition' : '1',
'textQuestion' : '¿Con qué entidad canceló o saldó una cuenta corriente en los últimos seis meses?',
'hashCodeCalc' : 'false'
}, {
'sequenceQuestion' : '3',
'answerList' : [ {
'textResponse' : 'BANCO CORPBANCA',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '3',
'sequenceAnswer' : '4365496'
}, {
'textResponse' : 'NINGUNA DE LAS ANTERIORES',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '3',
'sequenceAnswer' : '4365493'
}, {
'textResponse' : 'COLPATRIA',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '3',
'sequenceAnswer' : '4365495'
}, {
'textResponse' : 'CITIBANK',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '3',
'sequenceAnswer' : '4365494'
} ],
'questionPosition' : '2',
'textQuestion' : '¿Con cuál de las siguientes entidades usted tiene una cuenta de ahorros?',
'hashCodeCalc' : 'false'
}, {
'sequenceQuestion' : '95',
'answerList' : [ {
'textResponse' : '3 ó MÁS',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '95',
'sequenceAnswer' : '4365508'
}, {
'textResponse' : '2',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '95',
'sequenceAnswer' : '4365507'
}, {
'textResponse' : '0',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '95',
'sequenceAnswer' : '4365505'
}, {
'textResponse' : '1',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '95',
'sequenceAnswer' : '4365506'
} ],
'questionPosition' : '3',
'textQuestion' : '¿En los ultimos seis meses, en cuantas entidades bancarias distintas tiene cuenta de ahorro?',
'hashCodeCalc' : 'false'
}, {
'sequenceQuestion' : '108',
'answerList' : [ {
'textResponse' : 'HSBC COLOMBIA S.A.',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '108',
'sequenceAnswer' : '4365512'
}, {
'textResponse' : 'COLPATRIA',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '108',
'sequenceAnswer' : '4365510'
}, {
'textResponse' : 'CONFINANCIERA S.A.',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '108',
'sequenceAnswer' : '4365511'
}, {
'textResponse' : 'Ninguna de las anteriores',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '108',
'sequenceAnswer' : '4365509'
} ],
'questionPosition' : '4',
'textQuestion' : 'En los últimos seis meses, ¿con cuál de las siguientes entidades usted tiene reestructurado un crédito de vivienda?',
'hashCodeCalc' : 'false'
}, {
'sequenceQuestion' : '79',
'answerList' : [ {
'textResponse' : 'Ninguna de las anteriores',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '79',
'sequenceAnswer' : '4365501'
}, {
'textResponse' : 'CUENTA CORRIENTE',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '79',
'sequenceAnswer' : '4365502'
}, {
'textResponse' : 'CUENTA CORRIENTE Y TARJETA DE CREDITO',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '79',
'sequenceAnswer' : '4365504'
}, {
'textResponse' : 'TARJETA DE CREDITO',
'hashCodeCalc' : 'false',
'sequenceQuestion' : '79',
'sequenceAnswer' : '4365503'
} ],
'questionPosition' : '5',
'textQuestion' : '¿Cuál o cuáles de los siguientes productos canceló o saldó con BANCO DE OCCIDENTE en los últimos seis meses?',
'hashCodeCalc' : 'false'
} ],
'codeQuestionnaire' : '7060',
'keyCIFIN' : '523791',
'responseProcess' : {
'responseCode' : '1',
'descriptionCode' : 'Cuestionario obtenido exitosamente',
'hashCodeCalc' : 'false'
},
'dataThird' : {
'identificationNumber' : '1083916584',
'codeIdentificationType' : '1',
'fullName' : 'ARANDA MONTES JENYFER ALEJANDRA',
'statusIdentification' : 'VIGENTE',
'hashCodeCalc' : 'false'
},
'questionnaireSequence' : '13604632',
'descriptionQuestionnaire' : 'CONFRONTA PRUEBAS TELMEX',
'hashCodeCalc' : 'false'
}";

    }
}