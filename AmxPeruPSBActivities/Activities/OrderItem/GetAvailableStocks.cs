using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.AvailableStocks;
using AmxPeruPSBActivities.Mapping;
using Ericsson.ETELCRM.CrmFoundationLibrary.Entities;
using AmxPeruPSBActivities.Helpers;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class GetAvailableStocks : XrmAwareCodeActivity
    {

        public InArgument<string> PartNumber { get; set; }
        public InArgument<string> UserId { get; set; }

        public OutArgument<List<AvailabeStock>> AvailableStocks { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var partNumber = PartNumber.Get(context);
            var userId = UserId.Get(context);
          
            var ermsResultText = new Service.AvailableStocks.AvailableStockBroker().GetAvailableStock(context, partNumber, userId);
            var ermsResult = (AvailableStockResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(ermsResultText.ToString(), typeof(AvailableStockResponse));
            var result = new MapSellableStockLevelToAvailableStock().Map(ermsResult);

            AvailableStocks.Set(context, result);
        }
        
    }
}
