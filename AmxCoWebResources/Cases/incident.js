var validations = {};
validations.constants = {
    FORM_TYPE_CREATE: 1,
    FORM_TYPE_UPDATE: 2
};
//ToDo: Ask for storage of this header channel definitions.
const BI_HEADER_CHANNELS = {
    PHONE_CALL: 831260000,
    FACE_TO_FACE: 831260001,
    EMAIL: 831260002
}

function sendResponse() {
    alert("Respuesta enviada.");
}

function returnForTyping() {
    var category = Xrm.Page.getAttribute("amxperu_casecategory").getValue();
    var subcategory = Xrm.Page.getAttribute("amxperu_casesubcategory").getValue();
    var subsubcategory = Xrm.Page.getAttribute("amxperu_casesubsubcategory").getValue();
    var othercategory = Xrm.Page.getAttribute("amxperu_caseothercategory").getValue();
    var casetype = Xrm.Page.getAttribute("amx_casetype").getValue();

    var saveEvent = context.getEventArgs();
    debugger;
    if (category && subcategory && subsubcategory && othercategory && casetype) {
        //var getTipification = GetEntityRecords("amxperu_amxperu_casesubsubcategory_amxperu_case", null, "amxperu_casesubsubcategoryid ", "amxperu_caseothercategoryid eq guid'" + closeCode[0].id + "' and amxperu_casesubsubcategoryid eq guid'" + voiceClient[0].id + "'", false, null, null, null);

        //Alert.show(title, message, buttons, icon, width, height, baseUrl, preventCancel, padding)

        Alert.show("Devolución por tipificación", "Desea devolver el caso: ",
            [
                new Alert.Button("Aceptar", function () { }, true),
                new Alert.Button("Cancelar")
            ]
            , "QUESTION", 500, 250);

    }
    else {

        Alert.show("Devolución por tipificación", "Tipificación incompleta",
            [
                new Alert.Button("Ok")
            ]
            , "ERROR", 500, 250);
    }
}
//show customer info

function showemailaddress() {
    //Show email address from individual object 
    var viewId = '{0CBC820C-7033-4AFF-9CE8-FB610464DBD0}';
    var entityName = "amx_customercontactinformation";
    var viewDisplayName = "Correo electrónico";
    var fetchXml = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
        "<entity name= 'amx_customercontactinformation'>" +
        "<attribute name='amx_email'/>" +
        "<attribute name='amx_customercontactinformationid'/>" +
        "<filter type='and'><condition attribute='amx_contacttype' operator='eq' value='173800000'/></filter>" +
        "</entity></fetch>";
    var layoutXml = "<grid name='resultset' object='1' jump='name' select='1' icon='1' preview='1'>" +
        "<row name='result' id='amx_customercontactinformationid'>" +
        "<cell name='amx_email' width='150' />" +
        "</row>" +
        "</grid>";

    if (fetchXml != null && layoutXml != null) {
        Xrm.Page.getControl("amx_phone").addCustomView(viewId, entityName, viewDisplayName, fetchXml, layoutXml, true);
        Xrm.Page.getControl("amx_phone").setDefaultView(viewId.toUpperCase());
    }
}

function showPhone() {
    //Show Phone from individual object 
    var viewId = '{0CBC820C-7033-4AFF-9CE8-FB610464DBD1}';
    var entityName = "amx_customercontactinformation";
    var viewDisplayName = "Teléfono";
    var fetchXml = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
        "<entity name= 'amx_customercontactinformation'>" +
        "<attribute name='amx_phoneno'/>" +
        "<attribute name='amx_customercontactinformationid'/>" +
        "<filter type='and'><condition attribute='amx_contacttype' operator='eq' value='173800002'/></filter>" +
        "</entity></fetch>";
    var layoutXml = "<grid name='resultset' object='1' jump='name' select='1' icon='1' preview='1'>" +
        "<row name='result' id='amx_customercontactinformationid'>" +
        "<cell name='amx_phoneno' width='150' />" +
        "</row>" +
        "</grid>";
    if (fetchXml != null && layoutXml != null) {
        Xrm.Page.getControl("amx_phone").addCustomView(viewId, entityName, viewDisplayName, fetchXml, layoutXml, true);
        Xrm.Page.getControl("amx_phone").setDefaultView(viewId.toUpperCase());
    }
}

function showMobile() {
    //Show Mobile from individual object 
    var viewId = '{0CBC820C-7033-4AFF-9CE8-FB610464DBD2}';
    var entityName = "amx_customercontactinformation";
    var viewDisplayName = "Teléfono movil";
    var fetchXml = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
        "<entity name= 'amx_customercontactinformation'>" +
        "<attribute name='amx_phoneno'/>" +
        "<attribute name='amx_customercontactinformationid'/>" +
        "<filter type='and'><condition attribute='amx_contacttype' operator='eq' value='173800003'/></filter>" +
        "</entity></fetch>";
    var layoutXml = "<grid name='resultset' object='1' jump='name' select='1' icon='1' preview='1'>" +
        "<row name='result' id='amx_customercontactinformationid'>" +
        "<cell name='amx_phoneno' width='150' />" +
        "</row>" +
        "</grid>";
    if (fetchXml != null && layoutXml != null) {
        Xrm.Page.getControl("amx_mobilephone").addCustomView(viewId, entityName, viewDisplayName, fetchXml, layoutXml, true);
        Xrm.Page.getControl("amx_mobilephone").setDefaultView(viewId.toUpperCase());
    }
}

//validation of typology

