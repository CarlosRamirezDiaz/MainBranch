                   
wizard.controller("CatalogOffersQueryController", ['$scope', '$http', '$rootScope', 'uiGridConstants',
    function ($scope, $http, $rootScope, uiGridConstants, uiGridGroupingConstants) {
        alert('hello');
        var apiUrl = Wizard.Util.configStore.PsbRestServiceUrl;
        $scope.direct = $rootScope.direct; // setting direction for RTL language
        if ($scope.direct === "rtl") {
            $scope.isRTL = true;
        }
        else {
            $scope.isRTL = false;
        }
        var GuidEmpty = "00000000-0000-0000-0000-000000000000";

        $scope.lookFor = [
            { Id: "OfferName",       name: "OfferName" },
            { Id: "ProductCategory", name: "ProductCategory" },
            { Id: "MarketType",      name: "MarketType" },
            { Id: "PaymemtType",     name: "PaymemtType" },
            { Id: "EquimentName",    name: "EquimentName" },
        ];

        $scope.scopeData.searchOfferCatalog = function () {
            var config = {
                withCredentials: true
            };

            $scope.workflowStartInput = {
                "availableOfferingInputModel":
                {
                    "$type": "AmxPeruPSBActivities.Model.AvailableOfferingInputModel, AmxPeruPSBActivities",
                    "CharList": {
                        "$type": "System.Collections.Generic.List`1[[AmxPeruPSBActivities.Model.CharValue, AmxPeruPSBActivities]], mscorlib",
                        "$values": [
                            {
                                "$type": "AmxPeruPSBActivities.Model.CharValue, AmxPeruPSBActivities",
                                "Id": "A480B2EC-087D-E711-8126-00505601173A",
                                "Value": $scope.workflowContext.ResponseData.Output.province
                            }
                        ]
                    },
                    "ParentOfferinId": "",
                    "OfferTypeCode": "Basic"
                }

            };
            $http.post(apiUrl + 'GetAvailableOfferingConfiguration', JSON.stringify($scope.workflowStartInput), config)
                .success(function (result) {
                    if (result) {
                        $scope.scopeData.AvailableOffers = result.Output.responseModel;
                        for (var i = 0; i < $scope.scopeData.AvailableOffers.length; i++) {
                            $scope.scopeData.AvailableOffers[i].IsBasicPO = true;
                        }
                    }

                })
                .error(function(data, status, headers, config) {
                    alert((data.ExceptionMessage === undefined ?
                        (data.data === undefined ? data :
                            (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                    $scope.httpLoading = false;
                })
                .finally(function() {
                    //$scope.httpLoading = false;
                });

        };
    }]);