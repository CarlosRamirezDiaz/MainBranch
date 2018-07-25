var constants = new (function () {
    this.BIHeaderChannel = Object.freeze({ "FaceToFace": 831260000, "PhoneCall": 831260001, "Email": 831260002 });
    this.InteractionDirection = Object.freeze({ "Incoming": 2, "Outgoing": 1, "Event": 5, "All": 0 });
})();

var amxco_ctiCustomerSearch = {
    CustomerSearchUrl: "",
    View360Url: "",
    View360UrlExtraqs: "",
    ProspectCreateForm: "",
    DigiturnoTurnoId: "",
    CanalId: "",
    CustomerId: "",
    customerType: 2,
    ani: null,
    documentId: null,
    documentType: null,
    ivrOption: null,
    extension: null,
    ucid: null,

    Onload: function () {
        amxco_ctiCustomerSearch.ProspectCreateForm = Xrm.Page.context.getClientUrl() + "/main.aspx?etn=contact&Pagetype=entityrecord";
        amxco_ctiCustomerSearch.View360Url = Xrm.Page.context.getClientUrl() + "/main.aspx?etc=2&pagetype=entityrecord";

        parameters = Xrm.Page.context.getQueryStringParameters();

        var customparams = amxco_ctiCustomerSearch.ParseData(parameters);
        amxco_ctiCustomerSearch.ani = customparams.ani;
        amxco_ctiCustomerSearch.documentId = customparams.documentid;
        amxco_ctiCustomerSearch.documentType = customparams.documenttype;
        amxco_ctiCustomerSearch.ivrOption = customparams.ivroption;
        amxco_ctiCustomerSearch.extension = customparams.extension;
        amxco_ctiCustomerSearch.ucid = customparams.ucid;

        if (customparams.turnoid != undefined)
            amxco_ctiCustomerSearch.DigiturnoTurnoId = customparams.turnoid;

        if (customparams.canalid != undefined)
            amxco_ctiCustomerSearch.CanalId = customparams.canalid;

        amxco_ctiCustomerSearch.View360UrlExtraqs = "formid=e283abea-f298-4c98-9510-8e791d0e1ce5&id={[contactId]}&parameter_showWelcomeMessage=true&parameter_cti_option=" + amxco_ctiCustomerSearch.ivrOption;

        amxco_ctiCustomerSearch.CustomerSearchUrl = amxco_ctiCustomerSearch.createCustomerSearchUrl();

        if (amxco_ctiCustomerSearch.ani == "0" && amxco_ctiCustomerSearch.documentId == "") {
            amxco_ctiCustomerSearch.RedirectToCustomerSearch();
            return;
        }

        amxco_ctiCustomerSearch.SearchForIndividual(amxco_ctiCustomerSearch.ani, amxco_ctiCustomerSearch.documentId, amxco_ctiCustomerSearch.documentType);
    },

    createCustomerSearchUrl: function()
    {
        sessionStorage.clear();

        if (amxco_ctiCustomerSearch.ani)
            sessionStorage.setItem("parameter_ani", amxco_ctiCustomerSearch.ani);

        if (amxco_ctiCustomerSearch.documentType)
            sessionStorage.setItem("parameter_documenttype", amxco_ctiCustomerSearch.documentType);

        if (amxco_ctiCustomerSearch.documentId)
            sessionStorage.setItem("parameter_documentid", amxco_ctiCustomerSearch.documentId);

        if (amxco_ctiCustomerSearch.DigiturnoTurnoId)
            sessionStorage.setItem("parameter_digiturnoTurnoId", amxco_ctiCustomerSearch.DigiturnoTurnoId);

        if (amxco_ctiCustomerSearch.ivrOption)
            sessionStorage.setItem("parameter_ivroption", amxco_ctiCustomerSearch.ivrOption);

        var parameters = "parameter_showWelcomeMessage=true";
        var customerSearchUrl = Xrm.Page.context.getClientUrl() + "/main.aspx?area=etel_customersearch&page=CS&pageType=EntityList&web=true&extraqs=data=" + encodeURIComponent("parameter_showWelcomeMessage=true");

        return customerSearchUrl;
    },

    SearchForIndividual: function (ani, documentId, documentType) {

        if (documentId == null || documentId == "" || documentId == "0") {
            amxco_ctiCustomerSearch.SearchForIndividualByAni(ani);
            return;
        }

        if (documentType == undefined || documentType == null)
            documentType = 1;

        var searchUrl = Xrm.Page.context.getClientUrl() + "/api/data/v8.1/contacts?$select=firstname,telephone1,mobilephone&$filter=";

        searchUrl += "amxperu_documenttype eq " + documentType + " and etel_iddocumentnumber eq \'" + documentId + "\'";
        searchUrl += " and statecode eq 0 &$orderby=firstname asc&$count=true";

        var req = new XMLHttpRequest();
        req.open("GET", searchUrl, true);
        req.setRequestHeader("OData-MaxVersion", "4.0");
        req.setRequestHeader("OData-Version", "4.0");
        req.setRequestHeader("Accept", "application/json");
        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        req.setRequestHeader("Prefer", "odata.include-annotations=\"OData.Community.Display.V1.FormattedValue\"");
        req.setRequestHeader("Prefer", "odata.maxpagesize=50");
        req.onreadystatechange = function () {
            if (this.readyState === 4) {
                req.onreadystatechange = null;
                if (this.status === 200) {
                    var results = JSON.parse(this.response);
                    var recordCount = results["@odata.count"];

                    if (recordCount != 1) {
                        amxco_ctiCustomerSearch.SearchForIndividualByAni(ani, documentId);
                        return;
                    }

                    for (var i = 0; i < results.value.length; i++) {
                        var contactId = results.value[i]["contactid"];
                        amxco_ctiCustomerSearch.CustomerId = contactId;

                        var extraqs = amxco_ctiCustomerSearch.View360UrlExtraqs.replace("[contactId]", contactId);

                        var url = amxco_ctiCustomerSearch.View360Url + "&extraqs=" + encodeURIComponent(extraqs);

                        amxco_ctiCustomerSearch.open360View(url);
                        return;
                    }
                }
                else {
                    alert(this.statusText);
                }
            }
        };
        req.send();
    },

    SearchForIndividualByAni: function (ani, documentId) {

        var searchUrl = Xrm.Page.context.getClientUrl() + "/api/data/v8.1/contacts?$select=firstname,telephone1,mobilephone&$filter=";

        if (ani == null || ani == "" || ani == "0") {
            amxco_ctiCustomerSearch.RedirectToCustomerSearch();
            return;
        }

        searchUrl += "(telephone1 eq \'" + ani + "\' or mobilephone eq \'" + ani + "\')";

        searchUrl += " and statecode eq 0 &$orderby=firstname asc&$count=true";

        var req = new XMLHttpRequest();
        req.open("GET", searchUrl, true);
        req.setRequestHeader("OData-MaxVersion", "4.0");
        req.setRequestHeader("OData-Version", "4.0");
        req.setRequestHeader("Accept", "application/json");
        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        req.setRequestHeader("Prefer", "odata.include-annotations=\"OData.Community.Display.V1.FormattedValue\"");
        req.setRequestHeader("Prefer", "odata.maxpagesize=50");
        req.onreadystatechange = function () {
            if (this.readyState === 4) {
                req.onreadystatechange = null;
                if (this.status === 200) {
                    var results = JSON.parse(this.response);
                    var recordCount = results["@odata.count"];

                    if (recordCount != 1) {
                        amxco_ctiCustomerSearch.RedirectToCustomerSearch();
                        return;
                    }

                    for (var i = 0; i < results.value.length; i++) {
                        var contactId = results.value[i]["contactid"];
                        amxco_ctiCustomerSearch.CustomerId = contactId;

                        var extraqs = amxco_ctiCustomerSearch.View360UrlExtraqs.replace("[contactId]", contactId);

                        var url = amxco_ctiCustomerSearch.View360Url + "&extraqs=" + encodeURIComponent(extraqs);

                        amxco_ctiCustomerSearch.open360View(url);
                        return;
                    }
                }
                else {
                    alert(this.statusText);
                }
            }
        };
        req.send();
    },

    RedirectToCustomerSearch: function () {
        amxco_ctiCustomerSearch.CreateLaunchUrlLog(false, null);
        window.location.replace(amxco_ctiCustomerSearch.CustomerSearchUrl);
        return;
    },

    ProspectCreation: function (ani, documentId) {

        var extraqs = "formId=3A7BA5D1-84E6-4659-A654-9A4911A6A2F7";
        extraqs += "&mobilephone=[ani]";
        extraqs += "&etel_iddocumentnumber=[documentId]";
        extraqs += "&amxperu_documenttype=1";
        //extraqs += "&parameter_showWelcomeMessage=true";

        if (documentId != null && documentId != "" && documentId != "0") {
            extraqs = extraqs.replace("[documentId]", documentId);
        }
        else {
            extraqs = extraqs.replace("[documentId]", "");
        }

        if (ani != null && ani != "" && ani != "0") {
            extraqs = extraqs.replace("[ani]", ani);
        }
        else {
            extraqs = extraqs.replace("[ani]", "");
        }

        var url = amxco_ctiCustomerSearch.ProspectCreateForm + "&extraqs=" + encodeURIComponent(extraqs);
        window.location.replace(url);
    },

    ProspectCreation2: function (ani, documentId) {
        var parameters = {};

        if (documentId != null && documentId != "" && documentId != "0") {
            parameters["amxperu_documenttype"] = "1";
            parameters["etel_iddocumentnumber"] = documentId;
        }

        if (ani != null && ani != "" && ani != "0") {
            parameters["mobilephone"] = ani;
        }

        // Open the window.
        if (Object.keys(parameters).length > 0) {
            var windowOptions = {
                openInNewWindow: false
            };

            Xrm.Utility.openEntityForm("contact", null, parameters, windowOptions);
        }
        else {
            window.location.replace(amxco_ctiCustomerSearch.CustomerSearchUrl);
        }
    },

    ParseData: function (parameters) {
        var result = {};

        var query = null;
        if (parameters.data != undefined)
            query = parameters.data;
        else if (parameters.DATA != undefined)
            query = parameters.DATA;
        else if (parameters.Data != undefined)
            query = parameters.Data;

        if (typeof query == "undefined" || query == null) {
            return result;
        }

        var queryparts = query.split("&");
        for (var i = 0; i < queryparts.length; i++) {
            var params = queryparts[i].split("=");
            result[params[0].toLowerCase()] = params.length > 1 ? params[1] : null;
        }
        return result;
    },

    open360View : function(url)
    {
        // Exists BiHeader?
        var biheader = amxco_ctiCustomerSearch.getBIHeader();
        if (biheader != null) {
            amxco_ctiCustomerSearch.closeBIHeader(biheader, url);
            return;
        }
        amxco_ctiCustomerSearch.createBiHeader(url);
    },

    getBIHeader: function () {
        var userId = Xrm.Page.context.getUserId();
        var oDataSetName = "etel_bi_headerSet";
        var oDataUrl = "?$select=ActivityId, etel_individualcustomerid, etel_accountid&$filter=OwnerId/Id eq guid'" + userId + "' and etel_headerstatus eq true";
        var data = retrieveCrmRecord(oDataSetName, oDataUrl);
        return data.results[0];
    },

    closeBIHeader: function (biheader, url) {
        var updtBiHeader = {};
        updtBiHeader.etel_headerstatus = false;
        updtBiHeader.StateCode = { Value: 2 };
        updtBiHeader.StatusCode = { Value: 3 };
        updtBiHeader.etel_biheaderendtime = new Date();

        SDK.REST.updateRecord(biheader.ActivityId, updtBiHeader, "etel_bi_header", function () {
            amxco_ctiCustomerSearch.createBiHeader(url);
        }, function () {
            alert("ctiCustomerSearch - Error closing Bi Header");
        });
    },

    createBiHeader: function(url)
    {
        amxco_ctiCustomerSearch.CreateLaunchUrlLog(true, null);

        var userId = Xrm.Page.context.getUserId();

        var createHeader = {};
        if (amxco_ctiCustomerSearch.DigiturnoTurnoId != "")
        {
            createHeader.Subject = 'Digiturno: ' + amxco_ctiCustomerSearch.DigiturnoTurnoId;
            createHeader.etel_channelinteractionid = amxco_ctiCustomerSearch.DigiturnoTurnoId;
        }
        else
            createHeader.Subject = 'CTI Call';

        createHeader.etel_headerstatus = true;
        createHeader.etel_csrid = userId.replace('{', '').replace('}', '');
        createHeader.etel_customeridtext = amxco_ctiCustomerSearch.CustomerId.replace('{', '').replace('}', '');
        createHeader.etel_customerrequired = true;
        createHeader.etel_reason = "Sales";

        createHeader.etel_biheaderchanneltypecode = {
            Value: constants.BIHeaderChannel.PhoneCall
        };
        createHeader.etel_interactiondirectiontypecode = {
            Value: constants.InteractionDirection.Incoming
        };

        createHeader.etel_channelinteractionstarttime = new Date();
        createHeader.etel_biheaderstarttime = new Date();

        if (amxco_ctiCustomerSearch.customerType === 1) {
            createHeader.etel_accountid = {
                Id: customerId,
                LogicalName: 'account'
            };

            CrmRestKit.Retrieve('Account', customerId, ['Name'], false).done(function (data) {
                if (data.d.Name) {
                    createHeader.etel_customername = data.d.Name;
                }
            });
        }
        else {
            createHeader.etel_individualcustomerid = {
                Id: amxco_ctiCustomerSearch.CustomerId,
                LogicalName: 'contact'
            };

            CrmRestKit.Retrieve('Contact', amxco_ctiCustomerSearch.CustomerId, ['FullName'], false).done(function (data) {
                if (data.d.FullName) {
                    createHeader.etel_customername = data.d.FullName;
                }
            });
        }

        createCrmRecord(createHeader, 'etel_bi_header', function () { },
            _errorHandler, true);

        window.location.replace(url);
    },

    CreateLaunchUrlLog: function(isCustomerFound, comment)
    {
        var createLaunchUrlLog = {};

        createLaunchUrlLog.amx_name = window.location.href;
        createLaunchUrlLog.amx_IsCustomerFound = isCustomerFound;

        if (amxco_ctiCustomerSearch.DigiturnoTurnoId != undefined && amxco_ctiCustomerSearch.DigiturnoTurnoId != null)
            createLaunchUrlLog.amx_digiturnoid = amxco_ctiCustomerSearch.DigiturnoTurnoId;

        if (amxco_ctiCustomerSearch.ani != undefined && amxco_ctiCustomerSearch.ani != null)
            createLaunchUrlLog.amx_ani = amxco_ctiCustomerSearch.ani;

        if (amxco_ctiCustomerSearch.documentId != undefined && amxco_ctiCustomerSearch.documentId != null)
            createLaunchUrlLog.amx_documentnumber = amxco_ctiCustomerSearch.documentId;

        if (amxco_ctiCustomerSearch.documentType != undefined && amxco_ctiCustomerSearch.documentType != null)
            createLaunchUrlLog.amx_documenttype = { Value: amxco_ctiCustomerSearch.documentType };

        if (amxco_ctiCustomerSearch.ivrOption != undefined && amxco_ctiCustomerSearch.ivrOption != null)
            createLaunchUrlLog.amx_ivroption = amxco_ctiCustomerSearch.ivrOption;

        if (amxco_ctiCustomerSearch.extension != undefined && amxco_ctiCustomerSearch.extension != null)
            createLaunchUrlLog.amx_extension = amxco_ctiCustomerSearch.extension;

        if (amxco_ctiCustomerSearch.ucid != undefined && amxco_ctiCustomerSearch.ucid != null)
            createLaunchUrlLog.amx_ucid = amxco_ctiCustomerSearch.ucid;

        if (comment != undefined && comment != null)
            createLaunchUrlLog.amx_comment = comment;

        createCrmRecord(createLaunchUrlLog, 'amx_launchurllog', function () { },
            _errorHandler, true);
    }
}

function retrieveCrmRecord(odataSetName, url) {
    
    if (!odataSetName) {
        alert("odataSetName empty!");
        return;
    }

    var ODataPath = Xrm.Page.context.getClientUrl() + "/XRMServices/2011/OrganizationData.svc/";
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

    var ODataPath = Xrm.Page.context.getClientUrl() + "/XRMServices/2011/OrganizationData.svc/";
    var req = new XMLHttpRequest();
    req.open("POST", encodeURI(ODataPath + type + "Set"), async);
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
        if (req.description != undefined)
            alert(req.description);

        if (req.responseText != undefined)
            errorText = req.responseText;
    }
    return new Error("Error : " + req.status + ": " + req.statusText + ": " + errorText);
};
