if (typeof ($) === 'undefined') {
    $ = parent.$;
    jQuery = parent.jQuery;
}

var webServerName = null;

var constants = new (function () {
    this.Namespace = '#Ericsson.ETELCRM.CommonServiceLibrary.Message';
    this.IsDebugMode = false;
})();

//Function to Check the language code for Arabic
function IsRTL(languageCode) {

    var rtlLanguageCodes = ["5121", "15361", "3073", "2049", "11265", "13313", "12289", "4097", "6145", "8193", "16385", "1025", "10241", "7169", "14337", "9217", "1056", "1125"];// Urdu : "1056", Divehi: "1125" and all others are Arabic
    return (rtlLanguageCodes.indexOf(languageCode.toString()) > -1);
}


var PrepareTranslationRequest = function (request) {
    this.request = request;
}

var RequestTranslationMessage = new (function () {
    this.RetrieveTranslationRequest = 'RetrieveTranslationRequest';
})();

var RetrieveTranslationRequest = function (LanguageId, FormId) {
    this.__type = 'RetrieveTranslationRequest:' + constants.Namespace;
    this.LanguageId = ValidateNullParam(LanguageId);
    this.FormId = ValidateNullParam(FormId);
};

var GetAvailableWindowForXrm = function () {
    var availableWindow;
    if (typeof Xrm === "undefined") {
        if ((window.opener && (typeof window.opener !== "undefined")) && (window.opener.Xrm && (typeof window.opener.Xrm !== "undefined"))) {
            availableWindow = window.opener;
        }
        else {
            availableWindow = window.parent;
        }
    }
    else {
        availableWindow = window;
    }
    return availableWindow;
};

function GetUserLanguageCode() {
    var availableWindow = GetAvailableWindowForXrm();

    return availableWindow.Xrm.Page.context.getUserLcid();
}

function GetUserID() {
    var availableWindow = GetAvailableWindowForXrm();

    return availableWindow.Xrm.Page.context.getUserId();
}
function GetOrganizationName() {
    var availableWindow = GetAvailableWindowForXrm();

    return availableWindow.Xrm.Page.context.getOrgUniqueName();
}

function GetTranslationData(formId) {
    return Util.getTranslationData(formId);
}

function GetConfigData() {
    return Util.getConfigData();
}

function ValidateNullParam(param) {
    if (param === null || param === '') {
        return undefined;
    }
    else {
        return param;
    }
}

function GetODataPath() {
    return window.opener.Xrm.Page.context.getClientUrl() + "/XRMServices/2011/OrganizationData.svc/";
}
var _context = function () {
    if (typeof GetGlobalContext !== "undefined") {
        return GetGlobalContext();
    }
    else {
        if (typeof window.dialogArguments !== "undefined" && window.dialogArguments !== null) {
            return window.dialogArguments.XRMPage.context;
        }
        else if (typeof window.parent.Xrm !== "undefined") {
            return window.parent.Xrm.Page.context;
        }
        else if (typeof window.opener.Xrm !== "undefined") {
            return window.opener.Xrm.Page.context;
        }
        else {
            throw new Error("Context is not available.");
        }
    }
};

var _getClientUrl = function () {
    var clientUrl = this._context().getClientUrl();
    return clientUrl;
};

var _getClientUrlJustServerPath = function () {
    var clienteUrlsplit = typeof Xrm === "undefined" ? parent.Xrm.Page.context.getClientUrl().split('/') : Xrm.Page.context.getClientUrl().split('/');
    var protocol = clienteUrlsplit[0];
    var addressAndPort = clienteUrlsplit[2];
    var address = addressAndPort.split(':')[0];

    return protocol + "//" + address;
};

var _ODataPath = function () {
    return this._getClientUrl() + "/XRMServices/2011/OrganizationData.svc/";
};

