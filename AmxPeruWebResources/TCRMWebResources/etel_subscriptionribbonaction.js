var translationScope_JS_SubscriptionHandlerRibbonAction = {
    data: null,
    GetData: function () {
        var formId = "JS_SubscriptionHandlerRibbonAction";
        if (translationScope_JS_SubscriptionHandlerRibbonAction.data !== null) {
            return;
        }
        translationScope_JS_SubscriptionHandlerRibbonAction.data = GetTranslationData(formId);
    }
};

var biRoleSecurityNewAcquisitionFromIndividualCustomer = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_JS_SubscriptionHandlerRibbonAction.GetData();

        biRoleSecurityNewAcquisitionFromIndividualCustomer.IsValidatedRole = Util.Security.UserHasBIPrivilage("newacquisitionfromindividualcustomer");
    }
};

var biRoleSecurityCreateSubscriptionFromCustomer = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
        biRoleSecurityCreateSubscriptionFromCustomer.IsValidatedRole = Util.Security.UserHasBIPrivilage("createsubscriptionfromcustomer");
    }
};

var biRoleSecurityModifySubscriptionFromCustomer = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_JS_SubscriptionHandlerRibbonAction.GetData();

        biRoleSecurityModifySubscriptionFromCustomer.IsValidatedRole = Util.Security.UserHasBIPrivilage("modifysubscriptionfromcustomer");
    }
};

var biRoleSecuritySubscriptionTakeOver = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_JS_SubscriptionHandlerRibbonAction.GetData();

        biRoleSecuritySubscriptionTakeOver.IsValidatedRole = Util.Security.UserHasBIPrivilage("subscriptiontakeoverfromcustomer");
    }
};

var biRoleSecurityDepositCreationFromCustomer = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_JS_SubscriptionHandlerRibbonAction.GetData();

        biRoleSecurityDepositCreationFromCustomer.IsValidatedRole = Util.Security.UserHasBIPrivilage("depositcreationfromcustomer");
    }
};

var biRoleSecuritySubscriptionStatusChangeFromCustomer = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_JS_SubscriptionHandlerRibbonAction.GetData();

        biRoleSecuritySubscriptionStatusChangeFromCustomer.IsValidatedRole = Util.Security.UserHasBIPrivilage("subscriptionstatuschangefromcustomer");
    }
};

var biRoleSecurityOfferChangeFromCustomer = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
        biRoleSecurityOfferChangeFromCustomer.IsValidatedRole = Util.Security.UserHasBIPrivilage("offerchangefromcustomer");
    }
};

var biRoleSecurityCorporateCustomerCreationFromCustomer = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_JS_SubscriptionHandlerRibbonAction.GetData();

        biRoleSecurityCorporateCustomerCreationFromCustomer.IsValidatedRole = Util.Security.UserHasBIPrivilage("corporatecustomercreationfromcustomer");
    }
};

var settingsSubscription = {
    ServerURL: "",
    CurrentUserId: "",
    GetUrl: function () {
        translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
        Xrm.Page.context.getClientUrl();
        if (settingsSubscription.ServerURL.match(/\/$/)) {
            settingsSubscription.settingsSubscription = settingsSubscription.ServerURL.substring(0, settingsSubscription.ServerURL.length - 1);
        }
        if (typeof Xrm.Page.context.getClientUrl != "undefined") {
            settingsSubscription.ServerURL = Xrm.Page.context.getClientUrl();
        }
    },
    GetCurrentUserId: function () {
        translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
        settingsSubscription.CurrentUserId = Xrm.Page.context.getUserId();
    },
    Initialise: function () {
        translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
        settingsSubscription.GetUrl();
        settingsSubscription.GetCurrentUserId();
    }
};

var customerInfo = function () {
    var customerId, customerType, customerStatusCode;

    var individual = Xrm.Page.getAttribute("etel_individualcustomerid");
    var corporate = Xrm.Page.getAttribute("etel_corporatecustomerid");

    if ((individual !== null) && (individual.getValue() !== null)) {
        customerId = individual.getValue()[0].id;
        customerType = individual.getValue()[0].typename;
        customerStatusCode = globalRibbon.getEntityStatus(customerType, customerId);
    }
    else if ((corporate !== null) && (corporate.getValue() !== null)) {
        customerId = corporate.getValue()[0].id;
        customerType = corporate.getValue()[0].typename;
        customerStatusCode = globalRibbon.getEntityStatus(customerType, customerId);
    }

    return {
        customerId: customerId,
        customerType: customerType,
        customerStatusCode: customerStatusCode
    };
}

var globalRibbon = {
    getEntities: function () {
        return ["account", "contact"];
    },
    display: function (entityName, entityId, entityCode, biRoleSecurity) {
        if (globalRibbon.isHeaderCheck("etel_ordercapture", customer.customerId, "", customer.customerType)) {
            if (globalRibbon.isValidate(biRoleSecurity)) {
                globalRibbon.open(entityName, entityId, entityCode);
            } else {
                alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
            }
        }
    },
    open: function (entityName, entityId, entityCode) {
        var extraqs = "_CreateFromId=" + entityId + "&_CreateFromType=" + entityCode;

        var url = Xrm.Page.context.getClientUrl();
        if (url.match(/\/$/)) {
            url = url.substring(0, url.length - 1);
        }
        if (typeof Xrm.Page.context.getClientUrl !== "undefined") {
            url = Xrm.Page.context.getClientUrl();
        }

        var features = "location=no,menubar=no,status=no,toolbar=no";
        window.open(url + "/main.aspx?etn=" + entityName + "&pagetype=entityrecord&extraqs=" + encodeURIComponent(extraqs) + "&newWindow=true&histKey=" + Math.floor(Math.random() * 10000), "_blank", features, false);
    },
    isHeaderCheck: function (entityName, entityId, entityTypeCode, entityType) {
        var entities = globalRibbon.getEntities();

        if (!($.inArray(entityType, entities) > -1)) {
            var customer = new customerInfo();
            entityId = customer.customerId;
            entityType = customer.customerType;
            entityTypeCode = "";
        }

        return headerCheck(entityName, entityId, entityTypeCode, entityType);
    },
    isValidate: function (biRoleSecurity) {
        biRoleSecurity.ValidateRole();
        return biRoleSecurity.IsValidatedRole;
    },
    orderValidate: function (entityName, entityStatusCode, orderType) {
        var entities = globalRibbon.getEntities();

        if (!($.inArray(entityName, entities) > -1)) {
            var customer = new customerInfo();
            entityName = customer.customerType;
            entityStatusCode = customer.customerStatusCode;
        }

        var validate = OrderValidation(entityName, entityStatusCode, orderType);
        if (!validate.IsValid) {
            alert(validate.ErrorMessage);
        }

        return validate.IsValid;
    },
    isSelected: function (grid) {
        return grid.get_selectedRecords().length === 1;
    },
    getControl: function (selectorName) {
        return document.getElementById(selectorName);
    },
    getEntityId: function (data) {
        if (data != null && data.length > 0 && data[0][0] != null) {
            return data[0][0].RowData.SubscriptionId;
        }
        else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSelectSubscription);
            return null;
        }
    },
    getEntityStatus: function (entityName, entityId) {

        entityName = capitaliseFirstLetter(entityName);

        var oDataSetName = entityName + "Set";
        var oDataUrl = "?$select=StatusCode&$filter=" + entityName + "Id eq guid'" + entityId + "'";
        var data = retrieveCrmRecordAlias(oDataSetName, oDataUrl);
        return data.results[0].StatusCode.Value;
    }
};

function OpenChangeOwnership(entityId, entityName) {
    var selectedSubscription = Xrm.Page.ui.controls.get("WebResource_accountsummarytabbedview").getObject().contentWindow.angular.element(".main-container").scope().SubscriptionScopeSelectedItems;

    var entityStatusCode = Xrm.Page.getAttribute("statuscode").getValue();
    var control = globalRibbon.getControl("Subscription");

    if (globalRibbon.isHeaderCheck("subscriptiontakeoverfromcustomer", entityId, entityStatusCode, entityName)) {
        if (globalRibbon.isValidate(biRoleSecuritySubscriptionTakeOver)) {

            if (!globalRibbon.orderValidate(entityName, entityStatusCode, OrderType.SubscriptionTakeOver)) return;

            var subscriptionId = globalRibbon.getEntityId(selectedSubscription);
            if (subscriptionId != null) SubscriptionFromGrid(subscriptionId, OrderType.SubscriptionTakeOver);

        } else alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
    }
}

