using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using System;

namespace ISIAPI
{
    public class ModeloRequisicaoMaterial
    {
        private int idRequisicaoMaterial;
        private int idMaterial;
        private int idRequisicao;
        private int qtd;

        [Required]
        public int Id { get => idRequisicaoMaterial; set => idRequisicaoMaterial = value; }
        [Required]
        public int IdMaterial { get => idMaterial; set => idMaterial = value; }
        [Required]
        public int IdRequisicao { get => idRequisicao; set => idRequisicao = value; }
        public int Qtd { get => qtd; set => qtd = value; }
        
    }

    public class ModeloRequisicoesMateriais
    {

        List<ModeloRequisicaoMaterial> requisicoesMateriais;

        public ModeloRequisicoesMateriais()
        {
            if (requisicoesMateriais == null)
                requisicoesMateriais = new List<ModeloRequisicaoMaterial>();
        }

        public List<ModeloRequisicaoMaterial> RequisicoesMateriais
        {
            get => requisicoesMateriais;
        }

        //Obter todas as requisições de materiais
        public string GetAllRequisicoesMateriais()
        {

            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string q = "SELECT * FROM requisicaoMaterial";
            SqlDataAdapter da = new SqlDataAdapter(q, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(dt);
            return jsonString;

        }

        //Adicionar uma equipa
        public string AddRequisicaoMaterial(ModeloRequisicaoMaterial s)
        {

            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();
            string q = string.Empty;
            q = "INSERT INTO requisicaoMaterial (idMaterial, idRequisicao, qtd) values('" + s.IdMaterial.ToString() + "' , '" + s.IdRequisicao.ToString() + "', '" + s.Qtd.ToString() +"')";

            try
            {
                //4º Execute INSERT
                SqlCommand com = new SqlCommand(q, con);

                com.ExecuteNonQuery();

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
        public string GetRequisicaoMaterialById(int idRequisicaoMaterial)
        {
            return "True";
        }



    }

}
