using Ericsson.ETELCRM.Business;
using Ericsson.ETELCRM.Business.Abstractions;
using Ericsson.ETELCRM.Business.BulkImport;
using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using Ericsson.ETELCRM.Entities.Crm;
using Ericsson.ETELCRM.Utility;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;


namespace AmxPeruPlugins.Workflow.Bulk_Import
{
    public class IndividualCustomerImport : BulkImportParsingBase<IndividualCustomerImport>
    {
        public IndividualCustomerImport(IActionContext context) : base(context)
        {
        }

        public override void InitiateImport(Annotation annotation)
        {
            var orderCaptureBusiness = ActionContext.Resolve<IOrderCaptureBusiness>();

            var dataContext = ActionContext.XrmDataContext;
            var errorList = new List<string>();
            var bulkorderitemList = new List<etel_bulkorderitem>();

            var corpMainData = this.GetParsedEntity(annotation).ToList();
            var corpDtoList = corpMainData.Select(f => f.Entity).ToList();

            var headerOrderCapture = dataContext.etel_ordercaptureSet.First(o => o.Id == annotation.ObjectId.Id);
            var orderCaptureList = new List<etel_ordercapture>();

            //  Contact individual = new Contact();



            int rowNumber = 0;
            foreach (var corpMain in corpMainData)
            {
                Contact individual = new Contact();
                var corpDto = corpMain.Entity;
                var bulkOrderItem = new etel_bulkorderitem()
                {
                    etel_name = "BulkIndividual" + "" + corpDto.FirstName + "" + corpDto.LastName,
                    // statuscode = new OptionSetValue((int)etel_bulkorderitem_statuscode.),
                    statuscode = new OptionSetValue(831260010),

                };
                bulkorderitemList.Add(bulkOrderItem);

                dataContext.AddRelatedObject(headerOrderCapture, o => o.etel_ordercapture_bulkorderitem, bulkOrderItem);

                try
                {

                    individual["firstname"] = corpDto.FirstName;
                    individual["etel_prefferedgivenname"] = corpDto.PrefferedGivenName;
                    individual["lastname"] = corpDto.LastName;
                    individual["amxperu_motherslastname"] = corpDto.MothersLastName;
                    individual["amxperu_businessname"] = corpDto.BusinessName;
                    individual["etel_languagecode"] = new OptionSetValue(orderCaptureBusiness.ValidateOptionSetValue("contact", "etel_languagecode", corpDto.Language, 1033).Value);
                    //add for Status
                    individual["etel_salutationcode"] = new OptionSetValue(orderCaptureBusiness.ValidateOptionSetValue("contact", "etel_salutationcode", corpDto.Salutation, 1033).Value);
                    individual["gendercode"] = new OptionSetValue(orderCaptureBusiness.ValidateOptionSetValue("contact", "gendercode", corpDto.Gender, 1033).Value);
                    individual["familystatuscode"] = new OptionSetValue(orderCaptureBusiness.ValidateOptionSetValue("contact", "familystatuscode", corpDto.MaritalStatus, 1033).Value);
                    individual["etel_placeofbirth"] = corpDto.PlaceofBirth;
                    individual["birthdate"] = Convert.ToDateTime(corpDto.DateofBirth);
                    individual["mobilephone"] = corpDto.MainPhone;
                    individual["amxperu_otherphonehome"] = corpDto.OtherPhoneForHome;
                    individual["emailaddress1"] = corpDto.Email;
                    individual["amxperu_documenttype"] = new OptionSetValue(orderCaptureBusiness.ValidateOptionSetValue("contact", "amxperu_documenttype", corpDto.DocumentType, 1033).Value);
                    individual["etel_iddocumentnumber"] = corpDto.DocumentID;
                    individual["preferredcontactmethodcode"] = new OptionSetValue(orderCaptureBusiness.ValidateOptionSetValue("contact", "preferredcontactmethodcode", corpDto.ContactMethod, 1033).Value);
                    individual["amxperu_allowmail"] = new OptionSetValue(orderCaptureBusiness.ValidateOptionSetValue("contact", "amxperu_allowmail", corpDto.AllowMail, 1033).Value);
                    individual["amxperu_allowemail"] = new OptionSetValue(orderCaptureBusiness.ValidateOptionSetValue("contact", "amxperu_allowemail", corpDto.AllowEmail, 1033).Value);
                    individual["amxperu_allowbulkemail"] = new OptionSetValue(orderCaptureBusiness.ValidateOptionSetValue("contact", "amxperu_allowbulkemail", corpDto.AllowBulkEmail, 1033).Value);
                    individual["amxperu_allowphone"] = new OptionSetValue(orderCaptureBusiness.ValidateOptionSetValue("contact", "amxperu_allowphone", corpDto.AllowPhone, 1033).Value);
                    individual["amxperu_allowsocialnetworks"] = new OptionSetValue(orderCaptureBusiness.ValidateOptionSetValue("contact", "amxperu_allowsocialnetworks", corpDto.AllowSocialNetwork, 1033).Value);
                    individual["amxperu_allowvisit"] = new OptionSetValue(orderCaptureBusiness.ValidateOptionSetValue("contact", "amxperu_allowvisit", corpDto.AllowSMSInstantMessage, 1033).Value);
                    individual["amxperu_allowfax"] = new OptionSetValue(orderCaptureBusiness.ValidateOptionSetValue("contact", "amxperu_allowfax", corpDto.AllowFax, 1033).Value);
                    individual["company"] = corpDto.CompanyName;
                    individual["jobtitle"] = corpDto.JobTitle;
                    //includeforrole
                    individual["etel_socialmediafacebook"] = corpDto.SocialMediaFacebook;
                    // individual["etel_socialmediafacebook"] = corpDto.SocialMediaFacebook;
                    // individual["etel_socialmediafacebook"] = corpDto.SocialMediaFacebook;
                    //  individual["etel_socialmediafacebook"] = corpDto.SocialMediaFacebook;
                    individual["amxperu_clarocommunityuser"] = corpDto.ClaroCommunityUser;
                    individual["amxperu_claroaccountuser"] = corpDto.ClaroAccountUser;
                    dataContext.AddObject(individual);
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    // corpMain.ErrorList.Add(string.Format(ex.Message));
                }

                bulkOrderItem.etel_rownumber = ++rowNumber;
                bulkOrderItem.etel_errorlog = corpMain.GenerateErrorString();

            }

            var saveResult = dataContext.SaveChanges();
            //  throw new Exception(corpMainData[0].Entity.FirstName + corpMainData[0].Entity.LastName + corpMainData[0].Entity.DocumentID + corpMainData[0].Entity.MainPhone + corpMainData[0].Entity.ExternalId);

        }


