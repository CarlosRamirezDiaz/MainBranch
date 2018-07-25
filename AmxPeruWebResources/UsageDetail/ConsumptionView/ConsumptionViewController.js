angular.module('UsageDetail.ConsumptionViewController', [])
    .controller('ConsumptionViewController', ['$scope', '$rootScope', '$http', '$timeout', '$interval', 'uiGridConstants',
        function ($scope, $rootScope, $http, $timeout, $interval, uiGridConstants, uiGridGroupingConstants) {

            debugger;
            if (typeof $scope.scopeData === "undefined") {
                $scope.scopeData = {};
            }

            $scope.scopeData.translations = {
                getTranslations: function () {

                    $scope.scopeData.translations = GetTranslationData("DedicatedAccumulatorAccountForm");
                    document.title = $scope.scopeData.translations.tPageTitle;
                }

            };

            $scope.isSelected = [];
            $scope.selectedRow = null;
            $scope.toggleClass = function (index) {
                $scope.selectedRow = index;
                $scope.isSelected[index] = $scope.isSelected[index] == 'selected' ? '' : 'selected';
            };

            function tableText(tableCell) {
                alert(tableCell.innerHTML);
            }

            $scope.scopeData.translations.getTranslations();

            $scope.SearchBalanceHistoryInquiry = function () {
                var reqItem = {
                    "request": null
                };

                var queryParam = $scope.getDataParam();
                var subscriptionId = null;//queryParam[0][1];

                if (Xrm.Page.getAttribute("amxperu_relatedsubscription").getValue() != null && Xrm.Page.getAttribute("amxperu_relatedsubscription").getValue()[0] != null) {
                    subscriptionId = Xrm.Page.getAttribute("amxperu_relatedsubscription").getValue()[0].id;
                }

                var table = document.getElementById('configDataGridBody');
                var inputs = table.getElementsByClassName('selected');
                var id = "";
                for (var i = 0; i < inputs.length; i++) {
                    id = inputs[i].cells[8].innerText;
                }

                var ContractId = $scope.ExternalId;

                if (!id) {
                    id = $scope.MainAccountProductId;
                }
                var SNCode = id;
                var Startdate = new Date($scope.FromDate);
                var Enddate = new Date($scope.EndDate);
                Startdate.setHours(0, 0, 0);
                Enddate.setHours(23, 59, 59);

                if ($scope.DateValidation(Startdate, Enddate)) {
                    if (ContractId && SNCode) {
                        $scope.RetreiveBalanceHistoryInquiry(ContractId, SNCode, Startdate, Enddate);
                    }
                }
            };

            $scope.RetreiveBalanceHistoryInquiry = function (ContractId, SNCode, Startdate, Enddate) {

                var BalanceHistoryRequestModel = {
                    "$type": "ExternalApiActivities.Models.BalanceHistoryRequestModel, ExternalApiActivities",
                    "contractId": ContractId,
                    "snCode": SNCode,
                    "fromDate": $scope.modifyDateFormat(Startdate),
                    "endDate": $scope.modifyDateFormat(Enddate)
                };

                var reqData = { "requestModel": BalanceHistoryRequestModel };
                $scope.BalanceHistoryItems = null;
                $http.post(getPsbRestServiceUrl() + 'RetrieveBalanceHistory', reqData, { "withCredentials": true })
                    .success(function (result) {
                        if (result.Output != null) {
                            $scope.BalanceHistoryItems = result.Output.response.arrayOfBalanceHistory.item;
                        }
                    }).error(function (data, status, headers, config) {
                        alert($scope.scopeData.translations.tErrorOccurred + data.Message);
                    });

            };

            var convertDate = function (inputFormat) {
                var d = new Date(inputFormat);
                return [d.getMonth() + 1, d.getDate(), d.getFullYear()].join('/');
            };

            $scope.DateValidation = function (fromDate, endDate) {

                if (endDate == null || fromDate == null) {
                    alert('Date should be selected');

                    return false;
                }

                if (endDate < fromDate) {
                    alert($scope.scopeData.translations.tEndDateLessThenStartDate);
                    return false;
                }
                if (fromDate > endDate) {
                    alert($scope.scopeData.translations.tStartDateBiggerThenEndDate);
                    return false;
                }
                return true;
            };

            $scope.modifyDateFormat = function (tempInputDate) {

                var convertedDate = new Date(tempInputDate);
                var ValidDate = "/Date(" + convertedDate.getTime() + ")/";
                return ValidDate
            }

            $scope.dateSelected = function (date, pickerid) {
                if (pickerid == 'FromDate') {
                    $scope.filterDateFrom = date;
                }
                else if (pickerid == 'EndDate') {
                    $scope.filterDateTo = date;
                }
            }


            var initiate = function () {
                debugger;
                var reqItem = {
                    "request": null
                };
                var MainaccountBalance, ExternalId;
                var today = new Date();
                var threeMonthsAgo = new Date();
                threeMonthsAgo.setMonth(threeMonthsAgo.getMonth() - 12);
                $scope.filterDateFrom = $scope.FromDate = threeMonthsAgo;
                $scope.filterDateTo = $scope.EndDate = today;


                reqItem = window.createRequest(window.definitions.messages.RetrieveDedicatedAccumulatorAccountRequest, reqItem);
                var queryParam = $scope.getDataParam();
                var subscriptionId = null;//queryParam[0][1];

                if (Xrm.Page.getAttribute("amxperu_relatedsubscription").getValue() != null && Xrm.Page.getAttribute("amxperu_relatedsubscription").getValue()[0] != null) {
                    subscriptionId = Xrm.Page.getAttribute("amxperu_relatedsubscription").getValue()[0].id;
                }

                reqItem.request["SubscriptionId"] = subscriptionId;
                $http.post(window.definitions.url, reqItem, { "withCredentials": true }).success(function (result) {
                    if (result.d !== null) {
                        if (!result.d.Success) {
                            alert("Error occurred: " + result.d.ErrorMessage);
                        }
                        else {
                            $scope.ExternalId = result.d.ExternalId;
                            if (result.d.AccumulatorAccounts !== null && result.d.AccumulatorAccounts.length > 0) {
                                $scope.AccumulatorAccounts = result.d.AccumulatorAccounts;
                            }
                            if (result.d.DedicatedAccounts !== null && result.d.DedicatedAccounts.length > 0)
                                $scope.DedicatedAccounts = result.d.DedicatedAccounts;
                            if (result.d.MainAccount !== null && result.d.MainAccount.length > 0) {
                                $scope.MainAccount = result.d.MainAccount;
                                $scope.MainaccountBalance = result.d.MainAccount[0].Balance;
                                $scope.MainAccountProductId = result.d.MainAccount[0].ProductId;
                                $scope.MSISDN = result.d.MsisdnNumber;
                                $scope.UnitOfMeasure = result.d.UnitOfMeasure;
                                $scope.UnitCode = result.d.UnitCode;
                            }
                            $scope.SearchBalanceHistoryInquiry();
                        }
                    }
                }).error(function (data, status, headers, config) {
                    alert("Dedicated Accounts Error occurred: " + data.Message);
                });
            };

            $scope.getDataParam = function () {
                var vals = new Array();
                var result = new Array();

                if (location.search != "") {
                    vals = location.search.substr(1).split("&");
                    for (var i in vals) {
                        vals[i] = vals[i].replace(/\+/g, " ").split("=");
                    }

                    //look for the parameter named 'data'
                    for (var i in vals) {
                        if (vals[i][0].toLowerCase() == "data") {
                            result = $scope.parseDataValue(vals[i][1]);
                            break;
                        }
                    }
                }
                return result;
            };

            $scope.parseDataValue = function (datavalue) {
                if (datavalue != "") {
                    var vals = new Array();

                    vals = decodeURIComponent(datavalue).split("&");
                    for (var i in vals) {
                        vals[i] = vals[i].replace(/\+/g, " ").split("=");
                    }
                }
                return vals;
            };

            initiate();

            $scope.DownloadBalanceHistoryInquiry = function () {
                var currentDate = new Date();
                var fileName = "BalanceHistory_" + currentDate.getDate() + "_" + (currentDate.getMonth() + 1) + "_" + currentDate.getFullYear() + ".xls";
                //  $('#UsageCustomerDataGrid').datagrid('toExcel', fileName);
                downloadHistorytoExcel('#balanceHistoryGrid', fileName);
            };
        }]);


