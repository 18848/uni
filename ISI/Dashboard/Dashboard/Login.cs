using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Dashboard.Casos;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.IO;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;

using API.Models;


namespace Dashboard
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "https://localhost:44339/api/Security/login";

                List<ConcelhoModel> equipas = new List<ConcelhoModel>();
                HttpClient client = new HttpClient();

                HttpResponseMessage response = client.PostAsync(url, new StringContent(System.Text.Json.JsonSerializer.Serialize(new
                { username = unameBox.Text, password = passwdBox.Text}), Encoding.UTF8, "application/json")).Result;

                AuthResponse res = JsonConvert.DeserializeObject<AuthResponse>(response.Content.ReadAsStringAsync().Result);
                MessageBox.Show(res.Name);

                if (res.Name != "")
                {
                    StreamWriter writer = new StreamWriter("tmp");
                    writer.Write(res.Token);
                    writer.Close();
                }
                else
                {
                    StreamWriter writer = new StreamWriter("tmp");
                    writer.Write(res.Token);
                    writer.Close();
                    MessageBox.Show("Authentication Failed.");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
