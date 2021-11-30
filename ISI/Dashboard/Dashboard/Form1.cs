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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgs_Click(object sender, EventArgs e)
        {
            List<Concelho> concelhos = new List<Concelho>();
            HttpClient clint = new HttpClient();
            HttpResponseMessage response = clint.GetAsync("https://covid19-api.vost.pt/Requests/get_last_update_counties").Result;
            var res = response.Content.ReadAsStringAsync().Result;

            concelhos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Concelho>>(res);
            this.dataGridView1.DataSource = concelhos;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
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
