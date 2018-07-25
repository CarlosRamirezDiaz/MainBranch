﻿wizard.controller("changePlanGeneralInformationController",
    ['$scope', '$http', '$rootScope', '$window', 'uiGridConstants',
        function ($scope, $http, $rootScope, $window, uiGridConstants) {
            debugger;
            $scope.scopeData = {};

            $rootScope.rootScopeData = {};
            $scope.scopeData.planning = {};
            $scope.scopeData.yName = "";
            var apiUrl = Wizard.Util.configStore.PsbRestServiceUrl;
            $scope.direct = $rootScope.direct; // setting direction for RTL language
            var initiate = function () {
                debugger;
                $rootScope.rootScopeData.translations = Wizard.GetTranslationData("6666");
                $scope.scopeData.planning.translations.getTranslations();
                //$scope.scopeData.AddressSelection.Addresses = $scope.workflowContext.ResponseData.Output.customerAddressListModel;
                //$scope.scopeData.AddressSelection.Addresses = $scope.scopeData.AddressSelection.fetchAddress();
            };
            if ($scope.direct === "rtl") {
                $scope.isRTL = true;
            }
            else {
                $scope.isRTL = false;
            }
            //$scope.setName = function () {
            //    $scope.resumeInput.data.xName = $scope.scopeData.yName;
            //    alert( $scope.scopeData.yName );
            //}

            $scope.scopeData.planning.translations = {
                getTranslations: function () {
                    $scope.scopeData.planning.translations = Wizard.GetTranslationData("AmxPeruChangePlanFlow");
                }
            };

            debugger;
            $scope.scopeData.Selection = {

                ServiceTypes: [
                    { "serviceType": "Manual" },
                    { "serviceType": "Automatic" }
                ]
            };

            initiate();

        }]);