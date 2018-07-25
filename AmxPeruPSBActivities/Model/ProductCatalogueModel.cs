using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class ProductCatalogueModel
    {
        public string CatalogueId { get; set; }
        public string ParentCatalogueId { get; set; }
        public string CatalogueName { get; set; }
        public string ParentCatalogueName { get; set; }
        public string CatalogueType { get; set; }
    }
}
