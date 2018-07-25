function doSimpleSearch() {

    translationScope_JS_CustomerSearchScript.GetData();
    $('#SearchResultsGrid').datagrid('loadData', { "total": 0, "rows": [] });

    var searchText = $('#SearchText').val().trim();
    var searchType = $('#SearchType').val();

    if (searchText === "") {
        alert(translationScope_JS_CustomerSearchScript.data.tInvalidSearch);
        return false;
    }

    var request = null;
    var handler = null;
    var paging = null;
    var criteria = null;

    $('#SearchResultsGrid').datagrid({
        loader: function (param, success, error) {
            paging = new CustomerSearchCriteriaPaging(param.page, param.rows, "Name", param.order);
            request = new SubscriptionSearchRequest;
            request.UserRoles = Xrm.Page.context.getUserRoles();
            request.UserId = Xrm.Page.context.getUserId();
            criteria = SubscriptionSearchCriteria(searchText, null, null);
            handler = new CustomerSearchInfoHandler();
            handler.CustomerSearchCriteria = criteria;
            handler.CustomerSearchCriteriaPaging = paging;
            request.CustomerSearchInfoHandler = handler;
            var customerData = null;
            var searchRequest = new PrepareRequest(request);
            retrieveRecord(searchRequest, function (data, textStatus, XmlHttpRequest) { customerData = data.CustomerSearchResult; });
            if (customerData) {
                success(customerData);
            }
        },
    });
}