var dummy = function () {

};

var ermsconstants = new (function () {
    this.SecurityRoles = Object.freeze({
        "CASHIER": "c29e4e0a-5f8e-e411-8dda-005056ae4716"
    });
})();

/*\
|*|
|*|  :: cookies.js ::
|*|
|*|  A complete cookies reader/writer framework with full unicode support.
|*|
|*|  Revision #1 - September 4, 2014
|*|
|*|  https://developer.mozilla.org/en-US/docs/Web/API/document.cookie
|*|  https://developer.mozilla.org/User:fusionchess
|*|
|*|  This framework is released under the GNU Public License, version 3 or later.
|*|  http://www.gnu.org/licenses/gpl-3.0-standalone.html
|*|
|*|  Syntaxes:
|*|
|*|  * docCookies.setItem(name, value[, end[, path[, domain[, secure]]]])
|*|  * docCookies.getItem(name)
|*|  * docCookies.removeItem(name[, path[, domain]])
|*|  * docCookies.hasItem(name)
|*|  * docCookies.keys()
|*|
\*/

var docCookies = {
    getItem: function (sKey) {
        if (!sKey) {
            return null;
        }
        return decodeURIComponent(document.cookie.replace(new RegExp("(?:(?:^|.*;)\\s*" + encodeURIComponent(sKey).replace(/[\-\.\+\*]/g, "\\$&") + "\\s*\\=\\s*([^;]*).*$)|^.*$"), "$1")) || null;
    },
    setItem: function (sKey, sValue, vEnd, sPath, sDomain, bSecure) {
        if (!sKey || /^(?:expires|max\-age|path|domain|secure)$/i.test(sKey)) {
            return false;
        }
        var sExpires = "";
        if (vEnd) {
            switch (vEnd.constructor) {
                case Number:
                    sExpires = vEnd === Infinity ? "; expires=Fri, 31 Dec 9999 23:59:59 GMT" : "; max-age=" + vEnd;
                    break;
                case String:
                    sExpires = "; expires=" + vEnd;
                    break;
                case Date:
                    sExpires = "; expires=" + vEnd.toUTCString();
                    break;
            }
        }
        document.cookie = encodeURIComponent(sKey) + "=" + encodeURIComponent(sValue) + sExpires + (sDomain ? "; domain=" + sDomain : "") + (sPath ? "; path=" + sPath : "") + (bSecure ? "; secure" : "");
        return true;
    },
    removeItem: function (sKey, sPath, sDomain) {
        if (!this.hasItem(sKey)) {
            return false;
        }
        document.cookie = encodeURIComponent(sKey) + "=; expires=Thu, 01 Jan 1970 00:00:00 GMT" + (sDomain ? "; domain=" + sDomain : "") + (sPath ? "; path=" + sPath : "");
        return true;
    },
    hasItem: function (sKey) {
        if (!sKey) {
            return false;
        }
        return (new RegExp("(?:^|;\\s*)" + encodeURIComponent(sKey).replace(/[\-\.\+\*]/g, "\\$&") + "\\s*\\=")).test(document.cookie);
    },
    keys: function () {
        var aKeys = document.cookie.replace(/((?:^|\s*;)[^\=]+)(?=;|$)|^\s*|\s*(?:\=[^;]*)?(?:\1|$)/g, "").split(/\s*(?:\=[^;]*)?;\s*/);
        for (var nLen = aKeys.length, nIdx = 0; nIdx < nLen; nIdx++) {
            aKeys[nIdx] = decodeURIComponent(aKeys[nIdx]);
        }
        return aKeys;
    }
};

//Begin (erms.js) -------------
var angular = {};

