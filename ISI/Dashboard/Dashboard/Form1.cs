using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Dashboard.Casos;
//using Dashboard.CasosAzure;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        //private protected static string server = ConfigurationManager.ConnectionStrings["ISI"].ConnectionString;
        private protected static string server = "Server=.;Database=ISI;Trusted_Connection=True;";
        private protected SqlConnection con = new SqlConnection(server);

        //CasosAzure.CasosClient casosWS = new CasosAzure.CasosClient();
        //CasosClient casosWS = new CasosClient();
        Casos.CasosClient casosWS = new Casos.CasosClient();

        public Form1()
        {
            InitializeComponent();
        }

        #region Casos
        private void casos_Click(object sender, EventArgs e)
        {
            //ModeloCasos casos = new ModeloCasos();
            //casos.Data = DateTime.Today.ToString("yyyy-MM-dd");
            //casos.Nif = 123;
            //casosWS.AddCasos(casos);

            DataSet ds = casosWS.GetCasos();
            DataTable dt = ds.Tables[]

            foreach (DataRow row in ds["Casos"].Rows)
            {
                object[] r = row.ItemArray;
            }
        }
        #endregion
    }
}
