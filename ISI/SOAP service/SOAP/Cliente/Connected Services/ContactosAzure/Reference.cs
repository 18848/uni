﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações a este ficheiro poderão provocar um comportamento incorrecto e perder-se-ão se
//     o código for regenerado.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cliente.ContactosAzure {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ContactosAzure.IContactos")]
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
        string AddContacto(int idUtente, int idCaso);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactos/AddContacto", ReplyAction="http://tempuri.org/IContactos/AddContactoResponse")]
        System.Threading.Tasks.Task<string> AddContactoAsync(int idUtente, int idCaso);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IContactosChannel : Cliente.ContactosAzure.IContactos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ContactosClient : System.ServiceModel.ClientBase<Cliente.ContactosAzure.IContactos>, Cliente.ContactosAzure.IContactos {
        
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
        
        public string AddContacto(int idUtente, int idCaso) {
            return base.Channel.AddContacto(idUtente, idCaso);
        }
        
        public System.Threading.Tasks.Task<string> AddContactoAsync(int idUtente, int idCaso) {
            return base.Channel.AddContactoAsync(idUtente, idCaso);
        }
    }
}
