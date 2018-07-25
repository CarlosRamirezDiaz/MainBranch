﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace AmxPeruCommonLibrary.ServiceContracts.GenericDirectoryNumberSearchService

{

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6", ConfigurationName = "GenericDirectoryNumberSearchService")]
    public interface GenericDirectoryNumberSearchService
    {

        // CODEGEN: Generating message contract since the operation genericDirectoryNumberSearch is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        genericDirectoryNumberSearchResponse1 genericDirectoryNumberSearch(genericDirectoryNumberSearchRequest1 request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<genericDirectoryNumberSearchResponse1> genericDirectoryNumberSearchAsync(genericDirectoryNumberSearchRequest1 request);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/genericdirectorynumbersearch")]
    public partial class genericDirectoryNumberSearchRequest
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/genericdirectorynumbersearch")]
    public partial class inputAttributes
    {

        private long npcodeField;

        private bool npcodeFieldSpecified;

        private string npcodePubField;

        private long plcodeField;

        private bool plcodeFieldSpecified;

        private string plcodePubField;

        private string dirnumField;

        private long submIdField;

        private bool submIdFieldSpecified;

        private string submIdPubField;

        private long hlcodeField;

        private bool hlcodeFieldSpecified;

        private string hlcodePubField;

        private long hmcodeField;

        private bool hmcodeFieldSpecified;

        private string hmcodePubField;

        private long vpnIdField;

        private bool vpnIdFieldSpecified;

        private string vpnIdPubField;

        private string prefixField;

        private string publicDnNumField;

        private long publicNpcodeField;

        private bool publicNpcodeFieldSpecified;

        private string publicNpcodePubField;

        private long sncodeField;

        private bool sncodeFieldSpecified;

        private string sncodePubField;

        private bool requiredMappingRuleField;

        private bool requiredMappingRuleFieldSpecified;

        private bool searchBlockField;

        private bool searchBlockFieldSpecified;

        private string minBlkSizeField;

        private string maxBlkSizeField;

        private parameterValuesListpartRequest[] parameterValuesField;

        private long[] dntypesField;

        private string[] statusesField;

        private string searchCountField;

        private bool reservationField;

        private bool reservationFieldSpecified;

        private string externalStateField;

        private long csIdField;

        private bool csIdFieldSpecified;

        private string csIdPubField;

        private long rscodeField;

        private bool rscodeFieldSpecified;

        private string rscodePubField;

        private bool csControlledField;

        private bool csControlledFieldSpecified;

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
        public long submId
        {
            get
            {
                return this.submIdField;
            }
            set
            {
                this.submIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool submIdSpecified
        {
            get
            {
                return this.submIdFieldSpecified;
            }
            set
            {
                this.submIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string submIdPub
        {
            get
            {
                return this.submIdPubField;
            }
            set
            {
                this.submIdPubField = value;
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
        public string prefix
        {
            get
            {
                return this.prefixField;
            }
            set
            {
                this.prefixField = value;
            }
        }

        /// <remarks/>
        public string publicDnNum
        {
            get
            {
                return this.publicDnNumField;
            }
            set
            {
                this.publicDnNumField = value;
            }
        }

        /// <remarks/>
        public long publicNpcode
        {
            get
            {
                return this.publicNpcodeField;
            }
            set
            {
                this.publicNpcodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool publicNpcodeSpecified
        {
            get
            {
                return this.publicNpcodeFieldSpecified;
            }
            set
            {
                this.publicNpcodeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string publicNpcodePub
        {
            get
            {
                return this.publicNpcodePubField;
            }
            set
            {
                this.publicNpcodePubField = value;
            }
        }

        /// <remarks/>
        public long sncode
        {
            get
            {
                return this.sncodeField;
            }
            set
            {
                this.sncodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sncodeSpecified
        {
            get
            {
                return this.sncodeFieldSpecified;
            }
            set
            {
                this.sncodeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string sncodePub
        {
            get
            {
                return this.sncodePubField;
            }
            set
            {
                this.sncodePubField = value;
            }
        }

        /// <remarks/>
        public bool requiredMappingRule
        {
            get
            {
                return this.requiredMappingRuleField;
            }
            set
            {
                this.requiredMappingRuleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool requiredMappingRuleSpecified
        {
            get
            {
                return this.requiredMappingRuleFieldSpecified;
            }
            set
            {
                this.requiredMappingRuleFieldSpecified = value;
            }
        }

        /// <remarks/>
        public bool searchBlock
        {
            get
            {
                return this.searchBlockField;
            }
            set
            {
                this.searchBlockField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool searchBlockSpecified
        {
            get
            {
                return this.searchBlockFieldSpecified;
            }
            set
            {
                this.searchBlockFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string minBlkSize
        {
            get
            {
                return this.minBlkSizeField;
            }
            set
            {
                this.minBlkSizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string maxBlkSize
        {
            get
            {
                return this.maxBlkSizeField;
            }
            set
            {
                this.maxBlkSizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
        public parameterValuesListpartRequest[] parameterValues
        {
            get
            {
                return this.parameterValuesField;
            }
            set
            {
                this.parameterValuesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("dnCode", IsNullable = false)]
        public long[] dntypes
        {
            get
            {
                return this.dntypesField;
            }
            set
            {
                this.dntypesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("dnStatus", IsNullable = false)]
        public string[] statuses
        {
            get
            {
                return this.statusesField;
            }
            set
            {
                this.statusesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string searchCount
        {
            get
            {
                return this.searchCountField;
            }
            set
            {
                this.searchCountField = value;
            }
        }

        /// <remarks/>
        public bool reservation
        {
            get
            {
                return this.reservationField;
            }
            set
            {
                this.reservationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool reservationSpecified
        {
            get
            {
                return this.reservationFieldSpecified;
            }
            set
            {
                this.reservationFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string externalState
        {
            get
            {
                return this.externalStateField;
            }
            set
            {
                this.externalStateField = value;
            }
        }

        /// <remarks/>
        public long csId
        {
            get
            {
                return this.csIdField;
            }
            set
            {
                this.csIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool csIdSpecified
        {
            get
            {
                return this.csIdFieldSpecified;
            }
            set
            {
                this.csIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string csIdPub
        {
            get
            {
                return this.csIdPubField;
            }
            set
            {
                this.csIdPubField = value;
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
        public bool csControlled
        {
            get
            {
                return this.csControlledField;
            }
            set
            {
                this.csControlledField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool csControlledSpecified
        {
            get
            {
                return this.csControlledFieldSpecified;
            }
            set
            {
                this.csControlledFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/genericdirectorynumbersearch")]
    public partial class parameterValuesListpartRequest
    {

        private string prmValueStringField;

        private long prmNoField;

        private bool prmNoFieldSpecified;

        private string resourceLikeField;

        /// <remarks/>
        public string prmValueString
        {
            get
            {
                return this.prmValueStringField;
            }
            set
            {
                this.prmValueStringField = value;
            }
        }

        /// <remarks/>
        public long prmNo
        {
            get
            {
                return this.prmNoField;
            }
            set
            {
                this.prmNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool prmNoSpecified
        {
            get
            {
                return this.prmNoFieldSpecified;
            }
            set
            {
                this.prmNoFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string resourceLike
        {
            get
            {
                return this.resourceLikeField;
            }
            set
            {
                this.resourceLikeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/genericdirectorynumbersearch")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/genericdirectorynumbersearch")]
    public partial class directorynumbersListpartResponse
    {

        private long dnIdField;

        private bool dnIdFieldSpecified;

        private string dirnumField;

        private long npcodeField;

        private bool npcodeFieldSpecified;

        private long dnCodeField;

        private bool dnCodeFieldSpecified;

        private string dnStatusField;

        private long portIdField;

        private bool portIdFieldSpecified;

        private long hlcodeField;

        private bool hlcodeFieldSpecified;

        private long hmcodeField;

        private bool hmcodeFieldSpecified;

        private string desField;

        private long vpnIdField;

        private bool vpnIdFieldSpecified;

        private blocksListpartResponse[] blocksField;

        private long rscodeField;

        private bool rscodeFieldSpecified;

        private long sdpIdField;

        private bool sdpIdFieldSpecified;

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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/genericdirectorynumbersearch")]
    public partial class genericDirectoryNumberSearchResponse
    {

        private directorynumbersListpartResponse[] directorynumbersField;

        private bool searchIsCompleteField;

        private bool searchIsCompleteFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
        public directorynumbersListpartResponse[] directorynumbers
        {
            get
            {
                return this.directorynumbersField;
            }
            set
            {
                this.directorynumbersField = value;
            }
        }

        /// <remarks/>
        public bool searchIsComplete
        {
            get
            {
                return this.searchIsCompleteField;
            }
            set
            {
                this.searchIsCompleteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool searchIsCompleteSpecified
        {
            get
            {
                return this.searchIsCompleteFieldSpecified;
            }
            set
            {
                this.searchIsCompleteFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/sessionchange")]
    public partial class valuesListpartRequest
    {

        private string keyField;

        private string valueField;

        /// <remarks/>
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

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

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class genericDirectoryNumberSearchRequest1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/genericdirectorynumbersearch", Order = 0)]
        public genericDirectoryNumberSearchRequest genericDirectoryNumberSearchRequest;

        public genericDirectoryNumberSearchRequest1()
        {
        }

        public genericDirectoryNumberSearchRequest1(genericDirectoryNumberSearchRequest genericDirectoryNumberSearchRequest)
        {
            this.genericDirectoryNumberSearchRequest = genericDirectoryNumberSearchRequest;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class genericDirectoryNumberSearchResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ericsson.com/services/ws_CIL_6/genericdirectorynumbersearch", Order = 0)]
        public genericDirectoryNumberSearchResponse genericDirectoryNumberSearchResponse;

        public genericDirectoryNumberSearchResponse1()
        {
        }

        public genericDirectoryNumberSearchResponse1(genericDirectoryNumberSearchResponse genericDirectoryNumberSearchResponse)
        {
            this.genericDirectoryNumberSearchResponse = genericDirectoryNumberSearchResponse;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GenericDirectoryNumberSearchServiceChannel : GenericDirectoryNumberSearchService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GenericDirectoryNumberSearchServiceClient : System.ServiceModel.ClientBase<GenericDirectoryNumberSearchService>, GenericDirectoryNumberSearchService
    {

        public GenericDirectoryNumberSearchServiceClient()
        {
        }

        public GenericDirectoryNumberSearchServiceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public GenericDirectoryNumberSearchServiceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public GenericDirectoryNumberSearchServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public GenericDirectoryNumberSearchServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        genericDirectoryNumberSearchResponse1 GenericDirectoryNumberSearchService.genericDirectoryNumberSearch(genericDirectoryNumberSearchRequest1 request)
        {
            return base.Channel.genericDirectoryNumberSearch(request);
        }

        public genericDirectoryNumberSearchResponse genericDirectoryNumberSearch(genericDirectoryNumberSearchRequest genericDirectoryNumberSearchRequest)
        {
            genericDirectoryNumberSearchRequest1 inValue = new genericDirectoryNumberSearchRequest1();
            inValue.genericDirectoryNumberSearchRequest = genericDirectoryNumberSearchRequest;
            genericDirectoryNumberSearchResponse1 retVal = ((GenericDirectoryNumberSearchService)(this)).genericDirectoryNumberSearch(inValue);
            return retVal.genericDirectoryNumberSearchResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<genericDirectoryNumberSearchResponse1> GenericDirectoryNumberSearchService.genericDirectoryNumberSearchAsync(genericDirectoryNumberSearchRequest1 request)
        {
            return base.Channel.genericDirectoryNumberSearchAsync(request);
        }

        public System.Threading.Tasks.Task<genericDirectoryNumberSearchResponse1> genericDirectoryNumberSearchAsync(genericDirectoryNumberSearchRequest genericDirectoryNumberSearchRequest)
        {
            genericDirectoryNumberSearchRequest1 inValue = new genericDirectoryNumberSearchRequest1();
            inValue.genericDirectoryNumberSearchRequest = genericDirectoryNumberSearchRequest;
            return ((GenericDirectoryNumberSearchService)(this)).genericDirectoryNumberSearchAsync(inValue);
        }
    }
}
