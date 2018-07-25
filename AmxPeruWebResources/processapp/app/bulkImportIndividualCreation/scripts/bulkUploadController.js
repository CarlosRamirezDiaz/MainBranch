(function (window, angular) {
    var app = angular.module("ETELProcessApp");
    app.filter('isempty', function () {
        return function (input, replaceText) {
            if (input) return input;
            else return replaceText;
        };
    });
    app.controller("bulkUploadController", function ($scope, $http, $rootScope) {
        $rootScope.currentProcess = window.definitions.processes.newSubscription;
        $rootScope.displayColumnNewValue = false;
        $rootScope.displayColumnOption = false;
        if (typeof $scope.scopeData === "undefined") {
            $scope.scopeData = {};
        }
        $scope.lastPage = false;
        $scope.firstPage = true;
        $scope.stageLoaded = false;
        $scope.readyForSubmit = false;
        $scope.showErrorGrid = false;
        $scope.visibleValidate = false;
        $scope.isValidated = false;
        $scope.isSuccessfullySubmitted = false;
        $scope.errorLogs = [];
        $scope.currentIndex = 0;
        $scope.startIndex = 0;
        $scope.pageSize = 10;

        $scope.scopeData.bulkUpload = {
            'translation': function () {
                $scope.scopeData.bulkUpload.translations = GetTranslationData("BulkUpload");
            },
            'initiate': function () {
                $scope.translationHeader = GetTranslationData("BulkUploadHeader");
                $scope.messageUploadValidFile = $scope.translationHeader.tMessageUploadValidFile;
                $scope.messageRecordLimit = $scope.translationHeader.tMessageRecordLimit;
                $scope.messageContractId = $scope.translationHeader.tMessageContractId;
                $scope.messageCustomerId = $scope.translationHeader.tMessageCustomerId;
                $scope.messageRootorDivision = $scope.translationHeader.tMessageRootDivisionValue;
                $scope.messageSimNo = $scope.translationHeader.tMessageSimNo;
                $scope.messageYesNo = $scope.translationHeader.tMessageYesNo;
                $scope.messageCharacters = $scope.translationHeader.tMessageCharacters;
                $scope.messageOnlyAlphabet = $scope.translationHeader.tMessageOnlyAlphabet;
                $scope.messageOnlyNumbers = $scope.translationHeader.tMessageOnlyNumbers;
                $scope.messageOnlyAlphaNumeric = $scope.translationHeader.tMessageOnlyAlphaNumeric;
                $scope.messageOnlyAlphabetMaxLength = $scope.translationHeader.tMessageOnlyAlphabetMaxLength;
                $scope.messageOnlyNumbersMaxLength = $scope.translationHeader.tMessageOnlyNumbersMaxLength;
                $scope.messageOnlyAlphaNumericMaxLength = $scope.translationHeader.tMessageOnlyAlphaNumericMaxLength;
                $scope.messageStatus = $scope.translationHeader.tMessageStatus;
                $scope.messageRootDiv = $scope.translationHeader.tMessageRootDiv;
                $scope.messageEmpty = $scope.translationHeader.tMessageEmpty;
                $scope.messageMissingColumns = $scope.translationHeader.tMessageMissingColumns;
                $scope.messageValidOfCsv = $scope.translationHeader.tMessageValidOfCsv;
                $scope.messageSubmitWithoutFile = $scope.translationHeader.tMessageSubmitWithoutFile;
                $scope.messageErrorsInFile = $scope.translationHeader.tMessageErrorsInFile;
                $scope.messageRequestIsFailed = $scope.translationHeader.tMessageRequestIsFailed;
                $scope.errorLogFile = $scope.translationHeader.tErrorLogFile;
                $scope.sampleFile = $scope.translationHeader.tSampleFile;
                $scope.successfullyMessage = $scope.translationHeader.successfullyMessage;
                $scope.errorMsgForDNI = $scope.translationHeader.terrorMsgforDNI;
                $scope.errorMsgForCE = $scope.translationHeader.terrorMsgforCE;
                $scope.errorMsgForRUC = $scope.translationHeader.terrorMsgforRUC;
                $scope.errorMsgForDocType = $scope.translationHeader.terrorMsgforDocType;

                var newSubscriptionHeader = eval("[" + $scope.translationHeader.tNewSubscriptionHeader + "]");
                var newCorporateCustomerHeader = eval("[" + $scope.translationHeader.tNewCorporateCustomerHeader + "]");
                var subscriptionStatusChangeHeader = eval("[" + $scope.translationHeader.tSubscriptionStatusChangeHeader + "]");
                var newIndividualCustomerHeader = eval("[" + $scope.translationHeader.tNewIndividualCustomerHeader14 + "]");

                if (angular.equals(processName, "bulkImportNewSubscription")) {
                    $scope.cvsString = $scope.translationHeader.tNewSubscriptionCvsString;
                    $scope.dataHeader = newSubscriptionHeader;
                } else if (angular.equals(processName, "bulkImportSubscriptionStatusChange")) {
                    $scope.cvsString = $scope.translationHeader.tSubscriptionStatusChangeCvsString;
                    $scope.dataHeader = subscriptionStatusChangeHeader;
                } else if (angular.equals(processName, "bulkImportCorporateCreation")) {
                    $scope.cvsString = $scope.translationHeader.tNewCorporateCustomerCvsString;
                    $scope.dataHeader = newCorporateCustomerHeader;
                }
                else if (angular.equals(processName, "bulkImportIndividualCreation")) {
                    $scope.cvsString = $scope.translationHeader.tNewIndividualCustomerCvsString14;
                    $scope.dataHeader = newIndividualCustomerHeader;
                }

                if (window.definitions.parameters.OrderState === window.definitions.orderCaptures.StateCode.Inactive) {
                    $scope.isSuccessfullySubmitted = true;
                }
            },
            'validate': function () {
                var processName = window.processName;
                $scope.readyForSubmit = true;
                $scope.visibleValidate = false;
                $scope.errorLog = [];
                $scope.errorLogs = [];
                $scope.csvRows = [];
                $scope.types = [];
                var recordsFailed = 0;
                var custIdRegEx = new RegExp('^CUST[0-9]{10}$');
                var contIdRegEx = new RegExp('^CONTR[0-9]{10}$');
                var simNoRegEx = new RegExp('[-+]?([0-9]*\.)?[0-9]+([eE][-+]?[0-9]+)?');
                var alNumRegEx = new RegExp('^[a-zA-Z0-9]*$');
                var alRegex = new RegExp('^[a-zA-Z]*$');
                var numRegEx = new RegExp('^[0-9]*$');
                var emptyRegEx = new RegExp('^$');
                var DNIRegex = new RegExp('^[0-9]{8}$');
                var CERegex = new RegExp('^[0-9]{9}$');
                var RUCRegex = new RegExp('^[0-9]{11}$');
                var types = [];
                var lengths = [];
                var columnNames = [];
                var headers = $scope.customerData[0];

                for (i = 0; i < headers.length; i++) {
                    headers[i] = headers[i].replace(/(\r\n|\n|\r)/gm, "");
                }

                var recordLimit = eval("[" + $scope.translationHeader.tRecordLimit + "]");
                recordLimit = parseInt(recordLimit);

                for (k = 0; k < $scope.dataHeader.length; k++) {
                    var headerData = $scope.dataHeader[k];
                    var column = headerData.FieldName;
                    var type = headerData.ValidationValue;
                    var length = (headerData.MaxLength !== undefined ? headerData.MaxLength : 0);
                    columnNames.push(column);
                    types.push(type);
                    lengths.push(length);
                }

                //if (!angular.equals(columnNames, headers) || $scope.customerData.length < 2) {
                //    $scope.errorLogs.push($scope.messageUploadValidFile);
                //    window.alert($scope.messageUploadValidFile);
                //    return;
                //}

                if ($scope.customerData.length > recordLimit) {
                    $scope.errorLogs.push($scope.messageUploadValidFile);
                    $scope.messageRecordLimit = $scope.messageRecordLimit.replace("$replace$", recordLimit);
                    window.alert($scope.messageRecordLimit);
                    return;
                }

                $scope.duplicateDetector = [];

                for (i = 1; i < $scope.customerData.length; i++) {
                    var cust = $scope.customerData[i];
                    var error = null;
                    if (cust.length === headers.length) {
                        for (j = 0; j < cust.length; j++) {
                            var type = types[j];
                            var length = lengths[j];
                            var customerData = cust[j];
                            customerData = customerData.replace(/(\r\n|\n|\r)/gm, "").split(" ").join("");
                            switch (type) {
                                case "taxNo":
                                    //Customer Definition Should Be Changed with this mapping
                                    if (!emptyRegEx.test(customerData)) {
                                        var customId = $scope.duplicateDetector[customerData];
                                        if (customId) {
                                            error = {
                                                row: i + 1,
                                                data: customerData,
                                                column: "Tax No",
                                                reason: "Duplicate Tax No for " + customerData + " found. First occurence at line: " + customId
                                            };
                                            $scope.errorLog.push(error);
                                        }
                                        else {
                                            $scope.duplicateDetector[customerData] = i + 1;
                                        }
                                    }
                                    break;
                                case "contId":
                                    if (emptyRegEx.test(customerData) || !contIdRegEx.test(customerData)) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: "Contract ID",
                                            reason: $scope.messageContractId
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    else {
                                        var customId = $scope.duplicateDetector[customerData];
                                        if (customId) {
                                            error = {
                                                row: i + 1,
                                                data: customerData,
                                                column: "Contract ID",
                                                reason: "Duplicate Contract Id for " + customerData + " found. First occurence at line: " + customId
                                            };
                                            $scope.errorLog.push(error);
                                        }
                                        else {
                                            $scope.duplicateDetector[customerData] = i + 1;
                                        }
                                    }
                                    break;
                                case "custId":
                                    if (emptyRegEx.test(customerData) || !custIdRegEx.test(customerData)) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: "Customer ID",
                                            reason: $scope.messageCustomerId
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    break;
                                case "simNo":
                                    if (emptyRegEx.test(customerData) || !simNoRegEx.test(customerData)) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: "SIM No",
                                            reason: $scope.messageSimNo
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    break;
                                case "boolean":
                                    if (emptyRegEx.test(customerData) || ((customerData.trim().toLowerCase() !== 'no') && (customerData.trim().toLowerCase() !== 'yes'))) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageYesNo
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    break;
                                case "alpha":
                                    if (emptyRegEx.test(customerData) || !alRegex.test(customerData)) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageOnlyAlphabet
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    break;
                                case "rootAlpha":
                                    if (emptyRegEx.test(customerData) || !alRegex.test(customerData)) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageRootorDivision
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    else if (customerData != "Root" && customerData != "Division") {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageRootorDivision
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    break;
                                case "alphaMaxLength":
                                    if (emptyRegEx.test(customerData) || !alRegex.test(customerData) || customerData.length > length) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageOnlyAlphabetMaxLength + " " + length + " " + $scope.messageCharacters
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    break;
                                case "numeric":
                                    if (emptyRegEx.test(customerData) || !numRegEx.test(customerData)) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageOnlyNumbers
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    break;
                                case "numericMaxLength":
                                    if (emptyRegEx.test(customerData) || !numRegEx.test(customerData) || customerData.length > length) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageOnlyNumbersMaxLength + " " + length + " " + $scope.messageCharacters
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    break;
                                case "alphaNumeric":
                                    if (emptyRegEx.test(customerData) || !alNumRegEx.test(customerData)) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageOnlyAlphaNumeric
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    break;
                                case "alphaNumericMaxLength":
                                    if (emptyRegEx.test(customerData) || !alNumRegEx.test(customerData) || customerData.length > length) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageOnlyAlphaNumericMaxLength + " " + length + " " + $scope.messageCharacters
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    break;
                                case "status":
                                    customerData = angular.lowercase(customerData);
                                    if (emptyRegEx.test(customerData) || (customerData !== "draft" && customerData !== "inprogress" && customerData !== "scheduled" && customerData !== "completed")) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageStatus
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    break;
                                case "rootdiv":
                                    customerData = angular.lowercase(customerData);
                                    if (emptyRegEx.test(customerData) || (customerData !== "root" && customerData !== "division")) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageRootDiv
                                        };
                                        $scope.errorLog.push(error);
                                    }
                                    break;
                                case "text":
                                    if (emptyRegEx.test(customerData)) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageEmpty
                                        };
                                        $scope.errorLog.push(error);
                                    }

                                    break;
                                case "mi":
                                    if (emptyRegEx.test(customerData)) {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageEmpty
                                        };
                                        $scope.errorLog.push(error);
                                    }

                                    break;
                                case "documentTypeValidation":
                                    if (!emptyRegEx.test(customerData)) {
                                        if ((cust[headers.indexOf("DocumentType")] != "DNI") && (cust[headers.indexOf("DocumentType")] != "RUC") && (cust[headers.indexOf("DocumentType")] != "CE") && (cust[headers.indexOf("DocumentType")] != "Passport")) {
                                            error =
                                                {
                                                    row: i + 1,
                                                    data: cust[headers.indexOf("DocumentType")],
                                                    column: headers[j],
                                                    reason: headers[j] + " " + $scope.errorMsgForDocType
                                                };
                                            $scope.errorLog.push(error);
                                        }
                                    }
                                    else {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageEmpty
                                        };
                                        $scope.errorLog.push(error);

                                    }
                                    break;
                                case "documentIDValidation":
                                    if (!emptyRegEx.test(customerData)) {
                                        //  if ((cust[headers.indexOf("Document Type")] == "DNI") && (!DNIRegex.test("Document ID"))) {
                                        if ((cust[headers.indexOf("DocumentType")] == "DNI") && (!DNIRegex.test(cust[headers.indexOf("DocumentID")]))) {

                                            error = {
                                                row: i + 1,
                                                data: customerData,
                                                column: headers[j],
                                                reason: headers[j] + " " + $scope.errorMsgForDNI
                                            };
                                            $scope.errorLog.push(error);
                                        }
                                        else if ((cust[headers.indexOf("DocumentType")] == "CE") && (!CERegex.test(cust[headers.indexOf("DocumentID")]))) {
                                            error = {
                                                row: i + 1,
                                                data: customerData,
                                                column: headers[j],
                                                reason: headers[j] + " " + $scope.errorMsgForCE
                                            };
                                            $scope.errorLog.push(error);
                                        }
                                        else if ((cust[headers.indexOf("DocumentType")] == "RUC") && (!RUCRegex.test(cust[headers.indexOf("DocumentID")]))) {
                                            error = {
                                                row: i + 1,
                                                data: customerData,
                                                column: headers[j],
                                                reason: headers[j] + " " + $scope.errorMsgForRUC
                                            };
                                            $scope.errorLog.push(error);
                                        }
                                    }
                                    else {
                                        error = {
                                            row: i + 1,
                                            data: customerData,
                                            column: headers[j],
                                            reason: headers[j] + " " + $scope.messageEmpty
                                        };
                                        $scope.errorLog.push(error);
                                    }

                                    break;
                                default:
                                    break;
                            }
                        }
                    } else if (cust.length !== headers.length && cust.length !== 1) {
                        error = {
                            row: i + 1,
                            data: $scope.messageMissingColumns,
                            column: $scope.messageMissingColumns,
                            reason: $scope.messageMissingColumns
                        };
                        $scope.errorLog.push(error);
                    }
                    if (error !== null) {
                        recordsFailed++;
                    }
                }

                $scope.fileInfo.push(recordsFailed);
                if ($scope.errorLog.length > 0) {
                    $scope.showErrorGrid = true;
                    var errorRecords = [];
                    for (var j = 0; j < $scope.errorLog.length; j++) {
                        var e = [$scope.errorLog[j].row, $scope.errorLog[j].data,
                        $scope.errorLog[j].column, $scope.errorLog[j].reason
                        ];
                        errorRecords.push(e);
                    }
                    var headerArray = ["Row", "Data", "Column Header", "Reason"];
                    $scope.csvRows.push(headerArray);
                    for (var i = 0; i < errorRecords.length; i++) {
                        var r = errorRecords[i];
                        $scope.csvRows.push(r);
                    }
                }
                else {
                    $scope.isValidated = true;
                }
                $scope.tempErrorLogs = [];

                for (var k = 0; k < $scope.errorLog.length; k++) {
                    var errorLogLine = $scope.errorLog[k];
                    var index = errorLogLine.row;
                    var rowData = $scope.tempErrorLogs[index];
                    if (rowData === undefined || rowData === null || rowData === 'undefined') {
                        rowData = { rowNumber: index, reason: [] };
                        $scope.tempErrorLogs[index] = rowData;
                        $scope.errorLogs.push(rowData);
                    }
                    rowData.reason.push(errorLogLine.reason);
                }

                $scope.errorLog = [];

                window.definitions.bulkUploadResources = {
                    fileInfo: $scope.fileInfo,
                    encodedFile: $scope.encodedFile,
                    fileName: $scope.dataFile.name
                };
            },
            'file_changed': function (element) {
                $scope.fileInfo = [];
                $scope.dataFile = element.files[0];
                $scope.fileName = $scope.dataFile.name;
                document.getElementById("uploadFile").value = $scope.fileName;
                $scope.scopeData.bulkUpload.upload();
            },
            'upload': function () {
                $scope.customerData = [];
                $scope.errorLog = [];
                $scope.errorLogs = [];
                $scope.fileInfo = [];
                $scope.showErrorGrid = false;
                $scope.isValidated = false;
                var extn = $scope.dataFile.name.split(".").pop();
                if (extn === "csv") {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        var contents = e.target.result;
                        $scope.encodedFile = btoa(unescape(encodeURIComponent(contents)));
                        $scope.$apply(function () {
                            $scope.content = contents;
                            var lines, lineNumber, data;
                            lines = $scope.content.split('\n');
                            lineNumber = 0;
                            for (var i = 0; i < lines.length; i++) {
                                l = lines[i];
                                lineNumber++;
                                data = l.split(',');
                                $scope.customerData.push(data);
                            }
                            $scope.fileInfo.push((lines.length - 1));
                        });
                    };
                    reader.readAsText($scope.dataFile);
                    $scope.visibleValidate = true;
                } else {
                    window.alert($scope.messageValidOfCsv);
                }
            },
            'downloadSampleFile': function () {
                var csvString = $scope.cvsString;
                var filename = $scope.sampleFile;
                var blob = new Blob([csvString], {
                    type: 'text/csv;charset=utf-8;'
                });
                if (navigator.msSaveBlob) { // IE 10+
                    navigator.msSaveBlob(blob, filename);
                } else {
                    var link = document.createElement("a");
                    if (link.download !== undefined) { // feature detection Browsers that support HTML5 download attribute
                        var url = URL.createObjectURL(blob);
                        link.setAttribute("href", url);
                        link.setAttribute("download", filename);
                        link.style.visibility = 'hidden';
                        document.body.appendChild(link);
                        link.click();
                        document.body.removeChild(link);
                    }
                }
            },
            'downloadErrorLogFile': function () {
                var csvString = "";
                csvString = $scope.csvRows.join("\r\n");
                var filename = $scope.errorLogFile;
                var blob = new Blob([csvString], {
                    type: 'text/csv;charset=utf-8;'
                });
                if (navigator.msSaveBlob) { // IE 10+
                    navigator.msSaveBlob(blob, filename);
                } else {
                    var link = document.createElement("a");
                    if (link.download !== undefined) { // feature detection Browsers that support HTML5 download attribute
                        var url = URL.createObjectURL(blob);
                        link.setAttribute("href", url);
                        link.setAttribute("download", filename);
                        link.style.visibility = 'hidden';
                        document.body.appendChild(link);
                        link.click();
                        document.body.removeChild(link);
                    }
                }
            },
            'submit': function () {
                debugger;
                if (!$scope.readyForSubmit) {
                    alert($scope.messageSubmitWithoutFile);
                    return;
                }

                $scope.readyForSubmit = false;

                if ($scope.errorLogs.length > 0) {
                    alert($scope.messageErrorsInFile);
                    return;
                }
                else {
                    ////var inputFileName = $scope.dataFile.name;
                    ////var inputMimeType = "application/csv";
                    ////var inputOrderCaptureId = "";
                    ////var inputEncodedFile = "";
                    //////  psbWorkflowUrl = getConfigValues("PsbRestServiceUrl");
                    ////var workflowServiceUrl = "http://10.103.27.154:6004/api/v1/workflow/AmxPeruBulkIndividualCreation";
                    ////var request = {
                    ////    "request":
                    ////    {
                    ////        "$type": "AmxPeruPSBActivities.Model.AmxPeruBulkIndividualCreationRequest,AmxPeruPSBActivities",

                    ////        "FileName": inputFileName,
                    ////        "MimeType": inputMimeType,
                    ////        "OrderCaptureID": inputOrderCaptureId,
                    ////        "EncodedFile": inputEncodedFile,

                    ////    }
                    ////};

                    ////$.ajax({
                    ////    type: "POST",
                    ////    url: workflowServiceUrl,
                    ////    dataType: "json",
                    ////    data: JSON.stringify(request),
                    ////    contentType: "application/json; charset=utf-8",
                    ////    async: false,
                    ////    cache: false,
                    ////    xhrFields:
                    ////    {
                    ////        withCredentials: true
                    ////    },
                    ////    crossDomain: true,
                    ////    success: function (data) {
                    ////        if (data) {
                    ////            debugger;
                    ////            alert("Bulk Order Items Initiated Successfully");
                    ////        }
                    ////    },
                    ////    error: function (data) {
                    ////        debugger;
                    ////        alert("Bulk Order Items Initiated Failed");
                    ////    }
                    ////});
                        //var reader = new FileReader();
                        //reader.onload = function (e) {
                        //    var contents = e.target.result;
                        //    var encoded_file = btoa(unescape(encodeURIComponent(e.target.result.toString())));
                        //    var objectId = window.parent.Xrm.Page.data.entity.getId();
                        //    var bulkImportExcelUpload = {
                        //        "request": null
                        //    }
                        //    bulkImportExcelUpload = window.createRequest(window.definitions.messages.BulkUploadRequest, bulkImportExcelUpload);
                        //    bulkImportExcelUpload.request["OrderCaptureId"] = objectId;
                        //    bulkImportExcelUpload.request["EncodedFile"] = encoded_file;
                        //    bulkImportExcelUpload.request["FileName"] = $scope.dataFile.name;

                        //    $http.post(window.definitions.url, bulkImportExcelUpload, { "withCredentials": true }).success(function (result) {
                        //        if (result.d !== null) {
                        //            $scope.result = result.d.Message;
                        //        } else {
                        //            $scope.result = $scope.messageRequestIsFailed;
                        //        }
                        //        alert($scope.result);
                        //        var currentBulkOrderId = window.parent.Xrm.Page.data.entity.getId();
                        //        window.parent.Xrm.Utility.openEntityForm("etel_ordercapture", currentBulkOrderId);
                        //    });
                        //}
                        //reader.readAsText($scope.dataFile);
                   // }
                    var reader = new FileReader();
                        reader.onload = function (e) {
                            var contents = e.target.result;
                            var encoded_file = btoa(unescape(encodeURIComponent(e.target.result.toString())));
                            var objectId = window.parent.Xrm.Page.data.entity.getId();
                            
                            var workflowServiceUrl = "http://10.103.27.154:6004/api/v1/workflow/AmxPeruBulkIndividualCreation";
                            var request = {
                                "inputObject":
                                {
                                    "$type": "AmxPeruPSBActivities.Model.AmxPeruBulkIndividualCreationRequest,AmxPeruPSBActivities",

                                    "FileName": $scope.dataFile.name,
                                    "MimeType": "application/csv",
                                    "OrderCaptureID": objectId,
                                    "EncodedFile": encoded_file,

                                }
                            };


                            $.ajax({
                                type: "POST",
                                url: workflowServiceUrl,
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
                                        debugger;
                                        alert("Bulk Order Items Initiated Successfully");
                                    }
                                },
                                error: function (data) {
                                    debugger;
                                    alert("Bulk Order Items Initiated Failed");
                                }
                            });
                    }
                        reader.readAsText($scope.dataFile);
                }
            },
            'increase': function () {
                $scope.firstPage = false;
                var lastPage = Math.ceil(parseFloat($scope.errorLogs.length / $scope.pageSize)) - 1;
                if (lastPage == 0)
                    $scope.lastPage = true;
                else {
                    if ($scope.currentIndex < lastPage) {
                        $scope.currentIndex++;
                        $scope.startIndex = $scope.currentIndex * $scope.pageSize;
                        if ($scope.currentIndex >= lastPage) {
                            $scope.lastPage = true;
                        }
                    }
                }
            },
            'decrease': function () {
                $scope.lastPage = false;
                if ($scope.currentIndex > 1) {
                    $scope.currentIndex--;
                    $scope.startIndex = $scope.currentIndex * $scope.pageSize;
                }
                else if ($scope.currentIndex === 1) {
                    $scope.currentIndex = 0;
                    $scope.startIndex = 0;
                }
                if ($scope.startIndex <= 1) {
                    $scope.firstPage = true;
                    $scope.lastPage = false;
                }
            }
        }

        $scope.scopeData.bulkUpload.translation();
        $scope.scopeData.bulkUpload.initiate();

        window.bulkUploadValidation = function ($scope) {
            $scope.scopeData.bulkUpload.submit();
        };
    });
})(window, angular);