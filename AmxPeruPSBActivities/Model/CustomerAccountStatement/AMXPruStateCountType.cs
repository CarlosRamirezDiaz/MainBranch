using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.CustomerAccountStatement
{
  public  class AMXPruStateCountType
    {


        public string ClientName { get; set; }
        public string CurrentDebt { get; set; }
        public string ExpiredDebt { get; set; }
        public string TotalAmountDispute { get; set; }
        public string DateInvoiceUlt { get; set; }
        public string UltDatePayment { get; set; }
        public string CodeAccount { get; set; }
        public string AlternateAccountCode { get; set; }
        public string UBIGeoDescription { get; set; }
        public string ClientType { get; set; }
        public string AccountStatement { get; set; }
        public string ActivationDate { get; set; }
        public string BillingCycle { get; set; }
        public string CreditLimit { get; set; }
        public string CreditScore { get; set; }
        public string PayType { get; set; }
        public List<AMXPeruDetailStateType> DetailStateType { get; set; }
    }
}
