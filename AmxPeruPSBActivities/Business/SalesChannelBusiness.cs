using AmxPeruPSBActivities.Repository;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    class SalesChannelBusiness
    {
        XrmDataContextProvider _xrmDataContextProvider;

        /// <summary>
        /// Returns sales channel id of user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Sales Channel Id</returns>
        public Guid RetrieveSalesChannelIdByUser(Guid userId)
        {
            RepositoryBase<SystemUser> systemUserRep = new RepositoryBase<SystemUser>(_xrmDataContextProvider);
            var systemUser = (SystemUser)systemUserRep.RetrieveById(userId);

            if (systemUser.etel_saleschannelid == null)
            {
                return Guid.Empty;
            }

            return systemUser.etel_saleschannelid.Id;
        }
    }
}
