using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
   public class AmxPeruBillCycleChangefromOMResponse : BaseResponse
    {
        
        public string id { get; set; }

        
        public string createdBy { get; set; }

        
        public string createdDate { get; set; }

        
        public string modifiedBy { get; set; }

        
        public string lastModifiedDate { get; set; }

        
        public int version { get; set; }

        
        public string description { get; set; }

        
        public string orderType { get; set; }

        
        public string requestedCompletionDate { get; set; }

        
        public string state { get; set; }

        
        public string requestedStartDate { get; set; }

        
        public RelatedParties[] relatedParties { get; set; }

        
        public string notes { get; set; }

        
        public string externalID { get; set; }

        
        public string origOrderId { get; set; }

        
        public bool isBundled { get; set; }

        
        public string orderItems { get; set; }

        
        public string attrs { get; set; }

        
        public RelatedEntity[] relatedEntities { get; set; }

        
        public DateTime? completionDate { get; set; }

        
        public bool isLocked { get; set; }

        
        public string orderSpecification { get; set; }

        
        public string requester { get; set; }

        
        public string requestID { get; set; }

        
        public string mode { get; set; }

        
        public string relatedOrders { get; set; }

        
        public string interactionDate { get; set; }


    }

    public class RelatedEntity
    {
        public string type;
        public string name;
        public string reference;
        public string entitySpecification;
        public string dependentEntityName;
    }
}
