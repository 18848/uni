using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;

namespace SOAP
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService1" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface ICasos
    {
        [OperationContract]
        DataSet GetCasos();

        [OperationContract(Name = "GetCasosByNIF")]
        DataSet GetCasos(int nif);

        [OperationContract(Name = "GetCasosByData")]
        DataSet GetCasos(string data);

        [OperationContract]
        string AddCasos(ModeloCasos casos);
    }

    [DataContract]
    public class ModeloCasos
    {
        public ModeloCasos(string data, int nif)
        {
            Data = data;
            Nif = nif;
        }
        [DataMember]
        public string Data { get; set; }
        [DataMember]
        public int Nif{ get; set; }

        public override string ToString()
        {
            return "'" + this.Data.ToString() + "', '" + this.Nif.ToString() + "'";
        }
    }
}
