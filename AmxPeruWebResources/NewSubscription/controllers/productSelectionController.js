wizard.controller("productSelectionController",
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
            
            var GuidEmpty = "00000000-0000-0000-0000-000000000000";

            // eheldma: Request to Bureau already performed?
            bureauOK = false;

            if (typeof $scope.scopeData === "undefined") {
                $scope.scopeData = {};
            }
            if (typeof $rootScope.rootScopeData === "undefined") {
                $rootScope.rootScopeData = {};
            }
            if (typeof $rootScope.rootScopeData.order === "undefined") {
                $rootScope.rootScopeData.order = {};
            }
            if (typeof $rootScope.rootScopeData.customerInformation === "undefined") {
                $rootScope.rootScopeData.customerInformation = {};
            }
            if (typeof $rootScope.rootScopeData.customerInformation.SelectedAddress === "undefined") {
                $rootScope.rootScopeData.customerInformation.SelectedAddress = {};
            }


            var config = {
                withCredentials: true
            };

            $scope.scopeData.productSelection = {

                cart: {
                    family: {}
                },
                cartSubItems: {},
                availableAddons: {},
                basicOfferingDictionary: {
                    "TEL": "Telephony",
                    "INT": "Internet",
                    "TV": "Television",
                    "TEL2": "Telephony2",
                    "MOV": "Mobile"
                },
                offerTypeCodes: { "Plan": 10 },
                addCustomerProductsToCart: function (customerProducts) {

                    //if (!$scope.scopeData.productSelection.cart.items || $scope.scopeData.productSelection.cart.items.length === 0) {

                    var cartItemAdditionInputModel = {};

                    for (var i = 0; i < customerProducts.length; i++) {
                        cartItemAdditionInputModel.srProductId = customerProducts[i].id;
                        cartItemAdditionInputModel.poExternalId = customerProducts[i].productOffering.id;
                        cartItemAdditionInputModel.srParentPoId = "";
                        cartItemAdditionInputModel.orderItemAction = "3"; // No_Change
                        cartItemAdditionInputModel.activationStartDate = customerProducts[i].validFor.start;
                        cartItemAdditionInputModel.activationendDate = customerProducts[i].validFor.end;
                        cartItemAdditionInputModel.fromServiceRegistry = true;


                        if (customerProducts[i].productRelationships && customerProducts[i].productRelationships[0].type === "ChildOf") {
                            cartItemAdditionInputModel.srParentPoId = customerProducts[i].productRelationships[0].product.id;
                        }

                        $scope.scopeData.productSelection.findPOAndToBasket(cartItemAdditionInputModel);
                    }
                    // }
                },
                addOnsCartOperations: function () {

                    $scope.scopeData.productSelection.showLDILDNOffering = false;
                    var selectedAddOns = $scope.scopeData.productSelection.selectedAddOns();

                    if (selectedAddOns.length > 0) {

                        for (var i = 0; i < $scope.scopeData.productSelection.cart.items.length; i++) {
                            if ($scope.scopeData.productSelection.cart.items[i].offeringGuid === $scope.scopeData.productSelection.selectedBasicOfferingId) {
                                $scope.scopeData.productSelection.parentOrderItemId = $scope.scopeData.productSelection.cart.items[i].guid;
                                break;
                            }
                        }

                        $scope.scopeData.productSelection.addSelectedAddOnsToCart(selectedAddOns, $scope.scopeData.productSelection.parentOrderItemId);
                    }
                    else {
                        alert($scope.scopeData.productSelection.translations.tOfferSelectionWarning);
                    }
                },
                addSelectedAddOnsToCart: function (addOnList, parentOrderItemId) {

                    var deferred = $q.defer();

                    for (var i = 0; i < addOnList.length; i++) {

                        var cartItemAdditionInputModel = {
                            srProductId: "",
                            srParentPoId: "",
                            orderItemAction: "1",
                            recurringPrice: addOnList[i].Recurring ? "" + addOnList[i].Recurring[0].Amount + "" : "",
                            oneTimePrice: addOnList[i].OneTime ? "" + addOnList[i].OneTime[0].Amount + "" : "",
                            popExternalId: addOnList[i].Recurring ? addOnList[i].Recurring[0].PopExternalId : ""
                        }

                        if (addOnList[i].Recurring) {
                            cartItemAdditionInputModel.popExternalId = addOnList[i].Recurring[0].PopExternalId;
                        }
                        else if (addOnList[i].OneTime) {
                            cartItemAdditionInputModel.popExternalId = addOnList[i].OneTime[0].PopExternalId;
                        }

                        var isPermenancia = false;
                        isPermenancia = (addOnList[i].OfferingName.indexOf("Permanencia") >= 0);
                        var promise = $scope.scopeData.productSelection.addOfferToShoppingCart(addOnList[i].OfferingId, parentOrderItemId, cartItemAdditionInputModel);

                        promise.then(function () {
                            if (isPermenancia) {
                                $scope.scopeData.productSelection.calculateMultiPlayPrices();
                                isPermenancia = false;
                            }
                            else {
                                $scope.scopeData.productSelection.getOrderBasket();
                            }
                        });
                    }

                    deferred.resolve();

                    return deferred.promise;
                },
                addOfferToShoppingCart: function (offeringId, parentOrderItemId, cartItemAdditionInputModel) {
                    var deferred = $q.defer();
                    var orderCaptureId = Xrm.Page.data.entity.getId().substring(1).substring(0, 36);

                    var config = {
                        withCredentials: true
                    };

                    srProductId = "";
                    srParentPoId = "";
                    orderItemAction = "1";
                    recurringPrice = "";
                    oneTimePrice = "";
                    popExternalId = "";
                    selectedAddressStratum = "";
                    fromServiceRegistry = false

                    if (cartItemAdditionInputModel) {
                        srProductId = cartItemAdditionInputModel.srProductId;
                        srParentPoId = cartItemAdditionInputModel.srParentPoId;
                        orderItemAction = cartItemAdditionInputModel.orderItemAction;
                        recurringPrice = cartItemAdditionInputModel.recurringPrice;
                        oneTimePrice = cartItemAdditionInputModel.oneTimePrice;
                        popExternalId = cartItemAdditionInputModel.popExternalId ? cartItemAdditionInputModel.popExternalId : "";
                        selectedAddressStratum = $scope.scopeData.productSelection.selectedAddressStratum;
                        fromServiceRegistry = cartItemAdditionInputModel.fromServiceRegistry ? cartItemAdditionInputModel.fromServiceRegistry : false;
                    }

                    $scope.addShoppingCartInputModel = {
                        "orderItemShoppingCartModel": {
                            "$type": "AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel, AmxPeruPSBActivities",
                            "OrderCaptureId": orderCaptureId,
                            "OfferingId": offeringId,
                            "ParentOrderItemId": parentOrderItemId,
                            "SrProductId": srProductId,
                            "SrParentPoId": srParentPoId,
                            "OrderItemAction": orderItemAction,
                            "RecurringPrice": recurringPrice,
                            "OneTimePrice": oneTimePrice,
                            "PopExternalId": popExternalId,
                            "AddressId": $scope.scopeData.productSelection.selectedAddressId,
                            "SelectedAddressStratum": $scope.scopeData.productSelection.selectedAddressStratum,
                            "BasicOffering": $scope.scopeData.productSelection.basicOfferingDictionary[$scope.scopeData.productSelection.selectedBasicOffering],
                            "FromServiceRegistry": fromServiceRegistry
                        }
                    };

                    if (cartItemAdditionInputModel && cartItemAdditionInputModel.activationStartDate) {
                        $scope.addShoppingCartInputModel.activationStartDate = cartItemAdditionInputModel.activationStartDate;
                    }
                    if (cartItemAdditionInputModel && cartItemAdditionInputModel.activationEndDate) {
                        $scope.addShoppingCartInputModel.activationEndDate = cartItemAdditionInputModel.activationEndDate;
                    }


                    $http.post(apiUrl + 'AddShoppingCart', JSON.stringify($scope.addShoppingCartInputModel), config)
                        .success(function (result) {
                            if (result) {

                                var length = result.Output.orderDataModel.orderItems.length - 1;

                                if ($scope.addShoppingCartInputModel.orderItemShoppingCartModel.ParentOrderItemId === GuidEmpty) {
                                    for (var j = length; j >= 0; j--) {
                                        if (result.Output.orderDataModel.orderItems[j].ParentOrderItemId === GuidEmpty) {
                                            $scope.scopeData.productSelection.parentOrderItemId = result.Output.orderDataModel.orderItems[j].Id;
                                            break;
                                        }
                                    }
                                }

                                deferred.resolve();
                            }
                        }).error(function (data, status, headers, config) {
                            /*
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                            */
                            alert("Adding offering to basket has been unsuccessful. Please be sure that you selected address!");
                            $scope.scopeData.productSelection.getOrderBasket();
                            $scope.httpLoading = false;
                        }).finally(function () {
                            //$scope.httpLoading = false;
                        });

                    return deferred.promise;
                },
                basicOfferCartOperations: function (selectedBasicOffering) {

                    $scope.scopeData.productSelection.showLDILDNOffering = false;

                    if (selectedBasicOffering) {
                        $scope.scopeData.productSelection.selectedBasicOfferingId = selectedBasicOffering.OfferingId;
                        $scope.scopeData.productSelection.selectedBasicOffering = selectedBasicOffering.Family;
                        $scope.scopeData.productSelection.searchAssociatedOffers(selectedBasicOffering.OfferingId);
                        $scope.scopeData.productSelection.defineParentOrderItemId();

                        if ($scope.scopeData.productSelection.selectedBasicOffering === "TEL") {
                            $scope.scopeData.productSelection.firstLineTelSelected = true;
                        }
                    }
                },
                calculateMultiPlayPrices: function () {

                    var selectedAddressStratum = $scope.scopeData.productSelection.selectedAddressStratum;

                    $scope.removeShoppingCartInputModel = {
                        "orderCaptureId": Xrm.Page.data.entity.getId().substring(1).substring(0, 36),
                        "estrato": selectedAddressStratum ? selectedAddressStratum : "1"
                    };
                    var config = {
                        withCredentials: true
                    };
                    $http.post(apiUrl + 'UpdateOrderItemsForMultiPlay', JSON.stringify($scope.removeShoppingCartInputModel), config)
                        .success(function (result) {
                            if (result) {
                                $scope.scopeData.productSelection.getOrderBasket();
                            }
                        }).error(function (data, status, headers, config) {
                            alert($scope.scopeData.productSelection.translations.tPriceUpdateWarning);

                            $scope.httpLoading = false;
                        }).finally(function () {
                            //$scope.httpLoading = false;
                        });
                },
                checkIfMultiPlayUpdateNeeded: function (previousBasicOfferingLength, isRemovedItemPermanencia) {
                    var lenght = $scope.scopeData.productSelection.cart.items.length;
                    var currentBasicOfferingLength = 0;
                    for (var i = 0; i < length; i++) {
                        if ($scope.scopeData.productSelection.cart.items[i].ParentOrderItemId === GuidEmpty) {
                            currentBasicOfferingLength++;
                        }
                    }

                    if (previousBasicOfferingLength > currentBasicOfferingLength || isRemovedItemPermanencia) {
                        $scope.scopeData.productSelection.revertCartPrices(isRemovedItemPermanencia);
                    }
                },
                checkLDILDNOffers: function () {
                    var showLDILDNOffering;
                    $scope.scopeData.productSelection.selectedBasicOffering === "TEL" || $scope.scopeData.productSelection.selectedBasicOffering === "TEL2" ? showLDILDNOffering = true : showLDILDNOffering = false;
                    $scope.scopeData.productSelection.showLDILDNOffering = showLDILDNOffering;
                },
                calculateFamilySum: function (index) {
                    var monthlyTotalPrice = 0, oneTimeTotalPrice = 0, monthlyTotalTax = 0, oneTimeTotalTax = 0;
                    var family, length;
                    $scope.scopeData.productSelection.cart.family[index] = {};
                    if (index === 0) {
                        family = $scope.scopeData.productSelection.cart.family1;
                    }
                    if (index === 1) {
                        family = $scope.scopeData.productSelection.cart.family2;
                    }
                    if (index === 2) {
                        family = $scope.scopeData.productSelection.cart.family3;
                    }
                    if (index === 3) {
                        family = $scope.scopeData.productSelection.cart.family4;
                    }


                    length = family.items.length;                                               
                    for (var i = 0; i < length; i++) {
                        if (family.items[i].RecurringCharge) {
                            monthlyTotalPrice += parseFloat(family.items[i].RecurringCharge.replace(/\,/g, ''));
                        }
                        if (family.items[i].OneTimeCharge) {
                            oneTimeTotalPrice += parseFloat(family.items[i].OneTimeCharge.replace(/\,/g, ''));
                        }
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////
                        //// TAXES ////////////////////////////////////////////////////////////////////////////////////////////
                        if (family.items[i].Taxes && (family.items[i].RecurringCharge || family.items[i].OneTimeCharge)) {
                            var taxes = family.items[i].Taxes.split(";");
                            if (taxes.length > 0) {
                                var taxItems = taxes[0].split(":");
                                if (taxItems.length > 0) {
                                    monthlyTotalTax += taxItems[1] == "Percent" ? ((family.items[i].RecurringCharge).replace(/\,/g, '') * taxItems[2] * 0.01) : taxItems[2];
                                    oneTimeTotalTax += taxItems[1] == "Percent" ? ((family.items[i].OneTimeCharge).replace(/\,/g, '') * taxItems[2] * 0.01) : taxItems[2];
                                }
                            }

                        }
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////
                    }
                    $scope.scopeData.productSelection.cart.family[index].monthlyTotalPrice = monthlyTotalPrice.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                    $scope.scopeData.productSelection.cart.family[index].monthlyTotalTax = monthlyTotalTax.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                    $scope.scopeData.productSelection.cart.family[index].oneTimeTotalPrice = oneTimeTotalPrice.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                    $scope.scopeData.productSelection.cart.family[index].oneTimeTotalTax = oneTimeTotalTax.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                },
                getBIHeader: function () {
                    var orderCaptureId = Xrm.Page.data.entity.getId().substring(1).substring(0, 36);
                    var req = new XMLHttpRequest();
                    req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_ordercaptures(" + orderCaptureId + ")?$select=_amx_biheaderid_value", false);
                    req.setRequestHeader("OData-MaxVersion", "4.0");
                    req.setRequestHeader("OData-Version", "4.0");
                    req.setRequestHeader("Accept", "application/json");
                    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                    req.onreadystatechange = function () {
                        if (this.readyState === 4) {
                            req.onreadystatechange = null;
                            if (this.status === 200) {
                                var result = JSON.parse(this.response);
                                var _amx_biheaderid_value = result["_amx_biheaderid_value"];
                                $scope.scopeData.productSelection.biHeader = _amx_biheaderid_value;
                            } else {
                                Xrm.Utility.alertDialog(this.statusText);
                            }
                        }
                    };
                    req.send();
                },
                checkCustomerInformation: function (cId) {
                    var deferred = $q.defer();
                    var req = new XMLHttpRequest();
                    req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/contacts(" + cId.replace("{", "").replace("}", "") + ")?$select=amx_documentissuedate,amxperu_documenttype,etel_iddocumentnumber,lastname", false);
                    req.setRequestHeader("OData-MaxVersion", "4.0");
                    req.setRequestHeader("OData-Version", "4.0");
                    req.setRequestHeader("Accept", "application/json");
                    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                    req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                    req.onreadystatechange = function () {
                        if (this.readyState === 4) {
                            req.onreadystatechange = null;
                            if (this.status === 200) {
                                var result = JSON.parse(this.response);
                                var amx_documentissuedate = result["amx_documentissuedate"];
                                var amx_documentissuedate_formatted = result["amx_documentissuedate@OData.Community.Display.V1.FormattedValue"];
                                var amxperu_documenttype = result["amxperu_documenttype"];
                                var amxperu_documenttype_formatted = result["amxperu_documenttype@OData.Community.Display.V1.FormattedValue"];
                                var etel_iddocumentnumber = result["etel_iddocumentnumber"];
                                var lastname = result["lastname"];
                                if (amx_documentissuedate_formatted) {
                                } else {
                                    amx_documentissuedate_formatted = "No disponible";
                                }

                                var line1 = "Apellido: " + lastname + " <br />";
                                var line2 = amxperu_documenttype_formatted + ": " + etel_iddocumentnumber + " <br />";
                                var line3 = "Fecha de expedición: " + amx_documentissuedate_formatted + " <br />";
                                var line4 = "¿Las informaciones son coincidentes con lo que el cliente presentó?";

                                Alert.show("ATENCIÓN! <br />" + "Verificar las informaciones del cliente.",
                                    line1 + line2 + line3 + line4, [
                                        new Alert.Button("Sí", function () {
                                            $scope.scopeData.productSelection.closeOrder = false;
                                            deferred.resolve();
                                            //return deferred.promise;
                                        }, false, false),
                                        new Alert.Button("No", function () {
                                            alert("¡Es necesario actualizar los datos del cliente!\nLa orden será finalizada...");
                                            $scope.scopeData.productSelection.closeOrder = true;
                                            //$scope.scopeData.productSelection.cancelOrder();
                                            //$scope.scopeData.productSelection.redirectTo360View();
                                            deferred.resolve();
                                            //return deferred.promise;
                                        }, false, false)], "WARNING", 500, 200);
                                /*
                                                                  if (confirm("Verificar las informaciones del cliente\n\nApellido: " + lastname + "\n" +
                                                                      amxperu_documenttype_formatted + ": " + etel_iddocumentnumber + "\nFecha de expedición: " +
                                                                      amx_documentissuedate_formatted + "\n\n¿Las informaciones son coincidentes con lo que el cliente presentó? (Sí=OK / No=Cancel)"))
                                                                      {
                                                                         $scope.scopeData.productSelection.closeOrder = false;
                                                                         return;
                                                                      } else {
                                                                         alert("¡Es necesario actualizar los datos del cliente!\nEl orden será finalizado...");
                                                                         $scope.scopeData.productSelection.closeOrder = true;
                                                                         return;
                                                                     }
                                */
                            } else {
                                Xrm.Utility.alertDialog(this.statusText);
                            }
                        }
                    };
                    req.send();
                    return deferred.promise;
                },
                checkOrderCaptureSelectedAddressId: function () {
                    var inputModel = {
                        "orderCaptureId": Xrm.Page.data.entity.getId().substring(1).substring(0, 36)
                    };

                    $http.post(apiUrl + 'GetOrderCaptureAddress', JSON.stringify(inputModel), config)
                        .success(function (result) {
                            if (result && result.Output.addressId !== null && result.Output.addressId !== "") {
                                
                                var addressObject = {
                                    "AddressId": result.Output.addressId,
                                    "AddressName": result.Output.addressName
                                };
                                $scope.scopeData.productSelection.selectCustomerAddress(addressObject, false);
                            }
                        });
                },            
                collapseSubItems: function (show, index) {
                    $scope.scopeData.productSelection.cartSubItems[index] = {};
                    $scope.scopeData.productSelection.cartSubItems[index].show = show;
                    $scope.scopeData.productSelection.calculateFamilySum(index);

                },
                contractsSearch: function (cId) {
                    var config = {
                        withCredentials: true
                    };

                    $scope.workflowContractsSearchByIdInput = {
                        "individualCustomerId": cId
                        //"individualCustomerId": "{F67197E7-F0AD-E711-80E2-FA163E105D63}"
                    };

                    $http.post(apiUrl + 'ContractsSearchById', JSON.stringify($scope.workflowContractsSearchByIdInput), config)
                        .success(function (result) {
                            if (result) {
                                var contractsSearchResponse = result.Output.response;
                                var x = contractsSearchResponse.length;
                                if (x == 0) {
                                    // if customer hasn't recurrent service then validate biographic
                                    $scope.scopeData.productSelection.customerBiographic(cId);
                                    return;
                                } else {
                                    return;
                                }
                            } else {
                                return;
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                            $scope.httpLoading = false;
                        });
                },
                createCustomerAddress: function () {
                    var customerId = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
                    if (customerId != null) {
                        customerId = customerId[0].id;
                        var req = new XMLHttpRequest();
                        req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/contacts(" + customerId.replace("{", "").replace("}", "") + ")?$select=_amx_districtid_value,contactid,_etel_cityid_value", false);
                        req.setRequestHeader("OData-MaxVersion", "4.0");
                        req.setRequestHeader("OData-Version", "4.0");
                        req.setRequestHeader("Accept", "application/json");
                        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                        req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                        req.onreadystatechange = function () {
                            if (this.readyState === 4) {
                                req.onreadystatechange = null;
                                if (this.status === 200) {
                                    var result = JSON.parse(this.response);
                                    var _amx_districtid_value = result["_amx_districtid_value"];
                                    var _amx_districtid_value_formatted = result["_amx_districtid_value@OData.Community.Display.V1.FormattedValue"];
                                    var _amx_districtid_value_lookuplogicalname = result["_amx_districtid_value@Microsoft.Dynamics.CRM.lookuplogicalname"];
                                    var contactid = result["contactid"];
                                    var _etel_cityid_value = result["_etel_cityid_value"];
                                    var _etel_cityid_value_formatted = result["_etel_cityid_value@OData.Community.Display.V1.FormattedValue"];
                                    var _etel_cityid_value_lookuplogicalname = result["_etel_cityid_value@Microsoft.Dynamics.CRM.lookuplogicalname"];
                                    $scope.scopeData.productSelection.createAndOpenEntity(_etel_cityid_value_formatted, _amx_districtid_value, _etel_cityid_value, customerId.replace("{", "").replace("}", ""));
                                } else {
                                    Xrm.Utility.alertDialog(this.statusText);
                                }
                            }
                        };
                        req.send();
                    }


                },
                createAndOpenEntity: function (addressName, districtId, cityId, customerId) {
                    var entity = {};
                    entity.etel_name = addressName;
                    entity.amx_addressusagecode = "173800000,173800002";
                    entity.amx_addressusagelabel = "Invoice/contract,Installation";
                    entity["amxperu_district@odata.bind"] = "/amxperu_districts(" + districtId + ")";
                    entity["etel_cityid@odata.bind"] = "/etel_cities(" + cityId + ")";
                    entity["etel_individualcustomerid@odata.bind"] = "/contacts(" + customerId + ")";
                    var req = new XMLHttpRequest();
                    req.open("POST", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_customeraddresses", false);
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
                                var windowOptions = { openInNewWindow: true };
                                Xrm.Utility.openEntityForm("etel_customeraddress", newEntityId, null, windowOptions);
                            } else {
                                Xrm.Utility.alertDialog(this.statusText);
                            }
                        }
                    };
                    req.send(JSON.stringify(entity));
                },
                creditBureauCheck: function (cId) {

                    try {

                        var config = {
                            withCredentials: true
                        };

                        var uri = "http://172.18.88.73:7005/eoc/sr/v1/product/?relatedParties.reference=" +
                            $scope.scopeData.productSelection.customerExternalId + "&relatedParties.role=Customer";

                        $scope.workflowBureauInput = {
                            "individualCustomerId": cId,
                            "uri": uri
                        };

                        $http.post(apiUrl + 'AmxCoBureau', JSON.stringify($scope.workflowBureauInput), config)
                            .success(function (result) {
                                if (result) {

                                    var externalBureauResponse = result.Output.response;
                                    var internalBureauResponse = result.Output.internalBureauResponse;
                                    if (internalBureauResponse == "OK") {
                                        bureauOK = true;
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
                        alert("CreditBureauCheck: " + err.message);
                    }
                },
                defineParentOrderItemId: function () {

                    // regarding selected basic offering if it is in basket
                    //if ($scope.scopeData.productSelection.cart.items.length) {
                    for (var i = 0; i < $scope.scopeData.productSelection.cart.items.length; i++) {
                        if ($scope.scopeData.productSelection.cart.items[i].offeringGuid === $scope.scopeData.productSelection.basicOfferingId) {
                            $scope.scopeData.productSelection.parentOrderItemId = $scope.scopeData.productSelection.cart.items[i].guid;
                            return;
                        }
                    }
                    //}
                },
                evidenteCheck: function (individualCustomerId) {

                    try {
                        var webResourceName = "amx_/Evidente/amxco_EvidenteQuestionnaire.htm?data=individualCustomerId%3d" + individualCustomerId;
                        var width = 840;
                        var height = 580;
                        var title = "Autenticación cliente";
                        var buttons = [
                            new Alert.Button("Enviar", function () { Alert.getIFrameWindow().amxco_EvidenteQuestionnaire.showResults(); }, true),
                            new Alert.Button("Cerrar", function () { $scope.scopeData.productSelection.homeAppointmentCheck(individualCustomerId); }, true)
                        ];
                        var baseUrl = Xrm.Page.context.getClientUrl();
                        var preventCancel = false;
                        var padding = null;

                        Alert.showWebResource(webResourceName, width, height, title, buttons, baseUrl, preventCancel, padding)



                        //var evidenteURL = Xrm.Page.context.getClientUrl() + "/WebResources/amx_/Evidente/amxco_EvidenteQuestionnaire.htm?data=individualCustomerId%3d" + individualCustomerId;

                        //if (navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0) {
                        //    /* Microsoft Internet Explorer detected in. */

                        //    var sFeatures = "dialogHeight: 580px;dialogWidth: 840px"

                        //    window.showModalDialog(evidenteURL, "", sFeatures);
                        //}
                        //else {
                        //    var w = 840;
                        //    var h = 580;
                        //    var left = (screen.width / 2) - (w / 2);
                        //    var top = (screen.height / 2) - (h / 2);
                        //    popupWindow = window.open(evidenteURL, "Autenticación cliente", "directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=" + w + ", height=" + h + ", top=" + top + ", left=" + left);
                        //}
                    }
                    catch (err) {
                        alert("Evidente Authenthication: " + err.message);
                    }
                },
                getAddressAvailableTechnology: function (addressId) {
                    var config = {
                        withCredentials: true
                    };

                    $scope.workflowStartInput = {
                        "addressId": addressId
                    };

                    $http.post(apiUrl + 'GetAddressAvailableTechnology', JSON.stringify($scope.workflowStartInput), config)
                        .success(function (result) {
                            $scope.scopeData.productSelection.selectedAddressTechnology = result.Output.technology; 
                            $scope.scopeData.productSelection.redesignBasicOfferingsWithTechnology(result.Output.technology);
                        }).error(function (data, status, headers, config) {
                            alert("No technology available with selected address!");
                        });
                },
                getOrderBasket: function () {
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
                                $scope.scopeData.productSelection.cart.items = result.Output.orderBasket.listOfOrderBasketOrderItems;
                                deferred.resolve();

                                var cart = $scope.scopeData.productSelection.cart;
                                var length = cart.items.length;
                                if (length > 0) {
                                    $scope.scopeData.productSelection.cart.show = true;

                                    $scope.scopeData.productSelection.cart.family1 = { "items": [] };
                                    $scope.scopeData.productSelection.cart.family2 = { "items": [] };
                                    $scope.scopeData.productSelection.cart.family3 = { "items": [] };
                                    $scope.scopeData.productSelection.cart.family4 = { "items": [] };
                                    var startFamily2 = true, startFamily3 = true;
                                    var orderToBeChecked = 0;
                                    var monthlyTotalPrice = 0, oneTimeTotalPrice = 0, monthlyTotalTax = 0, oneTimeTotalTax = 0;

                                    for (var i = 0; i < length; i++) {
                                        ///////////////////////////////////////////////////////////////////////////////////////////////////////
                                        //// PRICE FIXES ////////////////////////////////////////////////////////////////////////////////////////////
                                        if (cart.items[i].RecurringCharge) {
                                            monthlyTotalPrice += parseFloat(cart.items[i].RecurringCharge);
                                            $scope.scopeData.productSelection.cart.items[i].RecurringCharge = parseFloat(cart.items[i].RecurringCharge).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                                        }
                                        if (cart.items[i].OneTimeCharge) {
                                            oneTimeTotalPrice += parseFloat(cart.items[i].OneTimeCharge);
                                            $scope.scopeData.productSelection.cart.items[i].OneTimeCharge = parseFloat(cart.items[i].OneTimeCharge).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                                        }
                                        if (cart.items[i].SinglePlanCharge) {
                                            $scope.scopeData.productSelection.cart.items[i].SinglePlanCharge = parseFloat(cart.items[i].SinglePlanCharge).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                                        }
                                        if (cart.items[i].OTSinglePlanCharge) {
                                            $scope.scopeData.productSelection.cart.items[i].OTSinglePlanCharge = parseFloat(cart.items[i].OTSinglePlanCharge).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////////////////////
                                        ///////////////////////////////////////////////////////////////////////////////////////////////////////

                                        ///////////////////////////////////////////////////////////////////////////////////////////////////////
                                        //// TAXES ////////////////////////////////////////////////////////////////////////////////////////////
                                        if (cart.items[i].Taxes && (cart.items[i].RecurringCharge || cart.items[i].OneTimeCharge)) {
                                            var taxes = cart.items[i].Taxes.split(";");
                                            if (taxes.length > 0) {
                                                var taxItems = taxes[0].split(":");
                                                if (taxItems.length > 0) {
                                                    $scope.scopeData.productSelection.cart.items[i].IsThereTax = true;
                                                    $scope.scopeData.productSelection.cart.items[i].TaxType = taxItems[1] == "Percent" ? taxItems[0] + " (% " + taxItems[2] + ")" : taxItems[0];
                                                    $scope.scopeData.productSelection.cart.items[i].RecurringTaxAmount = taxItems[1] == "Percent" ? parseFloat((cart.items[i].RecurringCharge).replace(/\,/g, '') * taxItems[2] * 0.01).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') : taxItems[2];
                                                    $scope.scopeData.productSelection.cart.items[i].OneTimeTaxAmount = taxItems[1] == "Percent" ? parseFloat((cart.items[i].OneTimeCharge).replace(/\,/g, '') * taxItems[2] * 0.01).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') : taxItems[2];
                                                    monthlyTotalTax += taxItems[1] == "Percent" ? ((cart.items[i].RecurringCharge).replace(/\,/g, '') * taxItems[2] * 0.01) : taxItems[2];
                                                    oneTimeTotalTax += taxItems[1] == "Percent" ? ((cart.items[i].OneTimeCharge).replace(/\,/g, '') * taxItems[2] * 0.01) : taxItems[2];
                                                }
                                            }
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////////////////////
                                        ///////////////////////////////////////////////////////////////////////////////////////////////////////

                                        if (i === orderToBeChecked && cart.items[i].ParentOrderItemId === GuidEmpty) {
                                            $scope.scopeData.productSelection.cart.family1.items[0] = cart.items[i];
                                            orderToBeChecked = null;
                                        }
                                        else if (i === orderToBeChecked && cart.items[i].ParentOrderItemId != GuidEmpty) {
                                            cart.items[length] = cart.items[i];
                                            orderToBeChecked++;
                                            length++;
                                        }
                                        else if (cart.items[i].ParentOrderItemId === $scope.scopeData.productSelection.cart.family1.items[0].guid) {
                                            family1Length = $scope.scopeData.productSelection.cart.family1.items.length;
                                            $scope.scopeData.productSelection.cart.family1.items[family1Length] = cart.items[i];
                                        }
                                        else if (cart.items[i].ParentOrderItemId === GuidEmpty && startFamily2) {
                                            $scope.scopeData.productSelection.cart.family2.items[0] = cart.items[i];
                                            startFamily2 = false;
                                        }
                                        else if ($scope.scopeData.productSelection.cart.family2.items.length > 0 && cart.items[i].ParentOrderItemId === $scope.scopeData.productSelection.cart.family2.items[0].guid) {
                                            family2Length = $scope.scopeData.productSelection.cart.family2.items.length;
                                            $scope.scopeData.productSelection.cart.family2.items[family2Length] = cart.items[i];
                                        }
                                        else if (cart.items[i].ParentOrderItemId === GuidEmpty && startFamily3) {
                                            $scope.scopeData.productSelection.cart.family3.items[0] = cart.items[i];
                                            startFamily3 = false;
                                        }
                                        else if ($scope.scopeData.productSelection.cart.family3.items.length > 0 && cart.items[i].ParentOrderItemId === $scope.scopeData.productSelection.cart.family3.items[0].guid) {
                                            family3Length = $scope.scopeData.productSelection.cart.family3.items.length;
                                            $scope.scopeData.productSelection.cart.family3.items[family3Length] = cart.items[i];
                                        }
                                        else if (cart.items[i].ParentOrderItemId === GuidEmpty) {
                                            $scope.scopeData.productSelection.cart.family4.items[0] = cart.items[i];
                                        }
                                        else if ($scope.scopeData.productSelection.cart.family4.items.length > 0 && cart.items[i].ParentOrderItemId === $scope.scopeData.productSelection.cart.family4.items[0].guid) {
                                            family4Length = $scope.scopeData.productSelection.cart.family4.items.length;
                                            $scope.scopeData.productSelection.cart.family4.items[family4Length] = cart.items[i];
                                        }
                                        else {
                                            family1Length = $scope.scopeData.productSelection.cart.family1.items.length;
                                            for (var j = 1; j < family1Length; j++) {
                                                if ($scope.scopeData.productSelection.cart.family1.items[j] && cart.items[i].ParentOrderItemId === $scope.scopeData.productSelection.cart.family1.items[j].guid) {
                                                    $scope.scopeData.productSelection.cart.family1.items[family1Length] = cart.items[i];
                                                    break;
                                                }
                                            }

                                            family2Length = $scope.scopeData.productSelection.cart.family2.items.length;
                                            for (var j = 1; j < family2Length; j++) {
                                                if ($scope.scopeData.productSelection.cart.family2.items[j] && cart.items[i].ParentOrderItemId === $scope.scopeData.productSelection.cart.family2.items[j].guid) {
                                                    $scope.scopeData.productSelection.cart.family2.items[family2Length] = cart.items[i];
                                                    break;
                                                }
                                            }

                                            family3Length = $scope.scopeData.productSelection.cart.family3.items.length;
                                            for (var j = 1; j < family3Length; j++) {
                                                if ($scope.scopeData.productSelection.cart.family3.items[j] && cart.items[i].ParentOrderItemId === $scope.scopeData.productSelection.cart.family3.items[j].guid) {
                                                    $scope.scopeData.productSelection.cart.family3.items[family3Length] = cart.items[i];
                                                    break;
                                                }
                                            }

                                            family4Length = $scope.scopeData.productSelection.cart.family4.items.length;
                                            for (var j = 1; j < family4Length; j++) {
                                                if ($scope.scopeData.productSelection.cart.family4.items[j] && cart.items[i].ParentOrderItemId === $scope.scopeData.productSelection.cart.family4.items[j].guid) {
                                                    $scope.scopeData.productSelection.cart.family4.items[family4Length] = cart.items[i];
                                                    break;
                                                }
                                            }
                                        }

                                    }

                                    $scope.scopeData.productSelection.monthlyTotalPrice = parseFloat(monthlyTotalPrice).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                                    $scope.scopeData.productSelection.oneTimeTotalPrice = parseFloat(oneTimeTotalPrice).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                                    $scope.scopeData.productSelection.monthlyTotalTax = parseFloat(monthlyTotalTax).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                                    $scope.scopeData.productSelection.oneTimeTotalTax = parseFloat(oneTimeTotalTax).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');

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

                    return deferred.promise;
                },
                getCustomerProductsFromSR: function () {
                    var uri = "http://172.18.88.73:7005/eoc/sr/v1/product/?relatedParties.reference=" + $scope.scopeData.productSelection.customerExternalId + "&relatedParties.role=Customer";
                    var workflowStartInput = {
                        "uri": uri
                    };

                    $http.post(apiUrl + 'AmxCoGetCustomerProductsFromSR', JSON.stringify(workflowStartInput), config)
                        .success(function (result) {

                            if (result) {
                                $scope.scopeData.productSelection.products = result.Output.srCustomerProductsResponse;
                                $scope.scopeData.productSelection.addCustomerProductsToCart(result.Output.srCustomerProductsResponse);
                            }
                        }).error(function (data, status, headers, config) {
                            alert($scope.scopeData.productSelection.translations.tSrWarning);
                            /* alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                            */

                            $scope.httpLoading = false;
                        });
                },
                getStratumByAddressId: function (addressId) {

                    var workflowStartInput = { "addressId": addressId };
                    $http.post(apiUrl + 'AmxCoGetStratumByAddressId', JSON.stringify(workflowStartInput), config)
                        .success(function (result) {

                            if (result) {
                                $scope.scopeData.productSelection.selectedAddressStratum = result.Output.stratum;
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                            $scope.httpLoading = false;
                        });
                },
                getCustomerExternalId: function () {
                    var individualCustomerGuid;
                    var lookupObj = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
                    if (lookupObj) {
                        individualCustomerGuid = lookupObj[0].id;
                    }

                    var req = new XMLHttpRequest();
                    var select = "/api/data/v8.2/contacts?$select=etel_externalid&$filter=contactid eq " + individualCustomerGuid.substring(1).substring(0, 36);
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

                                if (results.value[0].etel_externalid) {
                                    $scope.scopeData.productSelection.customerExternalId = results.value[0].etel_externalid;
                                }
                            }
                        }
                    };
                    req.send();
                },
                getCustomerAddress: function () {
                    var contactGuid, lookupRecordName;
                    var lookupObj = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
                    if (lookupObj) {
                        var lookupEntityType = lookupObj[0].entityType;
                        contactGuid = lookupObj[0].id;
                        lookupRecordName = lookupObj[0].name;
                    }
                    var customerGuidFormattedString = contactGuid.toString().substr(1).slice(0, -1);
                    var req = new XMLHttpRequest();
                    req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_customeraddresses?$select=_amx_cityarea_value,_amxperu_district_value,_etel_cityid_value,etel_customeraddressid,_etel_individualcustomerid_value,etel_name,amx_addressusagecode&$orderby=_amxperu_district_value desc&$filter=_etel_individualcustomerid_value eq " + customerGuidFormattedString, false);
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
                                $scope.scopeData.productSelection.customerAddresses = [];

                                for (var i = 0; i < results.value.length; i++) {

                                    var amx_addressusagecode = results.value[i]["amx_addressusagecode"];
                                    if (amx_addressusagecode && amx_addressusagecode.indexOf("173800002") >=0) {

                                        var _amx_cityarea_value = results.value[i]["_amx_cityarea_value"];
                                        var _amx_cityarea_value_formatted = results.value[i]["_amx_cityarea_value@OData.Community.Display.V1.FormattedValue"];
                                        var _amx_cityarea_value_lookuplogicalname = results.value[i]["_amx_cityarea_value@Microsoft.Dynamics.CRM.lookuplogicalname"];
                                        var _amxperu_district_value = results.value[i]["_amxperu_district_value"];
                                        var _amxperu_district_value_formatted = results.value[i]["_amxperu_district_value@OData.Community.Display.V1.FormattedValue"];
                                        var _amxperu_district_value_lookuplogicalname = results.value[i]["_amxperu_district_value@Microsoft.Dynamics.CRM.lookuplogicalname"];
                                        var _etel_cityid_value = results.value[i]["_etel_cityid_value"];
                                        var _etel_cityid_value_formatted = results.value[i]["_etel_cityid_value@OData.Community.Display.V1.FormattedValue"];
                                        var _etel_cityid_value_lookuplogicalname = results.value[i]["_etel_cityid_value@Microsoft.Dynamics.CRM.lookuplogicalname"];
                                        var etel_customeraddressid = results.value[i]["etel_customeraddressid"];
                                        var _etel_individualcustomerid_value = results.value[i]["_etel_individualcustomerid_value"];
                                        var _etel_individualcustomerid_value_formatted = results.value[i]["_etel_individualcustomerid_value@OData.Community.Display.V1.FormattedValue"];
                                        var _etel_individualcustomerid_value_lookuplogicalname = results.value[i]["_etel_individualcustomerid_value@Microsoft.Dynamics.CRM.lookuplogicalname"];
                                        var etel_name = results.value[i]["etel_name"];
                                        var nameArr = etel_name.split('-');
                                        $scope.scopeData.productSelection.customerAddresses.push({
                                            "AddressName": etel_name,
                                            "AddressId": etel_customeraddressid,
                                            "District": _amxperu_district_value_formatted,
                                            "City": _etel_cityid_value_formatted,
                                            "CityArea": _amx_cityarea_value_formatted,
                                            "IgacAddress": nameArr.length > 1 ? nameArr[1] : "",
                                        });

                                        if (results.value.length === 1) {
                                            $scope.scopeData.productSelection.selectCustomerAddress($scope.scopeData.productSelection.customerAddresses[0], true);
                                        }
                                        else {
                                            // TO DO : update function with promise
                                            $scope.scopeData.productSelection.checkOrderCaptureSelectedAddressId();
                                        }
                                    }
                                }
                            } else {
                                Xrm.Utility.alertDialog(this.statusText);
                            }
                        }
                    };
                    req.send();
                },
                findPOAndToBasket: function (cartItemAdditionInputModel) {
                    var req = new XMLHttpRequest();
                    req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/products?$select=name&$filter=etel_externalid eq '" + cartItemAdditionInputModel.poExternalId + "'", false);
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

                                if (results.value[0].productid) {
                                    var promise = $scope.scopeData.productSelection.addOfferToShoppingCart(results.value[0].productid, GuidEmpty, cartItemAdditionInputModel);
                                    promise.then(function () { $scope.scopeData.productSelection.getOrderBasket(); });
                                }
                            }
                        }
                    };
                    req.send();
                },
                filterProducts: function () {
                    $scope.scopeData.productSelection.availableAddons = $scope.scopeData.productSelection.availableAddonsBackup;
                    var filteredProducts = {}; 
                    var length = $scope.scopeData.productSelection.availableAddons.length;
                    var t = 0;
                    for (var i = 0; i < length; i++) {
                        if ($scope.scopeData.productSelection.availableAddons[i].SubOfferingTypeCode === '10' || $scope.scopeData.productSelection.availableAddons[i].OfferingName.toUpperCase().indexOf($scope.scopeData.productSelection.filter.toUpperCase()) >= 0) {
                            filteredProducts[t] = $scope.scopeData.productSelection.availableAddons[i];
                            t++;
                        }
                    }
                    $scope.scopeData.productSelection.availableAddons = filteredProducts;
                },
                internalListsCheck: function (cId) {
                    var config = {
                        withCredentials: true
                    };

                    $scope.workflowGetInternalListsInput = {
                        "individualCustomerId": cId
                    };

                    $http.post(apiUrl + 'AmxCoGetInfoLists', JSON.stringify($scope.workflowGetInternalListsInput), config)
                        .success(function (result) {
                            if (result) {
                                var listresponse = result.Output.response;
                                if (listresponse.clientes || listresponse.telefonos || listresponse.correos) {
                                    if (confirm("Cliente con marca de fraude! No se puede continuar con la venta. Cliente desea escalar caso?")) {
                                        $scope.scopeData.productSelection.closeOrder = true;
                                        $scope.scopeData.productSelection.createCaseInternalLists(cId);
                                        return;
                                    } else {
                                        $scope.scopeData.productSelection.closeOrder = false;
                                        return;
                                    }
                                }
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                            $scope.httpLoading = false;
                        });

                },
                createCaseInternalLists: function (cId) {
                    var customerId = cId;
                    //customerId = customerId[0].id;
                    var req = new XMLHttpRequest();
                    req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/contacts(" + customerId.replace("{", "").replace("}", "") + ")?$select=amxperu_documenttype,etel_iddocumentnumber,emailaddress1,mobilephone", false);
                    req.setRequestHeader("OData-MaxVersion", "4.0");
                    req.setRequestHeader("OData-Version", "4.0");
                    req.setRequestHeader("Accept", "application/json");
                    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                    req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                    req.onreadystatechange = function () {
                        if (this.readyState === 4) {
                            req.onreadystatechange = null;
                            if (this.status === 200) {
                                var result = JSON.parse(this.response);
                                var documentType = result["amxperu_documenttype"];
                                var documentNumber = result["etel_iddocumentnumber"];
                                var email = result["emailaddress1"];
                                var telephone = result["mobilephone"];
                                customerId = customerId.replace("{", "").replace("}", "");
                                var description = "Tipo de documento del cliente: " + documentType + " número: " + documentNumber + "; E-mail : " + email
                                    + "; Teléfono: " + telephone;
                                var parameters = {};
                                parameters["description"] = description;
                                //parameters["customerid"] = customerId;
                                //parameters["amxperu_casetype"] = "Prevención Fraude";
                                var windowOptions = {
                                    openInNewWindow: true
                                };
                                Xrm.Utility.openEntityForm("incident", null, parameters, windowOptions);
                            } else {
                                Xrm.Utility.alertDialog(this.statusText);
                            }
                        }
                    };
                    req.send();
                },
                cancelOrder: function () {
                    var orderCaptureId = Xrm.Page.data.entity.getId().substring(1).substring(0, 36);
                    var entity = {};
                    entity.statecode = 0; //Active
                    entity.statuscode = 831260011; //Cancelled
                    entity.amx_cancelreason = 5; // Verificacion de identidad no exitosa
                    AMX.COMMON.UpdateEntityWebApi("etel_ordercaptures", orderCaptureId, entity, function (sData) { }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false); 
                },
                redirectTo360View: function () {
                    var etel_individualcustomerid = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
                    if (etel_individualcustomerid != null) {
                        Xrm.Utility.openEntityForm("contact", etel_individualcustomerid[0].id);
                    }
                },
                homeAppointmentCheck: function (cId) {
                    try {
                        console.log("inicia validarVisitaDomiciliaria");
                        var minReliability = 0;
                        var isHome = true;
                        var viability = true;
                        var reliability = 0;

                        var configReliability = $scope.scopeData.productSelection.GetEntityRecords("etel_crmconfiguration", null, "etel_value", "etel_name eq 'minAddressReliability' ", false, null, null, null);
                        if (configReliability !== null) {
                            if (configReliability.length > 0) {
                                minReliability = configReliability[0].etel_value;
                            }
                        }
                        var address = $scope.scopeData.productSelection.GetEntityRecords("etel_customeraddress", $scope.scopeData.productSelection.selectedAddressId, "amx_AddressID", null, false, null, null, null);
                        var customAddressId = 0;
                        if (address !== null) {
                            if (address.length > 0) {
                                customAddressId = address[0].amx_AddressID;
                            }
                        }

                        var config = {
                            withCredentials: true
                        };
                        
                        $scope.workflowGetAddressTechDetails = {
                            "addressMGLRequest":
                            {
                                "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails, AmxPeruPSBActivities",
                                "idDireccion": customAddressId, "segmento": "", "residencial": "", "proyecto": "",
                            }
                        };
                        
                        $http.post(apiUrl + 'AMXRetrieveCustomerAddressMGLTechDetails', JSON.stringify($scope.workflowGetAddressTechDetails), config)
                            .success(function (result) {
                                if (result) {
                                    console.log("result.Output.addressMGLResponse: " + result.Output.addressMGLResponse);
                                    var resultJson = JSON.parse(result.Output.addressMGLResponse);
                                    console.log("resultJson" + resultJson);
                                    if (resultJson.addresses != undefined) {
                                        reliability = resultJson.addresses.adressReliability;
                                        if (resultJson.addresses.listHhpps.length > 0) {
                                            for (var i = 0; i < resultJson.addresses.listHhpps.length; i++) {
                                                var hhpp = resultJson.addresses.listHhpps[i];
                                                console.log("resultado de viabilidad: " + hhpp.viability.ResultadoValidacion);
                                                if (hhpp.viability.ResultadoValidacion !== true) {
                                                    viability = false;
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                    console.log("La condición de ingreso mensaje:");
                                    console.log("isHome: " + isHome);
                                    console.log("reliability < minReliability: " + reliability + " < " + minReliability);
                                    console.log("!viability: !" + viability);
                                    if ((isHome) && (reliability < minReliability) || (!viability)) {
                                        var validityAppointmentDays = $scope.scopeData.productSelection.GetEntityRecords("etel_crmconfiguration", null, "etel_value", "etel_name eq 'validityHomeAppointment' ", false, null, null, null);
                                        var qryMinDate = "1900-01-01T00:00:00";
                                        console.log("variable validityAppointmentDays: " + validityAppointmentDays[0].etel_value);
                                        if (validityAppointmentDays !== null) {
                                            if (validityAppointmentDays.length > 0) {
                                                var minDate = new Date();
                                                minDate.setDate(minDate.getDate() - validityAppointmentDays[0].etel_value);
                                                qryMinDate = minDate.toISOString().substring(0, 19);
                                                console.log("qryMinDate calculado: " + qryMinDate);
                                            }
                                        }
                                        var appointments = $scope.scopeData.productSelection.GetEntityRecords("etel_appointmentlog", null, "etel_AppointmentStatus,etel_appointmentdate", "etel_individualcustomerid/Id eq (guid'" + cId + "') and etel_AppointmentStatus/Value eq 831260008 and etel_appointmentdate gt DateTime'" + qryMinDate + "'", false, null, null, null);
                                        if (appointments === null) {
                                            Alert.show("ALTO RIESGO! <br />" + "Es necesario realizar visita domiciliaria. <br /><br />" +
                                                "¿El cliente está de acuerdo con la visita?", "", [new Alert.Button("Aceptar", function () {
                                                    $scope.scopeData.productSelection.createCaseHomeAppointment(cId);
                                                    $scope.scopeData.productSelection.createHomeAppointment();
                                                }, false, false), new Alert.Button("Rechazar", function () {
                                                    alert("¿El cliente desea continuar con una venta sin visita domiciliaria? Nota: si no acepta, por favor cancele la orden");
                                                }, false, false)], "INFO", 500, 200);
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
                        alert("validarVisitaDomiciliaria: " + err.message);
                    }
                },
                createHomeAppointment: function() {
                    try {
                        var appointmentURL = parent.Xrm.Page.context.getClientUrl() + "/WebResources/amxperu_/NewSubscription/templates/appointment.htm";//?data=individualCustomerId%3d" + individualCustomerId;

                        if (navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0) {
                            /* Microsoft Internet Explorer detected in. */
                            var sFeatures = "dialogHeight: 580px;dialogWidth: 840px"
                            window.showModalDialog(appointmentURL, "", sFeatures);
                        }
                        else {
                            var w = 840;
                            var h = 580;
                            var left = (screen.width / 2) - (w / 2);
                            var top = (screen.height / 2) - (h / 2);
                            popupWindow = window.open(appointmentURL, "Agendar cita", "directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=" + w + ", height=" + h + ", top=" + top + ", left=" + left);
                        }
                    }
                    catch (err) {
                        alert("createHomeAppointment: " + err.message);
                    }
                },
                createCaseHomeAppointment: function (cId) {
                    try {
                        /*var orderCaptureId = parent.Xrm.Page.data.entity.getId().substring(1).substring(0, 36);
                        var msnDescription;
                        var individual = $scope.scopeData.productSelection.GetEntityRecords("Contact", cId, "FullName,etel_iddocumentnumber", null, false, null, null, null);
                        if (individual !== null) {
                            if (individual.length > 0) {
                                msnDescription = individual[0].FullName + " Documento número: " + individual[0].etel_iddocumentnumber;
                                console.log("msnDescription 1: " + msnDescription);
                            }
                        }
                        var entity = {};
                        entity.title = "Caso visita domiciliaria";
                        entity.description = msnDescription + "Dirección: " + $scope.scopeData.productSelection.selectedAddressName;
                        entity["amx_ordercapture@odata.bind"] = "/etel_ordercaptures(" + orderCaptureId + ")";
                        entity["etel_customercontactid@odata.bind"] = "/contacts(" + cId.replace("{", "").replace("}", "") + ")";
                        //entity["primarycontactid@odata.bind"] = "/contacts(" + cId.replace("{", "").replace("}", "") + ")";
                        var req = new XMLHttpRequest();
                        req.open("POST", parent.Xrm.Page.context.getClientUrl() + "/api/data/v8.2/incidents", false);
                        req.setRequestHeader("OData-MaxVersion", "4.0");
                        req.setRequestHeader("OData-Version", "4.0");
                        req.setRequestHeader("Accept", "application/json");
                        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                        console.log("entity caseHomeAppointment " + entity);
                        req.onreadystatechange = function () {
                            if (this.readyState === 4) {
                                req.onreadystatechange = null;
                                if (this.status === 204) {
                                    var uri = this.getResponseHeader("OData-EntityId");
                                    console.log("uri - EntityId caseHomeAppointment " + uri);
                                    var regExp = /\(([^)]+)\)/;
                                    var matches = regExp.exec(uri);
                                    var newEntityId = matches[1];
                                    //var windowOptions = { openInNewWindow: true };
                                    //Xrm.Utility.openEntityForm("etel_customeraddress", newEntityId, null, windowOptions);
                                } else {
                                    console.log("Xrm.Utility.alertDialog caseHomeAppointment " + this.statusText);
                                    Xrm.Utility.alertDialog(this.statusText);
                                }
                            }
                        };
                        console.log("req: " + req);
                        req.send(JSON.stringify(entity));*/

                        var entityId = Xrm.Page.data.entity.getId();
                        var entityName = Xrm.Page.data.entity.getEntityName();
                        var request = $scope.scopeData.productSelection.launchActionNoParams(entityId, entityName, "amx_ACOrderCaptureOrderCaptureCreateCaseCreditRisk");
                        if (request.status == 200) {
                            var entityIdIncident = request.responseXML.childNodes[0].textContent;
                            if (entityIdIncident != null && entityIdIncident != undefined) {
                                entityIdIncident = entityIdIncident.replace("amx_ACOrderCaptureOrderCaptureCreateCaseCreditRisk", "");
                                entityIdIncident = entityIdIncident.replace("incidentid", "");
                                console.log("entityIdIncident: " + entityIdIncident);
                                //Xrm.Utility.openEntityForm("incident", entityIdIncident);
                            }
                            else {
                                Xrm.Page.ui.setFormNotification('Se genero un error en el proceso de creación del caso.', 'ERROR', 'msg_Action');
                            }
                        } else {
                            var error = ProcessSoapError(request.responseXML);
                            Xrm.Page.ui.setFormNotification('' + error, 'ERROR', 'msg_Action');
                        }
                    }
                    catch (err) {
                        alert("createCaseHomeAppointment: " + err.message);
                    }                    
                },
                isParentOfferingInBasket: function (parentOfferingId) {

                    var length = $scope.scopeData.productSelection.cart.items.length;

                    for (var i = 0; i < length; i++) {
                        if ($scope.scopeData.productSelection.cart.items[i].offeringGuid === parentOfferingId) {
                            return true;
                        }
                    }
                    return false;
                },
                plansCartOperations: function (addon) {

                    if ($scope.scopeData.productSelection.warnIfAddressNotSelected())
                        return;

                    if ($scope.scopeData.productSelection.selectedBasicOffering === "TEL") {
                        $scope.scopeData.productSelection.firstLineTelSelected = true;
                    }

                    $scope.scopeData.productSelection.numberOfBasicOffers++;

                    var parentOrderItemId = GuidEmpty;
                    var viewedCartItem;
                    var length = $scope.scopeData.productSelection.cart.items.length;
                    var parentOrderItemOfferingRelation = {};
                    var index = 0;
                    var cartItemAdditionInputModel = {
                        srProductId: "",
                        srParentPoId: "",
                        orderItemAction: "1",
                        recurringPrice: addon.RecurringPrice ? "" + addon.RecurringPrice + "" : "",
                        oneTimePrice: addon.OneTimePrice ? "" + addon.OneTimePrice + "" : "",
                        popExternalId: addon.Recurring ? addon.Recurring[0].PopExternalId : ""
                    }
                    $scope.scopeData.productSelection.showAddons = true;

                    var isParentOfferingInBasket = $scope.scopeData.productSelection.isParentOfferingInBasket($scope.scopeData.productSelection.selectedBasicOfferingId);

                    if (length === 0 || !isParentOfferingInBasket || $scope.scopeData.productSelection.selectedBasicOffering === "MOV") {

                        $scope.scopeData.productSelection.numberOfBasicOffers++;
                        if ($scope.scopeData.productSelection.numberOfBasicOffers == 2) {
                            $scope.scopeData.productSelection.runBureauCreditAnalysis();
                            if ($scope.scopeData.productSelection.closeOrder) {
                                return;
                            }
                        }
                        basicOfferingId = $scope.scopeData.productSelection.selectedBasicOfferingId;
                        var promise = $scope.scopeData.productSelection.addOfferToShoppingCart(basicOfferingId, GuidEmpty);
                        promise.then(function () {
                            var promise2 = $scope.scopeData.productSelection.addOfferToShoppingCart(addon.OfferingId, $scope.scopeData.productSelection.parentOrderItemId, cartItemAdditionInputModel);
                            promise2.then(function () {
                                $scope.scopeData.productSelection.calculateMultiPlayPrices();
                            });
                        });

                    }
                    else {
                        for (var t = 0; t < length; t++) {

                            viewedCartItem = $scope.scopeData.productSelection.cart.items[t];

                            if (viewedCartItem.ParentOrder) {
                                parentOrderItemId = viewedCartItem.guid;
                                parentOrderItemOfferingId = viewedCartItem.offeringGuid;
                                parentOrderItemOfferingRelation[parentOrderItemId] = parentOrderItemOfferingId;
                            }

                            if ((addon.LDILDNOffering && viewedCartItem.name.indexOf("LDILDN") >= 0) || (viewedCartItem.OfferTypeCode === "10" && viewedCartItem.OrderItemAction != "Delete" && parentOrderItemOfferingRelation[viewedCartItem.ParentOrderItemId] === addon.ParentOfferingGuid && !addon.LDILDNOffering)) {

                                viewedCartItem.checkToRemove = !addon.LDILDNOffering;
                                if (viewedCartItem.offeringGuid != addon.OfferingId) {
                                    if (viewedCartItem.SRProductId != "") {
                                        $scope.scopeData.productSelection.updateOrderItemAction(viewedCartItem.guid, "4");
                                    }
                                    else {
                                        $scope.scopeData.productSelection.removeFromBasket(viewedCartItem);
                                    }
                                    var promise3 = $scope.scopeData.productSelection.addOfferToShoppingCart(addon.OfferingId, viewedCartItem.ParentOrderItemId, cartItemAdditionInputModel);
                                    promise3.then(function () {
                                        $scope.scopeData.productSelection.calculateMultiPlayPrices();
                                    });
                                }
                                return;
                            }
                        }

                        // if arrives here there is no item matched in basket realized during LDILDN 12.01
                        if (addon.LDILDNOffering) {

                            var promise4 = $scope.scopeData.productSelection.addOfferToShoppingCart(addon.OfferingId, $scope.scopeData.productSelection.parentOrderItemId, cartItemAdditionInputModel);
                            promise4.then(function () {
                                $scope.scopeData.productSelection.calculateMultiPlayPrices();
                            });
                        }

                    }

                },
                redesignBasicOfferingsWithTechnology: function (selectedAddressTechnology) {
                    var basicOfferingList = $scope.scopeData.productSelection.basicOfferingList;
                    var basicOfferingLength = $scope.scopeData.productSelection.basicOfferingList? $scope.scopeData.productSelection.basicOfferingList.length : 0;
                    for (var i = 0; i < basicOfferingLength; i++) {
                        basicOfferingList[i].IsSellable = false;
                        if (basicOfferingList[i].Family === "MOV") {
                            basicOfferingList[i].IsSellable = true;
                        }
                        addressTechList = selectedAddressTechnology.split(";");

                        for (var j = 0; j < addressTechList.length - 1; j++) {

                            if (basicOfferingList[i].Technology.indexOf(addressTechList[j]) >= 0) {
                                basicOfferingList[i].IsSellable = true;
                            }
                        }
                    }
                    $scope.scopeData.productSelection.basicOfferingList = basicOfferingList;
                },
                redesignAddonsWithTechnology: function (selectedAddressTechnology) {
                    var addOnList = $scope.scopeData.productSelection.availableAddons;
                    var addOnLength = $scope.scopeData.productSelection.availableAddons ? $scope.scopeData.productSelection.availableAddons.length : 0;
                    for (var i = 0; i < addOnLength; i++) {
                        addOnList[i].IsSellable = false;
                        if ($scope.scopeData.productSelection.selectedBasicOffering === "MOV") {
                            addOnList[i].IsSellable = true;
                        }
                        addressTechList = selectedAddressTechnology.split(";");

                        for (var j = 0; j < addressTechList.length - 1; j++) {

                            if (addOnList[i].Technology.indexOf(addressTechList[j]) >= 0) {
                                addOnList[i].IsSellable = true;
                            }
                        }
                    }
                    $scope.scopeData.productSelection.availableAddons = addOnList;
                },
                runBureauCreditAnalysis: function () {
                    // eheldma: Run Bureau credit analysis
                    //if (!confirm('Execute credit analysis and authentication?')) {
                    //    return;
                    //}
                    if (bureauOK) {
                        alert("Credit analysis already performed");
                        return;
                    }

                    var lookupObj = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
                    if (lookupObj) {
                        var customerID = lookupObj[0].id;
                    }

                    // In case it is not a prepaid, do all verifications

                    if ($scope.scopeData.productSelection.selectedBasicOffering !== "MOV") {

                        // Run Internal Lists
                        $scope.scopeData.productSelection.internalListsCheck(customerID);
                        if ($scope.scopeData.productSelection.closeOrder) {
                            $scope.scopeData.productSelection.cancelOrder();
                            $scope.scopeData.productSelection.redirectTo360View();
                            return;
                        }

                        // Run Bureau de Credito
                        $scope.scopeData.productSelection.creditBureauCheck(customerID);
                        
                        // Run Sarglaft analysis
                        $scope.scopeData.productSelection.sarglaftCheck(lookupObj[0].name);

                        // Run Evidente Authenthication
                        $scope.scopeData.productSelection.evidenteCheck(customerID);

                    } else {

                        // Check customer information (last name, document and issue date)
                        var promise = $scope.scopeData.productSelection.checkCustomerInformation(customerID);
                        //if ($scope.scopeData.productSelection.closeOrder) {
                        //   $scope.scopeData.productSelection.cancelOrder();
                        //   $scope.scopeData.productSelection.redirectTo360View();
                        //   return;
                        //}

                        // Run Internal Lists
                        promise.then(function () {
                            if ($scope.scopeData.productSelection.closeOrder) {
                                $scope.scopeData.productSelection.cancelOrder();
                                $scope.scopeData.productSelection.redirectTo360View();
                                return;
                            }
                            $scope.scopeData.productSelection.getBIHeader();
                            $scope.scopeData.productSelection.internalListsCheck(customerID);
                            //if ($scope.scopeData.productSelection.closeOrder) {
                            //    $scope.scopeData.productSelection.cancelOrder();
                            //   $scope.scopeData.productSelection.redirectTo360View();
                            //   return;
                            //}
                            // Check if customer has recurrent service
                            $scope.scopeData.productSelection.contractsSearch(customerID);
                            return;
                        });

                    }

                    // Run home appointment
                    //$scope.scopeData.productSelection.homeAppointmentCheck(customerID);
                },
                removeCheck: function (itemToCheck) {

                    var length = $scope.scopeData.productSelection.cart.items.length;
                    var viewedCartItem;
                    var basicOfferingLength = 0;
                    itemToCheck.checkToRemove = true;
                    var isRemovedItemPermanencia = (itemToCheck.name.indexOf("Permanencia") >= 0);
                    /*
                    if (itemToCheck.Family === $scope.scopeData.productSelection.basicOfferingDictionary["MOV"]) {
                        itemToCheck.checkToRemove = false;
                    }
                    else if (itemToCheck.name.indexOf("LDILDN") >= 0) {
                        itemToCheck.checkToRemove = false;
                    }
                    */
                    itemToCheck.checkToRemove = !(itemToCheck.name.indexOf("LDILDN") >= 0);

                    for (var i = 0; i < length; i++) {
                        viewedCartItem = $scope.scopeData.productSelection.cart.items[i];
                        if (viewedCartItem.OfferTypeCode === itemToCheck.OfferTypeCode && viewedCartItem.ParentOrderItemId === itemToCheck.ParentOrderItemId && viewedCartItem.OrderItemAction === "Delete") {
                            $scope.scopeData.productSelection.updateOrderItemAction(viewedCartItem.guid, "3"); // No_change
                        }
                        if (viewedCartItem.ParentOrderItemId === GuidEmpty) {
                            basicOfferingLength++;
                        }
                    }
                    
                    if ($scope.scopeData.productSelection.basicOfferingDictionary["TEL"] === itemToCheck.Family) {
                        $scope.scopeData.productSelection.firstLineTelSelected = false;
                    }
                    
                    var promise = $scope.scopeData.productSelection.removeFromBasket(itemToCheck);
                    promise.then(function () { $scope.scopeData.productSelection.checkIfMultiPlayUpdateNeeded(basicOfferingLength, isRemovedItemPermanencia); });
                },
                removeFromBasket: function (itemToRemove) {
                    var deferred = $q.defer();
                    $scope.removeShoppingCartInputModel = {
                        "orderCaptureId": Xrm.Page.data.entity.getId().substring(1).substring(0, 36),
                        "orderItemId": itemToRemove.guid,
                        "checkToRemove": itemToRemove.checkToRemove
                    };
                    var config = {
                        withCredentials: true
                    };
                    $http.post(apiUrl + 'RemoveOrderItemFromBasket', JSON.stringify($scope.removeShoppingCartInputModel), config)
                        .success(function (result) {
                            if (result) {
                                $scope.scopeData.productSelection.cart.show = false;
                                $scope.scopeData.productSelection.getOrderBasket();
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
                    if (itemToRemove.OfferTypeCodeValue == "Basic Offer") {
                        $scope.scopeData.productSelection.numberOfBasicOffers--;
                    }
                    return deferred.promise;
                },
                retrieveBasicOfferings: function () {
                    var deferred = $q.defer();
                    var config = {
                        withCredentials: true
                    };
                    var workflowStartInput = {

                    };

                    $http.post(apiUrl + 'RetrieveBasicOfferings', JSON.stringify(workflowStartInput), config)
                        .success(function (result) {
                            $scope.scopeData.productSelection.basicOfferingList = result.Output.basicOfferingList;
                            deferred.resolve();
                        });
                    return deferred.promise;
                },
                revertCartPrices: function (isRemovedItemPermanencia) {
                    $scope.updateCartInputModel = {
                        "orderCaptureId": Xrm.Page.data.entity.getId().substring(1).substring(0, 36),
                        "isRemovedItemPermanencia": isRemovedItemPermanencia
                    };

                    $http.post(apiUrl + 'AmxCoRevertCartPrices', JSON.stringify($scope.updateCartInputModel), config)
                        .success(function (result) {
                            if (result) {
                                $scope.scopeData.productSelection.getOrderBasket();
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                        });
                },
                sarglaftCheck: function () {

                    try {
                        var individualCustomer = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();

                        var WorkflowUrlName = Xrm.Page.context.getClientUrlForInteractioncentricDashboard() + ":6004/api/v1/workflow/AmxCoSarglaftConsultLists";

                        var request = {
                            "FullName": individualCustomer[0].name,
                            "IndividualCustomerId": individualCustomer[0].id
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
                },                
                searchAssociatedOffers: function (parentOfferingId) {

                    var config = {
                        withCredentials: true
                    };
                    var selectedAddressStratum = $scope.scopeData.productSelection.selectedAddressStratum;

                    $scope.workflowStartInput = {
                        "parentOfferingId": parentOfferingId,
                        "estrato": selectedAddressStratum ? selectedAddressStratum : "1"
                    };

                    $http.post(apiUrl + 'RetrieveOptionalOfferings', JSON.stringify($scope.workflowStartInput), config)
                        .success(function (result) {

                            if (result) {

                                $scope.scopeData.productSelection.availableAddons = result.Output.optionalOfferingList;
                                $scope.scopeData.productSelection.availableAddonsBackup = $scope.scopeData.productSelection.availableAddons;
                                var length = $scope.scopeData.productSelection.availableAddons.length;
                                for (var i = 0; i < length; i++) {
                                    if ($scope.scopeData.productSelection.availableAddons[i].OneTime && $scope.scopeData.productSelection.availableAddons[i].OneTime[0].Amount) {
                                        $scope.scopeData.productSelection.availableAddons[i].OneTimePrice = parseFloat($scope.scopeData.productSelection.availableAddons[i].OneTime[0].Amount).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                                    }
                                    if ($scope.scopeData.productSelection.availableAddons[i].Recurring && $scope.scopeData.productSelection.availableAddons[i].Recurring[0].Amount) {
                                        $scope.scopeData.productSelection.availableAddons[i].RecurringPrice = parseFloat($scope.scopeData.productSelection.availableAddons[i].Recurring[0].Amount).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                                    }

                                    //////////////////////////////////////////////////////////////
                                    //// FOR LDILDN temporary /////////////////////////////////////
                                    if (($scope.scopeData.productSelection.selectedBasicOffering === "TEL" || $scope.scopeData.productSelection.selectedBasicOffering === "TEL2") && $scope.scopeData.productSelection.availableAddons[i].OfferingName.indexOf("LDILDN") >= 0) {
                                        // $scope.scopeData.productSelection.LDILDNOfferings[LDILDNIndex] = $scope.scopeData.productSelection.availableAddons[i];
                                        // LDILDNIndex++;
                                        $scope.scopeData.productSelection.availableAddons[i].LDILDNOffering = true;
                                    }
                                    //// FOR LDILDN temporary /////////////////////////////////////
                                    //////////////////////////////////////////////////////////////
                                }

                                if (selectedAddressTechnology = $scope.scopeData.productSelection.selectedAddressTechnology) {
                                    $scope.scopeData.productSelection.redesignAddonsWithTechnology(selectedAddressTechnology);
                                }
                                $scope.scopeData.productSelection.showPlans = false;
                            }
                        }).error(function (data, status, headers, config) {
                            alert($scope.scopeData.productSelection.translations.tOfferRetrieveWarning);
                            $scope.httpLoading = false;
                        }).finally(function () {
                            //$scope.httpLoading = false;
                        });
                },
                searchSecondLineTelephonyInBasket: function () {
                    var length = $scope.scopeData.productSelection.cart.items.length;
                    for (var i = 0; i < length; i++) {
                        if ($scope.scopeData.productSelection.cart.items[i].ParentOrder && $scope.scopeData.productSelection.cart.items[i].Family === $scope.scopeData.productSelection.basicOfferingDictionary["TEL2"]) {
                            return $scope.scopeData.productSelection.cart.items[i];
                        }
                    }
                    return null;
                },
                selectCustomerAddress: function (address, update) {
                    $scope.scopeData.productSelection.selectedAddressId = address.AddressId;
                    $scope.scopeData.productSelection.selectedAddressName = address.AddressName;

                    $rootScope.rootScopeData.customerInformation.SelectedAddress.AddressId = address.AddressId;
                    $rootScope.rootScopeData.customerInformation.SelectedAddress.AddressName = address.AddressName;

                    $rootScope.rootScopeData.customerInformation.AddressSelected = "Yes";
                    $scope.scopeData.productSelection.getStratumByAddressId($scope.scopeData.productSelection.selectedAddressId);

                    $scope.scopeData.productSelection.validateHHPPBusy(address.AddressId);
                    $scope.scopeData.productSelection.getAddressAvailableTechnology(address.AddressId);

                    if (update) {

                        // Saving address selected to order capture
                        $scope.updateAddressInput = {
                            "orderCaptureId": Xrm.Page.data.entity.getId().substring(1).substring(0, 36),
                            "addressId": address.AddressId
                        };
                        var config = {
                            withCredentials: true
                        };
                        $http.post(apiUrl + 'UpdateOrderAddress', JSON.stringify($scope.updateAddressInput), config);
                    }                    
                },
                selectedAddOns: function () {
                    var trues = $filter("filter")($scope.scopeData.productSelection.availableAddons, {
                        val: true
                    });
                    return trues;
                },
                updateSelection: function (position, entities) {
                    angular.forEach(entities, function (entity, index) {
                        if (position != index)
                            entity.checked = false;
                        else
                            entity.checked = true;
                    });
                },
                updateBasicOfferingSelection: function (position, entities) {
                    angular.forEach(entities, function (basicOffering, index) {
                        if (position != index)
                            basicOffering.checked = false;
                    });
                },
                getSequenceNumber: function () {
                    var customerId = Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].id.replace("{", "").replace("}", "");
                    var webApiSelectFilters = "etel_appointmentlogs?$select=amx_appointmentnumber,etel_name&$filter=_etel_individualcustomerid_value eq " + customerId + "&$orderby=createdon desc";
                    AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                        if (results.value.length == 0)
                        {
                            $rootScope.rootScopeData.order.sequenceNumber = "1";
                        }
                        else {
                            for (var i = 0; i < results.value.length; i++) {
                                var amx_appointmentnumber = results.value[i]["amx_appointmentnumber"];
                                amx_appointmentnumber = amx_appointmentnumber.substr(amx_appointmentnumber.lastIndexOf("_") + 1, amx_appointmentnumber.length);
                                $rootScope.rootScopeData.order.sequenceNumber = (parseInt(amx_appointmentnumber) + 1).toString();
                                break;
                            }
                        }
                    }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
                },
                updateOrderItemAction: function (orderItemId, nextAction) {
                    $scope.updateShoppingCartInputModel = {
                        "orderItemId": orderItemId,
                        "orderItemAction": nextAction
                    };

                    $http.post(apiUrl + 'AmxCoUpdateOrderItemAction', JSON.stringify($scope.updateShoppingCartInputModel), config)
                        .success(function (result) {
                            if (result) {
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                        });
                },
                customerBiographic: function (cId) {
                    var config = {
                        withCredentials: true
                    };

                    $scope.workflowCustomerBiographicInput = {
                        "individualCustomerId": cId
                    };

                    $http.post(apiUrl + 'CustomerBiographic', JSON.stringify($scope.workflowCustomerBiographicInput), config)
                        .success(function (result) {
                            if (result) {
                                var customerBiographicResponse = result.Output.response;
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                            $scope.httpLoading = false;
                        });
                },
                warnIfAddressNotSelected: function () {
                    if (!$scope.scopeData.productSelection.selectedAddressId) {
                        alert("You should select an address to advance!");
                        return true;
                    }
                    else if ($scope.scopeData.productSelection.selectedAddressId && !$scope.scopeData.productSelection.selectedAddressStratum) {
                        alert("Selected address doesn't have valid Stratum (Estrato)!");
                        return true;
                    }
                },
                validateHHPPBusy: function (addressId) {
                    
                    var address = $scope.scopeData.productSelection.GetEntityRecords("etel_customeraddress", addressId, "amx_AddressID", null, false, null, null, null);

                    if (address != null) {
                        if (address.length > 0) {
                            if (address[0].amx_AddressID != null && address[0].amx_AddressID != undefined) {
                                var workflowStartInput = {
                                    "addressMGLRequest":
                                    {
                                        "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails, AmxPeruPSBActivities",
                                        "idDireccion": address[0].amx_AddressID, "segmento": "", "residencial": "", "proyecto": "",
                                    }
                                };

                                jQuery.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    datatype: "json",
                                    data: JSON.stringify(workflowStartInput),
                                    async: false,
                                    cache: false,
                                    url: apiUrl + 'AMXRetrieveCustomerAddressMGLTechDetails',
                                    xhrFields: {
                                        withCredentials: true
                                    },
                                    beforeSend: function (XMLHttpRequest) {
                                        XMLHttpRequest.setRequestHeader("Accept", "application/json");
                                    },
                                    success: function (data, textStatus, XmlHttpRequest) {
                                        if (data) {
                                            
                                            var resultJsonOutput = new Array();
                                            var resultJson = JSON.parse(data.Output.addressMGLResponse);

                                            if (resultJson.addresses != undefined) {
                                                if (resultJson.addresses.listHhpps.length > 0) {
                                                    for (var i = 0; i < resultJson.addresses.listHhpps.length; i++) {
                                                        var hhpp = resultJson.addresses.listHhpps[i];

                                                        if (hhpp.subCcmmTechnology == undefined || hhpp.subCcmmTechnology == null) {
                                                            if (hhpp.state == "CS") {

                                                                Alert.show("El cliente ya tiene un servicio instalado en la dirección seleccionada. <br /><br />" +
                                                                    "Desea continuar con una compra que no requiera cobertura.", "", [new Alert.Button("Si", function () {
                                                                        $scope.scopeData.productSelection.createCaseReleaseHHPP(apiUrl);
                                                                    }, false, false), new Alert.Button("No", function () {
                                                                        $scope.scopeData.productSelection.createCaseReleaseHHPP(apiUrl);
                                                                    }, false, false)], "INFO", 800, 400);

                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    error: function (XmlHttpRequest, textStatus, errorThrown) {
                                        parent.Xrm.Utility.alertDialog((data.ExceptionMessage === undefined ?
                                            (data.data === undefined ? data :
                                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                                    }
                                });
                            }
                        }
                    }
                },
                createCaseReleaseHHPP: function () {
                    
                    if (parent.Xrm.Page.getAttribute("etel_individualcustomerid").getValue()) {
                        var individualId = parent.Xrm.Page.getAttribute("etel_individualcustomerid").getValue();

                        var workflowStartInput = {
                            "CreateCaseHHPPRequest":
                            {
                                "$type": "AmxPeruPSBActivities.Model.Case.AmxCoCreateCaseHHPPRequest, AmxPeruPSBActivities",
                                "individualId": individualId[0].id, "caseType": "CaseTypeReleaseHHPP", "description": "Solicitud de liberacion de HHPP."
                            }
                        };

                        jQuery.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            datatype: "json",
                            data: JSON.stringify(workflowStartInput),
                            async: false,
                            cache: false,
                            url: apiUrl + 'AmxCoCreateCaseHHPP',
                            xhrFields: {
                                withCredentials: true
                            },
                            beforeSend: function (XMLHttpRequest) {
                                XMLHttpRequest.setRequestHeader("Accept", "application/json");
                            },
                            success: function (data, textStatus, XmlHttpRequest) {
                                if (data) {
                                    
                                    var resultJson = data.Output.CreateCaseHHPPResponse;

                                    var daysReleaseHHPP = "0";
                                    var paramReleaseHHPP = $scope.scopeData.productSelection.GetEntityRecords("etel_crmconfiguration", null, "etel_value", "etel_name eq 'TimedayschangeHHPP' ", false, null, null, null);
                                    if (paramReleaseHHPP !== null) {
                                        if (paramReleaseHHPP.length > 0) {
                                            daysReleaseHHPP = paramReleaseHHPP[0].etel_value;
                                        }
                                    }                                    

                                    if (!resultJson.error) {
                                        Alert.show("Disculpe las molestias. Su dirección se presenta con servicios. Creamos el caso: " +
                                            resultJson.numberId + ". Nos comprometemos a liberar su dirección en " + daysReleaseHHPP + " días.", "",
                                            [new Alert.Button("Aceptar", function () {
                                                var recordId = Xrm.Page.data.entity.getId();
                                                
                                                var orderCapture = {};
                                                orderCapture.statuscode = { Value: 831260010 };
                                                orderCapture.amx_PostponeReason = { Value: 5 };

                                                $scope.scopeData.productSelection.updateRecord(
                                                    recordId,
                                                    orderCapture,
                                                    "etel_ordercapture",
                                                    function () {
                                                        var etel_individualcustomerid = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();

                                                        if (etel_individualcustomerid != null) {
                                                            Xrm.Utility.openEntityForm("contact", etel_individualcustomerid[0].id);
                                                        }
                                                    },
                                                    null
                                                );

                                            }, false, false)], "INFO", 800, 400);
                                    }
                                }
                            },
                            error: function (XmlHttpRequest, textStatus, errorThrown) {
                                parent.Xrm.Utility.alertDialog((data.ExceptionMessage === undefined ?
                                    (data.data === undefined ? data :
                                        (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                            }
                        });
                    }
                },
                updateRecord: function (id, object, type, successCallback, errorCallback) {
                    var req = new XMLHttpRequest();

                    req.open("POST", encodeURI(parent.Xrm.Page.context.getClientUrl() + "/XRMServices/2011/OrganizationData.svc/" + type + "Set(guid'" + id + "')"), true);
                    req.setRequestHeader("Accept", "application/json");
                    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                    req.setRequestHeader("X-HTTP-Method", "MERGE");
                    req.onreadystatechange = function () {
                        if (this.readyState == 4
                            /* complete */
                        ) {
                            req.onreadystatechange = null;
                            if (this.status == 204 || this.status == 1223) {
                                successCallback();
                            }
                            else {
                                errorCallback();
                            }
                        }
                    };
                    req.send(JSON.stringify(object));
                },
                launchActionNoParams: function (entityId, entityName, requestName) {

                    var requestXML = "";
                    requestXML += "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\">";
                    requestXML += "  <s:Body>";
                    requestXML += "    <Execute xmlns=\"http://schemas.microsoft.com/xrm/2011/Contracts/Services\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">";
                    requestXML += "    <request xmlns:a=\"http://schemas.microsoft.com/xrm/2011/Contracts\">";
                    requestXML += "        <a:Parameters xmlns:b=\"http://schemas.datacontract.org/2004/07/System.Collections.Generic\">";
                    requestXML += "          <a:KeyValuePairOfstringanyType>";
                    requestXML += "            <b:key>Target</b:key>";
                    requestXML += "            <b:value i:type=\"a:EntityReference\">";
                    requestXML += "              <a:Id>" + entityId + "</a:Id>";
                    requestXML += "              <a:LogicalName>" + entityName + "</a:LogicalName>";
                    requestXML += "              <a:Name i:nil=\"true\" />";
                    requestXML += "            </b:value>";
                    requestXML += "          </a:KeyValuePairOfstringanyType>";
                    requestXML += "        </a:Parameters>";
                    requestXML += "        <a:RequestId i:nil=\"true\" />";
                    requestXML += "        <a:RequestName>" + requestName + "</a:RequestName>";
                    requestXML += "      </request>";
                    requestXML += "    </Execute>";
                    requestXML += "  </s:Body>";
                    requestXML += "</s:Envelope>";

                    var req = new XMLHttpRequest();
                    req.open("POST", parent.Xrm.Page.context.getClientUrl() + "/XRMServices/2011/Organization.svc/web", false)
                    req.setRequestHeader("Accept", "application/xml, text/xml, */*");
                    req.setRequestHeader("Content-Type", "text/xml; charset=utf-8");
                    req.setRequestHeader("SOAPAction", "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Execute");
                    req.send(requestXML);
                    //Get the Response from the CRM Execute method
                    return req;
                },
                ValidateDateCutomer: function () {
                    var customerId = parent.Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
                    if (customerId != null) {
                        guidcontacto = customerId[0].id;
                        var contact = $scope.scopeData.productSelection.GetEntityRecords("Contact", guidcontacto, "amx_datecostumervalidation", null, false, null, null, null);
                        var risk = $scope.scopeData.productSelection.GetEntityRecords("amx_riskconfiguration", null, "amx_datevalidity", "amx_name eq 'Buro_Interno_Antiguedad_Cliente_Peso'", false, null, null, null);

                        var dateContact;
                        var dateRisk;

                        if (contact) {
                            if (contact.length > 0) {

                                if (contact[0].amx_datecostumervalidation) {
                                    dateContact = contact[0].amx_datecostumervalidation;
                                    dateContact = dateContact.replace("/Date(", "").replace(")/", "");
                                    dateContact = new Date(parseInt(dateContact, 10));
                                }
                            }
                        }

                        if (risk) {
                            if (risk.length > 0) {

                                if (risk[0].amx_datevalidity) {
                                    dateRisk = risk[0].amx_datevalidity;
                                    dateRisk = dateRisk.replace("/Date(", "").replace(")/", "");
                                    dateRisk = new Date(parseInt(dateRisk, 10));
                                }
                            }
                        }



                        if (dateContact && dateRisk) {

                            if (dateContact >= dateRisk) {
                                console.log("Se cumplió la condición");
                            }
                        }

                    }
                },
                GetEntityRecords: function (entityLogicalName, entityId, pSelect, pFilter, getAsync, pOrder, pTop, pExpand) {

                    var requestURL = parent.Xrm.Page.context.getClientUrl() + "/XRMServices/2011/OrganizationData.svc";
                    var result = [];

                    getAsync = (getAsync) ? getAsync : false;

                    requestURL += "/" + entityLogicalName + "Set";

                    if (entityId && entityId.length > 0) {
                        entityId = entityId.replace("{", "").replace("}", "");
                        requestURL += "(guid'" + entityId + "')";
                    }

                    var dataInfo = {};

                    if (typeof ($) === 'undefined') {
                        $ = parent.$;
                        jQuery = parent.jQuery;
                    }

                    if (pSelect) {
                        dataInfo.$select = pSelect;
                    }
                    if (pFilter) {
                        dataInfo.$filter = pFilter;
                    } if (pOrder) {
                        dataInfo.$orderby = pOrder;
                    }
                    if (pTop) {
                        dataInfo.$top = pTop;
                    }
                    if (pExpand) {
                        dataInfo.$expand = pExpand;
                    }

                    $.ajax({
                        dataType: "json",
                        async: getAsync,
                        url: requestURL,
                        data: dataInfo,
                        success: function (data) {
                            if (data.d) {
                                if (data.d.results) {
                                    if (data.d.results.length > 0) {
                                        result = data.d.results;
                                    }
                                    else {
                                        result = null;
                                    }
                                }
                                else {
                                    result = [data.d];
                                }
                            }
                            else {
                                result = null;
                            }
                        },
                        error: function () {
                            result = null;
                        }
                    });

                    return result;
                }
            };
            var initiate = function () {
                var promise = $scope.scopeData.productSelection.getOrderBasket();
                var formId = "NewSubscriptionProductSelection";
                $scope.scopeData.productSelection.translations = Wizard.GetTranslationData(formId);
                $scope.scopeData.productSelection.showAddons = false;
                $scope.scopeData.productSelection.numberOfBasicOffers = 0;
                $scope.scopeData.productSelection.getCustomerExternalId();
                $scope.scopeData.productSelection.closeOrder = false;
                $scope.scopeData.productSelection.biHeader = "";
                $rootScope.rootScopeData.order.appointmentRequired = false;
                var bOfferingPromise = $scope.scopeData.productSelection.retrieveBasicOfferings();
                bOfferingPromise.then(function () {
                    $scope.scopeData.productSelection.getCustomerAddress();
                });                
                $scope.scopeData.productSelection.getSequenceNumber();
                $scope.scopeData.productSelection.selectedBasicOffering = "";
                $scope.expanded = {};
                for (var i = 0; i < 4; i++) {
                    $scope.expanded[i] = true;
                    $scope.scopeData.productSelection.cartSubItems[i] = { show: true };
                }

                promise.then(function () {
                    if ($scope.scopeData.productSelection.cart.items.length === 0 && $scope.scopeData.productSelection.customerExternalId) {
                        $scope.scopeData.productSelection.getCustomerProductsFromSR();
                    }
                });
                
            };
            initiate();

        }]);

redirectTo360View = function () {
    var etel_individualcustomerid = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
    if (etel_individualcustomerid != null) {
        Xrm.Utility.openEntityForm("contact", etel_individualcustomerid[0].id);
    }
}