function OpenChangeOwnershipAssociateView(entityId, entityName, subscriptionId) {

    var entityStatusCode = Xrm.Page.getAttribute("statuscode").getValue();
    var control = globalRibbon.getControl("Subscription");

    if (globalRibbon.isHeaderCheck("subscriptiontakeoverfromcustomer", entityId, entityStatusCode, entityName)) {
        if (globalRibbon.isValidate(biRoleSecuritySubscriptionTakeOver)) {

            if (!globalRibbon.orderValidate(entityName, entityStatusCode, OrderType.SubscriptionTakeOver)) return;

            if (subscriptionId != null) SubscriptionFromGrid(subscriptionId, OrderType.SubscriptionTakeOver);

        } else alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
    }
}

function DisableNewOrderForInactiveCustomers() {
    var statecode = null;
    if (Xrm.Page.getAttribute("statecode")) {
        statecode = Xrm.Page.getAttribute("statecode").getValue();
    }
    if (statecode === null) {
        return true;
    } else {
        return !(statecode === 1);
    }
}

function CreateNewSubscriptionOrder() {
    var customerId = Xrm.Page.data.entity.getId();
    var customerType = Xrm.Page.data.entity.getEntityName();
    var customerTypeCode = Xrm.Page.getAttribute("statuscode").getValue();

    var headercheck = false;
    headercheck = headerCheck("createsubscriptionfromcustomer", customerId, '', customerType);

    if (headercheck) {
        biRoleSecurityCreateSubscriptionFromCustomer.ValidateRole();
        //Setting the below line for temparory perspective
        biRoleSecurityCreateSubscriptionFromCustomer.IsValidatedRole == true;
        if (biRoleSecurityCreateSubscriptionFromCustomer.IsValidatedRole === true) {

            var Validate = OrderValidation(customerType, customerTypeCode, OrderType.NewSubscription);
            if (!Validate.IsValid) {
                alert(Validate.ErrorMessage);
                return;
            }

            var newOrder = {};
            if (customerType === "contact") {

                newOrder.etel_individualcustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            }
            else if (customerType === "account") {
                newOrder.etel_corporatecustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            }
            newOrder.etel_ordertypecode = {
                Value: OrderType.NewSubscription
            };

            CreateOrder(newOrder);
        } else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
    }
}

function ModifySubscriptionOrder(selectedSubscriptionId) {
    var customerId = Xrm.Page.data.entity.getId();
    var customerType = Xrm.Page.data.entity.getEntityName();

    var capitalised = capitaliseFirstLetter(customerType);
    var customerTypeCode = GetCustomerStatusReason(capitalised, customerId);
    var headercheck = false;
    headercheck = headerCheck("modifysubscriptionfromcustomer", customerId, customerTypeCode, customerType);

    if (headercheck) {
        biRoleSecurityModifySubscriptionFromCustomer.ValidateRole();
        if (biRoleSecurityModifySubscriptionFromCustomer.IsValidatedRole === true) {

            var validate = OrderValidation(customerType, customerTypeCode, OrderType.ModifySubscription);
            if (!validate.IsValid) {
                alert(validate.ErrorMessage);
                return;
            }
            var subscriptionStatus = GetSubscriptionStatusReason(selectedSubscriptionId);
            if (subscriptionStatus !== null && subscriptionStatus !== 1) {
                alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSelectActiveSubscription);
                return;
            }

            SubscriptionFromGrid(selectedSubscriptionId, OrderType.ModifySubscription);
        } else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
    }
}

function OfferChangeOrder(selectedSubscriptionId) {
    var customerId = Xrm.Page.data.entity.getId();
    var customerType = Xrm.Page.data.entity.getEntityName();

    var subsProgressStatusCode = GetSubscriptionProgressStatus(selectedSubscriptionId);
    if (subsProgressStatusCode === 1) {
        alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSubscriptionIsInProgress);
        return;
    }

    var subStatusCode = GetSubscriptionStatusReason(selectedSubscriptionId);
    if (!(subStatusCode !== null && subStatusCode === 1)) {
        alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSelectActiveSubscription);
        return;
    }

    var headercheck = false;
    headercheck = headerCheck("offerchangefromcustomer", customerId, '', customerType);

    if (headercheck) {
        biRoleSecurityOfferChangeFromCustomer.ValidateRole();
        if (biRoleSecurityOfferChangeFromCustomer.IsValidatedRole === true) {

            var c = capitaliseFirstLetter(customerType);
            var statusReason = GetCustomerStatusReason(c, customerId);
            var Validate = OrderValidation(customerType, statusReason, OrderType.OfferChange);
            if (!Validate.IsValid) {
                alert(Validate.ErrorMessage);
                return;
            }

            var offerChange = {};
            if (customerType === 'contact') {
                offerChange.etel_individualcustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            }
            else if (customerType === 'account') {
                offerChange.etel_corporatecustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            }
            offerChange.etel_subscriptionid = {
                Id: selectedSubscriptionId,
                LogicalName: 'etel_subscription'
            };
            offerChange.etel_ordertypecode = {
                Value: OrderType.OfferChange
            };

            CreateOrder(offerChange);

        } else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
    }
}

function CreateOrder(orderObj) {
    orderObj.etel_numberofsubscription = 1;

    SDK.REST.createRecord(
        orderObj, 'etel_ordercapture', function (orderObj) {
            Xrm.Utility.openEntityForm('etel_ordercapture', orderObj.etel_ordercaptureId);
        },
        _errorHandler);
}

var _errorHandler = function errorHandler(error) {
    if (error) {
        if (error.message) {
            alert(error.message);
        }
        else if (error.statusText) { }
    }
}

function GetPrimaryBillingAccountId(customerId) {
    try {
        translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
        var oDataSetName = "etel_billingaccountSet";
        var oDataUrl = "?$select=etel_billingaccountId&$filter=etel_customerindividualid/Id eq guid'" + customerId + "' and etel_primarybillingaccount eq true";
        var data = retrieveCrmRecordAlias(oDataSetName, oDataUrl);
        var billingAccount = data.results[0];
        if (billingAccount === null) {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tNoPrimaryBillingAccountSet);
            return;
        }
        else {
            return billingAccount.etel_billingaccountId;
        }

    } catch (e) { }
}

function capitaliseFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function GetCustomerStatusReason(customerType, customerId) {
    var oDataSetName = customerType + "Set";
    var oDataUrl = "?$select=StatusCode&$filter=" + customerType + "Id eq guid'" + customerId + "'";
    var data = retrieveCrmRecordAlias(oDataSetName, oDataUrl);
    return data.results[0].StatusCode.Value;
}

function GetSubscriptionStatusReason(subscriptionId) {
    var oDataSetName = "etel_subscriptionSet";
    var oDataUrl = "?$select=etel_subscriptionstatuscode&$filter=etel_subscriptionId eq guid'" + subscriptionId + "'";
    var data = retrieveCrmRecordAlias(oDataSetName, oDataUrl);
    if (data !== null && data !== undefined) {
        return data.results[0].etel_subscriptionstatuscode.Value;
    }

    return SubscriptionStatusCode.ACTIVE;
}

function GetSubscriptionProgressStatus(subscriptionId) {
    var oDataSetName = "etel_subscriptionSet";
    var oDataUrl = "?$select=etel_subscriptionprogressstatuscode&$filter=etel_subscriptionId eq guid'" + subscriptionId + "'";
    var data = retrieveCrmRecordAlias(oDataSetName, oDataUrl);
    if (data !== null && data !== undefined) {
        return data.results[0].etel_subscriptionprogressstatuscode.Value;
    }

    return 2; //// completed.
}

function GetParentAccount(customerType, customerId) {
    var oDataSetName = customerType + "Set";
    var oDataUrl = "?$select=ParentAccountId&$filter=" + customerType + "Id eq guid'" + customerId + "'";
    var data = retrieveCrmRecordAlias(oDataSetName, oDataUrl);
    return data.results[0].ParentAccountId.Id;
}

function retrieveCrmRecord(entityId, entityName) {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    if (!entityId) {
        alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tOdataSetNameRequired)
        return;
    }

    var entitySetName = entityName + "Set";
    var oDataUrl = "?$select=StateCode,StatusCode,etel_occrateplanid,etel_billcyclecode&$filter=" + entityName + "Id eq guid'" + entityId + "'";

    var ODataPath = Xrm.Page.context.getClientUrl() + "/XRMServices/2011/OrganizationData.svc/";
    var fullUrl = ODataPath + entitySetName + oDataUrl;

    var result = null;
    jQuery.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        cache: false,
        url: fullUrl,
        xhrFields: {
            withCredentials: true
        },
        beforeSend: function (XMLHttpRequest) {
            XMLHttpRequest.setRequestHeader("Accept", "application/json");
        },
        success: function (data, textStatus, XmlHttpRequest) {
            result = data.d.results[0];
        },
        error: function (XmlHttpRequest, textStatus, errorThrown) {
            result = "hata";
        }
    });

    return result;
}

