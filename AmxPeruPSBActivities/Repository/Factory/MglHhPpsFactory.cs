using AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGL;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Repository.Factory
{
    internal static class MglHhPpsFactory
    {
        internal static Entity CreateFrom(MglHhPpsModel mglHHPPs)
        {
            Entity entity = new Entity("amx_mgllisthhpps");
            entity.Id = mglHHPPs.Id;

            return entity;
        }

        internal static MglHhPpsModel CreateFrom(Entity entity)
        {
            var mglHHPPs = new MglHhPpsModel();

            mglHHPPs.Id = entity.Id;

            if (entity.Contains("amx_nodetechnology"))
                mglHHPPs.Technology = entity.GetAttributeValue<string>("amx_nodetechnology");

            return mglHHPPs;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "amx_mgllisthhppsid"
                                                    ,"amx_nodetechnology"});
            }
        }
    }
}