function validateSubCategory(context) {
    // text
    var category = Xrm.Page.getAttribute("amxperu_casecategory").getValue();
    var subcategory = Xrm.Page.getAttribute("amxperu_casesubcategory").getValue(); //amxperu_casesubcategory
    var saveEvent = context.getEventArgs();
    if (category && subcategory) {
        var relationshipCategories = GetEntityRecords("amxperu_amxperu_casecategory_amxperu_casesubcat", null, "amxperu_casecategoryid", "amxperu_casesubcategoryid eq guid'" + subcategory[0].id + "' and amxperu_casecategoryid eq guid'" + category[0].id + "'", false, null, null, null);
        if (relationshipCategories == null) {
            alert("La SubCategoria no pertenece a la categoria.");
            saveEvent.preventDefault();
        }
        else if (relationshipCategories.length == 0) {
            alert("La SubCategoria no pertenece a la categoria.#2");
            saveEvent.preventDefault();
        }
    }
}

function voiceClient(context) {
    // text
    var subcategory = Xrm.Page.getAttribute("amxperu_casesubcategory").getValue();
    var voiceClient = Xrm.Page.getAttribute("amxperu_casesubsubcategory").getValue();
    var saveEvent = context.getEventArgs();
    if (voiceClient && subcategory) {
        var relationshipCategories = GetEntityRecords("amxperu_amxperu_casesubcategory_amxperu_casesub", null, "amxperu_casesubcategoryid", "amxperu_casesubsubcategoryid eq guid'" + voiceClient[0].id + "' and amxperu_casesubcategoryid eq guid'" + subcategory[0].id + "'", false, null, null, null);
        if (relationshipCategories == null) {
            alert("La Voz del cliente no pertenece a la SubCategoria.");
            saveEvent.preventDefault();
        }
        else if (relationshipCategories.length == 0) {
            alert("La Voz del cliente no pertenece a la SubCategoria.");
            saveEvent.preventDefault();
        }
    }
}

function validateNotification(context) {
    var saveEvent = context.getEventArgs();
    var notificationC = Xrm.Page.getAttribute("amx_notificationchannel").getValue();
    var email = Xrm.Page.getAttribute("amx_customercontactinformation").getValue();
    var phone = Xrm.Page.getAttribute("amx_phone").getValue();
    var address = Xrm.Page.getAttribute("amx_customeraddress").getValue();
    if (notificationC) {
        if (notificationC == 1 && email == null) {
            alert("El medio de notificación seleccionado, exige tener el campo Correo electrónico diligenciado");
            saveEvent.preventDefault();
        }
        else if (notificationC == 2 && address == null) {
            alert("El medio de notificación seleccionado, exige tener el campo Dirección diligenciado");
            saveEvent.preventDefault();
        }
        else if (notificationC == 3 && phone == null) {
            alert("El medio de notificación seleccionado, exige tener el campo Teléfono diligenciado");
            saveEvent.preventDefault();
        }
    }
}

function setCustomervalue() {
    var custId;
    var custName;
    var custType;
    if (Xrm.Page.context.getQueryStringParameters().amx_customerid != null && Xrm.Page.context.getQueryStringParameters().amx_customerid != 'undefined') {
        custId = Xrm.Page.context.getQueryStringParameters().amx_customerid;
    }
    if (Xrm.Page.context.getQueryStringParameters().amx_customeridname != null && Xrm.Page.context.getQueryStringParameters().amx_customeridname != 'undefined') {
        custName = Xrm.Page.context.getQueryStringParameters().amx_customeridname;
    }
    if (Xrm.Page.context.getQueryStringParameters().amx_customeridtype != null && Xrm.Page.context.getQueryStringParameters().amx_customeridtype != 'undefined') {
        custType = Xrm.Page.context.getQueryStringParameters().amx_customeridtype;
    }
    var lookup = new Array();
    lookup[0] = new Object();
    lookup[0].id = custId;
    lookup[0].name = custName;
    lookup[0].entityType = custType;
    if (lookup != null && lookup != "undefined") Xrm.Page.getAttribute("customerid").setValue(lookup);
}

function getExternalIdFromCustomerId(isLoad) {
    var booGet = true;
    if (isLoad) {
        if (Xrm.Page.getAttribute("etel_externalid").getValue() && Xrm.Page.getAttribute("amxperu_documenttype").getValue() && Xrm.Page.getAttribute("amxperu_documentnumber").getValue()) {
            booGet = false;
        }
    }
    if (booGet) {
        var individual = Xrm.Page.getAttribute("customerid").getValue();
        if (individual) {
            if (individual.length > 0) {
                if (individual[0].entityType == "contact") {
                    var currentCustomer = GetEntityRecords("Contact", null, "etel_externalid,amxperu_DocumentType,etel_iddocumentnumber", "ContactId eq guid'" + individual[0].id + "'", false, null, null, null);
                    if (currentCustomer != null) {
                        if (currentCustomer.length > 0) {
                            Xrm.Page.getAttribute("etel_externalid").setValue(currentCustomer[0].etel_externalid); //
                            Xrm.Page.getAttribute("amxperu_documenttype").setValue(currentCustomer[0].amxperu_DocumentType.Value);
                            Xrm.Page.getAttribute("amxperu_documentnumber").setValue(currentCustomer[0].etel_iddocumentnumber);
                        }
                    }
                }
            }
        }
    }
}

