var validations = {};
validations.constants = {
    FORM_TYPE_CREATE: 1,
    FORM_TYPE_UPDATE: 2
};

function onLoadForm() {

    Xrm.Page.data.entity.save();

    if (Xrm.Page.ui.getFormType() == validations.constants.FORM_TYPE_CREATE) {

        Xrm.Page.data.entity.save();
    }

    if (Xrm.Page.ui.getFormType() == validations.constants.FORM_TYPE_UPDATE && !Xrm.Page.getAttribute("amx_sincronized").getValue()) {
        prefilterBillingAccounts();

        var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");

        var individual = Xrm.Page.getAttribute("amx_individualcustomer").getValue();

        var workflowStartInput = {
            "Individuald": "" + individual[0].id + ""
        };

        jQuery.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            data: JSON.stringify(workflowStartInput),
            async: false,
            cache: false,
            url: apiUrl + 'AmxCoCreateItemsAccountWithDataBSCS',
            xhrFields: {
                withCredentials: true
            },
            beforeSend: function (XMLHttpRequest) {

                XMLHttpRequest.setRequestHeader("Accept", "application/json");
            },
            success: function (data, textStatus, XmlHttpRequest) {
                if (data) {

                    if (data.Output.CreateItemsAccountWithDataBSCSResponse.error) {

                        alert("Se produjo un error generando la lista de cuentas y contratos: " + data.Output.CreateItemsAccountWithDataBSCSResponse.message);
                    }
                    else {

                        Xrm.Page.getAttribute("amx_sincronized").setValue(true);
                        Xrm.Page.data.refresh(true).then(function () {
                            Xrm.Utility.openEntityForm(Xrm.Page.data.entity.getEntityName(), Xrm.Page.data.entity.getId());
                        }, null);
                    }
                }
            },
            error: function (XmlHttpRequest, textStatus, errorThrown) {

            }
        });
    }
}

function prefilterBillingAccounts() {

    var viewId = '{0CBC820C-7033-4AFF-9CE8-FB610464DBD3}';
    var entityName = "amx_itembillingaccount";
    var viewDisplayName = "Cuentas origen";

    var fetchXml = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
        "<entity name='amx_itembillingaccount'>" +
        "<attribute name='amx_name' />" +
        "<attribute name='amx_itembillingaccountid' />" +
        "<filter type='and'><condition attribute='amx_biinternalandexternal' operator='eq' value='" + Xrm.Page.data.entity.getId() + "' /></filter></entity></fetch>";

    var layoutXml = "<grid name='resultset' object='1' jump='name' select='1' icon='1' preview='1'>" +
        "<row name='result' id='amx_itembillingaccountid'>" +
        "<cell name='amx_name' width='150' />" +
        "<cell name='amx_itembillingaccountid' width='150' />" +
        "</row>" +
        "</grid>";

    Xrm.Page.getControl("amx_accountfrom").addCustomView(viewId, entityName, viewDisplayName, fetchXml, layoutXml, true);
    Xrm.Page.getControl("amx_accountfrom").setDefaultView(viewId.toUpperCase());

    var viewId2 = '{0CBC820C-7033-4AFF-9CE8-FB610464DBD4}';
    var entityName2 = "amx_itembillingaccount";
    var viewDisplayName2 = "Cuentas destino";

    var fetchXml2 = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
        "<entity name='amx_itembillingaccount'>" +
        "<attribute name='amx_name' />" +
        "<attribute name='amx_itembillingaccountid' />" +
        "<filter type='and'><condition attribute='amx_biinternalandexternal' operator='eq' value='" + Xrm.Page.data.entity.getId() + "' /></filter></entity></fetch>";

    var layoutXml2 = "<grid name='resultset' object='1' jump='name' select='1' icon='1' preview='1'>" +
        "<row name='result' id='amx_itembillingaccountid'>" +
        "<cell name='amx_name' width='150' />" +
        "<cell name='amx_itembillingaccountid' width='150' />" +
        "</row>" +
        "</grid>";

    Xrm.Page.getControl("amx_accountto").addCustomView(viewId2, entityName2, viewDisplayName2, fetchXml2, layoutXml2, true);
    Xrm.Page.getControl("amx_accountto").setDefaultView(viewId2.toUpperCase());
}

