wizard.controller("documentController",
    ['$scope', '$http', '$rootScope', '$window', 'uiGridConstants',
        function ($scope, $http, $rootScope, $window, uiGridConstants, uiGridGroupingConstants) {

            var initiate = function () {
                $scope.scopeData.selectOffering.translations.getTranslations();
                $scope.scopeData.getFamilies();
                $scope.resumeInput.data = {};
                $scope.resumeInput.data.province = "Test";
                $scope.resumeInput.data.order = $rootScope.rootScopeData.PriceConfiguration;
            };
            initiate(); 
        }]);