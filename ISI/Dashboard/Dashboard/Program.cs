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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

            if (!File.Exists("tmp"))
            {
                Application.Exit();
            }

            StreamReader reader = new StreamReader("tmp");
            var x = reader.ReadToEnd();
            reader.Close();


            if (x != "" || x != null)
            {
                Application.Run(new Form1());
            }

            File.Delete("tmp");
        }
    }
    
}