EnableField = function (fieldName, enabled) {
    if (Xrm.Page.getControl(fieldName)) {
        Xrm.Page.getControl(fieldName).setDisabled(!enabled);
    }
}

function CascadeBehavior(isOnLoad, nameField1, nameField2) {
    var field1 = Xrm.Page.getAttribute(nameField1);
    var field2 = Xrm.Page.getAttribute(nameField2);

    if (field2 && isOnLoad === false) {
        field2.setValue(null);
        field2.fireOnChange();
    }

    if (field1 && field1.getValue()) {
        EnableField(nameField2, true);
    }
    else {
        EnableField(nameField2, false);
    }
}

function AccountFrom_AccountTo_OnChange(isOnLoad) {
    CascadeBehavior(isOnLoad, "amx_accountfrom", "amx_accountto");
}

function AccountFrom_Contracts_OnChange(isOnLoad) {
    CascadeBehavior(isOnLoad, "amx_accountfrom", "amx_contractaccount");
}

function simulateChangesButton() {


    var titleName = "Condiciones cambio de ciclo";
    var wMessage = AMX.COMMON.RetrieveKBArticleByTitle(titleName);

    if (wMessage != null) {
        Alert.show(wMessage, "", [new Alert.Button("Aceptar",
            function () {

                var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");

                var contractOrigin = Xrm.Page.getAttribute("amx_contractaccount").getValue();
                var customer = Xrm.Page.getAttribute("amx_individualcustomer").getValue();

                var workflowStartInput = {
                    'GenerateSimulationRequest': {
                        '$type': 'AmxPeruPSBActivities.Model.InternalExternalAccount.AmcCoGenerateSimulationRequest, AmxPeruPSBActivities',
                        'CustomerId': "" + customer[0].id,
                        "ContractId": "" + contractOrigin[0].id
                    }
                };

                jQuery.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: JSON.stringify(workflowStartInput),
                    async: false,
                    cache: false,
                    url: apiUrl + 'AmcCoGenerateSimulation',
                    xhrFields: {
                        withCredentials: true
                    },
                    beforeSend: function (XMLHttpRequest) {
                        XMLHttpRequest.setRequestHeader("Accept", "application/json");
                    },
                    success: function (data, textStatus, XmlHttpRequest) {
                        if (data) {

                            Alert.show(data.Output.GenerateSimulationResponse.infoSimulation, "", [new Alert.Button("Aceptar",
                                function () { }, false, false)], "INFO", 1000, 600);
                        }
                    },
                    error: function (XmlHttpRequest, textStatus, errorThrown) {
                    }
                });
            }, false, false), new Alert.Button("No acepto", function () {
                // Button is added not accept for the solution of the incidence 18722.
                // Start of implementation
                var titleName = "No acepta escalar factura";
                var wMessage = AMX.COMMON.RetrieveKBArticleByTitle(titleName);

                if (wMessage != null) {
                    Alert.show(wMessage, "", [new Alert.Button("Ok", function () {

                        var entityId = Xrm.Page.data.entity.getId();
                        var entityName = Xrm.Page.data.entity.getEntityName();

                        var request = LaunchActionNoParams(entityId, entityName, "amx_ACIncludeAndExcludeUpdateForDigitalDate");

                        if (request.status == 200) {
                            var individual = Xrm.Page.getAttribute("amx_individualcustomer").getValue();
                            var entityId = individual[0].id;
                            var entityName = individual[0].entityType;
                            Xrm.Utility.openEntityForm(entityName, entityId);
                        } else {
                            var error = ProcessSoapError(request.responseXML);
                            Xrm.Page.ui.setFormNotification('' + error, 'ERROR', 'msg_Action');
                        }
                    }, false, false)], "INFO", 500, 200);
                }
                // End of implementation
            }, false, false)], "INFO", 750, 300);
    }
}

