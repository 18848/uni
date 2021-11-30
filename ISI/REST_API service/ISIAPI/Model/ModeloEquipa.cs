using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using System;

namespace ISIAPI
{
    public class ModeloEquipa
    {
        private int idEquipa;
        private string nome;


        public ModeloEquipa(int id, string n)
        {
            idEquipa = id;
            nome = n;

        }

        [Required]
        public int Id { get => idEquipa; set => idEquipa = value; }
        [Required]
        public string Nome { get => nome; set => nome = value; }
    }


    public class ModeloEquipas
    {

        List<ModeloEquipa> equipas;

        public ModeloEquipas()
        {
            if (equipas == null)
                equipas = new List<ModeloEquipa>();
        }

        public List<ModeloEquipa> Equipas
        {
            get => equipas;
        }

        //Obter todos os materiais
        public string GetAllEquipas()
        {

            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string q = "SELECT * FROM equipa";
            SqlDataAdapter da = new SqlDataAdapter(q, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(dt);
            con.Close();
            return jsonString;

        }

        //Adicionar uma equipa
        public string AddEquipa(ModeloEquipa s)
        {

            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string q = "INSERT INTO equipa (nome) values('" + s.Nome + "')";

            try
            {
                //4º Execute INSERT
                SqlCommand com = new SqlCommand(q, con);

                com.ExecuteNonQuery();
                con.Close();
                return "True";
            }
            catch (SqlException ex)
            {
                return "SQL Server:\n" + ex.Message.ToString();
            }
            catch (Exception ex)
            {
                return "Exception:\n" + ex.Message.ToString();
            }

        }

        //Encontrar nome de material
        public string GetEquipaById(int idEquipa)
        {
            return "True";
        }

    }
}
