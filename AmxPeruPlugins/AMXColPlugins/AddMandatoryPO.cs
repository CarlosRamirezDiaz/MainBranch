using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Data;
using System.ServiceModel;

namespace AmxPeruPlugins.AMXColPlugins
{
    public class AddMandatoryPO : IPlugin
    {
        IPluginExecutionContext _context = null;
        IOrganizationService _orgService = null;
        IOrganizationServiceFactory _orgServiceFactory = null;
        public void Execute(IServiceProvider serviceProvider)
        {
            _context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            _orgServiceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            _orgService = _orgServiceFactory.CreateOrganizationService(_context.UserId);

            try
            {
                //var logHelper = new LogHelper();
                //logHelper.createLog("before if: " + DateTime.Now);

                if (_context.InputParameters.Contains("Target") && _context.InputParameters["Target"] is Entity)
                {
                    Entity entity = (Entity)_context.InputParameters["Target"];
                    EntityReference Offer = ((EntityReference)entity.Attributes["etel_offeringid"]);
                    EntityReference OrderCapture = ((EntityReference)entity.Attributes["etel_orderid"]);


                    string srProductId = string.Empty;
                    if (entity.Attributes.Contains("amx_productsrid"))
                    {
                        srProductId = entity.Attributes["amx_productsrid"].ToString();
                    }

                    if (Offer != null && OrderCapture != null && string.IsNullOrEmpty(srProductId))
                    {
                        Guid OfferId = Offer.Id;
                        string OfferName = Offer.Name;
                        Guid OrderCaptureId = OrderCapture.Id;
                        if (OfferId != null)
                        {
                            string RetrievePO = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                  <entity name = 'etel_offeringassociation'>
                                                  <attribute name ='etel_offeringassociationid'/>
                                                  <attribute name ='etel_name'/>
                                                  <attribute name ='createdon'/>
                                                  <attribute name='etel_primaryofferingid'/>
                                                  <attribute name ='etel_offeringassociationtypeid'/>
                                                  <attribute name ='amxperu_associationtypecode'/>
                                                  <attribute name ='etel_secondaryofferingid'/>
                                                  <order attribute ='etel_name' descending = 'false'/>
                                                  <filter type='and'>
                                                  <condition attribute = 'etel_primaryofferingid' operator= 'eq'  uitype = 'product' value = '{0}' />
                                                  </filter>
                                                  </entity>
                                                  </fetch>";
                            EntityCollection AllOfeers = _orgService.RetrieveMultiple(new FetchExpression(string.Format(RetrievePO, OfferId)));
                            if (AllOfeers.Entities.Count != 0 && AllOfeers.Entities[0].Contains("amxperu_associationtypecode"))
                            {

                                foreach (Entity ent in AllOfeers.Entities)
                                {
                                    string AssociationType = ent.FormattedValues["amxperu_associationtypecode"].ToString();
                                    int AssociationTypeValue = ((OptionSetValue)ent.Attributes["amxperu_associationtypecode"]).Value;
                                    EntityReference PrimaryOffer = ((EntityReference)ent.Attributes["etel_primaryofferingid"]);
                                    Guid PrimaryOfferId = PrimaryOffer.Id;
                                    string PrimaryOfferName = PrimaryOffer.Name;
                                    EntityReference SecondaryOffer = ((EntityReference)ent.Attributes["etel_secondaryofferingid"]);
                                    Guid SecondaryOfferId = SecondaryOffer.Id;
                                    string SecondaryOfferName = SecondaryOffer.Name;

                                    
                                    if (AssociationTypeValue == 3 || AssociationTypeValue == 4)
                                    {
                                        Entity orderItem = new Entity("etel_orderitem");
                                        orderItem.Attributes["etel_offeringid"] = new EntityReference("product", SecondaryOfferId);
                                        orderItem.Attributes["etel_orderid"] = new EntityReference("etel_ordercapture", OrderCaptureId);
                                        Guid CreatedID=_orgService.Create(orderItem);
                                        //Logic To Update the Ordetitem with Parent PO
                                        string RetrieveOrderItem = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false' >
                                                                   <entity name = 'etel_orderitem'>
                                                                   <attribute name = 'etel_orderitemid'/>
                                                                   <attribute name = 'etel_name'/>
                                                                   <attribute name = 'createdon'/>
                                                                   <attribute name = 'etel_parentorderitemid'/>
                                                                   <attribute name = 'etel_offeringid'/>
                                                                   <order attribute = 'etel_name' descending = 'false'/>
                                                                   <filter type = 'and'>
                                                                   <condition attribute = 'etel_offeringid' operator= 'eq'  uitype = 'product' value = '{0}' />
                                                                   </filter>
                                                                   </entity>
                                                                   </fetch>";
                                        EntityCollection OrderItems = _orgService.RetrieveMultiple(new FetchExpression(string.Format(RetrieveOrderItem, PrimaryOfferId)));
                                        if (OrderItems.Entities.Count != 0 && OrderItems.Entities[0].Contains("etel_orderitemid"))
                                        {
                                            foreach (Entity Orders in OrderItems.Entities)
                                            {
                                                Guid Orderitem = Orders.Id;
                                                orderItem.Attributes["etel_parentorderitemid"] = new EntityReference("etel_orderitem", Orderitem);
                                                orderItem.Id = CreatedID;
                                                _orgService.Update(orderItem);
                                            }


                                        }
                                    }
                                    
                                }
                            }
                        }
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
