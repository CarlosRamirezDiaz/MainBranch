// This javascript file is created on 29/07/2015 for the purpose of custom customer search functions on customer search page
//function IndividualCustomerAcquisition() {
//    translationScope_JS_CustomerSearchScript.GetData();
//    var validate = Util.Security.UserHasBIPrivilage("newacquisitionfromindividualcustomer");

//    if (validate === null || validate === false) {
//        alert(translationScope_JS_CustomerSearchScript.data.tValidationRoleCheckMessage);
//        return;
//    }

//    var customer = $('#SearchResultsGrid').datagrid('getSelected');
//    if (customer === null || customer === undefined) {
//        var newOrder = {};
//        newOrder.etel_ordertypecode = {
//            Value: 831260001
//        };
//        CreateOrderSync(newOrder);

//    }
//    else {
//        if (customer.CustomerType === null || customer.CustomerType === 1) {
//            window.parent.Xrm.Utility.openEntityForm('etel_ordercapture');
//            return;
//        }
//        if (customer.CustomerStatusValue && (customer.CustomerStatusValue === constants.CustomerStatus.Prospect || customer.CustomerStatusValue === constants.CustomerStatus.NotCustomer)) {
//            var newOrder = {};
//            newOrder.etel_individualcustomerid = {
//                Id: customer.CustomerID,
//                LogicalName: 'contact'
//            };
//            newOrder.etel_ordertypecode = {
//                Value: 831260001
//            };
//            CreateOrderSync(newOrder);
//        }
//        else {
//            window.parent.Xrm.Utility.openEntityForm('etel_ordercapture');
//        }
//    }
//}

function IndividualCustomerAcquisition() {
	var contactFormID='3be6247b-bd4a-43e0-8f0f-b400314ffae5';
	
	var parameters = {};
    parameters["formid"] = contactFormID;
    window.parent.Xrm.Utility.openEntityForm('contact', null, parameters);
}

function Open360GenericIndividualCustomer() {
    var contactFormID = 'E283ABEA-F298-4C98-9510-8E791D0E1CE5'; // Generic Customer Form
    var contactID='4A7E32EE-3ED9-E711-80E6-FA163E10DFBE';  // Generic Customer Guid
	
    var parameters = {};
    parameters["formid"] = contactFormID;
    parameters["contactid"] = contactID;
    window.parent.Xrm.Utility.openEntityForm('contact', null, parameters);
}