function retrieveCrmRecordAlias(odataSetName, url) {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    if (!odataSetName) {
        alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tOdataSetNameRequired);
        return;
    }

    var serverUrl = window.location.origin;
    var ODataPath = serverUrl + "/" + Xrm.Page.context.getOrgUniqueName() + "/XRMServices/2011/OrganizationData.svc/";
    var fullUrl = ODataPath + odataSetName + url;

    var result = null;
    jQuery.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        cache: false,
        url: fullUrl,
        xhrFields: {
            withCredentials: true
        },
        beforeSend: function (XMLHttpRequest) {
            XMLHttpRequest.setRequestHeader("Accept", "application/json");
        },
        success: function (data, textStatus, XmlHttpRequest) {
            result = data.d;
        },
        error: function (XmlHttpRequest, textStatus, errorThrown) {
            result = "hata";
        }
    });

    return result;
}

function CreateSubscriptionFromForm() {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var customerId;
    var customerType = '';
    var individual = Xrm.Page.getAttribute("etel_individualcustomerid");
    var isIndividual = false;

    if ((individual !== null) && (individual.getValue() !== null)) {
        var individualval = individual.getValue();
        customerId = individualval[0].id;
        customerType = 'contact';
        isIndividual = true;
    }
    else {
        var corporate = Xrm.Page.getAttribute("etel_corporatecustomerid");
        if ((corporate !== null) && (corporate.getValue() !== null)) {
            var corporateval = corporate.getValue();
            customerId = corporateval[0].id;
            customerType = 'account';
        }
    }

    var headercheck = false;
    headercheck = headerCheck("createsubscriptionfromcustomer", customerId, '', customerType);

    if (headercheck) {
        biRoleSecurityCreateSubscriptionFromCustomer.ValidateRole();
        if (biRoleSecurityCreateSubscriptionFromCustomer.IsValidatedRole === true) {

            var c = capitaliseFirstLetter(customerType);
            var statusReason = GetCustomerStatusReason(c, customerId);
            var validate = OrderValidation(customerType, statusReason, OrderType.NewSubscription);
            if (!validate.IsValid) {
                alert(validate.ErrorMessage);
                return;
            }

            var newOrder = {};
            if (isIndividual) {
                newOrder.etel_individualcustomerid = {
                    Id: customerId,
                    LogicalName: 'contact'
                };
            } else {
                newOrder.etel_corporatecustomerid = {
                    Id: customerId,
                    LogicalName: 'account'
                };
            }
            newOrder.etel_ordertypecode = {
                Value: OrderType.NewSubscription
            }; //New subscription
            CreateOrder(newOrder);
        } else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
    }
}

function CreateNewSubscriptionForProspectCustomer() {
    var IndividualCustomer = Xrm.Page.data.entity.getId();
    //var IndividualCustomer = Xrm.Page.getAttribute("contactid").getValue();
    var IndividualCustomerId = IndividualCustomer.substr(1, 36);
    var etel_name;
    var statuscode_formatted;
    //string[] Messagearr= new string[0];
    var Message = "";
    var txt = "";
    var TranslationData = GetTranslationData("JS_SubscriptionHandlerRibbonAction");
    var req = new XMLHttpRequest();
    req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_ordercaptures?$select=etel_name,etel_ordercaptureid,statecode,statuscode&$filter=_etel_individualcustomerid_value eq " + IndividualCustomerId + " and statuscode eq 1", true);
    req.setRequestHeader("OData-MaxVersion", "4.0");
    req.setRequestHeader("OData-Version", "4.0");
    req.setRequestHeader("Accept", "application/json");
    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
    req.onreadystatechange = function () {
        if (this.readyState === 4) {
            req.onreadystatechange = null;
            if (this.status === 200) {
                var results = JSON.parse(this.response);
                if (results.value.length > 0) {
                    for (var i = 0; i < results.value.length; i++) {
                        etel_name = results.value[i]["etel_name"];
                        var etel_ordercaptureid = results.value[i]["etel_ordercaptureid"];
                        var statecode = results.value[i]["statecode"];
                        var statecode_formatted = results.value[i]["statecode@OData.Community.Display.V1.FormattedValue"];
                        var statuscode = results.value[i]["statuscode"];
                        statuscode_formatted = results.value[i]["statuscode@OData.Community.Display.V1.FormattedValue"];
                        if (statuscode_formatted != "Submitted") {
                            Message = TranslationData.tExistingOrders;//"You are already having some Orders "
                        }
                        break; // ypala 0702 -> technically the customer supposed to have only 1 active order
                    }

                    //Xrm.Utility.confirmDialog(Message + " " + TranslationData.tNeworder, // ypala 0702
                    //    function () {// ypala 0702
                            
                            translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
                            var customerId = Xrm.Page.data.entity.getId();
                            var customerType = Xrm.Page.data.entity.getEntityName();
                            var customerTypeCode = Xrm.Page.getAttribute("statuscode").getValue();

                            var headercheck = false;
                            headercheck = headerCheck("createsubscriptionfromcustomer", customerId, customerTypeCode, customerType);

                            if (headercheck && etel_ordercaptureid) {
                                window.parent.Xrm.Utility.openEntityForm("etel_ordercapture", etel_ordercaptureid); // ypala 0702

                                /*
                                 * ypala 0702
                                 *

                                biRoleSecurityCreateSubscriptionFromCustomer.ValidateRole();
                                //setting this line for temparory purpose
                                biRoleSecurityCreateSubscriptionFromCustomer.IsValidatedRole = true;
                                if (biRoleSecurityCreateSubscriptionFromCustomer.IsValidatedRole === true) {
                                    
                                    var newOrder = {};
                                    if (customerType === "contact") {
                                        newOrder.etel_individualcustomerid = {
                                            Id: customerId,
                                            LogicalName: customerType
                                        };
                                    }
                                    else if (customerType === "account") {
                                        newOrder.etel_corporatecustomerid = {
                                            Id: customerId,
                                            LogicalName: customerType
                                        };
                                    }
                                    newOrder.etel_ordertypecode = {
                                        Value: OrderType.NewSubscription
                                    };
                                    
                                    CreateOrder(newOrder);
                                }
                                else {
                                    alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
                                }
                                */
                            }
                    //   }  // ypala 0702
                        /*,
                         *
                         * // ypala 0702
                        function () {
                            alert(TranslationData.tselectorder);//Select any one of the Ordercaptires from the Grid using the OrderCapture tab
                        });//Would you like to create a new Order? If yes please click on OK else click on Cancel and select any Order
                    */
                }
                else {
                    //Launch New Order capture screen
                    
                    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
                    var customerId = Xrm.Page.data.entity.getId();
                    var customerType = Xrm.Page.data.entity.getEntityName();
                    var customerTypeCode = Xrm.Page.getAttribute("statuscode").getValue();

                    var headercheck = false;
                    headercheck = headerCheck("createsubscriptionfromcustomer", customerId, customerTypeCode, customerType);

                    if (headercheck) {
                        biRoleSecurityCreateSubscriptionFromCustomer.ValidateRole();
                        //setting this line for temparory purpose
                        biRoleSecurityCreateSubscriptionFromCustomer.IsValidatedRole = true;
                        if (biRoleSecurityCreateSubscriptionFromCustomer.IsValidatedRole === true) {
                            var newOrder = {};
                            if (customerType === "contact") {
                                newOrder.etel_individualcustomerid = {
                                    Id: customerId,
                                    LogicalName: customerType
                                };
                            }
                            else if (customerType === "account") {
                                newOrder.etel_corporatecustomerid = {
                                    Id: customerId,
                                    LogicalName: customerType
                                };
                            }
                            newOrder.etel_ordertypecode = {
                                Value: OrderType.NewSubscription
                            };
                            CreateOrder(newOrder);
                        }
                        else {
                            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
                        }
                    }
                }
            } else {
                Xrm.Utility.alertDialog(this.statusText);
            }
        }
    };
    req.send();

}
//New Code
function AddOrders() {
    var IndividualCustomer = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();
    var IndividualCustomerId = IndividualCustomer[0].id.substr(1, 36);
    var etel_name;
    var statuscode_formatted;
    var Message = "";
    var req = new XMLHttpRequest();
    req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_ordercaptures?$select=etel_name,etel_ordercaptureid,statecode,statuscode&$filter=_etel_individualcustomerid_value eq " + IndividualCustomerId + "", true);
    req.setRequestHeader("OData-MaxVersion", "4.0");
    req.setRequestHeader("OData-Version", "4.0");
    req.setRequestHeader("Accept", "application/json");
    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
    req.onreadystatechange = function () {
        if (this.readyState === 4) {
            req.onreadystatechange = null;
            if (this.status === 200) {
                var results = JSON.parse(this.response);
                for (var i = 0; i < results.value.length; i++) {
                    etel_name = results.value[i]["etel_name"];
                    var etel_ordercaptureid = results.value[i]["etel_ordercaptureid"];
                    var statecode = results.value[i]["statecode"];
                    var statecode_formatted = results.value[i]["statecode@OData.Community.Display.V1.FormattedValue"];
                    var statuscode = results.value[i]["statuscode"];
                    statuscode_formatted = results.value[i]["statuscode@OData.Community.Display.V1.FormattedValue"];
                    if (statuscode_formatted != "Submitted") {
                        Message = Message + "You have Order" + " " + etel_name + " " + "in State" + " " + statuscode_formatted + "";
                    }
                }
                Xrm.Utility.confirmDialog(Message + "Would you like to create a new quote", CreateNewSubscriptionForProspectCustomer(), SelectExistingOrder());
            } else {
                Xrm.Utility.alertDialog(this.statusText);
            }
        }
    };
    req.send();

    //alert("Message from AddOrder button")
}
function SelectExistingOrder() {
    alert("Please Select One of the existing orders");
}
function CreateSubscriptionFromCustomerForm() {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var customerId = Xrm.Page.data.entity.getId();
    var customerType = Xrm.Page.data.entity.getEntityName();
    var customerTypeCode = Xrm.Page.getAttribute("statuscode").getValue();

    var headercheck = false;
    headercheck = headerCheck("createsubscriptionfromcustomer", customerId, customerTypeCode, customerType);

    if (headercheck) {
        //To Do: Bisecurity Control will be added as a Story to implement all Order button.
        //biSecurityNewSubscription.Validate();
        //if (biSecurityNewSubscription.IsValidated == "true") {
        biRoleSecurityCreateSubscriptionFromCustomer.ValidateRole();
        if (biRoleSecurityCreateSubscriptionFromCustomer.IsValidatedRole === true) {
            var Validate = OrderValidation(customerType, customerTypeCode, OrderType.NewSubscription);
            if (!Validate.IsValid) {
                alert(Validate.ErrorMessagae);
                return;
            }

            var newOrder = {};
            if (customerType === "contact") {
                newOrder.etel_individualcustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            }
            else if (customerType === "account") {
                newOrder.etel_corporatecustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            }
            newOrder.etel_ordertypecode = {
                Value: OrderType.NewSubscription
            };
            CreateOrder(newOrder);
        }
        else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
        //}
        //else
        //{
        //    alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationCheckMessage);
        //}
    }
}

