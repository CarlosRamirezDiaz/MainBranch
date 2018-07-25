wizard.controller("selectProductController", ['$scope', '$http', '$rootScope', 'uiGridConstants',
    function ($scope, $http, $rootScope, uiGridConstants, uiGridGroupingConstants) {
        var apiUrl = Wizard.Util.configStore.PsbRestServiceUrl;
        $scope.direct = $rootScope.direct; // setting direction for RTL language
        if ($scope.direct === "rtl") {
            $scope.isRTL = true;
        }
        else {
            $scope.isRTL = false;
        }

        var GuidEmpty = "00000000-0000-0000-0000-000000000000";

        // eheldma: Request to Bureau already performed?
        bureauOK = false;
        var popupWindow = null;


        //$rootScope.currentProcess = window.definitions.processes.newSubscription;
        $rootScope.displayColumnNewValue = false;
        $rootScope.displayColumnOption = false;
        if (typeof $scope.scopeData === "undefined") {
            $scope.scopeData = {};
        }
        if (typeof $rootScope.rootScopeData.order === "undefined") {
            $rootScope.rootScopeData.order = {};
        }

        //define array for addOn Objects
        $scope.addOns = {};
        // Subscription maximmum limit
        var UpperLimitSubscription = 10;
        $scope.scopeData.selectOffering = {};
        $scope.scopeData.OrderBasketItems = [];
        $scope.scopeData.AvailableOffers = [];
        $scope.scopeData.AvailableAddons = [];
        $scope.scopeData.AvailableDevices = [];
        $scope.scopeData.AvailableErmsStocks = [];
        $scope.scopeData.OrderItems = [];
        $scope.scopeData.AvailableStocks = [];

        $scope.gridOptions = {};
        $scope.gridOptions.selectedItems = [];

        $scope.productOptionalsGrid = {};
        $scope.productOptionalsGrid.selectedItems = [];

        $scope.productDevicesGrid = {};
        $scope.productDevicesGrid.selectedItems = [];

        $scope.availableStocksGrid = {};
        $scope.availableStocksGrid.selectedItems = [];

        //Portability Validations
        $scope.scopeData.NoOfBasicPOAsPerMSISDN = 0;
        $scope.scopeData.BasicPoCountForPortItems = $rootScope.rootScopeData.ListPortableMSISDN.length;
        $scope.scopeData.listOfPortableMSISDNs = $rootScope.rootScopeData.ListPortableMSISDN;
        $scope.scopeData.CustomerSelectedAddress = $rootScope.rootScopeData.customerInformation.SelectedAddress;

        $scope.scopeData.searchOffers = function () {
            var config = {
                withCredentials: true
            };

            var offerName, offerId;
            if ($scope.scopeData.SearchOffer != undefined) {
                offerName = ($scope.scopeData.SearchOffer.OfferName != undefined) ? $scope.scopeData.SearchOffer.OfferName : "";
                offerId = ($scope.scopeData.SearchOffer.OfferID != undefined) ? $scope.scopeData.SearchOffer.OfferID : "";
            }

            $scope.workflowStartInput = {
                "input": {
                    "$type": "AmxPeruPSBActivities.Model.OrderCapture.OfferingRequestModel, AmxPeruPSBActivities",
                    "OfferName": offerName,
                    "OfferId": offerId,
                    "Campaign": "",
                    "Family": "",
                    "Location": "",
                    "OfferingTypeCode": "Basic",
                    "SpecialCase": ""
                }
            };

            $http.post(apiUrl + 'GetOfferings', JSON.stringify($scope.workflowStartInput), config)
                .success(function (result) {
                    if (result) {
                        $scope.scopeData.AvailableOffers = result.Output.output.ListOfOfferings;
                        for (var i = 0; i < $scope.scopeData.AvailableOffers.length; i++) {
                            $scope.scopeData.AvailableOffers[i].IsBasicPO = true;
                        }

                        $scope.gridOptions.data = null;
                        $scope.BindGridNew($scope.scopeData.AvailableOffers);
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

        $scope.scopeData.searchAssociatedOffers = function (offer) {
            if (offer == null) {
                $scope.scopeData.AvailableDevices = [];
                $scope.scopeData.AvailableAddons = [];
                $scope.BindProductOptionalsGrid($scope.scopeData.AvailableAddons);
                $scope.BindProductDevicesGrid($scope.scopeData.AvailableDevices);
                return;
            }

            var config = {
                withCredentials: true
            };

            $scope.workflowStartInput = {
                //"parentOfferingId": "481e958e-867e-e711-8126-00505601173a"
                "parentOfferingId": offer.entity.OfferingId
            };

            $scope.BindProductOptionalsGrid([]);
            $scope.BindProductDevicesGrid([]);
            $http.post(apiUrl + 'GetAssociatedProductOfferings', JSON.stringify($scope.workflowStartInput), config)
                .success(function (result) {

                    if (result) {
                        $scope.scopeData.AvailableAddons = result.Output.associatedProductOfferingAddons;
                        $scope.BindProductOptionalsGrid($scope.scopeData.AvailableAddons);

                        $scope.scopeData.AvailableDevices = result.Output.associatedProductOfferingDevices;
                        $scope.BindProductDevicesGrid($scope.scopeData.AvailableDevices);
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

        function FilterFamily(catalog) {
            return catalog.CatalogueType == '2';
        }

        $scope.scopeData.clearOffers = function () {
            $scope.scopeData.AvailableOffers = [];
        };
        $scope.scopeData.onSelectOffer = function (offer) {
            angular.forEach($scope.scopeData.AvailableOffers, function (currentOffer) {
                if (currentOffer !== offer) {
                    currentOffer.IsSelected = false;
                    currentOffer.IsExpanded = false;
                }
            });

            offer.IsSelected = !offer.IsSelected;

            $scope.scopeData.searchAssociatedOffers();
        };
        $scope.scopeData.onSelectDevice = function (device) {
            angular.forEach($scope.scopeData.AvailableDevices, function (currentDevice) {
                if (currentDevice !== device) {
                    currentDevice.IsSelected = false;
                    currentDevice.IsExpanded = false;
                }
                else {
                    currentDevice.IsSelected = true;
                    currentDevice.IsExpanded = false;
                }
            });
        };
        $scope.scopeData.checkStockInOtherInventory = function () {
            $scope.scopeData.AvailableErmsStocks = [
                { "storeName": "Store 1", "stockCount": "5", "stockAvailability": "Yes" },
                { "storeName": "Store 2", "stockCount": "0", "stockAvailability": "No" },
                { "storeName": "Store 3", "stockCount": "14", "stockAvailability": "Yes" },
                { "storeName": "Store 3", "stockCount": "6", "stockAvailability": "Yes" }
            ];
        };
        $scope.scopeData.AddDeviceToShoppingCart = function () {
            for (var i = 0; i < $scope.scopeData.AvailableDevices.length; i++) {
                if ($scope.scopeData.AvailableDevices[i].IsSelected) {
                    var parentOfferId = $scope.scopeData.AvailableDevices[i].parentOfferId;
                    for (var i = 0; i < $scope.scopeData.OrderItems.length; i++) {
                        if ($scope.scopeData.OrderItems[i].OfferId == parentOfferId) {
                            $scope.scopeData.OrderItems[i].SubItems.push($scope.scopeData.AvailableDevices[i]);
                        }
                    }
                }
            }
            $rootScope.rootScopeData.customerInformation.ProductSelected = $scope.scopeData.planning.translations.tYes;
        };

        $scope.scopeData.AddBasicOfferToShoppingCart = function () {
            var offeringId = $scope.gridOptions.selectedItems[0][0].OfferingId;
            $scope.scopeData.AddOfferToShoppingCart(offeringId, GuidEmpty);
            $scope.scopeData.AddOrders();
            $scope.scopeData.RunBureauCreditAnalysis();
        };
        $scope.scopeData.AddOrders = function () {
            Xrm.Utility.confirmDialog("Would you like to create a new quote", null, null);
        }

        $scope.scopeData.RunBureauCreditAnalysis = function () {
            // eheldma: Run Bureau credit analysis
            if (!confirm('Execute credit analysis and authentication?'))
                return;

            if (bureauOK) {
                alert("Credit analysis already performed");
                return;
            }

            // Perform Bureau de Credito credit analysis
            var lookupObj = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
            if (lookupObj) {
                var customerID = lookupObj[0].id;
            }

            // Run Bureau de Credito
            $scope.scopeData.CreditBureauCheck(customerID);

            // Run Internal Lists
            $scope.scopeData.InternalListsCheck(customerID);

            // Run Sarglaft analysis
            $scope.scopeData.SarglaftCheck(lookupObj[0].name)

            // Run Evidente Authenthication
            $scope.scopeData.EvidenteCheck(customerID);
        };

        $scope.scopeData.CreditBureauCheck = function (cId) {

            try {

                var config = {
                    withCredentials: true
                };

                $scope.workflowBureauInput = {
                    "individualCustomerId": cId
                    //"bureauURL": "http://172.24.42.211:8002/Bureau/V1.0/Rest/GetBureau"
                };

                $http.post(apiUrl + 'AmxCoBureau', JSON.stringify($scope.workflowBureauInput), config)
                    .success(function (result) {
                        if (result) {

                            var bureauresponse = result.Output.response;
                            bureauOK = true;

                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                        $scope.httpLoading = false;
                    });
            }
            catch (err) {
                alert("CreditBureauCheck: " + err.message);
            }
        };

        $scope.scopeData.InternalListsCheck = function (cId) {

            try {

                var config = {
                    withCredentials: true
                };

                $scope.workflowGetInternalListsInput = {
                    "individualCustomerId": cId,
                };

                $http.post(apiUrl + 'AmxCoGetInfoLists', JSON.stringify($scope.workflowGetInternalListsInput), config)
                    .success(function (result) {
                        if (result) {

                            var listresponse = result.Output.response;
                            if (listresponse != 0) {
                                var listaclientes = listaresponse - 4;
                                if (listaclientes >= 0) {
                                    window.alert("Cliente está an lista correos");
                                    var listatelefonos = listaclientes - 2;
                                    if (listatelefonos >= 0) {
                                        window.alert("Cliente está en lista telefonos");
                                        var listaclientes = listatelefonos - 1;
                                        if (listaclientes >= 0) {
                                            window.alert("Cliente está en lista clientes");
                                        }
                                    }
                                } else {
                                    var listatelefonos = listaresponse - 2;
                                    if (listatelefonos >= 0) {
                                        window.alert("Cliente está an lista teléfonos");
                                        var listaclientes = listatelefonos - 1;
                                        if (listaclientes >= 0) {
                                            window.alert("Cliente está en lista clientes");
                                        }
                                    } else {
                                        var listaclientes = listaresponse - 1;
                                        if (listaclientes >= 0) {
                                            window.alert("Cliente está an lista clientes");
                                        }
                                    }
                                }
                            }
                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                        $scope.httpLoading = false;
                    });
            }
            catch (err) {
                alert("InternalListsCheck: " + err.message);
            }
        };
        
        $scope.scopeData.InternalListsUpdate = function (cId) {

            try {

                var config = {
                    withCredentials: true
                };

                var orderItemGuid = window.parent.Xrm.Page.data.entity.getId();

                $scope.workflowInternalListsInput = {
                    "individualCustomerId": cId,
                    "orderId": orderItemGuid,
                    "idReason": "22"
                };

                $http.post(apiUrl + 'AmxCoUpdateList', JSON.stringify($scope.workflowInternalListsInput), config)
                    .success(function (result) {
                        if (result) {

                            //var bureauresponse = result.Output.response;
                            //bureauOK = true;

                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                        $scope.httpLoading = false;
                    });
            }
            catch (err) {
                alert("InternalListsCheck: " + err.message);
            }
        };

        $scope.scopeData.SarglaftCheck = function () {

            try {
                var individualCustomer = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();

                var WorkflowUrlName = Xrm.Page.context.getClientUrlForInteractioncentricDashboard() + ":6004/api/v1/workflow/AmxCoSarglaftConsultLists";

                var request = {
                    "FullName": individualCustomer[0].name
                };

                var config = {
                    withCredentials: true
                };

                $http.post(WorkflowUrlName, JSON.stringify(request), config)
                    .success(function (result) {
                        if (result) {
                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ? (data.data === undefined ? data :
                            (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                        $scope.httpLoading = false;
                    });
            }
            catch (err) {
                alert("Sarglaft analysis: " + err.message);
            }
        };

        $scope.scopeData.EvidenteCheck = function (individualCustomerId) {

            try {
                var evidenteURL = Xrm.Page.context.getClientUrl() + "/WebResources/amx_/Evidente/amxco_EvidenteQuestionnaire.htm?data=individualCustomerId%3d" + individualCustomerId;

                if (navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0) {
                    /* Microsoft Internet Explorer detected in. */

                    var sFeatures = "dialogHeight: 580px;dialogWidth: 840px"

                    window.showModalDialog(evidenteURL, "", sFeatures);
                }
                else {
                    var w = 840;
                    var h = 580;
                    var left = (screen.width / 2) - (w / 2);
                    var top = (screen.height / 2) - (h / 2);
                    popupWindow = window.open(evidenteURL, "Autenticación cliente", "directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=" + w + ", height=" + h + ", top=" + top + ", left=" + left);
                }
            }
            catch (err) {
                alert("Evidente Authenthication: " + err.message);
            }
        };

        $scope.GetOrderItemIdOfSelectedBasicOfferingFromBasket = function () {
            var parentOfferingId = $scope.gridOptions.selectedItems[0][0].OfferingId;
            for (var i = 0; i < $scope.scopeData.OrderItems.length; i++) {
                if ($scope.scopeData.OrderItems[i].offeringGuid == parentOfferingId) {
                    return $scope.scopeData.OrderItems[i].guid;
                }
            }
            return GuidEmpty;
        };

        $scope.scopeData.AddOfferAddonToShoppingCart = function () {

            var offeringId = $scope.productOptionalsGrid.selectedItems[0][0].OfferingId;
            var parentOrderItemId = $scope.GetOrderItemIdOfSelectedBasicOfferingFromBasket();

            if (parentOrderItemId == GuidEmpty) {
                alert('You must basic offer into basket!');
            } else {
                $scope.scopeData.AddOfferToShoppingCart(offeringId, parentOrderItemId);
            }

        };

        $scope.scopeData.AddOfferDeviceToShoppingCart = function () {

            var offeringId = $scope.productDevicesGrid.selectedItems[0][0].OfferingId;
            var parentOrderItemId = $scope.GetOrderItemIdOfSelectedBasicOfferingFromBasket();

            if (parentOrderItemId == GuidEmpty) {
                alert('You must basic offer into basket!');
            } else {
                $scope.scopeData.AddOfferToShoppingCart(offeringId, parentOrderItemId);
            }
        };

        //Define the Method for Getting the Order Basket
        $scope.scopeData.GetOrderBasket = function () {
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
                    }
                }).error(function (data, status, headers, config) {
                    alert((data.ExceptionMessage === undefined ?
                        (data.data === undefined ? data :
                            (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                    $scope.httpLoading = false;
                }).finally(function () {
                    //$scope.httpLoading = false;
                });
        }

        $scope.scopeData.AddOfferToShoppingCart = function (offeringId, parentOrderItemId) {

            var orderCaptureId = Xrm.Page.data.entity.getId().substring(1).substring(0, 36);

            var config = {
                withCredentials: true
            };

            $scope.addShoppingCartInputModel = {
                "orderCaptureId": orderCaptureId,
                "offeringId": offeringId,
                "parentOrderItemId": parentOrderItemId
            };


            $http.post(apiUrl + 'AddShoppingCart', JSON.stringify($scope.addShoppingCartInputModel), config)
                .success(function (result) {
                    if (result) {
                        $scope.scopeData.GetOrderBasket();

                        var currentPOCount = $scope.scopeData.OrderItems.length;
                        var portInCount = $rootScope.rootScopeData.ListPortableMSISDN.length;

                        if (portInCount > currentPOCount) {
                            var remainingCount = portInCount - currentPOCount;
                            alert("Please add " + remainingCount + " more Basic PO to Shopping Cart for Portability");
                        }
                    }


                }).error(function (data, status, headers, config) {
                    alert((data.ExceptionMessage === undefined ?
                        (data.data === undefined ? data :
                            (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                    $scope.httpLoading = false;
                }).finally(function () {
                    //$scope.httpLoading = false;
                });

        }

        $scope.scopeData.checkCredit = function () {
            //TODO: Recalculate the Check OUT Price for all the items in OrderBasket
            for (var i = 0; i < $scope.scopeData.OrderItems.length; i++) {
                var CheckOutPriceValue = parseInt($scope.scopeData.OrderItems[i].CheckOutPrice, 10);
                CheckOutPriceValue = CheckOutPriceValue + 5;
                $scope.scopeData.OrderItems[i].CheckOutPrice = CheckOutPriceValue.toString();

                var InstallMentAmountValue = parseInt($scope.scopeData.OrderItems[i].InstallmentAmount, 10);
                InstallMentAmountValue = InstallMentAmountValue + 5;
                $scope.scopeData.OrderItems[i].InstallmentAmount = InstallMentAmountValue.toString();
            }

            $rootScope.rootScopeData.customerInformation.CreditCheckPerformed = $scope.scopeData.selectOffering.translations.tYes;
        };
        $scope.scopeData.removeFromBasket = function (itemToRemove) {
            $scope.removeShoppingCartInputModel = {
                "orderCaptureId": Xrm.Page.data.entity.getId().substring(1).substring(0, 36),
                "orderItemId": itemToRemove.guid
            };
            var config = {
                withCredentials: true
            };
            $http.post(apiUrl + 'RemoveOrderItemFromBasket', JSON.stringify($scope.removeShoppingCartInputModel), config)
                .success(function (result) {
                    if (result) {
                        $scope.scopeData.GetOrderBasket();

                        var currentPOCount = $scope.scopeData.OrderItems.length;
                        var portInCount = $rootScope.rootScopeData.ListPortableMSISDN.length;

                        if (portInCount > currentPOCount) {
                            var remainingCount = portInCount - currentPOCount;
                            alert("Please add " + remainingCount + " more Basic PO to Shopping Cart for Portability");
                        }
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

        $scope.scopeData.selectOffering.translations = {
            getTranslations: function () {
                $scope.scopeData.selectOffering.translations = Wizard.GetTranslationData("selectOfferingStageTranslations");
            }
        };

        window.planningStateRepository = function (stateFunction) {
            return stateFunction($scope);
        };

        $scope.scopeData.registerOfferingsGrid = function () {
            $scope.gridOptions.onRegisterApi = function (gridApi) {
                $scope.gridApi = gridApi;
                $scope.gridApi.grid.registerRowsProcessor($scope.singleFilter, 200);


                $scope.gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                    $scope.gridOptions.selectedRow = [
                        {
                            id: row.entity.id,
                            OfferingId: row.entity.OfferingId,
                            PriceConfigurationId: row.entity.PriceConfigurationId
                        }
                    ];

                    $scope.gridOptions.selectedItems = [];
                    var indexOf = -1;
                    for (var ind = 0; ind < $scope.gridOptions.selectedItems.length; ind++) {
                        if ($scope.gridOptions.selectedItems[ind][0].id == row.entity.id) {
                            indexOf = ind;
                        }
                    }
                    if (row.isSelected) {
                        if (indexOf < 0) {
                            $scope.gridOptions.selectedItems.push($scope.gridOptions.selectedRow);

                        }

                        $scope.scopeData.searchAssociatedOffers(row);

                    }
                    else {
                        if (indexOf > -1) {
                            $scope.gridOptions.selectedItems.splice(indexOf, 1);
                        }

                        $scope.scopeData.searchAssociatedOffers(null);

                    }

                });

            };

            //Basic Offering Grid Configuration
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
            
            $scope.gridOptions.enablePaginationControls = false;
            $scope.gridOptions.paginationPageSize = 30;
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
            //Basic Offering Grid Configuration

            $scope.filter = function () {
                $scope.gridApi.grid.refresh();
            };

            $scope.singleFilter = function (renderableRows) {
                var matcher = new RegExp((!$scope.filterValue) ? $scope.filterValue : $scope.filterValue.toLowerCase());
                renderableRows.forEach(function (row) {
                    var match = false;
                    ['PriceConfigurationName', 'OneTimeCharge', 'RecurringCharge', 'Deposit', 'CheckOutPrice', 'tLink'].forEach(function (field) {
                        //if (row.entity[field].match(matcher)) {
                        match = true;
                        //}

                    });
                    if (!match) {
                        row.visible = false;
                    }
                });
                return renderableRows;
            };

            $scope.BindGrid = function (data) {
                $scope.gridOptions.data = data;

                for (var i = 0; i < data.length; i++) {
                    data[i].id = i;
                    $scope.gridOptions.data[i].tLink = "Link";
                }

                $scope.gridOptions.columnDefs = [
                    { name: "OfferingName", displayName: "Offering Name", field: 'OfferingName', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, cellTemplate: '<div class="ui-grid-cell-contents" ><a href="#" title="{{COL_FIELD}}" ng-click="grid.appScope.OnClickFinancialTransactionBI(row.entity)"><span>{{COL_FIELD}}</span></a></div>', width: 150 }
                    /*,
                    { name: "OneTimeCharge", field: 'OneTimeCharge', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "RecurringCharge", field: 'RecurringCharge', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150, cellTemplate: '<div class="ngCellText" title="{{row.entity.TransactionAmount}}">{{row.entity.TransactionAmount}}</div>' },
                    { name: "Deposit", displayName: "Deposit", field: 'Deposit', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "CheckOutPrice", displayName: "CheckOutPrice", field: 'CheckOutPrice', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 }            */
                ];
            };

            $scope.BindGridNew = function (data) {
                $scope.gridOptions.data = data;

                for (var i = 0; i < data.length; i++) {
                    data[i].id = i;
                    $scope.gridOptions.data[i].tLink = "Link";
                }

                $scope.gridOptions.columnDefs = [
                    { name: "OfferingName", displayName: "Offering Name", field: 'OfferingName', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, cellTemplate: '<div class="ui-grid-cell-contents" ><a href="#" title="{{COL_FIELD}}"><span>{{COL_FIELD}}</span></a></div>' }
                ];
            };
        }

        $scope.scopeData.registerOptionalsGrid = function () {
            $scope.productOptionalsGrid.onRegisterApi = function (gridApi) {
                $scope.productOptionalsGridApi = gridApi;
                $scope.productOptionalsGridApi.grid.registerRowsProcessor($scope.productOptionalsGridSingleFilter, 200);

                $scope.productOptionalsGridApi.selection.on.rowSelectionChanged($scope, function (row) {
                    $scope.productOptionalsGrid.selectedRow = [
                        {
                            id: row.entity.id,
                            OfferingId: row.entity.ProductOfferingId,
                            PriceConfigurationId: row.entity.PriceConfigurationId
                        }
                    ];

                    $scope.productOptionalsGrid.selectedItems = [];
                    var indexOf = -1;
                    for (var ind = 0; ind < $scope.productOptionalsGrid.selectedItems.length; ind++) {
                        if ($scope.productOptionalsGrid.selectedItems[ind][0].id == row.entity.id) {
                            indexOf = ind;
                        }
                    }
                    if (row.isSelected) {
                        if (indexOf < 0) {
                            $scope.productOptionalsGrid.selectedItems.push($scope.productOptionalsGrid.selectedRow);
                        }
                    }
                    else {
                        if (indexOf > -1) {
                            $scope.productOptionalsGrid.selectedItems.splice(indexOf, 1);
                        }
                    }
                });



            };

            //Optional Offering Grid Configuration
            $scope.productOptionalsGrid.enableColumnResizing = true;
            //$scope.productOptionalsGrid.enableHorizontalScrollbar = uiGridConstants.scrollbars.ALWAYS;
            $scope.productOptionalsGrid.enableFiltering = false;
            $scope.productOptionalsGrid.enableGridMenu = false;
            $scope.productOptionalsGrid.showGridFooter = false;
            $scope.productOptionalsGrid.enablePinning = false;
            $scope.productOptionalsGrid.flatEntityAccess = false;
            $scope.productOptionalsGrid.showColumnFooter = false;
            $scope.productOptionalsGrid.fastWatch = true;
            $scope.productOptionalsGrid.enableRowSelection = true;
            $scope.productOptionalsGrid.enableRowHeaderSelection = false;
            $scope.productOptionalsGrid.multiSelect = false;
            $scope.productOptionalsGrid.modifierKeysToMultiSelect = false;
            $scope.productOptionalsGrid.noUnselect = false;
            $scope.productOptionalsGrid.enablePaginationControls = false;
            $scope.productOptionalsGrid.paginationPageSize = 30;
            $scope.productOptionalsGrid.rowIdentity = function (row) {
                return row.id;
            };
            $scope.productOptionalsGrid.getRowIdentity = function (row) {
                return row.id;
            };

            var strVar = "";
            strVar += "<div ng-mouseover=\"rowStyle={'background-color': '#D6EBFF'}; grid.appScope.onRowHover(this);\" ng-mouseleave=\"rowStyle={}\">";
            strVar += "    <div ng-style=\"rowStyle\" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.uid\" ui-grid-one-bind-id-grid=\"rowRenderIndex + '-' + col.uid + '-cell'\"";
            strVar += "         class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" role=\"{{col.isRowHeader ? 'rowheader' : 'gridcell'}}\" ui-grid-cell>";
            strVar += "    <\/div>";
            strVar += "<\/div> ";

            $scope.productOptionalsGrid.rowTemplate = strVar;
            //Optional Offering Grid Configuration

            $scope.filter = function () {
                $scope.productOptionalsGridApi.grid.refresh();
            };

            $scope.productOptionalsGridSingleFilter = function (renderableRows) {
                var matcher = new RegExp((!$scope.filterValue) ? $scope.filterValue : $scope.filterValue.toLowerCase());
                renderableRows.forEach(function (row) {
                    var match = false;
                    ['PriceConfigurationName', 'OneTimeCharge', 'RecurringCharge', 'Deposit', 'CheckOutPrice', 'tLink'].forEach(function (field) {
                        //if (row.entity[field].match(matcher)) {
                        match = true;
                        //}

                    });
                    if (!match) {
                        row.visible = false;
                    }
                });
                return renderableRows;
            };

            $scope.BindProductOptionalsGrid = function (data) {


                if (data == null) {
                    return;
                }

                // $scope.productOptionalsGrid.data.clear();

                for (var i = 0; i < data.length; i++) {
                    // $scope.productOptionalsGrid.data.push(data[i]);

                    data[i].id = i;
                    // $scope.productOptionalsGrid.data[i].tLink = "Link";
                }

                $scope.productOptionalsGrid.data = data;

                $scope.productOptionalsGrid.columnDefs = [
                    { name: "OfferingName", displayName: "Offering Name", field: 'OfferingName', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, cellTemplate: '<div class="ui-grid-cell-contents" ><a href="#" title="{{COL_FIELD}}" ng-click="grid.appScope.OnClickFinancialTransactionBI(row.entity)"><span>{{COL_FIELD}}</span></a></div>' }
                    /*,
                    { name: "OneTimeCharge", field: 'OneTimeCharge', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "RecurringCharge", field: 'RecurringCharge', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150, cellTemplate: '<div class="ngCellText" title="{{row.entity.TransactionAmount}}">{{row.entity.TransactionAmount}}</div>' },
                    { name: "Deposit", displayName: "Deposit", field: 'Deposit', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "CheckOutPrice", displayName: "CheckOutPrice", field: 'CheckOutPrice', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 }            */
                ];
            };
        }

        $scope.scopeData.registerDevicesGrid = function () {
            $scope.productDevicesGrid.onRegisterApi = function (gridApi) {
                $scope.productDevicesGridApi = gridApi;
                $scope.productDevicesGridApi.grid.registerRowsProcessor($scope.productDevicesGridSingleFilter, 200);


                $scope.productDevicesGridApi.selection.on.rowSelectionChanged($scope, function (row) {
                    $scope.productDevicesGrid.selectedRow = [
                        {
                            id: row.entity.id,
                            OfferingId: row.entity.ProductOfferingId,
                            PriceConfigurationId: row.entity.PriceConfigurationId
                        }
                    ];

                    $scope.productDevicesGrid.selectedItems = [];
                    var indexOf = -1;
                    for (var ind = 0; ind < $scope.productDevicesGrid.selectedItems.length; ind++) {
                        if ($scope.productDevicesGrid.selectedItems[ind][0].id == row.entity.id) {
                            indexOf = ind;
                        }
                    }
                    if (row.isSelected) {
                        if (indexOf < 0) {
                            $scope.productDevicesGrid.selectedItems.push($scope.productDevicesGrid.selectedRow);
                        }
                    }
                    else {
                        if (indexOf > -1) {
                            $scope.productDevicesGrid.selectedItems.splice(indexOf, 1);
                        }
                    }
                });

            };

            //Device Offering Grid Configuration
            $scope.productDevicesGrid.enableColumnResizing = true;
            //$scope.productDevicesGrid.enableHorizontalScrollbar = uiGridConstants.scrollbars.ALWAYS;
            $scope.productDevicesGrid.enableFiltering = false;
            $scope.productDevicesGrid.enableGridMenu = false;
            $scope.productDevicesGrid.showGridFooter = false;
            $scope.productDevicesGrid.enablePinning = false;
            $scope.productDevicesGrid.flatEntityAccess = false;
            $scope.productDevicesGrid.showColumnFooter = false;
            $scope.productDevicesGrid.fastWatch = true;
            $scope.productDevicesGrid.enableRowSelection = true;
            $scope.productDevicesGrid.enableRowHeaderSelection = false;
            $scope.productDevicesGrid.multiSelect = false;
            $scope.productDevicesGrid.modifierKeysToMultiSelect = false;
            $scope.productDevicesGrid.noUnselect = false;
            $scope.productDevicesGrid.enablePaginationControls = false;
            $scope.productDevicesGrid.paginationPageSize = 30;
            $scope.productDevicesGrid.rowIdentity = function (row) {
                return row.id;
            };
            $scope.productDevicesGrid.getRowIdentity = function (row) {
                return row.id;
            };

            var strVar = "";
            strVar += "<div ng-mouseover=\"rowStyle={'background-color': '#D6EBFF'}; grid.appScope.onRowHover(this);\" ng-mouseleave=\"rowStyle={}\">";
            strVar += "    <div ng-style=\"rowStyle\" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.uid\" ui-grid-one-bind-id-grid=\"rowRenderIndex + '-' + col.uid + '-cell'\"";
            strVar += "         class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" role=\"{{col.isRowHeader ? 'rowheader' : 'gridcell'}}\" ui-grid-cell>";
            strVar += "    <\/div>";
            strVar += "<\/div> ";

            $scope.productDevicesGrid.rowTemplate = strVar;
            //Device Offering Grid Configuration

            $scope.filter = function () {
                $scope.productDevicesGridApi.grid.refresh();
            };

            $scope.productDevicesGridSingleFilter = function (renderableRows) {
                var matcher = new RegExp((!$scope.filterValue) ? $scope.filterValue : $scope.filterValue.toLowerCase());
                renderableRows.forEach(function (row) {
                    var match = false;
                    ['PriceConfigurationName', 'OneTimeCharge', 'RecurringCharge', 'Deposit', 'CheckOutPrice', 'tLink'].forEach(function (field) {
                        //if (row.entity[field].match(matcher)) {
                        match = true;
                        //}

                    });
                    if (!match) {
                        row.visible = false;
                    }
                });
                return renderableRows;
            };

            $scope.BindProductDevicesGrid = function (data) {

                if (data == null) {
                    return;
                }

                // $scope.productDevicesGrid.data.clear();

                for (var i = 0; i < data.length; i++) {
                    // $scope.productDevicesGrid.data.push(data[i]);

                    data[i].id = i;
                    // $scope.productDevicesGrid.data[i].tLink = "Link";
                }

                $scope.productDevicesGrid.data = data;

                $scope.productDevicesGrid.columnDefs = [
                    { name: "OfferingName", displayName: "Offering Name", field: 'OfferingName', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, cellTemplate: '<div class="ui-grid-cell-contents" ><a href="#" title="{{COL_FIELD}}" ng-click="grid.appScope.OnClickFinancialTransactionBI(row.entity)"><span>{{COL_FIELD}}</span></a></div>', width: 150 }
                    /*,
                    { name: "OneTimeCharge", field: 'OneTimeCharge', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "RecurringCharge", field: 'RecurringCharge', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150, cellTemplate: '<div class="ngCellText" title="{{row.entity.TransactionAmount}}">{{row.entity.TransactionAmount}}</div>' },
                    { name: "Deposit", displayName: "Deposit", field: 'Deposit', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "CheckOutPrice", displayName: "CheckOutPrice", field: 'CheckOutPrice', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 }            */
                ];
            };
        }

        $scope.scopeData.populateAvailableStocks = function () {
            var config = {
                withCredentials: true
            };

            $scope.workflowStartInput = {
                partNumber: "ClaroSimNano",
                userId: "39339"
            };

            $http.post(apiUrl + 'AmxPeruGetAvailableStocks', JSON.stringify($scope.workflowStartInput), config)
                .success(function (result) {
                    if (result) {
                        $scope.scopeData.AvailableStocks = result.Output.availableStocks;

                        $scope.BindAvailableStocksGrid($scope.scopeData.AvailableStocks);
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

        $scope.scopeData.registerAvailableStocksGrid = function () {
            $scope.availableStocksGrid.onRegisterApi = function (gridApi) {
                $scope.availableStocksGridApi = gridApi;
                $scope.availableStocksGridApi.grid.registerRowsProcessor($scope.availableStocksGridSingleFilter, 200);


                $scope.availableStocksGridApi.selection.on.rowSelectionChanged($scope, function (row) {
                    $scope.availableStocksGrid.selectedRow = [
                        {
                            id: row.entity.id,
                            OfferingId: row.entity.ProductOfferingId,
                            PriceConfigurationId: row.entity.PriceConfigurationId
                        }
                    ];

                    $scope.availableStocksGrid.selectedItems = [];
                    var indexOf = -1;
                    for (var ind = 0; ind < $scope.availableStocksGrid.selectedItems.length; ind++) {
                        if ($scope.availableStocksGrid.selectedItems[ind][0].id == row.entity.id) {
                            indexOf = ind;
                        }
                    }
                    if (row.isSelected) {
                        if (indexOf < 0) {
                            $scope.availableStocksGrid.selectedItems.push($scope.availableStocksGrid.selectedRow);
                        }
                    }
                    else {
                        if (indexOf > -1) {
                            $scope.availableStocksGrid.selectedItems.splice(indexOf, 1);
                        }
                    }
                });

            };
            $scope.availableStocksGrid.enableColumnResizing = true;
            $scope.availableStocksGrid.enableHorizontalScrollbar = "always"; // uiGridConstants.scrollbars.ALWAYS;
            //$scope.productOptionalsGrid.enableVerticalScrollbar = uiGridConstants.scrollbars.NEVER;
            $scope.availableStocksGrid.enableFiltering = false;
            $scope.availableStocksGrid.enableGridMenu = false;
            $scope.availableStocksGrid.showGridFooter = false;
            $scope.availableStocksGrid.enablePinning = false;
            $scope.availableStocksGrid.flatEntityAccess = false;
            $scope.availableStocksGrid.showColumnFooter = false;
            $scope.availableStocksGrid.fastWatch = true;
            $scope.availableStocksGrid.enableRowSelection = true;
            $scope.availableStocksGrid.enableRowHeaderSelection = false;
            $scope.availableStocksGrid.multiSelect = false;
            $scope.availableStocksGrid.modifierKeysToMultiSelect = false;
            $scope.availableStocksGrid.noUnselect = false;
            $scope.availableStocksGrid.expandableRowTemplate = '<div ui-grid="row.entity.subGridOptions" class="sub-grid" style="height:70px; width:50%;"></div>';
            $scope.availableStocksGrid.expandableRowHeight = 70;
            //subGridVariable will be available in subGrid scope
            $scope.availableStocksGrid.expandableRowScope = {
                subGridVariable: 'subGridScopeVariable'
            };
            $scope.availableStocksGrid.enablePaginationControls = false;
            $scope.availableStocksGrid.paginationPageSize = 10;
            $scope.availableStocksGrid.rowIdentity = function (row) {
                return row.id;
            };
            $scope.availableStocksGrid.getRowIdentity = function (row) {
                return row.id;
            };

            var strVar = "";
            strVar += "<div ng-mouseover=\"rowStyle={'background-color': '#D6EBFF'}; grid.appScope.onRowHover(this);\" ng-mouseleave=\"rowStyle={}\">";
            strVar += "    <div ng-style=\"rowStyle\" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.uid\" ui-grid-one-bind-id-grid=\"rowRenderIndex + '-' + col.uid + '-cell'\"";
            strVar += "         class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" role=\"{{col.isRowHeader ? 'rowheader' : 'gridcell'}}\" ui-grid-cell>";
            strVar += "    <\/div>";
            strVar += "<\/div> ";

            $scope.availableStocksGrid.rowTemplate = strVar;

            $scope.filter = function () {
                $scope.availableStocksGridApi.grid.refresh();
            };

            $scope.availableStocksGridSingleFilter = function (renderableRows) {
                var matcher = new RegExp((!$scope.filterValue) ? $scope.filterValue : $scope.filterValue.toLowerCase());
                renderableRows.forEach(function (row) {
                    var match = false;
                    ['PriceConfigurationName', 'OneTimeCharge', 'RecurringCharge', 'Deposit', 'CheckOutPrice', 'tLink'].forEach(function (field) {
                        //if (row.entity[field].match(matcher)) {
                        match = true;
                        //}

                    });
                    if (!match) {
                        row.visible = false;
                    }
                });
                return renderableRows;
            };

            $scope.BindAvailableStocksGrid = function (data) {

                if (data == null) {
                    return;
                }

                // $scope.availableStocksGrid.data.clear();

                for (var i = 0; i < data.length; i++) {
                    // $scope.availableStocksGrid.data.push(data[i]);

                    data[i].id = i;
                    // $scope.availableStocksGrid.data[i].tLink = "Link";
                }

                $scope.availableStocksGrid.data = data;

                $scope.availableStocksGrid.columnDefs = [
                    { name: "Description", displayName: "Desc ription", field: 'Description', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, cellTemplate: '<div class="ui-grid-cell-contents" ><a href="#" title="{{COL_FIELD}}" ng-click="grid.appScope.OnClickFinancialTransactionBI(row.entity)"><span>{{COL_FIELD}}</span></a></div>', width: 150 },
                    { name: "CharacteristicDescription", displayName: "Characteristic", field: 'CharacteristicDescription', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "SalesOrganizationRoleName", displayName: "Organization Role Name", field: 'SalesOrganizationRoleName', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "Quantity", displayName: "Quantity", field: 'Quantity', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 }
                    /*,
                    { name: "OfferingName", displayName: "Offering Name", field: 'OfferingName', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, cellTemplate: '<div class="ui-grid-cell-contents" ><a href="#" title="{{COL_FIELD}}" ng-click="grid.appScope.OnClickFinancialTransactionBI(row.entity)"><span>{{COL_FIELD}}</span></a></div>', width: 150 }
                    { name: "OneTimeCharge", field: 'OneTimeCharge', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "RecurringCharge", field: 'RecurringCharge', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150, cellTemplate: '<div class="ngCellText" title="{{row.entity.TransactionAmount}}">{{row.entity.TransactionAmount}}</div>' },
                    { name: "Deposit", displayName: "Deposit", field: 'Deposit', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                    { name: "CheckOutPrice", displayName: "CheckOutPrice", field: 'CheckOutPrice', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 }            */
                ];
            };
        }

        var initiate = function () {
            $scope.scopeData.selectOffering.translations.getTranslations();
            $scope.scopeData.catalogModel = $scope.workflowContext.ResponseData.Output.productCatalogueModel;
            $scope.scopeData.Families = $scope.workflowContext.ResponseData.Output.productCatalogueModel.filter(FilterFamily);
            $scope.resumeInput.data = {};
            $scope.resumeInput.data.province = "Test";

            $scope.scopeData.registerOfferingsGrid();
            $scope.scopeData.registerOptionalsGrid();
            $scope.scopeData.registerDevicesGrid();
            $scope.scopeData.registerAvailableStocksGrid();
            $scope.scopeData.GetOrderBasket();
        };

        initiate();
    }]);