function CorporateCustomerCreationNewProcess() {
    translationScope_JS_CustomerSearchScript.GetData();
    var validate = Util.Security.UserHasBIPrivilage("corporatecustomercreationfromcustomer");
    var OrderID;
    var OrderCorporateCustomerID;
    if (validate === null || validate === false) {
        alert(translationScope_JS_CustomerSearchScript.data.tValidationRoleCheckMessage);
        return;
    }
    var ordercapturecorporatecustomer = {};
    var customer = $('#SearchResultsGrid').datagrid('getSelected');
    if (customer === null || customer === undefined) {
        var newOrder = {};
        newOrder.etel_ordertypecode = {
            Value: 831260010
        };
        OrderID = CreateOrderSync(newOrder);

        ordercapturecorporatecustomer.etel_isroot = true; //root
        ordercapturecorporatecustomer.etel_ordercaptureid = {
            Id: OrderID,
            LogicalName: 'etel_ordercapture'
        };
        OrderCorporateCustomerID = CreateOrderCaptureCorporateCustomer(ordercapturecorporatecustomer);
        return;
    }
    else {
        if (customer.CustomerStatusValue && (customer.CustomerStatusValue === constants.CustomerStatus.Active || customer.CustomerStatusValue === constants.CustomerStatus.Passive || customer.CustomerStatusValue === constants.CustomerStatus.Suspend)) {
            var newOrder = {};
            newOrder.etel_ordertypecode = {
                Value: 831260010
            };
            OrderID = CreateOrderSync(newOrder);

            ordercapturecorporatecustomer.etel_ordercaptureid = {
                Id: OrderID,
                LogicalName: 'etel_ordercapture'
            };
            retrieveCrmRecord(customer.CustomerID, "Account", "StateCode,StatusCode,etel_occrateplanid,etel_billcyclecode", null, function (corporatecustomer) {
                ordercapturecorporatecustomer.etel_occrateplanid = corporatecustomer.etel_occrateplanid;
                ordercapturecorporatecustomer.etel_billcycle = corporatecustomer.etel_billcyclecode;
            }, this._errorHandler, false);

            ordercapturecorporatecustomer.etel_isroot = false;//division
            ordercapturecorporatecustomer.etel_parentcustomerid = {
                Id: customer.CustomerID,
                LogicalName: 'account'
            };
            OrderCorporateCustomerID = CreateOrderCaptureCorporateCustomer(ordercapturecorporatecustomer);
        }
        else if (customer.CustomerStatusValue && customer.CustomerStatusValue === constants.CustomerStatus.Prospect) {
            var newOrder = {};
            newOrder.etel_ordertypecode = {
                Value: 831260010
            };

            ordercapturecorporatecustomer.etel_isroot = true;//root

            newOrder.etel_corporatecustomerid = {
                Id: customer.CustomerID,
                LogicalName: 'account'
            };

            if (customer.ParentAccount && customer.ParentAccount != null && customer.ParentAccount != '') {
                retrieveCrmRecord(customer.ParentAccountId, "Account", "StateCode,StatusCode,etel_occrateplanid,etel_billcyclecode", null, function (corporatecustomer) {
                    if (corporatecustomer.StatusCode !== null && (corporatecustomer.StatusCode.Value === constants.CustomerStatus.Active || corporatecustomer.StatusCode.Value === constants.CustomerStatus.Suspend || corporatecustomer.StatusCode.Value === constants.CustomerStatus.Passive)) {
                        ordercapturecorporatecustomer.etel_parentcustomerid = {
                            Id: customer.ParentAccountId,
                            LogicalName: 'account'
                        };
                        ordercapturecorporatecustomer.etel_isroot = false;//division
                        ordercapturecorporatecustomer.etel_occrateplanid = corporatecustomer.etel_occrateplanid;
                        ordercapturecorporatecustomer.etel_billcycle = corporatecustomer.etel_billcyclecode;
                    }
                },
                    this._errorHandler, false);
            }
            OrderID = CreateOrderSync(newOrder);
            ordercapturecorporatecustomer.etel_ordercaptureid = {
                Id: OrderID,
                LogicalName: 'etel_ordercapture'
            };
            ordercapturecorporatecustomer.etel_corporateid = {
                Id: customer.CustomerID,
                LogicalName: 'account'
            };
            OrderCorporateCustomerID = CreateOrderCaptureCorporateCustomer(ordercapturecorporatecustomer);
        }
        else {
            var newOrder = {};
            newOrder.etel_ordertypecode = {
                Value: 831260010
            };
            OrderID = CreateOrderSync(newOrder);


            ordercapturecorporatecustomer.etel_isroot = true;//root
            ordercapturecorporatecustomer.etel_ordercaptureid = {
                Id: OrderID,
                LogicalName: 'etel_ordercapture'
            };
            OrderCorporateCustomerID = CreateOrderCaptureCorporateCustomer(ordercapturecorporatecustomer);
        }

    }
    var ordercorporateUpdaterecord = {};
    ordercorporateUpdaterecord.etel_ordercapturecorporateid =
        {
            Id: OrderCorporateCustomerID,
            LogicalName: 'etel_ordercapturecorporate'
        };
    updateRecord(OrderID, ordercorporateUpdaterecord, 'etel_ordercaptureSet');
}



function CheckCustomerButtons(CustomerStatusValue) {

    $('#btnNewSubscription').linkbutton('disable');

    var customer = $('#SearchResultsGrid').datagrid('getSelected');

    if (CustomerStatusValue) {

        if (CustomerStatusValue === constants.CustomerStatus.Active || CustomerStatusValue === constants.CustomerStatus.Deactive || CustomerStatusValue === constants.CustomerStatus.Passive || CustomerStatusValue === constants.CustomerStatus.Suspend) {
            $('#btnNewSubscription').linkbutton('enable');
        }

        if (customer.CustomerType === 2) { //Individual
            if (CustomerStatusValue === constants.CustomerStatus.Prospect || CustomerStatusValue === constants.CustomerStatus.NotCustomer) {
                $('#btnIndividualCustomerAcquisition').linkbutton('enable');
                $('#btnCorporateCustomerCreation').linkbutton('disable');
            }
            else if (CustomerStatusValue === constants.CustomerStatus.Active || CustomerStatusValue === constants.CustomerStatus.Passive || CustomerStatusValue === constants.CustomerStatus.Suspend || CustomerStatusValue === constants.CustomerStatus.Deactive) {
                $('#btnIndividualCustomerAcquisition').linkbutton('disable');
                $('#btnCorporateCustomerCreation').linkbutton('disable');
            }
        }
        else { //Corporate
            $('#btnIndividualCustomerAcquisition').linkbutton('disable');
            $('#btnCorporateCustomerCreation').linkbutton('enable');
        }
    }
    else {
        $('#btnIndividualCustomerAcquisition').linkbutton('enable');
        $('#btnCorporateCustomerCreation').linkbutton('enable');
    }
}

