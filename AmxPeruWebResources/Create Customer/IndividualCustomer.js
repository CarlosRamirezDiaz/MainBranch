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
var doubleAlertCheck = false;
function onChangeDocumentNumber() {
    debugger;
    translationScope_js_BI_CustomerCreation.GetData();

    //CRM Optionset Values
    var DNI = "250000000";
    var CE = "250000001";
    var RUC = "250000002";
    var Passport = "250000003";

    //Doc Id length as per Doc Type
    var DocIdLengthDNI = 8;
    var DocIdLengthCE = 9;
    var DocIdLengthRUC = 11;

    //Generic Alert Text : TODO Translation
    var DocIdValidationAlert = translationScope_js_BI_CustomerCreation.data.tDocType + "{0}," + translationScope_js_BI_CustomerCreation.data.tDocNum + " {1} " + translationScope_js_BI_CustomerCreation.data.tCharacters;

    var formType = Xrm.Page.ui.getFormType();
    var DocumentNumber = Xrm.Page.getAttribute("amxperu_documentid").getValue();
    var DocumentType = Xrm.Page.getAttribute("amxperu_documenttype").getValue();
    var DocumentTypeText = Xrm.Page.getAttribute("amxperu_documenttype").getText();
    doubleAlertCheck = !doubleAlertCheck;
    if (doubleAlertCheck && DocumentNumber != null) {
        if (DocumentType == DNI) {
            if (DocumentNumber.length != DocIdLengthDNI) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, DocumentTypeText, DocIdLengthDNI);
                alert(DocIdValidationAlert);
                Xrm.Page.getAttribute("amxperu_documentid").setValue(null);
            }
        }
        else if (DocumentType == CE) {
            if (DocumentNumber.length != DocIdLengthCE) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, DocumentTypeText, DocIdLengthCE);
                alert(DocIdValidationAlert);
                Xrm.Page.getAttribute("amxperu_documentid").setValue(null);
            }
        }
        else if (DocumentType == RUC) {
            if (DocumentNumber.length != DocIdLengthRUC) {
                DocIdValidationAlert = FormatString(DocIdValidationAlert, DocumentTypeText, DocIdLengthRUC);
                alert(DocIdValidationAlert);
                Xrm.Page.getAttribute("amxperu_documentid").setValue(null);
            }
        }
        else {
            doubleAlertCheck = false;
        }

        if (Xrm.Page.getAttribute("amxperu_documentid").getValue() != null) {
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
                    alert(translationScope_js_BI_CustomerCreation.data.tDocID + DocumentNumber+" " + translationScope_js_BI_CustomerCreation.data.tUniqueDocID);
                    Xrm.Page.getAttribute("amxperu_documentid").setValue(null);
                }
            }
        }
    }
}

function onLoad() {
    debugger;
    Xrm.Page.getAttribute("amxperu_salutation").setRequiredLevel("required");
    Xrm.Page.getAttribute("amxperu_firstname").setRequiredLevel("required");
    Xrm.Page.getAttribute("amxperu_lastname").setRequiredLevel("required");
    Xrm.Page.getAttribute("amxperu_gender").setRequiredLevel("required");
    Xrm.Page.getAttribute("amxperu_mainphone").setRequiredLevel("required");
    Xrm.Page.getAttribute("amxperu_language").setRequiredLevel("required");
    Xrm.Page.getAttribute("amxperu_documentid").setRequiredLevel("required");
    Xrm.Page.getAttribute("amxperu_documenttype").setRequiredLevel("required");
}

function onSaveIsCreatedInBscs() {
    debugger;
    translationScope_js_BI_CustomerCreation.GetData();
    var IsCreatedInBscsYes = "250000000";
    var IsCreatedInBscs = Xrm.Page.getAttribute("amxperu_iscreatedinbscs").getValue();
    if (IsCreatedInBscs == IsCreatedInBscsYes) {
        alert(translationScope_js_BI_CustomerCreation.data.tCustomerCreationDone);
        var createdIndividualGuid = Xrm.Page.getAttribute("amxperu_createdindividualid").getValue();
        if (createdIndividualGuid != null && createdIndividualGuid[0].id != null) {
            Xrm.Utility.openEntityForm("contact", createdIndividualGuid[0].id, null, null);
        }
    }
}

function FormatString(str) {
    var args = Array.prototype.slice.call(arguments, 1);
    return str.replace(/\{(\d+)\}/g, function (match, index) {
        return args[index];
    });
}

function submitToOrderProcess() {
    debugger;
    Xrm.Page.getAttribute("amxperu_submit").setValue(250000000);
    Xrm.Page.data.entity.save();
}

function OnSave() {

    if (Xrm.Page.getAttribute("amxperu_name").getValue() == null) {
        var firstName = Xrm.Page.getAttribute("amxperu_firstname").getValue();
        var middleName = Xrm.Page.getAttribute("amxperu_lastname").getValue();

        var fullName = firstName + " " + middleName;
        Xrm.Page.getAttribute('amxperu_name').setValue(fullName);
    }

}