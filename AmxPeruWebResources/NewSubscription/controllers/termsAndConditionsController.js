wizard.controller('termsAndConditionsController',
    ['$scope',
        function ($scope) {
            debugger;
            $scope.scopeData.test = function () {
                debugger;              
                $scope.ngDialog.open({
                    template: '../../../../Webresources/amx_/newSubscription/templates/termsAndConditions.htm',
                    className: 'ngdialog-theme-default',
                    scope: $scope
                });
            };
        }]);

