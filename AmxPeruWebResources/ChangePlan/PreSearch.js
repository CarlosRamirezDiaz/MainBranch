﻿﻿﻿//var selectedsubscriptions = [];
var translation_HTML_ConnectionSubscripiton = {
    data: null,
    GetData: function () {
        debugger;
        var formId = "HTML_ConnectionSubscripiton";
        if (translation_HTML_ConnectionSubscripiton.data !== null) {
            return;
        }
        translation_HTML_ConnectionSubscripiton.data = GetTranslationData(formId);
    }
};

function getConfigValues(value) {
    var url;
    var fetchXml = "<fetch distinct='false'>" +
        "<entity name='etel_crmconfiguration'>" +
        "<attribute name='etel_crmconfigurationid' />" +
        "<attribute name='etel_name' />" +
        "<attribute name='etel_value' />" +

        "<order attribute='etel_name' descending='false'/>" +
        "<filter type='and'>" +
        "<condition attribute='etel_name' operator='eq' value='" + value + "' />" +
        "</filter>" +
        "</entity>" +
        "</fetch>";
    var retriveID = XrmServiceToolkit.Soap.Fetch(fetchXml);
    if (retriveID.length > 0) {

        if (retriveID != null || retriveID != "undefined") {
            url = retriveID[0].attributes.etel_value.value;
        }
    }
    return url;
}
function CheckDebtStatus(selectEntityId) {
    var psbWorkflowUrl;
    var customerExternalId;
    var AplicationId;
    var UserApplication;
    var DocumentId;
    var DocumentNumber;
    var CustomerType;
    if (selectEntityId != null)
        var cols = ["firstname", "etel_externalid", "amxperu_documenttype", "etel_passportnumber"];
    var retrievedContact = XrmServiceToolkit.Soap.Retrieve("contact", selectEntityId, cols);
    if (retrievedContact != null) {
        customerExternalId = retrievedContact.attributes['etel_externalid'].value;
        DocumentId = retrievedContact.attributes['etel_externalid'].value;
        DocumentNumber = retrievedContact.attributes['etel_passportnumber'].value;
    }
    //customerExternalId = Xrm.page.getAttribute("etel_externalid").getValue();
    //DocumentId = Xrm.page.getAttribute("amxperu_documenttype").getValue();
    //DocumentNumber = Xrm.page.getAttribute("etel_passportnumber").getValue();

    psbWorkflowUrl = getConfigValues("PsbRestServiceUrl");
    var workflowServiceUrl = psbWorkflowUrl + 'GetDebtAccountStatus';
    var request = {
        "request":
        {
            "$type": "AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountRequest, AmxPeruPSBActivities",

            "CustomerExternalId": customerExternalId,
            "AplicationId": "00838",
            "UserApplication": "77665",
            "DocumentId": DocumentId,
            "DocumentNumber": DocumentNumber,
            "CustomerType": "1",

        }
    };

    $.ajax({
        type: "POST",
        url: workflowServiceUrl,
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
            //clearInterval(myVar);
            //
            //  alert(js_BI_ChangeSubscriptionBABIHandler.data.tDebtCheck);
            // alert("test success");
            // debugger;
            if (data) {

            }
        },
        error: function (data) {
            //clearInterval(myVar);
            debugger;
            alert(js_BI_ChangeSubscriptionBABIHandler.data.tDebtCheck);
            // alert(data.statusText);
        }
    });

}

function OpenSubscriptionMapping() {
    debugger;
    var translation_HTML_ConnectionSubscripiton = {
        data: null,
        GetData: function () {
            debugger;
            var formId = "HTML_ConnectionSubscripiton";
            if (translation_HTML_ConnectionSubscripiton.data !== null) {
                return;
            }
            translation_HTML_ConnectionSubscripiton.data = GetTranslationData(formId);
        }
    };
    var accountsummaryController = Xrm.Page.ui.controls.get("WebResource_accountsummarytabbedview");
    if (accountsummaryController != null && accountsummaryController.getObject() != null && accountsummaryController.getObject().contentWindow != null && accountsummaryController.getObject().contentWindow.angular.element(".main-container").scope() != null) {
        var selectedSubscription = accountsummaryController.getObject().contentWindow.angular.element(".main-container").scope().SubscriptionScopeSelectedItems;
        var selectedSubscriptionId = selectedSubscription[0][0].RowData.SubscriptionId;

        var subscriptionfetch = GetSubscription(selectedSubscriptionId);
        var nameValue = ((subscriptionfetch[0].attributes.etel_name) != null) ? (subscriptionfetch[0].attributes.etel_name.value) : "";

        var checklaunch = checkSubscriptionData(subscriptionfetch);
        {
            if (checklaunch == true) {
                var entityName = Xrm.Page.data.entity.getEntityName();
                var customerguidAndName = [];
                customerguidAndName = passparameters(entityName);
                var parameters = {};
                parameters["parameter_0"] = entityName.toString();
                parameters["parameter_1"] = (customerguidAndName[0].individualGUID).toString();
                parameters["parameter_3"] = (customerguidAndName[0].individualName).toString();
                parameters["parameter_2"] = selectedSubscriptionId;
                parameters["parameter_4"] = nameValue;
                debugger;
                CheckDebtStatus((customerguidAndName[0].individualGUID).toString());
                var windowOptions = {
                    openInNewWindow: true
                };
                Xrm.Utility.openEntityForm("amxperu_bisubscriptionmapping", null, parameters, windowOptions);
            }
            else {

                translation_HTML_ConnectionSubscripiton.GetData();
                // translation_HTML_SearchCatalog.GetData();
                alert(translation_HTML_ConnectionSubscripiton.data.tNewSM);
                //  alert("Please select a Non-Associated Subscription");
            }
        }

    }

}


function GetSubscription(subscriptionId) {

    var checksubscription = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
        " <entity name='etel_subscription'>" +
        "  <attribute name='etel_subscriptionid' />" +
        " <attribute name='etel_name' />" +
        "<attribute name='createdon' />" +
        "<attribute name='etel_individualuserid' />" +
        "<attribute name='etel_individualcustomerid' />" +
        "<order attribute='etel_name' descending='false' />" +
        "<filter type='and'>" +
        " <condition attribute='etel_subscriptionid' operator='eq' value='" + subscriptionId + "' />" +
        "</filter>" +
        "</entity>" +
        "</fetch>";

    var subscriptionfetch = XrmServiceToolkit.Soap.Fetch(checksubscription);
    return subscriptionfetch;
}


