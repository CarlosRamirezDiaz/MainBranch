using AmxPeruPSBActivities.Model;
using System;

namespace AmxCoPSBActivities.Model.Evidente
{
    public class AmxCoGetQuestionnaireRequest : BaseRequest
    {
        // ContactId from the Contact Entity
        public Guid ContactId { get; set; }
        public string codeQuestionnaire { get; set; }
        public int documentType { get; set; }
        public string documentNumber { get; set; }
        public DateTime documentIssueDate { get; set; }
        public string lastName { get; set; }
    }
}
