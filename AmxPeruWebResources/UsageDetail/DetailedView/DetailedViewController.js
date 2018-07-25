var translationScope_JS_UsageDataController = {
    data: null,
    GetData: function () {
        var formId = "JS_UsageDataController";
        if (translationScope_JS_UsageDataController.data !== null) {
            return;
        }
        // window.parent.
        translationScope_JS_UsageDataController.data = GetTranslationData(formId);
    }
};
//debugger;
(function (angular, window, jQuery) {

    'use strict';

    translationScope_JS_UsageDataController.GetData();
    if (typeof Xrm === "undefined") {
        // if no crm is defined then implement dummy crm Xrm object.
        window.Xrm = {
            'Page': {
                'ui': {
                    'getFormType': function () {
                        return 0;
                    }
                }
            }
        };
    }
    var initPageReference;

    var _context = function () {
        if (typeof GetGlobalContext != "undefined") {
            return GetGlobalContext();
        } else {
            if (typeof window.parent.Xrm != "undefined") {
                return window.parent.Xrm.Page.context;
            } else {
                throw new Error("Context is not available.");
            }
        }
    };

    var _getClientUrl = function () {
        var clientUrl = _context().getClientUrl();
        return clientUrl;
    };

    var _ODataPath = function () {
        return _getClientUrl() + "/XRMServices/2011/OrganizationData.svc/";
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
            } else {
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
                    if (returned.__next != null) {
                        var queryOptions = returned.__next.substring((_ODataPath() + type + "Set").length);
                        retrieveMultipleRecords(type, queryOptions, successCallback, errorCallback, OnComplete);
                    } else {
                        OnComplete();
                    }
                } else {
                    errorCallback(_errorHandler(this));
                }
            }
        };
        req.send();
    };

    var webServerName = null;

    var getWebServerName = function () {
        if (constants.IsDebugMode) {
            return "esekamw055:6670"; //"localhost:6667"; //"esekamw055:6670"; //"esekamw057:6667";
        }
        if (webServerName === null) {
            retrieveMultipleRecords("etel_crmconfiguration", "$select=etel_value&$filter=etel_name eq 'OrderWebServiceServer'", function (results) {
                var firstResult = results[0];
                if (firstResult != null) {
                    webServerName = results[0].etel_value;
                }
            },
                function (error) {
                    alert(error.message);
                },
                function () { });

        }

        return webServerName;
    };
    var constants = {
        Namespace: "#Ericsson.ETELCRM.CommonServiceLibrary.Message",
        IsDebugMode: false
    };

    window.definitions = {
        namespace: "#Ericsson.ETELCRM.CommonServiceLibrary.Message",
        baseurl: (getWebServerName().split(":"))[0],
        url: getWebServerName() + "/OrderProcess.svc/rest/ExecuteRequest",
        messages: {
            UsageDataRequest: "UsageDataRequest:",
            RetrieveMultipleProductBySubscriptionRequest: "RetrieveMultipleProductBySubscriptionRequest",
            RetrieveDedicatedAccumulatorAccountRequest: "RetrieveDedicatedAccumulatorAccountRequest:",
            RetrieveTranslationRequest: "RetrieveTranslationRequest:"

        },
        parameters: {
            CorpCustomerId: "",
            UserId: "",
            SubscriptionId: "",
            Language: _context().getUserLcid()

        },
    };

    window.createRequest = function (messageName, obj) {
        obj.request = {
            "__type": messageName + definitions.namespace
        };
        return obj;
    };
}(angular, window, jQuery));


translationScope_JS_UsageDataController.GetData();