function CorporateCustomerCreation() {
    translationScope_JS_CustomerSearchScript.GetData();
    var validate = Util.Security.UserHasBIPrivilage('corporatecustomercreationfromcustomer');
    if (validate === null || validate === false) {
        alert(translationScope_JS_CustomerSearchScript.data.tValidationRoleCheckMessage);
        return;
    }

    var customer = $('#SearchResultsGrid').datagrid('getSelected');
    if (customer === null || customer === undefined) {
        window.parent.Xrm.Utility.openEntityForm('etel_corporatecustomercreationorder');
        return;
    }
    else {
        if (customer.CustomerStatusValue && (customer.CustomerStatusValue === constants.CustomerStatus.Suspend)) {
            alert(translationScope_JS_CustomerSearchScript.data.tSuspendCorporateCustomerDetected);
            return;
        }
        else if (customer.CustomerStatusValue && (customer.CustomerStatusValue === constants.CustomerStatus.Active || customer.CustomerStatusValue === constants.CustomerStatus.Suspend || customer.CustomerStatusValue === constants.CustomerStatus.Passive)) {
            CorporateCustomerCreationForActive(customer);
        }
        else if (customer.CustomerStatusValue && customer.CustomerStatusValue === constants.CustomerStatus.Prospect) {
            CorporateCustomerCreationFromProspect(customer);
        }
        else {
            window.parent.Xrm.Utility.openEntityForm('etel_corporatecustomercreationorder');
        }
    }
}

function CorporateCustomerCreationForActive(customer) {
    var orderEntityLogicalName = "etel_corporatecustomercreationorder";
    var corporatecustomercreationorder = {};
    corporatecustomercreationorder.etel_isroot = false;
    if (customer.CustomerType === 2) { //Individual Customer option selected
        customer = null;
    }
    else {
        corporatecustomercreationorder.etel_parentcustomerid = {
            Id: customer.CustomerID,
            LogicalName: 'account'
        };
    }
    corporatecustomercreationorder["processid"] = "7c15aed9-c47c-42e8-8a4a-87634be651ab";
    corporatecustomercreationorder["stageid"] = "f7999886-152a-4f8e-9dd2-aaf2ebf7b7a5";

    createCrmRecord(corporatecustomercreationorder, orderEntityLogicalName, function (order) {
        window.parent.Xrm.Utility.openEntityForm('etel_corporatecustomercreationorder', order.etel_corporatecustomercreationorderId);
    },
        this._errorHandler, false);
}

function CorporateCustomerCreationFromProspect(customer) {
    var orderEntityLogicalName = "etel_corporatecustomercreationorder";
    var corporatecustomercreationorder = {};
    if (customer.CustomerType === 2) {
        //// Individual Customer option selected
        customer = null;
        corporatecustomercreationorder["processid"] = "7c15aed9-c47c-42e8-8a4a-87634be651ab";
        corporatecustomercreationorder["stageid"] = "f7999886-152a-4f8e-9dd2-aaf2ebf7b7a5";

        createCrmRecord(corporatecustomercreationorder, orderEntityLogicalName, function (order) {
            window.parent.Xrm.Utility.openEntityForm('etel_corporatecustomercreationorder', order.etel_corporatecustomercreationorderId);
        },
            this._errorHandler, false);
    }
    else {
        corporatecustomercreationorder.etel_corporatecustomerid = {
            Id: customer.CustomerID,
            LogicalName: 'account'
        };
        if (customer.ParentAccount && customer.ParentAccount != null && customer.ParentAccount != '') {
            retrieveCrmRecord(customer.ParentAccountId, "Account", "StateCode,StatusCode", null, function (corporatecustomer) {
                if (corporatecustomer.StatusCode !== null && (corporatecustomer.StatusCode.Value === constants.CustomerStatus.Active || corporatecustomer.StatusCode.Value === constants.CustomerStatus.Suspend || corporatecustomer.StatusCode.Value === constants.CustomerStatus.Passive)) {
                    corporatecustomercreationorder.etel_parentcustomerid = {
                        Id: customer.ParentAccountId,
                        LogicalName: 'account'
                    };
                    corporatecustomercreationorder.etel_isroot = false;
                }
            },
                this._errorHandler, false);
        }

        corporatecustomercreationorder["processid"] = "7c15aed9-c47c-42e8-8a4a-87634be651ab";
        corporatecustomercreationorder["stageid"] = "f7999886-152a-4f8e-9dd2-aaf2ebf7b7a5";

        createCrmRecord(corporatecustomercreationorder, orderEntityLogicalName, function (order) {
            window.parent.Xrm.Utility.openEntityForm('etel_corporatecustomercreationorder', order.etel_corporatecustomercreationorderId);
        },
            this._errorHandler, false);
    }
}

