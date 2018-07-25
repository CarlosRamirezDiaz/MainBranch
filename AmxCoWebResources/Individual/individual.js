
function ValidateUpdateDigitalDate(isForm360) {
    var modifiedon = null;

    var modifiedonnull = false;
    var isProcessActive = Xrm.Page.getAttribute("amx_isforchangestratum").getValue();
    var currentForm = Xrm.Page.ui.formSelector.getCurrentItem();
    var availableForms = Xrm.Page.ui.formSelector.items.get();

    if (isProcessActive) {

        if (Xrm.Page.getAttribute("sqdm_datedigitalupdate").getValue()) {
            modifiedon = Xrm.Page.getAttribute("sqdm_datedigitalupdate").getValue();
        } else {
            modifiedonnull = true;
        }

        if (modifiedon != null || modifiedonnull) {
            var today = Date.now();
            var daysInParameter = 0;
            var daysFromLastUpdate = 0;

            if (!modifiedonnull) {

                var dif = today - modifiedon;
                daysFromLastUpdate = Math.floor(dif / (1000 * 60 * 60 * 24));

                var paramDays = GetEntityRecords("amxperu_amxconfigurations", null, "amxperu_value", "amxperu_name eq 'DaysForDigitalUpdateValidation'", false, null, null, null);

                if (paramDays != null && paramDays != undefined) {
                    if (paramDays.length > 0) {
                        daysInParameter = parseInt(paramDays[0].amxperu_value);
                    }
                }
            }

            if (daysFromLastUpdate > daysInParameter && isForm360 || modifiedonnull && isForm360) {

                if (currentForm.getLabel() != "Update Form Customer") {
                    for (var i in availableForms) {
                        var form = availableForms[i];
                        if (form.getLabel() == "Update Form Customer") {
                            form.navigate();
                        }
                    }
                }
            }
            else if (!isForm360) {
                startDigiturnInUpdateContactInformation();
            }
        }
    }
    else if (!isForm360) {
        if (currentForm.getLabel() != "Customer 360") {
            for (var i in availableForms) {
                var form = availableForms[i];
                if (form.getLabel() == "Customer 360") {
                    form.navigate();
                }
            }
        }
    }
}

function hideBirthday() {
    Xrm.Page.getAttribute("amxperu_documenttype").setRequiredLevel("none");
    Xrm.Page.getAttribute("etel_salutationcode").setRequiredLevel("none");

    if (Xrm.Page.getAttribute("birthdate").getValue()) {
        Xrm.Page.getAttribute("birthdate").setRequiredLevel("none");
        Xrm.Page.ui.tabs.get("tab_summary").sections.get("section_birthday").setVisible(false);
    }
    else {
        Xrm.Page.getAttribute("birthdate").setRequiredLevel("required");
        Xrm.Page.ui.tabs.get("tab_summary").sections.get("section_birthday").setVisible(true);
    }
}

function lockFieldsCustomerAdddress(executionContext) {
    var entityObject = executionContext.getFormContext().data.entity;

    executionContext.getFormContext().data.entity.attributes.forEach(function (attribute, i) {
        if (attribute.getName() == "etel_name") {
            var emailControl = attribute.controls.get(0);
            emailControl.setDisabled(true);
        }

        if (attribute.getName() == "amx_installation") {
            if (attribute.getValue()) {
                var emailControl = attribute.controls.get(0);
                emailControl.setDisabled(true);
            }
        }
    });
}

function lockFieldsContactInformation(executionContext) {
    var entityObject = executionContext.getFormContext().data.entity;

    executionContext.getFormContext().data.entity.attributes.forEach(function (attribute, i) {
        if (attribute.getName() == "amx_name") {
            var emailControl = attribute.controls.get(0);
            emailControl.setDisabled(true);
        }
    });
}

function enableButtonsInUpdateForm() {
    var enable = false;
    var currentForm = Xrm.Page.ui.formSelector.getCurrentItem();

    if (currentForm.getLabel() == "Update Form Customer") {
        enable = true;
    }

    return enable;
}

