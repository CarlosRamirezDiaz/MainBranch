using AmxCoPSBActivities.Model;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.Individual;
using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Business.Individual
{
    public class AmxGetMobileCustomerInfoBusiness
    {
        private OrganizationServiceProxy _org = null;
        private ConfigurationRepository _configurationRepository;
        private ConfigurationRepository configurationRepository
        {
            get
            {
                if (this._configurationRepository == null)
                    this._configurationRepository = new ConfigurationRepository(this._org);
                return this._configurationRepository;
            }
        }

        public AmxGetMobileCustomerInfoBusiness(OrganizationServiceProxy org)
        {
            this._org = org;
        }
        
        /// <summary>
        /// Get customer infor by MIN (Mobile Identification Number)
        /// </summary>
        /// <param name="min">MIN - Mobile Identification Number</param>
        /// <returns></returns>
        public BaseResponse<AmxGetMobileCustomerInfoResponse> GetMobileCustomerInfo(string min)
        {
            var returnValue = new BaseResponse<AmxGetMobileCustomerInfoResponse>();

            returnValue.Success = true;

            // dummy values
            returnValue.Value = new AmxGetMobileCustomerInfoResponse();
            returnValue.Value.CustomerId = "CUST0000000084";
            returnValue.Value.Fullname = "Pepito Chaves";
            returnValue.Value.DocumentNumber = "1234567890";
            returnValue.Value.DocumentType = "1";
            returnValue.Value.DocumentTypeName = "CC-CEDULA DE CIUDADANIA";
            returnValue.Value.MailAddress = "CL 104 A SUR 9 06 USMINIA";
            returnValue.Value.MailAdrressCity = "BOGOTÁ, D.C.";
            returnValue.Value.ContactPhoneNumber1 = "17500500";
            returnValue.Value.ContactPhoneNumber2 = "3138228280";
            returnValue.Value.ActivationDate = DateTime.Now.Date.AddMonths(-1 * DateTime.Now.Day);

            return returnValue;
        }
    }
}
