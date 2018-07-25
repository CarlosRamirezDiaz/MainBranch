using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.ModelClaroESB.Bureau
{
    public class GetBureauRequest
    {
        public string documentType { get; set; }

        public string documentNumber { get; set; }

        public string givenNames { get; set; }

        public string issueDate { get; set; }

        public static GetBureauRequest GetBureauRequestFactory(int documentType, string documentNumber, DateTime documentIssueDate, string givenNames)
        {
            var returnValue = new GetBureauRequest();

            returnValue.documentType = documentType.ToString();
            returnValue.documentNumber = documentNumber;
            returnValue.issueDate = documentIssueDate.ToString("yyyy/MM/dd");
            returnValue.givenNames = givenNames;

            return returnValue;
        }
    }
}
