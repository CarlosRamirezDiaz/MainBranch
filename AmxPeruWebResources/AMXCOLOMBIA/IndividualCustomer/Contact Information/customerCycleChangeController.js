var app = angular.module("app", ["xeditable", "ngMockE2E"]);

app.run(function (editableOptions) {
    editableOptions.theme = 'bs3';
});

app.controller('Ctrl', function ($scope, $filter, $http) {

    $scope.contracts = [];
    $scope.cycles = [];

    $scope.getContractsByCustomer = function () {
        debugger;

        var customer = parent.Xrm.Page.getAttribute("amx_customerid").getValue()

        if (customer) {

            var request = {
                'GetContractsByCustomerRequest': {
                    '$type': 'AmxPeruPSBActivities.Model.Individual.AmxCoGetContractsByCustomerRequest, AmxPeruPSBActivities',
                    'customerid': customer[0].id,
                }
            };

            $scope.apiUrl = "http://172.18.88.70:6004/api/v1/workflow/";

            //$http.post($scope.apiUrl + 'AmxCoGetContractsByCustomer', JSON.stringify(request))
            //    .success(function (result) {

            //        alert('Respondió');

            //    }).error(function (data) {

            //        alert('Error');
            //    });

            jQuery.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                data: JSON.stringify(request),
                async: false,
                cache: false,
                url: 'http://100.126.0.19:6004/api/v1/workflow/AmxCoGetContractsByCustomer',
                xhrFields: {
                    withCredentials: true
                },
                beforeSend: function (XMLHttpRequest) {
                    XMLHttpRequest.setRequestHeader("Accept", "application/json");
                },
                success: function (data, textStatus, XmlHttpRequest) {
                    console.log(data);
                    if (data) {

                        if (data.Output.GetContractsByCustomerResponse.Error == false) {

                            if (data.Output.GetContractsByCustomerResponse.Contracts) {

                                $scope.contracts = data.Output.GetContractsByCustomerResponse.Contracts;
                                $scope.cycles = data.Output.GetContractsByCustomerResponse.Cyclies;
                            }
                        }
                        else {

                            if (data.Output.GetContractsByCustomerResponse.ErrorDetail) {
                                console.log(data.Output.GetContractsByCustomerResponse.ErrorDetail[0]);
                            }
                        }
                    }
                },
                error: function (XmlHttpRequest, textStatus, errorThrown) {
                    console.log(data);
                    console.log("Se presento un error al enviar la encuesta")
                }
            });
        }

    };

    $scope.validate = function () {
        alert("Aqui se envia el cambio de ciclo.");
    }

    $scope.getContractsByCustomer();


});