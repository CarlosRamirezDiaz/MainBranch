using System;

namespace AmxSoapServicesActivities.Model
{
    public class BalanceHistoryReadRequest
    {
        public string csIdPub { get; set; }
        public DateTime? snapFromDate { get; set; }
        public DateTime? snapEndDate { get; set; }
        public int? coId { get; set; }
        public string coIdPub { get; set; }
        public int? profileId { get; set; }
        public int? sncode { get; set; }
        public string sncodePub { get; set; }
        public int? seqNo { get; set; }
        public int? searchLimit { get; set; }
        public int? csId { get; set; }
        public int? bpId { get; set; }
        public int? memberCoId { get; set; }
        public string memberCoIdPub { get; set; }
        public string consumerCoId { get; set; }
        public string consumerCoIdPub { get; set; }
        public string cfssId { get; set; }
        public int? spcode { get; set; }
        public string productofferingId { get; set; }
        public string productId { get; set; }
        public bool? suppressReratedBirs { get; set; }
        public int? accountId { get; set; }
        public int? accountTypeId { get; set; }
        public string accountTypeIdPub { get; set; }
        public bool? excludeIndividualUc { get; set; }
        public string balanceSpecificationId { get; set; }
        public bool? excludeTechnicalBalances { get; set; }
    }
}
