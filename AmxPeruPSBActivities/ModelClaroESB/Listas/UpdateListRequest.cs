using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.ModelClaroESB.Listas
{
    class UpdateListRequest
    {

        public string list { get; set; }
        public string idReason { get; set; }
        public string applicant { get; set; }
        public string identifier { get; set; }
        public string information { get; set; }

        public static UpdateListRequest UpdateListRequestFactory(string list, string idReason, string applicant, string identifier, string information)
        {
            var returnValue = new UpdateListRequest();

            returnValue.list = list;
            returnValue.idReason = idReason;
            returnValue.applicant = applicant;
            returnValue.identifier = identifier;
            returnValue.information = information;
            
            return returnValue;
        }
    }

}
