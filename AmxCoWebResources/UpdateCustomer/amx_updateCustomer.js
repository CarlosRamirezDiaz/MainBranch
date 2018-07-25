function updateCustomerData() {
    var titleName = "Condiciones actualizacion de datos";
    var wMessage = AMX.COMMON.RetrieveKBArticleByTitle(titleName);
    Alert.show(wMessage, "", [new Alert.Button("Acepto",
        function () {
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
                sendRequest({
                    type: "POST",
                    url: urlDigiturno,
                    data: DigiturnoRequest,
                    onSuccess: function (response) {
                        redirectToUpdateEntity();
                    },
                    onError: function () {
                        alert("Error al abrir el digiturno");
                        Alert.hide();
                    }
                });
            } else {
                redirectToUpdateEntity();
            }
        }, false, false),
    new Alert.Button("No acepto", function () {
        Alert.hide();
    }, true, true)], "INFO", 1000, 400);
}


function redirectToUpdateEntity() {

    var individualId = Xrm.Page.data.entity.getId();

    SDK.REST.retrieveRecord(
        individualId,
        "Contact",
        "amxperu_DocumentType," +
        "etel_iddocumentnumber," +
        "amx_datecostumervalidation," +
        "FirstName," +
        "LastName," +
        "FullName," +
        "BirthDate," +
        "GenderCode," +
        "amxperu_dataprotection," +
        "amx_ccinfoupdjsontext",
        null,
        function (individual) {

            var parameters = {};
            setParameter(parameters, "amx_dataFetched", true);
            setParameter(parameters, "amx_individual", individualId);
            setParameter(parameters, "amx_name", individual.FullName);
            setParameter(parameters, "amx_documenttype", individual.amxperu_DocumentType.Value);
            setParameter(parameters, "amx_iddocumentnumber", individual.etel_iddocumentnumber);
            setParameter(parameters, "amx_datecostumervalidation", formatDate(individual.amx_datecostumervalidation));
            setParameter(parameters, "amx_firstname", individual.FirstName);
            setParameter(parameters, "amx_lastname", individual.LastName);
            setParameter(parameters, "amx_birthday", formatDate(individual.BirthDate));
            setParameter(parameters, "amx_gendercode", individual.GenderCode.Value);
            setParameter(parameters, "amx_dataprotection", individual.amxperu_dataprotection.Value);
            setParameter(parameters, "amx_ccinfoupdjsontext", individual.amx_ccinfoupdjsontext);

            var windowOptions = {
                openInNewWindow: false
            };

            Xrm.Utility.openEntityForm("amx_updatecustomer", null, parameters, windowOptions);
        },
        function (error) {
            console.log("Error al llamar los datos del usuario:", error);
        }
    );
}

function onLoadUpdateCustomer() {
    Xrm.Page.data.entity.save();
}

function onFieldChange(fieldName) {

    var dataFetched = !!Xrm.Page.context.getQueryStringParameters().amx_dataFetched;
    if (!dataFetched) return;

    var knowledgeDatabaseFieldsMap = {
        amx_documenttype: "Condiciones Actualizar tipo de documento",
        amx_iddocumentnumber: "Condiciones Actualizar documento",
        amx_datecostumervalidation: "Condiciones actualizar fecha expedición",
        amx_firstname: "Condiciones actualizar nombre",
        amx_lastname: "Condiciones actualizar nombre",
        amx_birthday: "Condiciones actualizar fecha nacimiento",
        amx_gendercode: "Condiciones actualizar genero"
    };

    var titleName = knowledgeDatabaseFieldsMap[fieldName];
    var wMessage = AMX.COMMON.RetrieveKBArticleByTitle(titleName);

    Alert.show(wMessage, "", [new Alert.Button("Entendido",
        function () {
            Xrm.Page.getAttribute("amx_requirefile").setValue(true);
            Alert.hide();
        }
    ), new Alert.Button("Deshacer",
        function () {
            var previousValue = Xrm.Page.context.getQueryStringParameters()[fieldName];
            if (fieldName == "amx_datecostumervalidation" || fieldName == "amx_birthday") {
                var dateParts = previousValue.split('/');
                previousValue = new Date(dateParts[2], dateParts[0] - 1, dateParts[1]);
            }
            Xrm.Page.getAttribute(fieldName).setValue(previousValue);
            Alert.hide();
        })
    ]);
}

