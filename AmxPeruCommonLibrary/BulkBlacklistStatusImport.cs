using Ericsson.ETELCRM.Business;
using Ericsson.ETELCRM.Business.Abstractions;
using Ericsson.ETELCRM.Business.BulkImport.Common;
using Ericsson.ETELCRM.Business.BulkImport.Interfaces;
using Ericsson.ETELCRM.CrmFoundationLibrary.Business;
using Ericsson.ETELCRM.CrmFoundationLibrary.Exceptions.BaseExceptions;
using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using Ericsson.ETELCRM.Entities.Crm;
using Ericsson.ETELCRM.Repository;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;

namespace AmxPeruCommonLibrary.Business
{
    public class BulkBlacklistStatusImport : BusinessBase, IBulkBlacklistStatusImport, IBusinessBase
    {
        private IBulkImportParsingBase<ChangeBlackListStatus> blacklist;

        private ITranslationBusiness translationBusiness { get; set; }

        private ISystemUserBusiness systemUserBusiness { get; set; }

        public BulkBlacklistStatusImport(IActionContext actionContext)
          : base(actionContext)
        {
            this.blacklist = this.ActionContext.Resolve<IBulkImportParsingBase<ChangeBlackListStatus>>();
            this.translationBusiness = this.ActionContext.Resolve<ITranslationBusiness>();
            this.systemUserBusiness = this.ActionContext.Resolve<ISystemUserBusiness>();
        }

        public void InitiateBulkBlacklistImport(Annotation annotation)
        {
            this.blacklist.InitiateImport(annotation);
        }

        public List<Annotation> RetrieveByObjId(string entityLogicalName, Guid primaryEntityId)
        {
            return this.ActionContext.Resolve<IChangeBlacklistStatusRepository>().RetrieveByObjId(entityLogicalName, primaryEntityId);
        }

        public void Submit(Guid biChangeBlackStatusId, bool CustomerNotFound, string description)
        {
            int? languageCodeByUserId = this.systemUserBusiness.GetLanguageCodeByUserId(this.ActionContext.UserInformation.UserId);
            int languageId = languageCodeByUserId.HasValue ? languageCodeByUserId.Value : 1033;
            etel_bi_changeblackliststatus changeblackliststatus1 = new etel_bi_changeblackliststatus();
            changeblackliststatus1.etel_description = description;
            changeblackliststatus1.Id = biChangeBlackStatusId;
            if (string.IsNullOrWhiteSpace(changeblackliststatus1.etel_description))
            {
                changeblackliststatus1.etel_submit = new bool?(true);
                changeblackliststatus1.etel_lifecyclestatus = new OptionSetValue(831260001);
                changeblackliststatus1.etel_description = this.translationBusiness.GetTranslationMessageOfAnElement(languageId, "ErrorCode", "SUBMITTED_SUCCESSFULLY");
            }
            else
            {
                if (!CustomerNotFound)
                    changeblackliststatus1.etel_submit = new bool?(true);
                changeblackliststatus1.etel_lifecyclestatus = new OptionSetValue(831260002);
            }
            etel_bi_changeblackliststatus changeblackliststatus2 = this.ActionContext.Resolve<IChangeBlacklistStatusRepository>().Update(changeblackliststatus1);
            if (changeblackliststatus2.etel_submit.HasValue)
            {
                bool? etelSubmit = changeblackliststatus2.etel_submit;
                bool flag = false;
                if ((etelSubmit.GetValueOrDefault() == flag ? (etelSubmit.HasValue ? 1 : 0) : 0) == 0)
                    return;
            }
            this.ActionContext.Resolve<IChangeBlacklistStatusRepository>().SetEntityState(new EntityReference("etel_bi_changeblackliststatus", changeblackliststatus2.Id), 1, 831260001);
        }

