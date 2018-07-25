

function ChangeResumeDate() {
    debugger;
    translationScope_JS_SubscriptionHandlerRibbonAction.GetData();
    var customerId = Xrm.Page.data.entity.getId();
    var customerType = Xrm.Page.data.entity.getEntityName();
    var customerTypeCode = Xrm.Page.getAttribute("statuscode").getValue();

    var headercheck = false;
    headercheck = headerCheck("createsubscriptionfromcustomer", customerId, customerTypeCode, customerType);

    if (headercheck) {
        biRoleSecurityCreateSubscriptionFromCustomer.ValidateRole();
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
                Value: 831260011   /// change resume date order type
            };
            CreateOrder(newOrder);
        }
        else {
            alert(translationScope_JS_SubscriptionHandlerRibbonAction.data.tValidationRoleCheckMessage);
        }
    }
}
