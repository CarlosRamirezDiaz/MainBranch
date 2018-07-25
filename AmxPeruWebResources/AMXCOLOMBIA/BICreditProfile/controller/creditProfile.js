
if (typeof (AMX) == "undefined") {
    AMX = { __namespace: true };
}

AMX.CREDITPROFILE = {

    CREDITPROFILEREQUEST: "",
    PSBCREDITPROFILEURL: "",

    OnLoadCreditProfile: function () {
        AMX.CREDITPROFILE.SetUrls();
        AMX.CREDITPROFILE.ShowOrHideGrids();
    },

    SetUrls: function () {
        var url1 = Xrm.Page.context.getClientUrl() + "/WebResources/amx_/BICreditProfile/template/CreditProfile.htm";
        var url2 = Xrm.Page.context.getClientUrl() + "/WebResources/amx_/BICreditProfile/template/InvoiceGrid.htm";
        var url3 = Xrm.Page.context.getClientUrl() + "/WebResources/amx_/BICreditProfile/template/ContractGrid.htm";

        Xrm.Page.getControl("IFRAME_ReportResult").setSrc(url1);
        Xrm.Page.getControl("IFRAME_InvoiceGrid").setSrc(url2);
        Xrm.Page.getControl("IFRAME_ContractGrid").setSrc(url3);
    },

    ShowOrHideGrids: function () {
        Xrm.Page.ui.tabs.get("InvoiceRecords").setVisible(false);
        Xrm.Page.ui.tabs.get("ContractRecords").setVisible(false);
    },

    OnValidateShippingChange: function () {
        if (Xrm.Page.getAttribute("amx_validateshipping").getValue() == 1) {
            Xrm.Page.ui.tabs.get("InvoiceRecords").setVisible(true);
        }
        else {
            Xrm.Page.ui.tabs.get("InvoiceRecords").setVisible(false);
        }
    },

    OnValidateContractChange: function () {
        if (Xrm.Page.getAttribute("amx_validatecontract").getValue() == 1) {
            Xrm.Page.ui.tabs.get("ContractRecords").setVisible(true);
        }
        else {
            Xrm.Page.ui.tabs.get("ContractRecords").setVisible(false);
        }
    },

    onCreditProfileButtonClick: function () {
        var titleName = "Credit Profile";
        var webApiSelectFilters = "kbarticles?$filter=title eq '" + titleName + "'";
        AMX.COMMON.GetKbArticle(webApiSelectFilters, function (message) {
            if (message != null && message != "") {
                Alert.show(message, "", [new Alert.Button("Acepto",
                    function () {
                        //var digiturnoRecord = GetEntityRecords("etel_bi_header", null, "etel_channelinteractionid", "etel_individualcustomerid/Id eq guid'" + Xrm.Page.data.entity.getId() + "' and etel_headerstatus eq true", false, null, null, null);
                        var digiturnoId = "";

                        //if (digiturnoRecord != null && digiturnoRecord != undefined) {
                        //    if (digiturnoRecord.length > 0) {
                        //        digiturnoId = digiturnoRecord[0].etel_channelinteractionid;
                        //    }
                        //}

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

                            AMX.COMMON.RetrieveCrmConfigurationWebApi("PsbRestServiceUrl", function (digiturnoURL) {
                                urlDigiturno = digiturnoURL;
                            },
                                function (error) {
                                    urlDigiturno = "";
                                    parent.Xrm.Utility.alertDialog(error);
                                }, false);

                            AMX.COMMON.CallPSBWorflow("POST", urlDigiturno + "AmxCoDigiturnoNotifyEventTurn", DigiturnoRequest, function (data) {

                                //Xrm.Utility.alertDialog("Success");
                            }, function (data) {
                                //Xrm.Utility.alertDialog("Failed");
                            }, false);
                        }
                        AMX.CREDITPROFILE.openCreditProfileForm();
                    }, false, false), new Alert.Button("No acepto", function () {
                        var entityId = Xrm.Page.data.entity.getId();
                        var entityName = Xrm.Page.data.entity.getEntityName();
                        var res = LaunchActionNoParams(entityId, entityName, "amx_ACIndividualCustomerChangeFieldIsChangeStratum");

                        if (res.status == 200) {
                            Xrm.Utility.openEntityForm(Xrm.Page.data.entity.getEntityName(), Xrm.Page.data.entity.getId());
                        }
                    }, true, true)], "INFO", 800, 350);
            }
        },
            function (errorData) {
                parent.Xrm.Utility.alertDialog(errorData);
            }, false);

    },

    openCreditProfileForm: function () {
        var options = { openInNewWindow: true };
        var contactId = Xrm.Page.data.entity.getId().replace("{", "").replace("}", "");
        var fullName = Xrm.Page.getAttribute("fullname").getValue();
        var parameters = {};
        parameters["amx_customer"] = contactId;
        parameters["amx_customername"] = fullName;
        parameters["amx_customertype"] = "contact";
        parameters["amx_documentid"] = parent.Xrm.Page.getAttribute("etel_iddocumentnumber").getValue();
        parameters["amx_name"] = "BI Credit Profile by " + parent.Xrm.Page.getAttribute("fullname").getValue();
        Xrm.Utility.openEntityForm("amx_bicreditprofile", null, parameters, options);
    },

    WordDocumentValueRule: function () {
        if (Xrm.Page.ui.getFormType() == 2) {
            var creditProfileResult = Xrm.Page.getAttribute("amx_creditprofilereportresult").getValue();
            var channel = Xrm.Page.getAttribute("amx_channel").getValue();
            if (creditProfileResult && channel == 0) {
                return true;
            }
        }
        return false;
    },

    callBICreditProfile: function () {

        var documentId = Xrm.Page.getAttribute("amx_documentid").getValue();
        var urlPSBWorkflow = null;
        AMX.COMMON.RetrieveCrmConfigurationWebApi("PsbRestServiceUrl", function (psbURL) {
            urlPSBWorkflow = psbURL;
        },
            function (error) {
                urlPSBWorkflow = "";
                parent.Xrm.Utility.alertDialog(error);
            }, false);

        workflowInput = {
            "BICreditProfileRequest":
            {
                "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.BICreditProfile.BICreditProfileRequest, AmxPeruPSBActivities",
                "getOperation": "cun",
                "message": "{\"documentType\":\"CC\",\"documentId\":\"" + documentId + "\", \"business\":\"FIJA\"}"
            }
        };

        AMX.COMMON.CallPSBWorflow("POST", urlPSBWorkflow + "BICreditProfile", workflowInput, function (data) {
            if (data.Output.BICreditProfileResponse != null && data.Output.BICreditProfileResponse != undefined && data.Output.BICreditProfileResponse != "") {
                if (data.Output.BICreditProfileResponse.isValid)
                    Xrm.Page.getAttribute("amx_creditprofilereportresult").setValue(true);
                else
                    Xrm.Utility.alertDialog(data.Output.BICreditProfileResponse.Error);
            }
        }, function (error) {
            parent.Xrm.Utility.alertDialog(error.responseText);
        }, false);
    },

    __namespace: true
}