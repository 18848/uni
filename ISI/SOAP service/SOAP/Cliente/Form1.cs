using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SOAP;

namespace Cliente
{
    public partial class Form1 : Form
    {
        private Casos.CasosClient casosWS = new Casos.CasosClient();
        private Contactos.ContactosClient contactosWS = new Contactos.ContactosClient();
        private Utentes.UtentesClient utentesWS = new Utentes.UtentesClient();

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
            try
            {
                DataSet ds = new DataSet();
                ModeloUtente u = new ModeloUtente("", 0);

                if(nifBox.Text != "")
                {
                    ds = utentesWS.GetUtentesByNIF(int.Parse(nifBox.Text));
                    DataRow [] dr = ds.Tables["Utentes"].Select("idutente = " + nifBox.Text);
                    u.Nif = int.Parse(dr[0][0].ToString());
                }
                else if(nomeBox.Text != "")
                {
                    ds = utentesWS.GetUtentesByNome(nomeBox.Text.ToString());
                    DataRow[] dr = ds.Tables["Utentes"].Select("nome = '" + nomeBox.Text + "'");
                    u.Nome = dr[0][1].ToString();
                }
                if (u.Nif != 0 || u.Nome != "")
                {
                    GetUtentes.DataSource = ds.Tables["Utentes"];
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("FORMAT EXCEPTION:\n" + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION:\n" + ex.Message.ToString());
            }
        }

        private void adicionar_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloUtente u = new ModeloUtente(
                                    nomeBox.Text
                                    , int.Parse(nifBox.Text));
                string result = utentesWS.AddUtentes(u.Nif, u.Nome);
                MessageBox.Show(result);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("FORMAT EXCEPTION:\n" + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION:\n" + ex.Message.ToString());
            }
        }

        private void atualizar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = utentesWS.GetUtentes();
                GetUtentes.DataSource = ds.Tables["Utentes"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION:\n" + ex.Message.ToString());
            }
        }

        #endregion

        #region Botões Casos
        private void atualizarCasos_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = casosWS.GetCasos();
                GetCasos.DataSource = ds.Tables["Casos"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void adicionarCasos_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloCasos c = new ModeloCasos(
                                DateTime.Parse(dataPicker.Text).ToString("yyyy-MM-dd")
                                , int.Parse(nifCasosBox.Text));
                MessageBox.Show(casosWS.AddCasos(c.Data, c.Nif));
            }
            catch (FormatException ex)
            {
                MessageBox.Show("FORMAT EXCEPTION:\n" + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION:\n" + ex.Message.ToString());
            }
        }

        private void procurarCasos_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ModeloCasos c = new ModeloCasos("", 0);
            string dataBox = "";

            try
            {
                dataBox = DateTime.Parse(dataPicker.Text).ToString("yyyy-MM-dd");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("FORMAT EXCEPTION:\n" + ex.Message.ToString());
            }

            if (nifCasosBox.Text != "")
            {
                try
                {
                    ds = casosWS.GetCasosByNIF(int.Parse(nifCasosBox.Text));
                    DataRow[] dr = ds.Tables["Casos"].Select("idutente = " + nifCasosBox.Text);
                    c.Nif = int.Parse(dr[0][2].ToString());
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("FORMAT EXCEPTION:\n" + ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION:\n" + ex.Message.ToString());
                }
            }
            else if (dataBox != "")
            {
                try
                {
                    ds = casosWS.GetCasosByData(dataBox);
                    DataRow[] dr = ds.Tables["Casos"].Select("data = '" + dataBox + "'");
                    c.Data = dr[0][1].ToString();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("FORMAT EXCEPTION:\n" + ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION:\n" + ex.Message.ToString());
                }
            }
            if (c.Nif != 0 || c.Data != "")
            {
                try
                {
                    GetCasos.DataSource = ds.Tables["Casos"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION:\n" + ex.Message.ToString());
                }
            }
        }
        #endregion

        #region Botões Contactos
        private void atualizarContactos_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = contactosWS.GetContacto();
                GetContactos.DataSource = ds.Tables["Contactos"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION:\n" + ex.Message.ToString());
            }
        }

        private void adicionarContactos_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloContactos con= new ModeloContactos(
                            int.Parse(idCasoBox.Text)
                            , int.Parse(nifContactoBox.Text));
                MessageBox.Show(contactosWS.AddContacto(con.Nif, con.IdCaso));
            }
            catch (FormatException ex)
            {
                MessageBox.Show("FORMAT EXCEPTION:\n" + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION:\n" + ex.Message.ToString());
            }
        }

        private void procurarContactos_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            bool print = false;

            if (idCasoBox.Text != "" && nifContactoBox.Text != "")
            {
                try
                {
                    ds = contactosWS.GetContactoByAtributes(int.Parse(nifContactoBox.Text), true);

                    List<DataRow> toDelete = new List<DataRow>();

                    //object[] row = { "" };
                    foreach (DataRow r in ds.Tables["Contactos"].Rows)
                    {
                        MessageBox.Show(r["idcaso"].ToString());
                        if (int.Parse(r["idcaso"].ToString()) != int.Parse(idCasoBox.Text))
                        {
                            toDelete.Add(r);
                        }
                    }

                    foreach (DataRow dr in toDelete)
                    {
                        ds.Tables["Contactos"].Rows.Remove(dr);
                    }

                    print = true;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("FORMAT EXCEPTION:\n" + ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION:\n" + ex.Message.ToString());
                }
            }
            else if (idCasoBox.Text != "")
            {
                try
                {
                    ds = contactosWS.GetContactoByAtributes(int.Parse(idCasoBox.Text), false);
                    print = true;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("FORMAT EXCEPTION:\n" + ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION:\n" + ex.Message.ToString());
                }
            }
            else if (nifContactoBox.Text != "")
            {
                try
                {
                    ds = contactosWS.GetContactoByAtributes(int.Parse(nifContactoBox.Text), true);
                    print = true;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("FORMAT EXCEPTION:\n" + ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION:\n" + ex.Message.ToString());
                }
            }

            if (print)
            {
                try
                {
                    GetContactos.DataSource = ds.Tables["Contactos"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION:\n" + ex.Message.ToString());
                }
            }
        }
        #endregion
    }
}
