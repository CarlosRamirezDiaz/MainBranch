wizard.controller("simConfigurationController",
    ['$scope', '$http', '$rootScope', '$window', 'uiGridConstants',
        function ($scope, $http, $rootScope, $window, uiGridConstants) {

            var initiate = function () {
                $scope.resumeInput.data = {};
            };

            initiate();

        }]);