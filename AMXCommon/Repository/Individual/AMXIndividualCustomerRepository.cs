using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMXCommon
{
    public class AMXIndividualCustomerRepository
    {
        /// <summary>
        /// Create Customer Contact information on Prospect create
        /// </summary>
        /// <param name="cusInfoList"></param>
        /// <param name="contactId"></param>
        /// <param name="service"></param>
        public void CreateCustomerContactInformation(List<CustomerContactInfo> cusInfoList, Guid contactId, IOrganizationService service)
        {
            Entity contactInfo = new Entity();
            foreach (var cusInfo in cusInfoList)
            {
                var contactInfoAttributeName = string.Empty;
                string nameAttribute = string.Empty;
                object contactInfoAttributeValue = null;
                if (cusInfo.contacttype == 173800000) { nameAttribute = " Email - "; contactInfoAttributeName = "amx_email"; contactInfoAttributeValue = cusInfo.contactinfo; }
                else if (cusInfo.contacttype == 173800001) { nameAttribute = " Cell nr - "; contactInfoAttributeName = "amx_phoneno"; contactInfoAttributeValue = cusInfo.mobileInfo.ToString(); }
                else if (cusInfo.contacttype == 173800002) { nameAttribute = " Fixed nr - "; contactInfoAttributeName = "amx_phoneno"; contactInfoAttributeValue = cusInfo.fixedlineInfo.ToString(); }
                contactInfo = new Entity
                {
                    LogicalName = "amx_customercontactinformation",
                    Attributes = new AttributeCollection {

                         new KeyValuePair<string, object>("amx_name", nameAttribute + contactInfoAttributeValue),
                         new KeyValuePair<string, object>("amx_contacttype", new OptionSetValue(cusInfo.contacttype)),
                         new KeyValuePair<string, object>(contactInfoAttributeName, contactInfoAttributeValue),
                         new KeyValuePair<string, object>("amx_primarycontacttype", cusInfo.isprimary == 0 ? false : true),
                         new KeyValuePair<string, object>("amx_individualcustomerid", new EntityReference("contact",contactId))
                    }
                };
                service.Create(contactInfo);
            }
        }
    }
}
