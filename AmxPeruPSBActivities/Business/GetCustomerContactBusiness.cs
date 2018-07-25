using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;

namespace AmxPeruPSBActivities.Business
{
    public class GetCustomerContactBusiness 
    {
        public AmxPeruCustomerContactResponse RetrieveContactData(string CustomerID, OrganizationServiceProxy _org)
        {
            AmxPeruCustomerContactResponse _response = null;
            List<Contact> _contacts = new List<Contact>();
            if (CustomerID != string.Empty)
            {
                _response = new AmxPeruCustomerContactResponse();
                QueryExpression _getContactData = new QueryExpression
                {
                    EntityName = "contact",
                    ColumnSet = new ColumnSet("fullname", "accountrolecode","address1_line1", "address1_line3", "address1_line3", "mobilephone", "emailaddress1","contactid"),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression
                            {
                                AttributeName = "etel_externalid",
                                Operator = ConditionOperator.Equal,
                                Values = { CustomerID }
                            }
                        }
                    }
                };
                DataCollection<Entity> _entities  = _org.RetrieveMultiple(_getContactData).Entities;
                foreach( var entity in _entities)
                {
                    Contact _contact = new Contact();
                    if (entity.Attributes.Contains("fullname"))
                    {
                        _contact.name = entity.Attributes["fullname"].ToString();
                    }
                    if (entity.Attributes.Contains("mobilephone"))
                    {
                        _contact.phoneNumber = entity.Attributes["mobilephone"].ToString();
                    }
                    if (entity.Attributes.Contains("emailaddress1"))
                    {
                        _contact.email = entity.Attributes["emailaddress1"].ToString();
                    }
                    if (entity.Attributes.Contains("contactid"))
                    {
                        _contact.contactId = entity.Attributes["contactid"].ToString();
                    }
                    if (entity.Attributes.Contains("address1_line1"))
                    {
                        _contact.address= entity.Attributes["address1_line1"].ToString();
                    }
                    if (entity.Attributes.Contains("address1_line2"))
                    {
                        _contact.address += entity.Attributes["address1_line2"].ToString();
                    }
                    if (entity.Attributes.Contains("address1_line3"))
                    {
                        _contact.address = entity.Attributes["address1_line3"].ToString();
                    }
                    if (entity.Attributes.Contains("accountrolecode"))
                    {
                        _contact.role = entity.FormattedValues["accountrolecode"].ToString();
                    }
                    _contacts.Add(_contact);
                }
                if(_contacts.Count>0)
                {
                    _response.successflag = 1;
                    _response.listOfContacts = _contacts;
                    _response.Status = "OK";
                }
                else
                {
                    _response.successflag = 0;
                    _response.Status = "NOK";
                    _response.Error = "No result found";
                }
            }
            return _response;
        }
    }
}
