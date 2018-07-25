wizard.controller("changeResumeDateController", ['$scope', '$rootScope', '$http', '$timeout', function ($scope, $rootScope, $http, $timeout)
{
   
    $rootScope.rootScopeData = {};
    var apiUrl = Wizard.Util.configStore.PsbRestServiceUrl;

    $scope.direct = $rootScope.direct; // setting direction for RTL language
    if ($scope.direct === "rtl") {
        $scope.isRTL = true;
    }
    else {
        $scope.isRTL = false;
    }

    $scope.resumeInput.data = {};
    $scope.resumeInput.data.resumeChangeDateInput={};

    

     var d = new Date();
     $scope.dtSartDate = d.getDate();
     $scope.dtEndDate = d.getDate();
     $scope.remainingDays = 20;
     $scope.newResumeDate = d.getDate();


     $scope.validateData = function ()
     {



     }



     $scope.checkData = function () {

         $scope.resumeInput.data.resumeChangeDateInput.dtSartDate = $scope.dtSartDate;
         $scope.resumeInput.data.resumeChangeDateInput.dtEndDate = $scope.dtEndDate;
         $scope.resumeInput.data.resumeChangeDateInput.remainingDays = $scope.remainingDays;
         $scope.resumeInput.data.resumeChangeDateInput.newResumeDate = $scope.newResumeDate;

     }
     $scop.dateDiff = function ()
     {

     }
}]);