using AmxCoPSBActivities.AMXCOLOMBIA.Model;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Business
{
    public class AddUpdateOrderResourceBusiness
    {
        public AmxCoCreateUpdateResourceCharInput CreateUpdateOrderResource(OrganizationServiceProxy _org, AmxCoCreateUpdateResourceCharInput createUpdateResourceCharInput)
        {
            foreach (AmxCoOrderResourceModelInput orderResourceInput in createUpdateResourceCharInput.orderResourceInputList)
            {

                AmxCoOrderResourceModel orderResource = new AmxCoOrderResourceModel(orderResourceInput);

                // Check if resource exists and needs update or create
                if (orderResource.etel_orderresourceid == Guid.Empty)
                {
                    AmxCoOrderResourceRepository orderResourceRepository = new AmxCoOrderResourceRepository(_org);
                    orderResource.etel_orderresourceid = orderResourceRepository.Create(orderResource);
                    orderResourceInput.etel_orderresourceid = orderResource.etel_orderresourceid.ToString();

                    // Creating resource characteristics
                    AmxCoOrderResourceCharRepository orderResourceCharRepository = new AmxCoOrderResourceCharRepository(_org);
                    foreach (AmxCoOrderResourceCharModelInput orderResourceCharInput in orderResourceInput.orderResourceCharInputList)
                    {
                        var orderResourceChar = new AmxCoOrderResourceCharModel(orderResourceCharInput);

                        orderResourceChar.etel_orderresourceid = new EntityReference
                        {
                            Id = orderResource.etel_orderresourceid,
                            LogicalName = "etel_orderresource"
                        };
                        orderResourceCharInput.etel_orderresourcecharactericid = orderResourceCharRepository.Create(orderResourceChar).ToString();
                    }
                }
                else
                {
                    // Check if resource char exists in DB and requires update or create
                    AmxCoOrderResourceCharRepository orderResourceCharRepository = new AmxCoOrderResourceCharRepository(_org);
                    foreach (AmxCoOrderResourceCharModelInput orderResourceCharInput in orderResourceInput.orderResourceCharInputList)
                    {
                        AmxCoOrderResourceCharModel orderResourceChar = new AmxCoOrderResourceCharModel(orderResourceCharInput);

                        if (orderResourceChar.etel_orderresourcecharactericid == Guid.Empty)
                            orderResourceCharInput.etel_orderresourcecharactericid = orderResourceCharRepository.Create(orderResourceChar).ToString();
                        else
                            orderResourceCharRepository.Update(orderResourceChar);
                    }
                }
            }

            return createUpdateResourceCharInput;
        }
    }
}