function validateChannel() {
    var channel = Xrm.Page.getAttribute("amx_channel").getValue();
    if (channel != null) {
        var channelId = channel[0].id;
        var codeChannel = GetEntityRecords("amx_channel", null, "amx_code", "amx_channelId eq guid'" + channelId + "'", false, null, null, null);
        var channelEmail = 'EmailChannel';
        var channelPhone = 'PhoneChannel';
        var channelMail = 'MailChannel';
        var emailCRMConfig = GetEntityRecords("etel_crmconfiguration", null, "etel_value", "etel_name eq '" + channelEmail + "'", false, null, null, null);
        var phonelCRMConfig = GetEntityRecords("etel_crmconfiguration", null, "etel_value", "etel_name eq '" + channelPhone + "'", false, null, null, null);
        var mailCRMConfig = GetEntityRecords("etel_crmconfiguration", null, "etel_value", "etel_name eq '" + channelMail + "'", false, null, null, null);
        if (codeChannel != null) {
            if (codeChannel.length > 0) {
                if (emailCRMConfig[0].etel_value.indexOf(codeChannel[0].amx_code) != -1) {
                    Xrm.Page.getAttribute("amx_notificationchannel").setValue(1);
                }
                else if (phonelCRMConfig[0].etel_value.indexOf(codeChannel[0].amx_code) != -1) {
                    Xrm.Page.getAttribute("amx_notificationchannel").setValue(3);
                }
                else if (mailCRMConfig[0].etel_value.indexOf(codeChannel[0].amx_code) != -1) {
                    Xrm.Page.getAttribute("amx_notificationchannel").setValue(2);
                }
            }
        }
    }
}

function validateCloseCode(context) {
    // text
    var voiceClient = Xrm.Page.getAttribute("amxperu_casesubsubcategory").getValue();
    var closeCode = Xrm.Page.getAttribute("amxperu_caseothercategory").getValue();
    var saveEvent = context.getEventArgs();
    if (voiceClient && closeCode) {
        var relationshipVoiceCC = GetEntityRecords("amxperu_amxperu_casesubsubcategory_amxperu_case", null, "amxperu_casesubsubcategoryid ", "amxperu_caseothercategoryid eq guid'" + closeCode[0].id + "' and amxperu_casesubsubcategoryid eq guid'" + voiceClient[0].id + "'", false, null, null, null);
        if (relationshipVoiceCC == null) {
            alert("El código de cierrre no pertenece a la voz del cliente.");
            saveEvent.preventDefault();
        }
        else if (relationshipVoiceCC.length == 0) {
            alert("El código de cierrre no pertenece a la voz del cliente.");
            saveEvent.preventDefault();
        }
    }
}

function validateType(context) {
    var voiceClient = Xrm.Page.getAttribute("amxperu_casesubsubcategory").getValue();
    var caseType = Xrm.Page.getAttribute("amx_casetype").getValue();
    var saveEvent = context.getEventArgs();
    if (voiceClient && caseType) {
        var relationshipVoiceCT = GetEntityRecords("amx_amxperu_casesubsubcategory_amx_casetype", null, "amx_amxperu_casesubsubcategory_amx_casetypeId", "amx_casetypeid  eq guid'" + caseType[0].id + "' and amxperu_casesubsubcategoryid eq guid'" + voiceClient[0].id + "'", false, null, null, null);
        if (relationshipVoiceCT == null) {
            alert("El tipo del caso no hace referencia a la voz del cliente.");
            saveEvent.preventDefault();
        }
        else if (relationshipVoiceCT.length == 0) {
            alert("El tipo del caso no hace referencia a la voz del cliente..");
            saveEvent.preventDefault();
        }
    }
}
//form customization

function lockFieldCategory() {
    if (Xrm.Page.getControl("header_process_amxperu_casecategory") != null) {
        Xrm.Page.getControl("header_process_amxperu_casecategory").setDisabled(true);
    }
    if (Xrm.Page.getControl("header_process_amxperu_casesubcategory") != null) {
        Xrm.Page.getControl("header_process_amxperu_casesubcategory").setDisabled(true);
    }
    if (Xrm.Page.getControl("header_process_amxperu_casesubsubcategory") != null) {
        Xrm.Page.getControl("header_process_amxperu_casesubsubcategory").setDisabled(true);
    }
}

function hideTabMulticarrier() {
    if (Xrm.Page.getAttribute("amx_multicarrier").getValue()) {
        Xrm.Page.ui.tabs.get("tab_Multicarrier").setVisible(true);
    }
    else {
        Xrm.Page.ui.tabs.get("tab_Multicarrier").setVisible(false);
    }
    if (Xrm.Page.getAttribute("amx_haveresourse").getValue()) {
        Xrm.Page.getControl("amx_haveresourse").setVisible(true);
    }
    else {
        Xrm.Page.getControl("amx_haveresourse").setVisible(false);
    }
    if (Xrm.Page.getAttribute("amx_resource").getValue()) {
        Xrm.Page.getControl("amx_resource").setVisible(true);
    }
    else {
        Xrm.Page.getControl("amx_resource").setVisible(false);
    }
    if (Xrm.Page.context.getQueryStringParameters().amx_resourcetype != null && Xrm.Page.context.getQueryStringParameters().amx_resourcetype != 'undefined') {
        Xrm.Page.getAttribute("amx_resourcetype").setValue(Xrm.Page.context.getQueryStringParameters().amx_resourcetype);
        Xrm.Page.data.entity.save();
    }
    if (Xrm.Page.getAttribute("amx_resourcetype").getValue()) {
        Xrm.Page.getControl("amx_resourcetype").setVisible(true);
    }
    else {
        Xrm.Page.getControl("amx_resourcetype").setVisible(false);
    }
}

function refreshWebResArea() {
    Xrm.Utility.openEntityForm(Xrm.Page.data.entity.getEntityName(), Xrm.Page.data.entity.getId());
}
//status validations

