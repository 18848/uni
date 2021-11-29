using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SOAP
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service1.svc ou Service1.svc.server no Gerenciador de Soluções e inicie a depuração.
    public class Casos : ICasos
    {
        //1º ConnectionString no Web Config
        private protected static string server = ConfigurationManager.ConnectionStrings["ISI"].ConnectionString;
        private protected SqlConnection con = new SqlConnection(server);

        public DataSet GetCasos()
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
                string q = "SELECT* FROM caso";
                SqlDataAdapter da = new SqlDataAdapter(q, con);

                da.Fill(ds, "Casos");
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

            //Devolve o resultado
            return ds;
        }

        public DataSet GetCasos(int nif)
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
                string q = "SELECT* FROM caso WHERE idutente = '" + nif.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(q, con);

                da.Fill(ds, "Casos");

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

            //Devolve o resultado
            return ds;
        }

        public DataSet GetCasos(string data)
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
                string q = "SELECT* FROM caso WHERE data = '" + data + "'";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
            
                da.Fill(ds, "Casos");
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
                DataSet x = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                x.Tables.Add(dt);
                return x;
            }

            //Devolve o resultado
            return ds;
        }

        public string AddCasos(string data, int idUtente)
        {
            //2º OpenConnection
            try
            {
                con.Open();
            }
            catch (SqlException ex)
            {
                return "SQL EXCEPTION:\n" + ex.Message.ToString();
            }

            //3º Query
            //4º Execute
            try
            {
                string caso = "INSERT INTO caso (data, idutente) VALUES (@data, @idutente)";
                
                SqlCommand casoCom = new SqlCommand(caso, con);

                casoCom.Parameters.AddWithValue("@data", data);
                casoCom.Parameters.AddWithValue("@idutente", idUtente);

                casoCom.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                return  "SQL Server:\n" + ex.Message.ToString();
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
            catch (SqlException ex)
            {
                return "SQL EXCEPTION:\n" + ex.Message.ToString();
            }

            //Devolve o resultado
            return "success";
        }
    }
}
