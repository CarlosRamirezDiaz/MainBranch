using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk;


namespace AmxPeruPSBActivities.Activities.CustomerDetails
{
    
    
  


    public class CustomerDetails : XrmAwareCodeActivity
    {
        public InArgument<string> CustomerID { get; set; }
        public InArgument<long> CustomerType { get; set; }
        public OutArgument<ICustomer> Customer { get; set; }
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var customerID = CustomerID.Get(context);
            var customerType = CustomerType.Get(context);
            if (customerType == (int)Contact.EntityTypeCode)
            {
                var query = from customer in dataContext.ContactSet
                            where customer.etel_accountnumber == customerID
                            select customer;
                context.SetValue(Customer, query.FirstOrDefault());
            }
            else if (customerType == (int)Account.EntityTypeCode)
            {

                var query = from customer in dataContext.AccountSet
                            where customer.AccountNumber == customerID
                            select customer;
                context.SetValue(Customer, query.FirstOrDefault());
            }

        }
    }

    public class GetBillingAccount : XrmAwareCodeActivity
    {

        [RequiredArgument]
        public InArgument<string> CustomerId { get; set; }
        [RequiredArgument]
        public InArgument<long> CustomerType { get; set; }
        [RequiredArgument]
        public InOutArgument<string> LanguageCode { get; set; }
        public OutArgument<List<etel_billingaccount>> BillingAccountList { get; set; }


        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var customerId = CustomerId.Get(context);
            var customerType = CustomerType.Get(context);
            var languageCode = LanguageCode.Get(context);

            var result = new List<etel_billingaccount>();

            if (customerType == (int)Account.EntityTypeCode)
            {
                result = (from billingAccount in dataContext.etel_billingaccountSet
                          where billingAccount.etel_accountid == new EntityReference(Account.EntityLogicalName, new Guid(customerId))
                          select billingAccount).ToList();
            }
            else if (customerType == (int)Contact.EntityTypeCode)
            {
                result = (from billingAccount in dataContext.etel_billingaccountSet
                          where billingAccount.etel_customerindividualid == new EntityReference(Contact.EntityLogicalName, new Guid(customerId))
                          select billingAccount).ToList();
            }

            BillingAccountList.Set(context, result);
        }
    }




    



}
