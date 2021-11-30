using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace API.Controllers
{
    [ApiController]
    [Route("equipas")]
    public class Equipas : ControllerBase
    {
        //1º ConnectionString no Web Config
        //private protected static string server = ConfigurationManager.ConnectionStrings["ISI"].ConnectionString;
        private protected static string server = "Server=.;Database=ISI;Trusted_Connection=True;";
        private protected SqlConnection con = new SqlConnection(server);

        [HttpGet]
        [Route("equipas")]
        public DataSet EquipasMaisCaras()
        {
            DataSet ds = new DataSet();
            string query;

            query = "SELECT * FROM equipas";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            da.Fill(ds, "Equipas Mais Caras");

            return ds;
        }

        [HttpGet]
        [Route("produtos")]
        public DataSet ProdutosMaisPedidos()
        {
            return new DataSet();
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
