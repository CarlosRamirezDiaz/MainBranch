using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Model.Cfss;
using System.Collections.Generic;
using System;

namespace AmxPeruPSBActivities.Activities.Cfss
{
    public class RetrieveCfssListByProductExternalId : XrmAwareCodeActivity
    {
        public InArgument<string> ProductExternalId { get; set; }
        public OutArgument<List<CfssCharacteristicList>> CfssList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var productExternalId = ProductExternalId.Get(context);
            var cfssList = new List<CfssCharacteristicList>();

            QueryExpression prodSpec = new QueryExpression();
            prodSpec.EntityName = etel_productspecification.EntityLogicalName;

            LinkEntity prod = new LinkEntity(etel_productspecification.EntityLogicalName, Product.EntityLogicalName, "etel_productspecificationid", "etel_productspecificationid", JoinOperator.Inner);
            prod.EntityAlias = Product.EntityLogicalName;
            prod.LinkCriteria.AddCondition(new ConditionExpression("etel_externalid", ConditionOperator.Equal, productExternalId));
            prodSpec.LinkEntities.Add(prod);

            LinkEntity cfssProdSpec = new LinkEntity(etel_productspecification.EntityLogicalName, "amxperu_cfss_etel_productspecification", "etel_productspecificationid", "etel_productspecificationid", JoinOperator.Inner);
            cfssProdSpec.EntityAlias = "amxperu_cfss_etel_productspecification";
            prodSpec.LinkEntities.Add(cfssProdSpec);

            LinkEntity cfss = new LinkEntity("amxperu_cfss_etel_productspecification", "amxperu_cfss", "amxperu_cfssid", "amxperu_cfssid", JoinOperator.Inner);
            cfss.EntityAlias = "amxperu_cfss";
            cfssProdSpec.LinkEntities.Add(cfss);

            LinkEntity cfssCharUse = new LinkEntity("amxperu_cfss", "amxperu_cfsscharuse", "amxperu_cfssid", "amxperu_cfssid", JoinOperator.Inner);
            cfssCharUse.EntityAlias = "amxperu_cfsscharuse";
            cfssCharUse.Columns = new ColumnSet("amxperu_defaultvalue");
            cfssCharUse.LinkCriteria.AddCondition(new ConditionExpression("amxperu_editable", ConditionOperator.Equal, true));
            cfss.LinkEntities.Add(cfssCharUse);

            LinkEntity prodChar = new LinkEntity("amxperu_cfsscharuse", "etel_productcharacteristic", "amxperu_characteristicid", "etel_productcharacteristicid", JoinOperator.Inner);
            prodChar.EntityAlias = etel_productcharacteristic.EntityLogicalName;
            prodChar.Columns = new ColumnSet("etel_name", "etel_externalid");
            cfssCharUse.LinkEntities.Add(prodChar);

            var cfssListEntity = ContextProvider.OrganizationService.RetrieveMultiple(prodSpec)
                                               .Entities
                                               .ToList();

            foreach (var item in cfssListEntity)
            {
                cfssList.Add(new CfssCharacteristicList
                {
                    Name = item.GetAttributeValue<AliasedValue>("etel_productcharacteristic.etel_name")?.Value?.ToString(),
                    ExternalId = item.GetAttributeValue<AliasedValue>("etel_productcharacteristic.etel_externalid")?.Value?.ToString(),
                    Value = item.GetAttributeValue<AliasedValue>("amxperu_cfsscharuse.amxperu_defaultvalue")?.Value?.ToString() == "1"
                });
            }

            CfssList.Set(context, cfssList);
        }
    }
}
