﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestPerson.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/Models")]
    [System.SerializableAttribute()]
    public partial class Person : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TestPerson.ServiceReference1.Login LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TestPerson.ServiceReference1.Login Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Login", Namespace="http://schemas.datacontract.org/2004/07/Models")]
    [System.SerializableAttribute()]
    public partial class Login : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TestPerson.ServiceReference1.Person personField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TestPerson.ServiceReference1.Person person {
            get {
                return this.personField;
            }
            set {
                if ((object.ReferenceEquals(this.personField, value) != true)) {
                    this.personField = value;
                    this.RaisePropertyChanged("person");
                }
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IBestilNemtService")]
    public interface IBestilNemtService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetData", ReplyAction="http://tempuri.org/IBestilNemtService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetData", ReplyAction="http://tempuri.org/IBestilNemtService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/findPerson", ReplyAction="http://tempuri.org/IBestilNemtService/findPersonResponse")]
        TestPerson.ServiceReference1.Person findPerson(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/findPerson", ReplyAction="http://tempuri.org/IBestilNemtService/findPersonResponse")]
        System.Threading.Tasks.Task<TestPerson.ServiceReference1.Person> findPersonAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/createPerson", ReplyAction="http://tempuri.org/IBestilNemtService/createPersonResponse")]
        void createPerson(TestPerson.ServiceReference1.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/createPerson", ReplyAction="http://tempuri.org/IBestilNemtService/createPersonResponse")]
        System.Threading.Tasks.Task createPersonAsync(TestPerson.ServiceReference1.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetALlPerson", ReplyAction="http://tempuri.org/IBestilNemtService/GetALlPersonResponse")]
        TestPerson.ServiceReference1.Person[] GetALlPerson();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetALlPerson", ReplyAction="http://tempuri.org/IBestilNemtService/GetALlPersonResponse")]
        System.Threading.Tasks.Task<TestPerson.ServiceReference1.Person[]> GetALlPersonAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBestilNemtServiceChannel : TestPerson.ServiceReference1.IBestilNemtService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BestilNemtServiceClient : System.ServiceModel.ClientBase<TestPerson.ServiceReference1.IBestilNemtService>, TestPerson.ServiceReference1.IBestilNemtService {
        
        public BestilNemtServiceClient() {
        }
        
        public BestilNemtServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BestilNemtServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BestilNemtServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BestilNemtServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public TestPerson.ServiceReference1.Person findPerson(int id) {
            return base.Channel.findPerson(id);
        }
        
        public System.Threading.Tasks.Task<TestPerson.ServiceReference1.Person> findPersonAsync(int id) {
            return base.Channel.findPersonAsync(id);
        }
        
        public void createPerson(TestPerson.ServiceReference1.Person person) {
            base.Channel.createPerson(person);
        }
        
        public System.Threading.Tasks.Task createPersonAsync(TestPerson.ServiceReference1.Person person) {
            return base.Channel.createPersonAsync(person);
        }
        
        public TestPerson.ServiceReference1.Person[] GetALlPerson() {
            return base.Channel.GetALlPerson();
        }
        
        public System.Threading.Tasks.Task<TestPerson.ServiceReference1.Person[]> GetALlPersonAsync() {
            return base.Channel.GetALlPersonAsync();
        }
    }
}
