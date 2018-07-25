using Ericsson.ETELCRM.CrmFoundationLibrary.ServiceClient.Entities;
using Ericsson.ETELCRM.Entities.Crm.CustomEntities;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Model.ProductOfferingPrice
{
    class AmxCoProductOfferingPriceModel
    {
        public Guid amxperu_productofferingpriceid { get; set; }
        public String amxperu_externalid { get; set; }
        public String amxperu_name { get; set; }
        public OptionSetValue amxperu_periodcode { get; set; }
        public Microsoft.Xrm.Sdk.Money amxperu_price { get; set; }
        public Microsoft.Xrm.Sdk.Money amxperu_price_base { get; set; }
        public OptionSetValue amxperu_pricetypecode { get; set; }
        public Guid amxperu_productofferingid { get; set; }
        public Guid transactioncurrencyid { get; set; }
    }
}
