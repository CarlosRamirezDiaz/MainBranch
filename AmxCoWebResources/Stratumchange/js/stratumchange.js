var validations = {};
validations.constants = {
    FORM_TYPE_CREATE: 1,
    FORM_TYPE_UPDATE: 2
};

function onLoadForm() {

    Xrm.Page.getAttribute("amx_hasfile").setValue(false);

    Xrm.Page.data.entity.save();

    if (Xrm.Page.ui.getFormType() == validations.constants.FORM_TYPE_CREATE) {

        debugger;
        Xrm.Page.data.entity.save();
    }

    if (Xrm.Page.ui.getFormType() == validations.constants.FORM_TYPE_UPDATE && !Xrm.Page.getAttribute("amx_synchronized").getValue()) {
        debugger;

        var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");

        var workflowStartInput = {
            'StratumChangeCreateItemRequest': {
                '$type': 'AmxPeruPSBActivities.Model.StratumChange.StratumChangeCreateItemRequest, AmxPeruPSBActivities',
                'idStratum': "" + Xrm.Page.data.entity.getId(),
                "idUser": "" + Xrm.Page.context.getUserId()
            }
        };

        jQuery.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            data: JSON.stringify(workflowStartInput),
            async: false,
            cache: false,
            url: apiUrl + 'StratumChangeCreateItems',
            xhrFields: {
                withCredentials: true
            },
            beforeSend: function (XMLHttpRequest) {
                XMLHttpRequest.setRequestHeader("Accept", "application/json");
            },
            success: function (data, textStatus, XmlHttpRequest) {
                if (data) {
                    debugger;
                    if (data.Output.StratumChangeCreateItemResponse.IsError) {
                        alert(data.Output.CreateItemsAccountWithDataBSCSResponse.MsgError);
                    }
                    else {
                        Xrm.Page.getAttribute("amx_synchronized").setValue(true);
                        Xrm.Page.data.refresh(true).then(function () {
                            Xrm.Utility.openEntityForm(Xrm.Page.data.entity.getEntityName(), Xrm.Page.data.entity.getId());
                        }, null);
                    }
                }
            },
            error: function (XmlHttpRequest, textStatus, errorThrown) {
                Xrm.Utility.alertDialog((data.ExceptionMessage === undefined ?
                    (data.data === undefined ? data :
                        (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
            }
        });

        //try {
        //    var entityId = Xrm.Page.data.entity.getId();
        //    var entityName = Xrm.Page.data.entity.getEntityName();
        //    var request = LaunchActionNoParams(entityId, entityName, "amx_ACStratumChangeCreateItemsAddress");

        //    if (request.status == 200) {
        //        Xrm.Page.getAttribute("amx_synchronized").setValue(true);
        //        Xrm.Page.data.refresh(true).then(function () {
        //            Xrm.Utility.openEntityForm(Xrm.Page.data.entity.getEntityName(), Xrm.Page.data.entity.getId());
        //        }, null);
        //    } else { }
        //}
        //catch (e) {
        //}
    }

    validateSendInformation();
}

function lockFieldsAddressList(executionContext) {
    var entityObject = executionContext.getFormContext().data.entity;
    var stratumMgl = "";

    executionContext.getFormContext().data.entity.attributes.forEach(function (attribute, i) {
        if (attribute.getName() == "amx_customeraddress" || attribute.getName() == "amx_mglcrmstratum") {
            var emailControl = attribute.controls.get(0);
            emailControl.setDisabled(true);
        }
    });
}

function RetrieveKBArticleByTitle(title) {
    debugger;
    var message = "";
    var fetchResult = GetEntityRecords("KbArticle", null, "ArticleXml", "Title eq '" + title + "'", false, null, null, null);

    if (fetchResult.length > 0) {
        if (fetchResult[0].ArticleXml != null) {
            var message = fetchResult[0].ArticleXml;
            var xmlDoc = $.parseXML(message);
            $xml = $(xmlDoc);
            $title = $xml.find("section")[0].textContent
            message = $title;
        }
    }

    return message;
}

function validateDocumentUpload(context) {
    debugger;
    var saveEvent = context.getEventArgs();
    if (!Xrm.Page.getAttribute("amx_supportfilename").getValue() && !Xrm.Page.getAttribute("amx_othersupportfilename").getValue()) {
        alert("Debe seleccionar un nombre de documento para realizar un cambio de estrato");
        saveEvent.preventDefault();
    }
    else {
        if (Xrm.Page.getAttribute("amx_hasfile").getValue() == false) {
            alert("Debe adjuntar un documento para realizar un cambio de estrato");
            saveEvent.preventDefault();
        }
        else {
            var titleCondSupp = "Condiciones de soportes requeridos";
            var wCondSupp = RetrieveKBArticleByTitle(titleCondSupp);
            if (wCondSupp != null) {
                Alert.show(wCondSupp, "", [new Alert.Button("Ok", function () {

                    var entityId = context.getFormContext().data.entity.getId();
                    var entityName = context.getFormContext().data.entity.getEntityName();

                    sendBase64FileToDocumentaryManager(saveEvent);

                    stratumChangeCretateCase();
                }, false, false)], "INFO", 1000, 400);
            }
        }
    }
}

function sendBase64FileToDocumentaryManager(saveEvent) {

    debugger;

    var filename;

    if (Xrm.Page.getAttribute("amx_supportfilename").getValue()) {
        filename = Xrm.Page.getAttribute("amx_supportfilename").getText();
    }
    else if (Xrm.Page.getAttribute("amx_othersupportfilename").getValue()) {
        filename = Xrm.Page.getAttribute("amx_othersupportfilename").getValue();
    }

    if (Xrm.Page.getAttribute("amx_fileextension").getValue()) {
        filename = filename + "." + Xrm.Page.getAttribute("amx_fileextension").getValue();
    }

    var individual = Xrm.Page.getAttribute("amx_individualcustomer").getValue();

    if (individual) {

        var file = {
            'SendBase64FileToDocumentaryManagerRequest': {
                '$type': 'AmxPeruPSBActivities.Model.StratumChange.AmxCoSendBase64FileToDocumentaryManagerRequest, AmxPeruPSBActivities',
                'base64file': Xrm.Page.getAttribute("amx_base64file").getValue(),
                'filename': filename,
                'individualid': individual[0].id
            }
        }

        var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");

        jQuery.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            data: JSON.stringify(file),
            async: false,
            cache: false,
            url: apiUrl + 'AmxCoSendBase64FileToDocumentaryManager',
            xhrFields: {
                withCredentials: true
            },
            beforeSend: function (XMLHttpRequest) {
                XMLHttpRequest.setRequestHeader("Accept", "application/json");
            },
            success: function (data, textStatus, XmlHttpRequest) {
                if (data) {

                    if (data.Output.SendBase64FileToDocumentaryManagerResponse.error == false) {

                        alert('El documento: ' + filename + ' que se adjuntó, se envió correctamente.');
                    }
                    else {

                        if (data.Output.SendBase64FileToDocumentaryManagerResponse.ErrorDetail) {
                            alert(data.Output.SendBase64FileToDocumentaryManagerResponse.ErrorDetail[0]);
                        }


                        saveEvent.preventDefault();
                    }
                }
            },
            error: function (XmlHttpRequest, textStatus, errorThrown) {
                alert('Se presento un error al intentar enviar el documento adjunto.');
                saveEvent.preventDefault();
            }
        });
    }
    else {
        alert('El campo: Cliente individual es requerido.');
        saveEvent.preventDefault();
    }
}

