wizard.controller("deliveryController",
    ['$scope', '$filter', '$http', '$rootScope', '$q', '$window', 'uiGridConstants',
        function ($scope, $filter, $http, $rootScope, $q, $window, uiGridConstants, uiGridGroupingConstants) {

            var apiUrl = Wizard.Util.configStore.PsbRestServiceUrl;
            $scope.direct = $rootScope.direct; // setting direction for RTL language
            if ($scope.direct === "rtl") {
                $scope.isRTL = true;
            }
            else {
                $scope.isRTL = false;
            }

            if (typeof $scope.scopeData === "undefined") {
                $scope.scopeData = {};
            }

            var GuidEmpty = "00000000-0000-0000-0000-000000000000";

            var config = {
                withCredentials: true
            };

            $scope.scopeData.delivery = {
                cart: {
                    items: {}
                },
                resourceRequiredOrderItems: [],
                simNumber: [],
                assignSimNumber: function () {
                    selectedNumberObject = JSON.parse($scope.scopeData.delivery.selectedValue);
                    for (var i = 0; i < $scope.scopeData.delivery.resourceRequiredOrderItems.length; i++) {
                        if (!($scope.scopeData.delivery.simNumber[i])) {
                            $scope.scopeData.delivery.simNumber[i] = selectedNumberObject.stmedno;
                            return;
                        }
                    }
                },
                checkedNumberTCRMOperations: function (resourceRequiredOrderItem, numberObject, validated) {

                    var inputModel = {
                        "orderItemId": resourceRequiredOrderItem.guid,
                        "validated": validated,
                        "simCardResourceCharModel": {
                            "$type": "AmxPeruPSBActivities.Model.Resources.SIMCardOrderResourceCharacteristicModel, AmxPeruPSBActivities",
                            "ICCID": numberObject.serialNumber,
                            "IMSI": numberObject.portNumber,
                            "PUK": numberObject.puk,
                            "KI": numberObject.authenticationKey,
                            "IMEI": "0",
                            "SerialNumber": numberObject.serialNumber,
                            "Technology": "LTE3",
                            "SDP_ID": "5"
                        }
                    };

                    $http.post(apiUrl + 'SIMCardOrderItemOperations', JSON.stringify(inputModel), config)
                        .success(function (result) {
                            if (result) {
                                //console.log(result);
                                alert("Number has been validated!");
                            }
                        }).error(function (data, status, headers, config) {
                            $scope.httpLoading = false;
                        });
                },
                findResourceRequiredOrderItem: function () {
                    // for now target is only Prepaid Mobil Equipment
                    var t = 0;
                    for (var i = 0; i < $scope.scopeData.delivery.cart.items.length; i++) {
                        var item = $scope.scopeData.delivery.cart.items[i];
                        if (item.Family === "Mobile" && item.OfferTypeCodeValue === "Equipment") {
                            $scope.scopeData.delivery.resourceRequiredOrderItems[t] = item;
                            t++;
                        }                        
                    }
                    if (t > 0) {
                        $scope.scopeData.delivery.storageMediumSearch();
                    }
                },
                getOrderBasket: function () {
                    var deferred = $q.defer();
                    var orderItemGuid = window.parent.Xrm.Page.data.entity.getId();

                    var workflowStartInput = {
                        "orderGuid": orderItemGuid
                    };

                    $http.post(apiUrl + 'GetOrderBasket', JSON.stringify(workflowStartInput), config)
                    .success(function (result) {
                        if (result) {
                            $scope.scopeData.delivery.cart.items = result.Output.orderBasket.listOfOrderBasketOrderItems;
                            deferred.resolve();
                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                        $scope.httpLoading = false;
                        });
                    return deferred.promise;
                },
                storageMediumSearch: function () {
                    var inputModel = {};

                    $http.post(apiUrl + 'StorageMediumSearch', JSON.stringify(inputModel), config)
                        .success(function (result) {
                            if (result) {
                                console.log(result);
                                $scope.scopeData.delivery.storageList = result.Output.response.allStoragemediums;
                            }
                        }).error(function (data, status, headers, config) {
                            $scope.httpLoading = false;
                        }).finally(function () {
                            //$scope.httpLoading = false;
                        });
                },
                storageMediumRead: function (resourceRequiredOrderItem, smId) {
                    var inputModel =
                        {
                            "smId": smId
                        };

                    $http.post(apiUrl + 'StorageMediumRead', JSON.stringify(inputModel), config)
                        .success(function (result) {
                            if (result) {
                                //console.log(result);
                                $scope.scopeData.delivery.checkedNumberTCRMOperations(resourceRequiredOrderItem, result.Output.response, true);
                            }
                        }).error(function (data, status, headers, config) {
                            $scope.httpLoading = false;
                        }).finally(function () {
                            //$scope.httpLoading = false;
                        });
                },
                updateStageName: function () {
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
                                "$values": ["tDelivery"],
                            }
                        };
                    $http.post(apiUrl + 'UpdateGenericEntityFields', JSON.stringify(workflowStartInput), config);
                },
                validateNumber: function (resourceRequiredOrderItem, index) {
                    numberObject = JSON.parse($scope.scopeData.delivery.selectedValue);
                    for (var i = 0; i < $scope.scopeData.delivery.storageList.length; i++) {
                        if ($scope.scopeData.delivery.storageList[i].stmedno === numberObject.stmedno) {
                            $scope.scopeData.delivery.storageMediumRead(resourceRequiredOrderItem, numberObject.smId);
                            // alert("Number has been validated!");
                            //$scope.scopeData.delivery.checkedNumberTCRMOperations(numberObject, true);
                            return;
                        }
                    }
                    // alert("Number has not been validated. Please try again.");
                    // $scope.scopeData.delivery.selectedValue = "";
                    //$scope.scopeData.delivery.checkedNumberTCRMOperations(numberObject, false);
                },
                validateUser: function () {
                    var deferred = $q.defer();
                    $scope.scopeData.delivery.userValidated = false;
                    var userId = Xrm.Page.context.getUserId().substring(1).substring(0, 36);

                    var req = new XMLHttpRequest();
                    var select = "/api/data/v8.2/teammemberships?$select=teamid,systemuserid&$orderby=systemuserid&$filter=teamid%20eq%2012c4798a-8e2c-e811-80ef-fa163e10dfbe and systemuserid eq  " + userId;
                    req.open("GET", Xrm.Page.context.getClientUrl() + select, false);
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

                                if (results.value.length > 0) {
                                    $scope.scopeData.delivery.userValidated = true;
                                }
                                deferred.resolve();
                            }
                        }
                    };
                    req.send();
                    return deferred.promise;
                }
            };


            initiate = function () {
                var promise = $scope.scopeData.delivery.validateUser();

                promise.then(function () {
                    if ($scope.scopeData.delivery.userValidated) {
                        var promiseBasket = $scope.scopeData.delivery.getOrderBasket();
                        promiseBasket.then(function () {
                            $scope.scopeData.delivery.findResourceRequiredOrderItem();
                        });
                    }
                    else {
                        alert("You can't operate in this stage please direct customer to Delivery Team");
                    }
                });
                $scope.scopeData.delivery.updateStageName();
            };

            initiate();

        }]);