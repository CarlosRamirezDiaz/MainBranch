//angular.module('AppointmentList', [])
angular.module('AccountSummary.Appointments', [])
    .controller('AppointmentListController', ['$scope', '$rootScope', '$location', '$http', '$timeout', '$interval', 'uiGridConstants',
        function ($scope, $rootScope, $location, $http, $timeout, $interval, uiGridConstants, uiGridGroupingConstants) {

            if (typeof $scope.scopeData === "undefined") {
                $scope.scopeData = {};
            }


            $scope.gridOptions = {};
            $scope.gridOptions.selectedItems = [];
            $scope.AppointmentArray = [];
            //Retrieve Appointments
            function Appointmentresult() {
                debugger;
                var Customer = Xrm.Page.data.entity.getId();
                var CustomerId = Customer.substr(1, 36);
                $scope.CustomerId = CustomerId;
                $scope.BindGrid([]);
                var city = new Array();
                var req = new XMLHttpRequest();
                //req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_appointmentlogs?$select=createdon,etel_name,etel_appointmentdate,etel_externalid,amx_workflowordersubtype,amx_confirmationstatus,etel_appointmentstatus,etel_appointmentlogid,_amx_addressid_value", false);
                req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_appointmentlogs?$select=amx_confirmationstatus,amx_workflowordersubtype,createdon,etel_appointmentdate,etel_appointmentclosedate,etel_appointmentlogid,etel_appointmentstatus,etel_externalid,_amx_addressid_value,etel_name,amx_timeslot,amx_appointmentnumber,amx_workorderid,amx_technicianid,amx_specialconditions,amx_thirdpersonassigned,amx_thirdpersoncontactname,amx_thirdpersoncontactphonenumber1,amx_thirdpersoncontactphonenumber2,amx_thirdpersoncontactemail1,amx_thirdpersoncontactemail2,statuscode&$filter=_etel_individualcustomerid_value eq " + CustomerId + "", false);
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
                            $scope.myresults = [];

                            //$rootScope.appointmentListModel = results;
                            //$scope.BindGrid($rootScope.appointmentListModel);
                            if (results != undefined) {
                                for (var i = 0; i < results.value.length; i++) {
                                    $scope.myresults.push({
                                        "createdon": results.value[i]['createdon@OData.Community.Display.V1.FormattedValue'].substr(0, 10),
                                        "etel_name": results.value[i]['etel_name'],
                                        "amx_timeslot": results.value[i]['amx_timeslot'],
                                        "etel_appointmentdate": results.value[i]['etel_appointmentdate@OData.Community.Display.V1.FormattedValue'].substr(0, 10),
                                        "etel_appointmentclosedate": results.value[i]['etel_appointmentclosedate@OData.Community.Display.V1.FormattedValue'].substr(0, 10),
                                        "amx_workflowordersubtype": results.value[i]['amx_workflowordersubtype'],
                                        "amx_confirmationstatus": results.value[i]['amx_confirmationstatus@OData.Community.Display.V1.FormattedValue'],
                                        "etel_appointmentstatus": results.value[i]['etel_appointmentstatus@OData.Community.Display.V1.FormattedValue'],
                                        "statuscode": results.value[i]['statuscode@OData.Community.Display.V1.FormattedValue'],
                                        "etel_externalid": results.value[i]['etel_externalid'],
                                        "amx_appointmentnumber": results.value[i]['amx_appointmentnumber'],
                                        "_amx_addressid_value": results.value[i]['_amx_addressid_value@OData.Community.Display.V1.FormattedValue'],
                                        "etel_appointmentlogid": results.value[i]['etel_appointmentlogid'],
                                        "amx_workorderid": results.value[i]['amx_workorderid'],
                                        "amx_specialconditions": results.value[i]['amx_specialconditions'],
                                        "amx_thirdpersoncontactname": results.value[i]['amx_thirdpersoncontactname'],
                                        "amx_thirdpersoncontactphonenumber1": results.value[i]['amx_thirdpersoncontactphonenumber1'],
                                        "amx_thirdpersoncontactphonenumber2": results.value[i]['amx_thirdpersoncontactphonenumber2'],
                                        "amx_thirdpersoncontactemail1": results.value[i]['amx_thirdpersoncontactemail1'],
                                        "amx_thirdpersoncontactemail2": results.value[i]['amx_thirdpersoncontactemail2'],
                                        "amx_technicianid": results.value[i]['amx_technicianid'],
                                        "amx_thirdpersonassigned": results.value[i]['amx_thirdpersonassigned']
                                    });

                                }
                            }
                            $rootScope.appointmentListModel = $scope.myresults;

                            $scope.BindGrid($rootScope.appointmentListModel);
                            //$scope.gridApi.grid.refresh();
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send();
            }

            $scope.BindGrid = function (appntdata) {

                for (var i = 0; i < appntdata.length; i++) {
                    appntdata[i].id = i;
                }

                $scope.gridOptions.data = appntdata;
                $scope.appointmentTranlations = GetTranslationData("AppointmentList");
                $scope.gridOptions.columnDefs = [
                    { name: $scope.appointmentTranlations.tCreatedOn, field: 'createdon', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, visible: false, width: 120 },//CreatedOn
                    { name: $scope.appointmentTranlations.tAppointmentNo, field: 'etel_name', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, cellTemplate: '<div class="ui-grid-cell-contents" ><a href="#" title="{{COL_FIELD}}" ng-click="grid.appScope.OnClickAppointment(row.entity)"><span>{{COL_FIELD}}</span></a></div>', width: 150 },//AppointmentNo
                    { name: $scope.appointmentTranlations.tAppointmentDate, field: 'etel_appointmentdate', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 140 },//Appointment Date
                    { name: 'etel_appointmentclosedate', field: 'etel_appointmentclosedate', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 140 },//Appointment Close Date
                    { name: $scope.appointmentTranlations.tExternalId, field: 'etel_externalid', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 140 },//ExternalId
                    { name: $scope.appointmentTranlations.tAppointmentNumber, field: 'amx_appointmentnumber', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, visible: false, width: 140 },//Appointment Number
                    { name: $scope.appointmentTranlations.tTimeslot, field: 'amx_timeslot', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 140 },//Timeslot
                    { name: $scope.appointmentTranlations.tWorkorderid, field: 'amx_workorderid', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, visible: false, width: 140 },//Workorderid
                    { name: $scope.appointmentTranlations.tOTType, field: 'amx_workflowordersubtype', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 80 },//OT Type
                    { name: $scope.appointmentTranlations.tConfirmationStatus, field: 'amx_confirmationstatus', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 140 },//Confirmation Status
                    { name: $scope.appointmentTranlations.tStatus, field: 'etel_appointmentstatus', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 80 },//Status
                    { name: $scope.appointmentTranlations.tStatusReason, field: 'statuscode', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 160 },//Status Reason
                    { name: $scope.appointmentTranlations.tAddress, field: '_amx_addressid_value', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 120 },//Address
                    { name: 'ThirdPersonAssigned', field: 'amx_thirdpersonassigned', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 120 },//Third Person Assigned
                    { name: 'amx_specialconditions', field: 'amx_specialconditions', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, visible: false, width: 80 },//Special Conditions
                    { name: 'amx_thirdpersoncontactname', field: 'amx_thirdpersoncontactname', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, visible: false, width: 80 },//thirdpersoncontactname,
                    { name: 'amx_thirdpersoncontactphonenumber1', field: 'amx_thirdpersoncontactphonenumber1', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, visible: false, width: 80 },//thirdpersoncontactphonenumber1,
                    { name: 'amx_thirdpersoncontactphonenumber2', field: 'amx_thirdpersoncontactphonenumber2', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, visible: false, width: 80 },//thirdpersoncontactphonenumber2,
                    { name: 'amx_thirdpersoncontactemail1', field: 'amx_thirdpersoncontactemail1', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, visible: false, width: 80 },//thirdpersoncontactemail1,
                    { name: 'amx_thirdpersoncontactemail2', field: 'amx_thirdpersoncontactemail2', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, visible: false, width: 80 },//thirdpersoncontactemail2,
                    { name: $scope.appointmentTranlations.tTechnicianId, field: 'amx_technicianid', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 120 },//TechnicianId
                    { name: $scope.appointmentTranlations.tAction, cellTemplate: '<button ng-click="grid.appScope.ConfirmAppointment(row.entity)">Confirm</button> <button ng-click="grid.appScope.CancelAppointment(row.entity)">Cancel</button> <button ng-click="">Reschedule</button>', enableColumnMenu: false, width: 250 },//Action
                    { name: 'Id', field: 'etel_appointmentlogid', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, visible: false, width: 80 }

                    //{ name: $scope.scopeData.translations.tDigitalSignature, field: 'DigitalSignature', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 150 },
                    //{ name: $scope.scopeData.translations.tCreatedOn, field: 'CreatedOn', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 150 },
                    //{ name: $scope.scopeData.translations.tApprovalDate, field: 'ApprovalDate', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 150 },
                    //{ name: $scope.scopeData.translations.tChannel, field: 'Channel', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 150 },
                    //{ name: $scope.scopeData.translations.tPdv, field: 'PDV', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 150 },
                    //{ name: $scope.scopeData.translations.tReason, field: 'Reason', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 150 }


                ];
                //$scope.gridOptions.columnDefs.column[7].hide = true;
                $scope.gridOptions.enableColumnResizing = true;
                $scope.gridOptions.enableHorizontalScrollbar = true;//uiGridConstants.scrollbars.ALWAYS;
                $scope.gridOptions.enableFiltering = false;
                $scope.gridOptions.enableGridMenu = false;
                $scope.gridOptions.showGridFooter = false;
                $scope.gridOptions.enablePinning = false;
                $scope.gridOptions.flatEntityAccess = false;
                $scope.gridOptions.showColumnFooter = false;
                $scope.gridOptions.fastWatch = true;
                $scope.gridOptions.enableRowSelection = true;
                $scope.gridOptions.enableRowHeaderSelection = false;
                $scope.gridOptions.multiSelect = false;
                $scope.gridOptions.modifierKeysToMultiSelect = false;
                $scope.gridOptions.noUnselect = false;
                $scope.gridOptions.enablePaginationControls = false;
                $scope.gridOptions.paginationPageSize = 4;
                $scope.loading = false;
                $scope.gridOptions.rowIdentity = function (row) {
                    return row.id;
                };
                $scope.gridOptions.getRowIdentity = function (row) {
                    return row.id;
                };

                $scope.filter = function () {
                    $scope.gridApi.grid.refresh();
                };
                
            };

            //$scope.gridOptions.onRegisterApi = function (gridApi) {
            //    $scope.gridApi = gridApi;
            //    $scope.gridApi.grid.registerRowsProcessor($scope.singleFilter, 200);
            //};
            $scope.gridOptions.onRegisterApi = function (gridApi) {
                $scope.gridApi = gridApi;
                $scope.gridApi.grid.registerRowsProcessor($scope.singleFilter, 200);
                $scope.gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                    $scope.gridOptions.selectedRow = [
                        {
                            RowData: row.entity
                        }
                    ];
                    if (row.isSelected) {
                        $scope.gridOptions.selectedItems.push($scope.gridOptions.selectedRow);
                    }
                    else {
                        $scope.gridOptions.selectedItems.splice($scope.gridOptions.selectedRow);
                    }
                });
            };
            $scope.gridOptions.enableColumnResizing = true;
            $scope.gridOptions.enableHorizontalScrollbar = true;//uiGridConstants.scrollbars.ALWAYS;
            $scope.gridOptions.enableFiltering = false;
            $scope.gridOptions.enableGridMenu = false;
            $scope.gridOptions.showGridFooter = false;
            $scope.gridOptions.enablePinning = false;
            $scope.gridOptions.flatEntityAccess = false;
            $scope.gridOptions.showColumnFooter = false;
            $scope.gridOptions.fastWatch = true;
            $scope.gridOptions.enableRowSelection = true;
            $scope.gridOptions.enableRowHeaderSelection = false;
            $scope.gridOptions.multiSelect = false;
            $scope.gridOptions.modifierKeysToMultiSelect = false;
            $scope.gridOptions.noUnselect = false;
            $scope.gridOptions.enablePaginationControls = false;
            $scope.gridOptions.paginationPageSize = 4;
            $scope.gridOptions.rowIdentity = function (row) {
                return row.id;
            };
            $scope.gridOptions.getRowIdentity = function (row) {
                return row.id;
            };

            $scope.filter = function () {
                $scope.gridApi.grid.refresh();
            };

            var refresh = function () {
                $scope.refresh = true;
                $timeout(function () {
                    $scope.refresh = false;
                }, 0);
            };

            $scope.OnClickAppointment = function (Appointment) {
                var Customername = Xrm.Page.getAttribute("fullname").getValue();
                var ArrayObj = [];
                ArrayObj[0] = Appointment.etel_appointmentstatus;
                ArrayObj[1] = Appointment.etel_externalid;
                ArrayObj[2] = Appointment.etel_name
                ArrayObj[3] = Appointment.etel_appointmentdate;
                ArrayObj[4] = Appointment.amx_timeslot;
                ArrayObj[5] = Appointment.amx_workflowordersubtype;
                ArrayObj[6] = Appointment.etel_appointmentlogid;
                //ArrayObj[7] = Appointment._amx_addressid_value;
                ArrayObj[7] = Appointment.amx_confirmationstatus;
                ArrayObj[8] = Appointment.amx_appointmentnumber;
                ArrayObj[9] = Customername;
                ArrayObj[10] = Appointment.amx_workorderid;
                ArrayObj[11] = window.definitions.psbUrl;
                ArrayObj[12] = Appointment.createdon;
                ArrayObj[13] = Appointment.etel_appointmentclosedate;
                ArrayObj[14] = Appointment.amx_specialconditions;
                ArrayObj[15] = $scope.CustomerId;
                ArrayObj[16] = Appointment.amx_thirdpersoncontactphonenumber2;
                ArrayObj[17] = Appointment.amx_thirdpersoncontactemail1;
                ArrayObj[18] = Appointment.amx_thirdpersoncontactemail2;
                ArrayObj[19] = Appointment.amx_thirdpersoncontactname;
                ArrayObj[20] = Appointment.amx_thirdpersonassigned;
                ArrayObj[21] = Appointment.amx_thirdpersoncontactphonenumber1;
                ArrayObj[22] = Appointment.amx_technicianid;

                var RecId = Appointment.etel_appointmentlogid;
                var appointmentStatus = Appointment.etel_appointmentstatus;
                var url = window.parent.Xrm.Page.context.getClientUrl() + "/WebResources/amx_Openappointmentdetails/html/Openappointmentdetails.htm?Data=";

                DialogOption = new Xrm.DialogOptions;
                DialogOption.width = 1200; DialogOption.height = 600;
                var Appointment_etel_externalid = Appointment.etel_externalid;
                Xrm.Internal.openDialog(url + ArrayObj, DialogOption, null, null, CallbackFunction);
                //Xrm.Internal.openDialog(url + "?data=" + ArrayObj, vDialogOption, null, null, CallbackFunction);
                function CallbackFunction(returnValue) {
                    //Logic to open html page
                    var url = window.parent.Xrm.Page.context.getClientUrl() + "/WebResources/amx_AppointmentCancelationreasons/html/AppointmentCancelationreasons.htm?Data=";
                    var DialogOption = new Xrm.DialogOptions;
                    DialogOption.width = 670; DialogOption.height = 300;

                    Xrm.Internal.openDialog(url + ArrayObj, DialogOption, null, null, CallbackFunction);
                    function CallbackFunction(returnValue) {
                        var url = window.parent.Xrm.Page.context.getClientUrl() + "/WebResources/amx_Openappointmentdetails/html/Openappointmentdetails.htm?Data=";

                        DialogOption = new Xrm.DialogOptions;
                        DialogOption.width = 1200; DialogOption.height = 500;
                        var Appointment_etel_externalid = Appointment.etel_externalid;
                        Xrm.Internal.openDialog(url + ArrayObj, DialogOption, null, null, CallbackFunction);
                    }
                }
                // Xrm.Internal.openDialog(url + antiFraudMFNumberArray + "%26" + depositArray + "%26" + monthlyPaymentArray + "%26" + monthlyPaymentRiskArray + "%26" + orderNoArray + "%26" + processArray + "%26" + segmentArray + " %26" + simCardsArray + " %26 OK", vDialogOption, null, null, CallbackFunction);

            }
            //retrieve Appointment status
            $scope.getAppointmentStatus = function ()
            {
                var req = new XMLHttpRequest();
                req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_appointmentlogs?$select=etel_appointmentstatus&$filter=etel_appointmentlogid eq " + $scope.RecId, false);
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
                                var apptStatus = results.value[0]["etel_appointmentstatus"];
                                $scope.appointment_status = results.value[0]["etel_appointmentstatus@OData.Community.Display.V1.FormattedValue"];
                            }
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send();
            }
            $scope.ConfirmAppointment = function (Appointment) {
                $scope.RecId = Appointment.etel_appointmentlogid;
                $scope.getAppointmentStatus();
                
                if ($scope.appointment_status != "Cancelado") {
                    var confirmationStatus = Appointment.amx_confirmationstatus;
                    if (confirmationStatus == 'Pending') {
                        //Logic to update the confirmationStatus
                        var entity = {};
                        entity.amx_confirmationstatus = 173800000;

                        var req = new XMLHttpRequest();
                        req.open("PATCH", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_appointmentlogs(" + $scope.RecId + ")", false);
                        req.setRequestHeader("OData-MaxVersion", "4.0");
                        req.setRequestHeader("OData-Version", "4.0");
                        req.setRequestHeader("Accept", "application/json");
                        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                        req.onreadystatechange = function () {
                            if (this.readyState === 4) {
                                req.onreadystatechange = null;
                                if (this.status === 204) {
                                    Appointmentresult();
                                    // $scope.gridOptions.data.push($rootScope.appointmentListModel);
                                    //$location.url("/appointments/5")
                                    alert("Appointment Status Confirmed.")

                                } else {
                                    Xrm.Utility.alertDialog(this.statusText);
                                }
                            }
                        };
                        req.send(JSON.stringify(entity));
                    }
                }
                else {
                    alert("You cannot confirm the appointment as it is already cancelled.");
                }

            }
            $scope.CancelAppointment = function (Appointment) {
                var Customername = Xrm.Page.getAttribute("fullname").getValue();
                var ArrayObj = [];
                ArrayObj[0] = Appointment.etel_appointmentstatus;
                ArrayObj[1] = Appointment.etel_externalid;
                ArrayObj[2] = Appointment.etel_name
                ArrayObj[3] = Appointment.etel_appointmentdate;
                ArrayObj[4] = Appointment.amx_timeslot;
                ArrayObj[5] = Appointment.amx_workflowordersubtype;
                ArrayObj[6] = Appointment.etel_appointmentlogid;
                //ArrayObj[7] = Appointment._amx_addressid_value;
                ArrayObj[7] = Appointment.amx_confirmationstatus;
                ArrayObj[8] = Appointment.amx_appointmentnumber;
                ArrayObj[9] = Customername;
                ArrayObj[10] = Appointment.amx_workorderid;
                ArrayObj[11] = window.definitions.psbUrl;
                ArrayObj[12] = Appointment.createdon;
                ArrayObj[13] = Appointment.etel_appointmentclosedate;
                ArrayObj[14] = Appointment.amx_specialconditions;
                ArrayObj[15] = $scope.CustomerId;

                var RecId = Appointment.etel_appointmentlogid;
                var appointmentStatus = Appointment.etel_appointmentstatus;
                //Logic to open html page
                var url = window.parent.Xrm.Page.context.getClientUrl() + "/WebResources/amx_AppointmentCancelationreasons/html/AppointmentCancelationreasons.htm?Data=";
                var DialogOption = new Xrm.DialogOptions;
                DialogOption.width = 670; DialogOption.height = 300;
                Xrm.Internal.openDialog(url + ArrayObj, DialogOption, null, null, CallbackFunction);
                function CallbackFunction(returnValue) {
                    var Returnvalue = returnValue;
                    $scope.refresh = true;
                    $scope.refresh = false;
                    Appointmentresult();
                    //$scope.RefreshParent();
                }
                // if (appointmentStatus == 'Open') {
                //Logic to update Confirmation status and Appointment status
                //var entity = {};
                //entity.amx_confirmationstatus = 100000000;
                //entity.etel_appointmentstatus = 831260002;

                //var req = new XMLHttpRequest();
                //req.open("PATCH", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_appointmentlogs(" + RecId + ")", false);
                //req.setRequestHeader("OData-MaxVersion", "4.0");
                //req.setRequestHeader("OData-Version", "4.0");
                //req.setRequestHeader("Accept", "application/json");
                //req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                //req.onreadystatechange = function () {
                //    if (this.readyState === 4) {
                //        req.onreadystatechange = null;
                //        if (this.status === 204) {
                //            Appointmentresult();
                //            //$scope.gridOptions.data.push($rootScope.appointmentListModel);
                //        } else {
                //            Xrm.Utility.alertDialog(this.statusText);
                //        }
                //    }
                //};
                //req.send(JSON.stringify(entity));

                // }

                //alert("Appointment Canceled Successfully.")
            }
            $scope.RefreshParent = function () {
                if (window.opener != null && !Window.opener.closed) {
                    window.open.location.reload();
                }
            }
            var initiate = function () {
                $scope.loading = true;
                $scope.pageIndex = 1;
                Appointmentresult();

            };

            initiate();
        }]);
