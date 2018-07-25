var webServerName = null;
var searchCompleted = null;
var translationScope_JS_CustomerSearchScript = {
    data: null,
    GetData: function () {
        var formId = "JS_CustomerSearchScript";

        if (translationScope_JS_CustomerSearchScript.data !== null) {
            return;
        }
        translationScope_JS_CustomerSearchScript.data = GetTranslationData(formId);
    }
};

var translationCustomerSearch = {
    data: null,
    GetData: function () {
        var formId = "CustomerSearch";
        if (translationCustomerSearch.data == null) {
            translationCustomerSearch.data = GetTranslationData(formId);
        }
        return translationCustomerSearch.data;
    }
}

// gets customer search template
var getCustomerSearchTemplate = function (customerSearchTemplateName) {

    return Util.SearchTemplate.getTemplateWithName(customerSearchTemplateName);

    /*
    var oDataSetName = "etel_customersearchtemplateSet";
    var oDataUrl = "?$select=etel_customersearchtemplateId,etel_htmlcontent,etel_scriptcontent,etel_name&$filter=etel_name eq '" + customerSearchTemplateName + "' and statecode/Value eq 0";
    var data = retrieveCrmRecordForSubscription(oDataSetName, oDataUrl);
    var customerSearchTemplate = data.results[0];
    if (customerSearchTemplate == null) {
        return null;
    }
    return customerSearchTemplate;
    */
}



// gets customer search main templates
var getCustomerSearchTemplates = function () {
    var data = Util.SearchTemplate.getRootTemplates();
    return data;
    /*
    var oDataSetName = "etel_customersearchtemplateSet";
    var oDataUrl = "?$select=etel_customersearchtemplateId,etel_htmlcontent,etel_scriptcontent,etel_name,etel_parenttemplateid,etel_issearchmodesimple&$orderby=etel_sequence asc&$filter=(etel_parenttemplateid eq null and statecode/Value eq 0)";
    var data = retrieveCrmRecordForSubscription(oDataSetName, oDataUrl);
    if (data != null && data.results != null && data.results.length > 0)
        return data.results;
    else
        return null;
        */
}

var getCustomerSearchTemplatesWithParentCode = function (parentCode) {

    return Util.SearchTemplate.getCustomerSearchTemplatesWithParentCode(parentCode);
    /*
    var oDataSetName = "etel_customersearchtemplateSet";
    var oDataUrl = "?$select=etel_customersearchtemplateId&$filter=etel_name eq '" + parentCode + "' and statecode/Value eq 0";
    var data = retrieveCrmRecordForSubscription(oDataSetName, oDataUrl);
    if (data != null && data.results != null && data.results.length > 0)
        return getCustomerSearchTemplatesWithParentId(data.results[0].etel_customersearchtemplateId);
    else
        return null;
        */
}

function appendSearchTemplate(template) {

    if (template != null) {

        if (template.etel_name === "SUBSCRIPTIONSEARCH") {
            var customerSearchTranslation = GetTranslationData('CustomerSearch');
            var name = $(template.etel_htmlcontent).filter("#SearchSubscriptions").attr('class');
            var translatedTitle = customerSearchTranslation[name];
            template.etel_htmlcontent = $(template.etel_htmlcontent).filter("#SearchSubscriptions").attr('title', translatedTitle).prop('outerHTML');
        }

        else if (template.etel_name == "INDIVIDUALSEARCH") {
            var customerSearchTranslation = GetTranslationData('CustomerSearch');
            var name = $(template.etel_htmlcontent).filter("#SearchIndividuals").attr('class');
            var translatedTitle = customerSearchTranslation[name];
            template.etel_htmlcontent = $(template.etel_htmlcontent).filter("#SearchIndividuals").attr('title', translatedTitle).prop('outerHTML');

        }

        else if (template.etel_name == "CORPORATESEARCH") {
            var customerSearchTranslation = GetTranslationData('CustomerSearch');
            var name = $(template.etel_htmlcontent).filter("#SearchCorporates").attr('class');
            var translatedTitle = customerSearchTranslation[name];
            template.etel_htmlcontent = $(template.etel_htmlcontent).filter("#SearchCorporates").attr('title', translatedTitle).prop('outerHTML');
        }

        if (template.etel_issearchmodesimple == true) {
            $('#SimpleSearchFiltersPanel').append(template.etel_htmlcontent);
            $('#SimpleSearchFiltersPanel').append('<script type="text/javascript">' + template.etel_scriptcontent + '</script>');
        } else {
            $('#AdvancedSearchFiltersPanel').append(template.etel_htmlcontent);
            $('#AdvancedSearchFiltersPanel').append('<script type="text/javascript">' + template.etel_scriptcontent + '</script>');
        }
    }
}

