using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;
using System.ServiceModel.Web;
using System.Text;

namespace SOAP
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService1" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface ICasos
    {
        #region Casos
        [OperationContract]
        DataSet GetCasos();

        [OperationContract(Name = "GetCasosByNIF")]
        DataSet GetCasos(int nif);

        [OperationContract(Name = "GetCasosByData")]
        DataSet GetCasos(string data);

        [OperationContract]
        string AddCasos(string data, int idUtente);
        #endregion

        #region Utentes
        [OperationContract]
        DataSet GetUtentes();

        [OperationContract(Name = "GetUtentesByNIF")]
        DataSet GetUtentes(int nif);

        [OperationContract(Name = "GetUtentesByNome")]
        DataSet GetUtentes(string nome);

        [OperationContract]
        DataSet AddUtentes(int idUtente, string nome);
        #endregion

        #region Contactos
        [OperationContract]
        DataSet GetContacto();

        [OperationContract]
        string AddContacto(int idUtente, int idCaso);
        #endregion
    }

    #region DataContracts
    [DataContract]
    public class ModeloCasos
    {
        public string Data { get; set; }
        public int Nif{ get; set; }
    }

    [DataContract]
    public class ModeloUtente
    {
        public ModeloUtente(string nome, string nif)
        {
            Nome = nome;
            Nif = nif;
        }

        public ModeloUtente(string nome)
        {
            Nome = nome;
        }

        public ModeloUtente(string nif)
        {
            Nif = nif;
        }

        public string Nome { get; set; }
        public int Nif { get; set; }
    }

    [DataContract]
    public class ModeloContactos
    {
        public ModeloContactos(int idcaso, int nif)
        {
            IdCaso = idcaso;
            Nif = nif;
        }
        public ModeloContactos(int idcaso)
        {
            IdCaso = idcaso;
        }
        public ModeloContactos(int nif)
        {
            Nif = nif;
        }
        public int IdCaso { get; set; }
        public int Nif { get; set; }
    }
    #endregion
}
