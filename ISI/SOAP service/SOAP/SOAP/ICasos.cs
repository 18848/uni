﻿using System;
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
        [OperationContract]
        //ModeloCasos GetCasos();
        DataSet GetCasos();

        [OperationContract]
        DataSet AddCasos(DateTime data, int idUtente);

        //Utentes
        [OperationContract]
        DataSet GetUtentes();

        [OperationContract]
        DataSet AddUtentes(int idUtente, string nome);
    }

    [DataContract]
    public class ModeloCasos
    {
        public DateTime Data { get; set; }
        public int IdUtente{ get; set; }
    }

    [DataContract]
    public class ModeloUtente
    {
        public string Nome { get; set; }
        public int IdUtente { get; set; }
    }
}
