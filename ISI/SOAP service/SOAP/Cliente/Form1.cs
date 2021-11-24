using System;
using System.Data;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form1 : Form
    {
        SOAP.CasosClient ws = new SOAP.CasosClient();
        public Form1()
        {
            InitializeComponent();
            GetUtentes.DataSource = ws.GetUtentes();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            GetUtentes.DataSource = ws.GetUtentes();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            GetUtentes.DataSource = ws.GetUtentes();
        }

        private void procurar_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            int nif = 0;
            string nome = "";

            if(nifBox.Text != "")
            {
                ds = ws.GetUtentesByNIF(int.Parse(nifBox.Text));
                DataRow [] dr = ds.Tables["Utentes"].Select("idutente = " + nifBox.Text);
                nif = int.Parse(dr[0][0].ToString());
            }
            else if(nomeBox.Text != "")
            {
                ds = ws.GetUtentesByNome(nomeBox.Text.ToString());
                DataRow[] dr = ds.Tables["Utentes"].Select("nome = '" + nomeBox.Text + "'");
                nome = dr[0][1].ToString();
            }
            if (nif != 0 || nome != "")
            {
                GetUtentes.DataSource = ds.Tables["Utentes"];
            }
        }

        //private async void procurar_Click(object sender, EventArgs e)
        //{
        //    DataSet ds = new DataSet();
        //    ds = await ws.GetUtentesAsync();
        //    GetUtentes.DataSource = ds.Tables["Utentes"];
        //}

        private void adicionar_Click(object sender, EventArgs e)
        {
            int nif = int.Parse(nifBox.Text);
            string nome = nomeBox.Text;
            ws.AddUtentes(nif, nome);
        }

        private void atualizar_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = ws.GetUtentes();
            GetUtentes.DataSource = ds.Tables["Utentes"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
