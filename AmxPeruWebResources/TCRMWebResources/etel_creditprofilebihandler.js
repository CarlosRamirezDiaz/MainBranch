var FORM_TYPE_CREATE = 1;
var FORM_TYPE_UPDATE = 2;
var ExternalId;

var translationScope_js_BI_CreditProfile = {
    data: null,
    GetData: function () {
        var formId = 'js_BI_CreditProfile';
        if (translationScope_js_BI_CreditProfile.data != null) {
            return;
        }
        translationScope_js_BI_CreditProfile.data = GetTranslationData(formId);
    }
};

var customerDep = {
    LogicalName: "",
    EntityCode: undefined,
    Id: "",
    Name: "",
    GetCustomer: function () {
        translationScope_js_BI_CreditProfile.GetData();
        var entityType = Xrm.Page.data.entity.getEntityName();
        if (entityType === "contact") {
            customerDep.EntityCode = 2;
            customerDep.Name = getValueFromDB("ContactSet", "ContactId", Xrm.Page.data.entity.getId(), "FullName");
            customerDep.LogicalName = entityType;
            customerDep.Id = Xrm.Page.data.entity.getId();
        }
        else if (entityType === "account") {
            customerDep.EntityCode = 1;
            customerDep.Name = getValueFromDB("AccountSet", "AccountId", Xrm.Page.data.entity.getId(), "Name");
            customerDep.LogicalName = entityType;
            customerDep.Id = Xrm.Page.data.entity.getId();
        }
        else if (entityType === "etel_bicreditprofilecreate") {
            if (Xrm.Page.getAttribute("etel_individualid").getValue() != null) {
                var customerIndividualField = Xrm.Page.getAttribute("etel_individualid").getValue();
            }
            else {
                var customerCorporateField = Xrm.Page.getAttribute("etel_corporateid").getValue();
            }
            if (customerIndividualField) {
                customerDep.EntityCode = 2;
                customerDep.Id = customerIndividualField[0].id;
                customerDep.Name = customerIndividualField[0].name;
                customerDep.LogicalName = "contact";
            }
            else if (customerCorporateField) {
                customerDep.EntityCode = 1;
                customerDep.Id = customerCorporateField[0].id;
                customerDep.Name = customerCorporateField[0].name;
                customerDep.LogicalName = "account";
            }
        }
    }
};

var settings = {
    ServerURL: "",
    CurrentUserId: "",
    GetUrl: function () {
        translationScope_js_BI_CreditProfile.GetData();
        Xrm.Page.context.getClientUrl();
        if (settings.ServerURL.match(/\/$/)) {
            settings.ServerURL = settings.ServerURL.substring(0, settings.ServerURL.length - 1);
        }
        if (typeof Xrm.Page.context.getClientUrl != "undefined") {
            settings.ServerURL = Xrm.Page.context.getClientUrl();
        }
    },
    GetCurrentUserId: function () {
        translationScope_js_BI_CreditProfile.GetData();
        settings.CurrentUserId = Xrm.Page.context.getUserId();
    },
    Initialise: function () {
        translationScope_js_BI_CreditProfile.GetData();
        settings.GetUrl();
        settings.GetCurrentUserId();
    }
};

var biRoleSecurityCreditProfile = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_js_BI_CreditProfile.GetData();

        biRoleSecurityCreditProfile.IsValidatedRole = Util.Security.UserHasBIPrivilage("etel_bicreditprofilecreate");
    }
};

var biAutoNumberCreditProfile = {
    IsCreated: "",
    BINumber: "",
    CreateBINumber: function () {
        translationScope_js_BI_CreditProfile.GetData();
        var request = new PrepareRequest(new CreateBINumberRequest());
        retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
            biAutoNumberCreditProfile.IsCreated = data.Success;
            biAutoNumberCreditProfile.BINumber = data.BINumber;
        });
    }
};

var biSecurityCreditProfile = {
    IsValidated: "",
    Validate: function () {
        translationScope_js_BI_CreditProfile.GetData();
        var request = new PrepareRequest(new CreditProfileSecurityRequest('etel_bicreditprofilecreate', customerDep.Id, customerDep.EntityCode, settings.CurrentUserId));
        retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
            biSecurityCreditProfile.IsValidated = data.IsValidated;
        });
    }
};

var biRoleSecurityCreditProfile = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_js_BI_CreditProfile.GetData();

        biRoleSecurityCreditProfile.IsValidatedRole = Util.Security.UserHasBIPrivilage("etel_bicreditprofilecreate");
    }
};

