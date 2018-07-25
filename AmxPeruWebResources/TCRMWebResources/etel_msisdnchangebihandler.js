var translationScope_js_BI_MSISDNChange = {
    data: null,
    GetData: function () {
        var formId = 'js_BI_MSISDNChange';
        if (translationScope_js_BI_MSISDNChange.data !== null) {
            return;
        }
        translationScope_js_BI_MSISDNChange.data = GetTranslationData(formId);
    }
};

var subscriptionCustomer = {

    LogicalName: "",
    EntityCode: undefined,
    Id: "",
    Name: "",
    GetCustomer: function (contactIdFieldName, accountIdFieldName) {
        translationScope_js_BI_MSISDNChange.GetData();
        var individualCustomer = Xrm.Page.getAttribute(contactIdFieldName).getValue();
        var corporateCustomer = Xrm.Page.getAttribute(accountIdFieldName).getValue();
        if (individualCustomer !== null) {
            subscriptionCustomer.LogicalName = "contact";
            subscriptionCustomer.EntityCode = 2;
            subscriptionCustomer.Id = individualCustomer[0].id;
            subscriptionCustomer.Name = getValueFromDB("ContactSet", "ContactId", individualCustomer[0].id, "FullName");
        } else if (corporateCustomer !== null) {
            subscriptionCustomer.LogicalName = "account";
            subscriptionCustomer.EntityCode = 1;
            subscriptionCustomer.Id = corporateCustomer[0].id;
            subscriptionCustomer.Name = getValueFromDB("AccountSet", "AccountId", corporateCustomer[0].id, "Name");
        }
    }
};

var selectedResourceMSISDN = {
    serialNumber: "",
    Id: "",
    GetSelectedResource: function () {
        translationScope_js_BI_MSISDNChange.GetData();
        var grid = Xrm.Page.getControl("resources").getGrid();
        selectedResourceMSISDN.Id = null;
        selectedResourceMSISDN.resourceType = null;
        selectedResourceMSISDN.serialNumber = null;
        for (var rowNo = 0; rowNo < grid.getSelectedRows().getLength(); rowNo++) {
            selectedResourceMSISDN.Id = grid.getSelectedRows().getAll()[rowNo].getKey();
            //selectedResourceMSISDN.Id = selectedResourceMSISDN.Id.substr(1, selectedResourceMSISDN.Id.length - 2);
        }

        if (selectedResourceMSISDN.Id) {
            var columns = ['etel_resourceidentifier', 'etel_serialnumber', 'etel_resourcespecification_resource/etel_resourcetypecode'];
            var filter = "etel_productresourceId eq guid'" + selectedResourceMSISDN.Id + "'";
            var relName = "etel_resourcespecification_resource";

            CrmRestKit.ByExpandQuery('etel_productresource', columns, relName, filter, false).fail(function (xhr, status, ethrow) {
                alert('Error: ' + status + ': ' + translationScope_js_BI_MSISDNChange.data.tResourceNotFound);
            }).done(function (collection) {
                if (collection.d !== null && collection.d.results !== null && collection.d.results.length > 0) {
                    selectedResourceMSISDN.serialNumber = collection.d.results[0].etel_serialnumber;
                    selectedResourceMSISDN.resourceType = collection.d.results[0].etel_resourcespecification_resource.etel_resourcetypecode;
                }
            });
        }
        else {
            alert(translationScope_js_BI_MSISDNChange.data.tSelectMSISDNResource);
        }
    }
};

