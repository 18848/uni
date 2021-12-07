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

        /// <summary>
        /// Obter todas as requisições de materiais através da base de dados
        /// </summary>
        /// <returns string=RequisicoesMateriais> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If it fails. </returns>
        public string GetAllRequisicoesMateriais()
        {

            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string q = "SELECT * FROM requisicaoMaterial";
            
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

        /// <summary>
        /// Adicionar uma RequisicãoMaterial
        /// </summary>
        /// <param ModeloRequisicaoMaterial="s"> recebe uma variável do tipo ModeloRequisicaoMaterial</param>
        /// <returns string="Success"> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If it fails. </returns>
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

        /// <summary>
        /// Devolver materiais para uma requisicao efetuada por uma equipa
        /// </summary>
        /// <param int=idRequisicao> recebe uma variavel do tipo int referente ao id da equipa</param>
        /// <returns string=Requisicao> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If it fails. </returns>
        public string GetRequisicaoMaterialByRequisicaoEquipa(int idRequisicao)
        {

            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string q = "SELECT  idRequisicao, reqMat.idMaterial, nome,  custo , reqMat.qtd FROM requisicaoMaterial AS reqMat INNER JOIN material ON material.idMaterial = reqMat.idMaterial WHERE idRequisicao = " + idRequisicao;
            
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


    }

}
