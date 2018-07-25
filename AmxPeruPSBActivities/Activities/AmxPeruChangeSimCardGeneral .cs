using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Ericsson.ETELCRM.Entities.Crm.CustomEntities;

namespace AmxPeruPSBActivities.Activities
{
   public class AmxPeruChangeSimCardGeneral : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruChangeSimCardGeneralRequest> SimChangeGeneralStageRequest { get; set; }
        public InArgument<List<OptionSet>> ChangeReasonList { get; set; }

        public OutArgument<AmxPeruChangeSimCardGeneralResponse> simChangeGeneralStageResponse { get; set; }
        protected override void Execute(XrmDataContext dataContext,CodeActivityContext context)
        {
            try
            {
                var simChangeGeneralStageRequest = SimChangeGeneralStageRequest.Get(context);
                var CurrentSimCard = string.Empty;
                CurrentSimCard = getSelectedResourceValues(ContextProvider.OrganizationService, simChangeGeneralStageRequest.ResourceID);
                var response = new AmxPeruChangeSimCardGeneralResponse();
                response.CurrentSimCard = CurrentSimCard;
                simChangeGeneralStageResponse.Set( context,  response);              

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
        public string getSelectedResourceValues(IOrganizationService service, string resourceID)
        {
            Entity ProductResouce = new Entity("etel_productresource");

            ColumnSet attributes = new ColumnSet(new string[] { "etel_productresourceid", "etel_serialnumber" });
            string simCardValue = string.Empty;
        
            ProductResouce = service.Retrieve(ProductResouce.LogicalName, new Guid(resourceID), attributes);
            if (ProductResouce != null)
            {
                simCardValue = ProductResouce.Attributes["etel_serialnumber"].ToString();
            }
            return simCardValue;
        }

    }
    public class GetResourceDetailsOfSubscription : XrmAwareCodeActivity
    {
        
        public InArgument<string> SubscriptionID { get; set; }
        public OutArgument<List<etel_productresource>> ResourceList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var subscriptionID = SubscriptionID.Get(context);
            var result = new List<etel_productresource>();
         
            QueryExpression resourceList = new QueryExpression { EntityName = "etel_productresource", ColumnSet = new ColumnSet(true) };
            resourceList.Criteria = new FilterExpression();
            resourceList.Criteria.AddCondition("etel_subscriptionid", ConditionOperator.Equal, new Guid(subscriptionID));
            EntityCollection ResourceCollectionList = ContextProvider.OrganizationService.RetrieveMultiple(resourceList);

            var resources = ResourceCollectionList.Entities.Select(s => (etel_productresource)s).ToList();
            foreach (var resource in resources)
            {
                var spec = (etel_productresourcespecification)ContextProvider.OrganizationService.Retrieve("etel_productresourcespecification", resource.etel_resourcespecificationid.Id, new ColumnSet(true));
                if (spec.etel_resourcetypecode.Value == 0)
                {
                    result.Add(resource);
                }
            }

            context.SetValue(ResourceList, result);

        }

    }
}
