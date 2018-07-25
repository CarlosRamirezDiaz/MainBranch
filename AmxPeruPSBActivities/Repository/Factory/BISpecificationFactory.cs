using AmxPeruPSBActivities.Model.BiSpecification;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Repository.Factory
{
    internal static class BISpecificationFactory
    {
        internal static Entity CreateEntityFrom(BISpecificationModel biSpecification)
        {
            Entity entity = new Entity("etel_businessinteractionspecification");

            return entity;
        }

        internal static BISpecificationModel CreateFrom(Entity entity)
        {
            var biSpecification = new BISpecificationModel();

            biSpecification.Id = entity.Id;

            if (entity.Contains("etel_name"))
                biSpecification.Name = entity.GetAttributeValue<string>("etel_name");

            if (entity.Contains("etel_requiresbiheader"))
                biSpecification.RequiresBiHeader = entity.GetAttributeValue<bool>("etel_requiresbiheader");

            if (entity.Contains("amx_senddigiturnonotification"))
                biSpecification.SendNotificationToDigiturno = entity.GetAttributeValue<bool>("amx_senddigiturnonotification");

            if (entity.Contains("amx_digiturnoid"))
                biSpecification.DigiturnoCode = entity.GetAttributeValue<int>("amx_digiturnoid");

            return biSpecification;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "etel_name"
                                                    ,"etel_requiresbiheader"
                                                    ,"amx_senddigiturnonotification"
                                                    ,"amx_digiturnoid"});
            }
        }
    }
}
