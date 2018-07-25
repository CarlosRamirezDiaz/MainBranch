using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model.BI_Log
{
    public class AmxBiLogAddRequest
    {
        public string BiHeaderId { get; set; }
        public string OperationType { get; set; }
        public string OperationName { get; set; }
        public string Description { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string BillingAccountId { get; set; }
        public string Channel { get; set; }
        public string ExternalTransactionId { get; set; }
        public string UserSignum { get; set; }
    }

    public class BILogSchema
    {
        public Guid BiHeaderRecordGuid { get; set; }
        public Guid LoggedInUserId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Channel { get; set; }
        public Guid BillCycleChangeRecordGuid { get; set; }
        public Guid CustomerId { get; set; }
    }
}
