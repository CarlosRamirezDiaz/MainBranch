var soapCallBacktoWCF, soapCallBacktoWcfErrorMessage;

var translationScope_js_BI_CustomerBillingAccount = {
    data: null,
    GetData: function () {
        var formId = 'js_BI_CustomerBillingAccount';
        if (translationScope_js_BI_CustomerBillingAccount.data != null) {
            return;
        }
        translationScope_js_BI_CustomerBillingAccount.data = GetTranslationData(formId);
    }
};

var customerCreateBA = {
    LogicalName: "",
    Id: "",
    EntityCode: 0,
    GetCustomer: function () {
        translationScope_js_BI_CustomerBillingAccount.GetData();
        var entityType = Xrm.Page.data.entity.getEntityName();
        if (entityType === "contact") {
            customerCreateBA.EntityCode = 2;
            customerCreateBA.Name = getValueFromDB("ContactSet", "ContactId", Xrm.Page.data.entity.getId(), "FullName");
            customerCreateBA.LogicalName = entityType;
            customerCreateBA.Id = Xrm.Page.data.entity.getId();
        }
        else if (entityType === "account") {
            customerCreateBA.EntityCode = 1;
            customerCreateBA.Name = getValueFromDB("AccountSet", "AccountId", Xrm.Page.data.entity.getId(), "Name");
            customerCreateBA.LogicalName = entityType;
            customerCreateBA.Id = Xrm.Page.data.entity.getId();
        }
        else if (entityType === "etel_bi_billingaccountcreate") {
            var customerIndividualField = Xrm.Page.getAttribute("etel_customerindividualid").getValue();
            var customerCorporateField = Xrm.Page.getAttribute("etel_accountid").getValue();
            if (customerIndividualField) {
                customerCreateBA.EntityCode = 2;
                customerCreateBA.Id = customerIndividualField[0].id;
                customerCreateBA.Name = getValueFromDB("ContactSet", "ContactId", customerCreateBA.Id, "FullName");
                customerCreateBA.LogicalName = "contact";
            }
            else if (customerCorporateField) {
                customerCreateBA.EntityCode = 1;
                customerCreateBA.Id = customerCorporateField[0].id;
                customerCreateBA.Name = getValueFromDB("AccountSet", "AccountId", customerCreateBA.Id, "Name");
                customerCreateBA.LogicalName = "account";
            }
        }
    },
    GetDefaultAddress: function () {

        var oDataUrl = "?$select=etel_billtoaddressid&$filter=";
        oDataUrl += customerCreateBA.LogicalName === "contact" ? "etel_customerindividualid" : "etel_accountid";
        oDataUrl += "/Id eq guid'" + customerCreateBA.Id + "' and etel_primarybillingaccount eq true";
        return retrieveRecord("etel_billingaccountSet", oDataUrl);
    }
};

var settings = {
    ServerURL: "",
    CurrentUserId: "",
    GetUrl: function () {
        Xrm.Page.context.getClientUrl();
        if (settings.ServerURL.match(/\/$/)) {
            settings.ServerURL = settings.ServerURL.substring(0, settings.ServerURL.length - 1);
        }
        if (typeof Xrm.Page.context.getClientUrl != "undefined") {
            settings.ServerURL = Xrm.Page.context.getClientUrl();
        }
    },
    GetCurrentUserId: function () {
        settings.CurrentUserId = Xrm.Page.context.getUserId();
    },
    Initialise: function () {
        settings.GetUrl();
        settings.GetCurrentUserId();
    }
};

var biSecurityCreateBillingAccount = {
    IsValidated: "",
    Validate: function () {
        var paymentType = null;
        var request = new PrepareRequest(new BillingAccountCreateSecurityRequest('etel_bi_billingaccountcreate', customerCreateBA.Id, customerCreateBA.EntityCode, paymentType, settings.CurrentUserId));
        retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
            biSecurityCreateBillingAccount.IsValidated = data.IsValidated;
        });
    }
};

