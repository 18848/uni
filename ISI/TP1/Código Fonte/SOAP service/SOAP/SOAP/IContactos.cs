using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;
using System.Text;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IContactos" in both code and config file together.
    [ServiceContract]
    public interface IContactos
    {
        [OperationContract]
        DataSet GetContacto();

        [OperationContract(Name = "GetContactoByAtributes")]
        DataSet GetContacto(int id, bool nif);

        [OperationContract]
        string AddContacto(ModeloContactos contacto);
    }

    [DataContract]
    public class ModeloContactos
    {
        public ModeloContactos(int idcaso, int nif)
        {
            IdCaso = idcaso;
            Nif = nif;
        }
        [DataMember]
        public int IdCaso { get; set; }
        [DataMember]
        public int Nif { get; set; }
        public override string ToString()
        {
            return "'" + this.Nif.ToString() + "', '" + this.IdCaso.ToString() + "'";
        }
    }
}
