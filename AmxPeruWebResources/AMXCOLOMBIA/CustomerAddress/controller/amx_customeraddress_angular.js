var cusAddress = angular
    //.module('customeraddress', ['ngGrid', 'components', 'bzm-date-picker', 'ngTouch',
    //    'ui.grid.expandable', 'ui.grid.pagination', 'ui.grid', 'ui.grid.edit', 'ui.grid.resizeColumns', 'ui.grid.selection',
    //    'ui.grid.moveColumns', 'ui.grid.autoResize'])
    .module('customeraddress', ['ngTouch', 'ui.grid', 'ui.grid.selection'])//'ui.grid.pagination'
    .config(function ($locationProvider, $httpProvider) {
        $locationProvider.html5Mode(true); //to get querys trings
        //initialize get if not there
        if (!$httpProvider.defaults.headers.get) {
            $httpProvider.defaults.headers.get = {};
        }
        //disable IE ajax request caching
        $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
        $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
        $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
    });

cusAddress.controller('amxCustomerAddress', ['$scope', '$http', '$rootScope',
    function ($scope, $http, $rootScope) {
        if (typeof $scope.scopeData === "undefined") { $scope.scopeData = {}; }
        $scope.scopeData.SearchCustomerAddresses = [];
        $scope.scopeData.confirmCustomerAddress = [];
        $scope.scopeData.createMGLListHhpps = [];
        $scope.scopeData.createMGLListCcmmMarks = [];
        $scope.scopeData.createMGLAddressCcmmMarks = [];
        
        var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");
        $scope.direct = $rootScope.direct; // setting direction for RTL language
        if ($scope.direct === "rtl") { $scope.isRTL = true; }
        else { $scope.isRTL = false; }
        $scope.amxCustomerAddressGrid = {
            enableColumnResizing: true, rowHeight : 25, showHeader : false/*, enableHorizontalScrollbar: "always", expandableRowHeight: 70*/, enableFiltering: false, enableGridMenu: false, showGridFooter: false, enablePinning: false, flatEntityAccess: false,
            showColumnFooter: false, fastWatch: true, enableRowSelection: true, enableRowHeaderSelection: false, multiSelect: false, modifierKeysToMultiSelect: false, noUnselect: true,
            //expandableRowTemplate: '<div ui-grid:"row.entity.subGridOptions" class:"sub-grid" style:"height:70px, width:100%,"></div>',
            enablePaginationControls: false, paginationPageSize: 4, /*paginationPageSizes: [25, 50, 75],*/
            rowIdentity: function (row) { return row.id; }, getRowIdentity: function (row) { return row.id; },
            /*expandableRowScope: { subGridVariable: 'subGridScopeVariable' },*/
            //rowTemplate: strVar
        };
        $scope.amxCustomerAddressGrid.selectedItems = [];

        $scope.scopeData.confirmCustomerAddress = function () {             
            var mglTechDetailObj = {};
            var config = { withCredentials: true };
            var selectedRowItem = $scope.amxCustomerAddressGrid.selectedRow;
            if (selectedRowItem == undefined) { Alert.show(TranslationCustomerAddress.data.tProceed, "", [new Alert.Button("Ok")], "INFO", 400, 150); return; }
            for(var x = 0; x < selectedRowItem.length; x++) {
                var addressId = selectedRowItem[x].addressId;
                var webApiSelectFilters = "amx_bimgltechnicaldetailses?$select=amx_bimgltechnicaldetailsid&$filter=amx_addressid eq '" + addressId + "' and  statecode eq 0";
                AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (sData) {
                    //if (sData.value.length > 0) {
                    //    Alert.show(TranslationCustomerAddress.data.tAssociated, "", [new Alert.Button("Ok")], "INFO", 400, 150);
                    //}
                    //else {
                        $scope.workflowStartInput = {
                            "addressMGLRequest":
                            {
                                "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails, AmxPeruPSBActivities",
                                "idDireccion": addressId, "segmento": "", "residencial": "", "proyecto": "",
                            }
                        };
                        Alert.showLoading(parent.Xrm.Page.context.getClientUrl(), TranslationCustomerAddress.data.tCreateMGL, 350, 115);
                        $scope.loading = true;
                        $scope.BindAmxCustomerAddressGrid([]);
                        $http.post(apiUrl + 'AMXRetrieveCustomerAddressMGLTechDetails', JSON.stringify($scope.workflowStartInput), config)
                            .success(function (result) {
                                $scope.loading = false;
                                if (result) {
                                    var resultJsonOutput = new Array();
                                    var resultJson = JSON.parse(result.Output.addressMGLResponse);
                                    if (resultJson.addresses != undefined) {
                                        var selectedRowData = resultJson.addresses;
                                        AMX.COMMON.SetMGLTechnicalDetailsEntityObj(selectedRowData, mglTechDetailObj, parent.Xrm.Page.data.entity.getId().replace("{", "").replace("}", ""));
                                        AMX.COMMON.CreateEntiyWebApi("amx_bimgltechnicaldetailses", mglTechDetailObj, function (sData) {
                                            $scope.scopeData.createMGLListCover(sData, selectedRowData);
                                            $scope.scopeData.createMGLListHhpps(sData, selectedRowData);
                                            Alert.hide();
                                        }, function (eData) { parent.Xrm.Utility.alertDialog(eData) }, false);
                                        $scope.scopeData.SetCustomerAddressFields(selectedRowData, mglTechDetailObj);
                                    }
                                }

                            }).error(function (data, status, headers, config) {
                                $scope.loading = false;
                                Alert.hide();
                                parent.Xrm.Utility.alertDialog((data.ExceptionMessage === undefined ?
                                    (data.data === undefined ? data :
                                        (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                                $scope.httpLoading = false;
                            }).finally(function () {
                                $scope.loading = false;
                                Alert.hide();
                            });  
                    //}
                }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);                            
            }
        };

        $scope.scopeData.SetCustomerAddressFields = function (selectedRowData, mglTechDetailObj)
        {
            var cityName = parent.Xrm.Page.getAttribute("etel_cityid").getValue() != null ? parent.Xrm.Page.getAttribute("etel_cityid").getValue()[0].name : "";
            parent.Xrm.Page.getAttribute("etel_name").setValue(cityName + "-" + mglTechDetailObj["amx_igacaddress"].toString());
            parent.Xrm.Page.getAttribute("etel_addressline1").setValue(mglTechDetailObj["amx_igacaddress"].toString());
            parent.Xrm.Page.getAttribute("amx_addressid").setValue(mglTechDetailObj["amx_addressid"].toString());
            parent.Xrm.Page.getAttribute("etel_postalcode").setValue($scope.daneCode);
            parent.Xrm.Page.getAttribute("amx_addressrealiability").setValue(selectedRowData.adressReliability == undefined || selectedRowData.adressReliability == null || selectedRowData.adressReliability == "" ? "" : selectedRowData.adressReliability.toString());
            parent.Xrm.Page.getAttribute("amxperu_latitude").setValue(selectedRowData.latitudeCoordinate == undefined || selectedRowData.latitudeCoordinate == null || selectedRowData.latitudeCoordinate == "" ? "" : selectedRowData.latitudeCoordinate.toString());
            parent.Xrm.Page.getAttribute("amxperu_longitude").setValue(selectedRowData.lengthCoordinate == undefined || selectedRowData.lengthCoordinate == null || selectedRowData.lengthCoordinate == "" ? "" : selectedRowData.lengthCoordinate.toString());
            //Get the Country details based on Country code
            var webApiSelectFilters = "etel_countries?$select=etel_countryid,etel_name&$filter=etel_value eq 'COL'";
            AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                if (results.value.length > 0) {
                    var etel_countryid = results.value[0]["etel_countryid"];
                    var etel_name = results.value[0]["etel_name"];
                    parent.Xrm.Page.getAttribute("etel_countryid").setValue([{ name: etel_name, id: etel_countryid, entityType : "etel_country" }]);
                }
            }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);


            
            var customerAddressIdToUpdate = parent.Xrm.Page.getAttribute("amxperu_schedulingid").getValue();
            if (customerAddressIdToUpdate != null && customerAddressIdToUpdate != "") {
                var entity = {};
                entity.etel_isprimaryaddress = false;
                AMX.COMMON.UpdateEntityWebApi("etel_customeraddresses", customerAddressIdToUpdate, entity, function (sData) { }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
                parent.Xrm.Page.getAttribute("amxperu_schedulingid").setValue("");
            }
            parent.Xrm.Page.data.entity.save("saveandclose");
        };

        $scope.scopeData.createMGLListCover = function (mglTechDetailId, selectedRowData) {
            var selectedListCover = selectedRowData.listCover;
            if (selectedListCover != undefined && selectedListCover != null && selectedListCover != "") {
                var mglListCoverObj = {};
                for (var i = 0; i < selectedListCover.length; i++) {
                    AMX.COMMON.SetMGLListCoverEntityObj(selectedListCover[i], mglListCoverObj, mglTechDetailId);
                    AMX.COMMON.CreateEntiyWebApi("amx_mgllistcovers", mglListCoverObj, function (sData) { }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
                }
            }
        };

        $scope.scopeData.createMGLListHhpps = function (mglTechDetailId, selectedRowData) {
            var mglListHhppsObj = {}; var selectedSubCcmmTechnology = {};
            var selectedListHhpps = selectedRowData.listHhpps;
            if (selectedListHhpps != null || selectedListHhpps != undefined) {
                for (var i = 0; i < selectedListHhpps.length; i++) {
                    AMX.COMMON.SetMGLListHhppsEntityObj(selectedListHhpps[i], mglListHhppsObj, selectedSubCcmmTechnology, mglTechDetailId);
                    AMX.COMMON.CreateEntiyWebApi("amx_bimgllisthhppses", mglListHhppsObj, function (sData) {
                        $scope.scopeData.createOtherAddressListAndCcmmMarks(sData, selectedSubCcmmTechnology);
                        $scope.scopeData.createViabilityMessageAndAddressCcmmMarks(sData, selectedListHhpps[i]);
                    }, function (eData) { parent.Xrm.Utility.alertDialog(eData) }, false);
                }
            }
        };

        $scope.scopeData.createOtherAddressListAndCcmmMarks = function (mglListHhppsId, selectedSubCcmmTechnology) {
            var mglListCcmmMarksObj = {}; var mglOtherAddrListObj = {};
            if (selectedSubCcmmTechnology != undefined && selectedSubCcmmTechnology != null && selectedSubCcmmTechnology != "") {
                var selectedListCcmmMarks = selectedSubCcmmTechnology.listCcmmMarks;
                if (selectedListCcmmMarks != undefined) {
                    AMX.COMMON.CreateMGLMarks("amx_MGLCcmmMarksId", mglListHhppsId, selectedListCcmmMarks);
                }
                var selectedOtherAddrList = selectedSubCcmmTechnology.otherAddressList;
                if (selectedOtherAddrList != undefined) {
                    for (var x = 0; x < selectedOtherAddrList.length; x++) {
                        AMX.COMMON.SetMGLOtherAddressListEntityObj(selectedOtherAddrList[x], mglOtherAddrListObj, mglListHhppsId);
                        AMX.COMMON.CreateEntiyWebApi("amx_mglotheraddresslists", mglOtherAddrListObj, function (sData) { }, function (eData) { parent.Xrm.Utility.alertDialog(eData) }, false);
                    }
                }
            }
        };

        $scope.scopeData.createViabilityMessageAndAddressCcmmMarks = function (mglListHhppsId, selectedListHhpps) {
            var mglAddressCcmmMarksObj = {}; var mglViabilityMessagesObj = {};
            var selectedListAddresMarks = selectedListHhpps.listAddresMarks;
            if (selectedListAddresMarks != undefined) {
                AMX.COMMON.CreateMGLMarks("amx_MGLAddressMarksId", mglListHhppsId, selectedListAddresMarks);
            }
            var selectedViability = selectedListHhpps.viability;
            if (selectedViability != undefined) {
                var selectedViabilityMessages = selectedViability.mensajes;
                if (selectedViabilityMessages != undefined) {
                    for (var x = 0; x < selectedViabilityMessages.length; x++) {
                        AMX.COMMON.SetMGLViabilityMessagesEntityObj(selectedViabilityMessages[x], mglViabilityMessagesObj, mglListHhppsId);
                        AMX.COMMON.CreateEntiyWebApi("amx_mglviabilitymessages", mglViabilityMessagesObj, function (sData) { }, function (eData) { parent.Xrm.Utility.alertDialog(eData) }, false);
                    }
                }
            }
        };
        $scope.ManipulateArray = function (actualArray, textBoxValue) {
            for (var i = 0; i < actualArray.length; i++) {
                if (textBoxValue.indexOf(actualArray[i]) === 0) {
                    var firstVal = actualArray[i];
                    return actualArray[i];
                    break;
                }
            }
            return "";
        };
        $scope.AddressCodeSet = []; $scope.BMAddressTypeSet = []; $scope.ITAddressTypeSet = []; $scope.Complemento = []; $scope.Apartmento = [];
        $scope.PushDataToArray = function (arrayList, arrName) {
            for (var i = 1; i < arrayList.length; i++) {
                if (arrName == "addressSet") { $scope.AddressCodeSet.push(arrayList[i]); }
                if (arrName == "bmArray") { $scope.BMAddressTypeSet.push(arrayList[i]); }
                if (arrName == "itArray") { $scope.ITAddressTypeSet.push(arrayList[i]); }
                if (arrName == "complementoArray") { $scope.Complemento.push(arrayList[i]); }
                if (arrName == "apartmentoArray") { $scope.Apartmento.push(arrayList[i]); }
            }
        };

        $scope.SetManipulatedArray = function () {
            var configValues = parent.Xrm.Page.getAttribute("amx_mglconfigvalues").getValue() != null ? parent.Xrm.Page.getAttribute("amx_mglconfigvalues").getValue() : "";
            if (configValues != "") {
                var configValueStr = configValues.split('@');
                var bmArray = configValueStr[0].split(';'); $scope.PushDataToArray(bmArray, "bmArray");
                var itArray = configValueStr[1].split(';'); $scope.PushDataToArray(itArray, "itArray");
                var complementoArray = configValueStr[2].split(';'); $scope.PushDataToArray(complementoArray, "complementoArray");
                var apartmentoArray = configValueStr[3].split(';'); $scope.PushDataToArray(apartmentoArray, "apartmentoArray");
            }
        };

        $scope.GetAddressCode = function () {
            var webApiSelectFilters = "amx_mgladdresscodes?$select=amx_name,amx_value,amx_mgladdresscodeid";
            AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                if (results.value.length > 0) {
                    for (var i = 0; i < results.value.length; i++) {
                        var amx_mgladdresscodeid = results.value[i]["amx_mgladdresscodeid"];
                        var amx_name = results.value[i]["amx_name"];
                        $scope.AddressCodeSet.push(amx_name);
                    }                    
                }
            }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);


        };

        $scope.daneCode = "";
        $scope.scopeData.searchCustomerAddress = function () {
            var config = {
                withCredentials: true
            };
            var districtId = parent.Xrm.Page.getAttribute("amxperu_district").getValue() != null ? parent.Xrm.Page.getAttribute("amxperu_district").getValue()[0].id : null;
            var cityId = parent.Xrm.Page.getAttribute("etel_cityid").getValue() != null ? parent.Xrm.Page.getAttribute("etel_cityid").getValue()[0].id : null;
            var cityAreaId = parent.Xrm.Page.getAttribute("amx_cityarea").getValue() != null ? parent.Xrm.Page.getAttribute("amx_cityarea").getValue()[0].id : null;
            var addressText1 = parent.Xrm.Page.getAttribute("amx_addresscode").getValue() != null ? parent.Xrm.Page.getAttribute("amx_addresscode").getValue()[0].id : null;
            var addressText2 = parent.Xrm.Page.getAttribute("amx_searchaddress").getValue() != null ? parent.Xrm.Page.getAttribute("amx_searchaddress").getValue() : "";
            var addressText3 = parent.Xrm.Page.getAttribute("amxperu_square").getValue() != null ? parent.Xrm.Page.getAttribute("amxperu_square").getValue() : "";
            var addressText4 = parent.Xrm.Page.getAttribute("etel_street2") != null ? parent.Xrm.Page.getAttribute("etel_street2").getValue() : "";

            var addressTextNameArray = addressText2.split(' ');
            var addressTextName = addressTextNameArray;
            addressTextName = addressTextName.length > 0 ? addressTextName[0] : "";

            if (districtId == null || cityId == null || cityAreaId == null || addressText2 == null) {
                //parent.Xrm.Utility.alertDialog('Please fill the required fields before searching the address');
                Alert.show(TranslationCustomerAddress.data.tRequired, "", [new Alert.Button("Ok")], "INFO", 400, 150);
                return;
            }
            var fetchDistrict = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" + "<entity name= 'amxperu_district'>" + "<attribute name='amxperu_districtid'/>" + "<attribute name='amxperu_name'/>" + "<attribute name='amxperu_districtcode'/>" + "<filter type='and'>" + "<condition attribute='statecode' operator='eq' value='0'/>" + "<condition attribute='amxperu_districtid' operator='eq' value='" + districtId + "'/>" + "</filter>" + "</entity>" + "</fetch >";
            var fetchCity = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" + "<entity name= 'etel_city'>" + "<attribute name='etel_cityid'/>" + "<attribute name='etel_name'/>" + "<attribute name='etel_code'/>" + "<filter type='and'>" + "<condition attribute='statecode' operator='eq' value='0'/>" + "<condition attribute='etel_cityid' operator='eq' value='" + cityId + "'/>" + "</filter>" + "</entity>" + "</fetch >";
            var fetchCityArea = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" + "<entity name= 'amx_cityarea'>" + "<attribute name='amx_cityareaid'/>" + "<attribute name='amx_name'/>" + "<attribute name='amx_cityareacode'/>" + "<filter type='and'>" + "<condition attribute='statecode' operator='eq' value='0'/>" + "<condition attribute='amx_cityareaid' operator='eq' value='" + cityAreaId + "'/>" + "</filter>" + "</entity>" + "</fetch >";
            var fetchAddressText = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" + "<entity name= 'amx_mgladdresscode'>" + "<attribute name='amx_mgladdresscodeid'/>" + "<attribute name='amx_name'/>" + "<attribute name='amx_value'/>" + "<filter type='and'>" + "<condition attribute='statecode' operator='eq' value='0'/>" + "<condition attribute='amx_mgladdresscodeid' operator='eq' value='" + addressText1 + "'/>" + "</filter>" + "</entity>" + "</fetch >";
            var fetchAddressCode = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" + "<entity name= 'amx_mgladdresscode'>" + "<attribute name='amx_mgladdresscodeid'/>" + "<attribute name='amx_name'/>" + "<attribute name='amx_value'/>" + "<filter type='and'>" + "<condition attribute='statecode' operator='eq' value='0'/>" + "<condition attribute='amx_name' operator='eq' value='" + addressTextName + "'/>" + "</filter>" + "</entity>" + "</fetch >";
            var districtCode = AMX.COMMON.RetrieveCrmEntity(fetchDistrict, "amxperu_districtcode", "amxperu_district");
            var cityCode = AMX.COMMON.RetrieveCrmEntity(fetchCity, "etel_code", "etel_city");
            var cityAreaCode = AMX.COMMON.RetrieveCrmEntity(fetchCityArea, "amx_cityareacode", "amx_cityarea");
            //var addressTextCode = AMX.COMMON.RetrieveCrmEntity(fetchAddressText, "amx_value", "amx_mgladdresscode");
            var addressTextCodeWithName = AMX.COMMON.RetrieveCrmEntity(fetchAddressCode, "amx_value", "amx_mgladdresscode");
            var addressText = "";//addressTextCode + " " + addressText2 + " " + addressText3 + " " + addressText4;
            addressText = addressTextCodeWithName + " ";
            for (var i = 1; i < addressTextNameArray.length; i++) { addressText += addressTextNameArray[i] + " "; }
            parent.Xrm.Page.getAttribute("amxperu_referencedescription").setValue(districtCode + cityCode + cityAreaCode);//Set the DaneCode value
            var isDTH = false;
            if (districtCode == null || cityCode == null || cityAreaCode == null || addressText.trim() == null || districtCode == "" || cityCode == "" || cityAreaCode == "" || addressText.trim() == "" || districtCode == undefined || cityCode == undefined || cityAreaCode == undefined || addressText == undefined) { return; }
            $scope.daneCode = districtCode + cityCode + cityAreaCode;
            //Tabular
            var idTipoDireccion = ""; var tipoViaPrincipal = ""; var numViaPrincipal = ""; var numViaGeneradora = ""; var placaDireccion = "";
            var barrio = "";
            var tabFieldValue = parent.Xrm.Page.getAttribute("amxperu_normalized").getValue();
            if (tabFieldValue) {
                $scope.GetAddressCode(); $scope.SetManipulatedArray();
                var addressTypeTab = parent.Xrm.Page.getAttribute("amx_addresstypetab").getValue() != null ? parent.Xrm.Page.getAttribute("amx_addresstypetab").getValue() : null;
                if (addressTypeTab != null) {
                    var addressTab7Value = parent.Xrm.Page.getAttribute("amx_addresstab7").getValue();
                    var addressTab7Arry = JSON.parse(addressTab7Value);
                    var comunidad = districtCode + cityCode + cityAreaCode;
                    $scope.GetAddressHhpp(addressTab7Arry, comunidad);
                }
            }
            else {
                $scope.workflowStartInput = {
                    "addressMGLRequest":
                    {
                        "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.cmtDireccionRequestDto, AmxPeruPSBActivities",
                        "codigoDane": districtCode + cityCode + cityAreaCode, "direccion": addressText == undefined ? null : addressText.trim(),
                        //"segmento": "", "proyecto": "",
                        "isDth": isDTH, "nodoGestion": "", "user": "", "estrato": ""
                        //,"cmtDireccionTabuladaDto": {
                        //    "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.cmtDireccionTabuladaDto, AmxPeruPSBActivities",
                        //    "idTipoDireccion": idTipoDireccion, "barrio": barrio, "idDirCatastro": "",
                        //    "itTipoPlaca": "", "itValorPlaca": "", "dirPrincAlt": "",
                        //    "tipoViaPrincipal": "", "numViaPrincipal": numViaPrincipal, "ltViaPrincipal": "",
                        //    "nlPostViaP": "", "bisViaPrincipal": "", "cuadViaPrincipal": "",
                        //    "tipoViaGeneradora": "", "numViaGeneradora": numViaGeneradora, "ltViaGeneradora": "",
                        //    "nlPostViaG": "", "bisViaGeneradora": "", "cuadViaGeneradora": "", "placaDireccion": placaDireccion,                        
                        //    "cpTipoNivel1": "", "cpTipoNivel2": "", "cpTipoNivel3": "",
                        //    "cpTipoNivel4": "", "cpTipoNivel5": apartamento, "cpTipoNivel6": "",
                        //    "cpValorNivel1": "", "cpValorNivel2": "", "cpValorNivel3": "",
                        //    "cpValorNivel4": "", "cpValorNivel5": apartamentoText, "cpValorNivel6": "",
                        //    "mzTipoNivel1": "", "mzTipoNivel2": "", "mzTipoNivel3": "",
                        //    "mzTipoNivel4": complemento, "mzTipoNivel5": "", "mzValorNivel1": "",
                        //    "mzValorNivel2": "", "mzValorNivel3": "", "mzValorNivel4": "",
                        //    "mzValorNivel5": complementoText, "mzTipoNivel6": "", "mzValorNivel6": "",
                        //    "estadoDirGeo": "", "letra3G": "", "idDireccionDetallada": ""
                        //}
                    }
                };
                $scope.GetMGLAddressAndBindGrid();
            }
        },
            $scope.GetMGLAddressAndBindGrid = function () {
            Alert.showLoading(parent.Xrm.Page.context.getClientUrl(), TranslationCustomerAddress.data.tRetrieve, 350, 115);
            $scope.loading = true;
            $scope.BindAmxCustomerAddressGrid([]);
            $http.post(apiUrl + 'AMXRetrieveCustomerAddress', JSON.stringify($scope.workflowStartInput), config)
                .success(function (result) {
                    $scope.loading = false;
                    if (result) {
                        var resultJsonOutput = new Array();
                        var addressIdUnique = [];
                        var resultJson = JSON.parse(result.Output.addressMGLResponse);
                        if ((resultJson.categoryCode == "01" || resultJson.categoryCode == "03") &&
                            (resultJson.categoryDescription == "Error de conectividad con el legado" ||
                                resultJson.categoryDescription == "Error funcional del legado")) {
                            //Alert.show(resultJson.categoryDescription, "", new Alert.Button("Ok"), "INFO", 500, 200);
                            parent.Xrm.Utility.alertDialog(resultJson.categoryDescription);
                            //parent.Xrm.Utility.alertDialog('Functional error of the legacy. Error: The address could not be tabulated, please make it tabulated.');
                            //parent.Xrm.Utility.alertDialog("The data which is displaying in the grid is dummy data. This is only for testing. We will remove this once MGL is up");
                            //Alert.show("The data which is displaying in the grid is dummy data. This is only for testing. We will remove this once MGL is up", "", [new Alert.Button("Ok")], "INFO", 500, 200);
                        };
                        if (resultJson.listsAddress != undefined) {
                            for (var i = 0; i < resultJson.listsAddress.length; i++) {
                                if (resultJson.listsAddress[i].splitAddres != undefined) {
                                    if (addressIdUnique.indexOf(resultJson.listsAddress[i].splitAddres.idDireccionDetallada) === -1) {
                                        addressIdUnique.push(resultJson.listsAddress[i].splitAddres.idDireccionDetallada);
                                        resultJsonOutput.push({
                                            AddressID: resultJson.listsAddress[i].splitAddres.idDireccionDetallada,
                                            //City: resultJson.listsAddress[i].city.name,
                                            CityArea: parent.Xrm.Page.getAttribute("amx_cityarea").getValue()[0].name,
                                            District: parent.Xrm.Page.getAttribute("amxperu_district").getValue()[0].name,
                                            Address: resultJson.listsAddress[i].splitAddres.tipoViaPrincipal + " " +
                                            resultJson.listsAddress[i].splitAddres.numViaPrincipal + " " +
                                            //resultJson.listsAddress[i].splitAddres.ltViaPrincipal + " " +
                                            resultJson.listsAddress[i].splitAddres.numViaGeneradora + " " +
                                            //resultJson.listsAddress[i].splitAddres.ltViaGeneradora + " " +
                                            resultJson.listsAddress[i].splitAddres.placaDireccion + " " +
                                            resultJson.listsAddress[i].splitAddres.barrio
                                            //ListAddress: resultJson.listsAddress[i]
                                        });
                                    }
                                }
                            }
                        }
                        $scope.scopeData.SearchCustomerAddresses = resultJsonOutput;
                        $scope.BindAmxCustomerAddressGrid($scope.scopeData.SearchCustomerAddresses);
                    }

                }).error(function (data, status, headers, config) {
                    $scope.loading = false;
                    Alert.hide();
                    parent.Xrm.Utility.alertDialog((data.ExceptionMessage === undefined ?
                        (data.data === undefined ? data :
                            (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                    $scope.httpLoading = false;
                }).finally(function () {
                    $scope.loading = false;
                    Alert.hide();
                });
            },

            $scope.GetAddressHhpp = function (addressTab7Arry, comunidad) {
                $scope.workflowStartHhppInput = {
                    "addressMGLRequest": {
                        "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.AmxAddressMGLHhppRequest, AmxPeruPSBActivities",
                        "drDireccion": {
                            "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.DrDireccion, AmxPeruPSBActivities",
                            "id": null,
                            "estrato": null,
                            "barrio": addressTab7Arry[0].barrio != undefined ? addressTab7Arry[0].barrio : "",
                            "idSolicitud": null,
                            "idDirCatastro": "",
                            "itTipoPlaca": null,
                            "itValorPlaca": null,
                            "idTipoDireccion": addressTab7Arry[0].idTipoDireccion != undefined ? addressTab7Arry[0].idTipoDireccion : "",
                            "dirPrincAlt": "",
                            "tipoViaPrincipal": addressTab7Arry[0].tipoViaPrincipal != undefined ? addressTab7Arry[0].tipoViaPrincipal : "",
                            "numViaPrincipal": addressTab7Arry[0].numViaPrincipal != undefined ? addressTab7Arry[0].numViaPrincipal : "",
                            "ltViaPrincipal": "",
                            "nlPostViaP": "",
                            "bisViaPrincipal": "",
                            "cuadViaPrincipal": addressTab7Arry[0].cuadViaPrincipal != undefined ? addressTab7Arry[0].cuadViaPrincipal : "",
                            "tipoViaGeneradora": "",
                            "numViaGeneradora": addressTab7Arry[0].numViaGeneradora != undefined ? addressTab7Arry[0].numViaGeneradora : "",
                            "ltViaGeneradora": addressTab7Arry[0].ltViaGeneradora != undefined ? addressTab7Arry[0].ltViaGeneradora : "",
                            "nlPostViaG": "",
                            "bisViaGeneradora": "",
                            "cuadViaGeneradora": "",
                            "placaDireccion": addressTab7Arry[0].placaDireccion != undefined ? addressTab7Arry[0].placaDireccion : "",
                            "cpTipoNivel1": "",
                            "cpTipoNivel2": "",
                            "cpTipoNivel3": "",
                            "cpTipoNivel4": "",
                            "cpTipoNivel5": "",
                            "cpTipoNivel6": "",
                            "cpValorNivel1": "",
                            "cpValorNivel2": "",
                            "cpValorNivel3": "",
                            "cpValorNivel4": "",
                            "cpValorNivel5": "",
                            "cpValorNivel6": "",
                            "mzTipoNivel1": "",
                            "mzTipoNivel2": "",
                            "mzTipoNivel3": "",
                            "mzTipoNivel4": "",
                            "mzTipoNivel5": "",
                            "mzValorNivel1": "",
                            "mzValorNivel2": "",
                            "mzValorNivel3": "",
                            "mzValorNivel4": "",
                            "mzValorNivel5": "",
                            "mzTipoNivel6": "",
                            "mzValorNivel6": "",
                            "estadoDirGeo": null,
                            "letra3G": null,
                            "dirEstado": null,
                            "barrioTxtBM": null
                        },
                        "comunidad": comunidad,
                        "direccionStr": addressTab7Arry[0].direccionStr != undefined ? addressTab7Arry[0].direccionStr : "",
                        "tipoAdicion": addressTab7Arry[0].tipoAdicion != undefined ? addressTab7Arry[0].tipoAdicion : "",
                        "tipoNivel": addressTab7Arry[0].tipoNivel != undefined ? addressTab7Arry[0].tipoNivel : "",
                        "valorNivel": addressTab7Arry[0].valorNivel != undefined ? addressTab7Arry[0].valorNivel : "",
                        "idUsuario": "hitss"
                    }
                };
                $http.post(apiUrl + 'AmxGetCustomerAddressHhpp', JSON.stringify($scope.workflowStartHhppInput), config)
                    .success(function (result) {
                        $scope.loading = false;
                        if (result) {
                            var resultJsonOutput = new Array();
                            var addressIdUnique = [];
                            var resultJson = JSON.parse(result.Output.addressMGLResponse);
                            if ((resultJson.categoryCode == "01" || resultJson.categoryCode == "03") &&
                                (resultJson.categoryDescription == "Error de conectividad con el legado" ||
                                    resultJson.categoryDescription == "Error funcional del legado")) {
                                parent.Xrm.Utility.alertDialog(resultJson.categoryDescription);                               
                            };
                            if (resultJson.drDireccion != undefined) {
                                if (addressIdUnique.indexOf(resultJson.listsAddress[i].splitAddres.idDireccionDetallada) === -1) {
                                    addressIdUnique.push(resultJson.listsAddress[i].splitAddres.idDireccionDetallada);
                                    resultJsonOutput.push({
                                        AddressID: resultJson.listsAddress[i].splitAddres.idDireccionDetallada,
                                        //City: resultJson.listsAddress[i].city.name,
                                        CityArea: parent.Xrm.Page.getAttribute("amx_cityarea").getValue()[0].name,
                                        District: parent.Xrm.Page.getAttribute("amxperu_district").getValue()[0].name,
                                        Address: resultJson.listsAddress[i].splitAddres.tipoViaPrincipal + " " +
                                        resultJson.listsAddress[i].splitAddres.numViaPrincipal + " " +
                                        //resultJson.listsAddress[i].splitAddres.ltViaPrincipal + " " +
                                        resultJson.listsAddress[i].splitAddres.numViaGeneradora + " " +
                                        //resultJson.listsAddress[i].splitAddres.ltViaGeneradora + " " +
                                        resultJson.listsAddress[i].splitAddres.placaDireccion + " " +
                                        resultJson.listsAddress[i].splitAddres.barrio
                                        //ListAddress: resultJson.listsAddress[i]
                                    });
                                }

                            }
                            $scope.scopeData.SearchCustomerAddresses = resultJsonOutput;
                            $scope.BindAmxCustomerAddressGrid($scope.scopeData.SearchCustomerAddresses);
                        }

                    }).error(function (data, status, headers, config) {
                        $scope.loading = false;
                        Alert.hide();
                        parent.Xrm.Utility.alertDialog((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                        $scope.httpLoading = false;
                    }).finally(function () {
                        $scope.loading = false;
                        Alert.hide();
                    });
            },

        $scope.amxCustomerAddressGrid.onRegisterApi = function (gridApi) {
                $scope.amxCustomerAddressGridApi = gridApi;
                $scope.gridApi = gridApi;
                $scope.amxCustomerAddressGridApi.grid.registerRowsProcessor($scope.amxCustomerAddressGridSingleFilter, 200);
                //$scope.amxCustomerAddressGridApi.selection.on.rowSelectionChanged($scope, function (row) {
                gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                    $scope.amxCustomerAddressGrid.selectedRow = [
                        {
                            //listAddress: row.entity.ListAddress,
                            district: row.entity.District,
                            city: row.entity.City,
                            cityarea: row.entity.CityArea,
                            address: row.entity.Address,
                            addressId: row.entity.AddressID
                            
                        }
                    ];
                    
                    var indexOf = -1;
                    for (var ind = 0; ind < $scope.amxCustomerAddressGrid.selectedItems.length; ind++) {
                        if ($scope.amxCustomerAddressGrid.selectedItems[ind][0].id == row.entity.id) {
                            indexOf = ind;
                        }
                    }
                    if (row.isSelected) {
                        if (indexOf < 0) {
                            $scope.amxCustomerAddressGrid.selectedItems.push($scope.amxCustomerAddressGrid.selectedRow);
                        }
                    }
                    else {
                        if (indexOf > -1) {
                            $scope.amxCustomerAddressGrid.selectedItems.splice(indexOf, 1);
                        }
                    }
                });
                //if ($scope.amxCustomerAddressGrid.selectedItems.length > 0) {
                //    document.getElementById("btnConfirm").disabled = false;
                //}
                //else { document.getElementById("btnConfirm").disabled = true; }
            };

        var strVar = "";
        strVar += "<div ng-mouseover=\"rowStyle={'background-color': '#D6EBFF'}; grid.appScope.onRowHover(this);\" ng-mouseleave=\"rowStyle={}\">";
        strVar += "    <div ng-style=\"rowStyle\" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.uid\" ui-grid-one-bind-id-grid=\"rowRenderIndex + '-' + col.uid + '-cell'\"";
        strVar += "         class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" role=\"{{col.isRowHeader ? 'rowheader' : 'gridcell'}}\" ui-grid-cell>";
        strVar += "    <\/div>";
        strVar += "<\/div> ";

       
        $scope.filter = function () {
            $scope.amxCustomerAddressGridApi.grid.refresh();
        };
        $scope.amxCustomerAddressGridSingleFilter = function (renderableRows) {
            var matcher = new RegExp((!$scope.filterValue) ? $scope.filterValue : $scope.filterValue.toLowerCase());
            renderableRows.forEach(function (row) {
                var match = false;
                ['addressid', 'district', 'city', 'cityarea', 'address'].forEach(function (field) {
                    match = true;
                });
                if (!match) {
                    row.visible = false;
                }
            });
            return renderableRows;
        };
        $scope.BindAmxCustomerAddressGrid = function (data) {
            if (data == null) { return; }
            for (var i = 0; i < data.length; i++) { data[i].id = i; }
            $scope.amxCustomerAddressGrid.data = data;
            $scope.amxCustomerAddressGrid.columnDefs = [
                //{ name: "addressid", displayName: "Address ID", field: 'AddressID', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 150 },
                //{ name: "checkrow", displayName: "", field: 'checkrow', enableCellEdit: true, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, cellTemplate: '<input type="checkbox" ng-model="row.entity.field03">' },
                //{ name: "district", displayName: "District", field: 'District', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: '15%' },
                //{ name: "city", displayName: "City", field: 'City', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: '15%' },
                //{ name: "cityarea", displayName: "City area", field: 'CityArea', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: '15%' },
                //{ name: "address", displayName: "Address", field: 'Address', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, cellTemplate: '<div class="ui-grid-cell-contents" ><a href="#" title="{{COL_FIELD}}"><span>{{COL_FIELD}}</span></a></div>', width: '55%' }
                { name: "address", displayName: "Address", field: 'Address', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: '100%' }
            ];
        }; 
        TranslationCustomerAddress = {
            data: null,
            GetData: function () {
                var formId = "CustomerAddressMGL";
                if (TranslationCustomerAddress.data == null) {
                    TranslationCustomerAddress.data = GetTranslationData(formId);
                }
                return TranslationCustomerAddress.data;
            }
        };
        //document.getElementById("btnConfirm").disabled = true;
        TranslationCustomerAddress.GetData();
        $scope.BindAmxCustomerAddressGrid($scope.scopeData.SearchCustomerAddresses);
    }]);

