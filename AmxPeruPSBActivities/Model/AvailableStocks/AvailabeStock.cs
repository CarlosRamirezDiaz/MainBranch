using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.AvailableStocks
{
    public class AvailabeStock
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string CharacteristicDescription { get; set; }
        public string SalesOrganizationRoleName { get; set; }
        public int Quantity { get; set; }
        public string StartSerialNumber { get; set; }
    }
}
