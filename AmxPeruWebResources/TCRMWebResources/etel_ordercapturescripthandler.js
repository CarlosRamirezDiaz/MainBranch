var FORM_ID = "JS_OrderCaptureScriptHandler";

if (window.definitions === undefined || window.definitions === null) {
    window.definitions = {};
}

var OrderType = Object.freeze({
    "BulkImportNewSubscription": 831260007,
    "BullkImportCorporateCreation": 831260008,
    "BulkImportSubscriptionStatusChange": 831260009,
    "BulkImportIndividualCreation": 250000000
});

var translationScope = {
    CurrentUserLanguageCode: GetUserLanguageCode(),
    data: null,
    GetData: function (formId) {
        if (translationScope.data !== null) {
            return;
        }

        translationScope.data = GetTranslationData(formId);

    }
};

function GetUserLanguageCode() {
    return Xrm.Page.context.getUserLcid();
}

function GetCustomer() {
    var corp = Xrm.Page.getAttribute("etel_corporatecustomerid").getValue();
    var ind = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();

    return {
        corporate: corp,
        individual: ind,
    };
}

function BIHeaderCreate() {
    //translationScope.GetData(FORM_ID);
    if ((Xrm.Page.getAttribute("statuscode").getValue() == 1) && (Xrm.Page.ui.getFormType() != 1)) {
        var userId = Xrm.Page.context.getUserId();
        var oDataSetName2 = "etel_bi_headerSet";
        var oDataUrl2 = "?$select=ActivityId&$filter=OwnerId/Id eq guid'" + userId + "' and etel_headerstatus eq true";
        var data2 = retrieveCrmRecord(oDataSetName2, oDataUrl2);
        var biHeader = data2.results[0];

        var orderType = Xrm.Page.getAttribute("etel_ordertypecode").getValue();
        var customerRequired = true;

        if (orderType == 831260001) {
            customerRequired = false;
        }
        else {
            customerRequired = true;
        }

        var corporate = GetCustomer().corporate;
        var individual = GetCustomer().individual;

        var createHeader = {};

        var customer = "";

        if (corporate != null) {
            customer = corporate[0].id;
            createHeader.etel_corporatecustomerid = {
                Id: corporate[0].id,
                LogicalName: corporate[0].entityType,
                Name: corporate[0].name
            };
        }
        else if (individual != null) {
            customer = individual[0].id;
            createHeader.etel_individualcustomerid = {
                Id: individual[0].id,
                LogicalName: individual[0].entityType,
                Name: individual[0].name
            };
        }

        if (biHeader != null) {
            var updateHeader = {};
            updateHeader.etel_headerstatus = false;
            updateRecord(biHeader.ActivityId, updateHeader, 'etel_bi_headerSet');
        }

        createHeader.Subject = 'Order Capture BI';
        createHeader.etel_headerstatus = true;
        createHeader.etel_csrid = userId.replace('{', '').replace('}', '');
        createHeader.etel_customerrequired = customerRequired;
        createHeader.etel_customeridtext = customer.replace('{', '').replace('}', '');

        createCrmRecord(createHeader, 'etel_bi_header', function () { },
            this._errorHandler, true);
    }
}

function onLoad() {
    //translationScope.GetData(FORM_ID);
    //setTimeout("loadProcess()", 2000);
    loadProcess();
}

function loadProcess() {
    //translationScope.GetData(FORM_ID);
    if (Xrm.Page.ui.getFormType() !== 1) {
        var orderTypeCode = Xrm.Page.getAttribute("etel_ordertypecode").getValue();
        showProcess(orderTypeCode);
    }
}

