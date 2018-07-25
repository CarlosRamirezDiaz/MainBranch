//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace AmxPeruPSBWorkflows.AMX_COLOMBIA.IVR {
    
    
    [System.Runtime.InteropServices.ComVisible(false)]
    public partial class AmxUpdateAppointmentStatus : System.Activities.Activity, System.ComponentModel.ISupportInitialize {
        
        private bool _contentLoaded;
        
        private System.Activities.OutArgument<AMXCommon.Model.AppointmentLog.ResponseStatus> _appUpdateResponse;
        
        private System.Activities.InArgument<string> _confirmationStatus;
        
        private System.Activities.InArgument<string> _appointmentNumber;
        
        private System.Activities.InArgument<string> _status;
        
        private System.Activities.InArgument<string> _technicianId;
        
        private System.Activities.InArgument<string> _statusReason;
        
partial void BeforeInitializeComponent(ref bool isInitialized);

partial void AfterInitializeComponent();

        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("XamlBuildTask", "15.0.0.0")]
        public AmxUpdateAppointmentStatus() {
            this.InitializeComponent();
        }
        
        public System.Activities.OutArgument<AMXCommon.Model.AppointmentLog.ResponseStatus> appUpdateResponse {
            get {
                return this._appUpdateResponse;
            }
            set {
                this._appUpdateResponse = value;
            }
        }
        
        public System.Activities.InArgument<string> confirmationStatus {
            get {
                return this._confirmationStatus;
            }
            set {
                this._confirmationStatus = value;
            }
        }
        
        public System.Activities.InArgument<string> appointmentNumber {
            get {
                return this._appointmentNumber;
            }
            set {
                this._appointmentNumber = value;
            }
        }
        
        public System.Activities.InArgument<string> status {
            get {
                return this._status;
            }
            set {
                this._status = value;
            }
        }
        
        public System.Activities.InArgument<string> technicianId {
            get {
                return this._technicianId;
            }
            set {
                this._technicianId = value;
            }
        }
        
        public System.Activities.InArgument<string> statusReason {
            get {
                return this._statusReason;
            }
            set {
                this._statusReason = value;
            }
        }
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("XamlBuildTask", "15.0.0.0")]
        public void InitializeComponent() {
            if ((this._contentLoaded == true)) {
                return;
            }
            this._contentLoaded = true;
            bool isInitialized = false;
            this.BeforeInitializeComponent(ref isInitialized);
            if ((isInitialized == true)) {
                this.AfterInitializeComponent();
                return;
            }
            string resourceName = this.FindResource();
            System.IO.Stream initializeXaml = typeof(AmxUpdateAppointmentStatus).Assembly.GetManifestResourceStream(resourceName);
            System.Xml.XmlReader xmlReader = null;
            System.Xaml.XamlReader reader = null;
            System.Xaml.XamlObjectWriter objectWriter = null;
            try {
                System.Xaml.XamlSchemaContext schemaContext = XamlStaticHelperNamespace._XamlStaticHelper.SchemaContext;
                xmlReader = System.Xml.XmlReader.Create(initializeXaml);
                System.Xaml.XamlXmlReaderSettings readerSettings = new System.Xaml.XamlXmlReaderSettings();
                readerSettings.LocalAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                readerSettings.AllowProtectedMembersOnRoot = true;
                reader = new System.Xaml.XamlXmlReader(xmlReader, schemaContext, readerSettings);
                System.Xaml.XamlObjectWriterSettings writerSettings = new System.Xaml.XamlObjectWriterSettings();
                writerSettings.RootObjectInstance = this;
                writerSettings.AccessLevel = System.Xaml.Permissions.XamlAccessLevel.PrivateAccessTo(typeof(AmxUpdateAppointmentStatus));
                objectWriter = new System.Xaml.XamlObjectWriter(schemaContext, writerSettings);
                System.Xaml.XamlServices.Transform(reader, objectWriter);
            }
            finally {
                if ((xmlReader != null)) {
                    ((System.IDisposable)(xmlReader)).Dispose();
                }
                if ((reader != null)) {
                    ((System.IDisposable)(reader)).Dispose();
                }
                if ((objectWriter != null)) {
                    ((System.IDisposable)(objectWriter)).Dispose();
                }
            }
            this.AfterInitializeComponent();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("XamlBuildTask", "15.0.0.0")]
        private string FindResource() {
            string[] resources = typeof(AmxUpdateAppointmentStatus).Assembly.GetManifestResourceNames();
            for (int i = 0; (i < resources.Length); i = (i + 1)) {
                string resource = resources[i];
                if ((resource.Contains(".AmxUpdateAppointmentStatus.g.xaml") || resource.Equals("AmxUpdateAppointmentStatus.g.xaml"))) {
                    return resource;
                }
            }
            throw new System.InvalidOperationException("Resource not found.");
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033")]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("XamlBuildTask", "15.0.0.0")]
        void System.ComponentModel.ISupportInitialize.BeginInit() {
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033")]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("XamlBuildTask", "15.0.0.0")]
        void System.ComponentModel.ISupportInitialize.EndInit() {
            this.InitializeComponent();
        }
    }
}