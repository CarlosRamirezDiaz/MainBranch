using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Business;
using Microsoft.Xrm.Sdk;

namespace AmxPeruPSBActivities.Activities.Address
{
    public class AmxPeruModifyCustomerAddress : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruCustomerAddressUpdateRequest> CustomerAddressRequest { get; set; }

        public OutArgument<AmxPeruCustomerAddressResponse> CustomerAddressResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {   

            

            var request = CustomerAddressRequest.Get(context);
            AmxPeruCustomerAddressResponse AddressResponse = null;
            if(request != null)
            {
                AddressResponse = new AmxPeruCustomerAddressResponse();

                var customerAddress = CustomerAddressRequest.Get(context);
                var CustomerAdddressEntity = new etel_customeraddress();
                CustomerAdddressEntity.Id = new Guid(customerAddress.CustomerAddressId);

                if (!string.IsNullOrEmpty(customerAddress.Street1))
                {
                    CustomerAdddressEntity.Attributes.Add("amxperu_street1", new OptionSetValue(Convert.ToInt32(customerAddress.Street1)));
                }

                if (!string.IsNullOrEmpty(customerAddress.Building))
                {
                    CustomerAdddressEntity.Attributes.Add("amxperu_building", new OptionSetValue(Convert.ToInt32(customerAddress.Building)));
                }


                if (customerAddress.BuildType != 0)
                {
                    CustomerAdddressEntity.Attributes.Add("amxperu_buildtype", new OptionSetValue(Convert.ToInt32(customerAddress.BuildType)));
                }

                if (customerAddress.BuildType != 0)
                {
                    CustomerAdddressEntity.Attributes.Add("amxperu_buildtype", new OptionSetValue(Convert.ToInt32(customerAddress.BuildType)));
                }

                if (!string.IsNullOrEmpty(customerAddress.Email))
                {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("amxperu_billingemail", customerAddress.Email));
                }

                if (!string.IsNullOrEmpty(customerAddress.Normalized))
                {
                    CustomerAdddressEntity.Attributes.Add("amxperu_normalized", Convert.ToBoolean(customerAddress.Normalized));
                }

                
                if (!string.IsNullOrEmpty(customerAddress.Street3))
                {                    
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("etel_addressline3", customerAddress.Street3));
                }


                if (!string.IsNullOrEmpty(customerAddress.Ubigeo))
                {
                    CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("amxperu_ubigeo", customerAddress.Ubigeo));
                }

                if (!string.IsNullOrEmpty(customerAddress.ReferenceDescription))
                {
                    CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("amxperu_referencedescription", customerAddress.ReferenceDescription));
                }


                ContextProvider.OrganizationService.Update(CustomerAdddressEntity);
            }

            CustomerAddressResponse.Set(context, AddressResponse);
        }
    }
}
