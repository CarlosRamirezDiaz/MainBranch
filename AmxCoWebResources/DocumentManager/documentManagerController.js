var app = angular.module("app", ["ngFileUpload"]);

app.controller('Ctrl', function ($scope, $filter, $http) {

    $scope.documents = [
        {
            name: 'Documento 1',
            target: 'https://www.google.es'
        },
        {
            name: 'Documento 2',
            target: 'https://stackoverflow.com/questions/20099784/open-links-in-new-window-using-angularjs'
        }
    ];
    $scope.cargarAdjunto = function (file) {
        //--------
        var id = parent.Xrm.Page.data.entity.getId();
        var id2 = new Date().toString();
        $scope.getDocumentsPerCase(id, function (e) { console.log(e); });
        //--------
        var filesSelected = document.getElementById("adjuntarArchivo").files;
        if (filesSelected.length > 0) {
            var fileToLoad = filesSelected[0];
            var fileReader = new FileReader();
            fileReader.onload = function (fileLoadedEvent) {

                var infoCompleteFile = fileLoadedEvent.target.result.split(",");

                if (infoCompleteFile.length > 1) {
                    $scope.base64file = infoCompleteFile[1];
                    $scope.ext = file[0].name.split('.')[1];
                }
            };
            fileReader.readAsDataURL(fileToLoad);
            if (file[0].name) {
                parent.Xrm.Page.getAttribute("amx_hasfile").setValue(true);
                $scope.sendFileToDocumentaryManager(function () {
                    parent.Xrm.Page.getAttribute("amx_filename").setValue(null);
                });
            }
        }
    }
    //$scope.sendFileToDocumentaryManager = function (callback) {
    //    var attachment = $scope.base64file;
    //    var filename = parent.Xrm.Page.getAttribute("amx_filename").getValue();
    //    var fileextension = $scope.ext;
    //    var customerid = parent.Xrm.Page.getAttribute("customerid").getValue()[0].id;
    //    var file = {
    //        'SendBase64FileToDocumentaryManagerRequest': {
    //            '$type': 'AmxPeruPSBActivities.Model.StratumChange.AmxCoSendBase64FileToDocumentaryManagerRequest, AmxPeruPSBActivities',
    //            'base64file': attachment,
    //            'filename': filename + "." + fileextension,
    //            'individualid': customerid
    //        }
    //    }
    //    var apiUrl = AMX.COMMON.RetrieveCrmConfiguration("PsbRestServiceUrl");
    //    apiUrl = apiUrl + 'AmxCoSendBase64FileToDocumentaryManager';
    //    $scope.sendRequest({
    //        type: "POST",
    //        url: apiUrl,
    //        data: file,
    //        onSuccess: function (response) {
    //            if (response) {
    //                if (response.Output.SendBase64FileToDocumentaryManagerResponse.error == false) {
    //                    alert('El documento: ' + filename + "." + fileextension + ' que se adjuntó, se envió correctamente.');
    //                    callback();
    //                }
    //                else {
    //                    if (response.Output.SendBase64FileToDocumentaryManagerResponse.ErrorDetail) {
    //                        alert(response.Output.SendBase64FileToDocumentaryManagerResponse.ErrorDetail[0]);
    //                    }
    //                }
    //            }
    //        },
    //        onError: function () {
    //            alert('Se presento un error al intentar enviar el documento adjunto.');
    //        }
    //    });

    //}
    $scope.openDocument = function (url) {
        $window.open(url, "_blank")
    }
    $scope.createRegistry = function (caseId, documentId) {
        var documentspercase = {
            amx_caseid: caseId,
            amx_documentid: documentId
        }
        $scope.createRecord(
            documentspercase,
            function (result) {
                console.log(result);
            }
        );
    }
    $scope.createDocumentPerCase = function (object, successCallback) {
        var url = parent.Xrm.Page.context.getClientUrl();
        url = url + "/XRMServices/2011/OrganizationData.svc/amx_documentspercaseSet";
        var endpoint = encodeURI(url);
        $http.post(endpoint, object).then(function (response) {
            successCallback(response);
        });
    }
    $scope.getDocumentsPerCase = function (caseId, successCallback) {
        var url = parent.Xrm.Page.context.getClientUrl();
        url = url + "/XRMServices/2011/OrganizationData.svc/amx_documentspercaseSet()?";
        url = url + "$select=amx_documentid&";
        url = url + "$filter=amx_caseid eq '" + caseId + "'";
        var endpoint = encodeURI(url);
        $http.get(endpoint).then(function (response) {
            if (response.status == 200) {
                var data = response.data.d.results;
                successCallback(data);
            }
        });
    }
});