function setInprogressStatus() {
    var caseStatus = Xrm.Page.getAttribute("amx_state").getValue();
    var firstStatus = 'FirstCaseStatus';
    var statusName = GetEntityRecords("etel_crmconfiguration", null, "etel_value", "etel_name eq '" + firstStatus + "'", false, null, null, null);
    var caseStatusId = GetEntityRecords("amx_statecase", null, "amx_statecaseId,amx_name", "amx_name eq '" + statusName[0].etel_value + "'", false, null, null, null);
    if (caseStatus == null) {
        var lookup = new Array();
        lookup[0] = new Object();
        lookup[0].id = caseStatusId[0].amx_statecaseId;
        lookup[0].entityType = 'amx_statecase';
        lookup[0].name = caseStatusId[0].amx_name;
        if (lookup != null) {
            Xrm.Page.getAttribute("amx_state").setValue(lookup);
        }
    }
}

function changeSapDate() {
    var sapDate = Xrm.Page.getAttribute("amx_sapdate").getValue();
    var slaFailId = Xrm.Page.getAttribute("firstresponsebykpiid").getValue();
    if (slaFailId != null) {
        var failureTime = GetEntityRecords("SLAKPIInstance", null, "FailureTime", "SLAKPIInstanceId  eq guid'" + slaFailId[0].id + "'", false, null, null, null);
        var endDateFilureTime = failureTime[0].FailureTime.replace("/Date(", "").replace(")/", "");
        var intEndDateFilureTime = parseInt(endDateFilureTime);
        var dateEndDateFilureTime = new Date(intEndDateFilureTime);
        if (dateEndDateFilureTime != null && sapDate != dateEndDateFilureTime) {
            Xrm.Page.getAttribute("amx_sapdate").setValue(dateEndDateFilureTime);
        }
    }
}

function getCun(context) {
    var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");
    var documentType = "";
    var documentNumber = Xrm.Page.getAttribute("amxperu_documentnumber").getValue();
    var families = null;
    var familiesCun = "";
    if (Xrm.Page.getAttribute("amx_productfamily").getValue()) {
        families = Xrm.Page.getAttribute("amx_productfamily").getValue().split(",");
        for (var i = 0; i < families.length; i++) {
            if (Xrm.Page.getAttribute("amxperu_documenttype").getText()) {
                var arrDocumentType = Xrm.Page.getAttribute("amxperu_documenttype").getText().split("-");
                if (arrDocumentType.length > 0) {
                    documentType = arrDocumentType[0];
                }
            }
            var workflowStartInput = {
                'GetCunRequest': {
                    '$type': 'AmxPeruPSBActivities.Model.Case.CaseGetCunRequest, AmxPeruPSBActivities',
                    'documentType': documentType,
                    'documentId': documentNumber,
                    'business': families[i],
                    "incidentId": "" + Xrm.Page.data.entity.getId()
                }
            };
            jQuery.ajax(
                {
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: JSON.stringify(workflowStartInput),
                    async: false,
                    cache: false,
                    url: apiUrl + 'CaseGetCun',
                    xhrFields: {
                        withCredentials: true
                    },
                    beforeSend: function (XMLHttpRequest) {
                        XMLHttpRequest.setRequestHeader("Accept", "application/json");
                    },
                    success: function (data, textStatus, XmlHttpRequest) {
                        if (data) {
                            if (data.Output.GetCunResponse.cun) {
                                if (familiesCun == "") familiesCun = families[i] + ":" + data.Output.GetCunResponse.cun;
                                else familiesCun = familiesCun + "," + families[i] + ":" + data.Output.GetCunResponse.cun;
                            }
                        }
                    },
                    error: function (XmlHttpRequest, textStatus, errorThrown) {
                        alert("Se produjo un error al consumir el servicio de generación de CUN. Error: " + errorThrown);
                    }
                });
        }
        if (familiesCun != "") {
            Xrm.Page.getAttribute("amx_cun").setValue(familiesCun);
            Xrm.Page.data.refresh(true).then(function () {
                refreshWebResArea();
            }, null);
        }
    }
}

function validateCunInOnload() {
    if (Xrm.Page.getAttribute("amx_cungenerated").getValue() && !Xrm.Page.getAttribute("amx_cun").getValue()) {
        getCun();
    }
}

function validateProductsSelection(context) {
    if (Xrm.Page.ui.getFormType() == validations.constants.FORM_TYPE_CREATE) {
        var saveEvent = context.getEventArgs();
        if (!Xrm.Page.getAttribute("amx_selectedproduct").getValue()) {
            alert("Debe seleccionar por lo menos un producto.");
            saveEvent.preventDefault();
        }
    }
}