var settings = {
    ServerURL: "",
    CurrentUserId: "",
    CurrenctUserDomainName: "",
    GetUrl: function () {
        translationScope_js_BI_MSISDNChange.GetData();
        Xrm.Page.context.getClientUrl();
        if (settings.ServerURL.match(/\/$/)) {
            settings.ServerURL = settings.ServerURL.substring(0, settings.ServerURL.length - 1);
        }
        if (typeof Xrm.Page.context.getClientUrl !== "undefined") {
            settings.ServerURL = Xrm.Page.context.getClientUrl();
        }
    },
    GetCurrentUserId: function () {
        translationScope_js_BI_MSISDNChange.GetData();
        settings.CurrentUserId = Xrm.Page.context.getUserId();
    },
    GetCurrentUserDomainName: function () {
        translationScope_js_BI_MSISDNChange.GetData();
        settings.CurrenctUserDomainName = "";
    },
    Initialise: function () {
        translationScope_js_BI_MSISDNChange.GetData();
        settings.GetUrl();
        settings.GetCurrentUserId();
    }
};

var biSecurityChangeMSISDN = {
    IsValidated: "",
    Validate: function (selectedEntityId, selectedEntityCode) {
        translationScope_js_BI_MSISDNChange.GetData();
        var paymentType = null; ////TODO: Rate plan should exist on subscription, and payment type information should be retrieved from rate plan!
        var request = new PrepareRequest(new MSISDNChangeSecurityRequest('etel_bimsisdnchange', subscriptionCustomer.Id, subscriptionCustomer.EntityCode, selectedEntityCode, paymentType, settings.CurrentUserId, selectedEntityId));
        retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
            biSecurityChangeMSISDN.IsValidated = data.IsValidated;
        });
    }
};

var biAutoNumberMSISDNChange = {
    IsCreated: "",
    BINumber: "",
    CreateBINumber: function () {
        translationScope_js_BI_MSISDNChange.GetData();
        var request = new PrepareRequest(new CreateBINumberRequest());
        retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
            biAutoNumberMSISDNChange.IsCreated = data.Success;
            biAutoNumberMSISDNChange.BINumber = data.BINumber;
        });
    }
};

var newEntityWindow = {
    features: "location=no,menubar=no,status=no,toolbar=no, resizable=yes",
    Open: function (entityTypeCode, extraqs) {
        window.open(settings.ServerURL + "/main.aspx?etn=" + entityTypeCode + "&pagetype=entityrecord&extraqs=" + encodeURIComponent(extraqs) + "&newWindow=true&histKey=" + Math.floor(Math.random() * 10000), "_blank", newEntityWindow.features, false);
    }
};

var biRoleSecurityMSISDNChange = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_js_BI_MSISDNChange.GetData();

        biRoleSecurityMSISDNChange.IsValidatedRole = Util.Security.UserHasBIPrivilage("etel_bimsisdnchange");

    }
};

// Updated for AMXPeru
function popUpFormMSISDN(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName) {
    translationScope_js_BI_MSISDNChange.GetData();
    subscriptionCustomer.GetCustomer("etel_individualcustomerid", "etel_corporatecustomerid");
    selectedResourceMSISDN.GetSelectedResource();
    if (!selectedResourceMSISDN.Id) {
        return;
    }

    if (selectedResourceMSISDN.resourceType.Value !== 1) {
        alert(translationScope_js_BI_MSISDNChange.data.tInvalidResourceType);
        return;
    }

    settings.Initialise();
    var id = subscriptionCustomer.Id.substr(1, subscriptionCustomer.Id.length - 2).toLowerCase();
    var headerStarted = headerCheck(entitytypecode, id, subscriptionCustomer.EntityCode, subscriptionCustomer.LogicalName);

    if (headerStarted) {
        biSecurityChangeMSISDN.Validate(selectedEntityId, selectedEntityCode);

        // Set parameters to create new order
        var newOrder = {};
        if (subscriptionCustomer.LogicalName === "contact") {
            newOrder.etel_individualcustomerid = {
                Id: id,
                LogicalName: "contact"
            };
        }
        else if (subscriptionCustomer.LogicalName === "account") {
            newOrder.etel_corporatecustomerid = {
                Id: id,
                LogicalName: "account"
            };
        }
        newOrder.etel_ordertypecode = {
            Value: 831260012   /// Change MSISDN order type

        };
        debugger;
        newOrder.amxperu_productresourceid =
            selectedResourceMSISDN.Id; 

        // SEt parameters to create new order

        if (biSecurityChangeMSISDN.IsValidated === true) {
            biRoleSecurityMSISDNChange.ValidateRole();
            if (biRoleSecurityMSISDNChange.IsValidatedRole === true) {
                biAutoNumberMSISDNChange.CreateBINumber();
                if (biAutoNumberMSISDNChange.IsCreated === true) {
                    // Create new order in TCRM
                    CreateOrder(newOrder);
                }
                else {
                    alert(translationScope_js_BI_MSISDNChange.data.tCreationBINumberMessage);
                }
            }
            else {
                alert(translationScope_js_BI_MSISDNChange.data.tValidationRoleCheckMessage);
            }
        } else {
            alert(translationScope_js_BI_MSISDNChange.data.tValidationCheck);
        }
    }
}

