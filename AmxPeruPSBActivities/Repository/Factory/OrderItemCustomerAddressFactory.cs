using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.OrderItem;

namespace AmxPeruPSBActivities.Repository.Factory
{
    class OrderItemCustomerAddressFactory
    {
        internal static Entity CreateEntityFrom(OrganizationServiceProxy org, OrderItemCustomerAddressModel orderItemCustomerAddress)
        {
            Entity entity = new Entity("amx_orderitemcustomeraddress");

            entity.Id = orderItemCustomerAddress.amx_orderitemcustomeraddressid;
            entity.Attributes.Add("amx_addresstype", orderItemCustomerAddress.amx_addresstype);
            entity.Attributes.Add("amx_name", orderItemCustomerAddress.amx_name);
            entity.Attributes.Add("amx_orderitemid", new EntityReference("etel_orderitem", orderItemCustomerAddress.amx_orderitemid));
            entity.Attributes.Add("amx_customeraddressid", new EntityReference("etel_customeraddress", orderItemCustomerAddress.amx_customeraddressid)); 

            return entity;
        }

        internal static OrderItemCustomerAddressModel CreateOrderItemCustomerAddressFrom(Entity entity)
        {
            var orderItemCustomerAddress = new OrderItemCustomerAddressModel();

            orderItemCustomerAddress.amx_orderitemcustomeraddressid = entity.Id;

            if (entity.Contains("amx_addresstype"))
                orderItemCustomerAddress.amx_addresstype = entity.Attributes["amx_addresstype"].ToString();
            if (entity.Contains("amx_name"))
                orderItemCustomerAddress.amx_name = entity.Attributes["amx_name"].ToString();
            if (entity.Contains("amx_orderitemid"))
                orderItemCustomerAddress.amx_orderitemid = ((EntityReference)entity.Attributes["amx_orderitemid"]).Id;
            if (entity.Contains("amx_customeraddressid"))
                orderItemCustomerAddress.amx_customeraddressid = ((EntityReference)entity.Attributes["amx_customeraddressid"]).Id;

            return orderItemCustomerAddress;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "amx_orderitemcustomeraddressid"
                                                    ,"amx_addresstype"
                                                    ,"amx_name"
                                                    ,"amx_orderitemid"
                                                    ,"amx_customeraddressid"});
            }
        }
    }
}
