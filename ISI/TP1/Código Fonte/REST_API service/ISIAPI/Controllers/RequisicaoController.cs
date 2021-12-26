using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Newtonsoft.Json;

namespace ISIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisicaoController : ControllerBase
    {
        public ModeloRequisicoes m = new ModeloRequisicoes();

        /// <summary>
        /// Rota para devolver todas as requisições presentes na base de dados
        /// </summary>
        /// <returns string=Requisicao> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If it fails. </returns>
        [HttpGet]
        [Route("getall")]
        public string GetRequisicoes()
        {
            return m.GetAllRequisicoes();
        }

        /// <summary>
        /// Rota para adicionar uma requisicao
        /// </summary>
        /// <param name="requisicao">recebe uma variavel tipo json no formato {"idEquipa":id, "entregue":(true or false)}</param>
        /// <returns string="Success"> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If it fails. </returns>
        [HttpPost]
        [Route("addRequisicao")]
        public string AddRequisicao(string requisicao)
        {
            ModeloRequisicao requisicaoConvertido = Newtonsoft.Json.JsonConvert.DeserializeObject<ModeloRequisicao>(requisicao);
            return m.AddRequisicao(requisicaoConvertido);
        }

        /// <summary>
        /// Rota para devolver as requisições de uma equipa
        /// </summary>
        /// <param name="idEquipa"> recebe o id da equipa na rota</param>
        /// <returns string=Requisicoes> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If it fails. </returns>
        [HttpGet]
        [Route("getrequisicaobyequipa/{idEquipa}")]
        public string GetRequisicaoByEquipca(int idEquipa)
        {
            return m.GetRequisicaoByEquipa(idEquipa);
        }

        /// <summary>
        /// Rota para dar update ao estado de entregue de uma requisição
        /// </summary>
        /// <param name="idRequisicao"> Recebe o id da Requisição na rota</param>
        /// <returns string="Success"> If reaches end of function. </returns>
        /// <returns string="$EXCEPTION$"> If it fails. </returns>
        [HttpPut]
        [Route("updateEntregue/{idRequisicao}")]
        public string UpdateRequisicaoEntregue(int idRequisicao)
        {
            return m.UpdateRequisicao(idRequisicao);
        }



    }
}