var newEntityWindow = {
    features: "location=no,menubar=no,status=no,toolbar=no, resizable=yes",
    Open: function (entityTypeCode, extraqs) {
        window.open(settings.ServerURL + "/main.aspx?etn=" + entityTypeCode + "&pagetype=entityrecord&extraqs=" + encodeURIComponent(extraqs) + "&newWindow=true&histKey=" + Math.floor(Math.random() * 10000), "_blank", newEntityWindow.features, false);
    }
};

var biRoleSecurityCreateBA = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_js_BI_CustomerBillingAccount.GetData();
        biRoleSecurityCreateBA.IsValidatedRole = Util.Security.UserHasBIPrivilage("etel_bi_billingaccountcreate");

    }
};


var biAutoNumberCustomerBillingAccount = {
    IsCreated: "",
    BINumber: "",
    CreateBINumber: function () {
        translationScope_js_BI_CustomerBillingAccount.GetData();
        var request = new PrepareRequest(new CreateBINumberRequest());
        retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
            biAutoNumberCustomerBillingAccount.IsCreated = data.Success;
            biAutoNumberCustomerBillingAccount.BINumber = data.BINumber;
        });
    }
};

function SetDefaultBillingAddress() {

    try {
        translationScope_js_BI_CustomerBillingAccount.GetData();
        customerCreateBA.GetCustomer("etel_customerindividualid", "etel_accountid");
        var returnValue = customerCreateBA.GetDefaultAddress();
        if (returnValue != null && returnValue.results != null && returnValue.results.length > 0) {
            var address = returnValue.results[0].etel_billtoaddressid;
            SetLookupValue("etel_billtoaddress", address.Id, address.Name, address.LogicalName);
            SetLookupValue("etel_mailtoaddress", address.Id, address.Name, address.LogicalName);
        }

    } catch (e) {
        alert(translationScope_js_BI_CustomerBillingAccount.data.tErrorDuringRetrievingAddress + ': ' + e.message);
    }
}

function CustomerBillingAccountOnLoad() {
    translationScope_js_BI_CustomerBillingAccount.GetData();
    var FORM_TYPE_CREATE = 1;
    var formtype = Xrm.Page.ui.getFormType();

    var individualCustomer = Xrm.Page.getAttribute("etel_customerindividualid").getValue();
    var corporateCustomer = Xrm.Page.getAttribute("etel_accountid").getValue();

    var billingaccountField = Xrm.Page.getAttribute("etel_billingaccountid").getValue();

    ////TODO: Retrieve billing account from BIL and populate fields:
    //// 'etel_name', 'etel_allowcallitemizationoninvoice', 'etel_billmediumcode', 'etel_billtoaddress', 'etel_accountid', 'etel_customerindividualid', 'etel_mailtoaddress', 'etel_billingcontactid', 'etel_numberofcopies', 'etel_primarybillingaccount', 'etel_primarybillingcurrencyid', 'etel_primaryexchangeratetypeid', 'etel_secondarybillingcurrencyid', 'etel_secondaryexchangeratetypeid'
    setBillingAccountName();

    if (Xrm.Page.ui.getFormType() === FORM_TYPE_CREATE) {
        SetDefaultBillingAddress();
    }

    var name = Xrm.Page.getAttribute("etel_name").getValue();
    var binumber = Xrm.Page.getAttribute("etel_binumber").getValue();

    if (name == null && binumber != null) {
        var newname = binumber + ' ' + translationScope_js_BI_CustomerBillingAccount.data.BI_Message;
        Xrm.Page.getAttribute("etel_name").setValue(newname);
        Xrm.Page.data.entity.save('save');
    }


    if (formtype === 1) {
        Xrm.Page.getAttribute("etel_accountname").setRequiredLevel("required");
        Xrm.Page.getAttribute("etel_billtoaddress").setRequiredLevel("required");
        Xrm.Page.getAttribute("etel_numberofcopies").setRequiredLevel("required");
        Xrm.Page.getAttribute("etel_billmediumcode").setRequiredLevel("required");
    }
}

