using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.User;

namespace AmxCoPSBActivities.Repository.Factory
{
    internal static class UserFactory
    {
        internal static Entity CreateEntityFrom(UserModel user)
        {
            Entity entity = new Entity("systemuser");

            entity.Attributes.Add("fullname", user.FullName);

            return entity;
        }

        internal static UserModel CreateUserFrom(Entity entity)
        {
            var user = new UserModel();

            user.Id = entity.Id;

            if (entity.Contains("fullname"))
                user.FullName = entity.GetAttributeValue<string>("fullname");

            if (entity.Contains("internalemailaddress"))
                user.PrimaryEmailAddress = entity.GetAttributeValue<string>("internalemailaddress");

            return user;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] {
                    "fullname",
                    "internalemailaddress"} );
            }
        }
    }
}
