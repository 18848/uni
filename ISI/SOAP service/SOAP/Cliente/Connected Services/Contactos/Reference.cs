﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cliente.Contactos {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Contactos.IContactos")]
    public interface IContactos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactos/GetContacto", ReplyAction="http://tempuri.org/IContactos/GetContactoResponse")]
        System.Data.DataSet GetContacto();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactos/GetContacto", ReplyAction="http://tempuri.org/IContactos/GetContactoResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetContactoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactos/GetContactoByAtributes", ReplyAction="http://tempuri.org/IContactos/GetContactoByAtributesResponse")]
        System.Data.DataSet GetContactoByAtributes(int id, bool nif);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactos/GetContactoByAtributes", ReplyAction="http://tempuri.org/IContactos/GetContactoByAtributesResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetContactoByAtributesAsync(int id, bool nif);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactos/AddContacto", ReplyAction="http://tempuri.org/IContactos/AddContactoResponse")]
        string AddContacto(SOAP.ModeloContactos contacto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactos/AddContacto", ReplyAction="http://tempuri.org/IContactos/AddContactoResponse")]
        System.Threading.Tasks.Task<string> AddContactoAsync(SOAP.ModeloContactos contacto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IContactosChannel : Cliente.Contactos.IContactos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ContactosClient : System.ServiceModel.ClientBase<Cliente.Contactos.IContactos>, Cliente.Contactos.IContactos {
        
        public ContactosClient() {
        }
        
        public ContactosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ContactosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ContactosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ContactosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet GetContacto() {
            return base.Channel.GetContacto();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetContactoAsync() {
            return base.Channel.GetContactoAsync();
        }
        
        public System.Data.DataSet GetContactoByAtributes(int id, bool nif) {
            return base.Channel.GetContactoByAtributes(id, nif);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetContactoByAtributesAsync(int id, bool nif) {
            return base.Channel.GetContactoByAtributesAsync(id, nif);
        }
        
        public string AddContacto(SOAP.ModeloContactos contacto) {
            return base.Channel.AddContacto(contacto);
        }
        
        public System.Threading.Tasks.Task<string> AddContactoAsync(SOAP.ModeloContactos contacto) {
            return base.Channel.AddContactoAsync(contacto);
        }
    }
}
