using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxSoapServicesActivities.XmlStrings
{
    public class ChangeCustomerEmailRequestXml
    {
        public string GetXmlrequest(string str_customerId = "CUST0000000089", string str_adrEmail = "test@sqdm.com",
                                    string str_prgCode = "2", int i_rpcode = 3, string str_Billcycle = "01",
                                    string str_pmntid = "-1", Int32 i_adrsep = 0, string str_lname = "Alvarado 2",
                                    string str_fname = "Jose", string str_street = "Calle uno",
                                    string str_streetno = "625", string str_zip = "12345678", string str_city = "Barranquilla",
                                    Boolean boo_presponseW = true, string str_status = "a", Int32 i_rscode = 1,
                                    Boolean boo_presponse = true)
        {
            string soaprequest = string.Empty;
            string buId = "BU_ID";
            int sesValue = 2;

            soaprequest = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:cus='http://ericsson.com/services/ws_CIL_7/customercreate'" +
                          "xmlns: cus1 = 'http://ericsson.com/services/ws_CIL_7/customernew' xmlns: mon = 'http://lhsgroup.com/lhsws/money'" +
                          "xmlns: pay = 'http://ericsson.com/services/ws_CIL_7/paymentarrangementwrite' xmlns: add = 'http://ericsson.com/services/ws_CIL_7/addresswrite'" +
                          "xmlns: cus2 = 'http://ericsson.com/services/ws_CIL_7/customerinfowrite' xmlns: cus3 = 'http://ericsson.com/services/ws_CIL_7/customerwrite'" +
                          "xmlns: ses = 'http://ericsson.com/services/ws_CIL_7/sessionchange' >" +
                          "<soapenv:Header>" +
                          "<Security xmlns = 'http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>" +
                          "<UsernameToken>" +
                          "<Username>ADMX</Username>" +
                          "<Password>ADMX</Password>" +
                          "</UsernameToken>" +
                          "</Security>" +
                          "</soapenv:Header>" +
                          "<soapenv:Body>" +
                          "<cus:customerCreateRequest>" +
                          "<cus:inputAttributes>" +
                          "<cus:customerNew>" +
                          "<cus1:paymentResp>" + boo_presponse + "</cus1:paymentResp>" +
                          "<cus1:externalCustomerId></cus1:externalCustomerId>" +
                          "<cus1:prgCode>" + str_prgCode + "</cus1:prgCode>" +
                          "<cus1:rpcode>" + i_rpcode + "</cus1:rpcode>" +
                          "<cus1:csBillcycle>" + str_Billcycle + "</cus1:csBillcycle>" +
                          "<cus1:roundingCarryLeftOver></cus1:roundingCarryLeftOver>" +
                          "</cus:customerNew>" +
                          "<cus:paymentArrangementWrite>" +
                          "<pay:cspId></pay:cspId>" +
                          "<pay:cspPmntId>" + str_pmntid + "</pay:cspPmntId>" +
                          "</cus:paymentArrangementWrite>" +
                          "<cus:addresses>" +
                          "<cus:item>" +
                          "<cus:addressWrite>" +
                          "<add:adrSeq>" + i_adrsep + "</add:adrSeq>" +
                          "<add:adrLname>" + str_lname + "</add:adrLname>" +
                          "<add:adrName></add:adrName>" +
                          "<add:adrFname>" + str_fname + "</add:adrFname>" +
                          "<add:adrStreet>" + str_street + "</add:adrStreet>" +
                          "<add:adrStreetno>" + str_streetno + " </add:adrStreetno>" +
                          "<add:adrZip>" + str_zip + "</add:adrZip>" +
                          "<add:adrCity>" + str_city + "</add:adrCity>" +
                          "<add:adrEmail>" + str_adrEmail + "</add:adrEmail>" +
                          "</cus:addressWrite>" +
                          "</cus:item>" +
                          "</cus:addresses>" +
                          "<cus:customerInfoWrite>" +
                          "<cus2:text01></cus2:text01>" +
                          "<cus2:text02></cus2:text02>" +
                          "<cus2:text03></cus2:text03>" +
                          "<cus2:text04></cus2:text04>" +
                          "<cus2:text05></cus2:text05>" +
                          "<cus2:text06></cus2:text06>" +
                          "<cus2:text07></cus2:text07>" +
                          "<cus2:text08></cus2:text08>" +
                          "<cus2:text09></cus2:text09>" +
                          "<cus2:text10></cus2:text10>" +
                          "<cus2:text11></cus2:text11>" +
                          "<cus2:text12></cus2:text12>" +
                          "<cus2:text13></cus2:text13>" +
                          "<cus2:text14></cus2:text14>" +
                          "<cus2:text15></cus2:text15>" +
                          "<cus2:text16></cus2:text16>" +
                          "<cus2:text17></cus2:text17>" +
                          "<cus2:text18></cus2:text18>" +
                          "<cus2:text19></cus2:text19>" +
                          "<cus2:text20></cus2:text20>" +
                          "<cus2:text21></cus2:text21>" +
                          "<cus2:text22></cus2:text22>" +
                          "<cus2:text23></cus2:text23>" +
                          "<cus2:text24></cus2:text24>" +
                          "<cus2:text25></cus2:text25>" +
                          "<cus2:text26></cus2:text26>" +
                          "<cus2:text27></cus2:text27>" +
                          "<cus2:text28></cus2:text28>" +
                          "<cus2:text29></cus2:text29>" +
                          "<cus2:text30></cus2:text30>" +
                          "<cus2:check01></cus2:check01>" +
                          "<cus2:check02></cus2:check02>" +
                          "<cus2:check03></cus2:check03>" +
                          "<cus2:check04></cus2:check04>" +
                          "<cus2:check05></cus2:check05>" +
                          "<cus2:check06></cus2:check06>" +
                          "<cus2:check07></cus2:check07>" +
                          "<cus2:check08></cus2:check08>" +
                          "<cus2:check09></cus2:check09>" +
                          "<cus2:check10></cus2:check10>" +
                          "<cus2:check11></cus2:check11>" +
                          "<cus2:check12></cus2:check12>" +
                          "<cus2:check13></cus2:check13>" +
                          "<cus2:check14></cus2:check14>" +
                          "<cus2:check15></cus2:check15>" +
                          "<cus2:check16></cus2:check16>" +
                          "<cus2:check17></cus2:check17>" +
                          "<cus2:check18></cus2:check18>" +
                          "<cus2:check19></cus2:check19>" +
                          "<cus2:check20></cus2:check20>" +
                          "<cus2:combo01></cus2:combo01>" +
                          "<cus2:combo02></cus2:combo02>" +
                          "<cus2:combo03></cus2:combo03>" +
                          "<cus2:combo04></cus2:combo04>" +
                          "<cus2:combo05></cus2:combo05>" +
                          "<cus2:combo06></cus2:combo06>" +
                          "<cus2:combo07></cus2:combo07>" +
                          "<cus2:combo08></cus2:combo08>" +
                          "<cus2:combo09></cus2:combo09>" +
                          "<cus2:combo10></cus2:combo10>" +
                          "<cus2:combo11></cus2:combo11>" +
                          "<cus2:combo12></cus2:combo12>" +
                          "<cus2:combo13></cus2:combo13>" +
                          "<cus2:combo14></cus2:combo14>" +
                          "<cus2:combo15></cus2:combo15>" +
                          "<cus2:combo16></cus2:combo16>" +
                          "<cus2:combo17></cus2:combo17>" +
                          "<cus2:combo18></cus2:combo18>" +
                          "<cus2:combo19></cus2:combo19>" +
                          "<cus2:combo20></cus2:combo20>" +
                          "<cus2:csId></cus2:csId>" +
                          "<cus2:csIdPub>" + str_customerId + "</cus2:csIdPub>" +
                          "</cus:customerInfoWrite>" +
                          "<cus:customerWrite>" +
                          "<cus3:paymentResp>" + boo_presponseW + "</cus3:paymentResp>" +
                          "<cus3:csStatus>" + str_status + "</cus3:csStatus>" +
                          "<cus3:rsCode>" + i_rscode + "</cus3:rsCode>" +
                          "</cus:customerWrite>" +
                          "</cus:inputAttributes>" +
                          "<cus:sessionChangeRequest>" +
                          "<ses:values>" +
                          "<ses:item>" +
                          "<ses:key>" + buId + "</ses:key>" +
                          "<ses:value>" + sesValue + "</ses:value>" +
                          "</ses:item>" +
                          "</ses:values>" +
                          "</cus:sessionChangeRequest>" +
                          "</cus:customerCreateRequest>" +
                          "</soapenv:Body>" +
                          "</soapenv:Envelope>";


            return soaprequest;
        }

        //public string GetXmlrequest(Boolean boo_presponse = true, string str_prgCode = "", int i_rpcode = 3,
        //                            string str_Billcycle = "01", string str_pmntid = "-1", Int32 i_adrsep = 0,
        //                            string str_lname = "", string str_fname = "", string str_street = "",
        //                            string str_streetno = "", string str_zip = "", string str_city = "",
        //                            Boolean boo_presponseW = true, string str_status = "a", Int32 i_rscode = 1,
        //                            string str_adrEmail = "",string str_customerId = "CUST0000000089")
        //{
        //    string soaprequest = string.Empty;
        //    string buId = "BU_ID";
        //    int sesValue = 2;

        //    soaprequest = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:cus='http://ericsson.com/services/ws_CIL_7/customercreate'" +
        //                  "xmlns: cus1 = 'http://ericsson.com/services/ws_CIL_7/customernew' xmlns: mon = 'http://lhsgroup.com/lhsws/money'" +
        //                  "xmlns: pay = 'http://ericsson.com/services/ws_CIL_7/paymentarrangementwrite' xmlns: add = 'http://ericsson.com/services/ws_CIL_7/addresswrite'" +
        //                  "xmlns: cus2 = 'http://ericsson.com/services/ws_CIL_7/customerinfowrite' xmlns: cus3 = 'http://ericsson.com/services/ws_CIL_7/customerwrite'" +
        //                  "xmlns: ses = 'http://ericsson.com/services/ws_CIL_7/sessionchange' >" +
        //                  "<soapenv:Header>" +
        //                  "<Security xmlns = 'http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>" +
        //                  "<UsernameToken>" +
        //                  "<Username>ADMX</Username>" +
        //                  "<Password>ADMX</Password>" +
        //                  "</UsernameToken>" +
        //                  "</Security>" +
        //                  "</soapenv:Header>" +
        //                  "<soapenv:Body>" +
        //                  "<cus:customerCreateRequest>" +
        //                  "<cus:inputAttributes>" +
        //                  "<cus:customerNew>" +
        //                  "<cus1:paymentResp>" + boo_presponse + "</cus1:paymentResp>" +
        //                  "<cus1:externalCustomerId></cus1:externalCustomerId>" +
        //                  "<cus1:prgCode>" + str_prgCode + "</cus1:prgCode>" +
        //                  "<cus1:rpcode>" + i_rpcode + "</cus1:rpcode>" +
        //                  "<cus1:csBillcycle>" + str_Billcycle + "</cus1:csBillcycle>" +
        //                  "<cus1:roundingCarryLeftOver></cus1:roundingCarryLeftOver>" +
        //                  "</cus:customerNew>" +
        //                  "<cus:paymentArrangementWrite>" +
        //                  "<pay:cspId></pay:cspId>" +
        //                  "<pay:cspPmntId>" + str_pmntid + "</pay:cspPmntId>" +
        //                  "</cus:paymentArrangementWrite>" +
        //                  "<cus:addresses>" +
        //                  "<cus:item>" +
        //                  "<cus:addressWrite>" +
        //                  "<add:adrSeq>" + i_adrsep + "</add:adrSeq>" +
        //                  "<add:adrLname>" + str_lname + "</add:adrLname>" +
        //                  "<add:adrName></add:adrName>" +
        //                  "<add:adrFname>" + str_fname + "</add:adrFname>" +
        //                  "<add:adrStreet>" + str_street + "</add:adrStreet>" +
        //                  "<add:adrStreetno>" + str_streetno + " </add:adrStreetno>" +
        //                  "<add:adrZip>" + str_zip + "</add:adrZip>" +
        //                  "<add:adrCity>" + str_city + "</add:adrCity>" +
        //                  "<add:adrEmail>" + str_adrEmail + "</add:adrEmail>" +
        //                  "</cus:addressWrite>" +
        //                  "</cus:item>" +
        //                  "</cus:addresses>" +
        //                  "<cus:customerInfoWrite>" +
        //                  "<cus2:text01></cus2:text01>" +
        //                  "<cus2:text02></cus2:text02>" +
        //                  "<cus2:text03></cus2:text03>" +
        //                  "<cus2:text04></cus2:text04>" +
        //                  "<cus2:text05></cus2:text05>" +
        //                  "<cus2:text06></cus2:text06>" +
        //                  "<cus2:text07></cus2:text07>" +
        //                  "<cus2:text08></cus2:text08>" +
        //                  "<cus2:text09></cus2:text09>" +
        //                  "<cus2:text10></cus2:text10>" +
        //                  "<cus2:text11></cus2:text11>" +
        //                  "<cus2:text12></cus2:text12>" +
        //                  "<cus2:text13></cus2:text13>" +
        //                  "<cus2:text14></cus2:text14>" +
        //                  "<cus2:text15></cus2:text15>" +
        //                  "<cus2:text16></cus2:text16>" +
        //                  "<cus2:text17></cus2:text17>" +
        //                  "<cus2:text18></cus2:text18>" +
        //                  "<cus2:text19></cus2:text19>" +
        //                  "<cus2:text20></cus2:text20>" +
        //                  "<cus2:text21></cus2:text21>" +
        //                  "<cus2:text22></cus2:text22>" +
        //                  "<cus2:text23></cus2:text23>" +
        //                  "<cus2:text24></cus2:text24>" +
        //                  "<cus2:text25></cus2:text25>" +
        //                  "<cus2:text26></cus2:text26>" +
        //                  "<cus2:text27></cus2:text27>" +
        //                  "<cus2:text28></cus2:text28>" +
        //                  "<cus2:text29></cus2:text29>" +
        //                  "<cus2:text30></cus2:text30>" +
        //                  "<cus2:check01></cus2:check01>" +
        //                  "<cus2:check02></cus2:check02>" +
        //                  "<cus2:check03></cus2:check03>" +
        //                  "<cus2:check04></cus2:check04>" +
        //                  "<cus2:check05></cus2:check05>" +
        //                  "<cus2:check06></cus2:check06>" +
        //                  "<cus2:check07></cus2:check07>" +
        //                  "<cus2:check08></cus2:check08>" +
        //                  "<cus2:check09></cus2:check09>" +
        //                  "<cus2:check10></cus2:check10>" +
        //                  "<cus2:check11></cus2:check11>" +
        //                  "<cus2:check12></cus2:check12>" +
        //                  "<cus2:check13></cus2:check13>" +
        //                  "<cus2:check14></cus2:check14>" +
        //                  "<cus2:check15></cus2:check15>" +
        //                  "<cus2:check16></cus2:check16>" +
        //                  "<cus2:check17></cus2:check17>" +
        //                  "<cus2:check18></cus2:check18>" +
        //                  "<cus2:check19></cus2:check19>" +
        //                  "<cus2:check20></cus2:check20>" +
        //                  "<cus2:combo01></cus2:combo01>" +
        //                  "<cus2:combo02></cus2:combo02>" +
        //                  "<cus2:combo03></cus2:combo03>" +
        //                  "<cus2:combo04></cus2:combo04>" +
        //                  "<cus2:combo05></cus2:combo05>" +
        //                  "<cus2:combo06></cus2:combo06>" +
        //                  "<cus2:combo07></cus2:combo07>" +
        //                  "<cus2:combo08></cus2:combo08>" +
        //                  "<cus2:combo09></cus2:combo09>" +
        //                  "<cus2:combo10></cus2:combo10>" +
        //                  "<cus2:combo11></cus2:combo11>" +
        //                  "<cus2:combo12></cus2:combo12>" +
        //                  "<cus2:combo13></cus2:combo13>" +
        //                  "<cus2:combo14></cus2:combo14>" +
        //                  "<cus2:combo15></cus2:combo15>" +
        //                  "<cus2:combo16></cus2:combo16>" +
        //                  "<cus2:combo17></cus2:combo17>" +
        //                  "<cus2:combo18></cus2:combo18>" +
        //                  "<cus2:combo19></cus2:combo19>" +
        //                  "<cus2:combo20></cus2:combo20>" +
        //                  "<cus2:csId></cus2:csId>" +
        //                  "<cus2:csIdPub>" + str_customerId + "</cus2:csIdPub>" +
        //                  "</cus:customerInfoWrite>" +
        //                  "<cus:customerWrite>" +
        //                  "<cus3:paymentResp>" + boo_presponseW + "</cus3:paymentResp>" +
        //                  "<cus3:csStatus>" + str_status + "</cus3:csStatus>" +
        //                  "<cus3:rsCode>" + i_rscode + "</cus3:rsCode>" +
        //                  "</cus:customerWrite>" +
        //                  "</cus:inputAttributes>" +
        //                  "<cus:sessionChangeRequest>" +
        //                  "<ses:values>" +
        //                  "<ses:item>" +
        //                  "<ses:key>" + buId + "</ses:key>" +
        //                  "<ses:value>" + sesValue + "</ses:value>" +
        //                  "</ses:item>" +
        //                  "</ses:values>" +
        //                  "</cus:sessionChangeRequest>" +
        //                  "</cus:customerCreateRequest>" +
        //                  "</soapenv:Body>" +
        //                  "</soapenv:Envelope>";                                                                                      


        //    return soaprequest;
        //}
    }
}