function checkSubscriptionData(subscriptionfetch) {

    if ((subscriptionfetch[0] != null) && (subscriptionfetch[0].attributes != null)) {
        var individualUserValue = ((subscriptionfetch[0].attributes.etel_individualuserid) != null) ? (subscriptionfetch[0].attributes.etel_individualuserid) : "";
        var individualCorporateValue = ((subscriptionfetch[0].attributes.etel_individualcustomerid) != null) ? (subscriptionfetch[0].attributes.etel_individualcustomerid) : "";

        if (individualUserValue.id == individualCorporateValue.id) {
            return true;
        }
        else {
            return false;
        }
    }
}
function OpenSubscriptionMappingUpdate() {
    debugger;
    var translation_HTML_ConnectionSubscripiton = {
        data: null,
        GetData: function () {
            debugger;
            var formId = "HTML_ConnectionSubscripiton";
            if (translation_HTML_ConnectionSubscripiton.data !== null) {
                return;
            }
            translation_HTML_ConnectionSubscripiton.data = GetTranslationData(formId);
        }
    };
    var accountsummaryController = Xrm.Page.ui.controls.get("WebResource_accountsummarytabbedview");
    if (accountsummaryController != null && accountsummaryController.getObject() != null && accountsummaryController.getObject().contentWindow != null && accountsummaryController.getObject().contentWindow.angular.element(".main-container").scope() != null) {
        var selectedSubscription = accountsummaryController.getObject().contentWindow.angular.element(".main-container").scope().SubscriptionScopeSelectedItems;
        var selectedSubscriptionId = selectedSubscription[0][0].RowData.SubscriptionId;

        var subscriptionfetch = GetSubscription(selectedSubscriptionId);
        var nameValue = ((subscriptionfetch[0].attributes.etel_name) != null) ? (subscriptionfetch[0].attributes.etel_name.value) : "";
        var individualUserValue = ((subscriptionfetch[0].attributes.etel_individualuserid) != null) ? (subscriptionfetch[0].attributes.etel_individualuserid.id) : "";
        var checklaunch = checkSubscriptionData(subscriptionfetch);
        {
            if (checklaunch == false) {
                var entityName = Xrm.Page.data.entity.getEntityName();
                var customerguidAndName = [];
                customerguidAndName = passparameters(entityName);
                var parameters = {};
                parameters["parameter_0"] = entityName.toString();
                parameters["parameter_1"] = (customerguidAndName[0].individualGUID).toString();
                parameters["parameter_3"] = (customerguidAndName[0].individualName).toString();
                parameters["parameter_2"] = selectedSubscriptionId;
                parameters["parameter_4"] = nameValue;
                parameters["parameter_5"] = individualUserValue;
                CheckDebtStatus((customerguidAndName[0].individualGUID).toString());
                var windowOptions = {
                    openInNewWindow: true
                };
                Xrm.Utility.openEntityForm("amxperu_bisubscriptionmappingupdate", null, parameters, windowOptions);

            }
            else {
                // For Translation

                translation_HTML_ConnectionSubscripiton.GetData();
                alert(translation_HTML_ConnectionSubscripiton.data.tUpdateSM);
                //  alert("Please select an Associated Subscription");
            }
        }
    }
}

