var translationScope_js_BI_CustomerAddress = {
    data: null,
    GetData: function () {
        var formId = 'js_BI_CustomerAddress';
        if (translationScope_js_BI_CustomerAddress.data != null) {
            return;
        }
        translationScope_js_BI_CustomerAddress.data = GetTranslationData(formId);
    }
};
var translationScope_js_BI_AffiliateDisaffiliate = {
    data: null,
    GetData: function () {
        var formId = 'js_BI_AffiliateDisaffiliate';
        if (translationScope_js_BI_AffiliateDisaffiliate.data != null) {
            return;
        }
        translationScope_js_BI_AffiliateDisaffiliate.data = GetTranslationData(formId);
    }
};
function OnPageLoad() {
    Xrm.Page.data.process.addOnStageSelected(stageSelectedandChangeEvent);
    Xrm.Page.data.process.addOnStageChange(stageSelectedandChangeEvent);
}
function stageSelectedandChangeEvent() {
    var stage = Xrm.Page.data.process.getSelectedStage();
    var stageName = stage.getName();
    if (stageName == "General") {
        Xrm.Page.ui.tabs.get("General").setVisible(true);
    }
    else {
        Xrm.Page.ui.tabs.get("General").setVisible(false);

    }
    if (stageName == "Document") {
        Xrm.Page.ui.tabs.get("Document_Upload").setVisible(true);
    }
    else {
        Xrm.Page.ui.tabs.get("Document_Upload").setVisible(false);

    }
}
function VisibleRuleonProcessstageChange() {
    var stage = Xrm.Page.data.process.getSelectedStage();
    var stageName = stage.getName();
    if (stageName == "General") {
        Xrm.Page.ui.tabs.get("General").setVisible(true);
    }
    else {
        Xrm.Page.ui.tabs.get("General").setVisible(false);

    }
    if (stageName == "Document") {
        Xrm.Page.ui.tabs.get("Document_Upload").setVisible(true);
    }
    else {
        Xrm.Page.ui.tabs.get("Document_Upload").setVisible(false);

    }
}
function GetBIBlacklistOnLoad() {
    if (Xrm.Page.ui.getFormType() == 1) {
        Xrm.Page.getAttribute("amxperu_name").setValue("Affiliate/Disaffiliate to Services Black List");
        Xrm.Page.data.entity.save();
    }
}
function affiliateDisaffiliateBlacklistAction(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName) {
    var headercheck = false;
    translationScope_js_BI_AffiliateDisaffiliate.GetData();
    translationScope_js_BI_CustomerAddress.GetData();
    headercheck = headerCheck(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName);
    debugger;
    if (headercheck) {
        var accountsummaryController = Xrm.Page.ui.controls.get("WebResource_accountsummarytabbedview");
        if (accountsummaryController != null && accountsummaryController.getObject() != null && accountsummaryController.getObject().contentWindow != null && accountsummaryController.getObject().contentWindow.angular.element(".main-container").scope() != null)
        {
            var selectedSubscription = accountsummaryController.getObject().contentWindow.angular.element(".main-container").scope().SubscriptionScopeSelectedItems;
            if (selectedSubscription != null && selectedSubscription.length == 1) {
                var selectedRecord = selectedSubscription[0][0].RowData.SubscriptionId;
                  var MSISDNGuid = GetMSISDNGuid();
                    var isMSISDN = GetMSISDNBasedRecords(selectedRecord, MSISDNGuid);
                    if (isMSISDN == 1) {
                        var cols = ["amxperu_promotions", "amxperu_surveys", "amxperu_clarovasservices", "amxperu_externalvasservices", "etel_externalid", "etel_individualcustomerid", "etel_corporatecustomerid", "etel_name", "etel_msisdnserialno"];
                        var retrievedSubscription = XrmServiceToolkit.Soap.Retrieve("etel_subscription", selectedRecord, cols);
                        var parameters = {};
                        if (retrievedSubscription != null) {
                            parameters["amxperu_subscription"] = selectedRecord;
                            parameters["amxperu_subscriptionname"] = retrievedSubscription.etel_name;
                            var currentEntity = Xrm.Page.data.entity;
                            if (currentEntity.getEntityName() == "contact") {
                                parameters["amxperu_customerindividualname"] = Xrm.Page.getAttribute("fullname").getValue();
                                parameters["amxperu_customerindividual"] = currentEntity.getId();
                            }
                            else if (currentEntity.getEntityName() == "account") {
                                parameters["amxperu_customercorporatename"] = Xrm.Page.getAttribute("name").getValue();
                                parameters["amxperu_customercorporate"] = currentEntity.getId();
                            }

                            if (retrievedSubscription.attributes['amxperu_promotions'] != null && retrievedSubscription.attributes['amxperu_promotions'].value) {
                                parameters["amxperu_currentpromotionsstatus"] = retrievedSubscription.attributes['amxperu_promotions'].value;
                            }
                            if (retrievedSubscription.attributes['amxperu_surveys'] != null && retrievedSubscription.attributes['amxperu_surveys'].value) {
                                parameters["amxperu_currentsurveysstatus"] = retrievedSubscription.attributes['amxperu_surveys'].value;
                            }
                            if (retrievedSubscription.attributes['amxperu_clarovasservices'] != null && retrievedSubscription.attributes['amxperu_clarovasservices'].value) {
                                parameters["amxperu_currentclarovasstatus"] = retrievedSubscription.attributes['amxperu_clarovasservices'].value;
                            }
                            if (retrievedSubscription.attributes['amxperu_externalvasservices'] != null && retrievedSubscription.attributes['amxperu_externalvasservices'].value) {
                                parameters["amxperu_currentexternalvasstatus"] = retrievedSubscription.attributes['amxperu_externalvasservices'].value;
                            }
                        }
                        var windowOptions = {
                            openInNewWindow: false
                        };
                        Xrm.Utility.openEntityForm("amxperu_biaffiliatedisaffiliateblacklist", null, parameters, windowOptions);
                    }
                    else {
                        alert(translationScope_js_BI_AffiliateDisaffiliate.data.tMSISDNnotFound);
                    }                
            }
            else {
                alert(translationScope_js_BI_AffiliateDisaffiliate.data.tSelectSubscription, translationScope_js_BI_CustomerAddress.data.tWarning, translationScope_js_BI_CustomerAddress.data.tFormNotification);
            }
        }
    }
}
function submitAction() {
    translationScope_js_BI_CustomerAddress.GetData();    
    var success = BlacklistServiceUpdate();
    if (success == 1) {
        Xrm.Page.getAttribute("amxperu_submit").setValue(true);
        Xrm.Page.data.save().then(function () {
            alert(translationScope_js_BI_CustomerAddress.data.tSubmittedSuccessfullyMessage);
            Xrm.Page.ui.close();
        }, function () { });
    }
    else {
        alert(translationScope_js_BI_AffiliateDisaffiliate.data.tErrorInEOC);
    }
}
function subscriptionFormAffiliateDisaffiliateBlackListAction(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName) {
    var customerId;
    translationScope_js_BI_AffiliateDisaffiliate.GetData();
    var individual = Xrm.Page.getAttribute("etel_individualcustomerid");
    var isIndividual = false;
    var customerType = '';
    if ((individual !== null) && (individual.getValue() !== null)) {
        var individualval = individual.getValue();
        customerId = individualval[0].id;
        customerType = 'contact';
        isIndividual = true;
    }
    else {
        var corporate = Xrm.Page.getAttribute("etel_corporatecustomerid");
        if ((corporate !== null) && (corporate.getValue() !== null)) {
            var corporateval = corporate.getValue();
            customerId = corporateval[0].id;
            customerType = 'account';
        }
    }

    var headercheck = false;
    headercheck = headerCheck(entitytypecode, customerId, "", customerType);
    if (headercheck) {
        var MSISDNGuid = GetMSISDNGuid();
        var isMSISDN = GetMSISDNBasedRecords(selectedEntityId, MSISDNGuid);
        if (isMSISDN == 1) {
            var cols = ["amxperu_promotions", "amxperu_surveys", "amxperu_clarovasservices", "amxperu_externalvasservices", "etel_externalid", "etel_individualcustomerid", "etel_corporatecustomerid", "etel_name", "etel_msisdnserialno"];
            var retrievedSubscription = XrmServiceToolkit.Soap.Retrieve(selectedEntityName, selectedEntityId, cols);
            var parameters = {};
            if (retrievedSubscription != null) {
                var msisdn = retrievedSubscription.etel_msisdnserialno;
                if (msisdn === null) {
                    alert("No MSISDN number present for this record.");
                    return false;
                    //  msisdn = "--";
                    //         extraqs += "&etel_subscriptionmsisdn=" + msisdn;
                }
                parameters["amxperu_subscription"] = selectedEntityId;
                parameters["amxperu_subscriptionname"] = retrievedSubscription.etel_name;
                if (Xrm.Page.getAttribute("etel_individualcustomerid").getValue() && Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0]) {
                    parameters["amxperu_customerindividualname"] = Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].name;
                    parameters["amxperu_customerindividual"] = Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].id;
                }
                if (Xrm.Page.getAttribute("etel_corporatecustomerid").getValue() && Xrm.Page.getAttribute("etel_corporatecustomerid").getValue()[0]) {
                    parameters["amxperu_customercorporatename"] = Xrm.Page.getAttribute("etel_corporatecustomerid").getValue()[0].name;
                    parameters["amxperu_customercorporatename"] = Xrm.Page.getAttribute("etel_corporatecustomerid").getValue()[0].id;
                }
                if (retrievedSubscription.attributes['amxperu_promotions'] != null && retrievedSubscription.attributes['amxperu_promotions'].value) {
                    parameters["amxperu_currentpromotionsstatus"] = retrievedSubscription.attributes['amxperu_promotions'].value;
                }
                if (retrievedSubscription.attributes['amxperu_surveys'] != null && retrievedSubscription.attributes['amxperu_surveys'].value) {
                    parameters["amxperu_currentsurveysstatus"] = retrievedSubscription.attributes['amxperu_surveys'].value;
                }
                if (retrievedSubscription.attributes['amxperu_clarovasservices'] != null && retrievedSubscription.attributes['amxperu_clarovasservices'].value) {
                    parameters["amxperu_currentclarovasstatus"] = retrievedSubscription.attributes['amxperu_clarovasservices'].value;
                }
                if (retrievedSubscription.attributes['amxperu_externalvasservices'] != null && retrievedSubscription.attributes['amxperu_externalvasservices'].value) {
                    parameters["amxperu_currentexternalvasstatus"] = retrievedSubscription.attributes['amxperu_externalvasservices'].value;
                }
            }
            var windowOptions = {
                openInNewWindow: false
            };
            Xrm.Utility.openEntityForm("amxperu_biaffiliatedisaffiliateblacklist", null, parameters, windowOptions);
        }
        else {
            alert(translationScope_js_BI_AffiliateDisaffiliate.data.tMSISDNnotFound);
        }
    }
}
function ServiceCall(request, WorkflowUrlName) {
    var status;
    $.ajax({
        type: "POST",
        url: WorkflowUrlName,
        dataType: "json",
        data: JSON.stringify(request),
        contentType: "application/json; charset=utf-8",
        async: false,
        cache: false,
        xhrFields:
        {
            withCredentials: true
        },
        crossDomain: true,
        success: function (data) {
            if (data) {
                status = data.Output.SubscriptionResponse.successflag;
                //alert(status);
            }
        },
        error: function (data) {

        }
    });
    return status;
}
function BlacklistServiceUpdate() {
    var status = 0;
    translationScope_js_BI_AffiliateDisaffiliate.GetData();
    var WorkflowUrlName = Util.configStore.PsbRestServiceUrl + "AmxPeruAffiliateDisaffiliateBlacklist";
    //TO DO
    var request = {
        "BlacklistRequest":
        {
            "$type": "AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AffiliateDisaffilateBlacklistRequest, AmxPeruPSBActivities",
        }
    };

    if (Xrm.Page.getAttribute("amxperu_customerindividual") != null) {
        var IndividualGuid = Xrm.Page.getAttribute("amxperu_customerindividual").getValue()[0].id;
        var CustExternalID = RetreieveFieldFromGuid("contact", "contactid", "etel_externalid", IndividualGuid);
        if (CustExternalID != null) {
            request.BlacklistRequest.CustomerExternalId = CustExternalID;
            if (Xrm.Page.getAttribute("amxperu_subscription") != null) {
                var SubscriptionGuid = Xrm.Page.getAttribute("amxperu_subscription").getValue()[0].id;
                var ExternalID = RetreieveFieldFromGuid("etel_subscription", "etel_subscriptionid", "etel_externalid", SubscriptionGuid);
                if (ExternalID != null) {
                    request.BlacklistRequest.ContractID = ExternalID;
                    if (Xrm.Page.getAttribute("amxperu_promotionsstatus").getValue() != null) {
                        if (Xrm.Page.getAttribute("amxperu_promotionsstatus").getValue() == 250000001) {
                            request.BlacklistRequest.PromotionsBlackList = "true";
                        }
                       else if (Xrm.Page.getAttribute("amxperu_promotionsstatus").getValue() == 250000000) {
                            request.BlacklistRequest.PromotionsBlackList = "false";
                        }
                    }
                    if (Xrm.Page.getAttribute("amxperu_surveysstatus").getValue() != null) {
                        if (Xrm.Page.getAttribute("amxperu_surveysstatus").getValue() == 250000001) {
                            request.BlacklistRequest.SurveysBlackList = "true";
                        }
                        else if (Xrm.Page.getAttribute("amxperu_surveysstatus").getValue() == 250000000) {
                            request.BlacklistRequest.SurveysBlackList = "false";
                        }
                    }
                    if (Xrm.Page.getAttribute("amxperu_clarovasstatus").getValue() != null) {
                        if (Xrm.Page.getAttribute("amxperu_clarovasstatus").getValue() == 250000001) {
                            request.BlacklistRequest.ClaroVASBlackList = "true";
                        }
                        else if (Xrm.Page.getAttribute("amxperu_clarovasstatus").getValue() == 250000000) {
                            request.BlacklistRequest.ClaroVASBlackList = "false";
                        }
                    }
                    if (Xrm.Page.getAttribute("amxperu_externalvasstatus").getValue() != null) {
                        if (Xrm.Page.getAttribute("amxperu_externalvasstatus").getValue() == 250000001) {
                            request.BlacklistRequest.ExternalVASBlackList = "true";
                        }
                        else if (Xrm.Page.getAttribute("amxperu_externalvasstatus").getValue() == 250000000) {
                            request.BlacklistRequest.ExternalVASBlackList = "false";
                        }
                    }
                    status = ServiceCall(request, WorkflowUrlName);
                }
                else {
                    //Subscription ExternalID not present
                    alert(translationScope_js_BI_AffiliateDisaffiliate.data.tSubscriptionIDNotFound);
                }
            }
        }
        else {
            //Customer ExternalID not present
            alert(translationScope_js_BI_AffiliateDisaffiliate.data.tCustomerIDNotFound);
        }
    }
    return status;
}
function RetreieveFieldFromGuid(entityName, entityGuidfield, fieldname, GuidValue) {
    var fetchQuery = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
        + "<entity name='" + entityName+"'>"
        + "<attribute name='" + entityGuidfield+"'/>"
        + "<attribute name='" + fieldname+"'/>"
        + "<filter type='and'>"
        + "<condition attribute='" + entityGuidfield+"' value='" + GuidValue + "' operator='eq'/>"
        + "</filter>"
        + "</entity>"
        + "</fetch>";
    var configRecord = XrmServiceToolkit.Soap.Fetch(fetchQuery);
    if (configRecord.length > 0) {
        if (configRecord[0].attributes[fieldname] != null) {
             return configRecord[0].attributes[fieldname].value;
            }
    }
    return null;
}
function EnableBlacklistCustomer() {
    var custStatus = Xrm.Page.getAttribute("statuscode").getValue();
    if (custStatus == 1) {
        return true;
    }
    else {
        return false;
    }
}
function EnableBlacklistSubscription() {
    if (Xrm.Page.getAttribute("etel_individualcustomerid") != null) {
        var IndividualGuid = Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].id;
        var CustStatus = RetreieveFieldFromGuid("contact", "contactid", "statuscode", IndividualGuid);
        if (CustStatus == 1) {
            return true;
        }
        else {
            return false;
        }
    }
}
function GetMSISDNGuid() {
    var fetchQuery = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
        + "<entity name='etel_productresourcespecification'>"
        + "<attribute name='etel_productresourcespecificationid'/>"
        + "<filter type='and'>"
        + "<condition attribute='etel_name' value='MSISDN' operator='eq'/>"
        + "</filter>"
        + "</entity>"
        + "</fetch>";
    var MSISDNRecord = XrmServiceToolkit.Soap.Fetch(fetchQuery);
    if (MSISDNRecord.length > 0) {
        if (MSISDNRecord[0].attributes["etel_productresourcespecificationid"] != null) {
            return MSISDNRecord[0].attributes["etel_productresourcespecificationid"].value;
        }
    }
    return null;
}
function GetMSISDNBasedRecords(subscriptionId, MSISDNId) {
    var haveMSISDNrecords = 0;
    var fetchQuery = "<fetch distinct='true' mapping='logical' output-format='xml-platform' version='1.0'>"
        + "<entity name='etel_subscription'>"
        + "<attribute name='etel_subscriptionid'/>"
        + "<attribute name='etel_name'/>"
        + "<filter type='and'>"
        + "<condition attribute='etel_subscriptionid' value='" + subscriptionId + "' operator='eq'/>"
        + "</filter>"
        + "<link-entity name='etel_productresource' alias='af' to='etel_subscriptionid' from='etel_subscriptionid'>"
        + "<filter type='and'>"
        + "<condition attribute='etel_resourcespecificationid' value='" + MSISDNId + "' operator='eq'/>"
        + "</filter>"
        + "</link-entity>"
        + "</entity>"
        + "</fetch>";
    var MSISDNRecords = XrmServiceToolkit.Soap.Fetch(fetchQuery);
    if (MSISDNRecords.length > 0) {
        haveMSISDNrecords = 1;
        return haveMSISDNrecords;
    }
    return haveMSISDNrecords;
}