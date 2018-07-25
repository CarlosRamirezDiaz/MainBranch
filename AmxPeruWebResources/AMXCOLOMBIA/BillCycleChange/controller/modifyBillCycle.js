var customerId = null;
var customerReadService = "";
var customerBillCyclesReadService = "";
var psbCustomerReadServiceUrl = "";
var psbBillCyclesReadUrl = "";
var psbEocUrl = "";

//This function is used to pop up terms and conditions to the call center agent.
//If accepted it will create a new bill cycle record else it will navigate to update customer form
function onModifyClick() {
    var titleName = "Bill Cycle Change";
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
                    createBillCycleChange();
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
}

//This function is used to create bill cycle change record.
function createBillCycleChange() {
    var isBlackListed = false;
    var isDateValidated = true;
    var contactId = parent.Xrm.Page.data.entity.getId().replace("{", "").replace("}", "");
    var entityName = "amx_bibillcyclechanges";

    //validateBlackListStatus(contactId, function (response) {
    // isBlackListed = response;
    //});
    dateValidation(function (response) {
        isDateValidated = response;
    });
    if (parent.Xrm.Page.ui.getFormType() == 2) { //&& isDateValidated && !isBlackListed) {
        var billingAccount = {};
        if (parent.Xrm.Page.getAttribute("etel_blackliststatuscode").getValue() != null)
            billingAccount["amx_blackliststatus"] = parent.Xrm.Page.getAttribute("etel_blackliststatuscode").getValue();

        if (parent.Xrm.Page.getAttribute("fullname").getValue() != null)
            billingAccount["amx_name"] = "Bill Cycle Change by " + parent.Xrm.Page.getAttribute("fullname").getValue();

        if (parent.Xrm.Page.getAttribute("etel_externalid").getValue() != null)
            billingAccount["amx_customerid"] = parent.Xrm.Page.getAttribute("etel_externalid").getValue();

        billingAccount["amx_Customer@odata.bind"] = "/contacts(" + contactId + ")";

        AMX.COMMON.CreateEntiyWebApi(entityName, billingAccount, function (ID) {
            var options = { openInNewWindow: true };
            parent.Xrm.Utility.openEntityForm("amx_bibillcyclechange", ID, null, options);
        },
            function (error) {
                parent.Xrm.Utility.alertDialog(error);
            }, false);
    }
}

//This function is used to set the source url to IFrame.
function onLoadBillCycle() {
    var url = Xrm.Page.context.getClientUrl() + "/WebResources/amx_/BillCycleChange/template/ModifyBillCycle.htm";
    Xrm.Page.getControl("IFRAME_BillCycleModification").setSrc(url);
}

//This function is used to validate the blacklisted customer based on contact Id.
function validateBlackListStatus(contactId, callBack) {
    var query = "etel_creditprofiles?$filter=etel_individualid/contactid eq " + contactId + "&$orderby=createdon desc";
    AMX.COMMON.RetrieveMultipleWebApi(query, function (response) {
        if (response.value.length > 0) {
            if (response.value[0].etel_creditscore != "" && response.value[0].etel_creditscore != undefined) {
                if (parseInt(response.value[0].etel_creditscore) <= 50) {
                    parent.Xrm.Utility.alertDialog("Customer is Blacklisted");
                    parent.Xrm.Page.getAttribute("etel_blackliststatuscode").setValue(831260002);
                    callBack(true);
                }
            }
            else if (response.value[0].etel_creditscore == null) {
                parent.Xrm.Utility.alertDialog("Customer is Blacklisted");
                parent.Xrm.Page.getAttribute("etel_blackliststatuscode").setValue(831260002);
                callBack(true);
            }
        }
    }, function (error) {
        parent.Xrm.Utility.alertDialog(error);
    }, false);
}

