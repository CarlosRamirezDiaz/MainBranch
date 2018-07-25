var orderCaptureListModel;

function RetreiveOrderCaptures(accountid, baId, startdate, enddate, pageIndex, orgOffset) {    
    var languageCode = window.parent.Xrm.Page.context.getUserLcid();
    var entityId = Xrm.Page.data.entity.getId(); // BA id

    if ((orgOffset === undefined) || (orgOffset === null)) {
        orgOffset = 0;
    }

    var OCCHistoryRequestModel = {
        "$type": "ExternalApiActivities.Models.OrderCaptureRequestModel, ExternalApiActivities",
        "customerId": accountid,
        "startDate": startdate,
        "endDate": enddate,
        "orgTimezoneOffset": orgOffset,
        "languagecode": languageCode.toString(),
        "viewtype": ""//$scope.selectedOption.value
    };

    var reqData = { "request": OCCHistoryRequestModel };

    $http.post(window.definitions.psbUrl + 'AmxRetrieveOrderCapture', reqData, { "withCredentials": true })
        .success(function (result) {
            if (result.Output.ordercapturelistmodel) {
                orderCaptureListModel = result.Output.ordercapturelistmodel;
            }
        }).error(function (data, status, headers, config) {
            alert(data.ExceptionMessage);
        });
}
function retreiveBILogActivity(customerId, baId) {
    var biLogActivity = GetEntityRecords("etel_bi_log", null, "etel_description", "etel_individualcustomerid/Id eq (guid'" + customerId + "') ", false, null, null, null);
    if (biLogActivity !== null) {
        if (biLogActivity.length > 0) {
            
            
        }
    }
}
function retreiveCase(customerId, baId) {
    var cases = GetEntityRecords("Incident", null, "TicketNumber", "etel_individualcustomerid/Id eq (guid'" + customerId + "') and amxperu_billingaccountoldinfo/Id eq (guid'" + baId + "')", false, null, null, null);
    if (cases !== null) {
        if (cases.length > 0) {


        }
    }
}

function getContract(customerId) {
    try {
        var config = {
            withCredentials: true
        };

        workflowGetFile = {
            "GetFileDocumentaryManagerRequest":
            {
                "$type": "AmxCoPSBActivities.Model.InvoiceClarification.AmxCoGetFileDocumentaryManagerRequest, AmxPeruPSBActivities",
                "individualId": customerId, "fileType": "CONTRATO", "isMobile": false,
            }
        };

        $http.post(apiUrl + 'AmxCoGetFileDocumentaryManager', JSON.stringify(workflowGetFile), config)
            .success(function (result) {
                if (result) {
                    var resultJson = JSON.parse(result.response);
                    var errorDetail = resultJson.errorDetail;
                    var error = resultJson.error;
                    var fileName = resultJson.fileName;
                    var base64file = resultJson.base64file;
                    var numContract = resultJson.numContract;

                    if (base64file === null || base64file === "") {
                        alert("Contrato no encontrado");
                    } else {
                        var windo = window.open("", "");
                        var objbuilder = '';
                        objbuilder += ('<embed width=\'100%\' height=\'100%\'  src="data:application/pdf;base64,');
                        objbuilder += (base64file);
                        objbuilder += ('" type="application/pdf" />');
                        windo.document.write(objbuilder); 
                    }
                }
            }).error(function (data, status, headers, config) {
                alert((data.ExceptionMessage === undefined ?
                    (data.data === undefined ? data :
                        (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                //$scope.httpLoading = false;
            });
    }
    catch (err) {
        alert("invoiceclarification - getContract: " + err.message);
    }
}
function sendNotification(customerId) {
    try {
        var contactInfo = GetEntityRecords("amx_customercontactinformation", null, "amx_email,amx_primarycontacttype,etel_externalid", "amx_individualcustomerid/Id eq (guid'" + customerId + "') and amx_contacttype/Value eq 173800000", false, null, null, null);
        var email = "";
        var extCustomerId = "";
        if (contactInfo !== null) {
            if (contactInfo.length > 0) {
                extCustomerId = contactInfo[0].etel_externalid;
                for (var i = 0; i < contactInfo.length; i++) {
                    if (contactInfo[0].amx_email !== null && contactInfo[0].amx_email === "") {
                        email = contactInfo[0].amx_email;
                        if (contactInfo[0].amx_primarycontacttype !== null) {
                            if (contactInfo[0].amx_primarycontacttype === true) {
                                break;
                            }
                        }
                    }
                }
            }
        }
        
        var config = {
            withCredentials: true
        };

        var messageboxInt = {
            "messageBox":
            {
                "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoMessageBoxInt, AmxPeruPSBActivities",
                    "customerId": extCustomerId, "customerBox": email,
            }            
        };

        var messageboxExt = {
            "messageBox":
            {
                "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoMessageBoxExt, AmxPeruPSBActivities",
                "messageChannel": "SMTP", "messageBox": messageboxInt,
            }
        };

        var profileId = ["profile1"];

        var communicationType = ["REGULATORIO"];
       

        workflowTorreControl = {
            "request":
            {
                "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest, AmxPeruPSBActivities",
                "typeCostumer": customerId, "messageBox": messageboxExt, "profileId": profileId, "communicationType": communicationType, "communicationOrigin": "TCRM", "deliveryReceipts": "N", "contentType": "MESSAGE", "messageContent": "Se le informa que se realizó el trámite referente a consulta de la factura",
            }
        };

        $http.post(apiUrl + 'AmxCoTorreDeControl', JSON.stringify(workflowTorreControl), config)
            .success(function (result) {
                if (result) {
                    var resultJson = JSON.parse(result.response);
                    var isValid = resultJson.isValid;
                    var message = resultJson.message;
                }
            }).error(function (data, status, headers, config) {
                alert((data.ExceptionMessage === undefined ?
                    (data.data === undefined ? data :
                        (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                //$scope.httpLoading = false;
            });
    }
    catch (err) {
        alert("invoiceclarification - sendNotification: " + err.message);
    }
}

function GetEntityRecords(entityLogicalName, entityId, pSelect, pFilter, getAsync, pOrder, pTop, pExpand) {

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