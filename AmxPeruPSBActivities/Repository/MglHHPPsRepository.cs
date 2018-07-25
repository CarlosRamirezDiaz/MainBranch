using AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGL;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Repository
{
    public class MglHHPPsRepository
    {
        OrganizationServiceProxy _organizationService;
        public MglHHPPsRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        public MglHhPpsModel GetByOrderItem(Guid orderCaptureId, string orderItemSequenceNumber)
        {
            if (orderCaptureId == Guid.Empty || string.IsNullOrEmpty(orderItemSequenceNumber))
                return new MglHhPpsModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "amx_bimgllisthhpps",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.MglHhPpsFactory.Fields
            };

            query.AddLink("amx_bimgltechnicaldetails", "amx_mgllisthhppsid", "amx_bimgltechnicaldetailsid");
            query.LinkEntities[0].AddLink("amx_orderitemcustomeraddress", "amx_customeraddressid", "amx_customeraddressid");
            query.LinkEntities[0].LinkEntities[0].AddLink("etel_orderitem", "amx_orderitemid", "etel_orderitemid");
            query.LinkEntities[0].LinkEntities[0].LinkEntities[0].LinkCriteria.AddCondition("etel_orderid", ConditionOperator.Equal, orderCaptureId);
            query.LinkEntities[0].LinkEntities[0].LinkEntities[0].LinkCriteria.AddCondition("etel_name", ConditionOperator.Equal, orderItemSequenceNumber);

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new MglHhPpsModel();

            var entity = collection.Entities[0];

            return AmxCoPSBActivities.Repository.Factory.MglHhPpsFactory.CreateFrom(entity);
        }
    }
}
