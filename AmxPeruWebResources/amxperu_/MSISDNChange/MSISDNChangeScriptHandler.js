function onLoad() {
    loadProcess();
}

function loadProcess() {
    //translationScope.GetData(FORM_ID);
    var customerParameter = "";
    if (Xrm.Page.getAttribute("etel_name").getValue() !== null) {
        customerParameter = "&MSISDNChangeId=" + Xrm.Page.getAttribute("etel_name").getValue();
    }

    if (Xrm.Page.getAttribute("etel_productresourceid").getValue() != null) {
        ResourceID = Xrm.Page.getAttribute("etel_productresourceid").getValue();
    }
    
    //window.definitions.psbWorkflowStartInput = {
    //    "MSISDNChangeId": Xrm.Page.data.entity.getId().substr(1, 36),
    //    "individualCustomerId": GetCustomer().individual != null ? GetCustomer().individual[0].id.substr(1, 36) : "",
    //    "corporateCustomerId": GetCustomer().corporate != null ? GetCustomer().corporate[0].id.substr(1, 36) : "",
    //    "languageId": "1033",

    //};

    window.definitions.psbWorkflowStartInput = {
        "AmxPeruChangeSimCardGeneralRequest": {
            "$type": "AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralRequest,AmxPeruPSBActivities",
            "ResourceID": Xrm.Page.getAttribute("etel_productresourceid").getValue().substring(1).substring(0, 36)
        }
    }; 

    //window.definitions.psbWorkflowStartInput = {};

    var parameters = "name=AmxPeruMSISDNChangeWorkflow" + customerParameter;
    var versionNumber = Util.getCrmWebResourceVersion();
    var url = Xrm.Page.context.getClientUrl() + "/" + versionNumber + "/WebResources/etel_/psb/Wizard/wizard.html?Data=" + encodeURIComponent(parameters);
    Xrm.Page.getControl("WebResource_processapp").setSrc(url);
}

if (window.definitions === undefined || window.definitions === null) {
    window.definitions = {};
}

var translationScope = {
    CurrentUserLanguageCode: GetUserLanguageCode(),
    data: null,
    GetData: function (formId) {
        if (translationScope.data !== null) {
            return;
        }

        translationScope.data = GetTranslationData(formId);

    }
};

function GetUserLanguageCode() {
    return Xrm.Page.context.getUserLcid();
}

function GetCustomer() {
    var corp = Xrm.Page.getAttribute("etel_corporateid").getValue();
    var ind = Xrm.Page.getAttribute("etel_individualid").getValue();

    return {
        corporate: corp,
        individual: ind,
    };
}