var MsIsdnFields = {
    Name: "etel_name",
    BINumber: "etel_binumber",
}

function onLoad() {
    translationScope_js_BI_MSISDNChange.GetData();
    // Notice :
    //  statuscode -> 831260000   =  "Submitted Successfully"
    //  statecode -> 1     = "Inactive" 
    if (Xrm.Page.getAttribute("statuscode").getValue() === 831260000 && Xrm.Page.getAttribute("statecode").getValue() === 1) {
        // WebResource_msisdnchangeHTML must be invisible due to new msisdn request
        Xrm.Page.getControl("WebResource_msisdnchangeHTML").setVisible(false);
        // Set visibility of etel_msisdn as true
        Xrm.Page.getControl("etel_msisdn").setVisible(true);
    }

    var msIsdnName = Xrm.Page.getAttribute(MsIsdnFields.Name).getValue();
    if (msIsdnName == null) {
        var biNumber = Xrm.Page.getAttribute(MsIsdnFields.BINumber).getValue();
        setFieldValue(MsIsdnFields.Name, biNumber + " - " + translationScope_js_BI_MSISDNChange.data.tNameFieldValue);
    }


    var lifecyclestatus = Xrm.Page.getAttribute("etel_lifecyclestatus").getValue();

    if (lifecyclestatus == 831260002) {
        Xrm.Page.getControl("etel_errordescription").setVisible(true);
    }

    //fillServiceFee();
}

var webServerName = null;

var getWebServerName = function () {
    if (constants.IsDebugMode) {
        return "esekamw055:6670";
    }
    if (webServerName == null) {
        retrieveMultipleRecords("etel_crmconfiguration", "$select=etel_value&$filter=etel_name eq 'OrderWebServiceServer'", function (results) {
            var firstResult = results[0];
            if (firstResult != null) {
                webServerName = results[0].etel_value;
            }
        },
            function (error) {
                alert(error.message);
            },
            function () { });
    }

    return webServerName;
};

var constants = {
    Namespace: "#Ericsson.ETELCRM.CommonServiceLibrary.Message",
    IsDebugMode: false
};

window.definitions = {
    namespace: "#Ericsson.ETELCRM.CommonServiceLibrary.Message",
    url: getWebServerName() + "/OrderProcess.svc/rest/ExecuteRequest",
    messages: {
        RetrieveDedicatedAccumulatorAccountRequest: "RetrieveDedicatedAccumulatorAccountRequest:",
        RetrieveTranslationRequest: "RetrieveTranslationRequest:"
    },
    parameters: {
        SubscriptionId: "",
        Language: _context().getUserLcid()
    }
};

function createRequest(messageName, obj) {
    obj.request = {
        "__type": messageName + definitions.namespace
    };
    return obj;
};

function ValidatePaymentFields(paymethodId, CustomerId, CustomerName, paymentamount, paymentcurrency, CustomerType) {
    var result = false;
    if (paymethodId == undefined || CustomerId == undefined || CustomerName == undefined || CustomerName == undefined || paymentamount == undefined || paymentcurrency == undefined || CustomerType == undefined) {
        return false;
    }
    return true;
}

function postSaveFail() {
    Xrm.Page.data.entity.save('save');
    postSaveSuccess();
}

