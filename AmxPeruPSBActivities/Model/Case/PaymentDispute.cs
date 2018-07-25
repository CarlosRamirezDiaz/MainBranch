using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace AmxPeruPSBActivities.Model.Case
{
    public class PaymentDispute
    {
        [Required]
        [Description("Document type that is the origin of dispute")]
        public  string PaymentDocumentType { get; set; }

        [Required]
        [Description("Number or code of payment document")]
        public string PaymentDocumentNumber { get; set; }

        [Required]
        [Description("Emision date for the payment document")]
        public string EmissionDate { get; set; }

        [Required]
        [Description("Destination or purpose for payment (Example: Fixed Charge)")]
        public string PaymentConcept { get; set; }
    }
}
