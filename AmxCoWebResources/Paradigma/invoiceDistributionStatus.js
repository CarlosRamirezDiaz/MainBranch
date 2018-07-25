/// <reference path="../../amxperuwebresources/amxcolombia/common/amx_common.js" />

if (typeof (AMX) == "undefined") {
    AMX = { __namespace: true };
}
AMX.InvoiceDistributionForm = {
    CREATE_FORMTYPE: "1",
    UPDATE_FORMTYPE: "2",

    onInvoiceDistributionButtonClick: function () {
        var titleName = "Invoice Distribution";
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

                            AMX.COMMON.RetrieveCrmConfigurationWebApi("UrlStartDigiturno", function (digiturnoURL) {
                                urlDigiturno = digiturnoURL;
                            },
                                function (error) {
                                    urlDigiturno = "";
                                    parent.Xrm.Utility.alertDialog(error);
                                }, false);

                            AMX.COMMON.CallPSBWorflow("POST", urlDigiturno, DigiturnoRequest, function (data) {

                                //Xrm.Utility.alertDialog("Success");
                            }, function (data) {
                                //Xrm.Utility.alertDialog("Failed");
                            }, false);
                        }
                        AMX.InvoiceDistributionForm.openInvoiceDistributionForm();
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

    openInvoiceDistributionForm: function () {
        var options = { openInNewWindow: true };
        var contactId = Xrm.Page.data.entity.getId().replace("{", "").replace("}", "");
        var fullName = Xrm.Page.getAttribute("fullname").getValue();
        var parameters = {};
        parameters["amx_customerid"] = contactId;
        parameters["amx_customeridname"] = fullName;
        parameters["amx_customeridtype"] = "contact";
        Xrm.Utility.openEntityForm("amx_biforinvoicedistributionstatus", null, parameters, options);
    },

    onLoadInvoiceDistributionForm: function () {

        debugger;
        var request = {
            "individualId": "{099B11B1-A5C0-E711-80E5-FA163E10DFBE}",
            "userId": Xrm.Page.context.getUserId()
        };

        AMX.COMMON.CallPSBWorflow("POST", "ParadigmaGetIFrameUrl", request, AMX.InvoiceDistributionForm.paradigmaGetIFrameUrl_CallBack, null, false);
    },

    paradigmaGetIFrameUrl_CallBack(data)
    {
        debugger;
        if (data && data.Output && data.Output.response)
        {
            if (data.Output.response.Success)
            {
                Xrm.Page.getControl("IFRAME_paradigma").setSrc(data.Output.response.Value)
            }
            else
            {
                alert("paradigmaGetIFrameUrl error: " + data.Output.response.ErrorMessage);
            }
        }
        else
        {
            alert("error calling paradigmaGetIFrameUrl");
        }
    },

    __namespace: true
}