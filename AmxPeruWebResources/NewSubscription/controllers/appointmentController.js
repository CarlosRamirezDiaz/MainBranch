wizard.controller("appointmentController",
    ['$scope', '$http', '$rootScope', '$window', 'uiGridConstants',
        function ($scope, $http, $rootScope, $window, uiGridConstants, uiGridGroupingConstants) {
            var apiUrl = Wizard.Util.configStore.PsbRestServiceUrl;
            $scope.direct = $rootScope.direct; // setting direction for RTL language
            if ($scope.direct === "rtl") { $scope.isRTL = true; }
            else { $scope.isRTL = false; }
            if ($scope.scopeData == null) { $scope.scopeData = {}; }

            if (typeof $rootScope.rootScopeData === "undefined") {
                $rootScope.rootScopeData = {};
            }

            if (typeof $rootScope.rootScopeData.order === "undefined") {
                $rootScope.rootScopeData.order = {};
            }

            if (typeof $rootScope.rootScopeData.appointment === "undefined") {
                $rootScope.rootScopeData.appointment = {};
            }

            getCapacity = function (t) {

                var config = { withCredentials: true };
                angular.element('#calendar').fullCalendar('removeEvents');
                dates = [];
                for (i = 1; i < 8; i++) {
                    var d = new Date(t + (86400000 * i));
                    day = d.getDate();
                    month = d.getMonth() + 1;
                    if (day < 10) { day = "0" + day; }
                    if (month < 10) { month = "0" + month; }
                    dates.push(d.getFullYear() + '-' + (month) + '-' + day);
                }
                if (!$scope.scopeData.appointment.isRequestDateEarlierThanToday(dates))
                    return;

                $scope.workflowStartInput = {};
                $scope.workflowStartInput =
                    {
                        "addressId": $rootScope.rootScopeData.customerInformation.SelectedAddress.AddressId,
                        "orderCaptureId": Xrm.Page.getAttribute("etel_name").getValue(),
                        "sequenceNumber": $rootScope.rootScopeData.order.sequenceNumber,
                        "documentId": "353534", // need to be sent int value belong CRM agent
                        "dates": {
                            "$type": "System.Collections.Generic.List`1[System.String], mscorlib",
                            "$values": dates
                        }
                    };
                $http.post(apiUrl + 'AmxCoGetCapacity', JSON.stringify($scope.workflowStartInput), config)
                    .success(function (result) {
                        if (result) {
                            $scope.scopeData.calendarEvents = [];
                            length = result.Output.calendarEvents.length;
                            var nowTimeSpan = new Date(Date.now());
                            var endTimeSpan;
                            var t = 0;

                            for (var i = 0; i < length; i++) {

                                endTimeSpan = new Date(result.Output.calendarEvents[i].End);

                                if ((endTimeSpan - nowTimeSpan) > 0) {

                                    $scope.scopeData.calendarEvents[t] = {};
                                    $scope.scopeData.calendarEvents[t] =
                                    {
                                        title: result.Output.calendarEvents[i].Title,
                                        start: result.Output.calendarEvents[i].Start,
                                        end: result.Output.calendarEvents[i].End
                                    };
                                    $scope.scopeData.calendarEvents[t].restriction = {};
                                    if (result.Output.calendarEvents[i].Restriction && result.Output.calendarEvents[i].Restriction.Type == "Error") {
                                        $scope.scopeData.calendarEvents[t].backgroundColor = "#ff0000";
                                        $scope.scopeData.calendarEvents[t].title = result.Output.calendarEvents[i].Restriction.Code;
                                        $scope.scopeData.calendarEvents[t].unclickable = true;
                                        $scope.scopeData.calendarEvents[t].description = "No se puede agendar en esta franja";
                                    }
                                    else if (result.Output.calendarEvents[i].AvailableTechnician === 0) {
                                        $scope.scopeData.calendarEvents[t].backgroundColor = "#ff7b00";
                                        $scope.scopeData.calendarEvents[t].unclickable = true;
                                    }
                                    t++;
                                }
                            }

                            angular.element('#calendar').fullCalendar('addEventSource', $scope.scopeData.calendarEvents);
                        }
                    }).error(function (data, status, headers, config) {
                        alert((data.ExceptionMessage === undefined ?
                            (data.data === undefined ? data :
                                (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                        $scope.httpLoading = false;
                    });
            };

            if (typeof $scope.scopeData === "undefined") {
                $scope.scopeData = {};
            }
            var config = {
                withCredentials: true
            };

            $scope.scopeData.appointment = {
                affectedServices: "",
                appoitnmentExternalId: "DNA102",
                otType: "Instalacion enpaquetada bidireccional",
                sla: "36 Horas",
                duration: "45 minutos",
                customerId: Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].id.replace("{", "").replace("}", ""),
                createAppointmentPropertiesFunction: function () {
                    $scope.scopeData.appointment.createAppointmentProperties = [
                        {
                            "attributeName": "activity_notes",
                            "attributeValue": "PRUEBAS DE NUEVA VERSION OFSC"
                        },
                        {
                            "attributeName": "XA_Idcity",
                            "attributeValue": "BOG"
                        },
                        {
                            "attributeName": "XA_FechaCreacion",
                            "attributeValue": $scope.getTodayDate()
                        },
                        {
                            "attributeName": "XA_Regional",
                            "attributeValue": "TVC"
                        },
                        {
                            "attributeName": "XA_TipoOrdenSupervision",
                            "attributeValue": "TC"
                        },
                        {
                            "attributeName": "Node",
                            "attributeValue": "LHS"
                        },
                        {
                            "attributeName": "XA_WorkOrderSubtype",
                            "attributeValue": "IN23"
                        },
                        {
                            "attributeName": "XA_Bucket",
                            "attributeValue": "DNA102"
                        },
                        {
                            "attributeName": "XA_Red",
                            "attributeValue": "Bidireccional"
                        },
                        {
                            "attributeName": "XA_NombreNodo",
                            "attributeValue": "LACHES SANTA BARBARA BIDACTCS"
                        },
                        {
                            "attributeName": "XA_NombreCompleto",
                            "attributeValue": Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].name
                        },
                        {
                            "attributeName": "XA_DireccionActual",
                            "attributeValue": "Calle: CL 3 Placa: 5-31"
                        },
                        {
                            "attributeName": "XA_SLASuscriptor",
                            "attributeValue": "36"
                        },
                        {
                            "attributeName": "XA_EstadoSLA",
                            "attributeValue": "EN CUMPLIMIENTO"
                        },
                        {
                            "attributeName": "XA_IndicadorEstadoSLA",
                            "attributeValue": "C"
                        },
                        {
                            "attributeName": "XA_SLACumplimiento",
                            "attributeValue": "2"
                        },
                        {
                            "attributeName": "XA_IndicadorReincidencias",
                            "attributeValue": "N"
                        },
                        {
                            "attributeName": "XA_TipoOrdenMGW",
                            "attributeValue": "W"
                        },
                        {
                            "attributeName": "XA_HogaresActivos",
                            "attributeValue": "0"
                        },
                        {
                            "attributeName": "XA_EspecialistaComercial",
                            "attributeValue": "CRM User"
                        },
                        {
                            "attributeName": "XA_CodigoEspecialistaComercial",
                            "attributeValue": "007"
                        },
                        {
                            "attributeName": "XA_Prioridad",
                            "attributeValue": "2"
                        },
                        {
                            "attributeName": "XA_Contacto",
                            "attributeValue": "prueba"
                        },
                        {
                            "attributeName": "XA_Telefonouno",
                            "attributeValue": "3214318140"
                        },
                        {
                            "attributeName": "XA_NumeroMarker",
                            "attributeValue": "A09271640"
                        },
                        {
                            "attributeName": "XA_Marker",
                            "attributeValue": "1"
                        },
                        {
                            "attributeName": "XA_Confirmation_Mail",
                            "attributeValue": "0"
                        },
                        {
                            "attributeName": "XA_Telefonodos_Contacto",
                            "attributeValue": "0"
                        },
                        {
                            "attributeName": "XA_Celular",
                            "attributeValue": "0"
                        },
                        {
                            "attributeName": "XA_Celular2",
                            "attributeValue": "VALOR"
                        },
                        {
                            "attributeName": "XA_NombreCorrespondencia",
                            "attributeValue": "prueba"
                        },
                        {
                            "attributeName": "XA_OrigenOrden",
                            "attributeValue": "7"
                        },
                        {
                            "attributeName": "XA_Telefonodos",
                            "attributeValue": 3143256656
                        },
                        {
                            "attributeName": "XA_NumeroReincidenciasOT",
                            "attributeValue": 1
                        },
                        {
                            "attributeName": "XA_NumeroCancelaciones",
                            "attributeValue": 0
                        },
                        {
                            "attributeName": "XA_NumeroReincidenciasServicios",
                            "attributeValue": 0
                        },
                        {
                            "attributeName": "XA_NumeroReincidenciasCalidad",
                            "attributeValue": 0
                        },
                        {
                            "attributeName": "XA_TipoCliente",
                            "attributeValue": "31"
                        },
                        {
                            "attributeName": "XA_Estrato",
                            "attributeValue": "2"
                        },
                        {
                            "attributeName": "XA_NotasUnidad",
                            "attributeValue": "Notas de MGL"
                        },
                        {
                            "attributeName": "XA_EstructuraComercial",
                            "attributeValue": "\n<estructuraComercial><estructura><row>1</row><nivel>4</nivel><codigo>LHS</codigo><descripcion>LACHES SANTA BARBARA BIDACTCS</descripcion></estructura></estructuraComercial>\n"
                        },
                        {
                            "attributeName": "XA_RentaCliente",
                            "attributeValue": "38585.00"
                        },
                        {
                            "attributeName": "XA_Saldo",
                            "attributeValue": "38585.00"
                        },
                        {
                            "attributeName": "XA_UltimoPago",
                            "attributeValue": "38585.00"
                        },
                        {
                            "attributeName": "XA_FechaUltimoPago",
                            "attributeValue": "20170515"
                        },
                        {
                            "attributeName": "XA_InformacionCatastral",
                            "attributeValue": "<InfoCatastral><item1>...................................</item1><item2>SANTAFE</item2><item3>NG - NG - CBU104</item3><item4>...................................</item4></InfoCatastral>"
                        },
                        {
                            "attributeName": "XA_Generico",
                            "attributeValue": "<condicionesEsoeciales ><ítem>CERTA – Certificado Alturas</ítem><ítem>TRAEX– Trabalho Especial</ítem><condicionesEsoeciales >"
                        },
                        {
                            "attributeName": "XA_TipoConstruccion",
                            "attributeValue": "Apartamento"
                        },
                        {
                            "attributeName": "XA_DireccionCorrespondencia",
                            "attributeValue": "CL 1 D SUR 77 05"
                        },
                        {
                            "attributeName": "XA_CantidadServicios",
                            "attributeValue": "2"
                        },
                        {
                            "attributeName": "XA_ServiciosOT",
                            "attributeValue": "<serviciosOt><servicio><row>1</row><codServ>U50</codServ><descripcion>Plan Internet 50 Megas</descripcion><actuales>0</actuales><cambios>1</cambios><rentaMensual>0</rentaMensual><CodActivacion>0</CodActivacion><CobroInstal>1</CobroInstal><TomasTelef>0</TomasTelef><CobroTT>0</CobroTT><TomasTV_Reinst>0</TomasTV_Reinst><CobroTTV_Reinst>0</CobroTTV_Reinst></servicio><servicio><row>2</row><codServ>LTE</codServ><descripcion>Plan Ilimitado Telefonia Fija</descripcion><actuales>0</actuales><cambios>1</cambios><rentaMensual>0</rentaMensual><CodActivacion>0</CodActivacion><CobroInstal>0</CobroInstal><TomasTelef>1</TomasTelef><CobroTT>0</CobroTT><TomasTV_Reinst>0</TomasTV_Reinst><CobroTTV_Reinst>0</CobroTTV_Reinst></servicio><servicio><row>3</row><codServ>PACK_COL_AVANZHD</codServ><descripcion>Plan Avanzada TV</descripcion><actuales>0</actuales><cambios>1</cambios><rentaMensual>0</rentaMensual><CodActivacion>0</CodActivacion><CobroInstal>0</CobroInstal><TomasTelef>0</TomasTelef><CobroTT>0</CobroTT><TomasTV_Reinst>0</TomasTV_Reinst><CobroTTV_Reinst>0</CobroTTV_Reinst></servicio><cobro><TotalRentaMens>0</TotalRentaMens><TotalInstal>3</TotalInstal><TotalTT>1</TotalTT><TotalTTV>1</TotalTTV></cobro></serviciosOt>"
                        },
                        {
                            "attributeName": "XA_ServiciosAfectados",
                            "attributeValue": $scope.scopeData.appointment.affectedServices //"<ServiciosAfectados><Servicio><IdCorto>1</IdCorto><IdProductoEnIntraway>4345345</IdProductoEnIntraway><NombreDelServicio>PACK_COL_AVANZHD</NombreDelServicio><DescripcionDelServicio>Plan Avanzado TV</DescripcionDelServicio><AccionARealizar>Nuevo</AccionARealizar><NumeroDeTomas>1</NumeroDeTomas><CodigoDeActivacion>00000</CodigoDeActivacion></Servicio><Servicio><IdCorto>2</IdCorto><IdProductoEnIntraway>09832j</IdProductoEnIntraway><NombreDelServicio>U50</NombreDelServicio><DescripcionDelServicio>Plan Internet 50 Megas</DescripcionDelServicio><AccionARealizar>Nuevo</AccionARealizar><NumeroDeTomas>1</NumeroDeTomas><CodigoDeActivacion>111111</CodigoDeActivacion></Servicio><Servicio><IdCorto>3</IdCorto><IdProductoEnIntraway>09832j</IdProductoEnIntraway><NombreDelServicio>LTE</NombreDelServicio><DescripcionDelServicio>Oferta Plan Ilimitado Telefonia Fija</DescripcionDelServicio><AccionARealizar>Nuevo</AccionARealizar><NumeroDeTomas>1</NumeroDeTomas><CodigoDeActivacion>22222</CodigoDeActivacion></Servicio>    </ServiciosAfectados>"
                        }

                    ]
                },
                checkIfThereIsCreatedAppointment: function () {
                    var orderCaptureName = Xrm.Page.getAttribute("etel_name").getValue();
                    var req = new XMLHttpRequest();
                    req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_appointmentlogs?$select=amx_workorderid&$filter=startswith(etel_name,'" + orderCaptureName + "')", false);
                    req.setRequestHeader("OData-MaxVersion", "4.0");
                    req.setRequestHeader("OData-Version", "4.0");
                    req.setRequestHeader("Accept", "application/json");
                    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                    req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                    req.onreadystatechange = function () {
                        if (this.readyState === 4) {
                            req.onreadystatechange = null;
                            if (this.status === 200) {
                                var results = JSON.parse(this.response);
                                if (results.value.length > 0) {
                                    $rootScope.rootScopeData.appointment.appointmentCreated = true;
                                    $scope.scopeData.appointment.workOrderId = results.value[0]["amx_workorderid"];
                                }
                            }
                        }
                    };

                    req.send();
                },
                getAffectedServiceDetails: function () {
                    var orderItemGuid = window.parent.Xrm.Page.data.entity.getId();

                    $scope.workflowStartInput = {
                        "orderGuid": orderItemGuid
                    };

                    $http.post(apiUrl + 'GetOrderBasket', JSON.stringify($scope.workflowStartInput), config)
                        .success(function (result) {
                            if (result) {
                                var length = result.Output.orderBasket.listOfOrderBasketOrderItems.length;
                                var xmlString = "<ServiciosAfectados>";
                                var t = 1;
                                var resource = null;
                                for (var i = 0; i < length; i++) {
                                    resource = resource === null ? result.Output.orderBasket.listOfOrderBasketOrderItems[i].ResourceValue : resource;
                                    if (result.Output.orderBasket.listOfOrderBasketOrderItems[i].OfferTypeCode === "10") {
                                        var family = result.Output.orderBasket.listOfOrderBasketOrderItems[i].Family;
                                        if (family === "Telephony") {
                                            family = "Telefonia";
                                        }
                                        xmlString += "<Servicio>";
                                        xmlString += "<IdCorto>" + t + "</IdCorto>";
                                        xmlString += "<NombreDelServicio>" + result.Output.orderBasket.listOfOrderBasketOrderItems[i].ServiceId + "</NombreDelServicio>";
                                        xmlString += "<DescripcionDelServicio>" + result.Output.orderBasket.listOfOrderBasketOrderItems[i].name + "</DescripcionDelServicio>";
                                        xmlString += "<AccionARealizar>" + result.Output.orderBasket.listOfOrderBasketOrderItems[i].OrderItemAction + "</AccionARealizar>";
                                        xmlString += "<NumeroDeTomas>0</NumeroDeTomas>";
                                        if (family === "Telefonia" && resource) {
                                            xmlString += "<linea>" + resource + "</linea>";
                                        }
                                        xmlString += "<Familia>" + family + "</Familia>";
                                        xmlString += "</Servicio>";
                                        t++;
                                        resource = null;
                                    }
                                }
                                xmlString += "</ServiciosAfectados>";
                                $scope.scopeData.appointment.affectedServices = xmlString;
                            }
                        });

                },
                isRequestDateEarlierThanToday: function (dates) {
                    var nowTimeSpan = new Date(Date.now());
                    var lastDateTimeSpan = new Date(dates[6]);
                    var difference = lastDateTimeSpan - nowTimeSpan;// + 86400000;
                    if (difference > 0) {
                        return true;
                    }
                    return false;
                },

            };

            $scope.customerAddressDataArray = [];
            $scope.getCustomerAndAddressData = function (customerId, cusAddressId) {
                $scope.customerAddressDataArray = [];
                var webApiSelectFilters = "etel_customeraddresses?$select=amx_addressid,_amx_cityarea_value,_amxperu_district_value,amxperu_latitude,amxperu_longitude,_etel_cityid_value,_etel_individualcustomerid_value,etel_name&$expand=etel_individualcustomerid($select=etel_accountnumber)&$filter=etel_customeraddressid eq " + cusAddressId + " and  _etel_individualcustomerid_value eq " + customerId;
                AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                    for (var i = 0; i < results.value.length; i++) {
                        var amx_addressid = results.value[i]["etel_customeraddressid"];
                        var _amx_cityarea_value = results.value[i]["_amx_cityarea_value"];
                        var _amx_cityarea_value_formatted = results.value[i]["_amx_cityarea_value@OData.Community.Display.V1.FormattedValue"];
                        var _amx_cityarea_value_lookuplogicalname = results.value[i]["_amx_cityarea_value@Microsoft.Dynamics.CRM.lookuplogicalname"];
                        var _amxperu_district_value = results.value[i]["_amxperu_district_value"];
                        var _amxperu_district_value_formatted = results.value[i]["_amxperu_district_value@OData.Community.Display.V1.FormattedValue"];
                        var _amxperu_district_value_lookuplogicalname = results.value[i]["_amxperu_district_value@Microsoft.Dynamics.CRM.lookuplogicalname"];
                        var amxperu_latitude = results.value[i]["amxperu_latitude"];
                        var amxperu_longitude = results.value[i]["amxperu_longitude"];
                        var _etel_cityid_value = results.value[i]["_etel_cityid_value"];
                        var _etel_cityid_value_formatted = results.value[i]["_etel_cityid_value@OData.Community.Display.V1.FormattedValue"];
                        var _etel_cityid_value_lookuplogicalname = results.value[i]["_etel_cityid_value@Microsoft.Dynamics.CRM.lookuplogicalname"];
                        var _etel_individualcustomerid_value = results.value[i]["_etel_individualcustomerid_value"];
                        var _etel_individualcustomerid_value_formatted = results.value[i]["_etel_individualcustomerid_value@OData.Community.Display.V1.FormattedValue"];
                        var _etel_individualcustomerid_value_lookuplogicalname = results.value[i]["_etel_individualcustomerid_value@Microsoft.Dynamics.CRM.lookuplogicalname"];
                        var etel_name = results.value[i]["etel_name"];
                        //Use @odata.nextLink to query resulting related records
                        var accountNumber = results.value[i]["etel_individualcustomerid"].etel_accountnumber;

                        $scope.customerAddressDataArray.push({
                            customername: _etel_individualcustomerid_value_formatted,
                            customernumber: accountNumber,
                            addressname: etel_name, addressid: cusAddressId,
                            cityname: _etel_cityid_value_formatted, cityid: _etel_cityid_value,
                            statename: _amxperu_district_value_formatted,
                            latitude: amxperu_latitude, longitude: amxperu_longitude
                        });
                        break;
                    }
                }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
            };

            $scope.customerContactInfoDataArray = {};
            $scope.getCustomerContactInfoData = function (customerId) {
                var webApiSelectFilters = "amx_customercontactinformations?$select=amx_contacttype,_amx_individualcustomerid_value,amx_phoneno,amx_primarycontacttype&$filter=(amx_contacttype eq 173800001 or  amx_contacttype eq 173800002) and  statecode eq 0 and  amx_primarycontacttype eq true and  _amx_individualcustomerid_value eq " + customerId;
                AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                    for (var i = 0; i < results.value.length; i++) {
                        var amx_contacttype = results.value[i]["amx_contacttype"];
                        var _amx_individualcustomerid_value = results.value[i]["_amx_individualcustomerid_value"];
                        var amx_phoneno = results.value[i]["amx_phoneno"];
                        if (amx_contacttype == 173800001) { $scope.customerContactInfoDataArray.cellno = amx_phoneno; }
                        if (amx_contacttype == 173800002) { $scope.customerContactInfoDataArray.phoneno = amx_phoneno; }
                    }
                }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
                if ($scope.customerContactInfoDataArray.cellno == undefined) { $scope.customerContactInfoDataArray.cellno = ""; }
                if ($scope.customerContactInfoDataArray.phoneno == undefined) { $scope.customerContactInfoDataArray.phoneno = ""; }
            };

            $scope.cityCode = "";
            $scope.getCityCode = function (cityId) {
                var webApiSelectFilters = "etel_cities?$select=etel_cityid,etel_code,etel_name&$filter=etel_cityid eq " + cityId;
                AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                    for (var i = 0; i < results.value.length; i++) {
                        var etel_code = results.value[i]["etel_code"];
                        $scope.cityCode = etel_code;
                        break;
                    }
                }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
            };

            $scope.appStartDate = null; $scope.appEndDate = null;
            $scope.createTCRMAppointmentLog = function (woId) {
                var customerId = Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].id.replace("{", "").replace("}", "");
                var entity = {};
                entity.amx_address = $scope.customerAddressDataArray.length > 0 ? $scope.customerAddressDataArray[0].addressname : "";
                entity["amx_AddressId@odata.bind"] = $scope.customerAddressDataArray.length > 0 ? "/etel_customeraddresses(" + $scope.customerAddressDataArray[0].addressid.replace("{", "").replace("}", "") + ")" : null;
                entity.amx_appointmentnumber = Xrm.Page.getAttribute("etel_name").getValue() + "_" + ($rootScope.rootScopeData.order.sequenceNumber);
                entity.amx_duration = "60";
                entity.etel_externalid = "DNA102";
                entity.amx_timeslot = $scope.timeSlot;
                entity.amx_workflowordersubtype = "INT";
                entity.amx_workorderid = woId;
                entity.etel_name = Xrm.Page.getAttribute("etel_name").getValue() + "_" + ($rootScope.rootScopeData.order.sequenceNumber);
                entity["etel_individualcustomerid@odata.bind"] = "/contacts(" + customerId + ")";
                entity.amx_confirmationstatus = 173800001;//pending
                entity.etel_appointmentstatus = 831260008;//open
                entity.etel_appointmentdate = $scope.appStartDate;//new Date("12/22/2017 07:00:00").toISOString();
                entity.etel_appointmentclosedate = $scope.appEndDate;//new Date("12/22/2017 10:00:00").toISOString();
                //to update special conditions field
                entity.amx_specialconditions = $scope.specialConditions;
                //logic to update Third Person details
                if (chkThirdperson.checked) {
                    entity.amx_thirdpersonassigned = $rootScope.Thirdpersonassigned;
                    entity.amx_thirdpersoncontactname = $rootScope.Name;
                    entity.amx_thirdpersoncontactphonenumber1 = $rootScope.Telephone1;
                    entity.amx_thirdpersoncontactphonenumber2 = $rootScope.Telephone2;
                    entity.amx_thirdpersoncontactemail1 = $rootScope.Email1;
                    entity.amx_thirdpersoncontactemail2 = $rootScope.Email2;
                }
                AMX.COMMON.CreateEntiyWebApi("etel_appointmentlogs", entity, function (sData) {
                    // Updating appointment log to all order items 
                    var config = { withCredentials: true };

                    $scope.workflowStartInput = {
                        "orderId": Xrm.Page.data.entity.getId().substring(1).substring(0, 36),
                        "appointmentId": sData
                    };

                    $http.post(apiUrl + 'AmxCoUpdateOrderItemAppointment', JSON.stringify($scope.workflowStartInput), config)
                        .success(function (result) {
                            if (result) {

                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                            $scope.httpLoading = false;
                        });

                }, function (eData) { parent.Xrm.Utility.alertDialog(eData) }, false);
            };

            $scope.formatTime = function (date_obj) {
                // formats a javascript Date object into a 12h AM/PM time string
                var hour = date_obj.getHours();
                var minute = date_obj.getMinutes();
                var amPM = (hour > 11) ? "PM" : "AM";
                if (hour > 12) {
                    hour -= 12;
                } else if (hour == 0) {
                    hour = "12";
                }
                if (minute < 10) {
                    minute = "0" + minute;
                }
                return hour + ":" + minute + amPM;
            };

            $scope.getFormatHours = function (dateHourObj) {
                var resDate = dateHourObj > 0 && dateHourObj < 10 ? "0" + dateHourObj : dateHourObj;
                return resDate;
            };

            $scope.getTodayDate = function () {
                var today = new Date();
                var dd = today.getDate();
                var mm = today.getMonth() + 1; //January is 0!
                var yyyy = today.getFullYear();

                if (dd < 10) {
                    dd = '0' + dd
                }

                if (mm < 10) {
                    mm = '0' + mm
                }

                return yyyy + "-" + mm + "-" + dd;
            };

            $scope.timeSlot = "";
            //Adding Third Person details
            $scope.appointmentInfo = function () {
                if (chkThirdperson.checked) {
                    //Logic to open html page
                    var url = window.parent.Xrm.Page.context.getClientUrl() + "/WebResources/amx_/appointmentContactInformation/html/appointmentContactInformation.htm?Data=";
                    var DialogOption = new Xrm.DialogOptions;
                    DialogOption.width = 670; DialogOption.height = 600;
                    Xrm.Internal.openDialog(url, DialogOption, null, null, CallbackFunction);
                    function CallbackFunction(returnValue) {
                        if (returnValue != null) {
                            var Data = returnValue;
                            var dataArray = new Array();
                            dataArray = Data.split(",");
                            $rootScope.Name = dataArray[0];
                            $rootScope.Telephone1 = dataArray[1];
                            $rootScope.Telephone2 = dataArray[2];
                            $rootScope.Email1 = dataArray[3];
                            $rootScope.Email2 = dataArray[4];
                            $rootScope.Thirdpersonassigned = true;
                        }
                        else {
                            $rootScope.Name = "";
                            $rootScope.Telephone1 = "";
                            $rootScope.Telephone2 = "";
                            $rootScope.Email1 = "";
                            $rootScope.Email2 = "";
                            $rootScope.Thirdpersonassigned = false;
                            document.getElementById("chkThirdperson").checked = false;
                        }
                    }
                }
            }
            //function to update CustomerContactInformation
            $scope.updateCustomerContactInformation = function () {
                var customerId = Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].id.substr(1, 36);
                var entity = {};
                if (chkEmail.checked) {
                    entity.amxperu_allowemail = 1;
                }
                else {
                    entity.amxperu_allowemail = 2;
                }
                if (chkPhone.checked) {
                    entity.amxperu_allowphone = 1;
                }
                else {
                    entity.amxperu_allowphone = 2;
                }
                if (chkSMS.checked) {
                    entity.amxperu_allowsmsinstantmessaging = 1;
                }
                else {
                    entity.amxperu_allowsmsinstantmessaging = 2;
                }

                var req = new XMLHttpRequest();
                req.open("PATCH", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/contacts( " + customerId + " )", false);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 204) {
                            //Success - No Return Data - Do Something
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send(JSON.stringify(entity));
            }
            //function to get the Customer Contact Information
            $scope.getCustometData = function (customerId) {
                var webApiSelectFilters = "contacts?$select=amxperu_allowemail,amxperu_allowphone,amxperu_allowsmsinstantmessaging&$filter=contactid eq " + customerId;
                AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                    if (results.value.length != 0) {
                        var amxperu_allowemail = results.value[0]["amxperu_allowemail"];
                        var amxperu_allowphone = results.value[0]["amxperu_allowphone"];
                        var amxperu_allowsmsinstantmessaging = results.value[0]["amxperu_allowsmsinstantmessaging"];
                        if (amxperu_allowemail == 1) {
                            document.getElementById("chkEmail").checked = true;
                        }
                        else {
                            document.getElementById("chkEmail").checked = false;
                        }
                        if (amxperu_allowphone == 1) {
                            document.getElementById("chkPhone").checked = true;
                        }
                        else {
                            document.getElementById("chkPhone").checked = false;
                        }
                        if (amxperu_allowsmsinstantmessaging == 1) {
                            document.getElementById("chkSMS").checked = true;
                        }
                        else {
                            document.getElementById("chkSMS").checked = false;
                        }
                    }
                },
                    function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
            };
            //function to get the Work Order type
            $scope.getWorkOrderType = function (appointmentNo) {
                var webApiSelectFilters = "amx_ordercaptureactivities?$select=amx_subtipotrabajo&$filter=amx_appointmentnumber eq " + "'" + appointmentNo + "'";
                AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                    if (results.value.length != 0) {
                        var amx_subtipotrabajo = results.value[0]["amx_subtipotrabajo"];
                        //$scope.amx_subtipotrabajo = amx_subtipotrabajo.replace(/\s/g, "");
                        $scope.mapWorkOrderTypeValue(amx_subtipotrabajo);
                        $scope.getSpecialConditions($scope.workOrderTypevalue);
                    }
                },
                    function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
            };
            //function to map the WorkOrderTypeValue
            $scope.mapWorkOrderTypeValue = function (amx_subtipotrabajo) {
                switch (amx_subtipotrabajo) {
                    case "Instalacion Empaquetada Bidireccional":
                        $scope.workOrderTypevalue = 1;
                        break;
                    case "Instalacion Cableada Bidireccional":
                        $scope.workOrderTypevalue = 2;
                        break;
                    case "Instalacion Unidireccional":
                        $scope.workOrderTypevalue = 3;
                        break;
                    case "Instalacion Hotspot":
                        $scope.workOrderTypevalue = 4;
                        break;
                    case "Instalacion Pymes":
                        $scope.workOrderTypevalue = 5;
                        break;
                    case "Instalacion Basica Bidireccional":
                        $scope.workOrderTypevalue = 6;
                        break;
                    case "Instalacion Basica Dth":
                        $scope.workOrderTypevalue = 7;
                        break;
                    case "Instalacion Empaquetada Dth":
                        $scope.workOrderTypevalue = 8;
                        break;
                    case "Instalacion Basica Ftth":
                        $scope.workOrderTypevalue = 9;
                        break;
                    case "Instalacion Empaquetada Ftth":
                        $scope.workOrderTypevalue = 10;
                        break;
                    case "Instalacion Um Destino":
                        $scope.workOrderTypevalue = 11;
                        break;
                    case "Instalacion Um Punto Central":
                        $scope.workOrderTypevalue = 12;
                        break;
                    case "Instalacion Ultima Milla Movil":
                        $scope.workOrderTypevalue = 13;
                        break;
                    case "Visita Tecnica":
                        $scope.workOrderTypevalue = 14;
                        break;
                    case "Entrega De Servicio":
                        $scope.workOrderTypevalue = 15;
                        break;
                    case "Reinstalacion Dth":
                        $scope.workOrderTypevalue = 16;
                        break;
                    case "Reinstalacion Hfc":
                        $scope.workOrderTypevalue = 17;
                        break;
                    case "Reinstalacion Ftth":
                        $scope.workOrderTypevalue = 18;
                        break;
                    case "Reinstalacion Umfo":
                        $scope.workOrderTypevalue = 19;
                        break;
                    case "Reinstalacion Datacenter":
                        $scope.workOrderTypevalue = 20;
                        break;
                    case "Cambio Tecnologia":
                        $scope.workOrderTypevalue = 21;
                        break;
                    case "Cambio Servicio Dth":
                        $scope.workOrderTypevalue = 22;
                        break;
                    case "Cambio Servicio Hfc":
                        $scope.workOrderTypevalue = 23;
                        break;
                    case "Cambio Servicio Ftth":
                        $scope.workOrderTypevalue = 24;
                        break;
                    case "Cambio Servicio Umfo":
                        $scope.workOrderTypevalue = 25;
                        break;
                    case "Migracion Dth":
                        $scope.workOrderTypevalue = 26;
                        break;
                    case "Migracion Hfc":
                        $scope.workOrderTypevalue = 27;
                        break;
                    case "Migracion Ftth":
                        $scope.workOrderTypevalue = 28;
                        break;
                    case "Cambio de Acceso":
                        $scope.workOrderTypevalue = 29;
                        break;
                    case "Puntos Adicionales":
                        $scope.workOrderTypevalue = 30;
                        break;
                    case "DX Fisica Cartera":
                        $scope.workOrderTypevalue = 31;
                        break;
                    case "DX Fisica Seguridad":
                        $scope.workOrderTypevalue = 32;
                        break;
                    case "DX Fisica Sds":
                        $scope.workOrderTypevalue = 33;
                        break;
                    case "Dx Fisica por Cancelación":
                        $scope.workOrderTypevalue = 34;
                        break;
                    case "RX Fisica por Cartera":
                        $scope.workOrderTypevalue = 35;
                        break;
                    case "RX Fisica por Seguridad":
                        $scope.workOrderTypevalue = 36;
                        break;
                    case "RX Fisica por Descongelación":
                        $scope.workOrderTypevalue = 37;
                        break;
                    case "Arreglo Bidireccional":
                        $scope.workOrderTypevalue = 38;
                        break;
                    case "Arreglo Dth":
                        $scope.workOrderTypevalue = 39;
                        break;
                    case "Arreglo Unidireccional":
                        $scope.workOrderTypevalue = 40;
                        break;
                    case "Arreglos Home Networking":
                        $scope.workOrderTypevalue = 41;
                        break;
                    case "Visita Mejoramiento Servicio":
                        $scope.workOrderTypevalue = 42;
                        break;
                    case "Arreglo N&E Fibra":
                        $scope.workOrderTypevalue = 43;
                        break;
                    case "Arreglo N&E Dth":
                        $scope.workOrderTypevalue = 44;
                        break;
                    case "Arreglos N&E Hfc":
                        $scope.workOrderTypevalue = 45;
                        break;
                    case "Entrega Equipos Especiales":
                        $scope.workOrderTypevalue = 46;
                        break;
                    case "Entrega Equipos":
                        $scope.workOrderTypevalue = 47;
                        break;
                    case "Traslado Dth":
                        $scope.workOrderTypevalue = 48;
                        break;
                    case "Traslado Bidireccional":
                        $scope.workOrderTypevalue = 49;
                        break;
                    case "Traslado Unidireccional":
                        $scope.workOrderTypevalue = 50;
                        break;
                    case "Traslado Pymes":
                        $scope.workOrderTypevalue = 51;
                        break;
                    case "Traslado Ftth":
                        $scope.workOrderTypevalue = 52;
                        break;
                    case "Traslado Um Destino":
                        $scope.workOrderTypevalue = 53;
                        break;
                    case "Traslado  Um Punto Central":
                        $scope.workOrderTypevalue = 54;
                        break;
                    case "Retiro De Equipos":
                        $scope.workOrderTypevalue = 55;
                        break;
                    case "Devoluciones":
                        $scope.workOrderTypevalue = 56;
                        break;
                    case "Garantia":
                        $scope.workOrderTypevalue = 57;
                        break;

                    default:
                        $scope.workOrderTypevalue = 1;
                }

            }
            //function to get Special Conditions
            $scope.getSpecialConditions = function (amx_subtipotrabajo) {
                var webApiSelectFilters = "amx_specialconditionsots?$select=amx_description&$filter=amx_workordertype eq " + $scope.workOrderTypevalue;
                AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
                    $scope.specialConditions = "";
                    for (var i = 0; i < results.value.length; i++) {
                        var amx_description = results.value[i]["amx_description"];

                        $scope.specialConditions += results.value[i]["amx_description"] + ";"

                        $scope.checkSpecialConditions(amx_description);
                    }
                },
                    function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
            };
            //function to select the Special conditions checkbox dynamically
            $scope.checkSpecialConditions = function (amx_description) {
                switch (amx_description) {
                    case "Trabajo Express":
                        document.getElementById("chkTrabajoExpress").checked = true;
                        break;
                    case "Certificado de Alturas":
                        document.getElementById("chkCertificadodeAlturas").checked = true;
                        break;
                    case "Carta de Autorización de trabajos Insfraestructura (Codensa)":
                        document.getElementById("chkCartadeAutorizacion").checked = true;
                        break;
                    case "Carnet de ARL":
                        document.getElementById("chkCarnetdeARL").checked = true;
                        break;
                    case "Carnet de EPS":
                        document.getElementById("chkCarnetdeEPS").checked = true;
                        break;
                    case "Carnet de Claro":
                        document.getElementById("chkCarnetdeClaro").checked = true;
                        break;
                    default:
                        document.getElementById("chkTrabajoExpress").checked = true;
                }
            }
            //Get SMS Template for CreatedAppointment
            $scope.getCreatedAppointmentSMSTemplate = function (operation) {
                var req = new XMLHttpRequest();
                req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/amxperu_smstemplates?$select=amxperu_templatetext&$filter=amxperu_name eq " + "'" + operation + "'", true);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 200) {
                            var results = JSON.parse(this.response);
                            if (results.value.length != 0) {
                                var amxperu_templatetext = results.value[0]["amxperu_templatetext"];
                                amxperu_templatetext = amxperu_templatetext.replace("{{etel_appointmentlog:amx_appointmentnumber}}", $scope.scopeData.appointment.apptNumber);
                                amxperu_templatetext = amxperu_templatetext.replace("{{etel_appointmentlog:etel_appointmentdate}}", $scope.appStartDate);
                                $scope.amxperu_templatetext = amxperu_templatetext.replace("{{etel_appointmentlog:amx_timeslot}}", $scope.timeSlot);

                            }
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send();
            }
            //Get Customer Contact Information
            $scope.getContactInformation = function () {
                var req = new XMLHttpRequest();
                req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/amx_customercontactinformations?$select=amx_email,amx_name,amx_phoneno&$filter=_amx_individualcustomerid_value eq " + $scope.customerId, false);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 200) {
                            var results = JSON.parse(this.response);
                            if (results.value.length != 0) {
                                $scope.Email = results.value[0]["amx_email"];
                                $scope.Mobile = results.value[0]["amx_phoneno"];
                                var amx_name = results.value[0]["amx_name"];
                            }
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send();
            }
            //Get Customer Contact Allow Permissions
            $scope.getCustomerContactAllowPermissions = function () {
                var req = new XMLHttpRequest();
                req.open("GET", Xrm.Page.context.getClientUrl() + "/api/data/v8.2/contacts?$select=amxperu_allowemail,amxperu_allowphone,amxperu_allowsmsinstantmessaging&$filter=contactid eq " + $scope.customerId, false);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                req.onreadystatechange = function () {
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 200) {
                            var results = JSON.parse(this.response);
                            if (results.value.length != 0) {
                                $scope.amxperu_allowemail = results.value[0]["amxperu_allowemail@OData.Community.Display.V1.FormattedValue"];
                                $scope.amxperu_allowphone = results.value[0]["amxperu_allowphone@OData.Community.Display.V1.FormattedValue"];
                                $scope.amxperu_allowsmsinstantmessaging = results.value[0]["amxperu_allowsmsinstantmessaging@OData.Community.Display.V1.FormattedValue"];

                            }
                        } else {
                            Xrm.Utility.alertDialog(this.statusText);
                        }
                    }
                };
                req.send();
            }
            //Send notifications to the customer when appointment is created
            $scope.torreDeControl = function () {
                //Sending Both SMS and Email Notifications
                if (($scope.Email != null) && ($scope.Mobile != null)) {
                    var config = { withCredentials: true };
                    $scope.workflowStartInput = {
                        "request": {
                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest, AmxPeruPSBActivities",
                            "pushType": "SINGLE",//hardcoded
                            "typeCostumer": $scope.customerId,//customerId
                            "messageBox": [
                                {
                                    "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxExt, AmxPeruPSBActivities",
                                    "messageChannel": "SMS",
                                    "messageBox": [
                                        {
                                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxInt, AmxPeruPSBActivities",
                                            "customerId": $scope.customerId,//customerId
                                            "customerBox": $scope.Mobile//phn number11111
                                        }
                                    ]
                                },
                                {
                                    "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxExt, AmxPeruPSBActivities",
                                    "messageChannel": "SMTP",
                                    "messageBox": [
                                        {
                                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxInt, AmxPeruPSBActivities",
                                            "customerId": $scope.customerId, //customerId
                                            "customerBox": $scope.Email //EmailIDhelder@ericsson.com
                                        }
                                    ]
                                }
                            ],
                            "profileId": ["SMTP_FS_TCRM1", "SMS_FS_TCRM1"],
                            "communicationType": ["REGULATORIO"],
                            "communicationOrigin": "TCRM",
                            "deliveryReceipts": "NO",
                            "contentType": "MESSAGE",
                            "messageContent": $scope.amxperu_templatetext
                        }
                    }

                    $http.post(apiUrl + 'AmxCoTorreDeControl', JSON.stringify($scope.workflowStartInput), config)
                        .success(function (result) {
                            if (result) {
                                if (result.Output.response.isValid = "true") {
                                    $scope.response = result.Output.response.message;
                                    if ($scope.response != null) {
                                        alert("Customer Notifications sent successfully");
                                        $scope.createBiLog();
                                    }
                                    else {
                                        alert("Notifications are not sent due to an error in the TorreDeControl");
                                    }
                                }
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                        });

                }
                //Sending Email Notifications
                if (($scope.Email != null) && ($scope.Mobile == null)) {
                    var config = { withCredentials: true };
                    $scope.workflowStartInput = {
                        "request": {
                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest, AmxPeruPSBActivities",
                            "pushType": "SINGLE",//hardcoded
                            "typeCostumer": $scope.customerId,//customerId
                            "messageBox": [
                                {
                                    "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxExt, AmxPeruPSBActivities",
                                    "messageChannel": "SMTP",
                                    "messageBox": [
                                        {
                                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxInt, AmxPeruPSBActivities",
                                            "customerId": $scope.customerId, //customerId
                                            "customerBox": $scope.Email //EmailIDhelder@ericsson.com
                                        }
                                    ]
                                }
                            ],
                            "profileId": ["SMTP_FS_TCRM1", "SMS_FS_TCRM1"],
                            "communicationType": ["REGULATORIO"],
                            "communicationOrigin": "TCRM",
                            "deliveryReceipts": "NO",
                            "contentType": "MESSAGE",
                            "messageContent": $scope.amxperu_templatetext
                        }
                    }
                    $http.post(apiUrl + 'AmxCoTorreDeControl', JSON.stringify($scope.workflowStartInput), config)
                        .success(function (result) {
                            if (result) {
                                if (result.Output.response.isValid = "true") {
                                    $scope.response = result.Output.response.message;
                                    if ($scope.response != null) {
                                        alert("Customer Email Notifications sent successfully");
                                        $scope.createBiLog();
                                    }
                                    else {
                                        alert("Notifications are not sent due to an error in the TorreDeControl");
                                    }
                                }
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                        });
                }
                //Sending SMS Notifications
                if (($scope.Mobile != null) && ($scope.Email == null)) {
                    var config = { withCredentials: true };
                    $scope.workflowStartInput = {
                        "request": {
                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest, AmxPeruPSBActivities",
                            "pushType": "SINGLE",//hardcoded
                            "typeCostumer": $scope.customerId,//customerId
                            "messageBox": [
                                {
                                    "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxExt, AmxPeruPSBActivities",
                                    "messageChannel": "SMS",
                                    "messageBox": [
                                        {
                                            "$type": "AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest+AmxCoMessageBoxInt, AmxPeruPSBActivities",
                                            "customerId": $scope.customerId,//customerId
                                            "customerBox": $scope.Mobile//phn number11111
                                        }
                                    ]
                                }
                            ],
                            "profileId": ["SMTP_FS_TCRM1", "SMS_FS_TCRM1"],
                            "communicationType": ["REGULATORIO"],
                            "communicationOrigin": "TCRM",
                            "deliveryReceipts": "NO",
                            "contentType": "MESSAGE",
                            "messageContent": $scope.amxperu_templatetext
                        }
                    }

                    $http.post(apiUrl + 'AmxCoTorreDeControl', JSON.stringify($scope.workflowStartInput), config)
                        .success(function (result) {
                            if (result) {
                                if (result.Output.response.isValid = "true") {
                                    $scope.response = result.Output.response.message;
                                    if ($scope.response != null) {
                                        alert("Customer SMS Notifications sent successfully");
                                        $scope.createBiLog();
                                    }
                                    else {
                                        alert("Notifications are not sent due to an error in the TorreDeControl");
                                    }
                                }
                            }
                        }).error(function (data, status, headers, config) {
                            alert((data.ExceptionMessage === undefined ?
                                (data.data === undefined ? data :
                                    (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));

                        });
                }
                else {
                    alert("Customer did not provide either Email or Phone number");

                }
            }
            //BI Log Creation for Customer Notifications
            $scope.createBiLog = function () {
                var entity = {};
                entity.amx_name = "Appointment Created" + "-" + Xrm.Page.getAttribute("etel_name").getValue() + "_" + ($rootScope.rootScopeData.order.sequenceNumber);
                entity.amx_notificationtemplate = $scope.amxperu_templatetext;
                AMX.COMMON.CreateEntiyWebApi("amx_bicustomernotificationses", entity, function (sData) {
                    var entityId = sData;
                    var entity = {};
                    entity.subject = "Appointment Created" + "-" + Xrm.Page.getAttribute("etel_name").getValue() + "_" + ($rootScope.rootScopeData.order.sequenceNumber);
                    entity.etel_description = "Appointment Created" + "-" + Xrm.Page.getAttribute("etel_name").getValue() + "_" + ($rootScope.rootScopeData.order.sequenceNumber);
                    entity["regardingobjectid_amx_bicustomernotifications@odata.bind"] = "/amx_bicustomernotificationses(" + entityId + ")";
                    entity["etel_individualcustomerid_etel_bi_log@odata.bind"] = "/contacts(" + $scope.customerId + ")";
                    var currentDateTime = new Date();
                    entity.actualstart = currentDateTime;
                    entity.actualend = currentDateTime;
                    //setting customer field on Bi Log 
                    var activityparties = [];
                    var to = {};
                    to["partyid_contact@odata.bind"] = "/contacts(" + $scope.customerId + ")";
                    to["participationtypemask"] = 11;
                    activityparties.push(to);
                    entity["etel_bi_log_activity_parties"] = activityparties;
                    AMX.COMMON.CreateEntiyWebApi("etel_bi_logs", entity, function (oData) {
                        var entityId = oData;

                    },
                        function (eData) { parent.Xrm.Utility.alertDialog(eData) }, false);
                },
                    function (eData) { parent.Xrm.Utility.alertDialog(eData) }, false);
            }

            var initiate = function () {
                $scope.customerId = Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].id.replace("{", "").replace("}", "");
                $scope.resumeInput.data = {};
                $scope.scopeData.calendarEvents = [];
                $scope.scopeData.appointment.apptNumber = Xrm.Page.getAttribute("etel_name").getValue() + "_" + ($rootScope.rootScopeData.order.sequenceNumber);
                $scope.scopeData.appointment.selectedAddressName = ($rootScope.rootScopeData.customerInformation && $rootScope.rootScopeData.customerInformation.SelectedAddress) ? $rootScope.rootScopeData.customerInformation.SelectedAddress.AddressName : "";
                $scope.scopeData.appointment.translations = Wizard.GetTranslationData("NewSubscriptionAppointment");
                $scope.scopeData.appointment.getAffectedServiceDetails();


                angular.element('#calendar').fullCalendar({
                    header: {
                        left: 'prev,next',
                        center: 'title',
                        right: ''
                    },
                    defaultDate: $scope.getTodayDate(),
                    navLinks: true, // can click day/week names to navigate views
                    selectable: false,
                    eventClick: function (event) {

                        if (event.unclickable) {
                            return;
                        }

                        $scope.scopeData.appointment.checkIfThereIsCreatedAppointment();
                        if ($rootScope.rootScopeData.appointment.appointmentCreated) {
                            alert("An appointment has been created for this order. Workorder item is : " + $scope.scopeData.appointment.workOrderId);
                            return;
                        }
                        $scope.appStartDate = new Date(event.start._i);
                        $scope.appEndDate = new Date(event.end._i);
                        day = $scope.appStartDate.getDate();
                        month = $scope.appStartDate.getMonth() + 1;
                        if (day < 10) { day = "0" + day; }
                        if (month < 10) { month = "0" + month; }
                        var appDate = day + "/" + (month) + "/" + $scope.appStartDate.getFullYear();
                        var appStart = $scope.appStartDate.getHours() + ":00";
                        var appEnd = $scope.appEndDate.getHours() + ":00";
                        var confirmMessage = $scope.scopeData.appointment.translations.tAppointmentConfirm;
                        confirmMessage = confirmMessage.replace("{{appDate}}", appDate);
                        confirmMessage = confirmMessage.replace("{{appStart}}", appStart);
                        confirmMessage = confirmMessage.replace("{{appEnd}}", appEnd);

                        if (confirm(confirmMessage)) {

                            $(this).css('background-color', 'green');

                            // ------------- APP CREATION REQ CALL ----------------- //
                            var config = { withCredentials: true };
                            $scope.timeSlot = $scope.getFormatHours($scope.appStartDate.getHours()) + "-" + $scope.getFormatHours($scope.appEndDate.getHours());
                            var customerId = Xrm.Page.getAttribute("etel_individualcustomerid").getValue()[0].id.replace("{", "").replace("}", "");
                            var customerAddressId = null;
                            if ($rootScope.rootScopeData.customerInformation && $rootScope.rootScopeData.customerInformation.SelectedAddress) {
                                customerAddressId = $rootScope.rootScopeData.customerInformation.SelectedAddress.AddressId;
                            }
                            if (customerId != null && customerAddressId != null) {
                                $scope.getCustomerAndAddressData(customerId, customerAddressId);
                                $scope.getCustomerContactInfoData(customerId);
                                if ($scope.customerAddressDataArray[0].cityid != undefined) { $scope.getCityCode($scope.customerAddressDataArray[0].cityid); }
                            }

                            $scope.scopeData.appointment.createAppointmentPropertiesFunction();
                            $scope.workflowStartInput = {
                                "createAppRequest":
                                {
                                    "$type": "AmxPeruPSBActivities.Model.Appointment.CreateAppointmentRequestModel, AmxPeruPSBActivities",
                                    "headerRequest": { "$type": "AmxPeruPSBActivities.Model.Appointment.Header, AmxPeruPSBActivities", "transactionId": "12345679", "system": "PRUEBA", "user": "YFONSECA", "password": "PRUEBA", "requestDate": "2017-11-01T14:20:45", "ipApplication": "PRUEBA", "traceabilityId": "PRUEBA" },
                                    "dateOrder": $scope.appStartDate.getFullYear() + "-" + ("0" + ($scope.appStartDate.getMonth() + 1)).slice(-2) + "-" + day,
                                    "commands": {
                                        "$type": "System.Collections.Generic.List`1[[AmxPeruPSBActivities.Model.Appointment.Commands, AmxPeruPSBActivities]], mscorlib",
                                        "$values": [{
                                            "externalId": "DNA102",
                                            "appointment": {
                                                "$type": "AmxPeruPSBActivities.Model.Appointment.AppointmentModel, AmxPeruPSBActivities",
                                                "apptNumber": Xrm.Page.getAttribute("etel_name").getValue() + "_" + ($rootScope.rootScopeData.order.sequenceNumber),
                                                "customerNumber": $scope.customerAddressDataArray[0] ? $scope.customerAddressDataArray[0].customernumber.replace(/\D/g, '') : "",
                                                "workTypeLabel": "INT",
                                                "slaWindowStart": "2017-09-20",
                                                "slaWindowEnd": "2017-09-20",
                                                "timeSlot": $scope.timeSlot,//event.timeslot
                                                "name": $scope.customerAddressDataArray[0] ? $scope.customerAddressDataArray[0].customername : "",
                                                "email": "@",
                                                "duration": "60", "cell": $scope.customerContactInfoDataArray.cellno, "phone": $scope.customerContactInfoDataArray.phoneno,
                                                "address": $scope.customerAddressDataArray[0] ? $scope.customerAddressDataArray[0].addressname.substr(0, 50) : "",
                                                "city": $scope.customerAddressDataArray[0] ? $scope.customerAddressDataArray[0].cityname.substr(0, 6) : "",
                                                "state": $scope.customerAddressDataArray[0] ? $scope.customerAddressDataArray[0].statename : "",
                                                "zip": $scope.cityCode,
                                                "points": "",
                                                "coordX": $scope.customerAddressDataArray[0] ? ($scope.customerAddressDataArray[0].latitude == undefined ? "" : $scope.customerAddressDataArray[0].latitude) : "",
                                                "coordY": $scope.customerAddressDataArray[0] ? ($scope.customerAddressDataArray[0].longitude == undefined ? "" : $scope.customerAddressDataArray[0].longitude) : "",
                                                "properties": {
                                                    "$type": "System.Collections.Generic.List`1[[AmxPeruPSBActivities.Model.Appointment.Fog, AmxPeruPSBActivities]], mscorlib",
                                                    "$values": $scope.scopeData.appointment.createAppointmentProperties
                                                }
                                            }
                                        }]
                                    }
                                }

                            };
                            $http.post(apiUrl + 'AmxCoCreateAppointment', JSON.stringify($scope.workflowStartInput), config)
                                .success(function (result) {
                                    if (result && result.Output.createAppointmentResponse.commandsResponse) {
                                        appointmentNumber = result.Output.createAppointmentResponse.commandsResponse[0].appointmentResponse.aid;
                                        $rootScope.rootScopeData.appointment.appointmentCreated = true;
                                        alert($scope.scopeData.appointment.translations.tAppointmentCreated + appointmentNumber);
                                        var operation = "createdAppointment";
                                        $scope.getCreatedAppointmentSMSTemplate(operation);
                                        $scope.createTCRMAppointmentLog(appointmentNumber);
                                        //Send notifications to the customer when appointment is created
                                        if ((($scope.amxperu_allowemail == "Allow") || ($scope.amxperu_allowsmsinstantmessaging == "Allow")) || (($scope.amxperu_allowemail == "Allow") && ($scope.amxperu_allowsmsinstantmessaging == "Allow"))) {
                                            $scope.torreDeControl();
                                        }
                                    }
                                    else {

                                        alert($scope.scopeData.appointment.translations.tAppointmentUnsucsessful);
                                    }
                                }).error(function (data, status, headers, config) {
                                    alert((data.ExceptionMessage === undefined ?
                                        (data.data === undefined ? data :
                                            (data.data.ExceptionMessage === undefined ? data.data : data.data.ExceptionMessage)) : data.ExceptionMessage));
                                    $scope.httpLoading = false;
                                });

                            // ------------- APP CREATION REQ CALL ----------------- //
                        }
                        else {
                            alert($scope.scopeData.appointment.translations.tAppointmentStopped);
                        }
                        return false;
                    },
                    selectHelper: false,
                    editable: false,
                    eventLimit: false, // allow "more" link when too many events
                    events: $scope.scopeData.calendarEvents
                });

                var d = new Date();
                getCapacity(d.getTime() - 86400000);

                $scope.getCustometData($scope.customerId);
                $scope.appointmentNo = "ORDMD0002268_36";
                $scope.getWorkOrderType($scope.appointmentNo);
                $scope.getCustomerContactAllowPermissions();
                $scope.getContactInformation();

            };

            initiate();
        }]);