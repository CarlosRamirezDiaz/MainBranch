wizard.controller("customerDataController", ['$scope', '$rootScope', '$http', '$timeout', function ($scope, $rootScope, $http, $timeout) {

    var customerInformationObj = {
        "AddressSelected": "",
        "ServicesAvailable": "",
        "PortabilityVerified": "",
        "ProductSelected": "",
        "CreditCheckPerformed": "",
        "StockCheckPerformed": "",
        "Portability": ""
    };

    if (typeof $rootScope.rootScopeData === "undefined") {
        $rootScope.rootScopeData = {};
    }
    $rootScope.rootScopeData.PriceConfiguration = [];
    $rootScope.rootScopeData.customerInformation = customerInformationObj;
    $rootScope.rootScopeData.ListPortableMSISDN = [];
    
    $rootScope.rootScopeData.customerInformation.SelectedAddress = [];

    var apiUrl = Wizard.Util.configStore.PsbRestServiceUrl;

    $scope.direct = $rootScope.direct; // setting direction for RTL language
    if ($scope.direct === "rtl") {
        $scope.isRTL = true;
    }
    else {
        $scope.isRTL = false;
    }
    //$rootScope.currentProcess = window.definitions.processes.newSubscription;
    $rootScope.displayColumnNewValue = false;
    $rootScope.displayColumnOption = false;
    if (typeof $scope.scopeData === "undefined") {
        $scope.scopeData = {};
    }
    $scope.addOns = {};

    var UpperLimitSubscription = 10;
    $scope.scopeData.planning = {};
    $scope.scopeData.planning.translations = {
        getTranslations: function () {
            $scope.scopeData.planning.translations = Wizard.GetTranslationData("NewSubscriptionPlanning");
        }
    };

    $scope.scopeData.portItems = [];

    $scope.scopeData.AvailableServices = [];


    $scope.scopeData.AddressSelection = {
        'onSelectAddress': function (item) {
            $scope.scopeData.AddressSelection.SelectedAddress = item;
            $rootScope.rootScopeData.customerInformation.AddressSelected = "Yes";
            $rootScope.rootScopeData.customerInformation.SelectedAddress = item;

            $scope.resumeInput.data = {};
            //$scope.resumeInput.data.province = item.Province;

            $scope.scopeData.AvailableServices = [
                { "serviceName": "3G" },
                { "serviceName": "4G" },
                { "serviceName": "HFC" }
            ];
            if (item != null) {
                $scope.scopeData.updateMGLDetails(item);
            }
            // $rootScope.rootScopeData.customerInformation.AddressSelected = $scope.scopeData.planning.translations.tYes;

            //$scope.scopeData.getAvailableStocks();
            //$scope.scopeData.getAvailableStocks();

            // Update address in order capture entity
            var config = { withCredentials: true };

            $scope.addUpdateAddressModel = {
                "orderCaptureId": Xrm.Page.data.entity.getId().substring(1).substring(0, 36),
                "addressId": item.AddressId
            };

            $http.post(apiUrl + 'UpdateOrderAddress', JSON.stringify($scope.addUpdateAddressModel), config)
                .success(function (result) {
                    if (result) {
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
    };
    $scope.scopeData.mglUpdateTimeValue = "";
    $scope.scopeData.mglTechnicalDetailsModifiedOn = null;
    $scope.scopeData.daneCode = null;

    $scope.scopeData.updateMGLDetails = function (selectedItem) {
        //Get MGL Update Timestamp        
        $scope.scopeData.getCRMConfigValue();
        if ($scope.scopeData.mglUpdateTimeValue != "") {
            var todayDate = new Date();
            var mglTechDetailsDate = new Date($scope.scopeData.mglTechnicalDetailsModifiedOn);
            var dateDiff = new Date().getDate() - mglTechDetailsDate.getDate();
            if (dateDiff >= $scope.scopeData.mglUpdateTimeValue) {
                Alert.showLoading(parent.Xrm.Page.context.getClientUrl(), "Updating MGL Techincal details..", 350, 115);
                $scope.scopeData.getAndUpdateMGLDetails(selectedItem);
            }
        }
    };

    $scope.scopeData.getAndUpdateMGLDetails = function (selectedItem) {
        $scope.workflowStartInput = {
            "addressMGLRequest":
            {
                "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails, AmxPeruPSBActivities",
                "idDireccion": selectedItem.MglAddressId, "segmento": "", "residencial": "", "proyecto": "",
            }
        };
        var config = { withCredentials: true };
        $http.post(apiUrl + 'AMXRetrieveCustomerAddressMGLTechDetails', JSON.stringify($scope.workflowStartInput), config)
            .success(function (result) {
                if (result) {
                    debugger;
                    var resultJsonOutput = new Array();
                    var addressIdUnique = [];
                    var resultJson = JSON.parse(result.Output.addressMGLResponse);
                    //if ((resultJson.categoryCode == "01" || resultJson.categoryCode == "03") && resultJson.categoryDescription == "Error de conectividad con el legado") {
                    //    Alert.hide();
                    //    parent.Xrm.Utility.alertDialog("Functional error of the legacy. Error: The address could not be tabulated, please make it tabulated.");
                    //    parent.Xrm.Utility.alertDialog("The data which is displaying in the grid is dummy data. This is only for testing. We will remove this once MGL is up");
                    //    resultJson = JSON.parse('{"headerResponse":{"responseDate":"2017-11-22T15:14:05.276","traceabilityId":"traceabilityId601"},"listsAddress":[{"addressId":"addressId602","city":{"cityId":603,"name":"name604","daneCode":"daneCode605","uperGeographycLevel":{"geographyStateId":606,"name":"name607","daneCode":"daneCode608","geographycLevelType":"geographycLevelType609","uperGeographycLevel":{"geographyStateId":610,"name":"name611","daneCode":"daneCode612","geographycLevelType":"geographycLevelType613","uperGeographycLevel":null}},"region":{"regionId":614,"name":"name615","technicalCode":"technicalCode616"},"claroCode":"claroCode617","geographycLevelType":"geographycLevelType618"},"igacAddress":"igacAddress619","adressReliability":620,"latitudeCoordinate":"latitudeCoordinate621","lengthCoordinate":"lengthCoordinate622","splitAddres":{"idTipoDireccion":"idTipoDireccion623","dirPrincAlt":"dirPrincAlt624","barrio":"barrio625","tipoViaPrincipal":"tipoViaPrincipal626","numViaPrincipal":"numViaPrincipal627","ltViaPrincipal":"ltViaPrincipal628","nlPostViaP":"nlPostViaP629","bisViaPrincipal":"bisViaPrincipal630","cuadViaPrincipal":"cuadViaPrincipal631","tipoViaGeneradora":"tipoViaGeneradora632","numViaGeneradora":"numViaGeneradora633","ltViaGeneradora":"ltViaGeneradora634","nlPostViaG":"nlPostViaG635","bisViaGeneradora":"bisViaGeneradora636","cuadViaGeneradora":"cuadViaGeneradora637","placaDireccion":"placaDireccion638","cpTipoNivel1":"cpTipoNivel1639","cpTipoNivel2":"cpTipoNivel2640","cpTipoNivel3":"cpTipoNivel3641","cpTipoNivel4":"cpTipoNivel4642","cpTipoNivel5":"cpTipoNivel5643","cpTipoNivel6":"cpTipoNivel6644","cpValorNivel1":"cpValorNivel1645","cpValorNivel2":"cpValorNivel2646","cpValorNivel3":"cpValorNivel3647","cpValorNivel4":"cpValorNivel4648","cpValorNivel5":"cpValorNivel5649","cpValorNivel6":"cpValorNivel6650","mzTipoNivel1":"mzTipoNivel1651","mzTipoNivel2":"mzTipoNivel2652","mzTipoNivel3":"mzTipoNivel3653","mzTipoNivel4":"mzTipoNivel4654","mzTipoNivel5":"mzTipoNivel5655","mzValorNivel1":"mzValorNivel1656","mzValorNivel2":"mzValorNivel2657","mzValorNivel3":"mzValorNivel3658","mzValorNivel4":"mzValorNivel4659","mzValorNivel5":"mzValorNivel5660","idDirCatastro":"idDirCatastro661","mzTipoNivel6":"mzTipoNivel6662","mzValorNivel6":"mzValorNivel6663","itTipoPlaca":"itTipoPlaca664","itValorPlaca":"itValorPlaca665","estrato":"estrato666","estadoDirGeo":"estadoDirGeo667","letra3G":"letra3G668","dirEstado":"dirEstado669","barrioTxtBM":"barrioTxtBM670"},"listCover":[{"technology":"technology671","node":"node672"}],"listCarrierCover":["listCarrierCover673"],"stratum":"stratum674","listHhpps":[{"hhppId":675,"state":"state676","technology":"technology677","viability":{"ResultadoValidacion":true,"Mensajes":{"Mensaje":[null]},"codRespuesta":"codRespuesta678","mensajeRespuesta":"mensajeRespuesta679","nombreProyecto":"nombreProyecto680"},"node":{"codeNode":"codeNode681","state":"state682","qualificationDate":"2006/06/30","nodeName":"nodeName684","technology":"technology685"},"subCcmmTechnology":{"subCcmmTechnologyId":686,"state":"state687","technology":"technology688","qualificationDate":"2006/06/13","subCcmmId":690,"ccmmId":691,"subBuildingName":"subBuildingName692","buildingName":"buildingName693","listCcmmMarks":[{"markId":694,"descriptionMark":"descriptionMark695","markCode":"markCode696"}],"tecnologyCcmmNode":{"codeNode":"codeNode697","state":"state698","qualificationDate":"2007/06/30","nodeName":"nodeName700","technology":"technology701"},"otherAddressList":[{"address":"address702"}],"addressesWithService":703,"typeDistribution":"typeDistribution704","buildingAddress":"buildingAddress705","buildingContact":"buildingContact706","phoneContactOne":"phoneContactOne707","phoneContactTwo":"phoneContactTwo708","elevatorCompany":"elevatorCompany709","managementCompany":"managementCompany710"},"listAddresMarks":[{"markId":"markId711","descriptionMark":"descriptionMark712"}],"constructionType":"constructionType713","rushtype":"rushtype714"}]}]}');
                    //};
                    if (resultJson.addresses != undefined) {
                        Alert.hide();
                        Alert.showLoading(parent.Xrm.Page.context.getClientUrl(), "Updating MGL Techincal details..", 350, 115);
                        $scope.scopeData.updateMGLTechnicalDetails(resultJson.addresses, selectedItem);                        
                        Alert.hide();
                    }
                }
            }).error(function (data, status, headers, config) {
                parent.Xrm.Utility.alertDialog((data.ExceptionMessage === undefined ?
                    (data.data === undefined ? data : (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                $scope.httpLoading = false;
                Alert.hide();
            }).finally(function () {
                Alert.hide();
            });
    };
    
    $scope.scopeData.updateMGLTechnicalDetails = function (selectedListAddress, selectedItem) {
        var mglTechDetailObj = {};
        var selectedRowItem = selectedListAddress;
        for (var x = 0; x < selectedRowItem.length; x++) {
            var selectedRowData = selectedRowItem[x];
            if (selectedRowData != undefined) {
                AMX.COMMON.SetMGLTechnicalDetailsEntityObj(selectedRowData, mglTechDetailObj, selectedItem.AddressId.toString().replace("{", "").replace("}", ""));
                var isMglTechDetailEntity = false; var mglTechDetailId = null;
                var webApiSelectFilters = "amx_bimgltechnicaldetailses?$select=amx_bimgltechnicaldetailsid&$filter=amx_addressid eq '" + selectedRowData.addressId + "' and  statecode eq 0";
                AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (sData) {
                    if (sData.value.length > 0) {
                        isMglTechDetailEntity = true;
                        mglTechDetailId = sData.value[0]["amx_bimgltechnicaldetailsid"];                        
                    }
                }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
                if (isMglTechDetailEntity) {
                    AMX.COMMON.UpdateEntityWebApi("amx_bimgltechnicaldetailses", mglTechDetailId, mglTechDetailObj, function (sData) {
                        $scope.scopeData.updateMGLListCover(mglTechDetailId, selectedRowData);
                        $scope.scopeData.updateMGLListHhpps(mglTechDetailId, selectedRowData);
                        Alert.showLoading(parent.Xrm.Page.context.getClientUrl(), "Customer Address and technical details Updated Successfully..", 500, 115);
                        //parent.Xrm.Utility.alertDialog("Customer Address and technical details Updated Successfully");
                    }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
                }
            }
        }
    };

    $scope.scopeData.updateMGLListCover = function (mglTechDetailId, selectedRowData) {
        var selectedListCover = selectedRowData.listCover;
        if (selectedListCover != undefined && selectedListCover != null && selectedListCover != "") {
            var mglListCoverObj = {};
            //Get All List Covers for mGL tech details.
            var webApiSelectFilters = "amx_mgllistcovers?$select=amx_mgllistcoverid&$filter=_amx_mgltechnicaldetailsid_value eq " + mglTechDetailId.replace("{","").replace("}","");
            AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                if (results.value.length > 0) {
                    for (var i = 0; i < results.value.length; i++) {
                        var amx_mgllistcoverid = results.value[i]["amx_mgllistcoverid"];
                        for (var i = 0; i < selectedListCover.length; i++) {
                            AMX.COMMON.SetMGLListCoverEntityObj(selectedListCover[i], mglListCoverObj, mglTechDetailId);
                            AMX.COMMON.UpdateEntityWebApi("amx_mgllistcovers", amx_mgllistcoverid, mglListCoverObj, function (sData) { }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
                        }
                    }
                }
            }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);  
        }
    };
    $scope.scopeData.updateMGLListHhpps = function (mglTechDetailId, selectedRowData) {
        var mglListHhppsObj = {}; var selectedSubCcmmTechnology = {};
        var selectedListHhpps = selectedRowData.listHhpps;
        if (selectedListHhpps != null || selectedListHhpps != undefined) {
            var webApiSelectFilters = "amx_bimgllisthhppses?$select=amx_bimgllisthhppsid&$filter=_amx_mgllisthhppsid_value eq " + mglTechDetailId.replace("{", "").replace("}", "");
            AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                if (results.value.length > 0) {
                    for (var i = 0; i < results.value.length; i++) {
                        var amx_bimgllisthhppsid = results.value[i]["amx_bimgllisthhppsid"];
                        for (var i = 0; i < selectedListHhpps.length; i++) {
                            AMX.COMMON.SetMGLListHhppsEntityObj(selectedListHhpps[i], mglListHhppsObj, selectedSubCcmmTechnology, mglTechDetailId);
                            AMX.COMMON.UpdateEntityWebApi("amx_bimgllisthhppses", amx_bimgllisthhppsid, mglListHhppsObj, function (sData) {
                                $scope.scopeData.updateOtherAddressListAndCcmmMarks(sData, selectedSubCcmmTechnology);
                                $scope.scopeData.updateViabilityMessageAndAddressCcmmMarks(sData, selectedListHhpps[i]);
                            }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
                        }
                    }
                }
            }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false); 
        }
    };

    $scope.scopeData.updateOtherAddressListAndCcmmMarks = function (mglListHhppsId, selectedSubCcmmTechnology) {
        var mglListCcmmMarksObj = {}; var mglOtherAddrListObj = {};
        if (selectedSubCcmmTechnology != undefined && selectedSubCcmmTechnology != null && selectedSubCcmmTechnology != "") {
            var selectedListCcmmMarks = selectedSubCcmmTechnology.listCcmmMarks;
            if (selectedListCcmmMarks != undefined) {
                var webApiSelectFilters = "amx_mglmarkses?$select=amx_mglmarksid&$filter=_amx_mglccmmmarksid_value eq " + mglListHhppsId.replace("{", "").replace("}", "");
                AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                    if (results.value.length > 0) {
                        for (var i = 0; i < results.value.length; i++) {
                            var amx_mglmarksid = results.value[i]["amx_mglmarksid"];
                            AMX.COMMON.UpdateMGLMarks("amx_MGLCcmmMarksId", mglListHhppsId, amx_mglmarksid, selectedListCcmmMarks);
                        }
                    }
                }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
            }
            var selectedOtherAddrList = selectedSubCcmmTechnology.otherAddressList;
            if (selectedOtherAddrList != undefined) {
                var webApiSelctFilter = "amx_mglotheraddresslists?$select=amx_mglotheraddresslistid&$filter=_amx_mgllisthhppsid_value eq" + mglListHhppsId.replace("{", "").replace("}", "");
                AMX.COMMON.RetrieveMultipleWebApi(webApiSelctFilter, function (results) {
                    if (results.value.length > 0) {
                        for (var i = 0; i < results.value.length; i++) {
                            var amx_mglotheraddresslistid = results.value[i]["amx_mglotheraddresslistid"];
                            for (var x = 0; x < selectedOtherAddrList.length; x++) {
                                AMX.COMMON.SetMGLOtherAddressListEntityObj(selectedOtherAddrList[x], mglOtherAddrListObj, mglListHhppsId);
                                AMX.COMMON.UpdateEntityWebApi("amx_mglotheraddresslists", amx_mglotheraddresslistid, mglOtherAddrListObj, function (sData) { }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
                            }
                        }
                    }
                }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
            }
        }
    };
    $scope.scopeData.updateViabilityMessageAndAddressCcmmMarks = function (mglListHhppsId, selectedListHhpps) {
        var mglAddressCcmmMarksObj = {}; var mglViabilityMessagesObj = {};
        var selectedListAddresMarks = selectedListHhpps.listAddresMarks;
        if (selectedListAddresMarks != undefined) {
            var webApiSelectFilters = "amx_mglmarkses?$select=amx_mglmarksid&$filter=_amx_mgladdressmarksid_value eq " + mglListHhppsId.replace("{", "").replace("}", "");
            AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                if (results.value.length > 0) {
                    for (var i = 0; i < results.value.length; i++) {
                        var amx_mglmarksid = results.value[i]["amx_mglmarksid"];
                        AMX.COMMON.UpdateMGLMarks("amx_MGLAddressMarksId", mglListHhppsId, amx_mglmarksid, selectedListCcmmMarks);
                    }
                }
            }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
        }
        var selectedViability = selectedListHhpps.viability;
        if (selectedViability != undefined) {
            var selectedViabilityMessages = selectedViability.mensajes;
            if (selectedViabilityMessages != undefined) {
                var webApiSelectFilters = "amx_mglviabilitymessages?$select=amx_mglviabilitymessageid&$filter=_amx_mgllisthhppsid_value eq" + mglListHhppsId.replace("{", "").replace("}", "");
                AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                    if (results.value.length > 0) {
                        for (var i = 0; i < results.value.length; i++) {
                            var amx_mglviabilitymessageid = results.value[i]["amx_mglviabilitymessageid"];
                            for (var x = 0; x < selectedViabilityMessages.length; x++) {
                                AMX.COMMON.SetMGLViabilityMessagesEntityObj(selectedViabilityMessages[x], mglViabilityMessagesObj, mglListHhppsId);
                                AMX.COMMON.UpdateEntityWebApi("amx_mglviabilitymessages", amx_mglviabilitymessageid, mglViabilityMessagesObj, function (sData) { }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
                            }
                        }
                    }
                }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
            }
        }
    };

    $scope.scopeData.getCRMConfigValue = function () {
        var mglUpdateTimestamp = "MGL_TecnicalDetails_Timestamp";
        var webApiSelectFilters = "etel_crmconfigurations?$select=etel_value&$filter=etel_name eq '" + mglUpdateTimestamp + "'";
        AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
            if (results.value.length > 0) {
                for (var i = 0; i < results.value.length; i++) {
                    var etel_value = results.value[i]["etel_value"];
                    if (etel_value != null) {
                        $scope.scopeData.mglUpdateTimeValue = etel_value;
                    }
                }
            }
        }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);        
    };

    $scope.scopeData.maxPortCount = 0;

    $scope.scopeData.validatePortability = {
        LineNumber: "",
        ServiceTypes: [
            { "serviceType": "Fixed" },
            { "serviceType": "Mobile" }
        ],
        CurrentPlans: [
            { "CurrentPlan": "Pre Paid" },
            { "CurrentPlan": "Post Paid" }
        ],
        CurrentCarriers: [
            { "CurrentCarrier": "Movistar" },
            { "CurrentCarrier": "Entel" }
        ],
        'validate': function () {

            //angular.forEach($scope.scopeData.portItems, function (portItem) {

            //});

            //TODO: Call PSB for Validating

            //for each of the Port Items Validated List
            angular.forEach($scope.scopeData.portItems, function (portItem) {
                if (portItem.LineNumber == "9830098300") {
                    portItem.Status = "Claro Owned";
                    portItem.BrowseFile = true;
                }
                else if (portItem.LineNumber == "9870098700") {
                    portItem.Status = "Pending Payment";
                    portItem.BrowseFile = false;
                }
                else {
                    portItem.Status = "Successful";
                    portItem.BrowseFile = true;
                }

                portItem.IsValidated = true;
            });


            //Store the Validated LineItems with Status as "Successful"
            angular.forEach($scope.scopeData.portItems, function (portItem) {
                if (portItem.Status == "Successful") {
                    $rootScope.rootScopeData.ListPortableMSISDN.push({
                        'msisdn': portItem.LineNumber
                    });
                }
            });

            $rootScope.rootScopeData.customerInformation.PortabilityVerified = $scope.scopeData.planning.translations.tYes;
        },
        'UploadDocument': function (portLineItem) {
            //TODO: Call HpOnBaseDocumentUpload API

            angular.forEach($scope.scopeData.portItems, function (portItem) {
                if (portItem.LineNumber == portLineItem.LineNumber) {
                    portItem.Status = "Successful";
                    portItem.BrowseFile = false;
                }
            });
        },
        'NoDocumentSelected': function (portLineItem) {
            angular.forEach($scope.scopeData.portItems, function (portItem) {
                if (portItem.LineNumber == portLineItem.LineNumber) {

                    if (portItem.IsSelected) {
                        portItem.IsSelected = false;
                        portItem.Status = "Pending Payment";
                    }
                    else {
                        portItem.IsSelected = true;
                        portItem.Status = "Rejected";
                    }
                }
            });
        },
        'addLineItems': function () {
            if ($scope.scopeData.maxPortCount == 10) {
                alert('Max 10 Lines are allowed');
                alert($scope.scopeData.planning.translations.tMaxPortabilityErrorMsg);
            }
            else {
                $scope.scopeData.portItems.push({
                    'LineNumber': $scope.scopeData.validatePortability.LineNumber,
                    'ServiceType': $scope.itemServiceType.serviceType,
                    'CurrentPlan': $scope.itemPlan.CurrentPlan,
                    'CurrentCarrier': $scope.itemCarrier.CurrentCarrier,
                    'Status': "",
                    'BrowseFile': true,
                    'IsValidated': false,
                    'IsSelected': false
                });
                $scope.scopeData.maxPortCount = $scope.scopeData.maxPortCount + 1;
            }
            $rootScope.rootScopeData.customerInformation.Portability = $scope.scopeData.planning.translations.tYes;
        },
        'clearLineItems': function () {

            $scope.scopeData.portItems = [];
            $rootScope.rootScopeData.customerInformation.PortabilityVerified = "";
            $rootScope.rootScopeData.customerInformation.Portability = "";
            $scope.scopeData.validatePortability.LineNumber = "";
            $scope.scopeData.maxPortCount = 0;
        },
        'removePortLineItem': function (portLineItem) {
            var index = $scope.scopeData.portItems.indexOf(portLineItem);
            if (index > -1) {
                $scope.scopeData.portItems.splice(index, 1);
            }
        }
    };

    $scope.scopeData.getAvailableStocks = function () {
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

    $scope.scopeData.CreateCustomerAddress = function () {
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
                        $scope.scopeData.CreateAndOpenEntity(_etel_cityid_value_formatted, _amx_districtid_value, _etel_cityid_value, customerId.replace("{", "").replace("}", ""));
                    } else {
                        Xrm.Utility.alertDialog(this.statusText);
                    }
                }
            };
            req.send();
        }
        

    };

    $scope.scopeData.CreateAndOpenEntity = function(addressName, districtId, cityId, customerId) {
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
    };

    $scope.scopeData.UpdateCustomerAddress = function () {
        alert("Development in Progress");
    };

    $scope.scopeData.RefreshCustomerAddress = function () {
        $scope.scopeData.GetCustomerAddressData();
    };

    $scope.scopeData.CheckNewStage = function () {
        $scope.resumeInput.data = {};
        $scope.resumeInput.data.newStage = !$scope.scopeData.NewStage;

    };

    window.planningStateRepository = function (stateFunction) {
        return stateFunction($scope);
    };

    var initiate = function () {
        $rootScope.rootScopeData.translations = Wizard.GetTranslationData("6666");
        $scope.scopeData.NewStage = false;
        $scope.scopeData.planning.translations.getTranslations();
        $scope.scopeData.GetCustomerAddressData();
    };

    $scope.scopeData.GetCustomerAddressData = function () {
        var contactGuid, lookupRecordName;
        var lookupObj = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
        if (lookupObj) {
            var lookupEntityType = lookupObj[0].entityType;
            contactGuid = lookupObj[0].id;
            lookupRecordName = lookupObj[0].name;
        }
        var customerGuidFormattedString = contactGuid.toString().substr(1).slice(0, -1);
        var webApiSelectFilters = "etel_customeraddresses?fetchXml=%3Cfetch%20version%3D%221.0%22%20output-format%3D%22xml-platform%22%20mapping%3D%22logical%22%20distinct%3D%22false%22%3E%3Centity%20name%3D%22etel_customeraddress%22%3E%3Cattribute%20name%3D%22etel_customeraddressid%22%20%2F%3E%3Cattribute%20name%3D%22etel_name%22%20%2F%3E%3Cattribute%20name%3D%22amx_addressid%22%20%2F%3E%3Cattribute%20name%3D%22amxperu_referencedescription%22%20%2F%3E%3Cattribute%20name%3D%22modifiedon%22%20%2F%3E%3Cattribute%20name%3D%22amxperu_district%22%20%2F%3E%3Cattribute%20name%3D%22amx_cityarea%22%20%2F%3E%3Cattribute%20name%3D%22etel_cityid%22%20%2F%3E%3Corder%20attribute%3D%22etel_name%22%20descending%3D%22false%22%20%2F%3E%3Cfilter%20type%3D%22and%22%3E%3Ccondition%20attribute%3D%22amx_addressid%22%20operator%3D%22not-null%22%20%2F%3E%3Ccondition%20attribute%3D%22etel_individualcustomerid%22%20operator%3D%22eq%22%20value%3D%22%7B" + customerGuidFormattedString + "%7D%22%20%2F%3E%3C%2Ffilter%3E%3C%2Fentity%3E%3C%2Ffetch%3E";
        AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
            $scope.scopeData.AddressSelection.Addresses = [];
            for (var i = 0; i < results.value.length; i++) {
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
                var etel_name = results.value[i]["etel_name"];
                var amx_addressid = results.value[i]["amx_addressid"];
                $scope.scopeData.daneCode = results.value[i]["amxperu_referencedescription"];
                $scope.scopeData.mglTechnicalDetailsModifiedOn = results.value[i]["modifiedon"];
                var nameArr = etel_name.split('-');
                $scope.scopeData.AddressSelection.Addresses.push({
                    "AddressName": etel_name,
                    "AddressId": etel_customeraddressid,
                    "MglAddressId": amx_addressid,
                    "District": _amxperu_district_value_formatted,
                    "City": _etel_cityid_value_formatted,
                    "CityArea": _amx_cityarea_value_formatted,
                    "IgacAddress": nameArr.length > 1 ? nameArr[1] : "",
                });
            }
        }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);            
    };
    initiate();
}]);