function showProcess(orderTypeCode) {
    debugger;
    //translationScope.GetData(FORM_ID);
    var processName = "newCustomerAcquisition.htm";
    var codePrefix = "etel_";

    if (orderTypeCode === 831260002) {
        var customerParameter = "";
        if (Xrm.Page.getAttribute("etel_name").getValue() !== null) {
            customerParameter = "&OrderCaptureId=" + Xrm.Page.getAttribute("etel_name").getValue();
        }

        window.definitions.psbWorkflowStartInput = {
            "orderCaptureId": Xrm.Page.data.entity.getId().substr(1, 36),
            "individualCustomerId": GetCustomer().individual != null ? GetCustomer().individual[0].id.substr(1, 36) : "",
            "corporateCustomerId": GetCustomer().corporate != null ? GetCustomer().corporate[0].id.substr(1, 36) : "",
            "languageId": "1033",

        };

        var parameters = "name=AmxPeruNewSubscription" + customerParameter;
        var versionNumber = Util.getCrmWebResourceVersion();
        var url = Xrm.Page.context.getClientUrl() + "/" + versionNumber + "/WebResources/etel_/psb/Wizard/wizard.html?Data=" + encodeURIComponent(parameters);
        Xrm.Page.getControl("WebResource_processapp").setSrc(url);
        return;
    }
    else if (orderTypeCode === 831260003) {
        //processName = "modifySubscription.htm";
        debugger;
        var customerParameter = "";
        if (Xrm.Page.getAttribute("etel_name").getValue() !== null) {
            customerParameter = "&OrderCaptureId=" + Xrm.Page.getAttribute("etel_name").getValue();
        }

        window.definitions.psbWorkflowStartInput = {
            "orderCaptureId": Xrm.Page.data.entity.getId().substr(1, 36),
            "individualCustomerId": GetCustomer().individual != null ? GetCustomer().individual[0].id.substr(1, 36) : "",
            "corporateCustomerId": GetCustomer().corporate != null ? GetCustomer().corporate[0].id.substr(1, 36) : "",
            "languageId": "1033",

        };

        var parameters = "name=AmxPeruModifySubscription" + customerParameter;
        var versionNumber = Util.getCrmWebResourceVersion();
        var url = Xrm.Page.context.getClientUrl() + "/" + versionNumber + "/WebResources/etel_/psb/Wizard/wizard.html?Data=" + encodeURIComponent(parameters);
        Xrm.Page.getControl("WebResource_processapp").setSrc(url);
        return;
    }
    else if (orderTypeCode === 831260011) {
        //processName = "modifySubscription.htm";
        debugger;
        var customerParameter = "";
        if (Xrm.Page.getAttribute("etel_name").getValue() !== null) {
            customerParameter = "&OrderCaptureId=" + Xrm.Page.getAttribute("etel_name").getValue();
        }

        window.definitions.psbWorkflowStartInput = {
            "orderCaptureId": Xrm.Page.data.entity.getId().substr(1, 36),
            "individualCustomerId": GetCustomer().individual != null ? GetCustomer().individual[0].id.substr(1, 36) : "",
            "corporateCustomerId": GetCustomer().corporate != null ? GetCustomer().corporate[0].id.substr(1, 36) : "",
            "languageId": "1033",

        };

        var parameters = "name=ChangeResumeDate" + customerParameter;
        var versionNumber = Util.getCrmWebResourceVersion();
        var url = Xrm.Page.context.getClientUrl() + "/" + versionNumber + "/WebResources/etel_/psb/Wizard/wizard.html?Data=" + encodeURIComponent(parameters);
        Xrm.Page.getControl("WebResource_processapp").setSrc(url);
        return;
    }
    else if (orderTypeCode === 831260012) { // Change MSISDN
        debugger;
        var customerParameter = "";
        if (Xrm.Page.getAttribute("etel_name").getValue() !== null) {
            customerParameter = "&OrderCaptureId=" + Xrm.Page.getAttribute("etel_name").getValue();
        }

        window.definitions.psbWorkflowStartInput = {
            "AmxPeruChangeSimCardGeneralRequest": {
                "$type": "AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralRequest,AmxPeruPSBActivities",
                "ResourceID": Xrm.Page.getAttribute("amxperu_productresourceid").getValue().substring(1).substring(0, 36)
            }
        };

        var parameters = "name=AmxPeruMSISDNChangeWorkflow" + customerParameter;
        var versionNumber = Util.getCrmWebResourceVersion();
        var url = Xrm.Page.context.getClientUrl() + "/" + versionNumber + "/WebResources/etel_/psb/Wizard/wizard.html?Data=" + encodeURIComponent(parameters);
        Xrm.Page.getControl("WebResource_processapp").setSrc(url);
        return;
    }
    else if (orderTypeCode === 100000000) {
        debugger;
        var customerParameter = "";
        if (Xrm.Page.getAttribute("etel_name").getValue() !== null) {
            customerParameter = "&OrderCaptureId=" + Xrm.Page.getAttribute("etel_name").getValue();
        }
      var  subscriptionId1 = Xrm.Page.getAttribute("etel_subscriptionid").getValue();
        var subscriptionId = subscriptionId1[0].id;

        window.definitions.psbWorkflowStartInput = {
            "orderCaptureId": Xrm.Page.data.entity.getId().substr(1, 36),
            "individualCustomerId": GetCustomer().individual != null ? GetCustomer().individual[0].id.substr(1, 36) : "",
            "corporateCustomerId": GetCustomer().corporate != null ? GetCustomer().corporate[0].id.substr(1, 36) : "",
            "languageId": "1033",
            "subscriptionId": subscriptionId
        };

        var parameters = "name=AMXPeruChangePlanFlow" + customerParameter;
        var versionNumber = Util.getCrmWebResourceVersion();
        var url = Xrm.Page.context.getClientUrl() + "/" + versionNumber + "/WebResources/etel_/psb/Wizard/wizard.html?Data=" + encodeURIComponent(parameters);
        Xrm.Page.getControl("WebResource_processapp").setSrc(url);
        return;
    }



    else if (orderTypeCode === 831260004) {
        processName = "subscriptionStatusChange.htm";
    }
    else if (orderTypeCode === 831260001) {
        processName = "newCustomerAcquisition.htm";
    }
    else if (orderTypeCode === 831260005) {
        processName = "ratePlanChange.htm";
    }
    else if (orderTypeCode === 831260006) {
        processName = "subscriptionTakeOver.htm";
    }
    else if (orderTypeCode === 831260007) {
        processName = "bulkImportNewSubscription.htm";
    }
    else if (orderTypeCode === 831260008) {
        processName = "bulkImportCorporateCreation.htm";
    }
    else if (orderTypeCode === 831260009) {
        processName = "bulkImportSubscriptionStatusChange.htm";
    }
    else if (orderTypeCode === 831260010) {
        processName = "corporateCustomerCreation.htm";
    }
    else if (orderTypeCode === 250000000) {
        processName = "bulkImportIndividualCreation.html";
        codePrefix = "amxperu_";
    }
    else if (orderTypeCode === 831260013) { // Change SIM

        var customerParameter = "";
        if (Xrm.Page.getAttribute("etel_name").getValue() !== null) {
            customerParameter = "&OrderCaptureId=" + Xrm.Page.getAttribute("etel_name").getValue();
        }

        //window.definitions.psbWorkflowStartInput = {
        //    "$type":`AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralRequest,AmxPeruPSBActivities",
        //    "ResourceID":
        //}


        window.definitions.psbWorkflowStartInput = {
            "AmxPeruChangeSimCardGeneralRequest": {
                "$type": "AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralRequest,AmxPeruPSBActivities",
                "ResourceID": Xrm.Page.getAttribute("amxperu_productresourceid").getValue().substring(1).substring(0, 36)
            }
            //  "simChangeId": Xrm.Page.data.entity.getId().substr(1, 36),
            //"individualCustomerId": GetCustomer().individual != null ? GetCustomer().individual[0].id.substr(1, 36) : "",
            //"corporateCustomerId": GetCustomer().corporate != null ? GetCustomer().corporate[0].id.substr(1, 36) : "",
            //"languageId": "1033",
        };

        // window.definitions.psbWorkflowStartInput = {};

        var parameters = "name=AmxPeruChangeSimCardGeneral" + customerParameter;
        var versionNumber = Util.getCrmWebResourceVersion();
        var url = Xrm.Page.context.getClientUrl() + "/" + versionNumber + "/WebResources/etel_/psb/Wizard/wizard.html?Data=" + encodeURIComponent(parameters);
        Xrm.Page.getControl("WebResource_processapp").setSrc(url);
        return;
    }


    var url = Util.getCachedWebResourceURL("WebResources/" + codePrefix + "/processapp/" + processName);
    Xrm.Page.getControl("WebResource_processapp").setSrc(url);
}


