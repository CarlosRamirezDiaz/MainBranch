using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxCoProductResourceCardinalityModel
    {
        public Guid amxperu_productresourcecardinalityid { get; set; }
        public String amxperu_name { get; set; }
        public Guid amxperu_productresourcespecificationid { get; set; }
        public Guid amxperu_productspecificationid { get; set; }
        public int amxperu_targetcardinalitymax { get; set; }
        public int amxperu_targetcardinalitymin { get; set; }
    }
}
