var translation_OrderCaptureCancelDialog = {
    formId: "OrderCaptureCancelDialog",
    data: null,
    GetData: function () {
        if (translation_OrderCaptureCancelDialog.data == null) {
            translation_OrderCaptureCancelDialog.data = GetTranslationData(translation_OrderCaptureCancelDialog.formId);
        }
        return translation_OrderCaptureCancelDialog.data;
    }
}

var translation_OrderCapturePostponeDialog = {
    formId: "OrderCapturePostponeDialog",
    data: null,
    GetData: function () {
        if (translation_OrderCapturePostponeDialog.data == null) {
            translation_OrderCapturePostponeDialog.data = GetTranslationData(translation_OrderCapturePostponeDialog.formId);
        }
        return translation_OrderCapturePostponeDialog.data;
    }
}

var translation_FingerprintDialog = {
    formId: "FingerprintDialog",
    data: null,
    GetData: function () {
        if (translation_FingerprintDialog.data == null) {
            translation_FingerprintDialog.data = GetTranslationData(translation_FingerprintDialog.formId);
        }
        return translation_FingerprintDialog.data;
    }
}

translation_OrderCaptureCancelDialog.GetData();
translation_OrderCapturePostponeDialog.GetData();
translation_FingerprintDialog.GetData();

var OrderCaptureRibbonButton = {

    OrderCapture_StatusCode: { Postponed: 831260010, Cancelled: 831260011 },

    CancelSelectedOptionValue: 0,
    PostponeSelectedOptionValue: 0,

    PostponeOrderRibbonButton: function () {
        var webResourceName = "amx_/OrderCapture/OrderCapturePostponeDialog.html";
        var width = 500;
        var height = 300;
        var title = translation_OrderCapturePostponeDialog.data.tPostponeTheOrder;
        var buttons = [
            new Alert.Button("Ok", OrderCaptureRibbonButton.PostponeOrderButton, true),
            new Alert.Button(translation_OrderCapturePostponeDialog.data.tReturnButton, null, true)
        ];
        var baseUrl = Xrm.Page.context.getClientUrl();
        var preventCancel = false;
        var padding = null;

        Alert.showWebResource(webResourceName, width, height, title, buttons, baseUrl, preventCancel, padding)
    },

    PostponeOrderButton: function () {
        var recordId = Xrm.Page.data.entity.getId();

        if (OrderCaptureRibbonButton.PostponeSelectedOptionValue <= 0) {
            alert("Select a postpone reason");
            return;
        }

        var orderCapture = {};
        orderCapture.statuscode = { Value: OrderCaptureRibbonButton.OrderCapture_StatusCode.Postponed };
        orderCapture.amx_PostponeReason = { Value: OrderCaptureRibbonButton.PostponeSelectedOptionValue };

        SDK.REST.updateRecord(
            recordId,
            orderCapture,
            "etel_ordercapture",
            OrderCaptureRibbonButton.RedirectTo360View,
            errorHandler
        );
    },

    CancelOrderRibbonButton: function () {
        var webResourceName = "amx_/OrderCapture/OrderCaptureCancelDialog.html";
        var width = 500;
        var height = 300;
        var title = translation_OrderCaptureCancelDialog.data.tCancelTheOrder;
        var buttons = [
            new Alert.Button("Ok", OrderCaptureRibbonButton.CancelOrderButton, true),
            new Alert.Button(translation_OrderCaptureCancelDialog.data.tReturnButton, null, true)
        ];
        var baseUrl = Xrm.Page.context.getClientUrl();
        var preventCancel = false;
        var padding = null;

        Alert.showWebResource(webResourceName, width, height, title, buttons, baseUrl, preventCancel, padding)
    },

    CancelOrderButton: function () {
        var recordId = Xrm.Page.data.entity.getId();

        if (OrderCaptureRibbonButton.CancelSelectedOptionValue <= 0) {
            alert("Select a cancel reason");
            return;
        }

        var orderCapture = {};
        orderCapture.statuscode = { Value: OrderCaptureRibbonButton.OrderCapture_StatusCode.Cancelled };
        orderCapture.amx_CancelReason = { Value: OrderCaptureRibbonButton.CancelSelectedOptionValue };

        SDK.REST.updateRecord(
            recordId,
            orderCapture,
            "etel_ordercapture",
            OrderCaptureRibbonButton.RedirectTo360View,
            errorHandler
        );
    },

    RedirectTo360View: function () {
        var etel_individualcustomerid = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();

        if (etel_individualcustomerid != null) {
            Xrm.Utility.openEntityForm("contact", etel_individualcustomerid[0].id);
        }
    },

    FingerPrintRibbonButton: function () {
        var customerId = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
        if (customerId != null) {
            customerId = customerId[0].id;

            var req = new XMLHttpRequest();
            req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/contacts(" + customerId.replace("{", "").replace("}", "") + ")?$select=etel_iddocumentnumber,fullname", true);
            req.setRequestHeader("OData-MaxVersion", "4.0");
            req.setRequestHeader("OData-Version", "4.0");
            req.setRequestHeader("Accept", "application/json");
            req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
            req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
            req.onreadystatechange = function() {
                if (this.readyState === 4) {
                    req.onreadystatechange = null;
                    if (this.status === 200) {
                        var result = JSON.parse(this.response);
                        var etel_iddocumentnumber = result["etel_iddocumentnumber"];
                        var fullname = result["fullname"];
                        var data = "action=huella&documentid=" + etel_iddocumentnumber + "&fullname=" + fullname;
                        
                        var webResourceName = "amx_/OrderCapture/CertiCamara/FingerPrintDialog.html?data=" + encodeURIComponent(data);
                        var width = 500;
                        var height = 300;
                        var title = translation_FingerprintDialog.data.tFingerPrintDialogTitle;
                        var buttons = [
                            new Alert.Button(translation_OrderCapturePostponeDialog.data.tReturnButton, OrderCaptureRibbonButton.validateFingerprint, true)
                        ];
                        var baseUrl = Xrm.Page.context.getClientUrl();
                        var preventCancel = false;
                        var padding = null;

                        Alert.showWebResource(webResourceName, width, height, title, buttons, baseUrl, preventCancel, padding);
                    } else {
                        Xrm.Utility.alertDialog(this.statusText);
                    }
                }
            };
            req.send();
        }
    },

    FingerPrintMinuciaRibbonButton: function () {
        var webResourceName = "amx_/OrderCapture/CertiCamara/FingerPrintDialog.html?data=action%3Dminucia";
        var width = 500;
        var height = 300;
        var title = translation_FingerprintDialog.data.tFingerPrintDialogMinuciaTitle;
        var buttons = [
            new Alert.Button(translation_OrderCapturePostponeDialog.data.tReturnButton, OrderCaptureRibbonButton.validateFingerprint, true)
        ];
        var baseUrl = Xrm.Page.context.getClientUrl();
        var preventCancel = false;
        var padding = null;

        Alert.showWebResource(webResourceName, width, height, title, buttons, baseUrl, preventCancel, padding);
    },

    fingerPrintValidationRibbonButton: function () {
    }
}

function escalationCaseButton() {
    Xrm.Page.ui.clearFormNotification('msg_Action');

    try {

        var entityId = Xrm.Page.data.entity.getId();
        var entityName = Xrm.Page.data.entity.getEntityName();
        var request = LaunchActionNoParams(entityId, entityName, "amx_ACOrderCaptureOrderCaptureCreateCaseCreditRisk");

        if (request.status == 200) {
            var entityIdIncident = request.responseXML.childNodes[0].textContent;
            if (entityIdIncident != null && entityIdIncident != undefined) {
                entityIdIncident = entityIdIncident.replace("amx_ACOrderCaptureOrderCaptureCreateCaseCreditRisk", "");
                entityIdIncident = entityIdIncident.replace("incidentid", "");
                Xrm.Utility.openEntityForm("incident", entityIdIncident);
            }
            else {
                Xrm.Page.ui.setFormNotification('Se genero un error en el proceso de creación del caso.', 'ERROR', 'msg_Action');
            }
        } else {
            var error = ProcessSoapError(request.responseXML);
            Xrm.Page.ui.setFormNotification('' + error, 'ERROR', 'msg_Action');
        }
    }
    catch (e) {
        console.log('ERROR! ' + e.message);
    }    
}