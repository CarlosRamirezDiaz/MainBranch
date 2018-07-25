using AmxPeruCommonLibrary;
using AmxSoapServicesActivities.Business;
using AmxSoapServicesActivities.Model;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using Microsoft.Xrm.Sdk;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Xrm.Sdk.Client;
using AMXCommon.Repository;



namespace AmxSoapServicesActivities.Activities
{
    public class ChangeCustomerEmailActivity : XrmAwareCodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<CustomerChangeEmailRequest> CustomerChangeEmailRequest { get; set; }
        public InArgument<string> individualCustomerId { get; set; }
        public InArgument<string> HostUrl { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        public OutArgument<string> CustomerChangeEmailResponse { get; set; }
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var XmlResponseStr = "";
            CustomerChangeEmailResponse objResponse = new CustomerChangeEmailResponse();
            if (CustomerChangeEmailRequest.Get(context) != null)
            {
                string endPoint = HostUrl.Get(context);
                //var customerID = individualCustomerId.Get(context);

                //Guid customerId = new Guid(customerID);
                //OrganizationServiceProxy _org = ContextProvider.OrganizationService;
                //var individualRepository = new IndividualCustomerRepository(_org);
                //var individual = individualRepository.GetById(customerId);

                //XmlResponseStr = new AmxCoChangeCustomerEmailBusiness().PutCustomerChangeEmail(CustomerChangeEmailRequest.Get(context), HostUrl.Get(context), ContextProvider.OrganizationService, individual.LastName,individual.FullName,individual.Status);
                XmlResponseStr = new ChangeCustomerEmailBusiness().PutCustomerChangeEmail(CustomerChangeEmailRequest.Get(context), HostUrl.Get(context), ContextProvider.OrganizationService);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(XmlResponseStr);

                string str = "<?xml version=\"1.0\"?>";
                XmlResponseStr = str + XmlResponseStr;
                var value = XDocument.Parse(XmlResponseStr);
                SOAPEnvelopeChangeCustomerEmail deserializedObject;
                using (var reader = value.CreateReader(System.Xml.Linq.ReaderOptions.None))
                {
                    var ser = new XmlSerializer(typeof(SOAPEnvelopeChangeCustomerEmail));
                    deserializedObject = (SOAPEnvelopeChangeCustomerEmail)ser.Deserialize(reader);
                    objResponse .customersNew.isIndividualOverdiscDisabled = deserializedObject.body.ChangeCustomerEmailResponse.isIndividualOverdiscDisabled;
                    objResponse.customersNew.familyId = deserializedObject.body.ChangeCustomerEmailResponse.familyId;
                    objResponse.customersNew.csStatus = deserializedObject.body.ChangeCustomerEmailResponse.csStatus;
                    objResponse.customersNew.csLevelCode = deserializedObject.body.ChangeCustomerEmailResponse.csLevelCode;
                    objResponse.customersNew.paymentResp = deserializedObject.body.ChangeCustomerEmailResponse.paymentResp;
                    objResponse.customersNew.prgCode = deserializedObject.body.ChangeCustomerEmailResponse.prgCode;
                    objResponse.customersNew.rpcode = deserializedObject.body.ChangeCustomerEmailResponse.rpcode;
                    objResponse.customersNew.rpcodePub = deserializedObject.body.ChangeCustomerEmailResponse.rpcodePub;
                    objResponse.customersNew.costId = deserializedObject.body.ChangeCustomerEmailResponse.costId;
                    objResponse.customersNew.costCodePub = deserializedObject.body.ChangeCustomerEmailResponse.costCodePub;
                    objResponse.customersNew.rsCode = deserializedObject.body.ChangeCustomerEmailResponse.rsCode;
                    objResponse.customersNew.wpCode = deserializedObject.body.ChangeCustomerEmailResponse.wpCode;
                    objResponse.customersNew.csBillInformation = deserializedObject.body.ChangeCustomerEmailResponse.csBillInformation;
                    objResponse.customersNew.expectPayCurrencyId = deserializedObject.body.ChangeCustomerEmailResponse.expectPayCurrencyId;
                    objResponse.customersNew.expectPayCurrencyIdPub = deserializedObject.body.ChangeCustomerEmailResponse.expectPayCurrencyIdPub;
                    objResponse.customersNew.csConvratetypePayment = deserializedObject.body.ChangeCustomerEmailResponse.csConvratetypePayment;
                    objResponse.customersNew.csConvratetypePaymentPub = deserializedObject.body.ChangeCustomerEmailResponse.csConvratetypePaymentPub;
                    objResponse.customersNew.refundCurrencyId = deserializedObject.body.ChangeCustomerEmailResponse.refundCurrencyId;
                    objResponse.customersNew.refundCurrencyIdPub = deserializedObject.body.ChangeCustomerEmailResponse.refundCurrencyIdPub;
                    objResponse.customersNew.csConvratetypeRefund = deserializedObject.body.ChangeCustomerEmailResponse.csConvratetypeRefund;
                    objResponse.customersNew.csConvratetypeRefundPub = deserializedObject.body.ChangeCustomerEmailResponse.csConvratetypeRefundPub;
                    objResponse.customersNew.csCrcheckAgreed = deserializedObject.body.ChangeCustomerEmailResponse.csCrcheckAgreed;
                    objResponse.customersNew.csIncorporatedInd = deserializedObject.body.ChangeCustomerEmailResponse.csIncorporatedInd;
                    objResponse.customersNew.csBillcycle = deserializedObject.body.ChangeCustomerEmailResponse.csBillcycle;
                    objResponse.customersNew.csLimitTr1 = deserializedObject.body.ChangeCustomerEmailResponse.csLimitTr1;
                    objResponse.customersNew.csLimitTr1Pub = deserializedObject.body.ChangeCustomerEmailResponse.csLimitTr1Pub;
                    objResponse.customersNew.csLimitTr2 = deserializedObject.body.ChangeCustomerEmailResponse.csLimitTr2;
                    objResponse.customersNew.csLimitTr2Pub = deserializedObject.body.ChangeCustomerEmailResponse.csLimitTr2Pub;
                    objResponse.customersNew.csLimitTr3 = deserializedObject.body.ChangeCustomerEmailResponse.csLimitTr3;
                    objResponse.customersNew.csLimitTr3Pub = deserializedObject.body.ChangeCustomerEmailResponse.csLimitTr3Pub;
                    objResponse.customersNew.CsClimit.amount = deserializedObject.body.ChangeCustomerEmailResponse.csClimit.amount;
                    objResponse.customersNew.CsClimit.currency = deserializedObject.body.ChangeCustomerEmailResponse.csClimit.currency;
                    objResponse.customersNew.csContresp = deserializedObject.body.ChangeCustomerEmailResponse.csContresp;
                    objResponse.customersNew.CsDeposit.amount = deserializedObject.body.ChangeCustomerEmailResponse.csDeposit.amount;
                    objResponse.customersNew.CsDeposit.currency = deserializedObject.body.ChangeCustomerEmailResponse.csDeposit.currency;
                    objResponse.customersNew.csDunning = deserializedObject.body.ChangeCustomerEmailResponse.csDunning;
                    objResponse.customersNew.csPrepayment = deserializedObject.body.ChangeCustomerEmailResponse.csPrepayment;
                    objResponse.customersNew.csFcId = deserializedObject.body.ChangeCustomerEmailResponse.csFcId;
                    objResponse.customersNew.csFcIdPub = deserializedObject.body.ChangeCustomerEmailResponse.csFcIdPub;
                    objResponse.customersNew.CsCscurbalance.amount = deserializedObject.body.ChangeCustomerEmailResponse.csCscurbalance.amount;
                    objResponse.customersNew.CsCscurbalance.currency = deserializedObject.body.ChangeCustomerEmailResponse.csCscurbalance.currency;
                    objResponse.customersNew.CsPrevbalance.amount = deserializedObject.body.ChangeCustomerEmailResponse.csPrevbalance.amount;
                    objResponse.customersNew.CsPrevbalance.currency = deserializedObject.body.ChangeCustomerEmailResponse.csPrevbalance.currency;
                    objResponse.customersNew.CsUnbilledAmount.amount = deserializedObject.body.ChangeCustomerEmailResponse.csUnbilledAmount.amount;
                    objResponse.customersNew.CsUnbilledAmount.currency = deserializedObject.body.ChangeCustomerEmailResponse.csUnbilledAmount.currency;
                    objResponse.customersNew.csId = deserializedObject.body.ChangeCustomerEmailResponse.csId;
                    objResponse.customersNew.csIdPub = deserializedObject.body.ChangeCustomerEmailResponse.csIdPub;
                    objResponse.customersNew.PartyRoleAssignments.Item.partyRoleId = 1;
                    objResponse.customersNew.PartyRoleAssignments.Item.partyRoleName = "Subscriber";
                    objResponse.customersNew.PartyRoleAssignments.Item.partyRoleDescription = "A Party that uses a network, services or content provided by other Party";
                    objResponse.customersNew.partyType = deserializedObject.body.ChangeCustomerEmailResponse.partyType;
                    objResponse.customersNew.csCreationDate = deserializedObject.body.ChangeCustomerEmailResponse.csCreationDate;
                    objResponse.customersNew.performCreditScoring = deserializedObject.body.ChangeCustomerEmailResponse.performCreditScoring;
                    objResponse.PaymentArrangementWrite.cspId = 1060;
                    objResponse.Addresses.Item.AddressWrite.adrSeq = 1;
                    CustomerChangeEmailResponse.Set(context, objResponse);

                }



            }

        }

    }
}
