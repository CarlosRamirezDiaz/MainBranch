using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxSoapServicesActivities.Model
{
    public class CustomerChangeEmailRequest
    {
        public string customerId { get; set; }
        public string email { get; set; }

        //public InputAttributes inputAttributes { get; set; }

        //   public class InputAttributes
        //{
        //    public CustomerNew customersNew { get; set; }
        //    public PaymentArrangementWrite paymentArrangementWrite { get; set; }
        //    public Addresses addresses { get; set; }
        //    public customerInfoWrite CustomerInfoWrite { get; set; }
        //    public CustomerWrite customerWrite { get; set; }

        //    public class CustomerNew
        //    {
        //        public Boolean paymentResp { get; set; }
        //        //public tbAmount tbAmounts { get; set; }
        //        //public class tbAmount
        //        //{
        //        //    public double amount { get; set; }
        //        //    public double currency { get; set; }
        //        //}
        //        //public string tbMode { get; set; }
        //        //public string tbPurpose { get; set; }
        //        //public string sioActionType { get; set; }

        //        //public sioThresholdAmt sioThresholdAmt_ { get; set; }

        //        //public class sioThresholdAmt
        //        //{
        //        //    public double amount { get; set; }
        //        //    public double currency { get; set; }
        //        //}

        //        //public string maxCarryOverLenght { get; set; }
        //        //public string maxCarryOverPeriodType { get; set; }

        //        //public string isIndividualOverdiscDisabled { get; set; }
        //        public string  externalCustomerId { get; set; }
        //        //public string externalCustomerSetId { get; set; }
        //        //public string csIdPub { get; set; }
        //        //public string familyId { get; set; }
        //        public string prgCode { get; set; }
        //        public int rpcode { get; set; }
        //        //public string rpcodePub { get; set; }
        //        //public string tradeCode { get; set; }
        //        //public string areaCode { get; set; }
        //        //public string costId { get; set; }
        //        //public string costCodePub { get; set; }
        //        //public string csPassword { get; set; }
        //        //public string wpCode { get; set; }
        //        //public string srCode { get; set; }
        //        //public string csRemark1 { get; set; }
        //        //public string csRemark2 { get; set; }
        //        //public string csBillInformation { get; set; }
        //        //public string expectPayCurrencyId { get; set; }
        //        //public string expectPayCurrencyIdPub { get; set; }
        //        //public string csConvratetypePayment { get; set; }
        //        //public string csConvratetypePaymentPub { get; set; }
        //        //public string refundCurrencyId { get; set; }
        //        //public string refundCurrencyIdPub { get; set; }
        //        //public string csConvratetypeRefund { get; set; }
        //        //public string csConvratetypeRefundPub { get; set; }
        //        //public string csCrcheckAgreed { get; set; }
        //        public string csBillcycle { get; set; }
        //        //public string csLimitTr1 { get; set; }
        //        //public string csLimitTr1Pub { get; set; }
        //        //public string csLimitTr2 { get; set; }
        //        //public string csLimitTr2Pub { get; set; }
        //        //public string csLimitTr3 { get; set; }
        //        //public string csLimitTr3Pub { get; set; }
        //        //public csClimit csClimit_ { get; set; }
        //        //public class csClimit
        //        //{
        //        //    public double amount { get; set; }
        //        //    public double currency { get; set; }
        //        //}

        //        //public csDeposit csDeposit_ { get; set; }

        //        //public class csDeposit
        //        //{
        //        //    public double amount { get; set; }
        //        //    public double currency { get; set; }
        //        //}

        //        //public string csDunning { get; set; }
        //        //public string csPrepayment { get; set; }
        //        //public string csCollector { get; set; }
        //        //public string custcatCode { get; set; }
        //        //public string custcatCodePub { get; set; }
        //        //public string csDealerid { get; set; }
        //        //public string csDealeridPub { get; set; }
        //        public int csJurisdictionId { get; set; }
        //        //public string csJurisdictionCode { get; set; }
        //        //public string csIncorporatedInd { get; set; }
        //        //public string partyType { get; set; }
        //        //public string csFcId { get; set; }
        //        //public string csFcIdPub { get; set; }
        //        //public string roundingCarryLeftOver { get; set; }


        //    }

        //    public class PaymentArrangementWrite
        //    {
        //        //public string cspId { get; set; }
        //        public string cspPmntId { get; set; }
        //        //public string cspPmntIdPub { get; set; }
        //        //public string cspDeleted { get; set; }
        //        //public string cspAccno { get; set; }
        //        //public string cspAccowner { get; set; }
        //        //public string cspBankcode { get; set; }
        //        //public string cspBankname { get; set; }
        //        //public string cspBankzip { get; set; }
        //        //public string cspBankcity { get; set; }
        //        //public string cspBankstreet { get; set; }
        //        //public string cspCcagCode { get; set; }
        //        //public string cspCcagCodePub { get; set; }
        //        //public string cspCcvaliddt { get; set; }

        //        //public cspCeiling cspCeiling_ { get; set; }

        //        //public class cspCeiling
        //        //{
        //        //    public double amount { get; set; }
        //        //    public double currency { get; set; }
        //        //}
        //        //public string cspBankstate { get; set; }
        //        //public string cspBankcounty { get; set; }
        //        //public string cspOrdernumber { get; set; }
        //        //public string cspBankstreetno { get; set; }
        //        //public string cspBankcountry { get; set; }
        //        //public string cspBankcountryPub { get; set; }
        //        //public string cspSwiftcode { get; set; }
        //        //public string cspTokenId { get; set; }
        //        //public string cspBic { get; set; }
        //        //public string cspIban { get; set; }
        //        //public string cspValidFrom { get; set; }
        //        //public string authRemark { get; set; }
        //        //public string authInd { get; set; }
        //        //public string csId { get; set; }
        //        //public string csIdPub { get; set; }


        //    }

        //    public class Addresses
        //    {
        //        public item Item { get; set; }

        //        public class item
        //        {

        //            public addressWrite AddressWrite { get; set; }
        //            public class addressWrite
        //            {
        //                public int adrSeq { get; set; }
        //                public string adrLname { get; set; }
        //                public string adrFname { get; set; }
        //                public string adrStreet { get; set; }
        //                public string adrStreetno { get; set; }
        //                public string adrZip { get; set; }
        //                public string adrCity { get; set; }
        //                public string adrEmail { get; set; }

        //            }

        //        }

        //    }

        //    public class customerInfoWrite
        //    {

        //    }

        //    public class CustomerWrite
        //    {
        //        public Boolean paymentResp { get; set; }
        //        public string csStatus { get; set; }
        //        public int rsCode { get; set; }
        //    }

        //}

    }
}