function ModifySubscriptionFromForm(selectedSubscriptionId) {
    var customerId;
    var individual = Xrm.Page.getAttribute("etel_individualcustomerid");
    var isIndividual = false;
    var customerType = '';
    if ((individual !== null) && (individual.getValue() !== null)) {
        var individualval = individual.getValue();
        customerId = individualval[0].id;
        customerType = 'contact';
        isIndividual = true;
    }
    else {
        var corporate = Xrm.Page.getAttribute("etel_corporatecustomerid");
        if ((corporate !== null) && (corporate.getValue() !== null)) {
            var corporateval = corporate.getValue();
            customerId = corporateval[0].id;
            customerType = 'account';
        }
    }

    var headercheck = false;
    headercheck = headerCheck("modifysubscriptionfromcustomer", customerId, "", customerType);

    if (headercheck) {
        biRoleSecurityModifySubscriptionFromCustomer.ValidateRole();
        if (biRoleSecurityModifySubscriptionFromCustomer.IsValidatedRole === true) {

            var c = capitaliseFirstLetter(customerType);
            var statusReason = GetCustomerStatusReason(c, customerId);
            var validate = OrderValidation(customerType, statusReason, OrderType.ModifySubscription);
            if (!validate.IsValid) {
                alert(validate.ErrorMessage);
                return;
            }

            var newOrder = {};
            newOrder.etel_subscriptionid = {
                Id: selectedSubscriptionId,
                LogicalName: 'etel_subscription'
            };
            if (isIndividual) {
                newOrder.etel_individualcustomerid = {
                    Id: customerId,
                    LogicalName: 'contact'
                };
            }
            else {
                newOrder.etel_corporatecustomerid = {
                    Id: customerId,
                    LogicalName: 'account'
                };
            }
            newOrder.etel_ordertypecode = {
                Value: OrderType.ModifySubscription
            };
            CreateOrder(newOrder);
        } else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
    }
}

function DepositCreationFromSubscription(entityName, entityId, entityCode) {

    globalRibbon.display(entityName, entityId, entityCode, biRoleSecurityDepositCreationFromCustomer);
}

function DepositCreationFromCorporate(entityName, entityId, entityCode) {
    globalRibbon.display(entityName, entityId, entityCode, biRoleSecurityDepositCreationFromCustomer);
}

function DepositCreationFromIndividual(entityName, entityId, entityCode) {

    globalRibbon.display(entityName, entityId, entityCode, biRoleSecurityDepositCreationFromCustomer);
}

function OfferChangeFromForm(selectedSubscriptionId) {
    var customerId;
    var individual = Xrm.Page.getAttribute("etel_individualcustomerid");
    var currentOfferingId = Xrm.Page.getAttribute("etel_subscriptionofferingid").getValue();
    var isIndividual = false;
    var customerType = '';
    if ((individual !== null) && (individual.getValue() !== null)) {
        var individualval = individual.getValue();
        customerId = individualval[0].id;
        customerType = 'contact';
        isIndividual = true;
    }
    else {
        var corporate = Xrm.Page.getAttribute("etel_corporatecustomerid");
        if ((corporate !== null) && (corporate.getValue() !== null)) {
            var corporateval = corporate.getValue();
            customerId = corporateval[0].id;
            customerType = 'account';
        }
    }

    var headercheck = false;
    headercheck = headerCheck("offerchangefromcustomer", customerId, "", customerType);

    if (headercheck) {
        biRoleSecurityOfferChangeFromCustomer.ValidateRole();
        if (biRoleSecurityOfferChangeFromCustomer.IsValidatedRole === true) {

            var c = capitaliseFirstLetter(customerType);
            var statusReason = GetCustomerStatusReason(c, customerId);
            var Validate = OrderValidation(customerType, statusReason, OrderType.OfferChange);
            if (!Validate.IsValid) {
                alert(Validate.ErrorMessage);
                return;
            }

            var offerChange = {};
            if (isIndividual) {
                offerChange.etel_individualcustomerid = {
                    Id: customerId,
                    LogicalName: 'contact'
                };
            }
            else {
                offerChange.etel_corporatecustomerid = {
                    Id: customerId,
                    LogicalName: 'account'
                };
            }
            offerChange.etel_ordertypecode = {
                Value: OrderType.OfferChange
            };
            offerChange.etel_subscriptionid = {
                Id: selectedSubscriptionId,
                LogicalName: 'etel_subscription'
            };
            offerChange.etel_currentofferingid = {
                Id: currentOfferingId[0].id,
                LogicalName: 'product'
            };
            CreateOrder(offerChange);
        } else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
    }
}

function SubscriptionFromGrid(selectedSubscriptionId, orderType) {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    SDK.REST.retrieveRecord(
        selectedSubscriptionId, 'etel_subscription', 'etel_individualcustomerid,etel_corporatecustomerid, etel_subscriptionstatuscode,etel_subscriptionprogressstatuscode', null, function (subscription) {

            var customerId;
            var customerType;
            if (subscription.etel_individualcustomerid.Id != null) {
                customerId = subscription.etel_individualcustomerid.Id;
                customerType = 'contact';
            }
            else {
                customerId = subscription.etel_corporatecustomerid.Id;
                customerType = 'account';
            }
            if (subscription.etel_subscriptionprogressstatuscode && subscription.etel_subscriptionprogressstatuscode.Value === 1) {
                alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSubscriptionIsInProgress);
                return;
            }
            if (subscription.etel_subscriptionstatuscode && subscription.etel_subscriptionstatuscode.Value !== 1) {
                alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSelectActiveSubscription);
                return;
            }

            var capitalised = capitaliseFirstLetter(customerType);
            var statusReason = GetCustomerStatusReason(capitalised, customerId);
            var validate = OrderValidation(customerType, statusReason, orderType);
            if (!validate.IsValid) {
                alert(validate.ErrorMessage);
                return;
            }

            var newOrder = {};
            if (customerType === 'contact') {
                newOrder.etel_individualcustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            } else {
                newOrder.etel_corporatecustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            }
            newOrder.etel_ordertypecode = {
                Value: orderType
            };
            newOrder.etel_subscriptionid = {
                Id: selectedSubscriptionId,
                LogicalName: 'etel_subscription'
            };

            CreateOrder(newOrder);
        },
        errorHandler);

}