function popupCustomerBillingAccountCreateForm(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName) {
    debugger;
    translationScope_js_BI_CustomerBillingAccount.GetData();
    var Customer_StatusCode_Prospect = 831260000;
    var entityName = "Account";
    var columns = ['StatusCode'];
    var filter = "AccountId eq (guid'" + selectedEntityId.replace('{', '').replace('}', '') + "')";
    var isProspect = false;

    if (selectedEntityName === "contact") {
        filter = "ContactId eq (guid'" + selectedEntityId + "')";
        entityName = "Contact";
    }

    CrmRestKit.ByQuery(entityName, columns, filter, false).fail(function (errorHandler) { }).done(function (collection) {
        if (collection.d != null && collection.d.results != null && collection.d.results.length > 0) {
            if (collection.d.results[0].StatusCode.Value === Customer_StatusCode_Prospect) {
                isProspect = true;
                alert(translationScope_js_BI_CustomerBillingAccount.data.tCreateBillingAccountProspectError);
            }
        }
    });

    if (isProspect) return;

    settings.Initialise();
    customerCreateBA.GetCustomer();
    var headerStarted = headerCheck(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName);

    if (headerStarted) {
        biSecurityCreateBillingAccount.Validate();

        if (biSecurityCreateBillingAccount.IsValidated === true) {
            biRoleSecurityCreateBA.ValidateRole();
            if (biRoleSecurityCreateBA.IsValidatedRole === true) {
                biAutoNumberCustomerBillingAccount.CreateBINumber();
                if (biAutoNumberCustomerBillingAccount.IsCreated === true) {
                    /*20170706:openbi as forms
                    var extraqs = "";
                    extraqs = "_CreateFromId=" + selectedEntityId;
                    extraqs += "&_CreateFromType=" + selectedEntityCode;

                    var url = Xrm.Page.context.getClientUrl();
                    if (url.match(/\/$/)) {
                        url = url.substring(0, url.length - 1);
                    }
                    if (typeof Xrm.Page.context.getClientUrl != "undefined") {
                        url = Xrm.Page.context.getClientUrl();
                    }

                    if (biAutoNumberCustomerBillingAccount.BINumber != null) {
                        extraqs += "&etel_binumber=" + biAutoNumberCustomerBillingAccount.BINumber;
                    }

                    newEntityWindow.Open(entitytypecode, extraqs);*/

                    var parameters = {};
                    parameters["_CreateFromId"] = selectedEntityId;
                    parameters["_CreateFromType"] = selectedEntityCode;
                    if (biAutoNumberCustomerBillingAccount.BINumber != null) {
                        parameters["etel_binumber"] = biAutoNumberCustomerBillingAccount.BINumber;
                    }

                    var windowOptions = {
                        openInNewWindow: false
                    };

                    Xrm.Utility.openEntityForm(entitytypecode, null, parameters, windowOptions);
                }
            }
            else {
                alert(translationScope_js_BI_CustomerBillingAccount.data.tValidationRoleCheckMessage);
            }
        }
        else {
            alert(translationScope_js_BI_CustomerBillingAccount.data.tValidationCheckMessage);
        }
    }
}

function filterAddressesBAFields() {
    translationScope_js_BI_CustomerBillingAccount.GetData();
    var FORM_TYPE_CREATE = 1;

    if (Xrm.Page.ui.getFormType() === FORM_TYPE_CREATE) {
        var individualCustomer, corporateCustomer;

        if (Xrm.Page.getAttribute('etel_customerindividualid').getValue() != null) {
            individualCustomer = Xrm.Page.getAttribute('etel_customerindividualid').getValue();
            filterBillToAddressForIndividual(individualCustomer);
        }
        else if (Xrm.Page.getAttribute('etel_accountid').getValue() != null) {
            corporateCustomer = Xrm.Page.getAttribute('etel_accountid').getValue();
            filterBillToAddressForCorporate(corporateCustomer);
            filterMailToAddressForCorporate(corporateCustomer);
        }
    }
}