        protected override void ValidateRecord(ParsedEntityContainer<IndividualCustomerImport> currentRecord)
        {
            return;
        }
        protected override IndividualCustomerImport ParseData(string[] fields)
        {
            Func<IEnumerator, string> next = enmr => { enmr.MoveNext(); return enmr.Current as string; };

            var enm = fields.GetEnumerator();
            return new IndividualCustomerImport(ActionContext)
            {
                FirstName = next(enm),
                PrefferedGivenName = next(enm),
                LastName = next(enm),
                MothersLastName = next(enm),
                BusinessName = next(enm),
                Language = next(enm),
                Status = next(enm),
                Salutation = next(enm),
                Gender = next(enm),
                MaritalStatus = next(enm),
                PlaceofBirth = next(enm),
                DateofBirth = next(enm),
                MainPhone = next(enm),
                OtherPhoneForHome = next(enm),
                Email = next(enm),
                DocumentType = next(enm),
                DocumentID = next(enm),
                ContactMethod = next(enm),
                AllowMail = next(enm),
                AllowEmail = next(enm),
                AllowBulkEmail = next(enm),
                AllowPhone = next(enm),
                AllowSocialNetwork = next(enm),
                AllowSMSInstantMessage = next(enm),
                AllowFax = next(enm),
                CompanyName = next(enm),
                JobTitle = next(enm),
                Role = next(enm),
                SocialMediaFacebook = next(enm),
                SocialMediaInstagram = next(enm),
                SocialMediaTwitter = next(enm),
                SocialMediaLinkedIn = next(enm),
                ClaroCommunityUser = next(enm),
                ClaroAccountUser = next(enm),
            };
        }

        public override int RetrieveFieldCount()
        {
            return 34;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MainPhone { get; set; }
        public string Salutation { get; set; }
        public string Language { get; set; }
        public string Gender { get; set; }
        public string DocumentType { get; set; }
        public string DocumentID { get; set; }
        public string BusinessName { get; set; }
        public string PrefferedGivenName { get; set; }
        //Remaining Fields
        public string MothersLastName { get; set; }
        public string MarketSegment { get; set; }
        public string BlacklistStatus { get; set; }
        public string Status { get; set; }
        public string ExternalId { get; set; }
        public string AccountNumber { get; set; }
        public string BlacklistStatusReason { get; set; }
        public string PaymentResponsible { get; set; }
        public string OCCRatePlan { get; set; }
        public string MaritalStatus { get; set; }
        public string PlaceofBirth { get; set; }
        public string DateofBirth { get; set; }
        public string OtherPhoneForBusiness { get; set; }
        public string OtherPhoneForHome { get; set; }
        public string Email { get; set; }
        public string Addresstype { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string ZIPOrPostalCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string PersonalNotes { get; set; }
        public string ContactMethod { get; set; }
        public string AllowMail { get; set; }
        public string AllowEmail { get; set; }
        public string AllowBulkEmail { get; set; }
        public string AllowPhone { get; set; }
        public string AllowSocialNetwork { get; set; }
        public string AllowSMSInstantMessage { get; set; }
        public string AllowFax { get; set; }
        public string PrefferedDay { get; set; }
        public string PrefferedTime { get; set; }
        public string PaymentArrangement { get; set; }
        public string PaymentTerm { get; set; }
        public string ValidFrom { get; set; }
        public string OriginatingLead { get; set; }
        public string SendMarketingMate { get; set; }
        public string LastDateIncludedIn { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string AnnualIncome { get; set; }
        public string Role { get; set; }
        public string Currency { get; set; }
        public string SocialMediaFacebook { get; set; }
        public string SocialMediaInstagram { get; set; }
        public string SocialMediaTwitter { get; set; }
        public string SocialMediaLinkedIn { get; set; }
        public string Nickname { get; set; }
        public string ClaroCommunityUser { get; set; }
        public string ClaroAccountUser { get; set; }
    }
}


