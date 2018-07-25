if (typeof (AMX) == "undefined") {
    AMX = { __namespace: true };
}

AMX.IVRAppointmentLog = {
    Customer360Url: null,
    Customer360UrlExtras: null,
    CustomerSearchUrl: null,
    DigiturnoTurnoId: null,
    CanalId : null,
    OnLoad: function () {
        AMX.IVRAppointmentLog.Customer360Url = Xrm.Page.context.getClientUrl() + "/main.aspx?etc=2&pagetype=entityrecord";
        AMX.IVRAppointmentLog.Customer360UrlExtras = "formid=e283abea-f298-4c98-9510-8e791d0e1ce5&is_ivroption=true&id={[contactId]}";
        AMX.IVRAppointmentLog.CustomerSearchUrl = Xrm.Page.context.getClientUrl() + "/main.aspx?area=etel_customersearch&page=CS&pageType=EntityList&web=true&extraqs=data=" + encodeURIComponent("parameter_showWelcomeMessage=false");
        var parameters = Xrm.Page.context.getQueryStringParameters();
        var customparams = AMX.IVRAppointmentLog.ParseData(parameters.data);
        var ani = customparams.ani;
        var documentId = customparams.documentid;
        var documentType = customparams.documenttype;
        if (customparams.turnoid != undefined) AMX.IVRAppointmentLog.DigiturnoTurnoId = customparams.turnoid;
        if (customparams.canalid != undefined) AMX.IVRAppointmentLog.CanalId = customparams.canalid;
        if (ani == "0" && documentId == "") { AMX.IVRAppointmentLog.RedirectToCustomerSearch(); return; }
        AMX.IVRAppointmentLog.SearchForIndividual(ani, documentId, documentType);
    },
    SearchForIndividual: function (ani, documentId, documentType) {
        if (documentId == null || documentId == "" || documentId == "0") { AMX.IVRAppointmentLog.SearchForIndividualByAni(ani); return; }
        if (documentType == undefined || documentType == null || documentType == "") { documentType = 1; }
        var webApiSelectFilters = "contacts?$select=amxperu_documenttype,fullname,contactid,etel_accountnumber,etel_iddocumentnumber&$filter=etel_iddocumentnumber eq '" + documentId + "' and  amxperu_documenttype eq " + documentType;
        AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {

            if (results.value.length == 0) { AMX.IVRAppointmentLog.SearchForIndividualByAni(ani); return; }
            for (var i = 0; i < results.value.length; i++) {
                var contactId = results.value[i]["contactid"];
                var contactName = results.value[i]["fullname"];
                AMX.IVRAppointmentLog.Customer360UrlExtras = AMX.IVRAppointmentLog.Customer360UrlExtras.replace("[contactId]", contactId);
                AMX.IVRAppointmentLog.Customer360Url = AMX.IVRAppointmentLog.Customer360Url + "&extraqs=" + encodeURIComponent(AMX.IVRAppointmentLog.Customer360UrlExtras);
                AMX.IVRAppointmentLog.Open360View(AMX.IVRAppointmentLog.Customer360Url, contactId, contactName);
                return;
            }

        }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);        
    },
    SearchForIndividualByAni: function (ani) {
        var webApiSelectFilters = "amx_customercontactinformations?$select=amx_contacttype,_amx_individualcustomerid_value,amx_name&$filter=amx_phoneno eq '" + ani + "' and  _amx_individualcustomerid_value ne null";
        AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
            if (results.value.length == 0) { AMX.IVRAppointmentLog.RedirectToCustomerSearch(); return; }
            for (var i = 0; i < results.value.length; i++) {
                var contactId = results.value[i]["_amx_individualcustomerid_value"];
                var contactName = results.value[i]["_amx_individualcustomerid_value@OData.Community.Display.V1.FormattedValue"];
                AMX.IVRAppointmentLog.Customer360UrlExtras = AMX.IVRAppointmentLog.Customer360UrlExtras.replace("[contactId]", contactId);
                AMX.IVRAppointmentLog.Customer360Url = AMX.IVRAppointmentLog.Customer360Url + "&extraqs=" + encodeURIComponent(AMX.IVRAppointmentLog.Customer360UrlExtras);
                AMX.IVRAppointmentLog.Open360View(AMX.IVRAppointmentLog.Customer360Url, contactId, contactName);
                return;
            }
        }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);    
    },

    RedirectToCustomerSearch: function () {
        window.location.replace(AMX.IVRAppointmentLog.CustomerSearchUrl);
        return;
    },
    ParseData: function (query) {
        var result = {};
        if (typeof query == "undefined" || query == null) { return result; }
        var queryparts = query.split("&");
        for (var i = 0; i < queryparts.length; i++) {
            var params = queryparts[i].split("=");
            result[params[0].toLowerCase()] = params.length > 1 ? params[1] : null;
        }
        return result;
    },
    Open360View: function (url, contactId, contactName) {
        // Exists BiHeader?
        var userId = Xrm.Page.context.getUserId();
        AMX.COMMON.GetBIHeader(userId, function (biheader) {
            if (biheader.value.length > 0) {
                AMX.COMMON.CloseBIHeader(biheader.value[0]["activityid"], url);
                AMX.IVRAppointmentLog.CreateBIHeader(url, contactId, contactName);
                return;
            }
            AMX.IVRAppointmentLog.CreateBIHeader(url, contactId, contactName);
        }, function (eData) { parent.Xrm.Utility.alertDialog(eData); } )
        
    },
    CreateBIHeader: function (url, contactId, contactName) {
        var userId = Xrm.Page.context.getUserId();
        var createHeader = {};
        if (AMX.IVRAppointmentLog.DigiturnoTurnoId != null) {
            createHeader.subject = 'Digiturno: ' + AMX.IVRAppointmentLog.DigiturnoTurnoId;
            createHeader.etel_channelinteractionid = AMX.IVRAppointmentLog.DigiturnoTurnoId;
        }
        else { createHeader.subject = 'IVR Call'; }
        createHeader.etel_headerstatus = true;
        createHeader.etel_csrid = userId.replace('{', '').replace('}', '');
        createHeader.etel_customeridtext = contactId.replace('{', '').replace('}', '');
        createHeader.etel_customerrequired = true;
        createHeader.etel_reason = "IVR Call";
        createHeader.etel_biheaderchanneltypecode = 831260001; //Phone Call
        createHeader.etel_interactiondirectiontypecode = 2; //Incoming
        createHeader.etel_channelinteractionstarttime = new Date().toISOString();
        createHeader.etel_biheaderstarttime = new Date().toISOString();
        //createHeader["etel_individualcustomerid@odata.bind"] = "/contacts(" + contactId.replace('{', '').replace('}', '') + ")"; 
        createHeader.etel_customername = contactName;
        AMX.COMMON.CreateEntiyWebApi("etel_bi_headers", createHeader, function (results) {
            window.location.replace(url);
        }, function (eData) { }, false);        
    },

    __namespace: true
}