function filterBillToAddressForIndividual(individualCustomerLookUp) {
    translationScope_js_BI_CustomerBillingAccount.GetData();
    var billToControl = Xrm.Page.getControl("etel_billtoaddress");
    var mailToControl = Xrm.Page.getControl("etel_mailtoaddress");
    var entityName = "etel_customeraddress";
    var viewId = "{00000000-0000-0000-0000-000000000111}";
    var filterFetch = "<?xml version='1.0'?>" + "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>" + "<entity name='etel_customeraddress'>" + "<attribute name='etel_customeraddressid'/>" + "<attribute name='etel_name'/><order descending='false' attribute='etel_name'/>" + "<filter type='and'>" + "<condition attribute='etel_individualcustomerid' value='" + individualCustomerLookUp[0].id + "' uitype='contact' operator='eq'/>" + "<condition attribute='statecode' value='0' operator='eq'/>" + "</filter>" + "</entity>" + "</fetch>";
    var layoutXML = "<grid name='resultset' object='10064' jump='etel_name' select='1' icon='1' preview='1'><row name='result' id='etel_customeraddressid'><cell name='etel_name' width='200'/></row></grid>";
    billToControl.addCustomView(viewId, entityName, "Billing Addresses for " + individualCustomerLookUp[0].name, filterFetch, layoutXML, true);
    mailToControl.addCustomView(viewId, entityName, "Mailing Addressesfor " + individualCustomerLookUp[0].name, filterFetch, layoutXML, true);
}

function filterBillToAddressForCorporate(corporateCustomerLookUp) {
    translationScope_js_BI_CustomerBillingAccount.GetData();
    var billToControl = Xrm.Page.getControl("etel_billtoaddress");

    var entityName = "etel_customeraddress";
    var viewId = "{00000000-0000-0000-0000-000000000111}";
    var filterFetch = "<?xml version='1.0'?>" + "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>" + "<entity name='etel_customeraddress'>" + "<attribute name='etel_customeraddressid'/>" + "<attribute name='etel_name'/><attribute name='etel_isprimaryaddress'/>" + "<order descending='false' attribute='etel_name'/>" + "<filter type='and'>" + "<condition attribute='etel_corporatecustomerid' value='" + corporateCustomerLookUp[0].id + "' uitype='account' operator='eq'/>" + "<condition attribute='statecode' value='0' operator='eq'/>" + "</filter>" + "</entity>" + "</fetch>";
    var layoutXML = "<grid name='resultset' object='10064' jump='etel_name' select='1' icon='1' preview='1'><row name='result' id='etel_customeraddressid'><cell name='etel_name' width='200'/><cell name='etel_isprimaryaddress' width='100'/></row></grid>";
    billToControl.addCustomView(viewId, entityName, "Billing Addresses for " + corporateCustomerLookUp[0].name, filterFetch, layoutXML, true);
}

function filterMailToAddressForCorporate(corporateCustomerLookUp) {
    translationScope_js_BI_CustomerBillingAccount.GetData();
    CrmRestKit.ByQuery('etel_customeraddress', ['etel_customeraddressId', 'etel_name'], "etel_corporatecustomerid/Id eq (guid'" + corporateCustomerLookUp[0].id + "')", false).fail(function (errorHandler) {
        alert("fail");
    }).done(function (customeraddress) {
        if (customeraddress.d.results.length > 0) {
            var lookup = new Array();
            lookup[0] = new Object();
            lookup[0].id = customeraddress.d.results[0].etel_customeraddressId;
            lookup[0].name = customeraddress.d.results[0].etel_name;
            lookup[0].entityType = "etel_customeraddress";
            Xrm.Page.getAttribute("etel_mailtoaddress").setValue(lookup);
        }
    });
}

function executeSubmit() {
    Xrm.Page.data.save().then(executeSubmitSuccessfulCallback, executeSubmitErrorCallback);
}

