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
        string AddContacto(int idUtente, int idCaso);
    }

    [DataContract]
    public class ModeloContactos
    {
        public ModeloContactos(int idcaso, int nif)
        {
            IdCaso = idcaso;
            Nif = nif;
        }
        public int IdCaso { get; set; }
        public int Nif { get; set; }
    }
}