function postSaveSuccess() {
    var IsPaymentExist = false;
    var PayMethodId;
    var CustomerId;
    var CustomerName;
    var TransactionReferenceNumber;
    var PaymentAmount;
    var PaymentCurrency;
    var PaymentCurrencyCode;
    var ServiceFeeAmount;
    var CustomerType;
    var Description;

    var customer = null;
    var customertype = null;

    if (Xrm.Page.data.entity.attributes.get("etel_individualid") != null && Xrm.Page.data.entity.attributes.get("etel_individualid").getValue() != null) {
        customer = Xrm.Page.data.entity.attributes.get("etel_individualid");
        customertype = "contact";
    }
    else if (Xrm.Page.data.entity.attributes.get("etel_corporateid") != null && Xrm.Page.data.entity.attributes.get("etel_corporateid").getValue() != null) {
        customer = Xrm.Page.data.entity.attributes.get("etel_corporateid");
        customertype = "account";
    }

    CustomerId = customer.getValue()[0].id;
    CustomerName = customer.getValue()[0].name;
    CustomerType = customertype;

    if (serviceFee !== "undefined" && serviceFee !== null) {
        //Payment Fields Required To Submit
        PayMethodId = window.parent.paymentmethod;
        TransactionReferenceNumber = Xrm.Page.data.entity.getId();
        TransactionReferenceNumber = TransactionReferenceNumber.substring(1, (TransactionReferenceNumber).length - 1);
        PaymentAmount = window.parent.paymentamount;
        PaymentCurrency = window.parent.exchangedcurrency;
        PaymentCurrencyCode = window.parent.pcurrencycode;
        ServiceFeeAmount = window.serviceFee.etel_ServiceFeeAmount;

        IsPaymentExist = true;
        Description = window.parent.description;
        if (!ValidatePaymentFields(PayMethodId, CustomerId, CustomerName, PaymentAmount, PaymentCurrencyCode, CustomerType)) {
            alert(translationScope_js_BI_MSISDNChange.data.tMSISDNPaymentRequired);
            //alert('You should fill all fields on the payment popup screen.');
            return;
        }
        CustomerId = CustomerId.substring(1, (window.parent.customerid).length - 1);

    }
    else {
        IsPaymentExist = false;
    }

    var ResourceGUID = Xrm.Page.getAttribute("etel_productresourceid").getValue();
    var SubscriptionId = Xrm.Page.getAttribute("etel_subscriptionid").getValue()[0].id;
    var OldMSISDN = Xrm.Page.getAttribute("etel_oldmsisdn").getValue();
    var SerialNumber = Xrm.Page.getAttribute("etel_msisdn").getValue();
    var ResourceId = Xrm.Page.getAttribute("etel_msisdnresourceid").getValue();
    var OtherIdentifier = Xrm.Page.getAttribute("etel_otheridentifier").getValue();
    var ReservationId = Xrm.Page.getAttribute("etel_reservationid").getValue();
    var submitCheck = Xrm.Page.getAttribute("etel_submit");
    var lifecyclestatus = Xrm.Page.getAttribute("etel_lifecyclestatus");
    var BINumber = Xrm.Page.getAttribute("etel_binumber").getValue();
    var BIName = window.biname;
    var entityId = Xrm.Page.data.entity.getId();
    var entityName = Xrm.Page.data.entity.getEntityName();


    if (!SerialNumber) {
        alert(translationScope_js_BI_MSISDNChange.data.tMSISDNRequired);
        return;
    }

    if (!ReservationId) {
        alert(translationScope_js_BI_MSISDNChange.data.tMSISDNReserveRequired);
        return;
    }

    var keepGoing = true;
    oDataPath = Xrm.Page.context.getClientUrl() + "/XRMServices/2011/OrganizationData.svc/";
    query = "etel_bimsisdnchangeSet?$select=etel_binumber,etel_bimsisdnchangeId&$filter=etel_binumber ne '" + BINumber + "'  and etel_subscriptionid/Id eq (guid'" + SubscriptionId + "') and statuscode/Value eq 1";

    retrieveRecordUsingODataFreeQuery(query, oDataPath,
        function (data) {
            if (data && data.results && data.results.length > 0) {
                var BiNumbers = '';

                for (var i = 0; i < data.results.length; i++) {
                    BiNumbers += data.results[i].etel_binumber + ",";
                }

                var answer = confirm(translationScope_js_BI_MSISDNChange.data.tDraftBiToCancelled.replace("{0}", BiNumbers.slice(0, -1)));
                if (answer) {
                    for (var i = 0; i < data.results.length; i++) {
                        var cancelledBiGuid = data.results[i].etel_bimsisdnchangeId;
                        var entityObject = {
                            statuscode: { Value: 2 },
                            statecode: { Value: 1 },
                            etel_lifecyclestatus: { Value: 831260003 }
                        };
                        updateCrmRecordUsingOData(cancelledBiGuid, entityObject, "etel_bimsisdnchange", oDataPath, function () { }, function (error) { alert(error); });
                    }
                }
                else {
                    keepGoing = false;
                }
            }
        },
        function (error) {
            alert(error);
        }, false);

    if (!keepGoing)
        return;

    var executionResult;
    var successResult;
    var ermsRefId;

    settings.GetCurrentUserDomainName();
    var request = new PrepareRequest(new MSISDNChangeIntegrationRequest(ResourceGUID, SubscriptionId, OldMSISDN, SerialNumber, ResourceId, OtherIdentifier, BINumber, settings.CurrenctUserDomainName, CustomerId, CustomerName, TransactionReferenceNumber, PayMethodId, PaymentAmount, PaymentCurrencyCode, IsPaymentExist, CustomerType, Description));
    retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
        successResult = data.Success;
        executionResult = data.ErrorMessage;
    });

    var alertMessage = "";

    if (successResult === true) {
        lifecyclestatus.setValue(831260001);
        alertMessage = translationScope_js_BI_MSISDNChange.data.tSubmittedSuccessfully;
    }
    else {
        if (1 == 1) {
            lifecyclestatus.setValue(831260002);
        }
        else {
            //lifecyclestatus.setValue(831260004);        
        }

        alertMessage = translationScope_js_BI_MSISDNChange.data.tSubmittedWithError + '\n' + executionResult;
        Xrm.Page.getControl("etel_errordescription").setVisible(true);
        Xrm.Page.data.entity.attributes.get("etel_errordescription").setSubmitMode('always');
        Xrm.Page.data.entity.attributes.get("etel_errordescription").setValue(translationScope_js_BI_MSISDNChange.data.tSubmittedWithError + '\n' + executionResult);

    }

    //Xrm.Page.data.entity.attributes.get("etel_servicefeeamount").setValue(parseFloat(window.parent.serviceFee.etel_ServiceFeeAmount).toFixed(2) + ' ' + window.parent.currency);
    Xrm.Page.data.entity.attributes.get("etel_paymentamount").setSubmitMode('always');
    Xrm.Page.data.entity.attributes.get("etel_servicefeeamount").setSubmitMode('always');
    //Xrm.Page.data.entity.attributes.get("etel_ermsrefid").setSubmitMode('always');
    submitCheck.setValue(true);
    submitCheck.setSubmitMode('always');
    lifecyclestatus.setSubmitMode('always');
    Xrm.Page.data.entity.save('save');
    alert(alertMessage);
    Xrm.Utility.openEntityForm(entityName, entityId);
}

function executeSubmit() {
    translationScope_js_BI_MSISDNChange.GetData();
    Xrm.Page.data.save().then(postSaveSuccess, postSaveFail);
}

function IsChangeMSISDNButtonEnabled() {
    settings.Initialise();
    var retVal = true;

    biRoleSecurityMSISDNChange.ValidateRole();

    retVal = !!biRoleSecurityMSISDNChange.IsValidatedRole;

    return retVal;
}