//This function is used to close the bill cycle record.
function updateBillCycleStatus() {
    if (parent.Xrm.Page.getAttribute("amx_description").getValue() != null && parent.Xrm.Page.getAttribute("amx_description").getValue() != "") {
        var setStateRequest = {};
        setStateRequest.statuscode = 173800000;
        setStateRequest.statecode = 1;
        var webApiEntityName = "amx_bibillcyclechanges";
        var webApiEntityId = parent.Xrm.Page.data.entity.getId();

        AMX.COMMON.UpdateEntityWebApi(webApiEntityName, webApiEntityId, setStateRequest, function (response) {
            setTimeout(function () {
                if (parent.opener != undefined)
                    window.parent.close();
                else
                    Xrm.Page.ui.close();
            }, 4000);
        },
            function (error) {
                parent.Xrm.Utility.alertDialog(error);
            }, false);
    }
}

//This function performs the validation whether there is any 
//pervious bill cycle change record exist for the customer in the last 30 days.
function dateValidation(callBack) {
    var contactId = parent.Xrm.Page.data.entity.getId().replace("{", "").replace("}", "");
    var query = "amx_bibillcyclechanges?$filter=amx_Customer/contactid eq " + contactId + "&$orderby=createdon desc";
    AMX.COMMON.RetrieveMultipleWebApi(query, function (response) {
        if (response.value.length > 0) {
            if (response.value[0].createdon != "" && response.value[0].createdon != undefined) {
                var prevBillDate = response.value[0].createdon;
                var currentDate = new Date();
                var days = date_diff_indays(prevBillDate);
                if (days <= 30) {
                    callBack(false);
                }
            }
        }
    }, function (error) {
        parent.Xrm.Utility.alertDialog(error);
    }, false);
}

//Generic method to calculate the difference between two dates.
var date_diff_indays = function (date1) {
    var prevBillDate = new Date(date1);
    var currentDate = new Date();
    return Math.floor((Date.UTC(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate()) - Date.UTC(prevBillDate.getFullYear(), prevBillDate.getMonth(), prevBillDate.getDate())) / (1000 * 60 * 60 * 24));
}

//This function will call the BSCS Api to fetch the list of bill cycles.
function getBillCycles(callBack) {
    var partyType = "";
    var readAll = "";
    var workflowBillCycleInput;

    workflowBillCycleInput = {
        "BillCycleReadRequest":
        {
            "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle.AmxCoBillCycleReadServiceRequest,AmxPeruPSBActivities",
            "partyType": "C",
            "readAll": false
        },
        "HostUrl": customerBillCyclesReadService
    };

    AMX.COMMON.CallPSBWorflow("POST", psbBillCyclesReadUrl, workflowBillCycleInput, function (data) {
        if (data) {
            if (data.Output.BillCycleReadResponse != undefined && data.Output.BillCycleReadResponse != "") {
                callBack(data.Output.BillCycleReadResponse);
            }
        }
    }, function (error) {
        callBack(error);
    }, false);
}

//This function is used to disable the html controls.
function enableOrDisableFields() {
    $("#currentbillcycle").prop("disabled", "disabled");
    $("#selectbillcycle").prop("disabled", "disabled");
    $("#billcycledetails").prop("disabled", "disabled");
    $("#modifybillcycle").prop("disabled", "disabled");
}

//This function is used to fetch the configuration data based on the key values.
function getCrmConfigurations(key1, key2, key3, key4, key5) {
    var query = "etel_crmconfigurations?$filter=etel_name eq '" + key1 + "' or etel_name eq '" + key2 + "' or etel_name eq '" + key3 + "' or etel_name eq '" + key4 + "' or etel_name eq '" + key5 + "'";
    AMX.COMMON.RetrieveMultipleWebApi(query, function (response) {
        for (var i = 0; i < response.value.length; i++) {
            if (response.value[i].etel_name == "UrlCustomerReadService")
                customerReadService = response.value[i].etel_value;
            if (response.value[i].etel_name == "UrlBillCycleReadService")
                customerBillCyclesReadService = response.value[i].etel_value;
            if (response.value[i].etel_name == "AmxCoGetCustomerBillAccounts_URL")
                psbCustomerReadServiceUrl = response.value[i].etel_value;
            if (response.value[i].etel_name == "AmxCoBillCycleChange_URL")
                psbBillCyclesReadUrl = response.value[i].etel_value;
            if (response.value[i].etel_name == "AmxCoSubmitBillCycleChangeToEOC_URL")
                psbEocUrl = response.value[i].etel_value;
        }
    }, function (error) {
        parent.Xrm.Utility.alertDialog(error);
    }, false);
}

