wizard.controller("itemConfigurationController",
    ['$scope', '$http', '$rootScope', '$q', '$window', 'uiGridConstants',
        function ($scope, $http, $rootScope, $q, $window, uiGridConstants) {

            $scope.direct = $rootScope.direct; // setting direction for RTL language
            if ($scope.direct === "rtl") {
                $scope.isRTL = true;
            }
            else {
                $scope.isRTL = false;
            }

            $scope.scopeData.GenerateResourceCharStruct = function () {
                debugger;
                
                for (var j = 0; j < $scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList.length; j++) {
                    // If max cardinality is 0, add to 1 as default
                    if ($scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList[j].productResourceCardinality.amxperu_targetcardinalitymax === 0) {
                        $scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList[j].productResourceCardinality.amxperu_targetcardinalitymax = 1;
                    }

                    // Loop if cardinality is > 0
                    if ($scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList[j].productResourceCardinality.amxperu_targetcardinalitymax > 0) {
                        if ($scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList[j].resourceCharList === undefined)
                            $scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList[j].resourceCharList = [];
                        else return;
                        
                        // Loop through max of cardinality
                        for (var i = 0; i < $scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList[j].productResourceCardinality.amxperu_targetcardinalitymax; i++) {
                            for (var w = 0; w < $scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList[j].ResourceCharValueList.length; w++) {
                                $scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList[j].resourceCharList.push({
                                    name: $scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList[j].ResourceCharValueList[w].resourceCharacteristic.amxperu_name + " " + (i + 1),
                                    value: "",
                                    nameId: $scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList[j].ResourceCharValueList[w].resourceCharacteristic.amxperu_name + (i + 1),
                                    resource: $scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList[j],
                                    resourceChar: $scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList[j].ResourceCharValueList[w]
                                });
                            }
                        }
                    }
                }
            }

            $scope.scopeData.SaveResourceChar = function () {
                debugger;
                for (var i = 0; i < $scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList.length; i++){
                    for (var j = 0; j < $scope.scopeData.currentOfferFull.ProductSpecification.ProductResourceSpecList[j].resourceCharList.length; j++) {
                        // Call to update or create resource char
                        var orderResource = {};
                    }
                }
                $scope.closeAll();
            }

            $scope.scopeData.CloseDialog = function () {
                debugger;
                $scope.closeAll();
            }

            var initiate = function () {
                debugger;
                $scope.scopeData.translations = Wizard.GetTranslationData("NewSubscriptionConfiguration");
                $scope.scopeData.GenerateResourceCharStruct();
                $scope.scopeData.emailReg = "/^(([^<>()\[\]\\.,;:\s@\"]+ (\.[^<>() \[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/";
                debugger;
            };

            initiate();
        }]);