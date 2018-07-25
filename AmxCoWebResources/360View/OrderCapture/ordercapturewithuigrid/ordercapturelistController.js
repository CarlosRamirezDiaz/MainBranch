angular.module('AccountSummary.Orders', [])
.controller('OrderCaptureListController', ['$scope', '$rootScope', '$http', '$timeout', '$interval', 'uiGridConstants',
    function ($scope, $rootScope, $http, $timeout, $interval, uiGridConstants, uiGridGroupingConstants) {

        $scope.CustomerType = 1;
        $scope.AccountIdAttributeName = "etel_accountnumber";

        $scope.gridOptions = {};
        $scope.gridOptions.selectedItems = [];

        if (typeof $scope.scopeData === "undefined") {
            $scope.scopeData = {};
        }

        $scope.languageCode = window.parent.Xrm.Page.context.getUserLcid();
        if ($scope.languageCode === 1025) {
            $scope.lang = "ar";
            $scope.direct = "rtl";
        }
        else {
            $scope.direct = "";
        }

        $scope.scopeData.translations = {
            getTranslations: function () {
                $scope.scopeData.translations = GetTranslationData("JS_OrderCaptureScripts");
            }
        };


        var initiate = function () {
            $scope.loading = true;
            $scope.pageIndex = 1;
            $scope.FillFormType();

            // getting translations
            $scope.scopeData.translations.getTranslations();
            $scope.FillViewTypes();

            // setting default 3 month value for date area
            var threeMonthsAgo = new Date();
            threeMonthsAgo.setMonth(threeMonthsAgo.getMonth() - 3);

            $scope.validFromDate = $rootScope.orderCaptureValidFromDate ? $rootScope.orderCaptureValidFromDate : threeMonthsAgo;
            $scope.validEndDate = $rootScope.orderCaptureValidEndDate ? $rootScope.orderCaptureValidEndDate : new Date();

            // assigning parameters     
            var accountid = window.parent.Xrm.Page.getAttribute($scope.AccountAttName).getValue();
            var startdate = $scope.modifyDateFormat($scope.validFromDate);
            var enddate = $scope.modifyDateFormat($scope.validEndDate);
            var orgOffset = window.parent.ORG_TIMEZONE_OFFSET;

            if (accountid != null && !$rootScope.orderCaptureListModel) {
                $scope.RetreiveOrderCaptures(accountid, startdate, enddate, $scope.pageIndex, orgOffset);
            }
            else {
                $scope.loading = false;
                $scope.BindGrid($rootScope.orderCaptureListModel);
            }
        };

        $scope.FillViewTypes = function () {


            $scope.viewTypes = [{
                name: $scope.scopeData.translations.tAllOrders,
                value: 1,
                id: 1
            },
            {
                name: $scope.scopeData.translations.tBulkOrders,
                value: 2,
                id: 2
            },
            {
                name: $scope.scopeData.translations.tCustomerActiveOrders,
                value: 3,
                id: 3
            },
            {
                name: $scope.scopeData.translations.tDraftOrderCaptures,
                value: 4,
                id: 4
            },
            {
                name: $scope.scopeData.translations.tInactiveOrderCaptures,
                value: 5,
                id: 5
            }];


            $scope.selectedOption = $rootScope.orderCaptureSelectedOption ? $rootScope.orderCaptureSelectedOption : $scope.CustomerType == 1 ? $scope.viewTypes[0] : $scope.viewTypes[3];

        }
        //$scope.SetDepositTypeDropDown = function () {
        //    $("#deposittypes").empty();
        //    var depositTypes = Util.caching.optionSet.get("global", "etel_deposittype");
        //    for (var field in depositTypes) {
        //        $('<option value="' + depositTypes[field].Value + '">' + depositTypes[field].Text + '</option>').appendTo('#deposittypes');
        //    }
        //};

        $scope.SearchOrderCapture = function () {
            $scope.loading = true;

            $rootScope.orderCaptureValidFromDate = $scope.validFromDate;
            $rootScope.orderCaptureValidEndDate = $scope.validEndDate;
            $rootScope.orderCaptureSelectedOption = $scope.selectedOption;

            if (!$scope.DateTextValidation(convertDate($scope.validFromDate), convertDate($scope.validEndDate))) {
                return;
            }

            var accountid = window.parent.Xrm.Page.getAttribute($scope.AccountAttName).getValue();
            var startdate = $scope.modifyDateFormat($scope.validFromDate);
            var enddate = $scope.modifyDateFormat($scope.validEndDate);
            var orgOffset = window.parent.ORG_TIMEZONE_OFFSET;


            if ($scope.DateValidation(startdate, enddate)) {
                if (accountid != null) {
                    $scope.RetreiveOrderCaptures(accountid, startdate, enddate, $scope.pageIndex, orgOffset);
                }
                else
                    $scope.loading = false;
            }
        };

        $scope.RetreiveOrderCaptures = function (accountid, startdate, enddate, pageIndex, orgOffset) {

            $scope.pageIndex = pageIndex;

            if ((orgOffset === undefined) || (orgOffset === null)) {
                orgOffset = 0;
            }

            var OCCHistoryRequestModel = {
                "$type": "ExternalApiActivities.Models.OrderCaptureRequestModel, ExternalApiActivities",
                "customerId": accountid,
                "startDate": startdate,
                "endDate": enddate,
                "orgTimezoneOffset": orgOffset,
                "languagecode": $scope.languageCode.toString(),
                "viewtype": $scope.selectedOption.value
            };

            var reqData = { "request": OCCHistoryRequestModel };

            $scope.BindGrid([]);

            $http.post(window.definitions.psbUrl + 'AmxRetrieveOrderCapture', reqData, { "withCredentials": true })
                .success(function (result) {
                    $scope.loading = false;
                    if (result.Output.ordercapturelistmodel) {
                        $rootScope.orderCaptureListModel = result.Output.ordercapturelistmodel;
                        $scope.BindGrid($rootScope.orderCaptureListModel);
                    }
                }).error(function (data, status, headers, config) {
                    $scope.loading = false;
                    alert($scope.scopeData.translations.tErrorMessage + data.ExceptionMessage);
                });
        };

        $scope.BindGrid = function (resultdata) {

            for (var i = 0; i < resultdata.length; i++) {
                resultdata[i].id = i;
            }

            $scope.gridOptions.data = resultdata;

            $scope.gridOptions.columnDefs = [
             { name: $scope.scopeData.translations.tCreatedOn, field: 'CreatedOn', sort: { direction: 'desc', priority: 0 }, enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 120 },
             { name: $scope.scopeData.translations.tName, field: 'Name', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, cellTemplate: '<div class="ui-grid-cell-contents" ><a href="#" title="{{COL_FIELD}}" ng-click="grid.appScope.OnClickOrderName(row.entity)"><span>{{COL_FIELD}}</span></a></div>', width: 150 },
             { name: $scope.scopeData.translations.tOrderType, field: 'OrderType', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 180 },
             { name: $scope.scopeData.translations.tStatusReason, field: 'StatusReason', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 110 },
             { name: $scope.scopeData.translations.tCancelOrPostponeReason, field: 'CancelOrPostponeReason', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 220 },
             { name: $scope.scopeData.translations.tExternalOrderId, field: 'ExternalOrderId', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 110 },
             { name: $scope.scopeData.translations.tShoppingCardId, field: 'ShoppingCardId', enableCellEdit: false, enableColumnMenu: false, headerTooltip: true, cellTooltip: true, width: 110 },
             { name: $scope.scopeData.translations.tSourceSystem, field: 'SourceSystem', enableCellEdit: false, enableColumnMenu: false, width: 110, headerTooltip: true, cellTooltip: true },
             { name: $scope.scopeData.translations.tSubscriptionName, field: 'SubscriptionName', enableCellEdit: false, enableColumnMenu: false, width: 110, cellTooltip: true, headerTooltip: true },
            ];
        }

        var convertDate = function (inputFormat) {
            var d = new Date(inputFormat);
            return [d.getMonth() + 1, d.getDate(), d.getFullYear()].join('/');
        };

        $scope.modifyDateFormat = function (tempInputDate) {
            var convertedDate = new Date(tempInputDate);
            var ValidDate = "/Date(" + convertedDate.getTime() + ")/";
            return ValidDate
        }
        //controlling of date values
        $scope.DateValidation = function (fromDate, endDate) {
            if (endDate === '/Date(NaN)/' || fromDate === '/Date(NaN)/') {
                $scope.loading = false;
                alert($scope.scopeData.translations.tDateValidation);
                $scope.gridOptions.data = [];
                $scope.gridApi.grid.refresh();
                return false;
            }

            if (endDate < fromDate) {
                $scope.loading = false;
                alert($scope.scopeData.translations.tEndDateLessThenCurrentDate);
                $scope.gridOptions.data = [];
                $scope.gridApi.grid.refresh();
                return false;
            }

            return true;
        };

        $scope.OnClickOrderName = function (OrderInquiry) {
            var id = OrderInquiry.OrderCaptureId;
            if (id !== null) {
                window.parent.Xrm.Utility.openEntityForm("etel_ordercapture", id);
            }
        };

        $scope.FillFormType = function () {

            var entitiyname = window.parent.Xrm.Page.data.entity.getEntityName()
            $scope.AccountAttName = "etel_accountnumber";

            if (entitiyname === "contact") {
                $scope.AccountAttName = "etel_accountnumber";
                $scope.CustomerType = 1;
            }
            else if (entitiyname === "account") {
                $scope.AccountAttName = "accountnumber";
                $scope.CustomerType = 2;
            }

        };

        $scope.DateTextValidation = function (fromDate, endDate) {
            var fromDateArray = fromDate.split("/");
            var endDateArray = endDate.split("/");

            if (fromDateArray[1] > 31 || endDateArray[1] > 31) {
                $scope.loading = false;
                alert($scope.scopeData.translations.tDateValidation);
                $scope.gridOptions.data = [];
                $scope.gridApi.grid.refresh();
                return false;
            }

            else if (fromDateArray[0] > 12 || endDateArray[0] > 12) {
                $scope.loading = false;
                alert($scope.scopeData.translations.tDateValidation);
                $scope.gridOptions.data = [];
                $scope.gridApi.grid.refresh();
                return false;
            }

            return true;
        };

        //$scope.setClickedRow = function (row) {
        //    if (row.entity.Type === "Paid") {
        //        row.isSelected = false;
        //    }
        //}

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
        $scope.gridOptions.enablePaginationControls = false;
        $scope.gridOptions.paginationPageSize = 4;
        $scope.gridOptions.rowIdentity = function (row) {
            return row.id;
        };
        $scope.gridOptions.getRowIdentity = function (row) {
            return row.id;
        };

        var strVar = "";
        strVar += "<div ng-mouseover=\"rowStyle={'background-color': '#D6EBFF'}; grid.appScope.onRowHover(this);\" ng-mouseleave=\"rowStyle={}\">";
        strVar += "    <div ng-style=\"rowStyle\" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.uid\" ui-grid-one-bind-id-grid=\"rowRenderIndex + '-' + col.uid + '-cell'\"";
        strVar += "         class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" role=\"{{col.isRowHeader ? 'rowheader' : 'gridcell'}}\" ui-grid-cell>";
        strVar += "    <\/div>";
        strVar += "<\/div> ";

        $scope.gridOptions.rowTemplate = strVar;

        $scope.filter = function () {
            $scope.loading = false;
            $scope.gridApi.grid.refresh();
        };

        $scope.singleFilter = function (renderableRows) {
            var matcher = new RegExp((!$scope.filterValue) ? $scope.filterValue : $scope.filterValue.toLowerCase());
            renderableRows.forEach(function (row) {
                var match = false;
                ['CreatedOn', 'Name', 'OrderType', 'StatusReason', 'ExternalOrderId', 'ShoppingCardId', 'SourceSystem', 'SubscriptionName'].forEach(function (field) {
                    if (typeof (field) !== "undefined") {
                        if ((row.entity[field]) !== null) {
                            if (row.entity[field].toString().toLowerCase().match(matcher)) {
                                match = true;
                            }
                        }
                    }
                });
                if (!match) {
                    row.visible = false;
                }
            });
            return renderableRows;
        };

        initiate();
    }]);