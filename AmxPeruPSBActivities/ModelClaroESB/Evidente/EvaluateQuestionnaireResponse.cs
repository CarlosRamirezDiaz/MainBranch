using System;
using System.Collections.Generic;

namespace AmxCoPSBActivities.ModelClaroESB.Evidente
{
//    {
//  "headerResponse" : {
//    "responseDate" : "2017-11-01T17:10:40.037-05:00",
//    "traceabilityId" : "f9eee4f3-2093-49b7-8c66-150017a9b64e"
//  },
//  "codeQuestionnaire" : "7060",
//  "keyCIFIN" : "523791",
//  "responseProcess" : {
//    "responseCode" : "0",
//    "descriptionCode" : "CONFRONTACIÃN RECHAZADA"
//  },
//  "numberHits" : "1",
//  "resultConfrontation" : "3",
//  "resultScore" : "20"
//}

    public class EvaluateQuestionnaireResponse
    {
        public string codeQuestionnaire { get; set; }
        public ResponseProcessEva responseProcess { get; set; }
        public string numberHits { get; set; }
        public string resultConfrontation { get; set; }
        public string keyCIFIN { get; set; }
        public string resultScore { get; set; }
        public HeaderResponseEva headerResponse { get; set; }
    }

    public class ResponseProcessEva
    {
        public string descriptionCode { get; set; }
        public string responseCode { get; set; }
    }

    public class HeaderResponseEva
    {
        public string traceabilityId { get; set; }
        public DateTime responseDate { get; set; }
    }

}