function validateSendNotify() {
    debugger;
    let caseStatus = Xrm.Page.getAttribute("amx_state").getValue();
    let assignedStatus = 'assignedStatus';
    let assignedStatusName = GetEntityRecords("etel_crmconfiguration", null, "etel_value", "etel_name eq '" + assignedStatus + "'", false, null, null, null);

    let notificationCUN = Xrm.Page.getAttribute("amx_notificationcun").getValue();
    let cun = Xrm.Page.getAttribute("amx_cun").getValue();
    debugger;
    if (cun != null && notificationCUN == 1 && caseStatus[0].name == assignedStatusName[0].etel_value) {
        var phoneId = Xrm.Page.getAttribute("amx_mobilephone").getValue();
        var emailId = Xrm.Page.getAttribute("amx_customercontactinformation").getValue();
        //Email notification
        if (emailId != null && phoneId == null) {
            var email = GetEntityRecords("amx_customercontactinformation", null, "amx_Email", "amx_customercontactinformationId eq guid'" + emailId[0].id + "'", false, null, null, null);
            var individual = Xrm.Page.getAttribute("customerid").getValue();
            var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");
            //Email notification
            if (email != null) {
                var workflowStartInput = {
                    'request': {
                        "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest, AmxPeruPSBActivities",
                        "pushType": "SINGLE", //hardcoded
                        "typeCostumer": individual[0].id.replace("{", "").replace("}", ""), //customerId
                        "messageBox": [
                            {
                                "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxExt, AmxPeruPSBActivities",
                                "messageChannel": "SMTP",
                                "messageBox": [
                                    {
                                        "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxInt, AmxPeruPSBActivities",
                                        "customerId": individual[0].id.replace("{", "").replace("}", ""), //customerId
                                        "customerBox": email[0].amx_Email //Email
                                    }
                                ]
                            }
                        ],
                        "profileId": ["SMTP_FS_TCRM1", "SMS_FS_TCRM1"],
                        "communicationType": ["REGULATORIO"],
                        "communicationOrigin": "TCRM",
                        "deliveryReceipts": "NO",
                        "contentType": "MESSAGE",
                        "messageContent": "CUN generado satisfactoriamente"
                    }
                }
                jQuery.ajax(
                    {
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        datatype: "json",
                        data: JSON.stringify(workflowStartInput),
                        async: false,
                        cache: false,
                        url: apiUrl + 'AmxCoTorreDeControl',
                        xhrFields: {
                            withCredentials: true
                        },
                        beforeSend: function (XMLHttpRequest) {
                            XMLHttpRequest.setRequestHeader("Accept", "application/json");
                        },
                        success: function (data, textStatus, XmlHttpRequest) {
                            Xrm.Page.getAttribute("amx_notificationcun").setValue(3);
                        },
                        error: function (XmlHttpRequest, textStatus, errorThrown) { }
                    });
            }
            else {
                alert("El usuario no cuenta con un Email");
            }
        }
        //phone notification
        if (phoneId != null && emailId == null) {
            var phone = GetEntityRecords("amx_customercontactinformation", null, "amx_PhoneNo", "amx_customercontactinformationId  eq guid'" + phoneId[0].id + "'", false, null, null, null);
            var individual = Xrm.Page.getAttribute("customerid").getValue();
            var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");
            ////Mobile notification
            if (phone != null) {
                var workflowStartInput = {
                    'request': {
                        "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest, AmxPeruPSBActivities",
                        "pushType": "SINGLE", //hardcoded
                        "typeCostumer": individual[0].id.replace("{", "").replace("}", ""), //customerId
                        "messageBox": [
                            {
                                "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxExt, AmxPeruPSBActivities",
                                "messageChannel": "SMS",
                                "messageBox": [
                                    {
                                        "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxInt, AmxPeruPSBActivities",
                                        "customerId": individual[0].id.replace("{", "").replace("}", ""), //customerId
                                        "customerBox": phone[0].amx_PhoneNo //phn number11111
                                    }
                                ]
                            }
                        ],
                        "profileId": ["SMTP_FS_TCRM1", "SMS_FS_TCRM1"],
                        "communicationType": ["REGULATORIO"],
                        "communicationOrigin": "TCRM",
                        "deliveryReceipts": "NO",
                        "contentType": "MESSAGE",
                        "messageContent": "CUN generado satisfactoriamente"
                    }
                }
                jQuery.ajax(
                    {
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        datatype: "json",
                        data: JSON.stringify(workflowStartInput),
                        async: false,
                        cache: false,
                        url: apiUrl + 'AmxCoTorreDeControl',
                        xhrFields: {
                            withCredentials: true
                        },
                        beforeSend: function (XMLHttpRequest) {
                            XMLHttpRequest.setRequestHeader("Accept", "application/json");
                        },
                        success: function (data, textStatus, XmlHttpRequest) {
                            Xrm.Page.getAttribute("amx_notificationcun").setValue(3);
                        },
                        error: function (XmlHttpRequest, textStatus, errorThrown) { }
                    });
            }
            else {
                alert("el cliente no ccuenta con un Numero de telefono de contacto");
            }
        }
        //Both notification
        if (phoneId != null && emailId != null) {
            var email = GetEntityRecords("amx_customercontactinformation", null, "amx_Email", "amx_customercontactinformationId eq guid'" + emailId[0].id + "'", false, null, null, null);
            var phone = GetEntityRecords("amx_customercontactinformation", null, "amx_PhoneNo", "amx_customercontactinformationId  eq guid'" + phoneId[0].id + "'", false, null, null, null);
            var individual = Xrm.Page.getAttribute("customerid").getValue();
            var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");
            //both Email and Mobile
            if (phone != null && email != null) {
                var workflowStartInput = {
                    'request': {
                        "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest, AmxPeruPSBActivities",
                        "pushType": "SINGLE", //hardcoded
                        "typeCostumer": individual[0].id.replace("{", "").replace("}", ""), //customerId
                        "messageBox": [
                            {
                                //type a 
                                "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxExt, AmxPeruPSBActivities",
                                "messageChannel": "SMS",
                                "messageBox": [
                                    {
                                        "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxInt, AmxPeruPSBActivities",
                                        "customerId": individual[0].id.replace("{", "").replace("}", ""), //customerId
                                        "customerBox": phone[0].amx_PhoneNo //phn number11111
                                    }
                                ]
                                //
                            },
                            {
                                "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxExt, AmxPeruPSBActivities",
                                "messageChannel": "SMTP",
                                "messageBox": [
                                    {
                                        "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxInt, AmxPeruPSBActivities",
                                        "customerId": individual[0].id.replace("{", "").replace("}", ""), //customerId
                                        "customerBox": email[0].amx_Email //EmailIDhelder@ericsson.com
                                    }
                                ]
                            }
                        ],
                        "profileId": ["SMTP_FS_TCRM1", "SMS_FS_TCRM1"],
                        "communicationType": ["REGULATORIO"],
                        "communicationOrigin": "TCRM",
                        "deliveryReceipts": "NO",
                        "contentType": "MESSAGE",
                        "messageContent": "UN generado satisfactoriamente"
                    }
                }
                jQuery.ajax(
                    {
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        datatype: "json",
                        data: JSON.stringify(workflowStartInput),
                        async: false,
                        cache: false,
                        url: apiUrl + 'AmxCoTorreDeControl',
                        xhrFields: {
                            withCredentials: true
                        },
                        beforeSend: function (XMLHttpRequest) {
                            XMLHttpRequest.setRequestHeader("Accept", "application/json");
                        },
                        success: function (data, textStatus, XmlHttpRequest) {
                            debugger;
                            Xrm.Page.getAttribute("amx_notificationcun").setValue(3);
                        },
                        error: function (XmlHttpRequest, textStatus, errorThrown) {
                            debugger;
                        }
                    });
            }
            else {
                alert("El cliente no cuenta con numero de telefono ni Email");
            }
        }
        //Both null
        if (emailId == null && phoneId == null) {
            alert("Customer did not provide either Email or Phone number");
        }
    }
}

