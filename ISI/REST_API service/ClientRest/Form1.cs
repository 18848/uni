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
using System.Net.Http.Headers;


namespace ClientRest
{
    public partial class Form1 : Form
    { 
        /// <summary>
        /// Variáveis
        /// </summary>
        string selectedMaterial; // Material selecionado na tabela de adicionar

        int upAndDownValue; // Valor definido para quantidade do material

        string selectedRemoveItem; // Material selecionado para remover

        string nomeMaterialAdd; // Nome do material a adicionar

        string custoMaterialAdd; // Custo do material a adicionar

        string equipaSelecionada; // Equipa Selecionada na primeira listbox

        string lisboxReqSelecionado; // Elemento selecionado na lista de requisições

        string nomeEquipaAdd; //Nome da Equipa a Adicionar

        /// <summary>
        /// Função que inicializa o form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Botão de fechar o form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region ObterDados


        /// <summary>
        /// Botão para obter todas as equipas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.listBox1.Items.Clear();

                List<EquipaModel> equipas = new List<EquipaModel>();
                HttpClient clint = new HttpClient();
                clint.BaseAddress = new Uri("https://localhost:44370/");
                HttpResponseMessage response = clint.GetAsync("api/Equipa/getall").Result;
                var res = response.Content.ReadAsStringAsync().Result;

                equipas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EquipaModel>>(res);