function ValidateRole() {
    biRoleSecurityCreditProfile.ValidateRole();
    return biRoleSecurityCreditProfile.IsValidatedRole;
};

function popupCreditProfileCreateForm(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName) {
    translationScope_js_BI_CreditProfile.GetData();
    customerDep.GetCustomer();

    settings.Initialise();

    var headercheck = false;
    headercheck = headerCheck(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName);

    if (headercheck) {
        biSecurityCreditProfile.Validate(selectedEntityId, selectedEntityCode);

        if (biSecurityCreditProfile.IsValidated === true) {
            biAutoNumberCreditProfile.CreateBINumber();
            if (biAutoNumberCreditProfile.IsCreated === true) {



                var creditProfileObject = {};
                creditProfileObject.etel_binumber = biAutoNumberCreditProfile.BINumber;
                creditProfileObject.etel_name = biAutoNumberCreditProfile.BINumber + ' - ' + translationScope_js_BI_CreditProfile.data.tCreditProfileCreate;
                if (customerDep.EntityCode === 2) {
                    creditProfileObject.etel_individualid = { Id: customerDep.Id, LogicalName: "contact" };
                }
                else if (customerDep.EntityCode === 1) {
                    creditProfileObject.etel_corporateid = { Id: customerDep.Id, LogicalName: "account" };

                }

                createCrmRecordUsingOData(creditProfileObject, "etel_bicreditprofilecreate", _ODataPath(), function (creditProfile) {
                    var entityId = creditProfile.etel_bicreditprofilecreateId;
                    Xrm.Utility.openEntityForm("etel_bicreditprofilecreate", entityId);
                },
                    function () { alert("Error") }, false);


            }
            else {
                alert(translationScope_js_BI_CreditProfile.data.tCreationBINumberMessage);
            }
        } else {
            alert(translationScope_js_BI_CreditProfile.data.tValidationCheck);
        }
    }
}

