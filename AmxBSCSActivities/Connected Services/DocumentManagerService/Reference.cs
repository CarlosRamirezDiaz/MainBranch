﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmxSoapServicesActivities.DocumentManagerService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.amx.com/Service/DocumentCMS/V2.0", ConfigurationName="DocumentManagerService.DocumentCMSInterface")]
    public interface DocumentCMSInterface {
        
        // CODEGEN: Generating message contract since the operation UploadDocument is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.amx.com/Service/DocumentCMS/V2.0/UploadDocument", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        AmxSoapServicesActivities.DocumentManagerService.UploadDocumentResponse1 UploadDocument(AmxSoapServicesActivities.DocumentManagerService.UploadDocumentRequest1 request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.amx.com/Service/DocumentCMS/V2.0/UploadDocument", ReplyAction="*")]
        System.Threading.Tasks.Task<AmxSoapServicesActivities.DocumentManagerService.UploadDocumentResponse1> UploadDocumentAsync(AmxSoapServicesActivities.DocumentManagerService.UploadDocumentRequest1 request);
        
        // CODEGEN: Generating message contract since the operation GetDocument is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.amx.com/Service/DocumentCMS/V2.0/GetDocument", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        AmxSoapServicesActivities.DocumentManagerService.GetDocumentResponse1 GetDocument(AmxSoapServicesActivities.DocumentManagerService.GetDocumentRequest1 request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.amx.com/Service/DocumentCMS/V2.0/GetDocument", ReplyAction="*")]
        System.Threading.Tasks.Task<AmxSoapServicesActivities.DocumentManagerService.GetDocumentResponse1> GetDocumentAsync(AmxSoapServicesActivities.DocumentManagerService.GetDocumentRequest1 request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.amx.com/Schema/Operation/UploadDocument/V2.0")]
    public partial class UploadDocumentRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private HeaderRequest headerRequestField;
        
        private AttributeValuePair[] documentField;
        
        private File fileField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public HeaderRequest headerRequest {
            get {
                return this.headerRequestField;
            }
            set {
                this.headerRequestField = value;
                this.RaisePropertyChanged("headerRequest");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("field", IsNullable=false)]
        public AttributeValuePair[] document {
            get {
                return this.documentField;
            }
            set {
                this.documentField = value;
                this.RaisePropertyChanged("document");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public File file {
            get {
                return this.fileField;
            }
            set {
                this.fileField = value;
                this.RaisePropertyChanged("file");
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.amx.com/CO/Schema/ClaroHeaders/v1")]
    public partial class HeaderRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string transactionIdField;
        
        private string systemField;
        
        private string userField;
        
        private string passwordField;
        
        private System.DateTime requestDateField;
        
        private string ipApplicationField;
        
        private string traceabilityIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string transactionId {
            get {
                return this.transactionIdField;
            }
            set {
                this.transactionIdField = value;
                this.RaisePropertyChanged("transactionId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string system {
            get {
                return this.systemField;
            }
            set {
                this.systemField = value;
                this.RaisePropertyChanged("system");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string user {
            get {
                return this.userField;
            }
            set {
                this.userField = value;
                this.RaisePropertyChanged("user");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public System.DateTime requestDate {
            get {
                return this.requestDateField;
            }
            set {
                this.requestDateField = value;
                this.RaisePropertyChanged("requestDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string ipApplication {
            get {
                return this.ipApplicationField;
            }
            set {
                this.ipApplicationField = value;
                this.RaisePropertyChanged("ipApplication");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string traceabilityId {
            get {
                return this.traceabilityIdField;
            }
            set {
                this.traceabilityIdField = value;
                this.RaisePropertyChanged("traceabilityId");
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
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="Exception", Namespace="http://www.amx.com/Schema/Operation/GetDocument/V2.0")]
    public partial class Exception1 : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string codeField;
        
        private string messageField;
        
        private string dateTimeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
                this.RaisePropertyChanged("code");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string dateTime {
            get {
                return this.dateTimeField;
            }
            set {
                this.dateTimeField = value;
                this.RaisePropertyChanged("dateTime");
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.amx.com/Schema/Operation/GetDocument/V2.0")]
    public partial class GetDocumentResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private HeaderResponse headerResponseField;
        
        private string actionStatusField;
        
        private string statusMessageField;
        
        private AttributeValuePair[] documentField; //cambio private AttributeValuePair[][] documentField;

        private Exception1[] exceptionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public HeaderResponse headerResponse {
            get {
                return this.headerResponseField;
            }
            set {
                this.headerResponseField = value;
                this.RaisePropertyChanged("headerResponse");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string actionStatus {
            get {
                return this.actionStatusField;
            }
            set {
                this.actionStatusField = value;
                this.RaisePropertyChanged("actionStatus");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string statusMessage {
            get {
                return this.statusMessageField;
            }
            set {
                this.statusMessageField = value;
                this.RaisePropertyChanged("statusMessage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("field", typeof(AttributeValuePair), IsNullable=false)]
        public AttributeValuePair[] document { //cambio [] []
            get {
                return this.documentField;
            }
            set {
                this.documentField = value;
                this.RaisePropertyChanged("document");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("exception", Order=4)]
        public Exception1[] exception {
            get {
                return this.exceptionField;
            }
            set {
                this.exceptionField = value;
                this.RaisePropertyChanged("exception");
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.amx.com/CO/Schema/ClaroHeaders/v1")]
    public partial class HeaderResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.DateTime responseDateField;
        
        private string traceabilityIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public System.DateTime responseDate {
            get {
                return this.responseDateField;
            }
            set {
                this.responseDateField = value;
                this.RaisePropertyChanged("responseDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string traceabilityId {
            get {
                return this.traceabilityIdField;
            }
            set {
                this.traceabilityIdField = value;
                this.RaisePropertyChanged("traceabilityId");
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.amx.com/CO/Schema/BaseTypeABE/v1")]
    public partial class AttributeValuePair : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string attributeNameField;
        
        private string attributeValueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string attributeName {
            get {
                return this.attributeNameField;
            }
            set {
                this.attributeNameField = value;
                this.RaisePropertyChanged("attributeName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string attributeValue {
            get {
                return this.attributeValueField;
            }
            set {
                this.attributeValueField = value;
                this.RaisePropertyChanged("attributeValue");
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.amx.com/Schema/Operation/GetDocument/V2.0")]
    public partial class GetDocumentRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private HeaderRequest headerRequestField;
        
        private AttributeValuePair[] documentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public HeaderRequest headerRequest {
            get {
                return this.headerRequestField;
            }
            set {
                this.headerRequestField = value;
                this.RaisePropertyChanged("headerRequest");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("field", IsNullable=false)]
        public AttributeValuePair[] document {
            get {
                return this.documentField;
            }
            set {
                this.documentField = value;
                this.RaisePropertyChanged("document");
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.amx.com/Schema/Operation/UploadDocument/V2.0")]
    public partial class Exception : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string codeField;
        
        private string messageField;
        
        private string dateTimeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
                this.RaisePropertyChanged("code");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string dateTime {
            get {
                return this.dateTimeField;
            }
            set {
                this.dateTimeField = value;
                this.RaisePropertyChanged("dateTime");
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.amx.com/Schema/Operation/UploadDocument/V2.0")]
    public partial class UploadDocumentResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private HeaderResponse headerResponseField;
        
        private string actionStatusField;
        
        private string statusMessageField;
        
        private AttributeValuePair[] documentField;
        
        private Exception[] exceptionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public HeaderResponse headerResponse {
            get {
                return this.headerResponseField;
            }
            set {
                this.headerResponseField = value;
                this.RaisePropertyChanged("headerResponse");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string actionStatus {
            get {
                return this.actionStatusField;
            }
            set {
                this.actionStatusField = value;
                this.RaisePropertyChanged("actionStatus");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string statusMessage {
            get {
                return this.statusMessageField;
            }
            set {
                this.statusMessageField = value;
                this.RaisePropertyChanged("statusMessage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("field", IsNullable=false)]
        public AttributeValuePair[] document {
            get {
                return this.documentField;
            }
            set {
                this.documentField = value;
                this.RaisePropertyChanged("document");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("exception", Order=4)]
        public Exception[] exception {
            get {
                return this.exceptionField;
            }
            set {
                this.exceptionField = value;
                this.RaisePropertyChanged("exception");
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.amx.com/Schema/Operation/UploadDocument/V2.0")]
    public partial class File : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nameField;
        
        private byte[] contentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", Order=1)]
        public byte[] content {
            get {
                return this.contentField;
            }
            set {
                this.contentField = value;
                this.RaisePropertyChanged("content");
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
    public partial class UploadDocumentRequest1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.amx.com/Schema/Operation/UploadDocument/V2.0", Order=0)]
        public AmxSoapServicesActivities.DocumentManagerService.UploadDocumentRequest uploadDocumentRequest;
        
        public UploadDocumentRequest1() {
        }
        
        public UploadDocumentRequest1(AmxSoapServicesActivities.DocumentManagerService.UploadDocumentRequest uploadDocumentRequest) {
            this.uploadDocumentRequest = uploadDocumentRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadDocumentResponse1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.amx.com/Schema/Operation/UploadDocument/V2.0", Order=0)]
        public AmxSoapServicesActivities.DocumentManagerService.UploadDocumentResponse uploadDocumentResponse;
        
        public UploadDocumentResponse1() {
        }
        
        public UploadDocumentResponse1(AmxSoapServicesActivities.DocumentManagerService.UploadDocumentResponse uploadDocumentResponse) {
            this.uploadDocumentResponse = uploadDocumentResponse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetDocumentRequest1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.amx.com/Schema/Operation/GetDocument/V2.0", Order=0)]
        public AmxSoapServicesActivities.DocumentManagerService.GetDocumentRequest getDocumentRequest;
        
        public GetDocumentRequest1() {
        }
        
        public GetDocumentRequest1(AmxSoapServicesActivities.DocumentManagerService.GetDocumentRequest getDocumentRequest) {
            this.getDocumentRequest = getDocumentRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetDocumentResponse1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.amx.com/Schema/Operation/GetDocument/V2.0", Order=0)]
        public AmxSoapServicesActivities.DocumentManagerService.GetDocumentResponse getDocumentResponse;
        
        public GetDocumentResponse1() {
        }
        
        public GetDocumentResponse1(AmxSoapServicesActivities.DocumentManagerService.GetDocumentResponse getDocumentResponse) {
            this.getDocumentResponse = getDocumentResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DocumentCMSInterfaceChannel : AmxSoapServicesActivities.DocumentManagerService.DocumentCMSInterface, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DocumentCMSInterfaceClient : System.ServiceModel.ClientBase<AmxSoapServicesActivities.DocumentManagerService.DocumentCMSInterface>, AmxSoapServicesActivities.DocumentManagerService.DocumentCMSInterface {
        
        public DocumentCMSInterfaceClient() {
        }
        
        public DocumentCMSInterfaceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DocumentCMSInterfaceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DocumentCMSInterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DocumentCMSInterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AmxSoapServicesActivities.DocumentManagerService.UploadDocumentResponse1 AmxSoapServicesActivities.DocumentManagerService.DocumentCMSInterface.UploadDocument(AmxSoapServicesActivities.DocumentManagerService.UploadDocumentRequest1 request) {
            return base.Channel.UploadDocument(request);
        }
        
        public AmxSoapServicesActivities.DocumentManagerService.UploadDocumentResponse UploadDocument(AmxSoapServicesActivities.DocumentManagerService.UploadDocumentRequest uploadDocumentRequest) {
            AmxSoapServicesActivities.DocumentManagerService.UploadDocumentRequest1 inValue = new AmxSoapServicesActivities.DocumentManagerService.UploadDocumentRequest1();
            inValue.uploadDocumentRequest = uploadDocumentRequest;
            AmxSoapServicesActivities.DocumentManagerService.UploadDocumentResponse1 retVal = ((AmxSoapServicesActivities.DocumentManagerService.DocumentCMSInterface)(this)).UploadDocument(inValue);
            return retVal.uploadDocumentResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<AmxSoapServicesActivities.DocumentManagerService.UploadDocumentResponse1> AmxSoapServicesActivities.DocumentManagerService.DocumentCMSInterface.UploadDocumentAsync(AmxSoapServicesActivities.DocumentManagerService.UploadDocumentRequest1 request) {
            return base.Channel.UploadDocumentAsync(request);
        }
        
        public System.Threading.Tasks.Task<AmxSoapServicesActivities.DocumentManagerService.UploadDocumentResponse1> UploadDocumentAsync(AmxSoapServicesActivities.DocumentManagerService.UploadDocumentRequest uploadDocumentRequest) {
            AmxSoapServicesActivities.DocumentManagerService.UploadDocumentRequest1 inValue = new AmxSoapServicesActivities.DocumentManagerService.UploadDocumentRequest1();
            inValue.uploadDocumentRequest = uploadDocumentRequest;
            return ((AmxSoapServicesActivities.DocumentManagerService.DocumentCMSInterface)(this)).UploadDocumentAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AmxSoapServicesActivities.DocumentManagerService.GetDocumentResponse1 AmxSoapServicesActivities.DocumentManagerService.DocumentCMSInterface.GetDocument(AmxSoapServicesActivities.DocumentManagerService.GetDocumentRequest1 request) {
            return base.Channel.GetDocument(request);
        }
        
        public AmxSoapServicesActivities.DocumentManagerService.GetDocumentResponse GetDocument(AmxSoapServicesActivities.DocumentManagerService.GetDocumentRequest getDocumentRequest) {
            AmxSoapServicesActivities.DocumentManagerService.GetDocumentRequest1 inValue = new AmxSoapServicesActivities.DocumentManagerService.GetDocumentRequest1();
            inValue.getDocumentRequest = getDocumentRequest;
            AmxSoapServicesActivities.DocumentManagerService.GetDocumentResponse1 retVal = ((AmxSoapServicesActivities.DocumentManagerService.DocumentCMSInterface)(this)).GetDocument(inValue);
            return retVal.getDocumentResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<AmxSoapServicesActivities.DocumentManagerService.GetDocumentResponse1> AmxSoapServicesActivities.DocumentManagerService.DocumentCMSInterface.GetDocumentAsync(AmxSoapServicesActivities.DocumentManagerService.GetDocumentRequest1 request) {
            return base.Channel.GetDocumentAsync(request);
        }
        
        public System.Threading.Tasks.Task<AmxSoapServicesActivities.DocumentManagerService.GetDocumentResponse1> GetDocumentAsync(AmxSoapServicesActivities.DocumentManagerService.GetDocumentRequest getDocumentRequest) {
            AmxSoapServicesActivities.DocumentManagerService.GetDocumentRequest1 inValue = new AmxSoapServicesActivities.DocumentManagerService.GetDocumentRequest1();
            inValue.getDocumentRequest = getDocumentRequest;
            return ((AmxSoapServicesActivities.DocumentManagerService.DocumentCMSInterface)(this)).GetDocumentAsync(inValue);
        }
    }
}