function OfferChangeFromGrid(selectedSubscriptionId) {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    SDK.REST.retrieveRecord(
        selectedSubscriptionId, 'etel_subscription', 'etel_individualcustomerid,etel_corporatecustomerid,etel_subscriptionstatuscode,etel_subscriptionprogressstatuscode,etel_subscriptionofferingid', null, function (subscription) {
            if (subscription.etel_subscriptionprogressstatuscode && subscription.etel_subscriptionprogressstatuscode.Value === 1) {
                alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSubscriptionIsInProgress);
                return;
            }
            if (subscription.etel_subscriptionstatuscode && subscription.etel_subscriptionstatuscode.Value !== 1) {
                alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSelectActiveSubscription);
                return;
            }

            var customerId;
            var customerType;
            if (subscription.etel_individualcustomerid.Id !== null) {
                customerId = subscription.etel_individualcustomerid.Id;
                customerType = 'contact';
            }
            else {
                customerId = subscription.etel_corporatecustomerid.Id;
                customerType = 'account';
            }

            var capitalised = capitaliseFirstLetter(customerType);
            var statusReason = GetCustomerStatusReason(capitalised, customerId);
            var validate = OrderValidation(customerType, statusReason, OrderType.OfferChange);
            if (!validate.IsValid) {
                alert(validate.ErrorMessage);
                return;
            }

            var offerChange = {};
            if (customerType === 'contact') {
                offerChange.etel_individualcustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            } else {
                offerChange.etel_corporatecustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            }
            offerChange.etel_ordertypecode = {
                Value: OrderType.OfferChange
            };
            offerChange.etel_subscriptionid = {
                Id: selectedSubscriptionId,
                LogicalName: 'etel_subscription'
            };

            offerChange.etel_currentofferingid = {
                Id: subscription.etel_subscriptionofferingid.Id,
                LogicalName: 'product'
            };

            CreateOrder(offerChange);
        },
        errorHandler);

}

function SubscriptionStatusChangeFromForm() {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var customerId;
    var customerType = '';
    var individual = Xrm.Page.getAttribute("etel_individualcustomerid");

    if (individual !== null && individual.getValue() !== null) {
        customerId = individual.getValue()[0].id;
        customerType = "contact";
    } else {
        var corporate = Xrm.Page.getAttribute("etel_corporatecustomerid");
        if (corporate !== null && corporate.getValue() !== null) {
            customerId = corporate.getValue()[0].id;
            customerType = "account";
        } else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tNoCustomer);
            return;
        }
    }

    var headercheck = false;
    headercheck = headerCheck("subscriptionstatuschangefromcustomer", customerId, "", customerType);

    if (headercheck) {
        biRoleSecuritySubscriptionStatusChangeFromCustomer.ValidateRole();
        if (biRoleSecuritySubscriptionStatusChangeFromCustomer.IsValidatedRole === true) {

            var newOrder = {};
            newOrder.etel_subscriptionid = {
                Id: Xrm.Page.data.entity.getId(),
                LogicalName: 'etel_subscription'
            };
            if (customerType === 'contact') {
                newOrder.etel_individualcustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            } else {
                newOrder.etel_corporatecustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            }
            newOrder.etel_ordertypecode = {
                Value: OrderType.ModifySubscriptionStatus
            };

            CreateOrder(newOrder);
        } else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
    }
}

function SubscriptionStatusChangeFromSubGrid(subscriptionId) {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var customerId = Xrm.Page.data.entity.getId();
    var customerType = Xrm.Page.data.entity.getEntityName();

    var headercheck = false;
    headercheck = headerCheck("subscriptionstatuschangefromcustomer", customerId, "", customerType);

    if (headercheck) {
        biRoleSecuritySubscriptionStatusChangeFromCustomer.ValidateRole();
        if (biRoleSecuritySubscriptionStatusChangeFromCustomer.IsValidatedRole === true) {

            var newOrder = {};
            if (customerType === 'contact') {
                newOrder.etel_individualcustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            } else {
                if (customerType === 'account') {
                    newOrder.etel_corporatecustomerid = {
                        Id: customerId,
                        LogicalName: customerType
                    };
                } else {
                    alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tNoCustomer);
                    return;
                }
            }
            var subsProgressStatusCode = GetSubscriptionProgressStatus(subscriptionId);
            if (subsProgressStatusCode === 1) {
                alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSubscriptionIsInProgress);
                return;
            }
            var subscriptionStatus = GetSubscriptionStatusReason(subscriptionId);
            if (subscriptionStatus !== null && subscriptionStatus === 2) {
                alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSelectActiveSubscription);
                return;
            }

            newOrder.etel_ordertypecode = {
                Value: OrderType.ModifySubscriptionStatus
            };
            newOrder.etel_subscriptionid = {
                Id: subscriptionId,
                LogicalName: 'etel_subscription'
            };
            CreateOrder(newOrder);
        } else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
    }
}

function ModifySubscriptionFromCustomerForm() {
    
    var selectedSubscription = Xrm.Page.ui.controls.get("WebResource_accountsummarytabbedview").getObject().contentWindow.angular.element(".main-container").scope().SubscriptionScopeSelectedItems;
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var customerId = Xrm.Page.data.entity.getId();
    var customerType = Xrm.Page.data.entity.getEntityName();
    var customerTypeCode = Xrm.Page.getAttribute("statuscode").getValue();

    var headercheck = false;
    headercheck = headerCheck("modifysubscriptionfromcustomer", customerId, customerTypeCode, customerType);

    if (headercheck) {

        biRoleSecurityModifySubscriptionFromCustomer.ValidateRole();
        if (biRoleSecurityModifySubscriptionFromCustomer.IsValidatedRole === true) {
            var validate = OrderValidation(customerType, customerTypeCode, OrderType.ModifySubscription);
            if (!validate.IsValid) {
                alert(validate.ErrorMessage);
                return;
            }
            var subscriptionId = globalRibbon.getEntityId(selectedSubscription);
            if (subscriptionId == null) {
                return;
            }

            var subsProgressStatusCode = GetSubscriptionProgressStatus(subscriptionId);
            if (subsProgressStatusCode === 1) {
                alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSubscriptionIsInProgress);
                return;
            }

            if (subscriptionId) {

                SubscriptionFromGrid(subscriptionId, OrderType.ModifySubscription);
            } else {
                alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSelectSubscription);
            }
        }
        else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
    }
}

function getresspecidvalue(value) {
    var msisdnflags;
    var fetchXml = "<fetch distinct='false' >" +
        "<entity name='etel_productresource'>" +
        "<attribute name='etel_name'/>" +
        "<attribute name='etel_serialnumber'/>" +
        "<attribute name='etel_imsinumber'/>" +
        "<attribute name='etel_productresourceid'/>" +
        "<attribute name='etel_resourcespecificationid'/>" +
        "<order descending='false' attribute='etel_name'/>" +
        "<filter type='and'>" +
        "<condition attribute='etel_subscriptionid' value='" + value + "'  operator='eq'/>" +
        "</filter>" +
        "<link-entity name='etel_productresourcespecification' alias='a_7e23bfd9b793e31185f3005056ae6319' link-type='outer' visible='false' to='etel_resourcespecificationid' from='etel_productresourcespecificationid'>" +
        "<attribute name='etel_resourcetypecode'/>" +
        "</link-entity>" +
        "</entity>" +
        "</fetch>";
    var retriveID = XrmServiceToolkit.Soap.Fetch(fetchXml);
    if (retriveID.length > 0) {
        if (retriveID != null || retriveID != "undefined") {
            for (var i in retriveID) {
                resspecid = retriveID[i].attributes.etel_resourcespecificationid.id;
                msisdnflags = getresspecificationvalue(resspecid);
                if (msisdnflags == true) {
                    return msisdnflags;
                }
                if (msisdnflags == false && retriveID.length == i) {
                    //alert("MSISDN, Not Associted with Product Resource");
                    alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tNotaasociateProductresource);
                }
            }
        }
    }
    else {
        //alert("Product Resource Not Associated with the subscription");
        alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tNotProductresource);
        return;
    }
    //return msisdnflags;
}

