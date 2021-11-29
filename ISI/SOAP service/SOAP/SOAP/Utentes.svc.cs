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
            try
            {
                //2º OpenConnection
                con.Open();
            }
            catch (Exception ex)
            {
                DataSet x = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                x.Tables.Add(dt);
                return x;
            }

            //3º Query
            string q = "select * from utente";

            SqlDataAdapter da = new SqlDataAdapter(q, con);    //via SQLServer
            DataSet ds = new DataSet();

            try
            {
                //4º Execute
                da.Fill(ds, "Utentes");

                //5º CloseConnection
                con.Close();
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds.Tables.Add(dt);
                return ds;
            }
            //Devolve o resultado
            return (ds);
        }

        public DataSet GetUtentes(int nif)
        {
            try
            {
                //2º OpenConnection
                con.Open();
            }
            catch (Exception ex)
            {
                DataSet x = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                x.Tables.Add(dt);
                return x;
            }

            //3º Query
            string q = "SELECT * FROM utente WHERE idutente = " + nif.ToString();

            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();

            try
            {
                //4º Execute
                da.Fill(ds, "Utentes");

                //5º CloseConnection
                con.Close();
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds.Tables.Add(dt);
                return ds;
            }
            //Devolve o resultado
            return (ds);
        }

        public DataSet GetUtentes(string nome)
        {
            try
            {
                //2º OpenConnection
                con.Open();
            }
            catch (Exception ex)
            {
                DataSet x = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                x.Tables.Add(dt);
                return x;
            }

            //3º Query
            string q = "SELECT * FROM utente WHERE nome = '" + nome.ToString() + "'";

            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();

            try
            {
                //4º Execute
                da.Fill(ds, "Utentes");

                //5º CloseConnection
                con.Close();
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds.Tables.Add(dt);
                return ds;
            }
            //Devolve o resultado
            return (ds);
        }

        public string AddUtentes(int idUtente, string nome)
        {
            //2º OpenConnection
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                return "SQL Server FAILED TO CONNECT:\n" + ex.Message.ToString();
            }

            try
            {
                //3º Query INSERT
                string utente = "INSERT INTO dbo.utente (idutente, nome) VALUES (@idutente, @nome)";

                //4º Execute INSERT
                SqlCommand utenteCom = new SqlCommand(utente, con);

                utenteCom.Parameters.AddWithValue("@idutente", idUtente);
                utenteCom.Parameters.AddWithValue("@nome", nome);

                utenteCom.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                return "SQL Server:\n" + ex.Message.ToString();
            }
            catch (Exception ex)
            {
                return "Exception:\n" + ex.Message.ToString();
            }
            
            con.Close();

            return "success";
        }
    }
}
