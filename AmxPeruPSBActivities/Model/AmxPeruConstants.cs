using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
   public class AmxPeruConstants
    {
        #region [Constant Values : Programming Purpose]
        public static string EntityLogicalNameIndividual = "contact";
        public static string EntityLogicalNameCorporate = "account";
        public static string CustomerTypeIndividual = "1";
        public static string CustomerTypeCorporate = "2";
        public static string StatusNotOK = "NOK";
        public static string StatusOK = "OK";
        public static string ErrorMessage = "";
        public static string EntityNameBiLog = "etel_bi_log";
        public static string EntityBiLogSubjectField = "subject";
        public static string CustomerSearchUriCti = @"main.aspx?etc=2&id=%7b{0}%7d&pagetype=entityrecord";
        public static string SearchByDocument = "Document";
        public static string SearchBySocialProfile = "SocialProfile";
        public static string ExternalChannel = "External Channel";
        public static string ModifyBillCycle = "Modify Bill Cycle";
        public static string ChangeBillCycle = "ModifyBillCycle";
        public static string PaymentArrangement = "Payment Arrangement";
        public static string OrderMilestoneSuccess = "Success";
        public static string OrderMilestoneFailure = "Failure";
        public static int OrderStatusFullfillmentStatusNew = 1;
        public static int OrderStatusFullfillmentStatusInProgress = 2;
        public static int OrderStatusFullfillmentStatusError = 3;
        public static int OrderStatusFullfillmentStatusCompleted = 4;
        public static int OrderStatusFullfillmentStatusCancelled = 5;
        public static int OrderStatusFullfillmentStatusAmended = 6;
        #endregion

        #region [Constant Values : Translation Required]
        public static string tIncomingRequestNull = "TCRM : Incoming Request Object is NULL";
        public static string tInvalidOrgService = "TCRM : Org Service Instance in Either NULL or Invalid";
        public static string tMandatoryFileName = "TCRM : File Name is mandatory for the current service.";
        public static string BILogBlacklistStatusSubject = "Blacklist Status Change.";
        public static string BILogBlacklistStatusDescription = "Blacklist Status and Status reason is changed for related customer.";
        public static string BILogChangeCustomerStatusSubject = "Customer Status Change.";
        public static string BILogChangeCustomerStatusDescription = "Customer Status is changed for related customer.";
        public static string BILogCreateCustomerSubject = "Customer Record Created.";
        public static string BILogCreateCustomerDescription = "New customer record is Created in CRM. ";
        public static string BILogCreateCustomerDocumentSubject = "Customer Document Record Created.";
        public static string BILogCreateCustomerDocumentDescription = "New customer document record is created in CRM. ";
        public static string BILogCreateTaskSubject = "Task Record Created.";
        public static string BILogCreateTaskDescription = "New task record is Created in CRM. ";
        public static string BILogDontInsistSubject = "Do Not Insist Information Updated.";
        public static string BILogDontInsistDescription = "Do not insist fields are updated in related customer record.";
        public static string InvalidCustomerType = "TCRM : Invalid Customer Type Entered";
        public static string NoRecordsFound = "No Records Found";
        public static string MultipleKeys = "Multiple Configuration Values Found With Same Key : ";
        public static string CustomerAlreadyPresent = "Customer is already present with the given document type and document id.";
        public static string DocumentLengthValidationDNI = "For DNI Document, Document ID must be 8 digit.";
        public static string DocumentLengthValidationCE = "For CE Document, Document ID must be 9 digit.";
        public static string DocumentLengthValidationRUC = "For RUC Document, Document ID must be 11 digit.";
        public static string MandatoryCustomerType = "Customer Type is mandatory for the current service.";
        public static string MandatoryDocumentType = "Document Type is mandatory for the current service.";
        public static string BilReturnExternalIdNull = "TCRM : External Id in BIL Response is NULL";
        public static string CustomerExternalIdIsNull = "Customer ExternalId is Null";
        public static string BilResponseQuoteIdNull = "TCRM : Bill Response QuoteId is Null or Empty";
        public static string BilServiceCallFailed = "TCRM : Bill Call Failed";
        public static string RecordCreationFailed = "TCRM : Record Creation Failed in CRM";
        public static string BiLogCreationFailed = "BI Log Creation Failed";
        public static string BiLogCreationSuccessful = "BI Log Creation Successful";
        public static string ResponseContainsNoData = "Response Contains No Data.";
        public static string CtiSearchCriteriaNull = "TCRM : Both DocumentNumber & MSISDN are NULL. Please Provide Any One.";
        public static string InvalidSearchCriteria = "TCRM : Invalid Search Criteria";
        public static string NullOrgService = "TCRM : CRM Organization Service Instance is NULL";
        public static string ActiveBiHeaderNotFound = "TCRM : No Active Bi Header Found for Logged In User";
        public static string tCreateBA = "Create Billing Account";
        public static string tUpdateBA = "Update Billing Account";
        public static string tCreatePaymentProfile = "Create Payment Profile";
        public static string CreatePaymentProfileChannel = "TCRM API";
        public static string BILogCreateLeadSubject = "Lead - Creation";
        public static string BILogCreateLeadDescription = "Lead- Created";
        public static string BILogClaroMailSubject = "Claro Mail Verification";
        public static string BILogClaroMailDescription = "Claro Mail Verification";
        public static string BILogECMProductSubject = "ECM Product List";
        public static string tBILogECMProductDescription = "ECM Product List";
        public static string tMilestoneIsNull = "TCRM : Milestone value is NULL or Empty";
        public static string tNullCustomerGuid = "TCRM : Customer Guid is Empty";
        public static string tEOCCustomerSearchException = "TCRM : EOC Customer Search Error";
        #endregion
    }
    
}