var _context = function () {
    //translationScope.GetData(FORM_ID);
    if (typeof GetGlobalContext != "undefined") {
        return GetGlobalContext();
    }
    else {
        if (typeof window.parent.Xrm != "undefined") {
            return window.parent.Xrm.Page.context;
        }
        else {
            throw new Error("Context is not available.");
        }
    }
};

var _getClientUrl = function () {
    //translationScope.GetData(FORM_ID);
    var clientUrl = this._context().getClientUrl();
    return clientUrl;
};

var _ODataPath = function () {
    //translationScope.GetData(FORM_ID);
    return this._getClientUrl() + "/XRMServices/2011/OrganizationData.svc/";
};

var _errorHandler = function (req) {
    //translationScope.GetData(FORM_ID);
    if (req.status == 12029) {
        return new Error("The attempt to connect to the server failed.");
    }
    if (req.status == 12007) {
        return new Error("The server name could not be resolved.");
    }
    var errorText;
    try {
        errorText = JSON.parse(req.responseText).error.message.value;
    }
    catch (e) {
        alert(req.description);
        errorText = req.responseText
    }
    return new Error("Error : " + req.status + ": " + req.statusText + ": " + errorText);
};

var _dateReviver = function (key, value) {
    //translationScope.GetData(FORM_ID);
    var a;
    if (typeof value === 'string') {
        a = /Date\(([-+]?\d+)\)/.exec(value);
        if (a) {
            return new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
        }
    }
    return value;
};

