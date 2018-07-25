var FORM_TYPE_CREATE = 1;
var translationScope_IndividualDemographicBIHandler = {
    data: null,
    GetData: function () {
        var formId = 'js_BI_IndividualDemographicChange';
        if (translationScope_IndividualDemographicBIHandler.data != null) {
            return;
        }
        translationScope_IndividualDemographicBIHandler.data = GetTranslationData(formId);
    }
};
var translationScope_js_BI_CustomerCreation = {
    data: null,
    GetData: function () {
        var formId = 'js_BI_CustomerCreation';
        if (translationScope_js_BI_CustomerCreation.data != null) {
            return;
        }
        translationScope_js_BI_CustomerCreation.data = GetTranslationData(formId);
    }
};
function DemographicOnLoad() {
    debugger;
    translationScope_IndividualDemographicBIHandler.GetData();
    var individualCustomer = Xrm.Page.getAttribute("etel_customerid").getValue();
    var formcreated = Xrm.Page.getAttribute("etel_name").getValue();
    if (individualCustomer === null) {
        alert(translationScope_IndividualDemographicBIHandler.data.tInvalidOperation);
        Xrm.Page.ui.close();    
    }
    else {        
        if (formcreated == null){
            var columns = ['amxperu_DocumentType', 'etel_passportnumber', 'MobilePhone', 'etel_salutationcode', 'FirstName', 'MiddleName', 'LastName', 'amxperu_motherslastname', 'amxperu_businessname', 'etel_prefferedgivenname', 'EMailAddress1', 'BirthDate', 'etel_placeofbirth', 'amxperu_otherphonebusiness', 'amxperu_otherphonehome', 'etel_languagecode', 'GenderCode', 'FamilyStatusCode', 'amxperu_WorkPlace', 'JobTitle', 'AccountRoleCode', 'amxperu_allowvisit', 'amxperu_allowsocialnetworks', 'amxperu_allowsmsinstantmessaging', 'amxperu_allowphone', 'amxperu_allowmail', 'amxperu_allowfax', 'amxperu_allowemail', 'amxperu_allowbulkemail', 'amxperu_clarocommunityuser', 'amxperu_claroaccountuser', 'etel_socialmediatwitter', 'etel_socialmedialinkedin', 'amxperu_SocialMediaInstagram', 'etel_socialmediafacebook', 'PreferredContactMethodCode'];
            var filter = "ContactId eq guid'" + individualCustomer[0].id + "'";

            CrmRestKit.ByQuery("Contact", columns, filter, false).fail(function (xhr, status, ethrow) {
                alert('Error: ' + status + translationScope_IndividualDemographicBIHandler.data.tCustomerNotFoundMessage);
            }).done(function (collection) {
                if (collection.d != null && collection.d.results != null && collection.d.results.length > 0) {

                    if (collection.d.results[0].etel_salutationcode) {
                        Xrm.Page.getAttribute("etel_salutation").setValue(collection.d.results[0].etel_salutationcode.Value);
                    }
                    var jsontext = collection.d.results[0].BirthDate;
                    if (jsontext != null) {
                        var dateValue = new Date(parseInt(jsontext.replace("/Date(", "").replace(")/", ""), 10));
                        Xrm.Page.getAttribute("etel_dateofbirth").setValue(dateValue);
                    }

                    var fullname = '';
                    var firstname = collection.d.results[0].FirstName;
                    var middlename = collection.d.results[0].MiddleName;
                    var lastname = collection.d.results[0].LastName;

                    if (firstname != null && firstname != "") fullname += firstname;
                    if (middlename != null && middlename != "") fullname += middlename;
                    if (lastname != null && lastname != "") fullname += ' ' + lastname

                    Xrm.Page.getAttribute("etel_fullname").setValue(fullname);
                    Xrm.Page.getAttribute("etel_firstname").setValue(collection.d.results[0].FirstName);
                    Xrm.Page.getAttribute("etel_lastname").setValue(collection.d.results[0].LastName);
                    //Xrm.Page.getAttribute("etel_nationalid").setValue(collection.d.results[0].etel_nationalid);
                    Xrm.Page.getAttribute("etel_passportnumber").setValue(collection.d.results[0].etel_passportnumber);
                    //Xrm.Page.getAttribute("etel_driverslicencenumber").setValue(collection.d.results[0].etel_driverlicensenumber);

                    var biNumber = Xrm.Page.getAttribute("etel_binumber").getValue();

                    Xrm.Page.getAttribute("etel_name").setValue(biNumber + " " + translationScope_IndividualDemographicBIHandler.data.tNameFieldSuffix);

                    Xrm.Page.getAttribute("amxperu_mainphone").setValue(collection.d.results[0].MobilePhone);
                    Xrm.Page.getAttribute("amxperu_motherslastname").setValue(collection.d.results[0].amxperu_motherslastname);
                    Xrm.Page.getAttribute("amxperu_companyname").setValue(collection.d.results[0].amxperu_businessname);
                    Xrm.Page.getAttribute("amxperu_prefferedgivenname").setValue(collection.d.results[0].etel_prefferedgivenname);
                    Xrm.Page.getAttribute("amxperu_placeofbirth").setValue(collection.d.results[0].etel_placeofbirth);
                    Xrm.Page.getAttribute("amxperu_otherphonehome").setValue(collection.d.results[0].amxperu_otherphonehome);

                    Xrm.Page.getAttribute("amxperu_email").setValue(collection.d.results[0].EMailAddress1);


                    Xrm.Page.getAttribute("amxperu_otherphonebusiness").setValue(collection.d.results[0].amxperu_otherphonebusiness);
                    Xrm.Page.getAttribute("amxperu_workplace").setValue(collection.d.results[0].amxperu_WorkPlace);
                    Xrm.Page.getAttribute("amxperu_jobtitle").setValue(collection.d.results[0].JobTitle);
                    Xrm.Page.getAttribute("amxperu_clarocommunityuser").setValue(collection.d.results[0].amxperu_clarocommunityuser);
                    Xrm.Page.getAttribute("amxperu_claroaccountuser").setValue(collection.d.results[0].amxperu_claroaccountuser);

                    Xrm.Page.getAttribute("amxperu_socialprofilefacebook").setValue(collection.d.results[0].etel_socialmediafacebook);
                    Xrm.Page.getAttribute("amxperu_socialprofileinstagram").setValue(collection.d.results[0].amxperu_SocialMediaInstagram);
                    Xrm.Page.getAttribute("amxperu_socialprofiletwitter").setValue(collection.d.results[0].etel_socialmediatwitter);
                    Xrm.Page.getAttribute("amxperu_socialprofilelinkedin").setValue(collection.d.results[0].etel_socialmedialinkedin);

                    if (collection.d.results[0].amxperu_DocumentType) {
                        Xrm.Page.getAttribute("amxperu_documenttype").setValue(collection.d.results[0].amxperu_DocumentType.Value);
                    }
                    if (collection.d.results[0].etel_languagecode) {
                        Xrm.Page.getAttribute("amxperu_language").setValue(collection.d.results[0].etel_languagecode.Value);
                    }
                    if (collection.d.results[0].GenderCode) {
                        Xrm.Page.getAttribute("amxperu_gender").setValue(collection.d.results[0].GenderCode.Value);
                    }
                    if (collection.d.results[0].AccountRoleCode) {
                        Xrm.Page.getAttribute("amxperu_role").setValue(collection.d.results[0].AccountRoleCode.Value);
                    }
                    if (collection.d.results[0].etel_prefferedgivenname) {
                        Xrm.Page.getAttribute("amxperu_contactmethod").setValue(collection.d.results[0].etel_prefferedgivenname.Value);
                    }
                    if (collection.d.results[0].amxperu_allowbulkemail) {
                        Xrm.Page.getAttribute("amxperu_allowbulkemails").setValue(collection.d.results[0].amxperu_allowbulkemail.Value);
                    }
                    if (collection.d.results[0].amxperu_allowemail) {
                        Xrm.Page.getAttribute("amxperu_allowemail").setValue(collection.d.results[0].amxperu_allowemail.Value);
                    }
                    if (collection.d.results[0].amxperu_allowmail) {
                        Xrm.Page.getAttribute("amxperu_allowmail").setValue(collection.d.results[0].amxperu_allowmail.Value);

                    }
                    if (collection.d.results[0].amxperu_allowphone) {
                        Xrm.Page.getAttribute("amxperu_allowphonecall").setValue(collection.d.results[0].amxperu_allowphone.Value);
                    }
                    if (collection.d.results[0].amxperu_allowsmsinstantmessaging) {
                        Xrm.Page.getAttribute("amxperu_allowsms").setValue(collection.d.results[0].amxperu_allowsmsinstantmessaging.Value);
                    }
                    if (collection.d.results[0].amxperu_allowsocialnetworks) {
                        Xrm.Page.getAttribute("amxperu_allowsocialnetwork").setValue(collection.d.results[0].amxperu_allowsocialnetworks.Value);
                    }
                    if (collection.d.results[0].amxperu_allowvisit) {
                        Xrm.Page.getAttribute("amxperu_allowvisit").setValue(collection.d.results[0].amxperu_allowvisit.Value);
                    }

                    if (collection.d.results[0].FamilyStatusCode) {
                        Xrm.Page.getAttribute("amxperu_maritalstatus").setValue(collection.d.results[0].FamilyStatusCode.Value);

                    }
                }
                });

            var lookup = new Array();
            lookup[0] = new Object();
            lookup[0].id = individualCustomer[0].id;
            lookup[0].name = individualCustomer[0].name;
            lookup[0].entityType = individualCustomer[0].entityType;
            Xrm.Page.getAttribute("etel_customerid").setValue(lookup);           
            Xrm.Page.data.entity.save('save');
        }
        
    }
}
function CustomerNameOnChange() {

    translationScope_IndividualDemographicBIHandler.GetData();
    var fullname = '';
    var firstname = Xrm.Page.getAttribute("etel_firstname").getValue();
    var middlename = Xrm.Page.getAttribute("etel_middlename").getValue();
    var lastname = Xrm.Page.getAttribute("etel_lastname").getValue();

    if (firstname != null && firstname != "") fullname += firstname;

    if (middlename != null && middlename != "") fullname += ' ' + middlename;

    if (lastname != null && lastname != "") fullname += ' ' + lastname

    Xrm.Page.getAttribute("etel_fullname").setSubmitMode('always');
    Xrm.Page.getAttribute("etel_fullname").setValue(fullname);
}
function FormatString(str) {
    var args = Array.prototype.slice.call(arguments, 1);
    return str.replace(/\{(\d+)\}/g, function (match, index) {
        return args[index];
    });
}
function documentTypeCheck() {
    debugger;
    translationScope_js_BI_CustomerCreation.GetData();

    var DNI = "250000000";
    var CE = "250000001";
    var RUC = "250000002";
    var Passport = "250000003";

    //Doc Id length as per Doc Type
    var DocIdLengthDNI = 8;
    var DocIdLengthCE = 9;
    var DocIdLengthRUC = 11;

    //Generic Alert Text : TODO Translation
    //var DocIdValidationAlert = "For Doc Type {0}, Doc Id Must Be Of  {1} Characters";
    var DocIdValidationAlert = translationScope_js_BI_CustomerCreation.data.tDocType + " {0}, " + translationScope_js_BI_CustomerCreation.data.tDocNum + " {1} " + translationScope_js_BI_CustomerCreation.data.tCharacters;

    var formType = Xrm.Page.ui.getFormType();
    var DocumentNumber = Xrm.Page.getAttribute("etel_passportnumber").getValue();
    var DocumentType = Xrm.Page.getAttribute("amxperu_documenttype").getValue();
    var DocumentTypeText = Xrm.Page.getAttribute("amxperu_documenttype").getText();

    if (DocumentNumber != null) {
        if (DocumentType == DNI) {
            if (DocumentNumber.length != DocIdLengthDNI) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, DocumentTypeText, DocIdLengthDNI);
                alert(DocIdValidationAlert);
                Xrm.Page.getAttribute("etel_passportnumber").setValue("");
            }
        }
        else if (DocumentType == CE) {
            if (DocumentNumber.length != DocIdLengthCE) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, DocumentTypeText, DocIdLengthCE);
                alert(DocIdValidationAlert);
                Xrm.Page.getAttribute("etel_passportnumber").setValue("");
            }
        }
        else if (DocumentType == RUC) {
            if (DocumentNumber.length != DocIdLengthRUC) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, DocumentTypeText, DocIdLengthRUC);
                alert(DocIdValidationAlert);
                Xrm.Page.getAttribute("etel_passportnumber").setValue("");
            }
        }

        if (Xrm.Page.getAttribute("etel_passportnumber").getValue() != null) {
            var fetchXml = "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
                "  <entity name='contact'>" +
                "    <attribute name='contactid' />" +
                "    <attribute name='createdon' />" +
                "    <filter type='and'>" +
                "      <condition attribute='etel_passportnumber' operator='eq' value='" + DocumentNumber + "' />" +
                "    </filter>" +
                "  </entity>" +
                "</fetch>";

            if (formType == 1) {
                var individualRecords = XrmServiceToolkit.Soap.Fetch(fetchXml);
                if (individualRecords.length > 0) {
                    alert(translationScope_js_BI_CustomerCreation.data.tDocID + DocumentNumber + translationScope_js_BI_CustomerCreation.data.tUniqueDocID);
                    Xrm.Page.getAttribute("etel_passportnumber").setValue("");
                }
            }
        }
    }
}
function DateOfBirthCheck() {
    translationScope_IndividualDemographicBIHandler.GetData();
    var today = new Date();
    var day = today.getDate();
    var month = today.getMonth();
    var year = today.getFullYear();
    var minAcceptableDate = new Date(year - 18, month, day);
    var dateOfBirth = Xrm.Page.getAttribute("etel_dateofbirth").getValue();

    if (minAcceptableDate < dateOfBirth) {
        alert(translationScope_IndividualDemographicBIHandler.data.tDateOfBirthCheck);
        Xrm.Page.getAttribute("etel_dateofbirth").setValue(null);
    }
}
var biSecurity = {
    IsValidated: "",
    Validate: function () {
        translationScope_IndividualDemographicBIHandler.GetData();
        var paymentType = null;
        var request = new PrepareRequest(new IndividualCustomerDemographicsModificationSecurityRequest('etel_bi_modifyindividualcustomerdemographics', customer.Id, customer.EntityCode, paymentType, settings.CurrentUserId));
        retrieveRecordFromCustomService(request, function (data, textStatus, XmlHttpRequest) {
            biSecurity.IsValidated = data.IsValidated;
        });
    }
};