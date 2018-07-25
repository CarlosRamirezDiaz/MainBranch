function preFilterBILogEntityLookup() {
    if (Xrm.Page.getControl("amxperu_relatedbilogactivity")) {
        var lookupControl = Xrm.Page.getControl("amxperu_relatedbilogactivity");
        lookupControl._control && lookupControl._control.tryCompleteOnDemandInitialization && lookupControl._control.tryCompleteOnDemandInitialization();
        lookupControl.addPreSearch(function () {
            fetchXml = "<filter type='and'><condition attribute='ownerid' operator='eq-useroruserteams'/></filter>";//eq-userid
            lookupControl.addCustomFilter(fetchXml);
        });
    }
}

function checkLockConditionForTaskType() {
    if (Xrm.Page.getAttribute("amxperu_tasktype") != null) {
        if (Xrm.Page.getAttribute("amxperu_tasktype").getValue() != null) {
            Xrm.Page.getControl("amxperu_tasktype").setDisabled(true);
            if (Xrm.Page.getAttribute("amxperu_tasktype").getIsDirty()) {
                Xrm.Page.getAttribute("amxperu_tasktype").setSubmitMode("always");
            }
        }
    }
}

function ConfirmationRequired() {
    var taskType;
    if (Xrm.Page.getAttribute("amxperu_tasktype") != null) {
        if (Xrm.Page.getAttribute("amxperu_tasktype").getValue() != null) {
            taskType = Xrm.Page.getAttribute("amxperu_tasktype").getValue();
            if (taskType == 3) {
                Xrm.Page.getAttribute("amxperu_confirmation").setRequiredLevel("required");
            }
            else {
                Xrm.Page.getAttribute("amxperu_confirmation").setRequiredLevel("none");
            }
        }
    }
}

function onSaveofTask(event) {
    var TaskType = Xrm.Page.getAttribute("amxperu_tasktype").getValue();
    var RemedyTicket = Xrm.Page.getAttribute("amxperu_remedyttnumber").getValue();
    if (TaskType == 1 && RemedyTicket == null)//Remedy
    {
        Xrm.Utility.confirmDialog("Selected Task Type is Remedy", function () {
        var TicketNo = CreateRemedyTicket();
        Xrm.Page.getAttribute("amxperu_remedyttnumber").setValue(TicketNo);
        }, function () {
            event.getEventArgs().preventDefault();
        });       
    }
}

function CreateRemedyTicket() {
    var WorkflowUrlName = GetConfigurationWorkflowUrl("PsbRestServiceUrl") + "AmxPeruGeneraIncidencia";
    var RemedyTicket = "";
    //TO DO
    var request = {
        "input": {
            "$type": "AmxPeruPSBActivities.Model.AMxperuGeneralIncidenciaRequest, AmxPeruPSBActivities",
            "customerSpec": {
                "lastName": "",
                "name": ""
            },
            "KnownProblemDescription": {
                "Description": "",
                "name": ""
            },
            "BusinessInteractionItem": {
                "id": ""
            },
            "CustomerProblemExtension": {
                "_affectedServices": "",
                "_affectedZone": "",
                "_typification": ""
            },
            "CustomerProblem": {
                "severity": ""
            }
        }
    };
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
            debugger;
            if (data) {
                RemedyTicket = data.Output.output._ticketRemedy;               
            }
        },
        error: function (data) {
            debugger;
            alert(data.statusText);
        }
    });
    return RemedyTicket;
}
function GetConfigurationWorkflowUrl(WorkflowUrlName) {
    var configValue;
    var fetchXml = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
        + "<entity name='etel_crmconfiguration'>"
        + "<attribute name='etel_crmconfigurationid'/>"
        + "<attribute name='etel_name'/>"
        + "<attribute name='etel_value'/>"
        + "<order descending='false' attribute='etel_name'/>"
        + "<filter type='and'>"
        + "<condition attribute='etel_name' value='" + WorkflowUrlName + "' operator='eq'/>"
        + "</filter>"
        + "</entity>"
        + "</fetch>";
    var configRecord = XrmServiceToolkit.Soap.Fetch(fetchXml);
    if (configRecord.length > 0) {
        if (configRecord[0].attributes.etel_crmconfigurationid != undefined) {
            if (configRecord[0].attributes.etel_value != null &&
                configRecord[0].attributes.etel_value != undefined) {
                configValue = configRecord[0].attributes.etel_value.value;
            }
        }
    }
    else {
        alert('Error: The Key ' + key + ' could not be found in AMX Configuration');
    }
    return configValue;
}