function submitChangesButton() {

    if (Xrm.Page.getAttribute("amx_contractaccount").getValue() && Xrm.Page.getAttribute("amx_accountto").getValue()) {
        var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");
        var contractOrigin = Xrm.Page.getAttribute("amx_contractaccount").getValue();
        var accountTo = Xrm.Page.getAttribute("amx_accountto").getValue();

        var workflowStartInput = {
            'BAAssignmentRequest': {
                '$type': 'AmxPeruPSBActivities.Model.InternalExternalAccount.AmxCoBillingAccountAssignmentRequest, AmxPeruPSBActivities',
                'BillingAccountId': "" + accountTo[0].id,
                "ContractId": "" + contractOrigin[0].id
            }
        };

        jQuery.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            data: JSON.stringify(workflowStartInput),
            async: false,
            cache: false,
            url: apiUrl + 'AmxCoBAAssignment',
            xhrFields: {
                withCredentials: true
            },
            beforeSend: function (XMLHttpRequest) {
                XMLHttpRequest.setRequestHeader("Accept", "application/json");
            },
            success: function (data, textStatus, XmlHttpRequest) {
                if (data) {

                    alert("Se ha realizado el envío de la información.");
                }
            },
            error: function (XmlHttpRequest, textStatus, errorThrown) {

                alert("Se ha presentado un error");
            }
        });
    }
    else {
        alert("Es necesario seleccionar un contrato y una cuenta destino.");
    }
}

function LaunchActionNoParams(entityId, entityName, requestName) {
    /// <summary>Ejecuta un Custom Action teniendo en cuenta el Id de la entidad, el nombre de la entidad y el nombre único del Action. Retorna el request después de haberlo ejecutado.</summary>
    /// <param name="entityId" type="String">Id de la entidad donde está el Action</param>
    /// <param name="entityName" type="String">Nombre lógico de la entidad donde está el Action.</param>
    /// <param name="requestName" type="String">Nombre único del Action a ejecutar.</param>
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

    var req = new XMLHttpRequest();
    req.open("POST", parent.Xrm.Page.context.getClientUrl() + "/XRMServices/2011/Organization.svc/web", false)
    req.setRequestHeader("Accept", "application/xml, text/xml, */*");
    req.setRequestHeader("Content-Type", "text/xml; charset=utf-8");
    req.setRequestHeader("SOAPAction", "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Execute");
    req.send(requestXML);
    //Get the Response from the CRM Execute method
    return req;
}

function ProcessSoapError(faultXml) {
    ///<summary>
    /// Parses the WCF fault returned in the event of an error.
    ///</summary>
    ///<param name="faultXml" Type="XML">
    /// The responseXML property of the XMLHttpRequest response.
    ///</param>
    var errorMessage = "Unknown Error (Unable to parse the fault)";
    if (typeof faultXml == "object") {
        try {
            var bodyNode = faultXml.firstChild.firstChild;
            //Retrieve the fault node
            for (var i = 0; i < bodyNode.childNodes.length; i++) {
                var node = bodyNode.childNodes[i];

                //NOTE: This comparison does not handle the case where the XML namespace changes
                if ("s:Fault" == node.nodeName) {
                    for (var j = 0; j < node.childNodes.length; j++) {
                        var faultStringNode = node.childNodes[j];
                        if ("faultstring" == faultStringNode.nodeName) {
                            errorMessage = faultStringNode.textContent;
                            break;
                        }
                    }
                    break;
                }
            }
        }
        catch (e) { };
    }
    return new Error(errorMessage);
}