function executeSubmitErrorCallback(errorCode, errorLocalized) {
    debugger;
    translationScope_js_BI_CustomerBillingAccount.GetData();
    alert(translationScope_js_BI_CustomerBillingAccount.data.tBiNotSaved);
}


function executeSubmitSuccessfulCallback() {
    debugger;
    translationScope_js_BI_CustomerBillingAccount.GetData();
    Xrm.Page.ui.tabs.get(0).sections.get("General_Section").setVisible(false);

    Xrm.Page.data.entity.save('save');

    var numberofCopiesValue;
    var numberofCopiesMax = Xrm.Page.getAttribute("etel_numberofcopies").getMax();
    var numberofCopiesMin = Xrm.Page.getAttribute("etel_numberofcopies").getMin();
    if (document.getElementById("etel_numberofcopies") != null) {
        numberofCopiesValue = parseInt(document.getElementById("etel_numberofcopies").title);
    }

    if (!Xrm.Page.data.getIsValid() && (numberofCopiesMax < numberofCopiesValue | numberofCopiesMin > numberofCopiesValue)) {
        alert(translationScope_js_BI_CustomerBillingAccount.data.tCompleteMandatoryFields);
        return;
    }

    var control = Xrm.Page.ui.controls.get("ownerid");
    control.setFocus();

    setBillingAccountName();

    var getAttribute = function (attributeName) {
        var field = Xrm.Page.getAttribute(attributeName);
        return field;
    };

    var getValue = function (attributeName, lookupValue) {
        if (!attributeName) {
            return null;
        }

        var field = getAttribute(attributeName);
        if (field) {
            var fieldValue = field.getValue();
            if (fieldValue !== null) {
                if (lookupValue) {
                    return fieldValue[0].id;
                } else {
                    return fieldValue;
                }
            }
        }
        return null;
    };

    var submitCheck = getAttribute("etel_submit", false);
    var lifecyclestatus = getAttribute("etel_lifecyclestatus", false);

    var AccountName = getValue("etel_accountname", false);
    var CorporateCustomerId = getValue("etel_accountid", true);
    var IndividualCustomerId = getValue("etel_customerindividualid", true);
    var NumberOfCopies = getValue("etel_numberofcopies", false);
    var BillToAddressId = getValue("etel_billtoaddress", true);
    var MailToAddressId = getValue("etel_mailtoaddress", true);
    var AllowCallItemization = getValue("etel_allowcallitemizationoninvoice", false);
    var BillMedium = getValue("etel_billmediumcode", false);
    var PrimaryBillingCurrencyId = getValue("etel_primarybillingcurrencyid", true);
    var PrimaryExchangeRateTypeId = getValue("etel_primaryexchangeratetypeid", true);
    var SecondaryBillingCurrencyId = getValue("etel_secondarybillingcurrencyid", true);
    var SecondaryExchangeRateTypeId = getValue("etel_secondaryexchangeratetypeid", true);

    if (BillMedium === null) {
        alert(translationScope_js_BI_CustomerBillingAccount.data.tBillMediumMandatory);
    }
    else if (BillToAddressId === null) {
        alert(translationScope_js_BI_CustomerBillingAccount.data.tBillToAddressMandatory);
    }
    else if (MailToAddressId === null) {
        alert(translationScope_js_BI_CustomerBillingAccount.data.tMailToAddress);
    }
    else if (NumberOfCopies === null) {
        alert(translationScope_js_BI_CustomerBillingAccount.data.tNumberOfCopiesMandatory);
    }
    else if (AccountName === null) {
        alert(translationScope_js_BI_CustomerBillingAccount.data.tAccountNameMandatory);
    }
    else {
        var executionResult;
        var errorMessage;

        //var request = new PrepareRequest(new BillingAccountCreateRequest(AccountName, CorporateCustomerId, IndividualCustomerId, NumberOfCopies, BillToAddressId, MailToAddressId, AllowCallItemization, BillMedium, PrimaryBillingCurrencyId, PrimaryExchangeRateTypeId, SecondaryBillingCurrencyId, SecondaryExchangeRateTypeId));
        //retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
        //    executionResult = data.Success;
        //    errorMessage = data.ErrorMessage;
        //});
        debugger;
        var soapMessage = '<soapenv:Envelope xmlns:bil="http://ericsson.com/services/ws_CIL_7/billingaccountwrite" xmlns:ses="http://ericsson.com/services/ws_CIL_7/sessionchange" xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/">' +
            '<soapenv:Header>' +
            '<wsse:Security soapenv:mustUnderstand="1" xmlns:wsse="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" xmlns:wsu="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd">' +
            '<wsse:UsernameToken wsu:Id="UsernameToken-1A214BF5D18C2D819A15035583017753">' +
            '<wsse:Username>ADMX</wsse:Username>' +
            '<wsse:Password Type="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText">ADMX</wsse:Password>' +
            '<wsse:Nonce EncodingType="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary">JrAkX9lPwZT/tO6wN0OarQ==</wsse:Nonce>' +
            '<wsu:Created>2017-08-24T07:05:01.775Z</wsu:Created>' +
            '</wsse:UsernameToken>' +
            '</wsse:Security>' +
            '</soapenv:Header>' +
            '<soapenv:Body>' +
            '<bil:billingAccountWriteRequest>' +
            '<bil:inputAttributes> ' +
            '<bil:create>true</bil:create>' +
            '<bil:csIdPub>CUST0000000096</bil:csIdPub>' +
            '<bil:invoicingInd>I</bil:invoicingInd>' +
            '<bil:status>A</bil:status>' +           
            '</bil:inputAttributes>' +
            '<bil:sessionChangeRequest>' +
            '<ses:values>' +
            '<ses:item>' +
            '<ses:key>BU_ID</ses:key>' +
            '<ses:value>2</ses:value>' +
            '</ses:item>' +
            '</ses:values>' +
            '</bil:sessionChangeRequest>' +
            '</bil:billingAccountWriteRequest>' +
            '</soapenv:Body>' +
            '</soapenv:Envelope>';
        var serviceUrl = "http://10.103.27.183:20103/wsi/services";

        $.ajax({
            type: "POST",
            contentType: "text/xml; charset=utf-8",
            dataType: "xml",
            url: serviceUrl,
            data: soapMessage,
            async: false,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("SOAPAction", "");
            },
            success: function () { executionResult = true; },
            error: function () { executionResult = false; },
        });

        if (executionResult === true) {
            lifecyclestatus.setValue(831260001);
            alert(translationScope_js_BI_CustomerBillingAccount.data.tSubmittedSuccessfully);
        }
        else {
            lifecyclestatus.setValue(831260002);
            alert(errorMessage);
        }

        submitCheck.setValue(true);
        submitCheck.setSubmitMode('always');
        lifecyclestatus.setSubmitMode('always');
        Xrm.Page.data.entity.save('saveandclose');
    }
}

