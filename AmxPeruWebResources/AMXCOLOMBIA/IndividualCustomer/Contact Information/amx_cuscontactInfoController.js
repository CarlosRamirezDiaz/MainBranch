var app = angular.module("app", ["xeditable", "ngMockE2E"]);

app.run(function (editableOptions) {
    editableOptions.theme = 'bs3';
});

app.controller('Ctrl', function ($scope, $filter, $http) {
    $scope.ccInformations = []; var availableDomains = []; var fixedLineCodeArray = [];
    TranslationCustomerContactInfo = {
        data: null,
        GetData: function () {
            var formId = "CustomerContactInfo";
            if (TranslationCustomerContactInfo.data == null) {
                TranslationCustomerContactInfo.data = GetTranslationData(formId);
            }
            return TranslationCustomerContactInfo.data;
        }
    };    
    TranslationCustomerContactInfo.GetData();    
    $scope.fixedLineCharCode = [];
    $scope.getSetCrmConfigData = function () {
        var emailDomain = ""; fixedLineCode = ""; availableDomains = []; fixedLineCodeArray = [];
        AMX.COMMON.RetrieveCrmConfigurationWebApi("EmailDomain", function (sData) { if (sData.length > 0) { emailDomain = sData; } }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
        AMX.COMMON.RetrieveCrmConfigurationWebApi("FixedLineAreaCode", function (sData) { if (sData.length > 0) { fixedLineCode = sData; } }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
        emailDomain = emailDomain.split(';'); fixedLineCode = fixedLineCode.split(';');
        for (var i = 0; i < emailDomain.length; i++) { availableDomains.push("@" + emailDomain[i]); }
        for (var i = 0; i < fixedLineCode.length; i++) { fixedLineCodeArray.push(fixedLineCode[i]); }
        for (var i = 0; i < fixedLineCode.length; i++) { $scope.fixedLineCharCode.push(fixedLineCode[i].substr(0, 1)); }
    };

    $scope.getSetCrmConfigData();
    $scope.onContactInfoChange = function (event) {
        var informations = $scope.ccInformations;
        var contactType = $scope.ccInformations[$scope.selectedIndex - 1].contacttype;
        var autoCompleteId = "#autocomplete" + ($scope.selectedIndex - 1).toString();
        $(autoCompleteId).autocomplete({
            //source: availableDomains	
            classes: {
                "ui-autocomplete": "customAutoComplete",
            },
            source: function (request, response) {
                var originalValue = $(autoCompleteId).val();
                var matcher = new RegExp("^" + $.ui.autocomplete.escapeRegex(request.term), "i");
                var data = $.grep(availableDomains, function (value) {
                    return value.substring(0, request.term.length).toLowerCase() == request.term.toLowerCase();
                });
                response(autoCompleteId, data);
                // response($.grep(availableDomains,function(item){
                // return matcher.test(item);
                // }));
            },
            select: function (event, ui) {
                $(autoCompleteId).val(ui.item.value);
                ui.item.value = ui.item.value;
            },
            change: function (event, ui) {
                var emailAddress1 = $(autoCompleteId).val();
                emailAddress1 = emailAddress1.substring(emailAddress1.indexOf("@") + 1, emailAddress1.length);
                if (emailAddress1.indexOf(".") < 0) {
                    //alert("Please enter valid email");
                    //alert(AMX.IndividualForm.TData.tValidateEmail)
                }
            }
        });
    };

    $scope.isInvalidFixedline = false;
    $scope.fixedLineOnChange = function () {
        var informations = $scope.ccInformations;
        var contactType = $scope.ccInformations[$scope.selectedIndex - 1].contacttype;
        var autoCompleteId = "#flautocomplete" + ($scope.selectedIndex - 1).toString();
        $(autoCompleteId).autocomplete({
            //source: fixedLineCodeArray	
            classes: {
                "ui-autocomplete": "customAutoComplete",
            },
            source: function (request, response) {
                var originalValue = $(autoCompleteId).val();
                var matcher = new RegExp("^" + $.ui.autocomplete.escapeRegex(request.term), "i");
                var data = $.grep(fixedLineCodeArray, function (value) {
                    return value.substring(0, request.term.length).toLowerCase() == request.term.toLowerCase();
                });
                if (originalValue.length == 1 && data.length == 0) { $scope.isInvalidFixedline = true; }
                response(autoCompleteId, data);
            },
            select: function (event, ui) {
                var originalValue = $(autoCompleteId).val();
                ui.item.value = ui.item.value;
            },
            change: function (event, ui) {
                var emailAddress1 = $(autoCompleteId).val();
                emailAddress1 = emailAddress1.substring(emailAddress1.indexOf("@") + 1, emailAddress1.length);
                if (emailAddress1.indexOf(".") < 0) {
                    //alert(AMX.IndividualForm.TData.tValidateEmail)
                }
            }
        });
        $(autoCompleteId).autocomplete("widget").addClass("fixedHeight");
    };

    $scope.selectedIndex = 0;
    $scope.numberFieldOnChange = function (event) {
        var informations = $scope.ccInformations;
        var contactType = $scope.ccInformations[$scope.selectedIndex - 1].contacttype;
        if (contactType == 1) {
            return;
        }
        if (isNaN(String.fromCharCode(event.keyCode))) {
            event.preventDefault();
        }
    };

    $scope.contactInfoArray = [];
    $scope.contactTypes = [{ value: 173800000, text: TranslationCustomerContactInfo.data.tEmail }, { value: 173800001, text: TranslationCustomerContactInfo.data.tCell }, { value: 173800002, text: TranslationCustomerContactInfo.data.tFixed },];
    $scope.IsPrimaryValues = [{ value: 1, text: TranslationCustomerContactInfo.data.tYes }, { value: 0, text: 'No' },];
    $scope.fixedOrMobiles = [{ value: 1, text: 'Mobile' }, { value: 2, text: 'Fixedline' },];

    $scope.showFixedOrMobiles = function (ccInformation) {
        var selected = [];
        if (ccInformation.fixedOrMobile) {
            selected = $filter('filter')($scope.fixedOrMobiles, {
                value: ccInformation.fixedOrMobile
            });
        }
        return selected.length ? selected[0].text : TranslationCustomerContactInfo.data.tNotset;
    };

    $scope.showContactTypes = function (ccInformation) {
        var selected = [];
        if (ccInformation.contacttype) {
            selected = $filter('filter')($scope.contactTypes, {
                value: ccInformation.contacttype
            });
        }
        return selected.length ? selected[0].text : TranslationCustomerContactInfo.data.tNotset;
    };

    $scope.finalPrimaryValue = false;
    $scope.showIsPrimaryValues = function (ccInformation) {
        var selected = [];
        // if($scope.isSave == true){
        // for(var x = 0; x < $scope.finalJsonArray.length; x++){
        // if($scope.finalJsonArray[x].id == $scope.selectedIndex){
        // ccInformation.isprimary = $scope.finalJsonArray[x].isprimary;
        // $scope.isSave = false;
        // break;
        // } 
        // }
        // }		
        if (ccInformation.isprimary) {
            selected = $filter('filter')($scope.IsPrimaryValues, {
                value: ccInformation.isprimary
            });
        }

        if ($scope.isPrimaryConfirm == 0 && $scope.isPrimaryConfirm !== "" && $scope.ccInformations[$scope.selectedIndex - 1].isprimary == 0) {
            $scope.finalPrimaryValue = true;
            $scope.ccInformations[$scope.selectedIndex - 1].isprimary = 0; selected = { value: 0 };
        }
        return selected.length ? selected[0].text : 'No';
    };
    $scope.saveText = function() {

    };

    $scope.editCCInformation = function (rowform, ccInformation) {
        $scope.selectedIndex = ccInformation.primaryid == undefined && $scope.selectedIndex == 0 ? $scope.selectedIndex : ccInformation.id;
        rowform.$show();
        var informations = $scope.ccInformations;
        $scope.ccInformations[ccInformation.id - 1].fixedOrMobile = 1;
    };

    $scope.validateEmailInfo = function (data, ccInformation) {
        var emailAddress1 = $('#autocomplete' + (ccInformation.id - 1).toString()).val();
        if (emailAddress1 != undefined) { emailAddress1 = emailAddress1.substring(emailAddress1.indexOf("@") + 1, emailAddress1.length); }
        if ((emailAddress1 == undefined || emailAddress1.indexOf(".") < 0) && ccInformation.contacttype == 173800000) { return TranslationCustomerContactInfo.data.tVEmail; }
    };

    $scope.validateMobileInfo = function (data, ccInformation) {
        if ((data == undefined || data.length < 10) && ccInformation.contacttype == 173800001) { return TranslationCustomerContactInfo.data.tVCell; }
    };

    $scope.validateFixedlineInfo = function (data, ccInformation) {
        if ((data == undefined || data.length < 8) && ccInformation.contacttype == 173800002) {
            return TranslationCustomerContactInfo.data.tVFixed;
        }
        if (data.length == 8 && ccInformation.contacttype == 173800002) {
            var result = jQuery.inArray(data.toString().substr(0, 1), $scope.fixedLineCharCode);
            if (result == -1) {
                return TranslationCustomerContactInfo.data.tVFixed;
            }
        }
    };

    $scope.validateContactType = function (data, id) {
        if (data == 0) { return TranslationCustomerContactInfo.data.tVContacttype; }
    };

    $scope.setFinalJsonArray = function () {
        $scope.finalJsonArray = [];
        for (var x = 0; x < $scope.ccInformations.length; x++) {
            $scope.finalJsonArray.push({
                id: $scope.ccInformations[x].id,
                contacttype: $scope.ccInformations[x].contacttype,
                contactinfo: $scope.ccInformations[x].contactinfo == undefined ? "" : $scope.ccInformations[x].contactinfo,
                mobileInfo: $scope.ccInformations[x].mobileInfo == undefined ? "" : $scope.ccInformations[x].mobileInfo.toString(),
                fixedlineInfo: $scope.ccInformations[x].fixedlineInfo == undefined ? "" : $scope.ccInformations[x].fixedlineInfo.toString(),
                fixedOrMobile: $scope.ccInformations[x].fixedOrMobile,
                isprimary: $scope.ccInformations[x].isprimary
            });
        }
        var finalJson = JSON.stringify($scope.finalJsonArray);
        parent.Xrm.Page.getAttribute("amx_ccinfojsontext").setValue(finalJson);
    };

    $scope.isPrimaryConfirm; $scope.isPrimarySelectedValue = ""; $scope.isPrimaryDefaultValue = "";
    $scope.isPrimaryOnChange = function (ccInformation, data) {
        if (data != undefined && data == 1) {
            $scope.isPrimarySelectedValue = data;
            $scope.ccInformations[$scope.selectedIndex - 1].isprimary = data;
            return;
        }
        if (data != undefined && data == 0) { $scope.isPrimarySelectedValue = data; $scope.ccInformations[$scope.selectedIndex - 1].isprimary = data; $scope.isPrimaryDefaultValue = 0; return; }
        if (ccInformation.isprimary == 0) { $scope.ccInformations[ccInformation.id - 1].isprimary = 0; return; }

        var informations = $scope.ccInformations;
        var findArray = [];
        currentArray = [ccInformation.contacttype.toString() + ";" + ccInformation.isprimary];
        for (var i = 0; i < informations.length; i++) { if (i != ($scope.selectedIndex - 1)) findArray.push(informations[i].contacttype + ";" + informations[i].isprimary); }
        var findResultId = jQuery.inArray(currentArray[0], findArray);
        if (findResultId + 1 >= $scope.selectedIndex) { findResultId = findResultId + 1 }
        else if (findResultId == 0 && $scope.selectedIndex == 2) { findResultId = 0; }
        else if (findResultId == 0 && $scope.selectedIndex == 1) { findResultId = 1; }
        var result = 0;
        for (var k = 0; k < findArray.length; k++) { if (findArray[k] == currentArray[0]) { result++; /*if( result > 1){break;}*/ } }
        if (result > 0) {
            var confirmResult = confirm(TranslationCustomerContactInfo.data.tConfirm);
            if (confirmResult) {
                $scope.isPrimaryConfirm = 1;
                $scope.ccInformations[findResultId].isprimary = 0;
            } else {
                $scope.isPrimaryConfirm = 0;
                $scope.ccInformations[ccInformation.id - 1].isprimary = 0;

            }
        }
    };
    $scope.clearPrimaryFields = function () {
        $scope.isPrimaryConfirm = ""; $scope.isPrimarySelectedValue = ""; $scope.isPrimaryDefaultValue = "";
    };
    $scope.isSave = false;
    $scope.saveCCInformation = function (data, id) {
        $scope.isSave = true;
        $scope.selectedIndex = $scope.selectedIndex == 0 ? $scope.selectedIndex : id;
        var finalJson = null;
        var conInfoArrayResult = $scope.ccInformations;
        angular.extend(data, { id: id });
        for (var z = 0; z < conInfoArrayResult.length; z++) {
            if (conInfoArrayResult[z].id == id) {
                if ($scope.isPrimarySelectedValue != "") { conInfoArrayResult[z].isprimary = $scope.isPrimarySelectedValue; }
                $scope.isPrimaryOnChange(conInfoArrayResult[z]);
                if ($scope.isPrimaryConfirm == 1) { data.isprimary = 1; } else if (($scope.isPrimaryConfirm == 0 && data.isprimary == 0) || ($scope.isPrimarySelectedValue == 0 && data.isprimary == 0)) { data.isprimary = 0; }
                data.contactinfo = $('#autocomplete' + z.toString()).val();
                data.primaryid = $scope.ccInformations[z].primaryid;
                data.isprimary = $scope.ccInformations[z].isprimary;
                $scope.ccInformations[z] = data;
                $scope.ccInformations[z].contactinfo = $('#autocomplete' + z.toString()).val();
                $scope.setFinalJsonArray();
                $scope.isInvalidFixedline = false;
                return $http.post('/saveCCInformation', data);
            }
        }
        $scope.ccInformations[id - 1].contactinfo = $('#autocomplete' + (id - 1).toString()).val();
        $scope.contactInfoArray.push(data);

        $scope.setFinalJsonArray();
        return $http.post('/saveCCInformation', data);
    };

    // remove ccInformation
    $scope.removeCCInformation = function (index) {
        $scope.ccInformations.splice(index, 1);
        var conInfoArrayResult = $scope.contactInfoArray;
        delete conInfoArrayResult[index];
        $scope.contactInfoArray = conInfoArrayResult;
    };



    $scope.selectedContactType = null;
    $scope.contactTypeOnChange = function (data, ccInformation) {
        $scope.selectedIndex = $scope.selectedIndex == 0 ? $scope.selectedIndex : ccInformation.id;
        var informations = $scope.ccInformations;
        $scope.ccInformations[ccInformation.id - 1].contacttype = data;
    };
    $scope.mobileInfoOnChange = function (data, ccInformation) {
        var informations = $scope.ccInformations;
        $scope.ccInformations[ccInformation.id - 1].contacttype = data;

    };

    // add ccInformation
    $scope.addCCInformation = function () {
        $scope.selectedIndex += 1;
        $scope.inserted = {
            id: $scope.ccInformations.length + 1,
            contacttype: 0,
            contactinfo: '',
            mobileInfo: '',
            fixedlineInfo: '',
            fixedOrMobile: 0,
            isprimary: 0
        };
        $scope.saveText = TranslationCustomerContactInfo.data.tSave;
        $scope.cancelText = TranslationCustomerContactInfo.data.tCancel;
        $scope.editText = TranslationCustomerContactInfo.data.tEdit;
        $scope.deleteText = TranslationCustomerContactInfo.data.tDelete;
        $scope.ccInformations.push($scope.inserted);
    };
});

// --------------- mock $http requests ----------------------
app.run(function ($httpBackend) {
    // $httpBackend.whenGET('/groups').respond([
    // {id: 1, text: 'ccInformation'},
    // {id: 2, text: 'customer'},
    // {id: 3, text: 'vip'},
    // {id: 4, text: 'admin'}
    // ]);

    $httpBackend.whenPOST(/\/saveCCInformation/).respond(function (method, url, data) {
        data = angular.fromJson(data);
        return [200, {
            status: 'ok'
        }];
    });
});