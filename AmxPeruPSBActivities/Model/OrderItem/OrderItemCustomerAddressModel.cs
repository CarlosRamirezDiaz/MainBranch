using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.OrderItem
{
    public class OrderItemCustomerAddressModel
    {
        public string amx_addresstype { get; set; }

        public Guid amx_customeraddressid { get; set; }

        public string amx_name { get; set; }

        public Guid amx_orderitemcustomeraddressid { get; set; }

        public Guid amx_orderitemid { get; set; }
    }
}