function updateCustomer() {

    var contactId = Xrm.Page.context.getQueryStringParameters().amx_individual;
    var previousContactInfo = Xrm.Page.getAttribute("amx_ccinfoupdjsontext").getValue();
    var newContactInfo = Xrm.Page.context.getQueryStringParameters()["amx_ccinfoupdjsontext"];

    var callDocumentaryManager = false;
    var callParadigmaAndBSCS = false;

    if (previousContactInfo != newContactInfo) {
        var previousEmail = getEmailFromContactInfo(previousContactInfo);
        var newEmail = getEmailFromContactInfo(newContactInfo);
        if (previousEmail != newEmail) {
            callParadigmaAndBSCS = true;
        }
    }
    if (Xrm.Page.getAttribute("amx_requirefile").getValue() == 1) {
        callDocumentaryManager = true;
    }
    if (callParadigmaAndBSCS) {
        callIntegrationWithParadigma(contactId, newEmail, function () {
            callIntegrationWithBSCS(contactId, newEmail, function () {
                if (callDocumentaryManager) {
                    callIntegrationWithDocumentaryManager(contactId, function () {
                        updateContact(contactId);
                    });
                } else {
                    updateContact(contactId);
                }
            });
        })
    } else {
        if (callDocumentaryManager) {
            callIntegrationWithDocumentaryManager(contactId, function () {
                updateContact(contactId);
            });
        } else {
            updateContact(contactId);
        }
    }
}

function updateContact(contactId) {

    SDK.REST.updateRecord(contactId, {
        "amxperu_DocumentType": { Value: Xrm.Page.getAttribute("amx_documenttype").getValue() },
        "etel_iddocumentnumber": Xrm.Page.getAttribute("amx_iddocumentnumber").getValue(),
        "amx_datecostumervalidation": Xrm.Page.getAttribute("amx_datecostumervalidation").getValue(),
        "FirstName": Xrm.Page.getAttribute("amx_firstname").getValue(),
        "LastName": Xrm.Page.getAttribute("amx_lastname").getValue(),
        "BirthDate": Xrm.Page.getAttribute("amx_birthday").getValue(),
        "GenderCode": { Value: Xrm.Page.getAttribute("amx_gendercode").getValue() },
        "amxperu_dataprotection": { Value: Xrm.Page.getAttribute("amx_dataprotection").getValue() },
        "amx_ccinfoupdjsontext": Xrm.Page.getAttribute("amx_ccinfoupdjsontext").getValue()
    }, "Contact",
        function () {
            Xrm.Page.getAttribute("amx_requirefile").setValue(0);
            Xrm.Page.getAttribute("amx_hasfile").setValue(0);
            Xrm.Page.getAttribute("amx_base64file").setValue(null);
            Xrm.Page.getAttribute("amx_filename").setValue(null);
            Xrm.Page.getAttribute("amx_fileextension").setValue(null);
            Xrm.Page.getAttribute("amx_lastbilog").setValue(new Date());
            Xrm.Page.data.entity.save();
            alert("Registro guardado correctamente");
        },
        function () {
            alert("Error al guardar");
        });
}

function getEmailFromContactInfo(contactInfo) {
    for (var i = 0; i < contactInfo; i++) {
        var contactInfo = contactInfo[i];
        if (contactInfo.contacttype == 173800000 && contactInfo.isprimary == 1) {
            return email;
        }
    }
    return null;
}

function validateAttachment() {
    if (Xrm.Page.getAttribute("amx_hasfile").getValue() == false) {
        alert("Debe adjuntar un documento para realizar la actualizacion de datos");
        return false;
    }
    if (!Xrm.Page.getAttribute("amx_filename").getValue()) {
        alert("Debe seleccionar un nombre de documento para realizar la actualizacion de datos");
        return false;
    }
    if (!Xrm.Page.getAttribute("amx_fileextension").getValue()) {
        alert("Error al obtener la extension del documento para realizar la actualizacion de datos");
        return false;
    }
    return true;
}