var _errorHandler = function (req) {
    if (req.status === 12029) {
        return new Error("The attempt to connect to the server failed.");
    }
    if (req.status === 12007) {
        return new Error("The server name could not be resolved.");
    }
    var errorText;
    try {
        errorText = JSON.parse(req.responseText).Message;
    }
    catch (e) {
        errorText = req.responseText
    }
    return new Error("Error : " + req.status + ": " + req.statusText + ": " + errorText);
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
    if (options !== null) {
        if (options.charAt(0) !== "?") {
            optionsString = "?" + options;
        }
        else {
            optionsString = options;
        }
    }
    var req = new XMLHttpRequest();
    req.open("GET", this._ODataPath() + type + "Set" + optionsString, false);
    req.setRequestHeader("Accept", "application/json");
    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    req.onreadystatechange = function () {
        if (this.readyState === 4
            /* complete */
        ) {
            req.onreadystatechange = null;
            if (this.status === 200) {
                var returned = JSON.parse(this.responseText, _dateReviver).d;
                successCallback(returned.results);
                if ((returned.__next !== null) && (typeof returned.__next !== "undefined")) {
                    var queryOptions = returned.__next.substring((_ODataPath() + type + "Set").length);
                    retrieveMultipleRecords(type, queryOptions, successCallback, errorCallback, OnComplete);
                }
                else {
                    OnComplete();
                }
            }
            else {
                errorCallback(_errorHandler(this));
            }
        }
    };
    req.send();
};

function errorHandler(xmlHttpRequest, textStatus, errorThrown) {
    try {
        if (typeof textStatus == "undefined") //unexpe
        {
            return;
        }
        var newline = '\n';
        var message = '';

        var response;

        if (xmlHttpRequest.responseJSON) {
            try {
                response = xmlHttpRequest.responseJSON;
            }
            catch (etel_e) {
                if (xmlHttpRequest.responseText) {
                    response = xmlHttpRequest.responseText;
                }
            }
        }
        else {
            if (xmlHttpRequest.responseText) {
                response = JSON.parse(xmlHttpRequest.responseText);
            }
        }
        if (xmlHttpRequest.statusText) {
            message += xmlHttpRequest.statusText + newline;
        }
        if (response) {
            if (response.ExceptionType) {
                message += response.ExceptionType + +newline;
            }
            if (response.Message) {
                message += response.Message + newline;
            }
            if (response.StackTrace) {
                message += response.StackTrace + newline;
            }
        }

        Error(message);

    } catch (e) {
        Error("Error occurred during service invocation");
    }
}
function Error(error) {
    try {
        window.parent.Xrm.Utility.alertDialog(error);
    } catch (e) {
        Xrm.Utility.alertDialog(error);
    }
}


