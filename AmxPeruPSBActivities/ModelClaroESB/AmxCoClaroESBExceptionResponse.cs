namespace AmxPeruPSBActivities.ModelClaroESB
{
    /// <summary>
    /// /////////////////////////////////////////////////////////
    /// Sample Exception Response
    /// /////////////////////////////////////////////////////////
    /// </summary>
    //{
    //  "traceabilityId" : "49255945-ade4-4d61-937c-f2ecaadc351e",
    //  "categoryCode" : "01",
    //  "categoryDescription" : "Error Funcional",
    //  "location" : "Exposicion",
    //  "technicalDescription" : {"description" : "4.Tercero no existe en CIFIN"}
    //}

    public class AmxCoClaroESBExceptionResponse
    {
        public string traceabilityId { get; set; }
        public string categoryCode { get; set; }
        public string categoryDescription { get; set; }
        public string location { get; set; }
        public AmxCoClaroESBException technicalDescription { get; set; }
    }

    public class AmxCoClaroESBException
    {
        public string description { get; set; }
    }
}
