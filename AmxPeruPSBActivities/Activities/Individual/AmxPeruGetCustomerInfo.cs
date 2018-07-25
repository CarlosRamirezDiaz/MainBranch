using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.Individual
{    
  public class AmxPeruGetCustomerInfo : XrmAwareCodeActivity
    {

        public InArgument<AmxPeruGetCustomerInfoRequest> CustomerRequest { get; set; }

        public OutArgument<AmxPeruGetCustomerInfoResponse> CustomerResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var request = CustomerRequest.Get(context);
            AmxPeruGetCustomerInfoResponse _response = null;
            try
            {
                _response = new AmxPeruGetCustomerInfoResponse();
                var _business = new AmxPSBActivities.Business.AmxGetCustomerInfoBusiness(ContextProvider.OrganizationService);

                var amxRequest = new AmxPSBActivities.Model.AmxGetCustomerInfoRequest()
                {
                    documentNumber = request.documentNumber,
                    documentType = request.documentType,
                    msisdn = request.msisdn
                };

                var response = _business.GetCustomerInfo(amxRequest);

                _response.Success = response.Success;
                _response.Error = response.Error;
                _response.customerId = response.customerId;
                _response.activeFlag = response.activeFlag;
                _response.corporateName = response.companyName;
                _response.segment = response.segment;
                _response.name = response.name;
                _response.firstName = response.firstName;
                _response.lastName = response.lastName;
                _response.companyName = response.companyName;
                _response.documentType = response.documentType;
                _response.documentNumber = response.documentNumber;
                _response.email = response.email;
                _response.birthDate = response.birthDate;
                _response.birthPlace = response.birthPlace;
                _response.phoneNumber = response.phoneNumber;
                _response.gender = response.gender;


                CustomerResponse.Set(context, _response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
