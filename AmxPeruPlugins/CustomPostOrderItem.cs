using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public class CustomPostOrderItem : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the execution context from the service provider.
            IPluginExecutionContext context =
                (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Get a reference to the Organization service.
            IOrganizationServiceFactory factory =
                (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            Entity OrderItem = (Entity)context.InputParameters["Target"];

            //Entity orderResource = new Entity("etel_orderresource");
            //orderResource["etel_name"] = "resource name given ";
            //// orderResource["etel_ordersubscriptionid"] = new EntityReference(etel_ordersubscription.EntityLogicalName, subscription.Id);
            //orderResource["etel_orderitemid"] = new EntityReference("etel_orderitem", context.PrimaryEntityId);
            ////orderResource["etel_productresourcespecification"] = new EntityReference("etel_productresourcespecification", Guid.Empty);
            //orderResource["etel_isrequired"] = true;
            //orderResource["etel_offeringid"] = new EntityReference("product", Guid.Parse("{481E958E-867E-E711-8126-00505601173A}"));
            //orderResource["etel_ismarketingresource"] = true;
            //service.Create(orderResource);

            //Create Order Subscription
            Entity OrderSubscription = new Entity("etel_ordersubscription");
            OrderSubscription.Attributes.Add("etel_orderitemid", new EntityReference(OrderItem.LogicalName, OrderItem.Id));

            //Resource Type MSISDN
            Entity OrderItemResourceMSISDN = new Entity("etel_orderresource");
            OrderItemResourceMSISDN["etel_name"] = "Resource Type MSISDN";
            OrderItemResourceMSISDN["etel_productresourcespecification"] = new EntityReference("etel_productresourcespecification", new Guid("242C6E27-F478-E711-8123-00505601173A"));
            OrderItemResourceMSISDN["etel_ordersubscriptionid"] = new EntityReference(OrderSubscription.LogicalName, OrderSubscription.Id);
            OrderItemResourceMSISDN["etel_orderitemid"] = new EntityReference("etel_orderitem", OrderItem.Id);
            OrderItemResourceMSISDN["etel_isrequired"] = true;
            //OrderItemResourceMSISDN["etel_offeringid"] = new EntityReference("product", Guid.Parse("{481E958E-867E-E711-8126-00505601173A}"));
            OrderItemResourceMSISDN["etel_ismarketingresource"] = true;
            service.Create(OrderItemResourceMSISDN);

            //Resource Type SIM
            Entity OrderItemResourceSIM = new Entity("etel_orderresource");
            OrderItemResourceSIM["etel_name"] = "Resource Type SIM";
            OrderItemResourceSIM["etel_productresourcespecification"] = new EntityReference("etel_productresourcespecification", new Guid("252C6E27-F478-E711-8123-00505601173A"));
            OrderItemResourceSIM["etel_ordersubscriptionid"] = new EntityReference(OrderSubscription.LogicalName, OrderSubscription.Id);
            OrderItemResourceSIM["etel_orderitemid"] = new EntityReference("etel_orderitem", OrderItem.Id);
            OrderItemResourceSIM["etel_isrequired"] = true;
            //OrderItemResourceSIM["etel_offeringid"] = new EntityReference("product", Guid.Parse("{481E958E-867E-E711-8126-00505601173A}"));
            OrderItemResourceSIM["etel_ismarketingresource"] = true;
            service.Create(OrderItemResourceSIM);
        }
    }
}