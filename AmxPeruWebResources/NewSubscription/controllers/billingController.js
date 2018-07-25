    wizard.controller("billingController",
        ['$scope', '$http', '$rootScope', '$q', '$window', 'uiGridConstants',
            function ($scope, $http, $rootScope, $q, $window, uiGridConstants, uiGridGroupingConstants) {

                $scope.direct = $rootScope.direct; // setting direction for RTL language
                if ($scope.direct === "rtl") {
                    $scope.isRTL = true;
                }
                else {
                    $scope.isRTL = false;
                }
                //$rootScope.currentProcess = window.definitions.processesznewSubscription;
                $rootScope.displayColumnNewValue = false;
                $rootScope.displayColumnOption = false;
                if (typeof $scope.scopeData === "undefined") {
                    $scope.scopeData = {};
                }
                if (typeof $scope.resumeInput.data === "undefined" || $scope.resumeInput.data === null) {
                    $scope.resumeInput.data = {};
                }

                $scope.scopeData.translations = {};

                $scope.scopeData.translationScope_js_BI_CustomerBillingAccount = {
                    data: null,
                    GetData: function () {
                        var formId = 'js_BI_CustomerBillingAccount';
                        if (translationScope_js_BI_CustomerBillingAccount.data != null) {
                            return;
                        }
                        translationScope_js_BI_CustomerBillingAccount.data = GetTranslationData(formId);
                    }
                };

                //Create New Billing Account
                $scope.scopeData.CreateBillingAccount = function () {
                    var IsActiveCustomer = false;
                    var selectedEntityName = "contact";
                    var selectedEntityId;
                    var lookupObj = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
                    if (lookupObj) {
                        var lookupEntityType = lookupObj[0].entityType;
                        selectedEntityId = lookupObj[0].id;
                        var lookupRecordName = lookupObj[0].name;
                    }

                    var IndividualCustomerGuid = selectedEntityId.replace('{', '').replace('}', '');

                    var reqFetch = new XMLHttpRequest();
                    reqFetch.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_rateplans?$select=etel_name,etel_rateplanid&$filter=etel_externalid eq 'OCCRP'", true);
                    reqFetch.setRequestHeader("OData-MaxVersion", "4.0");
                    reqFetch.setRequestHeader("OData-Version", "4.0");
                    reqFetch.setRequestHeader("Accept", "application/json");
                    reqFetch.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                    reqFetch.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                    reqFetch.onreadystatechange = function () {
                        if (this.readyState === 4) {
                            reqFetch.onreadystatechange = null;
                            if (this.status === 200) {
                                var results = JSON.parse(this.response);
                                for (var i = 0; i < results.value.length; i++) {
                                    var etel_name = results.value[i]["etel_name"];
                                    var etel_rateplanid = results.value[i]["etel_rateplanid"];

                                    var entity = {};
                                    entity.statuscode = 1;
                                    entity["etel_occrateplanid@odata.bind"] = "/etel_rateplans(" + etel_rateplanid + ")";
                                    entity.etel_paymentarrangement = 831260000;
                                    entity.etel_paymentresponsible = true;
                                    entity.etel_paymentterm = 831260000;
                                    entity.etel_billcyclecode = 831260000;

                                    var req = new XMLHttpRequest();
                                    req.open("PATCH", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/contacts(" + IndividualCustomerGuid + ")", true);
                                    req.setRequestHeader("OData-MaxVersion", "4.0");
                                    req.setRequestHeader("OData-Version", "4.0");
                                    req.setRequestHeader("Accept", "application/json");
                                    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                                    req.onreadystatechange = function () {
                                        if (this.readyState === 4) {
                                            req.onreadystatechange = null;
                                            if (this.status === 204) {
                                                //Customer Is Now Made as Active In TCRM
                                                var parameters = {};
                                                parameters["_CreateFromId"] = selectedEntityId;
                                                parameters["_CreateFromType"] = 2;

                                                //TODO:Auto Number Create Should be ReUsed
                                                var BINumber = "BISC" + Math.floor(Math.random() * 899999 + 100000);
                                                if (BINumber != null) {
                                                    parameters["etel_binumber"] = BINumber;
                                                }

                                                var windowOptions = {
                                                    openInNewWindow: true
                                                };

                                                var entitytypecode = "etel_bi_billingaccountcreate";

                                                Xrm.Utility.openEntityForm(entitytypecode, null, parameters, windowOptions);
                                            } else {
                                                Xrm.Utility.alertDialog(this.statusText);
                                            }
                                        }
                                    };
                                    req.send(JSON.stringify(entity));
                                }
                            } else {
                                Xrm.Utility.alertDialog(this.statusText);
                            }
                        }
                    };
                    reqFetch.send();
                };

                $scope.scopeData.UpdateBillingAccount = function () {
                    var IsActiveCustomer = false;
                    var selectedEntityName = "contact";
                    var selectedEntityId;
                    var lookupObj = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
                    if (lookupObj) {
                        var lookupEntityType = lookupObj[0].entityType;
                        selectedEntityId = lookupObj[0].id;
                        var lookupRecordName = lookupObj[0].name;
                    }

                    var IndividualCustomerGuid = selectedEntityId.replace('{', '').replace('}', '');

                    var reqFetch = new XMLHttpRequest();
                    reqFetch.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_rateplans?$select=etel_name,etel_rateplanid&$filter=etel_externalid eq 'OCCRP'", true);
                    reqFetch.setRequestHeader("OData-MaxVersion", "4.0");
                    reqFetch.setRequestHeader("OData-Version", "4.0");
                    reqFetch.setRequestHeader("Accept", "application/json");
                    reqFetch.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                    reqFetch.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                    reqFetch.onreadystatechange = function () {
                        if (this.readyState === 4) {
                            reqFetch.onreadystatechange = null;
                            if (this.status === 200) {
                                var results = JSON.parse(this.response);
                                for (var i = 0; i < results.value.length; i++) {
                                    var etel_name = results.value[i]["etel_name"];
                                    var etel_rateplanid = results.value[i]["etel_rateplanid"];

                                    var entity = {};
                                    entity.statuscode = 1;
                                    entity["etel_occrateplanid@odata.bind"] = "/etel_rateplans(" + etel_rateplanid + ")";
                                    entity.etel_paymentarrangement = 831260000;
                                    entity.etel_paymentresponsible = true;
                                    entity.etel_paymentterm = 831260000;
                                    entity.etel_billcyclecode = 831260000;

                                    var req = new XMLHttpRequest();
                                    req.open("PATCH", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/contacts(" + IndividualCustomerGuid + ")", true);
                                    req.setRequestHeader("OData-MaxVersion", "4.0");
                                    req.setRequestHeader("OData-Version", "4.0");
                                    req.setRequestHeader("Accept", "application/json");
                                    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                                    req.onreadystatechange = function () {
                                        if (this.readyState === 4) {
                                            req.onreadystatechange = null;
                                            if (this.status === 204) {
                                                //Customer Is Now Made as Active In TCRM
                                                var parameters = {};
                                                parameters["_CreateFromId"] = selectedEntityId;
                                                parameters["_CreateFromType"] = 2;
                                                //parameters["etel_accountid"] = $scope.SelectedBillingAccount.billingAccountID;
                                                parameters["etel_billtoaddressid"] = $scope.SelectedBillingAccount.billingAddressID;
                                                parameters["etel_mailtoaddressid"] = $scope.SelectedBillingAccount.mailingAddressID;
                                                parameters["etel_billmediumcode"] = $scope.SelectedBillingAccount.billMediumCode;
                                                parameters["etel_numberofcopies"] = $scope.SelectedBillingAccount.numberOfCopies;
                                                parameters["etel_allowcallitemizationoninvoice"] = $scope.SelectedBillingAccount.callItemizationCode;


                                                //TODO:Auto Number Create Should be ReUsed
                                                var BINumber = "BISC" + Math.floor(Math.random() * 899999 + 100000);
                                                if (BINumber != null) {
                                                    parameters["etel_binumber"] = BINumber;
                                                }

                                                var windowOptions = {
                                                    openInNewWindow: true
                                                };

                                                var entitytypecode = "etel_billingaccountupdatebi";

                                                Xrm.Utility.openEntityForm(entitytypecode, null, parameters, windowOptions);
                                            } else {
                                                Xrm.Utility.alertDialog(this.statusText);
                                            }
                                        }
                                    };
                                    req.send(JSON.stringify(entity));
                                }
                            } else {
                                Xrm.Utility.alertDialog(this.statusText);
                            }
                        }
                    };
                    reqFetch.send();
                };

                $scope.scopeData.RefreshBillingAccount = function () {
                    var selectedEntityId;
                    var lookupObj = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
                    if (lookupObj) {
                        var lookupEntityType = lookupObj[0].entityType;
                        selectedEntityId = lookupObj[0].id;
                        var lookupRecordName = lookupObj[0].name;
                    }
                    var customerGuidStringify = selectedEntityId.toString().substr(1).slice(0, -1);
                    var req = new XMLHttpRequest();
                    req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_billingaccounts?$select=etel_allowcallitemizationoninvoice,etel_billmediumcode,_etel_billtoaddressid_value,_etel_mailtoaddressid_value,etel_name,etel_numberofcopies,etel_accountid&$filter=_etel_customerindividualid_value eq " + customerGuidStringify + "&$count=true", true);
                    req.setRequestHeader("OData-MaxVersion", "4.0");
                    req.setRequestHeader("OData-Version", "4.0");
                    req.setRequestHeader("Accept", "application/json");
                    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                    req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                    req.onreadystatechange = function () {
                        if (this.readyState === 4) {
                            req.onreadystatechange = null;
                            if (this.status === 200) {
                                var results = JSON.parse(this.response);
                                var recordCount = results["@odata.count"];
                                if (recordCount > 0) {
                                    $scope.scopeData.SelectedBillingAccounts = [];
                                    for (var i = 0; i < results.value.length; i++) {
                                        $scope.scopeData.SelectedBillingAccounts.push({
                                            "billingAccount": results.value[i]["etel_name"],
                                            "billingAddress": results.value[i]["_etel_billtoaddressid_value@OData.Community.Display.V1.FormattedValue"],
                                            "mailingAddress": results.value[i]["_etel_mailtoaddressid_value@OData.Community.Display.V1.FormattedValue"],
                                            "billMedium": results.value[i]["etel_billmediumcode@OData.Community.Display.V1.FormattedValue"],
                                            "numberOfCopies": results.value[i]["etel_numberofcopies@OData.Community.Display.V1.FormattedValue"],
                                            "callItemization": results.value[i]["etel_allowcallitemizationoninvoice@OData.Community.Display.V1.FormattedValue"],
                                            "language": "English",
                                            "billingAccountID": results.value[i]["etel_externalid"],
                                            "billingAddressID": results.value[i]["etel_billtoaddressid"],
                                            "mailingAddressID": results.value[i]["etel_mailtoaddressid"],
                                            "billMediumCode": results.value[i]["etel_billmediumcode"],
                                            "callItemizationCode": results.value[i]["etel_allowcallitemizationoninvoice"]
                                        });
                                    }
                                    $scope.scopeData.generateOrderItemBillingAccountMatrix();
                                }
                            } else {
                                Xrm.Utility.alertDialog(this.statusText);
                            }
                        }
                    };
                    req.send();                    
                };
            
                //This function newly added
                $scope.scopeData.GetOrderBasket = function () {
                    var deferred = $q.defer();

                    var orderCaptureGuid = Xrm.Page.data.entity.getId().substring(1).substring(0, 36);

                    var config = {
                        withCredentials: true
                    };

                    $scope.workflowStartInput = {
                        orderGuid: orderCaptureGuid
                    };

                    $http.post(Wizard.Util.configStore.PsbRestServiceUrl + 'GetOrderBasket', JSON.stringify($scope.workflowStartInput), config)
                        .success(function (result) {
                            if (result) {
                                var status = result.Output.orderBasket.message;
                                if (status == "SUCCESS") {
                                    $scope.scopeData.OrderItems = result.Output.orderBasket.listOfOrderBasketOrderItems;
                                    deferred.resolve();
                                    $scope.scopeData.generateOrderItemBillingAccountMatrix();
                                }
                                else {
                                    alert("PSB returned an Error");
                                    deferred.resolve();
                                }                                
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                            $scope.httpLoading = false;
                        }).finally(function () {

                        });
                    return deferred.promise;
                };

                //Modificación
                $scope.scopeData.OrderItemBAMatrix = [];

                if (sessionStorage.getItem["ssOrderItemBAMatrix"] != null) {
                    debugger;
                    var storedArray = JSON.parse(sessionStorage.getItem("ssOrderItemBAMatrix"));
                    var i;
                    for (i = 0; i < storedArray.length; i++) {

                        $scope.scopeData.OrderItemBAMatrix.push({
                            "billingAccounts": storedArray.billingAccounts,
                            "orderItem": storedArray.scopeData.OrderItems[i],
                            "selected": storedArray.selected
                        });

                    }
                }
                else {
                    debugger;
                    $scope.scopeData.generateOrderItemBillingAccountMatrix = function () {
                        $scope.scopeData.BAMatrix = [];
                        for (i = 0; i < $scope.scopeData.SelectedBillingAccounts.length; i++) {
                            $scope.scopeData.BAMatrix.push({
                                "billingAccount": $scope.scopeData.SelectedBillingAccounts[i].billingAccount,
                                "selected": false
                            });
                        }

                        var billingAccounts = $scope.scopeData.SelectedBillingAccounts;
                        for (i = 0; i < $scope.scopeData.OrderItems.length; i++) {
                            $scope.scopeData.OrderItemBAMatrix.push({
                                "billingAccounts": billingAccounts,
                                "orderItem": $scope.scopeData.OrderItems[i],
                                "selected": false
                            });
                        }

                        /*for (i = 0; i < $scope.scopeData.OrderItemBAMatrix.length; i++) {
                            for (j = 0; j < $scope.scopeData.OrderItemBAMatrix[i].billingAccounts.length; j++) {
                                $scope.scopeData.OrderItemBAMatrix[i].billingAccounts[j].selected = false;
                            }
                        }*/
                    };
                }

                sessionStorage.setItem("ssOrderItemBAMatrix", JSON.stringify($scope.scopeData.OrderItemBAMatrix));


            //Fin Modificación

                $scope.scopeData.selectApplyToAll = function (billingAccount) {
                    // Creating array to update BAs
                    $scope.scopeData.orderItemBAtoUpdate = [];

                    // Updating first row billing account to true
                    /*for (i = 0; i < $scope.scopeData.BAMatrix.length; i++) {
                        if ($scope.scopeData.BAMatrix[i].billingAccount == billingAccount) {
                            $scope.scopeData.BAMatrix[i].selected = true;
                        }
                    }*/

                    // Updating column to true and remaining to false
                    for (i = 0; i < $scope.scopeData.OrderItemBAMatrix.length; i++) {
                        for (j = 0; j < $scope.scopeData.OrderItemBAMatrix[i].billingAccounts.length; j++) {
                            if ($scope.scopeData.OrderItemBAMatrix[i].billingAccounts[j].billingAccount == billingAccount)
                            {
                                $scope.scopeData.OrderItemBAMatrix[i].billingAccounts[j].selected = true;
                                $scope.scopeData.orderItemBAtoUpdate.push({
                                    "orderItem": $scope.scopeData.OrderItemBAMatrix[i].orderItem.guid,
                                    "billingAccount": $scope.scopeData.OrderItemBAMatrix[i].billingAccounts[j].billingAccount
                                });
                            }
                            else $scope.scopeData.OrderItemBAMatrix[i].billingAccounts[j].selected = false;
                        }
                    }

                    for (w = 0; w < $scope.scopeData.orderItemBAtoUpdate.length; w++) {
                        $scope.scopeData.UpdateOrderItemWithBA($scope.scopeData.orderItemBAtoUpdate[w].orderItem, $scope.scopeData.orderItemBAtoUpdate[w].billingAccount);
                    }
                };

                // Update order item with BA
                $scope.scopeData.UpdateOrderItemWithBA = function (orderItemId, billingAccount) {
                    /*for (i = 0; i < $scope.scopeData.BAMatrix.length; i++) {
                        $scope.scopeData.BAMatrix[i].selected = false;
                    }*/
                    var promise = $scope.scopeData.udpateOrderItemBA(orderItemId, billingAccount);
                    promise.then(function () {
                    });
                };

                $scope.scopeData.udpateOrderItemBA = function (orderItemId, billingAccountId) {
                    var deferred = $q.defer();

                    var config = {
                        withCredentials: true
                    };

                    $scope.updateOrderItemModel = {
                        "orderItemId": orderItemId,
                        "billingAccountId": billingAccountId
                    };

                    $http.post(Wizard.Util.configStore.PsbRestServiceUrl + 'UpdateOrderItemBillingAccount', JSON.stringify($scope.updateOrderItemModel), config)
                        .success(function (result) {
                            if (result) {
                                deferred.resolve();
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                            $scope.httpLoading = false;
                        }).finally(function () {
                            //$scope.httpLoading = false;
                        });
                    return deferred.promise;
                };

                var initiate = function () {
                    $scope.scopeData.translations = Wizard.GetTranslationData("NewSubscriptionBilling");
                    $scope.scopeData.SelectedBillingAccounts = $scope.workflowContext.ResponseData.Output.billingAccountListModel;
                    // $scope.scopeData.OrderItems = $rootScope.rootScopeData.order;
                    $scope.scopeData.GetOrderBasket();
                    if ($rootScope.rootScopeData.order === undefined)
                        $scope.resumeInput.data.appointmentRequired = true;
                    else
                        $scope.resumeInput.data.appointmentRequired = $rootScope.rootScopeData.order.appointmentRequired;
                    /*var promise = $scope.scopeData.GetOrderBasket();
                    promise.then(function () {
                        $scope.scopeData.generateOrderItemBillingAccountMatrix();
                    });*/

                };
                initiate();
            }]);