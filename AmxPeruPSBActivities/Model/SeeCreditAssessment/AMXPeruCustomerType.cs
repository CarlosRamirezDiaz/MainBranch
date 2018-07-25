using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.SeeCreditAssessment
{
    public class AMXPeruCustomerType
    {
        public int Numberofactivelines { get; set; }
        public int Quantityofplansbyproduct { get; set; }
        public int Numberoflegalrepresentatives { get; set; }
        public int Paymentcapacity { get; set; }
        public int Consolidatedbehavior { get; set; }
        public int Behaviorofpayment { get; set; }
        public int Paymentbehaviorc1 { get; set; }
        public double Creditscore { get; set; }
        public int Creditscorewhole { get; set; }
        public AMXPeruAddressType Address { get; set; }
        public AMXPeruDocumentType Document { get; set; }
        public int Age { get; set; }
        public double Factorofindebtedness { get; set; }
        public double Renovationfactor { get; set; }
        public double Averagebillingclaro { get; set; }
        public double Invoicingaverageproduct { get; set; }
        public double Creditlimitavailable { get; set; }
        public AMXPeruLegalRepresentativeType Legalrepresentative { get; set; }
        public string Risk { get; set; }
        public string Clarorisk { get; set; }
        public string Risktotallegalrepresentatives { get; set; }
        public string Sex { get; set; }
        public int Residencetime { get; set; }
        public string Kind { get; set; }
    }
}
