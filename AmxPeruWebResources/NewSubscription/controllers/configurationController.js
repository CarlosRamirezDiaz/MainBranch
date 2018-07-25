wizard.controller("configurationController",
    ['$scope', '$http', '$rootScope', '$q', '$window', '$timeout', '$filter', 'uiGridConstants',
        function ($scope, $http, $rootScope, $q, $window, $timeout, $filter, uiGridConstants, uiGridGroupingConstants) {

            var apiUrl = Wizard.Util.configStore.PsbRestServiceUrl;
            var config = {
                withCredentials: true
            };

            $scope.direct = $rootScope.direct; // setting direction for RTL lanreserguage
            if ($scope.direct === "rtl") {
                $scope.isRTL = true;
            }
            else {
                $scope.isRTL = false;
            }
            if (typeof $scope.scopeData === "undefined") {
                $scope.scopeData = {};
            }
            if (typeof $rootScope.rootScopeData === "undefined") {
                $rootScope.rootScopeData = {};
            }
            if (typeof $rootScope.rootScopeData.order === "undefined") {
                $rootScope.rootScopeData.order = {};
            }

            $scope.resumeInput.data = {};
            if ($scope.saveInput.data == undefined) {
                $scope.saveInput.data = {};
            }
            $scope.scopeData.OrderItems = {};

            $scope.scopeData.configuration = {
                fillDevicesAndDeliveryOptions: function () {
                    var orderCaptureGuid = Xrm.Page.data.entity.getId();

                    var request = {
                        "orderCaptureId": orderCaptureGuid
                    };

                    $http.post(apiUrl + 'AmxGetRequiredAppointments', JSON.stringify(request), config)
                        .success(function (result) {
                            if (result) {
                                $scope.scopeData.configuration.deliverableOrderItems = {};
                                if (result.Output.hasBi == "True")
                                    $rootScope.rootScopeData.order.appointmentRequired = true;
                                else
                                    $rootScope.rootScopeData.order.appointmentRequired = false;

                                var t = 0;
                                for (var i = 0; i < result.Output.response.Value.length; i++) {
                                    for (var j = 0; j < result.Output.response.Value[i].OrdemItems.length; j++) {
                                        if (result.Output.response.Value[i].OrdemItems[j].BIdeliveryOptions.length > 0) {
                                            $scope.scopeData.configuration.deliverableOrderItems[t] = result.Output.response.Value[i].OrdemItems[j];
                                            t++;
                                        }
                                    }
                                }
                            }
                        }).error(function (data, status, headers, config) {
                            $rootScope.rootScopeData.order.appointmentRequired = true;
                            alert("No se puede retornar la necesidad de agendamiento.");
                        });
                },
                getTranslations: function () {
                    $scope.scopeData.configuration.translations = Wizard.GetTranslationData("NewAcquisitionConfiguration");
                },
                showCommunityWidget: function () {
                    $scope.CommunityWidget = true;
                    $scope.widgetLeft = $window.event.srcElement.getBoundingClientRect().left + $window.pageXOffset + $window.event.srcElement.scrollWidth - 18;
                    $scope.widgetTop = $window.event.srcElement.getBoundingClientRect().top + $window.pageYOffset - 187;
                },
                hideCommunityWidget: function (characteristics) {
                    $scope.CommunityWidget = false;
                    characteristics.IsChanged = true;
                },
                updateOrderCapture: function () {
                    var reqDataOrderCapture = {
                        "request": null
                    };
                    reqDataOrderCapture = window.createRequest(window.definitions.messages.UpdateOrderCaptureRequest, reqDataOrderCapture);
                    reqDataOrderCapture.request["OrderCapture"] = {
                        "OrderId": window.definitions.parameters.OrderId,
                        "CallItemization": $scope.scopeData.configuration.callItemizationCode,
                    };

                    $http.post(window.definitions.url, reqDataOrderCapture, { "withCredentials": true });
                },
                retrieveOrderCapture: function () {
                    //var reqData = {
                    //    "request": null
                    //};
                    //reqData = window.createRequest(window.definitions.messages.RetrieveOrderCaptureRequest, reqData);
                    //reqData.request["OrderCaptureId"] = window.definitions.parameters.OrderId;
                    //$http.post(window.definitions.url, reqData, { "withCredentials": true }).success(function (result) {
                    //    if (result.d) {
                    //        $scope.scopeData.configuration.callItemizationCode = result.d.Order.CallItemization;
                    //        $scope.scopeData.configuration.setCallItemizationText();
                    //    }
                    //});
                },
                setCallItemization: function () {
                    $scope.scopeData.configuration.callItemizationCode = !$scope.scopeData.configuration.callItemizationCode;
                    $scope.scopeData.configuration.setCallItemizationText();
                },
                setCallItemizationText: function () {
                    if ($scope.scopeData.configuration.callItemizationCode) $scope.scopeData.configuration.callItemizationText = $scope.scopeData.configuration.translations.tYes;
                    else $scope.scopeData.configuration.callItemizationText = $scope.scopeData.configuration.translations.tNo;
                }
            };

            $scope.scopeData.isPrimaryNumberServiceCalled = false;
            $scope.scopeData.isSecondaryNumberServiceCalled = false;
            $scope.scopeData.isPrepaidNumberServiceCalled = false;
            $scope.scopeData.selectedConfiguration = 'none';
            $scope.scopeData.selectedConfiguration.Id = "";
            $scope.scopeData.selectedConfiguration.Name = "";
            $scope.scopeData.selectedConfiguration.OrderItemId = "";
            $scope.scopeData.pendingCongigurationIconUrl = Xrm.Page.context.getClientUrl() + "/Webresources/amx_/NewSubscription/controllers/PendingConfiguration.jpg";
            $scope.scopeData.noCongigurationIconUrl = Xrm.Page.context.getClientUrl() + "/Webresources/amx_/NewSubscription/controllers/NoConfiguration.jpg";

            $scope.gridOptions = {};
            $scope.gridOptions.selectedItems = [];

            //Set the Properties of the Grid
            $scope.gridOptions.enableColumnResizing = true;
            //$scope.gridOptions.enableHorizontalScrollbar = uiGridConstants.scrollbars.ALWAYS;
            $scope.gridOptions.enableFiltering = false;
            $scope.gridOptions.enableGridMenu = false;
            $scope.gridOptions.showGridFooter = false;
            $scope.gridOptions.enablePinning = false;
            $scope.gridOptions.flatEntityAccess = false;
            $scope.gridOptions.showColumnFooter = false;
            $scope.gridOptions.fastWatch = true;
            $scope.gridOptions.enableRowSelection = true;
            $scope.gridOptions.enableRowHeaderSelection = false;
            $scope.gridOptions.multiSelect = false;
            $scope.gridOptions.modifierKeysToMultiSelect = false;
            $scope.gridOptions.noUnselect = false;
            //$scope.gridOptions.expandableRowTemplate = '<div ui-grid="row.entity.subGridOptions" class="sub-grid" style="height:70px; width:50%;"></div>';
            //$scope.gridOptions.expandableRowHeight = 70;
            //subGridVariable will be available in subGrid scope
            //$scope.gridOptions.expandableRowScope = {
            //    subGridVariable: 'subGridScopeVariable'
            //};
            $scope.gridOptions.enablePaginationControls = false;
            $scope.gridOptions.paginationPageSize = 10;
            $scope.gridOptions.rowIdentity = function (row) {
                return row.id;
            };
            $scope.gridOptions.getRowIdentity = function (row) {
                return row.id;
            };
            var strVar = "";
            strVar += "<div ng-mouseover=\"rowStyle={'background-color': '#D6EBFF'}; grid.appScope.onRowHover(this);\" ng-mouseleave=\"rowStyle={}\">";
            strVar += "    <div ng-style=\"rowStyle\" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.uid\" ui-grid-one-bind-id-grid=\"rowRenderIndex + '-' + col.uid + '-cell'\"";
            strVar += "         class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" role=\"{{col.isRowHeader ? 'rowheader' : 'gridcell'}}\" ui-grid-cell>";
            strVar += "    <\/div>";
            strVar += "<\/div> ";
            $scope.gridOptions.rowTemplate = strVar;
            //Set the Properties of the Grid

            $scope.BindGrid = function (data) {
                $scope.gridOptions.data = data;

                for (var i = 0; i < data.length; i++) {
                    data[i].id = i;
                    $scope.gridOptions.data[i].tLink = "Link";
                }

                $scope.gridOptions.columnDefs = [
                    { name: "DeviceName", displayName: "Device Name", field: 'DeviceName', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, cellTemplate: '<div class="ui-grid-cell-contents" ><a href="#" title="{{COL_FIELD}}" ng-click="grid.appScope.OnClickFinancialTransactionBI(row.entity)"><span>{{COL_FIELD}}</span></a></div>', width: 150 },
                    { name: "Storage", field: 'Storage', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "Color", field: 'Color', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "OTCAmount", displayName: "One Time Price", field: 'OTCAmount', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "RCAmount", displayName: "Recurring Price", field: 'RCAmount', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "Installment", displayName: "Installment", field: 'Installment', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 }
                ];
            };

            $scope.scopeData.updateShoppingCart = function () {
                var deferred = $q.defer();
                var config = {
                    withCredentials: true
                };

                $scope.workflowStartInput = {
                    "ProductCharacteristicsModel": {
                        "$type": "AmxPeruPSBActivities.Model.ProductCharacteristicsModel, AmxPeruPSBActivities",
                        message: "updateShoppingCart",
                        listOrderItems: $scope.scopeData.ProdCharItems
                    }
                };

                $http.post(apiUrl + 'UpdateShoppingCart', JSON.stringify($scope.workflowStartInput), config)
                    .success(function (result) {
                        if (result) {

                            var status = result.Output.status;
                            if (status) {
                                //$scope.scopeData.GetOrderBasket();
                            }
                            else {
                                alert("PSB Error Occured while UpdatingChar or Basket Details");
                            }
                            deferred.resolve();
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

            $scope.refreshOrderBasket = function () {
                promise = $scope.scopeData.updateShoppingCart();
                promise.then(function () {
                    alert("Basket refreshed");
                });
            };

            $scope.filter = function () {
                $scope.gridApi.grid.refresh();
            };

            $scope.scopeData.AddDeviceToShoppingCart = function () {

                //filteredListToUseInTemplate -- selected priceconfigId and offerid are available
                //selected chars and values has name, not guid. not important, can be retireved from priceconfig, but unnecessary.. need guid in model 

                var orderCaptureId = Xrm.Page.data.entity.getId().substring(1).substring(0, 36);
                var offeringId = $scope.filteredListToUseInTemplate[0].OfferingId;
                var priceConfigurationId = $scope.filteredListToUseInTemplate[0].Id;

                var orderItems = [];
                var opm = {
                    "$type": "AmxPeruPSBActivities.Model.AmxPeruOfferingPriceModel, AmxPeruPSBActivities",
                    OrderId: orderCaptureId,
                    OrderItemList: {
                        "$type": "System.Collections.Generic.List`1[[AmxPeruPSBActivities.Model.Offering, AmxPeruPSBActivities]], mscorlib",
                        $values: orderItems
                    }
                };

                var ordItem = {
                    OfferingId: offeringId,
                    PriceConfigurationId: priceConfigurationId,
                    OfferingName: $scope.filteredListToUseInTemplate[0].OfferingName,
                    OrderItemId: null,
                    OneTimeCharge: $scope.filteredListToUseInTemplate[0].OTCAmount,
                    RecurringCharge: $scope.filteredListToUseInTemplate[0].RCAmount
                };

                orderItems.push(ordItem);

                $scope.workflowPrice = {
                    "InputModel": opm
                };

                var config = { withCredentials: true };

                $http.post(apiUrl + 'AmxPeruAddDeviceToShoppingCart', JSON.stringify($scope.workflowPrice), config)
                    .success(function (result) {
                        if (result) {
                            $scope.scopeData.PriceConfiguration = result.Output.InputModel;
                            $scope.resumeInput.data.order = $scope.workflowPrice.InputModel;

                            for (var i = 0; i < result.Output.InputModel.OrderItemList.length; i++) {
                                $scope.resumeInput.data.order.OrderItemList.$values[i].OneTimeCharge = result.Output.InputModel.OrderItemList[i].OneTimeCharge;
                                $scope.resumeInput.data.order.OrderItemList.$values[i].RecurringCharge = result.Output.InputModel.OrderItemList[i].RecurringCharge;
                                $scope.resumeInput.data.order.OrderItemList.$values[i].Deposit = result.Output.InputModel.OrderItemList[i].Deposit;
                                $scope.resumeInput.data.order.OrderItemList.$values[i].PriceConfigurationId = result.Output.InputModel.OrderItemList[i].PriceConfigurationId;
                            }

                            $rootScope.rootScopeData.PriceConfiguration = $scope.scopeData.PriceConfiguration.OrderItemList;

                            if ($scope.scopeData.OrderItems.length > 0) {
                                for (var i = 0; i < $scope.scopeData.PriceConfiguration.OrderItemList.length; i++) {
                                    $scope.scopeData.OrderItems.push($scope.scopeData.PriceConfiguration.OrderItemList[i]);
                                }
                            }
                            else {
                                $scope.scopeData.OrderItems = $scope.scopeData.PriceConfiguration.OrderItemList;
                            }

                            $rootScope.rootScopeData.order = $scope.scopeData.OrderItems;
                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                        $scope.httpLoading = false;
                    }).finally(function () {
                    });

            };

            $scope.scopeData.getDeviceConfiguration = function () {
                var config = {
                    withCredentials: true
                };

                $scope.workflowStartInput = {
                    "deviceId": "4FB98AA3-3083-E711-8126-00505601173A"
                };

                $http.post(apiUrl + 'RetrieveDeviceInfoModel', JSON.stringify($scope.workflowStartInput), config)
                    .success(function (result) {
                        if (result) {

                            $scope.scopeData.DeviceConfiguration = result.Output.responseModel;

                            $scope.scopeData.Colors = result.Output.charValueCollection.ColorValues;
                            $scope.scopeData.Storages = result.Output.charValueCollection.StorageValues;
                            $scope.scopeData.Devices = result.Output.charValueCollection.DeviceNameValues;

                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                        $scope.httpLoading = false;
                    }).finally(function () {
                        //$scope.httpLoading = false;
                    });
            };

            $scope.scopeData.getAvailableResources = function () {
                var config = {
                    withCredentials: true
                };

                var orderCaptureId = Xrm.Page.data.entity.getId();

                $scope.workflowStartInput = {
                    "orderId": orderCaptureId
                };

                $http.post(apiUrl + 'RetriveResources', JSON.stringify($scope.workflowStartInput), config)
                    .success(function (result) {
                        if (result) {
                            $scope.scopeData.AvailableResources = result.Output.responseModel;
                            //Port In patch Code
                            for (var i = 0; i < $scope.scopeData.AvailableResources.OrderItems.length; i++) {
                                for (var j = 0; j < $scope.scopeData.AvailableResources.OrderItems[i].ResourcePossibleValues.length; j++) {
                                    if ($scope.scopeData.AvailableResources.OrderItems[i].ResourcePossibleValues[j].ResourceType == "MSISDN") {
                                        var retrievedVals = $scope.scopeData.AvailableResources.OrderItems[i].ResourcePossibleValues[j].Values;

                                        //put empty Identifier
                                        retrievedVals.push({
                                            'orderResourceId': "",
                                            'resourceId': "",
                                            'resourceName': "",
                                            'serialNumber': "--Select Port-In--"
                                        });

                                        for (var k = 0; k < $rootScope.rootScopeData.ListPortableMSISDN.length; k++) {
                                            retrievedVals.push({
                                                'orderResourceId': retrievedVals[0].orderResourceId,
                                                'resourceId': "",
                                                'resourceName': "dirNum",
                                                'serialNumber': $rootScope.rootScopeData.ListPortableMSISDN[k].msisdn
                                            });
                                        }

                                        $scope.scopeData.AvailableResources.OrderItems[i].ResourcePossibleValues[j].Values = retrievedVals;
                                    }
                                }
                            }
                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                        $scope.httpLoading = false;
                    }).finally(function () { });
            };

            $scope.scopeData.reserveResource = function () {
                //alert($scope.scopeData.selectedResource.serialNumber);

                if ($scope.scopeData.selectedResourceType == 'MSISDN') {

                    if ($scope.scopeData.selectedResource.resourceId == "") {
                        var entity = {};
                        entity.etel_value = $scope.scopeData.selectedResource.serialNumber;
                        entity.amxperu_isportin = true;

                        var req = new XMLHttpRequest();
                        req.open("PATCH", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_orderresources(" + $scope.scopeData.selectedResource.orderResourceId + ")", true);
                        req.setRequestHeader("OData-MaxVersion", "4.0");
                        req.setRequestHeader("OData-Version", "4.0");
                        req.setRequestHeader("Accept", "application/json");
                        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                        req.setRequestHeader("If-Match", "*");
                        req.onreadystatechange = function () {
                            if (this.readyState === 4) {
                                req.onreadystatechange = null;
                                if (this.status === 204) {
                                    alert("MSISDN for Port In Reserved Successfully");
                                } else {
                                    Xrm.Utility.alertDialog(this.statusText);
                                }
                            }
                        };
                        req.send(JSON.stringify(entity));
                    }
                    else {

                        var config = {
                            withCredentials: true
                        };

                        var orderCaptureId = Xrm.Page.data.entity.getId().substring(1).substring(0, 36);


                        //var orderResourceId = subscriptionResource.OrderResourceId;
                        //ReserveMSISDN
                        var Contract = {
                            "$type": "ExternalApiActivities.Models.ContractModel, ExternalApiActivities",
                            "ExternalId": null
                        }

                        var CustomerParty = {
                            "$type": "ExternalApiActivities.Models.Party, ExternalApiActivities",
                            "Name": null,
                            "Surname": null,
                            "LegalName": null
                        }

                        var Customer = {
                            "$type": "ExternalApiActivities.Models.CustomerModel, ExternalApiActivities",
                            "CustomerId": null,
                            "CustomerType": null,
                            "CustomerParty": CustomerParty
                        }

                        var resource = {
                            "$type": "ExternalApiActivities.Models.ResourceModel, ExternalApiActivities",
                            "ResourceName": $scope.scopeData.selectedResource.resourceName,
                            "ResourceNameSpecified": true,
                            "ResourceValue": $scope.scopeData.selectedResource.serialNumber,
                            "ResourceId": $scope.scopeData.selectedResource.resourceId,
                            "ImsiNumber": null
                        };

                        var Resources =
                            {
                                "$type": "ExternalApiActivities.Models.ResourceModel[], ExternalApiActivities",
                                "$values": [resource]
                            };

                        //$scope.scopeData.reqReserveData = { "OrderResourceId": $scope.scopeData.selectedResource.orderResourceId, "IsFromOrderCapture": "True", "OrderGuid": window.defproons.parameters.OrderId, "OrderId": window.parent.Xrm.Page.getAttribute("etel_name").getValue(), "OrderType": resourceType, "UserId": $scope.UserDomainName, "Resources": Resources, "Customer": Customer, "Contract": Contract };
                        $scope.scopeData.reqReserveData = { "OrderResourceId": $scope.scopeData.selectedResource.orderResourceId, "IsFromOrderCapture": "True", "OrderGuid": Xrm.Page.data.entity.getId().replace("}", "").replace("{", ""), "OrderId": Xrm.Page.getAttribute("etel_name").getValue(), "OrderType": "NEW_ACQUISITION", "UserId": "tcrm32lab\\administrator", "Resources": Resources, "Customer": Customer, "Contract": Contract };

                        $http.post(apiUrl + 'ReserveResource', JSON.stringify($scope.scopeData.reqReserveData), config)
                            .success(function (result) {
                                if (result) {
                                    alert("MSISDN reservation is successful!");
                                }
                            }).error(function (data, status, headers, config) {
                                alert((data.ExceptionMessage === undefined ?
                                    (data.data === undefined ? data :
                                        (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                                $scope.httpLoading = false;
                            }).finally(function () { });

                    }
                }
                else { //SIM
                    //alert($scope.scopeData.selectedResourceType);
                    var config = {
                        withCredentials: true
                    };

                    var orderCaptureId = Xrm.Page.data.entity.getId().substring(1).substring(0, 36);

                    $scope.workflowStartInput = {
                        "orderResourceId": orderCaptureId,
                        "partNumber": $scope.scopeData.selectedResourceType,
                        "resourceId": $scope.scopeData.selectedResource.serialNumber
                    };

                    $http.post(apiUrl + 'ReserveReourceInERMS', JSON.stringify($scope.workflowStartInput), config)
                        .success(function (result) {
                            if (result) {
                                alert('SIM Successfully reserved!');
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                            $scope.httpLoading = false;
                        }).finally(function () { });
                }
            };

            $scope.scopeData.SetSelected = function (resource, rtype) {

                $scope.scopeData.selectedResource = resource;
                $scope.scopeData.selectedResourceType = rtype;
                return;
            };

            $scope.scopeData.ProdCharItems = [];

            $scope.scopeData.getProductCharacteristis = function () {
                var deferred = $q.defer();

                var config = {
                    withCredentials: true
                };

                var orderItemGuid = window.parent.Xrm.Page.data.entity.getId();

                $scope.workflowStartInput = {
                    "orderGuid": orderItemGuid
                };

                $http.post(apiUrl + 'GetProductCharacteristics', JSON.stringify($scope.workflowStartInput), config)
                    .success(function (result) {
                        if (result) {
                            for (var i = 0; i < result.Output.prodCharModel.listOrderItems.length; i++) {
                                var item = result.Output.prodCharModel.listOrderItems[i];
                                if (item.listProdChar !== null) {
                                    for (var j = 0; j < item.listProdChar.length; j++) {
                                        var char = item.listProdChar[j].name;
                                        if (char == "Estrato") {
                                            if (amx_stratum != null || amx_stratum != undefined) {
                                                result.Output.prodCharModel.listOrderItems[i].listProdChar[j].inputValue = amx_stratum;//Added for updating Estrato based on customer selected
                                            }
                                            break;
                                        }
                                    }

                                }
                            }
                            $scope.scopeData.ProdCharItems = result.Output.prodCharModel.listOrderItems;
                            deferred.resolve();
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

            var writeoutNode = function (childArray, currentLevel, dataArray) {
                childArray.forEach(function (childNode) {
                    if (childNode.children.length > 0) {
                        childNode.$$treeLevel = currentLevel;
                    }
                    dataArray.push(childNode);
                    writeoutNode(childNode.children, currentLevel + 1, dataArray);
                });
            };

            $scope.CommunityWidget = false;
            $scope.stageLoaded = false;

            $scope.scopeData.configuration.retrieveOrderCapture();
            var setOrderItem = function () {
                var reqOrderItem = {
                    "request": null
                };

                $scope.SelectedProductCharacteristics = []; // Keep Current selected values

                reqOrderItem = window.createRequest(window.definitions.messages.RetrieveMultipleOrderItemRequest, reqOrderItem);
                reqOrderItem.request["OrderId"] = window.definitions.parameters.OrderId; //"39A268D2-ABAA-E311-ABC3-005056AE59A0";
                reqOrderItem.request["IncludePossibleCharacteristics"] = true;
                reqOrderItem.request["IncludeOrderProductCharacteristics"] = true;
                $http.post(window.definitions.url, reqOrderItem, { "withCredentials": true }).success(function (result) {
                    $scope.stageLoaded = true;
                    if (result.d !== null) {
                        $scope.OrderItems = result.d.OrderItems;
                        for (var orderIndex = 0; orderIndex < $scope.OrderItems.length; orderIndex += 1) {
                            $scope.OrderItems[orderIndex].isExpanded = true;
                            if ($scope.OrderItems[orderIndex].SubItems) {
                                for (var itemsIndex = 0; itemsIndex < $scope.OrderItems[orderIndex].SubItems.length; itemsIndex += 1) {
                                    $scope.OrderItems[orderIndex].SubItems[itemsIndex].isExpanded = true;
                                }
                            }

                            if ($scope.OrderItems[orderIndex].ProductCharacteristics.length > 0) {

                                $scope.OrderItems[orderIndex].ProductCharacteristics[0].CommunityWidget = false;
                                $scope.OrderItems[orderIndex].ProductCharacteristics[0].SelectedCharacteristics = [];
                                var valueIds = $scope.OrderItems[orderIndex].ProductCharacteristics[0].ProductCharacteristicValueIds;
                                if (valueIds != null && valueIds.length > 0) {
                                    for (var i = 0; i < valueIds.length; i += 1) {
                                        $scope.OrderItems[orderIndex].ProductCharacteristics[0].SelectedCharacteristics.push(valueIds[i]);
                                    }
                                }
                                if ($scope.SelectedProductCharacteristics.length > 0) {
                                    $scope.showCommunityWidget($scope.SelectedProductCharacteristics, $event);
                                }
                            }
                            else if ($scope.OrderItems[orderIndex].SubItems.length > 0) {
                                for (var j = 0; j < $scope.OrderItems[orderIndex].SubItems.length; j++) {
                                    if ($scope.OrderItems[orderIndex].SubItems[j].ProductCharacteristics.length > 0) {
                                        $scope.OrderItems[orderIndex].SubItems[j].ProductCharacteristics[0].CommunityWidget = false;
                                        $scope.OrderItems[orderIndex].SubItems[j].ProductCharacteristics[0].SelectedCharacteristics = [];
                                        var valueIds = $scope.OrderItems[orderIndex].SubItems[j].ProductCharacteristics[0].ProductCharacteristicValueIds;
                                        if (valueIds != null && valueIds.length > 0) {
                                            for (var i = 0; i < valueIds.length; i += 1) {
                                                $scope.OrderItems[orderIndex].SubItems[j].ProductCharacteristics[0].SelectedCharacteristics.push(valueIds[i]);
                                            }
                                        }
                                        if ($scope.SelectedProductCharacteristics.length > 0) {
                                            $scope.showCommunityWidget($scope.SelectedProductCharacteristics, $event);
                                        }
                                    }
                                }
                            }
                        }
                    }

                }).error(function (data, status, headers, config) {
                    alert('Error:' + data.Message);
                });
            };

            $scope.scopeData.configuration.getTranslations();

            var object = [{
                'dummy': true
            }];

            $scope.getDummy = function () {
                return object;
            };

            $scope.changeCharacteristic = function (item) {
                item.IsChanged = true;
            };

            $scope.expand = function (item) {
                item.isExpanded = !item.isExpanded;
            };

            function onlyUnique(value, index, self) {
                return self.indexOf(value) === index;
            }

            $scope.filterSelectedValues = function (characteristic) {
                if (characteristic.Options != null) {
                    var optionlist = [];
                    for (var j = 0; j < characteristic.Options.length; j++) {
                        optionlist.push(characteristic.Options[j].Name)
                    }
                    var unique = optionlist.filter(onlyUnique);
                    var diff = $(unique).not(characteristic.ProductCharacteristicValueIds).get();
                    characteristic.Options = [];
                    for (var j = 0; j < diff.length; j++) {
                        characteristic.Options.push({ 'Name': diff[j] });
                    }
                }
                return characteristic;
            };
            //Community Widget Methods

            $scope.showCommunityWidget = function (characteristic, $event) {
                if (($event.target.className == "list") && ($rootScope.rootScopeData.currentStage.isActive)) {
                    characteristic = $scope.filterSelectedValues(characteristic);
                    characteristic.CommunityWidget = true;
                    $scope.widgetLeft = $window.event.srcElement.getBoundingClientRect().left + $window.pageXOffset + $window.event.srcElement.scrollWidth - 18;
                    $scope.widgetTop = $window.event.srcElement.getBoundingClientRect().top + $window.pageYOffset - 187;
                }
                $event.stopPropagation();
            }; // Show Community widget
            $scope.deleteCommunityListItem = function (char, $event, characteristicDataSource) {
                characteristicDataSource.CommunityWidget = false;
                for (var i = 0; i < characteristicDataSource.SelectedCharacteristics.length; i++) {
                    var selected = characteristicDataSource.SelectedCharacteristics[i];
                    if (selected === char) {
                        characteristicDataSource.SelectedCharacteristics.splice(i, 1);
                        characteristicDataSource.ProductCharacteristicValueIds = characteristicDataSource.SelectedCharacteristics;
                        characteristicDataSource.Options.push({ 'Name': char });
                        break;
                    }
                }
                if (characteristicDataSource.SelectedCharacteristics.length > 0) {
                    $scope.showCommunityWidget(characteristicDataSource.SelectedCharacteristics, $event);
                }
                $event.stopPropagation();
            };// Remove selected listitem from inputbox
            $scope.multiOptionSetItemSelected = function (characteristicDataSource, characteristics) {
                characteristics.IsChanged = true;
                if (characteristicDataSource.SelectedCharacteristics == null) {
                    characteristicDataSource.SelectedCharacteristics = [];
                }
                for (var i = 0; i < characteristics.length; i += 1) {
                    characteristicDataSource.SelectedCharacteristics.push(characteristics[i]);
                }
                for (var i = 0; i < characteristicDataSource.Options.length; i += 1)
                    for (var j = 0; j < characteristics.length; j += 1) {
                        if (characteristicDataSource.Options[i].Name == characteristics[j]) {
                            characteristicDataSource.Options.splice(i, 1);
                        }
                    }
                characteristicDataSource.ProductCharacteristicValueIds = characteristicDataSource.SelectedCharacteristics;
            } // Remove selecteditem from list and store selectedproductcharacteristics
            $scope.hideCommunityWidget = function (characteristic) {
                characteristic.CommunityWidget = false;
            }; // Close community widget

            // End Community Widget Methods
            $scope.scopeData.getDeviceConfiguration();

            //Updated Code for the Prod Char Grid

            $scope.scopeData.OrderItems = {};

            //$scope.scopeData.getAvailableResources();

            $scope.FilterGridActual = function () {
                //Filter the grid here
                var filterObject = {};
                if ($scope.deviceSelected)
                    filterObject.DeviceName = $scope.deviceSelected.Value;
                if ($scope.colorSelected)
                    filterObject.Color = $scope.colorSelected.Value;
                if ($scope.storageSelected)
                    filterObject.Storage = $scope.storageSelected.Value;

                $scope.filteredListToUseInTemplate = $filter("filter")($scope.scopeData.DeviceConfiguration, filterObject)

                $scope.BindGrid($scope.filteredListToUseInTemplate);

            }

            //Filter grid based on vhar value selected from the dropdown
            $scope.FilterGrid = function () {
                $scope.BindGrid([]);

                $timeout($scope.FilterGridActual, 1);
            }

            //Define the Method for Getting the Order Basket
            $scope.scopeData.GetOrderBasket = function () {
                var deferred = $q.defer();

                var config = {
                    withCredentials: true
                };

                var orderItemGuid = window.parent.Xrm.Page.data.entity.getId();

                $scope.workflowStartInput = {
                    "orderGuid": orderItemGuid
                };

                $http.post(apiUrl + 'GetOrderBasket', JSON.stringify($scope.workflowStartInput), config)
                    .success(function (result) {
                        if (result) {

                            $scope.scopeData.OrderItems = result.Output.orderBasket.listOfOrderBasketOrderItems;
                            $scope.saveInput.data = $scope.scopeData.OrderItems;
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
            }

            $scope.scopeData.CheckItemThatRequiresConfiguration = function () {
                for (var i = 0; i < $scope.scopeData.OrderItems.length; i++) {
                    $scope.scopeData.OrderItems[i].level = $scope.scopeData.ReturnItemHierarchy($scope.scopeData.OrderItems[i]);
                }

                array.splice(i, 1);
            }

            $scope.scopeData.FindOrderItem = function (orderItemId) {
                for (var i = 0; i < $scope.scopeData.OrderItems.length; i++) {
                    if ($scope.scopeData.OrderItems[i].guid == orderItemId)
                        return $scope.scopeData.OrderItems[i];
                }
            }

            $scope.scopeData.AddConfigurationIcon = function () {
                baseUrl = Xrm.Page.context.getClientUrl()
                for (var i = 0; i < $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems.length; i++) {
                    if ($scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].Configurable)
                        $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].configuration_url_icon = baseUrl + "/Webresources/amx_/NewSubscription/controllers/PendingConfiguration.jpg";
                    else
                        $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].configuration_url_icon = baseUrl + "/Webresources/amx_/NewSubscription/controllers/NoConfiguration.jpg";
                }
            }

            $scope.scopeData.GenerateResourceCharStructForAll = function () {
                for (var i = 0; i < $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems.length; i++) {
                    // Find product offer related
                    $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].offeringFullDesc = $scope.scopeData.getOfferingFullDescForResourceChar($scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].name);
                    // Creating the resource char struct based on this offer full
                    $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].resourceSpecList =
                        $scope.scopeData.GenerateResourceSpecListForOffer($scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].offeringFullDesc);
                    $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].display = "none";
                    $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].cellBorder = "none";
                }
            }

            $scope.scopeData.getOfferingFullDescForResourceChar = function (name) {
                for (var i = 0; i < $scope.scopeData.configurableItemsModel.productOfferingFullList.length; i++) {
                    if ($scope.scopeData.configurableItemsModel.productOfferingFullList[i].OfferingName == name) {
                        return $scope.scopeData.configurableItemsModel.productOfferingFullList[i];
                    }
                }
            }

            $scope.scopeData.GenerateResourceSpecListForOffer = function (offerFull) {
                var productResourceSpecList = [];

                for (var j = 0; j < offerFull.ProductSpecification.ProductResourceSpecList.length; j++) {
                    // If max cardinality is 0, add to 1 as default
                    if (offerFull.ProductSpecification.ProductResourceSpecList[j].productResourceCardinality.amxperu_targetcardinalitymax === 0) {
                        offerFull.ProductSpecification.ProductResourceSpecList[j].productResourceCardinality.amxperu_targetcardinalitymax = 1;
                    }

                    // Loop if cardinality is > 0
                    if (offerFull.ProductSpecification.ProductResourceSpecList[j].productResourceCardinality.amxperu_targetcardinalitymax > 0) {
                        if (offerFull.ProductSpecification.ProductResourceSpecList[j].resourceCharList === undefined)
                            resourceCharList = [];
                        else return productResourceSpecList;

                        // Loop through max of cardinality

                        for (var i = 0; i < offerFull.ProductSpecification.ProductResourceSpecList[j].productResourceCardinality.amxperu_targetcardinalitymax; i++) {
                            for (var w = 0; w < offerFull.ProductSpecification.ProductResourceSpecList[j].ResourceCharValueList.length; w++) {
                                resourceCharList.push({
                                    "name": offerFull.ProductSpecification.ProductResourceSpecList[j].ResourceCharValueList[w].resourceCharacteristic.amxperu_name + " " + (i + 1),
                                    "etel_value": "",
                                    "etel_value_initial": "",
                                    "etel_selectedvalue": "",
                                    "nameId": offerFull.ProductSpecification.ProductResourceSpecList[j].ResourceCharValueList[w].resourceCharacteristic.amxperu_name + (i + 1),
                                    "resource": offerFull.ProductSpecification.ProductResourceSpecList[j].etel_productresourcespecificationid,
                                    "amx_resource_characteristic": offerFull.ProductSpecification.ProductResourceSpecList[j].ResourceCharValueList[w].resourceCharacteristic.amxperu_resourcecharacteristicid,
                                    "amx_resource_characteristicvalue": offerFull.ProductSpecification.ProductResourceSpecList[j].ResourceCharValueList[w].amxperu_resourcecharacteristicvalueid,
                                    "etel_orderresourceid": "",
                                    "etel_orderresourcecharactericid": "",
                                    "etel_datatypecode": offerFull.ProductSpecification.ProductResourceSpecList[j].ResourceCharValueList[w].resourceCharacteristic.amxperu_datatype
                                });
                            }
                        }
                    }
                    resourceCharList = $scope.scopeData.chunk(resourceCharList, 3);
                    productResourceSpecList.push({
                        "resourceCharList": resourceCharList,
                        "etel_orderresourceid": null,
                        "productSpec": offerFull.ProductSpecification.ProductResourceSpecList[j]
                    });
                }
                return productResourceSpecList;
            }

            $scope.scopeData.chunk = function (arr, numberOfColumns) {
                var newArr = [];
                for (var i = 0; i < arr.length; i += numberOfColumns) {
                    newArr.push(arr.slice(i, i + numberOfColumns));
                }
                return newArr;
            }

            $scope.scopeData.IsParent = function (item, parent) {
                if (item.ParentOrderItemId == parent.guid || item.ParentOrderItemId == "00000000- 0000 - 0000 - 0000 - 000000000000")
                { return true }
                else {
                    // Loop through list of items and the item parent if it is child of main item
                    for (var i = 0; i < $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems.length; i++) {
                        if ($scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].guid == item.ParentOrderItemId) {
                            return $scope.scopeData.IsParent($scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i], parent);
                        }
                    }
                }
                return false;
            }

            $scope.scopeData.GenerateChannelMatrix = function (item) {
                var channelMatrix = [];
                var pattern = new RegExp("\.*Canales.*"); // Pattern for channel
                // Loop through order items and get equipments
                for (var i = 0; i < $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems.length; i++) {
                    if (($scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems.OfferTypeCodeValue == "Plan" ||
                        pattern.test($scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].name)) &&
                        $scope.scopeData.IsParent($scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i], item)) {
                        channelMatrix.push(
                            {
                                "channel": $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i],
                                "selected": false
                            }
                        );
                    }
                }
                return channelMatrix;
            }

            $scope.scopeData.GenerateEquipmentChannelMatrix = function () {
                // Loop through order items and find TV services Basic PO
                for (var i = 0; i < $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems.length; i++) {
                    var pattern = new RegExp("\.*TV.*");
                    var channelMatrix = [];
                    var EquipmentChannelMatrix = [];
                    if (pattern.test($scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].name) && $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].ParentOrderItemId == "00000000-0000-0000-0000-000000000000") {
                        channelMatrix = $scope.scopeData.GenerateChannelMatrix($scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i]);
                        // Loop through equipments
                        for (var j = 0; j < $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems.length; j++) {
                            if ($scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[j].OfferTypeCodeValue == "Equipment" &&
                                $scope.scopeData.IsParent($scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[j], $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i])) {
                                EquipmentChannelMatrix.push({
                                    "equipment": $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[j],
                                    "description": "",
                                    "channels": channelMatrix,
                                    "selected": false
                                });
                            }
                        }
                        $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].equipmentChannelMatrix = EquipmentChannelMatrix;
                    }
                }
            }

            $scope.scopeData.changeDisplay = function (orderItem) {
                // Loop through order items and disable
                for (var i = 0; i < $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems.length; i++) {
                    if (orderItem.Configurable) {

                        if ($scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].guid == orderItem.guid) {
                            if (orderItem.display == "none") {
                                orderItem.display = "inline-block";
                                orderItem.cellBorder = "3px double #bccad6";
                            }
                            else {
                                orderItem.display = "none";
                                orderItem.cellBorder = "none";
                            }
                        } else {
                            // Only change if the item is configurable
                            $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].display = "none";
                            $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].cellBorder = "none";
                        };
                    }
                }
            }

            $scope.scopeData.reserveNumber = function (number, orderItemId, isPrimary) {
                var numberToBeReleased = isPrimary == true ? $scope.scopeData.selectedNumberPrimary : $scope.scopeData.selectedNumberSecondary;
                var numberToBeReserved = number.toString();

                var config = {
                    withCredentials: true
                };

                var req = {
                    "serviceType": "reserveNumbers",
                    "addressId": $rootScope.rootScopeData.customerInformation.SelectedAddress.AddressId,
                    "customerId": Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].id.replace("{", "").replace("}", ""),
                    "numberToBeReleased": numberToBeReleased,
                    "numberToBeReserved": numberToBeReserved,
                    "orderItemId": orderItemId
                };

                $http.post(apiUrl + 'FixedLineNumberService', JSON.stringify(req), config)
                    .success(function (result) {
                        if (result && result.Output.result == "OK") {
                            if (isPrimary == true) {
                                $scope.scopeData.selectedNumberPrimary = number;
                                $scope.scopeData.associateTelephoneNumber($scope.scopeData.selectedNumberPrimary);
                            }
                            else if (isPrimary == false) {
                                $scope.scopeData.selectedNumberSecondary = number;
                                $scope.scopeData.associateTelephoneNumber($scope.scopeData.selectedNumberSecondary);
                            }
                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                        $scope.httpLoading = false;
                    });
            }
            $scope.scopeData.changeConfiguration = function (configType, orderItemId) {
                $scope.orerItemId = orderItemId;

                if (configType == "primaryPhone" || configType == "secondaryPhone") {
                    $scope.scopeData.selectedConfiguration = configType;
                    if ($rootScope.rootScopeData.customerInformation.SelectedAddress.AddressId == null) {
                        alert("Please select an address.");
                        return;
                    }
                    var config = {
                        withCredentials: true
                    };

                    var req = {
                        "serviceType": "getNumbers",
                        "addressId": $rootScope.rootScopeData.customerInformation.SelectedAddress.AddressId,
                        "customerId": Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].id.replace("{", "").replace("}", ""),
                        "orderItemId": orderItemId
                    };
                    $http.post(apiUrl + 'FixedLineNumberService', JSON.stringify(req), config)
                        .success(function (result) {
                            if (result && result.Output.result == "OK") {
                                if (configType == "primaryPhone") {
                                    $scope.scopeData.isPrimaryNumberServiceCalled = true;
                                    $scope.scopeData.numberListPrimary = result.Output.numberList;
                                    $scope.scopeData.selectedNumberPrimary = $scope.scopeData.numberListPrimary[0];
                                    $scope.scopeData.associateTelephoneNumber($scope.scopeData.selectedNumberPrimary);
                                }
                                else if (configType == "secondaryPhone") {
                                    $scope.scopeData.isSecondaryNumberServiceCalled = true;
                                    $scope.scopeData.numberListSecondary = result.Output.numberList;
                                    $scope.scopeData.selectedNumberSecondary = $scope.scopeData.numberListSecondary[0];
                                    $scope.scopeData.associateTelephoneNumber($scope.scopeData.selectedNumberSecondary);
                                }

                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                            $scope.httpLoading = false;
                        });
                }
                else if (configType.Name != null) {
                    $scope.scopeData.selectedConfiguration = configType;
                    $scope.scopeData.selectedConfiguration.Id = configType.Id;
                    $scope.scopeData.selectedConfiguration.Name = configType.Name;
                    $scope.scopeData.reservePrepaidNumberFromBSCS();
                    //for (var i = 0; i < $scope.scopeData.prepaid.length; i++) {
                    //    if ($scope.scopeData.selectedConfiguration.Id == $scope.scopeData.prepaid[i].Id) {
                    //        $scope.scopeData.isPrepaidNumberServiceCalled = true;
                    //    }
                    //    else {
                    //        $scope.scopeData.isPrepaidNumberServiceCalled = false;
                    //    }
                    //}

                }
                else if (configType.OfferingName != null && configType.ProductOfferingId != null) {
                    $scope.fafnumbers = [];
                    $scope.scopeData.selectedConfiguration = configType;
                    $scope.scopeData.selectedConfiguration.OrderItemId = configType.OrderItemId;
                    $scope.scopeData.GetProductDefaultValue(configType.ProductOfferingId);
                    $scope.scopeData.FaFDefaultValue = [];
                    $scope.scopeData.FAFNumbers = "";
                    if ($scope.scopeData.Defaultvalue != null) {
                        //get the values from OrderproductCharacteristrics
                        $scope.scopeData.getOrderproductCharacteristricsValue($scope.orerItemId, $scope.ProductCharacteristicsId);
                        for (var i = 0; i < $scope.scopeData.Defaultvalue; i++) {
                            if ($scope.scopeData.FAFNumbers != null) {
                                $scope.fafnumbers = $scope.scopeData.FAFNumbers.split(",");
                                $scope.scopeData.FaFDefaultValue.push({ "Name": $scope.fafnumbers[i], "Id": i.toString() });
                            }
                            else {
                                $scope.scopeData.FaFDefaultValue.push({ "Name": "", "Id": i.toString() });
                            }

                        }
                        //for (var i = 0; i < $scope.scopeData.Defaultvalue; i++) {
                        //    $scope.scopeData.FaFDefaultValue.push({ "Name": "" });

                        //}              
                    }
                }
                else {
                    $scope.scopeData.selectedConfiguration = configType;
                }
            }

            $scope.scopeData.CreateUpdateResourceChar = function (orderItem) {
                var config = {
                    withCredentials: true
                };

                // Loop through resource specification
                for (var i = 0; i < orderItem.resourceSpecList.length; i++) {
                    // Build structure to save/update resource specification

                    var values = [];

                    var orderResourceCharInputList = {
                        "$type": "System.Collections.Generic.List`1[[AmxPeruPSBActivities.AMXCOLOMBIA.Model.AmxCoOrderResourceCharModelInput, AmxPeruPSBActivities]], mscorlib",
                        "$values": values
                    };
                    // Loop through order items characteristics
                    for (var j = 0; j < orderItem.resourceSpecList[i].resourceCharList.length; j++) {
                        for (var w = 0; w < orderItem.resourceSpecList[i].resourceCharList[j].length; w++) {
                            if (orderItem.resourceSpecList[i].resourceCharList[j][w].etel_value != "") {
                                values.push({
                                    "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.AmxCoOrderResourceCharModelInput, AmxPeruPSBActivities",
                                    "etel_orderresourcecharactericid": orderItem.resourceSpecList[i].resourceCharList[j][w].etel_orderresourcecharactericid,
                                    "etel_orderresourceid": orderItem.resourceSpecList[i].etel_orderresourceid,
                                    "amx_resource_characteristic": orderItem.resourceSpecList[i].resourceCharList[j][w].amx_resource_characteristic,
                                    "amx_resource_characteristicvalue": orderItem.resourceSpecList[i].resourceCharList[j][w].amx_resource_characteristicvalue,
                                    "etel_selectedvalue": orderItem.resourceSpecList[i].resourceCharList[j][w].etel_selectedvalue,
                                    "etel_datatypecode": orderItem.resourceSpecList[i].resourceCharList[j][w].etel_datatypecode == null ? null : orderItem.resourceSpecList[i].resourceCharList[j][w].etel_datatypecode.Value.toString(),
                                    "etel_value": orderItem.resourceSpecList[i].resourceCharList[j][w].etel_value,
                                    "etel_name": orderItem.resourceSpecList[i].productSpec.etel_name + orderItem.resourceSpecList[i].resourceCharList[j][w].name
                                });
                            }
                        }
                    }

                    var orderResourceInput = [];

                    orderResourceInput.push(
                        {
                            "$type": "System.Collections.Generic.List`1[[AmxCoPSBActivities.AMXCOLOMBIA.Model.AmxCoOrderResourceModelInput, AmxPeruPSBActivities]], mscorlib",
                            "$values": {
                                "$type": "AmxCoPSBActivities.AMXCOLOMBIA.Model.AmxCoOrderResourceModelInput, AmxPeruPSBActivities",
                                "etel_orderresourceid": orderItem.resourceSpecList[i].etel_orderresourceid,
                                "etel_orderitemid": orderItem.guid,
                                "etel_offeringid": orderItem.offeringFullDesc.ProductOfferingId,
                                "etel_name": orderItem.resourceSpecList[i].productSpec.etel_name,
                                "etel_productresourcespecification": orderItem.resourceSpecList[i].productSpec.etel_productresourcespecificationid,
                                "etel_value": orderItem.resourceSpecList[i].productSpec.etel_name,
                                "orderResourceCharInputList": orderResourceCharInputList
                            }
                        });
                }

                $scope.workflowStartInput = {
                    "$type": "System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib",
                    "inputModel": {
                        "$type": "AmxCoPSBActivities.AMXCOLOMBIA.Model.AmxCoCreateUpdateResourceCharInput, AmxPeruPSBActivities",
                        "orderResourceInputList": orderResourceInput
                    }
                };

                $http.post(apiUrl + 'AmxCoCreteUpdateResourceChar', JSON.stringify($scope.workflowStartInput), config)
                    .success(function (result) {
                        if (result) {
                            $scope.scopeData.UpdateResourceCharWithGuids(result.Output.outputModel, orderItem);
                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                        $scope.httpLoading = false;
                    }).finally(function () {

                    });
            }

            $scope.scopeData.checkedItems = function (char) {
                $scope.saveInput.data.cfssCharacteristicList = angular.toJson($scope.scopeData.cfssCharacteristicList);
                $scope.resumeInput.data.cfssCharacteristicList = {
                    "$type": "System.Collections.Generic.List`1[[AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList, AmxPeruPSBActivities]], mscorlib",
                    "$values": $scope.saveInput.data.cfssCharacteristicList
                };
            }

            $scope.scopeData.UpdateResourceCharWithGuids = function (outputModel, orderItem) {
                // Find order item index in scope
                var orderItemIndex = 0;
                for (var i = 0; i < $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems.length; i++) {
                    if (orderItem.guid == $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i].guid) {
                        orderItemIndex = i;
                        break;
                    }
                }

                // Loop through output
                for (var i = 0; i < outputModel.orderResourceInputList.length; i++) {
                    $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[orderItemIndex].productResourceSpecList[i].etel_orderresourceid = outputModel.orderResourceInputList[i].etel_orderresourceid;

                    var resourceCharIndex = 0;
                    var resourceCharMax = $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[orderItemIndex].productResourceSpecList[i].resourceCharList[0].length;

                    var resourceCharRowIndex = 0;
                    var resourceCharRowMax = $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[orderItemIndex].productResourceSpecList[i].resourceCharList.length;

                    for (var j = 0; j < outputModel.orderResourceInputList[i].orderResourceCharInputList.length; j++) {
                        if (resourceCharRowIndex < resourceCharRowMax) {
                            if (resourceCharIndex < resourceCharMax) {
                                $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[orderItemIndex].productResourceSpecList[i].resourceCharList[resourceCharRowIndex][resourceCharIndex] = outputModel.orderResourceInputList[i].orderResourceCharInputList[j].etel_orderresourcecharactericid;
                                $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[orderItemIndex].productResourceSpecList[i].resourceCharList[resourceCharRowIndex][resourceCharIndex] = outputModel.orderResourceInputList[i].etel_orderresourceid;
                                resourceCharIndex++;
                            } else {
                                resourceCharRowIndex++;
                                resourceCharMax = $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[orderItemIndex].productResourceSpecList[i].resourceCharList[resourceCharRowIndex].length;
                            }
                        }
                        else break;
                    }
                }
            }
            $scope.scopeData.reservePrepaidNumberFromBSCS = function () {
                var config = {
                    withCredentials: true
                };
                var req = {
                    "$type": "System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib",
                    "directoryNumberRequest":
                    {
                        "$type": "AmxSoapServicesActivities.Model.GenericDirectoryNumberServiceRequest, AmxSoapServicesActivities",
                        "npcode": "1",
                        "plcode": "1001",
                        "submId": "1",
                        "hlcode": "1",
                        "hmcode": "1",
                        "dnCode": "3",
                        "dnStatus": "r",
                        "searchCount": "1",
                        "reservation": true
                    }
                };
                $http.post(apiUrl + 'RetrieveGenericDirectoryNumber', JSON.stringify(req), config)
                    .success(function (result) {
                        if (result.Output.response != null) {
                            for (var i = 0; i < $scope.scopeData.prepaid.length; i++) {
                                if ($scope.scopeData.selectedConfiguration.Id == $scope.scopeData.prepaid[i].Id) {
                                    $scope.scopeData.isPrepaidNumberServiceCalled = true;
                                }
                                else {
                                    $scope.scopeData.isPrepaidNumberServiceCalled = false;
                                }
                            }
                            $scope.prepaidNumber = result.Output.response;
                            $scope.sdpId = result.Output.sdpId;
                            $scope.ReservePrepaidNumber($scope.prepaidNumber, $scope.sdpId);
                            $scope.scopeData.associateMobilePhoneNumber($scope.prepaidNumber);
                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                        $scope.httpLoading = false;
                    });

            }
            //function to restore prepaid number in Order Resourse 
            $scope.ReservePrepaidNumber = function (prepaidNumber, sdpId) {
                var entity = {};
                entity.etel_name = "LRS Movil Numero";
                entity.etel_value = prepaidNumber;
                entity["etel_orderitemid@odata.bind"] = "/etel_orderitems(" + $scope.orerItemId + ")";
                entity["etel_productresourcespecification@odata.bind"] = "/etel_productresourcespecifications(" + "046B603D-9121-E811-80ED-FA163E10DFBE" + ")";
                var req = new XMLHttpRequest();
                req.open("POST", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_orderresources", false);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 204) {
                            var uri = this.getResponseHeader("OData-EntityId");
                            var regExp = /\(([^)]+)\)/;
                            var matches = regExp.exec(uri);
                            var newEntityId = matches[1];
                            //alert("Prepaid Number Reserved Successfully");
                            // Create resource characteristic based on number
                            var entity2 = {};
                            entity2.etel_name = "Resource Number";
                            entity2.etel_value = prepaidNumber;
                            entity2["etel_orderresourceid@odata.bind"] = "/etel_orderresources(" + newEntityId + ")";
                            entity2["amx_resource_characteristic@odata.bind"] = "/amxperu_resourcecharacteristics(" + "0BB22CCC-50DF-E711-80E7-FA163E10DFBE" + ")";
                            var req2 = new XMLHttpRequest();
                            req2.open("POST", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_orderresourcecharacterics", false);
                            req2.setRequestHeader("OData-MaxVersion", "4.0");
                            req2.setRequestHeader("OData-Version", "4.0");
                            req2.setRequestHeader("Accept", "application/json");
                            req2.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                            req2.onreadystatechange = function () {
                                if (this.readyState === 4) {
                                    req2.onreadystatechange = null;
                                    if (this.status === 204) {
                                        var uri = this.getResponseHeader("OData-entity2Id");
                                        var regExp = /\(([^)]+)\)/;
                                        var matches2 = regExp.exec(uri);
                                        var newentity2Id = matches2[1];
                                    } else {
                                        Xrm.Utility.alertDialog(this.statusText);
                                    }
                                }
                            };
                            req2.send(JSON.stringify(entity2));
                            // Finish creating rource based on number

                            // Create resource characteristic based on sdpid
                            var entity3 = {};
                            entity3.etel_name = "SDP_ID";
                            entity3.etel_value = sdpId;
                            entity3["etel_orderresourceid@odata.bind"] = "/etel_orderresources(" + newEntityId + ")";
                            entity3["amx_resource_characteristic@odata.bind"] = "/amxperu_resourcecharacteristics(" + "A7AC301D-61DF-E711-80E7-FA163E10DFBE" + ")";
                            var req3 = new XMLHttpRequest();
                            req3.open("POST", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_orderresourcecharacterics", false);
                            req3.setRequestHeader("OData-MaxVersion", "4.0");
                            req3.setRequestHeader("OData-Version", "4.0");
                            req3.setRequestHeader("Accept", "application/json");
                            req3.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                            req3.onreadystatechange = function () {
                                if (this.readyState === 4) {
                                    req3.onreadystatechange = null;
                                    if (this.status === 204) {
                                        var uri = this.getResponseHeader("OData-entity2Id");
                                        var regExp = /\(([^)]+)\)/;
                                        var matches3 = regExp.exec(uri);
                                        var newentity2Id = matches3[1];
                                    } else {
                                        Xrm.Utility.alertDialog(this.statusText);
                                    }
                                }
                            };
                            req3.send(JSON.stringify(entity3));
                            // Finish creating rource based on sdpid
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send(JSON.stringify(entity));
            }
            $scope.scopeData.GetProductDefaultValue = function (ProductOfferingId) {
                var fetchXml = ['<fetch version="1.0" output-format="xml-platform" mapping="logical" distinct="false">'
                    + '<entity name="amxperu_productofferingcharuse">'
                    + '<attribute name="amxperu_productofferingcharuseid"/>'
                    + '<attribute name="amxperu_name"/>'
                    + '<attribute name="createdon"/>'
                    + '<attribute name="amxperu_defaultvalue" />'
                    + '<attribute name="amxperu_characteristic" />'
                    + '<order attribute="amxperu_name" descending="false"/>'
                    + '<link-entity name="product" from="productid" to="amxperu_productoffering" alias="ad">'
                    + '<filter type="and">'
                    + '<condition attribute="productid" operator="eq" uitype="product" value="' + ProductOfferingId + '"/>'
                    + '</filter>'
                    + '</link-entity>'
                    + '</entity>'
                    + '</fetch>'].join('');
                var encodedFetchXML = encodeURIComponent(fetchXml);
                var req = new XMLHttpRequest();
                req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/amxperu_productofferingcharuses?fetchXml=" + encodedFetchXML, false);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.setRequestHeader("Prefer", "odata.include-annotations=\"OData.Community.Display.V1.FormattedValue\"");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 200) {
                            var results = JSON.parse(this.response);
                            for (var i = 0; i < results.value.length; i++) {
                                if (results.value[i]["amxperu_name"] == "Cantidad Elegido") {
                                    $scope.scopeData.Defaultvalue = results.value[i]["amxperu_defaultvalue"];

                                }
                                if (results.value[i]["amxperu_name"] == "Lista Elegido") {
                                    $scope.ProductCharacteristicsId = results.value[i]["_amxperu_characteristic_value"];

                                }
                            }
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send();

            }
            $scope.SetFaFDefaultValue = function () {
                $scope.finalfaFValue = [];
                for (var i = 0; i < $scope.scopeData.FaFDefaultValue.length; i++) {
                    var value = "";
                    if ($scope.scopeData.FaFDefaultValue.length == 1) {
                        value = $scope.scopeData.FaFDefaultValue[i].Name;
                        $scope.finalfaFValue.push(value);
                    }
                    else {
                        if ($scope.scopeData.FaFDefaultValue[i].Name != undefined) {
                            value = $scope.scopeData.FaFDefaultValue[i].Name;
                            $scope.finalfaFValue.push(value);
                        }

                    }

                }
            };

            //function to store prepaid number details in etel_orderproductcharacteristics
            $scope.scopeData.createOrderProductCharacteristics = function (faFValue) {
                var entity = {};
                entity["etel_characteristicid@odata.bind"] = "/etel_productcharacteristics(" + $scope.ProductCharacteristicsId + ")";
                entity["etel_orderitemid@odata.bind"] = "/etel_orderitems(" + $scope.orerItemId + ")";
                entity.etel_value = $scope.finalfaFValue.toString();

                var req = new XMLHttpRequest();
                req.open("POST", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_orderproductcharacteristics", false);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 204) {
                            var uri = this.getResponseHeader("OData-EntityId");
                            var regExp = /\(([^)]+)\)/;
                            var matches = regExp.exec(uri);
                            var newEntityId = matches[1];
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send(JSON.stringify(entity));
            }
            //function to get the number details from etel_orderproductcharacteristics
            $scope.scopeData.getOrderproductCharacteristricsValue = function (orerItemId, ProductCharacteristicsId) {
                //$scope.scopeData.FAFNumbers = [];

                var req = new XMLHttpRequest();
                req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_orderproductcharacteristics?$select=etel_value,etel_orderproductcharacteristicid&$filter=_etel_characteristicid_value eq " + ProductCharacteristicsId + "  and  _etel_orderitemid_value eq " + orerItemId + "", false);
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
                            for (var i = 0; i < results.value.length; i++) {
                                $scope.scopeData.FAFNumbers = results.value[i]["etel_value"];
                                $scope.scopeData.etel_orderproductcharacteristicid = results.value[i]["etel_orderproductcharacteristicid"];
                            }
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send();
            }
            $scope.scopeData.checkMobileNumberExists = function (FAFNumber) {
                $scope.SetFaFDefaultValue();

                if ($scope.scopeData.FAFNumbers == null || $scope.scopeData.FAFNumbers == undefined || $scope.scopeData.FAFNumbers == "") {
                    //function to create OrderProductCharacteristics
                    $scope.scopeData.createOrderProductCharacteristics($scope.Number);
                }
                else {
                    $scope.etel_value = $scope.scopeData.FAFNumbers;
                    //function to update OrderProductCharacteristics
                    $scope.scopeData.updateOrderProductCharacteristics($scope.Number);
                }

            }
            //function to update etel_value with comma seperated
            $scope.scopeData.updateOrderProductCharacteristics = function (FAFvalue) {
                var entity = {};
                entity.etel_value = $scope.finalfaFValue.toString();

                var req = new XMLHttpRequest();
                req.open("PATCH", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_orderproductcharacteristics(" + $scope.scopeData.etel_orderproductcharacteristicid + ")", false);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 204) {
                            //Success - No Return Data - Do Something
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send(JSON.stringify(entity));
            }
            $scope.scopeData.orderProductCharacteristicsUpdate = function (FAFvalue) {
                var entity = {};
                entity.etel_value = FAFvalue;

                var req = new XMLHttpRequest();
                req.open("PATCH", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_orderproductcharacteristics(" + $scope.scopeData.etel_orderproductcharacteristicid + ")", false);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 204) {
                            //Success - No Return Data - Do Something
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send(JSON.stringify(entity));
            }
            $scope.scopeData.contractsSearchByDirnum = function (faFValue, id, index) {
                $scope.Number = faFValue;//angular.element('#txtprepaidno').val();
                if (faFValue != "") {
                    if (faFValue != undefined) {
                        $scope.scopeData.FAFNumbers = "";
                        $scope.scopeData.getOrderproductCharacteristricsValue($scope.orerItemId, $scope.ProductCharacteristicsId);
                        if ($scope.scopeData.FAFNumbers != null) {
                            $scope.FAFnumbers = $scope.scopeData.FAFNumbers.split(",");
                            if ($scope.FAFnumbers.indexOf(faFValue) > -1) {
                                alert("The mobile number is already Exists.");
                            }
                            else {
                                $scope.scopeData.contractsSearch();
                            }
                        }
                        else {
                            $scope.scopeData.contractsSearch();
                        }
                    }
                    else {
                        alert("Please Enter mobile number");
                    }
                }
                else {
                    alert("Please Enter mobile number");
                }
            }

            $scope.scopeData.contractsSearch = function () {
                var config = { withCredentials: true };
                $scope.workflowStartInput = {

                    "dirNum": $scope.Number
                };
                $http.post(apiUrl + 'ContractsSearchByDirnum', JSON.stringify($scope.workflowStartInput), config)
                    .success(function (result) {
                        if (result.Output.response.length != 0) {
                            for (var i = 0; i < result.Output.response.length; i++) {
                                $scope.CoStatus = result.Output.response[i].coStatus;
                                if ($scope.CoStatus == 1 || $scope.CoStatus == 2) {
                                    $scope.scopeData.checkMobileNumberExists($scope.Number);
                                    alert("The entered mobile number is valid");
                                }
                                else {
                                    alert("The entered mobile number is not valid");
                                }
                            }

                        }
                        else {
                            alert("The number is not active at Claro");
                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                    });
            }
            $scope.scopeData.associateMobilePhoneNumber = function (Mobilephone) {
                var customerId = Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].id.replace("{", "").replace("}", "");
                var entity = {};
                entity.mobilephone = Mobilephone;

                var req = new XMLHttpRequest();
                req.open("PATCH", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/contacts(" + customerId + ")", false);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 204) {
                            //Success - No Return Data - Do Something
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send(JSON.stringify(entity));
            }
            $scope.scopeData.associateTelephoneNumber = function (Telephone) {
                var customerId = Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].id.replace("{", "").replace("}", "");
                var entity = {};
                entity.telephone1 = Telephone;
                //entity.telephone2 = "";

                var req = new XMLHttpRequest();
                req.open("PATCH", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/contacts(" + customerId + ")", false);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 204) {
                            //Success - No Return Data - Do Something
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send(JSON.stringify(entity));
            }
            var initiate = function () {
                $scope.scopeData.selectedFaFValue = "";
                $scope.scopeData.translations = Wizard.GetTranslationData("AmxPeruNewSubscription");
                $scope.scopeData.configuration.fillDevicesAndDeliveryOptions();
                $scope.scopeData.configurableItemsModel = $scope.workflowContext.ResponseData.Output.orderItemBasket;
                $scope.scopeData.cfssCharacteristicList = $scope.saveInput.data.cfssCharacteristicList != null ? angular.fromJson($scope.saveInput.data.cfssCharacteristicList) : $scope.workflowContext.ResponseData.Output.cfssCharacteristicList;
                $scope.scopeData.currentOfferFull = $scope.scopeData.configurableItemsModel.productOfferingFullList[1];
                $scope.scopeData.AddConfigurationIcon();
                $scope.workflowContext.ResponseData.Output.orderItemBasket = [];
                $scope.scopeData.GenerateResourceCharStructForAll();
                $scope.scopeData.GenerateEquipmentChannelMatrix();

                $scope.orderItemGuid = window.parent.Xrm.Page.data.entity.getId();
                //for (var i = 0; i < $scope.scopeData.configurableItemsModel.productOfferingFullList.length; i++) {
                //    var s = $scope.scopeData.configurableItemsModel.productOfferingFullList[i];
                //    //if (s.OfferingName == "Servicio Movil Prepago")
                //    //{
                //    //    $scope.scopeData.reservePrepaidNumberFromBSCS();
                //    //}
                //    if (s.OfferingName.substring(0, 3) == "FaF") {

                //        $scope.scopeData.prepaidfafplans.push(s);
                //    }

                //}
                $scope.scopeData.prepaidfafplans = [];
                $scope.scopeData.prepaid = [];
                $scope.scopeData.GetPlanOfBasicOffer = function (BasicofferId) {
                    var req = new XMLHttpRequest();
                    req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_orderitems?$select=amx_offertypecode,etel_orderitemid&$filter=_etel_parentorderitemid_value eq " + BasicofferId + "", false);
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
                                for (var i = 0; i < results.value.length; i++) {
                                    var amx_offertypecode = results.value[i]["amx_offertypecode"];
                                    var amx_offertypecode_formatted = results.value[i]["amx_offertypecode@OData.Community.Display.V1.FormattedValue"];
                                    var etel_orderitemid = results.value[i]["etel_orderitemid"];
                                    if (amx_offertypecode_formatted == "Plan") {
                                        $scope.scopeData.GetFAFofSelectedPlan(etel_orderitemid)
                                    }
                                }
                            } else {
                                Xrm.Utility.alertDialog(this.statusText);
                            }
                        }
                    };
                    req.send();
                }
                $scope.scopeData.GetFAFofSelectedPlan = function (PlanId) {

                    var req = new XMLHttpRequest();
                    req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_orderitems?$select=amx_offertypecode,_etel_offeringid_value,etel_orderitemid&$filter=_etel_parentorderitemid_value eq " + PlanId + "", false);
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
                                for (var i = 0; i < results.value.length; i++) {
                                    $scope.amx_offertypecode = results.value[i]["amx_offertypecode"];
                                    $scope.amx_offertypecode_formatted = results.value[i]["amx_offertypecode@OData.Community.Display.V1.FormattedValue"];
                                    $scope._etel_offeringid_value = results.value[i]["_etel_offeringid_value"];
                                    $scope._etel_offeringid_value_formatted = results.value[i]["_etel_offeringid_value@OData.Community.Display.V1.FormattedValue"];
                                    $scope._etel_offeringid_value_lookuplogicalname = results.value[i]["_etel_offeringid_value@Microsoft.Dynamics.CRM.lookuplogicalname"];
                                    $scope.etel_orderitemid = results.value[i]["etel_orderitemid"];
                                    if ($scope.amx_offertypecode_formatted == "Optional Service" && $scope._etel_offeringid_value_formatted.substring(0, 3) == "FaF") {
                                        $scope.scopeData.prepaidfafplans.push({ "OfferingName": $scope._etel_offeringid_value_formatted, "OrderItemId": $scope.etel_orderitemid, "ProductOfferingId": $scope._etel_offeringid_value, "RootOrderItemId": $scope.RootOrderItemId });
                                    }
                                }
                            } else {
                                Xrm.Utility.alertDialog(this.statusText);
                            }
                        }
                    };
                    req.send();
                }
                for (var i = 0; i < $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems.length; i++) {
                    var s = $scope.scopeData.configurableItemsModel.orderItemsBasket.listOfOrderBasketOrderItems[i];
                    if (s.name == "Servicio Movil Prepago" && s.OfferTypeCodeValue == "Basic Offer") {

                        var BasicOfferId = s.guid;
                        $scope.RootOrderItemId = BasicOfferId;
                        $scope.scopeData.prepaid.push({ "Name": "Configuración de Número", "Id": i, "RootOrderItemId": $scope.RootOrderItemId });
                        $scope.scopeData.GetPlanOfBasicOffer(BasicOfferId);
                    }
                }


            }

            initiate();
        }])
