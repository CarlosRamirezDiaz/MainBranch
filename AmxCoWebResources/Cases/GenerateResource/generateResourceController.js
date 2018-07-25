var app = angular.module("app", []);

app.controller('Ctrl', function ($scope, $filter, $http) {
    $scope.scopeData = {};
    $scope.scopeData.externalId = "";
    $scope.scopeData.disabledAll = false;
    $scope.scopeData.families = [];

    $scope.scopeData.generateResource = function (resourceType) {
        if (parent.Xrm.Page.getAttribute("amx_resource").getValue()) {
            $scope.scopeData.resource = parent.Xrm.Page.getAttribute("amx_resource").getValue();
            $scope.scopeData.launchActionNoParams($scope.scopeData.resource[0].id, "incident", "amx_ACCaseGenerateResource", resourceType);
        }
        else {
            alert("Debe seleccionar un caso para generar el recurso.");
        }
    }

    $scope.scopeData.launchActionNoParams = function (entityId, entityName, requestName, resourceType) {

        var requestXML = "";
        requestXML += "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\">";
        requestXML += "  <s:Body>";
        requestXML += "    <Execute xmlns=\"http://schemas.microsoft.com/xrm/2011/Contracts/Services\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">";
        requestXML += "    <request xmlns:a=\"http://schemas.microsoft.com/xrm/2011/Contracts\">";
        requestXML += "        <a:Parameters xmlns:b=\"http://schemas.datacontract.org/2004/07/System.Collections.Generic\">";
        requestXML += "          <a:KeyValuePairOfstringanyType>";
        requestXML += "            <b:key>Target</b:key>";
        requestXML += "            <b:value i:type=\"a:EntityReference\">";
        requestXML += "              <a:Id>" + entityId + "</a:Id>";
        requestXML += "              <a:LogicalName>" + entityName + "</a:LogicalName>";
        requestXML += "              <a:Name i:nil=\"true\" />";
        requestXML += "            </b:value>";
        requestXML += "          </a:KeyValuePairOfstringanyType>";
        requestXML += "        </a:Parameters>";
        requestXML += "        <a:RequestId i:nil=\"true\" />";
        requestXML += "        <a:RequestName>" + requestName + "</a:RequestName>";
        requestXML += "      </request>";
        requestXML += "    </Execute>";
        requestXML += "  </s:Body>";
        requestXML += "</s:Envelope>";

        var headers = {
            'Content-Type': 'text/xml; charset=utf-8',
            'Accept': 'application/xml, text/xml, */*',
            'SOAPAction': 'http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Execute'
        };

        $http.post(parent.Xrm.Page.context.getClientUrl() + "/XRMServices/2011/Organization.svc/web", requestXML, { "headers": headers })
            .success(function (data) {
                if (data) {
                    var result1 = data.split("<b:value i:type=\"c:string\" xmlns:c=\"http://www.w3.org/2001/XMLSchema\">");

                    if (result1.length > 0) {
                        var result = result1[1].split("</b:value>");

                        if (result.length > 0) {
                            parent.Xrm.Page.getAttribute("amx_resource").setValue(null);
                            parent.Xrm.Page.data.entity.save();

                            var windowOptions = {
                                openInNewWindow: false
                            };
                            var parameters = {};
                            parameters["amx_resourcetype"] = resourceType;
                            parent.Xrm.Utility.openEntityForm("incident", result[0], parameters, windowOptions);
                        }
                    }
                }
            }).error(function (data, status) {
                parent.Xrm.Page.ui.setFormNotification('' + data.Message, 'ERROR', 'msg_Action');
            });
    }

});

