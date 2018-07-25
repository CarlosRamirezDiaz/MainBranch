using System.Activities;
using Ericsson.ETELCRM.Business;
using Ericsson.ETELCRM.CrmFoundationLibrary.Exceptions;
using Ericsson.ETELCRM.CrmFoundationLibrary.Exceptions.BaseExceptions;
using Ericsson.ETELCRM.Entities.Crm;
using Ericsson.ETELCRM.Integration.Logging;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Linq;
using Microsoft.Xrm.Sdk;
using System.Threading;
using System.ServiceModel;
using System.Collections.Generic;
using Ericsson.ETELCRM.Utility;
using Ericsson.ETELCRM.Business.BulkImport;

namespace AmxPeruPlugins.Workflow.ProductOfferingOperations
{
    public class ProductOfferingSync : CodeActivity
    {
        protected override void Execute(CodeActivityContext executionContext)
        {
            var actionContext = BusinessInitializer.BuildWorkflowContext(executionContext);
            var context = executionContext.GetExtension<IWorkflowContext>();

            try
            {
                if (context.PrimaryEntityName == Annotation.EntityLogicalName)
                {
                    var annotation = (Annotation)actionContext.OrganizationService.Retrieve(Annotation.EntityLogicalName, context.PrimaryEntityId, new Microsoft.Xrm.Sdk.Query.ColumnSet(true));

                    if (annotation != null)
                    {
                        if (annotation.ObjectId.LogicalName == "amxperu_productofferingsync")
                        {
                            ProductOfferingImport productOfferingImport = new ProductOfferingImport(actionContext);

                            productOfferingImport.InitiateImport(annotation);
                        }
                    }
                    else
                    {
                        throw new Exception(string.Format("Annotation not found with PrimaryEntityID : {0} ", context.PrimaryEntityId) + "- Thread Id : " + Thread.CurrentThread.ManagedThreadId);
                    }
                }
                else if (context.PrimaryEntityName == "amxperu_ecmrequest")
                {
                    ECMInfoTableImport infoTableImport = new ECMInfoTableImport(actionContext);

                    infoTableImport.InitiateImport(context.PrimaryEntityId);
                }
                else if (context.PrimaryEntityName == "amxperu_productversionhandler")
                {
                    ProductVersionHandler productVersionHandler = new ProductVersionHandler(actionContext);

                    productVersionHandler.Execute(context.PrimaryEntityId);
                }
                ////else if (context.PrimaryEntityName == "amxperu_productofferingsync")
                ////{
                ////    ProductOfferingImport productOfferingImport = new ProductOfferingImport(actionContext);

                ////    productOfferingImport.Execute(context.PrimaryEntityId);
                ////}
            }
            catch (Exception ex)
            {
                var log = actionContext.Resolve<IExceptionLogBL>().HandleProcessError(ex);
                throw new Exception(ex.Message);
            }
        }

    }
}