//This function is used to submit the bill cycle change request to EOC.
function modifyBillCycle() {
    var type = "";
    var reference = "";
    var currentBillCycleName = $("#currentbillcycle").val();
    var currentBillCycleValue = $("#currentbillcycle")[0].name;
    var selectedBillCycleName = $("#selectbillcycle").find('option:selected').text();
    var selectedBillCycleValue = $("#selectbillcycle").find('option:selected').val().split('|')[0];
    var requestedCompletionDate = "";
    var biLogCustomerId = null;
    var biLogSubject = "Modify Bill Cycle";
    var biLogDescription = "Bill Cycle Modified successfully";
    var biLogChannel = "Call Center";
    var biLogBiHeaderGuid = "";
    var biLogLoginUserId = parent.Xrm.Page.context.getUserId().replace("{", "").replace("}", "");
    var biLogBillCycleId = parent.Xrm.Page.data.entity.getId().replace("{", "").replace("}", "");
    if (parent.Xrm.Page.getAttribute("amx_customer").getValue() != null && parent.Xrm.Page.getAttribute("amx_customer").getValue() != undefined)
        biLogCustomerId = parent.Xrm.Page.getAttribute("amx_customer").getValue()[0].id;
    var createdDate = new Date();
    createdDate = createdDate.toLocaleString();
    var workflowEOCInput;

    workflowEOCInput = {
        "BillCycleChangeEOCRequest":
        {
            "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle.BillCycleChangeEOCRequest,AmxPeruPSBActivities",
            "relatedEntities": {
                "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle.RelatedEntity,AmxPeruPSBActivities",
                "type": type,
                "reference": reference,
            },
            "relatedParties": {
                "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle.RelatedParty, AmxPeruPSBActivities",
                "role": "Customer",
                "reference": customerId
            },
            "orderItems": {
                "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle.OrderItems, AmxPeruPSBActivities",
                "item": {
                    "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle.Item, AmxPeruPSBActivities",
                    "orderType": "CustomerChangeOrder",
                    "action": "omCBIOBillCyclePOOIAction",
                    "attrs": {
                        "$values": [{
                            "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle.Attributes,AmxPeruPSBActivities",
                            "name": currentBillCycleName,
                            "value": currentBillCycleValue
                        },
                        {
                            "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle.Attributes, AmxPeruPSBActivities",
                            "name": selectedBillCycleName,
                            "value": selectedBillCycleValue
                        }]
                    }
                }
            },
            "createdDate": createdDate,
            "version": 1,
            "requestedCompletionDate": requestedCompletionDate,
            "description": "Add CCOI for change Bill Cycle",
            "run": true
        },
        "BILogSchemaRequest":
        {
            "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.BI_Log.BILogSchema, AmxPeruPSBActivities",
            "BiHeaderRecordGuid": biLogBiHeaderGuid,
            "LoggedInUserId": biLogLoginUserId,
            "Subject": biLogSubject,
            "Description": biLogDescription,
            "Channel": biLogChannel,
            "BillCycleChangeRecordGuid": biLogBillCycleId,
            "CustomerId": biLogCustomerId
        }
    };

    AMX.COMMON.CallPSBWorflow("POST", psbEocUrl, workflowEOCInput, function (data) {
        if (data != null && data != undefined && data != "") {
            if (data.Output.BillCycleChangeEOCResponse) {
                parent.Xrm.Utility.alertDialog("Request successfully submitted to EOC.");
                enableOrDisableFields();
            }
        }
    }, function (error) {
        parent.Xrm.Utility.alertDialog(error);
    }, false);
}

