using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.AvailableStocks
{
    class AvailableStockResponse
    {
        public List<AvailableStockItem> Items { get; set; }
        public AvailablePageInfo PageInfo { get; set; }
    }
}
