using AmxPeruCommonLibrary.BssServiceConfigMgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle
{
    public class BillCycleChangeEOCRequest
    {
        public RelatedEntity relatedEntities { get; set; }
        public RelatedParty relatedParties { get; set; }
        public OrderItems orderItems { get; set; }
        public DateTime createdDate { get; set; }
        public int version { get; set; }
        public DateTime requestedCompletionDate { get; set; }
        public string description { get; set; }
        public bool run { get; set; }
        
    }
    public class RelatedParty
    {
        public string role { get; set; }
        public int reference { get; set; }
    }
    public class RelatedEntity
    {
        public string type { get; set; }
        public string name { get; set; }
        public string reference { get; set; }
        public string dependentEntityName { get; set; }
        public Entity entity { get; set; }
    }

    public class OrderItems
    {
        public Item item { get; set; }
    }

    public class Item
    {
        public string orderType { get; set; }
        public string action { get; set; }
        public List<Attributes> attrs { get; set; }
    }

    public class Attributes
    {
        public string name {get;set;}
        public string value { get; set; }
    }

   
}