function NewSubscription() {

    var newOrder = {};
    var customer = $('#SearchResultsGrid').datagrid('getSelected');
    if (customer === null || customer === undefined) {
        alert('please, select a customer');
        return;
    }
    var customerId = customer.CustomerID;
    newOrder.etel_ordertypecode = {
        Value: 831260002
    };
    if (customer.CustomerType === 1) {
        newOrder.etel_corporatecustomerid = {
            Id: customerId,
            LogicalName: 'account'
        };
    } else {
        newOrder.etel_individualcustomerid = {
            Id: customerId,
            LogicalName: 'contact'
        };
    }
    CreateOrderSync(newOrder);

}

var OrderCaptureId;
function CreateOrder(orderObj) {
    orderObj.etel_numberofsubscription = 1;
    createCrmRecord(orderObj, 'etel_ordercapture', function (order) {
        OrderCaptureId = order.etel_ordercaptureId;
        window.parent.Xrm.Utility.openEntityForm('etel_ordercapture', order.etel_ordercaptureId);
    },
        this._errorHandler, true);
    return OrderCaptureId;
}

function CreateOrderSync(orderObj) {
    orderObj.etel_numberofsubscription = 1;
    createCrmRecord(orderObj, 'etel_ordercapture', function (order) {
        OrderCaptureId = order.etel_ordercaptureId;
        window.parent.Xrm.Utility.openEntityForm('etel_ordercapture', order.etel_ordercaptureId);
    },
        this._errorHandler, false);
    return OrderCaptureId;
}

var OrderCaptureCorporateCustomerID;
function CreateOrderCaptureCorporateCustomer(CorporateObj) {
    createCrmRecord(CorporateObj, 'etel_ordercapturecorporate', function (ordercorp) {
        OrderCaptureCorporateCustomerID = ordercorp.etel_ordercapturecorporateId;
    }, this._errorHandler, false);
    return OrderCaptureCorporateCustomerID;
}

function BIHeaderCreate() {
    var popupcheck = true;
    var notification = "";

    var biHeaderRestriction = false;

    var oDataSetName = "etel_businessinteractionspecificationSet";
    var oDataUrl = "?$select=etel_requiresbiheader&$filter=etel_RelatedEntityType eq 'etel_ordercapture' and etel_requiresbiheader eq true and etel_customerrequired eq false";
    var data = retrieveCrmRecordForSubscription(oDataSetName, oDataUrl);
    var biSpec = data.results[0];
    if (biSpec == null) {
        alert('BI Header');
    }
    else {
        var userId = Xrm.Page.context.getUserId();
        var oDataSetName2 = "etel_bi_headerSet";
        var oDataUrl2 = "?$select=ActivityId&$filter=OwnerId/Id eq guid'" + userId + "' and etel_headerstatus eq true";
        var data2 = retrieveCrmRecordForSubscription(oDataSetName2, oDataUrl2);
        var biHeader = data2.results[0];
        if (biHeader == null) {
            var createHeader = {};
            createHeader.Subject = 'New acquisition BI';
            createHeader.etel_headerstatus = true;
            createHeader.etel_csrid = userId.replace('{', '').replace('}', '');
            createHeader.etel_customerrequired = false;
            createCrmRecord(createHeader, 'etel_bi_header', function () { },
                this._errorHandler, true);
        }
        else {
            var updateHeader = {};
            updateHeader.etel_headerstatus = false;
            updateRecord(biHeader.ActivityId, updateHeader, 'etel_bi_headerSet');

            var createHeader = {};
            createHeader.Subject = 'New acquisition BI';
            createHeader.etel_headerstatus = true;
            createHeader.etel_csrid = userId.replace('{', '').replace('}', '');
            createHeader.etel_customerrequired = false;
            createCrmRecord(createHeader, 'etel_bi_header', function () { },
                this._errorHandler, true);
        }

    }
}

