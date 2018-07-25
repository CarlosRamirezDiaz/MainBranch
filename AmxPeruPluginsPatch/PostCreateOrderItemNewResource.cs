using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace AmxPeruPluginsPatch
{
    public class PostCreateOrderItemNewResource : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            try
            {
                // Obtain the execution context from the service provider.
                IPluginExecutionContext context =
                    (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

                // Get a reference to the Organization service.
                IOrganizationServiceFactory factory =
                    (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = factory.CreateOrganizationService(context.UserId);

                Entity OrderItem = (Entity)context.InputParameters["Target"];
                Entity PostEntityImage = (Entity)context.PostEntityImages["POSTIMG"];

                string fetchXmlResourceSpecification = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>
                                                            <entity name='amxperu_resourcespecification'>
                                                            <attribute name='amxperu_resourcespecificationid' />
                                                            <attribute name='amxperu_name' />
                                                            <attribute name='createdon' />
                                                            <attribute name='amxperu_resourcetype' />
                                                            <order attribute='amxperu_name' descending='false' />
                                                            <link-entity name='amxperu_productspecification_resourcespec' from='amxperu_resourcespecificationid' to='amxperu_resourcespecificationid' visible='false' intersect='true'>
                                                                <link-entity name='etel_productspecification' from='etel_productspecificationid' to='etel_productspecificationid' alias='ao'>
                                                                <link-entity name='product' from='etel_productspecificationid' to='etel_productspecificationid' alias='ap'>
                                                                    <filter type='and'>
                                                                    <condition attribute='productid' operator='eq' uitype='product' value='{0}' />
                                                                    </filter>
                                                                </link-entity>
                                                                </link-entity>
                                                            </link-entity>
                                                            </entity>
                                                        </fetch>";
                Guid OfferingGuid = (PostEntityImage.Attributes.Contains("etel_offeringid")) ? (PostEntityImage.Attributes["etel_offeringid"] as EntityReference).Id : Guid.Empty;
                fetchXmlResourceSpecification = string.Format(fetchXmlResourceSpecification, OfferingGuid.ToString());
                EntityCollection ResourceSpecifications = service.RetrieveMultiple(new FetchExpression(fetchXmlResourceSpecification));
                if (ResourceSpecifications != null)
                {
                    if (ResourceSpecifications.Entities.Count > 0)
                    {
                        //Create Order Subscription
                        Entity OrderSubscription = new Entity("etel_ordersubscription");
                        OrderSubscription.Attributes.Add("etel_orderitemid", new EntityReference(OrderItem.LogicalName, OrderItem.Id));
                        Guid createdOrderSubscriptionId = service.Create(OrderSubscription);
                        OrderSubscription.Id = createdOrderSubscriptionId;

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
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}