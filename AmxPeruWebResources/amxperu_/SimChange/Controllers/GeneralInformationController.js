wizard.controller("simGeneralInformationController",
    ['$scope', '$http', '$rootScope', '$window', 'uiGridConstants',
        function ($scope, $http, $rootScope, $window, uiGridConstants) {

            $scope.scopeData = {};

            $scope.scopeData.yName = "";

            $scope.setName = function () {
                $scope.resumeInput.data.xName = $scope.scopeData.yName;
                alert( $scope.scopeData.yName );
            }

            var initiate = function () {
                $scope.resumeInput.data = {};
            };


            initiate();

        }]);