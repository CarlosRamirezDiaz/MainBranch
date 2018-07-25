using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public static class constants
    {
        #region [Programming Purpose]
        public static string IndividualCreationEntityName = "tclab_individualcreation";
        public static string CorporateCreationEntityName = "tclab_corporatecreation";
        public static string EntityLogicalNameFinancialAgreement = "amxbase_financialagreement";
        #endregion

        #region [Translation Required]
        public static string PluginErrorMessagePrefix = "AmxPeru TCRM Plugin Error : <Start>";
        public static string PluginErrorMessagePostfix = "AmxPeru TCRM Plugin Error : <End>";
        public static string MultipleValuesFound = "Multiple Configuration Values Found With Same Key : ";
        public static string BiLogSubjecct_UpdateCustomerAddress = "Customer Address Update";
        public static string BiLogDescription_UpdateCustomerAddress = "Channel - Internal/External - TCRM PlugIn";
        #endregion

        #region [FetchXmls & SoapBody]
        public static string SoapXmlText = @"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:add='http://ericsson.com/services/ws_CIL_7/addresswrite' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>
                                       <soapenv:Header/>
                                       <soapenv:Body>
                                          <add:addressWriteRequest>
                                             <add:inputAttributes>
                                                <add:adrStreet>{0}</add:adrStreet>
                                                <add:adrStreetno>{1}</add:adrStreetno>                      
                                                <add:adrState>{2}</add:adrState>
                                                <add:adrPhn1Area>{3}</add:adrPhn1Area>
                                                <add:adrPhn1>{4}</add:adrPhn1>
                                                <add:adrZip>{5}</add:adrZip>
                                                <add:countryId>{6}</add:countryId>
                                                <add:adrCity>{7}</add:adrCity>
                                                <add:csIdPub>{8}</add:csIdPub>
                                                <add:adrSeq>{9}</add:adrSeq>
                                             </add:inputAttributes>
                                             <add:sessionChangeRequest>
                                                <ses:values>
                                                   <ses:item>
                                                      <ses:key>BU_ID</ses:key>
                                                      <ses:value>2</ses:value>
                                                   </ses:item>
                                                </ses:values>
                                             </add:sessionChangeRequest>
                                          </add:addressWriteRequest>
                                       </soapenv:Body>
                                    </soapenv:Envelope>
                                    ";
        #endregion
    }
}