function retrieveCrmRecord(odataSetName, url) {
    //translationScope.GetData(FORM_ID);
    if (!odataSetName) {
        ////alert("odataSetName is required.");
        alert(translationScope.data.tOdataSetNameRequierd);
        return;
    }

    var ODataPath = window.parent.Xrm.Page.context.getClientUrl() + "/XRMServices/2011/OrganizationData.svc/";
    var fullUrl = ODataPath + odataSetName + url;

    var result = null;
    jQuery.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        cache: false,
        url: fullUrl,
        xhrFields: {
            withCredentials: true
        },
        beforeSend: function (XMLHttpRequest) {
            XMLHttpRequest.setRequestHeader("Accept", "application/json");
        },
        success: function (data, textStatus, XmlHttpRequest) {
            result = data.d;
        },
        error: function (XmlHttpRequest, textStatus, errorThrown) {
            result = "hata";
        }
    });

    return result;
}

function createCrmRecord(object, type, successCallback, errorCallback, async) {
    //translationScope.GetData(FORM_ID);
    var req = new XMLHttpRequest();
    req.open("POST", encodeURI(this._ODataPath() + type + "Set"), async);
    req.setRequestHeader("Accept", "application/json");
    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    req.onreadystatechange = function () {
        if (this.readyState == 4
            /* complete */
        ) {
            req.onreadystatechange = null;
            if (this.status == 201) {
                successCallback(JSON.parse(this.responseText, _dateReviver).d);
            }
            else {
                errorCallback(_errorHandler(this));
            }
        }
    };
    req.send(JSON.stringify(object));
}

function updateRecord(id, entityObject, odataSetName) {
    //translationScope.GetData(FORM_ID);
    var jsonEntity = window.JSON.stringify(entityObject);

    $.ajax({

        type: "POST",

        contentType: "application/json; charset=utf-8",

        datatype: "json",

        data: jsonEntity,

        url: encodeURI(this._ODataPath() + odataSetName) + "(guid'" + id + "')",
        xhrFields: {
            withCredentials: true
        },
        beforeSend: function (XMLHttpRequest) {

            XMLHttpRequest.setRequestHeader("Accept", "application/json");

            XMLHttpRequest.setRequestHeader("X-HTTP-Method", "MERGE");

        },

        success: function (data, textStatus, XmlHttpRequest) {

        },

        error: function (XmlHttpRequest, textStatus, errorThrown) {
            if (XmlHttpRequest && XmlHttpRequest.responseText) {
                ////alert("Error while updating " + odataSetName + " ; Error – " + XmlHttpRequest.responseText);
                alert(translationScope.data.tUpdatingError + "  " + odataSetName + " ; " + translationScope.data.tError + " - " + XmlHttpRequest.responseText);
            }
        }
    });
}

function bulkOrderNewSubscription() {
    bulkOrderCreate(OrderType.BulkImportNewSubscription);
}

function bulkOrderCorporateCreation() {
    bulkOrderCreate(OrderType.BullkImportCorporateCreation);
}

function bulkOrderSubscriptionStatusChange() {
    bulkOrderCreate(OrderType.BulkImportSubscriptionStatusChange);
}

function bulkOrderIndividualCreation() {
    debugger;
    bulkOrderCreate(OrderType.BulkImportIndividualCreation);
}

function bulkOrderCreate(orderType) {
    var orderEntity = {
        etel_ordertypecode: {
            Value: orderType
        }
    };

    CrmRestKit.Create('etel_ordercapture', orderEntity, false).fail(function (xhr, status, ethrow) {
        alert('Error: ' + status + ': ' + xhr.statusText + '.');
    }).done(function (data, status, xhr) {
        Xrm.Utility.openEntityForm("etel_ordercapture", data.d.etel_ordercaptureId);
    });
}