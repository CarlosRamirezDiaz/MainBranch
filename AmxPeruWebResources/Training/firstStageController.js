wizard.controller("firstStageController", ['$scope', '$rootScope', '$http', '$timeout',
    function ($scope, $rootScope, $http, $timeout) {

        $scope.resumeInput.data = {};        


        $scope.workflowNextValidate = function () {

        }

    var initiate = function () {
        debugger;
        //$rootScope.rootScopeData.translations = Wizard.GetTranslationData("6666");
        //$scope.scopeData.planning.translations.getTranslations();
        $scope.value1 = $scope.workflowContext.ResponseData.Output.trainingVariable;


    };

    initiate();
}]);