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
        private string server = ConfigurationManager.ConnectionStrings["ISI"].ConnectionString;

        //public ModeloCasos GetCasos()
        public DataSet GetCasos()
        {
            //2º OpenConnection
            SqlConnection con = new SqlConnection(server);        //via SQLServer
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

        public DataSet AddCasos(DateTime data, int idUtente)
        {
            //2º OpenConnection
            SqlConnection con = new SqlConnection(server);
            con.Open();

            //3º Query
            //string contacto = "INSERT INTO contacto (idutente, idcaso) VALUES (@idutente, @idcaso)";
            string caso = "INSERT INTO caso (data, idutente) VALUES (@data, @idutente)";

            //4º Execute
            //SqlCommand contactoCom = new SqlCommand(contacto, con);
            SqlCommand casoCom = new SqlCommand(caso, con);
          
            casoCom.Parameters.AddWithValue("@data", data);
            casoCom.Parameters.AddWithValue("@idutente", idUtente);

            casoCom.ExecuteNonQuery();

            //SqlDataAdapter contactoDA = new SqlDataAdapter(contacto, con);
            SqlDataAdapter casoDA = new SqlDataAdapter(caso, con);
            DataSet ds = new DataSet();
            //ds.Tables.Add(utenteDA);

            //GET;
            //da.Fill(ds, "Casos");

            //INSERT; UPDATE; DELETE;
            //utenteDA.Fill(ds);
            //contactoDA.Update(ds);
            //casoDA.Update(ds);

            //Devolve o resultado
            return (ds);
        }

        public DataSet GetUtentes()
        {
            //2º OpenConnection
            SqlConnection con = new SqlConnection(server);        //via SQLServer
            con.Open();

            //3º Query
            string q = "select * from utente";

            //4º Execute
            SqlDataAdapter da = new SqlDataAdapter(q, con);    //via SQLServer
            DataSet ds = new DataSet();

            da.Fill(ds, "Utentes");

            //Devolve o resultado
            return (ds);
        }

        public DataSet AddUtentes(int idUtente, string nome)
        {
            //2º OpenConnection
            SqlConnection con = new SqlConnection(server);
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

            //Devolve a nova coluna da tabela
            return (ds);
        }
    }
}
