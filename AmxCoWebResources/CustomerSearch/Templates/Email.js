function doSimpleSearch() {
    translationScope_JS_CustomerSearchScript.GetData();
    $('#SearchResultsGrid').datagrid('loadData', { "total": 0, "rows": [] });

    var searchText = $('#SearchText').val().trim();

    if (searchText === "") {
        alert(translationScope_JS_CustomerSearchScript.data.tInvalidSearch);
        return false;
    }
    var LookFor = $('#LookFor :selected').text();
    var request = null;
    var handler = null;
    var paging = null;
    var criteria = null;

    customerData = new Array();
    $('#SearchResultsGrid').datagrid({
        loader: function (param, success, error) {
            paging = new CustomerSearchCriteriaPaging(param.page, param.rows, "Name", param.order);
            handler = new CustomerSearchInfoHandler();
            handler.CustomerSearchCriteriaPaging = paging;
            var customerType = $("input:radio[name=CustomerType]:checked").val();
            //                if (customerType == "Individuals") {
            fetchcustomer(searchText);
            //                }
            if (customerData) {
                success(customerData);
            }
        },
    });

    function fetchcustomer(searchText) {
        var fetchIndividual = "<fetch distinct='false' no-lock='true' mapping='logical' output-format='xml-platform' version='1.0'>"
			+ "<entity name='contact'>"
            + amx_CustomerSearch.Contact_Attributes
			+ "<order descending='false' attribute='fullname'/>"
			+ "<filter type='or'>"
			+ "<condition attribute='emailaddress1' value='" + searchText + "' operator='eq'/>"
			+ "<condition attribute='emailaddress2' value='" + searchText + "' operator='eq'/>"
			+ "<condition attribute='emailaddress3' value='" + searchText + "' operator='eq'/>"
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

function FormatString(str) {
    var args = Array.prototype.slice.call(arguments, 1);
    return str.replace(/\{(\d+)\}/g, function (match, index) {
        return args[index];
    });
}