function confirmUpdateInformation() {
    debugger;

    if (Xrm.Page.getAttribute("birthdate").getValue()) {
        if (validateCountContactInformation()) {
            Xrm.Page.data.refresh(true).then(function () {
                Xrm.Page.ui.clearFormNotification('msg_Action');

                try {

                    var isforchangestratum = Xrm.Page.getAttribute("amx_isforchangestratum").getValue()

                    if (isforchangestratum && Xrm.Page.getAttribute("amx_updateagree").getValue()) {
                        notifyStratumChange();
                    }

                    var entityId = Xrm.Page.data.entity.getId();
                    var entityName = Xrm.Page.data.entity.getEntityName();
                    var request = LaunchActionNoParams(entityId, entityName, "amx_ACIndividualCustomerConfirmUpdateForm");

                    if (request.status == 200) {
                        Xrm.Utility.openEntityForm(Xrm.Page.data.entity.getEntityName(), Xrm.Page.data.entity.getId());
                    } else {
                        var error = ProcessSoapError(request.responseXML);
                        Xrm.Page.ui.setFormNotification('' + error, 'ERROR', 'msg_Action');
                    }

                }
                catch (e) {
                    console.log('ERROR! ' + e.message);
                }
            }, null);
        }
        else {
            alert("El usuario debe asociar por lo menos un correo electronico como medio de contacto.");
        }
    }
    else {
        alert("El campo fecha de nacimiento es obligatoria.");
    }
}

function notifyStratumChange() {

    var contactid = Xrm.Page.data.entity.getId();

    var request = {
        'NotityStratumChangeRequest': {
            '$type': 'AmxPeruPSBActivities.Model.Individual.AmxCoNotityStratumChangeRequest, AmxPeruPSBActivities',
            'contactid': contactid
        }
    }

    var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");

    jQuery.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(request),
        async: false,
        cache: false,
        url: apiUrl + 'AmxCoNotityStratumChangeActivity',
        xhrFields: {
            withCredentials: true
        },
        beforeSend: function (XMLHttpRequest) {
            XMLHttpRequest.setRequestHeader("Accept", "application/json");
        },
        success: function (data, textStatus, XmlHttpRequest) {
            if (data) {

                if (data.Output.NotityStratumChangeResponse.Error == false) {

                    alert("Se envió correctamente la notificación");
                }
                else {

                    if (data.Output.NotityStratumChangeResponse.ErrorDetail) {
                        alert(data.Output.NotityStratumChangeResponse.ErrorDetail[0]);
                    }
                }
            }
        },
        error: function (XmlHttpRequest, textStatus, errorThrown) {
            alert('Se presento un error al intentar enviar la notificación.');
        }
    });

}

function cancelUpdateInformation() {
    debugger;

    Xrm.Page.ui.clearFormNotification('msg_Action');

    try {

        var entityId = Xrm.Page.data.entity.getId();
        var entityName = Xrm.Page.data.entity.getEntityName();
        var request = LaunchActionNoParams(entityId, entityName, "amx_ACIndividualCustomerConfirmUpdateForm");

        if (request.status == 200) {
            Xrm.Utility.openEntityForm(Xrm.Page.data.entity.getEntityName(), Xrm.Page.data.entity.getId());
        } else {
            var error = ProcessSoapError(request.responseXML);
            Xrm.Page.ui.setFormNotification('' + error, 'ERROR', 'msg_Action');
        }
    }
    catch (e) {
        console.log('CNX: ERROR! ' + e.message);
    }
}

