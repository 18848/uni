using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        public string currentPath = Directory.GetCurrentDirectory();

        public Form1()
        {
            currentPath = currentPath.Replace("\\Dashboard\\Dashboard\\bin\\Debug\\net5.0-windows", "");
            InitializeComponent();
            button1_Click(null, null);
            button2_Click(null, null);
            button1_Click_1(null, null);
            button3_Click(null, null);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            try
            {
                string filePath = currentPath + "\\KNIME\\Json\\File_0PrecMax.json";

                StreamReader r = new StreamReader(filePath);
                string jsonString = r.ReadToEnd();

                List<itemPrec> precipitacao = Newtonsoft.Json.JsonConvert.DeserializeObject<List<itemPrec>>(jsonString);

                this.dataGridView1.DataSource = precipitacao;
                foreach (DataGridViewRow rw in this.dataGridView1.Rows)
                {
                    for (int i = 0; i < rw.Cells.Count; i++)
                    {
                        if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                        {
                            rw.Cells[i].Value = "Sem informação";
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string filePath = currentPath + "\\KNIME\\Json\\File_0TempMax.json";

                StreamReader r = new StreamReader(filePath);
                string jsonString = r.ReadToEnd();

                List<TempMax> temperaturaMax = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TempMax>>(jsonString);

                this.dataGridView4.DataSource = temperaturaMax;
                foreach (DataGridViewRow rw in this.dataGridView4.Rows)
                {
                    for (int i = 0; i < rw.Cells.Count; i++)
                    {
                        if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                        {
                            rw.Cells[i].Value = "Sem informação";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = currentPath + "\\KNIME\\Json\\File_0PrevBraga.json";

                StreamReader r = new StreamReader(filePath);
                string jsonString = r.ReadToEnd();

                List<PrevBraga> prevBraga = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PrevBraga>>(jsonString);

                this.dataGridView2.DataSource = prevBraga;

                foreach (DataGridViewRow rw in this.dataGridView2.Rows)
                {
                    for (int i = 0; i < rw.Cells.Count; i++)
                    {
                        if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                        {
                            rw.Cells[i].Value = "Sem informação";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = currentPath + "\\KNIME\\Json\\File_0TempMin.json";

                StreamReader r = new StreamReader(filePath);
                string jsonString = r.ReadToEnd();

                List<TempMin> temperaturaMin = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TempMin>>(jsonString);

                this.dataGridView3.DataSource = temperaturaMin;

                foreach (DataGridViewRow rw in this.dataGridView3.Rows)
                {
                    for (int i = 0; i < rw.Cells.Count; i++)
                    {
                        if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                        {
                            rw.Cells[i].Value = "Sem informação";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
