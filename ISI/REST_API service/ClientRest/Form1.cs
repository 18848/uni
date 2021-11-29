using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace ClientRest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Botão de fechar o form
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        //Get Equipas Botão
        private void button6_Click(object sender, EventArgs e)
        {

            this.listBox1.Items.Clear();

            List<EquipaModel> equipas = new List<EquipaModel>();

            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri("https://localhost:44370/");
            HttpResponseMessage response = clint.GetAsync("api/Equipa/getall").Result;
            var res = response.Content.ReadAsStringAsync().Result;

            equipas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EquipaModel>>(res);

            foreach(EquipaModel s in equipas){
                this.listBox1.Items.Add(s.idEquipa + " - " +  s.nome);
            }
        }
        //Get Requisicao botao
        private void button7_Click(object sender, EventArgs e)
        {
            this.listBox2.Items.Clear();

            List<RequisicaoModel> requisicoes = new List<RequisicaoModel>();

            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri("https://localhost:44370/");
            HttpResponseMessage response = clint.GetAsync("api/Requisicao/getall").Result;
            var res = response.Content.ReadAsStringAsync().Result;

            requisicoes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RequisicaoModel>>(res);

            foreach (RequisicaoModel s in requisicoes)
            {
                this.listBox2.Items.Add(s.idRequisicao + " - " + s.entregue.ToString() + " - " + s.idEquipa);
            }
        }

        //Get Materiais botao
        private void button8_Click(object sender, EventArgs e)
        {
            this.listBox3.Items.Clear();

            List<MaterialModel> materiais = new List<MaterialModel>();

            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri("https://localhost:44370/");
            HttpResponseMessage response = clint.GetAsync("api/Material/getall").Result;
            var res = response.Content.ReadAsStringAsync().Result;

            materiais = Newtonsoft.Json.JsonConvert.DeserializeObject < List <MaterialModel>>(res);

            foreach (MaterialModel s in materiais)
            {
                this.listBox3.Items.Add(s.idMaterial + " - " + s.nome + " - " + s.custo);
            }
        }
        

        //Ao selecionar um item na lista de equipas
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.listBox2.Items.Clear();
            this.listBox3.Items.Clear();

            string curItem = listBox1.SelectedItem.ToString();
            string[] tokens = curItem.Split(new[] { " - " }, StringSplitOptions.None);

            List<RequisicaoModel> requisicoes = new List<RequisicaoModel>();

            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri("https://localhost:44370/");
            HttpResponseMessage response = clint.GetAsync("api/Requisicao/getrequisicaobyequipa/" + tokens[0]).Result;
            var res = response.Content.ReadAsStringAsync().Result;

            requisicoes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RequisicaoModel>>(res);

            foreach (RequisicaoModel s in requisicoes)
            {
                this.listBox2.Items.Add(s.idRequisicao + " - " + s.entregue.ToString() + " - " + s.idEquipa);
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox3.Items.Clear();

            string curItem = listBox2.SelectedItem.ToString();
            string[] tokens = curItem.Split(new[] { " - " }, StringSplitOptions.None);

            List<RequisicaoMaterialModel> materiais = new List<RequisicaoMaterialModel>();

            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri("https://localhost:44370/");
            HttpResponseMessage response = clint.GetAsync("/api/RequisicaoMaterial/getmaterialbyrequisicao/" + int.Parse(tokens[0])).Result;
            var res = response.Content.ReadAsStringAsync().Result;
            MessageBox.Show(res);
            materiais = Newtonsoft.Json.JsonConvert.DeserializeObject <List<RequisicaoMaterialModel>>(res);

            foreach (RequisicaoMaterialModel s in materiais)
            {
                this.listBox3.Items.Add(s.idMaterial + " - " + s.nome + " - " + s.custo.ToString() + " - " + s.qtd.ToString());
            }
        }
    }

    public class EquipaModel
    {
        public int idEquipa { get; set; }
        public string nome { get; set; }
    }
    public class RequisicaoModel
    {
        public int idRequisicao { get; set; }
        public bool entregue { get; set; }
        public int idEquipa { get; set; }
    }
    public class MaterialModel
    {
        public int idMaterial { get; set; }

        public string nome { get; set; }

        public float custo { get; set; }
    }
    public class RequisicaoMaterialModel
    {
        public int idRequsicao { get; set; }
        public int idMaterial { get; set; }
        public string nome { get; set; }
        public float custo { get; set; }
        public int qtd { get; set; }
    }
}