function appendScriptToElement(elementId, scriptcontent) {
    if (scriptcontent != null)
        $(elementId).append('<script type="text/javascript">' + scriptcontent + '</script>');
}

var constants = new (function () {
    this.Namespace = '#Ericsson.ETELCRM.CommonServiceLibrary.Message';
    this.IsDebugMode = false;
    this.INDIVIDUAL_CUSTOMER_FORM_NEW = "97F6F32D-7A4B-4DD4-A1E6-BCAD27F9F8A0";
    this.CORPORATE_CUSTOMER_FORM_NEW = "1D792FE1-4063-4333-BA0F-2181E5800A4F";
    this.INDIVIDUAL_CUSTOMER_FORM_SUMMARY = "DDB8DBF0-2BD9-43FF-B58F-0ACF8BECD189";
    this.CORPORATE_CUSTOMER_FORM_SUMMARY = "98E67066-E69D-4532-AF2E-B213B55E6A5A";
    this.CustomerStatus = Object.freeze({ "Active": 1, "Deactive": 2, "Prospect": 831260000, "Passive": 831260001, "Suspend": 831260002, "NotCustomer": 831260003 });
    var OrderType = Object.freeze({ "NewAcquisition": 831260001, "NewSubscription": 831260002, "ModifySubscription": 831260003, "ModifySubscriptionStatus": 831260004 });
    this.SecurityRoles = Object.freeze({
        "PRODUCTMANAGER": "edac0c4f-0dca-e311-9f99-005056ae2607"
    });
    this.BIHeaderChannel = Object.freeze({ "FaceToFace": 831260000, "PhoneCall": 831260001, "Email": 831260002 });
    this.InteractionDirection = Object.freeze({ "Incoming": 2, "Outgoing": 1, "Event": 5, "All": 0 });
})();

function popupEntityForm(objectType, entityGUID) {
    var entityType = null;
    var parameters = {};

    if (entityGUID) {
        entityType = objectType == 1 ? "account" : "contact";

        switch (objectType) {
            case 1:
                parameters["formid"] = constants.CORPORATE_CUSTOMER_FORM_SUMMARY;
                break;
            case 2:
                parameters["formid"] = constants.INDIVIDUAL_CUSTOMER_FORM_SUMMARY;
                break;
            default:
        }
    }
    else {
        entityType = objectType == 1 ? "account" : "etel_ordercapture";

        switch (objectType) {
            case 1:
                parameters["formid"] = constants.CORPORATE_CUSTOMER_FORM_NEW;
                break;
            case 2:
                parameters["formid"] = constants.INDIVIDUAL_CUSTOMER_FORM_NEW;
                break;
            default:
        }
    }

    if (window.parent &&
        window.parent.location &&
        window.parent.location.search &&
        getQueryString() && getQueryString().extraqs) {
        window.open(_getClientUrl() + "/main.aspx?etn=" + entityType + "&id=%7b" + entityGUID + "%7d&pagetype=entityrecord", "_parent", null, false);
    }
    else {
        window.parent.Xrm.Utility.openEntityForm(entityType, entityGUID, parameters);
    }
}

function errorHandlerIndividualOrder(error) {

    alert(error.message);
}

