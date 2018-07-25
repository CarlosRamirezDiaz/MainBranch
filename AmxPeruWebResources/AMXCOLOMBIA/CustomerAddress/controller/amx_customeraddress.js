if (typeof (AMX) == "undefined") {
    AMX = { __namespace: true };
}
AMX.CustomerAddress = {
    ApiUrl: null,
    CusAddress: null,
    AddressArr: [],
    IsMGLAddDetailsAvailable: false,
    DefaultDistrict: null, 
    CustomerIdToUpdate: null,
    ConfigValue: null,
    BMAddressTypeSet :[],
    ITAddressTypeSet: [],
    Complemento: [],
    Apartmento: [],
    OnLoad: function () {
        var formType = Xrm.Page.ui.getFormType();
        if (formType == 2) { Xrm.Page.getAttribute("amx_cityarea").setRequiredLevel("required"); }
        Xrm.Page.getAttribute("etel_cityid").setRequiredLevel("required");        
        AMX.CustomerAddress.ManipulateTypeOptions();
        AMX.CustomerAddress.SetMGLConfigValues();
        AMX.CustomerAddress.RegisterOnLoadEvents();        
        AMX.CustomerAddress.ShowHideAddressFreeTextTab();
        AMX.CustomerAddress.GetAddressCode();
        AMX.CustomerAddress.ShowHideMatchingAddressGrid();
        AMX.CustomerAddress.SetHeaderValues();
        if (AMX.CustomerAddress.IsMGLAddDetailsAvailable == true) {
            AMX.COMMON.ShowHideSection("customeraddress", "matchingaddress", false);
        } else {
            AMX.COMMON.ShowHideSection("customeraddress", "matchingaddress", true);
        }

    },
    OnSave: function (context) {
        var saveEvent = context.getEventArgs();
        if (saveEvent.getSaveMode() == 70) { //Form AutoSave Event
            saveEvent.preventDefault(); //Stops the Save Event
        }
    },

    SetMGLConfigValues: function () {
        var mglConfigValues = "BMTypeset;";
        for (var i = 0; i < AMX.CustomerAddress.BMAddressTypeSet.length; i++) { mglConfigValues += AMX.CustomerAddress.BMAddressTypeSet[i] + ";"; }
        mglConfigValues = mglConfigValues.substring(0, mglConfigValues.length - 1);
        mglConfigValues += "@ITTypeset;";
        for (var i = 0; i < AMX.CustomerAddress.ITAddressTypeSet.length; i++) { mglConfigValues += AMX.CustomerAddress.ITAddressTypeSet[i] + ";"; }
        mglConfigValues = mglConfigValues.substring(0, mglConfigValues.length - 1);
        mglConfigValues += "@Complemento;";
        for (var i = 0; i < AMX.CustomerAddress.Complemento.length; i++) { mglConfigValues += AMX.CustomerAddress.Complemento[i] + ";"; }
        mglConfigValues = mglConfigValues.substring(0, mglConfigValues.length - 1);
        mglConfigValues += "@Apartmento;";
        for (var i = 0; i < AMX.CustomerAddress.Apartmento.length; i++) { mglConfigValues += AMX.CustomerAddress.Apartmento[i] + ";"; }
        mglConfigValues = mglConfigValues.substring(0, mglConfigValues.length - 1);
        AMX.COMMON.SetAttributeValue("amx_mglconfigvalues", mglConfigValues);
    },

    ManipulateTypeOptions: function () {
        var ifMglFromTcrm = "";
        AMX.COMMON.RetrieveCrmConfigurationWebApi("MGL_Config_TCRM", function (sData) { if (sData.length > 0) { ifMglFromTcrm = sData; } }, function (eData) { Xrm.Utility.alertDialog(eData); }, false);
        if (ifMglFromTcrm == "yes") {
            AMX.COMMON.RetrieveCrmConfigurationWebApi("MGL_Type_Options", function (sData) { if (sData.length > 0) { AMX.CustomerAddress.ConfigValue = sData; } }, function (eData) { Xrm.Utility.alertDialog(eData); }, false);
            if (AMX.CustomerAddress.ConfigValue != null) {
                var configValueStr = AMX.CustomerAddress.ConfigValue.split('@');
                var bmArray = configValueStr[0].split(';'); AMX.CustomerAddress.PushDataToArray(bmArray, "bmArray");
                var itArray = configValueStr[1].split(';'); AMX.CustomerAddress.PushDataToArray(itArray, "itArray");
                var complementoArray = configValueStr[2].split(';'); AMX.CustomerAddress.PushDataToArray(complementoArray, "complementoArray");
                var apartmentoArray = configValueStr[3].split(';'); AMX.CustomerAddress.PushDataToArray(apartmentoArray, "apartmentoArray");
            }
        }
        else {
            AMX.COMMON.RetrieveCrmConfigurationWebApi("PsbRestServiceUrl", function (sData) {
                if (sData.length > 0) {
                    var apiUrl = sData;
                    var psbInput = { "tipoRed": "UNI" };
                    jQuery.ajax({
                        type: "POST", contentType: "application/json; charset=utf-8", datatype: "json", data: JSON.stringify(psbInput),
                        async: false, cache: false, url: apiUrl + 'AmxGetMGLTabularConfiguration', xhrFields: { withCredentials: true },
                        beforeSend: function (XMLHttpRequest) { XMLHttpRequest.setRequestHeader("Accept", "application/json"); },
                        success: function (data, textStatus, XmlHttpRequest) {
                            if (data) {
                                debugger;
                                var resultJsonOutput = new Array();
                                var resultJson = JSON.parse(data.Output.mglConfigurationResponse);
                                if (resultJson.categoryCode == "03") {
                                    Xrm.Utility.alertDialog(resultJson.categoryDescription); return;
                                }
                                //Complemento
                                if (resultJson.complementoValues != undefined) {
                                    if (resultJson.complementoValues.complementoDir != undefined) {
                                        for (var i = 0; i < resultJson.complementoValues.complementoDir.length; i++) { AMX.CustomerAddress.Complemento.push(resultJson.complementoValues.complementoDir[i].idParametro); }
                                    }
                                }
                                //BM Typeset values
                                if (resultJson.bmValues != undefined) {
                                    if (resultJson.bmValues.tipoConjuntoBm != undefined) {
                                        for (var i = 0; i < resultJson.bmValues.tipoConjuntoBm.length; i++) { AMX.CustomerAddress.BMAddressTypeSet.push(resultJson.bmValues.tipoConjuntoBm[i].idParametro); }
                                    }
                                    for (var x = 1; x < 5; x++) {
                                        var subdivisionBm = "subdivision" + x + "Bm";
                                        if (resultJson.bmValues[subdivisionBm] != undefined) {
                                            for (var i = 0; i < resultJson.bmValues[subdivisionBm].length; i++) { AMX.CustomerAddress.BMAddressTypeSet.push(resultJson.bmValues[subdivisionBm][i].idParametro); }
                                            if (resultJson.bmValues[subdivisionBm].length == undefined) { AMX.CustomerAddress.BMAddressTypeSet.push(resultJson.bmValues[subdivisionBm].idParametro); }
                                        }
                                    }
                                }
                                //IT Typeset values
                                if (resultJson.itValues != undefined) {
                                    if (resultJson.itValues.placaIt != undefined) {
                                        for (var i = 0; i < resultJson.itValues.placaIt.length; i++) { AMX.CustomerAddress.ITAddressTypeSet.push(resultJson.itValues.placaIt[i].idParametro); }
                                    }
                                    for (var x = 1; x < 7; x++) {
                                        var intrBM = "intr" + x + "It";
                                        if (resultJson.itValues[intrBM] != undefined) {
                                            for (var i = 0; i < resultJson.itValues[intrBM].length; i++) { AMX.CustomerAddress.ITAddressTypeSet.push(resultJson.itValues[intrBM][i].idParametro); }
                                            if (resultJson.itValues[intrBM].length == undefined) { AMX.CustomerAddress.ITAddressTypeSet.push(resultJson.itValues[intrBM].idParametro); }
                                        }
                                    }
                                }
                                //Apartamento 
                                if (resultJson.aptoValues != undefined) {
                                    if (resultJson.aptoValues.tiposApto != undefined) {
                                        for (var i = 0; i < resultJson.aptoValues.tiposApto.length; i++) { AMX.CustomerAddress.Apartmento.push(resultJson.aptoValues.tiposApto[i].idParametro); }
                                    }
                                }
                                if (resultJson.aptoValues != undefined) {
                                    if (resultJson.aptoValues.tiposAptoComplemento != undefined) {
                                        for (var i = 0; i < resultJson.aptoValues.tiposAptoComplemento.length; i++) { AMX.CustomerAddress.Apartmento.push(resultJson.aptoValues.tiposAptoComplemento[i].idParametro); }
                                    }
                                }
                            }
                        },
                        error: function (XmlHttpRequest, textStatus, errorThrown) {
                            Xrm.Utility.alertDialog(XmlHttpRequest.responseJSON);
                        }
                    });
                }
            }, function (eData) { Xrm.Utility.alertDialog(eData); }, false);
        }
    },

    SetTabularAddressFormat: function () {
        var addressTab1 = Xrm.Page.getAttribute("amx_addresstab1").getValue();
        var addressTab2 = Xrm.Page.getAttribute("amx_addresstab2").getValue();
        var addressTab3 = Xrm.Page.getAttribute("amx_addresstab3").getValue();
        var addressTab7 = (addressTab1 == null ? "" : addressTab1) + " " + (addressTab2 == null ? "" : addressTab2) + " " + (addressTab3 == null ? "" : addressTab3);
        AMX.COMMON.SetAttributeValue("amx_addresstab7", addressTab7);
    },

    PushDataToArray: function (arrayList, arrName) {
        for (var i = 1; i < arrayList.length; i++) {
            if (arrName == "bmArray") { AMX.CustomerAddress.BMAddressTypeSet.push(arrayList[i]); }
            if (arrName == "itArray") { AMX.CustomerAddress.ITAddressTypeSet.push(arrayList[i]); }
            if (arrName == "complementoArray") { AMX.CustomerAddress.Complemento.push(arrayList[i]); }
            if (arrName == "apartmentoArray") { AMX.CustomerAddress.Apartmento.push(arrayList[i]); }
        }        
    },

    ShowHideAddressFreeTextTab: function () {
        var isFreeText = Xrm.Page.getAttribute("amx_addressfreetext").getValue();
        if (isFreeText) {
            AMX.CustomerAddress.SetAndShowHideAddressFreeTextFields(true);
            Xrm.Page.getControl("WebResource_SaveTabular").setVisible(false);
        }
        else {
            AMX.CustomerAddress.SetAndShowHideAddressFreeTextFields(false);
            Xrm.Page.getControl("WebResource_SaveTabular").setVisible(true);
        }
    },

    SetHeaderValues: function () {
        var customerId = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
        if (customerId != null) {
            customerId = customerId[0].id;
            var req = new XMLHttpRequest();
            req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/contacts(" + customerId.replace("{", "").replace("}", "") + ")?$select=contactid,etel_blackliststatuscode,statuscode", false);
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
                        var contactid = result["contactid"];
                        var etel_blackliststatuscode = result["etel_blackliststatuscode"];
                        var etel_blackliststatuscode_formatted = result["etel_blackliststatuscode@OData.Community.Display.V1.FormattedValue"];
                        var statuscode = result["statuscode"];
                        Xrm.Page.getAttribute("statuscode").setValue(statuscode);
                        Xrm.Page.getAttribute("amx_blackliststatus").setValue(etel_blackliststatuscode);
                    } else {
                        Xrm.Utility.alertDialog(this.statusText);
                    }
                }
            };
            req.send();
        }
        else {
            AMX.CustomerAddress.SetDefaultCreatedFromBA();
        }
    },

    SetDefaultCreatedFromBA: function () {
        var param = Xrm.Page.context.getQueryStringParameters();
        if (param._CreateFromId != undefined && param._CreateFromId != "") {
            var bAccountId = param._CreateFromId.replace("{", "").replace("}", "");
            var webApiSelectFilters = "etel_bi_billingaccountcreates?fetchXml=%3Cfetch%20version%3D%221.0%22%20output-format%3D%22xml-platform%22%20mapping%3D%22logical%22%20distinct%3D%22false%22%3E%3Centity%20name%3D%22etel_bi_billingaccountcreate%22%3E%3Cattribute%20name%3D%22etel_bi_billingaccountcreateid%22%20%2F%3E%3Cattribute%20name%3D%22etel_name%22%20%2F%3E%3Cattribute%20name%3D%22createdon%22%20%2F%3E%3Cattribute%20name%3D%22etel_customerindividualid%22%20%2F%3E%3Corder%20attribute%3D%22etel_name%22%20descending%3D%22false%22%20%2F%3E%3Cfilter%20type%3D%22and%22%3E%3Ccondition%20attribute%3D%22etel_bi_billingaccountcreateid%22%20operator%3D%22eq%22%20value%3D%22%7B" + bAccountId + "%7D%22%20%2F%3E%3C%2Ffilter%3E%3Clink-entity%20name%3D%22contact%22%20from%3D%22contactid%22%20to%3D%22etel_customerindividualid%22%20alias%3D%22ac%22%3E%3Cattribute%20name%3D%22amx_districtid%22%20%2F%3E%3Cattribute%20name%3D%22etel_cityid%22%20%2F%3E%3Cattribute%20name%3D%22statuscode%22%20%2F%3E%3Cattribute%20name%3D%22etel_blackliststatuscode%22%20%2F%3E%3C%2Flink-entity%3E%3C%2Fentity%3E%3C%2Ffetch%3E";
            AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                for (var i = 0; i < results.value.length; i++) {
                    var _etel_customerindividualid_value = results.value[i]["_etel_customerindividualid_value"];   
                    var _etel_customerindividualid_value_formatted = results.value[i]["_etel_customerindividualid_value@OData.Community.Display.V1.FormattedValue"];
                    var _amxperu_district_value = results.value[i]["ac_x002e_amx_districtid"];
                    var _amx_districtid_value_formatted = results.value[i]["ac_x002e_amx_districtid@OData.Community.Display.V1.FormattedValue"];
                    var _etel_cityid_value = results.value[i]["ac_x002e_etel_cityid"];
                    var _etel_cityid_value_formatted = results.value[i]["ac_x002e_etel_cityid@OData.Community.Display.V1.FormattedValue"];
                    var etel_blackliststatuscode = results.value[i]["ac_x002e_etel_blackliststatuscode"];
                    var statuscode = results.value[i]["ac_x002e_statuscode"];
                    var etel_name = results.value[i]["etel_name"];                   
                    Xrm.Page.getAttribute("etel_individualcustomerid").setValue([{ name: _etel_customerindividualid_value_formatted, id: _etel_customerindividualid_value, entityType: "contact" }]);
                    Xrm.Page.getAttribute("etel_individualcustomerid").setSubmitMode("always");
                    Xrm.Page.getAttribute("amxperu_district").setValue([{ name: _amx_districtid_value_formatted, id: _amxperu_district_value, entityType: "amxperu_district" }]);
                    Xrm.Page.getAttribute("etel_cityid").setValue([{ name: _etel_cityid_value_formatted, id: _etel_cityid_value, entityType: "etel_city" }]);
                    Xrm.Page.getAttribute("statuscode").setValue(statuscode);
                    Xrm.Page.getAttribute("amx_blackliststatus").setValue(etel_blackliststatuscode);
                    Xrm.Page.getAttribute("amx_addressusagecode").setValue("173800000, 173800002");
                    Xrm.Page.getAttribute("amx_addressusagelabel").setValue("Invoice/contract,Installation");
                    Xrm.Page.getAttribute("amx_cityarea").setRequiredLevel("none");
                    Xrm.Page.data.entity.save();
                    break;
                }
            }, function (eData) { Xrm.Utility.alertDialog(eData); }, false);
            
        }
    },

    RegisterOnLoadEvents: function () {
        Xrm.Page.getControl("amx_searchaddress").addOnKeyPress(AMX.CustomerAddress.KeyPressFunction);
        Xrm.Page.getControl("amx_addresstab1").addOnKeyPress(AMX.CustomerAddress.KeyPressFunction);
        Xrm.Page.getControl("amx_addresstab2").addOnKeyPress(AMX.CustomerAddress.KeyPressFunction);
        Xrm.Page.getControl("amx_addresstab3").addOnKeyPress(AMX.CustomerAddress.KeyPressFunction);
        for (var i = 1; i < AMX.CustomerAddress.Arrays.AttributeNameCollection.length; i++) {
            Xrm.Page.getAttribute(AMX.CustomerAddress.Arrays.AttributeNameCollection[i]).addOnChange(AMX.CustomerAddress.SetTabularAddressFormat);
        }
    },
    KeyPressFunction: function (ext) {
        try {
            var addressCode = [];
            var addTypeTab = Xrm.Page.getAttribute("amx_addresstypetab").getValue();
            var userInput = ext.getEventSource().getValue();//Xrm.Page.getControl("amx_searchaddress").getValue();
            var fieldName = ext.getEventSource().getName();
            if (userInput.indexOf(" ") > -1) { ext.getEventSource().hideAutoComplete(); return; }
            if (fieldName == "amx_searchaddress") { addressCode = AMX.CustomerAddress.AddressArr; }
            else if (fieldName == "amx_addresstab1" && addTypeTab === 173800000) { addressCode = AMX.CustomerAddress.AddressArr; } //173800000 - CALLE - CARRERA (CK)
            else if (fieldName == "amx_addresstab1" && addTypeTab === 173800001) { addressCode = AMX.CustomerAddress.BMAddressTypeSet; } //173800001 - BARRIO and MANZANA (BM)
            else if (fieldName == "amx_addresstab1" && addTypeTab === 173800002) { addressCode = AMX.CustomerAddress.ITAddressTypeSet; } //173800001 - INTRADUCIBLE (IT)
            else if (fieldName == "amx_addresstab2") { addressCode = AMX.CustomerAddress.Complemento; }
            else if (fieldName == "amx_addresstab3") { addressCode = AMX.CustomerAddress.Apartmento; }
                resultSet = { results: new Array() };
                var userInputLowerCase = userInput.toLowerCase();
                var addressCodeUnique = [];
                for (i = 0; i < addressCode.length; i++) {
                    if (userInputLowerCase === addressCode[i].substring(0, userInputLowerCase.length).toLowerCase()) {
                        if (addressCodeUnique.indexOf(addressCode[i]) === -1) {
                            addressCodeUnique.push(addressCode[i]);
                            resultSet.results.push({
                                id: i,
                                fields: [addressCode[i]]
                            });
                        }
                        if (resultSet.results.length >= 20) break;
                    }
                }
                if (resultSet.results.length > 0) {
                    ext.getEventSource().showAutoComplete(resultSet);
                } else {
                    ext.getEventSource().hideAutoComplete();
                }
            
        }
        catch (e) {
            console.log(e);
        }
    },
    
    SetAndShowHideAddressFreeTextFields: function (isFreeText) {
        if (isFreeText) {
            for (var i = 1; i < AMX.CustomerAddress.Arrays.AttributeNameCollection.length; i++) {
                AMX.COMMON.SetAttributeValue(AMX.CustomerAddress.Arrays.AttributeNameCollection[i], "");
                AMX.COMMON.ShowHideAttribute(AMX.CustomerAddress.Arrays.AttributeNameCollection[i], false);
            }
            Xrm.Page.getControl('amx_addresstypetab').setVisible(false);
            AMX.COMMON.ShowHideAttribute(AMX.CustomerAddress.Arrays.AttributeNameCollection[0], true);
        }
        else {
            AMX.COMMON.SetAttributeValue(AMX.CustomerAddress.Arrays.AttributeNameCollection[0], "");
            AMX.COMMON.ShowHideAttribute(AMX.CustomerAddress.Arrays.AttributeNameCollection[0], false);
            for (var i = 1; i < AMX.CustomerAddress.Arrays.AttributeNameCollection.length; i++) {
                AMX.COMMON.ShowHideAttribute(AMX.CustomerAddress.Arrays.AttributeNameCollection[i], true);
            }
            Xrm.Page.getControl('amx_addresstypetab').setVisible(true);
        }
    },

    ShowAlertAndUpdateCustomerAddress: function (customerAddressId) {
        Alert.show("Customer already have Primary address assoicated. Do you want this to be Primary Address?", "", [
            new Alert.Button("Confirm", function () {
                AMX.COMMON.SetAttributeValue("amxperu_schedulingid", customerAddressId);
                Alert.hide();
            }, true, true),
            new Alert.Button("Cancel", function () {
                Xrm.Page.getAttribute("etel_isprimaryaddress").setValue(0);
                AMX.COMMON.SetAttributeValue("amxperu_schedulingid", "");
            })
        ], "QUESTION", 500, 200);
    },

    OnChange_PrimaryAddress: function () {
        var isPrimaryAddr = Xrm.Page.getAttribute("etel_isprimaryaddress").getValue();
        var customerToUpdate = Xrm.Page.getAttribute("amxperu_schedulingid").getValue();
        if (isPrimaryAddr) {
            var customerId = Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].id.replace("{", "").replace("}", "");
            var customerAddressId = Xrm.Page.data.entity.getId().replace("{", "").replace("}", "");
            var webApiSelectFilters = "etel_customeraddresses?$select=etel_customeraddressid,etel_isprimaryaddress&$filter=etel_customeraddressid ne " + customerAddressId + " and  _etel_individualcustomerid_value eq " + customerId + " and  etel_isprimaryaddress eq true";
            AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                for (var i = 0; i < results.value.length; i++) {
                    var etel_customeraddressid = results.value[i]["etel_customeraddressid"];
                    var etel_isprimaryaddress = results.value[i]["etel_isprimaryaddress"];
                    var etel_isprimaryaddress_formatted = results.value[i]["etel_isprimaryaddress@OData.Community.Display.V1.FormattedValue"];
                    AMX.COMMON.CustomerIdToUpdate = etel_customeraddressid;
                    AMX.CustomerAddress.ShowAlertAndUpdateCustomerAddress(etel_customeraddressid);
                    break;
                }
            }, function (eData) { Xrm.Utility.alertDialog(eData); }, false);
        }
        else {
            if (customerToUpdate != "" && customerToUpdate != null) { AMX.COMMON.SetAttributeValue("amxperu_schedulingid", ""); return; }
            Alert.show("Primary Address is not set for the Customer. Do you want this to be Primary Address?", "", [
                new Alert.Button("Confirm", function () {                    
                    Xrm.Page.getAttribute("etel_isprimaryaddress").setValue(1);
                    Alert.hide();
                    //Alert.show("Primary Address set successfully!", null, null, "SUCCESS", 350, 150);
                }, true, true),
                new Alert.Button("Cancel")
            ], "QUESTION", 500, 200);
        }
    },

    RefreshHTMLWebResource: function (webresourceName) {
        var webResourceControl = Xrm.Page.getControl(webresourceName);
        var src = webResourceControl.getSrc();
        webResourceControl.setSrc(null);
        webResourceControl.setSrc(src);

    },
    
    OnChange_AddressFreetext: function () {
        AMX.CustomerAddress.SetAndShowHideAddressFreeTextFields(true);
        Xrm.Page.getAttribute("amxperu_normalized").setValue(0);
        Xrm.Page.getAttribute("amx_addressfreetext").setValue(1);  
        Xrm.Page.getControl("WebResource_SaveTabular").setVisible(false);
    },
    OnChange_AddressTab: function () { 
        AMX.CustomerAddress.RefreshHTMLWebResource("WebResource_SaveTabular");
        AMX.CustomerAddress.SetAndShowHideAddressFreeTextFields(false);
        Xrm.Page.getAttribute("amxperu_normalized").setValue(1);
        Xrm.Page.getAttribute("amx_addressfreetext").setValue(0);
        Xrm.Page.getControl("WebResource_SaveTabular").setVisible(true);
        
    },    

    OnChange_City: function () {
        Xrm.Page.getAttribute("amx_cityarea").setValue(null);
        Xrm.Page.getControl('amx_cityarea').setFocus();
    },

    OnChange_District: function () {  
        var formType = Xrm.Page.ui.getFormType();
        if (formType != "1") {
            Xrm.Page.getAttribute("amx_cityarea").setValue(null);
            Xrm.Page.getAttribute("etel_cityid").setValue(null);            
            Xrm.Page.getControl('etel_cityid').setFocus();
        }
    },
    OnChange_CityArea: function () {
        var city = Xrm.Page.getAttribute("etel_cityid").getValue();
        if (city == null) {
            Xrm.Page.getControl('etel_cityid').setFocus();
        }
    },
    OnChange_AddressTypeTab: function (evnt) {
        var addtype = evnt.getEventSource().getValue();
        for (var i = 1; i < AMX.CustomerAddress.Arrays.AttributeNameCollection.length; i++) {
            AMX.COMMON.SetAttributeValue(AMX.CustomerAddress.Arrays.AttributeNameCollection[i], "");
        }
        //if (addtype == 173800000) { Xrm.Page.getControl('amx_addresstab4').setVisible(false); }
        //else { Xrm.Page.getControl('amx_addresstab4').setVisible(true);}        
    },

    GetAddressCode: function () {        
        var req = new XMLHttpRequest();
        req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/amx_mgladdresscodes?$select=amx_name,amx_value,amx_mgladdresscodeid", false);
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
                        var amx_mgladdresscodeid = results.value[i]["amx_mgladdresscodeid"];
                        var amx_name = results.value[i]["amx_name"];
                        AMX.CustomerAddress.AddressArr.push(amx_name);
                    }
                } else {
                    Xrm.Utility.alertDialog(this.statusText);
                }
            }
        };
        req.send();
    },

    ShowHideMatchingAddressGrid: function () {
        //Retieve MGL Technical Details record based on Customer Address id.
        var customerAddressId = Xrm.Page.data.entity.getId();
        if (customerAddressId != "" && customerAddressId != null) {
            customerAddressId = customerAddressId.replace("{", "").replace("}", "");
            var req = new XMLHttpRequest();
            req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/amx_bimgltechnicaldetailses?$select=amx_addressid,_amx_bimgltechdetailsid_value,amx_name&$filter=_amx_customeraddressid_value eq " + customerAddressId + "&$count=true", false);
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
                        if (recordCount > 0) { AMX.CustomerAddress.IsMGLAddDetailsAvailable = true; }
                    } else {
                        Xrm.Utility.alertDialog(this.statusText);
                    }
                }
            };
            req.send();
        }
    },

    __namespace: true
}

AMX.CustomerAddress.Arrays = {
    //AttributeNameCollection: ['amx_searchaddress', 'amx_addresstab1', 'amxperu_square', 'amxperu_grouping', 'amxperu_number', 'amxperu_allotment', 'amx_addresstab2', 'amx_addresstab3', 'amx_addresstab4', 'amx_addresstab5', 'amx_addresstab6', 'amx_addresstab7','amx_addresstab8'],
    AttributeNameCollection: ['amx_searchaddress', 'amx_addresstab1', 'amx_addresstab2', 'amx_addresstab3'],
}