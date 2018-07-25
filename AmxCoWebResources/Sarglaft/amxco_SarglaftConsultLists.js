var amxco_SarglaftConsultLists = {
    OnLoad: function () {
        var individualCustomer = Xrm.Page.getAttribute("etel_individualcustomerid").getValue();

        // Call Sarglaft Consult Lists
        amxco_SarglaftConsultLists.SarglaftConsultList(individualCustomer);
    },

    SarglaftConsultList: function (individualCustomer) {
        var WorkflowUrlName = Xrm.Page.context.getClientUrlForInteractioncentricDashboard() + ":6004/api/v1/workflow/AmxCoSarglaftConsultLists";
        //TO DO
        var request = {
            "FullName": "",
            "Punctuation": 90,
            "IndividualCustomerId": individualCustomer[0].id
        };

        request.FullName = individualCustomer[0].name;

        amxco_SarglaftConsultLists.ServiceCall(request, WorkflowUrlName, amxco_SarglaftConsultLists.SarglaftConsultList_Callback);
    },

    SarglaftConsultList_Callback: function (data) {
    },

    ServiceCall: function (request, WorkflowUrlName, success_callback) {
        $.ajax({
            type: "POST",
            url: WorkflowUrlName,
            dataType: "json",
            data: JSON.stringify(request),
            contentType: "application/json; charset=utf-8",
            async: true,
            cache: false,
            xhrFields:
            {
                withCredentials: true
            },
            crossDomain: true,
            success: function (data) {
                if (data && success_callback != undefined) {
                    success_callback(data);
                }
            },
            error: function (data) {
                var errorMessage = "";
                if (data.status != undefined && data.status != null)
                    errorMessage += data.status;

                if (data.statusText != undefined && data.statusText != null)
                    errorMessage += ("-" + data.statusText + "\n");

                if (data.responseText != undefined && data.responseText != null)
                    errorMessage += data.responseText;

                alert(errorMessage);
            }
        });
    }
}