function getBIHeader() {
    var ownerID = Xrm.Page.getAttribute("ownerid").getValue();
    if (ownerID) {
        return GetEntityRecords("etel_bi_header", null, "ActivityId,Subject,etel_biheaderchanneltypecode", "CreatedBy/Id eq guid'" + ownerID[0].id + "' and StateCode/Value eq 0", false, null, null, null);
    }
}

function referenceBIHeader() {
    if (validations.constants.FORM_TYPE_CREATE == Xrm.Page.ui.getFormType()) {
        var relationshipBIheader = getBIHeader();
        let biHeaderChannel = relationshipBIheader[0].etel_biheaderchanneltypecode;
        if (biHeaderChannel && biHeaderChannel.Value) {
            setChannel(biHeaderChannel.Value);
        }
        if (relationshipBIheader) {
            var lookup = [
                {
                    id: relationshipBIheader[0].ActivityId,
                    entityType: 'etel_bi_header',
                    name: relationshipBIheader[0].Subject
                }];
            Xrm.Page.getAttribute("amx_caseid").setValue(lookup);
        }
    }
}

function setChannel(biHeaderChannel) {
    let codeChannel = {};

    function getSpecificChannel(code) {
        return GetEntityRecords("amx_channel", null, "amx_channelId, amx_name", "amx_code eq '" + code + "'", false, null, null, null);
    }
    switch (biHeaderChannel) {
        case BI_HEADER_CHANNELS.PHONE_CALL:
            codeChannel = getSpecificChannel('1003');
            break;
        case BI_HEADER_CHANNELS.FACE_TO_FACE:
            codeChannel = getSpecificChannel('1001');
            break;
        case BI_HEADER_CHANNELS.EMAIL:
            codeChannel = getSpecificChannel('1001');
            break;
    }
    if (codeChannel && codeChannel.length > 0) {
        var lookUp = [
            {
                id: codeChannel[0].amx_channelId,
                entityType: 'amx_channel',
                name: codeChannel[0].amx_name,
            }];
        Xrm.Page.getAttribute("amx_channel").setValue(lookUp);
        validateChannel();
    }
}
//set default customer info

function setCustomerInfo() {
    if (Xrm.Page.ui.getFormType() == validations.constants.FORM_TYPE_CREATE) {
        setDefaultEmail();
        setDefaultTelephone();
        setDefaultCellphone();
        setDefaultAddress();
    }
}

function setDefaultEmail() {
    var individualID = Xrm.Page.getAttribute("customerid").getValue();
    if (individualID) {
        var emailRelated = GetEntityRecords("amx_customercontactinformation", null, "amx_Email,amx_customercontactinformationId", "amx_IndividualCustomerId/Id eq guid'" + individualID[0].id + "' and amx_ContactType/Value eq 173800000", false, null, null, null);
        if (emailRelated) {
            var lookup = new Array();
            lookup[0] = new Object();
            lookup[0].id = emailRelated[0].amx_customercontactinformationId;
            lookup[0].entityType = 'amx_customercontactinformation';
            lookup[0].name = emailRelated[0].amx_Email;
            Xrm.Page.getAttribute("amx_customercontactinformation").setValue(lookup);
        }
    }
}

function setDefaultTelephone() {
    var contactInformationPhone = getCustomerContactInformation(173800001);
    if (contactInformationPhone && contactInformationPhone[0]) {
        contactInformationPhone = contactInformationPhone[0];
        let lookUpPhone = [
            {
                id: contactInformationPhone.amx_customercontactinformationId,
                entityType: 'amx_customercontactinformation',
                name: contactInformationPhone.amx_PhoneNo
            }];
        Xrm.Page.getAttribute("amx_phone").setValue(lookUpPhone);
    }
}

function setDefaultCellphone() {
    var contactInformationPhone = getCustomerContactInformation(173800003);
    if (contactInformationPhone != null && contactInformationPhone[0]) {
        contactInformationPhone = contactInformationPhone[0];
        let lookUpPhone = [
            {
                id: contactInformationPhone.amx_customercontactinformationId,
                entityType: 'amx_customercontactinformation',
                name: contactInformationPhone.amx_PhoneNo
            }
        ];
        Xrm.Page.getAttribute("amx_mobilephone").setValue(lookUpPhone);
    }
}

