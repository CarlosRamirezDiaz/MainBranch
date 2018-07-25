using AmxPeruPSBActivities.Model.AvailableStocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Mapping
{
    class MapSellableStockLevelToAvailableStock
    {
        public List<AvailabeStock> Map(AvailableStockResponse response)
        {
            List<AvailabeStock> result = new List<AvailabeStock>();

            foreach (var item in response.Items)
            {
                result.Add(new AvailabeStock
                {
                    Description = item.Description,
                    CharacteristicDescription = item.CharacteristicDescription,
                    SalesOrganizationRoleName = item.SalesOrganizationRoleName,
                    Quantity = item.Quantity,
                    StartSerialNumber = item.StartSerialNumber
                });
            }

            return result;
        }
        
    }
}
