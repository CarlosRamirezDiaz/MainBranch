var CrmFormId = {
    IndividualCustomer360FormId: "e283abea-f298-4c98-9510-8e791d0e1ce5",
    CorporateCustomer360FormId: "162d9ec0-d88f-4d0e-b535-1d844364d900",
};
var translationScope_js_BI_CustomerAddress = {
    data: null,
    GetData: function () {
        var formId = 'js_BI_CustomerAddress';
        if (translationScope_js_BI_CustomerAddress.data != null) {
            return;
        }
        translationScope_js_BI_CustomerAddress.data = GetTranslationData(formId);
    }
};
var customer = {
    LogicalName: "",
    EntityCode: undefined,
    Id: "",
    Name: "",
    GetCustomer: function () {
        var entityType = Xrm.Page.data.entity.getEntityName();
        if (entityType == "contact") {
            customer.EntityCode = 2;
            customer.Name = getValueFromDB("ContactSet", "ContactId", Xrm.Page.data.entity.getId(), "FullName");
            customer.LogicalName = entityType;
            customer.Id = Xrm.Page.data.entity.getId();
        }
        else if (entityType == "account") {
            customer.EntityCode = 1;
            customer.Name = getValueFromDB("AccountSet", "AccountId", Xrm.Page.data.entity.getId(), "Name");
            customer.LogicalName = entityType;
            customer.Id = Xrm.Page.data.entity.getId();
        }
        else if (entityType == "etel_customeraddressbusinessinteraction" || entityType == "etel_bi_customeraddressmodification") {
            var customerIndividualField = Xrm.Page.getAttribute("etel_individualcustomer").getValue();
            var customerCorporateField = Xrm.Page.getAttribute("etel_corporatecustomer").getValue();
            if (customerIndividualField) {
                customer.EntityCode = 2;
                customer.Id = customerIndividualField[0].id;
                customer.Name = getValueFromDB("ContactSet", "ContactId", customer.Id, "FullName");
                customer.LogicalName = "contact";
            }
            else if (customerCorporateField) {
                customer.EntityCode = 1;
                customer.Id = customerCorporateField[0].id;
                customer.Name = getValueFromDB("AccountSet", "AccountId", customer.Id, "Name");
                customer.LogicalName = "account";
            }
        }
    }
};
var settings = {
    ServerURL: "",
    CurrentUserId: "",
    GetUrl: function () {
        Xrm.Page.context.getClientUrl();
        if (settings.ServerURL.match(/\/$/)) {
            settings.ServerURL = settings.ServerURL.substring(0, settings.ServerURL.length - 1);
        }
        if (typeof Xrm.Page.context.getClientUrl != "undefined") {
            settings.ServerURL = Xrm.Page.context.getClientUrl();
        }
    },
    GetCurrentUserId: function () {
        settings.CurrentUserId = Xrm.Page.context.getUserId();
    },
    Initialise: function () {
        settings.GetUrl();
        settings.GetCurrentUserId();
    }
};
var biSecurityCreateAddress = {
    IsValidated: "",
    Validate: function () {
        var paymentType = null;
        var request = new PrepareRequest(new CustomerAddressSecurityRequest('etel_customeraddressbusinessinteraction', customer.Id, customer.EntityCode, paymentType, settings.CurrentUserId));
        retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
            biSecurityCreateAddress.IsValidated = data.IsValidated;
        });
    }
};
var createAddressSecurityRoleCheck = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_js_BI_CustomerAddress.GetData();

        createAddressSecurityRoleCheck.IsValidatedRole = Util.Security.UserHasBIPrivilage("etel_customeraddressbusinessinteraction");
    }
};
var biSecurityUpd = {
    IsValidated: "",
    Validate: function () {
        var paymentType = null;
        var request = new PrepareRequest(new CustomerAddressModificationSecurityRequest('etel_bi_customeraddressmodification', customer.Id, customer.EntityCode, paymentType, settings.CurrentUserId));
        retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
            biSecurityUpd.IsValidated = data.IsValidated;
        });
    }
};
var customerAddressBIValidations = {
    ExecuteValidations: function () {
        var email = Xrm.Page.getAttribute("etel_emailaddress").getValue();

        if (email != null && !validateEmail(email)) {
            return false;
        }

        return true;
    }
}
var modifyAddressSecurityRoleCheck = {
    IsValidatedRole: "",
    ValidateRole: function () {
        translationScope_js_BI_CustomerAddress.GetData();

        modifyAddressSecurityRoleCheck.IsValidatedRole = Util.Security.UserHasBIPrivilage("etel_bi_customeraddressmodification");

    }
};
var biAutoNumberCustomerAddress = {
    IsCreated: "",
    BINumber: "",
    CreateBINumber: function () {
        translationScope_js_BI_CustomerAddress.GetData();
        var request = new PrepareRequest(new CreateBINumberRequest());
        retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
            biAutoNumberCustomerAddress.IsCreated = data.Success;
            biAutoNumberCustomerAddress.BINumber = data.BINumber;
        });
    }
};
var SelectedAddressId = null;
function CustomerAddressOnLoad() {
    debugger;
    translationScope_js_BI_CustomerAddress.GetData();
    var formType = Xrm.Page.ui.getFormType();
    var individualCustomer = Xrm.Page.getAttribute("etel_individualcustomer").getValue();
    var corporateCustomer = Xrm.Page.getAttribute("etel_corporatecustomer").getValue();
    var address = Xrm.Page.getAttribute("etel_customeraddress").getValue();
    if (formType == 1) {
        if (address != null) {
            var oDataUrl = "?$select=" + "etel_customeraddresstypecode, etel_addressline1, etel_addressline2, etel_addressline3, etel_cityid, etel_countryid, etel_postalcode, etel_fax, etel_emailaddress, etel_telephone2, etel_telephone1, etel_isprimaryaddress, amxperu_department, amxperu_province, amxperu_district, amxperu_populationzone, amxperu_blockedifice, amxperu_apartmenttypeinterior, amxperu_zonetype, amxperu_urbanizationtype, amxperu_longitude, amxperu_latitude, amxperu_ubigeo, amxperu_referencedescription, amxperu_square, amxperu_allotment, amxperu_number, amxperu_grouping, amxperu_buildtype, amxperu_building, amxperu_normalized, amxperu_billingemail, amxperu_street1" + "&$filter=" + "etel_customeraddressId" + " eq guid'" + address[0].id + "'";
            var resultSet = retrieveRecord("etel_customeraddressSet", oDataUrl);

            if (resultSet !== null && resultSet !== "undefined") {
                if (resultSet.results != null && resultSet.results.length > 0) {
                    var result = resultSet.results[0];
                    Xrm.Page.getAttribute("etel_customeraddresstypecode").setValue(result.etel_customeraddresstypecode.Value);
                    Xrm.Page.getAttribute("etel_street1").setValue(result.etel_addressline1);
                    Xrm.Page.getAttribute("etel_street2").setValue(result.etel_addressline2);
                    Xrm.Page.getAttribute("etel_street3").setValue(result.etel_addressline3);
                    Xrm.Page.getAttribute("etel_postalcode").setValue(result.etel_postalcode);
                    Xrm.Page.getAttribute("etel_fax").setValue(result.etel_fax);
                    Xrm.Page.getAttribute("etel_emailaddress").setValue(result.etel_emailaddress);
                    Xrm.Page.getAttribute("etel_telephone2").setValue(result.etel_telephone2);
                    Xrm.Page.getAttribute("etel_telephone1").setValue(result.etel_telephone1);
                    Xrm.Page.getAttribute("etel_isprimaryaddress").setValue(result.etel_isprimaryaddress);

                    //20170226:turboforms:artik onchange fonk.lari javascript ile set edildigindede calisiyor.siralama onemli.
                    //ayrica id,parantezli ve b�y�k olmaz ise,save sirasinda ikinci bir tetiklemeye neden oluyor.
                    Xrm.Page.getAttribute("etel_countryid").setValue([{
                        id: '{' + result.etel_countryid.Id.toUpperCase() + '}',//result.etel_countryid.Id,
                        name: result.etel_countryid.Name,
                        entityType: result.etel_countryid.LogicalName
                    }]);

                    //Xrm.Page.getAttribute("etel_cityid").setValue([{
                    //    id: result.etel_cityid.Id,
                    //    name: result.etel_cityid.Name,
                    //    entityType: result.etel_cityid.LogicalName
                    //}]);
                    //Added by Tanushri
                    Xrm.Page.getAttribute("amxperu_department").setValue([{
                        id: '{' + result.amxperu_department.Id.toUpperCase() + '}',
                        name: result.amxperu_department.Name,
                        entityType: result.amxperu_department.LogicalName
                    }]);
                    Xrm.Page.getAttribute("amxperu_province").setValue([{
                        id: '{' + result.amxperu_province.Id.toUpperCase() + '}',
                        name: result.amxperu_province.Name,
                        entityType: result.amxperu_province.LogicalName
                    }]);
                    Xrm.Page.getAttribute("amxperu_district").setValue([{
                        id: '{' + result.amxperu_district.Id.toUpperCase() + '}',
                        name: result.amxperu_district.Name,
                        entityType: result.amxperu_district.LogicalName
                    }]);
                    Xrm.Page.getAttribute("amxperu_buildtype").setValue(result.amxperu_buildtype.Value);
                    Xrm.Page.getAttribute("amxperu_building").setValue(result.amxperu_building.Value);
                    Xrm.Page.getAttribute("amxperu_populationzone").setValue(result.amxperu_populationzone.Value);
                    Xrm.Page.getAttribute("amxperu_blockedifice").setValue(result.amxperu_blockedifice.Value);
                    Xrm.Page.getAttribute("amxperu_apartmenttypeinterior").setValue(result.amxperu_apartmenttypeinterior.Value);
                    Xrm.Page.getAttribute("amxperu_zonetype").setValue(result.amxperu_zonetype.Value);
                    Xrm.Page.getAttribute("amxperu_urbanizationtype").setValue(result.amxperu_urbanizationtype.Value);
                    Xrm.Page.getAttribute("amxperu_longitude").setValue(result.amxperu_longitude);
                    Xrm.Page.getAttribute("amxperu_latitude").setValue(result.amxperu_latitude);
                    Xrm.Page.getAttribute("amxperu_number").setValue(result.amxperu_number);
                    Xrm.Page.getAttribute("amxperu_ubigeo").setValue(result.amxperu_ubigeo);
                    Xrm.Page.getAttribute("amxperu_referencedescription").setValue(result.amxperu_referencedescription);
                    Xrm.Page.getAttribute("amxperu_square").setValue(result.amxperu_square);
                    Xrm.Page.getAttribute("amxperu_allotment").setValue(result.amxperu_allotment);
                    Xrm.Page.getAttribute("amxperu_grouping").setValue(result.amxperu_grouping);
                    Xrm.Page.getAttribute("amxperu_normalized").setValue(result.amxperu_normalized);
                    Xrm.Page.getAttribute("amxperu_billingemail").setValue(result.amxperu_billingemail);
                    Xrm.Page.getAttribute("amxperu_street1").setValue(result.amxperu_street1.Value);
                    //END
                }
            }
            else {
                alert(translationScope_js_BI_CustomerAddress.data.tError + status + ': ' + translationScope_js_BI_CustomerAddress.data.tCustomerAddressNotFoundMessage);
            }
        }
        var entityType = Xrm.Page.data.entity.getEntityName();
        if (entityType === "etel_customeraddressbusinessinteraction") {
            if (individualCustomer != null || corporateCustomer != null) {
                Xrm.Page.getAttribute("etel_name").setValue(Xrm.Page.getAttribute("etel_binumber").getValue() + ' - ' + translationScope_js_BI_CustomerAddress.data.tNameFieldSuffix);
            }
        }
        Xrm.Page.data.entity.save('save');
        if (Xrm.Page.ui.getFormType() == 1) {
            //Xrm.Page.getAttribute("etel_street1").setRequiredLevel("required");
            //Xrm.Page.getAttribute("etel_countryid").setRequiredLevel("required");
            //Xrm.Page.getAttribute("etel_cityid").setRequiredLevel("required");
        }
    }
}
function popupCustomerAddressCreateForm(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName) {

    translationScope_js_BI_CustomerAddress.GetData();
    customer.GetCustomer();
    settings.Initialise();
    var headercheck = false;
    headercheck = headerCheck(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName);

    if (headercheck) {
        biSecurityCreateAddress.Validate();

        if (biSecurityCreateAddress.IsValidated === true) {
            createAddressSecurityRoleCheck.ValidateRole();
            if (createAddressSecurityRoleCheck.IsValidatedRole === true) {
                biAutoNumberCustomerAddress.CreateBINumber();
                if (biAutoNumberCustomerAddress.IsCreated === true) {
                    var paramaters = {};
                    paramaters["etel_businessinteraction"] = 0;
                    paramaters["_CreateFromId"] = selectedEntityId;
                    paramaters["_CreateFromType"] = selectedEntityCode;

                    if (biAutoNumberCustomerAddress.BINumber != null) {
                        paramaters["etel_binumber"] = biAutoNumberCustomerAddress.BINumber;
                        paramaters["etel_name"] = biAutoNumberCustomerAddress.BINumber + ' - ' + translationScope_js_BI_CustomerAddress.data.tNameFieldSuffix;
                    }
                    var windowOptions = {
                        openInNewWindow: false
                    };
                    Xrm.Utility.openEntityForm("etel_customeraddressbusinessinteraction", null, paramaters, windowOptions);
                }
            }
            else {
                alert(translationScope_js_BI_CustomerAddress.data.tValidationRoleCheckMessage);
            }
        }
        else {
            alert(translationScope_js_BI_CustomerAddress.data.tValidationCheckMessage);
        }
    }
}
function popupCustomerAddressUpdateForm(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName) {
    var formId = Xrm.Page.ui.formSelector.getCurrentItem().getId();
    translationScope_js_BI_CustomerAddress.GetData();
    customer.GetCustomer();
    settings.Initialise();

    var installationAddress;
    var corporateType;
    var corporateId;
    var corporateName;

    var individualType;
    var individualId;
    var individualName;

    var selectedName = "";

    var selectedEntityId = null;
    var selectedEntityCode = null;
    var selectedEntityName = null;

    this.SelectedAddressId = false;

    if (formId === CrmFormId.CorporateCustomer360FormId || formId === CrmFormId.IndividualCustomer360FormId) {
        var addresslist = Xrm.Page.ui.controls.get("WebResource_accountsummarytabbedview").getObject().contentWindow.angular.element(".main-container").scope().CustomerAddressScopeSelectedItems;

        if (addresslist == undefined || addresslist.length == 0) {
            alert(translationScope_js_BI_CustomerAddress.data.tCustomerAddressSelect);
            return;
        }

        this.SelectedAddressId = addresslist[0][0].RowData.CustomerAddressId;
    }
    else {

        var addressgrid = Xrm.Page.getControl("Addreses");
        if (addressgrid == null) {
            addressgrid = Xrm.Page.getControl("addresses");
        }

        if ((addressgrid) &&
            (addressgrid.getGrid()) &&
            (addressgrid.getGrid().getSelectedRows()) &&
            (addressgrid.getGrid().getSelectedRows().get(0)) &&
            (addressgrid.getGrid().getSelectedRows().get(0).getData()) &&
            (addressgrid.getGrid().getSelectedRows().get(0).getData().getEntity()) &&
            (addressgrid.getGrid().getSelectedRows().get(0).getData().getEntity().getId())) {
            this.SelectedAddressId = addressgrid.getGrid().getSelectedRows().get(0).getData().getEntity().getId();
        }
        if (this.SelectedAddressId) {
            this.SelectedAddressId = this.SelectedAddressId.substr(1, this.SelectedAddressId.length - 2);
        }
    }

    if (this.SelectedAddressId) {
            //Added by tanushri
            debugger;
            var columnsInstallation = ['etel_name', 'amxperu_isinstallation'];
            var filterInstallation = "etel_customeraddressId eq guid'" + this.SelectedAddressId + "'";
            CrmRestKit.ByQuery("etel_customeraddress", columnsInstallation, filterInstallation, false).fail(function (xhr, status, ethrow) {
                alert(translationScope_js_BI_CustomerAddress.data.tCustomerAddressNotFoundMessage);
            }).done(function (collectionAddress) {
                if (collectionAddress.d != null && collectionAddress.d.results != null && collectionAddress.d.results.length > 0) {
                    installationAddress = collectionAddress.d.results[0].amxperu_isinstallation;
                    selectedName = collectionAddress.d.results[0].etel_name;
                }
            });
            if (installationAddress != null && installationAddress == false) {
                //end
                var columns = ['etel_name', 'etel_corporatecustomerid', 'etel_individualcustomerid'];
                var filter = "etel_customeraddressId eq guid'" + this.SelectedAddressId + "'";

                CrmRestKit.ByQuery("etel_customeraddress", columns, filter, false).fail(function (xhr, status, ethrow) {
                    alert(translationScope_js_BI_CustomerAddress.data.tError + status + ': ' + translationScope_js_BI_CustomerAddress.data.tCustomerAddressNotFoundMessage);
                }).done(function (collection) {
                    if (collection.d != null && collection.d.results != null && collection.d.results.length > 0) {
                        corporateType = collection.d.results[0].etel_corporatecustomerid.LogicalName;
                        corporateId = collection.d.results[0].etel_corporatecustomerid.Id;
                        corporateName = collection.d.results[0].etel_corporatecustomerid.Name;

                        individualType = collection.d.results[0].etel_individualcustomerid.LogicalName;
                        individualId = collection.d.results[0].etel_individualcustomerid.Id;
                        individualName = collection.d.results[0].etel_individualcustomerid.Name;

                        selectedName = collection.d.results[0].etel_name;
                    }
                });
                var paramaters = {};
                paramaters["etel_customeraddress"] = this.SelectedAddressId;
                paramaters["etel_customeraddressname"] = selectedName;

                if (corporateId != null) {
                    paramaters["etel_corporatecustomer"] = corporateId;
                    paramaters["etel_corporatecustomername"] = corporateName;
                    selectedEntityId = corporateId;
                    selectedEntityCode = "1";
                    selectedEntityName = corporateType;
                }

                if (individualId != null) {
                    paramaters["etel_individualcustomer"] = individualId;
                    paramaters["etel_individualcustomername"] = individualName;
                    selectedEntityId = individualId;
                    selectedEntityCode = "2";
                    selectedEntityName = individualType;
                }

                var headercheck = false;
                headercheck = headerCheck(entitytypecode, selectedEntityId, selectedEntityCode, selectedEntityName);

                if (headercheck) {
                    biSecurityUpd.Validate();
                    if (biSecurityUpd.IsValidated === true) {
                        modifyAddressSecurityRoleCheck.ValidateRole();
                        if (modifyAddressSecurityRoleCheck.IsValidatedRole === true) {

                            biAutoNumberCustomerAddress.CreateBINumber();
                            if (biAutoNumberCustomerAddress.IsCreated === true) {
                                if (biAutoNumberCustomerAddress.BINumber != null) {
                                    paramaters["etel_binumber"] = biAutoNumberCustomerAddress.BINumber;
                                    paramaters["etel_name"] = selectedName;
                                }
                                var windowOptions = {
                                    openInNewWindow: false
                                };
                                Xrm.Utility.openEntityForm("etel_bi_customeraddressmodification", null, paramaters, windowOptions);
                            }
                        } else {
                            alert(translationScope_js_BI_CustomerAddress.data.tValidationRoleCheckMessage);
                        }
                    } else {
                        alert(translationScope_js_BI_CustomerAddress.data.tValidationCheckMessage);
                    }
                } else {
                    Xrm.Page.ui.setFormNotification(
                        translationScope_js_BI_CustomerAddress.data.tBIHeaderRequired, translationScope_js_BI_CustomerAddress.data.tWarning, translationScope_js_BI_CustomerAddress.data.tFormNotification);
                }
            }
            else {
                Xrm.Page.ui.setFormNotification(
                    translationScope_js_BI_CustomerAddress.data.tInstallationAddressUpdateNotAllowed, translationScope_js_BI_CustomerAddress.data.tWarning, translationScope_js_BI_CustomerAddress.data.tFormNotification);
            }
        }
        else {
            Xrm.Page.ui.setFormNotification(
                translationScope_js_BI_CustomerAddress.data.tCustomerAddressSelect, translationScope_js_BI_CustomerAddress.data.tWarning, translationScope_js_BI_CustomerAddress.data.tFormNotification);
        }    
}
function executeSubmit() {
    debugger;
    //Xrm.Page.data.save().then(executeSubmitSuccessfulCallback, executeSubmitErrorCallback);
    Xrm.Page.data.save().then(executeSubmitSuccessCallBack, executeSubmitErrorCallback);

}
function executeSubmitSuccessCallBack() {
    debugger;
    translationScope_js_BI_CustomerAddress.GetData();
    ValidateAddressBlacklist();
    var lifecyclestatus = Xrm.Page.getAttribute("etel_lifecyclestatus");
    lifecyclestatus.setValue(831260001);
    lifecyclestatus.setSubmitMode('always');
    var AddressName = Xrm.Page.getAttribute("etel_name").getValue();
    Xrm.Page.getAttribute("etel_name").setValue(AddressName);
    var etelSubmitStatus = Xrm.Page.getAttribute("etel_submit");
    etelSubmitStatus.setSubmitMode('always');
    Xrm.Page.getAttribute("etel_submit").setValue(true);
    Xrm.Page.data.entity.save();
    alert(translationScope_js_BI_CustomerAddress.data.tSubmittedSuccessfullyMessage);
    Xrm.Page.ui.close();
}
function executeSubmitErrorCallback(errorCode, errorLocalized) {
    translationScope_js_BI_CustomerAddress.GetData();
    alert(translationScope_js_BI_CustomerAddress.data.tBiNotSaved);
}
function executeSubmitSuccessfulCallback() {
    translationScope_js_BI_CustomerAddress.GetData();

    if (!validatePostalCode()) {
        return;
    }

    if (!customerAddressBIValidations.ExecuteValidations()) {
        alert(translationScope_js_BI_CustomerAddress.data.tValidEmailMessage);
        return;
    }

    if (!isPageReadyToSave()) {
        //CRM will throw message
        return;
    }

    customer.GetCustomer();

    var CustomerId = customer.Id;
    var CustomerType = customer.LogicalName;

    var AddressType = Xrm.Page.getAttribute("etel_customeraddresstypecode").getValue();
    var Street1 = Xrm.Page.getAttribute("etel_street1").getValue();
    var Street2 = Xrm.Page.getAttribute("etel_street2").getValue();
    var Street3 = Xrm.Page.getAttribute("etel_street3").getValue();

    var AddressName = Xrm.Page.getAttribute("etel_name").getValue();
    var PostalCode = Xrm.Page.getAttribute("etel_postalcode").getValue();

    var CountryField = Xrm.Page.getAttribute("etel_countryid").getValue();
    var Country = null;

    if (CountryField) {
        Country = CountryField[0].id;
    }

    var CityField = Xrm.Page.getAttribute("etel_cityid").getValue();
    var City = null;

    if (CityField) {
        City = CityField[0].id;
    }

    var IndividualCustomerField = Xrm.Page.getAttribute("etel_individualcustomer").getValue();
    var IndividualCustomer = null;

    if (IndividualCustomerField) {
        IndividualCustomer = IndividualCustomerField[0].id;
    }

    var CorporateCustomerField = Xrm.Page.getAttribute("etel_corporatecustomer").getValue();
    var CorporateCustomer = null;

    if (CorporateCustomerField) {
        CorporateCustomer = CorporateCustomerField[0].id;
    }

    var email = Xrm.Page.getAttribute("etel_emailaddress").getValue();
    if (email !== null) {
        Email = email;
    }
    else {
        Email = "";
    }

    var Fax = Xrm.Page.getAttribute("etel_fax").getValue();
    var MainPhone = Xrm.Page.getAttribute("etel_telephone1").getValue();
    var Phone2 = Xrm.Page.getAttribute("etel_telephone2").getValue();
    var lifecyclestatus = Xrm.Page.getAttribute("etel_lifecyclestatus");
    var submitCheck = Xrm.Page.getAttribute("etel_submit");
    var selectedAddressId = Xrm.Page.getAttribute("etel_customeraddress");

    var executionResult;
    var executionMessage;

    if (selectedAddressId.getValue()) {
        var selectedAddress = selectedAddressId.getValue()[0].id;
        var request = new PrepareRequest(new CustomerAddressModificationRequest(CustomerType, selectedAddress, AddressType, Street1, Street2, Street3, IndividualCustomer, AddressName, PostalCode, Country, City, CorporateCustomer, Email, Fax, MainPhone, Phone2, IsPrimaryAddress));
        retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
            executionResult = data.Success;
            executionMessage = data.ErrorMessage;
        });
    }
    else {
        var request = new PrepareRequest(new CustomerAddressCreateRequest(CustomerType, AddressType, Street1, Street2, Street3, IndividualCustomer, AddressName, PostalCode, Country, City, CorporateCustomer, Email, Fax, MainPhone, Phone2));
        retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
            executionResult = data.Success;
            executionMessage = data.ErrorMessage;
        });
    }

    if (executionMessage === "postalCodeValidation") {
        alert(translationScope_js_BI_CustomerAddress.data.tPostalCodeNotValid);
    }
    else {
        if (executionResult === true) {
            lifecyclestatus.setValue(831260001);
            alert(translationScope_js_BI_CustomerAddress.data.tSubmittedSuccessfullyMessage);
        }
        else {

            lifecyclestatus.setValue(831260002);
            if (executionMessage != null)
                alert(executionMessage);
            alert(translationScope_js_BI_CustomerAddress.data.tSubmittedErrorMessage);
        }

        submitCheck.setValue(true);
        submitCheck.setSubmitMode('always');
        lifecyclestatus.setSubmitMode('always');
        Xrm.Page.data.entity.save('saveandclose');
    }
}
function toGuid(stringWithCurlyBraces) {
    return stringWithCurlyBraces.substring(1).substring(0, 36);
}
function executeSubmitUpdateForm() {
    debugger;
    translationScope_js_BI_CustomerAddress.GetData();    

    Xrm.Page.data.entity.save('save');    

    var customerAddressUpdateRequest = {
        "CustomerAddressRequest": {
            "$type": "AmxPeruPSBActivities.Model.AmxPeruCustomerAddressUpdateRequest, AmxPeruPSBActivities",            
        }
    };

    if (!customerAddressBIValidations.ExecuteValidations()) {
        alert(translationScope_js_BI_CustomerAddress.data.tValidEmailMessage);
        return;
    }

    if (!isPageReadyToSave()) {
        return;
    }
    customer.GetCustomer();

    var CustomerId = customer.Id;
    var CustomerType = customer.LogicalName;

    var AddressType = Xrm.Page.getAttribute("etel_customeraddresstypecode").getValue();

    //var Street1 = Xrm.Page.getAttribute("etel_street1").getValue();

    var Street2 = Xrm.Page.getAttribute("etel_street2").getValue();
    customerAddressUpdateRequest.CustomerAddressRequest.Street2 = Xrm.Page.getAttribute("etel_street2").getValue();

    var Street3 = Xrm.Page.getAttribute("etel_street3").getValue();
    customerAddressUpdateRequest.CustomerAddressRequest.Street3 = Xrm.Page.getAttribute("etel_street3").getValue();

    var AddressName = Xrm.Page.getAttribute("etel_name").getValue();
    customerAddressUpdateRequest.CustomerAddressRequest.AddressName = Xrm.Page.getAttribute("etel_name").getValue();

    var PostalCode = Xrm.Page.getAttribute("etel_postalcode").getValue();
    customerAddressUpdateRequest.CustomerAddressRequest.PostalCode = Xrm.Page.getAttribute("etel_postalcode").getValue();

    var CountryField = Xrm.Page.getAttribute("etel_countryid").getValue();
    var Country = null;

    if (CountryField) {
        Country = CountryField[0].id;
        customerAddressUpdateRequest.CustomerAddressRequest.Country = toGuid(CountryField[0].id);
    }

    var IndividualCustomerField = Xrm.Page.getAttribute("etel_individualcustomer").getValue();
    var IndividualCustomer = null;

    if (IndividualCustomerField) {
        IndividualCustomer = IndividualCustomerField[0].id;
        customerAddressUpdateRequest.CustomerAddressRequest.IndividualCustomerId = toGuid(IndividualCustomerField[0].id);
    }

    var CorporateCustomerField = Xrm.Page.getAttribute("etel_corporatecustomer").getValue();
    var CorporateCustomer = null;

    if (CorporateCustomerField) {
        CorporateCustomer = CorporateCustomerField[0].id;
        customerAddressUpdateRequest.CustomerAddressRequest.CorporateCustomerId = toGuid(CorporateCustomerField[0].id);
    }

    var email = Xrm.Page.getAttribute("etel_emailaddress").getValue();
    if (email !== null) {
        Email = email;
        customerAddressUpdateRequest.CustomerAddressRequest.Email = email;
    }
    else {
        Email = "";
        customerAddressUpdateRequest.CustomerAddressRequest.Email = "";
    }

    var Fax = Xrm.Page.getAttribute("etel_fax").getValue();
    customerAddressUpdateRequest.CustomerAddressRequest.Fax = Xrm.Page.getAttribute("etel_fax").getValue();

    var MainPhone = Xrm.Page.getAttribute("etel_telephone1").getValue();
    customerAddressUpdateRequest.CustomerAddressRequest.MainPhone = Xrm.Page.getAttribute("etel_telephone1").getValue();

    var Phone2 = Xrm.Page.getAttribute("etel_telephone2").getValue();
    customerAddressUpdateRequest.CustomerAddressRequest.Phone2 = Xrm.Page.getAttribute("etel_telephone2").getValue();

    var lifecyclestatus = Xrm.Page.getAttribute("etel_lifecyclestatus");
    var submitCheck = Xrm.Page.getAttribute("etel_submit");

    var selectedAddressField = Xrm.Page.getAttribute("etel_customeraddress").getValue();
    var SelectedAddress;
    if (selectedAddressField) {
        SelectedAddress = selectedAddressField[0].id;
        customerAddressUpdateRequest.CustomerAddressRequest.CustomerAddressId = toGuid(selectedAddressField[0].id);
    }

    var IsPrimaryAddress = Xrm.Page.getAttribute("etel_isprimaryaddress").getValue();
    customerAddressUpdateRequest.CustomerAddressRequest.IsPrimaryAddress = Xrm.Page.getAttribute("etel_isprimaryaddress").getValue();


    var DepartmentField = Xrm.Page.getAttribute("amxperu_department").getValue();
    var Department = null;

    if (DepartmentField) {
        Department = DepartmentField[0].id;
        customerAddressUpdateRequest.CustomerAddressRequest.Department = toGuid(DepartmentField[0].id);
    }

    var ProvinceField = Xrm.Page.getAttribute("amxperu_province").getValue();
    var Province = null;

    if (ProvinceField) {
        Province = ProvinceField[0].id;
        customerAddressUpdateRequest.CustomerAddressRequest.Province = toGuid(ProvinceField[0].id);
    }


    var DistrictField = Xrm.Page.getAttribute("amxperu_district").getValue();
    var District = null;

    if (DistrictField) {
        District = DistrictField[0].id;
        customerAddressUpdateRequest.CustomerAddressRequest.District = toGuid(DistrictField[0].id);
    }

    if (Xrm.Page.getAttribute("amxperu_buildtype").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.BuildType = Xrm.Page.getAttribute("amxperu_buildtype").getValue();
    if (Xrm.Page.getAttribute("amxperu_building").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.Building = Xrm.Page.getAttribute("amxperu_building").getValue();
    if (Xrm.Page.getAttribute("amxperu_populationzone").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.PopulationZone = Xrm.Page.getAttribute("amxperu_populationzone").getValue();
    if (Xrm.Page.getAttribute("amxperu_blockedifice").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.Blockediffice = Xrm.Page.getAttribute("amxperu_blockedifice").getValue();
    if (Xrm.Page.getAttribute("amxperu_apartmenttypeinterior").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.ApartmentTypeInterior = Xrm.Page.getAttribute("amxperu_apartmenttypeinterior").getValue();
    if (Xrm.Page.getAttribute("amxperu_zonetype").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.ZoneType = Xrm.Page.getAttribute("amxperu_zonetype").getValue();
    if (Xrm.Page.getAttribute("amxperu_urbanizationtype").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.UrbanizationType = Xrm.Page.getAttribute("amxperu_urbanizationtype").getValue();
    if (Xrm.Page.getAttribute("amxperu_longitude").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.Longitude = Xrm.Page.getAttribute("amxperu_longitude").getValue();
    if (Xrm.Page.getAttribute("amxperu_latitude").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.Latitude = Xrm.Page.getAttribute("amxperu_latitude").getValue();
    if (Xrm.Page.getAttribute("amxperu_number").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.Number = Xrm.Page.getAttribute("amxperu_number").getValue();
    if (Xrm.Page.getAttribute("amxperu_ubigeo").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.Ubigeo = Xrm.Page.getAttribute("amxperu_ubigeo").getValue();
    if (Xrm.Page.getAttribute("amxperu_referencedescription").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.ReferenceDescription = Xrm.Page.getAttribute("amxperu_referencedescription").getValue();
    if (Xrm.Page.getAttribute("amxperu_square").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.Square = Xrm.Page.getAttribute("amxperu_square").getValue();
    if (Xrm.Page.getAttribute("amxperu_allotment").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.Allotment = Xrm.Page.getAttribute("amxperu_allotment").getValue();
    if (Xrm.Page.getAttribute("amxperu_grouping").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.Grouping = Xrm.Page.getAttribute("amxperu_grouping").getValue();
    if (Xrm.Page.getAttribute("amxperu_normalized").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.Normalized = Xrm.Page.getAttribute("amxperu_normalized").getValue();
    if (Xrm.Page.getAttribute("amxperu_billingemail").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.BillingEmail = Xrm.Page.getAttribute("amxperu_billingemail").getValue();
    if (Xrm.Page.getAttribute("amxperu_street1").getValue())
        customerAddressUpdateRequest.CustomerAddressRequest.Street1 = Xrm.Page.getAttribute("amxperu_street1").getValue();

    var executionResult;
    var executionMessage;


    jQuery.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(customerAddressUpdateRequest),
        async: false,
        cache: false,
        url: "http://10.103.27.154:6004/api/v1/workflow/AmxPeruModifyCustomerAddress",
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

    

    //if (selectedAddressId.getValue()) {
    //    var selectedAddress = selectedAddressId.getValue()[0].id;
    //    var request = new PrepareRequest(new CustomerAddressModificationRequest(CustomerType, selectedAddress, AddressType, Street1, Street2, Street3, IndividualCustomer, AddressName, PostalCode, Country, City, CorporateCustomer, Email, Fax, MainPhone, Phone2, IsPrimaryAddress));
    //    retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
    //        executionResult = data.Success;
    //        executionMessage = data.ErrorMessage;
    //    });
    //}

    if (executionMessage === "postalCodeValidation") {
        alert("Postal code is not valid");
    }
    else {

        if (executionResult === true) {
            lifecyclestatus.setValue(831260001);
            alert(translationScope_js_BI_CustomerAddress.data.tSubmittedSuccessfullyMessage);
        }
        else {
            lifecyclestatus.setValue(831260002);
            if (executionMessage != null)
                alert(executionMessage);
            alert(translationScope_js_BI_CustomerAddress.data.tSubmittedErrorMessage);
        }

        submitCheck.setValue(true);
        submitCheck.setSubmitMode('always');
        lifecyclestatus.setSubmitMode('always');
        Xrm.Page.data.entity.save('saveandclose');
    }


    debugger;
    translationScope_js_BI_CustomerAddress.GetData();
    var lifecyclestatus = Xrm.Page.getAttribute("etel_lifecyclestatus");
    lifecyclestatus.setValue(831260001);
    lifecyclestatus.setSubmitMode('always');
    var etelSubmitStatus = Xrm.Page.getAttribute("etel_submit");
    etelSubmitStatus.setSubmitMode('always');
    Xrm.Page.getAttribute("etel_submit").setValue(true);
    Xrm.Page.data.entity.save();
    alert(translationScope_js_BI_CustomerAddress.data.tSubmittedSuccessfullyMessage);
    Xrm.Page.ui.close();
}
function cleanCityFieldOnCountryChange() {
    translationScope_js_BI_CustomerAddress.GetData();
    if (Xrm.Page.getAttribute("etel_countryid") !== null) {
        var city = Xrm.Page.data.entity.attributes.get("etel_cityid");
        city.setValue(null);
    }
}
function IsCreateAddressButtonEnabled() {
    settings.Initialise();
    var retVal = true;

    createAddressSecurityRoleCheck.ValidateRole();
    retVal = !!createAddressSecurityRoleCheck.IsValidatedRole;

    return retVal;
}
function IsModifyAddressButtonEnabled() {
    settings.Initialise();
    var retVal = true;
    modifyAddressSecurityRoleCheck.ValidateRole();
    retVal = !!modifyAddressSecurityRoleCheck.IsValidatedRole;
    return retVal;
}

//Added by Tanushri
function fieldRequiredonAddressType() {
    if (Xrm.Page.getAttribute("etel_customeraddresstypecode").getValue() != null) {
        var AddressType = Xrm.Page.getAttribute("etel_customeraddresstypecode").getValue();
        if (AddressType == 1) {
            Xrm.Page.getAttribute("amxperu_street1").setRequiredLevel("required");
            Xrm.Page.getAttribute("amxperu_department").setRequiredLevel("required");
            Xrm.Page.getAttribute("amxperu_province").setRequiredLevel("required");
            Xrm.Page.getAttribute("amxperu_district").setRequiredLevel("required");
            Xrm.Page.getAttribute("etel_street2").setRequiredLevel("required");
            Xrm.Page.getAttribute("etel_street3").setRequiredLevel("required");
            Xrm.Page.getAttribute("etel_countryid").setRequiredLevel("required");
            Xrm.Page.getAttribute("amxperu_populationzone").setRequiredLevel("none");
        }
        else if (AddressType == 2) {
            Xrm.Page.getAttribute("amxperu_populationzone").setRequiredLevel("required");
            Xrm.Page.getAttribute("amxperu_street1").setRequiredLevel("none");
            Xrm.Page.getAttribute("amxperu_department").setRequiredLevel("none");
            Xrm.Page.getAttribute("amxperu_province").setRequiredLevel("none");
            Xrm.Page.getAttribute("amxperu_district").setRequiredLevel("none");
            Xrm.Page.getAttribute("etel_street2").setRequiredLevel("none");
            Xrm.Page.getAttribute("etel_street3").setRequiredLevel("none");
            Xrm.Page.getAttribute("etel_countryid").setRequiredLevel("none");
        }
    }
}
function validatePostalCode() {
    translationScope_js_BI_CustomerAddress.GetData();    
    var postalcode = Xrm.Page.getAttribute("etel_postalcode").getValue();
    if (postalcode != null) {
        if (isNaN(postalcode)) {
            alert(translationScope_js_BI_CustomerAddress.data.tPostalCodeNumeric);
            Xrm.Page.getAttribute("etel_postalcode").setValue("");
        }
    }
}
function filterDepartment(controlName) {
    debugger;
    var CountryName, CountryId;
    var country = Xrm.Page.getAttribute("etel_countryid");
    if (country != null) {
        var countryLookup = country.getValue();
        if (countryLookup != null) {
            CountryId = countryLookup[0].id;
            CountryName = countryLookup[0].name;
        }
    }
    if (CountryId != null) {
        var viewId = "{0CBC820C-7033-4AFF-9CE8-FB610464DAD3}";
        var entityName = "amxperu_department";
        var viewDisplayName = "Department Lookup View";
        var fetchDepartment = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
            + "<entity name='amxperu_department'>"
            + "<attribute name='amxperu_departmentid'/>"
            + "<attribute name='amxperu_name'/>"
            + "<order descending='false' attribute='amxperu_name'/>"
            + "<filter type='and'>"
            + "<condition attribute='amxperu_country' value='" + CountryId + "' operator='eq'/>"
            + "</filter>"
            + "</entity>"
            + "</fetch>";
        var layoutXml = "<grid name='resultset' object='1' jump='amxperu_name' select='1' icon='1' preview='1'>" +
            "<row name='result' id='amxperu_departmentid'>" +
            "<cell name='amxperu_name' width='150' />" +
            "<cell name='createdon' width='150' />" +
            "</row>" +
            "</grid>";
        Xrm.Page.getControl(controlName).addCustomView(viewId, entityName, viewDisplayName, fetchDepartment, layoutXml, true);
    }
}
function filterProvince(controlName) {
    var departmentName, departmentId;
    var department = Xrm.Page.getAttribute("amxperu_department");
    if (department != null) {
        var departmentLookup = department.getValue();
        if (departmentLookup != null) {
            departmentId = departmentLookup[0].id;
            departmentName = departmentLookup[0].name;
        }
    }
    if (departmentId != null) {
        var viewId = "{0CBC820C-7033-4AFF-9CE8-FB610464DAD3}";
        var entityName = "amxperu_province";
        var viewDisplayName = "Province Lookup View";
        var fetchProvince = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
            + "<entity name='amxperu_province'>"
            + "<attribute name='amxperu_provinceid'/>"
            + "<attribute name='amxperu_name'/>"
            + "<order descending='false' attribute='amxperu_name'/>"
            + "<filter type='and'>"
            + "<condition attribute='amxperu_department' value='" + departmentId + "' operator='eq'/>"
            + "</filter>"
            + "</entity>"
            + "</fetch>";
        var layoutXml = "<grid name='resultset' object='1' jump='amxperu_name' select='1' icon='1' preview='1'>" +
            "<row name='result' id='amxperu_provinceid'>" +
            "<cell name='amxperu_name' width='150' />" +
            "<cell name='createdon' width='150' />" +
            "</row>" +
            "</grid>";
        Xrm.Page.getControl(controlName).addCustomView(viewId, entityName, viewDisplayName, fetchProvince, layoutXml, true);
    }
}
function filterDistrict(controlName) {
    var provinceName, provinceId;
    var province = Xrm.Page.getAttribute("amxperu_province");
    if (province != null) {
        var provinceLookup = province.getValue();
        if (provinceLookup != null) {
            provinceId = provinceLookup[0].id;
            provinceName = provinceLookup[0].name;
        }
    }
    if (provinceId != null) {
        var viewId = "{0CBC820C-7033-4AFF-9CE8-FB610464DBD3}";
        var entityName = "amxperu_district";
        var viewDisplayName = "District Lookup View";
        var fetchDistrict = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
            + "<entity name='amxperu_district'>"
            + "<attribute name='amxperu_districtid'/>"
            + "<attribute name='amxperu_name'/>"
            + "<order descending='false' attribute='amxperu_name'/>"
            + "<filter type='and'>"
            + "<condition attribute='amxperu_province' value='" + provinceId + "' operator='eq'/>"
            + "</filter>"
            + "</entity>"
            + "</fetch>";
        var layoutXml = "<grid name='resultset' object='1' jump='amxperu_name' select='1' icon='1' preview='1'>" +
            "<row name='result' id='amxperu_districtid'>" +
            "<cell name='amxperu_name' width='150' />" +
            "<cell name='createdon' width='150' />" +
            "</row>" +
            "</grid>";
        Xrm.Page.getControl(controlName).addCustomView(viewId, entityName, viewDisplayName, fetchDistrict, layoutXml, true);
    }
}
function SetLookupNull(lookupAttribute) {
    var lookupObject = Xrm.Page.getAttribute(lookupAttribute);
    if (lookupObject != null) {
        Xrm.Page.getAttribute(lookupAttribute).setValue(null);
    }
}
function OnChangeLookupDepartmentProvince(executionContext) {
    var attributeName = executionContext.getEventSource().getName();
    if (attributeName == "etel_countryid") {
        SetLookupNull("amxperu_department");
        SetLookupNull("amxperu_province");
        SetLookupNull("amxperu_district");
    }
    else if (attributeName == "amxperu_department") {
        SetLookupNull("amxperu_province");
        SetLookupNull("amxperu_district");
    }
    else if (attributeName == "amxperu_province") {
        SetLookupNull("amxperu_district");
    }
}
function EventsOnFormLoad() {
    debugger;
    var defaultCountryID;
    var fetchCountryGuid = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
        + "<entity name='amxperu_amxconfigurations'>"
        + "<attribute name='amxperu_amxconfigurationsid'/>"
        + "<attribute name='amxperu_name'/>"
        + "<attribute name='amxperu_value'/>"
        + "<order descending='false' attribute='amxperu_name'/>"
        + "<filter type='and'>"
        + "<condition attribute='amxperu_name' value='DefaultCountryforAddress' operator='eq'/>"
        + "</filter></entity></fetch>";
    var fetchResult = XrmServiceToolkit.Soap.Fetch(fetchCountryGuid);
    if (fetchResult.length > 0) {
        if (fetchResult[0].attributes.amxperu_value != null) {
            defaultCountryID = fetchResult[0].attributes.amxperu_value.value;
        }
    }
    if (defaultCountryID != null) {
        Xrm.Page.getAttribute("etel_countryid").setValue([{
            id: defaultCountryID,
            name: "Peru",
            entityType: "etel_country"
        }]);
    }
    addPreSearchOnLookup("amxperu_department");
    addPreSearchOnLookup("amxperu_province");
    addPreSearchOnLookup("amxperu_district");
    Xrm.Page.getAttribute("amxperu_department").addOnChange(OnChangeLookupDepartmentProvince);
    Xrm.Page.getAttribute("amxperu_province").addOnChange(OnChangeLookupDepartmentProvince);
    Xrm.Page.getAttribute("amxperu_department").addOnChange(OnChangeLookupDepartmentProvince);
    Xrm.Page.getControl("amxperu_department").addPreSearch(function () { filterDepartment("amxperu_department"); });
    Xrm.Page.getControl("amxperu_province").addPreSearch(function () { filterProvince("amxperu_province"); });
    Xrm.Page.getControl("amxperu_district").addPreSearch(function () { filterDistrict("amxperu_district"); });  
}
function EventsOnFormLoadModify() {
    addPreSearchOnLookup("amxperu_department");
    addPreSearchOnLookup("amxperu_province");
    addPreSearchOnLookup("amxperu_district");
    Xrm.Page.getAttribute("amxperu_department").addOnChange(OnChangeLookupDepartmentProvince);
    Xrm.Page.getAttribute("amxperu_province").addOnChange(OnChangeLookupDepartmentProvince);
    Xrm.Page.getAttribute("amxperu_department").addOnChange(OnChangeLookupDepartmentProvince);
    Xrm.Page.getControl("amxperu_department").addPreSearch(function () { filterDepartment("amxperu_department"); });
    Xrm.Page.getControl("amxperu_province").addPreSearch(function () { filterProvince("amxperu_province"); });
    Xrm.Page.getControl("amxperu_district").addPreSearch(function () { filterDistrict("amxperu_district"); });
}
function addPreSearchOnLookup(fieldName) {

    if (Xrm.Page.getControl(fieldName)) {
        Xrm.Page.getControl(fieldName)._control
            && Xrm.Page.getControl(fieldName)._control.tryCompleteOnDemandInitialization
            && Xrm.Page.getControl(fieldName)._control.tryCompleteOnDemandInitialization();

    }
}
function LookupEnableDisable() {
    var country = Xrm.Page.getAttribute("etel_countryid");
    if (country != null) {
        var countryLookup = country.getValue();
        if (countryLookup != null) {
            Xrm.Page.getControl("amxperu_department").setDisabled(false);
        }
        else {
            Xrm.Page.getControl("amxperu_department").setDisabled(true);
        }
    }

    var department = Xrm.Page.getAttribute("amxperu_department");
    if (department != null) {
        var departmentLookup = department.getValue();
        if (departmentLookup != null) {
            Xrm.Page.getControl("amxperu_province").setDisabled(false);
        }
        else {
            Xrm.Page.getControl("amxperu_province").setDisabled(true);
        }
    }

    var province = Xrm.Page.getAttribute("amxperu_province");
    if (province != null) {
        var provinceLookup = province.getValue();
        if (provinceLookup != null) {
            Xrm.Page.getControl("amxperu_district").setDisabled(false);
        }
        else {
            Xrm.Page.getControl("amxperu_district").setDisabled(true);
        }
    }
}
function onChangeCountry() {
    var country = Xrm.Page.getAttribute("etel_countryid");
    if (country != null) {
        var countryLookup = country.getValue();
        if (countryLookup != null) {
            Xrm.Page.getControl("amxperu_department").setDisabled(false);
        }
        else {
            Xrm.Page.getControl("amxperu_department").setDisabled(true);
        }
    }
}
function onChangeProvince() {
    var province = Xrm.Page.getAttribute("amxperu_province");
    if (province != null) {
        var provinceLookup = province.getValue();
        if (provinceLookup != null) {
            Xrm.Page.getControl("amxperu_district").setDisabled(false);
        }
        else {
            Xrm.Page.getControl("amxperu_district").setDisabled(true);
        }
    }
}
function onChangeDepartment() {
    var department = Xrm.Page.getAttribute("amxperu_department");
    if (department != null) {
        var departmentLookup = department.getValue();
        if (departmentLookup != null) {
            Xrm.Page.getControl("amxperu_province").setDisabled(false);
        }
        else {
            Xrm.Page.getControl("amxperu_province").setDisabled(true);
        }
    }
}
function retrieveUbigeoValue() {
    var CountryID, DepartmentID, ProvinceID, DistrictID, Ubigeo;
    var country = Xrm.Page.getAttribute("etel_countryid");
    var department = Xrm.Page.getAttribute("amxperu_department");
    var province = Xrm.Page.getAttribute("amxperu_province");
    var district = Xrm.Page.getAttribute("amxperu_district");
    if (country != null) {
        var countryLookup = country.getValue();
        if (countryLookup != null) {
            CountryID = countryLookup[0].id;
        }
    }
    if (department != null) {
        var departmentLookup = department.getValue();
        if (departmentLookup != null) {
            DepartmentID = departmentLookup[0].id;
        }
    }
    if (province != null) {
        var provinceLookup = province.getValue();
        if (provinceLookup != null) {
            ProvinceID = provinceLookup[0].id;
        }
    }
    if (district != null) {
        var districtLookup = district.getValue();
        if (districtLookup != null) {
            DistrictID = districtLookup[0].id;
        }
    }
    var fetchUbigeo = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
        + "<entity name='amxperu_addressconfiguration'>"
        + "<attribute name='amxperu_addressconfigurationid'/>"
        + "<attribute name='amxperu_name'/>"
        + "<order descending='false' attribute='amxperu_name'/>"
        + "<filter type='and'>"
        + "<filter type='and'>"
        + "<condition attribute='amxperu_country' value='" + CountryID + "' operator='eq'/>"
        + "<condition attribute='amxperu_department' value='" + DepartmentID + "' operator='eq'/>"
        + "<condition attribute='amxperu_province' value='" + ProvinceID + "' operator='eq'/>"
        + "<condition attribute='amxperu_district' value='" + DistrictID + "' operator='eq'/>"
        + "</filter></filter></entity></fetch>";
    var fetchResult = XrmServiceToolkit.Soap.Fetch(fetchUbigeo);
    if (fetchResult.length > 0) {
        if (fetchResult[0].attributes.amxperu_name != null) {
            Ubigeo = fetchResult[0].attributes.amxperu_name.value;

            if (Ubigeo != null) {
                Xrm.Page.getAttribute("amxperu_ubigeo").setValue(Ubigeo);
            }
            else {
                Xrm.Page.getAttribute("amxperu_ubigeo").setValue("");
            }
        }
    }
}
function OnPageLoad() {
    debugger;
    Xrm.Page.data.process.addOnStageSelected(stageSelectedandChangeEvent);
    Xrm.Page.data.process.addOnStageChange(stageSelectedandChangeEvent);
}
function stageSelectedandChangeEvent() {
    var stage = Xrm.Page.data.process.getSelectedStage();
    var stageName = stage.getName();
    if (stageName == "General") {
        Xrm.Page.ui.tabs.get("Address").setVisible(true);
    }
    else {
        Xrm.Page.ui.tabs.get("Address").setVisible(false);

    }
    if (stageName == "Document") {
        Xrm.Page.ui.tabs.get("Document_Upload").setVisible(true);
    }
    else {
        Xrm.Page.ui.tabs.get("Document_Upload").setVisible(false);

    }
}
function VisibleRuleonProcessstageChange() {
    var stage = Xrm.Page.data.process.getSelectedStage();
    var stageName = stage.getName();
    if (stageName == "General") {
        Xrm.Page.ui.tabs.get("Address").setVisible(true);
    }
    else {
        Xrm.Page.ui.tabs.get("Address").setVisible(false);

    }
    if (stageName == "Document") {
        Xrm.Page.ui.tabs.get("Document_Upload").setVisible(true);
    }
    else {
        Xrm.Page.ui.tabs.get("Document_Upload").setVisible(false);

    }
} 
function ValidateAddressBlacklist() {
   var WorkflowUrlName = GetConfigurationWorkflowUrl("PsbRestServiceUrl") + "AMxperuValidaDireccion";
    var status = "";
    //TO DO
    var request = {
        "input":
        {
            "$type": "AmxPeruPSBActivities.Model.AMxperuValidaDireccionRequest, AmxPeruPSBActivities",
            "departmentCode": "",
            "provinceCode": "",
            "districtCode": "",
            "codePopulatedcenter": "",
            "street1Code": "",
            "street2": "",
            "street3": "",
            "street4": "",
            "squareCode": "",
            "allotmentCode": "",
            "subAllotmentCode": "",
            "buildTypeCode": "",
            "buildType": "",
            "apartmentCode": "",
            "apartmentNumber": "",
            "urbanizationCode": "",
            "urbanization": "",
            "zoneCode": "",
            "zone": "",
            "sectorType": "",
            "sectorDescription": "",
            "stageType": "",
            "stageDescription": "",
            "Channel": "",
            "CustomerExternalId": "",
            "CustomerType": ""
        }
    };
    request.input.apartmentCode = Xrm.Page.getAttribute("amxperu_apartmenttypeinterior").getValue();
    request.input.apartmentNumber = Xrm.Page.getAttribute("amxperu_apartmenttypeinterior").getText();
    request.input.street2 = Xrm.Page.getAttribute("etel_street2").getValue();
    request.input.street3 = Xrm.Page.getAttribute("etel_street3").getValue();
    request.input.street1Code = Xrm.Page.getAttribute("amxperu_street1").getValue();
    request.input.squareCode = Xrm.Page.getAttribute("amxperu_square").getValue();
    request.input.buildTypeCode = Xrm.Page.getAttribute("amxperu_buildtype").getValue();
    request.input.buildType = Xrm.Page.getAttribute("amxperu_buildtype").getText();
    request.input.urbanizationCode = Xrm.Page.getAttribute("amxperu_urbanizationtype").getValue();
    request.input.urbanization = Xrm.Page.getAttribute("amxperu_urbanizationtype").getText();
    request.input.codePopulatedcenter = Xrm.Page.getAttribute("amxperu_populationzone").getValue();
    request.input.zone = Xrm.Page.getAttribute("amxperu_zonetype").getText();
    request.input.zoneCode = Xrm.Page.getAttribute("amxperu_zonetype").getValue();
    if (Xrm.Page.getAttribute("etel_individualcustomer") != null) {
        var IndividualGuid = Xrm.Page.getAttribute("etel_individualcustomer").getValue()[0].id;
        var customerExternalID = "";
        customerExternalID = FetchCustomerExternalID(IndividualGuid);
        request.input.CustomerExternalId = customerExternalID;
    }
    else {
        request.input.CustomerExternalId = Xrm.Page.getAttribute("etel_corporatecustomer").getValue();
        request.input.CustomerType = "2";
    }
    if (Xrm.Page.getAttribute("amxperu_department") != null) {
        var DepartmentGuid = Xrm.Page.getAttribute("amxperu_department").getValue()[0].id;
        var DepartmentCode = "";
        DepartmentCode = FetchDepartmentCode(DepartmentGuid);
        request.input.departmentCode = DepartmentCode;
    }
    if (Xrm.Page.getAttribute("amxperu_province") != null) {
        var ProvinceGuid = Xrm.Page.getAttribute("amxperu_province").getValue()[0].id;
        var ProvinceCode = "";
        ProvinceCode = FetchProvinceCode(ProvinceGuid);
        request.input.provinceCode = ProvinceCode;
    }
    if (Xrm.Page.getAttribute("amxperu_district") != null) {
        var DistrictGuid = Xrm.Page.getAttribute("amxperu_district").getValue()[0].id;
        var DistrictCode = "";
        DistrictCode = FetchDepartmentCode(DistrictGuid);
        request.input.districtCode = DistrictCode;
    }
    request.input.sectorType = Xrm.Page.getAttribute("amxperu_blockedifice").getValue();
    request.input.sectorDescription = Xrm.Page.getAttribute("amxperu_referencedescription").getValue();
    ServiceCall(request, WorkflowUrlName);
}
function FetchCustomerExternalID(CustomerID) {
    var ExternalID ="";
    var fetchQuery = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
        + "<entity name='contact'>"
        + "<attribute name='contactid'/>"
        + "<attribute name='fullname'/>"
        + "<attribute name='etel_externalid'/>"
        + "<order descending='false' attribute='fullname'/>"
        + "<filter type='and'>"
        + "<condition attribute='contactid' value='" + CustomerID + "' operator='eq'/>"
        + "</filter>"
        + "</entity>"
        + "</fetch>";
    var configRecord = XrmServiceToolkit.Soap.Fetch(fetchQuery);
    if (configRecord.length > 0) {
        if (configRecord[0].attributes.contactid != undefined) {
            if (configRecord[0].attributes.etel_externalid != null &&
                configRecord[0].attributes.etel_externalid != undefined) {
                ExternalID = configRecord[0].attributes.etel_externalid.value;
            }
        }
    }
    return ExternalID;
}
function FetchDepartmentCode(DepartmentID) {
    var DepartmentCode ="";
    var fetchQuery = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
        + "<entity name='amxperu_department'>"
        + "<attribute name='amxperu_departmentid'/>"
        + "<attribute name='amxperu_name'/>"
        + "<attribute name='amxperu_departmentcode'/>"
        + "<order descending='false' attribute='amxperu_name'/>"
        + "<filter type='and'>"
        + "<condition attribute='amxperu_departmentid' value='" + DepartmentID + "' operator='eq'/>"
        + "</filter>"
        + "</entity>"
        + "</fetch>";
    var configRecord = XrmServiceToolkit.Soap.Fetch(fetchQuery);
    if (configRecord.length > 0) {
        if (configRecord[0].attributes.amxperu_departmentid != undefined) {
            if (configRecord[0].attributes.amxperu_departmentcode != null &&
                configRecord[0].attributes.amxperu_departmentcode != undefined) {
                DepartmentCode = configRecord[0].attributes.amxperu_departmentcode.value;
            }
        }
    }
    return DepartmentCode;
}
function GetConfigurationWorkflowUrl(WorkflowUrlName) {
    var configValue;
    var fetchXml = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
        + "<entity name='etel_crmconfiguration'>"
        + "<attribute name='etel_crmconfigurationid'/>"
        + "<attribute name='etel_name'/>"
        + "<attribute name='etel_value'/>"
        + "<order descending='false' attribute='etel_name'/>"
        + "<filter type='and'>"
        + "<condition attribute='etel_name' value='" + WorkflowUrlName + "' operator='eq'/>"
        + "</filter>"
        + "</entity>"
        + "</fetch>";
    var configRecord = XrmServiceToolkit.Soap.Fetch(fetchXml);
    if (configRecord.length > 0) {
        if (configRecord[0].attributes.etel_crmconfigurationid != undefined) {
            if (configRecord[0].attributes.etel_value != null &&
                configRecord[0].attributes.etel_value != undefined) {
                configValue = configRecord[0].attributes.etel_value.value;
            }
        }
    }
    else {
        alert('Error: The Key ' + key + ' could not be found in AMX Configuration');
    }
    return configValue;
}
function FetchDistrictCode(DistrictID) {
    var DistrictCode = "";
    var fetchQuery = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
        + "<entity name='amxperu_district'>"
        + "<attribute name='amxperu_districtid'/>"
        + "<attribute name='amxperu_name'/>"
        + "<attribute name='amxperu_districtcode'/>"
        + "<order descending='false' attribute='amxperu_name'/>"
        + "<filter type='and'>"
        + "<condition attribute='amxperu_districtid' value='" + DistrictID + "' operator='eq'/>"
        + "</filter>"
        + "</entity>"
        + "</fetch>";
    var configRecord = XrmServiceToolkit.Soap.Fetch(fetchQuery);
    if (configRecord.length > 0) {
        if (configRecord[0].attributes.amxperu_districtid != undefined) {
            if (configRecord[0].attributes.amxperu_districtcode != null &&
                configRecord[0].attributes.amxperu_districtcode != undefined) {
                DistrictCode = configRecord[0].attributes.amxperu_districtcode.value;
            }
        }
    }
    return DistrictCode;
}
function FetchProvinceCode(ProvinceID) {
    var ProvinceCode="";
    var fetchQuery = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
        + "<entity name='amxperu_province'>"
        + "<attribute name='amxperu_provinceid'/>"
        + "<attribute name='amxperu_name'/>"
        + "<attribute name='amxperu_provincecode'/>"
        + "<order descending='false' attribute='amxperu_name'/>"
        + "<filter type='and'>"
        + "<condition attribute='amxperu_provinceid' value='" + ProvinceID + "' operator='eq'/>"
        + "</filter>"
        + "</entity>"
        + "</fetch>";
    var configRecord = XrmServiceToolkit.Soap.Fetch(fetchQuery);
    if (configRecord.length > 0) {
        if (configRecord[0].attributes.amxperu_provinceid != undefined) {
            if (configRecord[0].attributes.amxperu_provincecode != null &&
                configRecord[0].attributes.amxperu_provincecode != undefined) {
                DepartmentCode = configRecord[0].attributes.amxperu_provincecode.value;
            }
        }
    }
    return ProvinceCode;
}
function ServiceCall(request, WorkflowUrlName) {
    $.ajax({
        type: "POST",
        url: WorkflowUrlName,
        dataType: "json",
        data: JSON.stringify(request),
        contentType: "application/json; charset=utf-8",
        async: false,
        cache: false,
        xhrFields:
        {
            withCredentials: true
        },
        crossDomain: true,
        success: function (data) {
            if (data) {
                status = data.Output.output.Status;
                //alert(status);
            }
        },
        error: function (data) {
            
        }
    });  
}
//End