function HasSecurityRole(roleGuid) {
    var retVal = false;

    var currentUserRoles = Xrm.Page.context.getUserRoles();

    if (currentUserRoles != null && currentUserRoles.length != 0) for (var i = 0; i < currentUserRoles.length; i++) {
        var userRole = currentUserRoles[i];
        if (userRole.toString() === roleGuid) {
            retVal = true;
            break;
        }
    }

    return retVal;
}

function BIHeaderCreateAction(customerType, customerId) {
    translationScope_JS_CustomerSearchScript.GetData();

    var retVal = false;
    var userId = Xrm.Page.context.getUserId();
    var oDataSetName = "etel_bi_headerSet";
    var oDataUrl = "?$select=ActivityId, etel_individualcustomerid, etel_accountid&$filter=OwnerId/Id eq guid'" + userId + "' and etel_headerstatus eq true";
    var data = retrieveCrmRecordForSubscription(oDataSetName, oDataUrl);
    var biHeader = data.results[0];
    if (biHeader == null) {
        var createHeader = {};
        createHeader.Subject = 'Customer Search';
        createHeader.etel_headerstatus = true;
        createHeader.etel_csrid = userId.replace('{', '').replace('}', '');
        createHeader.etel_customeridtext = customerId.replace('{', '').replace('}', '');
        createHeader.etel_customerrequired = true;

        if (window.parent && window.parent.location && window.parent.location.search && getQueryString() && getQueryString().extraqs) {
            createHeader.etel_originatedcontactinfo = getQueryString().extraqs.replace('msisdn_', '');
            createHeader.etel_channelinteractionid = getQueryString().extraqs.replace('msisdn_', '');
            createHeader.etel_biheaderchanneltypecode = {
                Value: constants.BIHeaderChannel.PhoneCall
            };
            createHeader.etel_interactiondirectiontypecode = {
                Value: constants.InteractionDirection.Incoming
            };
        }

        createHeader.etel_channelinteractionstarttime = new Date();
        createHeader.etel_biheaderstarttime = new Date();

        if (customerType === 1) {
            createHeader.etel_accountid = {
                Id: customerId,
                LogicalName: 'account'
            };

            CrmRestKit.Retrieve('Account', customerId, ['Name'], false).done(function (data) {
                if (data.d.Name) {
                    createHeader.etel_customername = data.d.Name;
                }
            });
        }
        else {
            createHeader.etel_individualcustomerid = {
                Id: customerId,
                LogicalName: 'contact'
            };

            CrmRestKit.Retrieve('Contact', customerId, ['FullName'], false).done(function (data) {
                if (data.d.FullName) {
                    createHeader.etel_customername = data.d.FullName;
                }
            });
        }

        createCrmRecord(createHeader, 'etel_bi_header', function () { },
            this._errorHandler, true);
        retVal = true;
    }
    else {
        ////We search the BI headers that are retrieved according to the above executed query,
        ////and look for the customerId
        for (var i = 0; i < data.results.length; i++) {
            var biHeaderItem = data.results[i];
            var biHeaderItem_CustomerId = null;
            if (biHeaderItem.etel_individualcustomerid.Id !== null) {
                biHeaderItem_CustomerId = biHeaderItem.etel_individualcustomerid.Id;
            }
            else if (biHeaderItem.etel_accountid.Id) {
                biHeaderItem_CustomerId = biHeaderItem.etel_accountid.Id;
            }

            if (biHeaderItem_CustomerId === customerId) {
                retVal = true;
                searchCompleted = true;
                break;
            }
        }

        if (searchCompleted === null) {
            alert(translationScope_JS_CustomerSearchScript.data.tBIHeaderCheck);
            searchCompleted = null;
        }
    }

    return retVal;
}