function RetrieveCallbackSuccess(data, status, req, xml, xmlHttpRequest, responseXML) {
    debugger;

    if (status == "NOK") {
        soapCallBacktoWCF = false;
    }
    else if (status == "OK") {
        soapCallBacktoWCF = true;
    }
}

function RetrieveCallbackError(err) {
    debugger;
    soapCallBacktoWcfErrorMessage = err.statusText;
}

function GetTclabConfigurationEntry(key) {
    var configValue;
    var fetchXml = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
        "  <entity name='tclab_crmconfiguration'>" +
        "    <attribute name='tclab_stringvalue' />" +
        "    <attribute name='tclab_name' />" +
        "    <attribute name='tclab_crmconfigurationid' />" +
        "    <filter type='and'>" +
        "      <condition attribute='tclab_name' operator='eq' value='" + key + "' />" +
        "    </filter>" +
        "  </entity>" +
        "</fetch>";
    var configRecord = XrmServiceToolkit.Soap.Fetch(fetchXml);
    if (configRecord.length > 0) {
        if (configRecord[0].attributes.tclab_crmconfigurationid != undefined) {
            if (configRecord[0].attributes.tclab_stringvalue != null &&
                configRecord[0].attributes.tclab_stringvalue != undefined) {
                configValue = configRecord[0].attributes.tclab_stringvalue.value;
            }
        }
    }
    else {
        alert('Error: The Key ' + key + ' could not be found in TCLAB Configuration');
    }
    return configValue;
}