function validateSendInformation() {
    if (Xrm.Page.getAttribute("amx_requestcasesended").getValue()) {
        debugger;
        if (Xrm.Page.getAttribute("amx_responserequest").getValue()) {
            var message = Xrm.Page.getAttribute("amx_responserequest").getValue();
            var messages = message.split("|");

            if (messages.length > 1) {
                var lastMessage = "Mensaje para cliente: " + messages[0] + " <br /><br /><br /> Mensaje para asesor: " + messages[1];
                Alert.show(lastMessage, "", [new Alert.Button("Ok", function () {
                    var individualCustomer = Xrm.Page.getAttribute("amx_individualcustomer").getValue();

                    if (individualCustomer != null) {
                        if (individualCustomer.length > 0) {
                            Xrm.Utility.openEntityForm(individualCustomer[0].entityType, individualCustomer[0].id);
                        }
                    }
                }, false, false)], "INFO", 750, 300);
            }
        }
    }
}

function showInformationPlan() {

    debugger;
    var wascasecreated = Xrm.Page.getAttribute("amx_wasthecasecreatedinmgl").getValue()

    if (wascasecreated) {

        Xrm.Page.ui.tabs.get("tab_general_sc").sections.get("scInformationPlan").setVisible(true);
    }
    else {
        Xrm.Page.ui.tabs.get("tab_general_sc").sections.get("scInformationPlan").setVisible(false);
    }
}

function stratumChangeCretateCase() {
    var request = {
        "IdStratumChange": "" + Xrm.Page.data.entity.getId()
    }

    var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");

    jQuery.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(request),
        async: false,
        cache: false,
        url: apiUrl + 'AmxCoStratumChangeCreateCase',
        xhrFields: {
            withCredentials: true
        },
        beforeSend: function (XMLHttpRequest) {
            XMLHttpRequest.setRequestHeader("Accept", "application/json");
        },
        success: function (data, textStatus, XmlHttpRequest) {
            if (data) {
                Xrm.Page.getAttribute("amx_requestcasesended").setValue(true);

                Xrm.Page.getAttribute("amx_supportfilename").setValue(null);
                Xrm.Page.getAttribute("amx_othersupportfilename").setValue(null);
                Xrm.Page.getAttribute("amx_base64file").setValue(null);
                Xrm.Page.getAttribute("amx_fileextension").setValue(null);

                Xrm.Page.data.refresh(true).then(function () {
                    Xrm.Utility.openEntityForm(Xrm.Page.data.entity.getEntityName(), Xrm.Page.data.entity.getId());
                }, null);
            }
        },
        error: function (XmlHttpRequest, textStatus, errorThrown) {
            Xrm.Page.getAttribute("amx_requestcasesended").setValue(true);
            Xrm.Page.data.refresh(true).then(function () {
                Xrm.Utility.openEntityForm(Xrm.Page.data.entity.getEntityName(), Xrm.Page.data.entity.getId());
            }, null);
        }
    });
}