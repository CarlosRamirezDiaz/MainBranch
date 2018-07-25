﻿angular.module('MonetaryTransactions.CreditProfile', [])
    .controller('CreditProfileTabViewController', ['$scope', '$http', '$rootScope', 'uiGridConstants',
        function ($scope, $http, $rootScope, uiGridConstants, uiGridGroupingConstants) {

            if (typeof $scope.scopeData === "undefined") {
                $scope.scopeData = {};
            }

            var languageCode = window.parent.Xrm.Page.context.getUserLcid();
            if (languageCode === 1025) {
                $scope.lang = "ar";
                $scope.direct = "rtl";
            }
            else {
                $scope.direct = "";
            }

            var getTranslations = function () {
                var translations = GetTranslationData("CreditProfile");
                $scope.scopeData.translations = translations;
                document.title = $scope.scopeData.translations.tCreditProfile;
                //setRtlDirection();
            };

            $scope.gridOptions = {};
            $scope.gridOptions.selectedItems = [];

            var getData = function () {

                var customerId = window.parent.Xrm.Page.data.entity.getId();
                var type = window.parent.Xrm.Page.data.entity.getEntityName();
                var formType = window.parent.Xrm.Page.ui.getFormType();

                if (formType == 1 && (customerId == "" || customerId == null)) {
                    return;
                }


                var filter = "";
                if (type == "account")
                    filter = "etel_corporateid/Id eq guid'" + customerId + "'";
                else
                    filter = "etel_individualid/Id eq guid'" + customerId + "'";

                $scope.BindGrid([]);

                retrieveMultipleRecords("etel_creditprofile", "$select=ModifiedOn,etel_name,etel_source,etel_startdate,etel_enddate,etel_creditscore,etel_creditriskrating,etel_financialinstitutionid,etel_institutionaccountnumber,etel_institutionaccounttype,amxperu_CurrentBureauCreditLimit,amxperu_CurrentCRMCreditLimit,amxperu_CurrentWalletsCreditLimits,amxperu_RequestedCRMCreditLimit,amxperu_ConfirmedCRMCreditLimit,amxperu_ChangeReason,&$orderby=CreatedOn desc&$filter=" + filter, function (results) {
                    $scope.loading = false;
                    if (results !== null) {
                        $scope.CreditProfiles = results;

                        for (var i = 0; i < $scope.CreditProfiles.length; i++) {
                            $scope.CreditProfiles[i].id = i;
                            var sdate = $scope.CreditProfiles[i].etel_startdate;
                            var edate = $scope.CreditProfiles[i].etel_enddate;
                            var ldate = $scope.CreditProfiles[i].ModifiedOn;

                            $scope.CreditProfiles[i].etel_startdate = sdate.toISOString().substr(0, 10);
                            $scope.CreditProfiles[i].etel_enddate = edate.toISOString().substr(0, 10);
                            $scope.CreditProfiles[i].ModifiedOn = ldate.toISOString().substr(0, 10);


                            $scope.CreditProfiles[i].etel_financialinstitutionidguid = "";
                            $scope.CreditProfiles[i].etel_financialinstitutionidname = "";
                            debugger;
                            $scope.CreditProfiles[i].amxperu_CurrentBureauCreditLimit = $scope.CreditProfiles[i].amxperu_CurrentBureauCreditLimit.Value;
                            $scope.CreditProfiles[i].amxperu_CurrentCRMCreditLimit = $scope.CreditProfiles[i].amxperu_CurrentCRMCreditLimit.Value;
                            $scope.CreditProfiles[i].amxperu_CurrentWalletsCreditLimits = $scope.CreditProfiles[i].amxperu_CurrentWalletsCreditLimits.Value;
                            $scope.CreditProfiles[i].amxperu_RequestedCRMCreditLimit = $scope.CreditProfiles[i].amxperu_RequestedCRMCreditLimit.Value;
                            $scope.CreditProfiles[i].amxperu_ConfirmedCRMCreditLimit = $scope.CreditProfiles[i].amxperu_ConfirmedCRMCreditLimit.Value;

                            if ($scope.CreditProfiles[i].etel_financialinstitutionid != null) {
                                $scope.CreditProfiles[i].etel_financialinstitutionidguid = $scope.CreditProfiles[i].etel_financialinstitutionid.Id;
                                $scope.CreditProfiles[i].etel_financialinstitutionidname = $scope.CreditProfiles[i].etel_financialinstitutionid.Name;
                            }

                            edate.setDate(edate.getDate() + 1);
                            edate.setSeconds(-1);
                            var now = new Date();
                            if ((edate.getTime() < now.getTime()) || (sdate.getTime() > now.getTime())) {
                                $scope.CreditProfiles[i].etel_status = false;
                            } else {
                                $scope.CreditProfiles[i].etel_status = true;
                            }
                        }
                        $rootScope.CreditProfilesResults = $scope.CreditProfiles;
                        $scope.BindGrid($scope.CreditProfiles);
                    }
                },
                    function (error) {
                        alert("Credit Profile retrieve error: " + data.Message);
                    },
                    function () { });


            };

            $scope.BindGrid = function (data) {
                $scope.gridOptions.data = data;
                for (var i = 0; i < data.length; i++) {
                    data[i].id = i;
                }

                $scope.gridOptions.columnDefs = [
                    { name: $scope.scopeData.translations.tStatus, field: 'etel_status', width: 50, enableCellEdit: false, headerTooltip: true, enableColumnMenu: false, cellTemplate: '<div class="circleContainer"><div title="{{row.entity.StatusTitle}}" ng-show="row.entity.etel_status" class="circleGreen"></div><div title="{{row.entity.StatusTitle}}" ng-show="!row.entity.etel_status" class="circleGrey"></div></div>' },
                    { name: $scope.scopeData.translations.tNo, field: 'etel_name', headerTooltip: true, cellTooltip: true, cellTemplate: '<div class="ui-grid-cell-contents" ><a href="#" title="{{COL_FIELD}}" ng-click="grid.appScope.OnClickCreditProfile(row.entity)"><span>{{COL_FIELD}}</span></a></div>', enableCellEdit: false, enableColumnMenu: false, width: 100 },
                    { name: $scope.scopeData.translations.tSource, field: 'etel_source', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 100 },
                    { name: $scope.scopeData.translations.tStartDate, field: 'etel_startdate', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 100 },
                    { name: $scope.scopeData.translations.tEndDate, field: 'etel_enddate', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 100 },
                    { name: $scope.scopeData.translations.tScore, field: 'etel_creditscore', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 100 },
                    { name: $scope.scopeData.translations.tRiskRating, field: 'etel_creditriskrating', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 100 },
                    { name: $scope.scopeData.translations.tInstitutionName, field: 'etel_financialinstitutionidname', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 120 },
                    { name: $scope.scopeData.translations.tInsAccountNumber, field: 'etel_institutionaccountnumber', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 100 },
                    { name: $scope.scopeData.translations.tInsAccountType, field: 'etel_institutionaccounttype', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 100 },
                    { name: $scope.scopeData.translations.tLastUpdate, field: 'ModifiedOn', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 100 },

                    { name: "Current Bureau Credit Limit", field: 'amxperu_CurrentBureauCreditLimit', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 100 },
                    { name: "Current CRM Credit Limit", field: 'amxperu_CurrentCRMCreditLimit', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 100 },
                    { name: "Current Wallets Credit Limits", field: 'amxperu_CurrentWalletsCreditLimit', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 120 },
                    { name: "Requested CRM Credit Limit", field: 'amxperu_RequestedCRMCreditLimit', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 100 },
                    { name: "Confirmed CRM Credit Limit", field: 'amxperu_ConfirmedCRMCreditLimit', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 100 },
                    { name: "Change Reason", field: 'amxperu_ChangeReason', headerTooltip: true, cellTooltip: true, enableCellEdit: false, enableColumnMenu: false, width: 100 }
                    

                ];

                $scope.loading = false;
            };

            var initiate = function () {
                $scope.loading = true;
                getTranslations();

                if (!$rootScope.CreditProfilesResults) {
                    getData();
                } else {
                    $scope.BindGrid($rootScope.CreditProfilesResults);
                }

            };


            $scope.OnClickCreditProfile = function (CreditProfileInquiry) {
                var creditprofileno = CreditProfileInquiry.etel_name;

                var tableName = "etel_creditprofile";
                var filter = "etel_name eq '" + creditprofileno + "'";

                retrieveMultipleRecords("etel_creditprofile", "$select=etel_creditprofileId&$filter=" + filter, function (results) {
                    if (results !== null) {
                        window.parent.Xrm.Utility.openEntityForm(tableName, results[0].etel_creditprofileId);
                    }
                });
            };

            $scope.gridOptions.onRegisterApi = function (gridApi) {
                $scope.gridApi = gridApi;

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

                    $rootScope.CreditProfileScopeSelectedItems = $scope.gridOptions.selectedItems;
                });
            };
            $scope.gridOptions.enableColumnResizing = true;
            $scope.gridOptions.enableHorizontalScrollbar = uiGridConstants.scrollbars.ALWAYS;
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
            $scope.gridOptions.expandableRowHeight = 70;
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

            $scope.selectedRow = null;
            $scope.setClickedRow = function (index) {  //function that sets the value of selectedRow to current index
                $scope.selectedRow = ($scope.selectedRow == index) ? null : index;
                if (index != null && index != undefined) {

                }
            }

            $scope.gridRowClick = function (row) {
                $scope.setClickedRow(row.entity.id);
            };

            var strVar = "";
            strVar += "<div ng-mouseover=\"rowStyle={'background-color': '#D6EBFF'}; grid.appScope.onRowHover(this);\" ng-click=\"grid.appScope.gridRowClick(row);\" ng-mouseleave=\"rowStyle={}\">";
            strVar += "    <div ng-style=\"rowStyle\" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.uid\" ui-grid-one-bind-id-grid=\"rowRenderIndex + '-' + col.uid + '-cell'\"";
            strVar += "         class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" role=\"{{col.isRowHeader ? 'rowheader' : 'gridcell'}}\" ui-grid-cell>";
            strVar += "    <\/div>";
            strVar += "<\/div> ";

            $scope.gridOptions.rowTemplate = strVar;

            initiate();
        }]);