function handlingparamenters() {
    debugger;
    var retrieveparameters = Xrm.Page.context.getQueryStringParameters();
    var entname = null;
    var custguid = null;
    var subguid = null;
    var existingValue = null;
    var subname = null;
    if ((retrieveparameters.parameter_0 != null) && (retrieveparameters.parameter_0 != "")) {
        entname = retrieveparameters.parameter_0;
        Xrm.Page.getAttribute("amxperu_entitycheck").setValue(entname);
    }
    if ((retrieveparameters.parameter_1 != null) && (retrieveparameters.parameter_1 != "")) {
        custguid = retrieveparameters.parameter_1;
        custname = retrieveparameters.parameter_3;
    }
    if ((retrieveparameters.parameter_2 != null) && (retrieveparameters.parameter_2 != "")) {
        subguid = retrieveparameters.parameter_2;
    }
    if ((retrieveparameters.parameter_4 != null) && (retrieveparameters.parameter_4 != "")) {
        subname = retrieveparameters.parameter_4;
    }

    if ((custguid != null) && (entname != null)) {
        var lookupVal = new Array();
        lookupVal[0] = new Object();
        lookupVal[0].id = custguid;
        //  lookupVal[0].name = "Saurabh Purohit";
        lookupVal[0].name = custname;
        lookupVal[0].entityType = entname;
        if (lookupVal[0].entityType == "contact") {
            existingValue = Xrm.Page.getAttribute("amxperu_individualcustomer").getValue();
            if (existingValue === null) {
                Xrm.Page.getAttribute("amxperu_individualcustomer").setValue(lookupVal);
                //  Xrm.Page.getAttribute("amxperu_individualcustomer").setSubmitMode(always);
            }
        }
        else if (lookupVal[0].entityType == "account") {
            existingValue = Xrm.Page.getAttribute("amxperu_corporatecustomer").getValue();
            if (existingValue === null) {
                Xrm.Page.getAttribute("amxperu_corporatecustomer").setValue(lookupVal);
                //  Xrm.Page.getAttribute("amxperu_corporatecustomer").setSubmitMode("always");
            }
        }
    }

    if (subguid != null) {
        var lookupVal1 = new Array();
        lookupVal1[0] = new Object();
        lookupVal1[0].id = subguid;
        lookupVal1[0].name = subname;
        lookupVal1[0].entityType = "etel_subscription";
        var existingValue = Xrm.Page.getAttribute("amxperu_subscription1").getValue();
        if (existingValue === null) {
            Xrm.Page.getAttribute("amxperu_subscription1").setValue(lookupVal1);
            //  Xrm.Page.getAttribute("amxperu_subscription1").setSubmitMode("always");
        }
    }

}
function handlingparamentersUpdate() {
    debugger;
    var retrieveparameters = Xrm.Page.context.getQueryStringParameters();
    var entname = null;
    var custguid = null;
    var subguid = null;
    var existingValue = null;
    var indUserId = null;
    if ((retrieveparameters.parameter_0 != null) && (retrieveparameters.parameter_0 != "")) {
        entname = retrieveparameters.parameter_0;
        Xrm.Page.getAttribute("amxperu_entitycheckupdate").setValue(entname);
    }
    if ((retrieveparameters.parameter_1 != null) && (retrieveparameters.parameter_1 != "")) {
        custguid = retrieveparameters.parameter_1;
        custname = retrieveparameters.parameter_3;
    }
    if ((retrieveparameters.parameter_2 != null) && (retrieveparameters.parameter_2 != "")) {
        subguid = retrieveparameters.parameter_2;
    }
    if ((retrieveparameters.parameter_4 != null) && (retrieveparameters.parameter_4 != "")) {
        subname = retrieveparameters.parameter_4;
    }
    if ((retrieveparameters.parameter_5 != null) && (retrieveparameters.parameter_5 != "")) {
        indUserId = retrieveparameters.parameter_5;
    }
    if ((custguid != null) && (entname != null)) {
        var lookupVal = new Array();
        lookupVal[0] = new Object();
        lookupVal[0].id = custguid;
        //  lookupVal[0].name = "Saurabh Purohit";
        lookupVal[0].name = custname;
        lookupVal[0].entityType = entname;
        if (lookupVal[0].entityType == "contact") {
            existingValue = Xrm.Page.getAttribute("amxperu_individualcustomerupdate").getValue();
            if (existingValue === null) {
                Xrm.Page.getAttribute("amxperu_individualcustomerupdate").setValue(lookupVal);
                //  Xrm.Page.getAttribute("amxperu_individualcustomer").setSubmitMode(always);
            }
        }
        else if (lookupVal[0].entityType == "account") {
            existingValue = Xrm.Page.getAttribute("amxperu_corporatecustomerupdate").getValue();
            if (existingValue === null) {
                Xrm.Page.getAttribute("amxperu_corporatecustomerupdate").setValue(lookupVal);
                //  Xrm.Page.getAttribute("amxperu_corporatecustomer").setSubmitMode("always");
            }
        }
    }

    if (subguid != null) {
        var lookupVal1 = new Array();
        lookupVal1[0] = new Object();
        lookupVal1[0].id = subguid;
        lookupVal1[0].name = subname;
        lookupVal1[0].entityType = "etel_subscription";
        var existingValue = Xrm.Page.getAttribute("amxperu_subscriptionupdate").getValue();
        if (existingValue === null) {
            Xrm.Page.getAttribute("amxperu_subscriptionupdate").setValue(lookupVal1);
            //  Xrm.Page.getAttribute("amxperu_subscription1").setSubmitMode("always");
        }

    }
    // Xrm.Page.ui.tabs.get("tab_3").sections.get("tab_3_section_2").setVisible(false);

    //For Translation

}

function submitSubscriptionMapping() {
    debugger;
    // alert("yes");
    Xrm.Page.getAttribute("amxperu_boolupdate").setValue(250000000);
    Xrm.Page.data.entity.save();
}
function submitSubscriptionMappingUpdate() {
    debugger;
    // alert("yes");
    Xrm.Page.getAttribute("amxperu_smuboolupdate").setValue(250000000);
    Xrm.Page.data.entity.save();
}
function SaveSubscriptionMapping() {
    debugger;
    var subname = null;
    var connectionName = null;

    connectionval = Xrm.Page.getAttribute("amxperu_newselectedconnectionname");
    if (connectionval != null) {
        connectionName = connectionval.getValue();
    }
    var suscriptionValue = Xrm.Page.getAttribute("amxperu_subscription1");
    if (suscriptionValue != null) {
        var subscrip = suscriptionValue.getValue();
        if (subscrip != null) {
            var subname = subscrip[0].name;
        }
    }
    Xrm.Page.getAttribute("amxperu_name").setValue(subname + "-" + connectionName);

}
function SaveSubscriptionMappingUpdate() {
    debugger;
    var subname = null;
    var connectionName = null;

    connectionval = Xrm.Page.getAttribute("amxperu_selectedconnectionupdate");
    if (connectionval != null) {
        connectionName = connectionval.getValue();
    }
    var suscriptionValue = Xrm.Page.getAttribute("amxperu_subscriptionupdate");
    if (suscriptionValue != null) {
        var subscrip = suscriptionValue.getValue();
        if (subscrip != null) {
            var subname = subscrip[0].name;
        }
    }
    Xrm.Page.getAttribute("amxperu_name").setValue(subname + "-" + connectionName);


}


function passparameters(external) {
    debugger;

    var externalId = Xrm.Page.getAttribute("etel_externalid").getValue();
    var individualGUID = null;
    var customerdataarray = [];
    var customerdata = {};
    if (external == "contact") {
        var individualRecord = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
            "<entity name='contact'>" +
            "<attribute name='fullname' />" +
            "<attribute name='etel_iddocumentnumber' />" +
            "<attribute name='address1_postalcode' />" +
            "<attribute name='address1_line1' />" +
            "<attribute name='etel_cityid' />" +
            "<attribute name='contactid' />" +
            "<attribute name='etel_externalid' />" +
            "<order attribute='fullname' descending='false' />" +
            "<filter type='and'>" +
            "<condition attribute='etel_externalid' operator='eq' value='" + externalId + "' />" +
            //"<condition attribute='etel_externalid' operator='eq' value='CUST0000000096' />" +
            "</filter>" +
            "</entity>" +
            "</fetch>"
        var individualRecordfetch = XrmServiceToolkit.Soap.Fetch(individualRecord);

        if ((individualRecordfetch[0] != null) && (individualRecordfetch[0].attributes != null)) {
            customerdata['individualGUID'] = ((individualRecordfetch[0].id) != null) ? (individualRecordfetch[0].id) : "";
            customerdata['individualName'] = ((individualRecordfetch[0].attributes.fullname) != null) ? (individualRecordfetch[0].attributes.fullname.value) : "";
        }
        //customerdataarray.push(customerdata);
    }
    else if (external == "account") {
        var corporaterecord = "< fetch version= '1.0' output- format='xml-platform' mapping= 'logical' distinct= 'false' >" +
            "<entity name='account'>" +
            "   <attribute name='name' />" +
            "  <attribute name='primarycontactid' />" +
            " <attribute name='accountnumber' />" +
            "<attribute name='accountid' />" +
            "<attribute name='etel_externalid' />" +
            "<order attribute='name' descending='false' />" +
            "<filter type='and'>" +
            "<condition attribute='etel_externalid' operator='eq' value='" + externalId + "' />" +
            "</filter>" +
            " </entity>" +
            "</fetch >"
        //   var corporaterecordfetch = XrmServiceToolkit.Soap.Fetch(corporaterecord);

        //  if ((corporaterecordfetch[0] != null) && (corporaterecordfetch[0].attributes != null)) {
        //      customerdata['individualGUID'] = ((corporaterecordfetch[0].id) != null) ? (corporaterecordfetch[0].id) : "";
        //      customerdata['individualName'] = ((corporaterecordfetch[0].attributes.name) != null) ? (corporaterecordfetch[0].attributes.name.value) : "";
        //  }
        customerdata['individualGUID'] = "6D7CEB5C-3379-E711-8126-00505601173A";
        customerdata['individualName'] = "ERCSN CORP";
    }
    customerdataarray.push(customerdata);
    return customerdataarray;
}
var selectedsubscriptions = [];


