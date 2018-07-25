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
function GetDataProtectionOnLoad() {
    if (Xrm.Page.ui.getFormType() == 1) {
        Xrm.Page.getAttribute("amxperu_name").setValue("Data Protection");
        Xrm.Page.data.entity.save();
    }
}
function affiliateDisaffiliatetoDataProtectionAction(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName) {
  var headercheck = false;
    headercheck = headerCheck(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName);

    if (headercheck) {
        var entityVal = Xrm.Page.data.entity;
        var cols = ["amxperu_dataprotection"];
        var retrievedCustomer = XrmServiceToolkit.Soap.Retrieve(entityVal.getEntityName(), entityVal.getId(), cols);
        var parameters = {};
        if (entityVal.getEntityName() == "contact") {
            parameters["amxperu_customerindividualname"] = Xrm.Page.getAttribute("fullname").getValue();
            parameters["amxperu_customerindividual"] = entityVal.getId();
        }
        else if (entityVal.getEntityName() == "account") {
            parameters["amxperu_customercorporatename"] = Xrm.Page.getAttribute("name").getValue();
            parameters["amxperu_customercorporate"] = entityVal.getId();
        }
        if (retrievedCustomer != null && retrievedCustomer.attributes['amxperu_dataprotection'] != null && retrievedCustomer.attributes['amxperu_dataprotection'].value) {
            parameters["amxperu_currentdpstatus"] = retrievedCustomer.attributes['amxperu_dataprotection'].value;
        }
        var windowOptions = {
            openInNewWindow: false
        };
        Xrm.Utility.openEntityForm("amxperu_biaffiliateordisaffiliatetodataprotecti", null, parameters, windowOptions);
 }

}
function submitAction() {
   translationScope_js_BI_CustomerAddress.GetData();
    var success = DataProtectionUpdate();
    if (success == 1) {
        Xrm.Page.getAttribute("amxperu_submit").setValue(true);
        //Xrm.Page.data.entity.save();
        Xrm.Page.data.save().then(function () {
            alert(translationScope_js_BI_CustomerAddress.data.tSubmittedSuccessfullyMessage);
            Xrm.Page.ui.close();
        }, function () { });
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
                status = data.Output.DataProtectionResponse.successFlag;
                //alert(status);
            }
        },
        error: function (data) {

        }
    });
    return status;
}
function DataProtectionUpdate() {
    var statusResult = 0;
    var WorkflowUrlName = Util.configStore.PsbRestServiceUrl + "AmxPeruAffiliateDisaffiliateDataProtection";
    //TO DO
    var request = {
        "DataProtectionRequest":
        {
            "$type": "AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruDataProtectionRequest, AmxPeruPSBActivities",
        }
    };
    if (Xrm.Page.getAttribute("amxperu_newdpstatus").getValue() != null) {
        request.DataProtectionRequest.DataProtectionValue = Xrm.Page.getAttribute("amxperu_newdpstatus").getValue();
        if (Xrm.Page.getAttribute("amxperu_customerindividual") != null) {
            var IndividualGuid = Xrm.Page.getAttribute("amxperu_customerindividual").getValue()[0].id;
            request.DataProtectionRequest.CustomerID = IndividualGuid;
        }
        statusResult = ServiceCall(request, WorkflowUrlName);
    }
    return statusResult;
}