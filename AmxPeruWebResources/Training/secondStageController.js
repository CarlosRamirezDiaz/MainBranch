wizard.controller("secondStageController", ['$scope', '$rootScope', '$http', '$timeout',
    function ($scope, $rootScope, $http, $timeout) {

        $scope.resumeInput.data = {};


        var initiate = function () {
            debugger;
            //$rootScope.rootScopeData.translations = Wizard.GetTranslationData("6666");
            //$scope.scopeData.planning.translations.getTranslations();
            $scope.value1 = $scope.workflowContext.ResponseData.Output.trainingResumeData;


        };

        initiate();
    }]);