﻿wizard.controller('summaryController',
    ['$scope', '$http', '$rootScope', '$window', 'uiGridConstants',
        function ($scope, $http, $rootScope, $window, uiGridConstants, uiGridGroupingConstants) {
            debugger;
            var apiUrl = Wizard.Util.configStore.PsbRestServiceUrl;
            $scope.resumeInput.data = {};
            $scope.scopeData = {};

            $scope.scopeData.readTermsAndConditions = function () {
                debugger;
                $rootScope.ngDialog.open({
                        template: '../../../../../Webresources/amx_/newSubscription/templates/termsAndConditions.htm',
                        className: 'ngdialog-theme-plain custom-width',
                        scope: $scope
                });
            };

            //This function newly added to display order items in the basket
            $scope.scopeData.GetOrderBasket = function () {
                debugger;

                var orderCaptureGuid = Xrm.Page.data.entity.getId().substring(1).substring(0, 36);

                var config = {
                    withCredentials: true
                };

                $scope.workflowStartInput = {
                    orderGuid: orderCaptureGuid
                };

                $http.post(apiUrl + 'GetOrderBasket', JSON.stringify($scope.workflowStartInput), config)
                    .success(function (result) {
                        if (result) {
                            debugger;
                            var status = result.Output.orderBasket.message;
                            if (status == "SUCCESS") {
                                $scope.scopeData.OrderItems = result.Output.orderBasket.listOfOrderBasketOrderItems;

                                var monthlyCostTotals = 0;
                                var oneTimeCostTotals = 0;
                                if (typeof $scope.scopeData.OrderItems != "undefined") {
                                    for (i = 0; i < $scope.scopeData.OrderItems.length; i++) {

                                        monthlyCostTotals = monthlyCostTotals + Number($scope.scopeData.OrderItems[i].RecurringCharge);
                                        oneTimeCostTotals = oneTimeCostTotals + Number($scope.scopeData.OrderItems[i].OneTimeCharge);
                                    }
                                }
                                $scope.scopeData.monthlyCostTotals = monthlyCostTotals;
                                $scope.scopeData.oneTimeCostTotals = oneTimeCostTotals;
                            }
                            else {
                                alert("PSB returned an Error");
                            }
                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                        $scope.httpLoading = false;
                    }).finally(function () { });
            };

            $scope.scopeData.updateStageName = function () {
                var config = {
                    withCredentials: true
                };

                var workflowStartInput =
                    {
                        "entityId": Xrm.Page.data.entity.getId().substring(1).substring(0, 36),
                        "entityName": "etel_ordercapture",
                        "fieldNames": {
                            "$type": "System.Collections.Generic.List`1[System.String], mscorlib",
                            "$values": ["amx_laststagename"],
                        },
                        "fieldValues": {
                            "$type": "System.Collections.Generic.List`1[System.String], mscorlib",
                            "$values": ["tSummary"],
                        }
                    };
                $http.post(apiUrl + 'UpdateGenericEntityFields', JSON.stringify(workflowStartInput), config);
            };

            $scope.scopeData.Initate = function () {
                $scope.scopeData.GetOrderBasket();
                $scope.scopeData.translations = Wizard.GetTranslationData("NewSubscriptionSummary");
                
                var lookupObj = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
                if (lookupObj) {
                    var customerID = lookupObj[0].id;
                }

                $scope.scopeData.customerSummaryFullName = lookupObj[0].name;
                $scope.scopeData.updateStageName();
            }
            $scope.scopeData.Initate();

            //var apiUrl = Wizard.Util.configStore.PsbRestServiceUrl;
            //$scope.direct = $rootScope.direct; // setting direction for RTL language
            //if ($scope.direct === "rtl") {
            //    $scope.isRTL = true;
            //}
            //else {
            //    $scope.isRTL = false;
            //}
            //if (typeof $scope.scopeData === "undefined") {
            //    $scope.scopeData = {};
            //}

            //var apiUrl = Wizard.Util.configStore.PsbRestServiceUrl;
            //$scope.direct = $rootScope.direct; // setting direction for RTL language
            //if ($scope.direct === "rtl") {
            //    $scope.isRTL = true;
            //}
            //else {
            //    $scope.isRTL = false;
            //}
            //if (typeof $scope.scopeData === "undefined") {
            //    $scope.scopeData = {};
            //}

            //$scope.scopeData.GetOrderBasket = function () {
            //    debugger;

            //    var config = {
            //        withCredentials: true
            //    };

            //    var orderGuid = Xrm.Page.data.entity.getId();

            //    $scope.workflowStartInput = {
            //        "orderGuid": orderGuid
            //    };

            //    $http.post(apiUrl + 'GetOrderBasket', JSON.stringify($scope.workflowStartInput), config)
            //        .success(function (result) {
            //            if (result) {
            //                debugger;
            //                $scope.scopeData.OrderItems = result.Output.orderBasket.listOfOrderBasketOrderItems;
            //                $scope.saveInput.data = $scope.scopeData.OrderItems;
            //            }
            //        }).error(function (data, status, headers, config) {
            //            alert((data.ExceptionMessage === undefined ?
            //                (data.data === undefined ? data :
            //                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

            //            $scope.httpLoading = false;
            //        }).finally(function () {
            //            //$scope.httpLoading = false;
            //        });
            //}

            //$scope.scopeData.Initate = function () {
            //    debugger;
            //    $scope.scopeData.GetOrderBasket();
            //    $scope.resumeInput.data = {};
            //    $scope.resumeInput.data.province = "Test";
            //    $scope.scopeData.OrderItems = $rootScope.rootScopeData.order.OrderItemList;
            //    $scope.resumeInput.data.order = $rootScope.rootScopeData.order;
            //    $scope.scopeData.SelectedBillingAccounts = $scope.workflowContext.ResponseData.Output.billingAccountListModel;
            //}

            ////Call Controller Initiate Method
            //debugger;
            //$scope.scopeData.Initate();

        }]);
