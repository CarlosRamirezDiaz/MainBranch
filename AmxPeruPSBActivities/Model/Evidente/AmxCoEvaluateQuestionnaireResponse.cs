using AmxPeruPSBActivities.Model;
using System.Collections.Generic;

namespace AmxCoPSBActivities.Model.Evidente
{
    public class AmxCoEvaluateQuestionnaireResponse : BaseResponse
    {
        public string resultConfrontation { get; set; }
        public string responseCode { get; set; }
        public string descriptionCode { get; set; }
    }
}