                foreach (EquipaModel s in equipas)
                {
                    this.listBox1.Items.Add(s.idEquipa + " - " + s.nome);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Botão para obter todas as requisições
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Botão para obter todos os materiais
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                this.listBox3.Items.Clear();

                List<MaterialModel> materiais = new List<MaterialModel>();
                HttpClient clint = new HttpClient();
                clint.BaseAddress = new Uri("https://localhost:44370/");
                HttpResponseMessage response = clint.GetAsync("api/Material/getall").Result;
                var res = response.Content.ReadAsStringAsync().Result;

                materiais = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MaterialModel>>(res);

                foreach (MaterialModel s in materiais)
                {
                    this.listBox3.Items.Add(s.idMaterial + " - " + s.nome + " - " + s.custo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        
        /// <summary>
        /// Ao selecionar um item na lista de equipas apresenta as requisiçoes da mesma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        /// <summary>
        /// Ao selecionar um elemento na lista de requisições mostra os materiais presentes na mesma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox2.SelectedItem != null)
            {
                try
                {
                    this.listBox3.Items.Clear();
                    string curItem = listBox2.SelectedItem.ToString();
                    lisboxReqSelecionado = curItem; // Selecionar o elemento

                    string[] tokens = curItem.Split(new[] { " - " }, StringSplitOptions.None);

                    List<RequisicaoMaterialModel> materiais = new List<RequisicaoMaterialModel>();
                    HttpClient clint = new HttpClient();
                    clint.BaseAddress = new Uri("https://localhost:44370/");
                    HttpResponseMessage response = clint.GetAsync("/api/RequisicaoMaterial/getmaterialbyrequisicao/" + int.Parse(tokens[0])).Result;
                    var res = response.Content.ReadAsStringAsync().Result;
                    materiais = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RequisicaoMaterialModel>>(res);

                    foreach (RequisicaoMaterialModel s in materiais)
                    {
                        this.listBox3.Items.Add(s.idMaterial + " - " + s.nome + " - " + s.custo.ToString() + " - " + s.qtd.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            
        }
        #endregion

        #region Cria Nova RequisiçãoMaterial
        /// <summary>
        /// Altera o valor para adicionar um material através do numerical up and down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            upAndDownValue = Decimal.ToInt32(this.numericUpDown1.Value);
        }

        /// <summary>
        /// Botão para receber todas as equipas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                this.listBox4.Items.Clear();

                List<EquipaModel> equipas = new List<EquipaModel>();
                HttpClient clint = new HttpClient();
                clint.BaseAddress = new Uri("https://localhost:44370/");
                HttpResponseMessage response = clint.GetAsync("api/Equipa/getall").Result;
                var res = response.Content.ReadAsStringAsync().Result;

                equipas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EquipaModel>>(res);

                foreach (EquipaModel s in equipas)
                {
                    this.listBox4.Items.Add(s.idEquipa + " - " + s.nome);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Ao selecionar a equipa na lista guarda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipaSelecionada = this.listBox4.SelectedItem.ToString();
        }

        /// <summary>
        /// Botão para apresentar todos os materiais
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.listBox5.Items.Clear();

                List<MaterialModel> materiais = new List<MaterialModel>();
                HttpClient clint = new HttpClient();
                clint.BaseAddress = new Uri("https://localhost:44370/");
                HttpResponseMessage response = clint.GetAsync("api/Material/getall").Result;
                var res = response.Content.ReadAsStringAsync().Result;

                materiais = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MaterialModel>>(res);

                foreach (MaterialModel s in materiais)
                {
                    this.listBox5.Items.Add(s.idMaterial + " - " + s.nome + " - " + s.custo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        /// <summary>
        /// Ao selecionar um item guarda numa variavel para adicionar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox5.SelectedItem != null)
            {
                selectedMaterial = listBox5.SelectedItem.ToString();
            }


        }

        /// <summary>
        /// Botão para adicionar o item selecionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.listBox6.Items.Add(selectedMaterial + " - " + upAndDownValue);
        }

        /// <summary>
        /// Botão para enviar a Requisição com os materiais todos na lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button3_Click_1(object sender, EventArgs e)
        {
            if(equipaSelecionada != null && this.listBox6.Items != null)
            {
                string[] tokensEquipa = equipaSelecionada.Split(new[] { " - " }, StringSplitOptions.None);
                
                //Formatação do Json para envio no post
                string json = "[";
                foreach (var x in listBox6.Items)
                {
                    string item = x.ToString();
                    string[] tokensItem = item.Split(new[] { " - " }, StringSplitOptions.None);
                    json = json + "{\"idMaterial\":" + tokensItem[0] + ",\"qtd\":" + tokensItem[3] + "},";
                }
                //Remover "," a mais na string
                json = json.Remove(json.Length - 1);
                json = json + "]";
                var materialAdd = JsonConvert.SerializeObject(json);
                var conteudo = new StringContent(materialAdd, Encoding.UTF8, "application/json");

                try
                {
                    //Enviar o post de uma nova requisicao Material
                    HttpClient clint = new HttpClient();
                    clint.BaseAddress = new Uri("https://localhost:44370/");
                    var response = await clint.PostAsync("api/RequisicaoMaterial/postRequisicaoMateriais/" + tokensEquipa[0], conteudo);

                    string res = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
                this.listBox6.Items.Clear();

            }
        }

        

        #endregion

        #region RemoverItemListaAdd

        /// <summary>
        /// Ao selecionar um item na lista de materiais para adicionar, adiciona à variável para remover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox6.SelectedItem != null)
            {
                selectedRemoveItem = this.listBox6.SelectedItem.ToString();
            }
        }

        /// <summary>
        /// Botão para remover o item selecionado na lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            if(selectedRemoveItem != null)
            {
                listBox6.Items.Remove(selectedRemoveItem);
            }
        }
        #endregion

        #region NovoMaterial
        /// <summary>
        /// Guardar o texto do nome do novo material a ser adicionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            nomeMaterialAdd = textBox1.Text;
        }
        /// <summary>
        /// Guardar o texto do custo do novo material a ser adicionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            custoMaterialAdd = textBox2.Text;
        }

        /// <summary>
        /// Botão para criar um novo material
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button4_Click_1(object sender, EventArgs e)
        {

            MaterialModel material = new MaterialModel();

            //Definir o conteudo para enviar por post
            string materialAdd = "{\"nome\": \"" + nomeMaterialAdd + "\" , \"custo\": " + custoMaterialAdd + "}";
            var json = JsonConvert.SerializeObject(materialAdd);
            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
           
            try
            {
                //Enviar o post de um novo material
                HttpClient clint = new HttpClient();
                clint.BaseAddress = new Uri("https://localhost:44370/");
                var response = await clint.PostAsync("api/Material/addmaterial", conteudo);

                string res = response.Content.ReadAsStringAsync().Result;
                //Atualizar tabela de materiais adicionados
                string materialJson = "{\"idMaterial\":" + res + ",\"nome\": \"" + nomeMaterialAdd + "\", \"custo\":" + custoMaterialAdd + "}";
                material = Newtonsoft.Json.JsonConvert.DeserializeObject<MaterialModel>(materialJson);
                if (res != null)
                {
                    this.listBox6.Items.Add(material.idMaterial + " - " + material.nome + " - " + material.custo + " - " + upAndDownValue);
                }
                button5_Click_1(null, null);

            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }
        #endregion


        #region UpdateEntregueRequisição

        /// <summary>
        /// Dar update ao campo "entregue" de uma requisição
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button11_Click(object sender, EventArgs e)
        {

            if(lisboxReqSelecionado != null)
            {
                try
                {
                    string[] token = lisboxReqSelecionado.Split(new[] { " - " }, StringSplitOptions.None);

                    string materialAdd = "";
                    var json = JsonConvert.SerializeObject(materialAdd);
                    var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpClient clint = new HttpClient();
                    clint.BaseAddress = new Uri("https://localhost:44370/");
                    var response = await clint.PutAsync("api/Requisicao/updateEntregue/" + token[0], conteudo);

                    button7_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            } 

        }
        #endregion


        #region AddEquipa

        /// <summary>
        /// Guardar o texto referente ao nome da nova equipa a ser adicionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            nomeEquipaAdd = textBox3.Text;
        }


        /// <summary>
        /// Botão para criar nova equipa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button12_Click(object sender, EventArgs e)
        {
            if (nomeEquipaAdd != null)
            {
                //Definir o conteudo para enviar por post
                string equipaAdd = "{\"nome\": \"" + nomeEquipaAdd + "\"}";
                var json = JsonConvert.SerializeObject(equipaAdd);
                var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
                
                try
                {
                    //Enviar o post de uma nova equipa
                    HttpClient clint = new HttpClient();
                    clint.BaseAddress = new Uri("https://localhost:44370/");
                    var response = await clint.PostAsync("api/Equipa/addEquipa", conteudo);
                    button9_Click(null, null);


                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
            
        }
        #endregion
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
