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

namespace AmxPeruPlugins.Workflow.Bulk_Import
{
    public class BulkImport : CodeActivity
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
                        IndividualCustomerImport individualCustomerImport = new IndividualCustomerImport(actionContext);

                        individualCustomerImport.InitiateImport(annotation);
                    }
                    else
                    {
                        throw new Exception(string.Format("Annotation not found with PrimaryEntityID : {0} ", context.PrimaryEntityId) + "- Thread Id : " + Thread.CurrentThread.ManagedThreadId);
                    }
                }
            }
            catch (Exception ex)
            {
                var log = actionContext.Resolve<IExceptionLogBL>().HandleProcessError(ex);
                throw new Exception(ex.Message);
            }
        }

    }
}
