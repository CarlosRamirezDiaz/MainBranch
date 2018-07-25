using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.ModelClaroESB.Evidente
{
    public class GetQuestionnaireRequest
    {
        // Sample Request
        //"codeQuestionnaire" : "7060",
        //"codeTypeIdentification" : "1",
        //"identificationNumber" : "1012417257",
        //"surName" : "SALAS",
        //"expeditionDate" : "21/12/2012",
        //"keyCIFIN" : "523791",
        //"password" : "Claro4",
        //"withProxy" : "0"

        public string codeQuestionnaire { get; set; }
        public string codeTypeIdentification { get; set; }
        public string identificationNumber { get; set; }
        public string surName { get; set; }
        public string expeditionDate { get; set; }
        public string keyCIFIN { get; set; }
        public string password { get; set; }
        public string withProxy { get; set; }

        public static GetQuestionnaireRequest GetQuestionnaireRequestFactory(string codeQuestionnaire, int documentType, string documentNumber, DateTime documentIssueDate, string lastName, string keyCIFIN, string password)
        {
            var returnValue = new GetQuestionnaireRequest();
            if (string.IsNullOrEmpty(codeQuestionnaire))
                codeQuestionnaire = "7060";

            returnValue.codeQuestionnaire = codeQuestionnaire;
            returnValue.keyCIFIN = keyCIFIN; // "523791"
            returnValue.password = password; // "Claro5";
            returnValue.withProxy = "0";

            returnValue.codeTypeIdentification = documentType.ToString();
            returnValue.identificationNumber = documentNumber;
            returnValue.surName = lastName;
            returnValue.expeditionDate = documentIssueDate.ToString("dd/MM/yyyy");

            return returnValue;
        }
    }
}
