﻿using AmxPeruCommonLibrary.ServiceContracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruCommonLibrary.ServiceContracts.Services
{
    //------------------------------------------------------------------------------
    // <auto-generated>
    //     This code was generated by a tool.
    //     Runtime Version:4.0.30319.42000
    //
    //     Changes to this file may cause incorrect behavior and will be lost if
    //     the code is regenerated.
    // </auto-generated>
    //------------------------------------------------------------------------------



    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6", ConfigurationName = "GenericDirectoryNumberReadService")]
    public interface GenericDirectoryNumberReadService
    {

        // CODEGEN: Generating message contract since the operation genericDirectoryNumberRead is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        genericDirectoryNumberReadResponse1 genericDirectoryNumberRead(genericDirectoryNumberReadRequest1 request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<genericDirectoryNumberReadResponse1> genericDirectoryNumberReadAsync(genericDirectoryNumberReadRequest1 request);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/genericdirectorynumberread")]
    public partial class genericDirectoryNumberReadRequest
    {

        private inputAttributes inputAttributesField;

        private sessionChangeRequest sessionChangeRequestField;

        /// <remarks/>
        public inputAttributes inputAttributes
        {
            get
            {
                return this.inputAttributesField;
            }
            set
            {
                this.inputAttributesField = value;
            }
        }

        /// <remarks/>
        public sessionChangeRequest sessionChangeRequest
        {
            get
            {
                return this.sessionChangeRequestField;
            }
            set
            {
                this.sessionChangeRequestField = value;
            }
        }
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/genericdirectorynumberread")]
    public partial class blocksListpartResponse
    {

        private long dnBlockSeqnoField;

        private bool dnBlockSeqnoFieldSpecified;

        private string dnBlockStatusField;

        private long sizeField;

        private bool sizeFieldSpecified;

        private string lowField;

        private string highField;

        /// <remarks/>
        public long dnBlockSeqno
        {
            get
            {
                return this.dnBlockSeqnoField;
            }
            set
            {
                this.dnBlockSeqnoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dnBlockSeqnoSpecified
        {
            get
            {
                return this.dnBlockSeqnoFieldSpecified;
            }
            set
            {
                this.dnBlockSeqnoFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string dnBlockStatus
        {
            get
            {
                return this.dnBlockStatusField;
            }
            set
            {
                this.dnBlockStatusField = value;
            }
        }

        /// <remarks/>
        public long size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sizeSpecified
        {
            get
            {
                return this.sizeFieldSpecified;
            }
            set
            {
                this.sizeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string low
        {
            get
            {
                return this.lowField;
            }
            set
            {
                this.lowField = value;
            }
        }

        /// <remarks/>
        public string high
        {
            get
            {
                return this.highField;
            }
            set
            {
                this.highField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/genericdirectorynumberread")]
    public partial class genericDirectoryNumberReadResponse
    {

        private long dnIdField;

        private bool dnIdFieldSpecified;

        private string dirnumField;

        private string ndcField;

        private long npcodeField;

        private bool npcodeFieldSpecified;

        private string npcodePubField;

        private long plcodeField;

        private bool plcodeFieldSpecified;

        private string plcodePubField;

        private long dnCodeField;

        private bool dnCodeFieldSpecified;

        private string dnStatusField;

        private long portIdField;

        private bool portIdFieldSpecified;

        private string portNumField;

        private long hlcodeField;

        private bool hlcodeFieldSpecified;

        private string hlcodePubField;

        private long hmcodeField;

        private bool hmcodeFieldSpecified;

        private string hmcodePubField;

        private string desField;

        private long vpnIdField;

        private bool vpnIdFieldSpecified;

        private string vpnIdPubField;

        private string vpnNameField;

        private blocksListpartResponse[] blocksField;

        private long rscodeField;

        private bool rscodeFieldSpecified;

        private string rscodePubField;

        private long sdpIdField;

        private bool sdpIdFieldSpecified;

        private long businessUnitIdField;

        private bool businessUnitIdFieldSpecified;

        /// <remarks/>
        public long dnId
        {
            get
            {
                return this.dnIdField;
            }
            set
            {
                this.dnIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dnIdSpecified
        {
            get
            {
                return this.dnIdFieldSpecified;
            }
            set
            {
                this.dnIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string dirnum
        {
            get
            {
                return this.dirnumField;
            }
            set
            {
                this.dirnumField = value;
            }
        }

        /// <remarks/>
        public string ndc
        {
            get
            {
                return this.ndcField;
            }
            set
            {
                this.ndcField = value;
            }
        }

        /// <remarks/>
        public long npcode
        {
            get
            {
                return this.npcodeField;
            }
            set
            {
                this.npcodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool npcodeSpecified
        {
            get
            {
                return this.npcodeFieldSpecified;
            }
            set
            {
                this.npcodeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string npcodePub
        {
            get
            {
                return this.npcodePubField;
            }
            set
            {
                this.npcodePubField = value;
            }
        }

        /// <remarks/>
        public long plcode
        {
            get
            {
                return this.plcodeField;
            }
            set
            {
                this.plcodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool plcodeSpecified
        {
            get
            {
                return this.plcodeFieldSpecified;
            }
            set
            {
                this.plcodeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string plcodePub
        {
            get
            {
                return this.plcodePubField;
            }
            set
            {
                this.plcodePubField = value;
            }
        }

        /// <remarks/>
        public long dnCode
        {
            get
            {
                return this.dnCodeField;
            }
            set
            {
                this.dnCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dnCodeSpecified
        {
            get
            {
                return this.dnCodeFieldSpecified;
            }
            set
            {
                this.dnCodeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string dnStatus
        {
            get
            {
                return this.dnStatusField;
            }
            set
            {
                this.dnStatusField = value;
            }
        }

        /// <remarks/>
        public long portId
        {
            get
            {
                return this.portIdField;
            }
            set
            {
                this.portIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool portIdSpecified
        {
            get
            {
                return this.portIdFieldSpecified;
            }
            set
            {
                this.portIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string portNum
        {
            get
            {
                return this.portNumField;
            }
            set
            {
                this.portNumField = value;
            }
        }

        /// <remarks/>
        public long hlcode
        {
            get
            {
                return this.hlcodeField;
            }
            set
            {
                this.hlcodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool hlcodeSpecified
        {
            get
            {
                return this.hlcodeFieldSpecified;
            }
            set
            {
                this.hlcodeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string hlcodePub
        {
            get
            {
                return this.hlcodePubField;
            }
            set
            {
                this.hlcodePubField = value;
            }
        }

        /// <remarks/>
        public long hmcode
        {
            get
            {
                return this.hmcodeField;
            }
            set
            {
                this.hmcodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool hmcodeSpecified
        {
            get
            {
                return this.hmcodeFieldSpecified;
            }
            set
            {
                this.hmcodeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string hmcodePub
        {
            get
            {
                return this.hmcodePubField;
            }
            set
            {
                this.hmcodePubField = value;
            }
        }

        /// <remarks/>
        public string des
        {
            get
            {
                return this.desField;
            }
            set
            {
                this.desField = value;
            }
        }

        /// <remarks/>
        public long vpnId
        {
            get
            {
                return this.vpnIdField;
            }
            set
            {
                this.vpnIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool vpnIdSpecified
        {
            get
            {
                return this.vpnIdFieldSpecified;
            }
            set
            {
                this.vpnIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string vpnIdPub
        {
            get
            {
                return this.vpnIdPubField;
            }
            set
            {
                this.vpnIdPubField = value;
            }
        }

        /// <remarks/>
        public string vpnName
        {
            get
            {
                return this.vpnNameField;
            }
            set
            {
                this.vpnNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
        public blocksListpartResponse[] blocks
        {
            get
            {
                return this.blocksField;
            }
            set
            {
                this.blocksField = value;
            }
        }

        /// <remarks/>
        public long rscode
        {
            get
            {
                return this.rscodeField;
            }
            set
            {
                this.rscodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool rscodeSpecified
        {
            get
            {
                return this.rscodeFieldSpecified;
            }
            set
            {
                this.rscodeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string rscodePub
        {
            get
            {
                return this.rscodePubField;
            }
            set
            {
                this.rscodePubField = value;
            }
        }

        /// <remarks/>
        public long sdpId
        {
            get
            {
                return this.sdpIdField;
            }
            set
            {
                this.sdpIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sdpIdSpecified
        {
            get
            {
                return this.sdpIdFieldSpecified;
            }
            set
            {
                this.sdpIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        public long businessUnitId
        {
            get
            {
                return this.businessUnitIdField;
            }
            set
            {
                this.businessUnitIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool businessUnitIdSpecified
        {
            get
            {
                return this.businessUnitIdFieldSpecified;
            }
            set
            {
                this.businessUnitIdFieldSpecified = value;
            }
        }
    }    

    

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class genericDirectoryNumberReadRequest1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/genericdirectorynumberread", Order = 0)]
        public genericDirectoryNumberReadRequest genericDirectoryNumberReadRequest;

        public genericDirectoryNumberReadRequest1()
        {
        }

        public genericDirectoryNumberReadRequest1(genericDirectoryNumberReadRequest genericDirectoryNumberReadRequest)
        {
            this.genericDirectoryNumberReadRequest = genericDirectoryNumberReadRequest;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class genericDirectoryNumberReadResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/genericdirectorynumberread", Order = 0)]
        public genericDirectoryNumberReadResponse genericDirectoryNumberReadResponse;

        public genericDirectoryNumberReadResponse1()
        {
        }

        public genericDirectoryNumberReadResponse1(genericDirectoryNumberReadResponse genericDirectoryNumberReadResponse)
        {
            this.genericDirectoryNumberReadResponse = genericDirectoryNumberReadResponse;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GenericDirectoryNumberReadServiceChannel : GenericDirectoryNumberReadService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GenericDirectoryNumberReadServiceClient : System.ServiceModel.ClientBase<GenericDirectoryNumberReadService>, GenericDirectoryNumberReadService
    {

        public GenericDirectoryNumberReadServiceClient()
        {
        }

        public GenericDirectoryNumberReadServiceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public GenericDirectoryNumberReadServiceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public GenericDirectoryNumberReadServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public GenericDirectoryNumberReadServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        genericDirectoryNumberReadResponse1 GenericDirectoryNumberReadService.genericDirectoryNumberRead(genericDirectoryNumberReadRequest1 request)
        {
            return base.Channel.genericDirectoryNumberRead(request);
        }

        public genericDirectoryNumberReadResponse genericDirectoryNumberRead(genericDirectoryNumberReadRequest genericDirectoryNumberReadRequest)
        {
            genericDirectoryNumberReadRequest1 inValue = new genericDirectoryNumberReadRequest1();
            inValue.genericDirectoryNumberReadRequest = genericDirectoryNumberReadRequest;
            genericDirectoryNumberReadResponse1 retVal = ((GenericDirectoryNumberReadService)(this)).genericDirectoryNumberRead(inValue);
            return retVal.genericDirectoryNumberReadResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<genericDirectoryNumberReadResponse1> GenericDirectoryNumberReadService.genericDirectoryNumberReadAsync(genericDirectoryNumberReadRequest1 request)
        {
            return base.Channel.genericDirectoryNumberReadAsync(request);
        }

        public System.Threading.Tasks.Task<genericDirectoryNumberReadResponse1> genericDirectoryNumberReadAsync(genericDirectoryNumberReadRequest genericDirectoryNumberReadRequest)
        {
            genericDirectoryNumberReadRequest1 inValue = new genericDirectoryNumberReadRequest1();
            inValue.genericDirectoryNumberReadRequest = genericDirectoryNumberReadRequest;
            return ((GenericDirectoryNumberReadService)(this)).genericDirectoryNumberReadAsync(inValue);
        }
    }

}