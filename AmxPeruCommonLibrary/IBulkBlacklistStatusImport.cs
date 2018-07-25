using Ericsson.ETELCRM.CrmFoundationLibrary.Business;
using Ericsson.ETELCRM.Entities.Crm;
using System;
using System.Collections.Generic;

namespace AmxPeruCommonLibrary.Business
{
    public interface IBulkBlacklistStatusImport : IBusinessBase
    {
        void InitiateBulkBlacklistImport(Annotation annotation);

        void Submit(Guid biChangeBlackStatus, bool CustomerNotFound, string description);

        List<Annotation> RetrieveByObjId(string entityLogicalName, Guid primaryEntityId);

        void SingleChangeBlacklistStatusProcess(etel_bi_changeblackliststatus biChangeBlackStatus, ref bool CustomerNotFound);

        void MultipleChangeBlacklistStatusProcess(etel_bi_changeblackliststatus biChangeBlackStatus);
    }
}