function fieldVisibilityAccordingToConnectedFromType() {
    var connectedto = Xrm.Page.getAttribute("record1id");
    if (connectedto.getValue() != null && connectedto.getValue()[0] != null) {
        var connectedtoLookUp = connectedto.getValue()[0];
        if ((connectedtoLookUp.id != null) && (connectedtoLookUp.entityType == "account")) {
            Xrm.Page.getControl("amxperu_fixedservice").setVisible(true);
            Xrm.Page.getControl("amxperu_mobileservice").setVisible(true);
            Xrm.Page.getControl("amxperu_allsubscriptions").setVisible(true);
            Xrm.Page.getAttribute("amxperu_allsubscriptions").setRequiredLevel("required");

        }
    }
}
function refreshHTMLWebResource() {
    var currentLocation = Xrm.Page.getControl("WebResource_amxperu_Connection_html_SubscriptionList").getObject().contentWindow.location.href;
    Xrm.Page.getControl("WebResource_amxperu_Connection_html_SubscriptionList").getObject().contentWindow.location.href = currentLocation;
    var iframe = document.getElementById('WebResource_amxperu_Connection_html_SubscriptionList');

}
function preFilterLookup() {

    document.getElementById("record2id").setAttribute("lookuptypenames", "account:1:Corporate,contact:2:Individual");
    document.getElementById("record2id").setAttribute("lookuptypes", "1,2");
    Xrm.Page.getControl("record2id").addPreSearch(function () {
        //   filter();
        preFilterForConnectedTo();

    });
}
function preFilterForConnectedTo() {
    var connectedfrom = Xrm.Page.getAttribute("record1id").getValue();
    if (connectedfrom != null && connectedfrom[0] != null) {
        // var fetchconfrmCommon = "<filter type='and'><condition attribute='statecode' value='0' operator='eq'/><condition attribute='statecode' value='1' operator='eq'/></filter>";
        // var fetchconfrmCommon = "<filter type='and'><condition attribute='createdon' operator='null'/></filter>";
        //  Xrm.Page.getControl("record2id").addCustomFilter(fetchconfrmCommon);
        if (connectedfrom[0].entityType == "contact") {

            var fetchconfrm = "<filter type='and'><condition attribute='contactid' operator='not-null'/></filter>";
            Xrm.Page.getControl("record2id").addCustomFilter(fetchconfrm, "contact");

            var fetchconfrmAccount = "<filter type='and'><condition attribute='accountid' operator='null'/></filter>";
            Xrm.Page.getControl("record2id").addCustomFilter(fetchconfrmAccount, "account");
        }
        else if (connectedfrom[0].entityType == "account") {
            var fetchconfrm = "<filter type='and'><condition attribute='contactid' operator='not-null'/></filter>";
            Xrm.Page.getControl("record2id").addCustomFilter(fetchconfrm, "contact");
        }

    }

}
var subfetchids = [];
var subassociatedfetchids = [];
function SavedSubscriptionsData(executionObj) {
    debugger;
    var hiddenGUID = Xrm.Page.getAttribute("amxperu_hiddensubscriptionguids").getValue();
    var hiddenassociatedGUID = Xrm.Page.getAttribute("amxperu_hiddenassociatedsubscriptionguids").getValue();
    var hiddenSavedGUID = Xrm.Page.getAttribute("amxperu_hiddensubscriptionsavedrecords").getValue();
    var finalassociatedrecords = "";
    if ((hiddenGUID != null) && (hiddenGUID != "")) {
        UpdateSubscription(hiddenGUID);
        if ((hiddenSavedGUID != null) && (hiddenSavedGUID != "")) {
            hiddenSavedGUID = hiddenSavedGUID + ";" + hiddenGUID;
            finalassociatedrecords = hiddenSavedGUID;
        }

        else {
            hiddenSavedGUID = hiddenGUID;
            finalassociatedrecords = hiddenGUID;
        }
        Xrm.Page.getAttribute("amxperu_hiddensubscriptionsavedrecords").setValue(hiddenSavedGUID);
        Xrm.Page.getAttribute("amxperu_hiddensubscriptionguids").setValue(null);
        Xrm.Page.getAttribute("amxperu_associatedguid").setValue(finalassociatedrecords);
    }

    if ((hiddenassociatedGUID != null) && (hiddenassociatedGUID != "")) {
        UpdateAssociateSubscription(hiddenassociatedGUID);
        if ((hiddenSavedGUID != null) && (hiddenSavedGUID != "")) {
            var hiddesavedsplit = hiddenSavedGUID.split(";");
            var hiddenassociatedsplit = hiddenassociatedGUID.split(";");

            for (var eachhiddesavedsplit = 0; eachhiddesavedsplit < hiddesavedsplit.length; eachhiddesavedsplit++) {
                for (var eachhiddenassociatedsplit = 0; eachhiddenassociatedsplit < hiddenassociatedsplit.length; eachhiddenassociatedsplit++) {
                    if (hiddesavedsplit[eachhiddesavedsplit] != hiddenassociatedsplit[eachhiddenassociatedsplit]) {
                        if (hiddenassociatedGUID.indexOf(hiddesavedsplit[eachhiddesavedsplit]) == -1) {
                            finalassociatedrecords = finalassociatedrecords + ";" + hiddesavedsplit[eachhiddesavedsplit];
                        }
                    }

                }
            }
            if (finalassociatedrecords[0] == "") {
                finalassociatedrecords = finalassociatedrecords.substr(1, finalassociatedrecords.length);
            }
        }
        else {

            finalassociatedrecords = hiddenassociatedGUID;
            //  hiddenSavedGUID = hiddenSavedGUID + ";" + hiddenassociatedGUID;
        }
        Xrm.Page.getAttribute("amxperu_hiddensubscriptionsavedrecords").setValue(hiddenSavedGUID);
        Xrm.Page.getAttribute("amxperu_hiddenassociatedsubscriptionguids").setValue(null);
        Xrm.Page.getAttribute("amxperu_associatedguid").setValue(finalassociatedrecords);
    }
    Xrm.Page.ui.clearFormNotification("NoSubscriptionError");

    var translation_HTML_Connection = {
        data: null,
        GetData: function () {
            debugger;
            var formId = "HTML_Connection";
            if (translation_HTML_Connection.data !== null) {
                return;
            }
            translation_HTML_Connection.data = GetTranslationData(formId);
        }
    };

    if (Xrm.Page.getAttribute("amxperu_hiddensubscriptionsavedrecords").getValue() == null) {
        // alert("Please select a subscription");translation_HTML_SearchCatalog.data.tOffersSearch
        Xrm.Page.ui.setFormNotification("Please select a subscription", "ERROR", "NoSubscriptionError");
        // Xrm.Page.ui.setFormNotification(translation_HTML_Connection.data.tselectsubscriptionerror, "ERROR", "NoSubscriptionError");
        executionObj.getEventArgs().preventDefault();
        return false;
    }
}

