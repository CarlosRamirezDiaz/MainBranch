initSearchByDocType();

function initSearchByDocType() {
    var optionSetDocTypeData = GetOptionSetData("amxperu_documenttype");
    for (var i = 0; i < optionSetDocTypeData.length; i++) {
        $('#SearchDocType')
            .append($("<option>" + optionSetDocTypeData[i].Text + "</option>")
                .attr("value", optionSetDocTypeData[i].Value)
                .text(optionSetDocTypeData[i].Text));
    }
}

function doSimpleSearch() {
    translationScope_JS_CustomerSearchScript.GetData();
    $('#SearchResultsGrid').datagrid('loadData', { "total": 0, "rows": [] });

    var searchCriteria = $('#SearchDocType').val();
    var searchText = $('#SearchDocId').val().trim();

    //CRM Optionset Values
    var CEDULA_DE_CIUDADANIA = "1";
    var NIT = "2";
    var NIT_DE_EXTRANJERIA = "3";
    var CEDULA_EXTRANJERIA = "4";
    var PASAPORTE = "5";
    var CARNET_DIPLOMATICO = "6";
    var TARJETA_DE_IDENTIDAD = "7";
    var TARJETA_DE_EXTRANJERIA = "8";
    var REGISTRO_DE_NACIMIENTO = "9";

    //Doc Id length as per Doc Type
    var DocIdLength_CEDULA_DE_CIUDADANIA = 1;
    var DocIdLength_NIT = 1;
    var DocIdLength_NIT_DE_EXTRANJERIA = 1;
    var DocIdLength_CEDULA_EXTRANJERIA = 1;
    var DocIdLength_PASAPORTE = 1;
    var DocIdLength_CARNET_DIPLOMATICO = 1;
    var DocIdLength_TARJETA_DE_IDENTIDAD = 1;
    var DocIdLength_TARJETA_DE_EXTRANJERIA = 1;
    var DocIdLength_REGISTRO_DE_NACIMIENTO = 1;

    var DocIdValidationAlert = "For Document type {0}, document number must be at least {1} Characters";

    if (searchCriteria != null) {
        if (searchCriteria == CEDULA_DE_CIUDADANIA) {
            if (searchText.length < DocIdLength_CEDULA_DE_CIUDADANIA) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, "CEDULA DE CIUDADANIA", DocIdLength_CEDULA_DE_CIUDADANIA);
                alert(DocIdValidationAlert);
                $('#SearchDocId').val("");
            }
        }
        else if (searchCriteria == NIT) {
            if (searchText.length < DocIdLength_NIT) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, "NIT", DocIdLength_NIT);
                alert(DocIdValidationAlert);
                $('#SearchDocId').val("");
            }
        }
        else if (searchCriteria == NIT_DE_EXTRANJERIA) {
            if (searchText.length < DocIdLength_NIT_DE_EXTRANJERIA) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, "NIT DE EXTRANJERIA", DocIdLength_NIT_DE_EXTRANJERIA);
                alert(DocIdValidationAlert);
                $('#SearchDocId').val("");
            }
        }
        else if (searchCriteria == CEDULA_EXTRANJERIA) {
            if (searchText.length < DocIdLength_CEDULA_EXTRANJERIA) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, "CEDULA EXTRANJERIA", DocIdLength_CEDULA_EXTRANJERIA);
                alert(DocIdValidationAlert);
                $('#SearchDocId').val("");
            }
        }
        else if (searchCriteria == PASAPORTE) {
            if (searchText.length < DocIdLength_PASAPORTE) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, "PASAPORTE", DocIdLength_PASAPORTE);
                alert(DocIdValidationAlert);
                $('#SearchDocId').val("");
            }
        }
        else if (searchCriteria == CARNET_DIPLOMATICO) {
            if (searchText.length < DocIdLength_CARNET_DIPLOMATICO) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, "CARNET DIPLOMATICO", DocIdLength_CARNET_DIPLOMATICO);
                alert(DocIdValidationAlert);
                $('#SearchDocId').val("");
            }
        }
        else if (searchCriteria == TARJETA_DE_IDENTIDAD) {
            if (searchText.length < DocIdLength_TARJETA_DE_IDENTIDAD) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, "TARJETA DE IDENTIDAD", DocIdLength_TARJETA_DE_IDENTIDAD);
                alert(DocIdValidationAlert);
                $('#SearchDocId').val("");
            }
        }
        else if (searchCriteria == TARJETA_DE_EXTRANJERIA) {
            if (searchText.length < DocIdLength_TARJETA_DE_EXTRANJERIA) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, "TARJETA DE EXTRANJERIA", DocIdLength_TARJETA_DE_EXTRANJERIA);
                alert(DocIdValidationAlert);
                $('#SearchDocId').val("");
            }
        }
        else if (searchCriteria == REGISTRO_DE_NACIMIENTO) {
            if (searchText.length < DocIdLength_REGISTRO_DE_NACIMIENTO) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, "REGISTRO DE NACIMIENTO", DocIdLength_REGISTRO_DE_NACIMIENTO);
                alert(DocIdValidationAlert);
                $('#SearchDocId').val("");
            }
        }
    }

    if (searchText === "") {
        alert(translationScope_JS_CustomerSearchScript.data.tInvalidSearch);
        return false;
    }
    else if ($('#SearchDocId').val().trim() != "") {
        var LookFor = $('#LookFor :selected').text();
        var SearchDocType = $('#SearchDocType').val();
        var SearchDocId = $('#SearchDocId').val().trim();
        var request = null;
        var handler = null;
        var paging = null;
        var criteria = null;

        customerData = new Array();
        $('#SearchResultsGrid').datagrid({
            loader: function (param, success, error) {
                paging = new CustomerSearchCriteriaPaging(param.page, param.rows, "Name", param.order);
                //request = new SubscriptionSearchRequest();
                // request.UserRoles = Xrm.Page.context.getUserRoles();
                // request.UserId = Xrm.Page.context.getUserId();
                // criteria = SubscriptionSearchCriteria(searchText, null, null);
                handler = new CustomerSearchInfoHandler();
                //handler.CustomerSearchCriteria = criteria;
                handler.CustomerSearchCriteriaPaging = paging;
                // request.CustomerSearchInfoHandler = handler;
                //var searchRequest = new PrepareRequest(request);
                var customerType = $("input:radio[name=CustomerType]:checked").val();
                //                if (customerType == "Individuals") {
                fetchcustomer();
                //                }
                if (customerData) {
                    success(customerData);
                }
            },
        });

        function fetchcustomer(customerData) {
            var fetchIndividual = "<fetch distinct='false' no-lock='true' mapping='logical' output-format='xml-platform' version='1.0'>"
                + "<entity name='contact'>"
                + amx_CustomerSearch.Contact_Attributes
                + "<order descending='false' attribute='fullname'/>"
                + "<filter type='and'>"
                + "<condition attribute='etel_iddocumentnumber' value='" + SearchDocId + "' operator='eq'/>"
                + "<condition attribute='amxperu_documenttype' value='" + SearchDocType + "' operator='eq'/>"
                + "</filter>"
                + "</entity>"
                + "</fetch>";
            var customerinfo = XrmServiceToolkit.Soap.Fetch(fetchIndividual);
            var resultSet;
            if (customerinfo.length > 0) {
                amx_CustomerSearch.InitialiseObject(customerinfo.length, customerinfo);
            }
        }
    }
}

function FormatString(str) {
    var args = Array.prototype.slice.call(arguments, 1);
    return str.replace(/\{(\d+)\}/g, function (match, index) {
        return args[index];
    });
}

