using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Repository
{
    class RepositoryBase<T> where T : Entity
    {
        XrmDataContextProvider _xrmDataContextProvider;


        public RepositoryBase(XrmDataContextProvider xrmDataContextProvider)
        {
            _xrmDataContextProvider = xrmDataContextProvider;
        }

        /// <summary>
        /// Retrieves an entity object with its Id
        /// </summary>
        /// <param name="id">ID of the record</param>
        /// <returns>an entity object</returns>
        public T RetrieveById(Guid id)
        {
            FieldInfo entityName = typeof(T).GetFields().FirstOrDefault(f => f.Name.Equals("EntityLogicalName"));

            Entity entity = _xrmDataContextProvider.OrganizationService.Retrieve(entityName.GetRawConstantValue().ToString(), id, new ColumnSet(true));

            return entity.ToEntity<T>();
        }
    }
}
