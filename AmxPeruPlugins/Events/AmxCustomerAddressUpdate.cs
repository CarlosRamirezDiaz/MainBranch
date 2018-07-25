using Ericsson.ETELCRM.Business;
using Ericsson.ETELCRM.CrmCachingLibrary.Caching;
using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins.Events
{
    public class AmxCustomerAddressUpdate : BusinessBase, IAmxCustomerAddressUpdate
    {
        public AmxCustomerAddressUpdate(IActionContext context)
            : base(context)
        {

        }

        protected override void Execute()
        {           

            if (ActionContext.Context.MessageName.ToUpper() == "UPDATE")
            {
                if(ActionContext.Context.InputParameters.Contains("Target") &&
                    ActionContext.Context.InputParameters["Target"] is Entity)
                {
                    var PluginScopeEntity = (Entity)ActionContext.Context.InputParameters["Target"];                    
                    var AssociatedCustomerAddressRecordGuid = (PluginScopeEntity.Attributes.Contains("etel_customeraddress")) 
                                                                    ? (PluginScopeEntity.Attributes["etel_customeraddress"] as EntityReference).Id 
                                                                    : Guid.Empty;
                    

                    // var cacheManager = ActionContext.Resolve<ICacheManager>();


                //    var productCatalogues = cacheManager.GetOrAdd("cache.etel_offeringcatalogue",
                //() => {
                //    var productCatalogueSet = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                //    {
                //        EntityName = EntityProductCatalogue,
                //        ColumnSet = new ColumnSet(true),
                //    });
                //    return productCatalogueSet;
                //}
            //);


                    var contractBusiness = ActionContext.Resolve<IContractBusiness>();                    

                    var translationBusiness = ActionContext.Resolve<ITranslationBusiness>();

                    //List<etel_translation> translations = translationBusiness.GetTranslationMessageOfAnElement()
                    //throw new Exception(translationBusiness.GetTranslationMessageOfAnElement(ActionContext.,))


                    if (AssociatedCustomerAddressRecordGuid != Guid.Empty)
                    {                                                

                        try
                        {
                            var response = new addressWriteResponse1();
                            //using (var factory = new AmxPeruGenericProxy<AddressWriteService>("", ""))
                            //{
                            //    response = factory.Channel.addressWrite(MapToBSCS(PluginScopeEntity));
                            //};
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
        }

        //private addressWriteRequest1 MapToBSCS(Entity PluginScopeEntity)
        //{
        //    var mappedRequest = new addressWriteRequest1();
        //    mappedRequest.addressWriteRequest = new addressWriteRequest();
        //    var _inputAttributes = new inputAttributes();
        //    if(PluginScopeEntity.Attributes.Contains("amxperu_street1"))
        //    {
        //        _inputAttributes.adrStreet = PluginScopeEntity.FormattedValues["amxperu_street1"].ToString();
        //    }
                        
        //    var _sessionChangeRequest = new List<valuesListpartRequest>();
        //    _sessionChangeRequest.Add(new valuesListpartRequest() { key = "BU_ID", value = "2" });


        //    mappedRequest.addressWriteRequest.inputAttributes = _inputAttributes;
        //    mappedRequest.addressWriteRequest.sessionChangeRequest = new sessionChangeRequest()
        //    {
        //        values = _sessionChangeRequest.ToArray()
        //    };

        //    return mappedRequest;
        //}
        

    }
}
