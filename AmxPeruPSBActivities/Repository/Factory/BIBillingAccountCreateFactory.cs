using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.BIBillingAccountCreate;

namespace AmxCoPSBActivities.Repository.Factory
{
    internal static class BIBillingAccountCreateFactory
    {
        internal static Entity CreateEntityFrom(BIBillingAccountCreateModel biBillingAccountCreate)
        {
            Entity entity = new Entity("etel_creditprofile");

            entity.Attributes.Add("createdon", biBillingAccountCreate.CreatedOn);
            entity.Attributes.Add("etel_customerindividualid", new EntityReference("contact", biBillingAccountCreate.IndividualCustomerId));

            return entity;
        }

        internal static BIBillingAccountCreateModel CreateBIBillingAccountCreateFrom(Entity entity)
        {
            var biBillingAccountCreate = new BIBillingAccountCreateModel();

            biBillingAccountCreate.Id = entity.Id;

            if (entity.Contains("createdon"))
                biBillingAccountCreate.CreatedOn = entity.GetAttributeValue<DateTime>("createdon");

            if (entity.Contains("etel_customerindividualid"))
                biBillingAccountCreate.IndividualCustomerId = entity.GetAttributeValue<EntityReference>("etel_customerindividualid").Id;

            return biBillingAccountCreate;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "createdon"
                                                    ,"etel_customerindividualid"});
            }
        }
    }
}
