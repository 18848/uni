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
        /// <returns DataSet="Contactos"> Returns a DataSet with information on All Rows for Contacts with Covid-positive Cases. </returns>
        public DataSet GetContacto()
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
                string q = "SELECT * FROM contacto";
                SqlDataAdapter da = new SqlDataAdapter(q, con);

                da.Fill(ds, "Contactos");
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
            catch(SqlException ex)
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
        /// Connects to a Database to Find Contacts.
        /// </summary>
        /// <param name="id" type="int">  </param>
        /// <param name="nif" type="bool"> True if 'id' is NIF. False if IdCaso. </param>
        /// <returns> Returns a DataSet with information on All Rows for Contacts with Covid-positive Cases. </returns>
        public DataSet GetContacto(int id, bool nif)
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
                string q;
                if(nif == true)
                {
                    q = "SELECT * FROM contacto WHERE idutente = '" + id.ToString() + "'";
                }
                else
                {
                    q = "SELECT * FROM contacto WHERE idcaso = '" + id.ToString() + "'";
                }
                SqlDataAdapter da = new SqlDataAdapter(q, con);

                da.Fill(ds, "Contactos");
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
        /// Connects to a Database to Insert Contactos
        /// </summary>
        /// <param name="idUtente"> NIF. </param>
        /// <param name="idCaso"> ID de Caso associado. </param>
        /// <returns string="Success"> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If reaches end of function. </returns>
        public string AddContacto(ModeloContactos contacto)
        {
            try
            {
                //2º OpenConnection
                con.Open();
            }
            catch (SqlException ex)
            {
                return "SQL Server:\n" + ex.Message.ToString();
            }

            //3º Query INSERT
            //4º Execute INSERT
            try
            {
                string contactoq = "INSERT INTO contacto (idutente, idcaso) VALUES (" + contacto.ToString() + ")";
            
                SqlCommand contactoCom = new SqlCommand(contactoq, con);

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

            try
            {
                con.Close();
            }
            catch(SqlException ex)
            {
                return "SQL:\n" + ex.Message.ToString();
            }
            //Devolve a nova coluna da tabela
            return "Success";
        }

    }
}