function getresspecificationvalue(value) {
    var msisdnflag = false;
    var fetchXml = "<fetch distinct='true' >" +
        "<entity name='etel_productresourcespecification'>" +
        "<attribute name='etel_name'/>" +
        "<attribute name='etel_resourcetypecode'/>" +
        "<attribute name='etel_resourcesubtypecode'/>" +
        "<attribute name='etel_productresourcespecificationid'/>" +
        "<attribute name='etel_externalid'/>" +
        "<order descending='false' attribute='etel_name'/>" +
        "<link-entity name='etel_productresource' alias='ad' to='etel_productresourcespecificationid' from='etel_resourcespecificationid'>" +
        "<filter type='and'>" +
        "<condition attribute='etel_resourcespecificationid' value='" + value + "'  operator='eq'/>" +
        "</filter>" +
        "</link-entity>" +
        "</entity>" +
        "</fetch>";
    var retriveID = XrmServiceToolkit.Soap.Fetch(fetchXml);
    if (retriveID.length > 0) {
        var externalid = retriveID[0].attributes.etel_externalid.value;
        if (externalid == "lrs_MSISDN") {
            msisdnflag = true;
        }
        else {
            //alert("MSISDN, Not Associted with Product Resource");
            return false;
        }
    }
    return msisdnflag;
}

function modifysubscriptionBIwhitepagefromcustomer() {
    
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var selectedSubscription = Xrm.Page.ui.controls.get("WebResource_accountsummarytabbedview").getObject().contentWindow.angular.element(".main-container").scope().SubscriptionScopeSelectedItems;
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var subscriptionId = globalRibbon.getEntityId(selectedSubscription);
    subscriptionId = "{" + subscriptionId + "}";
    if (subscriptionId == null) {
        return;
    }
    var cols = ["etel_corporatecustomerid", "etel_individualcustomerid", "amxperu_whitepages"];
    var retrievedsubscription = XrmServiceToolkit.Soap.Retrieve("etel_subscription", subscriptionId, cols);
    var msisdnval = getresspecidvalue(subscriptionId);
    if (subscriptionId != null && msisdnval == true) {
        var parameters = {};
        if (retrievedsubscription != null && retrievedsubscription.attributes['etel_corporatecustomerid'] != null && retrievedsubscription.attributes.etel_corporatecustomerid.id) {
            parameters["amxperu_customercorporateid"] = retrievedsubscription.attributes.etel_corporatecustomerid.id;
            parameters["amxperu_customercorporateidname"] = retrievedsubscription.attributes.etel_individualcustomerid.formattedValue
        }
        if (retrievedsubscription != null && retrievedsubscription.attributes['etel_individualcustomerid'] != null && retrievedsubscription.attributes.etel_individualcustomerid.id) {
            parameters["amxperu_customerindividualid"] = retrievedsubscription.attributes.etel_individualcustomerid.id;
            parameters["amxperu_customerindividualidname"] = retrievedsubscription.attributes.etel_individualcustomerid.formattedValue;
        }
        if (retrievedsubscription != null && retrievedsubscription.attributes['amxperu_whitepages'] != null && retrievedsubscription.attributes['amxperu_whitepages'].value) {
            parameters["amxperu_currentwpstatus"] = retrievedsubscription.attributes['amxperu_whitepages'].value;
        }
        if (subscriptionId != null) {
            parameters["amxperu_subscriptionrecordid"] = subscriptionId;
        }
        var windowOptions = {
            openInNewWindow: false
        };
        Xrm.Utility.openEntityForm("amxperu_affiliatedisaffiliatetowhitepages", null, parameters, windowOptions);
    }

}

function OfferChangeFromCustomerForm() {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var selectedSubscription = Xrm.Page.ui.controls.get("WebResource_accountsummarytabbedview").getObject().contentWindow.angular.element(".main-container").scope().SubscriptionScopeSelectedItems;

    var customerId = Xrm.Page.data.entity.getId();
    var customerType = Xrm.Page.data.entity.getEntityName();
    var customerTypeCode = Xrm.Page.getAttribute("statuscode").getValue();

    var headercheck = false;
    headercheck = headerCheck("offerchangefromcustomer", customerId, customerTypeCode, customerType);

    if (headercheck) {
        biRoleSecurityOfferChangeFromCustomer.ValidateRole();
        if (biRoleSecurityOfferChangeFromCustomer.IsValidatedRole === true) {
            var subscriptionId = globalRibbon.getEntityId(selectedSubscription);
            if (subscriptionId != null) {

                var subsProgressStatusCode = GetSubscriptionProgressStatus(subscriptionId);
                if (subsProgressStatusCode === 1) {
                    alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSubscriptionIsInProgress);
                    return;
                }
                var subStatusCode = GetSubscriptionStatusReason(subscriptionId);
                if (subStatusCode !== null && subStatusCode === 1) {
                    OfferChangeFromGrid(subscriptionId);
                } else {
                    alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSelectActiveSubscription);
                }
            }
        }
        else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
    }
}

function SubscriptionStatusChangeFromCustomerForm() {

    var selectedSubscription = Xrm.Page.ui.controls.get("WebResource_accountsummarytabbedview").getObject().contentWindow.angular.element(".main-container").scope().SubscriptionScopeSelectedItems;

    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var customerId = Xrm.Page.data.entity.getId();
    var customerType = Xrm.Page.data.entity.getEntityName();
    var customerTypeCode = Xrm.Page.getAttribute("statuscode").getValue();

    var headercheck = false;
    headercheck = headerCheck("subscriptionstatuschangefromcustomer", customerId, customerTypeCode, customerType);

    if (headercheck) {
        biRoleSecuritySubscriptionStatusChangeFromCustomer.ValidateRole();
        if (biRoleSecuritySubscriptionStatusChangeFromCustomer.IsValidatedRole === true) {
            var validate = OrderValidation(customerType, customerTypeCode, OrderType.ModifySubscriptionStatus);
            if (!validate.IsValid) {
                alert(validate.ErrorMessage);
                return;
            }

            var subscriptionId = globalRibbon.getEntityId(selectedSubscription);

            var subsProgressStatusCode = GetSubscriptionProgressStatus(subscriptionId);
            if (subsProgressStatusCode === 1) {
                alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSubscriptionIsInProgress);
                return;
            }
            var subStatusCode = GetSubscriptionStatusReason(subscriptionId);
            if (subStatusCode !== null && (subStatusCode === 1 || subStatusCode === 831260001)) {
                SubscriptionStatusChangeFromSubGrid(subscriptionId);
            }
            else if (subStatusCode !== null && subStatusCode === 2) { // 2=Deactive
                alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSelectActiveSubscription);
            }
            else {
                alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSelectActiveSubscription);
            }

        }
        else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
    }
}

function CorporateCustomerCreationFromCustomerFormOldProcess() {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    biRoleSecurityCorporateCustomerCreationFromCustomer.ValidateRole();
    if (biRoleSecurityCorporateCustomerCreationFromCustomer.IsValidatedRole === true) {
        //ii. If CSR choose a record with status other than “prospect”, ”not customer” and “suspended” (meaning active or passive)
        //then “New Subscription” and “Corporate Customer Creation” buttons should be active.
        //User can create new subscription under customer using “New Subscription” button or create new division under customer using “Corporate Customer Creation” button.
        var customerId = Xrm.Page.data.entity.getId();
        var customerType = Xrm.Page.data.entity.getEntityName();
        var customerTypeCode = Xrm.Page.getAttribute("statuscode").getValue();

        var orderEntityLogicalName = "etel_corporatecustomercreationorder";
        var corporatecustomercreationorder = {};
        corporatecustomercreationorder["processid"] = "7c15aed9-c47c-42e8-8a4a-87634be651ab";
        corporatecustomercreationorder["stageid"] = "f7999886-152a-4f8e-9dd2-aaf2ebf7b7a5";

        if (customerTypeCode === CorporateCustomerStatusCode.PROSPECT) {
            corporatecustomercreationorder.etel_corporatecustomerid = {
                Id: customerId,
                LogicalName: customerType
            };

            corporatecustomercreationorder.etel_addresstypecode = {
                Value: Xrm.Page.getAttribute("etel_customeraddresstypecode").getValue()
            };

            var parentaccount = Xrm.Page.getAttribute("parentaccountid");
            var parentaccountid;
            if (!parentaccount) {
                parentaccountid = GetParentAccount('Account', customerId);
            }
            else {
                if (parentaccount.getValue() !== null) {
                    parentaccountid = parentaccount.getValue()[0].id;
                }
            }

            if (parentaccountid && parentaccountid !== null) {
                var statusReason = GetCustomerStatusReason('Account', parentaccountid);
                if (statusReason === CorporateCustomerStatusCode.ACTIVE || statusReason === CorporateCustomerStatusCode.SUSPEND || statusReason === CorporateCustomerStatusCode.PASSIVE) {
                    corporatecustomercreationorder.etel_parentcustomerid = {
                        Id: parentaccountid,
                        LogicalName: 'account'
                    };
                    corporatecustomercreationorder.etel_isroot = false;
                }
            }
        } else {
            if (customerTypeCode === CorporateCustomerStatusCode.ACTIVE || customerTypeCode === CorporateCustomerStatusCode.SUSPEND || customerTypeCode === CorporateCustomerStatusCode.PASSIVE) {
                corporatecustomercreationorder.etel_isroot = false;
                corporatecustomercreationorder.etel_parentcustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
            }
        }

        SDK.REST.createRecord(
            corporatecustomercreationorder, orderEntityLogicalName, function (newOrder) {
                Xrm.Utility.openEntityForm(orderEntityLogicalName, newOrder.etel_corporatecustomercreationorderId);
            },
            errorHandler);
    } else {
        alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
    }
}

