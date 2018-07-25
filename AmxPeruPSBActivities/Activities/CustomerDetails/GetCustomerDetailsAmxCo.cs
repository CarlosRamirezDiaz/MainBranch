using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Interfaces;

namespace AmxPeruPSBActivities.Activities.CustomerDetails
{

    public class GetCustomerDetailsAmxCo : XrmAwareCodeActivity
    {
        public InArgument<string> IndividualCustomerId { get; set; }
        //public InArgument<string> CorporateCustomerId { get; set; }

        public OutArgument<ICustomerModel> IndividualCustomer { get; set; }
        //public OutArgument<Account> CorporateCustomer { get; set; }
        public OutArgument<string> CustomerType { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var individualCustomerId = IndividualCustomerId.Get(context);

            //var corporateCustomerId = CorporateCustomerId.Get(context);

            if (!string.IsNullOrEmpty(individualCustomerId))
            {
                var result = from individualCustomer in dataContext.ContactSet
                             where individualCustomer.Id == new Guid(individualCustomerId)
                             select individualCustomer;

                var contact = result.FirstOrDefault();
                if (contact == null)
                {
                    throw new Exception(string.Format("Individual Customer Not Found with given CustomerId {0}", individualCustomerId));
                }
                IndividualCustomer.Set(context, contact);
                CustomerType.Set(context, Contact.EntityLogicalName);
            }
            //else if (!string.IsNullOrEmpty(corporateCustomerId))
            //{
            //    var corpResult = from corporateCustomer in dataContext.AccountSet
            //                     where corporateCustomer.Id == new Guid(corporateCustomerId)
            //                     select corporateCustomer;
            //    var corporate = corpResult.FirstOrDefault();
            //    if (corporate == null)
            //    {
            //        throw new Exception(string.Format("Corporate Customer Not Found with given CustomerId {0}", corporateCustomerId));
            //    }
            //    CorporateCustomer.Set(context, corporate);
            //    CustomerType.Set(context, Account.EntityLogicalName);
            //}
            else
            {
                throw new Exception("Customer Id Expected");
            }

        }
    }
}