var Util = (function (module) {
    var constants = {
        ORDERSERVICENAME: "ORDERSERVICENAME",
        NULL_GUID: "00000000-0000-0000-0000-000000000000"
    };


    module.getCrmWebResourceVersion = function () {
        var resourceCache = undefined;
        var scripts = document.getElementsByTagName("script");
        for (var i = 0; i < scripts.length; i++) {
            var url = scripts[i].src;
            var p1 = url.search("/%7B")
            if (p1 > 0) {
                var p2 = url.search("%7D/", p1) + 4;
                resourceCache = url.substr(p1, (p2 - p1));
                break;
            }
        }
        resourceCache = decodeURI(resourceCache);
        if (resourceCache != undefined && resourceCache != null) {
            resourceCache = resourceCache.replace(/\//g, '');
        }
        if (resourceCache === undefined || resourceCache == null || resourceCache.length <= 0) {
            return "0";
        }
        return resourceCache;
    }

    //this parses html path end return version
    extractVersionFromUrl = function () {
        var version = undefined;
        var version = module.getCrmWebResourceVersion();
        return version;
    }

    module.retrieveMultipleRecords = function (type, options, successCallback, errorCallback, OnComplete) {
        var optionsString;
        if (options !== null) {
            if (options.charAt(0) !== "?") {
                optionsString = "?" + options;
            }
            else {
                optionsString = options;
            }
        }
        var req = new XMLHttpRequest();
        req.open("GET", _ODataPath() + type + "Set" + optionsString, false);
        req.setRequestHeader("Accept", "application/json");
        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        req.onreadystatechange = function () {
            if (this.readyState === 4
                /* complete */
            ) {
                req.onreadystatechange = null;
                if (this.status === 200) {
                    var returned = JSON.parse(this.responseText, _dateReviver).d;
                    successCallback(returned.results);
                    if ((returned.__next !== null) && (typeof returned.__next !== "undefined")) {
                        var queryOptions = returned.__next.substring((_ODataPath() + type + "Set").length);
                        retrieveMultipleRecords(type, queryOptions, successCallback, errorCallback, OnComplete);
                    }
                    else {
                        OnComplete();
                    }
                }
                else {
                    errorCallback(_errorHandler(this));
                }
            }
        };
        req.send();
    };

    module.getWebServerName = function () {
        if (constants.IsDebugMode) {
            return "esekamw059:6667";
        }
        if (webServerName === null) {
            module.retrieveMultipleRecords("etel_crmconfiguration", "$select=etel_value&$filter=etel_name eq 'OrderWebServiceServer'", function (results) {
                var firstResult = results[0];
                if (firstResult !== null) {
                    webServerName = results[0].etel_value;
                    if (webServerName.indexOf(':', 7) > 0)
                        webServerName = _getClientUrlJustServerPath() + ':' + webServerName.split(':')[2];
                }
            },
            function (error) {
                alert(error.message);
            },
            function () { });
        }

        return webServerName;
    }

    module.getLoggingWebServerName = function () {
        if (constants.IsDebugMode) {
            return "esekamw059:6667";
        }
        if (loggingWebServerName === null) {
            module.retrieveMultipleRecords("etel_crmconfiguration", "$select=etel_value&$filter=etel_name eq 'Logging_Service_URL'", function (results) {
                var firstResult = results[0];
                if (firstResult !== null) {
                    loggingWebServerName = results[0].etel_value;
                    if (loggingWebServerName.indexOf(':', 7) > 0)
                        loggingWebServerName = _getClientUrlJustServerPath() + ':' + loggingWebServerName.split(':')[2];
                }
            },
            function (error) {
                alert(error.message);
            },
            function () { });
        }

        return loggingWebServerName;
    }

    GetTranslationCachedServiceURL = function (langid) {
        var serviceAddress = undefined;
        var hostBaseAddress = GetCachedServiceURL();
        if (hostBaseAddress !== undefined) {
            var version = extractVersionFromUrl();
            serviceAddress = hostBaseAddress + "?v=" + version + "&action=translation&langId=" + langid;
        }
        return serviceAddress;
    }

    GetCachedServiceURL = function (orderServiceUrl) {
        var serviceAddress = undefined;
        var hostBaseAddress = orderServiceUrl;
        if (!hostBaseAddress) {
            hostBaseAddress = module.configStore.OrderWebServiceServer;
        }
        if (hostBaseAddress !== undefined) {
            serviceAddress = hostBaseAddress + "/CachedResource.ashx";
        }
        return serviceAddress;
    }

    var findTopWindow = function (wnd) {
        if (!wnd) {
            wnd = window;
        }

        if (wnd.parent !== wnd) {
            return findTopWindow(wnd.parent);
        }
        return wnd;
    };

    module.getCacheStore = function () {
        var top = findTopWindow();
        if (!top.cacheStore) {
            top.cacheStore = {};
        }
        return top.cacheStore;
    };

    module.cookieManager = {
        setCookie: function (cname, cvalue, exdays) {
            var cookieValue = cname + "=" + cvalue + "; ";
            if (exdays) {
                var d = new Date();
                d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
                var expires = "expires=" + d.toUTCString();
                cookieValue += expires;
            }
            document.cookie = cookieValue;
        },
        getCookie: function (name) {
            match = document.cookie.match(new RegExp('(^| )' + name + '=([^;]+)'));
            if (match) return match[2];
        }
    };

    module.getOrderServiceUrl = function () {
        //cacheKey is like: "http://machineName/SomeOrg/ORDERSERVICENAME", so every Crm Org cache its orderServiceUrl differently
        var ordUrlName = _getClientUrl() + '/' + constants.ORDERSERVICENAME;
        var orderServiceUrl = module.cookieManager.getCookie(ordUrlName);
        if (!orderServiceUrl) {
            orderServiceUrl = module.getWebServerName();
            module.cookieManager.setCookie(ordUrlName, orderServiceUrl);
        }
        return orderServiceUrl;
    }

    module.configStore = (function () {
        var cacheStore = module.getCacheStore();
        if (!cacheStore.configData) {
            var orderServiceUrl = module.getOrderServiceUrl();
            var version = extractVersionFromUrl();
            var configServiceUrl = GetCachedServiceURL(orderServiceUrl) + "?v=" + version + "&action=configuration";

            $.ajax({
                url: configServiceUrl,
                type: "GET",
                dataType: "json",
                contentType: "application/json",
                cache: true,
                async: false,
                xhrFields: {
                    withCredentials: true
                },
                success: function (data) {
                    cacheStore.configData = data[0];

                    if (cacheStore.configData.OrderWebServiceServer.indexOf(':', 7) > 0)
                        cacheStore.configData.OrderWebServiceServer = _getClientUrlJustServerPath() + ":" + cacheStore.configData.OrderWebServiceServer.split(':')[2];

                    if (cacheStore.configData.PsbRestServiceUrl.indexOf(':', 7) > 0)
                        cacheStore.configData.PsbRestServiceUrl = _getClientUrlJustServerPath() + ":" + cacheStore.configData.PsbRestServiceUrl.split(':')[2];

                    $.ajax({
                        url: cacheStore.configData.PsbRestServiceUrl + 'Echo',
                        type: "GET",
                        dataType: "json",
                        contentType: "application/json",
                        cache: true,
                        async: false,
                        xhrFields: {
                            withCredentials: true
                        }
                    });
                }
            });
        }
        return cacheStore.configData;
        //return { orderServiceUrl: orderServiceUrl };
    })();

    module.getTranslationData = function (formId) {
        var cacheStore = module.getCacheStore();
        if (!cacheStore.translationData) {
            var languageCode = GetUserLanguageCode();
            var transservis = GetTranslationCachedServiceURL(languageCode);
            $.ajax({
                url: transservis,
                type: "GET",
                dataType: "json",
                contentType: "application/json",
                cache: true,
                async: false,
                xhrFields: {
                    withCredentials: true
                },
                success: function (data) {
                    cacheStore.translationData = data;
                }
            });
        }
        if (cacheStore.translationData != undefined) {
            if (!cacheStore.translationData[formId]) {
                console.log("!!!!! Could not find translation definition for  " + formId + " in database, try clear browse cache and reopen browser ");
            }
            else {
                return cacheStore.translationData[formId][0];
            }
        } else {
            console.log("!!!!! Could not find translation definition for  " + formId + " in database, try clear browse cache and reopen browser ");
        }
    }

    module.getConfigData = function (formId) {
        var orderServiceUrl = module.getOrderServiceUrl();
        var version = extractVersionFromUrl();
        var cacheStore = module.getCacheStore();
        if (!cacheStore.configData) {

            var languageCode = GetUserLanguageCode();
            var configServiceUrl = GetCachedServiceURL(orderServiceUrl) + "?v=" + version + "&action=configuration";
            $.ajax({
                url: configServiceUrl,
                type: "GET",
                dataType: "json",
                contentType: "application/json",
                cache: true,
                async: false,
                xhrFields: {
                    withCredentials: true
                },
                success: function (data) {
                    cacheStore.configData = data;
                }
            });
        }
        if (!cacheStore.configData) {
            console.log("!!!!! Could not find configuration");
        }
        else {
            return cacheStore.configData;
        }
    }
    module.Security = function () {
        var getSecurityServiceURL = function (userId) {

            //if the cokie expired than generate new one
            var sessionkey = module.cookieManager.getCookie("sessionkey");
            if (!sessionkey) {
                sessionkey = module.generateUUID();
                module.cookieManager.setCookie("sessionkey", sessionkey);
            }

            var serviceAddress = undefined;
            var hostBaseAddress = GetCachedServiceURL();
            if (hostBaseAddress !== undefined) {
                var version = extractVersionFromUrl();
                serviceAddress = hostBaseAddress + "?v=" + version + "&v2=" + sessionkey + "&action=queryrole&userid=" + userId;
            }
            return serviceAddress;

        }

        var userHasBIPrivilage = function (biName) {

            var cacheStore = module.getCacheStore();
            var userId = Xrm.Page.context.getUserId();

            //window wide cache used for iframe 
            if (!cacheStore["BIPrivilageData" + userId]) {

                var url = getSecurityServiceURL(userId);
                $.ajax({
                    url: url,
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json",
                    cache: true,
                    async: false,
                    xhrFields: {
                        withCredentials: true
                    },
                    success: function (data) {
                        cacheStore["BIPrivilageData" + userId] = data;
                    }
                });
            }
            return cacheStore["BIPrivilageData" + userId][biName];
        }

        return {
            UserHasBIPrivilage: userHasBIPrivilage
        }
    }();

    module.generateUUID = function () {
        var d = new Date().getTime();
        if (window.performance && typeof window.performance.now === "function") {
            d += performance.now(); //use high-precision timer if available
        }
        var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d / 16);
            return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
        return uuid;
    }

    module.getJsDatefromMsDate = function (msDate) {
        var jsDate = new Date(parseInt(msDate.substr(6)));
        return jsDate;
    }

    var createCachedServiceURL = function (actionName, sessionCacheName, arrayOfNameValue) {

        var userId = GetUserID();
        var sessionkey = undefined;
        if (sessionCacheName != undefined) {
            //if the cokie expired than generate new one
            sessionkey = module.cookieManager.getCookie("sessionkey");
            if (!sessionkey) {
                sessionkey = module.generateUUID();
                module.cookieManager.setCookie("sessionkey", sessionkey);
            }
        }
        var serviceAddress = undefined;
        var hostBaseAddress = GetCachedServiceURL();
        if (hostBaseAddress !== undefined) {
            var version = extractVersionFromUrl();
            if (sessionCacheName != undefined) {
                serviceAddress = hostBaseAddress + "?v=" + version + "&v2=" + sessionkey + "&action=" + actionName + "&userid=" + userId;
            }
            else {
                serviceAddress = hostBaseAddress + "?v=" + version + "&action=" + actionName + "&userid=" + userId;
            }

            var len = arguments.length;
            if (len == 3) {
                for (var i = 0; i < arrayOfNameValue.length; i++) {
                    var param = arrayOfNameValue[i].name;
                    var value = arrayOfNameValue[i].value;
                    serviceAddress += "&" + param + "=" + value;
                }
            }
        }
        return serviceAddress;
    }

    module.callGetService = function (url, onSuccess, cache) {
        $.ajax({
            url: url,
            type: "GET",
            dataType: "json",
            contentType: "application/json",
            cache: cache,
            async: false,
            xhrFields: {
                withCredentials: true
            },
            success: function (data) {
                onSuccess(data);
            }
        });
    }

    module.getCountries = function () {
        var countries;
        var url = createCachedServiceURL("countries");
        module.callGetService(url, function (result) {
            countries = result;
        }, true);
        return countries;
    }

    module.getCountryById = function (countryId) {
        var countries = module.getCountries();
        for (var i = 0; i < countries.length; i++) {
            if (countries[i].ID === countryId)
                return countries[i];
        }
    }

    module.validatePostalCode = function (countryId, postalCode) {
        var result = { Status: false, StatusReason: '' };
        var country = module.getCountryById(countryId);

        if (!country) {
            result.Status = true;
        }
        else if (!country.PostalCodeRegex) {
            result.Status = true;
        }
        else if (country.PostalCodeRegex.length != postalCode.length) {
            result.Status = false;
        } else {
            var reg = new RegExp(country.RegexString);
            result.Status = reg.test(postalCode);
        }
        if (!result.Status) {
            //TODO: get message from translation
            result.StatusReason = 'Postal code is not valid for ' + country.Name;
        }
        return result;
    }

    module.getBiMoods = function () {
        var cacheStore = module.getCacheStore();
        if (!cacheStore.BiMoods) {
            var url = createCachedServiceURL("bimoods");
            module.callGetService(url, function (result) {
                cacheStore.BiMoods = result;
            }, true);
        }
        return cacheStore.BiMoods;
    }



    module.getProcessWizardStep = function (processName) {
        var wizards = undefined;
        var languagecode = GetUserLanguageCode();
        var url = createCachedServiceURL("ProcessWizard", undefined, [{ name: "WizardName", value: processName }, { name: "LanguageId", value: languagecode }]);
        module.callGetService(url, function (result) {
            wizards = result;
        }, true);

        if (!wizards) {
            throw new Error("Could not get process wizard steps for " + processName + " try to clear browser cache ");
        }
        return wizards;
    }

    module.retrieveProductCategory = function () {
        var data = undefined;
        var languagecode = GetUserLanguageCode();
        var url = createCachedServiceURL("ProductCategory");
        module.callGetService(url, function (result) {
            data = result;
        }, false);
        return data;
    }

    module.retrieveBrand = function (ProductCategoryId) {
        var data = undefined;
        var languagecode = GetUserLanguageCode();
        var url = createCachedServiceURL("Brand", undefined, [{ name: "ProductCategoryId", value: ProductCategoryId }]);
        module.callGetService(url, function (result) {
            data = result;
        }, false);
        return data;
    }

    module.retrieveModel = function (BrandId) {
        var data = undefined;
        var languagecode = GetUserLanguageCode();
        var url = createCachedServiceURL("Model", undefined, [{ name: "BrandId", value: BrandId }]);
        module.callGetService(url, function (result) {
            data = result;
        }, false);
        return data;
    }


    module.retrieveDevice = function (ModelId, BrandId, ProductCategoryId) {
        var data = undefined;
        var languagecode = GetUserLanguageCode();
        var url = createCachedServiceURL("Device", undefined, [{ name: "ModelId", value: ModelId },
        { name: "BrandId", value: BrandId }, { name: "ProductCategoryId", value: ProductCategoryId }]);
        module.callGetService(url, function (result) {
            data = result;
        }, false);
        return data;
    }

    module.retrieveMarket = function () {
        var data = undefined;
        var languagecode = GetUserLanguageCode();
        var url = createCachedServiceURL("Market");
        module.callGetService(url, function (result) {
            data = result;
        }, true);
        return data;
    }

    module.retrievePaymentOption = function () {
        var data = undefined;
        var languagecode = GetUserLanguageCode();
        var url = createCachedServiceURL("PaymentOption");
        module.callGetService(url, function (result) {
            data = result;
        }, true);
        return data;
    }

    module.getCities = function (countryId) {
        var cacheStore = module.getCacheStore();
        //window wide cache used for iframe 
        if (!cacheStore[countryId + "cities"]) {
            var url = createCachedServiceURL("cities", undefined, [{ name: "countryid", value: countryId }]);
            module.callGetService(url, function (result) {
                cacheStore[countryId + "cities"] = result;
            }, true);
        }
        return cacheStore[countryId + "cities"];
    }

    module.getBaseCurrencyId = function (organizationName) {
        var cacheStore = module.getCacheStore();
        if (!cacheStore[organizationName + "basecurrency"]) {
            var url = createCachedServiceURL("basecurrency", undefined, [{ name: "organizationname", value: organizationName }]);
            module.callGetService(url, function (result) {
                cacheStore[organizationName + "basecurrency"] = result;
            }, true);
        }
        return cacheStore[organizationName + "basecurrency"];
    }

    module.getActiveCurrencies = function () {
        var cacheStore = module.getCacheStore();
        if (!cacheStore.ActiveCurrencies) {
            var url = createCachedServiceURL("activecurrencies");
            module.callGetService(url, function (result) {
                cacheStore.ActiveCurrencies = result;
            }, true);
        }
        return cacheStore.ActiveCurrencies;
    }

    module.getCurrencyIdFromCurrencySymbol = function (currencySymbol) {
        var currencies = Util.getActiveCurrencies();
        for (var i = 0; i < currencies.length; i++) {
            if (currencies[i].CurrencySymbol === currencySymbol) {
                return currencies[i].TransactionCurrencyId;
            }
        }
    }

    module.getCurrencySymbolFromCurrencyId = function (currencyId) {
        var currencies = Util.getActiveCurrencies();
        for (var i = 0; i < currencies.length; i++) {
            if (currencies[i].TransactionCurrencyId === currencyId) {
                return currencies[i].CurrencySymbol;
            }
        }
    }

    module.getCurrencyCodeFromCurrencyId = function (currencyId) {
        var currencies = Util.getActiveCurrencies();
        for (var i = 0; i < currencies.length; i++) {
            if (currencies[i].TransactionCurrencyId === currencyId) {
                return currencies[i].ISOCurrencyCode;
            }
        }
    }

    module.SearchTemplate = function () {

        var getAllTemplates = function () {
            var cacheStore = module.getCacheStore();
            if (!cacheStore.searchtemplates) {
                var url = createCachedServiceURL("searchtemplates");
                module.callGetService(url, function (result) {
                    cacheStore.searchtemplates = result;
                }, true);
            }
            return cacheStore.searchtemplates;
        }

        var getRootTemplates = function () {
            return $(getAllTemplates()).filter(
              function (index, template) { return template.etel_parenttemplateid == constants.NULL_GUID; }
          ).toArray();
        }

        var getTemplateWithName = function (name) {
            return $(getRootTemplates()).filter(
               function (index, template) { return template.etel_name == name }
           ).toArray();
        }

        //returns childs templates whose parents template name is parent code
        var getCustomerSearchTemplatesWithParentCode = function (parentCode) {
            var parentTemplate = $(getRootTemplates()).filter(
               function (index, template) { return template.etel_name == parentCode }
               )[0];

            return $(getAllTemplates()).filter(
              function (index, template) { return template.etel_parenttemplateid == parentTemplate.etel_customersearchtemplateId }
            ).toArray();
        }

        return {
            getRootTemplates: getRootTemplates,
            getCustomerSearchTemplatesWithParentCode: getCustomerSearchTemplatesWithParentCode,
            getTemplateWithName: getTemplateWithName,
        }

    }();

    module.caching = {};
    module.caching.optionSet = function () {

        var get = function (entitylogicalname, attributelogicalname) {
            var languagecode = GetUserLanguageCode();
            //do not cache on windows local object
            var optionSet = undefined;
            var url = createCachedServiceURL("optionset", undefined, [{ name: "entitylogicalname", value: entitylogicalname }, { name: "attributelogicalname", value: attributelogicalname }, { name: "languagecode", value: languagecode }]);
            module.callGetService(url, function (result) {
                optionSet = result;
            }, true);
            return optionSet;
        }
        //public member functions
        return {
            get: get
        }
    }();

    //this function returns cached version url of the web resource
    //var url = getCachedWebResourceURL('/WebResources/etel_/AssignAccount.htm');
    module.getCachedWebResourceURL = function (webresourceUrl) {
        var scripts = document.getElementsByTagName("script");
        for (var i = 0; i < scripts.length; i++) {
            var url = scripts[i].src;
            var p1 = url.search("/%7B")
            if (p1 > 0) {
                var p2 = url.search("%7D/", p1) + 4;
                var resourceCache = url.substr(p1, (p2 - p1));
                break;
            }
        }
        var url = Xrm.Page.context.getClientUrl() + resourceCache + webresourceUrl;
        return url;
    }

    //return interface
    return module;
}(Util || {}));

