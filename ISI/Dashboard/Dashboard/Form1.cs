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
        private async void casos_Click(object sender, EventArgs e)
        {
            DataSet ds = await casosWS.GetCasosAsync();
            DataTable avg = new DataTable();
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


            foreach (ModeloCasos n in data)
            {
                if (DateTime.Compare(DateTime.Parse(n.Data), DateTime.Now.AddMonths(-6)) >= 0)
                {
                    result.Add(n);
                }
            }
            
            casosbutton.Text =  "Média de Casos: " + (result.Count / 6).ToString();

            ds.Tables["Casos"].Rows.Clear();
            ds.Tables["Casos"].Columns.Remove("idcaso");
            avg.Columns.Add("Mes");
            avg.Columns.Add("Total Mensal");
            avg.AcceptChanges();

            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (ModeloCasos n in result)
            {
                ds.Tables["Casos"].Rows.Add(new object[] {n.Data, n.Nif });
                ds.AcceptChanges();

                if ( dic.ContainsKey(DateTime.Parse(n.Data).Month.ToString()) )
                {
                    dic[DateTime.Parse(n.Data).Month.ToString()]++;
                }
                else
                {
                    dic.Add(DateTime.Parse(n.Data).Month.ToString(), 1);
                }
            }

            avg.Rows.Clear();
            foreach(var d in dic)
            {
                avg.Rows.Add( new object[] { d.Key, d.Value.ToString()});
            }
            avg.AcceptChanges();

            try
            {
                mediaGridView.DataSource = avg;
                casosGridView.DataSource = ds.Tables["Casos"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Visitas
        private void visitas_Click(object sender, EventArgs e)
        {
            con.Open();

            string q;

            q = "Select * FROM fiscalizacao";

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(q, con);

            da.Fill(ds);

            DataTable avg = new DataTable();
            List<string> data = new List<string>();
            List<string> result = new List<string>();


            foreach (DataRow row in ds.Tables[0].Rows)
            {
                object[] r = row.ItemArray;

                data.Add(r[2].ToString());
            }

            foreach (string n in data)
            {
                if (DateTime.Compare(DateTime.Parse(n), DateTime.Now.AddDays(-30)) >= 0)
                {
                    result.Add(n);
                }
            }

            ds.Tables[0].Rows.Clear();
            ds.Tables[0].Columns.Remove("idfiscalizacao");
            ds.Tables[0].Columns.Remove("idutente");
            avg.Columns.Add("Data");
            avg.Columns.Add("Visitas");
            avg.AcceptChanges();

            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (string n in result)
            {
                ds.Tables[0].Rows.Add(new object[] { n });
                ds.AcceptChanges();

                if (dic.ContainsKey(DateTime.Parse(n).ToString("dd-MM-yyyy")))
                {
                    dic[DateTime.Parse(n).ToString("dd-MM-yyyy")]++;
                }
                else
                {
                    dic.Add(DateTime.Parse(n).ToString("dd-MM-yyyy"), 1);
                }
            }

            avg.Rows.Clear();
            foreach (var d in dic)
            {
                avg.Rows.Add(new object[] { d.Key, d.Value.ToString() });
            }
            avg.AcceptChanges();

            try
            {
                visitasGridView.DataSource = avg;
                //casosGridView.DataSource = ds.Tables["Casos"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            con.Close();
        }
        #endregion
    }
}
