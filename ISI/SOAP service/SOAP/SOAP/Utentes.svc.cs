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

        /// <summary>
        /// Selects Utentes.
        /// </summary>
        /// <returns> All Utentes From Table. </returns>
        public DataSet GetUtentes()
        {
            DataSet ds = new DataSet();
        
            try
            {
                //2º OpenConnection
                con.Open();
            }
            catch (SqlException ex)
            {
                DataSet x = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                x.Tables.Add(dt);
                return x;
            }

            //3º Query
            //4º Execute
            try
            {
                string q = "select * from utente";
                SqlDataAdapter da = new SqlDataAdapter(q, con);    //via SQLServer

                da.Fill(ds, "Utentes");
            }
            catch (SqlException ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds.Tables.Add(dt);
                return ds;
            }

            //5º CloseConnection
            try
            {
                con.Close();
            }
            catch (SqlException ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds.Tables.Add(dt);
                return ds;
            }

            return ds;
        }

        /// <summary>
        /// Selects Utentes with matching nif (idutente).
        /// </summary>
        /// <param name="nif"> Primary Key on Database table. </param>
        /// <returns DataSet> Matching Table Rows. </returns>
        public DataSet GetUtentes(int nif)
        {
            DataSet ds = new DataSet();

            //2º OpenConnection
            try
            {
                con.Open();
            }
            catch (SqlException ex)
            {
                DataSet x = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                x.Tables.Add(dt);
                return x;
            }

            //3º Query
            //4º Execute
            try
            {
                string q = "SELECT * FROM utente WHERE idutente = " + nif.ToString();
                SqlDataAdapter da = new SqlDataAdapter(q, con);

                da.Fill(ds, "Utentes");

            }
            catch (SqlException ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds.Tables.Add(dt);
                return ds;
            }
            catch (FormatException ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds.Tables.Add(dt);
                return ds;
            }

            //5º CloseConnection
            try
            {
                con.Close();
            }
            catch (SqlException ex)
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

        /// <summary>
        /// Selects Utentes with matching nome.
        /// </summary>
        /// <param name="nome"> Filtering Condition. </param>
        /// <returns DataSet> Matching Table Rows. </returns>
        public DataSet GetUtentes(string nome)
        {
            DataSet ds = new DataSet();
            //2º OpenConnection
            try
            {
                con.Open();
            }
            catch (SqlException ex)
            {
                DataSet x = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                x.Tables.Add(dt);
                return x;
            }

            //3º Query
            //4º Execute
            try
            {
                string q = "SELECT * FROM utente WHERE nome = '" + nome.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(q, con);

                da.Fill(ds, "Utentes");
            }
            catch (SqlException ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds.Tables.Add(dt);
                return ds;
            }
            catch (FormatException ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds.Tables.Add(dt);
                return ds;
            }

            // 5º CloseConnection
            try
            {
                con.Close();
            }
            catch (SqlException ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds.Tables.Add(dt);
                return ds;
            }

            //Devolve o resultado
            return ds;
        }

        /// <summary>
        /// Add Utentes to Database.
        /// </summary>
        /// <param name="idUtente"></param>
        /// <param name="nome"></param>
        /// <returns string="success"> On successful INSERT. </returns>
        /// <returns string> On error or conflict. Returns Type and Message. </returns>
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

            //3º Query INSERT
            //4º Execute INSERT
            try
            {
                string utente = "INSERT INTO dbo.utente (idutente, nome) VALUES (@idutente, @nome)";

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
           
            //5º CloseConnection
            try
            {
                con.Close();
            }
            catch(SqlException ex)
            {
                return "SQL Server:\n" + ex.Message.ToString();
            }

            return "success";
        }
    }
}
