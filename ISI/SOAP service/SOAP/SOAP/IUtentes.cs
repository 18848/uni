using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;
using System.Text;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUtentes" in both code and config file together.
    [ServiceContract]
    public interface IUtentes
    {
        [OperationContract]
        DataSet GetUtentes();

        [OperationContract(Name = "GetUtentesByNIF")]
        DataSet GetUtentes(int nif);

        [OperationContract(Name = "GetUtentesByNome")]
        DataSet GetUtentes(string nome);

        [OperationContract]
        string AddUtentes(int idUtente, string nome);
    }

    [DataContract]
    public class ModeloUtente
    {
        public ModeloUtente(string nome, int nif)
        {
            Nome = nome;
            Nif = nif;
        }
        public string Nome { get; set; }
        public int Nif { get; set; }
    }
}