var OrderCaptureId;

function CorporateCustomerCreationFromCustomerForm() {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    biRoleSecurityCorporateCustomerCreationFromCustomer.ValidateRole();
    if (biRoleSecurityCorporateCustomerCreationFromCustomer.IsValidatedRole === true) {
        //ii. If CSR choose a record with status other than “prospect”, ”not customer” and “suspended” (meaning active or passive)
        //then “New Subscription” and “Corporate Customer Creation” buttons should be active.
        //User can create new subscription under customer using “New Subscription” button or create new division under customer using “Corporate Customer Creation” button.
        var customerId = Xrm.Page.data.entity.getId();
        var customerType = Xrm.Page.data.entity.getEntityName();
        var customerTypeCode = Xrm.Page.getAttribute("statuscode").getValue();

        var orderEntityLogicalName = "etel_ordercapture";
        var orderCorporateEntityLogicalName = "etel_ordercapturecorporate"
        var corporatecustomercreationorder = {};
        var newOrder = {};

        if (customerTypeCode === CorporateCustomerStatusCode.PROSPECT) {

            corporatecustomercreationorder.etel_corporateid = {
                Id: customerId,
                LogicalName: customerType
            };

            newOrder.etel_corporatecustomerid = {
                Id: customerId,
                LogicalName: 'account'
            };

            var parentaccount = Xrm.Page.getAttribute("parentaccountid");
            var parentaccountid;
            if (!parentaccount) {
                parentaccountid = GetParentAccount('Account', customerId);
            }
            else {
                if (parentaccount.getValue() !== null) {
                    parentaccountid = parentaccount.getValue()[0].id;
                }
            }

            corporatecustomercreationorder.etel_isroot = true;//root

            if (parentaccountid && parentaccountid !== null) {
                var resultAccount = retrieveCrmRecord(customerId, "Account", "StateCode,StatusCode,etel_occrateplanid,etel_billcyclecode", null);
                //if (resultAccount.StatusCode !== null && (resultAccount.StatusCode.Value === CorporateCustomerStatusCode.ACTIVE || resultAccount.StatusCode.Value === CorporateCustomerStatusCode.SUSPEND || resultAccount.StatusCode.Value === CorporateCustomerStatusCode.PASSIVE)) {
                corporatecustomercreationorder.etel_parentcustomerid = {
                    Id: parentaccountid,
                    LogicalName: 'account'
                };
                corporatecustomercreationorder.etel_isroot = false;//division
                corporatecustomercreationorder.etel_occrateplanid = resultAccount.etel_occrateplanid;
                corporatecustomercreationorder.etel_billcycle = resultAccount.etel_billcyclecode;
                //}
            }

            newOrder.etel_ordertypecode = {
                Value: 831260010
            };
        }
        else {
            if (customerTypeCode === CorporateCustomerStatusCode.ACTIVE || customerTypeCode === CorporateCustomerStatusCode.SUSPEND || customerTypeCode === CorporateCustomerStatusCode.PASSIVE) {
                corporatecustomercreationorder.etel_isroot = false;
                retrieveCrmRecord(customerId, "Account", "StateCode,StatusCode,etel_occrateplanid,etel_billcyclecode", null, function (corporatecustomer) {
                    corporatecustomercreationorder.etel_occrateplanid = corporatecustomer.etel_occrateplanid;
                    corporatecustomercreationorder.etel_billcycle = corporatecustomer.etel_billcyclecode;
                }, this._errorHandler, false);

                corporatecustomercreationorder.etel_parentcustomerid = {
                    Id: customerId,
                    LogicalName: customerType
                };
                newOrder.etel_ordertypecode = {
                    Value: 831260010
                };
            }
        }

        var OrderID = CreateOrderSync(newOrder);

        corporatecustomercreationorder.etel_ordercaptureid = {
            Id: OrderID,
            LogicalName: 'etel_ordercapture'
        };

        OrderCorporateCustomerID = CreateOrderCaptureCorporateCustomer(corporatecustomercreationorder);

        var ordercorporateUpdaterecord = {};
        ordercorporateUpdaterecord.etel_ordercapturecorporateid =
            {
                Id: OrderCorporateCustomerID,
                LogicalName: 'etel_ordercapturecorporate'
            };
        updateRecord(OrderID, ordercorporateUpdaterecord, 'etel_ordercapture', function () { }, this._errorHandler, false);
    }
    else {
        alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
    }
}

function CreateOrderCaptureCorporateCustomer(CorporateObj) {
    createCrmRecordOrderProcess(CorporateObj, 'etel_ordercapturecorporate', function (ordercorp) {
        OrderCaptureCorporateCustomerID = ordercorp.etel_ordercapturecorporateId;
    }, this._errorHandler, false);
    return OrderCaptureCorporateCustomerID;
}

function CreateOrderSync(orderObj) {
    orderObj.etel_numberofsubscription = 1;
    createCrmRecordOrderProcess(orderObj, 'etel_ordercapture', function (order) {
        OrderCaptureId = order.etel_ordercaptureId;
        window.parent.Xrm.Utility.openEntityForm('etel_ordercapture', order.etel_ordercaptureId);
    },
        this._errorHandler, false);
    return OrderCaptureId;
}

function NewAcquisitionFromIndividualCustomerForm() {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    biRoleSecurityNewAcquisitionFromIndividualCustomer.ValidateRole();
    if (biRoleSecurityNewAcquisitionFromIndividualCustomer.IsValidatedRole === true) {
        var customerId = Xrm.Page.data.entity.getId();
        var customerType = Xrm.Page.data.entity.getEntityName();
        var customerTypeCode = Xrm.Page.getAttribute("statuscode").getValue();
        var validate = OrderValidation(customerType, customerTypeCode, OrderType.NewAcquisition);
        if (!validate.IsValid) {
            alert(validate.ErrorMessage);
            return;
        }
        var newOrder = {};
        newOrder.etel_individualcustomerid = {
            Id: customerId,
            LogicalName: customerType
        };
        newOrder.etel_ordertypecode = {
            Value: OrderType.NewAcquisition
        };
        CreateOrder(newOrder);
    }
    else {
        alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
    }
}

