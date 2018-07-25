using System;
using System.Collections.Generic;

namespace AmxCoPSBActivities.ModelClaroESB.Evidente
{
    public class GetQuestionnaireResponse
    {
        public HeaderResponse headerResponse { get; set; }
        public List<ListQuestion> listQuestions { get; set; }
        public string codeQuestionnaire { get; set; }
        public string keyCIFIN { get; set; }
        public ResponseProcess responseProcess { get; set; }
        public DataThird dataThird { get; set; }
        public string questionnaireSequence { get; set; }
        public string descriptionQuestionnaire { get; set; }
        public string hashCodeCalc { get; set; }
    }

    public class HeaderResponse
    {
        public string traceabilityId { get; set; }
        public DateTime responseDate { get; set; }
    }
    public class ListQuestion
    {
        public string sequenceQuestion { get; set; }
        public List<AnswerList> answerList { get; set; }
        public string questionPosition { get; set; }
        public string textQuestion { get; set; }
        public string hashCodeCalc { get; set; }
    }

    public class ResponseProcess
    {
        public string responseCode { get; set; }
        public string descriptionCode { get; set; }
        public string hashCodeCalc { get; set; }
    }

    public class DataThird
    {
        public string identificationNumber { get; set; }
        public string codeIdentificationType { get; set; }
        public string fullName { get; set; }
        public string statusIdentification { get; set; }
        public string hashCodeCalc { get; set; }
    }
    public class AnswerList
    {
        public string textResponse { get; set; }
        public string hashCodeCalc { get; set; }
        public string sequenceQuestion { get; set; }
        public string sequenceAnswer { get; set; }
    }
}
