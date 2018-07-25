using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruCommonLibrary.Repository.Offering
{
    public class AmxPeruProductCharacteristicRepository : AmxPeruRepositoryBase
    {
        public Entity RetrieveCharValueEntity(IOrganizationService organizationService, string charExternalId, string value)
        {

            var ProdCharValEntity = "etel_productcharacteristicvalue";
            var ProdCharEntity = "etel_productcharacteristic";

            var ProdCharVal_ProdCharValIdColumn = "etel_productcharacteristicvalueid";
            var ProdCharVal_ProdCharIdColumn = "etel_productcharacteristicid";
            var ProdCharVal_NameColumn = "etel_name";

            var ProdChar_ProdCharIdColumn = "etel_productcharacteristicid";
            var ProdChar_ExternalIdColumn = "etel_externalid";

            //Add Product Offering Entity to Query
            QueryExpression query = new QueryExpression();
            query.EntityName = ProdCharValEntity;
            query.ColumnSet.Columns.Add(ProdCharVal_ProdCharValIdColumn);
            query.Criteria.Conditions.Add
            (
                new ConditionExpression(ProdCharVal_NameColumn, ConditionOperator.Equal, value)
            );
            query.LinkEntities.Add(new LinkEntity(ProdCharValEntity, ProdCharEntity, ProdCharVal_ProdCharIdColumn, ProdChar_ProdCharIdColumn, JoinOperator.Inner));
            query.LinkEntities[0].LinkCriteria.Conditions.Add(
                new ConditionExpression(ProdChar_ExternalIdColumn, ConditionOperator.Equal, charExternalId));

            var result = organizationService.RetrieveMultiple(query);
            if (result != null && result.Entities != null && result.Entities.Count > 0)
            {
                return result.Entities.First();
            }
            else
            {
                throw new Exception("Couldn't find any product characteristic value with given external id : " + charExternalId + " and value : " + value);
            }

        }
    }
}
