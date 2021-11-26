using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Contactos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Contactos.svc or Contactos.svc.cs at the Solution Explorer and start debugging.
    public class Contactos : IContactos
    {
        //1º ConnectionString no Web Config
        private protected static string server = ConfigurationManager.ConnectionStrings["ISI"].ConnectionString;
        private protected SqlConnection con = new SqlConnection(server);

        /// <summary>
        /// Connects to a Database to Find Contacts.
        /// </summary>
        /// <returns>Returns a DataSet with information on All Rows for Contacts with Covid-positive Cases.</returns>
        public DataSet GetContacto()
        {
            //2º OpenConnection
            con.Open();

            //3º Query
            string q = "SELECT * FROM contacto";

            //4º Execute
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();

            da.Fill(ds, "Contactos");

            con.Close();
            return ds;
        }

        public DataSet GetContacto(int id, bool nif)
        {
            //2º OpenConnection
            con.Open();

            //3º Query
            string q;
            if(nif == true)
            {
                q = "SELECT * FROM contacto WHERE idutente = '" + id.ToString() + "'";
            }
            else
            {
                q = "SELECT * FROM contacto WHERE idcaso = '" + id.ToString() + "'";
            }

            //4º Execute
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();

            da.Fill(ds, "Contactos");

            //Devolve o resultado
            return ds;
        }

        public string AddContacto(int idUtente, int idCaso)
        {
            //2º OpenConnection
            con.Open();

            //3º Query INSERT
            string contacto = "INSERT INTO contacto (idutente, idcaso) VALUES (@idutente, @idcaso)";

            try
            {
                //4º Execute INSERT
                SqlCommand contactoCom = new SqlCommand(contacto, con);

                contactoCom.Parameters.AddWithValue("@idutente", idUtente);
                contactoCom.Parameters.AddWithValue("@idcaso", idCaso);

                contactoCom.ExecuteNonQuery();
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
            //Devolve a nova coluna da tabela
            return "Success";
        }
    }
}
