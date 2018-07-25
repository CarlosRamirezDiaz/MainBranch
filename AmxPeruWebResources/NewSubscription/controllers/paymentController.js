wizard.controller("paymentController",
    ['$scope', '$http', '$rootScope', '$window', 'uiGridConstants',
        function ($scope, $http, $rootScope, $window, uiGridConstants, uiGridGroupingConstants) {
            var initiate = function () {
                debugger;
                $scope.resumeInput.data = {};
                $scope.resumeInput.data.province = "Test";
                //$scope.resumeInput.data.order = $rootScope.rootScopeData.PriceConfiguration;
            };
            debugger;
            initiate(); 

        }]);