function downloadHistorytoExcel(tableID, filename) {
    //   return jq.each(function () {

    var uri = 'data:application/vnd.ms-excel;base64,'
        , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>'
        , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
        , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }

    var headerData = "";//"<tr>";
    // $(tableID + "Header" + " >tbody >tr >th").each(function (a, b) { headerData += ("<th>" + b.innerHTML + "</th>"); })
    // headerData += "</tr>";
    var tableData = "<tr>";// $(tableID).find("tbody")[0].innerHTML;
    $(tableID + " >tbody >tr >:not(:has(img))").each(function (a, b) { tableData += ("<td>" + b.innerText + "</td>") });
    tableData += "</tr>";
    var dataToExport = "<tbody>" + headerData + tableData + "</tbody>";

    var ctx = { worksheet: name || 'Balance History', table: dataToExport || '' };

    dataURItoBlob(base64(format(template, ctx)), filename);

}


(function (angular, window) {
    "use strict";
    var _context = function () {
        if (typeof GetGlobalContext != "undefined") {
            return GetGlobalContext();
        }
        else {
            if (typeof window.opener.Xrm != "undefined") {
                return window.opener.Xrm.Page.context;
            }
            else {
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
            if (this.readyState == 4
                /* complete */
            ) {
                req.onreadystatechange = null;
                if (this.status == 200) {
                    var returned = JSON.parse(this.responseText, _dateReviver).d;
                    successCallback(returned.results);
                    if (returned.__next != null) {
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

    var webServerName = null;

    var generateBaseUrl = function () {
        var context = _context;
        var serverUrl = window.location.host;
        if (serverUrl.match(/\/$/)) {
            serverUrl = serverUrl.substring(0, serverUrl.length - 1);
        }
        return serverUrl;
    }
    var getWebServerName = function () {
        if (constants.IsDebugMode) {
            return "esekamw055:6670";
        }
        if (webServerName == null) {
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
        url: getWebServerName() + "/OrderProcess.svc/rest/ExecuteRequest",
        messages: {
            RetrieveDedicatedAccumulatorAccountRequest: "RetrieveDedicatedAccumulatorAccountRequest:",
            RetrieveTranslationRequest: "RetrieveTranslationRequest:"
        },
        parameters: {
            SubscriptionId: "",
            Language: _context().getUserLcid()
        }
    };

    window.createRequest = function (messageName, obj) {
        obj.request = {
            "__type": messageName + definitions.namespace
        };
        return obj;
    };
}(angular, window));
