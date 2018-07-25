if (typeof (AMX) == "undefined") {
    AMX = { __namespace: true };
}

AMX.IndividualForm = {
    CREATE_FORMTYPE: "1",
    UPDATE_FORMTYPE: "2",
    ConfigValue: null,
    TData: null,
    IsEmailReq: false,
    form_Customer360: (Xrm.Page.context.getUserLcid() == "3082") ? "Cliente 360" : "Customer 360",
    form_ProspectCreation: (Xrm.Page.context.getUserLcid() == "3082") ? "Creación de perspectiva" : "Prospect Creation",

    OnLoad: function () {
        var formType = Xrm.Page.ui.getFormType();
        AMX.IndividualForm.ConfigValue = AMX.COMMON.RetrieveCrmConfiguration("EmailDomain");
        AMX.IndividualForm.NavigateFormBasedOnField();
        AMX.IndividualForm.RegisterOnLoadEvents();
        AMX.IndividualForm.TranslationScope_js_ProspectCustomer();
        if (formType == AMX.IndividualForm.UPDATE_FORMTYPE) { AMX.IndividualForm.WelComeMessage(); }
        AMX.IndividualForm.SetPassportFieldValue();
    },

    OnSave: function (context) {
        AMX.IndividualForm.IsEmailReq = false;
        var formType = Xrm.Page.ui.getFormType();
        var firstName = Xrm.Page.getAttribute("firstname").getValue();
        AMX.IndividualForm.ValidateEmailRequired(formType);
        if (AMX.IndividualForm.IsEmailReq == true) {
            context.getEventArgs().preventDefault();
            return;
        }
        AMX.IndividualForm.RedirectEntityUrl(formType);
        if (formType == AMX.IndividualForm.CREATE_FORMTYPE) { AMX.IndividualForm.setChannelInteractionId(); }
    },

    ValidateEmailRequired: function (formType) {
        if (formType == 1) {
            var jsonText = Xrm.Page.getAttribute("amx_ccinfojsontext").getValue();
            if (jsonText == null || jsonText == "") {
                Alert.show(AMX.IndividualForm.TData.tValidateEmail, "", [new Alert.Button("Ok")], "INFO", 400, 150);
                AMX.IndividualForm.IsEmailReq = true;
            }
            else {
                if (jsonText.indexOf("173800000") == -1) {
                    Alert.show(AMX.IndividualForm.TData.tValidateEmail, "", [new Alert.Button("Ok")], "INFO", 400, 150);
                    AMX.IndividualForm.IsEmailReq = true;
                }
            }
        }
    },

    SetPassportFieldValue: function() {
        var ppField = Xrm.Page.getAttribute("etel_passportnumber");
        if (ppField != null) {
            if (ppField.getValue() == null) {
                AMX.COMMON.SetAttributeValue("etel_passportnumber", Xrm.Page.getAttribute("etel_iddocumentnumber").getValue());
            }
        }
    },

    setChannelInteractionId: function () {
        var digiturnoTurnoId = sessionStorage.getItem("parameter_digiturnoTurnoId");

        if (digiturnoTurnoId) {
            var field = Xrm.Page.getAttribute("amx_channelinteractionid");
            if (field != null) {
                AMX.COMMON.SetAttributeValue("amx_channelinteractionid", digiturnoTurnoId);
            }
            sessionStorage.removeItem("parameter_digiturnoTurnoId");
        }
    },

    RegisterOnLoadEvents: function () {
        Xrm.Page.getControl("emailaddress1").addOnKeyPress(AMX.IndividualForm.KeyPressFunction);
        Xrm.Page.getControl('firstname').addOnKeyPress(AMX.IndividualForm.AllowOnlyAlphabets);
        Xrm.Page.getControl('lastname').addOnKeyPress(AMX.IndividualForm.AllowOnlyAlphabets); 
    },
    
    AllowOnlyAlphabets: function (eContext) {        
        var fieldValue = eContext.getEventSource().getValue();
        var fieldName = eContext.getEventSource().getName();
        var oldValue = Xrm.Page.getAttribute(fieldName).getValue();        
        if (oldValue == fieldValue)//to allow space
        {
            fieldValue = fieldValue.replace(/[^a-z ]/gi, '');
            Xrm.Page.getAttribute(fieldName).setValue(fieldValue + " ");
        }
        else {
            fieldValue = fieldValue.replace(/[^a-z ]/gi, '');
            Xrm.Page.getAttribute(fieldName).setValue(fieldValue);
        }
    },

    TranslationScope_js_ProspectCustomer: function () {
            var formId = 'js_ProspectCustomer';
            if (AMX.IndividualForm.TData != null) {
                return;
            }
            AMX.IndividualForm.TData = GetTranslationData(formId);
    },


    KeyPressFunction: function (ext) {
        try {
            var userInput = Xrm.Page.getControl("emailaddress1").getValue();
            if (userInput.indexOf("@") <= 0) { ext.getEventSource().hideAutoComplete(); return; }
            var emailAdd1 = userInput.substring(0, userInput.indexOf("@") + 1)
            userInput = userInput.substring(userInput.indexOf("@") + 1, userInput.length);
            if (AMX.IndividualForm.ConfigValue != null) {
                var emailDomain = AMX.IndividualForm.ConfigValue.split(';');
                var emailDomains = new Array();
                for (var i = 0; i < emailDomain.length; i++) { emailDomains.push(emailDomain[i]); }

                resultSet = { results: new Array() };
                var userInputLowerCase = userInput.toLowerCase();
                for (i = 0; i < emailDomains.length; i++) {
                    if (userInputLowerCase === emailDomains[i].substring(0, userInputLowerCase.length).toLowerCase()) {
                        resultSet.results.push({
                            id: i,
                            fields: [emailAdd1 + emailDomains[i]]
                        });
                    }
                    if (resultSet.results.length >= 10) break;
                }

                if (resultSet.results.length > 0) {
                    ext.getEventSource().showAutoComplete(resultSet);
                } else {
                    ext.getEventSource().hideAutoComplete();
                }
            }
        }
        catch (e) {
            console.log(e);
        }
    },
    NavigateFormBasedOnField: function () {
        var firstName = Xrm.Page.getAttribute("firstname").getValue();
        if (firstName == null || firstName == undefined) {
            AMX.IndividualForm.NavigateForm(AMX.IndividualForm.form_ProspectCreation);
        }
        else {
            AMX.IndividualForm.NavigateForm(AMX.IndividualForm.form_Customer360);
        }
    },
    RedirectEntityUrl: function (formType) {
        if (formType != 1) {
            Xrm.Page.data.save().then(function () {
                AMX.IndividualForm.NavigateForm(AMX.IndividualForm.form_Customer360)
            }, function () { })
            //var windowOptions = {
            //    openInNewWindow: false
            //};
            //Xrm.Utility.openEntityForm("etel_subscription", null, null, windowOptions);
        }
    },
    NavigateForm: function (formName) {
        var currentForm = Xrm.Page.ui.formSelector.getCurrentItem();
        var availableForms = Xrm.Page.ui.formSelector.items.get();
        if (currentForm.getLabel().toLowerCase() != formName.toLowerCase()) {
            for (var i in availableForms) {
                var form = availableForms[i];
                if (form.getLabel().toLowerCase() == formName.toLowerCase()) {
                    form.navigate();
                    return true;
                }
            }
        }
    },
    WelComeMessage: function () {
        var param = Xrm.Page.context.getQueryStringParameters();
        if (param.parameter_showWelcomeMessage != null && param.parameter_showWelcomeMessage != 'undefined') {
            var booleanParam = param.parameter_showWelcomeMessage;
            if (booleanParam == "true") {
                var titleName = "Welcome Message";
                var customerName = Xrm.Page.getAttribute('fullname').getValue();
                var wMessage = AMX.COMMON.RetrieveKBArticleByTitle(titleName);
                if (customerName != null) {
                    wMessage = wMessage.replace("customername", " " + customerName)
                }
                else { wMessage = wMessage.replace("customername", "") }
                if (wMessage != null) { Alert.show(wMessage, "", [new Alert.Button("Ok")], "INFO", 500, 200); }
            }
        }
    },

    FirstName_OnChange: function (eContext) {
        AMX.IndividualForm.AllowOnlyAlphabets(eContext);
    },

    LastName_OnChange: function (eContext) {
        AMX.IndividualForm.AllowOnlyAlphabets(eContext);
    },
    
    EmailAddress1_OnChange: function (eContext) {
        var emailAddress1 = eContext.getEventSource().getValue();        
        emailAddress1 = emailAddress1.substring(emailAddress1.indexOf("@") + 1, emailAddress1.length);
        if (emailAddress1.indexOf(".") < 0) {
            Xrm.Page.getControl("emailaddress1").setNotification(AMX.IndividualForm.TData.tValidateEmail)
        }
        else {
            Xrm.Page.getControl("emailaddress1").clearNotification();
        }
    },

    DataProtection_OnChange: function () {
        if (Xrm.Page.getAttribute("amxperu_dataprotection").getValue() === 250000001) {
            var digiturnoTurnoId = sessionStorage.getItem("parameter_digiturnoTurnoId");
            if (digiturnoTurnoId) {
                AMX.IndividualForm.OpenFingerPrintDialog();
            }
        }
    },

    OpenFingerPrintDialog: function () {
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

        var Xrm = parent.Xrm;
        var documentId = Xrm.Page.getAttribute("etel_iddocumentnumber").getValue();
        var firstName = Xrm.Page.getAttribute("firstname").getValue();
        var lastName = Xrm.Page.getAttribute("lastname").getValue();

        if (!documentId) {
            Xrm.Utility.alertDialog("falta número de documento.");
            return;
        }
        if (!firstName) {
            Xrm.Utility.alertDialog("Falta primero nombre.");
            return;
        }
        if (!lastName) {
            Xrm.Utility.alertDialog("Falta apellido.");
            return;
        }

        var data = "action=huella&documentid=" + documentId + "&fullname=" + firstName + " " + lastName;
        var webResourceName = "amx_/OrderCapture/CertiCamara/FingerPrintDialog.html?data=" + encodeURIComponent(data);
        var width = 500;
        var height = 300;
        var title = translation_FingerprintDialog.data.tFingerPrintDialogTitle;
        var buttons = [
            new Alert.Button("Cerrar", null, true)
        ];
        var baseUrl = Xrm.Page.context.getClientUrl();
        var preventCancel = false;
        var padding = null;
        Alert.showWebResource(webResourceName, width, height, title, buttons, baseUrl, preventCancel, padding);
    },

    __namespace: true
}
