using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.ModelClaroESB.Listas
{
    class GetInfoListsRequest
    {
        public string channel { get; set; }
        public string typeProcess { get; set; }
        public Document document { get; set; }
        public Phone phone { get; set; }
        public string mail { get; set; }

        public static GetInfoListsRequest GetListasRequestFactory(string channel, string typeProcess, string typeDocument,
                                                                  string numberDocument, string areaCode, string phone, string mail)
        {
            var returnValue = new GetInfoListsRequest();

            returnValue.channel = channel;
            returnValue.typeProcess = typeProcess;
            returnValue.document.typeDocument = typeDocument;
            returnValue.document.numberDocument = numberDocument;
            returnValue.phone.areaCode = areaCode;
            returnValue.phone.phone = phone;
            returnValue.mail = mail;

            return returnValue;
        }
    }

    class Document
    {
        public string typeDocument { get; set; }
        public string numberDocument { get; set; }
    }

    class Phone
    {
        public string areaCode { get; set; }
        public string phone { get; set; }
    }

}
