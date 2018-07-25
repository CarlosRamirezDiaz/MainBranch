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
translation_FingerprintDialog.GetData();


var fingerprintdialog = {

    action: "huella",
    waitForResponseFromHClient_timeout: 8000,
    waitForResponseFromHClient_countdown: 120,

    load_Token_Callback: function (data) {
        if (data.Output.response.Success) {
            var token = data.Output.response.Value;

            var workflowUrlName = "https://hclient.certicamara.com.co:9669/huellasManager/huella";

            if (fingerprintdialog.action && fingerprintdialog.action == "minucia")
                workflowUrlName += "/minucia";

            var request = {
                "token": token
            }

            fingerprintdialog.showProgress(translation_FingerprintDialog.data.tLaunchHClient);
            fingerprintdialog.ServiceCall(request, workflowUrlName, fingerprintdialog.HclientRequest_Callback, false, null, 15000);

            return;
        }
        else {
            fingerprintdialog.showErrorMessage(data.Output.response.Error);
        }
    },

    HclientRequest_Callback: function (data) {
        var hClientResult = null;
        if (data.CaptureFingerPrintRNECResult) {
            hClientResult = data.CaptureFingerPrintRNECResult;
        }
        else if (data.CaptureFingerPrintMinutiaeResult) {
            hClientResult = data.CaptureFingerPrintMinutiaeResult;
        }
        else {
            fingerprintdialog.showErrorMessage(translation_FingerprintDialog.data.tUndefiniedErrorLaunchingHClient);
            return;
        }


        if (hClientResult.Message.Code == "1000231") {
            // "1000231 - Se encuentra un proceso finalizado pero no ha obtenido la respuesta".
            // The device is waiting for a "huellasManager/respuesta" request.
            // Execute "huellasManager/respuesta" end try again.
            var WorkflowUrlName = "https://hclient.certicamara.com.co:9669/huellasManager/respuesta";
            var request = {}

            fingerprintdialog.showProgress(translation_FingerprintDialog.data.tRetrying);

            fingerprintdialog.ServiceCall(request, WorkflowUrlName, fingerprintdialog.retryLaunchHClient, null, "GET", 5000);
            return;
        }

        if (hClientResult.Message.Code == "1000232") {
            // HClient iniciated
            //"El proceso inicio de manera satisfactoria"
            fingerprintdialog.showProgress(hClientResult.Message.Description);

            //$('#btnRequestReponse').show();
            fingerprintdialog.waitForResponseFromHClient();

            return;
        }

        fingerprintdialog.showErrorMessage(hClientResult.Message.Description);

        return;
    },

    waitForResponseFromHClient: function () {
        if (fingerprintdialog.waitForResponseFromHClient_countdown < 0)
        {
            fingerprintdialog.showProgress(translation_FingerprintDialog.data.tPressButtonGetResponseFromHClient);
            $('#btnRequestReponse').val(translation_FingerprintDialog.data.tRetrieveResponseFromHClient);
            $('#btnRequestReponse').show();
            return;
        }
        fingerprintdialog.showProgress(translation_FingerprintDialog.data.tWaitingResponseFromHClient);

        setTimeout(function () {
            fingerprintdialog.showCountdown(fingerprintdialog.waitForResponseFromHClient_countdown);
            fingerprintdialog.waitForResponseFromHClient_countdown--;

            fingerprintdialog.requestResponseFromHClient();
        },
        fingerprintdialog.waitForResponseFromHClient_timeout);

        fingerprintdialog.waitForResponseFromHClient_timeout = 1000;
    },

    retryLaunchHClient: function (data) {
        if (data != undefined && data != null)
            fingerprintdialog.load_Token();
    },

    ServiceCall: function (request, WorkflowUrlName, success_callback, withCredentials, type, timeout) {
        if (withCredentials == undefined)
            withCredentials = true;

        if (type == undefined || type == null)
            type = "POST";

        if (timeout == undefined)
            timeout = 15000;

        $.ajax({
            type: type,
            url: WorkflowUrlName,
            dataType: "json",
            data: JSON.stringify(request),
            contentType: "application/json",
            async: true,
            timeout: timeout,
            //cache: false,
            xhrFields:
            {
                withCredentials: withCredentials
            },
            crossDomain: false,
            success: function (data) {
                if (data && success_callback != undefined) {
                    success_callback(data);
                }
            },
            error: function (data) {
                var errorMessage = "";
                if (data.status != undefined && data.status != null)
                    errorMessage += data.status;

                if (data.statusText != undefined && data.statusText != null)
                    errorMessage += ("-" + data.statusText + "\n");

                if (data.responseText != undefined && data.responseText != null)
                    errorMessage += data.responseText;

                alert(errorMessage);
            }
        });
    },

    showProgress: function (message) {
        var progressMessage = document.getElementById("progressMessage");
        progressMessage.innerHTML = message;
    },

    showErrorMessage: function (message) {
        var error = document.getElementById("error");
        error.innerHTML = message;
    },

    showCountdown: function (message) {
        var wait = document.getElementById("wait");
        if (message)
            wait.innerHTML = "(" + message + ")";
        else
            wait.innerHTML = "";
    },

    load_Token: function () {
        var dataParameter = location.search.split('?data=')[1];
        var parameters = fingerprintdialog.parseDataParameter(dataParameter);

        fingerprintdialog.action = parameters.action;

        var WorkflowUrlName = parent.Xrm.Page.context.getClientUrlForInteractioncentricDashboard() + ":6004/api/v1/workflow/AmxGetHClientJsonWebToken";
        var request = {
            "documentId": parameters.documentid,
            "fullName": parameters.fullname
        }

        fingerprintdialog.showProgress(translation_FingerprintDialog.data.tGeneratingToken);
        fingerprintdialog.ServiceCall(request, WorkflowUrlName, fingerprintdialog.load_Token_Callback);
    },

    parseDataParameter: function (parameters) {
        var result = {};

        if (!parameters)
            return result;

        parameters = decodeURIComponent(parameters);

        var queryparts = parameters.split("&");
        for (var i = 0; i < queryparts.length; i++) {
            var params = queryparts[i].split("=");
            result[params[0].toLowerCase()] = params.length > 1 ? params[1] : null;
        }
        return result;
    },

    requestResponseFromHClient: function () {
        var WorkflowUrlName = "https://hclient.certicamara.com.co:9669/huellasManager/respuesta";
        var request = {}

        fingerprintdialog.ServiceCall(request, WorkflowUrlName, fingerprintdialog.requestResponseFromHClient_Callback, null, "GET");
    },

    requestResponseFromHClient_Callback: function (data) {
        if (data == undefined || data == null) {            
            fingerprintdialog.showErrorMessage(translation_FingerprintDialog.data.tUndefiniedErrorRetrieving);

            return;
        }

        try
        {
            var response = fingerprintdialog.base64_decode(data);
            if (response && response.json && !response.json.startsWith("{"))
            {
                if (response.json == "No existe respuesta, se encuentra un proceso iniciado") {
                    fingerprintdialog.waitForResponseFromHClient();
                    return;
                }
            }

        }
        catch (e){
        }

        var WorkflowUrlName = parent.Xrm.Page.context.getClientUrlForInteractioncentricDashboard() + ":6004/api/v1/workflow/AmxValidateHClientResponse";

        var request = {
            "token": data
        }

        fingerprintdialog.ServiceCall(request, WorkflowUrlName, fingerprintdialog.validateResponse_Callback);
    },

    validateResponse_Callback: function (data) {
        if (data.Output.response.Success) {
            if (data.Output.response.Value == "No existe respuesta, se encuentra un proceso iniciado") {
                fingerprintdialog.waitForResponseFromHClient();
                return;
            }
            fingerprintdialog.showProgress(data.Output.response.Value);
            fingerprintdialog.showCountdown(null);
        }
        else {
            fingerprintdialog.showCountdown(null);
            fingerprintdialog.showErrorMessage(data.Output.response.ErrorMessage);
        }
    },

    base64_decode: function (token) {
        //this is used to parse base64
        token = token.replace(/-/g, '+').replace(/_/g, '/');
        switch (token.length % 4) {
            case 0:
                break;
            case 2:
                token += '==';
                break;
            case 3:
                token += '=';
                break;
            default:
                throw 'Illegal base64url string!';
        }

        var base64Url = token.split('.')[1];
        var base64 = base64Url.replace('-', '+').replace('_', '/');
        return JSON.parse(window.atob(base64));
    }
}