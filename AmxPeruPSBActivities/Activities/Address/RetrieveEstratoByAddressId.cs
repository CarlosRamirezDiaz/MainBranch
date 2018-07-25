using ExternalApiActivities.Common;
using System;
using System.Linq;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Activities.Address
{
    public class RetrieveEstratoByAddressId : XrmAwareCodeActivity
    {
        public InArgument<string> AddressId { get; set; }
        public OutArgument<string> Estrato { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var addressId = AddressId.Get(context);

            QueryExpression mglTechEntity = new QueryExpression("amx_bimgltechnicaldetails");
            mglTechEntity.ColumnSet = new ColumnSet("amx_stratum");
            mglTechEntity.Criteria.AddCondition("amx_customeraddressid", ConditionOperator.Equal, new Guid(addressId));
            var mgl = ContextProvider.OrganizationService.RetrieveMultiple(mglTechEntity).Entities.FirstOrDefault();
            if (mgl != null)
            {
                Estrato.Set(context, mgl.GetAttributeValue<string>("amx_stratum"));
            }
        }
    }
}
