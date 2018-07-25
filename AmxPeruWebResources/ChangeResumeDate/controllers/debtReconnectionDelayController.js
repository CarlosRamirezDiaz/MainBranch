wizard.controller("debtReconnectionDelayController", ['$scope', '$rootScope', '$http', '$timeout', function ($scope, $rootScope, $http, $timeout) {

    debugger;
    $rootScope.rootScopeData = {};
    var apiUrl = Wizard.Util.configStore.PsbRestServiceUrl;

    $scope.direct = $rootScope.direct; // setting direction for RTL language
    if ($scope.direct === "rtl") {
        $scope.isRTL = true;
    }
    else {
        $scope.isRTL = false;
    }

    

}]);