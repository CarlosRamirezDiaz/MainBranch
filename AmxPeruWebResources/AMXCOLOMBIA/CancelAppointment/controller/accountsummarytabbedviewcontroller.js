var Xrm, CrmRestKit, OrderProcess;
(function () {
    var clientApiWrapper;
    for (var frameIndex = 0, parentFrames = window.parent.frames; frameIndex < parentFrames.length; frameIndex++) {
        var parentFrame = parentFrames[frameIndex];
        if (parentFrame.frameElement.id === "customScriptsFrame") {
            clientApiWrapper = parentFrame;
            break;
        }
    }
    Xrm = clientApiWrapper.Xrm;
    CrmRestKit = clientApiWrapper.CrmRestKit;
    OrderProcess = clientApiWrapper;
})();

var app = angular.module('AccountSummaryTabbedViewApp', ['ngMaterial', 'ui.router', 'ngTouch', 'ngAnimate', 'bzm-date-picker',
    'ui.grid.expandable', 'ui.grid.pagination', 'ui.grid', 'ui.grid.edit', 'ui.grid.resizeColumns', 'ui.grid.selection', 'ui.grid.moveColumns', 'ui.grid.autoResize',
    'AccountSummary.Invoices',
    'AccountSummary.Orders',
    'AccountSummary.Subscriptions',
    'AccountSummary.CustomerAddresses',
    'AccountSummary.Activities',
    'AccountSummary.Appointments',
    'AccountSummary.Cases',
    'AccountSummary.UserSubscriptions',
    'AccountSummary.NetworkIncident'])
    .config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/tab/dash');
        $stateProvider
            .state('billingOverview', {
                url: "/billingOverview/:TabIndex",
                templateUrl: "partials/billingOverview.html"
            })
            .state('orders', {
                url: "/orders/:TabIndex",
                templateUrl: "partials/orders.html"
            })
            .state('subscriptions', {
                url: "/subscriptions/:TabIndex",
                templateUrl: "partials/subscriptions.html"
            })
            .state('customerAddresses', {
                url: "/customerAddresses/:TabIndex",
                templateUrl: "partials/customerAddresses.html"
            })
            .state('activities', {
                url: "/activities/:TabIndex",
                templateUrl: "partials/activities.html"
            })
            .state('appointments', {
                url: "/appointments/:TabIndex",
                templateUrl: "partials/appointments.html"
            })
            .state('cases', {
                url: "/cases/:TabIndex",
                templateUrl: "partials/cases.html"
            })
            .state('usersubscriptions', {
                url: "/usersubscriptions/:TabIndex",
                templateUrl: "partials/usersubscriptions.html"
            })
            .state('NetworkIncident', {
                url: "/NetworkIncident/:TabIndex",
                templateUrl: "partials/NetworkIncident.html"
            });
    })
    .directive('myEnter', function () {
        return function (scope, element, attrs) {
            element.bind("keydown keypress  ", function (event) {
                if (event.which === 13) {
                    scope.$apply(function () {
                        scope.$eval(attrs.myEnter);
                    });
                    event.preventDefault();
                }
            });
        };
    })
    .controller('AccountSummaryTabbedViewController', ['$scope', '$rootScope', '$location', '$log',
        function ($scope, $rootScope, $location, $log) {

            $scope.accountSummaryTabTranlations = GetTranslationData("AccountSummaryTab");
            setRtlDirection();

            $scope.tabs = [];

            $scope.tabs.push({ name: $scope.accountSummaryTabTranlations.tBillingOverview, url: "/billingOverview/", order: 0 });
            $scope.tabs.push({ name: $scope.accountSummaryTabTranlations.tOrderCaptures, url: "/orders/", order: 1 });
            $scope.tabs.push({ name: $scope.accountSummaryTabTranlations.tSubscriptions, url: "/subscriptions/", order: 2 });
            $scope.tabs.push({ name: $scope.accountSummaryTabTranlations.tCustomerAddresses, url: "/customerAddresses/", order: 3 });
            $scope.tabs.push({ name: $scope.accountSummaryTabTranlations.tActivities, url: "/activities/", order: 4 });
            $scope.tabs.push({ name: $scope.accountSummaryTabTranlations.tAppointments, url: "/appointments/", order: 5 });//name: "Appointments"
            //   $scope.tabs.push({ name: $scope.accountSummaryTabTranlations.tCases, url: "/cases/", order: 5 });
            $scope.tabs.push({ name: $scope.accountSummaryTabTranlations.tUserSubscription, url: "/usersubscriptions/", order: 6 });
            $scope.tabs.push({ name: $scope.accountSummaryTabTranlations.tNetworkIncident, url: "/NetworkIncident/", order: 7 });
            $scope.getParamValue = null;
            var param = Xrm.Page.context.getQueryStringParameters()
            if (param.is_ivroption != null && param.is_ivroption != undefined) {
                if (param.is_ivroption == "true") {
                    $scope.getParamValue = param.is_ivroption;
                }
            }

            $scope.currentValue = 0;
            $scope.$watch('selectedIndex', function (current, old) {
                if ($scope.getParamValue == "true" && current !== undefined) {
                    $scope.selectedIndex = 5;
                    $scope.currentValue = 5;
                    current = $scope.currentValue;
                    $scope.getParamValue = "false";
                }
                for (var ind = 0; ind < $scope.tabs.length; ind++) {
                    if (current == $scope.tabs[ind].order) {
                        $location.url($scope.tabs[ind].url + current);
                        break;
                    }
                }
            });

            //$scope.$watch('selectedIndex', function (current, old) {
            //    for (var ind = 0; ind < $scope.tabs.length; ind++) {
            //        if (current == $scope.tabs[ind].order) {
            //            $location.url($scope.tabs[ind].url + current);
            //            break;
            //        }
            //    }
            //});
        }]);

(function (angular, window) {
    "use strict";
    if (typeof window.parent.Xrm === "undefined") {
        // if no crm is defined then implement dummy crm Xrm object
        window.parent.Xrm = {
            'Page': {
                'ui': {
                    'getFormType': function () {
                        return 0;
                    }
                }
            }
        };
    }

    var _context = function () {
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
            webServerName = Util.configStore.OrderWebServiceServer;
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
        psbUrl: getPsbRestServiceUrl(),
        bilFileHandlerUrl: getWebServerName() + "/BILFileHandler.ashx?",
        messages: {
            RetrieveTranslationRequest: "RetrieveTranslationRequest:",
            SearchCustomerBillRequest: "SearchCustomerBillRequest:",
        },
        parameters: {
            CustomerId: "",
            ContractExternalId: "",
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