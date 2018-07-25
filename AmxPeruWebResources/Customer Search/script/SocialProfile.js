function doSimpleSearch() {
    debugger;
    translationScope_JS_CustomerSearchScript.GetData();
    $('#SearchResultsGrid').datagrid('loadData', { "total": 0, "rows": [] });

    var searchCriteria = $('#LookFor').val().trim();
    var SocialMediaType = $('#SocialMediaType').val();
    var SocialMediaId = $('#SocialMediaId').val().trim();


    if (SocialMediaId === "") {
        alert(translationScope_JS_CustomerSearchScript.data.tInvalidSearch);
        return false;
    }
    else if (SocialMediaId != "") {
        debugger;
        var request = null;
        var handler = null;
        var paging = null;
        var criteria = null;

        customerData = new Array();
        $('#SearchResultsGrid').datagrid({
            loader: function (param, success, error) {
                paging = new CustomerSearchCriteriaPaging(param.page, param.rows, "Name", param.order);
                request = new SubscriptionSearchRequest;
                request.UserRoles = Xrm.Page.context.getUserRoles();
                request.UserId = Xrm.Page.context.getUserId();
                // criteria = SubscriptionSearchCriteria(searchText, null, null);
                handler = new CustomerSearchInfoHandler();
                //handler.CustomerSearchCriteria = criteria;
                handler.CustomerSearchCriteriaPaging = paging;
                request.CustomerSearchInfoHandler = handler;
                var searchRequest = new PrepareRequest(request);
                var customerType = $("input:radio[name=CustomerType]:checked").val();
                if (customerType == "Individuals") {
                    fetchcustomer();
                }
                if (customerData) {

                    success(customerData);
                }
            },
        });

        function fetchcustomer(customerData) {
            debugger;
            var fetchIndividual = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
                + "<entity name='contact'>"
                + "<attribute name='fullname'/>"
                + "<attribute name='contactid'/>"
                + "<attribute name='statuscode'/>"
                + "<attribute name='statecode'/>"
                + "<attribute name='address1_line1'/>"
                + "<attribute name='etel_passportnumber'/>"
                + "<attribute name='etel_accountnumber'/>"
                + "<order descending='false' attribute='fullname'/>"
                + "<filter type='and'>"
                + "<condition attribute='" + SocialMediaType + "' value='" + SocialMediaId + "' operator='eq'/>"
                + "</filter>"
                + "</entity>"
                + "</fetch>";
            var customerinfo = XrmServiceToolkit.Soap.Fetch(fetchIndividual);
            var resultSet;
            if (customerinfo.length > 0) {
                InitialiseObject(customerinfo.length, customerinfo);
            }
        }


        function InitialiseObject(length, customerinfo) {

            customerData[length - 1] =
                {
                    "AccountNumber": "",
                    "Address": "",
                    "CustomerID": "",
                    "CustomerStatus": "",
                    "CustomerStatusValue": "",
                    "CustomerType": "",
                    "IdentityNo": "",
                    "MSISDN": "",
                    "Name": "",
                    "ParentAccount": "",
                    "ParentAccountId": "",
                    "SubscriptionStatus": ""
                }
            for (var item = 0; item < length; item++) {

                if (customerinfo[item].attributes["etel_accountnumber"] != undefined && customerinfo[item].attributes["etel_accountnumber"] != null) {
                    customerData[item].AccountNumber = customerinfo[item].attributes["etel_accountnumber"].value;

                    if (customerinfo[item].attributes["address1_line1"] != undefined && customerinfo[item].attributes["address1_line1"] != null && customerinfo[item].attributes["address1_line2"] != undefined && customerinfo[item].attributes["address1_line2"] != null) {
                        //customerData[item].Address = customerinfo[item].attributes["address1_line1"].value + " " + customerinfo[item].attributes["address1_line2"].value + " " + customerinfo[item].attributes["address1_line3"].value + " " + customerinfo[item].attributes["etel_cityid"].name + " " + customerinfo[item].attributes["etel_countryid"].name;
                        var address1 = (customerinfo[item].attributes["address1_line1"] != undefined && customerinfo[item].attributes["address1_line1"] != null) ? customerinfo[item].attributes["address1_line1"].value : "";
                        var address2 = (customerinfo[item].attributes["address1_line2"] != undefined && customerinfo[item].attributes["address1_line2"] != null) ? customerinfo[item].attributes["address1_line2"].value : "";
                        var address3 = (customerinfo[item].attributes["address1_line3"] != undefined && customerinfo[item].attributes["address1_line3"] != null) ? customerinfo[item].attributes["address1_line3"].value : "";
                        //var address1 = (customerinfo[item].attributes["address1_line1"] != undefined && customerinfo[item].attributes["address1_line1"] != null) ? customerinfo[item].attributes["address1_line1"].value : "";
                        customerData[item].Address = address1 + " " + address2 + " " + address3 + " " + customerinfo[item].attributes["etel_cityid"].name + " " + customerinfo[item].attributes["etel_countryid"].name;
                    }
                }
                else if (customerinfo[item].attributes["accountnumber"] != undefined && customerinfo[item].attributes["accountnumber"] != null) {
                    customerData[item].AccountNumber = customerinfo[item].attributes["accountnumber"].value;

                    if (customerinfo[item].attributes["address1_line1"] != undefined && customerinfo[item].attributes["address1_line1"] != null && customerinfo[item].attributes["a_corporate.address1_line2"] != undefined && customerinfo[item].attributes["address1_line2"] != null) {
                        customerData[item].Address = customerinfo[item].attributes["address1_line1"].value + " " + customerinfo[item].attributes["address1_line2"].value + " " + customerinfo[item].attributes["a_corporate.address1_line3"].value + " " + customerinfo[item].attributes["etel_cityid"].name + " " + customerinfo[item].attributes["etel_countryid"].name;
                    }

                }

                // customerData[item].Address = (customerinfo[item].attributes["a_customeraddress.etel_addressline1"] != undefined && customerinfo[item].attributes["a_customeraddress.etel_addressline1"] != null) ? customerinfo[item].attributes["a_customeraddress.etel_addressline1"].value : "";
                var CustomerGuid = null; var CustomerStatus = null; var CustomerStatusformattedValue = null; var IdentityNumber = null;
                if (customerinfo[item].attributes.contactid != undefined && customerinfo[item].attributes.contactid != null) {
                    CustomerGuid = customerinfo[item].attributes["contactid"].value;
                }
                else if (customerinfo[item].attributes.etel_corporatecustomerid != undefined && customerinfo[item].attributes.etel_corporatecustomerid != null) {
                    CustomerGuid = customerinfo[item].attributes.etel_corporatecustomerid.id;

                }

                if (customerinfo[item].attributes["statecode"] != undefined && customerinfo[item].attributes["statecode"] != null) {
                    CustomerStatus = customerinfo[item].attributes["statecode"].value;
                }
                else if (customerinfo[item].attributes["statecode"] != undefined && customerinfo[item].attributes["statecode"] != null) {
                    CustomerStatus = customerinfo[item].attributes["statecode"].value;

                }

                if (customerinfo[item].attributes["statecode"] != undefined && customerinfo[item].attributes["statecode"] != null) {
                    CustomerStatusformattedValue = customerinfo[item].attributes["statecode"].formattedValue;
                }
                else if (customerinfo[item].attributes["statecode"] != undefined && customerinfo[item].attributes["statecode"] != null) {
                    CustomerStatusformattedValue = customerinfo[item].attributes["statecode"].formattedValue;

                }

                if (customerinfo[item].attributes["etel_passportnumber"] != undefined && customerinfo[item].attributes["etel_passportnumber"] != null) {

                    IdentityNumber = customerinfo[item].attributes["etel_passportnumber"].value;
                }

                customerData[item].CustomerID = CustomerGuid;
                customerData[item].CustomerStatus = CustomerStatusformattedValue;
                customerData[item].CustomerStatusValue = CustomerStatus;
                customerData[item].CustomerType = 2;
                customerData[item].IdentityNo = IdentityNumber;
                customerData[item].MSISDN = "";
                customerData[item].Name = (customerinfo[item].attributes.fullname != undefined && customerinfo[item].attributes.fullname != null) ? customerinfo[item].attributes.fullname.value : null;
                customerData[item].ParentAccount = (customerinfo[item].attributes.etel_parentaccountid != undefined && customerinfo[item].attributes.etel_parentaccountid != null) ? customerinfo[item].attributes.etel_parentaccountid.name : null;
                customerData[item].ParentAccountId = (customerinfo[item].attributes.etel_parentaccountid != undefined && customerinfo[item].attributes.etel_parentaccountid != null) ? customerinfo[item].attributes.etel_parentaccountid.id : null;
                customerData[item].SubscriptionStatus = (customerinfo[item].attributes.statecode != undefined && customerinfo[item].attributes.statecode != null) ? customerinfo[item].attributes.statecode.formattedValue : null;

            }
        }
    }
}