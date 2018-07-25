//angular.module('AppointmentList', [])
//angular.module('AccountSummary.Appointments', [])
angular.module('AccountSummaryTabbedViewApp', [])
    .controller('AppointmentCancelationreasonsController', ['$scope', '$http', '$rootScope',
        function ($scope, $http, $rootScope) {

            if (typeof $scope.scopeData === "undefined") {
                $scope.scopeData = {};
            }

            $scope.cancelAppointment = function () {
                if ($scope.etel_appointmentstatus != "Cancelado") {
                    //Validating Appointment Status--value--831260000,831260003,831260004,831260008 $scope.etel_appointmentstatus == "Visita Iniciada" || $scope.etel_appointmentstatus == "Activando"
                    if ($scope.etel_appointmentstatus == "Enrutando" || $scope.etel_appointmentstatus == "Abierta") {

                        //* getting the cancelation reason *//
                        var cancelation = document.getElementById("dropdown");
                        $scope.CancelationValue = cancelation.options[cancelation.selectedIndex].value;
                        $scope.CancelationName = cancelation.options[cancelation.selectedIndex].text;
                        $scope.Cancelationreason = $scope.CancelationValue + "-" + $scope.CancelationName;
                        //* getting the comments provided *//
                        $scope.CommentsText = document.getElementById("output").value;

                        var config = { withCredentials: true };

                        $scope.workflowStartInput = {
                            "cancelAppntRequest":
                            {
                                "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.CancelAppointment.AmxCancelAppointmentOSBRequest, AmxPeruPSBActivities",
                                "headerRequest": { "transactionId": "123456789", "system": "PRUEBA", "user": "YFONSECA", "password": "PRUEBA", "requestDate": "2018-01-02T14:20:45", "ipApplication": "PRUEBA", "traceabilityId": "PRUEBA" },
                                "dateOrder": "2017-11-15",
                                "commands": [{
                                    "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.CancelAppointment.Commands, AmxPeruPSBActivities",
                                    "externalId": $scope.etel_externalid,//"11DNA123",
                                    "appointment":
                                    {
                                        "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.CancelAppointment.Appointments, AmxPeruPSBActivities",
                                        "apptNumber": $scope.amx_appointmentnumber,//"cancelRequestFirstTry",//need dynamic value
                                        "workTypeLabel": "IN23",
                                        "timeSlot": $scope.amx_timeslot,
                                        "name": $scope.Customername,
                                        "properties": [
                                            {
                                                "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.CancelAppointment.Properties, AmxPeruPSBActivities",
                                                "attributeName": "XA_RazonDeCancelacion",
                                                "attributeValue": $scope.CancelationValue
                                            },
                                            {
                                                "$type": "AmxPeruPSBActivities.AMXCOLOMBIA.Model.CancelAppointment.Properties, AmxPeruPSBActivities",
                                                "attributeName": "XA_order_comments",
                                                "attributeValue": $scope.CommentsText
                                            }]
                                    }
                                }]
                            }
                        };


                        $http.post($scope.apiUrl + 'AmxCoAppointmentCancel', JSON.stringify($scope.workflowStartInput), config)
                            .success(function (result) {
                                if (result) {
                                    if (result.Output.cancelAppntResponse.commandsResponse[0].appointmentResponse.report[0].result == "OK") {
                                        var RecId = $scope.etel_appointmentlogid;
                                        //*Logic to update Confirmation status and Appointment status*//
                                        var Entity = {};

                                        Entity.etel_appointmentstatus = 831260002;
                                        //Entity.amx_confirmationstatus = 173800002;

                                        //*updating StatusReason field*//
                                        switch ($scope.Cancelationreason) {
                                            case "C02-Subscriber's request":
                                                Entity.statuscode = 100000000;
                                                break;
                                            case "C03-Technical breach":
                                                Entity.statuscode = 100000001;
                                                break;
                                            case "C04-Lack of Management Permits":
                                                Entity.statuscode = 100000002;
                                                break;
                                            case "C05-Massive Incident Still Open":
                                                Entity.statuscode = 100000003;
                                                break;
                                            case "C06-Lack of Materials / Equipment":
                                                Entity.statuscode = 100000004;
                                                break;
                                        }

                                        var req = new XMLHttpRequest();
                                        req.open("PATCH", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_appointmentlogs(" + RecId + ")", false);
                                        req.setRequestHeader("OData-MaxVersion", "4.0");
                                        req.setRequestHeader("OData-Version", "4.0");
                                        req.setRequestHeader("Accept", "application/json");
                                        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                                        req.onreadystatechange = function () {
                                            if (this.readyState === 4) {
                                                req.onreadystatechange = null;
                                                if (this.status === 204) {
                                                    $scope.notifyCancelAppESB();

                                                    //$scope.gridOptions.data.push($rootScope.appointmentListModel);

                                                } else {
                                                    Xrm.Utility.alertDialog(this.statusText);
                                                    var Returnvalue = "false";
                                                    Mscrm.Utilities.setReturnValue(Returnvalue);
                                                    closeWindow(true);
                                                }
                                            }
                                        };
                                        req.send(JSON.stringify(Entity));
                                    }
                                    else {
                                        alert("Bad Responce from OFSC");
                                    }

                                };
                            }).error(function (data, status, headers, config) {
                                alert((data.ExceptionMessage === undefined ?
                                    (data.data === undefined ? data :
                                        (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                                
                                var Returnvalue = "false";
                                Mscrm.Utilities.setReturnValue(Returnvalue);
                                closeWindow(true);
                            });


                    }
                    else {
                        alert(Translation_CancelAppointmentReasons.data.tWarningmessage);//Please select the correct Appointment
                        var Returnvalue = "false";
                        Mscrm.Utilities.setReturnValue(Returnvalue);
                        closeWindow(true);
                    }
                }
                else {
                    alert("Please note that you cannot cancel appointment which is already canceled.");
                    var Returnvalue = "false";
                    Mscrm.Utilities.setReturnValue(Returnvalue);
                    closeWindow(true);
                }
            }
            $scope.notifyCancelAppESB = function () {
                var config = { withCredentials: true };
                $scope.workflowStartInput = {
                    "workOrderId": $scope.workOrderId,//"1727272",
                    "appointmentNumber": $scope.amx_appointmentnumber,
                    "cancelDescription": $scope.CancelationName,
                    "cancelValue": $scope.CancelationValue
                };
                $http.post($scope.apiUrl + 'AmxCoNotifyCancelAppointment', JSON.stringify($scope.workflowStartInput), config)
                    .success(function (result) {
                        if (result) {
                            if (result.Output.Message = "Ok") {
                                alert(Translation_CancelAppointmentReasons.data.tSuccessmessage);//Appointment Cancelled Successfully.
                               
                                if ((($scope.amxperu_allowemail == "Allow") || ($scope.amxperu_allowsmsinstantmessaging == "Allow")) || (($scope.amxperu_allowemail == "Allow") && ($scope.amxperu_allowsmsinstantmessaging == "Allow")))
                                {
                                  $scope.torreDeControl();
                                }
                        else {
                                    alert("Customer did not opt for any notifications");
                                    var Returnvalue = "false";
                                    Mscrm.Utilities.setReturnValue(Returnvalue);
                                    closeWindow(true);

                                }
                                
                            }
                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                        var Returnvalue = "false";
                        Mscrm.Utilities.setReturnValue(Returnvalue);
                        closeWindow(true);
                    });
            }
            $scope.torreDeControl = function () {
                //Sending Both SMS and Email Notifications
                if (($scope.Email != null) && ($scope.Mobile != null))
                {
                    var config = { withCredentials: true };
                    $scope.workflowStartInput = {
                        "request": {
                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest, AmxPeruPSBActivities",
                            "pushType": "SINGLE",//hardcoded
                            "typeCostumer": $scope.CustomerId,//customerId
                            "messageBox": [
                                {
                                    "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxExt, AmxPeruPSBActivities",
                                    "messageChannel": "SMS",
                                    "messageBox": [
                                        {
                                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxInt, AmxPeruPSBActivities",
                                            "customerId": $scope.CustomerId,//customerId
                                            "customerBox": $scope.Mobile//phn number11111
                                        }
                                    ]
                                },
                                {
                                    "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxExt, AmxPeruPSBActivities",
                                    "messageChannel": "SMTP",
                                    "messageBox": [
                                        {
                                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxInt, AmxPeruPSBActivities",
                                            "customerId": $scope.CustomerId, //customerId
                                            "customerBox": $scope.Email //EmailIDhelder@ericsson.com
                                        }
                                    ]
                                }
                            ],
                            "profileId": ["SMTP_FS_TCRM1", "SMS_FS_TCRM1"],
                            "communicationType": ["REGULATORIO"],
                            "communicationOrigin": "TCRM",
                            "deliveryReceipts": "NO",
                            "contentType": "MESSAGE",
                            "messageContent": $scope.amxperu_templatetext
                        }
                    }

                    $http.post($scope.apiUrl + 'AmxCoTorreDeControl', JSON.stringify($scope.workflowStartInput), config)
                        .success(function (result) {
                            if (result) {
                                if (result.Output.response.isValid = "true") {
                                    $scope.response = result.Output.response.message;
                                    if ($scope.response != null)
                                    {
                                        alert("Customer Notifications sent successfully");
                                        $scope.createBiLog();
                                        var Returnvalue = "false";
                                        Mscrm.Utilities.setReturnValue(Returnvalue);
                                        closeWindow(true);
                                    }
                                    else {
                                        alert("Notifications are not sent due to an error in the TorreDeControl");
                                        var Returnvalue = "false";
                                        Mscrm.Utilities.setReturnValue(Returnvalue);
                                        closeWindow(true);
                                    }
                                }
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                            var Returnvalue = "false";
                            Mscrm.Utilities.setReturnValue(Returnvalue);
                            closeWindow(true);
                        });

                }
                 //Sending Email Notifications
                if (($scope.Email != null) && ($scope.Mobile == null)) {
                    var config = { withCredentials: true };
                    $scope.workflowStartInput = {
                        "request": {
                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest, AmxPeruPSBActivities",
                            "pushType": "SINGLE",//hardcoded
                            "typeCostumer": $scope.CustomerId,//customerId
                            "messageBox": [
                                {
                                    "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxExt, AmxPeruPSBActivities",
                                    "messageChannel": "SMTP",
                                    "messageBox": [
                                        {
                                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxInt, AmxPeruPSBActivities",
                                            "customerId": $scope.CustomerId, //customerId
                                            "customerBox": $scope.Email //EmailIDhelder@ericsson.com
                                        }
                                    ]
                                }
                            ],
                            "profileId": ["SMTP_FS_TCRM1", "SMS_FS_TCRM1"],
                            "communicationType": ["REGULATORIO"],
                            "communicationOrigin": "TCRM",
                            "deliveryReceipts": "NO",
                            "contentType": "MESSAGE",
                            "messageContent": $scope.amxperu_templatetext
                        }
                    }
                    $http.post($scope.apiUrl + 'AmxCoTorreDeControl', JSON.stringify($scope.workflowStartInput), config)
                        .success(function (result) {
                            if (result) {
                                if (result.Output.response.isValid = "true") {
                                    $scope.response = result.Output.response.message;
                                    if ($scope.response != null) {
                                        alert("Customer Email Notifications sent successfully");
                                        $scope.createBiLog();
                                        var Returnvalue = "false";
                                        Mscrm.Utilities.setReturnValue(Returnvalue);
                                        closeWindow(true);
                                    }
                                    else {
                                        alert("Notifications are not sent due to an error in the TorreDeControl");
                                        var Returnvalue = "false";
                                        Mscrm.Utilities.setReturnValue(Returnvalue);
                                        closeWindow(true);
                                    }
                                }
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                            var Returnvalue = "false";
                            Mscrm.Utilities.setReturnValue(Returnvalue);
                            closeWindow(true);
                        });
                }
                 //Sending SMS Notifications
                if (($scope.Mobile != null) && ($scope.Email == null))
                {
                    var config = { withCredentials: true };
                    $scope.workflowStartInput = {
                        "request": {
                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest, AmxPeruPSBActivities",
                            "pushType": "SINGLE",//hardcoded
                            "typeCostumer": $scope.CustomerId,//customerId
                            "messageBox": [
                                {
                                    "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxExt, AmxPeruPSBActivities",
                                    "messageChannel": "SMS",
                                    "messageBox": [
                                        {
                                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxInt, AmxPeruPSBActivities",
                                            "customerId": $scope.CustomerId,//customerId
                                            "customerBox": $scope.Mobile//phn number11111
                                        }
                                    ]
                                }
                            ],
                            "profileId": ["SMTP_FS_TCRM1", "SMS_FS_TCRM1"],
                            "communicationType": ["REGULATORIO"],
                            "communicationOrigin": "TCRM",
                            "deliveryReceipts": "NO",
                            "contentType": "MESSAGE",
                            "messageContent": $scope.amxperu_templatetext
                        }
                    }

                    $http.post($scope.apiUrl + 'AmxCoTorreDeControl', JSON.stringify($scope.workflowStartInput), config)
                        .success(function (result) {
                            if (result) {
                                if (result.Output.response.isValid = "true") {
                                    $scope.response = result.Output.response.message;
                                    if ($scope.response != null) {
                                        alert("Customer SMS Notifications sent successfully");
                                        $scope.createBiLog();
                                        var Returnvalue = "false";
                                        Mscrm.Utilities.setReturnValue(Returnvalue);
                                        closeWindow(true);
                                    }
                                    else {
                                        alert("Notifications are not sent due to an error in the TorreDeControl");
                                        var Returnvalue = "false";
                                        Mscrm.Utilities.setReturnValue(Returnvalue);
                                        closeWindow(true);
                                    }
                                }
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                            var Returnvalue = "false";
                            Mscrm.Utilities.setReturnValue(Returnvalue);
                            closeWindow(true);
                        });
                }
                //else {
                //    alert("Customer did not provide either Email or Phone number");
                //    var Returnvalue = "false";
                //    Mscrm.Utilities.setReturnValue(Returnvalue);
                //    closeWindow(true);
                //}
            }
            //Get SMS Template for CancelledAppointment
            $scope.getCancelledAppointmentSMSTemplate = function (operation)
            {
                var req = new XMLHttpRequest();
                req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/amxperu_smstemplates?$select=amxperu_templatetext&$filter=amxperu_name eq " + "'" +operation+"'", true);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 200) {
                            var results = JSON.parse(this.response);
                            if( results.value.length != 0) {
                                var amxperu_templatetext = results.value[0]["amxperu_templatetext"];
                                $scope.amxperu_templatetext = amxperu_templatetext.replace("{{etel_appointmentlog:amx_appointmentnumber}}", $scope.amx_appointmentnumber);
                            }
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send();
            }
            //Get Customer Contact Information
            $scope.getContactInformation = function ()
            {
                var req = new XMLHttpRequest();
                req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/amx_customercontactinformations?$select=amx_email,amx_name,amx_phoneno&$filter=_amx_individualcustomerid_value eq " + $scope.CustomerId, false);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 200) {
                            var results = JSON.parse(this.response);
                            if (results.value.length != 0) {
                                $scope.Email = results.value[0]["amx_email"];
                                $scope.Mobile = results.value[0]["amx_phoneno"];
                                var amx_name = results.value[0]["amx_name"];
                            }
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send();
            }
            //Get Customer Contact Allow Permissions
            $scope.getCustomerContactAllowPermissions = function()
            {
                var req = new XMLHttpRequest();
                req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/contacts?$select=amxperu_allowemail,amxperu_allowphone,amxperu_allowsmsinstantmessaging&$filter=contactid eq " +$scope.CustomerId, false);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 200) {
                            var results = JSON.parse(this.response);
                            if( results.value.length != 0 ) {
                                $scope.amxperu_allowemail = results.value[0]["amxperu_allowemail@OData.Community.Display.V1.FormattedValue"];
                                $scope.amxperu_allowphone = results.value[0]["amxperu_allowphone@OData.Community.Display.V1.FormattedValue"];
                                $scope.amxperu_allowsmsinstantmessaging = results.value[0]["amxperu_allowsmsinstantmessaging@OData.Community.Display.V1.FormattedValue"];
                               
                            }
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send();
            }
            //BI Log Creation for Customer Notifications
            $scope.createBiLog = function () {
                var entity = {};
                entity.amx_name = "Appointment Cancelled" + "-" + $scope.amx_appointmentnumber;
                entity.amx_notificationtemplate = $scope.amxperu_templatetext;
                AMX.COMMON.CreateEntiyWebApi("amx_bicustomernotificationses", entity, function (sData) {
                    var entityId = sData;
                    var entity = {};
                    entity.subject = "Appointment Cancelled" + "-" + $scope.amx_appointmentnumber;
                    entity.etel_description = "Appointment Cancelled" + "-" + $scope.amx_appointmentnumber;
                    entity["regardingobjectid_amx_bicustomernotifications@odata.bind"] = "/amx_bicustomernotificationses(" + entityId + ")";
                    entity["etel_individualcustomerid_etel_bi_log@odata.bind"] = "/contacts(" + $scope.CustomerId + ")";
                    var currentDateTime = new Date();
                    entity.actualstart = currentDateTime;
                    entity.actualend = currentDateTime;
                    //setting customer field on Bi Log 
                    var activityparties = [];
                    var to = {};
                    to["partyid_contact@odata.bind"] = "/contacts(" + $scope.CustomerId + ")";
                    to["participationtypemask"] = 11;
                    activityparties.push(to);
                    entity["etel_bi_log_activity_parties"] = activityparties;
                    AMX.COMMON.CreateEntiyWebApi("etel_bi_logs", entity, function (oData) {
                        var entityId = oData;

                    },
                        function (eData) { parent.Xrm.Utility.alertDialog(eData) }, false);
                },
                    function (eData) { parent.Xrm.Utility.alertDialog(eData) }, false);
            }
            $scope.RefreshParent = function () {
                if (window.opener != null && !Window.opener.closed) {
                    window.open.location.reload();
                }
            }
            $scope.getDataParam = function () {

                var vals = new Array();
                var messages = new Array();
                if (location.search != "") {

                    vals = location.search.substr(1).split("=");
                    for (var i in vals) {
                        if (vals[0].toLowerCase() == "data") {

                            var title = decodeURIComponent(vals[1]).split("&");
                            messages = decodeURIComponent(title[0]).split(",");

                            $scope.etel_appointmentstatus = messages[0];
                            $scope.etel_externalid = messages[1];
                            $scope.etel_name = messages[2];
                            $scope.etel_appointmentdate = messages[3];
                            $scope.amx_timeslot = messages[4];
                            $scope.amx_workflowordersubtype = messages[5];
                            $scope.etel_appointmentlogid = messages[6];
                            // $scope._amx_addressid_value = messages[7];
                            $scope.amx_confirmationstatus = messages[7];
                            $scope.amx_appointmentnumber = messages[8];
                            $scope.Customername = messages[9];
                            $scope.workOrderId = messages[10];
                            $scope.apiUrl = messages[11];
                            $scope.createdon = messages[12];
                            $scope.etel_appointmentclosedate = messages[13];
                            $scope.amx_specialconditions = messages[14];
                            $scope.CustomerId = messages[15];
                        }
                    }

                }

            }
            //*Function to transalate*//
            Translation_CancelAppointmentReasons = {
                data: null,
                GetData: function () {
                    var formId = "CancelAppointmentReasons";
                    if (Translation_CancelAppointmentReasons.data == null) {
                        Translation_CancelAppointmentReasons.data = GetTranslationData(formId);
                    }
                    return Translation_CancelAppointmentReasons.data;
                }

            }
            
            var initiate = function () {
                $scope.getDataParam();
                var operation = "cancelledAppointment";
                $scope.getCancelledAppointmentSMSTemplate(operation);
                $scope.getCustomerContactAllowPermissions();
                $scope.getContactInformation();
                //if ((($scope.amxperu_allowemail == "Allow") || ($scope.amxperu_allowsmsinstantmessaging == "Allow" )) || (($scope.amxperu_allowemail == "Allow") && ($scope.amxperu_allowsmsinstantmessaging == "Allow"))) {
                //    $scope.torreDeControl();
                //}
                //else {
                //    alert("Customer did not opt for any notifications")
                //}
                Translation_CancelAppointmentReasons.GetData();
                                
                };

            initiate();
        }]);
