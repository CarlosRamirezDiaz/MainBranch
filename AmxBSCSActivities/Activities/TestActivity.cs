using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruCommonLibrary;
namespace AmxSoapServicesActivities.Activities

{
    public sealed class TestActivity : XrmAwareCodeActivity
    {
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            string endPoint = "http://localhost:1010/wsi/services/ws_CIL_6_GenericDirectoryNumberSearchService.wsdl";
            string userName = "ADMX";

            // AmxPeruGenericProxy is a proxy class to call WCF services
            // GenericDirectoryNumberSearchService is the auto-generated class, used like an interface
            //using (var proxy = new AmxPeruGenericProxy<GenericDirectoryNumberSearchService>(endPoint, userName))
            //{
            //    var factory = proxy.Channel;
            //    // the request object to sent BSCS (you can see details when you click F12 to class)
            //    var request = new  genericDirectoryNumberSearchRequest();
            //    var inputAttributes = new inputAttributes() {
            //        npcode = 1,
            //        plcode = 1007,
            //        submId = 1,
            //        hlcode = 6,
            //        dntypes = new long[] { 21 },
            //        statuses = new string[] { "r" },
            //        searchCount = "1",
            //        reservation = true
            //    };
            //    request.inputAttributes = inputAttributes;

            //    /*
            //     * genericDirectoryNumberSearchRequest: the simple instance of our request object to sent to BSCS
            //     * factory.genericDirectoryNumberSearch(): the method to retrieve line numbers, accepts request object as parameter
            //     * genericDirectoryNumberSearchResponse: is the response class of number search request
            //     */
            //    var r1 = new genericDirectoryNumberSearchRequest1(request);
            //    var genericDirectoryNumberSearchResponse = factory.genericDirectoryNumberSearch(r1);

            //    //var directoryNumbers = genericDirectoryNumberSearchResponse.directorynumbers;

            //}    
        }
    }
}
