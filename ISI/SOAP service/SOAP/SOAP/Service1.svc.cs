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
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service1.svc ou Service1.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class Casos : ICasos
    {
        public DataSet GetCasos()
        {
            DataSet ds = new DataSet();
            //1º ConnectionString no Web Config

            string cs = ConfigurationManager.ConnectionStrings["ISI"].ConnectionString;

            //2º OpenConnection
            SqlConnection con = new SqlConnection(cs);        //via SQLServer
            con.Open();


            //3º Query
            string q = "select * from caso";


            //4º Execute
            SqlDataAdapter da = new SqlDataAdapter(q, con);    //via SQLServer

            da.Fill(ds, "Casos");

            //Devolve o resultado
            return (ds);
        }

        public DataSet AddCasos()
        {
            DataSet ds = new DataSet();
            //1º ConnectionString no Web Config

            string cs = ConfigurationManager.ConnectionStrings["ISI"].ConnectionString;

            //2º OpenConnection
            SqlConnection con = new SqlConnection(cs);        //via SQLServer
            con.Open();


            //3º Query
            //string utente = "INSERT INTO dbo.utente (idutente, nome) VALUES (@idutente, @nome)";
            string utente = "INSERT INTO dbo.utente (nome) VALUES (@nome)";
            string caso = "INSERT INTO caso (idcaso, data, idutente) VALUES (@idcaso, @data, @idutente)";
            string contacto = "INSERT INTO contacto (idutente, idcaso) VALUES (@idutente, @idcaso)";




            //4º Execute
            SqlDataAdapter utenteDA = new SqlDataAdapter(utente, con);
            SqlDataAdapter casoDA = new SqlDataAdapter(caso, con);
            SqlDataAdapter contactoDA = new SqlDataAdapter(contacto, con);

            SqlCommand com = new SqlCommand(utente, con);

            //com.Parameters.AddWithValue("@idutente", "1");
            com.Parameters.AddWithValue("@nome", "joao");

            int result = com.ExecuteNonQuery();

            if(result < 0)
            {
                Console.WriteLine("Youre Fucked");
            }

            //ds.Tables.Add(utenteDA);

            //GET;
            //da.Fill(ds, "Casos");

            //INSERT; UPDATE; DELETE;
            utenteDA.Fill(ds);
            casoDA.Update(ds);
            contactoDA.Update(ds);

            //Devolve o resultado
            return (ds);
        }

        public DataSet GetUtentes()
        {
            DataSet ds = new DataSet();
            //1º ConnectionString no Web Config

            string cs = ConfigurationManager.ConnectionStrings["ISI"].ConnectionString;

            //2º OpenConnection
            SqlConnection con = new SqlConnection(cs);        //via SQLServer
            con.Open();


            //3º Query
            string q = "select * from utente";


            //4º Execute
            SqlDataAdapter da = new SqlDataAdapter(q, con);    //via SQLServer

            da.Fill(ds, "Utentes");

            //Devolve o resultado
            return (ds);
        }
    }
}
