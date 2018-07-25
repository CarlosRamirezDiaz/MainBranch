function xModifySubscriptionFromCustomerForm() {
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
            var validate = AmxOrderValidation(customerType, customerTypeCode, OrderType.ModifySubscription);
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


function ResumeChangeSubscriptionFromCustomerForm() {
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
            var validate = AmxOrderValidation(customerType, customerTypeCode, "ResumeChangeDate");
            //if (!validate.IsValid) {
            //    alert(validate.ErrorMessage);
            //    return;
            //}
            //var subscriptionId = globalRibbon.getEntityId(selectedSubscription);
            //if (subscriptionId == null) {
            //    return;
            //}

            //var subsProgressStatusCode = GetSubscriptionProgressStatus(subscriptionId);
            //if (subsProgressStatusCode === 1) {
            //    alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSubscriptionIsInProgress);
            //    return;
            //}

            //if (subscriptionId) {

            //    SubscriptionFromGrid(subscriptionId, OrderType.ModifySubscription);
            //} else {
            //    alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tSelectSubscription);
            //}
        }
        else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
    }
}



function AmxOrderValidation(customerType, customerTypeCode, orderType) {

    if (subscriptionStatusCode === IndividualCustomerStatusCode.SUSPEND) {
        if (orderType == "ResumeChangeDate") {


        } else if (orderType == "Reconnection") {

        }
        else if (orderType == "WrongSubscriptions") {

        }
    }
}

//var OrderType = Object.freeze({
//    "NewAcquisition": 831260001,
//    "NewSubscription": 831260002,
//    "ModifySubscription": 831260003,
//    "ModifySubscriptionStatus": 831260004,
//    "OfferChange": 831260005,
//    "SubscriptionTakeOver": 831260006
//});

//var IndividualCustomerStatusCode = Object.freeze({
//    "ACTIVE": 1,
//    "PROSPECT": 831260000,
//    "PASSIVE": 831260001,
//    "SUSPEND": 831260002,
//    "NOTCUSTOMER": 831260003,
//});

//var CorporateCustomerStatusCode = Object.freeze({
//    "ACTIVE": 1,
//    "PROSPECT": 831260000,
//    "PASSIVE": 831260001,
//    "SUSPEND": 831260002,
//});