function retrieveCrmRecordForSubscription(odataSetName, url) {
    translationScope_JS_CustomerSearchScript.GetData();
    if (!odataSetName) {
        alert(translationScope_JS_CustomerSearchScript.data.tOData);
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

function getRestServiceUrl() {
    return getWebServerName() + "/OrderProcess.svc/rest";
}

function retrieveRecord(request, successCallback, errorCallback) {
    jQuery.support.cors = true;
    $.ajax({
        url: getRestServiceUrl() + '/ExecuteRequest',
        data: JSON.stringify(request),
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        cache: false,
        async: false,
        xhrFields: {
            withCredentials: true
        },
        success: function (data, textStatus, XmlHttpRequest) {
            if (successCallback) {
                successCallback(data.d, textStatus, XmlHttpRequest);
            }
        },
        error: function (XmlHttpRequest, textStatus, errorThrown) {
            if (errorCallback)
                errorCallback(XmlHttpRequest, textStatus, errorThrown);
            else
                _errorHandler(XmlHttpRequest);
        }
    });
}

var PrepareRequest = function (request) {
    this.request = request;
};

var RequestMessage = new (function () {
    this.RetrieveCountryRequest = 'RetrieveCountryRequest';
    this.RetrieveCityRequest = 'RetrieveCityRequest';
    this.BISpecSecurityRoleCheckForUserRequest = 'BISpecSecurityRoleCheckForUserRequest';
})();

var RetrieveCountryRequest = function () {
    this.__type = RequestMessage.RetrieveCountryRequest + ':' + constants.Namespace;
};

var BISpecSecurityRoleCheckForUserRequest = function (biSpecName) {
    this.__type = RequestMessage.BISpecSecurityRoleCheckForUserRequest + ':' + constants.Namespace;
    this.UserId = Xrm.Page.context.getUserId();
    this.RelatedEntityType = biSpecName;
};

var RetrieveCityRequest = function (countryId) {
    this.__type = RequestMessage.RetrieveCityRequest + ':' + constants.Namespace;
    this.CountryId = countryId;
};


function CustomerSearchInfoHandler(customerSearchCriteria, customerSearchCriteriaPaging, customerSearchType) {
    this.CustomerSearchCriteria = customerSearchCriteria;
    this.CustomerSearchCriteriaPaging = customerSearchCriteriaPaging;
    this.CustomerSearchType = customerSearchType;
}

function CustomerSearchCriteriaPaging(page, rows, sort, order) {
    this.Page = (page) ? page : 1;
    this.Rows = (rows) ? rows : 20;
    this.Sort = (sort) ? sort : "Name";
    this.Order = (order) ? order : "asc";
}

var lastselectedrow = undefined;

var TemplateCache = function () {
    this.templates = {};
}

TemplateCache.prototype = {
    store: function (key, template) {
        this.templates[key] = template;
    },
    retrieve: function (key) {
        if (this.templates == null)
            this.templates = {};

        if (this.templates[key] == null) {
            var template = getCustomerSearchTemplate(key);
            this.templates[key] = template;
            return template;
        }
        return this.templates[key];
    }
}

templateCache = new TemplateCache();

// Key publisher
var KeyPublisher = function () {
    this.subscribers = [];
}

KeyPublisher.prototype = {
    subscribe: function (callback) {
        this.subscribers.push(callback);
    },
    unsubscribe: function (callback) {
        var i = 0,
            len = this.subscribers.length;

        for (; i < len; i++) {
            if (this.subscribers[i] === callback) {
                this.subscribers.splice(i, 1);
                return;
            }
        }
    },
    publish: function (data) {
        var i = 0,
            len = this.subscribers.length;
        for (; i < len; i++) {
            this.subscribers[i](data);
        }
    }
};

keyPublisher = new KeyPublisher();

function loadSearchPage() {

    var urlParams = new URLSearchParams(window.location.search);

    alert(urlParams.toString());

    // create search panels
    var templates = getCustomerSearchTemplates();

    // translation data
    translationScope_JS_CustomerSearchScript.GetData();



    if (templates != null) {
        templates.forEach(appendSearchTemplate);
    }


}



function restOfLoadSearch() {
    // focus first input of selected panel

    $('#AdvancedSearchFiltersPanel').accordion({
        width: 'auto',
        height: 215,
        onSelect: function (title, index) {
            var opts = $("#ToggleSearchMode").linkbutton('options');
            if (opts.selected == true) {
                var currentPanel = $('#AdvancedSearchFiltersPanel').accordion('getSelected');
                if (currentPanel != null) {
                    var firstChild = $(currentPanel).find("input:first");
                    if (firstChild != null) {
                        firstChild.focus();
                    }
                }
            }
        }
    });

    $('#AdvancedSearchFiltersPanel').hide();
    $('#SimpleSearchFiltersPanel').show();
    $("#ToggleSearchMode").linkbutton('unselect');

    focusFirstPageControl();

    keyPublisher.publish('SIMPLESEARCHFROMURL');
}


function focusFirstPageControl() {
    var firstSearchBox = $('#SimpleSearchFiltersPanel input:text').first();
    if (firstSearchBox != null) {
        firstSearchBox.focus();
    }
}

function getQueryString() {
    var queryStringKeyValue = window.parent.location.search.replace('?', '').split('&');
    var qsJsonObject = {};
    if (queryStringKeyValue != '') {
        for (i = 0; i < queryStringKeyValue.length; i++) {
            qsJsonObject[queryStringKeyValue[i].split('=')[0]] = queryStringKeyValue[i].split('=')[1];
        }
    }
    return qsJsonObject;
}

function changeSearchMode() {

    var opts = $("#ToggleSearchMode").linkbutton('options');
    if (opts.selected == false) {
        $('#ToggleSearchMode').linkbutton({ text: '<span style="font-size:12px">' + translationScope_JS_CustomerSearchScript.data.tSimpleSearch + '</span>' });
        $('#AdvancedSearchFiltersPanel').show();
        $('#SimpleSearchFiltersPanel').hide();
        $('#AdvancedSearchFiltersPanel').accordion('select', 0);

        var firstSearchBox = $('#AdvancedSearchFiltersPanel input:text').first();
        if (firstSearchBox != null) {
            firstSearchBox.focus();
        }
    }
    else {
        $('#ToggleSearchMode').linkbutton({ text: '<span style="font-size:12px">' + translationScope_JS_CustomerSearchScript.data.tAdvancedSearch + '</span>' });
        $('#AdvancedSearchFiltersPanel').hide();
        $('#SimpleSearchFiltersPanel').show();
        focusFirstPageControl();
    }
}

var IndividualCustomerOrderStages = new (function () {
    this.Aquisition = Object.freeze({
        "OFFERINGINFO": "96980e9b-0ea4-bd30-2989-2c06883e3999"
    });
    this.NewSubscription = Object.freeze({
        "OFFERINGINFO": "2e1eb928-c043-4d64-8ac1-977677ec69f9"
    });
    this.ModifySubscription = Object.freeze({
        "OFFERINGINFO": "89e1f8d0-2064-440c-a5af-d1bda1c26654"
    });
})();

var IndividualCustomerOrderProcess = Object.freeze({
    "AQUISITION": "ad8d41f7-3bf8-4556-afe9-c544d6e89829",
    "NEWSUBSCRIPTION": "86619fef-1993-4d93-a936-4173cea736e3",
    "MODIFYSUBSCRIPTION": "7b8809cd-63f3-4e05-82fa-4db9be4ffba6",
});

var CorporateCustomerSubscriptionStages = new (function () {
    this.NewSubscription = Object.freeze({
        "PLANANDADDONS": "62956531-0ad9-4730-8433-6cc80764c587",
        "CONFIGURATION": "b3a90dd3-4ebc-a827-78ae-69ac9541856a",
        "RESOURCES": "a3a10670-6621-316e-cc97-069ea1eac858",
        "BILLINGANDPAYMENT": "97928dd9-56d8-3a21-0895-51b596483b1e",
        "SUMMARY": "382830e1-4b08-3edc-e6ec-ac9449409aa9"
    });
})();

var CorporateCustomerSubscriptionProcess = Object.freeze({
    "NEWSUBSCRIPTION": "A7D3E490-76FD-480A-B8DF-8598ABF97781"
});

var Grid = function (total, rows) {
    this.total = total;
    this.rows = rows;
};

var _context = function () {
    if (typeof GetGlobalContext != "undefined")
    { return GetGlobalContext(); }
    else {
        if (typeof window.parent.Xrm != "undefined") {
            return window.parent.Xrm.Page.context;
        }
        else { throw new Error("Context is not available."); }
    }
};

var _getClientUrl = function () {
    var clientUrl = this._context().getClientUrl();
    return clientUrl;
};

var _ODataPath = function () {
    return this._getClientUrl() + "/XRMServices/2011/OrganizationData.svc/";
};

var _errorHandler = function (req) {
    if (req.status == 12029)
    { return new Error("The attempt to connect to the server failed."); }
    if (req.status == 12007)
    { return new Error("The server name could not be resolved."); }
    var errorText = "";
    try {
        if (req.responseText) {
            errorText = JSON.parse(req.responseText).Message;
        }
        else {
            if (!(req.status)) {
                return null;
            }
        }
    }
    catch (e) {
        errorText = e.description;
    }
    return new Error("Error : " +
          req.status + ": " +
          req.statusText + ": " + errorText);
};

var _dateReviver = function (key, value) {
    var a;
    if (typeof value === 'string') {
        a = /Date\(([-+]?\d+)\)/.exec(value);
        if (a) {
            return new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
        }
    }
    return value;
};

var retrieveMultipleRecords = function (type, options, successCallback, errorCallback, OnComplete) {
    var optionsString;
    if (options != null) {
        if (options.charAt(0) != "?") {
            optionsString = "?" + options;
        }
        else { optionsString = options; }
    }
    var req = new XMLHttpRequest();
    req.open("GET", this._ODataPath() + type + "Set" + optionsString, false);
    req.setRequestHeader("Accept", "application/json");
    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    req.onreadystatechange = function () {
        if (this.readyState == 4 /* complete */) {
            req.onreadystatechange = null;
            if (this.status == 200) {
                var returned = JSON.parse(this.responseText, _dateReviver).d;
                successCallback(returned.results);
                if (returned.__next != null) {
                    var queryOptions = returned.__next.substring((_ODataPath() + type + "Set").length);
                    retrieveMultipleRecords(type, queryOptions, successCallback, errorCallback, OnComplete);
                }
                else { OnComplete(); }
            }
            else {
                errorCallback(_errorHandler(this));
            }
        }
    };
    req.send();
};

function createCrmRecord(object, type, successCallback, errorCallback, async) {
    var req = new XMLHttpRequest();
    req.open("POST", encodeURI(this._ODataPath() + type + "Set"), async);
    req.setRequestHeader("Accept", "application/json");
    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    req.onreadystatechange = function () {
        if (this.readyState == 4 /* complete */) {
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
    translationScope_JS_CustomerSearchScript.GetData();

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
                alert(translationScope_JS_CustomerSearchScript.data.tError1 + odataSetName + translationScope_JS_CustomerSearchScript.data.tError2 + XmlHttpRequest.responseText);
            }
        }
    });

}

function retrieveCrmRecord(id, type, select, expand, successCallback, errorCallback, async) {

    var systemQueryOptions = "";

    if (select != null || expand != null) {
        systemQueryOptions = "?";
        if (select != null) {
            var selectString = "$select=" + select;
            if (expand != null) {
                selectString = selectString + "," + expand;
            }
            systemQueryOptions = systemQueryOptions + selectString;
        }
        if (expand != null) {
            systemQueryOptions = systemQueryOptions + "&$expand=" + expand;
        }
    }


    var req = new XMLHttpRequest();
    req.open("GET", encodeURI(this._ODataPath() + type + "Set(guid'" + id + "')" + systemQueryOptions), async);
    req.setRequestHeader("Accept", "application/json");
    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    req.onreadystatechange = function () {
        if (this.readyState == 4 /* complete */) {
            req.onreadystatechange = null;
            if (this.status == 200) {
                successCallback(JSON.parse(this.responseText, _dateReviver).d);
            } else {
                errorCallback(errorHandler(this));
            }
        }
    };
    req.send();
}