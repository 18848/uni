using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using System;

namespace ISIAPI
{
    public class ModeloMaterial
    {
        private int idMaterial;
        private string nome;
        private float custo;

        [Required]
        public int Id { get => idMaterial; set => idMaterial = value; }
        public string Nome { get => nome; set => nome = value; }
        public float Custo { get => custo; set => custo = value; }
    }

    
    public class ModeloMateriais{

        List<ModeloMaterial> materiais;

        public ModeloMateriais(){
            if (materiais == null)
                materiais = new List<ModeloMaterial>();
        }

        public List<ModeloMaterial> Materiais
        {
            get => materiais;
        }

        //Obter todos os materiais
        public string GetAllMateriais()
        {

            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string q = "SELECT * FROM material";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(q, con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                string jsonString = string.Empty;
                jsonString = JsonConvert.SerializeObject(dt);
                con.Close();
                return jsonString;
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

        public string GetMaterialMaisUsado()
        {
            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string q = @"Select req.idMaterial, mat.nome, sum(qtd) as total from requisicaoMaterial as req
                        Inner Join material as mat on mat.idMaterial = req.idMaterial
                        GROUP BY req.idMaterial, mat.nome
                        ORDER BY total desc OFFSET 0 ROWS FETCH FIRST 5 ROWS ONLY";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(q, con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                string jsonString = string.Empty;
                jsonString = JsonConvert.SerializeObject(dt);
                con.Close();
                return jsonString;
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

        //Adicionar um material
        public string AddMaterial(ModeloMaterial s)
        {

            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string q = "INSERT INTO material (nome, custo) OUTPUT Inserted.idMaterial values('" + s.Nome + "', '" + s.Custo.ToString() + "')";

            try
            {
                //4º Execute INSERT
                SqlCommand com = new SqlCommand(q, con);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();

                string jsonString = string.Empty;
                string valor = reader[0].ToString();
                con.Close();
                return valor;
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


    }
}