//This function will call BSCS Api to fetch the current bill cycle details of the customer.
function onLoadModifyBillCycle() {
    $("#billcycledetails").prop("disabled", "disabled");
    $("#currentbillcycle").prop("disabled", "disabled");
    $("#modifybillcycle").prop("disabled", "disabled");
    $("#currentbillcycledetails").prop("disabled", "disabled");

    if (parent.Xrm.Page.ui.getFormType() == 4)
        $("#selectbillcycle").prop("disabled", "disabled");

    getCrmConfigurations("UrlCustomerReadService", "UrlBillCycleReadService", "AmxCoGetCustomerBillAccounts_URL", "AmxCoBillCycleChange_URL", "AmxCoSubmitBillCycleChangeToEOC_URL");

    var csIdPub = parent.Xrm.Page.getAttribute("amx_customerid").getValue();
    var csID = null;
    var syncWithDb = "";

    var workflowCustomerReadRequestInput;
    workflowCustomerReadRequestInput = {
        "CustomerReadRequest":
        {
            "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle.AmxCoCustomerReadServiceRequest, AmxPeruPSBActivities",
            "csId": csID,
            "csIdPub": csIdPub,
            "syncWithDb": syncWithDb
        },
        "HostUrl": customerReadService
    };

    AMX.COMMON.CallPSBWorflow("POST", psbCustomerReadServiceUrl, workflowCustomerReadRequestInput, function (data) {
        if (data != null && data != undefined && data != "") {
            if (data.Output.CustomerReadResponse != undefined && data.Output.CustomerReadResponse != "") {
                var customerBillCycleId = $(data.Output.CustomerReadResponse).find('csbillcycle').text();
                var customerBillCycle = $(data.Output.CustomerReadResponse).find('csbillcycledesc').text();
                customerId = $(data.Output.CustomerReadResponse).find("csId").text();
                if (customerBillCycleId != "" && customerBillCycle != "" && customerId != "") {
                    $("#currentbillcycle")[0].name = customerBillCycleId;
                    $("#currentbillcycle").val(customerBillCycle);
                    getBillCycles(function (billCycles) {
                        if (billCycles != null) {
                            $(billCycles).find('item').each(function () {
                                var id = $(this).find('billcycle').text();
                                if (id != customerBillCycleId) {
                                    var billCycle = $(this).find('description').text();
                                    var bchRunDate = $(this).find('bchRunDate').text();
                                    $("#selectbillcycle").append("<option value=" + id + "|" + bchRunDate + ">" + billCycle + "</option>");
                                }
                                else {
                                    var currentBCCRunDate = $(this).find('bchRunDate').text();
                                    if (currentBCCRunDate != "") {
                                        var bccDate = new Date(currentBCCRunDate);
                                        var currentbccdetails = "Runs every " + bccDate.getDay().toString() + " day of the month";
                                        $("#currentbillcycledetails").val(currentbccdetails);
                                    }
                                }
                            });
                        }
                    });
                }
            }
        }
    }, function (error) {
        parent.Xrm.Utility.alertDialog(error);
    }, false)
}

//This function will trigger on change of selectbillcycle dropdown and will binds selected bill cycle details
function onChangeSelectBillCycle(control) {
    $("#billcycledetails").val('');
    $("#modifybillcycle").prop("disabled", false);
    if ($(control).find('option:selected').val() != "") {
        var bchRunDate = $(control).find('option:selected').val().split('|')[1];
        if (bchRunDate != "") {
            var bcDate = new Date(bchRunDate);
            var str = "Runs every " + bcDate.getDay().toString() + " day of the month";
            $("#billcycledetails").val(str);
        }
    }
}

