﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



using AmxPeruCommonLibrary.ServiceContracts.Model;

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://ericsson.com/services/ws_CIL_7", ConfigurationName="AddressWriteService")]
public interface AddressWriteService
{
    
    // CODEGEN: Generating message contract since the operation addressWrite is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
    [System.ServiceModel.XmlSerializerFormatAttribute()]
    addressWriteResponse1 addressWrite(addressWriteRequest1 request);
    
    [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
    System.Threading.Tasks.Task<addressWriteResponse1> addressWriteAsync(addressWriteRequest1 request);
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ericsson.com/services/ws_CIL_7/addresswrite")]
public partial class addressWriteRequest
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
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ericsson.com/services/ws_CIL_7/addresswrite")]
public partial class addressWriteResponse
{
    
    private long adrSeqField;
    
    private bool adrSeqFieldSpecified;
    
    /// <remarks/>
    public long adrSeq
    {
        get
        {
            return this.adrSeqField;
        }
        set
        {
            this.adrSeqField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool adrSeqSpecified
    {
        get
        {
            return this.adrSeqFieldSpecified;
        }
        set
        {
            this.adrSeqFieldSpecified = value;
        }
    }
}


[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class addressWriteRequest1
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ericsson.com/services/ws_CIL_7/addresswrite", Order=0)]
    public addressWriteRequest addressWriteRequest;
    
    public addressWriteRequest1()
    {
    }
    
    public addressWriteRequest1(addressWriteRequest addressWriteRequest)
    {
        this.addressWriteRequest = addressWriteRequest;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class addressWriteResponse1
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ericsson.com/services/ws_CIL_7/addresswrite", Order=0)]
    public addressWriteResponse addressWriteResponse;
    
    public addressWriteResponse1()
    {
    }
    
    public addressWriteResponse1(addressWriteResponse addressWriteResponse)
    {
        this.addressWriteResponse = addressWriteResponse;
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface AddressWriteServiceChannel : AddressWriteService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class AddressWriteServiceClient : System.ServiceModel.ClientBase<AddressWriteService>, AddressWriteService
{
    
    public AddressWriteServiceClient()
    {
    }
    
    public AddressWriteServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public AddressWriteServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public AddressWriteServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public AddressWriteServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    addressWriteResponse1 AddressWriteService.addressWrite(addressWriteRequest1 request)
    {
        return base.Channel.addressWrite(request);
    }
    
    public addressWriteResponse addressWrite(addressWriteRequest addressWriteRequest)
    {
        addressWriteRequest1 inValue = new addressWriteRequest1();
        inValue.addressWriteRequest = addressWriteRequest;
        addressWriteResponse1 retVal = ((AddressWriteService)(this)).addressWrite(inValue);
        return retVal.addressWriteResponse;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    System.Threading.Tasks.Task<addressWriteResponse1> AddressWriteService.addressWriteAsync(addressWriteRequest1 request)
    {
        return base.Channel.addressWriteAsync(request);
    }
    
    public System.Threading.Tasks.Task<addressWriteResponse1> addressWriteAsync(addressWriteRequest addressWriteRequest)
    {
        addressWriteRequest1 inValue = new addressWriteRequest1();
        inValue.addressWriteRequest = addressWriteRequest;
        return ((AddressWriteService)(this)).addressWriteAsync(inValue);
    }
}
