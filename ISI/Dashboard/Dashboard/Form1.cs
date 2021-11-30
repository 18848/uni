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

        private async void mediaButton_Click(object sender, EventArgs e)
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

            mediaButton.Text = "Média de Casos: " + (result.Count / 6).ToString();

            ds.Tables["Casos"].Rows.Clear();
            ds.Tables["Casos"].Columns.Remove("idcaso");
            avg.Columns.Add("Mes");
            avg.Columns.Add("Total Mensal");
            avg.AcceptChanges();

            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (ModeloCasos n in result)
            {
                ds.Tables["Casos"].Rows.Add(new object[] { n.Data, n.Nif });
                ds.AcceptChanges();

                if (dic.ContainsKey(DateTime.Parse(n.Data).Month.ToString()))
                {
                    dic[DateTime.Parse(n.Data).Month.ToString()]++;
                }
                else
                {
                    dic.Add(DateTime.Parse(n.Data).Month.ToString(), 1);
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

        #region Equipas
        //Botão para equipas mais caras
        private void button1_Click(object sender, EventArgs e)
        {
            List<EquipaModel> equipas = new List<EquipaModel>();
            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri("https://localhost:44370/");
            HttpResponseMessage response = clint.GetAsync("api/Equipa/getEquipaMaisCara").Result;
            var res = response.Content.ReadAsStringAsync().Result;

            equipas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EquipaModel>>(res);
            this.dataGridView2.DataSource = equipas;
        }

        //Botão para produtos mais usados
        private void button2_Click(object sender, EventArgs e)
        {

            List<MaterialModel> materiais = new List<MaterialModel>();
            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri("https://localhost:44370/");
            HttpResponseMessage response = clint.GetAsync("api/Material/getMaterialMaisUsado").Result;
            var res = response.Content.ReadAsStringAsync().Result;

            materiais = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MaterialModel>>(res);
            this.dataGridView3.DataSource = materiais;

        }
        #endregion

        #region DGS
        private void dgs_Click(object sender, EventArgs e)
        {
            List<Concelho> concelhos = new List<Concelho>();
            HttpClient clint = new HttpClient();
            HttpResponseMessage response = clint.GetAsync("https://covid19-api.vost.pt/Requests/get_last_update_counties").Result;
            var res = response.Content.ReadAsStringAsync().Result;

            concelhos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Concelho>>(res);
            this.dataGridView1.DataSource = concelhos;
        }
        #endregion
    }
    public class MaterialModel
    {
        public int idMaterial { get; set; }
        public string nome { get; set; }
        public int total { get; set; }
    }


    public class EquipaModel
    {
        public int idEquipa { get; set; }
        public string nome { get; set; }
        public float total { get; set; }
    }


    // Classe dos dados provenintes da api https://covid19-api.vost.pt
    public class Concelho
    {
        public string data { get; set; }
        public string concelho { get; set; }
        public int confirmados_14 { get; set; }
        public int confirmados_1 { get; set; }
        public int incidencia { get; set; }
        public string incidencia_categoria { get; set; }
        public string incidencia_risco { get; set; }
        public string tendencia_incidencia { get; set; }
        public string tendencia_categoria { get; set; }
        public string tendencia_desc { get; set; }
        public int casos_14dias { get; set; }
        public string ars { get; set; }
        public string distrito { get; set; }
        public int dicofre { get; set; }
        public float area { get; set; }
        public int population { get; set; }
        public int population_65_69 { get; set; }
        public int population_70_74 { get; set; }
        public int population_75_79 { get; set; }
        public int population_80_84 { get; set; }
        public int population_85_mais { get; set; }
        public int population_80_mais { get; set; }
        public int population_75_mais { get; set; }
        public int population_70_mais { get; set; }
        public int population_65_mais { get; set; }
        public float densidade_populacional { get; set; }
        public float densidade_1 { get; set; }
        public float densidade_2 { get; set; }
        public float densidade_3 { get; set; }
    }



}
