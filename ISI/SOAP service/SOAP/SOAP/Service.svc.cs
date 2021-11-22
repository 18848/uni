using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.

    [ServiceContract]
    public class Utente : IUtente
    {
        public DataSet GetAllUtentes()
        {
            DataSet ds = new DataSet();

            //1º ConnectionString no Web Config
            string cs = ConfigurationManager.ConnectionStrings["ISI"].ConnectionString;

            //2º OpenConnection
            SqlConnection con = new SqlConnection(cs);        //via SQLServer
            con.Open();

            //3º Query
            string q = "select * from casos";

            //4º Execute
            SqlDataAdapter da = new SqlDataAdapter(q, con);    //via SQLServer

            da.Fill(ds, "Casos");

            //Devolve o resultado
            return (ds);
        }

        //public DataSet AddUtentes(string nome)
        //{
        //    DataSet ds = new DataSet();

        //    //1º ConnectionString no Web Config
        //    string cs = ConfigurationManager.ConnectionStrings["VoosConnectionString"].ConnectionString;

        //    //2º OpenConnection
        //    //OleDbConnection con = new OleDbConnection(cs);      //via OleDB
        //    SqlConnection con = new SqlConnection(cs);        //via SQLServer


        //    //3º Query
        //    string q = "select * from Voos";


        //    //4º Execute
        //    //OleDbDataAdapter da = new OleDbDataAdapter(q, con);
        //    SqlDataAdapter da = new SqlDataAdapter(q, con);    //via SQLServer

        //    da.Fill(ds, "Voos");

        //    //Devolve o resultado
        //    return (ds);
        //}
    }

    #region DataContracts
    #endregion
}
