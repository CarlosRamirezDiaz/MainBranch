using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruBillCycleChangefromOMRequest 
    {
        public string channel { get; set; }

        public string createdDate { get; set; }

        public int version { get; set; }

        public string requestedCompletionDate { get; set; }

        public string description { get; set; }

        public RelatedParties[] relatedParties { get; set; }

        public OrderItems[] orderItems { get; set; }

        public bool run { get; set; }
    }

    public class RelatedParties
    {
        public string role;
        public string reference;
    }

    public class OrderItems
    {
        public Item item { get; set; }
    }

    public class Item
    {
        public string orderType { get; set; }

        public string action { get; set; }

        public Attrs[] attrs { get; set; }

    }

    public class Attrs
    {
        public string name { get; set; }

        public string value { get; set; }

    }
}
