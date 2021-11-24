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

        #region Casos
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

        public DataSet AddCasos(DateTime data, int idUtente)
        {
            //2º OpenConnection
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
        #endregion

        #region Utentes
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

        public DataSet GetUtentesByNIF(int nif)
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

        public DataSet GetUtentesByNome(string nome)
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
        #endregion

        #region Contactos
        /// <summary>
        /// Connects to a Database to Find Contacts.
        /// </summary>
        /// <returns>Returns a DataSet with information on All Rows for Contacts with Covid-positive Cases.</returns>
        public DataSet GetContacto()
        {
            //2º OpenConnection
            con.Open();

            //3º Query
            string q = "SELECT* FROM contacto";

            //4º Execute
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();

            da.Fill(ds, "Casos");

            con.Close();
            return ds;
        }


        public DataSet AddContacto(int idUtente, int idCaso)
        {
            //2º OpenConnection
            con.Open();

            //3º Query INSERT
            string contacto = "INSERT INTO contacto (idutente, idcaso) VALUES (@idutente, @idcaso)";

            //4º Execute INSERT
            SqlCommand contactoCom = new SqlCommand(contacto, con);

            contactoCom.Parameters.AddWithValue("@idutente", idUtente);
            contactoCom.Parameters.AddWithValue("@idcaso", idCaso);

            contactoCom.ExecuteNonQuery();

            //5º Query SELECT
            contacto = "SELECT * FROM contacto WHERE idutente = " + idUtente.ToString() + " AND idcaso = " + idCaso.ToString();

            SqlDataAdapter contactoDA = new SqlDataAdapter(contacto, con);
            DataSet ds = new DataSet();


            //6º Execute SELECT of previous INSERT
            contactoDA.Fill(ds, "contacto");

            con.Close();
            //Devolve a nova coluna da tabela
            return (ds);
        }

        #endregion
    }
}
