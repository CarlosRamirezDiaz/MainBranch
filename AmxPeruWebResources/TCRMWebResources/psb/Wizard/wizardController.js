var wizard = angular
    .module('wizard', ['ngGrid', 'components', 'bzm-date-picker', 'ngTouch',
        'ui.grid.expandable', 'ui.grid.pagination', 'ui.grid', 'ui.grid.edit', 'ui.grid.resizeColumns', 'ui.grid.selection',
        'ui.grid.moveColumns', 'ui.grid.autoResize', 'ngDialog'])
    .config(function ($locationProvider, $httpProvider) {
        $locationProvider.html5Mode(true); //to get querys trings
        //initialize get if not there
        if (!$httpProvider.defaults.headers.get) {
            $httpProvider.defaults.headers.get = {};
        }
        //disable IE ajax request caching
        $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
        // extra
        $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
        $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
    })
    .filter('reverse', function () {
        return function (items) {
            if (items === undefined || items == null) {
                return items;
            };
            return items.slice().reverse();
        };
    }).filter('range', function () {
        return function (input, min, max) {
            min = parseInt(min); //Make string input int
            max = parseInt(max);
            for (var i = min; i < max; i++)
                input.push(i);
            return input;
        };
    }).factory('dataService', function () {
        var _dataObj = {};
        return {
            dataObj: _dataObj
        };
    });;