(function (angular, window, jQuery) {
    "use strict";

    var constants = {
        Namespace: '#Ericsson.ERMS.Common.Services.Messages',
        IsDebugMode: false
    };

    var getCRMConfigurationValue = function (key) {
        var result;
        var columns = ['etel_value'];
        var filter = " etel_name eq '" + key + "'";

        var collection = CrmRestKit.ByQuery('etel_crmconfiguration', columns, filter, false);

        if (collection.responseJSON != null && collection.responseJSON.d != null && collection.responseJSON.d.results != null && collection.responseJSON.d.results.length > 0) {
            result = collection.responseJSON.d.results[0].etel_value;
        }
        return result;
    };

    window.utils = {
        getErmsAddress: function () {
            return getCRMConfigurationValue('ErmsAddress');
        }
    };

    window.definitions = {
        isDebugMode: constants.IsDebugMode,
        retrieveCrmRecord: function (odataSetName, url, callback) {
            retrieveCRMRecord(odataSetName, url, callback);
        },
        retrieveERMSRecord: function (request, serviceType, actionName, successCallback, errorCallback) {
            retrieveERMSRecord(request, serviceType, actionName, successCallback, errorCallback);
        },
        namespaces: {
            'GetUserByClaimRequest': 'Ericsson.ERMS.Entities.Security.WindowsAuthClaim, Ericsson.ERMS.Entities'
        }
    };

    window.createRequest = function (modelName, obj) {
        var clone = {};
        clone['__type'] = definitions.namespaces[modelName];
        for (var prop in obj) {
            clone[prop] = obj[prop];
        }
        return clone;
    };

    var getERMSRestServiceUrl = function (serviceType, actionName) {
        return window.utils.getErmsAddress() + "/api/V1/" + serviceType.controller + "/" + actionName;
    };

    var retrieveERMSRecord = function (request, serviceType, actionName, successCallback, errorCallback) {
        jQuery.support.cors = true;
        jQuery.ajax({
            //todo update rest service action
            url: getERMSRestServiceUrl(serviceType, actionName),
            data: JSON.stringify(request),
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            cache: false,
            xhrFields: { withCredentials: true },
            async: false,
            success: function (data, textStatus, XmlHttpRequest) {
                if (successCallback) {
                    successCallback(data, textStatus, XmlHttpRequest);
                }
            },
            error: function (XmlHttpRequest, textStatus, errorThrown) {
                if (errorCallback)
                    errorCallback(XmlHttpRequest, textStatus, errorThrown);
                else {
                    var errorJson = XmlHttpRequest.getResponseHeader('erms-error-message');

                    var errorObj = JSON.parse(errorJson);

                    if (errorObj.length !== 1) {
                        _errorHandler(XmlHttpRequest);
                    }
                    else if (errorObj[0].Code !== "Security_InvalidUserException0") {
                        _errorHandler(XmlHttpRequest);
                    }
                }
            }
        });
    };

    var _errorHandler = function (req) {
        if (req.status == 12029)
        { return new Error("The attempt to connect to the server failed."); }
        if (req.status == 12007)
        { return new Error("The server name could not be resolved."); }
        var errorText;
        try
        { errorText = JSON.parse(req.responseText).error.message.value; }
        catch (e)
        { errorText = req.responseText }
        return new Error("Error : " +
              req.status + ": " +
              req.statusText + ": " + errorText);
    };


    var retrieveCRMRecord = function (odataSetName, url, callback) {
        var serverUrl = location.href.split("/")[0] + "//" + location.href.split("/")[2];
        var ODataPath = serverUrl + "/" + window.parent.Xrm.Page.context.getOrgUniqueName() + "/XRMServices/2011/OrganizationData.svc/";
        var fullUrl = ODataPath + odataSetName + url;

        var result = null;
        jQuery.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: false,
            cache: false,
            url: fullUrl,
            beforeSend: function (XMLHttpRequest) {
                XMLHttpRequest.setRequestHeader("Accept", "application/json");
            },
            success: function (data, textStatus, XmlHttpRequest) {
                callback(data);
            },
            error: function (XmlHttpRequest, textStatus, errorThrown) {
                result = "hata";
            }
        });

        return result;
    }



    return false;
}(angular, window, jQuery));
//End (erms.js) -------------

if (typeof scopeData === "undefined") {
    scopeData = {};
}

$(document).ready(function () {

    if (!window.definitions.isDebugMode) {
        getDomainName();
    } else {
        scopeData.DomainName = "crmdevelopment\\eeriari";
        openDialogIfForceToOpenSession();
    }
});

var getDomainName = function () {
    var oDataSetName = "SystemUserSet";
    var oDataUrl = "?$select=DomainName&$filter=SystemUserId eq (guid'" + window.parent.Xrm.Page.context.getUserId() + "')";
    window.definitions.retrieveCrmRecord(oDataSetName, oDataUrl, domainNameCallBack);
};

var domainNameCallBack = function (result) {
    if (result && result.d) {
        scopeData.DomainName = result.d.results[0].DomainName;
        openDialogIfForceToOpenSession();
    }
}

var openDialogIfForceToOpenSession = function () {
    if (!HasSecurityRole(ermsconstants.SecurityRoles.CASHIER)) {
        return;
    }

    var webApiCertificateBypasserAddress = window.utils.getErmsAddress() + "/empty.css";
    jQuery.ajax({
        //todo update rest service action
        url: webApiCertificateBypasserAddress,
        type: "GET",
        cache: false,
        xhrFields: { withCredentials: true },
        success: function (data, textStatus) {
            var serviceType = { name: 'ERMSWebServiceServerSecurity', controller: 'SecurityFacade' };
            var actionName = 'LoginWithWindowsAuth';

            window.definitions.retrieveERMSRecord(null, serviceType, actionName, openDialog);
        },
        error: function (XmlHttpRequest, textStatus, errorThrown) {

        }
    });
    //, function () { });
};

var openDialog = function (data, textStatus, xmlHttpRequest) {
    if (!xmlHttpRequest.responseJSON.Login.User.ForceToOpenSession) {
        return;
    }

    docCookies.setItem('culture', xmlHttpRequest.responseJSON.Culture, 24 * 60 * 60, "/");
    docCookies.setItem('rightToLeft', xmlHttpRequest.responseJSON.RightToLeft, 24 * 60 * 60, "/");
    docCookies.setItem('languageId', xmlHttpRequest.responseJSON.LanguageId, 24 * 60 * 60, "/");
    docCookies.setItem('dateFormat', xmlHttpRequest.responseJSON.DateFormat, 24 * 60 * 60, "/");

    if (docCookies.getItem("ermsExistingSessionUserName") === scopeData.DomainName) {
        return;
    }

    var dialogOption = new Xrm.DialogOptions;
    dialogOption.width = 830;
    dialogOption.height = 570;
    parent.parent.Xrm.Internal.openDialog("$webresource:etel_/Scripts/templates/shared/index.htm",
        dialogOption,
        null, null, null);
};
