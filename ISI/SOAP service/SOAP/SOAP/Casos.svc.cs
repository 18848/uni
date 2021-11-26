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
            //2º OpenConnection
            con.Open();

            //3º Query
            string q = "SELECT* FROM caso";

            //4º Execute
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();           

            da.Fill(ds, "Casos");

            //Devolve o resultado
            return ds;
        }

        public DataSet GetCasos(int nif)
        {
            //2º OpenConnection
            con.Open();

            //3º Query
            string q = "SELECT* FROM caso WHERE idutente = '" + nif.ToString() + "'";

            //4º Execute
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();

            da.Fill(ds, "Casos");

            //Devolve o resultado
            return ds;
        }

        public DataSet GetCasos(string data)
        {
            //2º OpenConnection
            con.Open();

            //3º Query
            string q = "SELECT* FROM caso WHERE data = '" + data + "'";

            //4º Execute
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();

            da.Fill(ds, "Casos");

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
            catch (Exception ex)
            {
                return "SQL Server FAILED TO CONNECT:\n" + ex.Message.ToString();
            }

            //3º Query
            string caso = "INSERT INTO caso (data, idutente) VALUES (@data, @idutente)";

            //4º Execute
            try
            {
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

            //Devolve o resultado
            return "success";
        }
    }
}
