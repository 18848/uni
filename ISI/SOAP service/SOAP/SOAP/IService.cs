using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Data;
using System.ServiceModel;


namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IUtente
    {
        [OperationContract]
        DataSet GetAllUtentes();

        [OperationContract]
        DataSet AddUtentes(string nome);
    }
}