function OrderValidation(customerType, customerStatusCode, orderType) {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var isValid = false;
    var errorMessage;

    if (customerType === 'contact') {
        if (orderType === OrderType.NewAcquisition) {
            if (customerStatusCode === IndividualCustomerStatusCode.PROSPECT || customerStatusCode === IndividualCustomerStatusCode.NOTCUSTOMER) {
                isValid = true;
            }
            else {
                isValid = false;
                errorMessage = 'can not create new acquisition order when customer status not in "prospect" or "not customer"';
            }
        }
        else if (orderType === OrderType.NewSubscription) {
            if (customerStatusCode === IndividualCustomerStatusCode.PASSIVE || customerStatusCode === IndividualCustomerStatusCode.ACTIVE || customerStatusCode === IndividualCustomerStatusCode.SUSPEND) {
                isValid = true;
            }
            else {
                isValid = false;
                errorMessage = 'can not create order when customer status not in "passive", "active", "suspend"';
            }
        }
        else if (orderType === OrderType.ModifySubscription) {
            if (customerStatusCode === IndividualCustomerStatusCode.PASSIVE || customerStatusCode === IndividualCustomerStatusCode.ACTIVE) {
                isValid = true;
            }
            else {
                isValid = false;
                errorMessage = 'can not create order when customer status not in "passive" or "active"';
            }
        }
        else if (orderType === OrderType.OfferChange) {
            if (customerStatusCode === IndividualCustomerStatusCode.PASSIVE || customerStatusCode === IndividualCustomerStatusCode.ACTIVE) {
                isValid = true;
            }
            else {
                isValid = false;
                errorMessage = 'can not create order when customer status not in "passive" or "active"';
            }
        } else if (orderType === OrderType.SubscriptionTakeOver) {
            if (customerStatusCode === IndividualCustomerStatusCode.ACTIVE) {
                isValid = true;
            }
            else {
                isValid = false;
                errorMessage = 'can not create order when customer status not in "active"';
            }
        }
        else if (orderType === OrderType.ModifySubscriptionStatus) {
            if (customerStatusCode === IndividualCustomerStatusCode.PASSIVE || customerStatusCode === IndividualCustomerStatusCode.ACTIVE || customerStatusCode === IndividualCustomerStatusCode.SUSPEND) {
                isValid = true;
            }
            else {
                isValid = false;
                errorMessage = 'can not create order when customer status not in "passive", "active" or "suspend"';
            }
        }
        else {
            isValid = true;
        }
    }
    else if (customerType === 'account') {
        if (orderType === OrderType.NewSubscription) {
            if (customerStatusCode === IndividualCustomerStatusCode.PASSIVE || customerStatusCode === IndividualCustomerStatusCode.ACTIVE || customerStatusCode === IndividualCustomerStatusCode.SUSPEND) {
                isValid = true;
            }
            else {
                isValid = false;
                errorMessage = 'can not create order when customer status not in "passive", "active", "suspend"';
            }
        }
        else if (orderType === OrderType.ModifySubscription) {
            if (customerStatusCode === IndividualCustomerStatusCode.PASSIVE || customerStatusCode === IndividualCustomerStatusCode.ACTIVE) {
                isValid = true;
            }
            else {
                isValid = false;
                errorMessage = 'can not create order when customer status not in "passive" or "active"';
            }
        }
        else if (orderType === OrderType.OfferChange) {
            if (customerStatusCode === IndividualCustomerStatusCode.PASSIVE || customerStatusCode === IndividualCustomerStatusCode.ACTIVE) {
                isValid = true;
            }
            else {
                isValid = false;
                errorMessage = 'can not create order when customer status not in "passive" or "active"';
            }
        }
        else if (orderType === OrderType.SubscriptionTakeOver) {
            if (customerStatusCode === IndividualCustomerStatusCode.ACTIVE) {
                isValid = true;
            }
            else {
                isValid = false;
                errorMessage = 'can not create order when customer status not in "active"';
            }
        }
        else if (orderType === OrderType.ModifySubscriptionStatus) {
            if (customerStatusCode === IndividualCustomerStatusCode.PASSIVE || customerStatusCode === IndividualCustomerStatusCode.ACTIVE || customerStatusCode === IndividualCustomerStatusCode.SUSPEND) {
                isValid = true;
            }
            else {
                isValid = false;
                errorMessage = 'can not create order when customer status not in "passive", "active" or "suspend"';
            }
        }
        else {
            isValid = true;
        }
    }

    var obj = new ValidationClass(isValid, errorMessage);

    return obj;
}

var ValidationClass = function (isvalid, errorMessage) {
    this.IsValid = isvalid;
    this.ErrorMessage = errorMessage;
};

var OrderType = Object.freeze({
    "NewAcquisition": 831260001,
    "NewSubscription": 831260002,
    "ModifySubscription": 831260003,
    "ModifySubscriptionStatus": 831260004,
    "OfferChange": 831260005,
    "SubscriptionTakeOver": 831260006
});

var IndividualCustomerStatusCode = Object.freeze({
    "ACTIVE": 1,
    "PROSPECT": 831260000,
    "PASSIVE": 831260001,
    "SUSPEND": 831260002,
    "NOTCUSTOMER": 831260003,
});

var CorporateCustomerStatusCode = Object.freeze({
    "ACTIVE": 1,
    "PROSPECT": 831260000,
    "PASSIVE": 831260001,
    "SUSPEND": 831260002,
});

var IndividualCustomerOrderStages = new (function () {
    this.Aquisition = Object.freeze({
        "OFFERINGINFO": "96980e9b-0ea4-bd30-2989-2c06883e3999"
    });
    this.NewSubscription = Object.freeze({
        "OFFERINGINFO": "2e1eb928-c043-4d64-8ac1-977677ec69f9"
    });
    this.ModifySubscription = Object.freeze({
        "OFFERINGINFO": "89e1f8d0-2064-440c-a5af-d1bda1c26654"
    });
})();

var IndividualCustomerOrderProcess = Object.freeze({
    "AQUISITION": "ad8d41f7-3bf8-4556-afe9-c544d6e89829",
    "NEWSUBSCRIPTION": "86619fef-1993-4d93-a936-4173cea736e3",
    "MODIFYSUBSCRIPTION": "7b8809cd-63f3-4e05-82fa-4db9be4ffba6",
});

var CorporateCustomerSubscriptionStages = new (function () {
    this.NewSubscription = Object.freeze({
        "PLANANDADDONS": "62956531-0ad9-4730-8433-6cc80764c587",
        "CONFIGURATION": "b3a90dd3-4ebc-a827-78ae-69ac9541856a",
        "RESOURCES": "a3a10670-6621-316e-cc97-069ea1eac858",
        "BILLINGANDPAYMENT": "97928dd9-56d8-3a21-0895-51b596483b1e",
        "SUMMARY": "382830e1-4b08-3edc-e6ec-ac9449409aa9"
    });
})();

var CorporateCustomerSubscriptionProcess = Object.freeze({
    "NEWSUBSCRIPTION": "A7D3E490-76FD-480A-B8DF-8598ABF97781"
});

var SecurityRoles = Object.freeze({
    "PRODUCTMANAGER": "edac0c4f-0dca-e311-9f99-005056ae2607"
});

function IsNewSubscriptionButtonEnabled() {
    
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var retVal = true;

    biRoleSecurityCreateSubscriptionFromCustomer.ValidateRole();

    retVal = !!biRoleSecurityCreateSubscriptionFromCustomer.IsValidatedRole;

    if (retVal) {
        retVal = CheckIfCustomerRelatedToSubscriptionIsNotInactive();
    }

    return retVal;
}

function CheckIfCustomerRelatedToSubscriptionIsNotInactive() {
    
    var individualObject = Xrm.Page.getAttribute("etel_individualcustomerid");
    var corporateObject = Xrm.Page.getAttribute("etel_corporatecustomerid");
    var statusReason;

    if (individualObject !== null) {

        var individualObjectValue = individualObject.getValue();

        if ((individualObjectValue !== null)) {
            var individualId = individualObjectValue[0].id;
            statusReason = GetCustomerStatusReason('Contact', individualId);
            return !(statusReason == 2);
            //return true;
        }
    }
    else if (corporateObject !== null) {

        var corporateObjectValue = corporateObject.getValue();

        if ((corporateObjectValue !== null)) {
            var corporateId = corporateObjectValue[0].id;
            statusReason = GetCustomerStatusReason('Account', corporateId);
            return !(statusReason == 2);
        }
    }

    return true;
}

function IsModifySubscriptionButtonEnabled() {
    var retVal = true;

    biRoleSecurityModifySubscriptionFromCustomer.ValidateRole();

    retVal = !!biRoleSecurityModifySubscriptionFromCustomer.IsValidatedRole;

    return retVal;
}

function IsChangeOwnershipButtonEnabled() {
    var retVal = true;

    biRoleSecuritySubscriptionTakeOver.ValidateRole();

    retVal = !!biRoleSecuritySubscriptionTakeOver.IsValidatedRole;

    return retVal;
}

function IsOfferChangeButtonEnabled() {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var retVal = true;

    biRoleSecurityOfferChangeFromCustomer.ValidateRole();

    retVal = !!biRoleSecurityOfferChangeFromCustomer.IsValidatedRole;

    return retVal;
}

function IsChangeStatusButtonEnabled() {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var retVal = true;

    biRoleSecuritySubscriptionStatusChangeFromCustomer.ValidateRole();

    retVal = !!biRoleSecuritySubscriptionStatusChangeFromCustomer.IsValidatedRole;

    return retVal;
}

function IsNewAcquisitionButtonEnabled() {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var retVal = true;

    biRoleSecurityNewAcquisitionFromIndividualCustomer.ValidateRole();

    retVal = !!biRoleSecurityNewAcquisitionFromIndividualCustomer.IsValidatedRole;

    return retVal;
}

function IsCorporateCustomerCreationButtonEnabled() {
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var retVal = true;

    biRoleSecurityCorporateCustomerCreationFromCustomer.ValidateRole();

    retVal = !!biRoleSecurityCorporateCustomerCreationFromCustomer.IsValidatedRole;

    return retVal;
}