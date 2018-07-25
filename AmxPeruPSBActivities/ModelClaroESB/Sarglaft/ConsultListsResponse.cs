using System;

namespace AmxCoPSBActivities.ModelClaroESB.Sarglaft
{

    /// ///////////////////////////////////////////////
    // Sarglaft sample response
    ///////////////////////////////////////////////////
    //   {
    //        "lists":  
    //        [
    //	        {
    //		        "coincidence":  	"false"	,
    //		        "list":  	"onu"
    //
    //               },
    //	        {
    //		        "observations":  	" * Puntuación: 100 ofac, (Alias) - Chapo GUZMAN\n<br />"	,
    //		        "coincidence":  	"true"	,
    //		        "list":  	"ofac"
    //	        },
    //	        {
    //		        "coincidence":  	"false"	,
    //		        "list":  	"fbi"
    //	        }
    //        ],
    //        "headerResponse":  
    //        {
    //	        "traceabilityId":  	"777f167a-dd83-472a-a635-b11ece367d72"	,
    //	        "responseDate":  	"2017-10-06T14:36:21.369-05:00"
    //        }
    //    }


    public class ConsultListsResponse
    {
        public SarglatList[] lists { get; set; }

        public SarglaftHeaderResponse HeaderResponse { get; set; }
    }

    public class SarglaftHeaderResponse
    {
        public string traceabilityId { get; set; }
        public DateTime responseDate { get; set; }
    }

    public class SarglatList
    {
        public string list { get; set; }
        public bool coincidence { get; set; }
        public string observations { get; set; }
    }
}
