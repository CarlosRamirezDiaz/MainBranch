using AmxPeruPSBActivities.Model;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities.Configuration
{
    public class GetResourceSpecificationBusiness
    {
        public List<etel_productresourcespecification> GetResourceSpecification(OrganizationServiceProxy _org, Guid productSpecificationId)
        {
            List<etel_productresourcespecification> productResourceSpecificationList = new List<etel_productresourcespecification>();
            

            string relationshipEntityName = "amxperu_productresourcespecification_productspec";
            QueryExpression query = new QueryExpression("etel_productspecification");
            query.ColumnSet = new ColumnSet(true);
            LinkEntity linkEntity1 = new LinkEntity("etel_productspecification", relationshipEntityName, "etel_productspecificationid", "etel_productspecificationid", JoinOperator.Inner);
            LinkEntity linkEntity2 = new LinkEntity(relationshipEntityName, "etel_productresourcespecification", "etel_productresourcespecification", "etel_productresourcespecification", JoinOperator.Inner);
            linkEntity1.LinkEntities.Add(linkEntity2);
            query.LinkEntities.Add(linkEntity1);

            linkEntity2.LinkCriteria = new FilterExpression();

            linkEntity2.LinkCriteria.AddCondition(new ConditionExpression("etel_productspecificationid", ConditionOperator.Equal, productSpecificationId));

            EntityCollection collRecords = _org.RetrieveMultiple(query);

            return productResourceSpecificationList;
        }
    }
}