function setDefaultAddress() {
    let primaryAddress = getMainAddress();
    if (primaryAddress && primaryAddress[0]) {
        primaryAddress = primaryAddress[0];
        let lookUpAddress = [
            {
                id: primaryAddress.etel_customeraddressId,
                entityType: 'etel_customeraddress',
                name: primaryAddress.amx_SearchAddress
            }];
        Xrm.Page.getAttribute("amx_customeraddress").setValue(lookUpAddress);
    }
}

function getCustomerContactInformation(contactType) {
    let individualObject = Xrm.Page.getAttribute("customerid").getValue();
    if (individualObject && individualObject[0]) {
        let individualId = individualObject[0].id;
        let condition = "amx_IndividualCustomerId/Id eq guid'" + individualId + "' and amx_ContactType/Value eq " + contactType;
        return GetEntityRecords("amx_customercontactinformation", null, "amx_PhoneNo,amx_Email,amx_customercontactinformationId", condition, false, null, null, null);
    }
}

function getMainAddress() {
    let individualObject = Xrm.Page.getAttribute("customerid").getValue();
    if (individualObject && individualObject[0]) {
        let individualId = individualObject[0].id;
        let condition = "etel_individualcustomerid/Id eq guid'" + individualId + "' and etel_isprimaryaddress eq true";
        return GetEntityRecords("etel_customeraddress", null, "etel_addressline1,amx_SearchAddress,etel_customeraddressId", condition, false, null, null, null);
    }
}
//remembrance function

function sendCase(context) {
    //Recording Flags
    var remembranceAdjustments = Xrm.Page.getAttribute("amx_adjustment").getValue();
    var remembranceCancellations = Xrm.Page.getAttribute("amx_cancel").getValue();
    var remembranceCentralRisk = Xrm.Page.getAttribute("amx_centralrisk").getValue();
    //Get case status
    var caseStatus = Xrm.Page.getAttribute("amx_state").getValue();
    var ScalingCloseStatus = 'ScalingClose';
    var statusName = GetEntityRecords("etel_crmconfiguration", null, "etel_value", "etel_name eq '" + ScalingCloseStatus + "'", false, null, null, null);
    var caseScalingStatus = statusName[0].etel_value;
    let optionsToNotify = [];
    remembranceAdjustments ? optionsToNotify.push(
        {
            option: 'Adjustment'
        }) : false;
    remembranceCancellations ? optionsToNotify.push(
        {
            option: 'Cancelation'
        }) : false;
    remembranceCentralRisk ? optionsToNotify.push(
        {
            option: 'CentralRisk'
        }) : false;
    if (caseStatus[0].name == caseScalingStatus) {
        notifyUserOptions(optionsToNotify);
    }
}

function notifyUserOptions(optionsToNotify) {
    optionsToNotify.forEach(function (notify, index) {
        let options = {
            affirmation: {
                option: 'Si'
            },
            denation: {
                option: 'No'
            },
            default: {
                option: 'No aplica'
            }
        };
        switch (notify.option) {
            case 'Adjustment':
                options.generalMessage = 'Realizo los ajustes necesarios sobre el caso.';
                options.affirmation.successMessage = 'ha realizado los ajustes necesarios';
                options.
                    default.successMessage = 'No aplica la ejecución de ajustes necesarios';
                options.attribute = 'amx_adjustment';
                options.attributeToUpdate = 'amx_adjustmentstatus';
                break;
            case 'Cancelation':
                options.generalMessage = 'Realizo los ajustes de cancelación necesarios sobre el caso.';
                options.affirmation.successMessage = 'ha realizado los ajustes necesarios';
                options.
                    default.successMessage = 'No aplica la ejecución de ajustes de cancelación necesarios';
                options.attribute = 'amx_cancel';
                options.attributeToUpdate = 'amx_cancelstatus';
                break;
            case 'CentralRisk':
                options.generalMessage = 'Realizo la validación de centrales de riesgo necesarios sobre el caso.';
                options.affirmation.successMessage = 'ha realizado los ajustes necesarios';
                options.
                    default.successMessage = 'No aplica la ejecución de la validación de centrales de riesgo.';
                options.attribute = 'amx_centralrisk';
                options.attributeToUpdate = 'amx_centralriskstatus';
                break;
        }
        //Common functions are executed for all responses
        options.commonFunctions = function () {
            setWithAnswerStatus();
        }
        //Callback for all popUp responses
        options.callBack = function (value) {
            options.commonFunctions();
            setStatusRememberValue(options.attribute, options.attributeToUpdate, value);
            optionsToNotify.splice(index, 1);
            notifyUserOptions(optionsToNotify);
        }
        showPopUpRemember(options);
    });
}

function setWithAnswerStatus() {
    var caseStatus = Xrm.Page.getAttribute("amx_state").getValue();
    var SendCaseStatus = 'SendCaseStatus';
    var statusName = GetEntityRecords("etel_crmconfiguration", null, "etel_value", "etel_name eq '" + SendCaseStatus + "'", false, null, null, null);
    var caseStatusId = GetEntityRecords("amx_statecase", null, "amx_statecaseId,amx_name", "amx_code eq '" + statusName[0].etel_value + "'", false, null, null, null);
    if (caseStatusId != null) {
        var lookup = [
            {
                id: caseStatusId[0].amx_statecaseId,
                entityType: 'amx_statecase',
                name: caseStatusId[0].amx_name
            }];
        Xrm.Page.getAttribute("amx_state").setValue(lookup);
    }
}

