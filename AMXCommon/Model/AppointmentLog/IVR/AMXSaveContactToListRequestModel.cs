using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMXCommon.Model.AppointmentLog
{
    public class AMXSaveContactToListRequestModel
    {
        public string userContactID { get; set; }
        public string contactListName { get; set; }
        public AmxWorkflowPlugin.VP_POMAgentAPIService.AttributeType[] attributeObj { get; set; }
    }

    //public class AttributeType {
    //    public string name { get; set; }
    //    public string value { get; set; }
    //    public string type { get; set; }
    //    public string displayName { get; set; }
    //    public bool masked { get; set; }
    //    public bool readOnly { get; set; }
    //}
}
