using AmxPeruPSBActivities.Activities.CustomerDetails;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Repository;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmxPeruPSBActivities.Business
{
    public class BillingAccountBusiness
    {
        XrmDataContextProvider ContextProvider;
        string BiBillingAccountUpdate = "etel_billingaccountupdatebi";
        Guid CustomerGuid = Guid.Empty;
        string CustomerName = string.Empty;
        string processedBillingAccountId = "00000000-0000-0000-0000-000000000000";
        Guid CreatedBiBAUpdateGuid = Guid.Empty;
        string MailToAddressTypeCode = "831260000";
        string BillToAddressTypeCode = "831260002";
        string BiBillingAccountCreate = "etel_bi_billingaccountcreate";

        public BillingAccountBusiness()
        {

        }

        public BillingAccountBusiness(XrmDataContextProvider contextProvider)
        {
            ContextProvider = contextProvider;
        }

        public void UpdateOrderItemBillingAccount(OrganizationServiceProxy _org, string OrderItemId, string BillingAccountId)
        {
            // Check if resource exists and needs update or create
            var orderItemRepository = new OrderItemRepository(_org);
            Guid itemGuid = new Guid(OrderItemId);
            var orderItem = orderItemRepository.RetrieveCustomizedOrderItemByOrder(itemGuid);

            orderItem.amx_billingaccountexternalid = BillingAccountId;

            orderItemRepository.Update(orderItem);
        }

        public AmxPeruModifyBillingAccountResponse UpdateBA(AmxPeruModifyBillingAccountRequest request, OrganizationServiceProxy organizationService)
        {
            string OrderServiceUrl = string.Empty;
            string responseString = string.Empty;
            AmxPeruModifyBillingAccountResponse _ModifyBillingAccountResponse = null;



            //try
            //{
            //    GetCustomerDetail(request.CustomerExternalId,organizationService);

            //    _ModifyBillingAccountResponse = new AmxPeruModifyBillingAccountResponse();
            //   // OrderServiceUrl = ConfigurationManager.AppSettings["OrderServiceUrl"].ToString();

            //    if (request != null && !string.IsNullOrEmpty(OrderServiceUrl))
            //    {
            //        BillingAccountUpdateRequest _BillingAccountUpdateRequest = new BillingAccountUpdateRequest();
            //        _BillingAccountUpdateRequest.AccountName = request.AccountName;
            //        _BillingAccountUpdateRequest.AllowCallItemization = request.AllowCallItemization;

            //        processedBillingAccountId = processedBillingAccountId.Substring(0, (processedBillingAccountId.Length - request.BillingAccountId.Length));
            //        processedBillingAccountId = processedBillingAccountId + request.BillingAccountId;

            //        _BillingAccountUpdateRequest.BillingAccountId = new Guid(processedBillingAccountId);
            //        _BillingAccountUpdateRequest.BillMedium = request.BillMedium;
            //        _BillingAccountUpdateRequest.BillToAddressId = request.BillToAddressId;
            //        if (request.IsIndividual)
            //        {
            //            _BillingAccountUpdateRequest.IndividualCustomerId = CustomerGuid;
            //        }
            //        else
            //        {
            //            _BillingAccountUpdateRequest.CorporateCustomerId = CustomerGuid;
            //        }
            //        _BillingAccountUpdateRequest.IsPrimaryBillingAccount = request.IsPrimaryBillingAccount;
            //        _BillingAccountUpdateRequest.MailToAddressId = request.MailToAddressId;
            //        _BillingAccountUpdateRequest.NumberOfCopies = request.NumberOfCopies;

            //        dynamic obj = new { request = _BillingAccountUpdateRequest };
            //        var data = new JavaScriptSerializer().Serialize(obj);
            //        using (var client = new WebClient { UseDefaultCredentials = true })
            //        {
            //            client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
            //            byte[] responseObj = client.UploadData(OrderServiceUrl, "POST", Encoding.UTF8.GetBytes(data));
            //            responseString = System.Text.Encoding.UTF8.GetString(responseObj);
            //        }

            //        CreateRecordinCrmBI(request,organizationService);
            //        _ModifyBillingAccountResponse.UpdateBAResponse = responseString;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            return _ModifyBillingAccountResponse;
        }

        private void CreateRecordinCrmBI(AmxPeruModifyBillingAccountRequest request, OrganizationServiceProxy organizationService)
        {
            try
            {
                Microsoft.Xrm.Sdk.Entity CreateBABIRecordInCrm = new Microsoft.Xrm.Sdk.Entity(BiBillingAccountUpdate);
                CreateBABIRecordInCrm.Attributes.Add("etel_accountname", "BA-" + request.BillingAccountId + "-" + CustomerName);
                CreateBABIRecordInCrm.Attributes.Add("etel_billtoaddress", new Microsoft.Xrm.Sdk.EntityReference("etel_customeraddress", request.BillToAddressId));
                CreateBABIRecordInCrm.Attributes.Add("etel_mailtoaddress", new Microsoft.Xrm.Sdk.EntityReference("etel_customeraddress", request.MailToAddressId));
                CreateBABIRecordInCrm.Attributes.Add("etel_numberofcopies", request.NumberOfCopies);
                CreateBABIRecordInCrm.Attributes.Add("etel_allowcallitemizationoninvoice", request.AllowCallItemization);
                CreateBABIRecordInCrm.Attributes.Add("etel_billmediumcode", new Microsoft.Xrm.Sdk.OptionSetValue(request.BillMedium));
                //CreateBABIRecordInCrm.Attributes.Add("tclab_baexternalid", request.BillingAccountId);
                CreateBABIRecordInCrm.Attributes.Add("etel_isprimarybillingaccount", request.IsPrimaryBillingAccount);

                if (request.IsIndividual)
                {
                    CreateBABIRecordInCrm.Attributes.Add("etel_customerindividualid", new Microsoft.Xrm.Sdk.EntityReference("contact", CustomerGuid));
                }
                else
                {
                    CreateBABIRecordInCrm.Attributes.Add("etel_accountid", new Microsoft.Xrm.Sdk.EntityReference("account", CustomerGuid));
                }

                CreatedBiBAUpdateGuid = organizationService.Create(CreateBABIRecordInCrm);
                CreateBILogEntry(request, organizationService);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetCustomerDetail(string CustomerExternalId, OrganizationServiceProxy organizationService)
        {
            string fetchXml = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(CustomerExternalId))
                {
                    //fetchXml = string.Format(FetchXMLs.FetchContactFields, CustomerExternalId);
                    Microsoft.Xrm.Sdk.EntityCollection _EntityCollection = organizationService.RetrieveMultiple(new FetchExpression(fetchXml));
                    if (_EntityCollection != null && _EntityCollection.Entities.Count > 0)
                    {
                        if (_EntityCollection.Entities[0].Attributes.Contains("contactid"))
                        {
                            CustomerGuid = new Guid(_EntityCollection.Entities[0].Attributes["contactid"].ToString());
                        }

                        if (_EntityCollection.Entities[0].Attributes.Contains("fullname"))
                        {
                            CustomerName = _EntityCollection.Entities[0].Attributes["fullname"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreateBILogEntry(AmxPeruModifyBillingAccountRequest request, OrganizationServiceProxy organizationService)
        {
            Guid loggedinUserId = Guid.Empty;
            string BIHeaderRecordGuid = string.Empty;
            string fetchXml = string.Empty;
            string customerType = string.Empty;
            string customerGuidField = string.Empty;

            try
            {

                //Create BI Log Record
                Microsoft.Xrm.Sdk.Entity biLogActivityEnt = new Microsoft.Xrm.Sdk.Entity("etel_bi_log");
                //Identify if its Individual Customer of Corporate Customer
                //Set corresponding customer type and field name to be used later
                if (request.IsIndividual)
                {
                    customerType = "contact";
                    customerGuidField = "etel_individualcustomerid";
                }
                else
                {
                    customerType = "account";
                    customerGuidField = "etel_corporatecustomerid";
                }

                //set up the values for BI Log entry
                //biLogActivityEnt.Attributes.Add("subject", AmxPeruCommon.Constants.tUpdateBA);
                biLogActivityEnt.Attributes.Add("customers", new Microsoft.Xrm.Sdk.EntityReference(customerType, CustomerGuid));
                biLogActivityEnt.Attributes.Add("etel_customerchannel", "CSR_TCRM-BI");
                //biLogActivityEnt.Attributes.Add("etel_description", AmxPeruCommon.Constants.tUpdateBA + " - " + CustomerName);
                biLogActivityEnt.Attributes.Add("scheduledend", DateTime.Now);
                biLogActivityEnt.Attributes.Add("regardingobjectid", new Microsoft.Xrm.Sdk.EntityReference(BiBillingAccountUpdate, CreatedBiBAUpdateGuid));
                biLogActivityEnt.Attributes.Add(customerGuidField, new Microsoft.Xrm.Sdk.EntityReference(customerType, CustomerGuid));
                //set up the values for BI Log entry

                //BI Log Activity is now Created
                Guid CreatedBiLogGuid = organizationService.Create(biLogActivityEnt);

                //set the state and the statuscode of the created record
                Microsoft.Xrm.Sdk.EntityReference moniker = new Microsoft.Xrm.Sdk.EntityReference();
                moniker.LogicalName = "etel_bi_log";
                moniker.Id = CreatedBiLogGuid;
                Microsoft.Xrm.Sdk.OrganizationRequest _OrganizationRequest = new Microsoft.Xrm.Sdk.OrganizationRequest() { RequestName = "SetState" };
                _OrganizationRequest["EntityMoniker"] = moniker;
                Microsoft.Xrm.Sdk.OptionSetValue state = new Microsoft.Xrm.Sdk.OptionSetValue(1);
                Microsoft.Xrm.Sdk.OptionSetValue status = new Microsoft.Xrm.Sdk.OptionSetValue(2);
                _OrganizationRequest["State"] = state;
                _OrganizationRequest["Status"] = status;
                organizationService.Execute(_OrganizationRequest);
                //set the state and the statuscode of the created record                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AmxPeruCreateBillingAccountResponse CreateBillingAccount(AmxPeruCreateBillingAccountRequest request, OrganizationServiceProxy organizationService)
        {
            AmxPeruCreateBillingAccountResponse billingAccountResponse = new AmxPeruCreateBillingAccountResponse();
            //try
            //{
            //    BasicHttpBinding binding = new BasicHttpBinding();
            //    binding.Name = "JavaBilServiceBinding";
            //    binding.OpenTimeout = new TimeSpan(0, 15, 0);
            //    binding.CloseTimeout = new TimeSpan(0, 15, 0);
            //    binding.ReceiveTimeout = new TimeSpan(0, 15, 0);
            //    binding.SendTimeout = new TimeSpan(0, 15, 0);
            //    // EndpointAddress endPointAddress = new EndpointAddress(ConfigurationManager.AppSettings["BilOOBBIService"].ToString());
            //    EndpointAddress endPointAddress = null;
            //    BusinessInteractionServicesClient _BilClient = new BusinessInteractionServicesClient(binding, endPointAddress);

            //    CustomerAccountRequest _CustomerAccountRequest = new CustomerAccountRequest();
            //    _CustomerAccountRequest.action = customerAccountActionEnum.CREATEUPDATE;
            //    _CustomerAccountRequest.actionSpecified = true;
            //    BilOOBServices.CustomerAccount _customerAccount = new BilOOBServices.CustomerAccount();
            //    _customerAccount.id = request.BillingAccountGuid;
            //    //_customerAccount.externalId = request.CustomerExternalId;
            //    _customerAccount.name = request.BillingAccountName;
            //    _customerAccount.accountStatus = request.AccountStatus.ToString();
            //    _customerAccount.accountType = request.AccountType;

            //    Customer _customer = new Customer();
            //    _customer.externalId = request.CustomerExternalId;
            //    Customer[] _Customer = new Customer[1];
            //    _Customer[0] = _customer;
            //    _customerAccount.customer = _Customer;

            //    CustomerBill[] _CustomerBill = new CustomerBill[1];
            //    BilOOBServices.CustomerBill _customerBill = new CustomerBill();

            //    CustomerBillingCycle _CustomerBillingCycle = new CustomerBillingCycle();
            //    _CustomerBillingCycle.id = request.BillCycleCode;

            //    CustomerBillFormat[] _CustomerBillFormat = new CustomerBillFormat[1];
            //    CustomerBillFormat _customerBillFormat = new CustomerBillFormat();
            //    _customerBillFormat.id = request.BillFormatId.ToString();
            //    _customerBillFormat.numberOfCopies = request.BillFormatNumberOfCopies;
            //    _customerBillFormat.numberOfCopiesSpecified = true;
            //    _CustomerBillFormat[0] = _customerBillFormat;

            //    CustomerBillSpec _CustomerBillSpec = new CustomerBillSpec();
            //    _CustomerBillSpec.customerBillFormat = _CustomerBillFormat;
            //    _CustomerBillSpec.allowCallItemization = request.AllowCallItemization;
            //    _CustomerBillSpec.allowCallItemizationSpecified = true;

            //    _customerBill.customerBillingCycle = _CustomerBillingCycle;
            //    _customerBill.customerBillSpec = _CustomerBillSpec;
            //    _CustomerBill[0] = _customerBill;
            //    _customerAccount.customerBill = _CustomerBill;

            //    BilOOBServices.CustomerAccountContact _customerAccountContact = new CustomerAccountContact();
            //    ContactMedium[] _ContactMedium = new ContactMedium[2];

            //    for (int i = 0; i < request.Addresses.Count; i++)
            //    {
            //        if (request.Addresses[i] != null)
            //        {
            //            PostalContact _PostalContactBill = new PostalContact();
            //            _PostalContactBill.externalId = request.Addresses[i].ExternalId;
            //            _PostalContactBill.id = request.Addresses[i].AddressGuid;
            //            _PostalContactBill.addressType = request.Addresses[i].AddressTypeCode;
            //            _ContactMedium[i] = _PostalContactBill;
            //        }
            //    }

            //    CustomerAccountContact[] _CustomerAccountContact = new CustomerAccountContact[1];
            //    _customerAccountContact.contactMedium = _ContactMedium;
            //    _CustomerAccountContact[0] = _customerAccountContact;

            //    _customerAccount.customerAccountContact = _CustomerAccountContact;
            //    _CustomerAccountRequest.customer = _customer;
            //    _CustomerAccountRequest.customerAccount = _customerAccount;
            //    CustomerAccountResponse _CustomerAccountResponse = new CustomerAccountResponse();
            //    _CustomerAccountResponse = (CustomerAccountResponse)_BilClient.processBusinessInteraction(_CustomerAccountRequest);

            //    if (_CustomerAccountResponse != null)
            //    {
            //        if (_CustomerAccountResponse.customerAccounts[0].externalId != null)
            //        {

            //            //Create BI Billing Account Record in CRM
            //            if (request.IsExternal)
            //            {
            //                CreateRecordinCrmBI(request, _CustomerAccountResponse.customerAccounts[0].externalId, organizationService);
            //            }
            //            //Create BI Billing Account Record in CRM

            //            billingAccountResponse.ExernalID = _CustomerAccountResponse.customerAccounts[0].externalId;
            //            billingAccountResponse.Status = AmxPeruCommon.Constants.StatusOK;

            //            CreateBILogEntry(request, organizationService);
            //        }
            //        else
            //        {
            //            throw new Exception(AmxPeruCommon.Constants.BilReturnExternalIdNull);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return billingAccountResponse;

        }

        private void CreateRecordinCrmBI(AmxPeruCreateBillingAccountRequest request, string BAExternalId, OrganizationServiceProxy organizationService)
        {
            try
            {
                Entity CreateBABIRecordInCrm = new Entity(BiBillingAccountCreate);
                CreateBABIRecordInCrm.Attributes.Add("etel_accountname", "BA-" + BAExternalId + "-" + CustomerName);

                foreach (BillingAddress item in request.Addresses)
                {
                    if (item.AddressTypeCode == MailToAddressTypeCode)
                    {
                        CreateBABIRecordInCrm.Attributes.Add("etel_billtoaddress", new EntityReference("etel_customeraddress", new Guid(item.AddressGuid)));
                    }
                    else if (item.AddressTypeCode == BillToAddressTypeCode)
                    {
                        CreateBABIRecordInCrm.Attributes.Add("etel_mailtoaddress", new EntityReference("etel_customeraddress", new Guid(item.AddressGuid)));
                    }
                }

                CreateBABIRecordInCrm.Attributes.Add("etel_numberofcopies", request.BillFormatNumberOfCopies);
                CreateBABIRecordInCrm.Attributes.Add("amxbase_billcycle", new OptionSetValue(Convert.ToInt32(request.BillCycleCode)));
                CreateBABIRecordInCrm.Attributes.Add("etel_allowcallitemizationoninvoice", request.AllowCallItemization);
                CreateBABIRecordInCrm.Attributes.Add("etel_billmediumcode", new OptionSetValue(request.BillFormatId));
                CreateBABIRecordInCrm.Attributes.Add("tclab_baexternalid", BAExternalId);

                if (request.IsIndividual)
                {
                    CreateBABIRecordInCrm.Attributes.Add("etel_customerindividualid", new EntityReference("contact", new Guid(request.CustomerGuid)));
                }
                else
                {
                    CreateBABIRecordInCrm.Attributes.Add("etel_accountid", new EntityReference("account", new Guid(request.CustomerGuid)));
                }

                organizationService.Create(CreateBABIRecordInCrm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreateBILogEntry(AmxPeruCreateBillingAccountRequest request, OrganizationServiceProxy organizationService)
        {
            //Guid loggedinUserId = Guid.Empty;
            //string BIHeaderRecordGuid = string.Empty;
            //string fetchXml = string.Empty;
            //string customerType = string.Empty;
            //string customerGuidField = string.Empty;

            //try
            //{

            //    //Create BI Log Record
            //    Entity biLogActivityEnt = new Entity("etel_bi_log");
            //    //Identify if its Individual Customer of Corporate Customer
            //    //Set corresponding customer type and field name to be used later
            //    if (request.IsIndividual)
            //    {
            //        customerType = "contact";
            //        customerGuidField = "etel_individualcustomerid";
            //    }
            //    else
            //    {
            //        customerType = "account";
            //        customerGuidField = "etel_corporatecustomerid";
            //    }

            //    //set up the values for BI Log entry
            //    biLogActivityEnt.Attributes.Add("subject", AmxPeruCommon.Constants.tCreateBA); //Take the BI Cancel Order record name as subject
            //    biLogActivityEnt.Attributes.Add("customers", new EntityReference(customerType, new Guid(request.CustomerGuid)));
            //    biLogActivityEnt.Attributes.Add("etel_customerchannel", "CSR_TCRM-BI");//change here
            //    biLogActivityEnt.Attributes.Add("etel_description", AmxPeruCommon.Constants.tCreateBA + " - " + request.BillingAccountName);
            //    biLogActivityEnt.Attributes.Add("scheduledend", DateTime.Now);
            //    //biLogActivityEnt.Attributes.Add("etel_bi_headerid", new EntityReference("etel_bi_header", new Guid(BIHeaderRecordGuid)));
            //    biLogActivityEnt.Attributes.Add("regardingobjectid", new EntityReference("etel_bi_billingaccountcreate", new Guid(request.BiCreateBARecordGuid)));
            //    biLogActivityEnt.Attributes.Add(customerGuidField, new EntityReference(customerType, new Guid(request.CustomerGuid)));
            //    //set up the values for BI Log entry

            //    //BI Log Activity is now Created
            //    Guid CreatedBiLogGuid = contextProvider.OrganizationService.Create(biLogActivityEnt);

            //    //set the state and the statuscode of the created record
            //    EntityReference moniker = new EntityReference();
            //    moniker.LogicalName = "etel_bi_log";
            //    moniker.Id = CreatedBiLogGuid;
            //    OrganizationRequest _OrganizationRequest = new OrganizationRequest() { RequestName = "SetState" };
            //    _OrganizationRequest["EntityMoniker"] = moniker;
            //    OptionSetValue state = new OptionSetValue(1);
            //    OptionSetValue status = new OptionSetValue(2);
            //    _OrganizationRequest["State"] = state;
            //    _OrganizationRequest["Status"] = status;
            //    organizationService.Execute(_OrganizationRequest);
            //    //set the state and the statuscode of the created record

            //    //Create BI Log Record
            //    //}
            //    //else
            //    //{
            //    //    throw new Exception(Constants.ActiveBiHeaderNotFound);
            //    //}
            //    //}
            //    //else
            //    //{
            //    //    throw new Exception(Constants.ActiveBiHeaderNotFound);
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public List<Entity> RetrieveBillingAccountByCustomerId(Guid? accountId, Guid? contactId)
        {
            var customerId = accountId ?? contactId;

            QueryExpression billingAccount = new QueryExpression(etel_billingaccount.EntityLogicalName);
            billingAccount.ColumnSet = new ColumnSet("etel_externalid", "etel_billingaccountid", "amxperu_emailaddress", "etel_name");

            if (accountId != null)
            {
                billingAccount.Criteria.AddCondition("etel_accountid", ConditionOperator.Equal, customerId);
            }
            else if (contactId != null)
            {
                billingAccount.Criteria.AddCondition("etel_customerindividualid", ConditionOperator.Equal, customerId);
            }

            var billingAccountList = ContextProvider.OrganizationService.RetrieveMultiple(billingAccount).Entities.ToList();
            return billingAccountList;
        }
    }
}
