using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxSoapServicesActivities.Model
{
    public class CustomerChangeEmailResponse
    {
        public CustomerNew customersNew { get; set; }

        public class CustomerNew
        {
            public Boolean isIndividualOverdiscDisabled { get; set; }
            public long familyId { get; set; }
            public string csStatus { get; set; }
            public string csLevelCode { get; set; }
            public Boolean paymentResp { get; set; }
            public string prgCode { get; set; }
            public long rpcode { get; set; }
            public string rpcodePub { get; set; }
            public long costId { get; set; }
            public string costCodePub { get; set; }
            public long rsCode { get; set; }
            public long wpCode { get; set; }
            public Boolean csBillInformation { get; set; }
            public long expectPayCurrencyId { get; set; }
            public string expectPayCurrencyIdPub { get; set; }
            public long csConvratetypePayment { get; set; }
            public string csConvratetypePaymentPub { get; set; }
            public long refundCurrencyId { get; set; }
            public string refundCurrencyIdPub { get; set; }
            public long csConvratetypeRefund { get; set; }
            public string csConvratetypeRefundPub { get; set; }
            public Boolean csCrcheckAgreed { get; set; }
            public Boolean csIncorporatedInd { get; set; }
            public string csBillcycle { get; set; }
            public long csLimitTr1 { get; set; }
            public string csLimitTr1Pub { get; set; }
            public long csLimitTr2 { get; set; }
            public string csLimitTr2Pub { get; set; }
            public long csLimitTr3 { get; set; }
            public string csLimitTr3Pub { get; set; }
            public csClimit CsClimit { get; set; }

            public class csClimit
            {
                public double amount { get; set; }
                public string currency { get; set; }
            }

            public Boolean csContresp { get; set; }

            public csDeposit CsDeposit { get; set; }

            public class csDeposit
            {
                public double amount { get; set; }
                public string currency { get; set; }
            }

            public Boolean csDunning { get; set; }
            public Boolean csPrepayment { get; set; }
            public long csFcId { get; set; }
            public string csFcIdPub { get; set; }

            public csCscurbalance CsCscurbalance { get; set; }

            public class csCscurbalance
            {
                public double amount { get; set; }
                public string currency { get; set; }
            }

            public csPrevbalance CsPrevbalance { get; set; }

            public class csPrevbalance
            {
                public double amount { get; set; }
                public string currency { get; set; }
            }

            public csUnbilledAmount CsUnbilledAmount { get; set; }

            public class csUnbilledAmount
            {
                public double amount { get; set; }
                public string currency { get; set; }
            }

            public long csId { get; set; }
            public string csIdPub { get; set; }

            public partyRoleAssignments PartyRoleAssignments { get; set; }

            public class partyRoleAssignments
            {

                public item Item { get; set; }
                public class item
                {
                    public long partyRoleId { get; set; }
                    public string partyRoleName { get; set; }
                    public string partyRoleDescription { get; set; }
                }
                
            }

            public string partyType { get; set; }
            public DateTime csCreationDate { get; set; }
            public Boolean performCreditScoring { get; set; }


            

        }

        public paymentArrangementWrite PaymentArrangementWrite { get; set; }

        public class paymentArrangementWrite
        {
            public long cspId { get; set; }

        }

        public addresses Addresses { get; set; }

        

        public class addresses
        {

            public item Item { get; set; }
            public class item
            {
                public addressWrite AddressWrite { get; set; }

                public class addressWrite
                {
                    public long adrSeq { get; set; }

                }
            }

        }
    }
}