function callIntegrationWithDocumentaryManager(id, callback) {

    if (!validateAttachment()) { return; }

    var attachment = Xrm.Page.getAttribute("amx_base64file").getValue();
    var filename = Xrm.Page.getAttribute("amx_filename").getValue();
    var fileextension = Xrm.Page.getAttribute("amx_fileextension").getValue();

    var file = {
        'SendBase64FileToDocumentaryManagerRequest': {
            '$type': 'AmxPeruPSBActivities.Model.StratumChange.AmxCoSendBase64FileToDocumentaryManagerRequest, AmxPeruPSBActivities',
            'base64file': attachment,
            'filename': filename + "." + fileextension,
            'individualid': id
        }
    };

    var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");
    apiUrl = apiUrl + 'AmxCoSendBase64FileToDocumentaryManager';

    sendRequest({
        type: "POST",
        url: apiUrl,
        data: file,
        onSuccess: function (response) {
            if (response) {
                if (response.Output.SendBase64FileToDocumentaryManagerResponse.error == false) {
                    callback();
                    alert('El documento: ' + filename + "." + fileextension + ' que se adjuntó, se envió correctamente.');
                }
                else {
                    if (response.Output.SendBase64FileToDocumentaryManagerResponse.ErrorDetail) {
                        alert(response.Output.SendBase64FileToDocumentaryManagerResponse.ErrorDetail[0]);
                    }
                }
            }
        },
        onError: function () {
            alert('Se presento un error al intentar enviar el documento adjunto.');
        }
    });
}

function callIntegrationWithParadigma(id, email, callback) {

    var data = {
        'AmxCoCustomerEmailBillingRequest': {
            '$type': 'AmxPeruPSBActivities.Model.CustomerEmailBilling.AmxCoCustomerEmailBillingRequest, AmxPeruPSBActivities',
            'numeroCuenta': id,
            'email1': email
        }
    };

    var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");
    apiUrl = apiUrl + 'AmxCoCustomerEmailBilling';

    sendRequest({
        type: "POST",
        url: apiUrl,
        data: data,
        onSuccess: function (response) {
            callback();
        },
        onError: function () {
            alert('Se presento un error al integrarse con Paradigma.');
        }
    });
}

function callIntegrationWithBSCS(id, email, callback) {

    var data = {
        'AmxCoCustomerChangeEmailRequest': {
            '$type': 'AmxSoapServicesActivities.Model.AmxCoCustomerChangeEmailRequest, AmxSoapServicesActivities',
            'inputAttributes.customersNew.externalCustomerId': id,
            'inputAttributes.addresses.Item.AddressWrite.adrEmail': email
        }
    };

    var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");

    sendRequest({
        type: "POST",
        url: apiUrl,
        data: data,
        onSuccess: function (response) {
            callback();
        },
        onError: function () {
            alert('Se presento un error al integrarse con BSCS.');
        }
    });
}

function scaleCase() {

    var titleName = "Tramitar Solicitud del Cliente - Generar casos y subcasos";
    var wMessage = AMX.COMMON.RetrieveKBArticleByTitle(titleName);

    Alert.show(wMessage, "", [new Alert.Button("Aceptar",
        function () {
            Alert.hide();
        })
    ]);

}

function sendRequest(parameters) {
    var req = new XMLHttpRequest();
    req.withCredentials = true;
    req.open(parameters.type, parameters.url, false);
    req.setRequestHeader("Accept", "application/json");
    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    req.onreadystatechange = function () {
        debugger;
        if (this.readyState === 4 && this.status == 200) {
            var response = JSON.parse(this.response);
            parameters.onSuccess(response);
        } else {
            parameters.onError();
        }
    };
    req.send(JSON.stringify(parameters.data));
}

function getAttribute(attribute) {
    Xrm.Page.getAttribute(attribute).getValue();
}

function setParameter(parameters, key, value) {
    if (value == null) {
        return;
    }
    parameters[key] = value;
}

function formatDate(date) {
    if (!date) {
        return null;
    }
    var dd = date.getUTCDate();
    var mm = date.getUTCMonth() + 1;
    var yyyy = date.getUTCFullYear();
    return mm + '/' + dd + '/' + yyyy;
}