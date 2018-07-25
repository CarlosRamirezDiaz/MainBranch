using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model.AffiliateDisaffiliate;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace AmxPeruPSBActivities.Business
{
    public class AmxPeruAffiliateDisaffiliateDataProtectionBusiness
    {
        public AmxPeruDataProtectionResponse UpdateCustomerDataProtection (AmxPeruDataProtectionRequest _request, OrganizationServiceProxy _org)
        {
            AmxPeruDataProtectionResponse _response = null;
            if(_request != null)
            {
                _response = new AmxPeruDataProtectionResponse();
                Entity individual = new Entity("contact");
                if(!string.IsNullOrEmpty(_request.CustomerID))
                {
                    Guid CustomerGuid = new Guid(_request.CustomerID);
                    individual.Id = CustomerGuid;

                    if(_request.DataProtectionValue != 0)
                    {
                        individual.Attributes["amxperu_dataprotection"] = new OptionSetValue(_request.DataProtectionValue);
                    }
                    _org.Update(individual);
                    _response.Status = "OK";
                    _response.successFlag = 1;
                }
            }
            return _response;
        }
    }
}
