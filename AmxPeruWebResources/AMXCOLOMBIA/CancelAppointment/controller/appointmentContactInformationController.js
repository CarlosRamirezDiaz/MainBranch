angular.module('appointmentContactInformation', [])
    .controller("appointmentContactInformationController",
    ['$scope', '$http', '$rootScope',
        function ($scope, $http, $rootScope) {

            $scope.saveData = function () {

                var Name = document.getElementById("firstname").value;
                var Telephone1 = document.getElementById("phonenumber1").value;
                var Telephone2 = document.getElementById("phonenumber2").value;
                var Email1 = document.getElementById("email1").value;
                var Email2 = document.getElementById("email2").value;

                var returnValue = Name + "," + Telephone1 + "," + Telephone2 + "," + Email1 + "," + Email2;
                Mscrm.Utilities.setReturnValue(returnValue);
                closeWindow(true);

            }
            $scope.closeWindow = function ()
            {
                var returnValue = null;
                Mscrm.Utilities.setReturnValue(returnValue);
                closeWindow(true);
            }
            //parent.document.getElementById("InlineDialogCloseLink").onclick = function ()
            //{
            //    $scope.closeWindow();
            //}
            var initiate = function () {
                //$scope.saveData();
                parent.document.getElementsByClassName("ms-crm-InlineDialogCloseInnerContainer")[0].style.visibility = 'hidden';
            };

            initiate();
        }]);    