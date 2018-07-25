using AmxPeruPSBActivities.Model;
using System.Collections.Generic;

namespace AmxCoPSBActivities.Model.Evidente
{
    public class AmxCoEvaluateQuestionnaireRequest : BaseResponse
    {
        public string codeQuestionnaire { get; set; }
        public string questionnaireSequence { get; set; }
        public string identificationNumber { get; set; }
        public string codeIdentificationType { get; set; }
        public List<AmxCoEvaluateQuestionnaireAnswer> answers { get; set; }
    }

    public class AmxCoEvaluateQuestionnaireAnswer
    {
        public int sequenceQuestion { get; set; }
        public int sequenceAnswer { get; set; }
    }
}