function getWebServerName() {
    return Util.configStore.OrderWebServiceServer;
}

function getPsbRestServiceUrl() {
    return Util.configStore.PsbRestServiceUrl;
}

function getRestServiceUrl() {
    return getWebServerName() + "/OrderProcess.svc/rest";
}

function createCrmRecordUsingOData(object, type, oDataPath, successCallback, errorCallback) {
    var req = new XMLHttpRequest();

    req.open("POST", encodeURI(oDataPath + type + "Set"), true);
    req.setRequestHeader("Accept", "application/json");
    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");

    req.onreadystatechange = function () {
        if (this.readyState == 4 /* complete */) {
            req.onreadystatechange = null;
            if (this.status == 201) {
                successCallback(jQuery.parseJSON(this.response).d);
            }
            else {
                errorCallback(jQuery.parseJSON(this.response).error);
            }
        }
    };
    req.send(JSON.stringify(object));
}

function updateCrmRecordUsingOData(id, object, type, oDataPath, successCallback, errorCallback) {
    var req = new XMLHttpRequest();

    req.open("POST", encodeURI(oDataPath + type + "Set(guid'" + id + "')"), true);
    req.setRequestHeader("Accept", "application/json");
    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    req.setRequestHeader("X-HTTP-Method", "MERGE");
    req.onreadystatechange = function () {
        if (this.readyState == 4 /* complete */) {
            req.onreadystatechange = null;
            if (this.status == 204 || this.status == 1223) {
                successCallback();
            }
            else {
                errorCallback(jQuery.parseJSON(this.response).error);
            }
        }
    };
    req.send(JSON.stringify(object));
}