wizard.controller('wizardController', [
    '$scope', '$location', 'dataService', '$http', '$rootScope', '$q', 'ngDialog',
    function ($scope, $location, dataService, $http, $rootScope, $q, ngDialog) {
        var apiUrl = Wizard.Util.configStore.PsbRestServiceUrl;
        var CrmUtil = Wizard.CrmUtil;
        var constants = {
            PsbWizard: "PsbWizard"
        };

        dataService.dataObj = {};

        $rootScope.ngDialog = ngDialog;
        $scope.firstRun = true;
        $scope.httpLoading = false;

        $scope.workflowNextAvailable = true;
        $scope.workflowRollbackAvailable = true;

        if (apiUrl.indexOf("/workflow/") != -1) {
            apiUrl = apiUrl.substring(0, apiUrl.indexOf("/workflow/") + 1);
        }

        var isDataEmpty = function (obj) {
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop))
                    return false;
            }

            return true;
        };

        var refreshPage = function (obj) {
            var entityFields = $scope.workflowHistoryResponse.data[obj];
            var entityName = Xrm.Page.data.entity.getEntityName();
            var entityId = Xrm.Page.data.entity.getId().substr(1, 36);
            if (entityName !== undefined && entityId !== undefined) {
                Xrm.Utility.openEntityForm(entityName, entityId);
            }
        };

        var getHistoriesOfWorkflow = function (stageName) {
            $scope.httpLoading = true;

            var config = {
                withCredentials: true
            };

            $http.get(apiUrl + "workflow/formdata/all/" + $scope.workflowName + "/" + $scope.workflowInstanceId, config)
                .success(function (result) {

                    if (result) {

                        if ($scope.registerWorkflowHistory) {
                            var objectInString = JSON.stringify(result);
                            updateWorkflowHistory(objectInString);
                        }
                        $scope.registerWorkflowHistory = true;
                        if ($scope.resume) {
                            $scope.workflowHistoryResponse.data = JSON.parse($scope.psbWorkflowHistory);
                            $scope.psbWorkflowHistory = null;
                            $scope.resume = false;
                        } else {
                            $scope.workflowHistoryResponse.data = result;
                        }

                        $scope.psbWizardTranslations = CrmUtil.psbTranslationService(constants.PsbWizard);

                        $scope.workflowHistoryResponse.data = CrmUtil.psbSetStageNames($scope.workflowName, $scope.workflowHistoryResponse.data);

                        if (stageName === undefined || stageName == null) {
                            if ($scope.workflowHistoryResponse.data[0].SaveData !== undefined && isDataEmpty($scope.workflowHistoryResponse.data[0].SaveData)) {
                                $scope.workflowSaveData.data = null;
                            } else {
                                $scope.workflowSaveData.data = JSON.parse($scope.workflowHistoryResponse.data[0].SaveData);
                            }
                            $scope.workflowHistoryCurrent = $scope.workflowHistoryResponse.data[0];
                            $scope.workflowHistoryCurrent.IsOnlyPreviewAvailable = false;
                            var stateCode = Xrm.Page.getAttribute("statecode") != null
                                ? Xrm.Page.getAttribute("statecode").getValue()
                                : null;
                            if ($scope.workflowHistoryCurrent.ResponseData.Status !== undefined && $scope.workflowHistoryCurrent.ResponseData.Status === 4) {
                                $rootScope.$broadcast("WorkflowHasNoNextStage");
                                if (stateCode === 0) {
                                    //TODO: this will be fixed and redesigned as dynamic.
                                    if ($scope.workflowName == "AmxPeruNewSubscription") {
                                        alert($scope.psbWizardTranslations.tSubmittedSuccessfully + " OM order id: " + $scope.workflowHistoryCurrent.ResponseData.Output.submitOrderResponse.id);
                                        $scope.redirectToIndividual();
                                    }
                                    else {
                                        alert($scope.psbWizardTranslations.tSubmittedSuccessfully + " OM order id: " + $scope.workflowHistoryCurrent.ResponseData.Output.submitOrderResponse.id);
                                    }
                                    //refreshPage(1);
                                }
                            }
                        } else {
                            for (var i = 0; i < $scope.workflowHistoryResponse.data.length; i++) {
                                if ($scope.workflowHistoryResponse.data[i].StageName == stageName) {
                                    if (isDataEmpty($scope.workflowHistoryResponse.data[i].SaveData)) {
                                        $scope.workflowSaveData.data = null;
                                    } else {
                                        $scope.workflowSaveData.data = JSON.parse($scope.workflowHistoryResponse.data[i].SaveData);
                                    }
                                    $scope.workflowHistoryCurrent = $scope.workflowHistoryResponse.data[i];
                                    $scope.workflowHistoryCurrent.IsOnlyPreviewAvailable = true;
                                    break;
                                }
                            }
                        }

                        if (!$scope.$$phase) {
                            $scope.$apply();
                        }
                    }

                }).error(function (data, status, headers, config) {
                    alert((data.ExceptionMessage === undefined ?
                        (data.data === undefined ? data :
                            (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                }).finally(function () {
                    $scope.httpLoading = false;
                });
        };

        var runNewWorkflow = function () {
            
            $scope.httpLoading = true;
            if ($scope.psbWorkflowHistory && $scope.psbWorkflowHistory != "") {
                var workflowHistoryObject = JSON.parse($scope.psbWorkflowHistory);
                $scope.workflowInstanceId = workflowHistoryObject[0].InstanceId;
                $scope.resume = true;
                getHistoriesOfWorkflow();
                return;
            } else {
                $scope.registerWorkflowHistory = false;
            }

            var config = {
                withCredentials: true
            };

            $http.post(apiUrl + 'workflow/' + $scope.workflowName, JSON.stringify($scope.workflowStartInput), config)
                .success(function (result) {

                    if (result) {
                        $scope.workflowRunResponse = result;
                        $scope.workflowInstanceId = result.InstanceId;
                        if (!$scope.$$phase) {
                            $scope.$apply();
                        }
                    }

                    getHistoriesOfWorkflow();

                    $scope.httpLoading = false;

                }).error(function (data, status, headers, config) {
                    alert((data.ExceptionMessage === undefined ?
                        (data.data === undefined ? data :
                            (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                    $scope.httpLoading = false;
                }).finally(function () {
                    //$scope.httpLoading = false;
                });
        };

        $scope.workflowNext = function () {
            var result = angular.isFunction($scope.workflowNextValidate) ? $scope.workflowNextValidate() : $scope.workflowNextValidate;
            if (result) {
                $scope.workflowSave(true);
            }
        };

        $scope.redirectToIndividual = function () {
            var entityName = "contact";
            var individualCustomerGuid, individualCustomerName;
            var lookupObj = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
            if (lookupObj) {
                var lookupEntityType = lookupObj[0].entityType;
                individualCustomerGuid = lookupObj[0].id;
                individualCustomerName = lookupObj[0].name;
            }
            if (individualCustomerGuid != null && individualCustomerGuid != undefined) {
                Xrm.Utility.openEntityForm(entityName, individualCustomerGuid);
            }
        };

        $scope.workflowNextValidate = function () {
            return true;
        };

        $scope.workflowNextAvailable = true;

        $scope.workflowRollback = function () {
            var result = angular.isFunction($scope.workflowRollbackValidate) ? $scope.workflowRollbackValidate() : $scope.workflowRollbackValidate;
            if (result) {
                var r = confirm($scope.psbWizardTranslations.tPreviousMessage);
                if (r == true) {

                    $scope.httpLoading = true;

                    var config = {
                        withCredentials: true
                    };

                    $http.post(apiUrl + "workflow/back/" + $scope.workflowName + "/" + $scope.workflowInstanceId, null, config)
                        .success(function (result) {

                            getHistoriesOfWorkflow();

                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                        }).finally(function () {
                            $scope.httpLoading = false;
                        });
                }
            }
        };

        $scope.workflowRollbackValidate = function () {
            return true;
        };

        $scope.workflowRollbackAvailable = true;

        $scope.workflowSave = function (callNext) {
            //save data only if it is not in preview mode!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if ($scope.workflowHistoryCurrent.IsOnlyPreviewAvailable == false) {

                if (callNext == true) { //show loading only for next calls (do not show for save events, auto save may be disturbing :) )
                    $scope.httpLoading = true;
                }
                var config = {
                    withCredentials: true
                };

                $http.post(apiUrl + "workflow/formdata/" + $scope.workflowName + "/" + $scope.workflowInstanceId,
                    JSON.stringify($scope.workflowSaveData.data), config)
                    .success(function (result) {

                        if (callNext == true) {

                            $scope.httpLoading = true;

                            var req = {
                                method: 'POST',
                                url: apiUrl + "workflow/" + $scope.workflowName + "/" + $scope.workflowInstanceId,
                                headers: {
                                    'Content-Type': 'application/json'
                                },
                                data: JSON.stringify($scope.workflowResumeInput.data),
                                withCredentials: true
                            }

                            $http(req).then(function (resultNextCall) {

                                getHistoriesOfWorkflow();

                            }, function (data, status, headers, config) {
                                $scope.httpLoading = false;
                                if (data != null && data.data != null && data.data.Exception != null && data.data.Exception.ClassName != null && data.data.Exception.ClassName.indexOf("NotCurrentStageException") != -1) {
                                    getHistoriesOfWorkflow();
                                }
                                else {
                                    alert((data.ExceptionMessage === undefined ?
                                        (data.data === undefined ? data :
                                            (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                                    var stateCode = Xrm.Page.getAttribute("statecode") != null
                                        ? Xrm.Page.getAttribute("statecode").getValue()
                                        : null;
                                    if (stateCode === 0) {
                                        refreshPage(0);
                                    }
                                }
                            }, function () {
                                //$scope.httpLoading = false;
                            });
                        }

                    }).error(function (data, status, headers, config) {
                        $scope.httpLoading = false;
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                    }).finally(function () {
                    });
            } else {
                alert($scope.psbWizardTranslations.tCannotSavePreviewMode);
            }
        };

        $scope.workflowRefresh = function () {
            $scope.loadContent();
        };

        $scope.getDataParam = function () {
            var vals = new Array();
            var result = new Array();

            if (location.search != "") {
                vals = location.search.substr(1).split("&");
                for (var i in vals) {
                    vals[i] = vals[i].replace(/\+/g, " ").split("=");
                }

                //look for the parameter named 'data'
                for (var i in vals) {
                    if (vals[i][0].toLowerCase() == "data") {
                        result = $scope.parseDataValue(vals[i][1]);
                        break;
                    }
                }
            }
            return result;
        };

        $scope.parseDataValue = function (datavalue) {
            if (datavalue != "") {
                var vals = new Array();

                vals = decodeURIComponent(datavalue).split("&");
                for (var i in vals) {
                    vals[i] = vals[i].replace(/\+/g, " ").split("=");
                }
            }
            return vals;
        };

        $scope.getValueFromArray = function (arrayvalue, paramkey) {
            if (arrayvalue == null)
                return null;

            for (var i = 0; i < arrayvalue.length; i++) {
                if (arrayvalue[i][0] == paramkey)
                    return arrayvalue[i][1];
            }

            return null;
        };

        var updateWorkflowHistory = function (psbWorkflowHistory) {
            var config = {
                withCredentials: true
            };

            var workflowStartInput =
                {
                    "entityId": $scope.workflowStartInput ? $scope.workflowStartInput.orderCaptureId : "",
                    "entityName": "etel_ordercapture",
                    "fieldNames": {
                    "$type": "System.Collections.Generic.List`1[System.String], mscorlib",
                    "$values": ["amx_psbworkflowhistory"],
                },
                "fieldValues": {
                    "$type": "System.Collections.Generic.List`1[System.String], mscorlib",
                    "$values": [psbWorkflowHistory],
                }
            };
            if ($scope.workflowStartInput) {
                $http.post(apiUrl + 'workflow/UpdateGenericEntityFields', JSON.stringify(workflowStartInput), config);
            }
        };

        var checkWorkflowHistory = function () {
            var deferred = $q.defer();
            var req = new XMLHttpRequest();
            var select = "/api/data/v8.2/etel_ordercaptures?$select=amx_psbworkflowhistory&$filter=etel_ordercaptureid eq " + $scope.workflowStartInput.orderCaptureId;
            req.open("GET", Xrm.Page.context.getClientUrl() + select, false);
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

                        if (results.value[0].amx_psbworkflowhistory) {
                            $scope.psbWorkflowHistory = results.value[0].amx_psbworkflowhistory;
                        }
                        deferred.resolve();
                    }
                }
            };
            req.send();
            return deferred.promise;
        };

        $scope.loadContent = function () {
            //var params = $scope.getDataParam();
            
            var params = $scope.parseDataValue($location.search().Data);

            var name = $scope.getValueFromArray(params, "name");
            var stageName = $scope.getValueFromArray(params, "stagename");
            var id = $scope.getValueFromArray(params, "id");

            $scope.workflowName = name;
            $scope.workflowStageName = stageName;
            $scope.workflowInstanceId = id;
            $scope.workflowStartInput = null;
            if ($scope.firstRun) {
                $scope.firstRun = false;
            }

            if (Wizard.definitions !== undefined && Wizard.definitions != null) //$location.search().input;
            {
                $scope.workflowStartInput = Wizard.definitions['psbWorkflowStartInput'];
                Wizard.definitions['psbWorkflowStartInput'] = null; //to not get it again :)
            } else if ($scope.workflowName !== undefined && $scope.workflowName != null &&
                ($scope.workflowStageName === undefined || $scope.workflowStageName == null) &&
                ($scope.workflowInstanceId === undefined || $scope.workflowInstanceId == null)) {
                $scope.workflowStartInput = {}; //send empty input
            }
            var promise = checkWorkflowHistory();

            $scope.workflowResumeInput = { data: null };
            $scope.workflowSaveData = { data: null };

            $scope.workflowRunResponse = {};
            $scope.workflowHistoryResponse = {};
            $scope.workflowHistoryCurrent = {};

            if (($scope.workflowStageName === undefined || $scope.workflowStageName == null)
                &&
                ($scope.workflowInstanceId === undefined || $scope.workflowInstanceId == null)) {
                //start new workflow
                promise.then(function () { runNewWorkflow() });
            } else if (($scope.workflowStageName === undefined || $scope.workflowStageName == null)) {
                //get history data
                getHistoriesOfWorkflow();
            } else {
                //get stage data
                getHistoriesOfWorkflow($scope.workflowStageName);
            }
        };

        $scope.loadContent();
    }
]);