function newStratumChange() {

    var titleName = "Condiciones cambio de estrato";
    var wMessage = AMX.COMMON.RetrieveKBArticleByTitle(titleName);

    if (wMessage != null) {
        Alert.show(wMessage, "", [new Alert.Button("Acepto",
            function () {
                debugger;
                var digiturnoRecord = GetEntityRecords("etel_bi_header", null, "etel_channelinteractionid", "etel_individualcustomerid/Id eq guid'" + Xrm.Page.data.entity.getId() + "' and etel_headerstatus eq true", false, null, null, null);
                var digiturnoId = "";

                if (digiturnoRecord != null && digiturnoRecord != undefined) {
                    if (digiturnoRecord.length > 0) {
                        digiturnoId = digiturnoRecord[0].etel_channelinteractionid;
                    }
                }

                if (digiturnoId != "--" && digiturnoId != "" && digiturnoId != undefined && digiturnoId != null) {
                    var DigiturnoRequest = {
                        "request": {
                            "$type": "AmxCoPSBActivities.Model.Digiturno.DigiturnoNotifyEventTurnRequest, AmxPeruPSBActivities",
                        }
                    };

                    DigiturnoRequest.request.IdBusinessInteraction = 2;
                    DigiturnoRequest.request.IdEvent = 1;
                    DigiturnoRequest.request.IdTurn = digiturnoId;

                    var urlDigiturno = 0;

                    var paramUrl = GetEntityRecords("amxperu_amxconfigurations", null, "amxperu_value", "amxperu_name eq 'UrlStartDigiturno'", false, null, null, null);

                    if (paramUrl != null && paramUrl != undefined) {
                        if (paramUrl.length > 0) {
                            urlDigiturno = paramUrl[0].amxperu_value;
                        }
                    }

                    jQuery.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        datatype: "json",
                        data: JSON.stringify(DigiturnoRequest),
                        async: false,
                        cache: false,
                        url: urlDigiturno,
                        xhrFields: {
                            withCredentials: true
                        },
                        beforeSend: function (XMLHttpRequest) {
                            XMLHttpRequest.setRequestHeader("Accept", "application/json");
                        },
                        success: function (data, textStatus, XmlHttpRequest) {
                            getSubscriptionFromAddressId();
                            createStratumChange();
                        },
                        error: function (XmlHttpRequest, textStatus, errorThrown) {
                            getSubscriptionFromAddressId();
                            createStratumChange();
                        }
                    });
                }
                else {
                    createStratumChange();
                }
            }, false, false), new Alert.Button("No acepto", function () {

                var titleNoFactibility = "Causales de no factibilidad del tramite de cambio de estrato";
                var wNoFactibiity = AMX.COMMON.RetrieveKBArticleByTitle(titleNoFactibility);
                if (wNoFactibiity != null) {
                    Alert.show(wNoFactibiity, "", [new Alert.Button("Ok", function () {
                        var entityId = Xrm.Page.data.entity.getId();
                        var entityName = Xrm.Page.data.entity.getEntityName();
                        var request = LaunchActionNoParams(entityId, entityName, "amx_ACIndividualCustomerChangeFieldIsChangeStratum");

                        if (request.status == 200) {
                            Xrm.Utility.openEntityForm(Xrm.Page.data.entity.getEntityName(), Xrm.Page.data.entity.getId());
                        } else {
                            var error = ProcessSoapError(request.responseXML);
                            Xrm.Page.ui.setFormNotification('' + error, 'ERROR', 'msg_Action');
                        }
                    }, false, false)], "INFO", 1000, 400);
                }

            }, true, true)], "INFO", 1000, 400);
    }
}

function updateFieldContactInformation() {
    debugger;
    try {

        var entityId = Xrm.Page.data.entity.getId();
        var entityName = Xrm.Page.data.entity.getEntityName();
        var request = LaunchActionNoParams(entityId, entityName, "amx_ACIndividualCustomerUpdateFieldContactInformation");

        if (request.status == 200) {
        } else { }
    }
    catch (e) {
    }
}

function updateFieldsAddressUsage() {
    debugger;
    try {

        var entityId = Xrm.Page.data.entity.getId();
        var entityName = Xrm.Page.data.entity.getEntityName();
        var request = LaunchActionNoParams(entityId, entityName, "amx_ACIndividualCustomerUpdateFieldsAddressUsage");

        if (request.status == 200) {
        } else { }
    }
    catch (e) {
    }
}

function createStratumChange() {
    var parameters = {};
    parameters["amx_individualcustomer"] = Xrm.Page.data.entity.getId();

    var windowOptions = {
        openInNewWindow: false
    };
    Xrm.Utility.openEntityForm("amx_stratumchange", null, parameters, windowOptions);
}

