using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxSoapServicesActivities.XmlStrings
{
    public class GenericDirectoryNumberRequestXml
    {
        public string GetXmlrequest(string npcode, string plcode, string submId, string hlcode, string dnCode, string dnStatus, string seasearchCount, bool reservation)
        {
            string soaprequest = string.Empty;
            string buId = "BU_ID";
            int sesValue = 2;
            soaprequest = "<soapenv:Envelope xmlns:gen='http://ericsson.com/services/ws_CIL_6/genericdirectorynumbersearch' xmlns:ses='http://ericsson.com/services/ws_CIL_6/sessionchange' xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/'>" +
                               "<soapenv:Header>" +
                               "<wsse:Security soapenv:mustUnderstand = '1' xmlns:wsse = 'http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:wsu = 'http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd'>" +
                               "<wsse:UsernameToken wsu:Id = 'UsernameToken-93CA9BF932EDF3392415202327943042' >" +
                               "<wsse:Username > ADMX </wsse:Username>" +
                               "<wsse:Password Type = 'http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText'> ADMX </wsse:Password>" +
                               "<wsse:Nonce EncodingType = 'http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary'> bERw7xQMWR + SDxCXuXQWnQ ==</wsse:Nonce>" +
                               "<wsu:Created>2018-03-05T06:53:14.304Z</wsu:Created>" +
                               "</wsse:UsernameToken>" +
                               "</wsse:Security>" +
                               "</soapenv:Header>" +
                               "<soapenv:Body>" +
                               "<gen:genericDirectoryNumberSearchRequest>" +
                               "<gen:inputAttributes>" +
                               "<gen:npcode>" + npcode + "</gen:npcode>" +
                               "<gen:npcodePub></gen:npcodePub>" +
                               "<gen:plcode>" + plcode + "</gen:plcode>" +
                               "<gen:plcodePub></gen:plcodePub>" +
                               "<gen:dirnum></gen:dirnum>" +
                               "<gen:submId>" + submId + "</gen:submId>" +
                               "<gen:submIdPub></gen:submIdPub>" +
                               "<gen:hlcode>" + hlcode + "</gen:hlcode>" +
                               "<gen:hlcodePub></gen:hlcodePub>" +
                               "<gen:hmcode></gen:hmcode>" +
                               "<gen:hmcodePub></gen:hmcodePub>" +
                               "<gen:vpnId></gen:vpnId>" +
                               "<gen:vpnIdPub></gen:vpnIdPub>" +
                               "<gen:prefix></gen:prefix>" +
                               "<gen:publicDnNum></gen:publicDnNum>" +
                               "<gen:publicNpcode></gen:publicNpcode>" +
                               "<gen:publicNpcodePub></gen:publicNpcodePub>" +
                               "<gen:sncode></gen:sncode>" +
                               "<gen:sncodePub></gen:sncodePub>" +
                               "<gen:requiredMappingRule></gen:requiredMappingRule>" +
                               "<gen:searchBlock></gen:searchBlock>" +
                               "<gen:minBlkSize></gen:minBlkSize>" +
                               "<gen:maxBlkSize></gen:maxBlkSize>" +
                               "<gen:parameterValues>" +
                               "<gen:item>" +
                               "<gen:prmValueString></gen:prmValueString>" +
                               "<gen:prmNo></gen:prmNo>" +
                               "<gen:resourceLike></gen:resourceLike>" +
                               "</gen:item>" +
                               "</gen:parameterValues>" +
                               "<gen:dntypes>" +
                               "<gen:dnCode>" + dnCode + "</gen:dnCode>" +
                               "</gen:dntypes>" +
                               "<gen:statuses>" +
                               "<gen:dnStatus>" + dnStatus + "</gen:dnStatus>" +
                               "</gen:statuses>" +
                               "<gen:searchCount>"+ seasearchCount + "</gen:searchCount>" +
                               "<gen:reservation>" + reservation + "</gen:reservation>" +
                               "<gen:externalState></gen:externalState>" +
                               "<gen:csId></gen:csId>" +
                               "<gen:csIdPub></gen:csIdPub>" +
                               "<gen:rscode></gen:rscode>" +
                               "<gen:rscodePub></gen:rscodePub>" +
                               "<gen:csControlled></gen:csControlled>" +
                               "</gen:inputAttributes>" +
                               "<gen:sessionChangeRequest>" +
                               "<ses:values>" +
                               "<ses:item>" +
                               "<ses:key>" + buId + "</ses:key>" +
                               "<ses:value>" + sesValue + "</ses:value>" +
                               "</ses:item>" +
                               "</ses:values>" +
                               "</gen:sessionChangeRequest>" +
                               "</gen:genericDirectoryNumberSearchRequest>" +
                               "</soapenv:Body>" +
                               "</soapenv:Envelope>";
            return soaprequest;
        }
    }
}
