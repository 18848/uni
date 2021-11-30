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
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
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
        private async void casos_Click(object sender, EventArgs e)
        {
            //ModeloCasos casos = new ModeloCasos();
            //casos.Data = DateTime.Today.ToString("yyyy-MM-dd");
            //casos.Nif = 123;
            //casosWS.AddCasos(casos);

            DataSet ds = await casosWS.GetCasosAsync();
            List<ModeloCasos> data = new List<ModeloCasos>();
            List<ModeloCasos> result = new List<ModeloCasos>();

            foreach (DataRow row in ds.Tables["Casos"].Rows)
            {
                object[] r = row.ItemArray;
                ModeloCasos n = new ModeloCasos();
                
                n.Data = r[1].ToString();
                n.Nif = int.Parse(r[2].ToString());
                
                data.Add(n);
            }

            foreach(ModeloCasos n in data)
            {
                if (DateTime.Compare(DateTime.Parse(n.Data), DateTime.Now.AddMonths(-6)) <= 0)
                {
                    result.Add(n);
                }
            }

            ds.Tables["Casos"].Rows.Clear();

            foreach (ModeloCasos n in result)
            {
                ds.Tables["Casos"].Rows.Add(new object[] {1, n.Data, n.Nif });
                ds.AcceptChanges();
            }
            try
            {
                casosGridView.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
