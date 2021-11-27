using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using System;

namespace ISIAPI
{
    public class ModeloRequisicao
    {
        private int idRequisicao;
        private bool entregue;
        private int equipa_idEquipa;

        [Required]
        public int Id { get => idRequisicao; set => idRequisicao = value; }
        public bool Entregue { get => entregue; set => entregue = value; }
        public int IdEquipa { get => equipa_idEquipa; set => equipa_idEquipa = value; }
    }

    public class ModeloRequisicoes
    {

        List<ModeloRequisicao> requisicoes;

        public ModeloRequisicoes()
        {
            if (requisicoes == null)
                requisicoes = new List<ModeloRequisicao>();
        }

        public List<ModeloRequisicao> Requisicoes
        {
            get => requisicoes;
        }

        //Obter todas as requisições
        public string GetAllRequisicoes()
        {

            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string q = "SELECT * FROM requisicao";
            SqlDataAdapter da = new SqlDataAdapter(q, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(dt);
            return jsonString;

        }

        //Adicionar uma equipa
        public string AddRequisicao(ModeloRequisicao s)
        {

            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);
            
            con.Open();
            string q = string.Empty;


            if (s.Entregue == true){
                q = "INSERT INTO requisicao (entregue, equipa_idEquipa) values(1, '"+ s.IdEquipa.ToString() +"')";
            }
            else
            {
                q = "INSERT INTO requisicao (entregue, equipa_idEquipa) values(0)";
            }
            

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
        public string GetRequisicaoById(int idRequisicao)
        {
            return "True";
        }



    }

}