function popupCreditProfileUpdateForm(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName) {
    translationScope_js_BI_CreditProfile.GetData();
    var angular = Xrm.Page.ui.controls.get("WebResource_monetarytransactionstabbedview").getObject().contentWindow.angular;
    var selectedItems = null;
    if (angular) {
        selectedItems = angular.element(".main-container").scope().CreditProfileScopeSelectedItems;
    }
    else {
        alert(translationScope_js_BI_CreditProfile.data.tSelectCreditProfile);
        return;
    }

    //[0].RowData
    if (selectedItems && selectedItems[0]) {
        var selectedCreditProfile = selectedItems[0];
        customerDep.GetCustomer();

        settings.Initialise();

        var headercheck = false;
        headercheck = headerCheck(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName);

        if (headercheck) {
            biSecurityCreditProfile.Validate(selectedEntityId, selectedEntityCode);

            if (biSecurityCreditProfile.IsValidated === true) {
                biAutoNumberCreditProfile.CreateBINumber();
                if (biAutoNumberCreditProfile.IsCreated === true) {

                    var item = [];
                    for (var creditProfile in selectedCreditProfile) {
                        item[creditProfile] = selectedCreditProfile[creditProfile];

                        var creditProfileObject = {};
                        creditProfileObject.etel_binumber = biAutoNumberCreditProfile.BINumber;
                        creditProfileObject.etel_name = biAutoNumberCreditProfile.BINumber;
                        creditProfileObject.etel_name = biAutoNumberCreditProfile.BINumber + ' - ' + translationScope_js_BI_CreditProfile.data.tCreditProfileUpdate;

                        if (customerDep.EntityCode === 2) {
                            creditProfileObject.etel_individualid = { Id: customerDep.Id, LogicalName: "contact" };
                        }
                        else if (customerDep.EntityCode === 1) {
                            creditProfileObject.etel_corporateid = { Id: customerDep.Id, LogicalName: "account" };
                        }

                        if (item[creditProfile].RowData.etel_name != null) {
                            creditProfileObject.etel_creditprofileno = item[creditProfile].RowData.etel_name;
                        }

                        if (item[creditProfile].RowData.etel_creditriskrating != null) {
                            creditProfileObject.etel_creditriskrating = item[creditProfile].RowData.etel_creditriskrating;
                        }

                        if (item[creditProfile].RowData.etel_creditscore != null) {
                            creditProfileObject.etel_creditscore = item[creditProfile].RowData.etel_creditscore;
                        }

                        if (item[creditProfile].RowData.etel_startdate != null) {
                            creditProfileObject.etel_startdate = item[creditProfile].RowData.etel_startdate;
                        }

                        if (item[creditProfile].RowData.etel_enddate != null) {
                            creditProfileObject.etel_enddate = item[creditProfile].RowData.etel_enddate;
                        }

                        if (item[creditProfile].RowData.etel_financialinstitutionidguid != null) {
                            creditProfileObject.etel_financialinstitutionid = { Id: item[creditProfile].RowData.etel_financialinstitutionidguid, LogicalName: "etel_financialinstitution" };
                        }

                        if (item[creditProfile].RowData.etel_institutionaccountnumber != null) {
                            creditProfileObject.etel_institutionaccountnumber = item[creditProfile].RowData.etel_institutionaccountnumber;
                        }

                        if (item[creditProfile].RowData.etel_institutionaccounttype != null) {
                            creditProfileObject.etel_institutionaccounttype = item[creditProfile].RowData.etel_institutionaccounttype;
                        }

                        ///////////extended///////////////
                        debugger;

                        if (item[creditProfile].RowData.amxperu_CurrentBureauCreditLimit != null) {
                            creditProfileObject.amxperu_CurrentBureauCreditLimit = item[creditProfile].RowData.amxperu_CurrentBureauCreditLimit;
                        //    creditProfileObject.amxperu_currentbureaucreditlimitdec = item[creditProfile].RowData.amxperu_CurrentBureauCreditLimit;                         
                        }

                        if (item[creditProfile].RowData.amxperu_CurrentCRMCreditLimit != null) {
                            creditProfileObject.amxperu_CurrentCRMCreditLimit = item[creditProfile].RowData.amxperu_CurrentCRMCreditLimit;
                        }

                        if (item[creditProfile].RowData.amxperu_CurrentWalletsCreditLimits != null) {
                            creditProfileObject.amxperu_CurrentWalletsCreditLimits = item[creditProfile].RowData.amxperu_CurrentWalletsCreditLimits;
                        }

                        //if (item[creditProfile].RowData.amxperu_ConfirmedCRMCreditLimit != null) {
                        //    creditProfileObject.amxperu_confirmedcrmcreditlimit = item[creditProfile].RowData.amxperu_ConfirmedCRMCreditLimit;
                        //}

                        //if (item[creditProfile].RowData.amxperu_RequestedCRMCreditLimit != null) {
                        //    creditProfileObject.amxperu_requestedcrmcreditlimit = item[creditProfile].RowData.amxperu_RequestedCRMCreditLimit;
                        //}

                        

                        //if (item[creditProfile].RowData.amxperu_ChangeReason != null) {
                        //    creditProfileObject.amxperu_changereason = item[creditProfile].RowData.amxperu_ChangeReason;
                        }

                        createCrmRecordUsingOData(creditProfileObject, "etel_bicreditprofileupdate", _ODataPath(), function (creditProfile) {
                            var entityId = creditProfile.etel_bicreditprofileupdateId;
                            Xrm.Utility.openEntityForm("etel_bicreditprofileupdate", entityId);
                        },
                            function () { alert("Error") }, false);
                    }
                }
                else {
                    alert(translationScope_js_BI_CreditProfile.data.tCreationBINumberMessage);
                }
            } else {
                alert(translationScope_js_BI_CreditProfile.data.tValidationCheck);
            }
        }

    }
    else {
        alert(translationScope_js_BI_CreditProfile.data.tSelectCreditProfile);
    }
}

function CreditProfileUpdateOnLoad() {
    var previousEndDateAttribute = Xrm.Page.getAttribute("etel_previousenddate");
    previousEndDateAttribute.setValue(Xrm.Page.getAttribute("etel_enddate").getValue());
    previousEndDateAttribute.setSubmitMode("never");

}

