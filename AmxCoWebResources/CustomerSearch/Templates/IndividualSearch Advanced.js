var individualSearchConstants = new (function () {
    this.Namespace = '#Ericsson.ETELCRM.CommonServiceLibrary.Message';
    this.RequestName = 'ContactSearchRequest';
})();

function initIndividualSearchForm() {
    prepareIndividualSearchFormControls();
    keyPublisher.subscribe(individualKeyListener);
}

var individualKeyListener = function (message) {
    if (message == 'SearchIndividuals')
        doIndividualCustomerSearch();
};

function prepareIndividualSearchFormControls() {
    $("#IndividualCustomerCountry").combobox({ editable: true });
    $("#IndividualCustomerCity").combobox({ editable: true });
    $("#IndividualCustomerStatus").combobox({
        data: [
            { label: "Active", value: 1 },
            { label: "Prospect", value: 831260000 },
            { label: "Passive", value: 831260001 },
            { label: "Suspend", value: 831260002 },
            { label: "Not Customer", value: 831260003 },
            { label: "Inactive", value: 2 }
        ],
        valueField: "value",
        textField: "label",
        editable: false
    });
    $("#IndividualCustomerIsPaymentResponsible").combobox({
        data: [
            { label: "Yes", value: true },
            { label: "No", value: false }
        ],
        valueField: "value",
        textField: "label",
        editable: false
    });
    $("#IndividualCustomerStatus").combobox("clear");
    $("#IndividualCustomerIsPaymentResponsible").combobox("clear");

    var individualCountryData = Util.getCountries();

    if (individualCountryData) {
        $("#IndividualCustomerCountry").combobox({
            data: individualCountryData,
            valueField: "ID",
            textField: "Name",
            editable: true,
            onSelect: function (record) {
                if (record) {
                    var cityData = Util.getCities(record.ID);
                    if (cityData) {
                        $("#IndividualCustomerCity").combobox({
                            data: cityData,
                            valueField: "ID",
                            textField: "Name",
                            editable: true
                        });
                    }
                }
            },
        });
    }
}

function cleanIndividualSearchForm() {
    $('#IndividualCustomerFirstName').val("");
    $('#IndividualCustomerLastName').val("");
    $('#IndividualCustomerIdentityNo').val("");
    $('#IndividualCustomerExternalID').val("");
    $('#IndividualCustomerAccountNumber').val("");
    $('#IndividualCustomerInvoiceNumber').val("");
    $('#IndividualCustomerPhone').val("");
    $('#IndividualCustomerEmail').val("");
    $('#IndividualCustomerCountry').combobox("setValue", "");
    $('#IndividualCustomerCity').combobox("setValue", "");
    $('#IndividualCustomerCity').combobox({ data: [] });
    $('#IndividualCustomerStatus').combobox("clear");
    $('#IndividualCustomerIsPaymentResponsible').combobox("clear");
    $('#SearchResultsGrid').datagrid('loadData', { "total": 0, "rows": [] });
}

var ContactSearchCriteria = function (invoiceNumber, firstName, lastName, fullName, identityNo, externalId, accountNumber, phone, email, country, city, status) {
    var searchCriteria = {};
    searchCriteria["InvoiceNumber"] = invoiceNumber;
    searchCriteria["FirstName"] = firstName;
    searchCriteria["LastName"] = lastName;
    searchCriteria["FullName"] = fullName;
    searchCriteria["IdentityNo"] = identityNo;
    searchCriteria["ExternalId"] = externalId;
    searchCriteria["AccountNumber"] = accountNumber;
    searchCriteria["Phone"] = phone;
    searchCriteria["Email"] = email;
    searchCriteria["Country"] = country;
    searchCriteria["City"] = city;
    searchCriteria["Status"] = status;
    return JSON.stringify(searchCriteria);
};

var ContactSearchRequest = function (customerSearchInfoHandler) {
    this.__type = individualSearchConstants.RequestName + ':' + individualSearchConstants.Namespace;
    this.CustomerSearchInfoHandler = customerSearchInfoHandler;
};

function doIndividualCustomerSearch() {
    translationScope_JS_CustomerSearchScript.GetData();
    $('#SearchResultsGrid').datagrid('loadData', { "total": 0, "rows": [] });

    var individualCustomerInvoiceNumberText = $('#IndividualCustomerInvoiceNumber').val().trim();
    var individualCustomerFirstNameText = $('#IndividualCustomerFirstName').val().trim();
    var individualCustomerLastNameText = $('#IndividualCustomerLastName').val().trim();
    var individualCustomerIdentityNoText = $('#IndividualCustomerIdentityNo').val().trim();
    var individualCustomerExternalIDText = $('#IndividualCustomerExternalID').val().trim();
    var individualCustomerAccountNumberText = $('#IndividualCustomerAccountNumber').val().trim();
    var individualCustomerPhoneText = $('#IndividualCustomerPhone').val().trim();
    var individualCustomerEmailText = $('#IndividualCustomerEmail').val().trim();
    var individualCustomerCountryText = $('#IndividualCustomerCountry').combobox("getValue");
    var individualCustomerCityText = $('#IndividualCustomerCity').combobox("getValue");
    var individualCustomerStatusText = $('#IndividualCustomerStatus').combobox("getValue");

    if (individualCustomerInvoiceNumberText == "" &&
        individualCustomerFirstNameText == "" &&
        individualCustomerLastNameText == "" &&
        individualCustomerIdentityNoText == "" &&
        individualCustomerExternalIDText == "" &&
        individualCustomerAccountNumberText == "" &&
        individualCustomerPhoneText == "" &&
        individualCustomerEmailText == "" &&
        individualCustomerCountryText == "" &&
        individualCustomerCityText == "" &&
        individualCustomerStatusText == "") {
        alert(translationScope_JS_CustomerSearchScript.data.tInvalidSearch);
        return false;
    }

    individualCustomerStatusText = individualCustomerStatusText == "" ? null : individualCustomerStatusText;

    var request = null;
    var handler = null;
    var paging = null;
    var criteria = null;

    $('#SearchResultsGrid').datagrid({
        loader: function (param, success, error) {
            paging = new CustomerSearchCriteriaPaging(param.page, param.rows, "FirstName", param.order);

            criteria = ContactSearchCriteria(individualCustomerInvoiceNumberText,
                                                 individualCustomerFirstNameText,
                                                 individualCustomerLastNameText,
                                                 null,
                                                 individualCustomerIdentityNoText,
                                                 individualCustomerExternalIDText,
                                                 individualCustomerAccountNumberText,
                                                 individualCustomerPhoneText,
                                                 individualCustomerEmailText,
                                                 individualCustomerCountryText,
                                                 individualCustomerCityText,
                                                 individualCustomerStatusText);

            var searchType = $('#SearchType').val();
            request = new ContactSearchRequest();
            request.UserRoles = Xrm.Page.context.getUserRoles();
            request.UserId = Xrm.Page.context.getUserId();

            handler = new CustomerSearchInfoHandler();
            handler.CustomerSearchCriteria = criteria;
            handler.CustomerSearchCriteriaPaging = paging;
            handler.CustomerSearchType = searchType;

            request.CustomerSearchInfoHandler = handler;

            var customerData = null;
            var searchRequest = new PrepareRequest(request);
            retrieveRecord(searchRequest, function (data, textStatus, XmlHttpRequest) { customerData = data.CustomerSearchResult; });

            if (customerData) {
                success(customerData);
            }
        }
    });
}

initIndividualSearchForm();