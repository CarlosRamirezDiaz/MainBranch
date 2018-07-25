using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.Resources;

namespace AmxPeruPSBActivities.Activities.OrderItem
{

    public sealed class SIMCardOrderItemOperationsActivity : XrmAwareCodeActivity
    {
        public InArgument<Guid> OrderItemId { get; set; }
        public InArgument<SIMCardOrderResourceCharacteristicModel> SIMCardResourceCharModel { get; set; }
        public InArgument<bool> Validated { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var orderItemId = OrderItemId.Get(context);
            var simCardResourceCharModel = SIMCardResourceCharModel.Get(context);
            var validated = Validated.Get(context);

            var cartResourceChars = (from cartResource in dataContext.etel_orderresourceSet
                     join cartResourceChar in dataContext.etel_orderresourcecharactericSet on cartResource.Id equals cartResourceChar.etel_orderresourceid.Id
                     where cartResource.etel_orderitemid.Id == orderItemId && cartResource.etel_name.Contains("Sim")
                     select new { cartResourceChar }).ToList();

            foreach (var item in cartResourceChars)
            {
                var cartResourceChar = item.cartResourceChar;
                var update = false;

                var orderResourceCharacteristic = new etel_orderresourcecharacteric()
                {
                    etel_orderresourcecharactericId = cartResourceChar.etel_orderresourcecharactericId,
                };

                if (cartResourceChar.etel_name == "ICCID")
                {
                    orderResourceCharacteristic.etel_value = simCardResourceCharModel.ICCID;
                    update = true;
                }
                else if (cartResourceChar.etel_name == "IMSI")
                {
                    orderResourceCharacteristic.etel_value = simCardResourceCharModel.IMSI;
                    update = true;
                }
                else if (cartResourceChar.etel_name == "PUK")
                {
                    orderResourceCharacteristic.etel_value = simCardResourceCharModel.PUK;
                    update = true;
                }
                else if (cartResourceChar.etel_name == "KI")
                {
                    orderResourceCharacteristic.etel_value = simCardResourceCharModel.KI;
                    update = true;
                }
                else if (cartResourceChar.etel_name == "IMEI")
                {
                    orderResourceCharacteristic.etel_value = simCardResourceCharModel.IMEI;
                    update = true;
                }
                else if (cartResourceChar.etel_name == "Serial Number")
                {
                    orderResourceCharacteristic.etel_value = simCardResourceCharModel.SerialNumber;
                    update = true;
                }
                else if (cartResourceChar.etel_name == "Tecnologia")
                {
                    orderResourceCharacteristic.etel_value = simCardResourceCharModel.Technology;
                    update = true;
                }

                if (update)
                {
                    ContextProvider.OrganizationService.Update(orderResourceCharacteristic);
                }
            }
        }
    }
}
