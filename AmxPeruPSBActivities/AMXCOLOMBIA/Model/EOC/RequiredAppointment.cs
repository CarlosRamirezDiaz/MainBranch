using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model.EOC
{
    public class RequiredAppointment
    {
        public RequiredAppointment()
        {
            this.OrdemItems = new List<RequiredAppointmentOrderItem>();
        }

        public List<RequiredAppointmentOrderItem> OrdemItems { get; set; }
    }

    public class RequiredAppointmentOrderItem
    {
        public RequiredAppointmentOrderItem()
        {
            this.relatedBIref = new List<string>();
            this.BusinessInteractions = new List<BusinessInteraction>();
            this.BIdeliveryOptions = new List<string>();
        }

        public string BIobjectId { get; set; }
        public List<string> relatedBIref { get; set; } // reference to another Bi object
        public string itemName { get; set; } //itemName(ex: PO_AccessoHFC)
        public string OfferingName { get; set; } //itemName(ex: Equipo DOCSIS 3)       
        public string itemId { get; set; }  // (ex: 002)
        public string itemAction { get; set; } // (ex: add)
        public int relatedAddress { get; set; }
        public string serviceOrderType { get; set; }    // calculated using item action
        public string serviceOrderSubType { get; set; }  // calculated using itemAction + hhpp technology
        public int workOrderType { get; set; } // (calculated using itemAction + hhpp technology + parentServices)
        public string BIType { get; set; }  // "workOrder";
        public List<string> BIdeliveryOptions { get; set; }
        public List<BusinessInteraction> BusinessInteractions { get; set; }
        public string Technology { get; internal set; }
    }

    public class BusinessInteraction
    {
        public string workOrderSla { get; set; } //(fetched from result workOrderType)
        public string technology { get; set; } //(fetched from result workOrderType)
        public string workOrderCode { get; set; }
        public string workOrderDuration { get; set; } // fetched from result workOrderType)
        public string biType { get; set; }
        public string serviceOrderType { get; set; }
        public string serviceOrderSubType { get; set; }
        public string displayValue { get; set; }

    }
}