function DateOnChange() {

    var startdate = Xrm.Page.getAttribute("etel_startdate").getValue();
    var enddate = Xrm.Page.getAttribute("etel_enddate").getValue();
    var previousenddate = null;

    var EntityName = Xrm.Page.data.entity.getEntityName();
    if (EntityName == "etel_bicreditprofileupdate") {

        previousenddate = Xrm.Page.getAttribute("etel_previousenddate").getValue();
    }

    if ((startdate != null) && (enddate != null)) {
        if (startdate >= enddate) {
            translationScope_js_BI_CreditProfile.GetData();
            alert(translationScope_js_BI_CreditProfile.data.tDateWarningMessage);

            var EntityName = Xrm.Page.data.entity.getEntityName();
            if (EntityName == "etel_bicreditprofilecreate") {
                Xrm.Page.getAttribute("etel_startdate").setValue(null);
                Xrm.Page.getAttribute("etel_enddate").setValue(null);
            }
            else {
                Xrm.Page.getAttribute("etel_enddate").setValue(previousenddate);
            }
        }
    }
}

function InstitutionNameOnChange() {

    var institutionname = Xrm.Page.getAttribute("etel_financialinstitutionid").getValue();

    if (institutionname == null) {
        Xrm.Page.getAttribute("etel_institutionaccountnumber").setValue(null);
        Xrm.Page.getAttribute("etel_institutionaccounttype").setValue(null);
    }
}

var CreditProfileCreateBIRequestFields = {
    SOURCE: "etel_source",
    INDIVIDUAL_ID: "etel_individualid",
    CORPORATE_ID: "etel_corporateid",
    CREDIT_RISK_RATING: "etel_creditriskrating",
    CREDIT_SCORE: "etel_creditscore",
    INSTITUTION_CODE: "etel_financialinstitutionid",
    INSTITUTION_ACCOUNT_NUMBER: "etel_institutionaccountnumber",
    INSTITUTION_ACCOUNT_TYPE: "etel_institutionaccounttype",
    START_DATE: "etel_startdate",
    END_DATE: "etel_enddate",
    SUBMIT: "etel_submit",
    LIFE_CYCLE_STATUS: "etel_lifecyclestatus",
    BI_NUMBER: "etel_binumber",
    CREDIT_PROFILE_NUMBER: "etel_creditprofileno"
}

var CreditProfileBIType = {
    CREATE: "create",
    UPDATE: "update"
}

//---- Create BI

function executeCreateBISubmit() {
    translationScope_js_BI_CreditProfile.GetData();

    Xrm.Page.data.save().then(postCreateBISaveSuccess, postCreateBISaveFail);
}

function postCreateBISaveFail() {
    Xrm.Page.data.entity.save('save');
    postSaveSuccess();
}

function postCreateBISaveSuccess() {
    postBISave(CreditProfileBIType.CREATE);
}


//---- Update BI


function executeUpdateBISubmit() {
    translationScope_js_BI_CreditProfile.GetData();

    Xrm.Page.data.save().then(postUpdateBISaveSuccess, postUpdateBISaveFail);
}

function postUpdateBISaveFail() {
    Xrm.Page.data.entity.save('save');
    postSaveSuccess();
}

function postUpdateBISaveSuccess() {
    postBISave(CreditProfileBIType.UPDATE);
}


