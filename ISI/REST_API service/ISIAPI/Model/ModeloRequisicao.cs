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
        private int idEquipa;

        [Required]
        public int Id { get => idRequisicao; set => idRequisicao = value; }
        public bool Entregue { get => entregue; set => entregue = value; }
        public int IdEquipa { get => idEquipa; set => idEquipa = value; }
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
                q = "INSERT INTO requisicao (entregue, idEquipa) OUTPUT Inserted.idRequisicao values(1, '" + s.IdEquipa.ToString() +"')";
            }
            else
            {
                q = "INSERT INTO requisicao (entregue, idEquipa) OUTPUT Inserted.idRequisicao values(0, '" + s.IdEquipa.ToString() + "')";
            }
            

            try
            {
                //4º Execute INSERT
                SqlCommand com = new SqlCommand(q, con);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();

                return reader[0].ToString();
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

        public string GetRequisicaoByEquipa(int idEquipa)
        {

            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string q = "Select * from requisicao where idEquipa = " + idEquipa.ToString();
            SqlDataAdapter da = new SqlDataAdapter(q, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(dt);
            return jsonString;
        }

        public string UpdateRequisicao(int idRequisicao)
        {
            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string q = "UPDATE requisicao SET requisicao.entregue = 1 WHERE idRequisicao = " + idRequisicao;

            try
            {
                //4º Execute INSERT
                SqlCommand com = new SqlCommand(q, con);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();

                return reader[0].ToString();
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