// This method is used to create Search Result DataGrid only for this customer search
function loadSearchGridOnCustomerSearch() {

    $('#SearchResultsGrid').datagrid({
        height: 520,
        pageSize: 20,
        width: 'auto',
        singleSelect: true,
        remoteSort: true,
        striped: true,
        fitColumns: true,
        rownumbers: true,
        loadMsg: "Loading",
        pagination: true,
        columns: [[{
            field: "CustomerID",
            title: "Customer ID",
            hidden: true
        },
        {
            field: "CustomerType",
            title: "",
            sortable: false,
            width: 30,
            formatter: function (value, row, index) {
                if (row.CustomerType) {
                    if (row.CustomerType == 1) {
                        return "<image src=styles/themes/icons/corporatecustomer.gif>";
                    }
                    else {
                        return "<image src=styles/themes/icons/individualcustomer.gif>";
                    }
                }
            }
        },
        {
            field: "MobilePhone",
            title: translationScope_JS_CustomerSearchScript.data.tPhone,
            sortable: false,
            width: 150
        },
        {
            field: "Name",
            title: translationScope_JS_CustomerSearchScript.data.tName,
            sortable: true,
            width: 300
        },
        {
            field: "Address",
            title: translationScope_JS_CustomerSearchScript.data.tAddress,
            sortable: false,
            width: 300
        },
        {
            field: "AccountNumber",
            title: translationScope_JS_CustomerSearchScript.data.tAccountNumber,
            sortable: false,
            width: 150
        },
        {
            field: "IdentityNo",
            title: translationScope_JS_CustomerSearchScript.data.tIdentityNo,
            sortable: false,
            width: 150
        },
        {
            field: "ParentAccount",
            title: translationScope_JS_CustomerSearchScript.data.tParentAccount,
            sortable: false,
            width: 250
        },
        {
            field: "CustomerStatus",
            title: translationScope_JS_CustomerSearchScript.data.tCustomerStatus,
            sortable: false,
            width: 150
        },
        {
            field: "CustomerStatusValue",
            title: "CustomerStatusValue",
            hidden: true
        },
        {
            field: "ParentAccountId",
            title: "ParentAccountId",
            hidden: true
        },
        {
            field: "TelePhone",
            title: translationScope_JS_CustomerSearchScript.data.tPhone,
            sortable: false,
            width: 150
        },
        {
            field: "TelePhone2",
            title: translationScope_JS_CustomerSearchScript.data.tPhone,
            sortable: false,
            width: 150
        },
        {
            field: "TelePhone3",
            title: translationScope_JS_CustomerSearchScript.data.tPhone,
            sortable: false,
            width: 150
        },
        {
            field: "Email",
            title: translationScope_JS_CustomerSearchScript.data.tEmail,
            sortable: false,
            width: 150
        },
        {
            field: "Email2",
            title: translationScope_JS_CustomerSearchScript.data.tEmail,
            sortable: false,
            width: 150
        },
        {
            field: "Email3",
            title: translationScope_JS_CustomerSearchScript.data.tEmail,
            sortable: false,
            width: 150
        }

        ]],
        data: {
            "total": 0,
            "rows": []
        },
        toolbar: '#SearchResultsGridToolBar',
        onSelect: function (rowIndex, rowData) {
            if (lastselectedrow == rowIndex) {
                $(this).datagrid('unselectRow', lastselectedrow);
                lastselectedrow = undefined;
                CheckCustomerButtons();
            }
            else {
                lastselectedrow = rowIndex;
                CheckCustomerButtons(rowData.CustomerStatusValue);
            }
        },
        onDblClickRow: function (rowIndex, rowData) {
            if (rowData.CustomerType && rowData.CustomerID) {
                var result = BIHeaderCreateAction(rowData.CustomerType, rowData.CustomerID);
                if (result === true) {
                    popupEntityForm(rowData.CustomerType, rowData.CustomerID);
                }
                else {
                    alert(translationScope_JS_CustomerSearchScript.data.tBIHeaderCheck);
                }
            }
        },
        onLoadSuccess: function (data) {
            if (data && data.total === 1 && data.rows && searchCompleted === null) {
                $(this).datagrid("selectRow", 0);

                var result = BIHeaderCreateAction(data.rows[0].CustomerType, data.rows[0].CustomerID);
                if (result === true) {
                    popupEntityForm(data.rows[0].CustomerType, data.rows[0].CustomerID);
                    searchCompleted = true;
                }
            }
            else {
                CheckCustomerButtons();
            }
        }
    });
}

$(document).ready(function () {
    $(document).on("keyup", function (event) {
        if (event.which == 13) {
            var opts = $("#ToggleSearchMode").linkbutton('options');
            if ($(document.activeElement).attr('class') != "pagination-num") {
                if (opts.selected == false) {
                    keyPublisher.publish('SIMPLESEARCH');
                }
                else {
                    var asfp = $('#AdvancedSearchFiltersPanel').accordion('getSelected');
                    if (asfp) {
                        keyPublisher.publish(asfp[0].id);
                    }
                }
            }
        }
    });

    focusFirstPageControl();
});