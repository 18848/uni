using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.ServiceModel.Web;
using System.Text;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
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
    }
}
