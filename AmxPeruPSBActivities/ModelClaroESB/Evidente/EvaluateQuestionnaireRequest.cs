using AmxCoPSBActivities.Model.Evidente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.ModelClaroESB.Evidente
{
    public class EvaluateQuestionnaireRequest
    {
        // Sample Request
        //"codeQuestionnaire" : "7060",
        //"Response" : "[{'__hashCodeCalc' : 'false','sequenceQuestion' : 17,'sequenceAnswer' : 198555},{'__hashCodeCalc' : 'false','sequenceQuestion' : 16,'sequenceAnswer' : 198551},{'__hashCodeCalc' : 'false','sequenceQuestion' : 12,'sequenceAnswer' : 198541},{'__hashCodeCalc' : 'false','sequenceQuestion' : 15,'sequenceAnswer' : 198546},{'__hashCodeCalc' : 'false','sequenceQuestion' : 49,'sequenceAnswer' : 198558}]",
        //"sequenceQuestion" : "13542601",
        //"keyCIFIN" : "523791",
        //"password" : "Claro4",
        //"withProxy" : "0"

        public string codeQuestionnaire { get; set; }
        public string Response { get; set; }
        public string sequenceQuestion { get; set; }
        public string keyCIFIN { get; set; }
        public string password { get; set; }
        public string withProxy { get; set; }

        public static EvaluateQuestionnaireRequest EvaluateQuestionnaireFactory(AmxCoEvaluateQuestionnaireRequest request, string keyCIFIN, string password)
        {
            var returnValue = new EvaluateQuestionnaireRequest();
            returnValue.codeQuestionnaire = request.codeQuestionnaire;
            returnValue.sequenceQuestion = request.questionnaireSequence;

            returnValue.keyCIFIN = keyCIFIN;
            returnValue.password = password;
            returnValue.withProxy = "0";

            var responses = new List<Response>();
            if (request.answers != null)
            {
                foreach (var item in request.answers)
                {
                    responses.Add(new Evidente.Response() { sequenceAnswer = item.sequenceAnswer, sequenceQuestion = item.sequenceQuestion });
                }
            }

            var responseString = JsonConvert.SerializeObject(responses);

            returnValue.Response = responseString.Replace('"', '\'');

            return returnValue;
        }
    }

    public class Response
    {
        public string __hashCodeCalc = "false";
        public int sequenceQuestion { get; set; }
        public int sequenceAnswer { get; set; }
    }
}