function SetCustomerAddressFields(selectedRowData, mglTechDetailObj) {
    var cityName = parent.Xrm.Page.getAttribute("etel_cityid").getValue() != null ? parent.Xrm.Page.getAttribute("etel_cityid").getValue()[0].name : "";
    parent.Xrm.Page.getAttribute("etel_name").setValue(cityName + "-" + mglTechDetailObj["amx_igacaddress"].toString());
    parent.Xrm.Page.getAttribute("etel_addressline1").setValue(mglTechDetailObj["amx_igacaddress"].toString());
    parent.Xrm.Page.getAttribute("amx_addressid").setValue(mglTechDetailObj["amx_addressid"].toString());
    parent.Xrm.Page.getAttribute("etel_addressline3").setValue(selectedRowData.adressReliability == undefined || selectedRowData.adressReliability == null || selectedRowData.adressReliability == "" ? "" : selectedRowData.adressReliability.toString());
    parent.Xrm.Page.getAttribute("amxperu_latitude").setValue(selectedRowData.latitudeCoordinate == undefined || selectedRowData.latitudeCoordinate == null || selectedRowData.latitudeCoordinate == "" ? "" : selectedRowData.latitudeCoordinate.toString());
    parent.Xrm.Page.getAttribute("amxperu_longitude").setValue(selectedRowData.lengthCoordinate == undefined || selectedRowData.lengthCoordinate == null || selectedRowData.lengthCoordinate == "" ? "" : selectedRowData.lengthCoordinate.toString());
    var customerAddressIdToUpdate = parent.Xrm.Page.getAttribute("amxperu_schedulingid").getValue();
    if (customerAddressIdToUpdate != null && customerAddressIdToUpdate != "") {
        var entity = {};
        entity.etel_isprimaryaddress = false;
        AMX.COMMON.UpdateEntityWebApi("etel_customeraddresses", customerAddressIdToUpdate, entity, function (sData) { }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
        parent.Xrm.Page.getAttribute("amxperu_schedulingid").setValue("");
    }
    parent.Xrm.Page.data.entity.save("saveandclose");
}

function createMGLListCover(mglTechDetailId, selectedRowData) {
    var selectedListCover = selectedRowData.listCover;
    if (selectedListCover != undefined && selectedListCover != null && selectedListCover != "") {
        var mglListCoverObj = {};
        for (var i = 0; i < selectedListCover.length; i++) {
            AMX.COMMON.SetMGLListCoverEntityObj(selectedListCover[i], mglListCoverObj, mglTechDetailId);
            AMX.COMMON.CreateEntiyWebApi("amx_mgllistcovers", mglListCoverObj, function (sData) { }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
        }
    }
}

function createOtherAddressListAndCcmmMarks(mglListHhppsId, selectedSubCcmmTechnology) {
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
}

function createViabilityMessageAndAddressCcmmMarks(mglListHhppsId, selectedListHhpps) {
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
}

function createMGLListHhpps(mglTechDetailId, selectedRowData) {
    var mglListHhppsObj = {}; var selectedSubCcmmTechnology = {};
    var selectedListHhpps = selectedRowData.listHhpps;
    if (selectedListHhpps != null || selectedListHhpps != undefined) {
        for (var i = 0; i < selectedListHhpps.length; i++) {
            AMX.COMMON.SetMGLListHhppsEntityObj(selectedListHhpps[i], mglListHhppsObj, selectedSubCcmmTechnology, mglTechDetailId);
            AMX.COMMON.CreateEntiyWebApi("amx_bimgllisthhppses", mglListHhppsObj, function (sData) {
                createOtherAddressListAndCcmmMarks(sData, selectedSubCcmmTechnology);
                createViabilityMessageAndAddressCcmmMarks(sData, selectedListHhpps[i]);
            }, function (eData) { parent.Xrm.Utility.alertDialog(eData) }, false);
        }
    }
}

function getSubscriptionFromAddressId() {
    var mglTechDetailObj = {};
    var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");
    var addresses = GetEntityRecords("etel_customeraddress", null, "amx_AddressID,etel_customeraddressId", "etel_individualcustomerid/Id eq guid'" + Xrm.Page.data.entity.getId() + "'", false, null, null, null);

    for (var x = 0; x < addresses.length; x++) {
        var addressId = addresses[x].amx_addressid;

        var workflowStartInput = {
            "addressMGLRequest":
            {
                "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails, AmxPeruPSBActivities",
                "idDireccion": addressId, "segmento": "", "residencial": "", "proyecto": "",
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
                    debugger;
                    console.log(data);
                    var resultJsonOutput = new Array();
                    var resultJson = JSON.parse(data.Output.addressMGLResponse);

                    if (resultJson.addresses != undefined) {
                        var selectedRowData = resultJson.addresses;
                        AMX.COMMON.SetMGLTechnicalDetailsEntityObj(selectedRowData, mglTechDetailObj, addresses[x].etel_customeraddressId.replace("{", "").replace("}", ""));
                        var isMglTechDetailEntity = false;
                        var webApiSelectFilters = "amx_bimgltechnicaldetailses?$select=amx_bimgltechnicaldetailsid&$filter=amx_addressid eq '" + selectedRowData.addressId + "' and  statecode eq 0";
                        AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (sData) { if (sData.value.length > 0) { isMglTechDetailEntity = true; } }, function (eData) { }, false);
                        if (!isMglTechDetailEntity) {
                            AMX.COMMON.CreateEntiyWebApi("amx_bimgltechnicaldetailses", mglTechDetailObj, function (sData) {
                                createMGLListCover(sData, selectedRowData);
                                createMGLListHhpps(sData, selectedRowData);
                            }, function (eData) { }, false);
                        }
                        SetCustomerAddressFields(selectedRowData, mglTechDetailObj);
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

function validateMobileClaro(executionContext) {
    debugger;
    var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");
    var workflowStartInput = {
        "AmxCoValidateMobileClaroInUpdateRequest":
        {
            "$type": "AmxPeruPSBActivities.Model.CustomerContactInformation.AmxCoValidateMobileClaroInUpdateRequest, AmxPeruPSBActivities",
            "Individuald": Xrm.Page.data.entity.getId()
        }
    };

    jQuery.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(workflowStartInput),
        async: false,
        cache: false,
        url: apiUrl + 'AmxCoValidateMobileClaroInUpdate',
        xhrFields: {
            withCredentials: true
        },
        beforeSend: function (XMLHttpRequest) {
            XMLHttpRequest.setRequestHeader("Accept", "application/json");
        },
        success: function (data, textStatus, XmlHttpRequest) {
            if (data) {
                debugger;
                console.log(data);
                var resultJsonOutput = new Array();
                //var resultJson = JSON.parse(data.Output.AmxCoValidateMobileClaroInUpdateResponse);

                if (data.Output.AmxCoValidateMobileClaroInUpdateResponse.isMobileClaro != undefined) {
                    if (data.Output.AmxCoValidateMobileClaroInUpdateResponse.isMobileClaro != true) {
                        Xrm.Page.getAttribute("amx_ismobileclaro").setValue(false);
                    }
                    else {
                        Xrm.Page.getAttribute("amx_ismobileclaro").setValue(true);
                    }
                    Xrm.Page.data.entity.save();
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

function startDigiturnInUpdateContactInformation() {
    if (!Xrm.Page.getAttribute("amx_updateagree").getValue()) {

        Alert.show("Es necesario actualizar la informacion del cliente. <br /><br />¿El usuario acepta que su infomración sea actualizada?", "", [new Alert.Button("Acepto",
            function () {
                debugger;
                Xrm.Page.getAttribute("amx_updateagree").setValue(true);
                Xrm.Page.data.entity.save();
                var digiturnoRecord = GetEntityRecords("etel_bi_header", null, "etel_channelinteractionid", "etel_individualcustomerid/Id eq guid'" + Xrm.Page.data.entity.getId() + "' and etel_headerstatus eq true", false, null, null, null);
                var digiturnoId = "";

                if (digiturnoRecord != null && digiturnoRecord != undefined) {
                    if (digiturnoRecord.length > 0) {
                        digiturnoId = digiturnoRecord[0].etel_channelinteractionid;
                    }
                }

                if (digiturnoId != "--" && digiturnoId != "" && digiturnoId != undefined && digiturnoId != null) {
                    var DigiturnoRequest = {
                        "request": {
                            "$type": "AmxCoPSBActivities.Model.Digiturno.DigiturnoNotifyEventTurnRequest, AmxPeruPSBActivities",
                        }
                    };

                    DigiturnoRequest.request.IdBusinessInteraction = 2;
                    DigiturnoRequest.request.IdEvent = 1;
                    DigiturnoRequest.request.IdTurn = digiturnoId;

                    var urlDigiturno = 0;

                    var paramUrl = GetEntityRecords("amxperu_amxconfigurations", null, "amxperu_value", "amxperu_name eq 'UrlStartDigiturno'", false, null, null, null);

                    if (paramUrl != null && paramUrl != undefined) {
                        if (paramUrl.length > 0) {
                            urlDigiturno = paramUrl[0].amxperu_value;
                        }
                    }

                    jQuery.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        datatype: "json",
                        data: JSON.stringify(DigiturnoRequest),
                        async: false,
                        cache: false,
                        url: urlDigiturno,
                        xhrFields: {
                            withCredentials: true
                        },
                        beforeSend: function (XMLHttpRequest) {
                            XMLHttpRequest.setRequestHeader("Accept", "application/json");
                        },
                        success: function (data, textStatus, XmlHttpRequest) {
                            console.log(data);
                        },
                        error: function (XmlHttpRequest, textStatus, errorThrown) {
                            console.log(textStatus);
                        }
                    });
                }
            }, false, false), new Alert.Button("No acepto", function () {

                cancelUpdateInformation();

            }, false, false)], "INFO", 600, 300);
    }
}

function validateBirthdate(context) {
    debugger;
    var saveEvent = context.getEventArgs();
    var birthdate = new Date(Xrm.Page.getAttribute("birthdate").getValue());

    var birthdateWithFormat = new Date(birthdate.getUTCFullYear(), birthdate.getUTCMonth(), birthdate.getUTCDate());
    var today = new Date();

    var todayWithFormat = new Date(today.getUTCFullYear(), today.getUTCMonth(), today.getUTCDate());

    if (birthdateWithFormat >= todayWithFormat) {

        alert("La fecha de nacimiento debe ser menor a la fecha actual.");
        saveEvent.preventDefault();
    }
}

function validateCountContactInformation() {
    var contactInformation = GetEntityRecords("amx_customercontactinformation", null, "amx_customercontactinformationId", "amx_IndividualCustomerId/Id eq guid'" + Xrm.Page.data.entity.getId() + "'", false, null, null, null);

    if (contactInformation != null && contactInformation != undefined) {
        if (contactInformation.length > 0) {
            return true;
        }
        else {
            return false
        }
    }
}

function newIncludeAndExcludeAccount() {
    var parameters = {};
    parameters["amx_individualcustomer"] = Xrm.Page.data.entity.getId();

    var windowOptions = {
        openInNewWindow: false
    };
    Xrm.Utility.openEntityForm("amx_biincludeandexcludeaccount", null, parameters, windowOptions);
}



function validateIfSendSurveyIsSent() {
   
    var biHeader = GetEntityRecords("etel_bi_header", null, "etel_moodid", "etel_individualcustomerid/Id eq guid'" + Xrm.Page.data.entity.getId() + "' and StateCode/Value eq 0", false, null, null, null);

    if (biHeader) {

        if (biHeader.length > 0) {
            if (biHeader[0].etel_moodid.Name.toUpperCase() == "HAPPY") {
                console.log("aqui se envía la encuesta profunda.");
            }
        }
    }
}

function updateCustomerData() {
    var parameters = {};
    parameters["amx_individual"] = Xrm.Page.data.entity.getId();

    var windowOptions = {
        openInNewWindow: false
    };
    Xrm.Utility.openEntityForm("amx_updatecustmer", null, parameters, windowOptions);
}

function selectedResource(executionContext) {
    var entityObject = executionContext.getFormContext().data.entity;
    var nameRecord = "";

    executionContext.getFormContext().data.entity.attributes.forEach(function (attribute, i) {        
            var objControl = attribute.controls.get(0);
            objControl.setDisabled(true);  
            if (attribute.getName() == "ticketnumber") { nameRecord = attribute.getValue();}
    });


    var lookup = new Array();
    lookup[0] = new Object();
    lookup[0].id = executionContext.getFormContext().data.entity.getId();
    lookup[0].name = nameRecord;
    lookup[0].entityType = "incident";

    Xrm.Page.getAttribute("amx_resource").setValue(lookup);    
    Xrm.Page.data.entity.save();
}

function cleanFieldsOnLoad() {
    Xrm.Page.getAttribute("amx_resource").setValue(null);
    Xrm.Page.data.entity.save();
}