function showPopUpRemember(options) {
    Alert.show("Señor Usuario: ", options.generalMessage, [
        new Alert.Button(options.affirmation.option, function () {
            Alert.show(options.affirmation.successMessage, null, [
                new Alert.Button("OK", function () {
                    options.callBack(1);
                }),
            ], "SUCCESS", 500, 200);
        }, true, true),
        new Alert.Button(options.denation.option),
        new Alert.Button(options.
            default.option, function () {
                Alert.show(options.
                    default.successMessage, null, [
                        new Alert.Button("OK", function () {
                            options.callBack(3);
                        }),
                    ], "SUCCESS", 500, 200);
            }, true, true)
    ], "QUESTION", 500, 200);
}

function setStatusRememberValue(attribute, attributeToUpdate, value) {
    var remembranceAdjustments = Xrm.Page.getAttribute(attribute).getValue();
    if (remembranceAdjustments) {
        Xrm.Page.getAttribute(attributeToUpdate).setValue(value);;
    }
}

function enableSendCase() {
    var caseStatus = Xrm.Page.getAttribute("amx_state").getValue();
    if (caseStatus) {
        var ScalingCloseStatus = 'ScalingClose';
        if (ScalingCloseStatus) {
            var statusName = GetEntityRecords("etel_crmconfiguration", null, "etel_value", "etel_name eq '" + ScalingCloseStatus + "'", false, null, null, null);
            if (statusName) {
                return (caseStatus[0].name == statusName[0].etel_value);
            }
        }
    }
}

function validateCaseDocument() {
    if (Xrm.Page.ui.getFormType() == validations.constants.FORM_TYPE_UPDATE) {
        let caseLevel = Xrm.Page.getAttribute("amx_caselevel").getValue();
        let supportIsRequired = Xrm.Page.getAttribute("amx_requiresupport").getValue();

        if (caseLevel === 1 && supportIsRequired) {
            var currentStatus = Xrm.Page.getAttribute("amx_state").getValue();
            var inProcessState = GetEntityRecords("amx_statecase", null, "amx_statecaseId,amx_name", "amx_code eq '1'", false, null, null, null);

            if (currentStatus[0].id = inProcessState[0].amx_statecaseId) {
                var condition = "amx_caseid eq '" + Xrm.Page.data.entity.getId() + "'";
                var documents = GetEntityRecords("amx_documentspercase", null, "amx_documentid", condition, false, null, null, null);

                let hasFiles = true;
                if (documents == null || documents.length === 0) {
                    hasFiles = false;
                    var caseStatus = GetEntityRecords("amx_statecase", null, "amx_statecaseId,amx_name", "amx_code eq '2'", false, null, null, null);

                    Xrm.Page.getAttribute("amx_state").setValue([{
                        id: caseStatus[0].amx_statecaseId,
                        entityType: 'amx_statecase',
                        name: caseStatus[0].amx_name
                    }]);
                }

                Xrm.Page.getAttribute("amx_hasfile").setValue(hasFiles ? 1 : 0);
            }
        }
    }
}

function setType(context) {
    let voiceClient = Xrm.Page.getAttribute("amxperu_casesubsubcategory").getValue();
    if (voiceClient) {
        let relationshipVoiceType = GetEntityRecords("amx_amxperu_casesubsubcategory_amx_casetype", null, "amx_casetypeid", "amxperu_casesubsubcategoryid eq guid'" + voiceClient[0].id + "'", false, null, null, null);
        if (relationshipVoiceType) {
            let caseType = GetEntityRecords("amx_casetype", null, "amx_name,amx_casetypeId", "amx_casetypeId eq guid'" + relationshipVoiceType[0].amx_casetypeid + "'", false, null, null, null);
            if (caseType) {
                var lookup = [
                    {
                        id: caseType[0].amx_casetypeId,
                        entityType: 'amx_casetype',
                        name: relationshipVoiceType[0].amx_name
                    }];
                Xrm.Page.getAttribute("amx_casetype").setValue(lookup);
            }
        }
    }
}

function lockFieldForState() {
    debugger;
    if (Xrm.Page.getAttribute("amx_state").getValue()) {
        var stateCurrent = Xrm.Page.getAttribute("amx_state").getValue();
        var stateLookup = GetEntityRecords("amx_statecase", null, "amx_code", "amx_statecaseId eq guid'" + stateCurrent[0].id + "'", false, null, null, null);

        if (stateLookup != null) {
            if (stateLookup[0].amx_code == "1") {
                Xrm.Page.getControl("header_process_amx_adjustment").setDisabled(false);
                Xrm.Page.getControl("header_process_amx_centralrisk").setDisabled(false);
                Xrm.Page.getControl("header_process_amx_cancel").setDisabled(false);
                Xrm.Page.getControl("amx_adjustment").setDisabled(false);
                Xrm.Page.getControl("amx_centralrisk").setDisabled(false);
                Xrm.Page.getControl("amx_cancel").setDisabled(false);
            }
            else {
                Xrm.Page.getControl("header_process_amx_adjustment").setDisabled(true);
                Xrm.Page.getControl("header_process_amx_centralrisk").setDisabled(true);
                Xrm.Page.getControl("header_process_amx_cancel").setDisabled(true);
                Xrm.Page.getControl("amx_adjustment").setDisabled(true);
                Xrm.Page.getControl("amx_centralrisk").setDisabled(true);
                Xrm.Page.getControl("amx_cancel").setDisabled(true);
            }
        }
    }
}