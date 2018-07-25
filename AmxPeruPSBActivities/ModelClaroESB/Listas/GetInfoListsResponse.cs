using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.ModelClaroESB.Listas
{
    public class GetInfoListsResponse
    {
        public HeaderResponse headerResponse { get; set; }
        public IList<InfoList> infoList { get; set; }
    }

    public class HeaderResponse
    {
        public string traceabilityId { get; set; }
        public DateTime responseDate { get; set; }
    }

    public class DescriptionError
    {
        public string code { get; set; }
        public string message { get; set; }
    }

    public class Lists
    {
        public string reason { get; set; }
        public string codAction { get; set; }
        public string action { get; set; }
        public string list { get; set; }
        public string codReason { get; set; }
    }

    public class InfoList
    {
        public DescriptionError descriptionError { get; set; }
        public Lists lists { get; set; }
    }

}
