using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AmxPeruPSBActivities.Model.Case
{
   public class CaseRequest: BaseRequest
    {
        [Required]
        public string CustomerId { get; set; }
        
        public string CaseParentId { get; set; }

        public string BillingAccountId { get; set; }

        [Required]
        public string CaseTitle { get; set; }


        [Required]
        public string CaseType { get; set; }


        [Required]
        public string Description { get; set; }

        public string ServiceIdentifier { get; set; }

        public string ProductName { get; set; }

        public string ComplaintPhase { get; set; }

        public string caseTypeCategory1 { get; set; }

        public string caseTypeCategory2 { get; set; }

        public string caseTypeCategory3 { get; set; }

        public string caseTypeCategory4 { get; set; }

        [Required]
        public int Origin { get; set; }


        [Required]
        public long Priority   { get; set; }

        [Required]
        public string SerialNumber { get; set; }


        [Required]
        public long Severity { get; set; }

        [Required]
        public long Status { get; set; }


        [Required]
        public string Subject { get; set; }
        
        public string Identifier { get; set; }

        public string ReferentialPhoneNumber { get; set; }

        public string ReferentialEMail { get; set; }

        public string ReferentialAddress { get; set; }

        public string NotificationMethod { get; set; }

        public PaymentDispute [] PaymentDispute { get; set; }

        public string CallRecordId { get; set; }

        public string ResolutionNumber { get; set; }

        public string ResolutionDate { get; set; }

        public Indecopi Indecopi { get; set; }

        public Osiptel Osiptel { get; set; }

        public string ResolutionNotificationDate{  get; set; }

        public string AddressOfServiceFailure { get; set; }

        public List<Documents>  Documents { get; set; }
    }   
}