function roleFromLookup() {
    debugger;
    Xrm.Page.getControl("record1roleid").addPreSearch(function () {
        preFilterForroleFrom();

    });
}
function roleToLookup() {
    debugger;
    //Xrm.Page.getControl("record2id").setDefaultView("{0F00BF5F- 3C30- 4C9B- 9E06 - 7F5F26FFD537}");    
    Xrm.Page.getControl("record2roleid").addPreSearch(function () {
        preFilterForroleFrom();

    });
}
//function preFilterForroleFrom() {
//    var connectedfrom = Xrm.Page.getAttribute("record1id").getValue();
//    if (connectedfrom != null && connectedfrom[0] != null) {
//        if (connectedfrom[0].entityType == "contact") {
//            var fetchconfrmrole = "<filter type='and'>" +
//                "<condition attribute='connectionroleid' operator='in'>" +
//                "<value uiname='Employee' uitype='connectionrole'>{35A23B91-EC62-41EA-B5E5-C59B689FF0B4}</value>" +
//                "<value uiname='Family' uitype='connectionrole'>{F87A6ECA-2671-E711-811F-00505601173A}</value>" +
//                "<value uiname='User' uitype='connectionrole'>{ADCCF191-576B-463B-BE78-019A427EB2E5}</value>" +
//                "</condition>" +
//                "</filter>"
//            Xrm.Page.getControl("record1roleid").addCustomFilter(fetchconfrmrole);

//        }
//        else if (connectedfrom[0].entityType == "account") {
//            var fetchconfrmrole1 = "<filter type='and'>" +
//                "<condition attribute='connectionroleid' operator='in'>" +
//                "   <value uiname='Legal Representative' uitype='connectionrole'>{96A3B4A1-3271-E711-811F-00505601173A}</value>" +
//                "  <value uiname='Customer Contact' uitype='connectionrole'>{BE6C0B85-3371-E711-811F-00505601173A}</value>" +
//                " <value uiname='Billing Contact' uitype='connectionrole'>{8C13CF92-3371-E711-811F-00505601173A}</value>" +
//                "<value uiname='Dispatch Contact' uitype='connectionrole'>{1A328B9A-3371-E711-811F-00505601173A}</value>" +
//                "<value uiname='Collection Contact' uitype='connectionrole'>{E52B77A1-3371-E711-811F-00505601173A}</value>" +
//                "<value uiname='Technical Contact' uitype='connectionrole'>{B3C6D1AD-3371-E711-811F-00505601173A}</value>" +
//                "<value uiname='Installation Contact' uitype='connectionrole'>{D1879EB5-3371-E711-811F-00505601173A}</value>" +
//                "<value uiname='Marketing Manager' uitype='connectionrole'>{61D9C3BE-3371-E711-811F-00505601173A}</value>" +
//                "<value uiname='Commercial Manager' uitype='connectionrole'>{B1FBC1C5-3371-E711-811F-00505601173A}</value>" +
//                "<value uiname='IT Manager' uitype='connectionrole'>{5F7A3BCE-3371-E711-811F-00505601173A}</value>" +
//                "<value uiname='General Manager' uitype='connectionrole'>{4C1283D6-3371-E711-811F-00505601173A}</value>" +
//                "<value uiname='User' uitype='connectionrole'>{4784E5ED-3371-E711-811F-00505601173A}</value>" +
//                "</condition>" +
//                "</filter>"

//            Xrm.Page.getControl("record1roleid").addCustomFilter(fetchconfrmrole1);
//        }

//    }

