﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmxSoapServicesActivities.StorageMediumSearch {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ericsson.com/services/ws_CIL_7", ConfigurationName="StorageMediumSearch.StorageMediumSearchService")]
    public interface StorageMediumSearchService {
        
        // CODEGEN: Generating message contract since the operation storageMediumSearch is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchResponse1 storageMediumSearch(AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchRequest1 request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchResponse1> storageMediumSearchAsync(AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchRequest1 request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ericsson.com/services/ws_CIL_7/storagemediumsearch")]
    public partial class storageMediumSearchRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private inputAttributes inputAttributesField;
        
        private sessionChangeRequest sessionChangeRequestField;
        
        /// <remarks/>
        public inputAttributes inputAttributes {
            get {
                return this.inputAttributesField;
            }
            set {
                this.inputAttributesField = value;
                this.RaisePropertyChanged("inputAttributes");
            }
        }
        
        /// <remarks/>
        public sessionChangeRequest sessionChangeRequest {
            get {
                return this.sessionChangeRequestField;
            }
            set {
                this.sessionChangeRequestField = value;
                this.RaisePropertyChanged("sessionChangeRequest");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ericsson.com/services/ws_CIL_7/storagemediumsearch")]
    public partial class inputAttributes : object, System.ComponentModel.INotifyPropertyChanged {
        
        private long plcodeField;
        
        private bool plcodeFieldSpecified;
        
        private string plcodePubField;
        
        private string stmednoField;
        
        private long submIdField;
        
        private bool submIdFieldSpecified;
        
        private string submIdPubField;
        
        private string portNumField;
        
        private long smcIdField;
        
        private bool smcIdFieldSpecified;
        
        private string smcIdPubField;
        
        private long hlcodeField;
        
        private bool hlcodeFieldSpecified;
        
        private string hlcodePubField;
        
        private string dirnumField;
        
        private string srchCountField;
        
        private bool reservationField;
        
        private bool reservationFieldSpecified;
        
        private string externalStateField;
        
        private bool includeReservedField;
        
        private bool includeReservedFieldSpecified;
        
        /// <remarks/>
        public long plcode {
            get {
                return this.plcodeField;
            }
            set {
                this.plcodeField = value;
                this.RaisePropertyChanged("plcode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool plcodeSpecified {
            get {
                return this.plcodeFieldSpecified;
            }
            set {
                this.plcodeFieldSpecified = value;
                this.RaisePropertyChanged("plcodeSpecified");
            }
        }
        
        /// <remarks/>
        public string plcodePub {
            get {
                return this.plcodePubField;
            }
            set {
                this.plcodePubField = value;
                this.RaisePropertyChanged("plcodePub");
            }
        }
        
        /// <remarks/>
        public string stmedno {
            get {
                return this.stmednoField;
            }
            set {
                this.stmednoField = value;
                this.RaisePropertyChanged("stmedno");
            }
        }
        
        /// <remarks/>
        public long submId {
            get {
                return this.submIdField;
            }
            set {
                this.submIdField = value;
                this.RaisePropertyChanged("submId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool submIdSpecified {
            get {
                return this.submIdFieldSpecified;
            }
            set {
                this.submIdFieldSpecified = value;
                this.RaisePropertyChanged("submIdSpecified");
            }
        }
        
        /// <remarks/>
        public string submIdPub {
            get {
                return this.submIdPubField;
            }
            set {
                this.submIdPubField = value;
                this.RaisePropertyChanged("submIdPub");
            }
        }
        
        /// <remarks/>
        public string portNum {
            get {
                return this.portNumField;
            }
            set {
                this.portNumField = value;
                this.RaisePropertyChanged("portNum");
            }
        }
        
        /// <remarks/>
        public long smcId {
            get {
                return this.smcIdField;
            }
            set {
                this.smcIdField = value;
                this.RaisePropertyChanged("smcId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool smcIdSpecified {
            get {
                return this.smcIdFieldSpecified;
            }
            set {
                this.smcIdFieldSpecified = value;
                this.RaisePropertyChanged("smcIdSpecified");
            }
        }
        
        /// <remarks/>
        public string smcIdPub {
            get {
                return this.smcIdPubField;
            }
            set {
                this.smcIdPubField = value;
                this.RaisePropertyChanged("smcIdPub");
            }
        }
        
        /// <remarks/>
        public long hlcode {
            get {
                return this.hlcodeField;
            }
            set {
                this.hlcodeField = value;
                this.RaisePropertyChanged("hlcode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool hlcodeSpecified {
            get {
                return this.hlcodeFieldSpecified;
            }
            set {
                this.hlcodeFieldSpecified = value;
                this.RaisePropertyChanged("hlcodeSpecified");
            }
        }
        
        /// <remarks/>
        public string hlcodePub {
            get {
                return this.hlcodePubField;
            }
            set {
                this.hlcodePubField = value;
                this.RaisePropertyChanged("hlcodePub");
            }
        }
        
        /// <remarks/>
        public string dirnum {
            get {
                return this.dirnumField;
            }
            set {
                this.dirnumField = value;
                this.RaisePropertyChanged("dirnum");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string srchCount {
            get {
                return this.srchCountField;
            }
            set {
                this.srchCountField = value;
                this.RaisePropertyChanged("srchCount");
            }
        }
        
        /// <remarks/>
        public bool reservation {
            get {
                return this.reservationField;
            }
            set {
                this.reservationField = value;
                this.RaisePropertyChanged("reservation");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool reservationSpecified {
            get {
                return this.reservationFieldSpecified;
            }
            set {
                this.reservationFieldSpecified = value;
                this.RaisePropertyChanged("reservationSpecified");
            }
        }
        
        /// <remarks/>
        public string externalState {
            get {
                return this.externalStateField;
            }
            set {
                this.externalStateField = value;
                this.RaisePropertyChanged("externalState");
            }
        }
        
        /// <remarks/>
        public bool includeReserved {
            get {
                return this.includeReservedField;
            }
            set {
                this.includeReservedField = value;
                this.RaisePropertyChanged("includeReserved");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool includeReservedSpecified {
            get {
                return this.includeReservedFieldSpecified;
            }
            set {
                this.includeReservedFieldSpecified = value;
                this.RaisePropertyChanged("includeReservedSpecified");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://lhsgroup.com/lhsws/money")]
    public partial class money : object, System.ComponentModel.INotifyPropertyChanged {
        
        private double amountField;
        
        private string currencyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public double amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
                this.RaisePropertyChanged("amount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string currency {
            get {
                return this.currencyField;
            }
            set {
                this.currencyField = value;
                this.RaisePropertyChanged("currency");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ericsson.com/services/ws_CIL_7/storagemediumsearch")]
    public partial class allStoragemediumsListpartResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string stmednoField;
        
        private long smcIdField;
        
        private bool smcIdFieldSpecified;
        
        private string smcIdPubField;
        
        private long dlCodeField;
        
        private bool dlCodeFieldSpecified;
        
        private long hlcodeField;
        
        private bool hlcodeFieldSpecified;
        
        private money initialCreditField;
        
        private long portNpcodeField;
        
        private bool portNpcodeFieldSpecified;
        
        private string smStatusField;
        
        private long smIdField;
        
        private bool smIdFieldSpecified;
        
        private long linkedDnIdField;
        
        private bool linkedDnIdFieldSpecified;
        
        private string linkedPortNumField;
        
        private long linkedPortIdField;
        
        private bool linkedPortIdFieldSpecified;
        
        private string linkedPortStatusField;
        
        /// <remarks/>
        public string stmedno {
            get {
                return this.stmednoField;
            }
            set {
                this.stmednoField = value;
                this.RaisePropertyChanged("stmedno");
            }
        }
        
        /// <remarks/>
        public long smcId {
            get {
                return this.smcIdField;
            }
            set {
                this.smcIdField = value;
                this.RaisePropertyChanged("smcId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool smcIdSpecified {
            get {
                return this.smcIdFieldSpecified;
            }
            set {
                this.smcIdFieldSpecified = value;
                this.RaisePropertyChanged("smcIdSpecified");
            }
        }
        
        /// <remarks/>
        public string smcIdPub {
            get {
                return this.smcIdPubField;
            }
            set {
                this.smcIdPubField = value;
                this.RaisePropertyChanged("smcIdPub");
            }
        }
        
        /// <remarks/>
        public long dlCode {
            get {
                return this.dlCodeField;
            }
            set {
                this.dlCodeField = value;
                this.RaisePropertyChanged("dlCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dlCodeSpecified {
            get {
                return this.dlCodeFieldSpecified;
            }
            set {
                this.dlCodeFieldSpecified = value;
                this.RaisePropertyChanged("dlCodeSpecified");
            }
        }
        
        /// <remarks/>
        public long hlcode {
            get {
                return this.hlcodeField;
            }
            set {
                this.hlcodeField = value;
                this.RaisePropertyChanged("hlcode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool hlcodeSpecified {
            get {
                return this.hlcodeFieldSpecified;
            }
            set {
                this.hlcodeFieldSpecified = value;
                this.RaisePropertyChanged("hlcodeSpecified");
            }
        }
        
        /// <remarks/>
        public money initialCredit {
            get {
                return this.initialCreditField;
            }
            set {
                this.initialCreditField = value;
                this.RaisePropertyChanged("initialCredit");
            }
        }
        
        /// <remarks/>
        public long portNpcode {
            get {
                return this.portNpcodeField;
            }
            set {
                this.portNpcodeField = value;
                this.RaisePropertyChanged("portNpcode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool portNpcodeSpecified {
            get {
                return this.portNpcodeFieldSpecified;
            }
            set {
                this.portNpcodeFieldSpecified = value;
                this.RaisePropertyChanged("portNpcodeSpecified");
            }
        }
        
        /// <remarks/>
        public string smStatus {
            get {
                return this.smStatusField;
            }
            set {
                this.smStatusField = value;
                this.RaisePropertyChanged("smStatus");
            }
        }
        
        /// <remarks/>
        public long smId {
            get {
                return this.smIdField;
            }
            set {
                this.smIdField = value;
                this.RaisePropertyChanged("smId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool smIdSpecified {
            get {
                return this.smIdFieldSpecified;
            }
            set {
                this.smIdFieldSpecified = value;
                this.RaisePropertyChanged("smIdSpecified");
            }
        }
        
        /// <remarks/>
        public long linkedDnId {
            get {
                return this.linkedDnIdField;
            }
            set {
                this.linkedDnIdField = value;
                this.RaisePropertyChanged("linkedDnId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool linkedDnIdSpecified {
            get {
                return this.linkedDnIdFieldSpecified;
            }
            set {
                this.linkedDnIdFieldSpecified = value;
                this.RaisePropertyChanged("linkedDnIdSpecified");
            }
        }
        
        /// <remarks/>
        public string linkedPortNum {
            get {
                return this.linkedPortNumField;
            }
            set {
                this.linkedPortNumField = value;
                this.RaisePropertyChanged("linkedPortNum");
            }
        }
        
        /// <remarks/>
        public long linkedPortId {
            get {
                return this.linkedPortIdField;
            }
            set {
                this.linkedPortIdField = value;
                this.RaisePropertyChanged("linkedPortId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool linkedPortIdSpecified {
            get {
                return this.linkedPortIdFieldSpecified;
            }
            set {
                this.linkedPortIdFieldSpecified = value;
                this.RaisePropertyChanged("linkedPortIdSpecified");
            }
        }
        
        /// <remarks/>
        public string linkedPortStatus {
            get {
                return this.linkedPortStatusField;
            }
            set {
                this.linkedPortStatusField = value;
                this.RaisePropertyChanged("linkedPortStatus");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ericsson.com/services/ws_CIL_7/storagemediumsearch")]
    public partial class storageMediumSearchResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private allStoragemediumsListpartResponse[] allStoragemediumsField;
        
        private bool searchIsCompleteField;
        
        private bool searchIsCompleteFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable=false)]
        public allStoragemediumsListpartResponse[] allStoragemediums {
            get {
                return this.allStoragemediumsField;
            }
            set {
                this.allStoragemediumsField = value;
                this.RaisePropertyChanged("allStoragemediums");
            }
        }
        
        /// <remarks/>
        public bool searchIsComplete {
            get {
                return this.searchIsCompleteField;
            }
            set {
                this.searchIsCompleteField = value;
                this.RaisePropertyChanged("searchIsComplete");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool searchIsCompleteSpecified {
            get {
                return this.searchIsCompleteFieldSpecified;
            }
            set {
                this.searchIsCompleteFieldSpecified = value;
                this.RaisePropertyChanged("searchIsCompleteSpecified");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ericsson.com/services/ws_CIL_7/sessionchange")]
    public partial class valuesListpartRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string keyField;
        
        private string valueField;
        
        /// <remarks/>
        public string key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
                this.RaisePropertyChanged("key");
            }
        }
        
        /// <remarks/>
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("value");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ericsson.com/services/ws_CIL_7/sessionchange")]
    public partial class sessionChangeRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private valuesListpartRequest[] valuesField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable=false)]
        public valuesListpartRequest[] values {
            get {
                return this.valuesField;
            }
            set {
                this.valuesField = value;
                this.RaisePropertyChanged("values");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class storageMediumSearchRequest1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ericsson.com/services/ws_CIL_7/storagemediumsearch", Order=0)]
        public AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchRequest storageMediumSearchRequest;
        
        public storageMediumSearchRequest1() {
        }
        
        public storageMediumSearchRequest1(AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchRequest storageMediumSearchRequest) {
            this.storageMediumSearchRequest = storageMediumSearchRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class storageMediumSearchResponse1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ericsson.com/services/ws_CIL_7/storagemediumsearch", Order=0)]
        public AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchResponse storageMediumSearchResponse;
        
        public storageMediumSearchResponse1() {
        }
        
        public storageMediumSearchResponse1(AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchResponse storageMediumSearchResponse) {
            this.storageMediumSearchResponse = storageMediumSearchResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface StorageMediumSearchServiceChannel : AmxSoapServicesActivities.StorageMediumSearch.StorageMediumSearchService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StorageMediumSearchServiceClient : System.ServiceModel.ClientBase<AmxSoapServicesActivities.StorageMediumSearch.StorageMediumSearchService>, AmxSoapServicesActivities.StorageMediumSearch.StorageMediumSearchService {
        
        public StorageMediumSearchServiceClient() {
        }
        
        public StorageMediumSearchServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StorageMediumSearchServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StorageMediumSearchServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StorageMediumSearchServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchResponse1 AmxSoapServicesActivities.StorageMediumSearch.StorageMediumSearchService.storageMediumSearch(AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchRequest1 request) {
            return base.Channel.storageMediumSearch(request);
        }
        
        public AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchResponse storageMediumSearch(AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchRequest storageMediumSearchRequest) {
            AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchRequest1 inValue = new AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchRequest1();
            inValue.storageMediumSearchRequest = storageMediumSearchRequest;
            AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchResponse1 retVal = ((AmxSoapServicesActivities.StorageMediumSearch.StorageMediumSearchService)(this)).storageMediumSearch(inValue);
            return retVal.storageMediumSearchResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchResponse1> AmxSoapServicesActivities.StorageMediumSearch.StorageMediumSearchService.storageMediumSearchAsync(AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchRequest1 request) {
            return base.Channel.storageMediumSearchAsync(request);
        }
        
        public System.Threading.Tasks.Task<AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchResponse1> storageMediumSearchAsync(AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchRequest storageMediumSearchRequest) {
            AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchRequest1 inValue = new AmxSoapServicesActivities.StorageMediumSearch.storageMediumSearchRequest1();
            inValue.storageMediumSearchRequest = storageMediumSearchRequest;
            return ((AmxSoapServicesActivities.StorageMediumSearch.StorageMediumSearchService)(this)).storageMediumSearchAsync(inValue);
        }
    }
}
