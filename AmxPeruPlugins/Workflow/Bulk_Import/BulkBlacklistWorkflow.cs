using AmxPeruCommonLibrary.Business;
using Ericsson.ETELCRM.CrmFoundationLibrary.Exceptions.BaseExceptions;
using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace AmxPeruPlugins.Workflow.Bulk_Import
{
    public class BulkBlacklistWorkflow : CodeActivity
    {
        protected override void Execute(CodeActivityContext executionContext)
        {
            IActionContext actionContext = Ericsson.ETELCRM.Business.BusinessInitializer.BuildWorkflowContext(executionContext);
            IWorkflowContext extension = executionContext.GetExtension<IWorkflowContext>();
            IBulkBlacklistStatusImport blacklistStatusImport = actionContext.Resolve<IBulkBlacklistStatusImport>();
            etel_bi_changeblackliststatus biChangeBlackStatus = blacklistStatusImport.RetrieveById("etel_bi_changeblackliststatus", extension.PrimaryEntityId) as etel_bi_changeblackliststatus;
            bool CustomerNotFound = false;
            if (biChangeBlackStatus.etel_ismultiplerequest.HasValue)
            {
                bool? ismultiplerequest = biChangeBlackStatus.etel_ismultiplerequest;
                bool flag = true;
                if ((ismultiplerequest.GetValueOrDefault() == flag ? (ismultiplerequest.HasValue ? 1 : 0) : 0) != 0)
                {
                    try
                    {
                        blacklistStatusImport.MultipleChangeBlacklistStatusProcess(biChangeBlackStatus);
                        return;
                    }
                    catch (UserLevelException ex)
                    {
                        throw new InvalidWorkflowException(ex.Message.ToString());
                    }
                }
            }
            try
            {
                blacklistStatusImport.SingleChangeBlacklistStatusProcess(biChangeBlackStatus, ref CustomerNotFound);
            }
            catch (UserLevelException ex)
            {
                biChangeBlackStatus.etel_description = ex.ErrorCode;
            }
            catch (Exception ex)
            {
                biChangeBlackStatus.etel_description = ex.Message;
            }
            finally
            {
                blacklistStatusImport.Submit(biChangeBlackStatus.Id, CustomerNotFound, biChangeBlackStatus.etel_description);
            }
        }
    }
}