//}
function preFilterForroleFrom() {
    var connectedfrom = Xrm.Page.getAttribute("record1id").getValue();
    if (connectedfrom != null && connectedfrom[0] != null) {
        if (connectedfrom[0].entityType == "contact") {
            var fetchconfrmrole = "<filter type='and'>" +
                "<condition attribute='connectionroleid' operator='in'>" +
                "<value uiname='Employee' uitype='connectionrole'>{35A23B91-EC62-41EA-B5E5-C59B689FF0B4}</value>" +
                "<value uiname='Family' uitype='connectionrole'>{F87A6ECA-2671-E711-811F-00505601173A}</value>" +
                "<value uiname='User' uitype='connectionrole'>{ADCCF191-576B-463B-BE78-019A427EB2E5}</value>" +
                "</condition>" +
                "</filter>"
            Xrm.Page.getControl("record1roleid").addCustomFilter(fetchconfrmrole);

        }
        else if (connectedfrom[0].entityType == "account") {
            var fetchconfrmrole1 = "<filter type='and'>" +
                "<condition attribute='connectionroleid' operator='in'>" +
                "   <value uiname='Legal Representative' uitype='connectionrole'>{96A3B4A1-3271-E711-811F-00505601173A}</value>" +
                "  <value uiname='Customer Contact' uitype='connectionrole'>{BE6C0B85-3371-E711-811F-00505601173A}</value>" +
                " <value uiname='Billing Contact' uitype='connectionrole'>{8C13CF92-3371-E711-811F-00505601173A}</value>" +
                "<value uiname='Dispatch Contact' uitype='connectionrole'>{1A328B9A-3371-E711-811F-00505601173A}</value>" +
                "<value uiname='Collection Contact' uitype='connectionrole'>{E52B77A1-3371-E711-811F-00505601173A}</value>" +
                "<value uiname='Technical Contact' uitype='connectionrole'>{B3C6D1AD-3371-E711-811F-00505601173A}</value>" +
                "<value uiname='Installation Contact' uitype='connectionrole'>{D1879EB5-3371-E711-811F-00505601173A}</value>" +
                "<value uiname='Marketing Manager' uitype='connectionrole'>{61D9C3BE-3371-E711-811F-00505601173A}</value>" +
                "<value uiname='Commercial Manager' uitype='connectionrole'>{B1FBC1C5-3371-E711-811F-00505601173A}</value>" +
                "<value uiname='IT Manager' uitype='connectionrole'>{5F7A3BCE-3371-E711-811F-00505601173A}</value>" +
                "<value uiname='General Manager' uitype='connectionrole'>{4C1283D6-3371-E711-811F-00505601173A}</value>" +
                "<value uiname='User' uitype='connectionrole'>{4784E5ED-3371-E711-811F-00505601173A}</value>" +
                "</condition>" +
                "</filter>"

            Xrm.Page.getControl("record1roleid").addCustomFilter(fetchconfrmrole1);
        }

    }
}
function UpdateSubscription(hiddenGUID) {
    debugger;
    var SplitSubscriptionGUID = hiddenGUID.split(";");
    // debugger;
    var connectedto = Xrm.Page.getAttribute("record2id");
    if (connectedto.getValue() != null && connectedto.getValue()[0] != null) {
        var connectedtoLookUp = connectedto.getValue()[0];
        for (var subfetchidseach = 0; subfetchidseach < SplitSubscriptionGUID.length; subfetchidseach++) {

            var updateEntity = new XrmServiceToolkit.Soap.BusinessEntity("etel_subscription", SplitSubscriptionGUID[subfetchidseach]);
            if ((connectedtoLookUp.id != null) && (connectedtoLookUp.entityType == "contact")) {

                updateEntity.attributes["etel_individualuserid"] = { id: connectedtoLookUp.id, logicalName: 'contact', type: 'EntityReference' };
                updateEntity.attributes["etel_corporateuserid"] = null;
            }
            else {
                updateEntity.attributes["etel_corporateuserid"] = { id: connectedtoLookUp.id, logicalName: 'account', type: 'EntityReference' };
                updateEntity.attributes["etel_individualuserid"] = null;
            }

            var updateResponse = XrmServiceToolkit.Soap.Update(updateEntity);

        }
    }


}
function UpdateAssociateSubscription(hiddenassociatedGUID1) {
    debugger;
    var SplitAssociateSubscriptionGUID = hiddenassociatedGUID1.split(";");
    var connectedassociatefrom = Xrm.Page.getAttribute("record1id");
    if (connectedassociatefrom.getValue() != null && connectedassociatefrom.getValue()[0] != null) {
        var connectedassociatefromLookup = connectedassociatefrom.getValue()[0];
        for (var eachSplitAssociateSubscriptionGUID = 0; eachSplitAssociateSubscriptionGUID < SplitAssociateSubscriptionGUID.length; eachSplitAssociateSubscriptionGUID++) {

            var updateAssociateEntity = new XrmServiceToolkit.Soap.BusinessEntity("etel_subscription", SplitAssociateSubscriptionGUID[eachSplitAssociateSubscriptionGUID]);
            if ((connectedassociatefromLookup.id != null) && (connectedassociatefromLookup.entityType == "contact")) {
                updateAssociateEntity.attributes["etel_individualuserid"] = { id: connectedassociatefromLookup.id, logicalName: 'contact', type: 'EntityReference' };
                updateAssociateEntity.attributes["etel_corporateuserid"] = null;
            }
            else {
                updateAssociateEntity.attributes["etel_corporateuserid"] = { id: connectedassociatefromLookup.id, logicalName: 'account', type: 'EntityReference' };
                updateAssociateEntity.attributes["etel_individualuserid"] = null;
            }

            var updateAssociateResponse = XrmServiceToolkit.Soap.Update(updateAssociateEntity);

        }
    }


}
function blankHiddenGUID() {

    var allSubscripvalue = parent.Xrm.Page.getAttribute("amxperu_AllSubscriptions");
    if (allSubscripvalue != null && allSubscripvalue.getValue() != null) {
        //for Yes select all the displayed Subscriptions
        if (allSubscripvalue.getValue() == "250000000") {
            Xrm.Page.getAttribute("amxperu_hiddensubscriptionguids").setValue(null);
        }
    }
}
function createBILOG() {
    debugger;
    var connectedToValue = Xrm.Page.getAttribute("record1id").getValue();
    var customerTypeValue = null;
    var descriptionparamvalue = "";
    var externalIDFetch = null;
    var externalIdValue = null;
    if ((connectedToValue != null) && (connectedToValue[0] != null)) {
        descriptionparam = Xrm.Page.getAttribute("description").getValue();
        if (descriptionparam != null) {
            descriptionparamvalue = descriptionparam;
        }

        var connectedEntityid = connectedToValue[0].id;
        if (connectedToValue[0].entityType == "account") {
            customerTypeValue = "1";
            externalIDFetch = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>" +
                "<entity name='account'>" +
                "<attribute name='name'/>" +
                "<attribute name='accountid'/>" +
                "<attribute name='etel_externalid'/>" +
                "<order descending='false' attribute='name'/>" +
                "<filter type='and'>" +
                "<condition attribute='accountid' value='" + connectedEntityid + "' operator='eq'/>" +
                "</filter>" +
                "</entity>" +
                "</fetch>"

        }
        else if (connectedToValue[0].entityType == "contact") {
            customerTypeValue = "0";
            externalIDFetch = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>" +
                "<entity name='contact'>" +
                "<attribute name='fullname'/>" +
                "<attribute name='contactid'/>" +
                "<attribute name='etel_externalid'/>" +
                "<order descending='false' attribute='fullname'/>" +
                "<filter type='and'>" +
                "<condition attribute='contactid' value='" + connectedEntityid + "'  operator='eq'/>" +
                "</filter>" +
                "</entity>" +
                "</fetch>"

        }
        var externalFetchValue = XrmServiceToolkit.Soap.Fetch(externalIDFetch);
        if (externalFetchValue.length > 0) {
            for (var eachExternalFetchValue = 0; eachExternalFetchValue < externalFetchValue.length; eachExternalFetchValue++) {
                if ((externalFetchValue[eachExternalFetchValue] != null) && (externalFetchValue[eachExternalFetchValue].attributes != null)) {
                    externalIdValue = ((externalFetchValue[eachExternalFetchValue].attributes.etel_externalid) != null) ? (externalFetchValue[eachExternalFetchValue].attributes.etel_externalid.value) : "";
                }
            }
        }


    }
    //  var serviceUrl = "http://localhost:2501/CreateBILog.svc/rest/CreateBILogEntry";
    var serviceUrl = "http://10.103.27.187:2500/CreateBILog.svc/rest/CreateBILogEntry";

    var request = {
        "subject": "Connection Role BI Information",
        "description": "Connection Role BI Log:" + descriptionparamvalue,
        "CustomerChannel": "CallCenter",
        "customerType": customerTypeValue,
        "ExternalID": externalIdValue
    };
    $.ajax({
        type: "POST",
        url: serviceUrl,
        dataType: "json",
        data: JSON.stringify(request),
        contentType: "application/json; charset=utf-8",
        async: false,
        cache: false,
        crossDomain: true,
        success: function (data) {
            debugger;
            if (data) {
                if (data.Status == "OK") {
                    // alert("Call to Create BI Log is completed Successfully : " + data.Status);
                }
            }
        },
        error: function (data) {
            debugger;
        }
    });
}
////for Removing a Existing Subscription
function createdconnectionrecord(selectedsubscriptionID1, selectedConnectionID1, selectedCustomerID1) {
    var retrievecreatedconnectionrecordID = "";
    var createdconnectionrec = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
        " <entity name='amxperu_biconnectionmapping'>" +
        "               <attribute name='amxperu_biconnectionmappingid' />" +
        "              <attribute name='amxperu_name' />" +
        "             <attribute name='createdon' />" +
        "            <order attribute='amxperu_name' descending='false' />" +
        "           <filter type='and'>" +
        "              <condition attribute='amxperu_subscription12' operator='eq' uiname='OfferSubscription1' uitype='etel_subscription' value='{04A311FD-6C7B-E711-8126-00505601173A}' />" +
        "             <condition attribute='amxperu_connectionguid' operator='like' value='%A7274130-CD7C-E711-8126-00505601173A%' />" +
        "            <condition attribute='amxperu_individualcustomer' operator='eq' uiname='Saurabh Purohit' uitype='contact' value='{B43FDF45-1D79-E711-8126-00505601173A}' />" +
        "       </filter>" +
        "  </entity>" +
        " </fetch > "
    var retrievecreatedconnectionrecord = XrmServiceToolkit.Soap.Fetch(createdconnectionrec);
    if (retrievecreatedconnectionrecord.length > 0) {
        if ((retrievecreatedconnectionrecord[0] != null) && (retrievecreatedconnectionrecord[0].attributes != null)) {
            retrievecreatedconnectionrecordID = ((retrievecreatedconnectionrecord[0].id) != null) ? retrievecreatedconnectionrecord[0].id : "";
        }
    }
    return retrievecreatedconnectionrecordID;
}
function removesubscription() {
    var selectedsubscriptionID = "";
    var selectedConnectionID = parent.Xrm.Page.getAttribute("amxperu_connectionguid").getValue();
    var selectedCustomerID = "";
    currentRecordIdforUpdate = createdconnectionrecord(selectedsubscriptionID, selectedConnectionID, selectedCustomerID);
    XrmServiceToolkit.Soap.Delete("amxperu_biconnectionmapping", currentRecordIdforUpdate);
    var entName = Xrm.Page.getAttribute("amxperu_entitycheckupdate").setValue(entname);
    var updateEntity = new XrmServiceToolkit.Soap.BusinessEntity("etel_subscription", selectedsubscriptionID);
    var retrieveparametersonupdate = Xrm.Page.context.getQueryStringParameters();
    if ((retrieveparametersonupdate.parameter_1 != null) && (retrieveparametersonupdate.parameter_1 != "")) {
        if (entName == "contact") {
            updateEntity.attributes["etel_individualuserid"] = { id: retrieveparametersonupdate.parameter_1, logicalName: 'contact', type: 'EntityReference' };
            updateEntity.attributes["etel_corporateuserid"] = null;
        }
        else if (entName == "account") {
            updateEntity.attributes["etel_corporateuserid"] = { id: retrieveparametersonupdate.parameter_1, logicalName: 'account', type: 'EntityReference' };
            updateEntity.attributes["etel_individualuserid"] = null;
        }
    }
}
//onsave of SubscriptionMappingUpdate()
function createdconnectionrecord(selectedsubscriptionID1, selectedConnectionID1, selectedCustomerID1) {
    var retrievecreatedconnectionrecordID = "";
    var createdconnectionrec = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
        " <entity name='amxperu_biconnectionmapping'>" +
        "               <attribute name='amxperu_biconnectionmappingid' />" +
        "              <attribute name='amxperu_name' />" +
        "             <attribute name='createdon' />" +
        "            <order attribute='amxperu_name' descending='false' />" +
        "           <filter type='and'>" +
        "              <condition attribute='amxperu_subscription12' operator='eq' uiname='OfferSubscription1' uitype='etel_subscription' value='{04A311FD-6C7B-E711-8126-00505601173A}' />" +
        // "             <condition attribute='amxperu_connectionguid' operator='like' value='%A7274130-CD7C-E711-8126-00505601173A%' />" +
        "            <condition attribute='amxperu_individualcustomer' operator='eq' uiname='Saurabh Purohit' uitype='contact' value='{B43FDF45-1D79-E711-8126-00505601173A}' />" +
        "       </filter>" +
        "  </entity>" +
        " </fetch > "
    var retrievecreatedconnectionrecord = XrmServiceToolkit.Soap.Fetch(createdconnectionrec);
    if (retrievecreatedconnectionrecord.length > 0) {
        if ((retrievecreatedconnectionrecord[0] != null) && (retrievecreatedconnectionrecord[0].attributes != null)) {
            retrievecreatedconnectionrecordID = ((retrievecreatedconnectionrecord[0].id) != null) ? retrievecreatedconnectionrecord[0].id : "";
        }
    }
    return retrievecreatedconnectionrecordID;
}
function createdconnectionrecord2(selectedsubscriptionID1, selectedConnectionID1, selectedCustomerID1) {
    var retrievecreatedconnectionrecordhidden = "";
    var createdconnectionrec = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
        " <entity name='amxperu_biconnectionmapping'>" +
        "               <attribute name='amxperu_biconnectionmappingid' />" +
        "              <attribute name='amxperu_name' />" +
        "             <attribute name='createdon' />" +
        "              <attribute name='amxperu_rolehiddenguids' />" +
        "            <order attribute='amxperu_name' descending='false' />" +
        "           <filter type='and'>" +
        "              <condition attribute='amxperu_subscription12' operator='eq' uiname='OfferSubscription1' uitype='etel_subscription' value='{04A311FD-6C7B-E711-8126-00505601173A}' />" +
        //  "             <condition attribute='amxperu_connectionguid' operator='like' value='%A7274130-CD7C-E711-8126-00505601173A%' />" +
        "            <condition attribute='amxperu_individualcustomer' operator='eq' uiname='Saurabh Purohit' uitype='contact' value='{B43FDF45-1D79-E711-8126-00505601173A}' />" +
        "       </filter>" +
        "  </entity>" +
        " </fetch > "
    var retrievecreatedconnectionrecord = XrmServiceToolkit.Soap.Fetch(createdconnectionrec);
    if (retrievecreatedconnectionrecord.length > 0) {
        if ((retrievecreatedconnectionrecord[0] != null) && (retrievecreatedconnectionrecord[0].attributes != null)) {
            retrievecreatedconnectionrecordhidden = ((retrievecreatedconnectionrecord[0].attributes.amxperu_rolehiddenguids) != null) ? retrievecreatedconnectionrecord[0].attributes.amxperu_rolehiddenguids.value : "";
        }
    }
    return retrievecreatedconnectionrecordhidden;
}
function onchangeSubscriptionMapping() {
    debugger;

    var selectedsubscriptionID = "";
    var selectedConnectionID = "";
    var selectedCustomerID = "";
    var updatedrolehidden = Xrm.Page.getAttribute("amxperu_rolehiddenguidsupdate").getValue();
    var currentRecordIdforUpdate = createdconnectionrecord(selectedsubscriptionID, selectedConnectionID, selectedCustomerID);
    var rolehidden = createdconnectionrecord2(selectedsubscriptionID, selectedConnectionID, selectedCustomerID);
    if (rolehidden != "") {
        rolehidden = rolehidden + "," + updatedrolehidden;
    }
    else if (rolehidden == "") {
        rolehidden = updatedrolehidden;
    }
    var updateEntity = new XrmServiceToolkit.Soap.BusinessEntity("amxperu_biconnectionmapping", currentRecordIdforUpdate);
    //  updateEntity.attributes["amxperu_rolehiddenguids"] = rolehidden;
    updateEntity.attributes["amxperu_subscriptionupdatebool"] = { value: "250000000", type: 'OptionSetValue' };
    Xrm.Page.getAttribute("amxperu_boolupdate1").setValue(250000000);
}
function CreateOrder(orderObj) {
    orderObj.etel_numberofsubscription = 1;

    SDK.REST.createRecord(
        orderObj, 'etel_ordercapture', function (orderObj) {
            Xrm.Utility.openEntityForm('etel_ordercapture', orderObj.etel_ordercaptureId);
        },
        _errorHandler);
}
function changeplanorderflow() {

    debugger;
    //  alert("changeplan");
   // translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var customerId1 = Xrm.Page.getAttribute("etel_individualcustomerid");
    var customerId = null;
    var customerId2 = null;
    var customerType = null;
    var subscriptionId1 = null;
    if (customerId1 != null)
    {
        customerId2 = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
        customerId = customerId2[0].id;
        customerType = "contact";

    }
    else if (Xrm.Page.getAttribute("etel_individualcustomerid") != null)
    {
        customerId2 = Xrm.Page.getAttribute("etel_corporatecustomerid").getValue();
        customerId = customerId2[0].id;
        customerType = "account";
    }
    subscriptionId1 = Xrm.Page.getAttribute("etel_subscriptionid").getValue();
    var subscriptionId = subscriptionId1[0].id;
    //var customerType = Xrm.Page.data.entity.getEntityName();
    //var customerTypeCode = Xrm.Page.getAttribute("statuscode").getValue();

    var headercheck = false;
    headercheck = headerCheck("createsubscriptionfromcustomer", customerId, subscriptionId, customerType);

    if (headercheck) {
      //  biRoleSecurityCreateSubscriptionFromCustomer.ValidateRole();
      //  if (biRoleSecurityCreateSubscriptionFromCustomer.IsValidatedRole === true) {
            var newOrder = {};
            if (customerType === "contact") {
                newOrder.etel_individualcustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            }
            else if (customerType === "account") {
                newOrder.etel_corporatecustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            }
            newOrder.etel_ordertypecode = {
                Value: 100000000  /// change resume date order type
            };
            newOrder.etel_subscriptionid = {
                Id: subscriptionId,
                LogicalName: "etel_subscription"
            };
            CreateOrder(newOrder);
      //  }
        //else {
        //    alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        //}
    }

}

// JavaScript source code