angular.module('UsageDetail.DetailedView', [])
    .controller('DetailedViewController', ['$scope', '$rootScope', '$http','$filter',
        function ($scope, $rootScope, $http, $filter) {

//.controller('DetailedViewController', ['$scope', '$rootScope', '$http', '$timeout', '$interval', 'uiGridConstants', '$filter',
//                function ($scope, $rootScope, $http, $timeout, $interval, uiGridConstants, uiGridGroupingConstants, $filter) {


            {
                if (typeof $scope.scopeData === "undefined") {
                    $scope.scopeData = {};
                }
                //$scope.scopeData.selectedProductSpec = null;

                $scope.scopeData.usageData = translationScope_JS_UsageDataController.data;

                $scope.initPage = function () {

                    var crmDurationMeasure = window.parent.Xrm.Page.getAttribute("etel_calldurationmeasurement").getOptions();
                    $scope.optDurationMeasure = new Object();
                    for (var i = 0; i < crmDurationMeasure.length; i++) {
                        if (crmDurationMeasure[i].value !== null) {
                            $scope.optDurationMeasure[crmDurationMeasure[i].value] = crmDurationMeasure[i].text;
                        }
                    }
                };
                // Item List Arrays
                $scope.scopeData.usageData.ProductSpecs = [];
                $scope.scopeData.products = function () {
                    if (Subscription.products === null) {
                        Subscription.retrieveProducts();
                    }
                    $scope.scopeData.selectedProductSpec = Subscription.products;
                    if (typeof $scope.specs === "undefined") {
                        $scope.specs = {};
                        $scope.specs.selected = "ALL";
                    }
                };
                //   debugger;
                $scope.getData = function () {

                    // Change focus to submit the last active input
                    window.parent.Xrm.Page.data.entity.save();
                    //window.parent.Xrm.Page.data.Entity.delete();
                    //window.parent.Xrm.Page.getControl("etel_searchlimit").setFocus(true);
                    //window.parent.Xrm.Page.getControl("etel_enddate").fireOnChange();
                    //window.parent.Xrm.Page.data.entity.attributes.get("etel_startdate").fireOnChange();
                    if (typeof $scope.specs === "undefined") {
                        $scope.specs = {};
                        $scope.specs.selected = "ALL";
                    }
                    // Prepare request
                    $scope.UsageData = null;
                    var baseUrl = window.definitions.baseurl + "/" + parent.Xrm.Page.context.getOrgUniqueName();
                    var reqItem = {
                        "request": null
                    };
                    reqItem = window.createRequest(window.definitions.messages.UsageDataRequest, reqItem);

                    // Do the request
                    if ($scope.fillQueryParameters(reqItem) && $scope.specs.selected !== "ALL") {
                        $scope.sendUsageDetailsRequest(reqItem);

                    }
                    else if ($scope.specs.selected === "ALL") {

                        var productIds = "";
                        if ($scope.scopeData.selectedProductSpec != null) {
                            for (var j = 0; j < $scope.scopeData.selectedProductSpec.length; j++) {

                                //productIds += $scope.scopeData.selectedProductSpec[j].Resources[0].Name + ';';
                                productIds += $scope.scopeData.selectedProductSpec[j].SerialNumber + ';';
                                console.log(productIds);
                            }
                        }
                        reqItem.request["ProductIdList"] = productIds;
                        if ($scope.fillQueryParameters(reqItem)) {
                            $scope.scopeData.usageData.IsSearchInProgress = true;
                            $scope.sendUsageDetailsRequest(reqItem);
                        }

                        //for (var j = 0; j < $scope.scopeData.selectedProductSpec.length; j++) {
                        //    reqItem.request["ProductId"] = $scope.scopeData.selectedProductSpec[j].SerialName;
                        //    if ($scope.fillQueryParameters(reqItem)) {
                        //        $scope.scopeData.usageData.IsSearchInProgress = true;
                        //        $scope.sendUsageDetailsRequest(reqItem);
                        //    }
                        //}
                    }
                };

                $scope.toMsDate = function (crmValue) {
                    var number = 0;
                    if (crmValue != null) {
                        number = crmValue.getTime();
                    }

                    return '\/Date(' + number + ')\/';
                };
                $scope.sendUsageDetailsRequest = function (reqItem) {
                    $http.post(window.definitions.url, reqItem, { "withCredentials": true }).success(function (result) {
                        if (result.d.Success) {
                            $scope.scopeData.usageData.IsSearchInProgress = false;
                            if ($scope.UsageData === null) {
                                $scope.UsageData = angular.fromJson(result.d.JsonResult);
                            } else {
                                $scope.UsageData.push.apply(angular.fromJson(result.d.JsonResult));
                            }

                            // Convert results into human readable format
                            for (var i = 0; i < $scope.UsageData.length; i++) {
                                var date = new Date($scope.UsageData[i].timeOfCall);
                                var data = $scope.UsageData[i];
                                data.timeOfCall = $filter('date')(date, "yyyy/MM/dd HH:mm");

                                data.callType = ($scope.UsageData[i].callType === "1" || $scope.UsageData[i].callType === "Outgoing") ? "Outgoing" : (($scope.UsageData[i].callType === "2" || $scope.UsageData[i].callType === "Incoming") ? "Incoming" : "Other");

                                if ($scope.UsageData[i].callDurationMeasureUnit != null && $scope.UsageData[i].callDurationMeasureUnit != "Seconds" && $scope.UsageData[i].callDurationMeasureUnit != "Per Msg" && $scope.UsageData[i].callDurationMeasureUnit != "Bytes" && $scope.UsageData[i].callDurationMeasureUnit != "per Event"
                                    && $scope.UsageData[i].callDurationMeasureUnit != "Money" && $scope.UsageData[i].callDurationMeasureUnit != "Rating Clicks" && $scope.UsageData[i].callDurationMeasureUnit != "Minutes" && $scope.UsageData[i].callDurationMeasureUnit != "Hours"
                                    && $scope.UsageData[i].callDurationMeasureUnit != "Kilo Bytes" && $scope.UsageData[i].callDurationMeasureUnit != "Mega Bytes" && $scope.UsageData[i].callDurationMeasureUnit != "Giga Bytes" && $scope.UsageData[i].callDurationMeasureUnit != "Bit per second")
                                    data.callDurationMeasureUnit = $scope.optDurationMeasure[$scope.UsageData[i].callDurationMeasureUnit];

                                data.costOfCallCurrency = $scope.UsageData[i].costOfCallCurrency;

                                data.productSpec = $scope.UsageData[i].productId;

                                data.billIndicator = ($scope.UsageData[i].billIndicator === "0" || $scope.UsageData[i].billIndicator === "Billed") ? "Billed" : (($scope.UsageData[i].billIndicator === "1" || $scope.UsageData[i].billIndicator === "Unbilled") ? "Unbilled" : "Unknown");
                            }
                        }
                        else {
                            ////alert("Error in Query Service: \n" + result.d.JsonResult);
                            alert(translationScope_JS_UsageDataController.data.tErrorInQueryService + ": \n" + result.d.ErrorMessage);
                        }

                    }).error(function (data, status, headers, config) {
                        $scope.scopeData.usageData.IsSearchInProgress = false;
                        ////alert("UsageDataRequest: HTTP get error (" + status + ")");
                        alert(translationScope_JS_UsageDataController.data.tUsageDataHttpRequestErr + " (" + status + ")");
                        $scope.errorPage = data;
                    });

                };
                $scope.fillQueryParameters = function (reqItem) {

                    // Mandatory fields
                    reqItem.request["CustomerId"] = window.parent.Xrm.Page.getAttribute("etel_customerid").getValue();

                    reqItem.request["ContractId"] = window.parent.Xrm.Page.getAttribute("etel_contractid").getValue();

                    var tSearchLimit = window.parent.Xrm.Page.getAttribute("etel_searchlimit").getValue();
                    reqItem.request["SearchLimit"] = (tSearchLimit !== null) ? tSearchLimit : 100;
                    reqItem.request["SearchLimitSpecified"] = (tSearchLimit !== null);

                    // Optional fields
                    var tStartdate = window.parent.Xrm.Page.getAttribute("etel_startdate").getUtcValue();
                    var tEnddate = window.parent.Xrm.Page.getAttribute("etel_enddate").getUtcValue();

                    if ((!tStartdate) || (!tEnddate)) {
                        return false;
                    }

                    reqItem.request["FromDateSpecified"] = (tStartdate !== null);
                    reqItem.request["FromDate"] = $scope.toMsDate(tStartdate);

                    reqItem.request["ToDateSpecified"] = (tEnddate !== null);
                    reqItem.request["ToDate"] = $scope.toMsDate(tEnddate);

                    reqItem.request["BillIndicator"] = window.parent.Xrm.Page.getAttribute("etel_billstate").getValue();

                    var tCallType = window.parent.Xrm.Page.getAttribute("etel_calltype").getValue();
                    reqItem.request["CallType"] = (tCallType === 0) ? null : tCallType; // NOTE: Workaround: "All" option should be passed as "null" in value (It is defined as "0" in option set)
                    var tProductId = $scope.scopeData.selectedProductSpec; //reqItem.request["ProductId"] = window.parent.Xrm.Page.getAttribute("etel_productspecificationid").getValue();
                    if (tProductId !== null && $scope.specs.selected !== "ALL") reqItem.request["ProductId"] = $scope.specs.selected; //reqItem.request["ProductId"] = "TEL"; //tProductId[0].id;  TEL, SMS
                    else if ($scope.specs.selected === "ALL") {
                        return true;
                    } else return false;

                    // Following parameters are available, but not used.
                    //reqItem.request["CallingParty"]  = window.parent.Xrm.Page.getAttribute("etel_callingparty").getValue();
                    //reqItem.request["CalledParty"]  = window.parent.Xrm.Page.getAttribute("etel_calledparty").getValue();
                    return true; // Parameters are OK
                };

                // Used in subscription to get the External Id of the product spec
                $scope.getExternalIdOfProductSpec = function (productId) {
                    var columns = ['etel_externalid'];
                    var filter = "etel_productspecificationId" + " eq guid'" + productId + "'";
                    var prodSpecExternalId = null;

                    var crmrestkit = window.parent.CrmRestKit;
                    crmrestkit.ByQuery("etel_productspecification", columns, filter, false).fail(function (xhr, status, ethrow) {
                        window.console.log("Error <getExternalIdOfProductSpec()>: " + xhr.status);
                    }).done(function (collection) {
                        if (collection.d !== null && collection.d.results !== null && collection.d.results.length > 0) {
                            prodSpecExternalId = collection.d.results[0].etel_externalid;
                        }
                    });

                    return prodSpecExternalId;
                };

                // Used for debugging
                $scope.getDummyData = function () {
                    var reqItem = {
                        "request": null
                    };
                    reqItem = window.createRequest(window.definitions.messages.UsageDataRequest, reqItem);

                    if ($scope.fillQueryParameters(reqItem)) {
                        ////alert("params OK");
                        alert(translationScope_JS_UsageDataController.data.tParametersOk);
                    } else {
                        ////alert("params FAILED");
                        alert(translationScope_JS_UsageDataController.data.tParametersFailed);
                    }

                    $scope.UsageData = new Object();

                    for (var i = 0; i < 5; i++) {
                        $scope.UsageData[i] = new Object();
                        $scope.UsageData[i].originationAddress = "535*****5" + i;
                        $scope.UsageData[i].destinationAddress = "535*****6" + i;
                        $scope.UsageData[i].costOfCall = (i + 1) + "0";
                        $scope.UsageData[i].costOfCallCurrency = "Euro";
                        $scope.UsageData[i].timeOfCall = "2014.05.23 16:" + i + "0";
                        $scope.UsageData[i].timeOfCallSpecified = (i % 2 === 1) ? true : false;
                        $scope.UsageData[i].callDuration = "1" + i;
                        $scope.UsageData[i].callDurationMeasureUnit = "minutes";
                        $scope.UsageData[i].callType = (i % 2 === 1) ? "Incoming" : "Outgoing";
                        $scope.UsageData[i].usageDateSpecified = false;
                        $scope.UsageData[i].usageStatusSpecified = false;
                        $scope.UsageData[i].productPrice = null;
                        $scope.UsageData[i].partyRole = null;
                        $scope.UsageData[i].usageDateSpecified = null;
                        $scope.UsageData[i].unit = null;
                    }
                };

                // Set default search parameters
                //   debugger;
                $scope.clearSearch = function () {

                    window.parent.Xrm.Page.getAttribute("etel_billstate").setValue(window.parent.Xrm.Page.getAttribute("etel_billstate").getInitialValue());
                    window.parent.Xrm.Page.getAttribute("etel_calltype").setValue(window.parent.Xrm.Page.getAttribute("etel_calltype").getInitialValue());
                    window.parent.Xrm.Page.getAttribute("etel_searchlimit").setValue(window.parent.Xrm.Page.getAttribute("etel_searchlimit").getInitialValue());
                    // window.parent.Xrm.Page.getAttribute("etel_productspecificationid").setValue(null);
                    // Reset product spec
                    // set default value of the combobox
                    var element = $('#comboProductSpec');
                    element[0].value = element[0][0].value;
                    // Clear Grid jquery remove tr element of the grid
                    $("#usageCustomerDataGrid tr").remove();
                    //
                    var date = new Date();
                    window.parent.Xrm.Page.getAttribute("etel_enddate").setValue(date); // Set today
                    date = date.setMonth(date.getMonth() - 1);
                    window.parent.Xrm.Page.getAttribute("etel_startdate").setValue(date); // Set one month ago
                };
                $scope.initPage();
                $scope.scopeData.products();
                //   debugger;
                $scope.downloadGrid = function () {
                    var currentDate = new Date();
                    var fileName = "UsageDetails_" + currentDate.getDate() + "_" + (currentDate.getMonth() + 1) + "_" + currentDate.getFullYear() + ".xls";
                    //  $('#UsageCustomerDataGrid').datagrid('toExcel', fileName);
                    downloadtoExcel('#UsageCustomerDataGrid', fileName);
                };

            }


        }]);



