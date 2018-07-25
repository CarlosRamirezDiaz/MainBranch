OrderCaptureAssociateBiHeader = {

    Init: function()
    {
        if (Xrm.Page.data.entity.getId() == "")
            return;

        var biHeader = OrderCaptureAssociateBiHeader.getBIHeader();
        if (biHeader == null)
            return;

        var etel_individualcustomerid = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();

        if (etel_individualcustomerid == null)
            return;

        var orderCaptureCustomerId = etel_individualcustomerid[0].id;
        orderCaptureCustomerId = orderCaptureCustomerId.replace('{', '').replace('}', '');

        if (biHeader.etel_individualcustomerid != undefined && biHeader.etel_individualcustomerid.Id !== null) {
            if (biHeader.etel_individualcustomerid.Id.toLowerCase() == orderCaptureCustomerId.toLowerCase())
            {
                OrderCaptureAssociateBiHeader.associateBiHeader(biHeader);
                return;
            }
        }
    },

    associateBiHeader: function(biHeader)
    {
        var orderCapture = {};
        orderCapture.amx_BIHeaderId = { Id: biHeader.ActivityId, LogicalName: "etel_bi_header" };

        SDK.REST.updateRecord(Xrm.Page.data.entity.getId(), orderCapture, "etel_ordercapture",
            function () {
            },
            function (error) { alert("OrderCaptureAssociateBiHeader - " + error.message); });
    },

    getBIHeader: function () {
        var userId = Xrm.Page.context.getUserId();
        var oDataSetName = "etel_bi_headerSet";
        var oDataUrl = "?$select=ActivityId, etel_individualcustomerid, etel_accountid&$filter=OwnerId/Id eq guid'" + userId + "' and etel_headerstatus eq true";
        var data = OrderCaptureAssociateBiHeader.retrieveCrmRecord(oDataSetName, oDataUrl);
        return data.results[0];
    },

    retrieveCrmRecord: function (odataSetName, url) {

        if (!odataSetName) {
            alert("odataSetName empty!");
            return;
        }

        var ODataPath = Xrm.Page.context.getClientUrl() + "/XRMServices/2011/OrganizationData.svc/";
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
}