using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace FileConversion
{
    public partial class Form1 : Form
    {
        Fiscalizacao fiscalizados;
        private protected static string server = ConfigurationManager.ConnectionStrings["ISI"].ConnectionString;
        private protected SqlConnection con = new SqlConnection(server);

        public Form1()
        {
            InitializeComponent();
        }

        #region XML
        private (Fiscalizacao, string) DeserializeXml()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Fiscalizacao));
                string filePath;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "d:\\temp";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        //Read the contents of the file into a stream
                        var fileStream = openFileDialog.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            return ((Fiscalizacao)ser.Deserialize(reader), filePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return(null, null);
        }

        private void UpdateTextBox(string filePath)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.FileName = filePath;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        xmlTextBox.Text = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType() + "\n" + ex.Message);
            }
        }

        private void xmlSendButton_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                foreach (Civil civil in fiscalizados.Fiscalizados)
                {
                    string qCivil = "INSERT INTO fiscalizacao (idcivil, nome, data) VALUES ('" + civil.IdCivil.ToString() + "','" +
                        civil.Nome + "','" + civil.Data.ToString("yyyy-MM-dd") + "')";

                    SqlCommand cmdCivil = new SqlCommand(qCivil, con);
                    cmdCivil.ExecuteNonQuery();

                    foreach(Irregularidade irregularidade in civil.Irregularidades)
                    {
                        string select = "SELECT idfiscalizacao FROM fiscalizacao WHERE idcivil = '" + civil.IdCivil.ToString()
                            + "' AND nome = LOWER('" + civil.Nome + "') AND data = '" + civil.Data.ToString("yyyy-MM-dd") + "'";

                        SqlDataAdapter da = new SqlDataAdapter(select, con);
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        string qIrregularidade = "INSERT INTO irregularidade (descricao, idfiscalizacao) VALUES ('" + irregularidade.Descricao + "','" +
                            dt.Rows[0][0].ToString() + "')";

                        SqlCommand cmdIrregularidade = new SqlCommand(qIrregularidade, con);
                        cmdIrregularidade.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Dados Adicionados com Sucesso.");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("FORMAT EXCEPTION:\n" + ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL EXCEPTION:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION:\n" + ex.Message);
            }

            try
            {
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL EXCEPTION:\n" + ex.Message);
            }
        }

        private void xmlLoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                string path;

                (fiscalizados, path) = DeserializeXml();
                if(fiscalizados == null)
                {
                    MessageBox.Show("An Error Has Ocurred While Openning File Dialog.\nPlease try again.");
                }
                else
                {
                    xmlFilePath.Text = path;
                    UpdateTextBox(path);
                }

                MessageBox.Show("File Contents Loaded Successfully");
            }
            catch (XmlException ex)
            {
                MessageBox.Show("XML. OR HAS ERRORS.\n\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION:\n" + ex.Message);
            }
        }
        #endregion

        #region JSON
        /// <summary>
        /// Function to Validate Written JSON.
        /// </summary>
        /// <returns> True if Valid. False if Not Valid. </returns>
        private bool verifyJson()
        {
            try
            {
                JSchema schema = new JSchemaGenerator().Generate(typeof(Fiscalizacao));
                JObject fiscalizacao = JObject.Parse(jsonTextBox.Text);

                if (fiscalizacao.IsValid(schema))
                {
                    fiscalizados = JsonConvert.DeserializeObject<Fiscalizacao>(jsonTextBox.Text);

                    MessageBox.Show("JSON em formato válido.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("FORMAT EXCEPTION:\n" + ex.Message);
                return false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL EXCEPTION:\n" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION:\n" + ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates JSON formatted information and if Valid stores in Database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jsonSendButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (verifyJson())
                {
                    con.Open();

                    foreach(Civil civil in fiscalizados.Fiscalizados)
                    {
                        string qCivil = "INSERT INTO fiscalizacao (idcivil, nome, data) VALUES ('" + civil.IdCivil.ToString() + "','" +
                            civil.Nome + "','" + civil.Data.ToString("yyyy-MM-dd") + "')";

                        SqlCommand cmdCivil = new SqlCommand(qCivil, con);
                        cmdCivil.ExecuteNonQuery();

                        foreach (Irregularidade irregularidade in civil.Irregularidades)
                        {
                            string select = "SELECT idfiscalizacao FROM fiscalizacao WHERE idcivil = '" + civil.IdCivil.ToString()
                               + "' AND nome = LOWER('" + civil.Nome + "') AND data = '" + civil.Data.ToString("yyyy-MM-dd") + "'";

                            SqlDataAdapter da = new SqlDataAdapter(select, con);
                            DataTable dt = new DataTable();

                            da.Fill(dt);

                            string qIrregularidade = "INSERT INTO irregularidade (descricao, idfiscalizacao) VALUES ('" + irregularidade.Descricao + "','" +
                                dt.Rows[0][0].ToString() + "')";

                            SqlCommand cmdIrregularidade = new SqlCommand(qIrregularidade, con);
                            cmdIrregularidade.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Dados Adicionados com Sucesso.");
                    
                    con.Close();
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show("FORMAT EXCEPTION:\n" + ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL EXCEPTION:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION:\n" + ex.Message);
            }
        }
        
        /// <summary>
        /// Loads file and Formats it in JSON format.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jsonLoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    //openFileDialog.InitialDirectory = "g:\\asdasdasd";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        //Read the contents of the file into a stream
                        var fileStream = openFileDialog.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                        }
                    }
                }
                fiscalizados = JsonConvert.DeserializeObject<Fiscalizacao>(fileContent);
                string json = JsonConvert.SerializeObject(fiscalizados, Newtonsoft.Json.Formatting.Indented);

                jsonFilePath.Text = "File: " + filePath;
                jsonTextBox.Text = json;

                MessageBox.Show("File Contents Loaded Successfully");
            }
            catch(JsonSerializationException ex)
            {
                MessageBox.Show("Not a JSON File. OR HAS ERRORS.\n\n" + ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("EXCEPTION:\n" + ex.Message);
            }
        }

        /// <summary>
        /// Checks if Text is a Valid JSON format.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jsonVerifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                verifyJson();
            }
            catch (JsonException ex)
            {
                MessageBox.Show("JSON EXCEPTION:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION:\n" + ex.Message);
            }
        }

        #endregion

        #region Get DataBase

        /// <summary>
        /// Gets Stored Information on DataBase.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void atualizarDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                //2º OpenConnection
                con.Open();
            }
            catch (Exception ex)
            {
                DataSet x = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                x.Tables.Add(dt);
                databaseGridView.DataSource = x;
            }

            //3º Query
            string q = "SELECT * FROM fiscalizacao";

            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            try
            {
                //4º Execute
                da.Fill(ds1, "Fiscalizacao");

                //5º CloseConnection
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Exception");
                dt.Rows.Add(ex.Message);
                ds1.Tables.Add(dt);
                databaseGridView.DataSource= ds1;
            }

            if(idFiscalizacaoTextBox.Text != "")
            {
                q = "SELECT idirregularidade, descricao FROM irregularidade WHERE idfiscalizacao = '" + idFiscalizacaoTextBox.Text + "'";
                da = new SqlDataAdapter(q, con);

                da.Fill(ds2, "Fiscalizacao");
            }

            databaseGridView.DataSource= ds1.Tables["Fiscalizacao"];
            irregularidadesDataGrid.DataSource= ds2.Tables["Fiscalizacao"];
            con.Close();
        }

        #endregion
    }
}