function downloadtoExcel(tableID, filename) {
    //   return jq.each(function () {

    var uri = 'data:application/vnd.ms-excel;base64,'
        , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>'
        , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
        , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }

    //var alink = $('<a style="display:none"></a>').appendTo('body');
    //var view = $(this).datagrid('getPanel').find('div.datagrid-view');
    //  var headerTable = $(tableID + "Header").find("tbody")[0].innerHTML;
    var headerData = "<tr>";
    $(tableID + "Header" + " >tbody >tr >th").each(function (a, b) { headerData += ("<th>" + b.innerHTML + "</th>"); })
    headerData += "</tr>";
    var tableData = $(tableID).find("tbody")[0].innerHTML;
    var dataToExport = "<tbody>" + headerData + tableData + "</tbody>";
    // var table = $(tableID);// view.find('div.datagrid-view2 table.datagrid-btable').clone();
    //var tbody = table.find('>tbody');
    //view.find('div.datagrid-view1 table.datagrid-btable>tbody>tr').each(function (index) {
    //    $(this).clone().children().prependTo(tbody.children('tr:eq(' + index + ')'));
    //});

    //var head = view.find('div.datagrid-view2 table.datagrid-htable').clone();
    //var hbody = head.find('>tbody');
    //view.find('div.datagrid-view1 table.datagrid-htable>tbody>tr').each(function (index) {
    //    $(this).clone().children().prependTo(hbody.children('tr:eq(' + index + ')'));
    //});
    //hbody.prependTo(table);

    var ctx = { worksheet: name || 'Usage Detail', table: dataToExport || '' };

    dataURItoBlob(base64(format(template, ctx)), filename);

    //alink[0].href = uri + base64(format(template, ctx));
    //alink[0].download = filename;
    //alink[0].click();
    // alink.remove();
    //  })
}

function dataURItoBlob(dataURI, filename) {
    // convert base64 to raw binary data held in a string
    var byteString = atob(dataURI);
    // write the bytes of the string to an ArrayBuffer

    var ab = new ArrayBuffer(byteString.length);
    var ia = new Uint8Array(ab);
    for (var i = 0; i < byteString.length; i++) {
        ia[i] = byteString.charCodeAt(i);
    }
    // write the ArrayBuffer to a blob, and you're done

    var bb = new Blob([ab]);
    saveAs(bb, filename); //pass blob and file name

    //var blob = new Blob([ab], {
    //    type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
    //});
    //saveAs(blob, "Statement.xlsx");
}

