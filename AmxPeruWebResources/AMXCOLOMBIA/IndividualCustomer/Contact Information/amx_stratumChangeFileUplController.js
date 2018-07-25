var app = angular.module("app", ["ngFileUpload"]);

app.controller('Ctrl', function ($scope, $filter, $http) {

    $scope.cargarAdjunto = function (file) {
        debugger;

        var filesSelected = document.getElementById("adjuntarArchivo").files;
        if (filesSelected.length > 0) {
            var fileToLoad = filesSelected[0];

            var fileReader = new FileReader();

            fileReader.onload = function (fileLoadedEvent) {

                var infoCompleteFile = fileLoadedEvent.target.result.split(",");

                if (infoCompleteFile.length > 1) {
                    $scope.base64file = infoCompleteFile[1];
                    parent.Xrm.Page.getAttribute("amx_base64file").setValue($scope.base64file);

                    var ext = file[0].name.split('.')[1];

                    parent.Xrm.Page.getAttribute("amx_fileextension").setValue(ext);
                }
            };

            fileReader.readAsDataURL(fileToLoad);

            if (file[0].name) {

                parent.Xrm.Page.getAttribute("amx_hasfile").setValue(true);
            }
        }
    }
});