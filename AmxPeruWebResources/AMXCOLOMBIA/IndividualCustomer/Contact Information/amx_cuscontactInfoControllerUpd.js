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

    endPoints = {
        serverUrl: parent.Xrm.Page.context.getClientUrl(),
        oData: parent.Xrm.Page.context.getClientUrl() + "/XRMServices/2011/OrganizationData.svc",
        SOAP: parent.Xrm.Page.context.getClientUrl() + "/XRMServices/2011/Organization.svc/web"
    };

    $scope.selectedIndex = 0;

    GetRecords = function (entityLogicalName, entityId, pSelect, pFilter/*, requestURL*/, getAsync, pOrder, pTop, pExpand) {
        var requestURL = endPoints.oData;
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


    $scope.getCCsInformation = function () {

        $scope.ccInformations = [];
        var contactid = parent.Xrm.Page.data.entity.getId();
        contactid = contactid.replace("{", "").replace("}", "");

        var ccList = GetRecords("amx_customercontactinformation", null, "amx_customercontactinformationId,amx_ContactType,amx_Email,amx_PhoneNo,amx_PrimaryContactType,amx_MobileFixed", "amx_IndividualCustomerId/Id eq (guid'" + contactid + "')", false, null, null, null);

        if (ccList) {

            for (i = 0; i < ccList.length; i++) {

                var info;
                var ismobilefixed = 0;
                var isPrimary = 0;

                if (ccList[i].amx_MobileFixed) {
                    ismobilefixed = 1;
                }

                if (ccList[i].amx_PrimaryContactType) {
                    isPrimary = 1;
                }

                $scope.selectedIndex += 1;
                $scope.inserted = {
                    guid: ccList[i].amx_customercontactinformationId,
                    id: $scope.ccInformations.length + 1,
                    contacttype: ccList[i].amx_ContactType.Value,
                    contactinfo: ccList[i].amx_ContactType.Value == 173800000 ? ccList[i].amx_Email : '',
                    mobileInfo: ccList[i].amx_ContactType.Value == 173800001 ? ccList[i].amx_PhoneNo : '',
                    fixedlineInfo: ccList[i].amx_ContactType.Value == 173800002 ? ccList[i].amx_PhoneNo : '',
                    fixedOrMobile: ismobilefixed,
                    isprimary: isPrimary
                };
                $scope.ccInformations.push($scope.inserted);
            }
        }

        $scope.saveText = TranslationCustomerContactInfo.data.tSave;
        $scope.cancelText = TranslationCustomerContactInfo.data.tCancel;
        $scope.editText = TranslationCustomerContactInfo.data.tEdit;
        $scope.deleteText = TranslationCustomerContactInfo.data.tDelete;

        $scope.inserted = null;
    }

    function LaunchActionNoParams(entityId, entityName, requestName) {
        /// <summary>Ejecuta un Custom Action teniendo en cuenta el Id de la entidad, el nombre de la entidad y el nombre único del Action. Retorna el request después de haberlo ejecutado.</summary>
        /// <param name="entityId" type="String">Id de la entidad donde está el Action</param>
        /// <param name="entityName" type="String">Nombre lógico de la entidad donde está el Action.</param>
        /// <param name="requestName" type="String">Nombre único del Action a ejecutar.</param>
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
    }

    function ProcessSoapError(faultXml) {
        ///<summary>
        /// Parses the WCF fault returned in the event of an error.
        ///</summary>
        ///<param name="faultXml" Type="XML">
        /// The responseXML property of the XMLHttpRequest response.
        ///</param>
        var errorMessage = "Unknown Error (Unable to parse the fault)";
        if (typeof faultXml == "object") {
            try {
                var bodyNode = faultXml.firstChild.firstChild;
                //Retrieve the fault node
                for (var i = 0; i < bodyNode.childNodes.length; i++) {
                    var node = bodyNode.childNodes[i];

                    //NOTE: This comparison does not handle the case where the XML namespace changes
                    if ("s:Fault" == node.nodeName) {
                        for (var j = 0; j < node.childNodes.length; j++) {
                            var faultStringNode = node.childNodes[j];
                            if ("faultstring" == faultStringNode.nodeName) {
                                errorMessage = faultStringNode.textContent;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            catch (e) { };
        }
        return new Error(errorMessage);
    }

    // add ccInformation
    $scope.addCCInformation = function () {
        $scope.selectedIndex += 1;
        $scope.inserted = {
            guid: '',
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

    //$scope.validateContactType = function (data, id) {
    //    if (data == 0) { return "Please select valid contact type"; }
    //};

    $scope.validateContactType = function (data, id) {
        if (data == 0) { return TranslationCustomerContactInfo.data.tVContacttype; }
    };

    $scope.contactTypeOnChange = function (data, ccInformation) {
        $scope.selectedIndex = $scope.selectedIndex == 0 ? $scope.selectedIndex : ccInformation.id;
        var informations = $scope.ccInformations;
        $scope.ccInformations[ccInformation.id - 1].contacttype = data;
    };

    $scope.validateEmailInfo = function (data, ccInformation) {
        var emailAddress1 = $('#autocomplete' + (ccInformation.id - 1).toString()).val();
        if (emailAddress1 != undefined) { emailAddress1 = emailAddress1.substring(emailAddress1.indexOf("@") + 1, emailAddress1.length); }
        if ((emailAddress1 == undefined || emailAddress1.indexOf(".") < 0) && ccInformation.contacttype == 173800000) { return "Please enter valid email"; }
    };

    $scope.getSetCrmConfigData = function () {
        var emailDomain = ""; fixedLineCode = ""; availableDomains = []; fixedLineCodeArray = [];
        AMX.COMMON.RetrieveCrmConfigurationWebApi("EmailDomain", function (sData) { if (sData.length > 0) { emailDomain = sData; } }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
        AMX.COMMON.RetrieveCrmConfigurationWebApi("FixedLineAreaCode", function (sData) { if (sData.length > 0) { fixedLineCode = sData; } }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
        emailDomain = emailDomain.split(';'); fixedLineCode = fixedLineCode.split(';');
        for (var i = 0; i < emailDomain.length; i++) { availableDomains.push("@" + emailDomain[i]); }
        for (var i = 0; i < fixedLineCode.length; i++) { fixedLineCodeArray.push(fixedLineCode[i]); }
        for (var i = 0; i < fixedLineCode.length; i++) { $scope.fixedLineCharCode.push(fixedLineCode[i].substr(0, 1)); }

        $scope.getCCsInformation();
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

    $scope.validateMobileInfo = function (data, ccInformation) {
        if ((data == undefined || data.length < 10) && ccInformation.contacttype == 173800001) { return TranslationCustomerContactInfo.data.tVCell; }
    };


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

    $scope.clearPrimaryFields = function () {
        $scope.isPrimaryConfirm = ""; $scope.isPrimarySelectedValue = ""; $scope.isPrimaryDefaultValue = "";
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
            //var confirmResult = confirm("Already another contact type is set to primary. Do you want this to be primary contact type?");
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
                data.guid = $scope.ccInformations[z].guid;
                $scope.ccInformations[z] = data;
                $scope.ccInformations[z].contactinfo = $('#autocomplete' + z.toString()).val();
                $scope.setFinalJsonArray();
                $scope.isInvalidFixedline = false;
                parent.Xrm.Page.data.entity.save();
             
                //return $http.post('/saveCCInformation', data);
            }
        }
        $scope.ccInformations[id - 1].contactinfo = $('#autocomplete' + (id - 1).toString()).val();
        $scope.contactInfoArray.push(data);

        $scope.setFinalJsonArray();

        //return $http.post('/saveCCInformation', data);
    };

    $scope.editCCInformation = function (rowform, ccInformation) {
        $scope.getCCsInformation();

        $scope.selectedIndex = ccInformation.primaryid == undefined && $scope.selectedIndex == 0 ? $scope.selectedIndex : ccInformation.id;
        rowform.$show();
        var informations = $scope.ccInformations;
        $scope.ccInformations[ccInformation.id - 1].fixedOrMobile = 1;
    };

    $scope.contactInfoArray = [];

    // remove ccInformation
    $scope.removeCCInformation = function (index) {

        $scope.ccInformations.splice(index, 1);
        var conInfoArrayResult = $scope.contactInfoArray;
        delete conInfoArrayResult[index];
        $scope.contactInfoArray = conInfoArrayResult;

        $scope.setFinalJsonArray();
        parent.Xrm.Page.data.entity.save();
    };

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

    $scope.setFinalJsonArray = function () {
        $scope.finalJsonArray = [];
        for (var x = 0; x < $scope.ccInformations.length; x++) {
            $scope.finalJsonArray.push({
                guid: $scope.ccInformations[x].guid,
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
        parent.Xrm.Page.getAttribute("amx_ccinfoupdjsontext").setValue(finalJson);
    };

    $scope.selectedContactType = null;

    $scope.mobileInfoOnChange = function (data, ccInformation) {
        var informations = $scope.ccInformations;
        $scope.ccInformations[ccInformation.id - 1].contacttype = data;

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