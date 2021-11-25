using System;
using System.Data;
using System.Windows.Forms;
using SOAP;

namespace Cliente
{
    public partial class Form1 : Form
    {
        private SOAP.CasosClient ws = new SOAP.CasosClient();

        #region Form
        public Form1()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Botões Utentes
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

        #endregion

        #region Botões Casos
        private void atualizarCasos_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ws.GetCasos();
                GetCasos.DataSource = ds.Tables["Casos"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void adicionarCasos_Click(object sender, EventArgs e)
        {
            ModeloCasos casos = new ModeloCasos(
                            DateTime.Parse(dataPicker.Text).ToString("yyyy-MM-dd")
                            , int.Parse(nifCasosBox.Text));
            ws.AddCasos(casos.Data, casos.Nif);
        }

        private void procurarCasos_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            int nif = 0;
            string data = "";
            string dataBox = DateTime.Parse(dataPicker.Text).ToString("yyyy-MM-dd");

            if (nifCasosBox.Text != "")
            {
                try
                {
                    ds = ws.GetCasosByNIF(int.Parse(nifCasosBox.Text));
                    DataRow[] dr = ds.Tables["Casos"].Select("idutente = " + nifCasosBox.Text);
                    nif = int.Parse(dr[0][2].ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else if (dataBox != "")
            {
                try
                {
                    ds = ws.GetCasosByData(dataBox);
                    DataRow[] dr = ds.Tables["Casos"].Select("data = '" + dataBox + "'");
                    data = dr[0][1].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            if (nif != 0 || data != "")
            {
                try
                {
                    GetCasos.DataSource = ds.Tables["Casos"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        #endregion

        #region Contactos
        private void atualizarContactos_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ws.GetContacto();
                GetContactos.DataSource = ds.Tables["Contactos"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void adicionarContactos_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloContactos contactos= new ModeloContactos(
                            int.Parse(idCasoBox.Text)
                            , int.Parse(nifContactoBox.Text));
                ws.AddContacto(contactos.Nif, contactos.IdCaso);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void procurarContactos_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
