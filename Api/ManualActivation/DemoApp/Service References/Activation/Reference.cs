﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoApp.Activation {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ActivationError", Namespace="http://schemas.datacontract.org/2004/07/Microsoft.Licensing.LicenseIssue")]
    public enum ActivationError : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Success = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CommunicationError = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InvalidRequestData = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NumberOfActivationsExceeded = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LicenseDisabled = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LicenseExpired = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Failed = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InternalServerError = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DeviceChanged = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TagsChanged = 9,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.microsoft.com/slps/", ConfigurationName="Activation.IActivationWS")]
    public interface IActivationWS {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.microsoft.com/slps/IActivationWS/ImportTypes", ReplyAction="http://www.microsoft.com/slps/IActivationWS/ImportTypesResponse")]
        void ImportTypes(DemoApp.Activation.ActivationError enErr1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.microsoft.com/slps/IActivationWS/ActivateLicense", ReplyAction="http://www.microsoft.com/slps/IActivationWS/ActivateLicenseResponse")]
        byte[] ActivateLicense(byte[] licenseRequest, string note);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IActivationWSChannel : DemoApp.Activation.IActivationWS, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ActivationWSClient : System.ServiceModel.ClientBase<DemoApp.Activation.IActivationWS>, DemoApp.Activation.IActivationWS {
        
        public ActivationWSClient() {
        }
        
        public ActivationWSClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ActivationWSClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ActivationWSClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ActivationWSClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void ImportTypes(DemoApp.Activation.ActivationError enErr1) {
            base.Channel.ImportTypes(enErr1);
        }
        
        public byte[] ActivateLicense(byte[] licenseRequest, string note) {
            return base.Channel.ActivateLicense(licenseRequest, note);
        }
    }
}