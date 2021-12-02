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

        //Obter as 10 equipas cujo total de preços de requisições é o mais elevado
        public string GetEquipaMaisCara()
        {
            string conString = "Server=.;Database=ISI;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string q = @"Select * from (SELECT somaReq.idEquipa, somaReq.nome, sum(somaReq.total) as total
                        FROM (SELECT requisicao.idEquipa, nome, valores.idRequisicao, valores.total from equipa
                        Inner Join requisicao on requisicao.idEquipa = equipa.idEquipa
                        Inner Join (SELECT rm.idRequisicao,
		                SUM(rm.qtd * m.custo) as total
		                FROM requisicaoMaterial rm
		                JOIN material m ON m.idMaterial = rm.idMaterial
		                WHERE rm.idRequisicao = idRequisicao
		                GROUP BY rm.idRequisicao) as valores
		                on requisicao.idRequisicao = valores.idRequisicao) as somaReq
                        GROUP BY somaReq.idEquipa, somaReq.nome) as tabela 
                        ORDER BY tabela.total desc OFFSET 0 ROWS FETCH FIRST 10 ROWS ONLY";
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
