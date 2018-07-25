using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxDynamicsActivities.Common
{
    public class TraslationManage
    {
        public EntityCollection getTraslateFormMessage(string idForm, Guid guidUserId, OrganizationServiceProxy service)
        {
            EntityCollection ecReslt = null;
            int languageCode = 0;

            QueryExpression query = new QueryExpression("usersettings");
            query.ColumnSet = new ColumnSet("uilanguageid");
            query.Criteria.AddCondition("systemuserid", ConditionOperator.Equal, guidUserId);

            EntityCollection ecUserSetting = service.RetrieveMultiple(query);

            if (ecUserSetting.Entities.Count > 0) { languageCode = int.Parse(ecUserSetting.Entities[0]["uilanguageid"].ToString()); }
            else { languageCode = 3082; }

            QueryExpression queryTraslate = new QueryExpression("etel_translation");
            queryTraslate.ColumnSet = new ColumnSet("etel_code", "etel_message");
            queryTraslate.Criteria.AddCondition("etel_formid", ConditionOperator.Equal, idForm);
            queryTraslate.Criteria.AddCondition("etel_lcid", ConditionOperator.Equal, languageCode);

            ecReslt = service.RetrieveMultiple(queryTraslate);

            return ecReslt;
        }
    }
}
