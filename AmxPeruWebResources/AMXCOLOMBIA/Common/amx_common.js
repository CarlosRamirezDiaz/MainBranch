if (typeof (AMX) == "undefined") {
    AMX = { __namespace: true };
}

AMX.COMMON = {
    RetrieveCrmConfiguration: function (keyName) {
        var configValue;
        var fetchXml = "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"
            + "<entity name='etel_crmconfiguration'>"
            + "<attribute name='etel_name'/>"
            + "<attribute name='etel_value'/>"
            + "<filter type='and'>"
            + "<condition attribute='etel_name' value='" + keyName + "' operator='eq'/>"
            + "</filter>"
            + "</entity>"
            + "</fetch>";
        var configRecord = XrmServiceToolkit.Soap.Fetch(fetchXml);
        if (configRecord.length > 0) {
            if (configRecord[0].attributes.etel_crmconfigurationid != undefined) {
                if (configRecord[0].attributes.etel_value != null &&
                    configRecord[0].attributes.etel_value != undefined) {
                    configValue = configRecord[0].attributes.etel_value.value;
                }
            }
        }
        else {
            alert('Error: The Key ' + keyName + ' could not be found in AMX Configuration');
        }
        return configValue;
    },

    RetrieveCrmEntity: function (fetchXml, outField, entityName) {
        var entityValue;
        var entityRecord = XrmServiceToolkit.Soap.Fetch(fetchXml);
        if (entityRecord.length > 0) {
            if (entityRecord[0].attributes[outField] != null &&
                entityRecord[0].attributes[outField] != undefined) {
                entityValue = entityRecord[0].attributes[outField].value;
            }
        }
        else {
            //alert('Error while retrieving ' + entityName + " records");
        }
        return entityValue;
    },

    RetrieveKBArticleByTitle: function (titleName) {
        var message = null;
        var fetchKBArticle = "<fetch version='1.0' output-format='xml- platform' mapping='logical' distinct='false'>" +
            "<entity name= 'kbarticle' >" +
            "<attribute name='title' />" +
            "<attribute name='articlexml' />" +
            "<filter type='and'>" +
            "<condition attribute='title' operator='eq' value='" + titleName + "' />" +
            "</filter></entity></fetch>";
        var fetchResult = XrmServiceToolkit.Soap.Fetch(fetchKBArticle);
        if (fetchResult.length > 0) {
            if (fetchResult[0].attributes.articlexml != null) {
                var message = fetchResult[0].attributes.articlexml.value;
                var xmlDoc = $.parseXML(message);
                $xml = $(xmlDoc);
                $title = $xml.find("section")[0].textContent
                message = $title;
            }
        }
        return message;
    },

    CreateEntity: function (entityName, entityObject, successCallback, errorCallback, async) {
        var jsonEntity = JSON.stringify(entityObject);
        //OData URI
        var oDataURI = Xrm.Page.context.getClientUrl()
            + "/XRMServices/2011/OrganizationData.svc/" + entityName + "Set";
        var createRecordReq = new XMLHttpRequest();
        createRecordReq.open("POST", oDataURI, false);
        createRecordReq.setRequestHeader("Accept", "application/json");
        createRecordReq.setRequestHeader("Content-Type", "application/json; charset=utf-8");

        createRecordReq.onreadystatechange = function () {
            if (this.readyState == 4 /* complete */) {
                createRecordReq.onreadystatechange = null; //avoids memory leaks
                if (this.status == 201) {
                    successCallback(JSON.parse(createRecordReq.responseText).d);
                }
                else {
                    errorCallback("Error: " + createRecordReq.responseText);
                }
            }
        };
        createRecordReq.send(jsonEntity);
    },

    SetAttributeValue: function (attribute, value) {
        Xrm.Page.getAttribute(attribute).setValue(value);
        Xrm.Page.getAttribute(attribute).setSubmitMode("always");
    },

    SetCorrectAttributeValue: function (entityObj, selectedRowData, crmField, mglField, dataType) {
        switch (dataType) {
            case "string":
                entityObj[crmField] = selectedRowData[mglField] == undefined || selectedRowData[mglField] == null || selectedRowData[mglField] == "" ? "" : selectedRowData[mglField].toString();
                break;
            case "decimal":
                entityObj[crmField] = selectedRowData[mglField] == undefined || selectedRowData[mglField] == null || selectedRowData[mglField] == "" ? null : selectedRowData[mglField];
                break;
            case "int":
                entityObj[crmField] = selectedRowData[mglField] == undefined || selectedRowData[mglField] == null || selectedRowData[mglField] == "" ? null : selectedRowData[mglField];
                break;
            case "datetime":
                entityObj[crmField] = selectedRowData[mglField] == undefined || selectedRowData[mglField] == null || selectedRowData[mglField] == "" ? "" : new Date(selectedRowData[mglField]);
                break;
            case "boolean":
                entityObj[crmField] = selectedRowData[mglField] == undefined || selectedRowData[mglField] == null || selectedRowData[mglField] == "" ? false : selectedRowData[mglField];
                break;
            default:
                entityObj[crmField] = null;
                break;
        }
    },

    ShowHideAttribute: function (attribute, flag) {
        Xrm.Page.getControl(attribute).setVisible(flag);
    },

    ShowHideSection: function (tabName, sectionName, flag) {
        Xrm.Page.ui.tabs.get(tabName).sections.get(sectionName).setVisible(flag);
    },

    RetrieveCrmConfigurationWebApi: function (keyName, successCallback, errorCallback, async) {
        var req = new XMLHttpRequest();
        req.open("GET", parent.Xrm.Page.context.getClientUrl() + "/api/data/v8.2/etel_crmconfigurations?$select=etel_value&$filter=etel_name eq '" + keyName + "'", false);
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
                    for (var i = 0; i < results.value.length; i++) {
                        var etel_value = results.value[i]["etel_value"];
                        successCallback(etel_value);
                        break;
                    }
                } else {
                    errorCallback(this.statusText);
                }
            }
        };
        req.send();
    },

    RetrieveMultipleWebApi: function (webApiSelectFilters, successCallback, errorCallback, async) {
        var results = null;
        var req = new XMLHttpRequest();
        req.open("GET", parent.Xrm.Page.context.getClientUrl() + "/api/data/v8.2/" + webApiSelectFilters, async);
        req.setRequestHeader("OData-MaxVersion", "4.0");
        req.setRequestHeader("OData-Version", "4.0");
        req.setRequestHeader("Accept", "application/json");
        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
        req.onreadystatechange = function () {
            if (this.readyState === 4) {
                req.onreadystatechange = null;
                if (this.status === 200) {
                    results = JSON.parse(this.response);
                    successCallback(results);
                } else {
                    errorCallback(this.statusText);
                }
            }
        };
        req.send();
    },

    CreateEntiyWebApi: function (webApiEntityName, entityObj, successCallback, errorCallback, async) {
        var entityId = null;
        var req = new XMLHttpRequest();
        req.open("POST", parent.Xrm.Page.context.getClientUrl() + "/api/data/v8.2/" + webApiEntityName, async);
        req.setRequestHeader("OData-MaxVersion", "4.0");
        req.setRequestHeader("OData-Version", "4.0");
        req.setRequestHeader("Accept", "application/json");
        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        req.onreadystatechange = function () {
            if (this.readyState === 4) {
                req.onreadystatechange = null;
                if (this.status === 204) {
                    var uri = this.getResponseHeader("OData-EntityId");
                    var regExp = /\(([^)]+)\)/;
                    var matches = regExp.exec(uri);
                    entityId = matches[1];
                    successCallback(entityId);
                } else {
                    errorCallback(this.statusText);
                    //Xrm.Utility.alertDialog(this.statusText);
                }
            }
        };
        req.send(JSON.stringify(entityObj));
    },

    UpdateEntityWebApi: function (webApiEntityName, webApiEntityId, entityObj, successCallback, errorCallback, async) {
        var req = new XMLHttpRequest();
        req.open("PATCH", parent.Xrm.Page.context.getClientUrl() + "/api/data/v8.2/" + webApiEntityName + "(" + webApiEntityId.replace("{", "").replace("}", "") + ")", async);
        req.setRequestHeader("OData-MaxVersion", "4.0");
        req.setRequestHeader("OData-Version", "4.0");
        req.setRequestHeader("Accept", "application/json");
        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        req.onreadystatechange = function () {
            if (this.readyState === 4) {
                req.onreadystatechange = null;
                if (this.status === 204) {
                    //Success - No Return Data - Do Something
                    successCallback(webApiEntityId);
                } else {
                    errorCallback(this.statusText);
                }
            }
        };
        req.send(JSON.stringify(entityObj));
    },

    SetMGLTechnicalDetailsEntityObj: function (selectedRowData, mglTechDetailObj, customerAddressId) {
        //Array list for general section
        for (var i = 1; i < AMX.COMMON.Arrays.MGLTechDetailsAttributeCollection.length; i++) {
            var attrCollArray = AMX.COMMON.Arrays.MGLTechDetailsAttributeCollection[i].split(';');
            AMX.COMMON.SetCorrectAttributeValue(mglTechDetailObj, selectedRowData, attrCollArray[0], attrCollArray[1], attrCollArray[2]);
        }
        mglTechDetailObj["amx_CustomerAddressId@odata.bind"] = "/etel_customeraddresses(" + customerAddressId + ")";
        //Array list for Split Address
        var selectedSplitAddress = selectedRowData.splitAddres;
        if (selectedSplitAddress != undefined && selectedSplitAddress != null && selectedSplitAddress != "") {
            for (var y = 0; y < AMX.COMMON.Arrays.MGLSplitAddressAttributeCollection.length; y++) {
                var attrCollArray = AMX.COMMON.Arrays.MGLSplitAddressAttributeCollection[y].split(';');
                AMX.COMMON.SetCorrectAttributeValue(mglTechDetailObj, selectedSplitAddress, attrCollArray[0], attrCollArray[1], attrCollArray[2]);
            }
        }
    },

    SetMGLListCoverEntityObj: function (selectedListCover, mglListCoverObj, mglTechDetailId) {
        for (var x = 1; x < AMX.COMMON.Arrays.MGLListCoverAttributeCollection.length; x++) {
            var attrCollArray = AMX.COMMON.Arrays.MGLListCoverAttributeCollection[x].split(';');
            AMX.COMMON.SetCorrectAttributeValue(mglListCoverObj, selectedListCover, attrCollArray[0], attrCollArray[1], attrCollArray[2]);
        }
        mglListCoverObj["amx_MGLTechnicalDetailsId@odata.bind"] = "/amx_bimgltechnicaldetailses(" + mglTechDetailId.replace("{", "").replace("}", "") + ")";

    },

    SetMGLListHhppsEntityObj: function (selectedListHhpps, mglListHhppsObj, selectedSubCcmmTechnology, mglTechDetailId) {
        //Array list for General Section
        for (var a = 1; a < AMX.COMMON.Arrays.MGLListHhppsAttributeCollection.length; a++) {
            var attrCollArray = AMX.COMMON.Arrays.MGLListHhppsAttributeCollection[a].split(';');
            AMX.COMMON.SetCorrectAttributeValue(mglListHhppsObj, selectedListHhpps, attrCollArray[0], attrCollArray[1], attrCollArray[2]);
        }
        //Array list for Node Section
        if (selectedListHhpps.node != undefined && selectedListHhpps.node != null && selectedListHhpps.node != "") {
            var selectedListHhppsNode = selectedListHhpps.node;
            for (var b = 0; b < AMX.COMMON.Arrays.MGLListHhppsNodeAttributeCollection.length; b++) {
                var attrCollArray = AMX.COMMON.Arrays.MGLListHhppsNodeAttributeCollection[b].split(';');
                AMX.COMMON.SetCorrectAttributeValue(mglListHhppsObj, selectedListHhppsNode, attrCollArray[0], attrCollArray[1], attrCollArray[2]);
            }
        }
        //Array list for Viability Section
        var selectedListHhppsViability = null;
        if (selectedListHhpps.viability != undefined && selectedListHhpps.viability != null && selectedListHhpps.viability != "") {
            selectedListHhppsViability = selectedListHhpps.viability;
            for (var c = 0; c < AMX.COMMON.Arrays.MGLListHhppsViabilityAttributeCollection.length; c++) {
                var attrCollArray = AMX.COMMON.Arrays.MGLListHhppsViabilityAttributeCollection[c].split(';');
                AMX.COMMON.SetCorrectAttributeValue(mglListHhppsObj, selectedListHhppsViability, attrCollArray[0], attrCollArray[1], attrCollArray[2]);
            }
        }
        //Array list for SubCcmmTechnology Section
        selectedSubCcmmTechnology = selectedListHhpps.subCcmmTechnology;
        var selectedOtherAddrList = null;
        if (selectedListHhpps.subCcmmTechnology != undefined && selectedListHhpps.subCcmmTechnology != null && selectedListHhpps.subCcmmTechnology != "") {
            for (var d = 0; d < AMX.COMMON.Arrays.MGLListHhppsSubCcmmTechnologyAttributeCollection.length; d++) {
                var attrCollArray = AMX.COMMON.Arrays.MGLListHhppsSubCcmmTechnologyAttributeCollection[d].split(';');
                AMX.COMMON.SetCorrectAttributeValue(mglListHhppsObj, selectedSubCcmmTechnology, attrCollArray[0], attrCollArray[1], attrCollArray[2]);
            }
            var selectedTechnologyCcmmNode = selectedSubCcmmTechnology.tecnologyCcmmNode;
            if (selectedTechnologyCcmmNode != undefined && selectedTechnologyCcmmNode != null && selectedTechnologyCcmmNode != "") {
                for (var e = 0; e < AMX.COMMON.Arrays.MGLListHhppsTechnologyCcmmNodeAttributeCollection.length; e++) {
                    var attrCollArray = AMX.COMMON.Arrays.MGLListHhppsTechnologyCcmmNodeAttributeCollection[e].split(';');
                    AMX.COMMON.SetCorrectAttributeValue(mglListHhppsObj, selectedTechnologyCcmmNode, attrCollArray[0], attrCollArray[1], attrCollArray[2]);
                }
            }
        }
        mglListHhppsObj["amx_MGLListHhppsId@odata.bind"] = "/amx_bimgltechnicaldetailses(" + mglTechDetailId.replace("{", "").replace("} ", "") + ")";

    },

    SetMGLOtherAddressListEntityObj: function (selectedOtherAddrList, mglOtherAddrListObj, mglListHhppsId) {
        for (var i = 1; i < AMX.COMMON.Arrays.MGLOtherAddrListAttributeCollection.length; i++) {
            var attrCollArray = AMX.COMMON.Arrays.MGLOtherAddrListAttributeCollection[i].split(';');
            AMX.COMMON.SetCorrectAttributeValue(mglOtherAddrListObj, selectedOtherAddrList, attrCollArray[0], attrCollArray[1], attrCollArray[2]);
        }
        mglOtherAddrListObj["amx_MGLListHhppsId@odata.bind"] = "/amx_bimgllisthhppses(" + mglListHhppsId.replace("{", "").replace("}", "") + ")";

    },

    SetMGLViabilityMessagesEntityObj: function (selectedViabilityMessages, mglViabilityMessagesObj, mglListHhppsId) {
        for (var i = 1; i < AMX.COMMON.Arrays.MGLVmessageAttributeCollection.length; i++) {
            var attrCollArray = AMX.COMMON.Arrays.MGLVmessageAttributeCollection[i].split(';');
            AMX.COMMON.SetCorrectAttributeValue(mglViabilityMessagesObj, selectedViabilityMessages, attrCollArray[0], attrCollArray[1], attrCollArray[2]);
        }
        mglViabilityMessagesObj["amx_MGLListHhppsId@odata.bind"] = "/amx_bimgllisthhppses(" + mglListHhppsId.replace("{", "").replace("}", "") + ")";
    },

    CreateMGLMarks: function (relatedEntityRef, mglListHhppsId, selectedMGLMarks) {
        var mglMarksObj = {};
        for (var i = 0; i < selectedMGLMarks.length; i++) {
            for (var j = 1; j < AMX.COMMON.Arrays.MGLMarksAttributeCollection.length; j++) {
                var attrCollArray = AMX.COMMON.Arrays.MGLMarksAttributeCollection[j].split(';');
                AMX.COMMON.SetCorrectAttributeValue(mglMarksObj, selectedMGLMarks[i], attrCollArray[0], attrCollArray[1], attrCollArray[2]);
            }
            mglMarksObj[relatedEntityRef + "@odata.bind"] = "/amx_bimgllisthhppses(" + mglListHhppsId.replace("{", "").replace("}", "") + ")";
            AMX.COMMON.CreateEntiyWebApi("amx_mglmarkses", mglMarksObj, function (sData) { }, function (eData) { parent.Xrm.Utility.alertDialog(eData) }, false);
        }
    },

    UpdateMGLMarks: function (relatedEntityRef, mglListHhppsId, amx_mglmarksid, selectedMGLMarks) {
        var mglMarksObj = {};
        for (var i = 0; i < selectedMGLMarks.length; i++) {
            for (var j = 1; j < AMX.COMMON.Arrays.MGLMarksAttributeCollection.length; j++) {
                var attrCollArray = AMX.COMMON.Arrays.MGLMarksAttributeCollection[j].split(';');
                AMX.COMMON.SetCorrectAttributeValue(mglMarksObj, selectedMGLMarks[i], attrCollArray[0], attrCollArray[1], attrCollArray[2]);
            }
            mglMarksObj[relatedEntityRef + "@odata.bind"] = "/amx_bimgllisthhppses(" + mglListHhppsId.replace("{", "").replace("}", "") + ")";
            AMX.COMMON.UpdateEntiyWebApi("amx_mglmarkses", amx_mglmarksid, mglMarksObj, function (sData) { }, function (eData) { parent.Xrm.Utility.alertDialog(eData) }, false);
        }
    },

    GetBIHeader: function (userId, successCallback, errorCallback) {
        var webApiSelectFilters = "etel_bi_headers?$select=activityid,_etel_accountid_value,_etel_individualcustomerid_value&$filter=_ownerid_value eq " + userId.replace("{", "").replace("}", "") + " and  etel_headerstatus eq true";
        AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (results) {
            successCallback(results);
        }, function (eData) { errorCallback(eData); }, false);
    },

    CloseBIHeader: function (entityId, url) {
        var entity = {};
        entity.etel_headerstatus = false;
        entity.statecode = 0;
        entity.statuscode = 1;
        entity.etel_biheaderendtime = new Date();
        AMX.COMMON.UpdateEntityWebApi("etel_bi_headers", entityId.replace("{", "").replace("}", ""), entity, function (sData) { }, function (eData) { parent.Xrm.Utility.alertDialog(eData); }, false);
    },

    GetKbArticle: function (webApiSelectFilters, successCallback, errorCallback, mode) {
        AMX.COMMON.RetrieveMultipleWebApi(webApiSelectFilters, function (response) {
            if (response.value[0].articlexml != null && response.value[0].articlexml != undefined) {
                var message = response.value[0].articlexml;
                var xmlDoc = $.parseXML(message);
                $xml = $(xmlDoc);
                $title = $xml.find("section")[0].textContent;
                message = $title;
                successCallback(message);
            }
        }, function (error) {
            errorCallback(error);
        }, mode);
    },

    CallPSBWorflow: function (reqType, url, workflowInput, successCallBack, errorCallBack, executionMode) {

        if (!reqType)
            reqType = "POST";

        if (!url.toLowerCase().startsWith("http"))
            url = Xrm.Page.context.getClientUrlForInteractioncentricDashboard() + ":6004/api/v1/workflow/" + url;

        if (!errorCallBack)
            errorCallBack = AMX.COMMON.callPSBWorflow_errorCallback;

        $.ajax({
            type: reqType,
            url: url,
            dataType: "json",
            data: JSON.stringify(workflowInput),
            contentType: "application/json; charset=utf-8",
            async: executionMode,
            cache: false,
            xhrFields:
            {
                withCredentials: true
            },
            crossDomain: true,
            success: function (data) {
                successCallBack(data);
            },
            error: function (error) {
                errorCallBack(error);
            }
        });
    },

    callPSBWorflow_errorCallback : function(data)
    {

    },

    __namespace: true
}
AMX.COMMON.Arrays = {
    MGLTechDetailsAttributeCollection: ['amx_bimgltechnicaldetailses', 'amx_stratum;stratum;string', 'amx_addressid;addressId;string', 'amx_igacaddress;igacAddress;string', 'amx_name;igacAddress;string','amx_listcarriercover;listCarrierCover;string'],
    MGLSplitAddressAttributeCollection: ['amx_barrio;barrio;string','amx_bisviageneradora;bisViaGeneradora;string', 'amx_bisviaprincipal;bisViaPrincipal;string', 'amx_cptiponivel1;cpTipoNivel1;string', 'amx_cptiponivel2;cpTipoNivel2;string', 'amx_cptiponivel3;cpTipoNivel3;string', 'amx_cptiponivel4;cpTipoNivel4;string', 'amx_cptiponivel5;cpTipoNivel5;string', 'amx_cptiponivel6;cpTipoNivel6;string', 'amx_cpvalornivel1;cpValorNivel1;string', 'amx_cpvalornivel2;cpValorNivel2;string', 'amx_cpvalornivel3;cpValorNivel3;string', 'amx_cpvalornivel4;cpValorNivel4;string', 'amx_cpvalornivel5;cpValorNivel5;string', 'amx_cpvalornivel6;cpValorNivel6;string', 'amx_cuadviageneradora;cuadViaGeneradora;string', 'amx_cuadviaprincipal;cuadViaPrincipal;string',
        'amx_dirprincalt;dirPrincAlt;string', 'amx_estadodirgeo;estadoDirGeo;string', 'amx_iddircatastro;idDirCatastro;string', 'amx_idtipodireccion;idTipoDireccion;string', 'amx_ittipoplaca;itTipoPlaca;string', 'amx_itvalorplaca;itValorPlaca;string', 'amx_letra3g;letra3G;string', 'amx_ltviageneradora;ltViaGeneradora;string', 'amx_ltviaprincipal;ltViaPrincipal;string', 'amx_mztiponivel1;mzTipoNivel1;string', 'amx_mztiponivel2;mzTipoNivel2;string', 'amx_mztiponivel3;mzTipoNivel3;string', 'amx_mztiponivel4;mzTipoNivel4;string', 'amx_mztiponivel5;mzTipoNivel5;string', 'amx_mztiponivel6;mzTipoNivel6;string', 'amx_mzvalornivel1;mzValorNivel1;string', 'amx_mzvalornivel2;mzValorNivel2;string', 'amx_mzvalornivel3;mzValorNivel3;string',
        'amx_mzvalornivel4;mzValorNivel4;string', 'amx_mzvalornivel5;mzValorNivel5;string', 'amx_mzvalornivel6;mzValorNivel6;string', 'amx_nlpostviag;nlPostViaG;string', 'amx_nlpostviap;nlPostViaP;string', 'amx_numviageneradora;numViaGeneradora;string', 'amx_numviaprincipal;numViaPrincipal;string', 'amx_placadireccion;placaDireccion;string', 'amx_tipoviageneradora;tipoViaGeneradora;string', 'amx_tipoviaprincipal;tipoViaPrincipal;string'],
    MGLListCoverAttributeCollection: ['amx_mgllistcovers', 'amx_name;node;string','amx_technology;technology;string'],
    MGLListHhppsAttributeCollection: ['amx_bimgllisthhppses', 'amx_name;hhppId;string','amx_state;state;string', 'amx_nodename;nodeName;string', 'amx_technology;technology;string', 'amx_constructiontype;constructionType;string', 'amx_rushtype;rushtype;string'],
    MGLListHhppsNodeAttributeCollection: ['amx_nodestate;state;string', 'amx_nodename;nodeName;string', 'amx_nodetechnology;technology;string', 'amx_nodequalificationdate;qualificationDate;datetime', 'amx_codenode;codeNode;string'],
    MGLListHhppsViabilityAttributeCollection: ['amx_resultadovalidacion;resultadoValidacion;boolean', 'amx_viability;codRespuesta;string', 'amx_mensajerespuesta;mensajeRespuesta;string', 'amx_nombreproyecto;nombreProyecto;string'],
    MGLListHhppsSubCcmmTechnologyAttributeCollection: ['amx_subbuildingname;subBuildingName;string', 'amx_subccmmid;subCcmmId;string', 'amx_subccmmtechnology;technology;string', 'amx_subccmmtechnologyid;subCcmmTechnologyId;string', 'amx_subccmmtechqualificationdate;qualificationDate;datetime', 'amx_subccmmtechstate;state;string',
        'amx_buildingname;buildingName;string', 'amx_ccmmid;ccmmId;string', 'amx_addresseswithservice;addressesWithService;int', 'amx_buildingaddress;buildingAddress;string', 'amx_buildingcontact;buildingContact;string', 'amx_elevatorcompany;elevatorCompany;string', 'amx_managementcompany;managementCompany;string', 'amx_phonecontactone;phoneContactOne;string', 'amx_phonecontacttwo;phoneContactTwo;string', 'amx_typedistribution;typeDistribution;string'],
    MGLListHhppsTechnologyCcmmNodeAttributeCollection: ['amx_ccmmnodename;nodeName;string', 'amx_ccmmnodestate;state;string', 'amx_ccmmnodetecnology;technology;string', 'amx_ccmmqualificationdate;qualificationDate;datetime', 'amx_ccmmcodenode;codeNode;string'],
    MGLMarksAttributeCollection: ['amx_mglmarkses', 'amx_name;markId;string', 'amx_descriptionmark;descriptionMark;string'],
    MGLVmessageAttributeCollection: ['amx_mglviabilitymessages', 'amx_codigo;codigo;string', 'amx_descripcion;descripcion;string', 'amx_name;mensaje;string', 'amx_tabla;tabla;string', 'amx_viabilidad;viabilidad;string'],
    MGLOtherAddrListAttributeCollection: ['amx_mglotheraddresslists','amx_name;address;string'],
}