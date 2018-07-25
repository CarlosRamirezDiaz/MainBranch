function initSimpleSearchForm() {
    keyPublisher.subscribe(simpleKeyListener);
    bindSimpleSearchControls();
}
var simpleKeyListener = function (message) {
    switch (message) {
        case 'SIMPLESEARCH':
            doSimpleSearch();
            break;
        case 'SIMPLESEARCHFROMURL':
            doSimpleSearchFromUrl();
            break;
    }
};

function bindSimpleSearchControls() {
    var childs = getCustomerSearchTemplatesWithParentCode('SIMPLESEARCH');
    if (childs != null) {
        childs.forEach(appendLookForOption);
    }
    changeLookFor();
}

function appendLookForOption(template) {
    if (template != null) {
        $('#LookFor')
         .append($("<option>" + template.etel_name + "</option>")
         .attr("value", template.etel_name)
		 .attr("class", "t" + template.etel_name)
		 .attr("data-translate", "t" + template.etel_name)
         .text(template.etel_name));

        templateCache.store(template.etel_name, template);
    }
}

function changeLookFor() {
    var searchField = $('#LookFor').val();

    var template = templateCache.retrieve(searchField);
    $('#childTemplateContainer').empty();

    if (template != null) {
        $('#childTemplateContainer').append(template.etel_htmlcontent);
        appendScriptToElement('#childTemplateContainer', template.etel_scriptcontent);
    }

    setTranslation(translationCustomerSearch.GetData());
}

function doSimpleSearchFromUrl() {
    if (window.parent &&
        window.parent.location &&
        window.parent.location.search &&
        getQueryString() && getQueryString().extraqs) {
        if (getQueryString().extraqs.indexOf("msisdn_") > -1) {
            var msisdn = getQueryString().extraqs.replace("msisdn_", "");
            $('#SearchText').val(msisdn);
            $('#LookFor').val("MSISDN");
            doSimpleSearch();
        }
    }
}

function cleanSimpleSearchForm() {
    $('#LookFor').val("MSISDN").change();
    $('#SearchResultsGrid').datagrid('loadData', { "total": 0, "rows": [] });
}

initSimpleSearchForm();