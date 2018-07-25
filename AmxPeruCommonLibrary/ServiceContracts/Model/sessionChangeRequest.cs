using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruCommonLibrary.ServiceContracts.Model
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/sessionchange")]
    public partial class sessionChangeRequest
    {

        private valuesListpartRequest[] valuesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
        public valuesListpartRequest[] values
        {
            get
            {
                return this.valuesField;
            }
            set
            {
                this.valuesField = value;
            }
        }
    }
}