function retrieveRecordUsingOData(id, type, select, expand, oDataPath, successCallback, errorCallback, async) {
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
    req.open("GET", encodeURI(oDataPath + type + "Set(guid'" + id + "')" + systemQueryOptions), async);
    req.setRequestHeader("Accept", "application/json");
    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    req.onreadystatechange = function () {
        if (this.readyState == 4 /* complete */) {
            req.onreadystatechange = null;
            if (this.status == 200) {
                var returned = JSON.parse(this.responseText, _dateReviver).d;
                successCallback(returned);
            }
            else {
                errorCallback(jQuery.parseJSON(this.response).error);
            }
        }
    };
    req.send();
}

function retrieveRecordUsingODataFreeQuery(query, oDataPath, successCallback, errorCallback, async) {

    var req = new XMLHttpRequest();
    req.open("GET", encodeURI(oDataPath + query), async);
    req.setRequestHeader("Accept", "application/json");
    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    req.onreadystatechange = function () {
        if (this.readyState == 4 /* complete */) {
            req.onreadystatechange = null;
            if (this.status == 200) {
                var returned = JSON.parse(this.responseText, _dateReviver).d;
                successCallback(returned);
            }
            else {
                errorCallback(jQuery.parseJSON(this.response).error);
            }
        }
    };
    req.send();
}