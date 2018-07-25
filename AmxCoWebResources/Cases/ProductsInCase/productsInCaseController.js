var app = angular.module("app", []);

app.controller('Ctrl', function ($scope, $filter, $http) {
    $scope.scopeData = {};
    $scope.scopeData.externalId = "";
    $scope.scopeData.disabledAll = false;
    $scope.scopeData.families = [];

    $scope.scopeData.validations = {};
    $scope.scopeData.validations.constants = {
        FORM_TYPE_CREATE: 1,
        FORM_TYPE_UPDATE: 2
    };

    $scope.scopeData.config = {
        withCredentials: true
    };

    $scope.scopeData.getProductsExternalId = function () {

        if (parent.Xrm.Page.ui.getFormType() != $scope.scopeData.validations.constants.FORM_TYPE_CREATE) {
            $scope.scopeData.disabledAll = true;
        }

        if (parent.Xrm.Page.getAttribute("etel_externalid").getValue() && !parent.Xrm.Page.getAttribute("amx_productsjson").getValue()) {
            var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");

            var externalId = parent.Xrm.Page.getAttribute("etel_externalid").getValue();
            var uri = "http://172.18.88.73:7005/eoc/sr/v1/product/?relatedParties.reference=" + externalId + "&relatedParties.role=Customer";
            $scope.scopeData.workflowStartInput = {};
            $scope.scopeData.workflowStartInput.uri = uri;

            $http.post(apiUrl + 'AmxCoGetCustomerProductsFromSR', JSON.stringify($scope.scopeData.workflowStartInput), $scope.scopeData.config)
                .success(function (result) {

                    if (result) {
                        $scope.scopeData.addCustomerProducts(result.Output.srCustomerProductsResponse);
                        parent.Xrm.Page.getAttribute("amx_productsjson").setValue(JSON.stringify($scope.scopeData.families));
                        if (parent.Xrm.Page.ui.getFormType() == $scope.scopeData.validations.constants.FORM_TYPE_UPDATE) {
                            parent.Xrm.Page.data.entity.save();
                        }
                    }
                }).error(function (data, status, headers, config) {

                });
        }
        else {
            var objJson = JSON.parse(parent.Xrm.Page.getAttribute("amx_productsjson").getValue());
            $scope.scopeData.families = objJson;
        }
    }

    $scope.scopeData.addCustomerProducts = function (customerProducts) {        

        var productCase = {};
        productCase.family = "";
        productCase.name = "No aplica";
        productCase.poExternalId = "NoAp";
        productCase.srParentPoId = "";
        productCase.check = false;

        $scope.scopeData.produFamiliesAndProducts(productCase);

        for (var i = 0; i < customerProducts.length; i++) {

            var currentFamily = "";

            if (customerProducts[i].productOffering.id.includes("Int")) {
                currentFamily = "Internet";
            }
            else if (customerProducts[i].productOffering.id.includes("Tv")) {
                currentFamily = "Television";
            }
            else if (customerProducts[i].productOffering.id.includes("Tel")) {
                currentFamily = "Telefonia fija";
            }
            else if (customerProducts[i].productOffering.id.includes("Mov")) {
                currentFamily = "Telefonia Movil";
            }

            if (currentFamily != "") {
                var productCase = {};
                productCase.family = currentFamily;
                productCase.name = customerProducts[i].name;
                productCase.poExternalId = customerProducts[i].productOffering.id;
                productCase.srParentPoId = "";
                productCase.check = false;

                $scope.scopeData.produFamiliesAndProducts(productCase);
            }
        }
    }

    $scope.scopeData.produFamiliesAndProducts = function (product) {
        var booFind = false;

        for (var i = 0; i < $scope.scopeData.families.length; i++) {
            if ($scope.scopeData.families[i].name == product.family) {
                $scope.scopeData.families[i].products.push(product);
                booFind = true;
            }
        }

        if (!booFind) {
            var newFamily = {};
            newFamily.name = product.family;
            newFamily.products = [];
            newFamily.products.push(product);
            newFamily.check = false;

            $scope.scopeData.families.push(newFamily);
        }
    }

    $scope.scopeData.selectFamily = function (family) {
        for (var i = 0; i < $scope.scopeData.families.length; i++) {
            if ($scope.scopeData.families[i].name == family.name) {
                if ($scope.scopeData.families[i].check)
                    $scope.scopeData.families[i].check = false;
                else
                    $scope.scopeData.families[i].check = true;
                parent.Xrm.Page.getAttribute("amx_productsjson").setValue(JSON.stringify($scope.scopeData.families));
                if (parent.Xrm.Page.ui.getFormType() == $scope.scopeData.validations.constants.FORM_TYPE_UPDATE) {
                    parent.Xrm.Page.data.entity.save();
                }
                break;
            }
        }
    }

    $scope.scopeData.selectProduct = function (product) {
        var countSelected = 0;

        for (var i = 0; i < $scope.scopeData.families.length; i++) {
            for (var j = 0; j < $scope.scopeData.families[i].products.length; j++) {
                if ($scope.scopeData.families[i].products[j].name == product.name) {
                    if ($scope.scopeData.families[i].products[j].check)
                        $scope.scopeData.families[i].products[j].check = false;
                    else
                        $scope.scopeData.families[i].products[j].check = true;
                    parent.Xrm.Page.getAttribute("amx_productsjson").setValue(JSON.stringify($scope.scopeData.families));                    
                }

                if ($scope.scopeData.families[i].products[j].check) {
                    countSelected = countSelected + 1;
                }
            }            
        }

        if (countSelected == 0) {
            parent.Xrm.Page.getAttribute("amx_selectedproduct").setValue(false);
        }
        else {
            parent.Xrm.Page.getAttribute("amx_selectedproduct").setValue(true);
        }
    }
       

    $scope.scopeData.getProductsExternalId();

});

