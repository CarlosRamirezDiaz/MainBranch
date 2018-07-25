using AmxPeruPSBActivities.Model;
using System.Collections.Generic;

namespace AmxCoPSBActivities.Model.Evidente
{
    public class AmxCoGetQuestionnaireResponse : BaseResponse
    {
        public string codeQuestionnaire { get; set; }
        public string questionnaireSequence { get; set; }
        public string fullName { get; set; }
        public string identificationNumber { get; set; }
        public string codeIdentificationType { get; set; }
        public List<Question> Questions { get; set; }
    }
}