        public void SingleChangeBlacklistStatusProcess(etel_bi_changeblackliststatus biChangeBlackStatus, ref bool CustomerNotFound)
        {
            if (biChangeBlackStatus.etel_corporateid != null)
            {
                IAccountBusiness accountBusiness = this.ActionContext.Resolve<IAccountBusiness>();
                Account account = accountBusiness.RetrieveAccountById(biChangeBlackStatus.etel_corporateid.Id);
                if (account != null)
                {
                    if (account.IsActiveCustomerOrSuspend())
                    {
                        if (account.CheckCustomerNewBlacklistStatusIsDifferent(biChangeBlackStatus.etel_newblackliststatus))
                            accountBusiness.UpdateBlacklistStatusField(account, biChangeBlackStatus);
                        else if (string.IsNullOrEmpty(biChangeBlackStatus.etel_description))
                        {
                            UserLevelException userLevelException = new UserLevelException();
                            string str = string.Format("{0} : ", (object)biChangeBlackStatus.etel_corporateid.Name) + "99036";
                            userLevelException.ErrorCode = str;
                            throw userLevelException;
                        }
                    }
                    else
                    {
                        CustomerNotFound = true;
                        if (string.IsNullOrEmpty(biChangeBlackStatus.etel_description))
                        {
                            UserLevelException userLevelException = new UserLevelException();
                            string str = string.Format("{0} : ", (object)biChangeBlackStatus.etel_corporateid.Name) + "99029";
                            userLevelException.ErrorCode = str;
                            throw userLevelException;
                        }
                    }
                }
                else
                {
                    CustomerNotFound = true;
                    if (string.IsNullOrEmpty(biChangeBlackStatus.etel_description))
                    {
                        UserLevelException userLevelException = new UserLevelException();
                        string str = "99030";
                        userLevelException.ErrorCode = str;
                        throw userLevelException;
                    }
                }
            }
            else if (biChangeBlackStatus.etel_individualid != null)
            {
                IContactBusiness contactBusiness = this.ActionContext.Resolve<IContactBusiness>();
                Contact contact = contactBusiness.RetrieveContactById(biChangeBlackStatus.etel_individualid.Id);
                if (contact != null)
                {
                    if (contact.IsActiveCustomerOrSuspend())
                    {
                        if (contact.CheckCustomerNewBlacklistStatusIsDifferent(biChangeBlackStatus.etel_newblackliststatus))
                        {
                            Entity biUpdate = new Entity("etel_bi_blackliststatuschange");
                            biUpdate = this.ActionContext.OrganizationService.Retrieve(biChangeBlackStatus.LogicalName, biChangeBlackStatus.Id, new ColumnSet(true));

                            Entity contactUpdate = new Entity("contact");
                            contactUpdate = this.ActionContext.OrganizationService.Retrieve(contact.LogicalName, contact.Id, new ColumnSet(true));
                            contactUpdate["etel_blackliststatuscode"] = new OptionSetValue(biChangeBlackStatus.etel_newblackliststatus.Value);

                            Entity historyUpdate = new Entity("etel_blacklisthistory");
                            historyUpdate["etel_sourcecode"] = new OptionSetValue(831260000);
                            historyUpdate["etel_date"] = biChangeBlackStatus.CreatedOn.Value;
                            historyUpdate["etel_blackliststatuscode"] = new OptionSetValue(biChangeBlackStatus.etel_newblackliststatus.Value);
                            historyUpdate["etel_description"] = biChangeBlackStatus.etel_reason;
                            historyUpdate["etel_individualcustomerid"] = new EntityReference(contact.LogicalName, contact.Id);

                            if (biUpdate.Attributes.Contains("amxperu_validity"))
                            {
                                contactUpdate["amxperu_blackliststatusvalidity"] = biUpdate["amxperu_validity"];
                                historyUpdate["amxperu_validity"] = biUpdate["amxperu_validity"];
                            }
                            else
                            {
                                contactUpdate["amxperu_blackliststatusvalidity"] = null;
                                historyUpdate["amxperu_validity"] = null;
                            }

                            try
                            {
                                this.ActionContext.OrganizationService.Update(contactUpdate);
                                this.ActionContext.OrganizationService.Create(historyUpdate);
                            }
                            catch (Exception ex)
                            {
                                this.ActionContext.XrmDataContext.Detach((Entity)contact);
                                throw ex;
                            }
                        }
                        else if (string.IsNullOrEmpty(biChangeBlackStatus.etel_description))
                        {
                            UserLevelException userLevelException = new UserLevelException();
                            string str = string.Format("{0} : ", (object)biChangeBlackStatus.etel_individualid.Name) + "99037";
                            userLevelException.ErrorCode = str;
                            throw userLevelException;
                        }
                    }
                    else
                    {
                        CustomerNotFound = true;
                        if (string.IsNullOrEmpty(biChangeBlackStatus.etel_description))
                        {
                            UserLevelException userLevelException = new UserLevelException();
                            string str = string.Format("{0} : ", (object)biChangeBlackStatus.etel_individualid.Name) + "99031";
                            userLevelException.ErrorCode = str;
                            throw userLevelException;
                        }
                    }
                }
                else
                {
                    CustomerNotFound = true;
                    if (string.IsNullOrEmpty(biChangeBlackStatus.etel_description))
                    {
                        UserLevelException userLevelException = new UserLevelException();
                        string str = "99032";
                        userLevelException.ErrorCode = str;
                        throw userLevelException;
                    }
                }
            }
            else
            {
                CustomerNotFound = true;
                if (string.IsNullOrEmpty(biChangeBlackStatus.etel_description))
                {
                    UserLevelException userLevelException = new UserLevelException();
                    string str = "99033";
                    userLevelException.ErrorCode = str;
                    throw userLevelException;
                }
            }
        }

        public void MultipleChangeBlacklistStatusProcess(etel_bi_changeblackliststatus biChangeBlackStatus)
        {
            IBulkBlacklistStatusImport blacklistStatusImport = this.ActionContext.Resolve<IBulkBlacklistStatusImport>();
            List<Annotation> annotationList = blacklistStatusImport.RetrieveByObjId("annotation", biChangeBlackStatus.Id);
            if (annotationList != null)
            {
                if (annotationList.Count == 1)
                {
                    blacklistStatusImport.InitiateBulkBlacklistImport(annotationList[0]);
                }
                else
                {
                    if (annotationList.Count == 0)
                    {
                        UserLevelException userLevelException = new UserLevelException();
                        string str = "99038";
                        userLevelException.ErrorCode = str;
                        throw userLevelException;
                    }
                    UserLevelException userLevelException1 = new UserLevelException();
                    string str1 = "99034";
                    userLevelException1.ErrorCode = str1;
                    throw userLevelException1;
                }
            }
            else
            {
                UserLevelException userLevelException = new UserLevelException();
                string str = "99035" + string.Format("{0}", (object)biChangeBlackStatus.Id);
                userLevelException.ErrorCode = str;
                throw userLevelException;
            }
        }
    }
}