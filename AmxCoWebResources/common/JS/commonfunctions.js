function GetEntityRecords(entityLogicalName, entityId, pSelect, pFilter, getAsync, pOrder, pTop, pExpand) {
    /// <summary>Retorna un arreglo con los objetos json de los registros de la entidad que cumple los criterios del filtro.</summary>
    /// <param name="entityLogicalName" type="String">Nombre de la entidad a consultar, por ejemplo: Account, Contact. (la inicial debe ser en mayúscula).</param>
    /// <param name="entityId" type="String">GUID del registro que se quiere consultar.</param>
    /// <param name="pSelect" type="String">Lista de los campos que se quieren consultar, separados por coma, por ejemplo: Address1_City.</param>
    /// <param name="pFilter" type="String">Cadena de filtro para la entidad a consultar.</param>
    /// <param name="pOrder" type="String">Especifica la condición de ordenamiento.</param>
    /// <param name="pTop" type="String">Especifica la cantidad de registros por traer.</param>
    /// <param name="getAsync" type="Boolean">Indica si el request se debe hacer de manera asíncrona; true: se hace el request asíncrono; false: se hace el request síncrono.</param>
    /// <param name="pExpand" type="String">Expresión para obtener los registros relacionados con la entidad consultada.</param>

    var requestURL = Xrm.Page.context.getClientUrl() + "/XRMServices/2011/OrganizationData.svc";
    var result = [];

    getAsync = (getAsync) ? getAsync : false;

    requestURL += "/" + entityLogicalName + "Set";

    if (entityId && entityId.length > 0) {
        entityId = entityId.replace("{", "").replace("}", "");
        requestURL += "(guid'" + entityId + "')";
    }

    var dataInfo = {};

    // Identifica si el jQuery está corriendo en un iframe e invoca al padre
    if (typeof ($) === 'undefined') {
        $ = parent.$;
        jQuery = parent.jQuery;
    }

    if (pSelect) {
        dataInfo.$select = pSelect;
    }
    if (pFilter) {
        dataInfo.$filter = pFilter;
    } if (pOrder) {
        dataInfo.$orderby = pOrder;
    }
    if (pTop) {
        dataInfo.$top = pTop;
    }
    if (pExpand) {
        dataInfo.$expand = pExpand;
    }

    $.ajax({
        dataType: "json",
        async: getAsync,
        url: requestURL,
        data: dataInfo,
        success: function (data) {
            if (data.d) {
                if (data.d.results) {
                    if (data.d.results.length > 0) {
                        result = data.d.results;
                    }
                    else {
                        result = null;
                    }
                }
                else {
                    result = [data.d];
                }
            }
            else {
                result = null;
            }
        },
        error: function () {
            result = null;
        }
    });

    return result;
}

function LaunchActionNoParams (entityId, entityName, requestName) {
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
    req.open("POST", Xrm.Page.context.getClientUrl() + "/XRMServices/2011/Organization.svc/web", false)
    req.setRequestHeader("Accept", "application/xml, text/xml, */*");
    req.setRequestHeader("Content-Type", "text/xml; charset=utf-8");
    req.setRequestHeader("SOAPAction", "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Execute");
    req.send(requestXML);
    //Get the Response from the CRM Execute method
    return req;
}

function ProcessSoapError (faultXml) {
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