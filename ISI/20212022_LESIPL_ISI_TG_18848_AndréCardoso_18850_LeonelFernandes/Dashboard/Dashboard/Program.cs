using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

using System.IO;
using API.Models;

namespace Dashboard
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (File.Exists("tmp"))
            {
                File.Delete("tmp");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

            string x = "";

            if (File.Exists("tmp"))
            {
                StreamReader reader = new StreamReader("tmp");
                x = reader.ReadToEnd();
                reader.Close();
                if(x == "")
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }



            if (x != "")
            {
                Application.Run(new Form1());
            }

            File.Delete("tmp");
        }
    }
    
}
