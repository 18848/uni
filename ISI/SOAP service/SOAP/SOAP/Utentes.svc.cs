using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Utentes" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Utentes.svc or Utentes.svc.cs at the Solution Explorer and start debugging.
    public class Utentes : IUtentes
    {
        //1º ConnectionString no Web Config
        private protected static string server = ConfigurationManager.ConnectionStrings["ISI"].ConnectionString;
        private protected SqlConnection con = new SqlConnection(server);

        public DataSet GetUtentes()
        {
            //2º OpenConnection
            con.Open();

            //3º Query
            string q = "select * from utente";

            //4º Execute
            SqlDataAdapter da = new SqlDataAdapter(q, con);    //via SQLServer
            DataSet ds = new DataSet();

            da.Fill(ds, "Utentes");

            con.Close();
            //Devolve o resultado
            return (ds);
        }

        public DataSet GetUtentes(int nif)
        {
            //2º OpenConnection
            con.Open();

            //3º Query
            string q = "SELECT * FROM utente WHERE idutente = " + nif.ToString();

            //4º Execute
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();

            da.Fill(ds, "Utentes");

            con.Close();
            //Devolve o resultado
            return (ds);
        }

        public DataSet GetUtentes(string nome)
        {
            //2º OpenConnection
            con.Open();

            //3º Query
            string q = "SELECT * FROM utente WHERE nome = '" + nome.ToString() + "'";

            //4º Execute
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();

            da.Fill(ds, "Utentes");

            con.Close();
            //Devolve o resultado
            return (ds);
        }

        public DataSet AddUtentes(int idUtente, string nome)
        {
            //2º OpenConnection
            con.Open();

            //3º Query INSERT
            string utente = "INSERT INTO dbo.utente (idutente, nome) VALUES (@idutente, @nome)";

            //4º Execute INSERT
            SqlCommand utenteCom = new SqlCommand(utente, con);

            utenteCom.Parameters.AddWithValue("@idutente", idUtente);
            utenteCom.Parameters.AddWithValue("@nome", nome);

            utenteCom.ExecuteNonQuery();

            //5º Query SELECT
            utente = "SELECT * FROM utente WHERE idutente = " + idUtente.ToString();

            SqlDataAdapter utenteDA = new SqlDataAdapter(utente, con);
            DataSet ds = new DataSet();


            //6º Execute SELECT of previous INSERT
            utenteDA.Fill(ds, "Utente");

            con.Close();
            //Devolve a nova coluna da tabela
            return (ds);
        }
    }
}
