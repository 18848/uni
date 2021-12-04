using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dashboard.Casos;
using System.Net.Http;
//using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
            bool auth = false;
            try
            {
                string url = "https://localhost:44339/api/Security/authorize";
                StreamReader reader = new StreamReader("tmp");
                string token = reader.ReadToEnd();
                reader.Close();

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                HttpResponseMessage response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode)
                {
                    auth = false;
                }
                else
                {
                    auth = Newtonsoft.Json.JsonConvert.DeserializeObject<bool>(res);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            if(auth == true)
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
        }
        #endregion

        #region Visitas

        private void visitas_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "https://localhost:44339/api/Visitas";
                StreamReader reader = new StreamReader("tmp");
                string token = reader.ReadToEnd();
                reader.Close();

                DataTable visitas = new DataTable();
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                HttpResponseMessage response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;


                if (response.IsSuccessStatusCode)
                {
                    var x = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string,string>>(res);

                    visitas.Columns.Add("Data");
                    visitas.Columns.Add("Visitas");
                    visitas.AcceptChanges();

                    foreach(var item in x)
                    {
                        visitas.Rows.Add(item.Key, item.Value);
                    }
                    visitas.AcceptChanges();

                    this.visitasGridView.DataSource = visitas;
                }
                else
                {
                    MessageBox.Show("You are not allowed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Equipas
        //Botão para equipas mais caras
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "https://localhost:44339/api/Equipas/equipas";
                StreamReader reader = new StreamReader("tmp");
                string token = reader.ReadToEnd();
                reader.Close();

                List<EquipaModel> equipas = new List<EquipaModel>();
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                HttpResponseMessage response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;

                equipas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EquipaModel>>(res);
                this.dataGridView2.DataSource = equipas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //Botão para produtos mais usados
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "https://localhost:44339/api/Equipas/material";
                StreamReader reader = new StreamReader("tmp");
                string token = reader.ReadToEnd();
                reader.Close();

                List<MaterialModel> materiais = new List<MaterialModel>();
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                HttpResponseMessage response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;

                materiais = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MaterialModel>>(res);
                this.dataGridView3.DataSource = materiais;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        #endregion

        #region DGS
        private void dgs_Click(object sender, EventArgs e)
        {
            
            try
            {
                string url = "https://localhost:44339/api/DGS";
                StreamReader reader = new StreamReader("tmp");
                string token = reader.ReadToEnd();
                reader.Close();

                List<ConcelhoModel> concelhos = new List<ConcelhoModel>();
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                HttpResponseMessage response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;

                concelhos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConcelhoModel>>(res);
                this.dataGridView1.DataSource = concelhos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    public class ConcelhoModel
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