function postBISave(creditProfileBIType) {

    Xrm.Page.data.entity.save('save');
    var activityRequestType = "ExternalApiActivities.Models.CustomerCreditProfileRequestModel, ExternalApiActivities";
    var activityProfileType = "ExternalApiActivities.Models.CustomerCreditProfileModel, ExternalApiActivities";

    //fields
    var source = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.SOURCE);
    var individualId = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.INDIVIDUAL_ID);
    var corporateId = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.CORPORATE_ID);
    var creditRiskRating = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.CREDIT_RISK_RATING);
    var creditScore = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.CREDIT_SCORE);
    var institutionCode = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.INSTITUTION_CODE);
    var institutionAccountNumber = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.INSTITUTION_ACCOUNT_NUMBER);
    var institutionAccountType = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.INSTITUTION_ACCOUNT_TYPE);
    var startDate = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.START_DATE);
    var endDate = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.END_DATE);
    var biNumber = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.BI_NUMBER);



    var submitCheck = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.SUBMIT);
    var lifeCycleStatus = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.LIFE_CYCLE_STATUS);
    var Reason = '';
    var creditProfileBiId = Xrm.Page.data.entity.getId();
    var EntityName = Xrm.Page.data.entity.getEntityName();

    var customer = null;
    var customerAccountNumber;
    if (individualId.getValue() != null) {
        customer = individualId.getValue();
        retrieveMultipleRecords("Contact", "$select=etel_accountnumber&$filter=ContactId eq guid'" + customer[0].id + "'",
            function (results) {
                if (results != null && results.length == 1) {
                    customerAccountNumber = results[0].etel_accountnumber;
                }
            }, function error(error) {

            }, function complete() {

            });
    }
    else {
        customer = corporateId.getValue();
        retrieveMultipleRecords("Account", "$select=AccountNumber&$filter=AccountId eq guid'" + customer[0].id + "'",
            function (results) {
                if (results != null && results.length == 1) {
                    customerAccountNumber = results[0].AccountNumber;
                }
            }, function error(error) {

            }, function complete() {

            });

    }

    var financialInstitutionCode;
    var fic = institutionCode.getValue();
    if (fic != null) {
        retrieveMultipleRecords("etel_financialinstitution", "$select=etel_code&$filter=etel_financialinstitutionId eq guid'" + fic[0].id + "'",
            function (results) {
                if (results != null && results.length == 1) {
                    financialInstitutionCode = results[0].etel_code;
                }
            }, function error(error) {

            }, function complete() {

            });
    }


    var creditProfileNumber;
    if (creditProfileBIType == CreditProfileBIType.CREATE) {
        var psbAction = "CreateCustomerCreditProfile";
    }
    else {
        var psbAction = "UpdateCustomerCreditProfile";
        creditProfileNumber = Xrm.Page.getAttribute(CreditProfileCreateBIRequestFields.CREDIT_PROFILE_NUMBER).getValue();
    }

    var profile = {
        "$type": activityProfileType,
        "Source": "TCRM",
        "CreditRiskRating": creditRiskRating.getValue(),
        "CreditScore": creditScore.getValue(),
        "InstitutionCode": financialInstitutionCode,
        "InstitutionAccountNumber": institutionAccountNumber.getValue(),
        "InstitutionAccountType": institutionAccountType.getValue(),
        "StartDate": new Date(startDate.getValue().getTime() - (startDate.getValue().getTimezoneOffset() * 60000)),
        "EndDate": new Date(endDate.getValue().getTime() - (endDate.getValue().getTimezoneOffset() * 60000)),
        "BINumber": biNumber.getValue(),
        "CreditProfileNumber": creditProfileNumber,
    }

    var reqData = {
        "customerCreditProfileRequestModel": {
            "$type": activityRequestType,
            "CustomerId": customerAccountNumber,
            "CustomerCreditProfiles": [profile]
        }
    }

    var psbServiceUrl = getPsbRestServiceUrl();
    var jsonString = JSON.stringify(reqData);
    var responseText = $.ajax({
        type: "POST",
        contentType: "application/json",
        url: psbServiceUrl + psbAction,
        data: jsonString,
        async: false,
        xhrFields: {
            withCredentials: true
        },
        success: function (data, textStatus, XmlHttpRequest) {
            var outProfile = data.Output.customerCreditProfileRequestModel.CustomerCreditProfiles["0"];
            if (outProfile.IsError == true) {
                lifeCycleStatus.setValue(831260002);
                alert(outProfile.ErrorDescription);
            } else {
                lifeCycleStatus.setValue(831260001);
                alert(translationScope_js_BI_CreditProfile.data.tSubmitSuccessMessage);
            }
        },
        error: function (XmlHttpRequest, textStatus, errorThrown) {
            lifeCycleStatus.setValue(831260002);
            var errorMessage = XmlHttpRequest.responseJSON.ExceptionMessage;
            alert(translationScope_js_BI_CreditProfile.data.tSubmitFailMessage + " Error Detail : " + errorMessage);
        }
    });

    submitCheck.setValue(true);

    var attributes = Xrm.Page.data.entity.attributes.get();
    for (var i in attributes) {
        var attribute = attributes[i];
        if (attribute.getIsDirty())
            attribute.setSubmitMode("always");
    }
    submitCheck.setSubmitMode('always');
    lifeCycleStatus.setSubmitMode('always');
    Xrm.Page.data.entity.save('save');

    var attributes = Xrm.Page.data.entity.attributes.get();
    for (var i in attributes) {
        var attribute = attributes[i];
        if (attribute.getIsDirty())
            attribute.setSubmitMode("never");
    }

    if (individualId.getValue() != null) {
        Xrm.Utility.openEntityForm("contact", customer[0].id);
    }
    else {
        Xrm.Utility.openEntityForm("account", customer[0].id);
    }
}


function preventAutoSave(econtext) {
    var eventArgs = econtext.getEventArgs();
    if (eventArgs.getSaveMode() == 70 || eventArgs.getSaveMode() == 2) {
        eventArgs.preventDefault();
    }
}