function onSave() {
    translationScope_js_BI_CustomerBillingAccount.GetData();
    setBillingAccountName();
}

function setBillingAccountName() {
    translationScope_js_BI_CustomerBillingAccount.GetData();
    var accountName = Xrm.Page.getAttribute("etel_accountname");

    if (accountName.getValue() === null || accountName.getValue() === "" || accountName.getValue() === undefined) {

        var uniqueId = Math.floor((Math.random() * 1000000) + 1);
        var customerName;

        var corporateCustomer = Xrm.Page.getAttribute("etel_accountid").getValue();
        if (corporateCustomer != null) {
            customerName = corporateCustomer[0].name;
        }
        else {
            var individualCustomer = Xrm.Page.getAttribute("etel_customerindividualid").getValue();
            if (individualCustomer != null) {
                customerName = individualCustomer[0].name;
            }
        }

        var billingAccountName = "BA - " + uniqueId + " - " + customerName;
        var billingAccountName30 = get30ByteString(billingAccountName);

        accountName.setValue(billingAccountName30);

    }
}

function get30ByteString(fullText) {
    var byteLength = getByteCount(fullText);
    var _30bytetext = fullText;
    if (byteLength > 30) {
        _30bytetext = fullText.slice(0, -1);
        return get30ByteString(_30bytetext);
    }
    else {
        return (_30bytetext);
    }
}

function getByteCount(str) {
    var count = 0, stringLength = str.length, i;
    str = String(str || "");
    for (i = 0; i < stringLength; i++) {
        var partCount = encodeURI(str[i]).split("%").length;
        count += partCount == 1 ? 1 : partCount - 1;
    }
    return count;
}

function setPrimaryAddressAsBillToOnCreate() {
    translationScope_js_BI_CustomerBillingAccount.GetData();
    var FORM_TYPE_CREATE = 1;

    if (Xrm.Page.ui.getFormType() === FORM_TYPE_CREATE) {
        var corporateid = Xrm.Page.getAttribute("etel_accountid").getValue();

        var individualid = Xrm.Page.getAttribute("etel_customerindividualid").getValue();

        var columns = ['etel_name', 'etel_customeraddressId'];
        var filter;

        if (corporateid != null || corporateid != undefined) {
            filter = "etel_corporatecustomerid/Id eq guid'" + corporateid[0].id + "' and etel_isprimaryaddress eq true";
        }
        else if (individualid != null || individualid != undefined) {
            filter = "etel_individualcustomerid/Id eq guid'" + individualid[0].id + "' and etel_isprimaryaddress eq true";
        }

        CrmRestKit.ByQuery("etel_customeraddress", columns, filter, false).fail(function (xhr, status, ethrow) {
            alert('Error: ' + xhr.status);
        }).done(function (collection) {
            if (collection.d != null && collection.d.results != null && collection.d.results.length > 0) {
                var addressName = collection.d.results[0].etel_name;
                var addressId = collection.d.results[0].etel_customeraddressId;

                SetLookupValue("etel_billtoaddress", addressId, addressName, "etel_customeraddress");
                SetLookupValue("etel_mailtoaddress", addressId, addressName, "etel_customeraddress");
            }
        });
    }
}

function IsCreateBillingAccountButtonEnabled() {
    settings.Initialise();
    var retVal = true;

    biRoleSecurityCreateBA.ValidateRole();

    retVal = !!biRoleSecurityCreateBA.IsValidatedRole;

    return retVal;
}