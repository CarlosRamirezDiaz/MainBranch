using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxSoapServicesActivities.Model
{
    //public class ContractsSearchResponse
    //{
    //    public List<Contract> contracts { get; set; }
    //}

    public class ContractsSearchResponse
    {
            public string contractTypeId { get; set; }
            public string buId { get; set; }
            public string coStatus { get; set; }
            public string dirnum { get; set; }
            public string plcode { get; set; }
            public string rpcode { get; set; }
            public string coActivated { get; set; }
            public string coId { get; set; }
            public string coIdPub { get; set; }
            public Boolean currentDn { get; set; }
            public Boolean dnPending { get; set; }
            public string paymentMethodInd { get; set; }
            public string csCode { get; set; }
            public string submId { get; set; }
            public Boolean externalind { get; set; }
            public string hlcode { get; set; }
            public string csId { get; set; }
            public string csIdPub { get; set; }
            public string paymentResp { get; set; }
            public string csContrResp { get; set; }
    }
}
